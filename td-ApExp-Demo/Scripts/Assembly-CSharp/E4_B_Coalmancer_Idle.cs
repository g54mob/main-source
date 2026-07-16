using UnityEngine;

public class E4_B_Coalmancer_Idle : StateBaseEnemy
{
	private E4_B_Coalmancer enemyCoalmancer;

	private float timer;

	public override string Key => "Idle";

	public E4_B_Coalmancer_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Suck" };
	}

	public E4_B_Coalmancer_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyCoalmancer = enemy as E4_B_Coalmancer;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		timer = enemyCoalmancer.IdleTime;
		enemyCoalmancer.HeadAnim.Play("CoalmancerHeadIdle");
	}

	public override void UpdateState()
	{
		timer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyCoalmancer.Move();
		enemyCoalmancer.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return timer <= 0f;
	}
}
