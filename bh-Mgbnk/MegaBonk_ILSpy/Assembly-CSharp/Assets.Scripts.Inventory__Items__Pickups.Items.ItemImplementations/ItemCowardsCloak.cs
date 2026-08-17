using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemCowardsCloak : ItemBase
{
	private float speedPerAmount = 0.05f;

	private float speedPerStack = 0.3f;

	private int maxStacks = 2;

	private int stacksPerAmount = 2;

	private float extraDurationPerAmount;

	private float stacksResetAtTime;

	private int stacks;

	protected override void OnInitOrAmountChanged()
	{
		RefreshStats();
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
		//IL_000e: Invalid comparison between I4 and F4
		if (0f < dc.damage)
		{
			if (stacks < maxStacks)
			{
				int num = stacks + 1;
				stacks = num;
			}
			float num2 = (float)amount * 0.5f;
			float num3 = MyTime.time + 3f;
			float num4 = num2 - 1f;
			float num5 = num4 + num3;
			stacksResetAtTime = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 87 Invalid \"Jump target not found in method: 0x18043E5A0\"");
		}
	}

	private void AddTemporaryStack()
	{
		if (stacks < maxStacks)
		{
			int num = stacks + 1;
			stacks = num;
		}
		float num2 = (float)amount * 0.5f;
		float num3 = MyTime.time + 3f;
		float num4 = num2 - 1f;
		float num5 = num4 + num3;
		stacksResetAtTime = num5;
		RefreshStats();
	}

	public override void Tick()
	{
		if (stacks > 0 && MyTime.time > stacksResetAtTime)
		{
			stacks = 0;
			RefreshStats();
		}
	}

	private void RefreshStats()
	{
		StatModifier statModifier = new StatModifier();
		float modification = speedPerAmount * (float)amount;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.MoveSpeedMultiplier;
		statModifier.modification = modification;
		SetStat(statModifier);
		StatModifier statModifier2 = new StatModifier();
		float num = speedPerStack * (float)stacks;
		statModifier2.modifyType = EStatModifyType.Multiplication;
		statModifier2.stat = EStat.MoveSpeedMultiplier;
		float modification2 = num + 1f;
		statModifier2.modification = modification2;
		SetStat(statModifier2);
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
		if (action != null)
		{
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public ItemCowardsCloak(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
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
		string text = EnumUtility.EnumToReadable(EStat.MoveSpeedMultiplier);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 25;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num2 = speedPerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"+{arg}%";
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
