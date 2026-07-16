using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "Upgrade/Shield/Waves")]
public class UpgradeShieldWaves : EnhancementUpgrade
{
	[SerializeField]
	private float damage;

	[SerializeField]
	public float damageNeededToFire;

	public override void ApplyUpgrade()
	{
		ModuleShield moduleByType = Train.Instance.GetModuleByType<ModuleShield>();
		if ((object)moduleByType != null)
		{
			moduleByType.wavesReady = true;
			moduleByType.waveDamage = damage;
			moduleByType.wavesDamageNeeded = damageNeededToFire;
		}
	}
}
