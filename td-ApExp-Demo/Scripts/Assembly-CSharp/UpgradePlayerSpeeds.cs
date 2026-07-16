using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSpeeds", menuName = "Upgrade/Player/Speeds")]
public class UpgradePlayerSpeeds : EnhancementUpgrade
{
	[SerializeField]
	private float shovelModifier;

	[SerializeField]
	private float moveSpeedModifier;

	[SerializeField]
	private float repairModifier;

	public override void ApplyUpgrade()
	{
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.speedModifierShovel *= 1f + shovelModifier;
			player.UpgradeMoveSpeed(moveSpeedModifier);
			player.UpgradeRepairSpeed(repairModifier);
		}
	}
}
