using Rewired.Dev;

public static class RewiredActions
{
	[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Menu InputActions QuickSave")]
	public const int Default_QuickSave = 49;

	[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Menu InputActions QuickLoad")]
	public const int Default_QuickLoad = 50;

	[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Menu InputActions TogglePause")]
	public const int Default_Toggle_Pause = 51;

	[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Menu InputActions TimeSpeedUp")]
	public const int Default_Time_Speed_Up = 53;

	[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Menu InputActions TimeSlowDown")]
	public const int Default_Time_Slow_Down = 54;

	[ActionIdFieldInfo(categoryName = "Main Menu", friendlyName = "New Room")]
	public const int Main_Menu_New_Room = 7;

	[ActionIdFieldInfo(categoryName = "Main Menu", friendlyName = "StartScreenContinue")]
	public const int Main_Menu_StartScreenContinue = 74;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Pan Horizontal")]
	public const int Camera_Pan_Horizontal = 0;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Pan Vertical")]
	public const int Camera_Pan_Vertical = 1;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraPanUp")]
	public const int Camera_Pan_Up = 36;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraPanDown")]
	public const int Camera_Pan_Down = 37;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraPanLeft")]
	public const int Camera_Pan_Left = 34;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraPanRight")]
	public const int Camera_Pan_Right = 35;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Zoom")]
	public const int Camera_Zoom = 3;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraZoomIn")]
	public const int Camera_Zoom_In = 40;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraZoomOut")]
	public const int Camera_Zoom_Out = 41;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Rotation")]
	public const int Camera_Rotation = 5;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraRotateClockwise")]
	public const int Camera_Rotate_Clockwise = 38;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraRotateAntiClockwise")]
	public const int Camera_Rotate_AntiClockwise = 39;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Mouse Horizontal")]
	public const int Camera_Mouse_Horizontal = 42;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Mouse Vertical")]
	public const int Camera_Mouse_Vertical = 43;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Mouse Wheel")]
	public const int Camera_Mouse_Wheel = 44;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Action0")]
	public const int Camera_Pitch = 45;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraPitchUp")]
	public const int Camera_Pitch_Up = 46;

	[ActionIdFieldInfo(categoryName = "Camera", friendlyName = "Menu InputActions CameraPitchDown")]
	public const int Camera_Pitch_Down = 47;

	[ActionIdFieldInfo(categoryName = "Build Room", friendlyName = "Menu InputActions Cancel")]
	public const int Build_Room_Cancel = 9;

	[ActionIdFieldInfo(categoryName = "Build Room", friendlyName = "Menu InputActions Accept")]
	public const int Build_Room_Accept = 10;

	[ActionIdFieldInfo(categoryName = "Build Room", friendlyName = "Menu InputActions BuildAddMode")]
	public const int Build_Room_Add_Mode = 12;

	[ActionIdFieldInfo(categoryName = "Build Room", friendlyName = "Menu InputActions BuildSubMode")]
	public const int Build_Room_Sub_Mode = 13;

	[ActionIdFieldInfo(categoryName = "Build Room", friendlyName = "Menu InputActions RotateItemClockwise")]
	public const int Build_Room_Rotate_Item_Clockwise = 16;

	[ActionIdFieldInfo(categoryName = "Build Room", friendlyName = "Menu InputActions RotateItemAntiClockwise")]
	public const int Build_Room_Rotate_Item_AntiClockwise = 17;

	[ActionIdFieldInfo(categoryName = "Build Room", friendlyName = "Rotate Item")]
	public const int Build_Room_Rotate_Item = 21;

	[ActionIdFieldInfo(categoryName = "Build Room", friendlyName = "Menu InputActions DisableSnap")]
	public const int Build_Room_Disable_Snap = 31;

	[ActionIdFieldInfo(categoryName = "Build Room", friendlyName = "Menu InputActions DeleteItem")]
	public const int Build_Room_Delete_Item = 52;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Camera Up Down")]
	public const int Debug_Debug_Camera_Up_Down = 22;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Camera Forward Back")]
	public const int Debug_Debug_Camera_Forward_Back = 23;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Camera Left Right")]
	public const int Debug_Debug_Camera_Left_Right = 24;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Camera Speed Up")]
	public const int Debug_Debug_Camera_Speed_Up = 26;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Camera Slow Down")]
	public const int Debug_Debug_Camera_Slow_Down = 27;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Camera Yaw")]
	public const int Debug_Debug_Camera_Yaw = 28;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Camera Pitch")]
	public const int Debug_Debug_Camera_Pitch = 29;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Camera Lock Height")]
	public const int Debug_Debug_Camera_Lock_Height = 30;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Hide In World Icons")]
	public const int Debug_Hide_In_World_Icons = 33;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions SkipToNextSong")]
	public const int HUD_Skip_to_Next_Song = 48;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleIllnessList")]
	public const int HUD_Toggle_Illness_List = 58;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions TogglePatientList")]
	public const int HUD_Toggle_Patient_List = 56;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleStaffList")]
	public const int HUD_Toggle_Staff_List = 55;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions OpenOverviewFinance")]
	public const int HUD_Open_Overview_Finance = 57;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions OpenOverviewStaff")]
	public const int HUD_Open_Overview_Staff = 59;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions OpenOverviewPatient")]
	public const int HUD_Open_Overview_Patient = 60;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualAttractiveness")]
	public const int HUD_Toggle_Visual_Attractiveness = 61;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualTemperature")]
	public const int HUD_Toggle_Visual_Temperature = 65;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualHygiene")]
	public const int HUD_Toggle_Visual_Hygiene = 64;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualPatientHealth")]
	public const int HUD_Toggle_Visual_Patient_Health = 63;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualPatientHappiness")]
	public const int HUD_Toggle_Visual_Patient_Happiness = 62;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualStaffHappiness")]
	public const int HUD_Toggle_Visual_Staff_Happiness = 66;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualThirst")]
	public const int HUD_Toggle_Visual_Thirst = 68;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualHunger")]
	public const int HUD_Toggle_Visual_Hunger = 69;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualStaffEnergy")]
	public const int HUD_Toggle_Visual_Staff_Energy = 70;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualToilet")]
	public const int HUD_Toggle_Visual_Toilet = 71;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualBoredom")]
	public const int HUD_Toggle_Visual_Boredom = 72;

	[ActionIdFieldInfo(categoryName = "HUD Keys", friendlyName = "Menu InputActions ToggleVisualMaintenance")]
	public const int HUD_Toggle_Visual_Maintenance = 73;
}
