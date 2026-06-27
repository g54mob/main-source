using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_ChildControlsSettingPanelBackButton : MonoBehaviour
	{
		[SerializeField]
		private GUI_ChildControlsSettingPanel settingPanel;

		[SerializeField]
		private GUI_Button backButton;

		private void OnEnable()
		{
			backButton.OnClick += ResolveBackButtonOnClick;
		}

		private void OnDisable()
		{
			backButton.OnClick -= ResolveBackButtonOnClick;
		}

		private void ResolveBackButtonOnClick()
		{
			settingPanel.Back();
		}
	}
}
