using ModApi.Input.Events;
using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public abstract class MouseInputSettings : SettingsCategory<MouseInputSettings>
	{
		public enum MouseClickType
		{
			[EnumOption(DisplayName = "None")]
			None = 0,
			[EnumOption(DisplayName = "Left Click")]
			LeftClick = 1,
			[EnumOption(DisplayName = "Right Click")]
			RightClick = 2,
			[EnumOption(DisplayName = "Middle Click")]
			MiddleClick = 3
		}

		public enum MouseDragOrScrollType
		{
			[EnumOption(DisplayName = "None")]
			None = 0,
			[EnumOption(DisplayName = "Left Click Drag")]
			LeftClickDrag = 1,
			[EnumOption(DisplayName = "Right Click Drag")]
			RightClickDrag = 2,
			[EnumOption(DisplayName = "Middle Click Drag")]
			MiddleClickDrag = 3,
			[EnumOption(DisplayName = "Mouse Scroll Vertical")]
			MouseScrollVertical = 4,
			[EnumOption(DisplayName = "Mouse Scroll Horizontal")]
			MouseScrollHorizontal = 5,
			[EnumOption(DisplayName = "Left Click Drag (Inverted)")]
			LeftClickDragInverted = 6,
			[EnumOption(DisplayName = "Right Click Drag (Inverted)")]
			RightClickDragInverted = 7,
			[EnumOption(DisplayName = "Middle Click Drag (Inverted)")]
			MiddleClickDragInverted = 8,
			[EnumOption(DisplayName = "Mouse Scroll Vertical (Inverted)")]
			MouseScrollVerticalInverted = 9,
			[EnumOption(DisplayName = "Mouse Scroll Horizontal (Inverted)")]
			MouseScrollHorizontalInverted = 10
		}

		public MouseInputSettings(string categoryName)
			: base(categoryName)
		{
			base.State = (CurrentDevice.HasAnyFlag(DeviceFlags.Mobile) ? SettingState.HiddenReadOnly : SettingState.Enabled);
		}

		protected static bool IsMatch(InputButton inputButton, MouseClickType clickType)
		{
			return clickType switch
			{
				MouseClickType.LeftClick => inputButton == InputButton.Primary, 
				MouseClickType.RightClick => inputButton == InputButton.Secondary, 
				MouseClickType.MiddleClick => inputButton == InputButton.Middle, 
				_ => false, 
			};
		}

		protected static bool IsMatch(InputButton inputButton, MouseDragOrScrollType type, out bool inverted)
		{
			inverted = false;
			switch (type)
			{
			case MouseDragOrScrollType.LeftClickDrag:
				return inputButton == InputButton.Primary;
			case MouseDragOrScrollType.RightClickDrag:
				return inputButton == InputButton.Secondary;
			case MouseDragOrScrollType.MiddleClickDrag:
				return inputButton == InputButton.Middle;
			case MouseDragOrScrollType.LeftClickDragInverted:
				inverted = true;
				return inputButton == InputButton.Primary;
			case MouseDragOrScrollType.RightClickDragInverted:
				inverted = true;
				return inputButton == InputButton.Secondary;
			case MouseDragOrScrollType.MiddleClickDragInverted:
				inverted = true;
				return inputButton == InputButton.Middle;
			default:
				return false;
			}
		}

		protected static bool IsMatch(InputAxis inputAxis, MouseDragOrScrollType type, out bool inverted)
		{
			inverted = false;
			switch (type)
			{
			case MouseDragOrScrollType.MouseScrollVertical:
				return inputAxis == InputAxis.ScrollVertical;
			case MouseDragOrScrollType.MouseScrollHorizontal:
				return inputAxis == InputAxis.ScrollHorizontal;
			case MouseDragOrScrollType.MouseScrollVerticalInverted:
				inverted = true;
				return inputAxis == InputAxis.ScrollVertical;
			case MouseDragOrScrollType.MouseScrollHorizontalInverted:
				inverted = true;
				return inputAxis == InputAxis.ScrollHorizontal;
			default:
				return false;
			}
		}

		protected override void InitializeSettings()
		{
		}
	}
}
