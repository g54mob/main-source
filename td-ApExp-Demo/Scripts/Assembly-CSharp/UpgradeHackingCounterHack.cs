using UnityEngine;

[CreateAssetMenu(fileName = "HackingCounterHack", menuName = "Upgrade/Hacking/UpgradeHackingCounterHack")]
public class UpgradeHackingCounterHack : EnhancementUpgrade
{
	[SerializeField]
	private int enemiesCount = 2;

	private ModuleHacking hackingModule;

	public override void ApplyUpgrade()
	{
		Module[] modulesByType = Train.Instance.GetModulesByType<Module>();
		if (modulesByType != null)
		{
			for (int i = 0; i < modulesByType.Length; i++)
			{
				modulesByType[i].FullyBroken += OnModuleFullyBroken;
			}
		}
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if ((object)moduleByType != null)
		{
			hackingModule = moduleByType;
		}
	}

	private void OnModuleFullyBroken()
	{
		EnemyBase[] hackableEnemies = hackingModule.GetHackableEnemies(enemiesCount);
		if (hackableEnemies.Length != 0)
		{
			EnemyBase[] array = hackableEnemies;
			foreach (EnemyBase enemyToHack in array)
			{
				hackingModule.HackEnemy(enemyToHack);
			}
		}
	}
}
