using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Info_tc : EditorWindow
{
	public string text;

	public float label_old;

	public bool foldout;

	public Color backgroundColor;

	public bool backgroundActive;

	public global_settings_tc global_script;

	public Vector2 scrollPos;

	public int update_height;

	public EditorWindow parent;

	public Info_tc()
	{
		this.foldout = true;
		this.backgroundActive = true;
	}

	public static void ShowWindow()
	{
		EditorWindow window = EditorWindow.GetWindow(typeof(Info_tc));
		window.titleContent = new GUIContent("Update");
	}

	public void OnDisable()
	{
		if (this.parent)
		{
			this.parent.Repaint();
		}
	}

	public void OnGUI()
	{
		GUI.color = Color.white;
		this.scrollPos = EditorGUILayout.BeginScrollView(this.scrollPos, new GUILayoutOption[]
		{
			GUILayout.Width(position.width),
			GUILayout.Height(position.height)
		});
		EditorGUILayout.BeginHorizontal(new GUILayoutOption[0]);
		EditorGUILayout.LabelField(this.text, new GUILayoutOption[]
		{
			GUILayout.Height((float)this.update_height)
		});
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.EndScrollView();
	}
}
