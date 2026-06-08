using Duskers.EnemyStates;

public class SwarmDumbBrain : BaseEnemyBrain
{
	public StateSwarmDumbAttack StateSwarmDumbAttack { get; private set; }

	public StateGlobalSwarmDumb StateGlobalSwarmDumb { get; private set; }

	public SwarmEnemy SwarmEnemy { get; private set; }

	public SwarmDumbBrain(BaseEnemy enemy)
		: base(enemy)
	{
		SwarmEnemy = (SwarmEnemy)enemy;
	}

	public override void CreateStateInstances()
	{
		base.StateStunned = new StateStunned(this);
		base.StateNil = new StateNil(this);
		StateSwarmDumbAttack = new StateSwarmDumbAttack(this);
		StateGlobalSwarmDumb = new StateGlobalSwarmDumb(this);
	}

	protected override void SetInitialState()
	{
		_stateMachine.ChangeState(StateSwarmDumbAttack);
	}

	protected override void SetGlobalState()
	{
		_stateMachine.SetGlobalState(StateGlobalSwarmDumb);
	}
}
