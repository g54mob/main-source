public class E3_B_AttackerBombardment : StateBaseEnemy
{
	private E3_B_Phase1Plane bossPlane;

	public override string Key => "Bombardment";

	public E3_B_AttackerBombardment(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_B_AttackerBombardment(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		bossPlane = enemy as E3_B_Phase1Plane;
	}

	public override bool CanEnter()
	{
		return GameManager.Instance.minigameInProgress;
	}

	public override void EnterState()
	{
		bossPlane.LockRotation = false;
	}

	public override void UpdateState()
	{
		bossPlane.HealthComponent.IsImmune = true;
	}

	public override void FixedUpdateState()
	{
		bossPlane.Retreat(5f);
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return !GameManager.Instance.minigameInProgress;
	}
}
