using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemJoesDagger : ItemBase
{
	private float attackDamagePerProcPerAmount;

	private float attackDamagePerProc;

	private float executionChance;

	private float accumulatedDamaged;

	private int stacks;

	private int maxStacks;

	private int lastUsedStacks;

	private float nextUpdateTime;

	private string damageSource;

	private const float maxRollsPerMinute = 200f;

	private float rollCooldown;

	private float nextRollTime;

	private int joesProcs;

	private float nextProcTime;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * attackDamagePerProcPerAmount;
		attackDamagePerProc = num;
	}

	public override void Tick()
	{
		if (!(nextUpdateTime > MyTime.time))
		{
			float num = MyTime.time + 1f;
			nextUpdateTime = num;
			if (stacks > lastUsedStacks)
			{
				StatModifier statModifier = new StatModifier();
				statModifier.stat = EStat.DamageMultiplier;
				statModifier.modification = accumulatedDamaged;
				statModifier.modifyType = EStatModifyType.Addition;
				SetStat(statModifier);
				lastUsedStacks = stacks;
			}
		}
	}

	private void OnEnemyDamage(Enemy e, DamageContainer dc)
	{
		if (!(nextRollTime > MyTime.time))
		{
			bool flag = e.IsBoss();
			if (!flag && dc.isExecute != flag)
			{
				float num = MyTime.time + rollCooldown;
				int num2 = stacks + 1;
				stacks = num2;
				nextRollTime = num;
				float num3 = accumulatedDamaged + attackDamagePerProc;
				accumulatedDamaged = num3;
			}
		}
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> b = OnEnemyDamage;
		Delegate obj = Delegate.Combine(Enemy.A_Damage, b);
		if ((object)obj == null)
		{
			Enemy.A_Damage = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_Damage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> b = OnEnemyDamage;
		Delegate obj = Delegate.Combine(Enemy.A_Damage, b);
		if ((object)obj == null)
		{
			Enemy.A_Damage = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_Damage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe ItemJoesDagger(ItemInventory itemInventoryRef)
	{
		//IL_003b: Expected O, but got Ref
		attackDamagePerProcPerAmount = 0.01f;
		attackDamagePerProc = 0.01f;
		executionChance = 0.01f;
		maxStacks = 999999;
		object obj = default(object);
		damageSource = ((Enum)(&obj)).ToString();
		rollCooldown = 0.3f;
		base._002Ector(itemInventoryRef);
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
		if (dc.canProcJoe && !(nextProcTime > MyTime.time))
		{
			double num = MyRandom.random.NextDouble();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
			if ((nint)MyRandom.random > 0)
			{
				dc.damageSource = damageSource;
				dc.isExecute = true;
				int num2 = joesProcs + 1;
				joesProcs = num2;
				float num3 = MyTime.time + rollCooldown;
				nextProcTime = num3;
			}
		}
	}

	public override bool HasPreAttackProc()
	{
		return true;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	protected unsafe override Dictionary<string, object> GetLocalizationKeys()
	{
		//IL_00dd: Expected O, but got Ref
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.DamageMultiplier);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num = executionChance * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			float num2 = attackDamagePerProc * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			object obj = default(object);
			string key = ((Enum)(&obj)).ToString();
			string text2 = LocalizationUtility.GetLocalizedString("DamageSources", key);
			if (text2 == null)
			{
				text2 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"execute", (object)text2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
