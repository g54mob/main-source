using UnityEngine;

public class HauntedHouseUpgrade : UpgradeCard
{
	[SerializeField]
	private float rateIncrease;

	public override void Upgrade()
	{
		base.Upgrade();
		GameManager.instance.hauntedHouseTaxRate += rateIncrease;
	}
}
