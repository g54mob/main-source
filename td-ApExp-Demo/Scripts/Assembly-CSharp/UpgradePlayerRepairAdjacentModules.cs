using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRepairAdjacentModules", menuName = "Upgrade/Player/RepairAdjacentModules")]
public class UpgradePlayerRepairAdjacentModules : EnhancementUpgrade
{
	[SerializeField]
	private float repairAmountPercent;

	public override void ApplyUpgrade()
	{
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.UpgradeRepairAdjacentModules(repairAmountPercent);
		}
	}
}
