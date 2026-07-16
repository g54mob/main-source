public class E1_B_Destroyed : StateBaseEnemy
{
	private EnemyCentipede part;

	public override string Key => "Destroyed";

	public E1_B_Destroyed(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[0];
		part = enemy as EnemyCentipede;
	}

	public E1_B_Destroyed(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		part = enemy as EnemyCentipede;
	}

	public override bool CanEnter()
	{
		return false;
	}

	public override void EnterState()
	{
		part.plateAnim.Play("CloseDestroyed");
		part.rustAnim.Play("Close");
		enemy.IsHackable = false;
		part.HealthComponent.IsImmune = true;
		enemy.isImmuneToEMP = true;
		part.isImmuneToEMP = true;
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
