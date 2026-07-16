using UnityEngine;

public class PlayerIdle : StatePlayerBase
{
	public override string Key => "Idle";

	public PlayerIdle(StateMachine sm, PlayerController player)
		: base(sm, player)
	{
		transitionStates = new string[5] { "Walk", "Shovel", "Interact", "RepairDamage", "RepairMinigame" };
	}

	public PlayerIdle(StateMachine sm, PlayerController player, string[] transitionStates)
		: base(sm, player, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return player.RawInput.magnitude == 0f;
	}

	public override void EnterState()
	{
		player.animator.Play("Idle");
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		player.rb2d.velocity = Vector2.zero;
		player.AimMove();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}
}
