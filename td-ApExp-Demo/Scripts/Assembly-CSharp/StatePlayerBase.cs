public abstract class StatePlayerBase : StateBase
{
	protected PlayerController player;

	public StatePlayerBase(StateMachine sm, PlayerController player)
		: base(sm)
	{
		this.player = player;
	}

	public StatePlayerBase(StateMachine sm, PlayerController player, params string[] transitionStates)
		: base(sm, transitionStates)
	{
		this.player = player;
	}
}
