using UnityEngine;

[CreateAssetMenu(fileName = "Missiles", menuName = "Upgrade/Shield/Missiles")]
public class UpgradeShieldMissiles : EnhancementUpgrade
{
	[SerializeField]
	public int numberOfMissiles;

	[SerializeField]
	public float damageNeededToFire;

	public override void ApplyUpgrade()
	{
		ModuleShield moduleByType = Train.Instance.GetModuleByType<ModuleShield>();
		if ((object)moduleByType != null)
		{
			moduleByType.missilesReady = true;
			moduleByType.numberOfMissiles = numberOfMissiles;
			moduleByType.missileDamageNeeded = damageNeededToFire;
		}
	}
}
