using System;
using System.Collections.Generic;
using DV.Utils;
using Rewired;
using Rewired.Dev;
using UnityEngine;

namespace DV.Interaction.Inputs
{
	public static class InputManager
	{
		public static class Actions
		{
			private static bool[] _disabledActions;

			public static bool pausedInBackground;

			public static int MoveHorizontal => GetActionID(0);

			public static int MoveVertical => GetActionID(1);

			public static int Crouch => GetActionID(2);

			public static int Run => GetActionID(3);

			public static int Sit => GetActionID(4);

			public static int Jump => GetActionID(5);

			public static int Lean => GetActionID(6);

			public static int Drop => GetActionID(7);

			public static int Place => GetActionID(8);

			public static int Teleport => GetActionID(9);

			public static int Zoom => GetActionID(10);

			public static int Scroll => GetActionID(11);

			public static int MouseLookHorizontal => GetActionID(12);

			public static int MouseLookVertical => GetActionID(13);

			public static int Hotbar => GetActionID(14);

			public static int MouseLook => GetActionID(15);

			public static int AlternativeScroll => GetActionID(102);

			public static int TurnAround => GetActionID(134);

			public static int ThrottleIncremental => GetActionID(16);

			public static int ThrottleAbsolute => GetActionID(17);

			public static int BrakeIncremental => GetActionID(18);

			public static int BrakeAbsolute => GetActionID(19);

			public static int IndependentBrakeIncremental => GetActionID(20);

			public static int IndependentBrakeAbsolute => GetActionID(21);

			public static int ReverserIncremental => GetActionID(22);

			public static int ReverserAbsolute => GetActionID(23);

			public static int DynamicBrakeIncremental => GetActionID(24);

			public static int DynamicBrakeAbsolute => GetActionID(25);

			public static int HandbrakeIncremental => GetActionID(26);

			public static int HandbrakeAbsolute => GetActionID(27);

			public static int HandbrakeToggle => GetActionID(111);

			public static int CylCockIncremental => GetActionID(28);

			public static int CylCockAbsolute => GetActionID(29);

			public static int CylCockToggle => GetActionID(112);

			public static int SandIncremental => GetActionID(30);

			public static int SandAbsolute => GetActionID(31);

			public static int SandToggle => GetActionID(113);

			public static int WiperIncremental => GetActionID(32);

			public static int WiperAbsolute => GetActionID(116);

			public static int WiperToggle => GetActionID(114);

			public static int HeadlightFrontIncremental => GetActionID(33);

			public static int HeadlightFrontAbsolute => GetActionID(132);

			public static int HeadlightRearIncremental => GetActionID(34);

			public static int HeadlightRearAbsolute => GetActionID(133);

			public static int CabLightIncrement => GetActionID(35);

			public static int CabLightToggle => GetActionID(129);

			public static int GearAIncrement => GetActionID(36);

			public static int GearAAbsolute => GetActionID(117);

			public static int GearBIncrement => GetActionID(37);

			public static int GearBAbsolute => GetActionID(118);

			public static int HornIncremental => GetActionID(38);

			public static int Pantograph => GetActionID(40);

			public static int CabOrient => GetActionID(41);

			public static int BellIncremental => GetActionID(42);

			public static int BellAbsolute => GetActionID(130);

			public static int BellToggle => GetActionID(131);

			public static int ReleaseCyl => GetActionID(43);

			public static int FiredoorIncremental => GetActionID(44);

			public static int FiredoorAbsolute => GetActionID(119);

			public static int FiredoorToggle => GetActionID(124);

			public static int InjectorIncremental => GetActionID(45);

			public static int InjectorAbsolute => GetActionID(120);

			public static int InjectorToggle => GetActionID(125);

			public static int DraftIncremental => GetActionID(46);

			public static int DraftAbsolute => GetActionID(121);

			public static int DraftToggle => GetActionID(126);

			public static int BlowerIncremental => GetActionID(47);

			public static int BlowerAbsolute => GetActionID(122);

			public static int BlowerToggle => GetActionID(127);

			public static int BlowdownIncremental => GetActionID(48);

			public static int BlowdownAbsolute => GetActionID(123);

			public static int BlowdownToggle => GetActionID(128);

