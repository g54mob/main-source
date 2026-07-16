using UnityEngine;

[CreateAssetMenu(fileName = "OverdriveLootsurge", menuName = "Upgrade/Overdrive/UpgradeOverdriveLootsurge")]
public class UpgradeOverdriveLootsurge : EnhancementUpgrade
{
	[SerializeField]
	private float resourceGainMult = 0.4f;

	private float totalGainMult;

	private ModuleClaw claw;

	public override void ApplyUpgrade()
	{
		ModuleOverdrive moduleByType = Train.Instance.GetModuleByType<ModuleOverdrive>();
		if ((object)moduleByType != null)
		{
			moduleByType.OnOverdriveStart += OnOverdriveStart;
		}
		ModuleClaw moduleByType2 = Train.Instance.GetModuleByType<ModuleClaw>();
		if ((object)moduleByType2 != null)
		{
			claw = moduleByType2;
			claw.OnPickup += Claw_OnPickup;
		}
	}

	private void Claw_OnPickup()
	{
		LootManager.Instance.CacheMult -= totalGainMult;
		totalGainMult = 0f;
	}

	private void OnOverdriveStart()
	{
		totalGainMult += resourceGainMult;
		LootManager.Instance.CacheMult += resourceGainMult;
	}
}
