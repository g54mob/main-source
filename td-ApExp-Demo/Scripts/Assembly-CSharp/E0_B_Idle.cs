public class E0_B_Idle : StateBaseEnemy
{
	private E0_B_APC apc;

	public override string Key => "Idle";

	public E0_B_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Launch" };
	}

	public E0_B_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		apc = enemy as E0_B_APC;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemy.Anim.Play("Idle", 1, 0f);
		apc.SetIdleTimer();
	}

	public override void UpdateState()
	{
		apc.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (apc.IsInPosition)
		{
			return enemy.idleTimer <= 0f;
		}
		return false;
	}
}
