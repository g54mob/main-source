using System.Collections.Generic;
using FullInspector;

namespace TH20
{
	public class LeaderboardConfig
	{
		public List<CareerStatsManager.Type> LeaderboardPlaylistYearEnd;

		public Dictionary<SharedInstance<RivalFoundationDefinition>, float> RivalHospitalStrength;

		public Dictionary<CareerStatsManager.Type, int> MinimumScores;

		public Dictionary<CareerStatsManager.Type, int> MaximumScores;
	}
}
