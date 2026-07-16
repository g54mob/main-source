public class E3_B_C_Disruptor_Idle : StateBaseEnemy
{
	private E3_B_C_SecondaryWeapon secondary;

	public override string Key => "Idle";

	public E3_B_C_Disruptor_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Disrupt" };
	}

	public E3_B_C_Disruptor_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		secondary = enemy as E3_B_C_SecondaryWeapon;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
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
