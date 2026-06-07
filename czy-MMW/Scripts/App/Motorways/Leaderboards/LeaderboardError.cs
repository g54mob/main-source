namespace Motorways.Leaderboards
{
	public class LeaderboardError
	{
		public LeaderboardErrorCode Code { get; private set; }

		public StringId Description { get; private set; }

		public LeaderboardError(LeaderboardErrorCode code, StringId description = StringId.None)
		{
			Code = code;
			Description = description;
		}

		public override string ToString()
		{
			return $"[LeaderboardError code={Code} Description={Description}]";
		}
	}
}
