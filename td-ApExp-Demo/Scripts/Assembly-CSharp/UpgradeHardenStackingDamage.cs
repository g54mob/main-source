using UnityEngine;

[CreateAssetMenu(fileName = "HardenStackingDamage", menuName = "Upgrade/Harden/StackingDamage")]
public class UpgradeHardenStackingDamage : EnhancementUpgrade
{
	[SerializeField]
	private float stackAmount;

	[SerializeField]
	private StatusEffect statusEffectSO;

	private ModuleHarden harden;

	private float totalDamageMitigated;

	public override void ApplyUpgrade()
	{
		ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
		if ((object)moduleByType != null)
		{
			harden = moduleByType;
			harden.OnMitigateDamage += TrackMitigatedDamage;
			LevelManager.Instance.LevelCompleted += RemoveDamageBuff;
		}
	}

	public void TrackMitigatedDamage(float mitigatedDamage)
	{
		totalDamageMitigated += mitigatedDamage;
		if (!(totalDamageMitigated >= stackAmount))
		{
			return;
		}
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				StatUtils.IncreaseDamage(module, statusEffectSO);
			}
		}
		totalDamageMitigated = 0f;
	}

	public void RemoveDamageBuff()
	{
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				StatUtils.RemoveBuff(module, statusEffectSO);
			}
		}
		totalDamageMitigated = 0f;
	}
}
