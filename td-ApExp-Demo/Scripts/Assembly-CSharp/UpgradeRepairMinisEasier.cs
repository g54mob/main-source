using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRepairMinigamesEasier", menuName = "Upgrade/Player/RepairMinigamesEasier")]
public class UpgradeRepairMinisEasier : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		GameManager.Instance.UpgradeMinigames();
	}
}
