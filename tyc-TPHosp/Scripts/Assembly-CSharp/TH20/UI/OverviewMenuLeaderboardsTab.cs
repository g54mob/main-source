using UnityEngine;

namespace TH20.UI
{
	public class OverviewMenuLeaderboardsTab : OverviewMenuTab
	{
		[SerializeField]
		private LeaderboardsTabPanel _hospitalValuePanel;

		[SerializeField]
		private LeaderboardsTabPanel _cureRatePanel;

		[SerializeField]
		private LeaderboardsTabPanel _reputationPanel;

		[SerializeField]
		private LeaderboardsTabPanel _profitsPanel;

		[SerializeField]
		private LeaderboardsTabPanel _cureTotalsPanel;

		[SerializeField]
		private LeaderboardsTabPanel _staffMoralePanel;

		[SerializeField]
		private GameObject _leaderboardItemPrefab;

		private bool _showFriends = true;

		private LeaderboardConfig _leaderboardConfig;

		private Level _theLevel;

		public override void Setup(OverviewMenu theOverviewRoot, OverviewMenu.Mode theMode)
		{
			base.Setup(theOverviewRoot, theMode);
			_theLevel = theOverviewRoot.TheLevel;
			_leaderboardConfig = ((_theLevel != null) ? _theLevel.Config.GetLeaderboardConfig() : null);
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				_showFriends = false;
			}
			InitialisePanel(_hospitalValuePanel);
			InitialisePanel(_cureRatePanel);
			InitialisePanel(_reputationPanel);
			InitialisePanel(_profitsPanel);
			InitialisePanel(_cureTotalsPanel);
			InitialisePanel(_staffMoralePanel);
		}

		private void InitialisePanel(LeaderboardsTabPanel _theTabPanel)
		{
			_theTabPanel.SetupLeaderboardView(_theLevel.Metagame, _leaderboardConfig, _showFriends);
			_theTabPanel.PopulateLeaderboardView(_leaderboardItemPrefab);
		}
	}
}
