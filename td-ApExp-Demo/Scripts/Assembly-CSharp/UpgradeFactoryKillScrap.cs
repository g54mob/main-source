using UnityEngine;

[CreateAssetMenu(fileName = "FactoryKillScrap", menuName = "Upgrade/Factory/KillScrap")]
public class UpgradeFactoryKillScrap : EnhancementUpgrade
{
	[SerializeField]
	private float scrapGain = 5f;

	[SerializeField]
	private float scrapProb = 0.05f;

	private ModuleFactory factory;

	public override void ApplyUpgrade()
	{
		factory = Train.Instance.GetModuleByType<ModuleFactory>();
		CombatManager.Instance.EnemyKilled += OnEnemyKilled;
	}

	private void OnEnemyKilled(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		if (!killer.IsEnemy)
		{
			float num = scrapProb + scrapProb * GlobalFields.Instance.LuckProb;
			if (!(Random.Range(0f, 1f) > num))
			{
				factory.AddResource(scrapProb, ResourceTypes.Scrap);
			}
		}
	}

	public override void OnRemove()
	{
		base.OnRemove();
		CombatManager.Instance.EnemyKilled -= OnEnemyKilled;
	}
}
