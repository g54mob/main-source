public class E2_7EMP : BEMPState
{
	private E2_7Chainer chainer;

	public override string Key => "EMP";

	public E2_7EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_7EMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		chainer = enemy as E2_7Chainer;
		base.EnterState();
	}

	public override void ExitState()
	{
		base.ExitState();
	}

	public override bool CanExit()
	{
		if (base.CanExit())
		{
			if (chainer.IsAttached)
			{
				transitionStates = new string[1] { "Attach" };
			}
			else
			{
				transitionStates = new string[1] { "Idle" };
			}
			return true;
		}
		return false;
	}
}
