using System;
using System.IO;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
public class NamePip : MonoBehaviour
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
    public Vector3 axisData;
    private static NamedPipeClientStream pipeClient;
    private void Start()
    {
        try{ pipeClient = new NamedPipeClientStream(".", "UNITY_PIP", PipeDirection.InOut, PipeOptions.Asynchronous);}catch(Exception xpc){ Debug.LogError(xpc.Message);}
    }
    private void Update()
    {
        //axisData = new Vector3 (targetObject.rotation.x,targetObject.rotation.y,targetObject.rotation.z );
        axisData = new Vector3 (targetObject.eulerAngles.x, targetObject.eulerAngles.y, targetObject.eulerAngles.z );
        AxisX.text = axisData.x.ToString();
        AxisY.text = axisData.y.ToString();
        AxisZ.text = axisData.z.ToString();
        //SendDataAsync(axisData.ToString(), pipeClient);
    }
    public bool ConnectServerAsync()
    {
        try
        {
            pipeClient.ConnectAsync(2);
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
        using (var sr = new StreamWriter(clientStream))
        {
            try
            {
                sr.WriteAsync(input);
                sr.Dispose();
                sr.Close();
                return "SUCCES";
            }
            catch (Exception exp)
            {
                sr.Dispose();
                sr.Close();
                return "WriteAsync: "+exp.Message;
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
                sr.Dispose();
                sr.Close();
                return "SUCCES";
            }
            catch (Exception exp)
            {
                sr.Dispose();
                sr.Close();
                return "WriteLine: "+exp.Message;
            }
            
        }
    }
}
