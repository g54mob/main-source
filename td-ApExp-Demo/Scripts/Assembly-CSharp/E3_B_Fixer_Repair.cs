using UnityEngine;

public class E3_B_Fixer_Repair : StateBaseEnemy
{
	private E3_B_E_Fixer fixer;

	private float timer;

	public override string Key => "Repair";

	public E3_B_Fixer_Repair(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "GoHome" };
	}

	public E3_B_Fixer_Repair(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		fixer = enemy as E3_B_E_Fixer;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		timer = fixer.RepairTime;
		fixer.Fix();
	}

	public override void UpdateState()
	{
		timer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
	}

	public override void ExitState()
	{
		fixer.FinishFixing();
	}

	public override bool CanExit()
	{
		return timer <= 0f;
	}
}
