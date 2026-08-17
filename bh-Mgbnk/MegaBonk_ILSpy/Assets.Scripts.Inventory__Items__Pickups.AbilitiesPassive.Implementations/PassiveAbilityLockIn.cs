using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Inventory__Items__Pickups.Xp_and_Levels;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityLockIn : PassiveAbility
{
	public int thornsPerLevel = 2;

	private float maxDamage = 1f;

	private float maxDamagePerLevel = 0.01f;

	private float updateCooldown = 1f;

	private float nextUpdateTime;

	private float lastValue = -1f;

	public override void Init()
	{
		//IL_02d0: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0236: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_029f: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		maxDamage = 1f;
		Action<int> b = OnLevelup;
		Delegate obj = Delegate.Combine(PlayerXp.A_LevelUp, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action = default(Action<int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0342;
			}
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02ff;
			}
		}
		Action<int> b2 = OnAegisChange;
		Delegate obj6 = Delegate.Combine(AegisAttack.A_Used, b2);
		if ((object)obj6 == null)
		{
			AegisAttack.A_Used = (Action<int>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_030a;
			}
			AegisAttack.A_Used = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_031a;
			}
		}
		Action<int> b3 = OnAegisChange;
		Delegate obj8 = Delegate.Combine(AegisAttack.A_Regen, b3);
		if ((object)obj8 == null)
		{
			AegisAttack.A_Regen = (Action<int>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action3 = default(Action<int>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_0332;
		}
		AegisAttack.A_Regen = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_0342;
		IL_0342:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0332;
		IL_02ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_030a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02ff;
		IL_031a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_030a;
		IL_0332:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_031a;
	}

	public override void Cleanup()
	{
		//IL_02d0: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0236: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_029f: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		Action<int> value = OnLevelup;
		Delegate obj = Delegate.Remove(PlayerXp.A_LevelUp, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerXp.A_LevelUp = (Action<int>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action = default(Action<int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0337;
			}
			PlayerXp.A_LevelUp = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02f4;
			}
		}
		Action<int> value2 = OnAegisChange;
		Delegate obj6 = Delegate.Remove(AegisAttack.A_Used, value2);
		if ((object)obj6 == null)
		{
			AegisAttack.A_Used = (Action<int>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action2 = default(Action<int>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02ff;
			}
			AegisAttack.A_Used = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<int>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_030f;
			}
		}
		Action<int> value3 = OnAegisChange;
		Delegate obj8 = Delegate.Remove(AegisAttack.A_Regen, value3);
		if ((object)obj8 == null)
		{
			AegisAttack.A_Regen = (Action<int>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action3 = default(Action<int>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_0327;
		}
		AegisAttack.A_Regen = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<int>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_0337;
		IL_0337:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0327;
		IL_02f4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02f4;
		IL_030f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02ff;
		IL_0327:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_030f;
	}

	private void OnAegisChange(int currentAmount)
	{
		StatModifier statModifier = new StatModifier();
		if (currentAmount > 0)
		{
			statModifier._002Ector();
			statModifier.stat = EStat.AttackSpeed;
			statModifier.modification = 0f;
		}
		else
		{
			statModifier._002Ector();
			statModifier.stat = EStat.AttackSpeed;
			statModifier.modification = 1.5f;
		}
		SetStat(statModifier);
	}

	public override void Tick()
	{
		//IL_0086: Invalid comparison between I4 and F4
		//IL_00d1: Expected F4, but got I4
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0105: Invalid comparison between F4 and O
		if (nextUpdateTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + updateCooldown;
		nextUpdateTime = num;
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int combinedHp = inventory.playerHealth.GetCombinedHp();
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance2.inventory;
		int combinedMaxHp = inventory2.playerHealth.GetCombinedMaxHp();
		int num2 = combinedHp / combinedMaxHp;
		float num3 = 1f - (float)num2;
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = num3 * maxDamage;
		float num5 = lastValue - num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num5 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.02f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			StatModifier statModifier = new StatModifier();
			statModifier.modification = num4;
			statModifier.stat = EStat.DamageMultiplier;
			SetStat(statModifier);
			lastValue = num4;
		}
	}

	private void OnLevelup(int level)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		object obj = level * maxDamagePerLevel;
		float num = (float)obj + 1f;
		maxDamage = num;
		StatModifier statModifier = new StatModifier();
		float modification = (float)level * (float)thornsPerLevel;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.Thorns;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.LockIn;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_01ed: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_00ba: Expected I, but got O
		//IL_00d0: Expected I, but got O
		//IL_00e9: Expected O, but got I
		//IL_0111: Expected O, but got I
		//IL_0119: Expected I, but got O
		//IL_021e: Expected O, but got I
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected I, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.Thorns);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 3;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"{arg}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)text2);
			object[] array = new object[1];
			bool flag2 = array == null;
			obj = text2;
			obj2 = 1;
			num = (nint)typeof(object[]);
			if (!flag2)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text2);
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				obj = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
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
