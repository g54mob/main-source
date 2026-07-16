using UnityEngine;

[CreateAssetMenu(fileName = "8DiscountAmmoAndHull", menuName = "Radar/8DiscountAmmoAndHull")]
public class RadarDiscountAmmoAndHull : EnhancementRadar
{
	[SerializeField]
	[Tooltip("The chance of first offer of ammo or hull in the shop to be discounted, so 0.05 = 5% chance an offer to be discounted.")]
	private float firstDiscountChance;

	[SerializeField]
	[Tooltip("The chance of second offer of ammo or hull in the shop to be discounted, so 0.05 = 5% chance an offer to be discounted.")]
	private float secondDiscountChance;

	public override void OnApplied()
	{
		LootManager.Instance.DiscountProbAmmoAndHull1 += firstDiscountChance;
		LootManager.Instance.DiscountProbAmmoAndHull2 += secondDiscountChance;
	}

	public override void OnRemoved()
	{
		LootManager.Instance.DiscountProbAmmoAndHull1 -= firstDiscountChance;
		LootManager.Instance.DiscountProbAmmoAndHull2 -= secondDiscountChance;
	}
}
