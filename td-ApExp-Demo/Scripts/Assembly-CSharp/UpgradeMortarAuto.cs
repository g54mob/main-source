using UnityEngine;

[CreateAssetMenu(fileName = "MortarAuto", menuName = "Upgrade/Mortar/Auto")]
public class UpgradeMortarAuto : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleMortar moduleByType = Train.Instance.GetModuleByType<ModuleMortar>();
		if ((object)moduleByType != null)
		{
			moduleByType.IsAutomatic = true;
		}
	}
}
