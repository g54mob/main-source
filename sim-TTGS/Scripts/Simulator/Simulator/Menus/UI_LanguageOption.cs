using System;
using Dhs5.Utility.Settings;
using I2.Loc;
using TMPro;
using UnityEngine;

namespace Simulator.Menus
{
	[Serializable]
	public class UI_LanguageOption
	{
		[SerializeField]
		private TMP_Dropdown m_dropdown;

		public void Awake()
		{
			FillDropdown();
		}

		public void OnEnable()
		{
			DropdownSelectCurrentLanguage();
			m_dropdown.onValueChanged.AddListener(OnDropdownValueChange);
		}

		public void OnDisable()
		{
			m_dropdown.onValueChanged.RemoveListener(OnDropdownValueChange);
		}

		private void FillDropdown()
		{
			m_dropdown.ClearOptions();
			m_dropdown.AddOptions(LocalizationManager.GetAllLanguages());
		}

		private void DropdownSelectCurrentLanguage()
		{
			int valueWithoutNotify = m_dropdown.options.FindIndex((TMP_Dropdown.OptionData x) => x.text == LocalizationManager.CurrentLanguage);
			m_dropdown.SetValueWithoutNotify(valueWithoutNotify);
		}

		private void OnDropdownValueChange(int index)
		{
			SetLanguage(m_dropdown.options[index].text);
		}

		private void SetLanguage(string language)
		{
			CustomSettings<GameplayApplicationOptions>.I.SetLanguage(language);
		}
	}
}
