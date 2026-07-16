using UnityEngine;

[CreateAssetMenu(fileName = "LeverAutoTurn", menuName = "Upgrade/Lever/AutoTurn")]
public class UpgradeLeverAutoTurn : EnhancementUpgrade
{
	private ModuleDirectionLever lever;

	[SerializeField]
	private int usesPerLevel;

	public override void ApplyUpgrade()
	{
		lever = Train.Instance.GetModuleByType<ModuleDirectionLever>();
		lever.numberOfFreeTurns = usesPerLevel;
		TrackManager.Instance.OnNewTrackSet += lever.TurnLeverAutomatically;
		LevelManager.Instance.LevelStarted += ResetTurnUses;
	}

	public void ResetTurnUses()
	{
		lever.numberOfFreeTurns = usesPerLevel;
	}
}
