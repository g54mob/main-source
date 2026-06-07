using Rewired.Dev;

namespace RewiredConsts
{
	public static class Action
	{
		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Input_CameraForward")]
		public const int Camera_Forward = 0;

		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Input_CameraBackward")]
		public const int Camera_Backward = 1;

		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Input_CameraLeft")]
		public const int Camera_Left = 31;

		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Input_CameraRight")]
		public const int Camera_Right = 32;

		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Input_RotateLeft")]
		public const int Rotate_Left = 2;

		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Input_RotateRight")]
		public const int Rotate_Right = 33;

		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Action0")]
		public const int Rotate_Horizontal = 150;

		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Input_Zoom")]
		public const int Zoom = 89;

		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Grab")]
		public const int Grab = 143;

		[ActionIdFieldInfo(categoryName = "Input_CameraControls_Category", friendlyName = "Action0")]
		public const int Grab_Cancel = 144;

		[ActionIdFieldInfo(categoryName = "Input_CameraAction_Category", friendlyName = "Input_LockCamera")]
		public const int Lock_Camera = 39;

		[ActionIdFieldInfo(categoryName = "Input_CameraAction_Category", friendlyName = "Input_ResetCamera")]
		public const int Reset_Camera = 40;

		[ActionIdFieldInfo(categoryName = "Input_CameraAction_Category", friendlyName = "Input_ResetCameraRotation")]
		public const int Reset_Camera_Rotation = 45;

		[ActionIdFieldInfo(categoryName = "Input_CameraAction_Category", friendlyName = "Input_FocusHouse")]
		public const int Lock_Camera_On_House = 60;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_Interact")]
		public const int Interact = 93;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_Cancel")]
		public const int Cancel = 102;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_DecreaseBuoyRadius")]
		public const int Decrease_Buoy_Radius = 35;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_IncreaseBuoyRadius")]
		public const int Increase_Buoy_Radius = 36;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_PauseSpeed")]
		public const int Pause_Speed = 46;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_NormalSpeed")]
		public const int Normal_Speed = 47;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_FastSpeed")]
		public const int Fast_Speed = 48;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_VeryFastSpeed")]
		public const int Very_Fast_Speed = 62;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_ShowMarkers")]
		public const int Show_Markers = 50;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_PlaceSwimmingBuoy")]
		public const int Place_Swimming_Buoy = 51;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_PlaceSalvageBoatBuoy")]
		public const int Place_RawBoat_Buoy = 52;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_PlaceFishBoatBuoy")]
		public const int Place_FishBoat_Buoy = 53;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_BuildingSnapping")]
		public const int Building_Snapping = 73;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_BuildingGrid")]
		public const int Building_Grid = 74;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_ContinuousBuilding")]
		public const int Continuous_Building = 75;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_CycleDrifters")]
		public const int Cycle_Drifters = 64;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_InvertCycleDrifters")]
		public const int Invert_Cycle_Drifters = 130;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Architect_StoreBuildable")]
		public const int Architect_Store_Buildable = 140;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Architect Cancel")]
		public const int Architect_Cancel = 141;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_DecorationRotate")]
		public const int Decoration_Rotate = 155;

