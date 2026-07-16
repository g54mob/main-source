using UnityEngine;

public class E3_6_Chicken_Enter : StateBaseEnemy
{
	private E3_6_Chicken chicken;

	public override string Key => "Enter";

	public E3_6_Chicken_Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Attack" };
	}

	public E3_6_Chicken_Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		Debug.LogWarning("Chicken Enter");
		chicken.IsInPosition = false;
		chicken.HealthComponent.DamageReductionPercent = chicken.DecentDamageReduction;
	}

	public override void UpdateState()
	{
		if (chicken.readyToRetreat)
		{
			chicken.sm.ForceState("Despawn");
		}
	}

	public override void FixedUpdateState()
	{
		if ((bool)chicken.TargetUnit)
		{
			chicken.Decend();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return chicken.IsInPosition;
	}
}
