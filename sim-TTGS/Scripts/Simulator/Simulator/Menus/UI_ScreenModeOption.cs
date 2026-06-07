using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Simulator.Menus
{
	[Serializable]
	public class UI_ScreenModeOption
	{
		[SerializeField]
		private TabletopDropdown m_dropdown;

		private const FullScreenMode FilteredFullScreenMode = FullScreenMode.MaximizedWindow;

		public void Awake()
		{
			FillResolutionDropDown();
		}

		public void OnEnable()
		{
			DropdownSelectCurrentResolution();
			m_dropdown.onValueChanged.AddListener(OnDropdownValueChanged_Apply);
		}

		public void OnDisable()
		{
			m_dropdown.onValueChanged.RemoveListener(OnDropdownValueChanged_Apply);
		}

		private void FillResolutionDropDown()
		{
			m_dropdown.ClearOptions();
			m_dropdown.AddOptions(GetFullScreenModeNamesFiltered());
		}

		private void DropdownSelectCurrentResolution()
		{
			m_dropdown.SetValueWithoutNotify((int)Screen.fullScreenMode);
		}

		private void OnDropdownValueChanged_Apply(int index)
		{
			FullScreenMode fullScreenModeFromValueFiltered = GetFullScreenModeFromValueFiltered(index);
			Apply(fullScreenModeFromValueFiltered);
		}

		private void Apply(FullScreenMode fullscreenMode)
		{
			Screen.fullScreenMode = fullscreenMode;
		}

		private List<string> GetFullScreenModeNamesFiltered()
		{
			string filteredName = FullScreenMode.MaximizedWindow.ToString();
			return (from name in Enum.GetNames(typeof(FullScreenMode))
				where name != filteredName
				select name).ToList();
		}

		private FullScreenMode GetFullScreenModeFromValueFiltered(int value)
		{
			if (value >= 2)
			{
				value++;
			}
			return (FullScreenMode)Enum.ToObject(typeof(FullScreenMode), value);
		}
	}
}
