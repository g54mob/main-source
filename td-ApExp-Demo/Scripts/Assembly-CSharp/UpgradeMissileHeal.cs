using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissileHeal", menuName = "Upgrade/Missile/Heal")]
public class UpgradeMissileHeal : EnhancementUpgrade
{
	[SerializeField]
	private float healAmount;

	[SerializeField]
	private float chanceToHeal;

	private List<Module> damagedModules;

	public override void ApplyUpgrade()
	{
		ModuleMissile moduleByType = Train.Instance.GetModuleByType<ModuleMissile>();
		if ((object)moduleByType != null)
		{
			moduleByType.OnHit += HealRandomModule;
		}
		damagedModules = new List<Module>();
	}

	public void HealRandomModule()
	{
		if (!ProbUtils.CheckWithLuck(chanceToHeal))
		{
			return;
		}
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module && (bool)module.HealthComponent && module.HealthComponent.HealthCurrent < module.HealthComponent.HealthMax && !module.IsFullyBroken)
			{
				damagedModules.Add(module);
			}
		}
		if (damagedModules.Count != 0)
		{
			int index = Random.Range(0, damagedModules.Count);
			damagedModules[index].HealthComponent.Heal(healAmount, Train.Instance.GetModuleByType<ModuleMissile>());
			damagedModules.Clear();
		}
	}
}
