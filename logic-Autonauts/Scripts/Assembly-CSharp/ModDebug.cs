using System;
using System.IO;
using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class ModDebug
{
	public void Log(params object[] args)
	{
		Script lastCalledScript = ModManager.Instance.GetLastCalledScript();
		Mod lastCalledMod = ModManager.Instance.GetLastCalledMod();
		if (lastCalledMod == null || !lastCalledMod.IsLocal)
		{
			return;
		}
		string text = "";
		DynValue[] array = new DynValue[args.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = DynValue.FromObject(lastCalledScript, args[i]);
			text += array[i];
		}
		text = text.Replace("\"", "");
		string text2 = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\ModLog.txt";
		try
		{
			File.AppendAllText(text2, text + "\n");
		}
		catch (UnauthorizedAccessException ex)
		{
			ErrorMessage.LogError("Summary Save - UnauthorizedAccessException : " + text2 + " " + ex.ToString());
		}
	}

	public void ClearLog()
	{
		string path = Path.Combine(Application.streamingAssetsPath, "Mods") + "\\ModLog.txt";
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}
}
