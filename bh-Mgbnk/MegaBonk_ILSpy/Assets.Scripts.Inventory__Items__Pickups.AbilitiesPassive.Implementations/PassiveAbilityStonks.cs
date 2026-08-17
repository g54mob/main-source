using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityStonks : PassiveAbility
{
	private float goldIncreasePerLevel = 0.01f;

	private float damageIncreasePer1000Gold = 0.1f;

	private float damagePer1000Gold_First10k = 0.2f;

	private float damagePer1000Gold_First200k = 0.085f;

	private float damagePer1000Gold_First1m = 0.06f;

	private float damagePer1000Gold_After1m = 0.035f;

	private float nextUpdateTime;

	private float updateCooldown = 1f;

	private float lastValue = -1f;

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

	private float GetDamage()
	{
		//IL_00a8: Expected F4, but got I4
		//IL_0131: Expected F4, but got I4
		//IL_0147: Expected F4, but got I4
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		float num4;
		float num5;
		float num6;
		float num7;
		float num8;
		float num9;
		if (inventory._003Cgold_003Ek__BackingField > 1000000f)
		{
			float num = inventory._003Cgold_003Ek__BackingField - 1000000f;
			float num2 = num / 1000f;
			float num3 = num2 * damagePer1000Gold_After1m;
			num4 = num3;
			num5 = 1000000f;
		}
		else
		{
			bool flag = !(inventory._003Cgold_003Ek__BackingField > 200000f);
			num4 = 0f;
			num5 = inventory._003Cgold_003Ek__BackingField;
			if (flag)
			{
				bool flag2 = !(inventory._003Cgold_003Ek__BackingField > 10000f);
				num6 = 0f;
				num7 = inventory._003Cgold_003Ek__BackingField;
				num8 = 0f;
				num9 = inventory._003Cgold_003Ek__BackingField;
				if (!flag2)
				{
					goto IL_0162;
				}
				goto IL_01b5;
			}
		}
		float num10 = num5 - 200000f;
		float num11 = num10 / 1000f;
		float num12 = num11 * damagePer1000Gold_First1m;
		num6 = num4 + num12;
		num7 = 200000f;
		goto IL_0162;
		IL_0162:
		float num13 = num7 - 10000f;
		float num14 = num13 / 1000f;
		float num15 = num14 * damagePer1000Gold_First200k;
		num8 = num6 + num15;
		num9 = 10000f;
		goto IL_01b5;
		IL_01b5:
		float num16 = num9 / 1000f;
		float num17 = num16 * damagePer1000Gold_First10k;
		return num17 + num8;
	}

	public override void Tick()
	{
		//IL_00ad: Expected F4, but got I4
		//IL_0136: Expected F4, but got I4
		//IL_014c: Expected F4, but got I4
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_01e4: Invalid comparison between F4 and O
		if (nextUpdateTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + updateCooldown;
		nextUpdateTime = num;
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		float num5;
		float num6;
		float num7;
		float num8;
		float num9;
		float num10;
		if (inventory._003Cgold_003Ek__BackingField > 1000000f)
		{
			float num2 = inventory._003Cgold_003Ek__BackingField - 1000000f;
			float num3 = num2 / 1000f;
			float num4 = num3 * damagePer1000Gold_After1m;
			num5 = num4;
			num6 = 1000000f;
		}
		else
		{
			bool flag = !(inventory._003Cgold_003Ek__BackingField > 200000f);
			num5 = 0f;
			num6 = inventory._003Cgold_003Ek__BackingField;
			if (flag)
			{
				bool flag2 = !(inventory._003Cgold_003Ek__BackingField > 10000f);
				num7 = 0f;
				num8 = inventory._003Cgold_003Ek__BackingField;
				num9 = 0f;
				num10 = inventory._003Cgold_003Ek__BackingField;
				if (!flag2)
				{
					goto IL_0167;
				}
				goto IL_0270;
			}
		}
		float num11 = num6 - 200000f;
		float num12 = num11 / 1000f;
		float num13 = num12 * damagePer1000Gold_First1m;
		num7 = num5 + num13;
		num8 = 200000f;
		goto IL_0167;
		IL_0270:
		float num14 = num10 / 1000f;
		float num15 = num14 * damagePer1000Gold_First10k;
		float num16 = num15 + num9;
		float num17 = lastValue - num16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num17 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.02f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			StatModifier statModifier = new StatModifier();
			statModifier.modification = num16;
			statModifier.stat = EStat.DamageMultiplier;
			SetStat(statModifier);
			lastValue = num16;
		}
		return;
		IL_0167:
		float num18 = num8 - 10000f;
		float num19 = num18 / 1000f;
		float num20 = num19 * damagePer1000Gold_First200k;
		num9 = num7 + num20;
		num10 = 10000f;
		goto IL_0270;
	}

	private void OnLevelup(int level)
	{
		StatModifier statModifier = new StatModifier();
		float modification = (float)level * goldIncreasePerLevel;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.GoldIncreaseMultiplier;
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
		return EPassive.Stonks;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_024e: Expected O, but got I
		//IL_010d: Expected O, but got I4
		//IL_011b: Expected I, but got O
		//IL_0131: Expected I, but got O
		//IL_014a: Expected O, but got I
		//IL_0172: Expected O, but got I
		//IL_017a: Expected I, but got O
		//IL_027f: Expected O, but got I
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected I, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.GoldIncreaseMultiplier);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 31;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num2 = goldIncreasePerLevel * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			string statName = LocalizationUtility.GetStatName(EStat.DamageMultiplier);
			((Dictionary<object, object>)(object)dictionary).Add((object)"damage", (object)statName);
			string localizedString2 = LocalizationUtility.GetLocalizedString("Other", "GOLD");
			((Dictionary<object, object>)(object)dictionary).Add((object)"gold", (object)localizedString2);
			object[] array = new object[1];
			bool flag2 = array == null;
			obj = localizedString2;
			obj2 = 1;
			num = (nint)typeof(object[]);
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rdx_v16 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, localizedString2);
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				obj = localizedString2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rdx_v16 (Il2CppClass<System.Object[]>)+40]");
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
				obj = localizedString2;
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
