public abstract class StateBase
{
	protected StateMachine sm;

	protected string[] transitionStates;

	public virtual string Key => "Base";

	public StateBase(StateMachine sm)
	{
		this.sm = sm;
	}

	public StateBase(StateMachine sm, params string[] transitionStates)
	{
		this.sm = sm;
		this.transitionStates = transitionStates;
	}

	public virtual void Initialize()
	{
	}

	public abstract bool CanEnter();

	public abstract void EnterState();

	public abstract void UpdateState();

	public virtual void FixedUpdateState()
	{
	}

	public abstract void ExitState();

	public abstract bool CanExit();

	public virtual bool TryTransitionStates()
	{
		if (!CanExit())
		{
			return false;
		}
		if (transitionStates == null)
		{
			return false;
		}
		if (transitionStates.Length == 0)
		{
			return false;
		}
		for (int i = 0; i < transitionStates.Length; i++)
		{
			sm.states.TryGetValue(transitionStates[i], out var value);
			if (value != null && sm.SwitchState(value))
			{
				return true;
			}
		}
		return false;
	}
}
