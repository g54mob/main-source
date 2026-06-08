using UnityEngine;

namespace Dorfromantik
{
	public class NintendoSwitchLeaderboardManager : MonoBehaviour
	{
		[SerializeField]
		private RewardSystem rewardSystem;

		[SerializeField]
		private LeaderboardManager leaderboardManager;

		[SerializeField]
		private CustomModeConfiguration customModeConfiguration;

		[SerializeField]
		private TileGenerator tileGenerator;

		[SerializeField]
		private MonthlyModeManager monthlyModeManager;

		[SerializeField]
		private SettingsRouter settingsRouter;

		[SerializeField]
		private NetworkEventRouter networkEventRouter;
	}
}
