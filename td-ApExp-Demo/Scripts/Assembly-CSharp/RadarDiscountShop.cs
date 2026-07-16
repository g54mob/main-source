using UnityEngine;

[CreateAssetMenu(fileName = "17DiscountShop", menuName = "Radar/17DiscountShop")]
public class RadarDiscountShop : EnhancementRadar
{
	[SerializeField]
	[Tooltip("The chance of first card in the shop to be discounted, so 0.05 = 5% chance for first card to be discounted.")]
	private float shopDiscountProbIncFirst;

	[SerializeField]
	[Tooltip("The chance of second card in the shop being discounted, so 0.05 = 5% chance for second card to be discounted.")]
	private float shopDiscountProbIncSecond;

	public override void OnApplied()
	{
		LootManager.Instance.DiscountProbShop1 += shopDiscountProbIncFirst;
		LootManager.Instance.DiscountProbShop2 += shopDiscountProbIncSecond;
	}

	public override void OnRemoved()
	{
		LootManager.Instance.DiscountProbShop1 -= shopDiscountProbIncFirst;
		LootManager.Instance.DiscountProbShop2 -= shopDiscountProbIncSecond;
	}
}
