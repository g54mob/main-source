using Restory.UserInterface.ElementPresets;
using TMPro;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_DropdownView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Dropdown dropdown;

		[SerializeField]
		private GUI_PresetSwitcher presetSwitcher;

		[SerializeField]
		private PresetName defaultPreset;

		[SerializeField]
		private PresetName expandedPreset;

		private bool isExpanded;

		private void OnEnable()
		{
			isExpanded = false;
			ActivatePreset(defaultPreset);
		}

		private void Update()
		{
			if (isExpanded != dropdown.IsExpanded)
			{
				isExpanded = dropdown.IsExpanded;
				ActivatePreset(isExpanded ? expandedPreset : defaultPreset);
			}
		}

		private void ActivatePreset(PresetName preset)
		{
			if (preset != PresetName.None)
			{
				presetSwitcher.ActivatePreset(preset);
			}
		}
	}
}
