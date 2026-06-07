using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Decision/Task Done Decision", order = 200)]
	public class TaskDecision : MAIDecision
	{
		[Space]
		[Tooltip("What Task Index you want to check if is Done")]
		public int TaskIndex;

		public override string DisplayName => "General/Is Task Done?";

		public override bool Decide(MAnimalBrain brain, int index)
		{
			return brain.IsTaskDone(TaskIndex);
		}
	}
}
