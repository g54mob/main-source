using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemPhantomShroud : ItemBase
{
	private float evasionPerAmount = 0.05f;

	private float damageMultiplierBase = 2f;

	private float damageMultiplierPerAmount = 0.5f;

	private float speedAdditionBase = 0.5f;

	private float speedAdditionPerAmount = 0.15f;

	private float timeout = 2f;

	private float attackSpeedPerStack = 0.25f;

	private float damagePerStack = 0.5f;

	private int stacks;

	private int maxStacks;

	private bool hasEvaded;

	private float speedResetAtTime;

	private bool hasSpeed;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0086: Expected O, but got I4
		int num = amount << 2;
		maxStacks = num;
		object obj = amount - 1;
		float num2 = (float)obj * 0.5f;
		if ((timeout = num2 + 3f) > 6f)
		{
			timeout = 6f;
		}
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.Evasion;
		float modification = (float)amount * evasionPerAmount;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	private void OnEvade(Enemy enemy)
	{
		//IL_0042: Expected O, but got I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		hasEvaded = true;
		float num = MyTime.time + timeout;
		speedResetAtTime = num;
		if (stacks < maxStacks)
		{
			int num2 = stacks + 1;
			stacks = num2;
		}
		StatModifier statModifier = new StatModifier();
		statModifier.stat = EStat.MoveSpeedMultiplier;
		object obj = amount - 1;
		object obj2 = obj * speedAdditionPerAmount;
		float modification = (float)obj2 + speedAdditionBase;
		statModifier.modification = modification;
		SetStat(statModifier);
		StatModifier statModifier2 = new StatModifier();
		statModifier2.stat = EStat.DamageMultiplier;
		float modification2 = (float)stacks * damagePerStack;
		statModifier2.modification = modification2;
		SetStat(statModifier2);
		StatModifier statModifier3 = new StatModifier();
		statModifier3.stat = EStat.AttackSpeed;
		float modification3 = (float)stacks * attackSpeedPerStack;
		statModifier3.modification = modification3;
		SetStat(statModifier3);
		hasSpeed = true;
	}

	public override void Tick()
	{
		if (hasSpeed && MyTime.time > speedResetAtTime)
		{
			StatModifier statModifier = new StatModifier();
			statModifier.stat = EStat.MoveSpeedMultiplier;
			statModifier.modification = 0f;
			SetStat(statModifier);
			StatModifier statModifier2 = new StatModifier();
			statModifier2.stat = EStat.DamageMultiplier;
			statModifier2.modification = 0f;
			SetStat(statModifier2);
			StatModifier statModifier3 = new StatModifier();
			statModifier3.stat = EStat.AttackSpeed;
			statModifier3.modification = 0f;
			SetStat(statModifier3);
			hasSpeed = false;
			stacks = 0;
		}
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
		//IL_003f: Expected O, but got I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		if (hasEvaded)
		{
			hasEvaded = false;
			object obj = amount - 1;
			object obj2 = obj * damageMultiplierPerAmount;
			float value = (float)obj2 + damageMultiplierBase;
			itemAttackModifier.AddMultiplier(value);
		}
	}

	public override bool HasPreAttackProc()
	{
		return true;
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> b = OnEvade;
		Delegate obj = Delegate.Combine(PlayerHealth.A_Evaded, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_Evaded = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			PlayerHealth.A_Evaded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> value = OnEvade;
		Delegate obj = Delegate.Remove(PlayerHealth.A_Evaded, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_Evaded = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			PlayerHealth.A_Evaded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public ItemPhantomShroud(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
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
		//IL_0085: Expected I, but got O
		//IL_009e: Expected O, but got I
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string value = $"{obj}x";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
		string text = EnumUtility.EnumToReadable(EStat.AttackSpeed);
		if (text == null)
		{
			text = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
		string text2 = EnumUtility.EnumToReadable(EStat.MoveSpeedMultiplier);
		if (text2 == null)
		{
			text2 = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text2);
		object[] array = new object[1];
		if (array != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rdx_v14 (Il2CppClass<System.Object[]>)+40]");
			dictionary.Add((string)0, text2);
			object obj2 = default(object);
			if (obj2 == null)
			{
				((Dictionary<string, object>)(object)"{0}x").Add((string)obj, (object)null);
				object obj3 = default(object);
				throw obj3;
			}
			array[0] = dictionary;
			if (localizedString != null)
			{
				return localizedString.GetLocalizedString(array);
			}
		}
		return (string)(object)new NullReferenceException();
	}
}
