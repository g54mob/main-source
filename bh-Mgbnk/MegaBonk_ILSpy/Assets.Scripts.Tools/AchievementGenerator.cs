using System;
using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Saves___Serialization.Progression;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Tools;

public class AchievementGenerator : MonoBehaviour
{
	public LocalizedString stageBossLocalizedKey;

	public LocalizedString tierLocalizedKey;

	public LocalizedString finalBossLocalizedKey;

	public LocalizedString rankLocalizedKey;

	public LocalizedString localizedKills;

	public LocalizedString localizedLevel;

	public LocalizedString localizedFinalBoss;

	public LocalizedString localizedSpeedrun;

	public LocalizedString localizedGold;

	public DataManager dataManager;

	private static Dictionary<(ECharacter, ESkinType), string> skinAchievementNameCache;

	private string GetPath()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317256D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "Assets/Scripts/_Data/Progression/Achievements/Skins";
	}

	public static int GetSkinAchValue(ESkinType skinType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 14 Invalid \"Jump target not found in method: 0x1803D6D9B\"");
		return (int)(skinType - 1);
	}

	private string GetSkinAchValueStat(ESkinType skinType, ECharacter character)
	{
		//IL_0058: Expected O, but got I4
		//IL_0013: Expected O, but got I4
		//IL_0020: Expected O, but got I8
		//IL_003a: Expected O, but got I8
		object obj = skinType - 1;
		if ((nint)obj <= 5)
		{
			object obj2 = skinType - 1;
			object obj3 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rdx_v1+3D6D2C+v50 @ rax_v5*4]");
			object obj4 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ rax_v7 (should have been resolved before IL gen)");
		}
		return "";
	}

	private LocalizedString GetLocalizedDescription(ESkinType skinType)
	{
		//IL_000e: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_0046: Expected O, but got I8
		//IL_0060: Expected O, but got I8
		object obj = skinType - 1;
		if ((nint)obj <= 5)
		{
			object obj2 = skinType - 1;
			object obj3 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8_v1+3D67CC+v15 @ rax_v3*4]");
			object obj4 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ rax_v5 (should have been resolved before IL gen)");
		}
		return null;
	}

	private List<LocalizationKey> GetLocalizedKeys(ESkinType skinType, CharacterData characterData)
	{
		//IL_001d: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 54 Invalid \"Jump target not found in method: 0x1803D6B06\"");
		return (List<LocalizationKey>)(skinType - 1);
	}

	public unsafe static string GetSkinAchievementName(ECharacter character, ESkinType skinType)
	{
		//IL_0018: Expected O, but got I4
		//IL_0033: Expected O, but got Ref
		//IL_0090: Expected O, but got Ref
		//IL_00e2: Expected I4, but got O
		//IL_0119: Expected O, but got I4
		(ECharacter, ESkinType) tuple = (character, skinType);
		string text5 = default(string);
		if (!((Dictionary<(System.Int32Enum, System.Int32Enum), object>)(object)skinAchievementNameCache).TryGetValue(((System.Int32Enum, System.Int32Enum))0, out object _))
		{
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			if (text != null)
			{
				char c = text.get_Chars(0);
				char c2 = char.ToLower(c);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814478A0");
				IntPtr intPtr = default(IntPtr);
				string text2 = ((Enum)(&intPtr)).ToString();
				if (text2 != null)
				{
					string text3 = text2.Substring(1);
					string text4 = default(string);
					string arg = text4 + text3;
					object obj2 = default(object);
					object arg2 = (ESkinType)obj2;
					text5 = $"a_skin_{arg}{arg2}";
					if (skinAchievementNameCache != null)
					{
						((Dictionary<(System.Int32Enum, System.Int32Enum), object>)(object)skinAchievementNameCache).set_Item(((System.Int32Enum, System.Int32Enum))0, (object)text5);
						goto IL_011e;
					}
				}
			}
			return (string)(object)new NullReferenceException();
		}
		goto IL_011e;
		IL_011e:
		return text5;
	}

	private static EAchievementDifficulty GetSkinDifficulty(ESkinType skinType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 14 Invalid \"Jump target not found in method: 0x1803D704A\"");
		return (EAchievementDifficulty)(skinType - 1);
	}

	static AchievementGenerator()
	{
		Dictionary<(ECharacter, ESkinType), string> dictionary = (Dictionary<(ECharacter, ESkinType), string>)(object)new Dictionary<(System.Int32Enum, System.Int32Enum), object>();
		skinAchievementNameCache = dictionary;
	}
}
