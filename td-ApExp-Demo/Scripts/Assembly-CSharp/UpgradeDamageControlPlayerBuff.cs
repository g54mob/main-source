using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageControlPlayerBuff", menuName = "Upgrade/DamageControl/PlayerBuff")]
public class UpgradeDamageControlPlayerBuff : EnhancementUpgradeStats
{
	[SerializeField]
	private float playerStatAddMult = 0.3f;

	private ModuleDamageControl dc;

	private List<PlayerController> players = new List<PlayerController>();

	private int affectedPlayersCount;

	public override void ApplyUpgrade()
	{
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			if (!(player == null))
			{
				affectedPlayersCount++;
				players.Add(player);
			}
		}
		ModuleDamageControl moduleByType = Train.Instance.GetModuleByType<ModuleDamageControl>();
		if ((object)moduleByType != null)
		{
			dc = moduleByType;
			dc.Started += StartBuff;
			dc.Ended += EndBuff;
			dc.FullyBroken += EndBuff;
		}
	}

	private void StartBuff()
	{
		SetBuffActive(isActive: true);
	}

	private void EndBuff()
	{
		SetBuffActive(isActive: false);
	}

	private void SetBuffActive(bool isActive)
	{
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			if (!(player == null))
			{
				ApplyBuffToPlayer(player, isActive);
			}
		}
	}

	private void ApplyBuffToPlayer(PlayerController player, bool isActive)
	{
		float num = 1f;
		if (isActive)
		{
			num = 1f + playerStatAddMult * dc.GetUpgradedStatValueByStatType(StatTypes.damage);
		}
		player.speedModifierMove = num;
		player.speedModifierRepair = num;
		player.speedModifierShovel = num;
	}
}
