using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGasmask : ItemBase
{
	private float armorPerStack = 0.005f;

	private float overhealPerStack = 0.005f;

	private float maxArmorPerAmount = 0.4f;

	private float maxOverhealPerAmount = 0.25f;

	private float maxArmor;

	private float maxOverheal;

	private int lastStoredStacks;

	private float updateInverval = 1f;

	private float nextUpdateTime;

	protected override void OnInitOrAmountChanged()
	{
		float num = MyTime.time + updateInverval;
		float num2 = (float)amount * maxArmorPerAmount;
		nextUpdateTime = num;
		maxArmor = num2;
		float num3 = (float)amount * maxOverhealPerAmount;
		maxOverheal = num3;
	}

	private void UpdateRetaliation()
	{
		if (lastStoredStacks != DebuffPoison.numPoisonedEnemies)
		{
			StatModifier statModifier = new StatModifier();
			statModifier.modifyType = EStatModifyType.Flat;
			statModifier.stat = EStat.Overheal;
			float num = (float)DebuffPoison.numPoisonedEnemies * overhealPerStack;
			if (num > maxOverheal)
			{
				num = maxOverheal;
			}
			statModifier.modification = num;
			SetStat(statModifier);
			StatModifier statModifier2 = new StatModifier();
			statModifier2.modifyType = EStatModifyType.Flat;
			statModifier2.stat = EStat.Armor;
			float num2 = (float)DebuffPoison.numPoisonedEnemies * armorPerStack;
			if (num2 > maxArmor)
			{
				num2 = maxArmor;
			}
			statModifier2.modification = num2;
			SetStat(statModifier2);
			lastStoredStacks = DebuffPoison.numPoisonedEnemies;
		}
	}

	private int GetNumPoisonedEnemies()
	{
		return DebuffPoison.numPoisonedEnemies;
	}

	private void OnStageStarted()
	{
		DebuffPoison.numPoisonedEnemies = 0;
	}

	public override void Tick()
	{
		if (nextUpdateTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + updateInverval;
		nextUpdateTime = num;
		if (lastStoredStacks != DebuffPoison.numPoisonedEnemies)
		{
			StatModifier statModifier = new StatModifier();
			statModifier.modifyType = EStatModifyType.Flat;
			statModifier.stat = EStat.Overheal;
			float num2 = (float)DebuffPoison.numPoisonedEnemies * overhealPerStack;
			if (num2 > maxOverheal)
			{
				num2 = maxOverheal;
			}
			statModifier.modification = num2;
			SetStat(statModifier);
			StatModifier statModifier2 = new StatModifier();
			statModifier2.modifyType = EStatModifyType.Flat;
			statModifier2.stat = EStat.Armor;
			float num3 = (float)DebuffPoison.numPoisonedEnemies * armorPerStack;
			if (num3 > maxArmor)
			{
				num3 = maxArmor;
			}
			statModifier2.modification = num3;
			SetStat(statModifier2);
			lastStoredStacks = DebuffPoison.numPoisonedEnemies;
		}
	}

	public ItemGasmask(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
		//IL_0124: Expected I, but got O
		Action b = OnStageStarted;
		Delegate obj = Delegate.Combine(GameManager.A_StageStarted, b);
		if ((object)obj == null)
		{
			GameManager.A_StageStarted = null;
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
			GameManager.A_StageStarted = (Action)obj2;
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
		Action value = OnStageStarted;
		Delegate obj = Delegate.Remove(GameManager.A_StageStarted, value);
		if ((object)obj == null)
		{
			GameManager.A_StageStarted = null;
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
			GameManager.A_StageStarted = (Action)obj2;
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

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.Armor);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			string text2 = EnumUtility.EnumToReadable(EStat.Overheal);
			if (text2 == null)
			{
				text2 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
