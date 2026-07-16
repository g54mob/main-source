using UnityEngine;

[CreateAssetMenu(fileName = "RelicDiscountByAmmo", menuName = "Upgrade/Relic/DiscountByAmmo")]
public class RelicDiscountByAmmo : EnhancementUpgrade
{
	[SerializeField]
	private float ammoStackAmount;

	[SerializeField]
	private float discountPercentPerStack;

	[SerializeField]
	private float maxiumumDiscount;

	private float discountPercent;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		LevelManager.Instance.DestinationReached += ApplyDiscount;
		LevelManager.Instance.LevelStarted += RemoveDiscount;
	}

	public void ApplyDiscount()
	{
		if (LevelManager.Instance.CurrentLevel.LootType == LootType.Shop)
		{
			float num = ResourceManager.Instance.Ammo.Value;
			int num2 = 0;
			while (num >= ammoStackAmount)
			{
				num2++;
				num -= ammoStackAmount;
			}
			discountPercent = Mathf.Min(discountPercentPerStack * (float)num2, maxiumumDiscount);
			LootManager.Instance.AddCostModifier(0f - discountPercent, ShopItemType.General);
		}
	}

	public void RemoveDiscount()
	{
		LootManager.Instance.RemoveCostModifier(0f - discountPercent, ShopItemType.General);
	}
}
