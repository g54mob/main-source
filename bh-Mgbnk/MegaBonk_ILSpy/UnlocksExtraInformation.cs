using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Upgrades;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.UI.Mouse;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class UnlocksExtraInformation : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<string> _003C_003E9__6_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CSetInfoWeapon_003Eb__6_0(string a, string b)
		{
			return string.Compare(a, b, StringComparison.Ordinal);
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public EStat stat;

		internal bool _003CSetCharacterInformation_003Eb__0(StatModifier x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if (x != null)
			{
				object obj = x.stat - stat;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public TextMeshProUGUI t_title;

	public TextMeshProUGUI t_info;

	public TextMeshProUGUI t_infoNumbers;

	public LocalizedString titleStringWeapons;

	public LocalizedString titleStringCharacters;

	private PlayerInventory dummyInventory;

	public void TrySetInfo(UnlockableBase unlockable)
	{
		//IL_0081: Expected I, but got O
		//IL_0089: Expected I, but got O
		//IL_0099: Expected O, but got I
		//IL_011b: Expected I, but got O
		//IL_012b: Expected O, but got I
		//IL_00d5: Expected O, but got I
		//IL_0167: Expected O, but got I
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		if (unlockable != null)
		{
			GameObject gameObject2 = t_infoNumbers.gameObject;
			gameObject2.SetActive(value: false);
			if ((object)unlockable != null)
			{
				nint num = (nint)typeof(WeaponData);
				nint num2 = (nint)unlockable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v10 (Il2CppClass<WeaponData>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v10 (Il2CppClass<WeaponData>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v18+FFFFFFF8+v236 @ rax_v13*8]");
					if (0 == (nint)typeof(WeaponData))
					{
						SetInfoWeapon((WeaponData)unlockable);
						return;
					}
				}
				nint num4 = (nint)typeof(CharacterData);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v11 (Il2CppClass<CharacterData>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v11 (Il2CppClass<CharacterData>)+130]");
				if (num5 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ r8_v7 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v16+FFFFFFF8+v198 @ rax_v15*8]");
					if (0 == (nint)typeof(CharacterData))
					{
						SetCharacterInformation((CharacterData)unlockable);
						return;
					}
				}
			}
		}
		GameObject gameObject3 = base.gameObject;
		gameObject3.SetActive(value: false);
	}

	public unsafe void SetInfoWeapon(WeaponData weaponData)
	{
		//IL_0413: Expected O, but got I
		//IL_0423: Expected O, but got I
		//IL_0058: Expected I4, but got O
		//IL_00b8: Expected I4, but got O
		//IL_0121: Expected O, but got I4
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected I4, but got Unknown
		//IL_022c: Expected I4, but got O
		//IL_0501: Expected I4, but got O
		//IL_032e: Expected O, but got I4
		//IL_0383: Expected I4, but got O
		//IL_03aa: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3+B8]");
		object obj2 = 0;
		string text = (string)obj2;
		List<string> list = new List<string>();
		string statName = LocalizationUtility.GetStatName(EStat.AttackSpeed);
		bool flag = list == null;
		EStat eStat = EStat.AttackSpeed;
		if (!flag)
		{
			int version = list._version + 1;
			list._version = version;
			eStat = (EStat)list._items;
			if (list._items != null)
			{
				int size = list._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v9 (Assets.Scripts.Menu.Shop.EStat)+18]");
				if ((nint)size >= (nint)0)
				{
					((List<object>)(object)list).AddWithResize((object)statName);
					eStat = (EStat)list;
				}
				else
				{
					int size2 = list._size + 1;
					list._size = size2;
					int size3 = list._size;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v9 (Assets.Scripts.Menu.Shop.EStat)+18]");
					if ((nint)size3 >= (nint)0)
					{
						throw new IndexOutOfRangeException();
					}
					object obj3 = list._size * 8;
					object obj4 = (object)list._items + obj3;
					eStat = (EStat)(obj4 + 32);
				}
				if ((object)weaponData != null)
				{
					UpgradeData upgradeData = weaponData.upgradeData;
					if ((object)weaponData.upgradeData != null && upgradeData.upgradeModifiers != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						List<object>.Enumerator enumerator = default(List<object>.Enumerator);
						EStat eStat2 = default(EStat);
						while (enumerator.MoveNext())
						{
							bool flag2 = eStat2 == EStat.MaxHealth;
							eStat = eStat2;
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ stack_-78 (Assets.Scripts.Menu.Shop.EStat)+10]");
								string statName2 = LocalizationUtility.GetStatName(EStat.MaxHealth);
								int version2 = list._version + 1;
								list._version = version2;
								eStat = (EStat)list._items;
								if (list._items != null)
								{
									int size4 = list._size;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v9 (Assets.Scripts.Menu.Shop.EStat)+18]");
									if ((nint)size4 >= (nint)0)
									{
										((List<object>)(object)list).AddWithResize((object)statName2);
										continue;
									}
									int size5 = list._size + 1;
									list._size = size5;
									int size6 = list._size;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v9 (Assets.Scripts.Menu.Shop.EStat)+18]");
									if ((nint)size6 < (nint)0)
									{
										continue;
									}
									throw new IndexOutOfRangeException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						((List<StatModifier>.Enumerator*)(&enumerator))->Dispose();
						Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__6_0;
						if (_003C_003Ec._003C_003E9__6_0 == null)
						{
							comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__6_0 = (string a, string b) => string.Compare(a, b, StringComparison.Ordinal));
						}
						((List<object>)(object)list).Sort(comparison);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
						while (enumerator2.MoveNext())
						{
							string text2 = text + "- " + (string)eStat2 + "\n";
							text = text2;
						}
						((List<string>.Enumerator*)(&enumerator2))->Dispose();
						bool flag3 = titleStringWeapons == null;
						eStat = (EStat)titleStringWeapons;
						if (!flag3)
						{
							TextMeshProUGUI textMeshProUGUI = t_title;
							string localizedString = titleStringWeapons.GetLocalizedString();
							bool flag4 = (object)t_title == null;
							eStat = (EStat)titleStringWeapons;
							if (!flag4)
							{
								t_title.text = localizedString;
								eStat = (EStat)t_info;
								if ((object)t_info != null)
								{
									int value__ = ((EStat*)(int)eStat)->value__;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v683 @ rax_v36 (System.Int32)+558] (should have been resolved before IL gen)");
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SetCharacterInformation(CharacterData characterData)
	{
		//IL_0052: Expected O, but got I
		//IL_0062: Expected O, but got I
		//IL_0086: Expected O, but got I
		//IL_0096: Expected O, but got I
		//IL_0134: Expected O, but got I
		//IL_018e: Expected O, but got I
		//IL_096f: Expected O, but got I
		//IL_01f8: Expected O, but got I
		//IL_09a3: Expected O, but got I
		//IL_0262: Expected O, but got I
		//IL_09cb: Expected O, but got I
		//IL_02cc: Expected O, but got I
		//IL_0308: Expected O, but got I4
		//IL_0327: Expected O, but got I4
		//IL_035b: Expected O, but got I4
		//IL_0372: Expected O, but got I4
		//IL_0397: Expected O, but got I4
		//IL_0a42: Invalid comparison between F4 and I4
		//IL_0763: Expected I, but got O
		//IL_079a: Expected O, but got I
		//IL_07ae: Expected I, but got O
		//IL_07d6: Expected O, but got I
		//IL_07fe: Expected O, but got I
		//IL_055a: Expected O, but got I
		GameObject gameObject = t_infoNumbers.gameObject;
		gameObject.SetActive(value: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rax_v8+B8]");
		object text = 0;
		t_info.text = (string)text;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v10+B8]");
		object text2 = 0;
		t_infoNumbers.text = (string)text2;
		if (dummyInventory != null)
		{
			dummyInventory.Cleanup();
			dummyInventory = null;
		}
		PlayerInventory playerInventory = new PlayerInventory(characterData, ignoreShopItems: true);
		dummyInventory = playerInventory;
		List<EStat> list = new List<EStat>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v13+18]");
		if (num >= 0)
		{
			list.AddWithResize(EStat.MaxHealth);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v16+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(EStat.MoveSpeedMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 25;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v18+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(EStat.JumpHeight);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 26;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v20+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(EStat.PickupRange);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v16 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 29;
		}
		List<EStat> list2 = new List<EStat>();
		List<EStat> list3 = new List<EStat>();
		list3._002Ector();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		EStat eStat = default(EStat);
		List<EStat>.Enumerator enumerator2 = default(List<EStat>.Enumerator);
		bool usePrefix = default(bool);
		string text10 = default(string);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (!ChallengesUi.IsNegativeModifier((StatModifier)eStat))
				{
					list3.Add(((StatModifier)eStat).stat);
				}
				else
				{
					if (eStat == EStat.MaxHealth)
					{
						break;
					}
					list2.Add(((StatModifier)eStat).stat);
				}
				if (!((List<System.Int32Enum>)(object)list).Contains((System.Int32Enum)((StatModifier)eStat).stat))
				{
					list.Add(((StatModifier)eStat).stat);
				}
				continue;
			}
			((List<StatModifier>.Enumerator*)(&enumerator))->Dispose();
			if (((List<System.Int32Enum>)(object)list).Contains((System.Int32Enum)27))
			{
				bool flag = ((List<System.Int32Enum>)(object)list).Remove((System.Int32Enum)27);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
			List<EStat> list4 = list2;
			while (true)
			{
				if (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass8_0();
					if (CS_0024_003C_003E8__locals7 != null)
					{
						CS_0024_003C_003E8__locals7.stat = eStat;
						float baseValue = PlayerStatsNew.GetBaseValue(eStat);
						PlayerInventory playerInventory2 = dummyInventory;
						if (dummyInventory != null)
						{
							if (playerInventory2.playerStats != null)
							{
								float rawStat = playerInventory2.playerStats.GetRawStat(CS_0024_003C_003E8__locals7.stat);
								string tooltipString = Tooltip.GetTooltipString(CS_0024_003C_003E8__locals7.stat, "#FFFFFF");
								string text3 = StatsUi.FormatStat(CS_0024_003C_003E8__locals7.stat, rawStat);
								float num5 = rawStat - baseValue;
								bool flag2 = text3 != null;
								string text4 = text3;
								if (!flag2)
								{
									text4 = "";
								}
								bool flag3 = num5 == 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018037B1F3h\"");
								string text5 = tooltipString;
								if (!flag3)
								{
									if (list4 == null)
									{
										throw new NullReferenceException();
									}
									string text6 = MyColorUtility.positiveColorString;
									if (((List<System.Int32Enum>)(object)list4).Contains((System.Int32Enum)CS_0024_003C_003E8__locals7.stat))
									{
										text6 = MyColorUtility.negativeColorString;
									}
									Predicate<StatModifier> match = (Predicate<object>)delegate(StatModifier x)
									{
										//IL_0053: Expected I4, but got O
										//IL_0031: Expected O, but got I4
										if (x == null)
										{
											NullReferenceException ex = new NullReferenceException();
											return (byte)(int)ex != 0;
										}
										object obj14 = x.stat - CS_0024_003C_003E8__locals7.stat;
										return obj14 == null;
									};
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ stack_10+60]");
									if ((nint)0 == 0)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ stack_10+60]");
									StatModifier statModifier = ((List<StatModifier>)0).Find(match);
									string[] array = new string[6];
									if (array == null)
									{
										throw new NullReferenceException();
									}
									if (array.Length <= 0)
									{
										break;
									}
									array[0] = text4;
									if (array.Length <= 1)
									{
										throw new IndexOutOfRangeException();
									}
									array[1] = " <color=";
									if (array.Length <= 2)
									{
										throw new IndexOutOfRangeException();
									}
									array[2] = text6;
									if (array.Length <= 3)
									{
										throw new IndexOutOfRangeException();
									}
									array[3] = ">(";
									if (statModifier == null)
									{
										throw new NullReferenceException();
									}
									string modificationString = StatUtility.GetModificationString(statModifier.modifyType, statModifier.stat, statModifier.modification, addOneToMultiplication: false, usePrefix);
									string text7 = StatUtility.EncapsulateNumber(modificationString, text6);
									if (array.Length <= 4)
									{
										throw new IndexOutOfRangeException();
									}
									array[4] = text7;
									if (array.Length <= 5)
									{
										throw new IndexOutOfRangeException();
									}
									array[5] = ")</color>";
									string text8 = string.Concat(array);
									text5 = tooltipString;
									text4 = text8;
								}
								if (titleStringCharacters != null)
								{
									nint num6 = (nint)t_title;
									string localizedString = titleStringCharacters.GetLocalizedString();
									if ((object)t_title != null)
									{
										object obj11 = num6;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1375 @ r9_v25+558] (should have been resolved before IL gen)");
										nint num7 = (nint)t_info;
										if ((object)t_info != null)
										{
											object obj12 = num7;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1874 @ rax_v81+548] (should have been resolved before IL gen)");
											string text9 = text10 + text5 + ": \n";
											object obj13 = num7;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1291 @ r9_v27+558] (should have been resolved before IL gen)");
											if ((object)t_infoNumbers != null)
											{
												string text11 = t_infoNumbers.text;
												string text12 = text11 + text4 + "\n";
												t_infoNumbers.text = text12;
												list4 = list2;
												continue;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				enumerator2.Dispose();
				return;
			}
			throw new IndexOutOfRangeException();
		}
		throw new NullReferenceException();
	}

	private void OnDestroy()
	{
		if (dummyInventory != null)
		{
			dummyInventory.Cleanup();
		}
		dummyInventory = null;
	}
}
