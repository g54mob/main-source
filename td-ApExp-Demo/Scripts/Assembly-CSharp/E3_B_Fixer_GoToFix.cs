public class E3_B_Fixer_GoToFix : StateBaseEnemy
{
	private E3_B_E_Fixer fixer;

	public override string Key => "GoToFix";

	public E3_B_Fixer_GoToFix(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Repair" };
	}

	public E3_B_Fixer_GoToFix(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
	}

	public override void FixedUpdateState()
	{
		fixer.Move();
		fixer.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return fixer.IsInPosition;
	}

	public override void UpdateState()
	{
	}
}
