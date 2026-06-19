using Rewired.Dev;

namespace RewiredConsts
{
	public static class Action
	{
		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "GameMenu")]
		public const int GameMenu = 5;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "GameCancel")]
		public const int GameCancel = 15;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "ToggleInventory")]
		public const int ToggleInventory = 54;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "ToggleMap")]
		public const int ToggleMap = 55;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "RightJoyStickX")]
		public const int RightJoyStickX = 59;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "RightJoyStickY")]
		public const int RightJoyStickY = 60;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "ObjectInteract")]
		public const int ObjectInteract = 68;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "Scroll")]
		public const int Scroll = 77;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "UIInteract")]
		public const int UIInteract = 105;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "UISecondInteract")]
		public const int UISecondInteract = 106;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "ToggleUI")]
		public const int ToggleUI = 208;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "MenuUp")]
		public const int MenuUp = 211;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "MenuDown")]
		public const int MenuDown = 210;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "MenuLeft")]
		public const int MenuLeft = 212;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "MenuRight")]
		public const int MenuRight = 213;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "Touchpad")]
		public const int Touchpad = 228;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "TouchpadX")]
		public const int TouchpadX = 229;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "TouchpadY")]
		public const int TouchpadY = 230;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "LeftJoyStickY")]
		public const int LeftJoyStickY = 1;

		[ActionIdFieldInfo(categoryName = "Common actions used in multiple input contexts", friendlyName = "LeftJoyStickX")]
		public const int LeftJoyStickX = 0;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "GameInteract")]
		public const int GameInteract = 2;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "GameSecondInteract")]
		public const int GameSecondInteract = 3;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "GameNextItem")]
		public const int GameNextItem = 17;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "GamePreviousItem")]
		public const int GamePreviousItem = 47;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot1")]
		public const int EquipSlot1 = 46;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot2")]
		public const int EquipSlot2 = 19;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot3")]
		public const int EquipSlot3 = 20;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot4")]
		public const int EquipSlot4 = 21;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot5")]
		public const int EquipSlot5 = 48;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot6")]
		public const int EquipSlot6 = 49;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot7")]
		public const int EquipSlot7 = 50;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot8")]
		public const int EquipSlot8 = 51;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot9")]
		public const int EquipSlot9 = 52;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "EquipSlot10")]
		public const int EquipSlot10 = 53;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "OpenChat")]
		public const int OpenChat = 94;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "SendChatMessage")]
		public const int SendChatMessage = 95;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "QuickSwapTorch")]
		public const int QuickSwapTorch = 101;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "ToggleSpectatedPlayer")]
		public const int ToggleSpectatedPlayer = 104;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "UseOffHand")]
		public const int UseOffHand = 112;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "Rotate")]
		public const int Rotate = 207;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "MoveFaster")]
		public const int MoveFaster = 218;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "Move character horizontally")]
		public const int CharacterMoveX = 292;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "Move character vertically")]
		public const int CharacterMoveY = 293;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "Aim horizontally")]
		public const int CharacterAimX = 294;

		[ActionIdFieldInfo(categoryName = "In-game actions", friendlyName = "Aim vertically")]
		public const int CharacterAimY = 295;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "PickUpItems")]
		public const int PickUpItems = 107;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "PickUpAllItems")]
		public const int PickUpAllItems = 108;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "Sort")]
		public const int Sort = 109;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "QuickStack")]
		public const int QuickStack = 111;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "TrashItem")]
		public const int TrashItem = 209;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "ToggleShortCutsWindow")]
		public const int ToggleShortCutsWindow = 214;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "EquipPreset1")]
		public const int EquipPreset1 = 215;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "EquipPreset2")]
		public const int EquipPreset2 = 216;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "EquipPreset3")]
		public const int EquipPreset3 = 217;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "ToggleLocking")]
		public const int ToggleLocking = 226;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "SwapNextHotbar")]
		public const int SwapNextHotbar = 304;

		[ActionIdFieldInfo(categoryName = "Inventory", friendlyName = "SwapPreviousHotbar")]
		public const int SwapPreviousHotbar = 305;

		[ActionIdFieldInfo(categoryName = "Map", friendlyName = "ZoomInMap")]
		public const int ZoomInMap = 92;

		[ActionIdFieldInfo(categoryName = "Map", friendlyName = "ZoomOutMap")]
		public const int ZoomOutMap = 93;

		[ActionIdFieldInfo(categoryName = "Map", friendlyName = "MapPing")]
		public const int MapPing = 110;

		[ActionIdFieldInfo(categoryName = "Map", friendlyName = "MapNextMarker")]
		public const int MapNextMarker = 113;

		[ActionIdFieldInfo(categoryName = "Map", friendlyName = "MapPreviousMarker")]
		public const int MapPreviousMarker = 114;

		[ActionIdFieldInfo(categoryName = "Map", friendlyName = "Move map horizontally.")]
		public const int MapMoveX = 296;

		[ActionIdFieldInfo(categoryName = "Map", friendlyName = "Move map vertically.")]
		public const int MapMoveY = 297;

		[ActionIdFieldInfo(categoryName = "Vehicle", friendlyName = "AccelerateVehicle")]
		public const int AccelerateVehicle = 115;

		[ActionIdFieldInfo(categoryName = "Vehicle", friendlyName = "ReverseVehicle")]
		public const int ReverseVehicle = 116;

		[ActionIdFieldInfo(categoryName = "Vehicle", friendlyName = "Honk")]
		public const int Honk = 117;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuActivate")]
		public const int MenuActivate = 4;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuBack")]
		public const int MenuBack = 6;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuL")]
		public const int MenuL = 10;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuR")]
		public const int MenuR = 11;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuU")]
		public const int MenuU = 12;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuD")]
		public const int MenuD = 13;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuStart")]
		public const int MenuStart = 14;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuMouseActivate")]
		public const int MenuMouseActivate = 61;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "Paste")]
		public const int Paste = 71;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuShoulderL")]
		public const int MenuShoulderL = 73;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuShoulderR")]
		public const int MenuShoulderR = 74;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "LeftMouse")]
		public const int LeftMouse = 75;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "RightMouse")]
		public const int RightMouse = 76;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuSelect")]
		public const int MenuSelect = 219;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuOptions")]
		public const int MenuOptions = 220;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "MenuSecondaryActivate")]
		public const int MenuSecondaryActivate = 221;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "Refresh")]
		public const int Refresh = 222;

		[ActionIdFieldInfo(categoryName = "Menu", friendlyName = "OpenProfile")]
		public const int OpenProfile = 223;

		[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "DebugNoClip")]
		public const int DebugNoClip = 7;

		[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "DebugMenu")]
		public const int DebugMenu = 9;

		[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "ToggleConsole")]
		public const int ToggleConsole = 72;

		[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "ToggleLightProfile")]
		public const int ToggleLightProfile = 96;

		[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "ToggleNetworkDebug")]
		public const int ToggleNetworkDebug = 224;

		[ActionIdFieldInfo(categoryName = "UI for control mapper", friendlyName = "UIHorizontal")]
		public const int UIHorizontal = 78;

		[ActionIdFieldInfo(categoryName = "UI for control mapper", friendlyName = "UIVertical")]
		public const int UIVertical = 79;

		[ActionIdFieldInfo(categoryName = "UI for control mapper", friendlyName = "UISubmit")]
		public const int UISubmit = 80;

		[ActionIdFieldInfo(categoryName = "UI for control mapper", friendlyName = "UICancel")]
		public const int UICancel = 81;

		[ActionIdFieldInfo(categoryName = "UI for control mapper", friendlyName = "SelectNextCategory")]
		public const int SelectNextCategory = 298;

		[ActionIdFieldInfo(categoryName = "UI for control mapper", friendlyName = "SelectPreviousCategory")]
		public const int SelectPreviousCategory = 299;

		[ActionIdFieldInfo(categoryName = "UI for control mapper", friendlyName = "ResetDefaults")]
		public const int ResetDefaults = 300;

		[ActionIdFieldInfo(categoryName = "UI for control mapper", friendlyName = "Calibrate")]
		public const int Calibrate = 301;

		[ActionIdFieldInfo(categoryName = "UIModifierKeys", friendlyName = "DropSelectedItem")]
		public const int DropSelectedItem = 87;

		[ActionIdFieldInfo(categoryName = "UIModifierKeys", friendlyName = "QuickMoveItems")]
		public const int QuickMoveItems = 90;

		[ActionIdFieldInfo(categoryName = "UIModifierKeys", friendlyName = "PickUp10")]
		public const int PickUp10 = 98;

		[ActionIdFieldInfo(categoryName = "UIModifierKeys", friendlyName = "PickUpHalf")]
		public const int PickUpHalf = 99;

		[ActionIdFieldInfo(categoryName = "UIModifierKeys", friendlyName = "HotbarSwapModifier")]
		public const int HotbarSwapModifier = 225;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "C4")]
		public const int C4 = 178;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "C4S")]
		public const int C4S = 179;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "D4")]
		public const int D4 = 180;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "D4S")]
		public const int D4S = 181;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "E4")]
		public const int E4 = 182;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "F4")]
		public const int F4 = 183;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "F4S")]
		public const int F4S = 184;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "G4")]
		public const int G4 = 185;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "G4S")]
		public const int G4S = 186;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "A4")]
		public const int A4 = 187;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "A4S")]
		public const int A4S = 188;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "B4")]
		public const int B4 = 189;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "C5")]
		public const int C5 = 192;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "C5S")]
		public const int C5S = 193;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "D5")]
		public const int D5 = 194;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "D5S")]
		public const int D5S = 195;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "E5")]
		public const int E5 = 196;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "F5")]
		public const int F5 = 197;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "F5S")]
		public const int F5S = 198;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "G5")]
		public const int G5 = 199;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "G5S")]
		public const int G5S = 200;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "A5")]
		public const int A5 = 201;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "A5S")]
		public const int A5S = 202;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "B5")]
		public const int B5 = 203;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "OctaveChange")]
		public const int OctaveChange = 191;

		[ActionIdFieldInfo(categoryName = "Music Instrument", friendlyName = "StopPlayingInstrument")]
		public const int StopPlayingInstrument = 190;
	}
}
