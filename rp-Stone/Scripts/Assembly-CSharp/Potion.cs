using System;
using System.Collections.Generic;

public class Potion : Item, IAbilityActivationProvider
{
	public enum Type
	{
		Empty = 0,
		Healing = 1,
		Armor = 2,
		Cleanse = 3,
		Vampiric = 4,
		Strength = 5,
		Invisibility = 6,
		CriticalStrike = 7,
		Alacrity = 8,
		AttackSpeed = 9,
		AoeDamage = 10,
		Experience = 11,
		FireElemental = 12
	}

	private Type _type;

	private Type lastType;

	private List<Data.Cost> _costs = new List<Data.Cost>();

	public static Action<Potion> OnPotionActivated;

	public Type type
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
			UpdateContent();
		}
	}

	public bool autoRefill { get; set; }

	public List<Data.Cost> costs => _costs;

	public static Type GetPotionForResources(List<Data.Resource> resources)
	{
		if (AreResources(resources, Data.Resource.Tar))
		{
			return Type.Healing;
		}
		if (AreResources(resources, Data.Resource.Tar, Data.Resource.Stone))
		{
			return Type.Armor;
		}
		if (AreResources(resources, Data.Resource.Tar, Data.Resource.Wood))
		{
			return Type.Cleanse;
		}
		if (AreResources(resources, Data.Resource.Tar, Data.Resource.Bronze))
		{
			return Type.Vampiric;
		}
		if (AreResources(resources, Data.Resource.Stone))
		{
			return Type.Strength;
		}
		if (AreResources(resources, Data.Resource.Stone, Data.Resource.Wood))
		{
			return Type.Invisibility;
		}
		if (AreResources(resources, Data.Resource.Stone, Data.Resource.Bronze))
		{
			return Type.CriticalStrike;
		}
		if (AreResources(resources, Data.Resource.Wood))
		{
			return Type.Experience;
		}
		if (AreResources(resources, Data.Resource.Wood, Data.Resource.Bronze))
		{
			return Type.AttackSpeed;
		}
		if (AreResources(resources, Data.Resource.Bronze))
		{
			return Type.AoeDamage;
		}
		return Type.Empty;
	}

	public void UpdateContent()
	{
		if (type == Type.Empty)
		{
			displayName = "Empty Bottle";
			iconPath = "Relics/Potions/Icons/potion_empty_icon";
			description.line1 = "";
		}
		else if (type == Type.Healing)
		{
			displayName = "Healing Potion";
			iconPath = "Relics/Potions/Icons/potion_tar_tar_icon";
			description.line1 = "tid_potion_02";
		}
		else if (type == Type.Armor)
		{
			displayName = "Defensive Potion";
			iconPath = "Relics/Potions/Icons/potion_tar_stone_icon";
			description.line1 = "tid_potion_04";
		}
		else if (type == Type.Cleanse)
		{
			displayName = "Cleansing Potion";
			iconPath = "Relics/Potions/Icons/potion_tar_wood_icon";
			description.line1 = "tid_potion_06";
		}
		else if (type == Type.Vampiric)
		{
			displayName = "Vampiric Potion";
			iconPath = "Relics/Potions/Icons/potion_tar_bronze_icon";
			description.line1 = "tid_potion_08";
		}
		else if (type == Type.Strength)
		{
			displayName = "Strength Potion";
			iconPath = "Relics/Potions/Icons/potion_stone_stone_icon";
			description.line1 = "tid_potion_10";
		}
		else if (type == Type.Invisibility)
		{
			displayName = "Invisibility Potion";
			iconPath = "Relics/Potions/Icons/potion_stone_wood_icon";
			description.line1 = "tid_potion_12";
		}
		else if (type == Type.CriticalStrike)
		{
			displayName = "Lucky Potion";
			iconPath = "Relics/Potions/Icons/potion_stone_bronze_icon";
			description.line1 = "tid_potion_14";
		}
		else if (type == Type.Alacrity)
		{
			displayName = "Acrobatic Potion";
			iconPath = "Relics/Potions/Icons/potion_wood_wood_icon";
			description.line1 = "↓◘ For 30 seconds, dash back each time a ranged weapon is equipped and dash forward each time a melee weapon is equipped.";
		}
		else if (type == Type.AttackSpeed)
		{
			displayName = "Berserk Potion";
			iconPath = "Relics/Potions/Icons/potion_wood_bronze_icon";
			description.line1 = "tid_potion_16";
		}
		else if (type == Type.AoeDamage)
		{
			displayName = "Lightning Potion";
			iconPath = "Relics/Potions/Icons/potion_bronze_bronze_icon";
			description.line1 = "tid_potion_18";
		}
		else if (type == Type.Experience)
		{
			displayName = "Experience Potion";
			iconPath = "Relics/Potions/Icons/potion_wood_wood_icon";
			description.line1 = "tid_potion_20";
		}
		else if (type == Type.FireElemental)
		{
			displayName = "Trapped Cinderwisp";
			iconPath = "Relics/Potions/Icons/potion_fire_elemental_icon";
			description.line1 = "tid_q_blow_stu_0";
		}
	}

	public string GetId()
	{
		return "potion";
	}

	public bool IsAvailable()
	{
		return type != Type.Empty;
	}

	public new AsciiSprite GetIcon()
	{
		return IconLoader.Singleton.GetSharedIcon(iconPath);
	}

	public virtual bool IsEnabled()
	{
		return type != Type.FireElemental;
	}

	public bool IsWaiting()
	{
		return type != Type.Empty;
	}

	public float GetCooldownRemaining()
	{
		return 0f;
	}

	public SuperAbilityActivationState ActivateAbility()
	{
		SuperAbilityActivationState superAbilityActivationState = null;
		superAbilityActivationState = type switch
		{
			Type.Armor => GetComponentInChildren<DefensivePotionActivationState>(), 
			Type.Cleanse => GetComponentInChildren<CleansingPotionActivationState>(), 
			Type.Vampiric => GetComponentInChildren<VampiricPotionActivationState>(), 
			Type.Strength => GetComponentInChildren<StrengthPotionActivationState>(), 
			Type.Invisibility => GetComponentInChildren<InvisibilityPotionActivationState>(), 
			Type.CriticalStrike => GetComponentInChildren<LuckyPotionActivationState>(), 
			Type.AttackSpeed => GetComponentInChildren<BerserkPotionActivationState>(), 
			Type.AoeDamage => GetComponentInChildren<LightningPotionActivationState>(), 
			Type.Experience => GetComponentInChildren<ExperiencePotionActivationState>(), 
			Type.FireElemental => null, 
			_ => GetComponentInChildren<HealingPotionActivationState>(), 
		};
		if (superAbilityActivationState != null && superAbilityActivationState.CanActivate())
		{
			OnPotionActivated?.Invoke(this);
		}
		return superAbilityActivationState;
	}

	public void Refill()
	{
		if (lastType != Type.Empty)
		{
			Refill(lastType);
		}
	}

	public void Refill(Type newType)
	{
		for (int i = 0; i < costs.Count; i++)
		{
			Data.Cost cost = costs[i];
			if (InventoryResources.singleton.GetResourceOfType(cost.resource) < cost.amount)
			{
				return;
			}
		}
		for (int j = 0; j < costs.Count; j++)
		{
			Data.Cost cost2 = costs[j];
			InventoryResources.singleton.RemoveResourceOfType(cost2.resource, cost2.amount);
		}
		type = newType;
		lastType = newType;
	}

	public static Potion GetItem()
	{
		return (Potion)Inventory.Singleton.GetFirstItemWithId("potion");
	}

	private static bool AreResources(List<Data.Resource> resources, Data.Resource res)
	{
		if (resources.Count == 1)
		{
			return resources[0] == res;
		}
		return false;
	}

	private static bool AreResources(List<Data.Resource> resources, Data.Resource resA, Data.Resource resB)
	{
		if (resources.Count == 2)
		{
			if (resources[0] != resA || resources[1] != resB)
			{
				if (resources[0] == resB)
				{
					return resources[1] == resA;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override void ParseMore(string sjson)
	{
		base.ParseMore(sjson);
		type = SlimJson.ParseEnum<Type>(sjson, "potion_type");
		lastType = SlimJson.ParseEnum<Type>(sjson, "last_type");
		autoRefill = SlimJson.ParseBool(sjson, "auto_refill");
		costs.Clear();
		Data.Cost[] array = SlimJson.ParseArray(sjson, "costs", Data.Cost.FromString);
		if (array != null)
		{
			costs.AddRange(array);
		}
	}

	public override void SerializeMore()
	{
		base.SerializeMore();
		SlimJson.AddProperty("potion_type", type.ToString());
		SlimJson.AddProperty("last_type", lastType.ToString());
		SlimJson.AddProperty("auto_refill", autoRefill);
		if (costs.Count > 0)
		{
			SlimJson.AddProperty("costs", costs.ToArray());
		}
	}
}
