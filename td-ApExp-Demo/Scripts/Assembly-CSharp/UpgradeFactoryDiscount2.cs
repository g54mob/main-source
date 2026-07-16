using UnityEngine;

[CreateAssetMenu(fileName = "FactoryDiscount2", menuName = "Upgrade/Factory/Discount2")]
public class UpgradeFactoryDiscount2 : EnhancementUpgrade
{
	public float discountPercentIncrease;

	public override void ApplyUpgrade()
	{
		LootManager.Instance.AddCostModifier(discountPercentIncrease, ShopItemType.Ammo);
		LootManager.Instance.AddCostModifier(discountPercentIncrease, ShopItemType.Hull);
	}

	public override void OnRemove()
	{
		base.OnRemove();
		LootManager.Instance.RemoveCostModifier(discountPercentIncrease, ShopItemType.Ammo);
		LootManager.Instance.RemoveCostModifier(discountPercentIncrease, ShopItemType.Hull);
	}
}
