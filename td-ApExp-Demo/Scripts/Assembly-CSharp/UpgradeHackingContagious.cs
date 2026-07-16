using UnityEngine;

[CreateAssetMenu(fileName = "HackingContagious", menuName = "Upgrade/Hacking/Contagious")]
public class UpgradeHackingContagious : EnhancementUpgrade
{
	private ModuleHacking moduleHacking;

	[SerializeField]
	private float prob = 0.05f;

	public override void ApplyUpgrade()
	{
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if ((object)moduleByType != null)
		{
			moduleHacking = moduleByType;
			moduleByType.HackedEnemyHit += OnEnemyHit;
		}
	}

	private void OnEnemyHit(HealthChangeInfo info)
	{
		if (ProbUtils.CheckWithLuck(prob) && info.Target.TryGetComponent<Unit>(out var component) && component.IsEnemy && moduleHacking.IsEnemyHackable(component))
		{
			moduleHacking.HackEnemy(component as EnemyBase);
		}
	}
}
