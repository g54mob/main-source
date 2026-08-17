using System;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts._Data.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Saves___Serialization.Progression.Achievements;

public class MyAchievement : ScriptableObject, IComparable<MyAchievement>
{
	public LocalizedString localizedName;

	public LocalizedString localizedDescription;

	public bool isEnabled;

	public bool isHidden;

	public string internalName;

	public string statName;

	public int targetValue;

	public float targetValueFloat;

	public string targetValueString;

	public Texture icon;

	public int sortingOrder;

	public EAchievementDifficulty difficulty;

	public EAchievementType achievementType;

	public List<LocalizationKey> serializedLocalizationKeys;

	public int achIteration;

	public bool useIterations;

	private UnlockableBase _003Cunlockable_003Ek__BackingField;

	public UnlockableBase unlockable
	{
		get
		{
			return _003Cunlockable_003Ek__BackingField;
		}
		private set
		{
			_003Cunlockable_003Ek__BackingField = value;
		}
	}

	public string GetUnlockDescription()
	{
		//IL_0040: Expected I, but got O
		//IL_00b2: Expected I, but got O
		//IL_00ea: Expected I, but got O
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0184: Expected I, but got O
		bool flag = localizedDescription == null;
		MyAchievement myAchievement = (MyAchievement)(object)localizedDescription;
		if (!flag)
		{
			if (localizedDescription.IsEmpty)
			{
				return "";
			}
			Dictionary<string, string> keys = GetKeys();
			bool flag2 = keys == null;
			nint num = unchecked((nint)null);
			if (!flag2)
			{
				int count = keys.Count;
				bool flag3 = count <= 0;
				num = 0;
				if (!flag3)
				{
					object[] array = new object[1];
					Dictionary<string, string> keys2 = GetKeys();
					bool flag4 = array == null;
					num = unchecked((nint)null);
					myAchievement = this;
					if (!flag4)
					{
						if (keys2 != null)
						{
							nint num2 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
							num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							object obj = default(object);
							bool flag5 = obj == null;
							myAchievement = (MyAchievement)(object)keys2;
							if (flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
								object obj2 = default(object);
								throw obj2;
							}
						}
						if (array.Length <= 0)
						{
							return (string)(object)new IndexOutOfRangeException();
						}
						myAchievement = (MyAchievement)(array + 32);
						array[0] = keys2;
						bool flag6 = localizedDescription == null;
						num = (nint)keys2;
						if (!flag6)
						{
							return localizedDescription.GetLocalizedString(array);
						}
					}
					goto IL_01ed;
				}
			}
			bool flag7 = localizedDescription == null;
			myAchievement = (MyAchievement)(object)localizedDescription;
			if (!flag7)
			{
				return localizedDescription.GetLocalizedString();
			}
		}
		goto IL_01ed;
		IL_01ed:
		throw new NullReferenceException();
	}

	public virtual string GetDisplayName()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831726A7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (localizedName != null)
		{
			bool isEmpty = localizedName.IsEmpty;
			if (!isEmpty)
			{
				if (useIterations == isEmpty)
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
		}
		return _003Cunlockable_003Ek__BackingField.GetName();
	}

