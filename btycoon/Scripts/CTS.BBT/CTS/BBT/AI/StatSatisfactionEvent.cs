namespace CTS.BBT.AI
{
	public struct StatSatisfactionEvent
	{
		public Agent Agent;

		public bool IsGood;

		public EAgentStatistics Stat;

		public StatSatisfactionEvent(Agent agent, bool isGood, EAgentStatistics stat)
		{
			Agent = agent;
			IsGood = isGood;
			Stat = stat;
		}
	}
}
