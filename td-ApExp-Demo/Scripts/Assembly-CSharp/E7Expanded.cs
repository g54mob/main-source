public class E7Expanded : StateBaseEnemy
{
	public override string Key => "Expanded";

	public E7Expanded(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[0];
	}

	public E7Expanded(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return false;
	}

	public override void EnterState()
	{
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}
}
