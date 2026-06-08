using System;
using UnityEngine;

public class StatModifier : MonoBehaviour
{
	public string id;

	public bool stacks;

	public int maxStack = -1;

	public int ticDuration = -1;

	public bool cleansable = true;

	public bool isPositiveBuff;

	public string customHudSymbol;

	public Color customSymbolColor = Color.clear;

	private Item _sourceItem;

	private int elapsedTics;

	protected bool done;

	public ItemData.Ability abilityData { get; set; }

	public ItemData.Stat statData { get; set; }

	public Item sourceItem
	{
		get
		{
			return _sourceItem;
		}
		set
		{
			_sourceItem = value;
			if (_sourceItem != null)
			{
				element = _sourceItem.element;
			}
		}
	}

	public ItemData.Element element { get; set; }

	public Character character { get; set; }

	public ItemData.Rarity rarity { get; set; }

	public float initializationTimestamp { get; set; }

	public int ElapsedTics
	{
		get
		{
			return elapsedTics;
		}
		set
		{
			elapsedTics = value;
		}
	}

	public event Action<StatModifier> OnEnded;

	public event Action<StatModifier> OnDestroyed;

	public virtual void Init()
	{
		initializationTimestamp = Time.realtimeSinceStartup;
	}

	public virtual void ResetFromReapplying()
	{
		ElapsedTics = 0;
	}

	public virtual void ModDamage(Damage dmg, Character target)
	{
		if (statData == null)
		{
			return;
		}
		if (statData.type == ItemData.Stat.Type.Damage)
		{
			dmg.amount += Mathf.RoundToInt(ComputeStatValue());
		}
		else if (target != null && statData.type == ItemData.Stat.Type.ElementDamage)
		{
			int num = Mathf.RoundToInt(ComputeStatValue());
			ItemData.Element element = this.element;
			if (sourceItem != null && element == ItemData.Element.Stone)
			{
				element = sourceItem.element;
			}
			element = ((num < 0) ? ItemData.CounteredBy(element) : ItemData.Counters(element));
			if (target.tags.Contains(element.ToString()))
			{
				dmg.amount += num;
			}
		}
	}

	public virtual int ModMaxHealth(int maxHealth)
	{
		if (statData != null && statData.type == ItemData.Stat.Type.Health)
		{
			return maxHealth + Mathf.RoundToInt(ComputeStatValue());
		}
		return maxHealth;
	}

	public virtual int ModAttackSpeed(int attackSpeed)
	{
		if (statData != null && sourceItem != null)
		{
			if (statData.type == ItemData.Stat.Type.AttackSpeed)
			{
				return attackSpeed + Mathf.RoundToInt(ComputeStatValue());
			}
			if (statData.type == ItemData.Stat.Type.Stun)
			{
				return -99999;
			}
		}
		return attackSpeed;
	}

	public virtual float ModArmorPerSecond(float aps)
	{
		if (statData != null && statData.type == ItemData.Stat.Type.ArmorPerSecond)
		{
			return aps + ComputeStatValue();
		}
		return aps;
	}

	public virtual float ModMaxArmor(float maxArmor)
	{
		if (statData != null && statData.type == ItemData.Stat.Type.MaxArmor)
		{
			return maxArmor + ComputeStatValue();
		}
		return maxArmor;
	}

	public virtual int ModTicsPerMove(int ticsPerMove)
	{
		if (statData != null)
		{
			if (statData.type == ItemData.Stat.Type.Stun)
			{
				return 99999;
			}
			if (statData.type == ItemData.Stat.Type.TicsPerMove)
			{
				ticsPerMove += Mathf.RoundToInt(ComputeStatValue());
			}
		}
		return ticsPerMove;
	}

	public virtual float ModChanceToEvade(float chanceToEvade)
	{
		if (statData != null && sourceItem != null && statData.type == ItemData.Stat.Type.EvadeChance)
		{
			return chanceToEvade + ComputeStatValue();
		}
		return chanceToEvade;
	}

	public virtual float ModChanceToAOE(float chanceToAOE)
	{
		if (statData != null && sourceItem != null && statData.type == ItemData.Stat.Type.AoeChance)
		{
			return chanceToAOE + ComputeStatValue();
		}
		return chanceToAOE;
	}

	public virtual float ModChanceToLifesteal(float chanceToLifesteal)
	{
		if (statData != null && sourceItem != null && statData.type == ItemData.Stat.Type.LifestealChance)
		{
			return chanceToLifesteal + ComputeStatValue();
		}
		return chanceToLifesteal;
	}

	public virtual float ModCriticalChance(float criticalChance)
	{
		if (statData != null && sourceItem != null && statData.type == ItemData.Stat.Type.CritChance)
		{
			return criticalChance + ComputeStatValue();
		}
		return criticalChance;
	}

	public virtual float ModCriticalMultiplier(float criticalMultiplier)
	{
		if (statData != null && sourceItem != null && statData.type == ItemData.Stat.Type.CritMult)
		{
			return criticalMultiplier + ComputeStatValue();
		}
		return criticalMultiplier;
	}

	public virtual int ModRange(int range)
	{
		if (statData != null && sourceItem != null && statData.type == ItemData.Stat.Type.Range)
		{
			return range + Mathf.RoundToInt(ComputeStatValue());
		}
		return range;
	}

	protected float ComputeStatValue()
	{
		if (statData == null)
		{
			return 0f;
		}
		float num = ((sourceItem != null) ? ItemFactory.GetLevelDisplayValueForItem(sourceItem) : 0f);
		if (rarity != null)
		{
			num = ((!statData.rareStatOnly) ? (num + (float)rarity.levelBonus) : ((float)rarity.levelBonus));
		}
		return statData.Compute(num);
	}

	public float ComputeStatForSourceItemLevelAndRarity()
	{
		if (statData == null)
		{
			return 0f;
		}
		Item item = sourceItem;
		float num = 1f;
		if (item != null)
		{
			num = ItemFactory.GetLevelDisplayValueForItem(item);
			if (abilityData.applyRarity && item.rarity != null)
			{
				num = ((!statData.rareStatOnly) ? (num + (float)item.rarity.levelBonus) : ((float)item.rarity.levelBonus));
			}
		}
		return statData.Compute(num);
	}

	public float GetPercentComplete()
	{
		if (ticDuration > 0)
		{
			return (float)elapsedTics / (float)ticDuration;
		}
		return 1f;
	}

	public int GetRemainingTics()
	{
		return ticDuration - elapsedTics;
	}

	public virtual void UpdateTic()
	{
		if (!done && ticDuration >= 0)
		{
			elapsedTics++;
			if (elapsedTics >= ticDuration)
			{
				End();
			}
		}
	}

	public virtual void End()
	{
		if (!done)
		{
			done = true;
			if (this.OnEnded != null)
			{
				this.OnEnded(this);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	protected virtual void OnDestroy()
	{
		if (this.OnDestroyed != null)
		{
			this.OnDestroyed(this);
		}
		this.OnEnded = null;
		this.OnDestroyed = null;
		abilityData = null;
		statData = null;
		sourceItem = null;
		character = null;
		rarity = null;
	}
}
