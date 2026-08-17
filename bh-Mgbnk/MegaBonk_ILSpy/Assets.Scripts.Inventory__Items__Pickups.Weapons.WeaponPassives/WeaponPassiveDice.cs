using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.WeaponPassives;

public class WeaponPassiveDice : WeaponPassive
{
	private int stacks;

	private float critPer6 = 0.005f;

	private string movingStatName = "DiceCritChance";

	private static float maxRollsUpgradesPerMinute = 100f;

	private float rollCooldown = maxRollsUpgradesPerMinute / 60f;

	private float nextRollTime;

	private float accumulatedCritChance;

	public override void Init()
	{
		//IL_0124: Expected I, but got O
		Action b = OnStackAdded;
		Delegate obj = Delegate.Combine(ProjectileDice.A_RollSix, b);
		if ((object)obj == null)
		{
			ProjectileDice.A_RollSix = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			ProjectileDice.A_RollSix = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_0124: Expected I, but got O
		Action value = OnStackAdded;
		Delegate obj = Delegate.Remove(ProjectileDice.A_RollSix, value);
		if ((object)obj == null)
		{
			ProjectileDice.A_RollSix = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			ProjectileDice.A_RollSix = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnStackAdded()
	{
		if (!(MyTime.time < nextRollTime))
		{
			float num = MyTime.time + rollCooldown;
			int num2 = ++stacks;
			nextRollTime = num;
			float num3 = (float)num2 * critPer6;
			accumulatedCritChance = num3;
			StatModifier statModifier = new StatModifier();
			statModifier.modification = accumulatedCritChance;
			statModifier.stat = EStat.CritChance;
			statModifier.modifyType = EStatModifyType.Flat;
			if (!((Dictionary<System.Int32Enum, object>)(object)statModifiers).ContainsKey((System.Int32Enum)statModifier.stat))
			{
				StatModifiersContainer value = new StatModifiersContainer();
				((Dictionary<System.Int32Enum, object>)(object)statModifiers).Add((System.Int32Enum)statModifier.stat, (object)value);
			}
			object obj = ((Dictionary<System.Int32Enum, object>)(object)statModifiers).get_Item((System.Int32Enum)statModifier.stat);
			((StatModifiersContainer)obj).SetModifier(statModifier);
			weaponBase.UpdateStat(statModifier.stat);
		}
	}

	public WeaponPassiveDice(WeaponBase weaponBase)
		: base(weaponBase)
	{
	}
}
