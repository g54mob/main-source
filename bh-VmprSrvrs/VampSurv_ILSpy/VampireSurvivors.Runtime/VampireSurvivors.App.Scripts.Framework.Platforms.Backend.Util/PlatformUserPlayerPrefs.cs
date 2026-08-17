using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;

public class PlatformUserPlayerPrefs
{
	public static string GetString(string key, string defaultValue = "")
	{
		string userSpecificKey = GetUserSpecificKey(key);
		return PlayerPrefs.GetString(userSpecificKey, defaultValue);
	}

	public static void SetString(string key, string value)
	{
		string userSpecificKey = GetUserSpecificKey(key);
		PlayerPrefs.SetString(userSpecificKey, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	public static void DeleteKey(string key)
	{
		string userSpecificKey = GetUserSpecificKey(key);
		PlayerPrefs.DeleteKey(userSpecificKey);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	private static string GetUserSpecificKey(string key)
	{
		SystemPlatform sInstance = SystemPlatform.sInstance;
		if (SystemPlatform.sInstance != null && sInstance.m_CurrentSystem != null)
		{
			string uniqueAccountID = sInstance.m_CurrentSystem.UniqueAccountID;
			return uniqueAccountID + key;
		}
		return (string)(object)new NullReferenceException();
	}
}
