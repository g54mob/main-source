using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Simulator.Menus
{
	[Serializable]
	public class UI_FramerateOption
	{
		[SerializeField]
		private TMP_Dropdown m_dropdown;

		public void Awake()
		{
			FillDropdown();
		}

		public void OnEnable()
		{
			DropdownSelectCurrentResolution();
			m_dropdown.onValueChanged.AddListener(OnDropDownValueChanged_SetFramerate);
		}

		public void OnDisable()
		{
			m_dropdown.onValueChanged.RemoveListener(OnDropDownValueChanged_SetFramerate);
		}

		private void FillDropdown()
		{
			m_dropdown.ClearOptions();
			List<string> options = (from x in GraphicsApplicationOptions.FramerateOption.GetAvailableFrameRates()
				select x.ToString()).ToList();
			m_dropdown.AddOptions(options);
		}

		private void DropdownSelectCurrentResolution()
		{
			int valueWithoutNotify = m_dropdown.options.FindIndex((TMP_Dropdown.OptionData optionData) => optionData.text == GraphicsApplicationOptions.FramerateOption.Get().ToString());
			m_dropdown.SetValueWithoutNotify(valueWithoutNotify);
		}

		private void OnDropDownValueChanged_SetFramerate(int index)
		{
			if (int.TryParse(m_dropdown.options[index].text, out var result))
			{
				GraphicsApplicationOptions.FramerateOption.Set(result);
			}
			else
			{
				Debug.LogError("FrameRateSettings inputField text parse failed. This should never happened");
			}
		}
	}
}