	private unsafe Dictionary<string, string> GetKeys()
	{
		//IL_0064: Invalid comparison between F4 and I4
		//IL_010f: Expected Ref, but got F4
		//IL_001a: Invalid comparison between F4 and I4
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected I4, but got Unknown
		//IL_00c8: Expected F4, but got I4
		//IL_0188: Expected O, but got Ref
		//IL_01cc: Expected O, but got I
		//IL_0206: Expected O, but got I
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (targetValue == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180403C75h\"");
			if (targetValueFloat == 0f && string.IsNullOrEmpty(targetValueString))
			{
				goto IL_0142;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180403CB4h\"");
		object value;
		string text;
		if (targetValueFloat == 0f)
		{
			if (!string.IsNullOrEmpty(targetValueString))
			{
				if (dictionary == null)
				{
					goto IL_021b;
				}
				value = targetValueString;
				goto IL_0267;
			}
			int num = this + 64;
			text = ((int*)num)->ToString("N0");
			float num2 = num;
		}
		else
		{
			float num2 = (float)this + 68f;
			text = ((float*)num2)->ToString();
		}
		if (dictionary == null)
		{
			goto IL_021b;
		}
		value = text;
		goto IL_0267;
		IL_021b:
		throw new NullReferenceException();
		IL_0267:
		((Dictionary<object, object>)(object)dictionary).Add((object)"value", value);
		goto IL_0142;
		IL_0142:
		if (serializedLocalizationKeys != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			object obj = default(object);
			while (true)
			{
				if (enumerator.MoveNext())
				{
					bool flag = obj == null;
					LocalizedString localizedString = (LocalizedString)(&enumerator);
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ stack_-40+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ stack_-40+18]");
							string localizedString2 = ((LocalizedString)0).GetLocalizedString();
							if (dictionary == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ stack_-40+10]");
							((Dictionary<object, object>)(object)dictionary).Add((object)0, (object)localizedString2);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				((List<LocalizationKey>.Enumerator*)(&enumerator))->Dispose();
				return dictionary;
			}
			throw new NullReferenceException();
		}
		goto IL_021b;
	}

	public Texture GetIcon()
	{
		if (!(_003Cunlockable_003Ek__BackingField != null))
		{
			return icon;
		}
		if ((object)_003Cunlockable_003Ek__BackingField != null)
		{
			return _003Cunlockable_003Ek__BackingField.GetIcon();
		}
		return (Texture)(object)new NullReferenceException();
	}

	public bool IsUsingTargetValue()
	{
		//IL_0037: Invalid comparison between F4 and I4
		if (targetValue == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018040445Bh\"");
			if (targetValueFloat == 0f)
			{
				bool flag = string.IsNullOrEmpty(targetValueString);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
		}
		return true;
	}

	public bool IsTrackingStat()
	{
		bool flag = string.IsNullOrEmpty(statName);
		return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
	}

	public virtual string GetUnlockRequirement()
	{
		//IL_0040: Expected I, but got O
		//IL_00b2: Expected I, but got O
		//IL_00ea: Expected I, but got O
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0184: Expected I, but got O
		bool flag = localizedDescription == null;
		MyAchievement myAchievement = (MyAchievement)(object)localizedDescription;
		if (!flag)
		{
			if (localizedDescription.IsEmpty)
			{
				return "";
			}
			Dictionary<string, string> keys = GetKeys();
			bool flag2 = keys == null;
			nint num = unchecked((nint)null);
			if (!flag2)
			{
				int count = keys.Count;
				bool flag3 = count <= 0;
				num = 0;
				if (!flag3)
				{
					object[] array = new object[1];
					Dictionary<string, string> keys2 = GetKeys();
					bool flag4 = array == null;
					num = unchecked((nint)null);
					myAchievement = this;
					if (!flag4)
					{
						if (keys2 != null)
						{
							nint num2 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
							num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							object obj = default(object);
							bool flag5 = obj == null;
							myAchievement = (MyAchievement)(object)keys2;
							if (flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
								object obj2 = default(object);
								throw obj2;
							}
						}
						if (array.Length <= 0)
						{
							return (string)(object)new IndexOutOfRangeException();
						}
						myAchievement = (MyAchievement)(array + 32);
						array[0] = keys2;
						bool flag6 = localizedDescription == null;
						num = (nint)keys2;
						if (!flag6)
						{
							return localizedDescription.GetLocalizedString(array);
						}
					}
					goto IL_01ed;
				}
			}
			bool flag7 = localizedDescription == null;
			myAchievement = (MyAchievement)(object)localizedDescription;
			if (!flag7)
			{
				return localizedDescription.GetLocalizedString();
			}
		}
		goto IL_01ed;
		IL_01ed:
		throw new NullReferenceException();
	}

