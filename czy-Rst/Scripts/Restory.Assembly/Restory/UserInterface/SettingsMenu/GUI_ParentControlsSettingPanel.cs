using UnityEngine;
using UnityEngine.Events;

namespace Restory.UserInterface.SettingsMenu
{
	public abstract class GUI_ParentControlsSettingPanel : GUI_BaseSettingPanel
	{
		private GUI_ChildControlsSettingPanel currentChildPanel;

		[SerializeField]
		private BaseSettingEvent currentPanelChanged;

		public GUI_ChildControlsSettingPanel CurrentPanel => currentChildPanel;

		public event UnityAction<GUI_BaseSettingPanel> CurrentPanelChanged
		{
			add
			{
				currentPanelChanged.AddListener(value);
			}
			remove
			{
				currentPanelChanged.RemoveListener(value);
			}
		}

		protected void SetCurrentPanel(GUI_ChildControlsSettingPanel panel)
		{
			if (currentChildPanel != null)
			{
				currentChildPanel.OnBack.RemoveListener(ResolveCurrentPanelOnBack);
				currentChildPanel.HasChanged -= ResolveCurrentPanelHasChanged;
				currentChildPanel.IsDefaultValuesChanged -= ResolveCurrentPanelIsDefaultValuesChanged;
				currentChildPanel.Hide();
			}
			currentChildPanel = panel;
			panelContent.gameObject.SetActive(currentChildPanel == null);
			if (currentChildPanel != null)
			{
				currentChildPanel.OnBack.AddListener(ResolveCurrentPanelOnBack);
				currentChildPanel.HasChanged += ResolveCurrentPanelHasChanged;
				currentChildPanel.IsDefaultValuesChanged += ResolveCurrentPanelIsDefaultValuesChanged;
				currentChildPanel.Show();
				SetIsDefaultValues(panel.IsDefaultValues);
				SetHasChange(panel.HasChanges);
			}
			else
			{
				Load();
			}
			currentPanelChanged?.Invoke(currentChildPanel);
		}

		private void ResolveCurrentPanelOnBack(GUI_BaseSettingPanel panel)
		{
			if (!panel.HasChanges)
			{
				SetCurrentPanel(null);
				return;
			}
			panel.ConfirmApply(delegate
			{
				SetCurrentPanel(null);
			});
		}

		private void ResolveCurrentPanelIsDefaultValuesChanged(GUI_BaseSettingPanel panel)
		{
			SetIsDefaultValues(panel.IsDefaultValues);
		}

		private void ResolveCurrentPanelHasChanged(GUI_BaseSettingPanel panel)
		{
			SetHasChange(panel.HasChanges);
		}
	}
}
