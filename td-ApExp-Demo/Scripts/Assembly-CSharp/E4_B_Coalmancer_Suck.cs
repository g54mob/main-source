using UnityEngine;

public class E4_B_Coalmancer_Suck : StateBaseEnemy
{
	private E4_B_Coalmancer enemyCoalmancer;

	private float timer;

	public override string Key => "Suck";

	public E4_B_Coalmancer_Suck(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E4_B_Coalmancer_Suck(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		timer = enemyCoalmancer.SuckDuration;
		enemyCoalmancer.HeadAnim.Play("CoalmancerHeadShoot");
	}

	public override void UpdateState()
	{
		timer -= Time.deltaTime;
		enemyCoalmancer.Shoot();
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
