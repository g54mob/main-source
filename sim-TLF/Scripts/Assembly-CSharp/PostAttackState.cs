using UnityEngine;
using UnityHFSM;

public class PostAttackState : StateBase
{
	private readonly AirplaneWaypointMover mover;

	private int targetWaypointIndex;

	private bool waypointReached;

	public bool WaypointReached => waypointReached;

	public PostAttackState(AirplaneWaypointMover mover)
		: base(needsExitTime: false)
	{
		this.mover = mover;
	}

	public override void OnEnter()
	{
		mover.OverrideTarget = null;
		mover.ResetPIDs();
		targetWaypointIndex = mover.CurrentWaypointIndex;
		waypointReached = false;
		Debug.Log($"[AirplaneAI] -> PostAttack  (чекаємо waypoint #{targetWaypointIndex})");
	}

	public override void OnLogic()
	{
		if (!waypointReached && mover.CurrentWaypointIndex != targetWaypointIndex)
		{
			waypointReached = true;
			Debug.Log($"[AirplaneAI] PostAttack: waypoint #{targetWaypointIndex} досягнуто");
		}
	}

	public override void OnExit()
	{
		waypointReached = false;
	}
}
