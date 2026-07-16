using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TransitionStateMachine : MonoBehaviour
{
	[SerializeField]
	private float routineTick = 1f;

	[SerializeField]
	private bool defaultCreate = true;

	private float tickProgress;

	private bool processRoutine;

	public TransitionState[] registeredStates;

	public TransitionState entryState;

	public TransitionState currentState;

	public TransitionState fallbackState;

	public UnityEvent OnStateChangeEvent = new UnityEvent();

	public UnityEvent OnEndRoutine = new UnityEvent();

	private void Start()
	{
		if (defaultCreate)
		{
			Create();
		}
	}

	public void Create()
	{
		registeredStates = base.transform.GetComponentsInChildren<TransitionState>();
		TransitionState[] array = registeredStates;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].manager = this;
		}
		processRoutine = true;
		currentState = entryState;
		currentState.Enter();
		currentState.gameObject.name = "[ACTIVE]" + currentState.stateName + "_State";
	}

	public TransitionState[] GetRegisteredStates()
	{
		return registeredStates;
	}

	public TransitionState GetStateByName(string stateName)
	{
		return registeredStates.ToList().FirstOrDefault((TransitionState x) => x.stateName.ToLower() == stateName.ToLower());
	}

	public void Stop()
	{
		processRoutine = false;
	}

	public void Continue()
	{
		processRoutine = true;
	}

	public void FixedUpdate()
	{
		if (processRoutine)
		{
			if (tickProgress < 1f)
			{
				tickProgress += routineTick * Time.deltaTime;
			}
			else
			{
				currentState.UpdateState();
				tickProgress = 0f;
			}
			currentState.DurationUpdate();
		}
	}

	public void ChangeState(TransitionState state)
	{
		currentState.gameObject.name = currentState.stateName + "_State";
		currentState.Exit();
		processRoutine = false;
		if (state != null)
		{
			currentState = state;
		}
		else
		{
			state = fallbackState;
		}
		processRoutine = true;
		currentState.Enter();
		currentState.gameObject.name = "[ACTIVE] " + currentState.stateName + "_State";
		OnStateChangeEvent.Invoke();
	}
}
