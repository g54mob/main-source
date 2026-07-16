public class E3_B_Fixer_GoHome : StateBaseEnemy
{
	private E3_B_E_Fixer fixer;

	public override string Key => "GoHome";

	public E3_B_Fixer_GoHome(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_B_Fixer_GoHome(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		fixer = enemy as E3_B_E_Fixer;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		fixer.TargetUnit = null;
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		fixer.MoveToHome();
		fixer.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return fixer.IsInPosition;
	}
}
