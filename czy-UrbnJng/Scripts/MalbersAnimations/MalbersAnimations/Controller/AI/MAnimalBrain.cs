using System;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Serialization;

namespace MalbersAnimations.Controller.AI
{
	[AddComponentMenu("Malbers/Animal Controller/AI/Animal Brain")]
	public class MAnimalBrain : MonoBehaviour, IAnimatorListener
	{
		public IAIControl AIControl;

		[RequiredField]
		[Tooltip("Transform used to raycast Rays to interact with the world")]
		public Transform Eyes;

		[Tooltip("Time needed to make a new transition. Necessary to avoid Changing to multiple States in the same frame")]
		public FloatReference TransitionCoolDown = new FloatReference(0.2f);

		[CreateScriptableAsset]
		public MAIState currentState;

		[Tooltip("Removes all AI Components when the Animal Dies. (Brain, AiControl, Agent)")]
		[FormerlySerializedAs("RemoveAIOnDeath")]
		public bool DisableAIOnDeath = true;

		public bool debug;

		public bool debugAIStates;

		public IntEvent OnTaskStarted = new IntEvent();

		public IntEvent OnTaskDone = new IntEvent();

		public IntEvent OnDecisionSucceeded = new IntEvent();

		public IntEvent OnAIStateChanged = new IntEvent();

		private float TransitionLastTime;

		public BrainVars[] TasksVars;

		internal bool[] TasksDone;

		internal bool[] DecisionResult;

		internal bool[] TasksStarted;

		public BrainVars[] DecisionsVars;

		internal bool BrainInitialize;

		[HideInInspector]
		public float[] DecisionsTime;

		[SerializeField]
		private int Editor_Tabs1;

		[Obsolete("Use AIControl Instead")]
		public IAIControl AIMovement => AIControl;

		public float StateLastTime { get; set; }

		public MAnimal Animal { get; private set; }

		public Dictionary<int, Stat> AnimalStats { get; set; }

		public Transform Target { get; set; }

		public MAnimal TargetAnimal { get; set; }

		public MLocalVars TargetVars { get; set; }

		public MLocalVars LocalVars { get; private set; }

		public MLocalVars ExtraLocalVars { get; set; }

		public Vector3 Position => AIControl.Transform.position;

		public float AIHeight => Animal.transform.lossyScale.y * AIControl.StoppingDistance;

		public bool TargetHasStats { get; private set; }

		public Dictionary<int, Stat> TargetStats { get; set; }

		public IWayPoint LastWayPoint { get; set; }

		public float[] TasksStartTime { get; set; }

		public float[] TasksUpdateTime { get; set; }

		Transform IAnimatorListener.transform => base.transform;

		public bool AllTasksDone()
		{
			bool[] tasksDone = TasksDone;
			for (int i = 0; i < tasksDone.Length; i++)
			{
				if (!tasksDone[i])
				{
					return false;
				}
			}
			return true;
		}

		public void TaskDone(MTask task)
		{
			if (!(currentState != null))
			{
				return;
			}
			for (int i = 0; i < currentState.tasks.Length; i++)
			{
				if (currentState.tasks[i] == task)
				{
					TaskDone(i);
					break;
				}
			}
		}

		public bool IsTasksDone(int index)
		{
			return TasksDone[index % TasksDone.Length];
		}

		private void Awake()
		{
			if (Animal == null)
			{
				Animal = base.gameObject.FindComponent<MAnimal>();
			}
			if (LocalVars == null)
			{
				LocalVars = base.gameObject.FindComponent<MLocalVars>();
			}
			if (LocalVars == null)
			{
				LocalVars = base.gameObject.AddComponent<MLocalVars>();
			}
			if (AIControl == null)
			{
				AIControl = base.gameObject.FindInterface<IAIControl>();
			}
			Stats stats = Animal.FindComponent<Stats>();
			if ((bool)stats)
			{
				AnimalStats = stats.Stats_Dictionary();
			}
			Animal.isPlayer.Value = false;
		}

