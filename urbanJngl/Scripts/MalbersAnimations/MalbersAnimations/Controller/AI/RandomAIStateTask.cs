using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Random AI State")]
	public class RandomAIStateTask : MTask
	{
		[NonReorderable]
		public MAIState[] states;

		public override string DisplayName => "General/Random AI State";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			brain.TaskDone(index);
			if (states == null || states.Length != 0)
			{
				brain.StartNewState(states[Random.Range(0, states.Length)]);
			}
		}

		private void Reset()
		{
			Description = "From a State List choses a random AI State and Play it on the Brain";
		}
	}
}
