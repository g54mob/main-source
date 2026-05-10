using CTS.Core;
using CTS.ScriptableSettings;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class UILocaleToggle : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Toggle _toggle;

		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private TMP_Text _nameText;

		[SerializeField]
		private LocaleIdentifier _locale;

		[SerializeField]
		private SettingObject<LocaleIdentifier> _setting;

		[SerializeField]
		private LocalizedString _localeName;

		public void Initialize(LocaleIdentifier locale, SettingObject<LocaleIdentifier> settingObject, LocalizedString localeName)
		{
			_locale = locale;
			_setting = settingObject;
			_localeName = localeName;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			ToggleGroup componentInParent = GetComponentInParent<ToggleGroup>();
			if ((bool)componentInParent)
			{
				_toggle.group = componentInParent;
			}
			_toggle.onValueChanged.AddListener(OnToggleChanged);
			LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
			OnLocaleChanged(null);
			if (_setting.GetValue() == _locale)
			{
				_toggle.isOn = true;
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.onValueChanged.RemoveListener(OnToggleChanged);
			LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
		}

		private void OnLocaleChanged(Locale obj)
		{
			_nameText.text = _localeName.GetLocalizedStringSafe();
			if ((object)obj != null && obj.Identifier == _locale)
			{
				_toggle.isOn = true;
			}
		}

		private void OnToggleChanged(bool isOn)
		{
			if (isOn)
			{
				_setting.SetValue(_locale);
			}
		}
	}
}