		public void OnEnable()
		{
			AIControl.TargetSet.AddListener(OnTargetSet);
			AIControl.OnArrived.AddListener(OnTargetArrived);
			Animal.OnStateChange.AddListener(OnAnimalStateChange);
			Animal.OnStanceChange.AddListener(OnAnimalStanceChange);
			Animal.OnModeStart.AddListener(OnAnimalModeStart);
			Animal.OnModeEnd.AddListener(OnAnimalModeEnd);
			this.Delay_Action(() => !AIControl.AIReady, StartBrain);
		}

		public void OnDisable()
		{
			AIControl.TargetSet.RemoveListener(OnTargetSet);
			AIControl.OnArrived.RemoveListener(OnTargetArrived);
			Animal.OnStateChange.RemoveListener(OnAnimalStateChange);
			Animal.OnStanceChange.RemoveListener(OnAnimalStanceChange);
			Animal.OnModeStart.RemoveListener(OnAnimalModeStart);
			Animal.OnModeEnd.RemoveListener(OnAnimalModeEnd);
			StopAllCoroutines();
			if ((bool)currentState)
			{
				for (int i = 0; i < currentState.tasks.Length; i++)
				{
					currentState.tasks[i]?.ExitAIState(this, i);
				}
			}
			BrainInitialize = false;
		}

		private void Update()
		{
			if (BrainInitialize && currentState != null)
			{
				currentState.Update_State(this);
			}
		}

		public void StartBrain()
		{
			if ((bool)currentState)
			{
				AIControl.AutoNextTarget = false;
				AIControl.SetActive(value: true);
				OnTargetSet(AIControl.Target);
				for (int i = 0; i < currentState.tasks.Length; i++)
				{
					if (currentState.tasks[i] == null)
					{
						Debug.LogError("The [" + currentState.name + "] AI State has an Empty Task. AI States can't have empty Tasks. " + Animal.name, currentState);
						return;
					}
				}
				StartNewState(currentState);
				LastWayPoint = null;
				if ((bool)AIControl.Target)
				{
					SetLastWayPoint(AIControl.Target);
				}
				BrainInitialize = true;
			}
			else
			{
				base.enabled = false;
			}
		}

		public virtual void TransitionToState(MAIState nextState, bool decisionValue, MAIDecision decision, int Index)
		{
			if (MTools.ElapsedTime(TransitionLastTime, TransitionCoolDown) && nextState != null && nextState != currentState)
			{
				TransitionLastTime = Time.time;
				decision.FinishDecision(this, Index);
				Debuging("<color=white>Changed AI State from <B>[" + currentState.name + "]</B> to" + $" <B>[{nextState.name}]</B>. Decision: <b>[{decision.name}]</b> = <B>[{decisionValue}]</B>.</color>", currentState);
				InvokeDecisionEvent(decisionValue, decision);
				StartNewState(nextState);
			}
		}

		protected virtual void Debuging(string Log, UnityEngine.Object val)
		{
			if (debug)
			{
				Debug.Log("<B><color=green>[" + Animal.name + "]</color> - </B> " + Log, val);
			}
		}

		private void InvokeDecisionEvent(bool decisionValue, MAIDecision decision)
		{
			if (decision.send == MAIDecision.WSend.SendTrue && decisionValue)
			{
				OnDecisionSucceeded.Invoke(decision.DecisionID);
			}
			else if (decision.send == MAIDecision.WSend.SendFalse && !decisionValue)
			{
				OnDecisionSucceeded.Invoke(decision.DecisionID);
			}
		}

		public virtual void Play(MAIState newState)
		{
			StartNewState(newState);
		}

		public virtual void StartNewState(MAIState newState)
		{
			if (!base.enabled)
			{
				base.enabled = true;
			}
			StateLastTime = Time.time;
			if (currentState != null && currentState != newState)
			{
				currentState.Finish_Tasks(this);
			}
			currentState = newState;
			ResetVarsOnNewState();
			OnAIStateChanged.Invoke(currentState.ID);
			currentState.Start_AIState(this);
			currentState.Prepare_Decisions(this);
			Debuging("<color=white>Play AI State <B>[" + currentState.name + "]</B>. " + $"Tasks[{currentState.tasks.Length}]. Decisions[{currentState.transitions.Length}]</color>", currentState);
		}

