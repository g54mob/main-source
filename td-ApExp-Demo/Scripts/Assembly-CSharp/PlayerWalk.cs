using UnityEngine;

public class PlayerWalk : StatePlayerBase
{
	public override string Key => "Walk";

	public PlayerWalk(StateMachine sm, PlayerController player)
		: base(sm, player)
	{
		transitionStates = new string[4] { "Idle", "RepairDamage", "RepairMinigame", "Interact" };
	}

	public PlayerWalk(StateMachine sm, PlayerController player, string[] transitionStates)
		: base(sm, player, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		if (player.canMove)
		{
			return player.RawInput.magnitude > 0f;
		}
		return false;
	}

	public override void EnterState()
	{
		player.animator.Play("Walk");
		player.audioSource.clip = player.sounds[0];
		player.audioSource.Play();
	}

	public override void UpdateState()
	{
		if (!player.canMove)
		{
			sm.ForceState("Idle");
		}
		player.animator.SetFloat("WalkSpeed", player.RawInput.magnitude);
	}

	public override void FixedUpdateState()
	{
		Vector3 vector = player.RawInput * player.MoveSpeed * player.speedModifierMove * Time.fixedDeltaTime;
		player.rb2d.velocity = vector;
		player.AimMove();
	}

	public override void ExitState()
	{
		player.audioSource.Stop();
	}

	public override bool CanExit()
	{
		return true;
	}
}
