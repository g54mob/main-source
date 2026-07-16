using UnityEngine;

public class E3_7_Idle : StateBaseEnemy
{
	private E3_7_Scrambler scrambler;

	private float scrambleDuration;

	public float scrambleCooldown;

	public override string Key => "Idle";

	public E3_7_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E3_7_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		scrambler = enemy as E3_7_Scrambler;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Start Idle");
		if (!scrambler.IsHacked)
		{
			scrambler.Scramble();
		}
		scrambler.Move();
	}

	public override void UpdateState()
	{
		if (!scrambler.isScrambling && !scrambler.IsHacked)
		{
			scrambler.idleTimer -= Time.deltaTime;
			if (scrambler.idleTimer <= 0f)
			{
				scrambler.Scramble();
			}
		}
	}

	public override void FixedUpdateState()
	{
		scrambler.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