		[ActionIdFieldInfo(categoryName = "Input_Gameplay_Category", friendlyName = "Input_DecorationVariation")]
		public const int Decoration_Variation = 156;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "UIHorizontal")]
		public const int UIHorizontal = 27;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "UIVertical")]
		public const int UIVertical = 28;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "UISubmit")]
		public const int UISubmit = 29;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "UICancel")]
		public const int UICancel = 30;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "UICancelMouse")]
		public const int UICancelMouse = 149;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "UIHorizontalRestricted")]
		public const int UIHorizontalRestricted = 148;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "UIVerticalRestricted")]
		public const int UIVerticalRestricted = 147;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Escape")]
		public const int Escape = 43;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenSurvivalGuide")]
		public const int Open_Survival_Guide = 49;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenLog")]
		public const int Open_Log = 67;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenDailyReports")]
		public const int Open_Daily_Reports = 68;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_Quicksave")]
		public const int Quicksave = 63;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenBuildMenu")]
		public const int Open_Build_Menu = 66;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "INPUT_OpenDecorationsBuildMenu")]
		public const int OpenDecorationsBuildMenu = 153;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenResearchPanel")]
		public const int Open_Research_Panel = 54;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenMap")]
		public const int Open_Map = 55;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenInventory")]
		public const int Open_Inventory = 56;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenDrifterPanel")]
		public const int Open_Drifters_Panel = 57;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenProducerPanel")]
		public const int Open_Producer_Panel = 61;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_OpenTutorialPanel")]
		public const int Open_Tutorial_Panel = 152;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Input_ShowDrifterNames")]
		public const int Show_Drifter_Names = 65;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Settings Reset")]
		public const int Settings_Reset = 131;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Settings Apply")]
		public const int Settings_Apply = 132;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Increase Value")]
		public const int Increase_Value = 137;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Decrease Value")]
		public const int Decrease_Value = 138;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "Scroll Vertical")]
		public const int Scroll_Vertical = 142;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "MouseHorizontal")]
		public const int MouseHorizontal = 145;

		[ActionIdFieldInfo(categoryName = "Input_UI", friendlyName = "MouseVertical")]
		public const int MouseVertical = 146;

		[ActionIdFieldInfo(categoryName = "Input_Category_Map", friendlyName = "Input_TownheartForward")]
		public const int Townheart__Forward = 69;

		[ActionIdFieldInfo(categoryName = "Input_Category_Map", friendlyName = "Input_TownheartBackward")]
		public const int Townheart_Backward = 70;

		[ActionIdFieldInfo(categoryName = "Input_Category_Map", friendlyName = "Input_TownheartRotateLeft")]
		public const int Townheart__Rotate_Left = 71;

		[ActionIdFieldInfo(categoryName = "Input_Category_Map", friendlyName = "Input_TownheartRotateRight")]
		public const int Townheart_Rotate_Right = 72;

		[ActionIdFieldInfo(categoryName = "Input_Category_Map", friendlyName = "Input_CameraForward")]
		public const int Map_Camera_Forward = 79;

		[ActionIdFieldInfo(categoryName = "Input_Category_Map", friendlyName = "Input_CameraBackward")]
		public const int Map_Camera_Backward = 80;

		[ActionIdFieldInfo(categoryName = "Input_Category_Map", friendlyName = "Input_CameraLeft")]
		public const int Map_Camera_Left = 81;

		[ActionIdFieldInfo(categoryName = "Input_Category_Map", friendlyName = "Input_CameraRight")]
		public const int Map_Camera_Right = 82;

		[ActionIdFieldInfo(categoryName = "Input_Category_Map", friendlyName = "Input_MapToggle")]
		public const int Map_Input_Toggle = 83;

		[ActionIdFieldInfo(categoryName = "Category0", friendlyName = "Input_RotateVerticalForward")]
		public const int Rotate_Vertical_Forward = 23;

		[ActionIdFieldInfo(categoryName = "Category0", friendlyName = "Input_RotateVerticalBackward")]
		public const int Rotate_Vertical_Backward = 34;

		[ActionIdFieldInfo(categoryName = "Joystick Mouse Mapping", friendlyName = "Joystick Mouse X")]
		public const int Joystick_Mouse_X = 85;

		[ActionIdFieldInfo(categoryName = "Joystick Mouse Mapping", friendlyName = "Joystick Mouse Y")]
		public const int Joystick_Mouse_Y = 86;

		[ActionIdFieldInfo(categoryName = "Joystick Mouse Mapping", friendlyName = "Joystick Mouse Button Left")]
		public const int Joystick_Mouse_Button_Left = 87;

		[ActionIdFieldInfo(categoryName = "Joystick Mouse Mapping", friendlyName = "Action0")]
		public const int Joystick_Mouse_Button_Right = 88;

		[ActionIdFieldInfo(categoryName = "Joystick Mouse Mapping", friendlyName = "Action0")]
		public const int Joystick_Mouse_Toggle = 91;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "LeftStick X")]
		public const int LeftStick_X = 103;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "LeftStick Y")]
		public const int LeftStick_Y = 104;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "RightStick X")]
		public const int RightStick_X = 105;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "RightStick Y")]
		public const int RightStick_Y = 106;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Left Trigger")]
		public const int Left_Trigger = 107;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Right Trigger")]
		public const int Right_Trigger = 108;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Button A")]
		public const int Button_A = 109;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Button B")]
		public const int Button_B = 110;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Button X")]
		public const int Button_X = 111;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Button Y")]
		public const int Button_Y = 112;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Left Shoulder")]
		public const int Left_Shoulder = 113;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Right Shoulder")]
		public const int Right_Shoulder = 114;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "View")]
		public const int View = 115;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Menu")]
		public const int Menu = 116;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Guide")]
		public const int Guide = 117;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "LeftStick Button")]
		public const int LeftStick_Button = 118;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "RightStick Button")]
		public const int RightStick_Button = 119;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "DPad Up")]
		public const int DPad_Up = 120;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "DPad Right")]
		public const int DPad_Right = 121;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "DPad Down")]
		public const int DPad_Down = 122;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "DPad Left")]
		public const int DPad_Left = 123;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Right Stick Up")]
		public const int Right_Stick_Up = 124;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Right Stick Right")]
		public const int Right_Stick_Right = 125;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Right Stick Down")]
		public const int Right_Stick_Down = 126;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Right Stick Left")]
		public const int Right_Stick_Left = 127;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Left Stick Up")]
		public const int Left_Stick_Up = 133;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Left Stick Right")]
		public const int Left_Stick_Right = 134;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Left Stick Down")]
		public const int Left_Stick_Down = 135;

		[ActionIdFieldInfo(categoryName = "Joystick", friendlyName = "Left Stick Left")]
		public const int Left_Stick_Left = 136;
	}
}
