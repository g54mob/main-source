using UnityEngine;

[CreateAssetMenu(fileName = "MissileEnhanced", menuName = "Upgrade/Missile/Enhanced")]
public class UpgradeMissileEnhanced : EnhancementUpgrade
{
	[SerializeField]
	private GameObject enhancedMissileGO;

	[SerializeField]
	private float enhancedMissileHp;

	private ModuleMissile missile;

	public override void ApplyUpgrade()
	{
		missile = Train.Instance.GetModuleByType<ModuleMissile>();
		missile.upgradedMissiles = true;
		missile.enhancedMissilePrefab = enhancedMissileGO;
		missile.upgradedMissilesHp = enhancedMissileHp;
	}
}
