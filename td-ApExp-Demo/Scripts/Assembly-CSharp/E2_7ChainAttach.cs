public class E2_7ChainAttach : StateBase
{
	private TrainChain chain;

	public override string Key => "Attach";

	public E2_7ChainAttach(StateMachine sm, TrainChain c)
		: base(sm)
	{
		chain = c;
		transitionStates = new string[1] { "" };
	}

	public E2_7ChainAttach(StateMachine sm, TrainChain c, string[] transitionStates)
		: base(sm, transitionStates)
	{
		chain = c;
	}

	public override void Initialize()
	{
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		chain.AttachHook();
	}

	public override void UpdateState()
	{
		chain.HoldChain();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
