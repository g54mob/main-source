public class E1Idle : BIdleState
{
	public E1Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Move" };
	}

	public E1Idle(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void UpdateState()
	{
		base.UpdateState();
		enemy.Aim();
		enemy.Shoot();
	}

	public override void ExitState()
	{
	}
}
