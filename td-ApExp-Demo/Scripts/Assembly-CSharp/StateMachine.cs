using System.Collections.Generic;
using System.Linq;

public class StateMachine
{
	public Dictionary<string, StateBase> states;

	public StateBase CurrentState { get; protected set; }

	public StateBase PreviousState { get; protected set; }

	public void BuildStateDictionary(StateBase[] newStates)
	{
		states = new Dictionary<string, StateBase>();
		foreach (StateBase stateBase in newStates)
		{
			states.Add(stateBase.Key, stateBase);
			stateBase.Initialize();
		}
		CurrentState = states.Values.ElementAt(0);
		CurrentState.EnterState();
	}

	public void UpdateStates()
	{
		if (!CurrentState.TryTransitionStates())
		{
			CurrentState.UpdateState();
		}
	}

	public void FixedUpdateStates()
	{
		CurrentState.FixedUpdateState();
	}

	public bool SwitchState(StateBase newState)
	{
		if (newState.CanEnter() && CurrentState.CanExit())
		{
			CurrentState.ExitState();
			PreviousState = CurrentState;
			CurrentState = newState;
			CurrentState.EnterState();
			return true;
		}
		return false;
	}

	public bool SwitchState(string newStateName)
	{
		states.TryGetValue(newStateName, out var value);
		if (value == null)
		{
			return false;
		}
		if (value.CanEnter() && CurrentState.CanExit())
		{
			CurrentState.ExitState();
			PreviousState = CurrentState;
			CurrentState = value;
			CurrentState.EnterState();
			return true;
		}
		return false;
	}

	public void ForceState(string newStateStr)
	{
		states.TryGetValue(newStateStr, out var value);
		if (value != null)
		{
			CurrentState.ExitState();
			PreviousState = CurrentState;
			CurrentState = value;
			CurrentState.EnterState();
		}
	}

	public void ForceState(StateBase newState)
	{
		CurrentState.ExitState();
		PreviousState = CurrentState;
		CurrentState = newState;
		CurrentState.EnterState();
	}
}
