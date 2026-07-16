public class E3_8_Jet_Leave : StateBaseEnemy
{
	private E3_8_FighterJet jet;

	public override string Key => "Leave";

	public E3_8_Jet_Leave(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E3_8_Jet_Leave(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		jet.Despawn();
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
