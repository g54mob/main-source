using System;
using System.Collections.Generic;
using System.Linq;

public class FiniteStateMachine<T>
{
	private readonly T owner;

	private State<T> newState;

	private State<T> newSubState;

	private State<T> currentState;

	private State<T> previousState;

	private State<T> globalState;

	private Stack<State<T>> subStateStack;

	private readonly Dictionary<State<T>, Dictionary<State<T>, List<Action>>> onTransitionBetweenStates;

	private bool shouldExitSubState;

	private bool shouldExitAllSubStates;

	private Action customExitMethod;

	private bool shouldRunExit;

	private bool shouldRunEnter;

	public event Action<State<T>> OnStateChanged;

	public event Action<State<T>> OnSubStateChanged;

	public FiniteStateMachine(T owner, State<T> state)
	{
		newState = null;
		newSubState = null;
		currentState = null;
		previousState = null;
		globalState = null;
		subStateStack = new Stack<State<T>>();
		shouldExitSubState = false;
		shouldExitAllSubStates = false;
		customExitMethod = null;
		shouldRunExit = true;
		shouldRunEnter = true;
		this.owner = owner;
		onTransitionBetweenStates = new Dictionary<State<T>, Dictionary<State<T>, List<Action>>>();
		ChangeState(state);
	}

	public void Update()
	{
		if (globalState != null)
		{
			globalState.Execute(owner);
		}
		if (currentState != null)
		{
			if (subStateStack.Count == 0)
			{
				currentState.Execute(owner);
			}
			else
			{
				subStateStack.Peek().Execute(owner);
			}
		}
		if (shouldExitSubState)
		{
			ExitingSubState();
			shouldExitSubState = false;
		}
		if (shouldExitAllSubStates)
		{
			ExitingAllSubStates();
			shouldExitAllSubStates = false;
		}
		if (newSubState != null)
		{
			EnteringSubState();
		}
		if (newState != null)
		{
			ChangingState();
		}
	}

	public void ChangeState(State<T> newState)
	{
		ChangeState(newState, shouldRunExit: true);
	}

	public void ChangeState(State<T> newState, Action customExitMethod, bool shouldRunEnter = true)
	{
		this.customExitMethod = customExitMethod;
		ChangeState(newState, shouldRunExit: true, shouldRunEnter);
	}

	public void ChangeState(State<T> newState, bool shouldRunExit, bool shouldRunEnter = true)
	{
		if (newState == currentState || subStateStack.Any((State<T> subState) => newSubState == subState))
		{
			throw new Exception("Can't change to the same state that is running!");
		}
		this.newState = newState;
		this.shouldRunExit = shouldRunExit;
		this.shouldRunEnter = shouldRunEnter;
	}

	private void ChangingState()
	{
		ExitingAllSubStates();
		previousState = currentState;
		if (currentState != null && shouldRunExit)
		{
			if (customExitMethod != null)
			{
				currentState.CustomExitWithLog(customExitMethod);
			}
			else
			{
				currentState.ExitWithLog(owner);
			}
		}
		ExecuteActionsBetweenStates(previousState, newState);
		currentState = newState;
		if (currentState != null)
		{
			if (currentState.IsFirstEntry)
			{
				currentState.IsFirstEntry = false;
				currentState.StartWithLog(owner);
			}
			if (shouldRunEnter)
			{
				currentState.EnterWithLog(owner);
			}
		}
		customExitMethod = null;
		shouldRunExit = true;
		shouldRunEnter = true;
		newState = null;
		if (this.OnStateChanged != null)
		{
			this.OnStateChanged(currentState);
		}
	}

	public void SetSubState(State<T> newSubState)
	{
		if (subStateStack.Any((State<T> subState) => newSubState == subState) || newSubState == currentState)
		{
			throw new Exception("Can't change to the same state that is running!");
		}
		this.newSubState = newSubState;
	}

	public void ExitSubState()
	{
		shouldExitSubState = true;
	}

	private void ExitingSubState()
	{
		if (subStateStack.Count > 0)
		{
			subStateStack.Pop().ExitWithLog(owner);
			if (subStateStack.Count == 0)
			{
				currentState.EnterFromSubState(owner);
			}
			else
			{
				subStateStack.Peek().EnterFromSubState(owner);
			}
		}
	}

	public void ExitAllSubStates()
	{
		shouldExitAllSubStates = true;
	}

	private void ExitingAllSubStates()
	{
		while (subStateStack.Count > 0)
		{
			ExitingSubState();
		}
	}

	private void EnteringSubState()
	{
		State<T> state = newSubState;
		if (subStateStack.Count == 0)
		{
			currentState.ExitToSubState(owner);
		}
		else
		{
			subStateStack.Peek().ExitToSubState(owner);
		}
		if (state.IsFirstEntry)
		{
			state.IsFirstEntry = false;
			state.StartWithLog(owner);
		}
		state.EnterWithLog(owner);
		subStateStack.Push(state);
		if (this.OnSubStateChanged != null)
		{
			this.OnSubStateChanged(state);
		}
		newSubState = null;
	}

	public void RevertToPreviousState()
	{
		RevertToPreviousState(shouldRunExit: true);
	}

	public void RevertToPreviousState(bool shouldRunExit, bool shouldRunEnter = true)
	{
		if (previousState != null)
		{
			ChangeState(previousState, shouldRunExit, shouldRunEnter);
		}
	}

	public State<T> GetCurrentState()
	{
		return currentState;
	}

	public State<T> GetCurrentSubState()
	{
		if (subStateStack.Count == 0)
		{
			return null;
		}
		return subStateStack.Peek();
	}

	public State<T> GetPreviousState()
	{
		return previousState;
	}

	private void ExecuteActionsBetweenStates(State<T> previousState, State<T> nextState)
	{
		if (previousState != null && nextState != null && onTransitionBetweenStates.ContainsKey(previousState) && onTransitionBetweenStates[previousState].ContainsKey(nextState))
		{
			onTransitionBetweenStates[previousState][nextState].ForEach(delegate(Action action)
			{
				action?.Invoke();
			});
		}
	}

	public void AddActionOnTransitionBetweenStates(State<T>[] previousStates, State<T>[] nextStates, Action action)
	{
		foreach (State<T> state in previousStates)
		{
			AddActionOnTransitionBetweenStates(state, nextStates, action);
		}
	}

	public void AddActionOnTransitionBetweenStates(State<T> previousState, State<T>[] nextStates, Action action)
	{
		foreach (State<T> nextState in nextStates)
		{
			AddActionOnTransitionBetweenStates(previousState, nextState, action);
		}
	}

	public void AddActionOnTransitionBetweenStates(State<T>[] previousStates, State<T> nextState, Action action)
	{
		foreach (State<T> state in previousStates)
		{
			AddActionOnTransitionBetweenStates(state, nextState, action);
		}
	}

	public void AddActionOnTransitionBetweenStates(State<T> previousState, State<T> nextState, Action action)
	{
		if (!onTransitionBetweenStates.ContainsKey(previousState))
		{
			onTransitionBetweenStates.Add(previousState, new Dictionary<State<T>, List<Action>>());
		}
		if (!onTransitionBetweenStates[previousState].ContainsKey(nextState))
		{
			onTransitionBetweenStates[previousState].Add(nextState, new List<Action>());
		}
		onTransitionBetweenStates[previousState][nextState].Add(action);
	}
}
