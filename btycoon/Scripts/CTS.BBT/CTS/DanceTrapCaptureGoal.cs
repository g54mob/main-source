using CTS.BBT.AI;

namespace CTS
{
	public class DanceTrapCaptureGoal : QuestNumericGoal
	{
		public DanceTrapCaptureGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			DanceTrap.HumanCaptured -= OnPunchingBallHumanCaptured;
		}

		public override void StartObserving()
		{
			DanceTrap.HumanCaptured += OnPunchingBallHumanCaptured;
		}

		private void OnPunchingBallHumanCaptured(Agent obj)
		{
			AddToGoalVariable(1);
		}
	}
}
