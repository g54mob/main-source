using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public abstract class Enhancement : ScriptableObject
{
	[field: SerializeField]
	public string Name { get; private set; }

	[field: SerializeField]
	[field: TextArea(20, 20)]
	public string Description { get; private set; }

	[field: SerializeField]
	public LocalizedString NameKey { get; private set; }

	[field: SerializeField]
	public LocalizedString DescriptionKey { get; private set; }

	[field: SerializeField]
	public Sprite Icon { get; private set; }

	[field: SerializeField]
	public Rarity Rarity { get; private set; }

	[field: SerializeField]
	public int CostOverride { get; private set; }

	[field: SerializeField]
	public bool Locked { get; set; }

	[field: SerializeField]
	public bool LockedOnRuntime { get; set; }

	[field: SerializeField]
	[field: Tooltip("From which Zone will it start to appear")]
	public int Zone { get; private set; }

	public virtual int Cost
	{
		get
		{
			int cost = ((CostOverride != 0) ? CostOverride : LootManager.Instance.CostPerRarity[Rarity]);
			return LootManager.Instance.ApplyCostModifier(cost, ShopItemType.Enhancment);
		}
	}

	public override bool Equals(object obj)
	{
		if (obj is Enhancement enhancement)
		{
			return Name == enhancement.Name;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public virtual string GetEnhancementType()
	{
		return null;
	}

	public virtual string GetEnhancementSimplified()
	{
		return null;
	}
}
