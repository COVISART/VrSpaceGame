using System;
using System.IO;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEditor;

public class NamedPipe : MonoBehaviour
{
    /*
    * public NamedPipeClientStream (
    * string serverName, 
    * string pipeName, 
    * System.IO.Pipes.PipeDirection direction, 
    * System.IO.Pipes.PipeOptions options);
    */
    public Transform targetObject;
    public Text AxisX, AxisY, AxisZ;
    public float x, y, z;
    public Quaternion VrCameraLocal, VrCameraGlobar, VrCameraEulerAngles;
    private static NamedPipeClientStream pipeClient;
    void Awake()
    {
        InputTracking.Recenter();
        InputTracking.disablePositionalTracking = true;
    }

    private void Update()
    {
        VrCameraLocal = new Quaternion(targetObject.localRotation.x , targetObject.localRotation.y, targetObject.localRotation.z, 1);
        VrCameraGlobar = new Quaternion(targetObject.rotation.x, targetObject.rotation.y, targetObject.rotation.z, 1);
        VrCameraEulerAngles = new Quaternion(targetObject.localEulerAngles.x, targetObject.localEulerAngles.y, targetObject.localEulerAngles.z, 1);

        try
        {
            var ret =SendOfData((VrCameraEulerAngles.x + "/" + VrCameraEulerAngles.z).ToString());
            //Debug.Log(ret);
        }
        catch (Exception exp)
        {
            Debug.LogError(exp.Message);
        }
        
    }
    private static string SendOfData(string input)
    {
        string output;
        using (var pipeClient = new NamedPipeClientStream(".", "UNITY_PIP", PipeDirection.InOut))
        {
            try
            {
                pipeClient.Connect(2);
            }
            catch (Exception exp)
            {
                pipeClient.Close();
                return exp.Message + ": Connection";
            }

            using (var sr = new StreamWriter(pipeClient))
            {
                try
                {
                    sr.WriteLine(input);
                    output = "Succes";
                }
                catch (Exception exp)
                {
                    output = exp.Message + ": WriteLine";
                }
                sr.Close();
            }
            pipeClient.Close();
        }
        return output;
    }

    #region Old Garbage, Must Fix
    public async System.Threading.Tasks.Task<bool> ConnectServerAsync()
    {
        try
        {
            await pipeClient.ConnectAsync(2);
            return true;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    public bool ConnectServer()
    {
        try
        {
            pipeClient.Connect(2);
            return true;
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    private static string SendDataAsync(string input, NamedPipeClientStream clientStream)
    {
        Debug.Log(input);
        using (var sr = new StreamWriter(clientStream))
        {
            try
            {
                sr.WriteAsync(input);
                sr.Close();
                return "SUCCES";
            }
            catch (Exception exp)
            {
                sr.Close();
                return "WriteAsync: " + exp.Message;
            }
            
        }
    }
    private static string SendData(string input, NamedPipeClientStream clientStream)
    {
        using (var sr = new StreamWriter(clientStream))
        {
            try
            {
                sr.WriteLine(input);
                sr.Close();
                Debug.Log("Data Has been send");
                return "SUCCES";
            }
            catch (Exception exp)
            {
                sr.Close();
                Debug.Log("Data Has not been send:"+ exp.Message);
                return "WriteLine: " + exp.Message;
            }

        }
    }
    #endregion
}
