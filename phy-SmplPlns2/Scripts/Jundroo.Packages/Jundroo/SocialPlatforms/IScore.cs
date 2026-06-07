using System;

namespace Jundroo.SocialPlatforms
{
	public interface IScore
	{
		DateTime date { get; }

		string formattedValue { get; }

		string leaderboardID { get; set; }

		int rank { get; }

		string userID { get; }

		long value { get; set; }

		void ReportScore(Action<bool> callback);
	}
}
