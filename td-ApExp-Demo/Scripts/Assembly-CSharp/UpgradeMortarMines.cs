using UnityEngine;

[CreateAssetMenu(fileName = "MortarMines", menuName = "Upgrade/Mortar/Mines")]
public class UpgradeMortarMines : EnhancementUpgradeStats
{
	public override void ApplyUpgrade()
	{
		ModuleMortar moduleByType = Train.Instance.GetModuleByType<ModuleMortar>();
		if ((object)moduleByType != null)
		{
			moduleByType.areShellsMines = true;
		}
	}
}
