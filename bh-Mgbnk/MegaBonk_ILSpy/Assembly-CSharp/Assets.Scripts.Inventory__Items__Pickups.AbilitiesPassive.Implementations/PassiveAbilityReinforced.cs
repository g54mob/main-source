using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityReinforced : PassiveAbility
{
	private float armorPerLevel = 0.01f;

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<int> b = OnLevelup;
		Delegate obj = Delegate.Combine(PlayerXp.A_LevelUp, b);
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		if (action != null)
		{
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<int>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<int>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Tick()
	{
	}

	private void OnLevelup(int level)
	{
		StatModifier statModifier = new StatModifier();
		float modification = (float)level * armorPerLevel;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.Armor;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<int> value = OnLevelup;
		Delegate obj = Delegate.Remove(PlayerXp.A_LevelUp, value);
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		if (action != null)
		{
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<int>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<int>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Reinforced;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_01ff: Expected O, but got I
		//IL_00be: Expected O, but got I4
		//IL_00cc: Expected I, but got O
		//IL_00e2: Expected I, but got O
		//IL_00fb: Expected O, but got I
		//IL_0123: Expected O, but got I
		//IL_012b: Expected I, but got O
		//IL_0230: Expected O, but got I
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected I, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.Armor);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 4;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num2 = armorPerLevel * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)text2);
			object[] array = new object[1];
			bool flag2 = array == null;
			obj = text2;
			obj2 = 1;
			num = (nint)typeof(object[]);
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text2);
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				obj = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
				obj2 = 0;
				num = (nint)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)num).Add((string)obj2, obj);
					object obj4 = default(object);
					throw obj4;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				num = (nint)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				obj = text2;
				obj2 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}
}
