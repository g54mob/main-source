using ModApi.Input.Events;
using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public class MouseInputSettingsDesigner : MouseInputSettings
	{
		public EnumSetting<MouseClickType> ClonePart { get; private set; }

		public EnumSetting<MouseClickType> ClonePartAlt { get; private set; }

		public EnumSetting<MouseClickType> FocusCameraOnPart { get; private set; }

		public EnumSetting<MouseClickType> FocusCameraOnPartAlt { get; private set; }

		public EnumSetting<MouseDragOrScrollType> MoveCameraVertically { get; private set; }

		public EnumSetting<MouseDragOrScrollType> MoveCameraVerticallyAlt { get; private set; }

		public override int Order => 10;

		public EnumSetting<MouseDragOrScrollType> PanCamera { get; private set; }

		public EnumSetting<MouseDragOrScrollType> PanCameraAlt { get; private set; }

		public EnumSetting<MouseDragOrScrollType> RotateCamera { get; private set; }

		public EnumSetting<MouseDragOrScrollType> RotateCameraAlt { get; private set; }

		public EnumSetting<MouseClickType> SelectPart { get; private set; }

		public EnumSetting<MouseClickType> SelectPartAlt { get; private set; }

		public EnumSetting<MouseDragOrScrollType> ZoomCamera { get; private set; }

		public EnumSetting<MouseDragOrScrollType> ZoomCameraAlt { get; private set; }

		public MouseInputSettingsDesigner()
			: base("Camera & Mouse (Design)")
		{
			RegisterPresetList(SettingsCategoryPreset.Default, SettingsCategoryPreset.LittleGreenMen, SettingsCategoryPreset.Custom);
		}

		public bool CanClonePart(InputButton inputButton)
		{
			if (!MouseInputSettings.IsMatch(inputButton, ClonePart.Value))
			{
				return MouseInputSettings.IsMatch(inputButton, ClonePartAlt.Value);
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

		public bool CanMoveCameraVertically(InputButton inputButton, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputButton, MoveCameraVertically.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputButton, MoveCameraVerticallyAlt.Value, out inverted);
			}
			return true;
		}

		public bool CanMoveCameraVertically(InputAxis inputAxis, out bool inverted)
		{
			if (!MouseInputSettings.IsMatch(inputAxis, MoveCameraVertically.Value, out inverted))
			{
				return MouseInputSettings.IsMatch(inputAxis, MoveCameraVerticallyAlt.Value, out inverted);
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
				ClonePart.Value = MouseClickType.RightClick;
				ClonePartAlt.Value = MouseClickType.None;
				FocusCameraOnPart.Value = MouseClickType.MiddleClick;
				FocusCameraOnPartAlt.Value = MouseClickType.None;
				RotateCamera.Value = MouseDragOrScrollType.RightClickDrag;
				RotateCameraAlt.Value = MouseDragOrScrollType.None;
				PanCamera.Value = MouseDragOrScrollType.None;
				PanCameraAlt.Value = MouseDragOrScrollType.None;
				ZoomCamera.Value = MouseDragOrScrollType.MiddleClickDrag;
				ZoomCameraAlt.Value = MouseDragOrScrollType.None;
				MoveCameraVertically.Value = MouseDragOrScrollType.MouseScrollVertical;
				MoveCameraVerticallyAlt.Value = MouseDragOrScrollType.None;
				break;
			default:
				SelectPart.Value = MouseClickType.LeftClick;
				SelectPartAlt.Value = MouseClickType.None;
				ClonePart.Value = MouseClickType.RightClick;
				ClonePartAlt.Value = MouseClickType.None;
				FocusCameraOnPart.Value = MouseClickType.MiddleClick;
				FocusCameraOnPartAlt.Value = MouseClickType.None;
				RotateCamera.Value = MouseDragOrScrollType.LeftClickDrag;
				RotateCameraAlt.Value = MouseDragOrScrollType.MiddleClickDrag;
				PanCamera.Value = MouseDragOrScrollType.RightClickDrag;
				PanCameraAlt.Value = MouseDragOrScrollType.None;
				ZoomCamera.Value = MouseDragOrScrollType.MouseScrollVertical;
				ZoomCameraAlt.Value = MouseDragOrScrollType.None;
				MoveCameraVertically.Value = MouseDragOrScrollType.MouseScrollHorizontal;
				MoveCameraVerticallyAlt.Value = MouseDragOrScrollType.None;
				break;
			}
		}

		protected override void InitializeSettings()
		{
			base.InitializeSettings();
			SelectPart = CreateEnum<MouseClickType>("Select & Move Part", "selectPart").SetDescription("The mouse button(s) used to select and move parts.");
			SelectPartAlt = CreateEnum<MouseClickType>(string.Empty, "selectPartAlt");
			ClonePart = CreateEnum<MouseClickType>("Clone Part", "clonePart").SetDescription("The mouse button(s) used to clone parts.");
			ClonePartAlt = CreateEnum<MouseClickType>(string.Empty, "clonePartAlt");
			FocusCameraOnPart = CreateEnum<MouseClickType>("Focus Camera On Part", "focusCameraOnPart").SetDescription("The mouse button(s) used to to focus the camera on a part.");
			FocusCameraOnPartAlt = CreateEnum<MouseClickType>(string.Empty, "focusCameraOnPartAlt");
			RotateCamera = CreateEnum<MouseDragOrScrollType>("Rotate Camera", "rotateCamera").SetDescription("The mouse input(s) used to rotate the camera around a focal point.");
			RotateCameraAlt = CreateEnum<MouseDragOrScrollType>(string.Empty, "rotateCameraAlt");
			PanCamera = CreateEnum<MouseDragOrScrollType>("Pan Camera", "PanCamera").SetDescription("The mouse input(s) used to pan the camera left/right/up/down.");
			PanCameraAlt = CreateEnum<MouseDragOrScrollType>(string.Empty, "panCameraAlt");
			ZoomCamera = CreateEnum<MouseDragOrScrollType>("Zoom Camera", "zoomCamera").SetDescription("The mouse input(s) used to zoom the camera in and out.");
			ZoomCameraAlt = CreateEnum<MouseDragOrScrollType>(string.Empty, "zoomCameraAlt");
			MoveCameraVertically = CreateEnum<MouseDragOrScrollType>("Move Camera Vertically", "moveCameraVertically").SetDescription("The mouse input(s) used to move the camera vertically up and down, regardless of orientation.");
			MoveCameraVerticallyAlt = CreateEnum<MouseDragOrScrollType>(string.Empty, "moveCameraVerticallyAlt");
		}
	}
}
