using Duskers.EnemyStates;

public class PatrolBotBrain : BaseEnemyBrain
{
	public override int WANDERYNESS
	{
		get
		{
			return 85;
		}
	}

	public override float WANDER_CHECK_PERIOD
	{
		get
		{
			return 5f;
		}
	}

	public override bool RotatesBeforeNavigate
	{
		get
		{
			return true;
		}
	}

	public override bool RotatesBeforeAttack
	{
		get
		{
			return true;
		}
	}

	public StatePatrolBotScan StatePatrolBotScan { get; private set; }

	public StatePatrolBotCombat StatePatrolBotCombat { get; private set; }

	public PatrolBotEnemy ThisPatrolBot
	{
		get
		{
			return (PatrolBotEnemy)ThisEnemy;
		}
	}

	public Waypoint CurrentDestination { get; set; }

	public int ContinuePathRetryCount { get; set; }

	public PatrolBotBrain(BaseEnemy enemy)
		: base(enemy)
	{
		CurrentDestination = null;
		ContinuePathRetryCount = 0;
	}

	public override void CreateStateInstances()
	{
		base.StatePatrol = new StatePatrol(this);
		base.StateFlee = new StateFlee(this);
		base.StateStunned = new StateStunned(this);
		base.StateGlobalCommon = new StateGlobalCommon(this);
		base.StateNil = new StateNil(this);
		base.StatePatrolNavigatePath = new StateNavigatePath(this);
		base.StatePatrolCurious = new StateCurious(this);
		base.StateNavigatePath = new StateNavigatePath(this);
		StatePatrolBotScan = new StatePatrolBotScan(this);
		StatePatrolBotCombat = new StatePatrolBotCombat(this);
	}

	protected override void SetInitialState()
	{
		base.StatePatrol.Initialize(StatePatrolBotScan, StatePatrolBotCombat, 0.05f);
		_stateMachine.ChangeState(base.StatePatrol);
	}
}
