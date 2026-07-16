using UnityEngine;

[CreateAssetMenu(fileName = "MortarShellBullets", menuName = "Upgrade/Mortar/ShellBullets")]
public class UpgradeMortarShellBullets : EnhancementUpgrade
{
	private ModuleMortar mortar;

	public override void ApplyUpgrade()
	{
		mortar = Train.Instance.GetModuleByType<ModuleMortar>();
		mortar.splashBullets = true;
	}
}
