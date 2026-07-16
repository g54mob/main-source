public abstract class StateBaseEnemy : StateBase
{
	protected readonly EnemyBase enemy;

	public StateBaseEnemy(StateMachine sm, EnemyBase enemy)
		: base(sm)
	{
		this.enemy = enemy;
	}

	public StateBaseEnemy(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, transitionStates)
	{
		this.enemy = enemy;
	}
}
