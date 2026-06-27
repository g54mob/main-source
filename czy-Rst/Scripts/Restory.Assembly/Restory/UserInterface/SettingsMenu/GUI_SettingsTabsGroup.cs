using Restory.UserInterface.GameplayMenu;
using UnityEngine;

namespace Restory.UserInterface.SettingsMenu
{
	public class GUI_SettingsTabsGroup : GUI_TabsGroupBase<GUI_Tab>
	{
		[SerializeField]
		private GUI_SettingsMenu settingsMenu;

		private void OnEnable()
		{
			SubscribeClicksOnTabs();
		}

		private void OnDisable()
		{
			UnsubscribeClicksOnTabs();
		}

		public void OnTabClicked(GUI_Tab clickedTab)
		{
			settingsMenu.CheckHasChangesAndInvoke(delegate
			{
				ActiveTab = clickedTab;
			});
		}

		public void SubscribeClicksOnTabs()
		{
			foreach (GUI_Tab tabs in tabsList)
			{
				tabs.OnClicked.AddListener(OnTabClicked);
			}
		}

		public void UnsubscribeClicksOnTabs()
		{
			foreach (GUI_Tab tabs in tabsList)
			{
				tabs.OnClicked.RemoveListener(OnTabClicked);
			}
		}

		public override void SetCurrentTab(int targetTabID = 0)
		{
			settingsMenu.CheckHasChangesAndInvoke(delegate
			{
				base.SetCurrentTab(targetTabID);
			});
		}

		public override void NextTab(int currentTabID = -1)
		{
			settingsMenu.CheckHasChangesAndInvoke(delegate
			{
				base.NextTab(currentTabID);
			});
		}

		public override void PreviousTab()
		{
			settingsMenu.CheckHasChangesAndInvoke(delegate
			{
				base.PreviousTab();
			});
		}
	}
}
