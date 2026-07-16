using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public abstract class FSMState : MonoBehaviour
{
	private enum FSMStateStep
	{
		Enter = 0,
		WaitForTarget = 1,
		IsMoving = 2,
		Arrived = 3,
		InUpdate = 4,
		Exit = 5
	}

	private FSMStateStep stateStep;

	public new string name;

	public bool arriveToArea;

	public bool useCustomReachRadius;

	public float reachRadius = 2f;

	public bool useStateDuration;

	public float duration;

	private float timer;

	public Transform moveTarget;

	public GameObject agent;

	protected NavMeshAgent navAgent;

	public bool useParentRoutine = true;

	public FSMRoutine routine;

	public FSMState fallbackState;

	public FSMState targetState;

	private bool arrivedAtTargetPosition;

	private bool isRunning;

	public void ReEnterState()
	{
		Enter();
	}

	public void SetFallbackState(FSMState state)
	{
		fallbackState = state;
	}

	public void SetTargetState(FSMState state)
	{
		targetState = state;
	}

	public void WaitForATarget()
	{
		AssignTarget();
	}

	public void Start()
	{
		base.gameObject.name = name + "_State";
		navAgent = agent.GetComponent<NavMeshAgent>();
		if (useParentRoutine)
		{
			routine = base.transform.parent.GetComponent<FSMRoutine>();
		}
	}

	public void SetDuration(float newDuration)
	{
		duration = newDuration;
		timer = duration;
	}

	public void Enter()
	{
		arrivedAtTargetPosition = false;
		moveTarget = null;
		isRunning = true;
		stateStep = FSMStateStep.Enter;
		if (navAgent == null)
		{
			navAgent = agent.GetComponent<NavMeshAgent>();
		}
		OnInit();
		if (useStateDuration)
		{
			timer = duration;
		}
	}

	public void DurationUpdate()
	{
		if (isRunning)
		{
			DebugState();
		}
		if (!arrivedAtTargetPosition)
		{
			return;
		}
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
		if (moveTarget == null)
		{
			stateStep = FSMStateStep.WaitForTarget;
			WaitForATarget();
			arrivedAtTargetPosition = false;
			return;
		}
		if (!arrivedAtTargetPosition)
		{
			CheckArrival();
			return;
		}
		OnUpdate();
		stateStep = FSMStateStep.InUpdate;
		if (ExitCondition() && !useStateDuration && targetState != null)
		{
			routine.ChangeState(targetState);
		}
	}

	private bool CheckArrival()
	{
		bool flag = false;
		flag = ((!arriveToArea) ? ((double)Vector3.Distance(moveTarget.position, agent.transform.position) < (useCustomReachRadius ? ((double)reachRadius) : ((double)navAgent.stoppingDistance + 0.1))) : InsideAreaTarget());
		if (flag)
		{
			ArriveAtDestination();
		}
		else
		{
			IsMoving();
		}
		bool state = stateStep == FSMStateStep.IsMoving;
		if (((navAgent != null) & navAgent.isActiveAndEnabled) && navAgent.isStopped)
		{
			state = false;
		}
		agent.GetComponent<CustomerCore>().SetAnimationState("Move", state);
		arrivedAtTargetPosition = flag;
		return flag;
	}

	private void ArriveAtDestination()
	{
		agent.GetComponent<CustomerCore>().TriggerAnimationState("Idle");
		navAgent.isStopped = true;
		navAgent.ResetPath();
		OnArrive();
		SetAnimationStateOnArrive();
		stateStep = FSMStateStep.Arrived;
	}

	private bool IsMoving()
	{
		if (navAgent.destination != moveTarget.position)
		{
			navAgent.SetDestination(moveTarget.position);
			navAgent.isStopped = false;
		}
		stateStep = FSMStateStep.IsMoving;
		return true;
	}

	public void Exit()
	{
		stateStep = FSMStateStep.Exit;
		base.gameObject.name = name + "_State";
		isRunning = false;
	}

	public virtual bool InsideAreaTarget()
	{
		return false;
	}

	public virtual void RegisterTargetState()
	{
	}

	public virtual void SetAnimationStateOnArrive()
	{
	}

	public virtual void OnInit()
	{
	}

	public virtual void OnDismiss()
	{
	}

	public abstract void AssignTarget();

	public abstract void OnArrive();

	public abstract void OnUpdate();

	public virtual void OnStateDurationOver()
	{
		routine.ChangeState(targetState);
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
		base.gameObject.name = "[ACTIVE] " + name + " [" + stateStep.ToString().ToUpper() + "]";
	}
}
