using System;
using UnityEngine;

[Serializable]
public class FSMRoutine : MonoBehaviour
{
	[SerializeField]
	public string routineName;

	[SerializeField]
	protected FSMState currentState;

	[SerializeField]
	protected FSMState previousState;

	[SerializeField]
	protected FSMState fallbackState;

	[SerializeField]
	private bool alwaysEnterEntryRoutineFirst;

	[SerializeField]
	protected FSMState entryRoutineState;

	[SerializeField]
	protected FSMState exitRoutineState;

	public FSMRoutine idleRoutine;

	[SerializeField]
	private FSMRoutine nextRoutine;

	[SerializeField]
	private FSMRoutine previousRoutine;

	public FSMManager manager;

	public string previousStateName = "";

	public string currentStateName = "";

	public bool returnToPreviousRoutineEveryRound;

	[HideInInspector]
	public GameObject agent;

	private bool changingRoutine;

	public void AssignAgent(GameObject agent)
	{
		this.agent = agent;
		FSMState[] componentsInChildren = base.transform.GetComponentsInChildren<FSMState>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].agent = agent;
		}
	}

	public void DismissAgent()
	{
		FSMState[] componentsInChildren = base.transform.GetComponentsInChildren<FSMState>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].OnDismiss();
		}
	}

	public FSMState GetState(string localStateName)
	{
		return base.transform.Find(localStateName).GetComponent<FSMState>();
	}

	public FSMState GetCurrentState()
	{
		return currentState;
	}

	public FSMState GetPreviousState()
	{
		return previousState;
	}

	protected virtual void Create()
	{
	}

	protected virtual void OnDismiss()
	{
	}

	protected virtual void OnExit()
	{
	}

	protected virtual void OnInit()
	{
	}

	protected virtual void UpdateRoutine()
	{
	}

	public void OnStart()
	{
		OnInit();
		if (currentState == null || alwaysEnterEntryRoutineFirst)
		{
			currentState = entryRoutineState;
		}
		currentStateName = currentState.name;
		if (currentState != null)
		{
			currentState.Enter();
		}
	}

	public void OnUpdate()
	{
		if (!(currentState == null) || changingRoutine)
		{
			UpdateRoutine();
			currentState.UpdateState();
			if (returnToPreviousRoutineEveryRound)
			{
				currentState.Exit();
				manager.ChangeRoutine(previousRoutine);
			}
		}
	}

	public void ContinuesUpdate()
	{
		if (!(currentState == null))
		{
			currentState.DurationUpdate();
		}
	}

	public void ChangeState(FSMState newState)
	{
		changingRoutine = true;
		if (currentState != null)
		{
			previousStateName = currentStateName;
			currentState.Exit();
			previousState = currentState;
		}
		if (newState == null)
		{
			newState = fallbackState;
		}
		else
		{
			currentState = newState;
		}
		currentState.Enter();
		currentStateName = newState.name;
		changingRoutine = false;
		manager.OnStateChangeEvent.Invoke();
	}

	public void Exit()
	{
		OnExit();
		previousStateName = currentStateName;
		currentState.Exit();
		previousState = currentState;
		currentState = null;
	}

	public void PreviousRoutine()
	{
		currentState.Exit();
		currentState.gameObject.name = base.name;
		manager.ChangeRoutine(previousRoutine);
	}

	public void NextRoutine()
	{
		if (currentState != null)
		{
			currentState.Exit();
			currentState.gameObject.name = base.name;
		}
		manager.ChangeRoutine(nextRoutine);
	}

	public void ChangeRoutineTo(FSMRoutine routine)
	{
		currentState.gameObject.name = base.name;
		routine.previousRoutine = this;
		currentState.Exit();
		manager.ChangeRoutine(routine);
	}
}