		private void ResetVarsOnNewState()
		{
			if (!currentState)
			{
				return;
			}
			int num = ((currentState.tasks == null || currentState.tasks.Length == 0) ? 1 : currentState.tasks.Length);
			int num2 = ((currentState.transitions == null || currentState.transitions.Length == 0) ? 1 : currentState.transitions.Length);
			TasksVars = new BrainVars[num];
			TasksUpdateTime = new float[num];
			TasksStartTime = new float[num];
			TasksDone = new bool[num];
			TasksStarted = new bool[num];
			DecisionsVars = new BrainVars[num2];
			DecisionsTime = new float[num2];
			DecisionResult = new bool[num2];
			for (int i = 0; i < currentState.tasks.Length; i++)
			{
				if (!currentState.tasks[i].active)
				{
					TasksDone[i] = true;
				}
			}
		}

		public bool IsTaskDone(int TaskIndex)
		{
			return TasksDone[TaskIndex];
		}

		public void TaskDone(int TaskIndex, bool value = true)
		{
			if (!TasksDone[TaskIndex])
			{
				TasksDone[TaskIndex] = value;
				OnTaskDone.Invoke(currentState[TaskIndex].MessageID.Value);
				if (TaskIndex + 1 < currentState.tasks.Length && currentState.tasks[TaskIndex + 1].WaitForPreviousTask)
				{
					currentState.StartWaitforPreviusTask(this, TaskIndex + 1);
				}
			}
		}

		public bool CheckIfDecisionsCountDownElapsed(float duration, int index)
		{
			DecisionsTime[index] += Time.deltaTime;
			return DecisionsTime[index] >= duration;
		}

		public void SetTaskStartTime(int Index)
		{
			TasksStartTime[Index] = Time.time;
		}

		public void ResetDecisionTime(int Index)
		{
			DecisionsTime[Index] = 0f;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}

		private void OnAnimalStateChange(int state)
		{
			currentState?.OnAnimalStateEnter(this, Animal.ActiveState);
			currentState?.OnAnimalStateExit(this, Animal.LastState);
			if (state == StateEnum.Death)
			{
				for (int i = 0; i < currentState.tasks.Length; i++)
				{
					currentState.tasks[i].ExitAIState(this, i);
				}
				StopAllCoroutines();
				BrainInitialize = false;
				base.enabled = false;
				if (DisableAIOnDeath)
				{
					AIControl.SetActive(value: false);
					AIControl.ClearTarget();
				}
			}
		}

		private void OnAnimalStanceChange(int stance)
		{
			currentState.OnAnimalStanceChange(this, Animal.Stance.ID);
		}

		private void OnAnimalModeStart(int mode, int ability)
		{
			currentState.OnAnimalModeStart(this, Animal.ActiveMode);
		}

		private void OnAnimalModeEnd(int mode, int ability)
		{
			currentState.OnAnimalModeEnd(this, Animal.ActiveMode);
		}

		private void OnTargetArrived(Transform target)
		{
			currentState.OnTargetArrived(this, target);
		}

		private void OnTargetSet(Transform target)
		{
			Target = target;
			TargetAnimal = null;
			TargetVars = null;
			TargetStats = null;
			TargetHasStats = false;
			if ((bool)target)
			{
				TargetAnimal = target.FindComponent<MAnimal>();
				TargetVars = target.FindComponent<MLocalVars>();
				Stats stats = target.FindComponent<Stats>();
				TargetHasStats = stats != null;
				if (TargetHasStats)
				{
					TargetStats = stats.Stats_Dictionary();
				}
			}
		}

		public bool CheckForPreviusTaskDone(int index)
		{
			if (index == 0)
			{
				return true;
			}
			if (!TasksStarted[index] && IsTaskDone(index - 1))
			{
				return true;
			}
			return false;
		}

		public void SetLastWayPoint(Transform target)
		{
			if (target.gameObject.FindInterface<IWayPoint>() != null)
			{
				LastWayPoint = target?.gameObject.FindInterface<IWayPoint>();
			}
		}
	}
}
