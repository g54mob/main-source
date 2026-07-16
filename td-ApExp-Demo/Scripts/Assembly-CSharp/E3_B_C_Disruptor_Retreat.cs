public class E3_B_C_Disruptor_Retreat : StateBaseEnemy
{
	private E3_B_C_SecondaryWeapon secondary;

	public override string Key => "Retreat";

	public E3_B_C_Disruptor_Retreat(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_B_C_Disruptor_Retreat(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		secondary = enemy as E3_B_C_SecondaryWeapon;
	}

	public override bool CanEnter()
	{
		return GameManager.Instance.minigameInProgress;
	}

	public override void EnterState()
	{
		secondary.gameObject.GetComponent<E3_B_C_SecondaryWeapon_DisruptorScrambler>().Unscramble();
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
		return !GameManager.Instance.minigameInProgress;
	}
}
