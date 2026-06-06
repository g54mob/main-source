using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Chance Task")]
	public class ChanceTask : MTask
	{
		private static readonly int ChanceKey = "ChanceTask".GetHashCode();

		[Range(0f, 1f)]
		[Tooltip("Chance this Task can execute another Task when the AI State start")]
		public float Chance = 1f;

		[Tooltip("Task to execute if the chance succeded")]
		public MTask Task;

		[Tooltip("Task to execute if the chance failed")]
		public MTask TaskFailed;

		public override string DisplayName => "General/Chance";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			float num = Random.Range(0f, 1f);
			bool flag = Chance >= num;
			brain.TasksVars[index].boolValue = flag;
			if (brain.debug)
			{
				Debug.Log($"Probability to execute <B>[{Task.name}]</B>. Value:<B>[{num:F2}]</B> >= Limit:<B>[{Chance:F2}] ?</B>. Result: [<B>{flag}]</B>");
			}
			if (flag)
			{
				Task?.StartTask(brain, index);
			}
			else
			{
				TaskFailed?.StartTask(brain, index);
			}
		}

		public override void UpdateTask(MAnimalBrain brain, int index)
		{
			if (brain.TasksVars[index].boolValue)
			{
				Task.UpdateTask(brain, index);
			}
			else
			{
				TaskFailed?.UpdateTask(brain, index);
			}
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			if (brain.TasksVars[index].boolValue)
			{
				Task.ExitAIState(brain, index);
			}
			else
			{
				TaskFailed?.ExitAIState(brain, index);
			}
		}

		private void Reset()
		{
			Description = "Gives a Percent Chance to execute another task";
		}
	}
}
