using CTS.BBT.AI;

namespace CTS
{
	public class HypnoticTrapCaptureGoal : QuestNumericGoal
	{
		public HypnoticTrapCaptureGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			Hypnotic.HumanCaptured += OnHumanCaptured;
		}

		public override void StartObserving()
		{
			Hypnotic.HumanCaptured += OnHumanCaptured;
		}

		private void OnHumanCaptured(Agent obj)
		{
			AddToGoalVariable(1);
		}
	}
}
