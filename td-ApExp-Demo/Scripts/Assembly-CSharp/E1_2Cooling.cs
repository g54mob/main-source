using UnityEngine;

public class E1_2Cooling : StateBaseEnemy
{
	private E1_2Technical technical;

	private float coolTimer;

	public override string Key => "Cooling";

	public E1_2Cooling(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E1_2Cooling(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		technical.CoolDown();
		coolTimer = technical.CoolTime;
	}

	public override void UpdateState()
	{
		coolTimer -= Time.deltaTime;
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return coolTimer <= 0f;
	}
}
