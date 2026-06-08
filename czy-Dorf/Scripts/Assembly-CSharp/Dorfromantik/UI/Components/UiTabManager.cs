using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik.UI.Components
{
	public class UiTabManager : MonoBehaviour
	{
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			public GameMode currentGameMode;

			public Func<UiTab, bool> _003C_003E9__0;

			internal bool _003CGetCurrentActiveTab_003Eb__0(UiTab x)
			{
				if (x.assignedGameMode == currentGameMode)
				{
					return x.assignedGameMode != null;
				}
				return false;
			}
		}

		[SerializeField]
		private bool shouldAlternateTabs = true;

		[SerializeField]
		private bool isGameModeDepended;

		[SerializeField]
		private SaveFileManager saveFileManager;

		[SerializeField]
		private List<UiTab> tabs = new List<UiTab>();

		[SerializeField]
		private List<UiTab> defaultActiveTabs = new List<UiTab>();

		[SerializeField]
		private UiTab currentActiveTab;

		private void Start()
		{
			InitializeTabs(isInitializingOnRuntime: true);
		}

		private void OnValidate()
		{
			InitializeTabs();
		}

		private void OnDestroy()
		{
			foreach (UiTab tab in tabs)
			{
				tab.OnSetActive -= RememberNewActiveTab;
			}
		}

		public void OnEnable()
		{
			if (!(OverwritingSingleton<GameSession>.Instance == null))
			{
				GetCurrentActiveTab().SetVisualStateActivated(shouldSetActivated: true);
			}
		}

		internal void RememberNewActiveTab(UiTab activeUiTab)
		{
			if (!(activeUiTab == currentActiveTab))
			{
				if ((bool)currentActiveTab)
				{
					currentActiveTab.SetVisualStateActivated(shouldSetActivated: false);
				}
				currentActiveTab = activeUiTab;
			}
		}

		public void GamepadInputNavigateLeft()
		{
			int num = tabs.IndexOf(currentActiveTab);
			tabs[(num - 1 + tabs.Count) % tabs.Count].Submit();
		}

		public void GamepadInputNavigateRight()
		{
			int num = tabs.IndexOf(currentActiveTab);
			tabs[(num + 1) % tabs.Count].Submit();
		}

		public void SwitchToTab(UiTab targetTab)
		{
			RememberNewActiveTab(targetTab);
			currentActiveTab.Submit();
		}

		private void InitializeTabs(bool isInitializingOnRuntime = false)
		{
			tabs.Clear();
			tabs = Enumerable.ToList(GetComponentsInChildren<UiTab>());
			defaultActiveTabs.Clear();
			int num = 0;
			foreach (UiTab tab in tabs)
			{
				if (isInitializingOnRuntime)
				{
					tab.OnSetActive += RememberNewActiveTab;
				}
				if (shouldAlternateTabs)
				{
					tab.isVisualAlternate = num % 2 == 0;
				}
				if (tab.isDefaultActiveTab)
				{
					defaultActiveTabs.Add(tab);
				}
				num++;
			}
			if (isInitializingOnRuntime)
			{
				currentActiveTab = GetCurrentActiveTab();
				currentActiveTab.SetVisualStateActivated(shouldSetActivated: true, shouldIgnoreCurrentState: true);
			}
		}

		private UiTab GetCurrentActiveTab()
		{
			UiTab uiTab = null;
			if (isGameModeDepended)
			{
				_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass15_0();
				CS_0024_003C_003E8__locals2.currentGameMode = ((OverwritingSingleton<GameSession>.Instance != null) ? OverwritingSingleton<GameSession>.Instance.GameMode : saveFileManager.GameModeById((GameModeId)PlayerPrefsAccessor.GetInt("LastPlayedGameMode", 1)));
				foreach (UiTab item in Enumerable.Where(tabs, (UiTab x) => x.assignedGameMode == CS_0024_003C_003E8__locals2.currentGameMode && x.assignedGameMode != null))
				{
					uiTab = item;
				}
			}
			if (uiTab == null)
			{
				uiTab = ((defaultActiveTabs.Count > 0) ? defaultActiveTabs[0] : Enumerable.First(tabs));
			}
			return uiTab;
		}
	}
}
