using UnityEngine;

public class TreeUpgradeCard : UpgradeCard
{
	[SerializeField]
	private int treeCardChanceMultiplierInt;

	public override void Upgrade()
	{
		base.Upgrade();
		GameManager.instance.treeCardChanceMultiplier += treeCardChanceMultiplierInt;
	}
}
