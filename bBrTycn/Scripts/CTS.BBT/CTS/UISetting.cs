using CTS.Core;
using CTS.ScriptableSettings;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public abstract class UISetting : CTSBehaviour
	{
		[SerializeField]
		private TMP_Text _settingName;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			LocalizationSettings.SelectedLocaleChanged += OnLocaledChanged;
			OnLocaledChanged(null);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			LocalizationSettings.SelectedLocaleChanged -= OnLocaledChanged;
		}

		private void OnLocaledChanged(Locale obj)
		{
			UpdateName();
		}

		public abstract void ResetSetting();

		public void UpdateName()
		{
			if ((bool)_settingName)
			{
				_settingName.text = GetName();
			}
		}

		protected abstract string GetName();
	}
	public abstract class UISetting<T> : UISetting
	{
		[SerializeField]
		protected SettingObject<T> _setting;

		[SerializeField]
		protected LocalizedString _localizedString;

		[SerializeField]
		private bool _initOnAwake;

		protected override void OnAwake()
		{
			base.OnAwake();
			if (_initOnAwake)
			{
				Initialize(_setting, _localizedString);
			}
		}

		public virtual void Initialize(SettingObject<T> settingObject, LocalizedString localizedString)
		{
			_setting = settingObject;
			_localizedString = localizedString;
		}

		public override void ResetSetting()
		{
			_setting.ResetValue();
		}

		protected override string GetName()
		{
			return _localizedString.GetLocalizedStringSafe();
		}
	}
}
