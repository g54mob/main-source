using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	public abstract class MAIDecision : BrainBase
	{
		public enum WSend
		{
			None = 0,
			SendTrue = 1,
			SendFalse = 2
		}

		[Space]
		[Tooltip("ID Used for sending messages to the Brain to see if the Decision was TRUE or FALSE")]
		public IntReference DecisionID = new IntReference(0);

		[Tooltip("What to send to to the Brain.OnDecisionSucceeded() if a Decision is executed")]
		public WSend send;

		[Tooltip("Execute the Decide method every x Seconds to improve performance")]
		public FloatReference interval = new FloatReference(0.2f);

		[Tooltip("Check for decisions after all tasks are done")]
		public bool WaitForAllTasks;

		[Tooltip("Check for decisions after an specific task is done. (Using this Index) -1 will be ignored")]
		[Min(-1f)]
		public int waitForTask = -1;

		public abstract string DisplayName { get; }

		public abstract bool Decide(MAnimalBrain brain, int Index);

		public virtual void PrepareDecision(MAnimalBrain brain, int Index)
		{
		}

		public virtual void FinishDecision(MAnimalBrain brain, int Index)
		{
		}

		public virtual void OnAnimalEventDecisionListen(MAnimalBrain brain, MAnimal animal, int Index)
		{
		}
	}
}
