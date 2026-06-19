using UnityEngine;
using UnityHFSM;

public class PatrolState : StateBase
{
	private readonly AirplaneWaypointMover mover;

	public PatrolState(AirplaneWaypointMover mover)
		: base(needsExitTime: false)
	{
		this.mover = mover;
	}

	public override void OnEnter()
	{
		mover.OverrideTarget = null;
		mover.ResetPIDs();
		Debug.Log("[AirplaneAI] → Patrol");
	}

	public override void OnLogic()
	{
	}
}
