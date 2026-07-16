public class E3_8_Jet_Attack : StateBaseEnemy
{
	private E3_8_FighterJet jet;

	public override string Key => "Attack";

	public E3_8_Jet_Attack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "FlyOver" };
	}

	public E3_8_Jet_Attack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		jet = enemy as E3_8_FighterJet;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		jet.shootTimer = 0f;
		jet.PlayShootSound();
	}

	public override void UpdateState()
	{
		jet.Shoot();
	}

	public override void FixedUpdateState()
	{
		jet.MoveForShooting();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return jet.isFinishedShooting;
	}
}
