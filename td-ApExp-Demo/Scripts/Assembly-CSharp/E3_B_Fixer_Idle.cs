public class E3_B_Fixer_Idle : StateBaseEnemy
{
	private E3_B_E_Fixer fixer;

	public override string Key => "Idle";

	public E3_B_Fixer_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "GoToFix" };
	}

	public E3_B_Fixer_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		fixer.Show(show: false);
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
	}

	public override void ExitState()
	{
		fixer.Show(show: true);
	}

	public override bool CanExit()
	{
		return fixer.TargetUnit != null;
	}
}