			public static int Shovel => GetActionID(51);

			public static int Lubricator => GetActionID(53);

			public static int AirPump => GetActionID(54);

			public static int Dynamo => GetActionID(55);

			public static int LightFire => GetActionID(56);

			public static int AshPan => GetActionID(57);

			public static int Couple => GetActionID(58);

			public static int Uncouple => GetActionID(59);

			public static int CouplerSelect => GetActionID(60);

			public static int BrakeCutoutIncremental => GetActionID(100);

			public static int BrakeCutoutAbsolute => GetActionID(101);

			public static int BrakeCutoutToggle => GetActionID(115);

			public static int InteractionPrimary => GetActionID(95);

			public static int InteractionSecondary => GetActionID(97);

			public static int InteractionMiddle => GetActionID(98);

			public static int Interact => GetActionID(99);

			public static int PhotoMode => GetActionID(61);

			public static int HUD => GetActionID(62);

			public static int ContextMenu => GetActionID(63);

			public static int FirstPersonCam => GetActionID(64);

			public static int ExternalCamFollow => GetActionID(65);

			public static int ExternalCamUnfollow => GetActionID(66);

			public static int InventorySlot1 => GetActionID(67);

			public static int InventorySlot2 => GetActionID(68);

			public static int InventorySlot3 => GetActionID(69);

			public static int InventorySlot4 => GetActionID(70);

			public static int InventorySlot5 => GetActionID(71);

			public static int InventorySlot6 => GetActionID(72);

			public static int InventorySlot7 => GetActionID(73);

			public static int InventorySlot8 => GetActionID(74);

			public static int InventorySlot9 => GetActionID(75);

			public static int InventorySlot10 => GetActionID(76);

			public static int InventorySlot11 => GetActionID(77);

			public static int InventorySlot12 => GetActionID(78);

			public static int InventoryOpen => GetActionID(79);

			public static int InventoryQuickMoveModifier => GetActionID(81);

			public static int InventoryQuickEquipModifier => GetActionID(82);

			public static int FlipMultiplePagesModifier => GetActionID(83);

			public static int FlipPage => GetActionID(84);

			public static int Recenter => GetActionID(85);

			public static int ToggleTrackingMode => GetActionID(86);

			public static int Turntable => GetActionID(87);

			public static int Starter => GetActionID(88);

			public static int FuelCutoff => GetActionID(89);

			public static int StarterFuse => GetActionID(90);

			public static int TractionMotorFuse => GetActionID(91);

			public static int ElectricsFuse => GetActionID(92);

			public static int Escape => GetActionID(94);

			public static int Console => GetActionID(93);

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
			private static void StaticInit()
			{
				_disabledActions = new bool[200];
				pausedInBackground = false;
			}

			public static void SetActionDisabled(int id, bool state)
			{
				_disabledActions[id] = state;
			}

			public static int GetActionID(int actionID)
			{
				if (actionID == -1)
				{
					return -1;
				}
				if (pausedInBackground)
				{
					return -1;
				}
				if (_disabledActions[actionID])
				{
					return -1;
				}
				return actionID;
			}
		}

