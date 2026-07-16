public class BEMPState : StateBaseEnemy
{
	private int randomSpinSign;

	private const float SPIN_SPEED = 5f;

	private bool wasImmune;

	public override string Key => "EMP";

	public BEMPState(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Idle", "Move" };
	}

	public BEMPState(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		wasImmune = enemy.HealthComponent.IsImmune;
		enemy.HealthComponent.IsImmune = false;
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		enemy.Move();
	}

	public override void ExitState()
	{
		enemy.HealthComponent.IsImmune = wasImmune;
		enemy.OnEMPEnd();
	}

	public override bool CanExit()
	{
		return enemy.empDuration <= 0f;
	}
}
