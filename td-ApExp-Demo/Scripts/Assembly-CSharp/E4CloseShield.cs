public class E4CloseShield : StateBaseEnemy
{
	private E4Cocoon coc;

	public override string Key => "CloseShield";

	public E4CloseShield(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Idle", "Move" };
		coc = enemy as E4Cocoon;
	}

	public E4CloseShield(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		coc = enemy as E4Cocoon;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemy.Anim.Play("Close", 1);
	}

	public override void UpdateState()
	{
		enemy.Aim();
	}

	public override bool CanExit()
	{
		return enemy.Anim.GetCurrentAnimatorStateInfo(1).normalizedTime >= 1f;
	}

	public override void ExitState()
	{
		enemy.HealthComponent.IsImmune = true;
	}
}
