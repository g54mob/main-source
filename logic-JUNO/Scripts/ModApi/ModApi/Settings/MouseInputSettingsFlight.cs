using ModApi.Input.Events;
using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public class MouseInputSettingsFlight : MouseInputSettings
	{
		public EnumSetting<MouseClickType> ActivatePart { get; private set; }

		public EnumSetting<MouseClickType> ActivatePartAlt { get; private set; }

		public EnumSetting<MouseClickType> FocusCameraOnPart { get; private set; }

		public EnumSetting<MouseClickType> FocusCameraOnPartAlt { get; private set; }

		public NumericSetting<float> MouseJoystickDeadzonePitch { get; private set; }

		public NumericSetting<float> MouseJoystickDeadzoneRoll { get; private set; }

		public BoolSetting MouseJoystickInvertPitch { get; private set; }

		public override int Order => 10;

		public EnumSetting<MouseDragOrScrollType> PanCamera { get; private set; }

		public EnumSetting<MouseDragOrScrollType> PanCameraAlt { get; private set; }

		public EnumSetting<MouseDragOrScrollType> RotateCamera { get; private set; }

		public EnumSetting<MouseDragOrScrollType> RotateCameraAlt { get; private set; }

		public EnumSetting<MouseClickType> SelectPart { get; private set; }

		public EnumSetting<MouseClickType> SelectPartAlt { get; private set; }

		public EnumSetting<MouseDragOrScrollType> SpinForwardAxis { get; private set; }

		public EnumSetting<MouseDragOrScrollType> SpinForwardAxisAlt { get; private set; }

		public EnumSetting<MouseDragOrScrollType> ZoomCamera { get; private set; }

		public EnumSetting<MouseDragOrScrollType> ZoomCameraAlt { get; private set; }

		public MouseInputSettingsFlight()
			: base("Camera & Mouse (Flight)")
		{
			RegisterPresetList(SettingsCategoryPreset.Default, SettingsCategoryPreset.LittleGreenMen, SettingsCategoryPreset.Custom);
		}

		public bool CanActivatePart(InputButton inputButton)
		{
			if (!MouseInputSettings.IsMatch(inputButton, ActivatePart.Value))
			{
				return MouseInputSettings.IsMatch(inputButton, ActivatePartAlt.Value);
			}
			return true;
		}

		public bool CanFocusCameraOnPart(InputButton inputButton)
		{
			if (!MouseInputSettings.IsMatch(inputButton, FocusCameraOnPart.Value))
			{
				return MouseInputSettings.IsMatch(inputButton, FocusCameraOnPartAlt.Value);
			}
			return true;
		}

		public bool CanPanCamera(InputButton inputButton, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputButton, PanCamera.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputButton, PanCameraAlt.Value, out inverted);
			}
			return true;
		}

		public bool CanPanCamera(InputAxis inputAxis, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputAxis, PanCamera.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputAxis, PanCameraAlt.Value, out inverted);
			}
			return true;
		}

		public bool CanRotateCamera(InputButton inputButton, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputButton, RotateCamera.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputButton, RotateCameraAlt.Value, out inverted);
			}
			return true;
		}

		public bool CanRotateCamera(InputAxis inputAxis, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputAxis, RotateCamera.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputAxis, RotateCameraAlt.Value, out inverted);
			}
			return true;
		}

		public bool CanSelectPart(InputButton inputButton)
		{
			if (!MouseInputSettings.IsMatch(inputButton, SelectPart.Value))
			{
				return MouseInputSettings.IsMatch(inputButton, SelectPartAlt.Value);
			}
			return true;
		}

		public bool CanSpinForwardAxis(InputButton inputButton, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputButton, SpinForwardAxis.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputButton, SpinForwardAxisAlt.Value, out inverted);
			}
			return true;
		}

		public bool CanSpinForwardAxis(InputAxis inputAxis, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputAxis, SpinForwardAxis.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputAxis, SpinForwardAxisAlt.Value, out inverted);
			}
			return true;
		}

		public bool CanZoomCamera(InputButton inputButton, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputButton, ZoomCamera.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputButton, ZoomCameraAlt.Value, out inverted);
			}
			return true;
		}

		public bool CanZoomCamera(InputAxis inputAxis, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputAxis, ZoomCamera.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputAxis, ZoomCameraAlt.Value, out inverted);
			}
			return true;
		}

		public override SettingsCategoryPreset GetDefaultPreset()
		{
			return SettingsCategoryPreset.Default;
		}

		protected override void ApplyPreset(SettingsCategoryPreset preset, DeviceFlags devices)
		{
			base.ApplyPreset(preset, devices);
			switch (preset)
			{
			case SettingsCategoryPreset.Custom:
				break;
			case SettingsCategoryPreset.LittleGreenMen:
				SelectPart.Value = MouseClickType.LeftClick;
				SelectPartAlt.Value = MouseClickType.None;
				ActivatePart.Value = MouseClickType.RightClick;
				ActivatePartAlt.Value = MouseClickType.None;
				FocusCameraOnPart.Value = MouseClickType.MiddleClick;
				FocusCameraOnPartAlt.Value = MouseClickType.None;
				RotateCamera.Value = MouseDragOrScrollType.RightClickDrag;
				RotateCameraAlt.Value = MouseDragOrScrollType.None;
				PanCamera.Value = MouseDragOrScrollType.None;
				PanCameraAlt.Value = MouseDragOrScrollType.None;
				ZoomCamera.Value = MouseDragOrScrollType.MouseScrollVertical;
				ZoomCameraAlt.Value = MouseDragOrScrollType.None;
				SpinForwardAxis.Value = MouseDragOrScrollType.None;
				SpinForwardAxisAlt.Value = MouseDragOrScrollType.None;
				break;
			default:
				SelectPart.Value = MouseClickType.LeftClick;
				SelectPartAlt.Value = MouseClickType.None;
				ActivatePart.Value = MouseClickType.RightClick;
				ActivatePartAlt.Value = MouseClickType.None;
				FocusCameraOnPart.Value = MouseClickType.MiddleClick;
				FocusCameraOnPartAlt.Value = MouseClickType.None;
				RotateCamera.Value = MouseDragOrScrollType.LeftClickDrag;
				RotateCameraAlt.Value = MouseDragOrScrollType.MiddleClickDrag;
				PanCamera.Value = MouseDragOrScrollType.RightClickDrag;
				PanCameraAlt.Value = MouseDragOrScrollType.None;
				ZoomCamera.Value = MouseDragOrScrollType.MouseScrollVertical;
				ZoomCameraAlt.Value = MouseDragOrScrollType.None;
				SpinForwardAxis.Value = MouseDragOrScrollType.MouseScrollHorizontal;
				SpinForwardAxisAlt.Value = MouseDragOrScrollType.None;
				break;
			}
		}

		protected override void InitializeSettings()
		{
			base.InitializeSettings();
			SelectPart = CreateEnum<MouseClickType>("Select Part", "selectPart").SetDescription("The mouse button(s) used to select parts.");
			SelectPartAlt = CreateEnum<MouseClickType>(string.Empty, "selectPartAlt");
			ActivatePart = CreateEnum<MouseClickType>("Activate Part", "activatePart").SetDescription("The mouse button(s) used to activate parts.");
			ActivatePartAlt = CreateEnum<MouseClickType>(string.Empty, "activatePartAlt");
			FocusCameraOnPart = CreateEnum<MouseClickType>("Focus Camera On Part", "focusCameraOnPart").SetDescription("The mouse button(s) used to to focus the camera on a part.");
			FocusCameraOnPartAlt = CreateEnum<MouseClickType>(string.Empty, "focusCameraOnPartAlt");
			RotateCamera = CreateEnum<MouseDragOrScrollType>("Rotate Camera", "rotateCamera").SetDescription("The mouse input(s) used to rotate the camera around a focal point.");
			RotateCameraAlt = CreateEnum<MouseDragOrScrollType>(string.Empty, "rotateCameraAlt");
			PanCamera = CreateEnum<MouseDragOrScrollType>("Pan Camera", "PanCamera").SetDescription("The mouse input(s) used to pan the camera left/right/up/down.");
			PanCameraAlt = CreateEnum<MouseDragOrScrollType>(string.Empty, "panCameraAlt");
			ZoomCamera = CreateEnum<MouseDragOrScrollType>("Zoom Camera", "zoomCamera").SetDescription("The mouse input(s) used to zoom the camera in and out.");
			ZoomCameraAlt = CreateEnum<MouseDragOrScrollType>(string.Empty, "zoomCameraAlt");
			SpinForwardAxis = CreateEnum<MouseDragOrScrollType>("Tilt Camera", "spinForwardAxis").SetDescription("The mouse input(s) used to spin the camera around its forward axis.");
			SpinForwardAxisAlt = CreateEnum<MouseDragOrScrollType>(string.Empty, "spinForwardAxisAlt");
			MouseJoystickDeadzonePitch = CreateNumeric("Mouse Joystick Pitch Deadzone", 0f, 0.5f, 0.01f, "mouseJoystickDeadzoneY").SetDefault(0.05f).SetDisplayFormatter(Utilities.FormatPercentage).SetDescription("The deadzone percent of the screen where the mouse joystick pitch input will be zero. Enable the mouse joystick by assigning a button to Toggle Mouse Joystick in Flight Craft settings.");
			MouseJoystickDeadzoneRoll = CreateNumeric("Mouse Joystick Roll Deadzone", 0f, 0.5f, 0.01f, "mouseJoystickDeadzoneX").SetDefault(0.1f).SetDisplayFormatter(Utilities.FormatPercentage).SetDescription("The deadzone percent of the screen where the mouse joystick roll input will be zero. Enable the mouse joystick by assigning a button to Toggle Mouse Joystick in Flight Craft settings.");
			MouseJoystickInvertPitch = CreateBool("Mouse Joystick Invert Pitch", "mouseJoystickInvertPitch").SetDefault(value: false).SetDescription("If enabled, the pitch axis of the mouse joystick will be inverted. Enable the mouse joystick by assigning a button to Toggle Mouse Joystick in Flight Craft settings.");
		}
	}
}
