using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Simulator.Menus
{
	[Serializable]
	public class UI_ResolutionOption
	{
		[SerializeField]
		private TMP_Dropdown m_dropdown;

		public void OnEnable()
		{
			FillResolutionDropDown();
			DropdownSelectCurrentResolution();
			m_dropdown.onValueChanged.AddListener(OnDropdownValueChanged_Apply);
		}

		public void OnDisable()
		{
			m_dropdown.onValueChanged.RemoveListener(OnDropdownValueChanged_Apply);
		}

		private void OnDropdownValueChanged_Apply(int index)
		{
			Apply();
		}

		private void FillResolutionDropDown()
		{
			m_dropdown.ClearOptions();
			List<string> options = Screen.resolutions.Select((Resolution resolution) => $"{resolution.width} x {resolution.height}").Distinct().Reverse()
				.ToList();
			m_dropdown.AddOptions(options);
		}

		private void DropdownSelectCurrentResolution()
		{
			int valueWithoutNotify = m_dropdown.options.FindIndex((TMP_Dropdown.OptionData optionData) => optionData.text == GetCurrentResolutionName());
			m_dropdown.SetValueWithoutNotify(valueWithoutNotify);
		}

		private void Apply()
		{
			Resolution resolution = ExtractResolutionFromOption(m_dropdown.options[m_dropdown.value]);
			Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
		}

		private Resolution ExtractResolutionFromOption(TMP_Dropdown.OptionData optionData)
		{
			string[] array = optionData.text.Split('x', StringSplitOptions.RemoveEmptyEntries);
			return new Resolution
			{
				width = int.Parse(array[0]),
				height = int.Parse(array[1])
			};
		}

		private string GetCurrentResolutionName()
		{
			return $"{Screen.width} x {Screen.height}";
		}
	}
}
