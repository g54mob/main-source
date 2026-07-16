using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RelicBurnSpread", menuName = "Upgrade/Relic/BurnSpread")]
public class RelicBurnSpread : EnhancementUpgrade
{
	[SerializeField]
	private float chanceForBurnToSpread = 0.2f;

	[SerializeField]
	private float spreadRange = 1f;

	[SerializeField]
	private float stackTransferModifier = 1f;

	[SerializeField]
	private GameObject fireEmber;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		CombatManager.Instance.EnemyKilled += EnemyBurned;
	}

	private void EnemyBurned(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		if (enemy.HealthComponent.burnStack == 0f)
		{
			return;
		}
		List<EnemyBase> alliesInRange = UnitHelper.GetAlliesInRange(enemy, spreadRange);
		if (alliesInRange == null)
		{
			return;
		}
		foreach (EnemyBase item in alliesInRange)
		{
			if ((bool)item.HealthComponent && ProbUtils.CheckWithLuck(chanceForBurnToSpread))
			{
				SpawnProjectile(enemy, item, enemy.HealthComponent.burnStack * stackTransferModifier);
			}
		}
	}

	public void SpawnProjectile(Unit source, Unit target, float burnAmount)
	{
		ProjectileFireEmber component = Object.Instantiate(fireEmber, source.transform.position, Quaternion.identity, null).GetComponent<ProjectileFireEmber>();
		component.targetPos = target.transform.position;
		component.burn = burnAmount;
		component.speedMult = 1f;
	}

	public override void OnRemove()
	{
		base.OnRemove();
		CombatManager.Instance.EnemyKilled -= EnemyBurned;
	}
}
