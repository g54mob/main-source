using UnityEngine;

public abstract class TransitionState : MonoBehaviour
{
	private enum StateStep
	{
		Enter = 0,
		InUpdate = 1,
		Exit = 2
	}

	private StateStep stateStep;

	public string stateName;

	public bool useStateDuration;

	public float duration;

	private float timer;

	public TransitionStateMachine manager;

	public TransitionState fallbackState;

	public TransitionState targetState;

	private bool isRunning;

	public void ReEnterState()
	{
		Enter();
	}

	public void SetFallbackState(TransitionState state)
	{
		fallbackState = state;
	}

	public void SetTargetState(TransitionState state)
	{
		targetState = state;
	}

	public void Start()
	{
		base.gameObject.name = base.name + "_State";
		OnStart();
	}

	public void SetDuration(float newDuration)
	{
		duration = newDuration;
		timer = duration;
	}

	public void Enter()
	{
		isRunning = true;
		stateStep = StateStep.Enter;
		OnEnter();
		if (useStateDuration)
		{
			timer = duration;
		}
	}

	public void DurationUpdate()
	{
		OnContinousUpdate();
		if (useStateDuration)
		{
			if (timer <= 0f)
			{
				timer = 0f;
				OnStateDurationOver();
			}
			else
			{
				timer -= 1f * Time.deltaTime;
			}
		}
	}

	public void UpdateState()
	{
		OnUpdate();
		stateStep = StateStep.InUpdate;
		if (ExitCondition() && !useStateDuration && targetState != null)
		{
			manager.ChangeState(targetState);
		}
	}

	public void Exit()
	{
		stateStep = StateStep.Exit;
		isRunning = false;
		OnExit();
	}

	public virtual void OnStart()
	{
	}

	public abstract void OnEnter();

	public abstract void OnUpdate();

	public abstract void OnExit();

	public virtual void OnDismiss()
	{
	}

	public virtual void OnStateDurationOver()
	{
		manager.ChangeState(targetState);
	}

	public virtual void OnContinousUpdate()
	{
	}

	public virtual bool ExitCondition()
	{
		return true;
	}

	private void DebugState()
	{
		base.gameObject.name = "[ACTIVE] " + base.name + " [" + stateStep.ToString().ToUpper() + "]";
	}
}
