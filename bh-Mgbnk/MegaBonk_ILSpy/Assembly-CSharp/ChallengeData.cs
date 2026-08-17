using System;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

public class ChallengeData : MyAchievement
{
	public EMap map;

	public int tier;

	public float silverMultiplier = 1f;

	public string suggestionAuthor;

	public int requiresNumChallengesCompleted;

	public ChallengeData prerequisiteChallenge;

	public ChallengeModifier[] challengeModifiers;

	public ChallengeWinCondition winCondition;

	public override string GetDisplayName()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172181]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (localizedName != null && !localizedName.IsEmpty)
		{
			if (tier <= 0)
			{
				return localizedName.GetLocalizedString();
			}
			if (localizedName != null)
			{
				string localizedString = localizedName.GetLocalizedString();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				string text = $" {arg}";
				return localizedString + text;
			}
			return (string)(object)new NullReferenceException();
		}
		return base._003Cunlockable_003Ek__BackingField.GetName();
	}

	public unsafe override string GetUnlockRequirement()
	{
		//IL_008b: Expected I4, but got O
		//IL_00a1: Expected I, but got O
		//IL_00ba: Expected O, but got I
		//IL_00e2: Expected O, but got I
		//IL_00ea: Expected I4, but got O
		//IL_0418: Expected O, but got I4
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected I4, but got Unknown
		//IL_01aa: Expected O, but got I4
		//IL_01b8: Expected I4, but got O
		//IL_0209: Expected I, but got O
		//IL_0237: Expected O, but got I
		//IL_0240: Expected I4, but got O
		//IL_0281: Expected O, but got I4
		//IL_028a: Expected I4, but got O
		LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("Other", "TIER_SMART");
		object[] array = new object[1];
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary._002Ector();
		int num = default(int);
		string text = num.ToString();
		bool flag = dictionary == null;
		object obj = null;
		object obj2 = null;
		int num2 = (int)(&num);
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"tier", (object)text);
			bool flag2 = array == null;
			obj = text;
			obj2 = "tier";
			num2 = (int)dictionary;
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text);
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				obj = text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
				obj2 = 0;
				num2 = (int)dictionary;
				if (flag3)
				{
					((Dictionary<string, string>)num2).Add((string)obj2, (string)obj);
					object obj4 = default(object);
					throw obj4;
				}
				if (array.Length <= 0)
				{
					goto IL_0423;
				}
				num2 = array + 32;
				array[0] = dictionary;
				bool flag4 = localizedStringReference == null;
				obj = text;
				obj2 = dictionary;
				if (!flag4)
				{
					string localizedString = localizedStringReference.GetLocalizedString(array);
					string[] array2 = new string[6];
					bool flag5 = array2 == null;
					obj = null;
					obj2 = 6;
					num2 = (int)typeof(string[]);
					if (!flag5)
					{
						if (array2.Length <= 0)
						{
							goto IL_0423;
						}
						array2[0] = "[";
						nint num4 = (nint)typeof(DataManager);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v19 (Il2CppClass<DataManager>)+B8]");
						nint num5 = 0;
						bool flag6 = (object)DataManager.Instance == null;
						obj = null;
						obj2 = num5;
						num2 = (int)DataManager.Instance;
						if (!flag6)
						{
							MapData mapData = DataManager.Instance.GetMap(map);
							bool flag7 = (object)mapData == null;
							obj = null;
							obj2 = map;
							num2 = (int)DataManager.Instance;
							if (!flag7)
							{
								string text2 = mapData.GetName();
								if (array2.Length > 1)
								{
									array2[1] = text2;
									if (array2.Length > 2)
									{
										array2[2] = " ";
										if (array2.Length > 3)
										{
											array2[3] = localizedString;
											if (array2.Length > 4)
											{
												array2[4] = " - ";
												string displayName = GetDisplayName();
												if (array2.Length > 5)
												{
													array2[5] = displayName;
													return string.Concat(array2);
												}
											}
										}
									}
								}
								goto IL_0423;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0423:
		return (string)(object)new IndexOutOfRangeException();
	}

	public unsafe bool CanShow()
	{
		//IL_005e: Expected O, but got Ref
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected I4, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected I4, but got Unknown
		if (prerequisiteChallenge != null)
		{
			bool flag = MyAchievements.IsUnlocked(prerequisiteChallenge);
			if (!flag)
			{
				return flag;
			}
		}
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		float stat = MyStats.GetStat(text);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj2 = text - requiresNumChallengesCompleted;
		int num = text ^ requiresNumChallengesCompleted;
		object obj3 = (object)text ^ obj2;
		int num2 = num & obj3;
		bool flag2 = num2 < 0;
		bool flag3 = (nint)obj2 < 0;
		return flag3 == flag2;
	}

	public string GetSilverMultiplier()
	{
		return MyStringUtil.ShowOnlyDecimals(silverMultiplier);
	}

	public unsafe override int CompareTo(MyAchievement otherAch)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_024e: Expected I4, but got O
		//IL_0071: Expected O, but got I
		//IL_0106: Expected I4, but got O
		//IL_0117: Expected O, but got Ref
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected I4, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected I4, but got Unknown
		//IL_01e4: Expected O, but got I
		UnityEngine.Object obj;
		if ((object)otherAch == null)
		{
			obj = null;
			goto IL_00ab;
		}
		nint num = (nint)typeof(ChallengeData);
		nint num2 = (nint)otherAch;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v11 (Il2CppClass<ChallengeData>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v10 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v11 (Il2CppClass<ChallengeData>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v10 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v20+FFFFFFF8+v50 @ rax_v17*8]");
			if (0 == (nint)typeof(ChallengeData))
			{
				obj = otherAch;
				goto IL_00ab;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0240;
		IL_0240:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_00ab:
		if (obj != null)
		{
			if ((object)this != obj)
			{
				if ((object)obj != null)
				{
					object obj4 = default(object);
					object target = (EMap)obj4;
					IntPtr intPtr = default(IntPtr);
					int num4 = ((Enum)(&intPtr)).CompareTo(target);
					if (num4 == 0)
					{
						int num5 = this + 132;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v2 (UnityEngine.Object)+84]");
						num4 = ((int*)num5)->CompareTo(0);
						if (num4 == 0)
						{
							int num6 = this + 88;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v2 (UnityEngine.Object)+58]");
							num4 = ((int*)num6)->CompareTo(0);
							if (num4 == 0)
							{
								string strA = internalName;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rbx_v2 (UnityEngine.Object)+30]");
								num4 = string.Compare(strA, (string)0, StringComparison.Ordinal);
							}
						}
					}
					return num4;
				}
				goto IL_0240;
			}
			return 0;
		}
		return base.CompareTo(otherAch);
	}
}
