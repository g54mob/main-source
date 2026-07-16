using UnityEngine;

[CreateAssetMenu(fileName = "DamageControlHardenCombo", menuName = "Upgrade/DamageControl/HardenCombo")]
public class UpgradeDamageControlHardenCombo : EnhancementUpgradeStats
{
	[SerializeField]
	private float hardenDamageReductionBoostPercent;

	[SerializeField]
	private float boostDuration;

	private ModuleDamageControl dc;

	private ModuleHarden harden;

	private float boostTimer;

	private bool boostOn;

	public override void ApplyUpgrade()
	{
		ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
		if ((object)moduleByType != null)
		{
			harden = moduleByType;
		}
		ModuleDamageControl moduleByType2 = Train.Instance.GetModuleByType<ModuleDamageControl>();
		if ((object)moduleByType2 != null)
		{
			dc = moduleByType2;
			dc.OnInteractStartEvent += BoostHarden;
		}
	}

	public void BoostHarden()
	{
		harden.DamageReductionPercent += hardenDamageReductionBoostPercent;
		boostTimer = boostDuration;
		boostOn = true;
	}

	public override void UpdateUpgrade()
	{
		base.UpdateUpgrade();
		if (boostOn)
		{
			if (boostTimer > 0f)
			{
				boostTimer -= Time.deltaTime;
			}
			else if (boostTimer <= 0f)
			{
				harden.DamageReductionPercent -= hardenDamageReductionBoostPercent;
				boostOn = false;
			}
		}
	}
}
