using System.Collections.Generic;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class SettingTab : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Transform _settingsParent;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private SettingTabData _tabData;

		private readonly List<UISetting> _settings = new List<UISetting>();

		private bool _initialized;

		protected override void OnAwake()
		{
			base.OnAwake();
			Initialize(_tabData);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
			OnLocaleChanged(null);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
		}

		public void Initialize(SettingTabData tabData)
		{
			if (_initialized)
			{
				return;
			}
			_initialized = true;
			_tabData = tabData;
			foreach (SettingCreator setting in _tabData.Settings)
			{
				_settings.Add(setting.Spawn(_settingsParent));
			}
		}

		public void ResetAll()
		{
			foreach (UISetting setting in _settings)
			{
				setting.ResetSetting();
			}
		}

		private void OnLocaleChanged(Locale obj)
		{
			_titleText.text = _tabData.Title.GetLocalizedStringSafe();
		}
	}
}
