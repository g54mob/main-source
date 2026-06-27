using Restory.UserInterface.ElementPresets;
using UnityEngine;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_SettingsPanelActionButtons : MonoBehaviour
	{
		[SerializeField]
		private GUI_BaseSettingPanel settingPanel;

		[SerializeField]
		private GUI_ElementPresetSwitcher applyPresetSwitcher;

		[SerializeField]
		private GUI_ElementPresetSwitcher defaultPresetSwitcher;

		[SerializeField]
		private PresetName defaultPreset = PresetName.Normal;

		[SerializeField]
		private PresetName inactivePreset = PresetName.Disabled;

		private void OnEnable()
		{
			settingPanel.HasChanged += ResolveSettingPanelHasChanged;
			settingPanel.IsDefaultValuesChanged += ResolveSettingPanelIsDefaultValuesChanged;
			ResolveSettingPanelHasChanged(settingPanel);
			ResolveSettingPanelIsDefaultValuesChanged(settingPanel);
		}

		private void OnDisable()
		{
			settingPanel.HasChanged -= ResolveSettingPanelHasChanged;
			settingPanel.IsDefaultValuesChanged -= ResolveSettingPanelIsDefaultValuesChanged;
		}

		private void ResolveSettingPanelHasChanged(GUI_BaseSettingPanel panel)
		{
			applyPresetSwitcher.ActivatePreset(settingPanel.HasChanges ? defaultPreset : inactivePreset);
		}

		private void ResolveSettingPanelIsDefaultValuesChanged(GUI_BaseSettingPanel panel)
		{
			defaultPresetSwitcher.ActivatePreset((!settingPanel.IsDefaultValues) ? defaultPreset : inactivePreset);
		}
	}
}
