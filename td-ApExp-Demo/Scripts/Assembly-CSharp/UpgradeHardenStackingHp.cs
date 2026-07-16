using UnityEngine;

[CreateAssetMenu(fileName = "HardenStackingHp", menuName = "Upgrade/Harden/StackingHp")]
public class UpgradeHardenStackingHp : EnhancementUpgrade
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
				StatUtils.RaiseMaxHp(module, statusEffectSO);
			}
		}
		totalDamageMitigated = 0f;
	}
}
