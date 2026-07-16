using UnityEngine;

[CreateAssetMenu(fileName = "HackingSunder2", menuName = "Upgrade/Hacking/Sunder2")]
public class UpgradeHackingSunder2 : EnhancementUpgrade
{
	private ModuleHacking moduleHacking;

	[SerializeField]
	private int sunderAmount;

	public override void ApplyUpgrade()
	{
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
			for (int i = 0; i < sunderAmount; i++)
			{
				component.HealthComponent.ApplySunder();
			}
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
