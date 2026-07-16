public class E2_B_SpecialAttack : StateBaseEnemy
{
	private E2_B_BossController boss;

	private bool canExit;

	public override string Key => "SpecialAttack";

	public E2_B_SpecialAttack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_B_SpecialAttack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		boss = enemy as E2_B_BossController;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		boss.StateSwitchBlocked = true;
		boss.SpecialAttack();
	}

	public override void UpdateState()
	{
		if (boss.SpecialAttackComplete)
		{
			boss.StateSwitchBlocked = false;
			sm.SwitchState("Idle");
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		if (boss.canAimDuringSpecialAttack)
		{
			boss.Aim();
		}
	}

	public override void ExitState()
	{
		boss.SpecialAttackComplete = true;
	}

	public override bool CanExit()
	{
		return !boss.StateSwitchBlocked;
	}
}
