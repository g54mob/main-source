using UnityEngine;

[CreateAssetMenu(fileName = "HardenSpeed", menuName = "Upgrade/Harden/Speed")]
public class UpgradeHardenSpeed : EnhancementUpgrade
{
	[SerializeField]
	private float stackAmount;

	[SerializeField]
	private float buffDuration;

	[SerializeField]
	private float speedAmount;

	private ModuleHarden harden;

	private float totalDamageMitigated;

	private float timer;

	public override void ApplyUpgrade()
	{
		ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
		if ((object)moduleByType != null)
		{
			harden = moduleByType;
			harden.OnMitigateDamage += TrackMitigatedDamage;
		}
	}

	public override void UpdateUpgrade()
	{
		base.UpdateUpgrade();
		timer -= Time.deltaTime;
	}

	public void TrackMitigatedDamage(float mitigatedDamage)
	{
		if (!(timer > 0f))
		{
			totalDamageMitigated += mitigatedDamage;
			if (totalDamageMitigated >= stackAmount)
			{
				Train.Instance.SpeedUpBuff(speedAmount, buffDuration, isPercent: true);
				totalDamageMitigated = 0f;
				timer = buffDuration;
			}
		}
	}
}
