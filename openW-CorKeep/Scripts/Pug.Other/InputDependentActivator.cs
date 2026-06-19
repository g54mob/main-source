using UnityEngine;

public class InputDependentActivator : MonoBehaviour
{
	public enum InputControllerType
	{
		KEYBOARD = 0,
		GAMEPAD = 1
	}

	public InputControllerType enabledWhenControllerTypeIsActive = InputControllerType.GAMEPAD;

	private void Start()
	{
		InputControllerType inputControllerType = (Manager.input.IsAnyGamepadConnected() ? InputControllerType.GAMEPAD : InputControllerType.KEYBOARD);
		bool active = enabledWhenControllerTypeIsActive == inputControllerType;
		base.gameObject.SetActive(active);
	}
}
