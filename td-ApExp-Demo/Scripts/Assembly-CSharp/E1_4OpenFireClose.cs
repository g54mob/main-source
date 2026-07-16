public class E1_4OpenFireClose : StateBaseEnemy
{
	private E1_4Bus bus;

	public override string Key => "OpenFireClose";

	public E1_4OpenFireClose(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
		bus = enemy as E1_4Bus;
	}

	public E1_4OpenFireClose(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		bus = enemy as E1_4Bus;
	}

	public override bool CanEnter()
	{
		return enemy.TargetUnit != null;
	}

	public override void EnterState()
	{
		bus.SetOpenFireAnim();
		bus.HealthComponent.IsImmune = false;
	}

	public override void UpdateState()
	{
	}

	public override bool CanExit()
	{
		return !bus.shooting;
	}

	public override void ExitState()
	{
		enemy.Anim.Play("Idle", 1);
	}
}
