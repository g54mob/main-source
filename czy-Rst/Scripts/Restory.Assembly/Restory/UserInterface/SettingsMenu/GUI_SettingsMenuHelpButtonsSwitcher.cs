using Restory.UserInterface.HelpActions;
using UnityEngine;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_SettingsMenuHelpButtonsSwitcher : MonoBehaviour
	{
		[SerializeField]
		private GUI_SettingsMenu settingsMenu;

		[SerializeField]
		private HelpActionButtonsHolder helpActionButtonsHolder;

		[SerializeField]
		private HelpAction closeHelpButton;

		private void OnEnable()
		{
			settingsMenu.ControlSettingPanel.CurrentPanelChanged += ResolveCurrentPanelChanged;
			settingsMenu.GameplaySettingPanel.CurrentPanelChanged += ResolveCurrentPanelChanged;
			UpdateButtons();
		}

		private void OnDisable()
		{
			settingsMenu.ControlSettingPanel.CurrentPanelChanged -= ResolveCurrentPanelChanged;
			settingsMenu.GameplaySettingPanel.CurrentPanelChanged -= ResolveCurrentPanelChanged;
			helpActionButtonsHolder.Remove(closeHelpButton);
		}

		private void UpdateButtons()
		{
			if (settingsMenu.ControlSettingPanel.CurrentPanel != null || settingsMenu.GameplaySettingPanel.CurrentPanel != null)
			{
				helpActionButtonsHolder.Remove(closeHelpButton);
			}
			else
			{
				helpActionButtonsHolder.Add(closeHelpButton);
			}
		}

		private void ResolveCurrentPanelChanged(GUI_BaseSettingPanel panel)
		{
			UpdateButtons();
		}
	}
}
