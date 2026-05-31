namespace CTS.BBT.AI
{
	public struct SatisfactionEvent
	{
		public Agent Agent;

		public bool IsGood;

		public SatisfactionEvent(Agent agent, bool isGood)
		{
			Agent = agent;
			IsGood = isGood;
		}
	}
}