	public string GetUnlockedString()
	{
		if (!(_003Cunlockable_003Ek__BackingField != null))
		{
			return "";
		}
		if ((object)_003Cunlockable_003Ek__BackingField != null)
		{
			string unlockableTypeDisplayString = _003Cunlockable_003Ek__BackingField.GetUnlockableTypeDisplayString();
			if ((object)_003Cunlockable_003Ek__BackingField != null)
			{
				string text = _003Cunlockable_003Ek__BackingField.GetName();
				return "<sprite name=unlock> " + unlockableTypeDisplayString + " - " + text;
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetRewardString()
	{
		//IL_0043: Expected O, but got I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831726AB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = difficulty == EAchievementDifficulty.Easy;
		if (!flag)
		{
			object obj = difficulty - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag && (nint)obj2 != 1)
				{
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("Other", "SILVER");
		if (localizedStringReference != null)
		{
			string localizedString = localizedStringReference.GetLocalizedString();
			object arg = default(object);
			return $"<size=110%><sprite name=silver></size> {arg} {localizedString}";
		}
		return (string)(object)new NullReferenceException();
	}

	public void SetUnlockable(UnlockableBase unlockable)
	{
		_003Cunlockable_003Ek__BackingField = unlockable;
	}

	public bool IsCompleted()
	{
		return MyAchievements.IsUnlocked(this);
	}

	public bool IsClaimed()
	{
		//IL_00ad: Expected I4, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null && progression.claimedAchievements != null)
			{
				return ((HashSet<object>)(object)progression.claimedAchievements).Contains((object)internalName);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public float GetProgress()
	{
		//IL_0067: Invalid comparison between I4 and F4
		//IL_00aa: Expected F4, but got I4
		//IL_0039: Expected F4, but got I4
		if (string.IsNullOrEmpty(statName))
		{
			if (MyAchievements.IsUnlocked(this))
			{
				return 1f;
			}
			return 0f;
		}
		float stat = MyStats.GetStat(statName);
		float num = stat / (float)targetValue;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				return 1f;
			}
		}
		else
		{
			num = 0f;
		}
		return num;
	}

	public int GetCurrentValue()
	{
		if (string.IsNullOrEmpty(statName))
		{
			bool flag = MyAchievements.IsUnlocked(this);
			bool flag2 = !flag;
			return (!flag2) ? 1 : 0;
		}
		float stat = MyStats.GetStat(statName);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int result = default(int);
		return result;
	}

	public bool IsHiddenInMenus()
	{
		if (!isHidden)
		{
			return false;
		}
		bool flag = MyAchievements.IsUnlocked(this);
		return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
	}

	private void OnValidate()
	{
		string text = base.name;
		internalName = text;
	}

	public unsafe bool IsVisible()
	{
		//IL_024e: Expected I, but got O
		//IL_0253: Expected I, but got O
		//IL_0263: Expected O, but got I
		//IL_028f: Expected I, but got O
		//IL_0043: Expected I, but got O
		//IL_00af: Expected I, but got O
		//IL_00b7: Expected I, but got O
		//IL_00c7: Expected O, but got I
		//IL_00f3: Expected I, but got O
		//IL_02b2: Expected O, but got I
		//IL_02df: Expected I, but got O
		//IL_0116: Expected O, but got I
		//IL_0143: Expected I, but got O
		//IL_0310: Expected I, but got O
		//IL_015e: Expected I, but got O
		//IL_016e: Expected O, but got I
		//IL_017e: Expected O, but got I
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01b8: Expected I, but got O
		//IL_0526: Expected I, but got O
		//IL_01d0: Expected I, but got O
		//IL_038f: Expected I, but got O
		//IL_03ba: Expected O, but got I
		//IL_03d6: Expected I, but got O
		//IL_040d: Expected I, but got O
		//IL_0445: Expected O, but got I
		//IL_045d: Expected I, but got O
		//IL_0490: Expected O, but got I
		//IL_0561: Expected I, but got O
		if (!isEnabled)
		{
			goto IL_04d2;
		}
		if (isHidden)
		{
			bool flag = MyAchievements.IsUnlocked(this);
			bool flag2 = !flag;
			nint num = unchecked((nint)null);
			if (flag2)
			{
				goto IL_04d2;
			}
		}
		if (achievementType != EAchievementType.Skins)
		{
			goto IL_021e;
		}
		UnlockableBase unlockableBase = _003Cunlockable_003Ek__BackingField;
		bool flag3 = (object)_003Cunlockable_003Ek__BackingField == null;
		MyAchievement myAchievement = this;
		string requirementsString;
		if (!flag3)
		{
			nint num2 = (nint)typeof(SkinData);
			nint num = (nint)unlockableBase;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r8_v11 (Il2CppClass<SkinData>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v3 (Il2CppMethodInfo)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r8_v11 (Il2CppClass<SkinData>)+130]");
			bool flag4 = num3 < 0;
			nint num4 = (nint)typeof(SkinData);
			myAchievement = this;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v3 (Il2CppMethodInfo)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v28+FFFFFFF8+v289 @ rax_v27*8]");
				bool flag5 = 0 != (nint)typeof(SkinData);
				num4 = (nint)typeof(SkinData);
				myAchievement = this;
				if (!flag5)
				{
					nint num5 = (nint)unlockableBase;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r8_v11 (Il2CppClass<SkinData>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rax_v29 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v21+FFFFFFF8+v452 @ rdx_v13*8]");
					object obj5 = 0 - typeof(SkinData);
					bool flag6 = obj5 == null;
					bool flag7 = !flag6;
					num = unchecked((nint)null);
					if (!flag7)
					{
						num = (nint)_003Cunlockable_003Ek__BackingField;
					}
					bool flag8 = (object)DataManager.Instance == null;
					num4 = (nint)typeof(SkinData);
					myAchievement = this;
					if (!flag8)
					{
						DataManager instance = DataManager.Instance;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v3 (Il2CppMethodInfo)+60]");
						CharacterData characterData = instance.GetCharacterData(ECharacter.Fox);
						if (MyAchievements.IsUnlocked(characterData, out requirementsString))
						{
							goto IL_021e;
						}
						goto IL_04d2;
					}
				}
			}
		}
		goto IL_04d8;
		IL_04d2:
		return false;
		IL_021e:
		if (achievementType == EAchievementType.Challenges)
		{
			nint num6 = (nint)typeof(ChallengeData);
			nint num4 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rdx_v7 (Il2CppClass<ChallengeData>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r8_v2 (Il2CppClass<SkinData>)+130]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rdx_v7 (Il2CppClass<ChallengeData>)+130]");
			bool flag9 = num7 < 0;
			nint num = (nint)typeof(ChallengeData);
			myAchievement = this;
			if (!flag9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r8_v2 (Il2CppClass<SkinData>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v13+FFFFFFF8+v421 @ rax_v12*8]");
				bool flag10 = 0 != (nint)typeof(ChallengeData);
				num = (nint)typeof(ChallengeData);
				myAchievement = this;
				if (!flag10)
				{
					bool flag11 = (object)DataManager.Instance == null;
					num = (nint)typeof(ChallengeData);
					myAchievement = this;
					if (!flag11)
					{
						DataManager instance2 = DataManager.Instance;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement)+80]");
						MapData map = instance2.GetMap(EMap.None);
						if (!MyAchievements.IsUnlocked(map, out requirementsString))
						{
							goto IL_04d2;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
						object obj8 = default(object);
						bool flag12 = obj8 == null;
						num4 = unchecked((nint)null);
						num = (nint)(&requirementsString);
						myAchievement = this;
						if (!flag12)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v19+30]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v19+30]");
							bool flag13 = (nint)0 == 0;
							num4 = unchecked((nint)null);
							num = (nint)(&requirementsString);
							myAchievement = this;
							if (!flag13)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v20+50]");
								bool flag14 = (nint)0 == 0;
								num4 = unchecked((nint)null);
								num = (nint)(&requirementsString);
								myAchievement = this;
								if (!flag14)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v20+50]");
									nint num8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement)+80]");
									MapProgress mapProgress = ((MenuMeta)num8).GetMapProgress(EMap.None);
									bool flag15 = mapProgress == null;
									num4 = unchecked((nint)null);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement)+80]");
									num = 0;
									myAchievement = this;
									if (!flag15)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement)+84]");
										myAchievement = (MyAchievement)0;
										bool flag16 = mapProgress.completedTiers == null;
										num4 = unchecked((nint)null);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement)+80]");
										num = 0;
										if (!flag16)
										{
											List<int> completedTiers = mapProgress.completedTiers;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement)+84]");
											if (completedTiers.Contains(0))
											{
												goto IL_04cc;
											}
											goto IL_04d2;
										}
									}
								}
							}
						}
					}
					goto IL_04d8;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			bool result = default(bool);
			return result;
		}
		goto IL_04cc;
		IL_04d8:
		throw new NullReferenceException();
		IL_04cc:
		return true;
	}

	public bool IsUnlocked()
	{
		return MyAchievements.IsUnlocked(this);
	}

	public int GetSilverReward()
	{
		//IL_002f: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		bool flag = difficulty == EAchievementDifficulty.Easy;
		if (!flag)
		{
			object obj = difficulty - 1;
			if (flag)
			{
				return 2;
			}
			object obj2 = obj - 1;
			if (flag)
			{
				return 4;
			}
			if ((nint)obj2 == 1)
			{
				return 8;
			}
		}
		return 1;
	}

	public unsafe virtual int CompareTo(MyAchievement other)
	{
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected I4, but got Unknown
		//IL_016c: Expected O, but got I4
		//IL_029e: Expected I4, but got O
		//IL_01e1: Expected O, but got I4
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		int num;
		if ((object)this != other)
		{
			if ((object)other != null)
			{
				if (other.sortingOrder == sortingOrder)
				{
					if (_003Cunlockable_003Ek__BackingField != null && other._003Cunlockable_003Ek__BackingField != null)
					{
						if ((object)_003Cunlockable_003Ek__BackingField == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (int)ex;
						}
						num = _003Cunlockable_003Ek__BackingField.CompareTo(other._003Cunlockable_003Ek__BackingField);
						if (num != 0)
						{
							goto IL_00fb;
						}
					}
					num = string.Compare(internalName, other.internalName, StringComparison.Ordinal);
					if (num == 0)
					{
						bool flag = difficulty == EAchievementDifficulty.Easy;
						if (!flag)
						{
							object obj = difficulty - 1;
							if (!flag)
							{
								object obj2 = obj - 1;
								if (!flag && (nint)obj2 != 1)
								{
								}
							}
						}
						bool flag2 = other.difficulty == EAchievementDifficulty.Easy;
						int value = 1;
						if (!flag2)
						{
							object obj3 = other.difficulty - 1;
							if (!flag2)
							{
								object obj4 = obj3 - 1;
								if (!flag2)
								{
									bool flag3 = (nint)obj4 != 1;
									value = 1;
									if (!flag3)
									{
										value = 8;
									}
								}
								else
								{
									value = 4;
								}
							}
							else
							{
								value = 2;
							}
						}
						int num2 = default(int);
						num = num2.CompareTo(value);
						if (num == 0)
						{
							goto IL_025e;
						}
					}
					goto IL_00fb;
				}
				goto IL_025e;
			}
			return 1;
		}
		return 0;
		IL_00fb:
		return num;
		IL_025e:
		int num3 = this + 88;
		return ((int*)num3)->CompareTo(other.sortingOrder);
	}
}
