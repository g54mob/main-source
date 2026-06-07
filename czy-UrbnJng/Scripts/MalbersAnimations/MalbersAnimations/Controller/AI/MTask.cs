using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	public abstract class MTask : BrainBase
	{
		[Tooltip("ID Used for sending messages to the Brain to see if the Task started")]
		public IntReference MessageID = new IntReference(0);

		[Min(0f)]
		[Tooltip("Task using Update will be executed every X seconds")]
		public float UpdateInterval = 0.2f;

		[Tooltip("If the previous Task is done then this Task will start")]
		public bool WaitForPreviousTask;

		public abstract string DisplayName { get; }

		public virtual void StartTask(MAnimalBrain brain, int index)
		{
		}

		public virtual void InternalUpdateTask(MAnimalBrain brain, int index)
		{
			if (MTools.ElapsedTime(brain.TasksUpdateTime[index], UpdateInterval))
			{
				brain.TasksUpdateTime[index] = Time.time;
				UpdateTask(brain, index);
			}
		}

		public virtual void UpdateTask(MAnimalBrain brain, int index)
		{
		}

		public virtual void ExitAIState(MAnimalBrain brain, int index)
		{
			brain.TaskDone(index);
		}

		public virtual void OnTargetArrived(MAnimalBrain brain, Transform target, int index)
		{
		}

		public virtual void OnPositionArrived(MAnimalBrain brain, Vector3 Position, int index)
		{
		}

		public virtual void OnAnimalStateEnter(MAnimalBrain brain, State state, int index)
		{
		}

		public virtual void OnAnimalStateExit(MAnimalBrain brain, State state, int index)
		{
		}

		public virtual void OnAnimalStanceChange(MAnimalBrain brain, int Stance, int index)
		{
		}

		public virtual void OnAnimalModeStart(MAnimalBrain brain, Mode mode, int index)
		{
		}

		public virtual void OnAnimalModeEnd(MAnimalBrain brain, Mode mode, int index)
		{
		}

		public virtual void OnTargetAnimalStateEnter(MAnimalBrain brain, State state, int index)
		{
		}

		public virtual void OnTargetAnimalStateExit(MAnimalBrain brain, State state, int index)
		{
		}

		public virtual void OnTargetAnimalStanceChange(MAnimalBrain brain, int Stance, int index)
		{
		}

		public virtual void OnTargetAnimalModeStart(MAnimalBrain brain, Mode mode, int index)
		{
		}

		public virtual void OnTargetAnimalModeEnd(MAnimalBrain brain, Mode mode, int index)
		{
		}
	}
}
