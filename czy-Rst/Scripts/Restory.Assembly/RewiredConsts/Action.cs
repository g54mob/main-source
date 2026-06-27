using Rewired.Dev;

namespace RewiredConsts
{
	public static class Action
	{
		public static class Default
		{
			[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Rotate")]
			public const int Rotate = 29;

			[ActionIdFieldInfo(categoryName = "Default", friendlyName = "RotateLMB")]
			public const int RotateLMB = 68;

			[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Activation Hold Button")]
			public const int Activation_Hold_Button = 76;
		}

		public static class Movements
		{
			[ActionIdFieldInfo(categoryName = "Movements", friendlyName = "Move Horizontal")]
			public const int Move_Horizontal = 0;

			[ActionIdFieldInfo(categoryName = "Movements", friendlyName = "Move Vertical")]
			public const int Move_Vertical = 1;
		}

		public static class CameraControl
		{
			[ActionIdFieldInfo(categoryName = "CameraControl", friendlyName = "Camera Rotation Hold Button")]
			public const int Camera_Rotation_Hold_Button = 55;

			[ActionIdFieldInfo(categoryName = "CameraControl", friendlyName = "Camera Rotate Horizontal")]
			public const int Camera_Rotate_Horizontal = 15;

			[ActionIdFieldInfo(categoryName = "CameraControl", friendlyName = "Camera Rotate Vertical")]
			public const int Camera_Rotate_Vertical = 16;

			[ActionIdFieldInfo(categoryName = "CameraControl", friendlyName = "Camera Rotate Left")]
			public const int Camera_Rotate_Left = 72;

			[ActionIdFieldInfo(categoryName = "CameraControl", friendlyName = "Camera Rotate Right")]
			public const int Camera_Rotate_Right = 73;

			[ActionIdFieldInfo(categoryName = "CameraControl", friendlyName = "Camera Climb")]
			public const int Camera_Climb = 54;

			[ActionIdFieldInfo(categoryName = "CameraControl", friendlyName = "Camera Zoom")]
			public const int Camera_Zoom = 52;
		}

		public static class UI
		{
			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIHorizontal")]
			public const int UIHorizontal = 18;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIVertical")]
			public const int UIVertical = 19;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UISubmit")]
			public const int UISubmit = 20;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UICancel")]
			public const int UICancel = 21;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UI_RT")]
			public const int UI_RT = 22;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UI_LT")]
			public const int UI_LT = 23;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UI_RB")]
			public const int UI_RB = 83;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UI_LB")]
			public const int UI_LB = 84;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UI_Back")]
			public const int UI_Back = 24;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIReset")]
			public const int UIReset = 77;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIApply")]
			public const int UIApply = 78;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIMouseHorizontal")]
			public const int UIMouseHorizontal = 79;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIMouseVertical")]
			public const int UIMouseVertical = 80;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIMouseLeftButton")]
			public const int UIMouseLeftButton = 81;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIMouseRightButton")]
			public const int UIMouseRightButton = 82;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIRightStickButton")]
			public const int UIRightStickButton = 85;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UILeftStickButton")]
			public const int UILeftStickButton = 96;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIWheelHorizontal")]
			public const int UIWheelHorizontal = 86;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIWheelVertical")]
			public const int UIWheelVertical = 87;

			[ActionIdFieldInfo(categoryName = "UI", friendlyName = "UIPlusMinus")]
			public const int UIPlusMinus = 98;
		}

		public static class PauseMenu
		{
			[ActionIdFieldInfo(categoryName = "PauseMenu", friendlyName = "PauseMenu")]
			public const int PauseMenu0 = 40;
		}

		public static class GameplayMenu
		{
			[ActionIdFieldInfo(categoryName = "GameplayMenu", friendlyName = "Gameplay_Menu")]
			public const int Gameplay_Menu = 53;
		}

		public static class Inventory
		{
			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory")]
			public const int Inventory0 = 67;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 1")]
			public const int Inventory_Item_1 = 57;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 2")]
			public const int Inventory_Item_2 = 58;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 3")]
			public const int Inventory_Item_3 = 59;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 4")]
			public const int Inventory_Item_4 = 60;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 5")]
			public const int Inventory_Item_5 = 61;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 6")]
			public const int Inventory_Item_6 = 62;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 7")]
			public const int Inventory_Item_7 = 63;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 8")]
			public const int Inventory_Item_8 = 64;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 9")]
			public const int Inventory_Item_9 = 65;

			[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Inventory Item 10")]
			public const int Inventory_Item_10 = 66;
		}

		public static class ObjectInteractions
		{
			[ActionIdFieldInfo(categoryName = "ObjectInteractions", friendlyName = "Use")]
			public const int Use = 41;

			[ActionIdFieldInfo(categoryName = "ObjectInteractions", friendlyName = "Abort")]
			public const int Abort = 42;

			[ActionIdFieldInfo(categoryName = "ObjectInteractions", friendlyName = "Drop")]
			public const int Drop = 45;

			[ActionIdFieldInfo(categoryName = "ObjectInteractions", friendlyName = "HorizontalAxis")]
			public const int Horizontal = 48;

			[ActionIdFieldInfo(categoryName = "ObjectInteractions", friendlyName = "VerticalAxis")]
			public const int Vertical = 50;
		}

		public static class CharacterStateMachine
		{
			[ActionIdFieldInfo(categoryName = "CharacterStateMachine", friendlyName = "CancelCurrentActivity")]
			public const int CancelCurrentActivity = 56;
		}

		public static class MiniGame
		{
			[ActionIdFieldInfo(categoryName = "MiniGame", friendlyName = "Activate")]
			public const int Activate = 71;

			[ActionIdFieldInfo(categoryName = "MiniGame", friendlyName = "Undo action in minigame")]
			public const int UnDo = 140;

			[ActionIdFieldInfo(categoryName = "MiniGame", friendlyName = "Redo action in minigame")]
			public const int ReDo = 141;
		}

		public static class ExpeditionMapCameraMovement
		{
			[ActionIdFieldInfo(categoryName = "ExpeditionMapCameraMovement", friendlyName = "Read Horizontal")]
			public const int Read_Horizontal__Alt_ = 88;

			[ActionIdFieldInfo(categoryName = "ExpeditionMapCameraMovement", friendlyName = "Read Vertical")]
			public const int Read_Vertical__Alt_ = 89;
		}

		public static class Copybook
		{
			[ActionIdFieldInfo(categoryName = "Copybook", friendlyName = "OpenCopybook")]
			public const int OpenCopybook = 90;

			[ActionIdFieldInfo(categoryName = "Copybook", friendlyName = "PinCopybook")]
			public const int PinCopybook = 91;

			[ActionIdFieldInfo(categoryName = "Copybook", friendlyName = "UnpinAllRecipes")]
			public const int UnpinAllRecipes = 92;
		}

		public static class Typing
		{
			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "A")]
			public const int A = 100;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "B")]
			public const int B = 101;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "C")]
			public const int C = 102;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "D")]
			public const int D = 103;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "E")]
			public const int E = 104;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "F")]
			public const int F = 105;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "G")]
			public const int G = 106;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "H")]
			public const int H = 107;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "I")]
			public const int I = 108;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "J")]
			public const int J = 109;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "K")]
			public const int K = 110;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "L")]
			public const int L = 111;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "M")]
			public const int M = 112;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "N")]
			public const int N = 113;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "O")]
			public const int O = 114;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "P")]
			public const int P = 115;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "Q")]
			public const int Q = 116;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "R")]
			public const int R = 117;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "S")]
			public const int S = 118;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "T")]
			public const int T = 119;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "U")]
			public const int U = 120;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "V")]
			public const int V = 121;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "W")]
			public const int W = 122;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "X")]
			public const int X = 123;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "Y")]
			public const int Y = 124;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "Z")]
			public const int Z = 125;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "0")]
			public const int _0 = 126;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "1")]
			public const int _1 = 127;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "2")]
			public const int _2 = 128;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "3")]
			public const int _3 = 129;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "4")]
			public const int _4 = 130;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "5")]
			public const int _5 = 131;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "6")]
			public const int _6 = 132;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "7")]
			public const int _7 = 133;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "8")]
			public const int _8 = 134;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "9")]
			public const int _9 = 135;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "SPACE")]
			public const int SPACE = 136;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "ENTER")]
			public const int ENTER = 137;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "UP")]
			public const int UP = 138;

			[ActionIdFieldInfo(categoryName = "Typing", friendlyName = "DOWN")]
			public const int DOWN = 139;
		}

		public static class PC
		{
			[ActionIdFieldInfo(categoryName = "PC", friendlyName = "OpenPC")]
			public const int OpenPC = 97;
		}

		public static class Disassemble
		{
			[ActionIdFieldInfo(categoryName = "Disassemble", friendlyName = "GetTooltip")]
			public const int GetTooltip = 99;
		}
	}
}
