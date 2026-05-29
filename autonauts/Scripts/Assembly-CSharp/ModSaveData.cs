using System;
using System.IO;
using MoonSharp.Interpreter;
using SimpleJSON;
using UnityEngine;

[MoonSharpUserData]
public class ModSaveData
{
	private JSONNode GetLoadData()
	{
		if (SaveLoadManager.Instance.m_LastFile.Length == 0)
		{
			return null;
		}
		Mod lastCalledMod = ModManager.Instance.GetLastCalledMod();
		string text = Application.persistentDataPath + "/ModSaves/" + lastCalledMod.Name + "_" + SaveLoadManager.Instance.m_LastFile + ".txt";
		if (!File.Exists(text))
		{
			return null;
		}
		string aJSON;
		try
		{
			aJSON = File.ReadAllText(text);
		}
		catch (UnauthorizedAccessException ex)
		{
			ErrorMessage.LogError("Summary Load - UnauthorizedAccessException : " + text + " " + ex.ToString());
			return null;
		}
		JSONNode jSONNode = JSON.Parse(aJSON);
		if (jSONNode == null)
		{
			return null;
		}
		return jSONNode;
	}

	public bool SaveValue(string Name, string Variable)
	{
		if (SaveLoadManager.Instance.m_LastFile.Length == 0)
		{
			return false;
		}
		Mod lastCalledMod = ModManager.Instance.GetLastCalledMod();
		string text = Application.persistentDataPath + "/ModSaves/" + lastCalledMod.Name + "_" + SaveLoadManager.Instance.m_LastFile + ".txt";
		if (!Directory.Exists(Path.Combine(Application.persistentDataPath, "ModSaves")))
		{
			Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "ModSaves"));
		}
		JSONNode jSONNode = GetLoadData();
		if (jSONNode == null)
		{
			jSONNode = new JSONObject();
		}
		JSONUtils.Set(jSONNode, Name, Variable);
		string contents = jSONNode.ToString();
		try
		{
			File.WriteAllText(text, contents);
		}
		catch (UnauthorizedAccessException ex)
		{
			ErrorMessage.LogError("Summary Save - UnauthorizedAccessException : " + text + " " + ex.ToString());
			return false;
		}
		return true;
	}

	public string LoadValue(string Name)
	{
		if (SaveLoadManager.Instance.m_LastFile.Length == 0)
		{
			return null;
		}
		Mod lastCalledMod = ModManager.Instance.GetLastCalledMod();
		string text = Application.persistentDataPath + "/ModSaves/" + lastCalledMod.Name + "_" + SaveLoadManager.Instance.m_LastFile + ".txt";
		if (!Directory.Exists(Path.Combine(Application.persistentDataPath, "ModSaves")))
		{
			Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "ModSaves"));
		}
		JSONNode loadData = GetLoadData();
		if (loadData == null)
		{
			return null;
		}
		return JSONUtils.GetAsString(loadData, Name, null);
	}

	public bool SaveValueInGroup(string Group, string Name, string Variable)
	{
		if (SaveLoadManager.Instance.m_LastFile.Length == 0)
		{
			return false;
		}
		Mod lastCalledMod = ModManager.Instance.GetLastCalledMod();
		string text = Application.persistentDataPath + "/ModSaves/" + lastCalledMod.Name + "_" + SaveLoadManager.Instance.m_LastFile + ".txt";
		if (!Directory.Exists(Path.Combine(Application.persistentDataPath, "ModSaves")))
		{
			Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "ModSaves"));
		}
		JSONNode jSONNode = GetLoadData();
		if (jSONNode == null)
		{
			jSONNode = new JSONObject();
		}
		JSONNode jSONNode2 = jSONNode[Group];
		if (jSONNode2 == null || jSONNode2.IsNull)
		{
			jSONNode[Group] = new JSONObject();
		}
		JSONUtils.Set(jSONNode[Group], Name, Variable);
		string contents = jSONNode.ToString();
		try
		{
			File.WriteAllText(text, contents);
		}
		catch (UnauthorizedAccessException ex)
		{
			ErrorMessage.LogError("Summary Save - UnauthorizedAccessException : " + text + " " + ex.ToString());
			return false;
		}
		return true;
	}

	public string LoadValueInGroup(string Group, string Name)
	{
		if (SaveLoadManager.Instance.m_LastFile.Length == 0)
		{
			return null;
		}
		Mod lastCalledMod = ModManager.Instance.GetLastCalledMod();
		string text = Application.persistentDataPath + "/ModSaves/" + lastCalledMod.Name + "_" + SaveLoadManager.Instance.m_LastFile + ".txt";
		if (!Directory.Exists(Path.Combine(Application.persistentDataPath, "ModSaves")))
		{
			Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "ModSaves"));
		}
		JSONNode loadData = GetLoadData();
		if (loadData == null || loadData.IsNull)
		{
			return null;
		}
		JSONNode jSONNode = loadData[Group];
		if (jSONNode == null || jSONNode.IsNull)
		{
			return null;
		}
		return JSONUtils.GetAsString(jSONNode, Name, null);
	}
}
