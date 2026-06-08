using System;
using System.Collections.Generic;
using UnityEngine;

public class StatModController : StatModifier
{
	private List<StatModRenderer> statModRenderers;

	private Dictionary<string, List<StatModifier>> statModifierDict;

	private static Stack<List<StatModifier>> stackPool = new Stack<List<StatModifier>>(24);

	public List<StatModifier> statModifiers { get; set; }

	public List<List<StatModifier>> debuffs { get; private set; }

	public static event Action<Character, DebuffStatMod> OnDebuffAdded;

	public static event Action<Character, DebuffStatMod> OnDebuffReset;

	public static event Action<Character, StatModifier> OnCleanse;

	public override void UpdateTic()
	{
		if (statModifiers != null)
		{
			for (int i = 0; i < statModifiers.Count; i++)
			{
				statModifiers[i].UpdateTic();
			}
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Character character)
	{
		if (statModRenderers != null)
		{
			for (int i = 0; i < statModRenderers.Count; i++)
			{
				statModRenderers[i].Draw(r, offsetX, offsetY, character);
			}
		}
	}

	public ItemData.Rarity.Type ModRarityForStatType(ItemData.Rarity.Type rarityType, ItemData.Stat.Type statType)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			StatModifier statModifier = statModifiers[num];
			if (statModifier.statData != null && statModifier.statData.type == statType && statModifier.rarity != null && statModifier.rarity.type > rarityType)
			{
				return statModifier.rarity.type;
			}
			num++;
		}
		return rarityType;
	}

	public override void ModDamage(Damage dmg, Character target)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			statModifiers[num].ModDamage(dmg, target);
			num++;
		}
	}

	public override int ModMaxHealth(int maxHealth)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			maxHealth = statModifiers[num].ModMaxHealth(maxHealth);
			num++;
		}
		return maxHealth;
	}

	public override int ModAttackSpeed(int attackSpeed)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			attackSpeed = statModifiers[num].ModAttackSpeed(attackSpeed);
			num++;
		}
		return attackSpeed;
	}

	public override float ModArmorPerSecond(float aps)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			aps = statModifiers[num].ModArmorPerSecond(aps);
			num++;
		}
		return aps;
	}

	public override float ModMaxArmor(float maxArmor)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			maxArmor = statModifiers[num].ModMaxArmor(maxArmor);
			num++;
		}
		return maxArmor;
	}

	public override int ModTicsPerMove(int ticsPerMove)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			ticsPerMove = statModifiers[num].ModTicsPerMove(ticsPerMove);
			num++;
		}
		return ticsPerMove;
	}

	public override float ModChanceToEvade(float chanceToEvade)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			chanceToEvade = statModifiers[num].ModChanceToEvade(chanceToEvade);
			num++;
		}
		return chanceToEvade;
	}

	public override float ModChanceToAOE(float chanceToAOE)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			chanceToAOE = statModifiers[num].ModChanceToAOE(chanceToAOE);
			num++;
		}
		return chanceToAOE;
	}

	public override float ModChanceToLifesteal(float chanceToLifesteal)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			chanceToLifesteal = statModifiers[num].ModChanceToLifesteal(chanceToLifesteal);
			num++;
		}
		return chanceToLifesteal;
	}

	public override float ModCriticalChance(float criticalChance)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			criticalChance = statModifiers[num].ModCriticalChance(criticalChance);
			num++;
		}
		return criticalChance;
	}

	public override float ModCriticalMultiplier(float criticalMultiplier)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			criticalMultiplier = statModifiers[num].ModCriticalMultiplier(criticalMultiplier);
			num++;
		}
		return criticalMultiplier;
	}

	public override int ModRange(int range)
	{
		int num = 0;
		while (statModifiers != null && num < statModifiers.Count)
		{
			range = statModifiers[num].ModRange(range);
			num++;
		}
		return range;
	}

	public void AddStatModifier(StatModifier modifier)
	{
		if (modifier.id == null || modifier.id == "")
		{
			Utils.LogWarning("Stat modifier " + modifier?.ToString() + " cannot be added to " + this?.ToString() + " because it doesn't have a valid id.");
			return;
		}
		if (modifier.stacks && modifier.maxStack > 0 && statModifierDict != null && statModifierDict.ContainsKey(modifier.id) && statModifierDict[modifier.id].Count >= modifier.maxStack)
		{
			List<StatModifier> list = statModifierDict[modifier.id];
			StatModifier statModifier = null;
			int num = 999999;
			for (int i = 0; i < list.Count; i++)
			{
				StatModifier statModifier2 = list[i];
				int num2 = statModifier2.ticDuration - statModifier2.ElapsedTics;
				if (num2 < num)
				{
					statModifier = statModifier2;
					num = num2;
				}
			}
			if (statModifier != null)
			{
				statModifier.ResetFromReapplying();
				FireOnDebuffReset(statModifier);
			}
			UnityEngine.Object.Destroy(modifier.gameObject);
			return;
		}
		if (!modifier.stacks && statModifierDict != null && statModifierDict.ContainsKey(modifier.id))
		{
			StatModifier statModifier3 = statModifierDict[modifier.id][0];
			statModifier3.ResetFromReapplying();
			FireOnDebuffReset(statModifier3);
			UnityEngine.Object.Destroy(modifier.gameObject);
			return;
		}
		modifier.transform.parent = base.transform;
		modifier.OnEnded += HandleStatModifierEnded;
		if (statModifiers == null)
		{
			statModifiers = new List<StatModifier>();
			debuffs = new List<List<StatModifier>>();
			statModifierDict = new Dictionary<string, List<StatModifier>>();
		}
		statModifiers.Add(modifier);
		List<StatModifier> list2;
		if (statModifierDict.ContainsKey(modifier.id))
		{
			list2 = statModifierDict[modifier.id];
		}
		else
		{
			list2 = NewStack();
			statModifierDict.Add(modifier.id, list2);
			if (modifier is DebuffStatMod)
			{
				debuffs.Add(list2);
			}
		}
		list2.Add(modifier);
		FireOnDebuffAdded(modifier);
		StatModRenderer component = modifier.GetComponent<StatModRenderer>();
		if (component != null)
		{
			if (statModRenderers == null)
			{
				statModRenderers = new List<StatModRenderer>();
			}
			statModRenderers.Add(component);
		}
	}

	public void Cleanse()
	{
		if (statModifiers == null)
		{
			return;
		}
		List<StatModifier> list = new List<StatModifier>();
		for (int i = 0; i < statModifiers.Count; i++)
		{
			if (statModifiers[i].cleansable)
			{
				list.Add(statModifiers[i]);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (StatModController.OnCleanse != null)
			{
				StatModController.OnCleanse(base.character, list[j]);
			}
			list[j].End();
		}
	}

	public StatModifier GetOldestBuff()
	{
		StatModifier statModifier = null;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			for (int j = 0; j < list.Count; j++)
			{
				StatModifier statModifier2 = list[j];
				if (statModifier2.isPositiveBuff && (statModifier == null || statModifier.initializationTimestamp > statModifier2.initializationTimestamp))
				{
					statModifier = statModifier2;
				}
			}
		}
		return statModifier;
	}

	public StatModifier GetOldestDebuff()
	{
		StatModifier statModifier = null;
		for (int i = 0; i < debuffs.Count; i++)
		{
			List<StatModifier> list = debuffs[i];
			for (int j = 0; j < list.Count; j++)
			{
				StatModifier statModifier2 = list[j];
				if (!statModifier2.isPositiveBuff && (statModifier == null || statModifier.initializationTimestamp > statModifier2.initializationTimestamp))
				{
					statModifier = statModifier2;
				}
			}
		}
		return statModifier;
	}

	private void FireOnDebuffAdded(StatModifier modifier)
	{
		if (StatModController.OnDebuffAdded != null)
		{
			DebuffStatMod debuffStatMod = modifier as DebuffStatMod;
			if (debuffStatMod != null && base.character != null)
			{
				StatModController.OnDebuffAdded(base.character, debuffStatMod);
			}
		}
	}

	private void FireOnDebuffReset(StatModifier modifier)
	{
		if (StatModController.OnDebuffReset != null)
		{
			DebuffStatMod debuffStatMod = modifier as DebuffStatMod;
			if (debuffStatMod != null && base.character != null)
			{
				StatModController.OnDebuffReset(base.character, debuffStatMod);
			}
		}
	}

	private void HandleStatModifierEnded(StatModifier modifier)
	{
		modifier.OnEnded -= HandleStatModifierEnded;
		List<StatModifier> list = statModifierDict[modifier.id];
		list.Remove(modifier);
		if (list.Count == 0)
		{
			if (modifier is DebuffStatMod)
			{
				debuffs.Remove(list);
			}
			statModifierDict.Remove(modifier.id);
			RecycleStack(list);
		}
		statModifiers.Remove(modifier);
		if (statModRenderers != null)
		{
			StatModRenderer component = modifier.GetComponent<StatModRenderer>();
			if (component != null)
			{
				statModRenderers.Remove(component);
			}
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (statModifiers != null)
		{
			for (int num = statModifiers.Count - 1; num >= 0; num--)
			{
				statModifiers[num].End();
			}
			statModifiers.Clear();
		}
		if (statModRenderers != null)
		{
			statModRenderers.Clear();
		}
		if (statModifierDict != null)
		{
			statModifierDict.Clear();
		}
	}

	private static List<StatModifier> NewStack()
	{
		if (stackPool.Count > 0)
		{
			return stackPool.Pop();
		}
		return new List<StatModifier>(1);
	}

	private static void RecycleStack(List<StatModifier> stack)
	{
		stack.Clear();
		if (stackPool.Contains(stack))
		{
			Utils.LogError("Trying to recycle a stack that is already in the pool.");
		}
		else
		{
			stackPool.Push(stack);
		}
	}
}
