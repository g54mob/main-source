using UnityEngine;

[CreateAssetMenu(fileName = "New Module", menuName = "Module/Create New Module")]
public class EnhancementModule : Enhancement
{
	[field: SerializeField]
	public GameObject ModulePrefab { get; private set; }

	[field: SerializeField]
	public ModuleCombatTypes ModuleCombatType { get; private set; }

	[field: SerializeField]
	public ModuleTypes ModuleType { get; private set; }

	public override int Cost
	{
		get
		{
			int cost = ((base.CostOverride == 0) ? LootManager.Instance.CostPerRarityModules[base.Rarity] : base.CostOverride);
			return LootManager.Instance.ApplyCostModifier(cost, ShopItemType.Enhancment);
		}
	}

	public override string GetEnhancementType()
	{
		return $"<color=#{ColorUtils.ColorToHex(UIManager.Instance.RarityColor(base.Rarity))}>{base.Rarity} Module</color>";
	}

	public override string GetEnhancementSimplified()
	{
		return "<color=#" + ColorUtils.ColorToHex(UIManager.Instance.RarityColor(base.Rarity)) + ">Module</color>";
	}
}
