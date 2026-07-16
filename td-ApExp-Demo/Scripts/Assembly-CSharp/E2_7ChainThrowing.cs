public class E2_7ChainThrowing : StateBase
{
	private TrainChain chain;

	private bool canExit;

	public override string Key => "Throwing";

	public E2_7ChainThrowing(StateMachine sm, TrainChain c)
		: base(sm)
	{
		chain = c;
		transitionStates = new string[1] { "Attach" };
	}

	public E2_7ChainThrowing(StateMachine sm, TrainChain c, string[] transitionStates)
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
		canExit = false;
	}

	public override void UpdateState()
	{
		chain.Throw();
		if (chain.CheckCanHookAttach())
		{
			chain.AttachHook();
			canExit = true;
			ExitState();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
