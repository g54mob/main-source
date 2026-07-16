using UnityEngine;

[CreateAssetMenu(fileName = "ModulesDeathBullets", menuName = "Upgrade/Modules/DeathBullets")]
public class UpgradeModulesDeathBullets : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.moduleDeathBulletBurst = true;
	}
}
