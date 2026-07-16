using UnityEngine;

public class E1_2Spinning : StateBaseEnemy
{
	private E1_2Technical technical;

	private float spinTimer;

	public override string Key => "Spinning";

	public E1_2Spinning(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Firing" };
	}

	public E1_2Spinning(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		technical = enemy as E1_2Technical;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		technical.SpinUp();
		spinTimer = technical.SpinUpTime;
	}

	public override void UpdateState()
	{
		spinTimer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		technical.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return spinTimer <= 0f;
	}
}
