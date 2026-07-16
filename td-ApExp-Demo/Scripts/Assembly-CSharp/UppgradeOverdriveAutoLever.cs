using UnityEngine;

[CreateAssetMenu(fileName = "OverdriveAutoLever", menuName = "Upgrade/Overdrive/AutoLever")]
public class UppgradeOverdriveAutoLever : EnhancementUpgrade
{
	private ModuleOverdrive overdrive;

	private ModuleDirectionLever lever;

	public override void ApplyUpgrade()
	{
		lever = Train.Instance.GetModuleByType<ModuleDirectionLever>();
		overdrive = Train.Instance.GetModuleByType<ModuleOverdrive>();
		overdrive.OnInteractStartEvent += AutoTurn;
		overdrive.OnOverdriveEnd += TurnOffAutoTurn;
	}

	public void AutoTurn()
	{
		lever.autoTurnOn = true;
	}

	public void TurnOffAutoTurn()
	{
		lever.autoTurnOn = false;
	}
}
