using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[Constructor("Construct")]
	public class SettingsInterface : CTSSingleton<SettingsInterface>
	{
		[SerializeField]
		[Inject(false)]
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		private List<SettingTabData> _tabsToGenerate;

		[SerializeField]
		private Transform _tabButtonsParent;

		[SerializeField]
		private SettingTabToggle _tabButtonPrefab;

		[SerializeField]
		private Transform _tabParent;

		[SerializeField]
		private SettingTab _tabPrefab;

		private readonly Dictionary<StringKey<SettingTabData>, SettingTab> _tabs = new Dictionary<StringKey<SettingTabData>, SettingTab>();

		private SettingTab _currentTab;

		private void Construct()
		{
			bool flag = true;
			foreach (SettingTabData item in _tabsToGenerate)
			{
				if (!_tabs.ContainsKey(item) && (item.RestrictedCountry.Count <= 0 || !item.RestrictedCountry.Contains(CountryManager.GetPlayerCountry())))
				{
					SettingTabToggle settingTabToggle = CTSFactory.Instantiate(_tabButtonPrefab, _tabButtonsParent);
					settingTabToggle.Initialize(item);
					SettingTab settingTab = CTSFactory.Instantiate(_tabPrefab, _tabParent, instantiateInWorldSpace: false, false);
					settingTab.Initialize(item);
					settingTab.transform.Cast<RectTransform>().anchoredPosition = Vector2.zero;
					_tabs[item] = settingTab;
					settingTabToggle.gameObject.SetActive(value: true);
					if (flag)
					{
						flag = false;
						settingTabToggle.GetComponent<Toggle>().isOn = true;
						_currentTab = settingTab;
						settingTab.gameObject.SetActive(value: true);
					}
				}
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void Open()
		{
			_canvasGroupController.QuickShow();
		}

		public void Close()
		{
			_canvasGroupController.QuickHide();
		}

		public void SwitchToTab(StringKey<SettingTabData> tabKey)
		{
			if (!_tabs.TryGetValue(tabKey, out var value))
			{
				throw new NullReferenceException("No tab for key " + tabKey.ToString());
			}
			if (!(_currentTab == value))
			{
				if ((bool)_currentTab)
				{
					_currentTab.gameObject.SetActive(value: false);
				}
				_currentTab = value;
				_currentTab.gameObject.SetActive(value: true);
			}
		}

		public void ResetCurrentTab()
		{
			if ((bool)_currentTab)
			{
				_currentTab.ResetAll();
			}
		}
	}
}
