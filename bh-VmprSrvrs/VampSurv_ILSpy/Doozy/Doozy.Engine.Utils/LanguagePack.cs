using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Utils;

[Serializable]
public class LanguagePack : ScriptableObject
{
	private const string CURRENT_LANGUAGE_PREFS_KEY = "Doozy.CurrentLanguage";

	public const Language DEFAULT_LANGUAGE = Language.English;

	private static Language s_currentLanguage;

	public static Language CurrentLanguage
	{
		get
		{
			if (s_currentLanguage == Language.Unknown)
			{
				int value = PlayerPrefs.GetInt("Doozy.CurrentLanguage", 1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980627]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				PlayerPrefs.SetInt("Doozy.CurrentLanguage", value);
				PlayerPrefs.Save();
				s_currentLanguage = (Language)value;
				return s_currentLanguage;
			}
			return s_currentLanguage;
		}
		set
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980627]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PlayerPrefs.SetInt("Doozy.CurrentLanguage", (int)value);
			PlayerPrefs.Save();
			s_currentLanguage = value;
		}
	}

	private static void SaveLanguagePreference(Language language)
	{
		//IL_0047: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980627]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PlayerPrefs.SetInt("Doozy.CurrentLanguage", (int)language);
		object obj = 0;
		string text = "Doozy.CurrentLanguage";
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v47 @ rax_v4 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	private static void SaveLanguagePreference(string prefsKey, Language language)
	{
		//IL_0013: Expected O, but got I
		string key = default(string);
		PlayerPrefs.SetInt(key, (int)language);
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ rax_v3 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}
}
