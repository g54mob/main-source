using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HackingCompanion", menuName = "Upgrade/Hacking/Companion")]
public class UpgradeHackingCompanion : EnhancementUpgrade
{
	[SerializeField]
	private List<EnemySpawn> companionPerZone;

	private ModuleHacking moduleHacking;

	public override void ApplyUpgrade()
	{
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if ((object)moduleByType != null)
		{
			moduleHacking = moduleByType;
		}
		LevelManager.Instance.LevelStarted += SpawnCompanion;
	}

	private void SpawnCompanion()
	{
		if (companionPerZone[ZoneManager.Instance.CurrentZoneIndex].EnemyType != EnemyTypes.None && EnemyManager.Instance.SpawnEnemy(companionPerZone[ZoneManager.Instance.CurrentZoneIndex]).TryGetComponent<EnemyBase>(out var component))
		{
			moduleHacking.ForceInfiniteHack(component);
		}
	}
}
