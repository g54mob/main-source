using System.Collections.Generic;
using UnityEngine;

namespace TH20.UI
{
	public class LeaderboardsTabPanel : OverviewMenuTabPanel
	{
		[SerializeField]
		private CareerStatsManager.Type _theStatType;

		private LeaderboardView _theLeaderboardView;

		private Table _theTable;

		private readonly List<PanelItemLeaderboardElement> _rows = new List<PanelItemLeaderboardElement>(64);

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			_theTable = GetComponent<Table>();
			_theLeaderboardView = GetComponent<LeaderboardView>();
		}

		public void SetupLeaderboardView(Metagame metagame, LeaderboardConfig leaderboardConfig, bool showFriends)
		{
			_theLeaderboardView.Initialise(metagame);
			_theLeaderboardView.SetupHospitalList(_theStatType, showFriends, leaderboardConfig);
		}

		public void PopulateLeaderboardView(GameObject itemPrefab)
		{
			_theLeaderboardView.InstantiateRowPrefabsToTable(_theStatType, itemPrefab, _theTable);
		}

		public void Populate(GameObject itemPrefab)
		{
			if (!_theTable || !itemPrefab)
			{
				return;
			}
			for (int i = 0; i < 20; i++)
			{
				GameObject gameObject = Object.Instantiate(itemPrefab, _theTable.Rows, worldPositionStays: false);
				if ((bool)gameObject)
				{
					PanelItemLeaderboardElement component = gameObject.GetComponent<PanelItemLeaderboardElement>();
					_rows.Add(component);
				}
			}
		}
	}
}
