using System.Collections.Generic;
using UnityEngine;

public class FSMComponent : MonoBehaviour
{
	public List<FSMState> states;

	public List<FSMTransition> anyStateTransitions;

	[HideInInspector]
	public Dictionary<string, string> blackboard;

	private FSMState currentState;

	private AiController controller;

	private bool paused;

	private List<FSMTask> currentTasks;

	public AiController Controller => controller;

	public Character Character => controller.ControlledCharacter;

	protected FSMState CurrentState
	{
		get
		{
			return currentState;
		}
		set
		{
			foreach (FSMTask currentTask in currentTasks)
			{
				currentTask.EndTask(this);
			}
			if (currentState != null)
			{
				foreach (FSMTask onExitTask in CurrentState.onExitTasks)
				{
					onExitTask.StartTask(this);
					onExitTask.ExecuteTask(this);
					onExitTask.EndTask(this);
				}
			}
			currentState = value;
			UpdateCurrentTasks();
			if ((bool)currentState)
			{
				foreach (FSMTask onEnterTask in CurrentState.onEnterTasks)
				{
					onEnterTask.StartTask(this);
					onEnterTask.ExecuteTask(this);
					onEnterTask.EndTask(this);
				}
			}
			foreach (FSMTask currentTask2 in currentTasks)
			{
				currentTask2.StartTask(this);
			}
		}
	}

	private void Awake()
	{
		controller = GetComponent<AiController>();
		currentTasks = new List<FSMTask>();
		blackboard = new Dictionary<string, string>();
	}

	private void Start()
	{
		if (states.Count <= 0)
		{
			return;
		}
		CurrentState = states[0];
		foreach (FSMTask onEnterTask in CurrentState.onEnterTasks)
		{
			onEnterTask.StartTask(this);
			onEnterTask.ExecuteTask(this);
			onEnterTask.EndTask(this);
		}
	}

	private void Update()
	{
		if (!paused)
		{
			EvaluateStates();
			DoTasks();
		}
	}

	private void OnDestroy()
	{
		CurrentState = null;
	}

	private void UpdateCurrentTasks()
	{
		foreach (FSMTask currentTask in currentTasks)
		{
			if (currentTask.instanceTask)
			{
				Object.Destroy(currentTask);
			}
		}
		currentTasks.Clear();
		if (!currentState)
		{
			return;
		}
		foreach (FSMTask task in currentState.tasks)
		{
			if (task.instanceTask)
			{
				currentTasks.Add(Object.Instantiate(task));
			}
			else
			{
				currentTasks.Add(task);
			}
		}
	}

	private void EvaluateStates()
	{
		FSMState fSMState = null;
		foreach (FSMTransition anyStateTransition in anyStateTransitions)
		{
			if (anyStateTransition.state != currentState && anyStateTransition.EvaluateConditions(this))
			{
				fSMState = anyStateTransition.state;
			}
		}
		if (fSMState != null)
		{
			CurrentState = fSMState;
		}
		else if (CurrentState != null)
		{
			fSMState = CurrentState.EvaluateTransitions(this);
			if (fSMState != null)
			{
				CurrentState = fSMState;
			}
		}
	}

	private void DoTasks()
	{
		if (!(CurrentState != null))
		{
			return;
		}
		foreach (FSMTask currentTask in currentTasks)
		{
			currentTask.ExecuteTask(this);
		}
	}

	public void Pause(bool pause = true)
	{
		paused = pause;
	}
}
