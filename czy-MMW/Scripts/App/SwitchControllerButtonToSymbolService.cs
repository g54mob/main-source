using System;
using Factory;

public class SwitchControllerButtonToSymbolService : DefaultControllerButtonToSymbolService, InputState.IObserver
{
	[Dependency]
	private IHardwareCapabilities _hardwareCapabilities;

	public override string GetTextMeshProSymbolTextForControllerButton(ControllerButton buttonType)
	{
		string text = "";
		text = buttonType switch
		{
			ControllerButton.FaceButtonBottom => "SPR_Switch_LetterButtons-Down", 
			ControllerButton.FaceButtonRight => "SPR_Switch_LetterButtons-Right", 
			ControllerButton.FaceButtonLeft => "SPR_Switch_LetterButtons-Left", 
			ControllerButton.FaceButtonTop => "SPR_Switch_LetterButtons-Up", 
			ControllerButton.ButtonLeft => "SPR_Switch_DPad-Down", 
			ControllerButton.ButtonRight => "SPR_Switch_DPad-Right", 
			ControllerButton.ButtonUp => "SPR_Switch_DPad-Up", 
			ControllerButton.ButtonDown => "SPR_Switch_DPad-Down", 
			ControllerButton.ButtonShoulderLeft => (_hardwareCapabilities.CurrentGamepadStyle != DeviceInputGamepadStyle.SwitchJoyConL && _hardwareCapabilities.CurrentGamepadStyle != DeviceInputGamepadStyle.SwitchJoyConR) ? "SPR_Switch_L" : "SPR_Switch_SL", 
			ControllerButton.ButtonShoulderRight => (_hardwareCapabilities.CurrentGamepadStyle != DeviceInputGamepadStyle.SwitchJoyConL && _hardwareCapabilities.CurrentGamepadStyle != DeviceInputGamepadStyle.SwitchJoyConR) ? "SPR_Switch_R" : "SPR_Switch_SR", 
			ControllerButton.ButtonTriggerLeft => (_hardwareCapabilities.CurrentGamepadStyle != DeviceInputGamepadStyle.SwitchJoyConL && _hardwareCapabilities.CurrentGamepadStyle != DeviceInputGamepadStyle.SwitchJoyConR) ? "SPR_Switch_ZL" : "SPR_Switch_SL", 
			ControllerButton.ButtonTriggerRight => (_hardwareCapabilities.CurrentGamepadStyle != DeviceInputGamepadStyle.SwitchJoyConL && _hardwareCapabilities.CurrentGamepadStyle != DeviceInputGamepadStyle.SwitchJoyConR) ? "SPR_Switch_ZR" : "SPR_Switch_SR", 
			ControllerButton.ButtonHome => "SPR_Switch_Home", 
			ControllerButton.ButtonMenu => "SPR_Switch_Home", 
			ControllerButton.ButtonOptions => "SPR_Switch_Home", 
			ControllerButton.ButtonThumbstickLeft => "SPR_Switch_Joystick_Click-Left", 
			ControllerButton.ButtonThumbstickRight => "SPR_Switch_Joystick_Click-Right", 
			ControllerButton.Dpad => "SPR_Switch_DPad-Filled", 
			ControllerButton.ThumbstickLeft => "SPR_Switch_Joystick-Left", 
			ControllerButton.ThumbstickRight => "SPR_Switch_Joystick-Right", 
			_ => throw new ArgumentOutOfRangeException("buttonType", buttonType, null), 
		};
		if (text.Length <= 0)
		{
			return null;
		}
		return "<sprite name=\"" + text + "\" tint=1>";
	}

	public void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
	{
	}
}
