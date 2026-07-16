using UnityEngine;

[CreateAssetMenu(fileName = "MortarDeathPrevent", menuName = "Upgrade/Nuke/DeathPrevent")]
public class UpgradeNukeDeathPrevent : EnhancementUpgrade
{
	private ModuleNuke nuke;

	public override void ApplyUpgrade()
	{
		ModuleNuke moduleByType = Train.Instance.GetModuleByType<ModuleNuke>();
		if ((object)moduleByType != null)
		{
			nuke = moduleByType;
		}
		Train.Instance.HealthComponent.PreLethalDamage += PreTrainLethalDamage;
	}

	private void PreTrainLethalDamage(ref HealthChangeInfo info)
	{
		if (nuke.NukeCount != 0)
		{
			info.HealthChange = 0f;
			nuke.StartLaunch();
		}
	}
}
