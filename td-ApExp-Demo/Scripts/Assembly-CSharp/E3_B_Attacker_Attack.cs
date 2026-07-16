public class E3_B_Attacker_Attack : StateBaseEnemy
{
	private E3_B_Phase1Plane bossPlane;

	public override string Key => "Attack";

	public E3_B_Attacker_Attack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_B_Attacker_Attack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		bossPlane.AttackCompleted = false;
		bossPlane.Shoot();
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		bossPlane.Move();
		bossPlane.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return bossPlane.AttackCompleted;
	}
}
