using UnityEngine;

namespace Dorfromantik
{
	public class MainMenuReference : MonoBehaviour
	{
		public void ShowMenuScreen(int index)
		{
			Singleton<MainMenuUi>.Instance.SwitchToScreen(index);
		}

		public void ShowConfirmationScreen(int index)
		{
			Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(index);
		}

		public void ShowCreativeModeConfigOverlay()
		{
			if (Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard)
			{
				Singleton<MainMenuUi>.Instance.SwitchToScreen(MainMenuScreenType.CreativeMode_Configuration);
			}
			else
			{
				Singleton<MainMenuUi>.Instance.SwitchToScreen(MainMenuScreenType.CreativeMode_Configuration_Gamepad);
			}
		}

		public void ShowCustomModeConfigurationScreen()
		{
			Singleton<MainMenuUi>.Instance.SwitchToScreen((Singleton<InputManager>.Instance.CurrentInputDevice == InputDevice.MouseKeyboard) ? MainMenuScreenType.CustomMode_Configuration_Gamepad : MainMenuScreenType.CustomMode_Configuration_Gamepad);
		}

		public void ShowSettingsScreen()
		{
			Singleton<MainMenuUi>.Instance.SwitchToScreen(MainMenuScreenType.Settings);
		}
	}
}
