using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.GoldAndMoney;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.UI.InGame.Rewards.Effects;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

namespace Assets.Scripts.UI.InGame.Rewards;

[Serializable]
public class EffectStat
{
	public EEncounterEffect effectType;

	public StatModifier statModifier;

	public bool permanent = true;

	public float duration;

	public float value;

	public bool isPositiveEffect = true;

	public unsafe string GetDescription()
	{
		//IL_0043: Expected O, but got I4
		//IL_0449: Invalid comparison between I4 and F4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0394: Invalid comparison between I4 and F4
		//IL_075b: Expected O, but got Ref
		//IL_0785: Expected O, but got I4
		//IL_0793: Expected I, but got O
		//IL_00e3: Expected O, but got I4
		//IL_00f1: Expected I, but got O
		//IL_0520: Expected O, but got Ref
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected I, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected I, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected I, but got Unknown
		//IL_05a3: Expected I, but got O
		//IL_05b3: Expected O, but got I
		//IL_05c8: Expected O, but got I
		//IL_05e3: Expected I, but got O
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected I, but got Unknown
		//IL_0806: Expected O, but got I
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected I, but got Unknown
		string statTextColor = MyColorUtility.GetStatTextColor(isPositiveEffect);
		bool flag = effectType == EEncounterEffect.StatChange;
		string text;
		string text6;
		string text7;
		string text8;
		string text10;
		if (!flag)
		{
			object obj = effectType - 1;
			object obj3 = default(object);
			float num2 = default(float);
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						text = "No description defined u oh";
						goto IL_0439;
					}
					StatModifier statModifier = this.statModifier;
					if (this.statModifier != null)
					{
						string text2 = ((Enum)(&obj3)).ToString();
						string[] array = new string[7];
						bool flag2 = array == null;
						string text3 = (string)7;
						nint num = (nint)typeof(string[]);
						if (!flag2)
						{
							bool flag3 = array.Length <= 0;
							text3 = (string)7;
							num = (nint)typeof(string[]);
							if (!flag3)
							{
								num = (nint)(array + 32);
								array[0] = "<link=\"";
								bool flag4 = array.Length <= 1;
								text3 = "<link=\"";
								if (!flag4)
								{
									num = (nint)(array + 40);
									array[1] = text2;
									bool flag5 = array.Length <= 2;
									text3 = text2;
									if (!flag5)
									{
										num = (nint)(array + 48);
										array[2] = "\"><color=";
										bool flag6 = array.Length <= 3;
										text3 = "\"><color=";
										if (!flag6)
										{
											num = (nint)(array + 56);
											array[3] = "#ffe88a";
											bool flag7 = array.Length <= 4;
											text3 = "#ffe88a";
											if (!flag7)
											{
												array[4] = ">";
												string text4 = EnumUtility.EnumToReadable(statModifier.stat);
												bool flag8 = array.Length <= 5;
												text3 = null;
												num = (nint)statModifier.stat;
												if (!flag8)
												{
													num = (nint)(array + 72);
													array[5] = text4;
													bool flag9 = array.Length <= 6;
													text3 = text4;
													if (!flag9)
													{
														array[6] = "</color></link>";
														string text5 = string.Concat(array);
														StatModifier statModifier2 = this.statModifier;
														if (this.statModifier == null)
														{
															goto IL_0744;
														}
														if (statModifier2.modification < 1f)
														{
															text6 = " <color=red>(-0.5x)</color>";
															text7 = text5;
															text8 = "Halve ";
														}
														else
														{
															text6 = " <color=green>(+2.0x)</color>";
															text7 = text5;
															text8 = "Double ";
														}
														goto IL_07ad;
													}
												}
											}
										}
									}
								}
							}
							throw new IndexOutOfRangeException();
						}
						throw new NullReferenceException();
					}
					goto IL_0744;
				}
				if (!(0f > value))
				{
					string text9 = num2.ToString();
					string number = text9 + "%";
					text10 = StatUtility.EncapsulateNumber(number, statTextColor);
					text6 = " HP of max HP";
					text8 = "Heal ";
					goto IL_07c7;
				}
				string text11 = num2.ToString();
				string number2 = text11 + "%";
				text10 = StatUtility.EncapsulateNumber(number2, statTextColor);
				text6 = " HP of max HP";
			}
			else
			{
				if (!(0f > value))
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					if (dictionary != null)
					{
						((Dictionary<object, object>)(object)dictionary).Add((object)"gold_icon", (object)"<size=110%><sprite name=gold></size>");
						float num3 = GetValue();
						string text12 = num2.ToString();
						if (text12 == null)
						{
							text12 = "";
						}
						((Dictionary<object, object>)(object)dictionary).Add((object)"gold_amount", (object)text12);
						LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
						TableReference tableReference = "Game_Ui";
						if (stringDatabase != null)
						{
							DetailedLocalizationTable<StringTableEntry> table = stringDatabase.GetTable((TableReference)(&obj3));
							if ((object)table != null)
							{
								StringTableEntry entry = table.GetEntry("SHRINE_GREEDY_GOLD");
								if (entry != null)
								{
									object[] array2 = new object[1];
									if (array2 == null)
									{
										goto IL_0744;
									}
									nint num4 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ rdx_v27 (Il2CppClass<System.Object[]>)+40]");
									string text3 = (string)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ rdx_v27 (Il2CppClass<System.Object[]>)+40]");
									StringTableEntry entry2 = ((DetailedLocalizationTable<StringTableEntry>)(object)dictionary).GetEntry((string)0);
									bool flag10 = entry2 == null;
									nint num = (nint)dictionary;
									if (flag10)
									{
										StringTableEntry entry3 = ((DetailedLocalizationTable<StringTableEntry>)num).GetEntry(text3);
										throw entry3;
									}
									array2[0] = dictionary;
									text = entry.GetLocalizedString(array2);
									if (text != null)
									{
										goto IL_0439;
									}
								}
							}
							text = "Missing localization for " + "Game_Ui" + "." + "SHRINE_GREEDY_GOLD";
							goto IL_0439;
						}
					}
					goto IL_0744;
				}
				text10 = StatUtility.EncapsulateNumber(value, statTextColor);
				text6 = " gold";
			}
			text8 = "Lose ";
			goto IL_07c7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172532]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!permanent)
		{
			string upgradeDescriptionStat = StatUtility.GetUpgradeDescriptionStat(this.statModifier, statTextColor);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			return $"{upgradeDescriptionStat} for {arg} seconds";
		}
		string upgradeDescriptionStat2 = StatUtility.GetUpgradeDescriptionStat(this.statModifier, statTextColor);
		bool flag11 = upgradeDescriptionStat2 == null;
		string result = "";
		if (!flag11)
		{
			result = upgradeDescriptionStat2;
		}
		return result;
		IL_0744:
		return (string)(object)new NullReferenceException();
		IL_07c7:
		text7 = text10;
		goto IL_07ad;
		IL_0439:
		return text;
		IL_07ad:
		text = text8 + text7 + text6;
		goto IL_0439;
	}

	private float GetValue()
	{
		//IL_0185: Expected F4, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_0107: Expected O, but got I4
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		if (effectType != EEncounterEffect.EGold)
		{
			return value;
		}
		float[] array = new float[1];
		int chestPrice = MoneyUtility.GetChestPrice();
		if (array.Length > 0)
		{
			float num = (array[0] = (float)chestPrice * value);
			float result;
			if (array.Length != 0)
			{
				object obj = 1 - array.Length;
				object obj2 = 1 ^ array.Length;
				object obj3 = 1 ^ obj;
				object obj4 = obj2 & obj3;
				bool flag = (nint)obj4 < 0;
				bool flag2 = (nint)obj < 0;
				bool flag3 = 1 >= array.Length;
				object obj5 = 1;
				result = num;
				if (!flag3)
				{
					while (flag2 != flag)
					{
						if (array[obj5] > num)
						{
							num = array[obj5];
						}
						obj5++;
						object obj6 = obj5 - array.Length;
						object obj7 = obj5 ^ array.Length;
						object obj8 = obj5 ^ obj6;
						object obj9 = obj7 & obj8;
						flag = (nint)obj9 < 0;
						flag2 = (nint)obj6 < 0;
						if ((nint)obj5 >= array.Length)
						{
							return num;
						}
					}
					goto IL_01a9;
				}
			}
			else
			{
				result = 0f;
			}
			return result;
		}
		goto IL_01a9;
		IL_01a9:
		throw new IndexOutOfRangeException();
	}

	private string GetStatDescription(string color)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172532]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!permanent)
		{
			string upgradeDescriptionStat = StatUtility.GetUpgradeDescriptionStat(statModifier, color);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			return $"{upgradeDescriptionStat} for {arg} seconds";
		}
		string upgradeDescriptionStat2 = StatUtility.GetUpgradeDescriptionStat(statModifier, color);
		bool flag = upgradeDescriptionStat2 == null;
		string result = "";
		if (!flag)
		{
			result = upgradeDescriptionStat2;
		}
		return result;
	}

	public string GetShortDescription()
	{
		//IL_0071: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172533]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string statTextColor = MyColorUtility.GetStatTextColor(isPositiveEffect);
		bool flag = effectType == EEncounterEffect.StatChange;
		if (!flag)
		{
			object obj = effectType - 1;
			if (!flag && (nint)obj != 1)
			{
				return "No description defined u oh";
			}
			return "";
		}
		string modificationString = StatUtility.GetModificationString(this.statModifier);
		string text = StatUtility.EncapsulateNumber(modificationString, statTextColor);
		StatModifier statModifier = this.statModifier;
		if (this.statModifier != null)
		{
			string text2 = EnumUtility.EnumToReadable(statModifier.stat);
			return text + " " + text2;
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetEffectNumber()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172534]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string statTextColor = MyColorUtility.GetStatTextColor(isPositiveEffect);
		if (effectType != EEncounterEffect.StatChange)
		{
			return "";
		}
		string modificationString = StatUtility.GetModificationString(statModifier);
		string text = StatUtility.EncapsulateNumber(modificationString, statTextColor);
		bool flag = text == null;
		string result = "";
		if (!flag)
		{
			result = text;
		}
		return result;
	}

	public string GetEffectName()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172535]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (effectType != EEncounterEffect.StatChange)
		{
			return "";
		}
		StatModifier statModifier = this.statModifier;
		if (this.statModifier != null)
		{
			string text = EnumUtility.EnumToReadable(statModifier.stat);
			bool flag = text == null;
			string result = "";
			if (!flag)
			{
				result = text;
			}
			return result;
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe void ApplyEffect()
	{
		//IL_0015: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00bc: Invalid comparison between F4 and I4
		//IL_012f: Expected F4, but got O
		//IL_015d: Expected F4, but got O
		//IL_015d: Expected O, but got I
		//IL_0118: Expected O, but got Ref
		bool flag = effectType == EEncounterEffect.StatChange;
		bool flag2 = default(bool);
		if (!flag)
		{
			object obj = effectType - 1;
			if (flag)
			{
				MyPlayer instance = MyPlayer.Instance;
				float num = GetValue();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
				instance.inventory.ChangeGold(0);
				return;
			}
			object obj2 = obj - 1;
			if (flag)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory = instance2.inventory;
				PlayerHealth playerHealth = inventory.playerHealth;
				float num2 = value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
				object obj3 = num2 & 0;
				float damage = (float)obj3 * (float)playerHealth.maxHp;
				if (!(value > 0f))
				{
					MyPlayer instance3 = MyPlayer.Instance;
					PlayerInventory inventory2 = instance3.inventory;
					object obj4 = default(object);
					string damageSource = default(string);
					DcFlags flags = default(DcFlags);
					EDamageEffect damageEffect = default(EDamageEffect);
					inventory2.playerHealth.DamagePlayerExternal(damage, 0f, (Vector3)(&obj4), flag2, damageSource, flags, damageEffect);
				}
				else
				{
					MyPlayer instance4 = MyPlayer.Instance;
					float num3 = (float)instance4.inventory;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v27 (System.Single)+40]");
					int num4 = ((PlayerHealth)0).Heal((float)instance4.inventory);
				}
				return;
			}
			if ((nint)obj2 != 1)
			{
				return;
			}
		}
		MyPlayer instance5 = MyPlayer.Instance;
		PlayerInventory inventory3 = instance5.inventory;
		inventory3.statInventory.ChangeStat(statModifier, permanent, duration, flag2);
	}

	private string GetColor()
	{
		return MyColorUtility.GetStatTextColor(isPositiveEffect);
	}

	private unsafe void HealthEffect()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_005f: Invalid comparison between F4 and I4
		//IL_00ce: Expected F4, but got O
		//IL_00fc: Expected F4, but got O
		//IL_00fc: Expected O, but got I
		//IL_00bb: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		PlayerHealth playerHealth = inventory.playerHealth;
		float num = value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num & 0;
		float damage = (float)obj * (float)playerHealth.maxHp;
		if (!(value > 0f))
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			object obj2 = default(object);
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory2.playerHealth.DamagePlayerExternal(damage, 0f, (Vector3)(&obj2), ignoreShield, damageSource, flags, damageEffect);
		}
		else
		{
			MyPlayer instance3 = MyPlayer.Instance;
			float num2 = (float)instance3.inventory;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v10 (System.Single)+40]");
			int num3 = ((PlayerHealth)0).Heal((float)instance3.inventory);
		}
	}

	public unsafe bool CanApplyEffect(out string reason)
	{
		//IL_0010: Invalid comparison between I4 and F4
		//IL_0252: Expected I4, but got O
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0088: Invalid comparison between F4 and O
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0145: Invalid comparison between I4 and F4
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		ref string reference = ref *(string*)"";
		if (effectType == EEncounterEffect.EGold)
		{
			if (!(0f > value))
			{
				goto IL_0236;
			}
			reference = ref *(string*)"Not enough gold";
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance.inventory;
				if (instance.inventory != null)
				{
					float num = value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
					object obj = num ^ 0;
					float num2 = inventory._003Cgold_003Ek__BackingField;
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
					return !flag;
				}
			}
		}
		else
		{
			if (effectType != EEncounterEffect.EHealth)
			{
				goto IL_0236;
			}
			MyPlayer instance2 = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory2 = instance2.inventory;
				if (instance2.inventory != null)
				{
					PlayerHealth playerHealth = inventory2.playerHealth;
					if (inventory2.playerHealth != null)
					{
						float num3 = value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
						object obj2 = num3 & 0;
						if (!(0f > value))
						{
							goto IL_0236;
						}
						reference = ref *(string*)"Not enough HP";
						MyPlayer instance3 = MyPlayer.Instance;
						if ((object)MyPlayer.Instance != null)
						{
							PlayerInventory inventory3 = instance3.inventory;
							if (instance3.inventory != null)
							{
								PlayerHealth playerHealth2 = inventory3.playerHealth;
								if (inventory3.playerHealth != null)
								{
									object obj3 = playerHealth.maxHp * obj2;
									bool flag2 = playerHealth2.hp < (nint)obj3;
									object obj4 = playerHealth2.hp - obj3;
									bool flag3 = obj4 == null;
									bool flag4 = !flag2;
									bool flag5 = !flag3;
									return flag5 & flag4;
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0236:
		return true;
	}
}
