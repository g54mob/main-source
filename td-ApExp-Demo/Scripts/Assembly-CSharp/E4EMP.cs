public class E4EMP : BEMPState
{
	public override string Key => "EMP";

	public E4EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Idle", "Move" };
	}

	public E4EMP(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void ExitState()
	{
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
