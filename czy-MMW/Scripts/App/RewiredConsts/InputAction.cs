using Rewired.Dev;

namespace RewiredConsts
{
	public static class InputAction
	{
		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Move Horizontal")]
		public const int MoveHorizontal = 0;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Move Vertical")]
		public const int MoveVertical = 1;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Confirm or context specific action in game")]
		public const int Confirm = 2;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "NavigateUp")]
		public const int NavigateUp = 3;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "NavigateRight")]
		public const int NavigateRight = 4;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "NavigateDown")]
		public const int NavigateDown = 5;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "NavigateLeft")]
		public const int NavigateLeft = 6;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Navigate back or cancel in game")]
		public const int Back = 7;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "To access pause menu from game")]
		public const int Menu = 8;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "ActivateControllerSelect")]
		public const int ActivateControllerSelect = 12;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Left Mouse Button Pressed")]
		public const int LeftMouse = 19;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Right Mouse Button Pressed")]
		public const int RightMouse = 20;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "X Position of Mouse")]
		public const int MousePosition = 23;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Y Position of Mouse")]
		public const int MouseY = 24;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "NavigateUpSiri2")]
		public const int NavigateUpSiri2 = 26;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "NavigateRightSiri2")]
		public const int NavigateRightSiri2 = 27;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Action0")]
		public const int NavigateDownSiri2 = 28;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "NavigateLeftSiri2")]
		public const int NavigateLeftSiri2 = 29;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Middle mouse button pressed")]
		public const int MiddleMouse = 30;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Left Stick Press")]
		public const int LeftStickPress = 36;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Right Stick Press")]
		public const int RightStickPress = 37;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Go one page left")]
		public const int PageLeft = 42;

		[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Go one page right")]
		public const int PageRight = 43;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Draw Mode Toggle")]
		public const int DrawModeToggle = 9;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Increase Game Speed")]
		public const int IncreaseSpeed = 10;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Decrease Game Speed")]
		public const int DecreaseSpeed = 11;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Pauses the game")]
		public const int Pause = 13;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Sets to normal speed")]
		public const int NormalSpeed = 14;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Sets fast forward")]
		public const int FastForward = 15;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Toggles paused or not")]
		public const int TogglePause = 16;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Start drawing roads")]
		public const int DrawRoads = 17;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Start Deleting Roads")]
		public const int DeleteRoads = 18;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Raise or Lock the upgrade toolbar")]
		public const int RaiseToolbar = 21;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Unlock or lower the upgrade toolbar")]
		public const int LowerToolbar = 22;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "When held, DrawRoads will actually delete.")]
		public const int DeleteModeModifier = 25;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Zooms in or out")]
		public const int ToggleZoomAction = 31;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Toggles the game UI visible")]
		public const int ToggleGameUI = 32;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Pan Camera vertical")]
		public const int PanVertical = 33;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Pan camera horizontal")]
		public const int PanHorizontal = 34;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Zooms in")]
		public const int ZoomInAction = 40;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Zooms out")]
		public const int ZoomOutAction = 41;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "OpenElectiveUpgradeScreen")]
		public const int OpenElectiveUpgradeScreen = 44;

		[ActionIdFieldInfo(categoryName = "In Game Actions", friendlyName = "Sets extra fast forward")]
		public const int ExtraFastForward = 45;
	}
}
