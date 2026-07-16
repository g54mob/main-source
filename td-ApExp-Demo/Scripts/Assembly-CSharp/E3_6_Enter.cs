using UnityEngine;

public class E3_6_Enter : StateBaseEnemy
{
	private E3_6_Paradropper dropper;

	private float waitTimer = 1f;

	public override string Key => "Enter";

	public E3_6_Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Drop" };
	}

	public E3_6_Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		dropper = enemy as E3_6_Paradropper;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Start Enter");
		dropper.SetPlaneFlyOver();
		waitTimer = dropper.WaitTime;
		dropper.HealthComponent.ApplyImmunityBuff(999f);
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		if (dropper.IsInPosition)
		{
			waitTimer -= Time.deltaTime;
		}
		else
		{
			dropper.MoveBack();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (dropper.IsInPosition)
		{
			return waitTimer <= 0f;
		}
		return false;
	}
}
