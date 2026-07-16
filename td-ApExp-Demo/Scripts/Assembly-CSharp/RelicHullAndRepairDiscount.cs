using UnityEngine;

[CreateAssetMenu(fileName = "RelicHullAndRepairDiscount", menuName = "Upgrade/Relic/HullAndRepairDiscount")]
public class RelicHullAndRepairDiscount : EnhancementUpgrade, IEnhancementMaxHull
{
	[SerializeField]
	private float repairDiscountMult = -0.5f;

	[SerializeField]
	private float trainHullInc = 500f;

	public override void ApplyUpgrade()
	{
		LootManager.Instance.AddCostModifier(repairDiscountMult, ShopItemType.Hull);
		Train.Instance.HealthComponent.ChangeMaxHealthBy(trainHullInc);
	}

	public override void OnRemove()
	{
		LootManager.Instance.RemoveCostModifier(repairDiscountMult, ShopItemType.Hull);
	}

	public void ExecuteOnLoad()
	{
	}
}
