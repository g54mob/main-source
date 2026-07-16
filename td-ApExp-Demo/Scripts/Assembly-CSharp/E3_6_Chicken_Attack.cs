using UnityEngine;

public class E3_6_Chicken_Attack : StateBaseEnemy
{
	private E3_6_Chicken chicken;

	public override string Key => "Attack";

	public E3_6_Chicken_Attack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E3_6_Chicken_Attack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		chicken = enemy as E3_6_Chicken;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Chicken Attack");
		chicken.transform.parent = chicken.TargetUnit.transform;
		chicken.HealthComponent.DamageReductionPercent = 0f;
		chicken.hasLanded = true;
		chicken.StartPecking();
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return chicken.IsInPosition;
	}
}
