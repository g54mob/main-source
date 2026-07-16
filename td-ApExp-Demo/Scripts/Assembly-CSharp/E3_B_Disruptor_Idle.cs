public class E3_B_Disruptor_Idle : StateBaseEnemy
{
	private E3_B_Phase1Plane bossPlane;

	public override string Key => "Idle";

	public E3_B_Disruptor_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Disrupt" };
	}

	public E3_B_Disruptor_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		bossPlane = enemy as E3_B_Phase1Plane;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		if (bossPlane.startingMoveSpeed > 0f)
		{
			bossPlane.MoveSpeed = bossPlane.startingMoveSpeed;
		}
	}

	public override void UpdateState()
	{
		bossPlane.HealthComponent.IsImmune = false;
		if (bossPlane.shotTimer <= 0f)
		{
			bossPlane.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		bossPlane.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