		public static class RewiredActionConsts
		{
			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "MoveHorizontal")]
			public const int MoveHorizontal = 0;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "MoveVertical")]
			public const int MoveVertical = 1;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Crouch")]
			public const int Crouch = 2;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Run")]
			public const int Run = 3;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Sit")]
			public const int Sit = 4;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Jump")]
			public const int Jump = 5;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Lean")]
			public const int Lean = 6;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Drop")]
			public const int Drop = 7;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Place")]
			public const int Place = 8;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Teleport")]
			public const int Teleport = 9;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Zoom")]
			public const int Zoom = 10;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "Scroll")]
			public const int Scroll = 11;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "MouseLookHorizontal")]
			public const int MouseLookHorizontal = 12;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "MouseLookVertical")]
			public const int MouseLookVertical = 13;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "MouseLook (alt mode)")]
			public const int MouseLook = 15;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "AlternativeScroll")]
			public const int AlternativeScroll = 102;

			[ActionIdFieldInfo(categoryName = "Movement", friendlyName = "TurnAround")]
			public const int TurnAround = 134;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "ThrottleIncremental")]
			public const int ThrottleIncremental = 16;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "ThrottleAbsolute")]
			public const int ThrottleAbsolute = 17;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BrakeIncremental")]
			public const int BrakeIncremental = 18;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BrakeAbsolute")]
			public const int BrakeAbsolute = 19;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "IndependentBrakeIncremental")]
			public const int IndependentBrakeIncremental = 20;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "IndependentBrakeAbsolute")]
			public const int IndependentBrakeAbsolute = 21;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "ReverserIncremental")]
			public const int ReverserIncremental = 22;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "ReverserAbsolute")]
			public const int ReverserAbsolute = 23;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "DynamicBrakeIncremental")]
			public const int DynamicBrakeIncremental = 24;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "DynamicBrakeAbsolute")]
			public const int DynamicBrakeAbsolute = 25;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BrakeCutoutIncremental")]
			public const int BrakeCutoutIncremental = 100;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BrakeCutoutAbsolute")]
			public const int BrakeCutoutAbsolute = 101;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BrakeCutoutToggle")]
			public const int BrakeCutoutToggle = 115;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "HandbrakeIncremental")]
			public const int HandbrakeIncremental = 26;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "HandbrakeAbsolute")]
			public const int HandbrakeAbsolute = 27;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "HandbrakeToggle")]
			public const int HandbrakeToggle = 111;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "CylCockIncremental")]
			public const int CylCockIncremental = 28;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "CylCockAbsolute")]
			public const int CylCockAbsolute = 29;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "CylCockToggle")]
			public const int CylCockToggle = 112;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "SandIncremental")]
			public const int SandIncremental = 30;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "SandAbsolute")]
			public const int SandAbsolute = 31;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "SandToggle")]
			public const int SandToggle = 113;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "WiperIncremental")]
			public const int WiperIncremental = 32;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "WiperAbsolute")]
			public const int WiperAbsolute = 116;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "WiperToggle")]
			public const int WiperToggle = 114;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "HeadlightFrontIncremental")]
			public const int HeadlightFrontIncremental = 33;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "HeadlightFrontAbsolute")]
			public const int HeadlightFrontAbsolute = 132;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "HeadlightRearIncremental")]
			public const int HeadlightRearIncremental = 34;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "HeadlightRearAbsolute")]
			public const int HeadlightRearAbsolute = 133;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "CabLightIncremental")]
			public const int CabLightIncremental = 35;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "CabLightToggle")]
			public const int CabLightToggle = 129;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "GearAIncrement")]
			public const int GearAIncrement = 36;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "GearAAbsolute")]
			public const int GearAAbsolute = 117;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "GearBIncrement")]
			public const int GearBIncrement = 37;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "GearBAbsolute")]
			public const int GearBAbsolute = 118;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "HornIncremental")]
			public const int HornIncremental = 38;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "Pantograph")]
			public const int Pantograph = 40;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "CabOrient")]
			public const int CabOrient = 41;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BellIncremental")]
			public const int BellIncremental = 42;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BellAbsolute")]
			public const int BellAbsolute = 130;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BellToggle")]
			public const int BellToggle = 131;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "ReleaseCyl")]
			public const int ReleaseCyl = 43;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "FiredoorIncremental")]
			public const int FiredoorIncremental = 44;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "FiredoorAbsolute")]
			public const int FiredoorAbsolute = 119;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "FiredoorToggle")]
			public const int FiredoorToggle = 124;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "InjectorIncremental")]
			public const int InjectorIncremental = 45;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "InjectorAbsolute")]
			public const int InjectorAbsolute = 120;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "InjectorToggle")]
			public const int InjectorToggle = 125;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "DraftIncremental")]
			public const int DraftIncremental = 46;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "DraftAbsolute")]
			public const int DraftAbsolute = 121;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "DraftToggle")]
			public const int DraftToggle = 126;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BlowerIncremental")]
			public const int BlowerIncremental = 47;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BlowerAbsolute")]
			public const int BlowerAbsolute = 122;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BlowerToggle")]
			public const int BlowerToggle = 127;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BlowdownIncremental")]
			public const int BlowdownIncremental = 48;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BlowdownAbsolute")]
			public const int BlowdownAbsolute = 123;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "BlowdownToggle")]
			public const int BlowdownToggle = 128;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "Shovel")]
			public const int Shovel = 51;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "Lubricator")]
			public const int Lubricator = 53;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "AirPump")]
			public const int AirPump = 54;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "Dynamo")]
			public const int Dynamo = 55;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "LightFire")]
			public const int LightFire = 56;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "AshPan")]
			public const int AshPan = 57;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "Couple")]
			public const int Couple = 58;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "Uncouple")]
			public const int Uncouple = 59;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "CouplerSelect")]
			public const int CouplerSelect = 60;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "Turntable")]
			public const int Turntable = 87;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "Starter")]
			public const int Starter = 88;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "FuelCutoff")]
			public const int FuelCutoff = 89;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "StarterFuse")]
			public const int StarterFuse = 90;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "TractionMotorFuse")]
			public const int TractionMotorFuse = 91;

			[ActionIdFieldInfo(categoryName = "Train Controls", friendlyName = "ElectricsFuse")]
			public const int ElectricsFuse = 92;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot1")]
			public const int InventorySlot1 = 67;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot2")]
			public const int InventorySlot2 = 68;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot3")]
			public const int InventorySlot3 = 69;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot4")]
			public const int InventorySlot4 = 70;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot5")]
			public const int InventorySlot5 = 71;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot6")]
			public const int InventorySlot6 = 72;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot7")]
			public const int InventorySlot7 = 73;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot8")]
			public const int InventorySlot8 = 74;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot9")]
			public const int InventorySlot9 = 75;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot10")]
			public const int InventorySlot10 = 76;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot11")]
			public const int InventorySlot11 = 77;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventorySlot12")]
			public const int InventorySlot12 = 78;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventoryOpen")]
			public const int InventoryOpen = 79;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventoryQuickMoveModifier")]
			public const int InventoryQuickMoveModifier = 81;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "InventoryQuickEquipModifier")]
			public const int InventoryQuickEquipModifier = 82;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "FlipMultiplePagesModifier")]
			public const int FlipMultiplePagesModifier = 83;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "FlipPage")]
			public const int FlipPage = 84;

			[ActionIdFieldInfo(categoryName = "Item Interaction", friendlyName = "Hotbar")]
			public const int Hotbar = 14;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "InteractionPrimary")]
			public const int InteractionPrimary = 95;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "InteractionSecondary")]
			public const int InteractionSecondary = 97;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "InteractionMiddle")]
			public const int InteractionMiddle = 98;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "Interact")]
			public const int Interact = 99;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "PhotoMode")]
			public const int PhotoMode = 61;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "HUD")]
			public const int HUD = 62;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "ContextMenu")]
			public const int ContextMenu = 63;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "FirstPersonCam")]
			public const int FirstPersonCam = 64;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "ExternalCamFollow")]
			public const int ExternalCamFollow = 65;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "ExternalCamUnfollow")]
			public const int ExternalCamUnfollow = 66;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "Recenter")]
			public const int Recenter = 85;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "ToggleTrackingMode")]
			public const int ToggleTrackingMode = 86;

			[ActionIdFieldInfo(categoryName = "Other", friendlyName = "Escape")]
			public const int Escape = 94;

			[ActionIdFieldInfo(categoryName = "Console", friendlyName = "Console")]
			public const int Console = 93;
		}

		public static class Categories
		{
			public const int Default = 0;

			public const int Train_Controls = 2;

			public const int Item_Interaction = 3;

			public const int Other = 4;

			public const int ConsoleMap = 1;
		}

		public static class Layouts
		{
			public static class Joystick
			{
				public const int Default = 0;
			}

			public static class Keyboard
			{
				public const int Default = 0;
			}

			public static class Mouse
			{
				public const int Default = 0;
			}

			public static class CustomController
			{
				public const int Default = 0;
			}
		}

		public static class Players
		{
			[PlayerIdFieldInfo(friendlyName = "System")]
			public const int System = 9999999;

			[PlayerIdFieldInfo(friendlyName = "Player0")]
			public const int Player0 = 0;
		}

		public static class CustomController
		{
			public static class RailDriver2
			{
				public static class Axis
				{
					public const int Reverser = 0;

					public const int Throttle = 1;

					public const int DynamicBrake = 2;

					public const int Brake = 3;

					public const int IndBrake = 4;

					public const int BailOff = 5;

					public const int Wiper = 10;

					public const int Lights = 11;
				}

				public static class Button
				{
					public const int Button_0 = 12;

					public const int Button_1 = 13;

					public const int Button_2 = 14;

					public const int Button_3 = 15;

					public const int Button_4 = 16;

					public const int Button_5 = 17;

					public const int Button_6 = 18;

					public const int Button_7 = 19;

					public const int Button_8 = 20;

					public const int Button_9 = 21;

					public const int Button_10 = 22;

					public const int Button_11 = 23;

					public const int Button_12 = 24;

					public const int Button_13 = 25;

					public const int Button_14 = 26;

					public const int Button_15 = 27;

					public const int Button_16 = 28;

					public const int Button_17 = 29;

					public const int Button_18 = 30;

					public const int Button_19 = 31;

					public const int Button_20 = 32;

					public const int Button_21 = 33;

					public const int Button_22 = 34;

					public const int Button_23 = 35;

					public const int Button_24 = 36;

					public const int Button_25 = 37;

					public const int Button_26 = 38;

					public const int Button_27 = 39;

					public const int Vertical_Button_Up = 40;

					public const int Vertical_Button_Down = 41;

					public const int Dpad_Up = 42;

					public const int Dpad_Right = 45;

					public const int Dpad_Down = 43;

					public const int Dpad_Left = 44;

					public const int Rocker_A_Up = 46;

					public const int Rocker_A_Down = 47;

					public const int Rocker_B_Up = 48;

					public const int Rocker_B_Down = 49;

					public const int Alert = 50;

					public const int Sand = 51;

					public const int P_Button = 52;

					public const int Bell = 53;

					public const int Horn_Up = 54;

					public const int Horn_Down = 55;
				}

				public const int sourceId = 0;

				public const string name = "RailDriver2";

				public static readonly Guid typeGuid = new Guid("29917115-430c-48a0-8a47-cde711d4d1bd");
			}
		}

		private static bool initialized;

		private static Player _newPlayer;

		private static InputConflictRemover interactTutorialConflictRemover;

		private static RequestSystem keyboardAndMouseSystem;

		private static List<ControllerMap> maps = new List<ControllerMap>();

		private static List<ActionElementMap> bindings = new List<ActionElementMap>();

		private static List<ActionElementMap> allBindings = new List<ActionElementMap>();

		public static Player NewPlayer
		{
			get
			{
				Initialize();
				return _newPlayer;
			}
			private set
			{
				_newPlayer = value;
			}
		}

		public static float MouseSensitivity { get; set; } = 1f;

		public static bool IsMouseOverGameWindow
		{
			get
			{
				Vector3 mousePosition = Input.mousePosition;
				if (mousePosition.x.IsInRange(0f, Screen.width))
				{
					return mousePosition.y.IsInRange(0f, Screen.height);
				}
				return false;
			}
		}

		public static event Action KeybindingsChanged;

		public static void Fire_KeybindingsChanged()
		{
			InputManager.KeybindingsChanged?.Invoke();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Reload()
		{
			initialized = false;
			_newPlayer = null;
		}

		public static void SetInteractConflictersEnabled(bool on)
		{
			interactTutorialConflictRemover.SetBlocked(!on);
		}

		public static void SetAllMapsBesidesPredicateEnabled(Predicate<ControllerMap> predicate, bool enabled)
		{
			if (!ReInput.isReady)
			{
				return;
			}
			foreach (ControllerMap allMap in NewPlayer.controllers.maps.GetAllMaps())
			{
				if (!predicate(allMap) && allMap.controllerType != ControllerType.Joystick && allMap.controllerType != ControllerType.Custom)
				{
					allMap.enabled = enabled;
				}
			}
		}

		public static void SetKeyboardAndMouseEnabled(object caller, bool enabled)
		{
			if (!enabled)
			{
				keyboardAndMouseSystem.RequestValue(caller, 0f);
			}
			else
			{
				keyboardAndMouseSystem.RemoveValue(caller);
			}
		}

		private static void Initialize()
		{
			if (initialized)
			{
				return;
			}
			initialized = true;
			NewPlayer = ReInput.players.GetPlayer(0);
			interactTutorialConflictRemover = new InputConflictRemover(99);
			keyboardAndMouseSystem = new RequestSystem(0f);
			keyboardAndMouseSystem.ValueChanged += delegate(float val)
			{
				if (val > 0.5f)
				{
					Player.ControllerHelper controllers = NewPlayer.controllers;
					controllers.AddController(ReInput.controllers.Keyboard, removeFromOtherPlayers: true);
					controllers.AddController(ReInput.controllers.Mouse, removeFromOtherPlayers: true);
				}
				else
				{
					Player.ControllerHelper controllers2 = NewPlayer.controllers;
					Keyboard keyboard = controllers2.Keyboard;
					Mouse mouse = controllers2.Mouse;
					controllers2.RemoveController(keyboard.type, keyboard.id);
					controllers2.RemoveController(mouse.type, mouse.id);
				}
			};
			keyboardAndMouseSystem.RequestValue(keyboardAndMouseSystem, 1f, int.MinValue);
		}

		public static IEnumerable<int> FindActionsThatConflictWith(int checkAgainstActionID)
		{
			NewPlayer.controllers.maps.GetAllMaps(maps);
			allBindings.Clear();
			foreach (ControllerMap map2 in maps)
			{
				map2.GetButtonMapsWithAction(checkAgainstActionID, bindings);
				allBindings.AddRange(bindings);
			}
			foreach (ControllerMap map in maps)
			{
				foreach (ActionElementMap binding in allBindings)
				{
					foreach (ActionElementMap allMap in map.AllMaps)
					{
						if (allMap.actionId == checkAgainstActionID)
						{
							continue;
						}
						if (allMap.keyboardKeyCode != KeyboardKeyCode.None)
						{
							if (allMap.CheckForAssignmentConflict(binding))
							{
								yield return allMap.actionId;
							}
						}
						else if (allMap.controllerMap.controllerId == binding.controllerMap.controllerId && allMap.CheckForAssignmentConflict(binding) && binding.CheckForAssignmentConflict(allMap))
						{
							yield return allMap.actionId;
						}
					}
				}
			}
		}

		public static Vector2 GetMouseAxisInputWithoutSensitivity()
		{
			Vector2 vector = default(Vector2);
			if (NewPlayer.controllers.hasMouse)
			{
				Mouse mouse = NewPlayer.controllers.Mouse;
				vector = new Vector2(mouse.Axes[0].value, mouse.Axes[1].value);
				vector *= 0.1f;
			}
			Vector2 axis2D = NewPlayer.GetAxis2D(Actions.MouseLookHorizontal, Actions.MouseLookVertical);
			axis2D *= Time.deltaTime;
			axis2D *= 100f;
			return vector + axis2D;
		}

		public static Vector2 GetMouseAxisInput()
		{
			return GetMouseAxisInputWithoutSensitivity() * MouseSensitivity;
		}

		public static bool GetAnyDirButton(this Player player, int actionID)
		{
			if (!player.GetButton(actionID))
			{
				return player.GetNegativeButton(actionID);
			}
			return true;
		}

		public static bool GetAnyDirButtonDown(this Player player, int actionID)
		{
			if (!player.GetButtonDown(actionID))
			{
				return player.GetNegativeButtonDown(actionID);
			}
			return true;
		}

		public static bool GetAnyDirButtonUp(this Player player, int actionID)
		{
			if (!player.GetButtonUp(actionID))
			{
				return player.GetNegativeButtonUp(actionID);
			}
			return true;
		}

		public static int GetScrollValue()
		{
			if (!IsMouseOverGameWindow)
			{
				return 0;
			}
			int num = (NewPlayer.GetButtonDown(Actions.AlternativeScroll) ? 1 : (NewPlayer.GetNegativeButtonDown(Actions.AlternativeScroll) ? (-1) : 0));
			return MouseInputEvents.ScrollLinesThisFrame + num;
		}
	}
}
