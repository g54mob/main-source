using CTS.BBT.AI;

namespace CTS
{
	public class PunchingBallCaptureGoal : QuestNumericGoal
	{
		public PunchingBallCaptureGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			PunchingBall.HumanCaptured -= OnPunchingBallHumanCaptured;
		}

		public override void StartObserving()
		{
			PunchingBall.HumanCaptured += OnPunchingBallHumanCaptured;
		}

		private void OnPunchingBallHumanCaptured(Agent obj)
		{
			AddToGoalVariable(1);
		}
	}
}
