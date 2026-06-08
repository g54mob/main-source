using Duskers.EnemyStates;

public class DbfBrain : BaseEnemyBrain
{
	public const float ENGAGE_DISTANCE = 3f;

	public const float ENGAGE_FUDGE_DISTANCE = 0.6f;

	public StateDbfPatrolIdle StateDbfPatrolIdle { get; private set; }

	public StateDbfCombat StateDbfCombat { get; private set; }

	public StateDbfSniffAround StateDbfSniffAround { get; private set; }

	public StateDbfCombatIdle StateDbfCombatIdle { get; private set; }

	public StateDbfCombatApproach StateDbfCombatApproach { get; private set; }

	public StateDbfCombatAvoid StateDbfCombatAvoid { get; private set; }

	public StateDbfLunge StateDbfLunge { get; private set; }

	public StateDbfRunToSpot StateDbfRunToSpot { get; private set; }

	public override int WANDERYNESS
	{
		get
		{
			return 65;
		}
	}

	public override float WANDER_CHECK_PERIOD
	{
		get
		{
			return 45f;
		}
	}

	public override bool RotatesBeforeAttack
	{
		get
		{
			return true;
		}
	}

	public override bool RotatesBeforeNavigate
	{
		get
		{
			return true;
		}
	}

	public DronesBestFriend Dbf { get; private set; }

	public DbfBrain(BaseEnemy enemy)
		: base(enemy)
	{
		Dbf = (DronesBestFriend)enemy;
	}

	public override void CreateStateInstances()
	{
		base.StatePatrol = new StatePatrol(this);
		StateDbfCombat = new StateDbfCombat(this);
		base.StateFlee = new StateFlee(this);
		StateDbfPatrolIdle = new StateDbfPatrolIdle(this);
		base.StatePatrolNavigatePath = new StateNavigatePath(this);
		base.StatePatrolCurious = new StateCurious(this);
		base.StateNavigatePath = new StateNavigatePath(this);
		base.StateStunned = new StateStunned(this);
		base.StateGlobalCommon = new StateGlobalCommon(this);
		base.StateNil = new StateNil(this);
		StateDbfSniffAround = new StateDbfSniffAround(this);
		StateDbfCombatIdle = new StateDbfCombatIdle(this);
		StateDbfCombatApproach = new StateDbfCombatApproach(this);
		StateDbfCombatAvoid = new StateDbfCombatAvoid(this);
		StateDbfLunge = new StateDbfLunge(this);
		base.StateCombatNavigate = new StateCombatNavigate(this);
		StateDbfRunToSpot = new StateDbfRunToSpot(this);
	}

	protected override void SetInitialState()
	{
		base.StatePatrol.Initialize(StateDbfPatrolIdle, StateDbfCombat);
		_stateMachine.ChangeState(base.StatePatrol);
	}

	public override void OnStartIdle()
	{
		Dbf.StopWalkAudio();
	}

	public override void OnStartWalk()
	{
		Dbf.StartWalkSound();
	}

	public override void OnStartDeath()
	{
		Dbf.StopWalkAudio();
	}
}
