using System;
using System.IO;
using Crosstales.FB;
using UnityEngine;

public class Procedural : MonoBehaviour
{
	public static LuaBridge bridge = new LuaBridge();

	public static string lastPath;

	private void Awake()
	{
		bridge.AddObject("forge", new Forge());
	}

	public static void Execute(string path)
	{
		StreamReader streamReader = new StreamReader(path);
		string code = streamReader.ReadToEnd();
		streamReader.Close();
		try
		{
			bridge.ExecuteCode(code);
		}
		catch (Exception ex)
		{
			Global.ShowMessage(ex.Message, 4f);
			Debug.Log("Error: " + ex);
		}
	}

	public static void ExecuteString(string script)
	{
		bridge.ExecuteCode(script);
	}

	public static void LoadLua()
	{
		ExtensionFilter extensionFilter = new ExtensionFilter("Script (Lua)", "lua");
		string text = FileBrowser.OpenSingleFile(null, null, extensionFilter);
		if (text != "")
		{
			lastPath = text;
			Menubar.Enable("Script/repeat");
			Execute(text);
		}
	}

	public static void RepeatLua()
	{
		if (lastPath != null)
		{
			Execute(lastPath);
		}
	}

	public static Vector3 ParseVector(float[] i)
	{
		return new Vector3(i[0], i[1], i[2]);
	}

	public static float[] UnparseVector(Vector3 i)
	{
		return new float[3] { i.x, i.y, i.z };
	}

	public static string[] ParseBlock(string b)
	{
		return b.Split("/"[0]);
	}
}
