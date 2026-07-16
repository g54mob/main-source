using UnityEngine;

[CreateAssetMenu(fileName = "LeverUseWhenBroken", menuName = "Upgrade/Lever/UseWhenBroken")]
public class UpgradeLeverUseWhenBroken : EnhancementUpgrade
{
	private ModuleDirectionLever lever;

	public override void ApplyUpgrade()
	{
		lever = Train.Instance.GetModuleByType<ModuleDirectionLever>();
		lever.canTurnWhileBroken = true;
	}
}
