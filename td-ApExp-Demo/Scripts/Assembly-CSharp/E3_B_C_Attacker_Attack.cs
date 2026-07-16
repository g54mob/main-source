using UnityEngine;

public class E3_B_C_Attacker_Attack : StateBaseEnemy
{
	private E3_B_C_SecondaryWeapon secondary;

	public override string Key => "Attack";

	public E3_B_C_Attacker_Attack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_B_C_Attacker_Attack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		secondary = enemy as E3_B_C_SecondaryWeapon;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		secondary.SetIdleTimer();
		secondary.Shoot();
	}

	public override void UpdateState()
	{
		secondary.idleTimer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return secondary.idleTimer <= 0f;
	}
}
