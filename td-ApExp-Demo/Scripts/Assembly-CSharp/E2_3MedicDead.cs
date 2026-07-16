public class E2_3MedicDead : StateBaseEnemy
{
	private E2_3Medic medic;

	public override string Key => "Dead";

	public E2_3MedicDead(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_3MedicDead(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		medic = enemy as E2_3Medic;
	}

	public override bool CanEnter()
	{
		return medic.HealthComponent.IsDead;
	}

	public override void EnterState()
	{
		medic.ShowDeadAssSmoke();
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
		medic.HideDeadAssSmoke();
	}

	public override bool CanExit()
	{
		return !medic.HealthComponent.IsDead;
	}
}
