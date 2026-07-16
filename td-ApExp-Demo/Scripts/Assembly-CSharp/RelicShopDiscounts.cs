using UnityEngine;

[CreateAssetMenu(fileName = "RelicDiscounts", menuName = "Upgrade/Relic/Discounts")]
public class RelicShopDiscounts : EnhancementUpgrade
{
	[SerializeField]
	private float costMultiplier = -0.25f;

	public override void ApplyUpgrade()
	{
		LootManager.Instance.AddCostModifier(costMultiplier, ShopItemType.General);
	}
}
