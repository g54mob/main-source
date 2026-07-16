using UnityEngine;

[CreateAssetMenu(fileName = "FactoryScrapFromBoss", menuName = "Upgrade/Factory/ScrapFromBoss")]
public class UpgradeFactoryScrapFromBoss : EnhancementUpgrade
{
	[SerializeField]
	private float minScrapGainedPerDamageOnBoss;

	[SerializeField]
	private float maxScrapGainedPerDamageOnBoss;

	[SerializeField]
	private float chanceToGainScrap;

	private ModuleFactory factory;

	public override void ApplyUpgrade()
	{
		factory = Train.Instance.GetModuleByType<ModuleFactory>();
		CombatManager.Instance.HealthChanged += GetScrap;
	}

	private void GetScrap(HealthChangeInfo info)
	{
		if (info.HealthChange >= 0f)
		{
			return;
		}
		EnemyBase component = info.Target.gameObject.GetComponent<EnemyBase>();
		if ((object)component == null || !component.IsBoss)
		{
			return;
		}
		float num = Mathf.Abs(info.HealthChange);
		for (int i = 0; (float)i < num; i++)
		{
			if (ProbUtils.CheckWithLuck(chanceToGainScrap))
			{
				factory.AddResource(Random.Range(minScrapGainedPerDamageOnBoss, maxScrapGainedPerDamageOnBoss + 1f), ResourceTypes.Scrap);
			}
		}
	}
}
