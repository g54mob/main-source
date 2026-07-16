public class BTemplateState : StateBaseEnemy
{
	public override string Key => "Key";

	public BTemplateState(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[3] { "Idle", "Move", "etc" };
	}

	public BTemplateState(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return false;
	}

	public override void EnterState()
	{
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}
}
