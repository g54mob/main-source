namespace Motorways
{
	public class ChallengeOverride
	{
		public readonly int timestamp;

		public readonly string cityName;

		public readonly string[] challengeNames;

		public ChallengeOverride(int timestamp, string cityName, string[] challengeNames)
		{
			this.timestamp = timestamp;
			this.cityName = cityName;
			this.challengeNames = challengeNames;
		}
	}
}
