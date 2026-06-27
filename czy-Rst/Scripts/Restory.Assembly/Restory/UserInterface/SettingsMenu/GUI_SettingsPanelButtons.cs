using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_SettingsPanelButtons : MonoBehaviour
	{
		[SerializeField]
		private GUI_BaseSettingPanel settingPanel;

		[SerializeField]
		private GUI_Button applyButton;

		[SerializeField]
		private GUI_Button defaultButton;

		private void OnEnable()
		{
			settingPanel.HasChanged += ResolveSettingPanelHasChanged;
			settingPanel.IsDefaultValuesChanged += ResolveSettingPanelIsDefaultValuesChanged;
			defaultButton.OnClick += ResolveDefaultButtonOnClick;
			applyButton.OnClick += ResolveApplyButtonOnClick;
		}

		private void OnDisable()
		{
			settingPanel.HasChanged -= ResolveSettingPanelHasChanged;
			settingPanel.IsDefaultValuesChanged -= ResolveSettingPanelIsDefaultValuesChanged;
			defaultButton.OnClick -= ResolveDefaultButtonOnClick;
			applyButton.OnClick -= ResolveApplyButtonOnClick;
		}

		private void ResolveApplyButtonOnClick()
		{
			settingPanel.Apply();
		}

		private void ResolveDefaultButtonOnClick()
		{
			settingPanel.ConfirmSetDefault();
		}

		private void ResolveSettingPanelHasChanged(GUI_BaseSettingPanel panel)
		{
			applyButton.Interactable = settingPanel.HasChanges;
		}

		private void ResolveSettingPanelIsDefaultValuesChanged(GUI_BaseSettingPanel panel)
		{
			defaultButton.Interactable = !settingPanel.IsDefaultValues;
		}
	}
}
