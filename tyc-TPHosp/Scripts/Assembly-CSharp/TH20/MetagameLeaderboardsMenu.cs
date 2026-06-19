using UnityEngine;

namespace TH20
{
	public class MetagameLeaderboardsMenu : AnimatedMenuBase
	{
		[SerializeField]
		private LeaderboardView _leaderboardStars;

		[SerializeField]
		private LeaderboardView _leaderboardValue;

		[SerializeField]
		private LeaderboardView _leaderboardSilver;

		[SerializeField]
		private LeaderboardView _leaderboardRemixBadges;

		public void Setup(Metagame metagame)
		{
			_leaderboardStars.Initialise(metagame);
			_leaderboardValue.Initialise(metagame);
			_leaderboardSilver.Initialise(metagame);
			_leaderboardRemixBadges.Initialise(metagame);
			_leaderboardStars.Setup(CareerStatsManager.Type.TotalStars, showFriends: true, null);
			_leaderboardValue.Setup(CareerStatsManager.Type.TotalFoundationValue, showFriends: true, null);
			_leaderboardSilver.Setup(CareerStatsManager.Type.TotalSilverEarned, showFriends: true, null);
			_leaderboardRemixBadges.Setup(CareerStatsManager.Type.TotalRemixBadges, showFriends: true, null);
		}
	}
}
