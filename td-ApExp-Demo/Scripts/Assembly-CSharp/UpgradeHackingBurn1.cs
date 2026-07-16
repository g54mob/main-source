using UnityEngine;

[CreateAssetMenu(fileName = "HackingBurn1", menuName = "Upgrade/Hacking/Burn1")]
public class UpgradeHackingBurn1 : EnhancementUpgrade
{
	private ModuleHacking moduleHacking;

	[SerializeField]
	private int burnAmount;

	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if ((object)moduleByType != null)
		{
			moduleHacking = moduleByType;
			moduleHacking.HackedEnemyHit += OnEnemyHit;
		}
	}

	private void OnEnemyHit(HealthChangeInfo info)
	{
		if (info.Target.TryGetComponent<Unit>(out var component) && component.IsEnemy)
		{
			component.HealthComponent.ApplyBurn(burnAmount, info.source);
		}
	}

	public override void OnRemove()
	{
		base.OnRemove();
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if ((object)moduleByType != null)
		{
			moduleHacking = moduleByType;
			moduleHacking.HackedEnemyHit -= OnEnemyHit;
		}
	}
}
