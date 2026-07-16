public class E2_3MedicRevive : StateBaseEnemy
{
	private E2_3Medic enemyBiker;

	public override string Key => "Revive";

	public E2_3MedicRevive(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Idle", "Dead" };
	}

	public E2_3MedicRevive(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyBiker = enemy as E2_3Medic;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemyBiker.SetReviveAnim();
		enemyBiker.Revive();
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return enemyBiker.HealthComponent.isEMPd;
	}
}
