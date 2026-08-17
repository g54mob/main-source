using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.UI.Mouse;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public static class StatUtility
{
	public static string GetUpgradeDescriptionWeapon(List<StatModifier> modifiers, WeaponData weaponData)
	{
		bool flag = modifiers == null;
		int num = 0;
		string text = "";
		int num2 = 0;
		if (!flag)
		{
			while (num2 < modifiers._size)
			{
				if (num > 0)
				{
					string text2 = text + "\n";
					text = text2;
				}
				StatModifier modifier = modifiers.get_Item(num);
				string upgradeDescriptionWeaponModifier = GetUpgradeDescriptionWeaponModifier(modifier, weaponData);
				string text3 = text + upgradeDescriptionWeaponModifier;
				num++;
				text = text3;
				num2 = num;
			}
			return text;
		}
		return (string)(object)new NullReferenceException();
	}

	public static string GetUpgradeDescriptionTome(List<StatModifier> modifiers, TomeData tomeData)
	{
		bool flag = modifiers == null;
		int num = 0;
		string text = "";
		int num2 = 0;
		if (!flag)
		{
			while (num2 < modifiers._size)
			{
				if (num > 0)
				{
					string text2 = text + "\n";
					text = text2;
				}
				StatModifier modifier = modifiers.get_Item(num);
				string upgradeDescriptionTomeModifier = GetUpgradeDescriptionTomeModifier(modifier, tomeData);
				string text3 = text + upgradeDescriptionTomeModifier;
				num++;
				text = text3;
				num2 = num;
			}
			return text;
		}
		return (string)(object)new NullReferenceException();
	}

	public static string GetUpgradeDescriptionWeaponModifier(StatModifier modifier, WeaponData weaponData, string color = "#ffffff")
	{
		string tooltipString = Tooltip.GetTooltipString(modifier.stat);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		WeaponInventory weaponInventory = inventory.weaponInventory;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)weaponInventory.weapons).get_Item((System.Int32Enum)weaponData.eWeapon);
		float value = ((WeaponBase)obj).GetValue(modifier.stat);
		float testUpdateStat = ((WeaponBase)obj).GetTestUpdateStat(modifier.stat, modifier);
		string[] array = new string[6];
		if (array.Length > 0)
		{
			array[0] = tooltipString;
			if (array.Length > 1)
			{
				array[1] = ": ";
				string weaponModificationString = GetWeaponModificationString(modifier.modifyType, modifier.stat, value);
				if (array.Length > 2)
				{
					array[2] = weaponModificationString;
					if (array.Length > 3)
					{
						array[3] = " <sprite name=arrow> <color=green>";
						string weaponModificationString2 = GetWeaponModificationString(modifier.modifyType, modifier.stat, testUpdateStat);
						if (array.Length > 4)
						{
							array[4] = weaponModificationString2;
							if (array.Length > 5)
							{
								array[5] = "</color>";
								return string.Concat(array);
							}
						}
					}
				}
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public static string GetUpgradeDescriptionTomeModifier(StatModifier modifier, TomeData tomeData, string color = "#ffffff")
	{
		//IL_0059: Expected F4, but got I4
		//IL_00b7: Expected F4, but got I4
		//IL_011f: Expected F4, but got I
		string tooltipString = Tooltip.GetTooltipString(modifier.stat);
		float value = modifier.modification;
		bool flag = tomeData != null;
		bool flag2 = !flag;
		bool addOneToMultiplication = true;
		float value2 = 0f;
		if (!flag2)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			bool flag3 = inventory.tomeInventory.HasTome(tomeData.eTome);
			bool flag4 = !flag3;
			addOneToMultiplication = true;
			value2 = 0f;
			if (!flag4)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance2.inventory;
				TomeInventory tomeInventory = inventory2.tomeInventory;
				object obj = ((Dictionary<System.Int32Enum, object>)(object)tomeInventory.tomeUpgrade).get_Item((System.Int32Enum)tomeData.eTome);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v31 (System.Object)+18]");
				value2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v31 (System.Object)+18]");
				value = 0f + modifier.modification;
				addOneToMultiplication = false;
			}
		}
		string[] array = new string[6];
		if (array.Length > 0)
		{
			array[0] = tooltipString;
			if (array.Length > 1)
			{
				array[1] = ": ";
				bool usePrefix = default(bool);
				string modificationString = GetModificationString(modifier.modifyType, modifier.stat, value2, addOneToMultiplication, usePrefix);
				if (array.Length > 2)
				{
					array[2] = modificationString;
					if (array.Length > 3)
					{
						array[3] = " <sprite name=arrow> <color=green>";
						string modificationString2 = GetModificationString(modifier.modifyType, modifier.stat, value, addOneToMultiplication, usePrefix);
						if (array.Length > 4)
						{
							array[4] = modificationString2;
							if (array.Length > 5)
							{
								array[5] = "</color>";
								return string.Concat(array);
							}
						}
					}
				}
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public static string GetUpgradeDescriptionStat(StatModifier modifier, string color = "#ffffff")
	{
		string tooltipString = Tooltip.GetTooltipString(modifier.stat);
		bool usePrefix = default(bool);
		string modificationString = GetModificationString(modifier.modifyType, modifier.stat, modifier.modification, addOneToMultiplication: true, usePrefix);
		string[] array = new string[5];
		if (array.Length > 0)
		{
			array[0] = "<b><color=";
			if (array.Length > 1)
			{
				array[1] = color;
				if (array.Length > 2)
				{
					array[2] = ">";
					if (array.Length > 3)
					{
						array[3] = modificationString;
						if (array.Length > 4)
						{
							array[4] = "</color></b>";
							string text = string.Concat(array);
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							string value = text + " " + tooltipString;
							((Dictionary<object, object>)(object)dictionary).Add((object)"upgrade", (object)value);
							return LocalizationUtility.GetLocalizedString("Game_Ui", "SHRINE_CHARGE_UPGRADE", dictionary);
						}
					}
				}
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public static string EncapsulateNumber(string number, string color)
	{
		string[] array = new string[5];
		if (array.Length > 0)
		{
			array[0] = "<b><color=";
			if (array.Length > 1)
			{
				array[1] = color;
				if (array.Length > 2)
				{
					array[2] = ">";
					if (array.Length > 3)
					{
						array[3] = number;
						if (array.Length > 4)
						{
							array[4] = "</color></b>";
							return string.Concat(array);
						}
					}
				}
			}
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public static string EncapsulateNumber(float number, string color)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172801]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		return $"<b><color={color}>{arg}</color></b>";
	}

	public static string GetModificationString(StatModifier modifier, bool addOneToMultiplication = true)
	{
		bool usePrefix = default(bool);
		if (modifier != null)
		{
			return GetModificationString(modifier.modifyType, modifier.stat, modifier.modification, addOneToMultiplication, usePrefix);
		}
		return (string)(object)new NullReferenceException();
	}

	public static string GetModificationString(EStatModifyType modifyType, EStat stat, float value, bool addOneToMultiplication = true, bool usePrefix = true)
	{
		//IL_035c: Expected O, but got I
		//IL_036c: Expected O, but got I
		//IL_0248: Expected O, but got I4
		//IL_0276: Expected O, but got I4
		//IL_029f: Invalid comparison between I4 and F4
		//IL_02c6: Expected O, but got I
		//IL_017e: Expected O, but got I
		//IL_018e: Expected O, but got I
		//IL_03e9: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v2+B8]");
		object obj2 = 0;
		string text = (string)obj2;
		string text2;
		float num;
		if (modifyType != EStatModifyType.Flat)
		{
			if (modifyType != EStatModifyType.Addition)
			{
				bool flag = modifyType != EStatModifyType.Multiplication;
				text2 = (string)obj2;
				num = value;
				if (!flag)
				{
					bool flag2 = !addOneToMultiplication;
					num = value;
					if (!flag2)
					{
						num = value + 1f;
					}
					text2 = text;
					text = "x";
				}
				goto IL_03ac;
			}
		}
		else if (stat > EStat.CritDamage)
		{
			if (stat != EStat.FallDamageReduction && stat != EStat.Luck && stat != EStat.Difficulty)
			{
				goto IL_0296;
			}
		}
		else
		{
			object obj3 = stat - 4;
			if ((nint)obj3 > 1)
			{
				object obj4 = stat - 17;
				if ((nint)obj4 > 2)
				{
					goto IL_0296;
				}
			}
		}
		num = value * 100f;
		text2 = text;
		text = "%";
		goto IL_03ac;
		IL_0296:
		if (0f > value)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v2+B8]");
			object obj5 = 0;
			text2 = (string)obj5;
			num = value;
		}
		else
		{
			text2 = "+";
			num = value;
		}
		goto IL_03ac;
		IL_03ac:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm6\"");
		double num2 = Math.Round(num, 2, MidpointRounding.ToEven);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
		object obj6 = default(object);
		if (obj6 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v23+B8]");
			object obj8 = 0;
			text2 = (string)obj8;
		}
		if (!(text != "x"))
		{
			string text3 = MyStringUtil.ShowOnlyDecimals(0f);
			return text2 + text3 + text;
		}
		nint num3 = (nint)typeof(Math);
		double num4 = Math.Round(0.0, 1, MidpointRounding.ToEven);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180300F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018044DD58h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rcx_v11 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			return $"{text2}{arg:N0}{text}";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg2 = default(object);
		return $"{text2}{arg2:N1}{text}";
	}

	public static string GetWeaponModificationString(EStatModifyType modifyType, EStat stat, float value, bool addOneToMultiplication = true)
	{
		switch (stat)
		{
		default:
		{
			bool usePrefix = default(bool);
			return GetModificationString(modifyType, stat, value, addOneToMultiplication: true, usePrefix);
		}
		case EStat.ProjectileSpeedMultiplier:
		case EStat.KnockbackMultiplier:
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			return $"{arg:N1}";
		}
		case EStat.DurationMultiplier:
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm6\"");
			double num = Math.Round(value, 2, MidpointRounding.ToEven);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
			string text = MyStringUtil.ShowOnlyDecimals((float)num);
			return text + "s";
		}
		}
	}

	private static string ModifyStatName(string statName, EWeapon eWeapon)
	{
		return statName;
	}

	public static float GetRarityValue(float value, ERarity rarity, int decimals = 2)
	{
		float multiplier = Rarity.GetMultiplier(rarity);
		float num = multiplier * value;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm6,xmm6\"");
		float result = (float)Math.Round(num, decimals, MidpointRounding.ToEven);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		return result;
	}

	public static EStatCategory GetStatCategory(EStat eStat)
	{
		//IL_001c: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 34 Invalid \"Jump target not found in method: 0x18044DF0A\"");
		object obj = 6442450944L;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdx_v1+44DF70+eStat @ rcx (Assets.Scripts.Menu.Shop.EStat)]");
		return EStatCategory.Offensive;
	}
}
