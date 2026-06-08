using UnityEngine;

public class StateMachine
{
	private IState _currentState;

	private IState _globalState;

	public string CurrentState
	{
		get
		{
			return (_currentState == null) ? string.Empty : _currentState.StateId;
		}
	}

	public virtual void Update()
	{
		if (_globalState != null)
		{
			_globalState.Update();
		}
		if (_currentState != null)
		{
			_currentState.Update();
		}
	}

	public void ChangeState(IState newState)
	{
		if (newState == null)
		{
			Debug.LogWarning("Attempting to change to a null state.  If this was intentional please define an 'Unknown' state class and use that instead.");
		}
		if (_currentState != null)
		{
			_currentState.ExitState();
			_currentState.ChangeState -= ChangeState;
		}
		_currentState = newState;
		if (_currentState != null)
		{
			_currentState.ChangeState += ChangeState;
			_currentState.EnterState();
		}
	}

	public void EndAllStates()
	{
		if (_globalState != null)
		{
			_globalState.ExitState();
		}
		if (_currentState != null)
		{
			_currentState.ExitState();
		}
	}

	public void SetGlobalState(IState globalState)
	{
		if (globalState == null)
		{
			Debug.LogWarning("Attempting to change to a null global state.  If this was intentional please define an 'Unknown' state class and use that instead.");
		}
		if (_globalState != null)
		{
			_globalState.ExitState();
			_globalState.ChangeState -= ChangeState;
		}
		_globalState = globalState;
		_globalState.ChangeState += ChangeState;
		_globalState.EnterState();
	}
}
