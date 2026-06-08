namespace Dorfromantik
{
	public class ChallengeTooltipState
	{
		public SessionQuest challenge;

		public int level;

		public ChallengeTooltipState(SessionQuest challenge, int level)
		{
			this.challenge = challenge;
			this.level = level;
		}
	}
}
