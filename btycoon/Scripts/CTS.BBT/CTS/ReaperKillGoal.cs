using CTS.BBT.AI;

namespace CTS
{
	public class ReaperKillGoal : QuestNumericGoal
	{
		public ReaperKillGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			AgentActionReaperDash.ReaperDashKill -= OnReaperDashKill;
		}

		public override void StartObserving()
		{
			AgentActionReaperDash.ReaperDashKill += OnReaperDashKill;
		}

		private void OnReaperDashKill(Agent reaper, Agent victim)
		{
			AddToGoalVariable(1);
		}
	}
}
