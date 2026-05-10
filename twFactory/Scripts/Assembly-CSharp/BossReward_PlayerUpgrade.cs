using UnityEngine;

[CreateAssetMenu(fileName = "BossReward_playerUpgrade_default", menuName = "Tower Factory/Boss Rewards/Player Upgrade")]
public class BossReward_PlayerUpgrade : BossReward
{
	[SerializeField]
	private PlayerUpgrade playerUpgrade;

	public override void GiveBossReward()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().UnlockUpgrade(playerUpgrade, unlockedByPlayer: false);
	}
}
