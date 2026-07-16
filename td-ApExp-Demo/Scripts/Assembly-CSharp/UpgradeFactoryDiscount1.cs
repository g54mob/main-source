using UnityEngine;

[CreateAssetMenu(fileName = "FactoryDiscount1", menuName = "Upgrade/Factory/Discount1")]
public class UpgradeFactoryDiscount1 : EnhancementUpgrade
{
	public float discountPercent;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		LootManager.Instance.AddCostModifier(discountPercent, ShopItemType.Ammo);
		LootManager.Instance.AddCostModifier(discountPercent, ShopItemType.Hull);
	}

	public override void OnRemove()
	{
		base.OnRemove();
		LootManager.Instance.RemoveCostModifier(discountPercent, ShopItemType.Ammo);
		LootManager.Instance.RemoveCostModifier(discountPercent, ShopItemType.Hull);
	}
}
