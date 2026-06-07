using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class MapButtonLeaderboardCard : MapButtonCard
	{
		[SerializeField]
		private LeaderboardPanel leaderboardPanel;

		[SerializeField]
		private TouchOptionButton recurringLeaderboardSelector;

		[SerializeField]
		private TouchButton leaderboardSelectorPrevious;

		[SerializeField]
		private TouchButton leaderboardSelectorNext;

		[SerializeField]
		private GameObject[] selectorDayOptions;

		[SerializeField]
		private GameObject[] selectorWeekOptions;

		[SerializeField]
		private GameObject[] selectorTypeOptions;

		public LeaderboardPanel LeaderboardPanel => leaderboardPanel;

		public TouchOptionButton RecurringLeaderboardSelector => recurringLeaderboardSelector;

		public TouchButton LeaderboardSelectorPrevious => leaderboardSelectorPrevious;

		public TouchButton LeaderboardSelectorNext => leaderboardSelectorNext;

		public TouchToggle LeaderboardSurroundingButton => leaderboardPanel.SurroundingLeaderboardsButton;

		public TouchToggle LeaderboardFriendsButton => leaderboardPanel.FriendsLeaderboardsButton;

		public TouchToggle LeaderboardGlobalButton => leaderboardPanel.GlobalLeaderboardsButton;

		public TouchToggle LeaderboardHistogramButton => leaderboardPanel.HistogramLeaderboardsButton;

		public TouchButton LeaderboardErrorButton => leaderboardPanel.LeaderboardErrorButton;

		public GameObject[] RecurringDayOptions => selectorDayOptions;

		public GameObject[] RecurringWeekOptions => selectorWeekOptions;

		public GameObject[] RecurringTypeOptions => selectorTypeOptions;
	}
}
