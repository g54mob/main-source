using CTS.BBT.AI;

namespace CTS
{
	public class ToiletUseGoal : QuestNumericGoal
	{
		public ToiletUseGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			AgentActionToilet.ToiletUsed -= OnToiletUsed;
		}

		public override void StartObserving()
		{
			AgentActionToilet.ToiletUsed += OnToiletUsed;
		}

		private void OnToiletUsed(Agent agent, Toilet toilet)
		{
			AddToGoalVariable(1);
		}
	}
}
