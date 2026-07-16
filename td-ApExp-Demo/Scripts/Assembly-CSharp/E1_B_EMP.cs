public class E1_B_EMP : StateBaseEnemy
{
	public override string Key => "EMP";

	public E1_B_EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E1_B_EMP(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemy.shotTimer = 0f;
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
		enemy.OnEMPEnd();
	}

	public override bool CanExit()
	{
		return enemy.empDuration <= 0f;
	}

	public override bool TryTransitionStates()
	{
		if (!CanExit())
		{
			return false;
		}
		if (sm.SwitchState(sm.PreviousState))
		{
			return true;
		}
		return base.TryTransitionStates();
	}
}
