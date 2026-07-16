using UnityEngine;
using UnityEngine.Events;

public class FSMManager : MonoBehaviour
{
	[SerializeField]
	private float routineTick = 1f;

	[SerializeField]
	private bool defaultCreate = true;

	public UnityEvent OnEndRoutine = new UnityEvent();

	private float tickProgress;

	private bool processRoutine;

	public FSMRoutine[] registeredRoutines;

	public FSMRoutine entryRoutine;

	public FSMRoutine currentRoutine;

	public FSMRoutine dismissRoutine;

	public FSMRoutine fallbackRoutine;

	public UnityEvent OnStateChangeEvent = new UnityEvent();

	private bool dismiss;

	private void Start()
	{
		if (defaultCreate)
		{
			Create();
		}
	}

	public void Create()
	{
		registeredRoutines = base.transform.GetComponentsInChildren<FSMRoutine>();
		FSMRoutine[] array = registeredRoutines;
		foreach (FSMRoutine obj in array)
		{
			obj.manager = this;
			obj.AssignAgent(base.transform.parent.gameObject);
		}
		if (!dismiss)
		{
			currentRoutine = entryRoutine;
			processRoutine = true;
			currentRoutine.OnStart();
			currentRoutine.gameObject.name = "[ACTIVE]" + currentRoutine.routineName + "_Routine";
		}
	}

	public void Dismiss()
	{
		dismiss = true;
		registeredRoutines = base.transform.GetComponentsInChildren<FSMRoutine>();
		FSMRoutine[] array = registeredRoutines;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DismissAgent();
		}
		ChangeRoutine(dismissRoutine);
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
				currentRoutine.OnUpdate();
				tickProgress = 0f;
			}
			currentRoutine.ContinuesUpdate();
		}
	}

	public void ChangeRoutine(FSMRoutine routine)
	{
		currentRoutine.gameObject.name = currentRoutine.routineName + "_Routine";
		currentRoutine.Exit();
		processRoutine = false;
		if (routine != null)
		{
			currentRoutine = routine;
		}
		else
		{
			currentRoutine = fallbackRoutine;
		}
		processRoutine = true;
		currentRoutine.OnStart();
		currentRoutine.gameObject.name = "[ACTIVE] " + currentRoutine.routineName + "_Routine";
		OnStateChangeEvent.Invoke();
	}

	public bool EndStateFlow(FSMRoutine endStateFSMRoutine)
	{
		if (!base.transform.gameObject.activeInHierarchy)
		{
			return false;
		}
		if (currentRoutine != null)
		{
			currentRoutine.ChangeRoutineTo(endStateFSMRoutine);
		}
		return true;
	}

	public string ReadActiveState()
	{
		return currentRoutine.currentStateName;
	}
}
