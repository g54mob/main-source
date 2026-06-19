using I2.Loc;
using InControl;
using TMPro;
using UnityEngine;

public class CommandMappingOption : MonoBehaviour
{
	public ControlCommand command;

	public GameObject singleMappingObject;

	public GameObject toggleMappingObject;

	public TextMeshProUGUI commandLabel;

	public TextMeshProUGUI mouseBindingLabel;

	public TextMeshProUGUI keyboardBindingLabel;

	public TextMeshProUGUI gamepadBindingLabel;

	public TextMeshProUGUI toggleCommandLabel_A;

	public TextMeshProUGUI toggleBindingLabel_A;

	public TextMeshProUGUI toggleCommandLabel_B;

	public TextMeshProUGUI toggleBindingLabel_B;

	public GameObject mouseBindingBox;

	public GameObject keyboardBindingBox;

	public GameObject gamepadBindingBox;

	public GameObject resetButtonRef;

	public GameObject resetToggleButtonRef;

	private bool isMouseKeyboard = true;

	private bool isToggle;

	private bool isEmpty;

	private CursorUpdateArea updateAreaRef;

	private ControlManager controlManagerRef;

	private ControlsMenuController controlsGUIRef;

	public void SetGUIRef(ControlsMenuController newRef, CursorUpdateArea areaRef)
	{
		controlsGUIRef = newRef;
		updateAreaRef = areaRef;
	}

	public void OnCursorStay()
	{
		updateAreaRef.ReportCursorOverContent();
	}

	public void SetToggleCommandType()
	{
		isToggle = true;
		isMouseKeyboard = false;
		controlManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER);
		singleMappingObject.SetActive(value: false);
		toggleMappingObject.SetActive(value: true);
		toggleCommandLabel_A.text = ScriptLocalization.GUI.GUI_CONTROLS_CURSORMOV;
		toggleCommandLabel_B.text = ScriptLocalization.GUI.GUI_CONTROLS_CAMMOV;
		if (GameControls.isLeftStickDefault)
		{
			toggleBindingLabel_A.text = ScriptLocalization.GUI.GUI_CONTROLS_LEFTSTICK;
			toggleBindingLabel_B.text = ScriptLocalization.GUI.GUI_CONTROLS_RIGHTSTICK;
		}
		else
		{
			toggleBindingLabel_A.text = ScriptLocalization.GUI.GUI_CONTROLS_RIGHTSTICK;
			toggleBindingLabel_B.text = ScriptLocalization.GUI.GUI_CONTROLS_LEFTSTICK;
		}
		RefreshDefaultButton();
	}

	public void SetEmpty()
	{
		isEmpty = true;
		singleMappingObject.SetActive(value: false);
		toggleMappingObject.SetActive(value: false);
	}

	public void SetCommandType(ControlCommand newType, bool mouseKeyboard)
	{
		isToggle = false;
		isMouseKeyboard = mouseKeyboard;
		controlManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER);
		singleMappingObject.SetActive(value: true);
		toggleMappingObject.SetActive(value: false);
		command = newType;
		commandLabel.text = ControlManager.ControlCommandToLocalizedString(command);
		mouseBindingBox.SetActive(mouseKeyboard);
		keyboardBindingBox.SetActive(mouseKeyboard);
		gamepadBindingBox.SetActive(!mouseKeyboard);
		if (mouseKeyboard)
		{
			mouseBindingLabel.text = controlManagerRef.GetCurrentMouseBindingForCommand(command);
			keyboardBindingLabel.text = controlManagerRef.GetCurrentKeyboardBindingForCommand(command);
		}
		else
		{
			gamepadBindingLabel.text = controlManagerRef.GetCurrentGamepadBindingForCommand(command);
		}
		RefreshDefaultButton();
	}

	public void OnToggleBindingPressed()
	{
		controlManagerRef.SwapSticks();
		Refresh();
	}

	public void OnMouseBindingBoxPressed()
	{
		if (command == ControlCommand.INTERACT)
		{
			controlsGUIRef.ShowInteractRemappingPopup();
		}
		else
		{
			controlsGUIRef.OpenRemappingPopup(command, ControlType.MOUSE);
		}
	}

	public void OnKeyboardBindingBoxPressed()
	{
		controlsGUIRef.OpenRemappingPopup(command, ControlType.KEYBOARD);
	}

	public void OnGamepadBindingBoxPressed()
	{
		controlsGUIRef.OpenRemappingPopup(command, ControlType.GAMEPAD);
	}

	public void ResetToDefault()
	{
		if (!isEmpty)
		{
			if (isToggle)
			{
				controlManagerRef.ResetStickToggle();
			}
			else if (isMouseKeyboard)
			{
				controlManagerRef.ResetBinding(command, BindingSourceType.KeyBindingSource);
				controlManagerRef.ResetBinding(command, BindingSourceType.MouseBindingSource);
			}
			else
			{
				controlManagerRef.ResetBinding(command, BindingSourceType.DeviceBindingSource);
			}
			Refresh();
		}
	}

	public void Refresh()
	{
		if (!isEmpty)
		{
			if (isToggle)
			{
				SetToggleCommandType();
			}
			else
			{
				SetCommandType(command, isMouseKeyboard);
			}
		}
	}

	public void ReportBindingCleared(ControlType controlType)
	{
		switch (controlType)
		{
		case ControlType.MOUSE:
			mouseBindingLabel.text = "";
			break;
		case ControlType.KEYBOARD:
			keyboardBindingLabel.text = "";
			break;
		case ControlType.GAMEPAD:
			gamepadBindingLabel.text = "";
			break;
		}
	}

	private void RefreshDefaultButton()
	{
		if (!isEmpty)
		{
			if (isToggle)
			{
				resetToggleButtonRef.SetActive(!GameControls.isLeftStickDefault);
			}
			if (isMouseKeyboard)
			{
				resetButtonRef.SetActive(!controlManagerRef.IsCommandSetToDefaultMouseKeyboardBindings(command));
			}
			else
			{
				resetButtonRef.SetActive(!controlManagerRef.IsCommandSetToDefaultGamepadBindings(command));
			}
		}
	}
}
