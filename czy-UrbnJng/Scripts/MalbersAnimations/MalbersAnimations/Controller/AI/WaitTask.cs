using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Wait")]
	public class WaitTask : MTask
	{
		[Space]
		public FloatReference WaitMinTime = new FloatReference(5f);

		public FloatReference WaitMaxTime = new FloatReference(5f);

		[Tooltip("After the wait is over if this MAI State is not null. Execute it!")]
		public MAIState NextState;

		public override string DisplayName => "General/Wait";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			brain.TasksVars[index].floatValue = Random.Range(WaitMinTime, WaitMaxTime);
		}

		public override void UpdateTask(MAnimalBrain brain, int index)
		{
			if (MTools.ElapsedTime(brain.TasksStartTime[index], brain.TasksVars[index].floatValue))
			{
				brain.TaskDone(index);
				if ((bool)NextState)
				{
					brain.StartNewState(NextState);
				}
			}
		}
	}
}
