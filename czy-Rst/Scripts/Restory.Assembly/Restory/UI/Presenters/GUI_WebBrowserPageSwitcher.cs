using System;
using System.Collections.Generic;
using Restory.UI.Views;
using UnityEngine;

namespace Restory.UI.Presenters
{
	public class GUI_WebBrowserPageSwitcher : MonoBehaviour
	{
		[SerializeField]
		private List<GUI_WebBrowserTabView> tabs;

		private GUI_WebBrowserTabView currentTab;

		public GUI_WebBrowserTabView CurrentTab => currentTab;

		public IReadOnlyList<GUI_WebBrowserTabView> Tabs => tabs;

		public event Action<GUI_WebBrowserTabView> OnCurrentTabChanged;

		public void Activate()
		{
			foreach (GUI_WebBrowserTabView tab in tabs)
			{
				if (!currentTab || currentTab == tab)
				{
					currentTab = tab;
					tab.Activate();
				}
				else
				{
					tab.Deactivate();
				}
				tab.OnTabClick += ResolveTabClick;
			}
		}

		public void Deactivate()
		{
			foreach (GUI_WebBrowserTabView tab in tabs)
			{
				tab.OnTabClick -= ResolveTabClick;
			}
			if ((bool)currentTab)
			{
				currentTab.Deactivate();
			}
		}

		public void ResolveTabClick(GUI_WebBrowserTabView clickedTab)
		{
			if (currentTab == clickedTab)
			{
				return;
			}
			foreach (GUI_WebBrowserTabView tab in tabs)
			{
				if (tab == clickedTab)
				{
					tab.Activate();
					currentTab = tab;
					this.OnCurrentTabChanged?.Invoke(currentTab);
				}
				else
				{
					tab.Deactivate();
				}
			}
		}
	}
}
