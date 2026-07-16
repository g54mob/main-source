public class E2Idle : BIdleState
{
	public E2Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Move", "LaserCharge" };
	}

	public E2Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return enemy.IsDistanceToTrainCorrect();
	}
}
