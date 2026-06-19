using System.Collections.Generic;
using UnityEngine;

namespace TH20.UI
{
	public class OverviewMenuTab : MonoBehaviour
	{
		protected LevelStatsDatabase _levelStatsDatabase;

		protected OverviewMenu.Mode _theMode;

		protected List<OverviewMenuTabPanel> _overviewMenuTabPanels = new List<OverviewMenuTabPanel>();

		public OverviewMenu TheOverviewMenu { get; private set; }

		public OverviewMenu.Mode TheMode
		{
			get
			{
				return _theMode;
			}
			set
			{
				_theMode = value;
			}
		}

		public virtual void Setup(OverviewMenu theOverviewRoot, OverviewMenu.Mode theMode)
		{
			TheOverviewMenu = theOverviewRoot;
			TheMode = theMode;
			_levelStatsDatabase = theOverviewRoot.TheLevel.LevelStatsDatabase;
			OverviewMenuTabPanel[] componentsInChildren = GetComponentsInChildren<OverviewMenuTabPanel>(includeInactive: true);
			foreach (OverviewMenuTabPanel overviewMenuTabPanel in componentsInChildren)
			{
				_overviewMenuTabPanels.Add(overviewMenuTabPanel);
				overviewMenuTabPanel.Setup(this);
			}
		}

		public virtual void Activate(bool state)
		{
		}
	}
}
