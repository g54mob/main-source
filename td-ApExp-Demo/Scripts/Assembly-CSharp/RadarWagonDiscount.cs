using UnityEngine;

[CreateAssetMenu(fileName = "27DiscountWagon", menuName = "Radar/27DiscountWagon")]
public class RadarWagonDiscount : EnhancementRadar
{
	[SerializeField]
	[Tooltip("The chance of for 1 of 2 wagons in the shop to be discounted, so 0.05 = 5% chance a wagon will be discounted.")]
	private float discountChance;

	public override void OnApplied()
	{
		LootManager.Instance.DiscountProbWagon += discountChance;
	}

	public override void OnRemoved()
	{
		LootManager.Instance.DiscountProbWagon -= discountChance;
	}
}
