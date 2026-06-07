using System;
using Data.SaveData;
using Presentation.UI.Menus;
using Presentation.UI.Menus.FullscreenPage;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class SettingsMenu : GamecontrolMenu
	{
		[SerializeField]
		private Button _backButton;

		[SerializeField]
		private Button _resetButton;

		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private GameObject[] _tabs;

		[SerializeField]
		private PageButton[] _tabButtons;

		[SerializeField]
		private GlobalPersistentManager _globalPersistentManager;

		private int _currentTabIndex;

		public event Action<bool> SelectedBackButton;

		protected override void Awake()
		{
			base.Awake();
			_currentTabIndex = 0;
			for (int i = 0; i < _tabs.Length; i++)
			{
				int iD = i;
				_tabs[i].SetActive(value: false);
				_tabButtons[i].ID = iD;
				_tabButtons[i].ActiveState = false;
				PageButton obj = _tabButtons[i];
				obj.OnClick = (Action<int>)Delegate.Combine(obj.OnClick, new Action<int>(OpenSettingsTab));
			}
			_tabs[_currentTabIndex].SetActive(value: true);
			_tabButtons[_currentTabIndex].ActiveState = true;
			_scrollRect.content = (RectTransform)_tabs[_currentTabIndex].transform;
			_backButton?.onClick.AddListener(base.GoBack);
			_resetButton.onClick.AddListener(ResetButtonClicked);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			for (int i = 0; i < _tabs.Length; i++)
			{
				PageButton obj = _tabButtons[i];
				obj.OnClick = (Action<int>)Delegate.Remove(obj.OnClick, new Action<int>(OpenSettingsTab));
			}
			_backButton?.onClick.RemoveListener(base.GoBack);
			_resetButton.onClick.RemoveListener(ResetButtonClicked);
		}

		private void OnDisable()
		{
			_globalPersistentManager.SaveGlobalPersistentSOs();
		}

		private void ResetButtonClicked()
		{
			_globalPersistentManager.ResetToDefaults();
		}

		private void OpenSettingsTab(int tabIndex)
		{
			_tabs[_currentTabIndex].SetActive(value: false);
			_tabButtons[_currentTabIndex].ActiveState = false;
			_currentTabIndex = tabIndex;
			_tabs[tabIndex].SetActive(value: true);
			_tabButtons[tabIndex].ActiveState = true;
			_scrollRect.content = (RectTransform)_tabs[tabIndex].transform;
			_scrollRect.normalizedPosition = Vector2.one;
		}
	}
}
