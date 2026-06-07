using CTS.BBT.AI;

namespace CTS
{
	public class KillAgentWithTagGoal : QuestNumericGoal
	{
		protected EAgentTag[] Tags { get; private set; }

		public KillAgentWithTagGoal(Quest quest, int entryID, string variableName, string targetVariableName, params EAgentTag[] tags)
			: base(quest, entryID, variableName, targetVariableName)
		{
			Tags = tags;
		}

		public override void StopObserving()
		{
			Agent.Died -= OnAgentDied;
			AgentActionGetDeleted.AgentDeleted -= OnAgentDied;
		}

		public override void StartObserving()
		{
			Agent.Died += OnAgentDied;
			AgentActionGetDeleted.AgentDeleted += OnAgentDied;
		}

		private void OnAgentDied(Agent agent)
		{
			if (agent.Tags.HasOneOfTags(Tags))
			{
				AddToGoalVariable(1);
			}
		}
	}
}
