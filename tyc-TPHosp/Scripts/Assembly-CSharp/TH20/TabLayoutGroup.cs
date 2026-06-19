using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TH20
{
	public class TabLayoutGroup : MonoBehaviour
	{
		public List<TabItem> TabItems = new List<TabItem>();

		public Action<TabItem> OnTabSelected;

		private TabItem _currentTab;

		private void Start()
		{
			foreach (TabItem tabItem in TabItems)
			{
				tabItem.OwnerTab = this;
			}
		}

		public void AddTab(TabItem tab, bool selectTabOnAdd)
		{
			TabItems.AddUnique(tab);
			tab.OwnerTab = this;
			if (selectTabOnAdd)
			{
				SelectTab(tab);
			}
		}

		public void RemoveTab(TabItem tab)
		{
			if (TabItems.Contains(tab))
			{
				if (_currentTab == tab && _currentTab != null && TabItems.Count > 0)
				{
					SelectTab(TabItems.First());
				}
				TabItems.Remove(tab);
			}
		}

		public void Refresh()
		{
			foreach (TabItem tabItem in TabItems)
			{
				if (tabItem == _currentTab)
				{
					tabItem.Select();
				}
				else
				{
					tabItem.Deselect();
				}
			}
		}

		public void SelectTab(int index)
		{
			SelectTab(TabItems[index]);
		}

		public void SelectTab(TabItem tab)
		{
			if (TabItems.Contains(tab) && !(tab == _currentTab))
			{
				if (_currentTab != null)
				{
					_currentTab.Deselect();
					_currentTab = null;
				}
				if (tab != null)
				{
					_currentTab = tab;
					_currentTab.Select();
					OnTabSelected.InvokeSafe(_currentTab);
				}
			}
		}
	}
}
