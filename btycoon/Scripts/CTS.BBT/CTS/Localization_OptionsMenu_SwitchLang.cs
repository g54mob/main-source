using System.Collections.Generic;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class Localization_OptionsMenu_SwitchLang : MonoBehaviour
	{
		public TMP_Dropdown _dropdownButton;

		public Langs _langsScriptable;

		private List<Locale> _langsDisabled = new List<Locale>();

		private List<TMP_Dropdown.OptionData> _newOptions = new List<TMP_Dropdown.OptionData>();

		private TMP_Dropdown.OptionData _optionData = new TMP_Dropdown.OptionData();

		private void Start()
		{
			AddValuesDropdown();
			SetValueDropdown();
		}

		private void AddValuesDropdown()
		{
			_langsDisabled.Clear();
			_langsDisabled = _langsScriptable._langsDisabled;
			foreach (Locale locale in LocalizationSettings.AvailableLocales.Locales)
			{
				foreach (Locale item in _langsDisabled)
				{
					if (item == locale)
					{
						return;
					}
				}
				_dropdownButton.options.Add(new TMP_Dropdown.OptionData(locale.LocaleName, null));
			}
		}

		private void SetValueDropdown(Locale value = null)
		{
			_dropdownButton.value = (value ? value.SortOrder : LocalizationSettings.SelectedLocale.SortOrder);
		}

		public void OnClickSwitchLanguage()
		{
			MonoSingleton<LocalizationManager>.Instance.SwitchLanguage(LocalizationSettings.AvailableLocales.Locales[_dropdownButton.value]);
		}
	}
}
