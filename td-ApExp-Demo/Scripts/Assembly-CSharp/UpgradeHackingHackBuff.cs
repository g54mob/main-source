using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HackingHackBuff", menuName = "Upgrade/Hacking/HackBuff")]
public class UpgradeHackingHackBuff : EnhancementUpgrade
{
	[SerializeField]
	private float percentHpIncrease;

	[SerializeField]
	private int maxOpponents;

	private ModuleHacking moduleHacking;

	private Action handler;

	public override void ApplyUpgrade()
	{
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if ((object)moduleByType != null)
		{
			moduleHacking = moduleByType;
			moduleHacking.OnEnemyHacked += BuffEnemy;
			moduleHacking.OnHackExpiration += DebuffEnemy;
		}
	}

	private void BuffEnemy(EnemyBase enemy)
	{
		enemy.HealthComponent.SetMaxHealth(enemy.HealthComponent.HealthMax * (1f + percentHpIncrease / 100f));
		enemy.maxNumberOfOpponents = maxOpponents;
		handler = delegate
		{
			enemy.numberOfCurrentOpponents = 0;
		};
		EnemyManager.Instance.OnWaweSpawned += handler;
	}

	private void DebuffEnemy(EnemyBase enemy)
	{
		enemy.HealthComponent.SetMaxHealth(enemy.HealthComponent.HealthMax * (1f - percentHpIncrease / 100f));
		enemy.maxNumberOfOpponents = 100;
		EnemyManager.Instance.OnWaweSpawned -= handler;
	}
}
