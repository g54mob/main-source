using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Utils;

public static class DataUtils
{
	public static void PlayerPrefsSetInt(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}

	public static void PlayerPrefsSetFloat(string key, float value)
	{
		PlayerPrefs.SetFloat(key, value);
	}

	public static void PlayerPrefsSetString(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
	}

	public static int PlayerPrefsGetInt(string key)
	{
		return PlayerPrefs.GetInt(key, 0);
	}

	public static int PlayerPrefsGetInt(string key, int defaultValue)
	{
		return PlayerPrefs.GetInt(key, defaultValue);
	}

	public static float PlayerPrefsGetFloat(string key)
	{
		return PlayerPrefs.GetFloat(key, 0f);
	}

	public static float PlayerPrefsGetFloat(string key, float defaultValue)
	{
		return PlayerPrefs.GetFloat(key, defaultValue);
	}

	public static string PlayerPrefsGetString(string key)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999017]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return PlayerPrefs.GetString(key, "");
	}

	public static string PlayerPrefsGetString(string key, string defaultValue)
	{
		return PlayerPrefs.GetString(key, defaultValue);
	}

	public static void PlayerPrefsDeleteKey(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	public static void PlayerPrefsDeleteAll()
	{
		//IL_0006: Expected O, but got I
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ rax_v2 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	public static void PlayerPrefsSave()
	{
		//IL_0006: Expected O, but got I
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ rax_v2 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	public static bool PlayerPrefsHasKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}
}
