using Restory.Infrastructure.CommonServices;
using Restory.UserInterface.ElementPresets;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.SettingsMenu
{
	[RequireComponent(typeof(GUI_ElementPresetSwitcher))]
	public sealed class GUI_SettingsPanelButtonsSwitcher : MonoBehaviour
	{
		[SerializeField]
		private PresetName keyBoardAndMouseKey = PresetName.Keyboard;

		[SerializeField]
		private PresetName joystickKey = PresetName.Gamepad;

		[SerializeField]
		private GUI_ElementPresetSwitcher presetSwitcher;

		private ControlsManager controlsManager;

		[Inject]
		private void Construct(ControlsManager controlsManager)
		{
			this.controlsManager = controlsManager;
			if (base.isActiveAndEnabled)
			{
				this.controlsManager.OnControlsTypeChanged += ControlsManager_OnControlsTypeChanged;
				ControlsManager_OnControlsTypeChanged(this.controlsManager.ControlType);
			}
		}

		private void OnEnable()
		{
			if (controlsManager != null)
			{
				controlsManager.OnControlsTypeChanged += ControlsManager_OnControlsTypeChanged;
				ControlsManager_OnControlsTypeChanged(controlsManager.ControlType);
			}
		}

		private void OnDisable()
		{
			if (controlsManager != null)
			{
				controlsManager.OnControlsTypeChanged -= ControlsManager_OnControlsTypeChanged;
			}
		}

		private void ControlsManager_OnControlsTypeChanged(InputControlsType type)
		{
			switch (type)
			{
			case InputControlsType.Joystick:
				presetSwitcher.ActivatePreset(joystickKey);
				break;
			default:
				presetSwitcher.ActivatePreset(keyBoardAndMouseKey);
				break;
			}
		}
	}
}
