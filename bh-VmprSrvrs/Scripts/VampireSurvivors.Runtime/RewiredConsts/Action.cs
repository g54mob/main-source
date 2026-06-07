using Rewired.Dev;

namespace RewiredConsts
{
	public static class Action
	{
		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Move Horizontal")]
		public const int Move_Horizontal = 0;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Move Vertical")]
		public const int Move_Vertical = 1;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "MouseTarget")]
		public const int MouseTarget = 7;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Mouse Wheel")]
		public const int Mouse_Wheel = 8;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Controller A Button")]
		public const int ActionBottomRow1 = 11;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Controller B Button")]
		public const int ActionBottomRow2 = 16;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "DPadUp")]
		public const int DPadUp = 12;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "DPadDown")]
		public const int DPadDown = 15;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "DPadLeft")]
		public const int DPadLeft = 14;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "DPadRight")]
		public const int DPadRight = 13;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Left Trigger")]
		public const int LeftTrigger = 19;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Right Trigger")]
		public const int RightTrigger = 20;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Toggles the game speed")]
		public const int SpeedToggle = 24;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "BlockSpeedToggle")]
		public const int BlockSpeedToggle = 26;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIHorizontal")]
		public const int UIHorizontal = 3;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIVertical")]
		public const int UIVertical = 4;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UISubmit")]
		public const int UISubmit = 5;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UICancel")]
		public const int UICancel = 6;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UICancel mapping on controller")]
		public const int UICancelController = 10;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIStart")]
		public const int UIStart = 9;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIPageDown")]
		public const int UIPageDown = 17;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIPageUp")]
		public const int UIPageUp = 18;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIScrollUp")]
		public const int UIScrollUp = 21;

		[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIScrollDown")]
		public const int UIScrollDown = 22;
	}
}
