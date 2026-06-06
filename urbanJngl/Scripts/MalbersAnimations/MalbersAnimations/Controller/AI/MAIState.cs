using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/AI State", order = -100, fileName = "New AI State")]
	public class MAIState : ScriptableObject
	{
		[Tooltip("ID of the AI State. This is used on the AI Brain On AIStateChanged Event")]
		public IntReference ID = new IntReference();

		public MTask[] tasks;

		public MAITransition[] transitions;

		public Color GizmoStateColor = Color.gray;

		[HideInInspector]
		public bool CreateTaskAsset = true;

		[HideInInspector]
		public bool CreateDecisionAsset = true;

		[HideInInspector]
		[SerializeField]
		private int TasksIndex = -1;

		[HideInInspector]
		[SerializeField]
		private int DecisionIndex = -1;

		public MTask this[int index]
		{
			get
			{
				return tasks[index];
			}
			set
			{
				tasks[index] = value;
			}
		}

		private void Reset()
		{
			tasks = new MTask[0];
			transitions = new MAITransition[0];
		}

		public virtual void Play(MAnimalBrain brain)
		{
			brain?.StartNewState(this);
		}

		internal void Update_State(MAnimalBrain brain)
		{
			Update_Tasks(brain);
			Update_Transitions(brain);
		}

		private void Update_Transitions(MAnimalBrain brain)
		{
			for (int i = 0; i < transitions.Length; i++)
			{
				if (this != brain.currentState)
				{
					break;
				}
				MAITransition mAITransition = transitions[i];
				MAIDecision decision = mAITransition.decision;
				if (decision == null)
				{
					break;
				}
				if ((decision.waitForTask != -1 && !brain.IsTasksDone(decision.waitForTask)) || (decision.WaitForAllTasks && !brain.AllTasksDone()))
				{
					continue;
				}
				if ((float)decision.interval > 0f)
				{
					if (brain.CheckIfDecisionsCountDownElapsed(decision.interval, i))
					{
						brain.ResetDecisionTime(i);
						Decide(brain, i, mAITransition);
					}
				}
				else
				{
					Decide(brain, i, mAITransition);
				}
			}
		}

		private void Decide(MAnimalBrain brain, int Index, MAITransition transition)
		{
			if (transition.decision.active)
			{
				bool flag;
				brain.DecisionResult[Index] = (flag = transition.decision.Decide(brain, Index));
				bool flag2 = flag;
				brain.TransitionToState(flag2 ? transition.trueState : transition.falseState, flag2, transition.decision, Index);
			}
		}

		internal void Start_AIState(MAnimalBrain brain)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				StartTaks(brain, i);
			}
		}

		internal void StartTaks(MAnimalBrain brain, int i)
		{
			if (tasks[i] == null)
			{
				Debug.LogError("The  " + base.name + " AI State has an Empty Task. Please check all your AI States Tasks. " + brain.Animal.name + " brain is Disabled", this);
				brain.enabled = false;
			}
			else if (tasks[i].active && !brain.TasksStarted[i] && (i == 0 || !tasks[i].WaitForPreviousTask))
			{
				brain.TasksStarted[i] = true;
				brain.SetTaskStartTime(i);
				tasks[i].StartTask(brain, i);
				if ((int)tasks[i].MessageID != 0)
				{
					brain.OnTaskStarted.Invoke(tasks[i].MessageID);
				}
			}
		}

		internal void StartWaitforPreviusTask(MAnimalBrain brain, int i)
		{
			if (tasks[i] == null)
			{
				Debug.LogError("The  " + base.name + " AI State has an Empty Task. Please check all your AI States Tasks. " + brain.Animal.name + " brain is Disabled", this);
				brain.enabled = false;
			}
			else if (!brain.TasksStarted[i] && tasks[i].WaitForPreviousTask)
			{
				brain.TasksStarted[i] = true;
				brain.SetTaskStartTime(i);
				tasks[i].StartTask(brain, i);
				if ((int)tasks[i].MessageID != 0)
				{
					brain.OnTaskStarted.Invoke(tasks[i].MessageID);
				}
			}
		}

		internal void Prepare_Decisions(MAnimalBrain brain)
		{
			if (transitions != null)
			{
				for (int i = 0; i < transitions.Length; i++)
				{
					transitions[i].decision.PrepareDecision(brain, i);
				}
			}
		}

		internal void Update_Tasks(MAnimalBrain brain)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				if (this != brain.currentState)
				{
					break;
				}
				if (brain.TasksStarted[i] && !brain.TasksDone[i] && tasks[i].active)
				{
					tasks[i].InternalUpdateTask(brain, i);
				}
			}
		}

		internal void Finish_Tasks(MAnimalBrain brain)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				if (tasks[i].active)
				{
					tasks[i].ExitAIState(brain, i);
				}
			}
		}

		internal void OnTargetArrived(MAnimalBrain brain, Transform target)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				if (tasks[i] != null)
				{
					tasks[i].OnTargetArrived(brain, target, i);
				}
			}
		}

		internal void OnAnimalStateEnter(MAnimalBrain brain, State state)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i]?.OnAnimalStateEnter(brain, state, i);
			}
		}

		internal void OnAnimalStateExit(MAnimalBrain brain, State state)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i]?.OnAnimalStateExit(brain, state, i);
			}
		}

		internal void OnAnimalStanceChange(MAnimalBrain brain, int Stance)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i]?.OnAnimalStanceChange(brain, Stance, i);
			}
		}

		internal void OnAnimalModeStart(MAnimalBrain brain, Mode mode)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i]?.OnAnimalModeStart(brain, mode, i);
			}
		}

		internal void OnAnimalModeEnd(MAnimalBrain brain, Mode mode)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i]?.OnAnimalModeEnd(brain, mode, i);
			}
		}

		public void OnTargetAnimalStateEnter(MAnimalBrain brain, State state)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i].OnTargetAnimalStateEnter(brain, state, i);
			}
		}

		public void OnTargetAnimalStateExit(MAnimalBrain brain, State state)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i].OnTargetAnimalStateExit(brain, state, i);
			}
		}

		public void OnTargetAnimalStanceChange(MAnimalBrain brain, int Stance)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i].OnTargetAnimalStanceChange(brain, Stance, i);
			}
		}

		public void OnTargetAnimalModeStart(MAnimalBrain brain, Mode mode)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i].OnTargetAnimalModeStart(brain, mode, i);
			}
		}

		public void OnTargetAnimalModeEnd(MAnimalBrain brain, Mode mode)
		{
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i].OnTargetAnimalModeEnd(brain, mode, i);
			}
		}
	}
}
