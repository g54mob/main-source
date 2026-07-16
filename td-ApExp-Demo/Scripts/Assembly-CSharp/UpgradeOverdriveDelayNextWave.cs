using UnityEngine;

[CreateAssetMenu(fileName = "OverdriveDelayNextWave", menuName = "Upgrade/Overdrive/DelayNextWave")]
public class UpgradeOverdriveDelayNextWave : EnhancementUpgrade
{
	private ModuleOverdrive overdrive;

	public override void ApplyUpgrade()
	{
		overdrive = Train.Instance.GetModuleByType<ModuleOverdrive>();
		overdrive.OnInteractStartEvent += DelayNextWave;
	}

	public void DelayNextWave()
	{
		foreach (EnhancementUpgrade item in UpgradeManager.Instance.UpgradesInInventory)
		{
			Stats[] statsObjectsToUpgrade = item.StatsObjectsToUpgrade;
			for (int i = 0; i < statsObjectsToUpgrade.Length; i++)
			{
				if (statsObjectsToUpgrade[i] == overdrive.StatsSO)
				{
					EnemyManager.Instance.WaveTimer += 0.5f;
				}
			}
		}
	}
}
