using System.Collections.Generic;
using UnityEngine;

namespace TH20.UI
{
	public class AwardsTabTrophyPanel : OverviewMenuTabPanel
	{
		private Dictionary<HospitalAwardsManager.AwardType, PanelItemTrophyItem> _trophyLookup = new Dictionary<HospitalAwardsManager.AwardType, PanelItemTrophyItem>();

		private PanelItemTrophyItem[] _thePanelItemTrophyItems;

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			_thePanelItemTrophyItems = GetComponentsInChildren<PanelItemTrophyItem>(includeInactive: true);
			PanelItemTrophyItem[] thePanelItemTrophyItems = _thePanelItemTrophyItems;
			foreach (PanelItemTrophyItem panelItemTrophyItem in thePanelItemTrophyItems)
			{
				_trophyLookup.Add(panelItemTrophyItem.theAwardType, panelItemTrophyItem);
			}
		}

		protected override void Update()
		{
			base.Update();
			if (_thePanelItemTrophyItems != null)
			{
				PanelItemTrophyItem[] thePanelItemTrophyItems = _thePanelItemTrophyItems;
				for (int i = 0; i < thePanelItemTrophyItems.Length; i++)
				{
					thePanelItemTrophyItems[i].Process();
				}
			}
		}

		public Vector2 GetTrophySpotFocus(int index)
		{
			if (index < _thePanelItemTrophyItems.Length && _thePanelItemTrophyItems[index] != null)
			{
				return _thePanelItemTrophyItems[index].SpotFocus;
			}
			return Vector2.zero;
		}

		public PanelItemTrophyItem GetTrophy(HospitalAwardsManager.AwardType type)
		{
			return _trophyLookup[type];
		}
	}
}
