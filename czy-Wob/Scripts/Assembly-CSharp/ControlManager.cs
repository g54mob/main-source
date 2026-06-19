using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using InControl;
using Steamworks;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
	public class GameActions : PlayerActionSet
	{
		public PlayerAction Interact;

		public PlayerAction Cancel;

		public PlayerAction CloseMenu;

		public PlayerAction ZoomIn;

		public PlayerAction ZoomOut;

		public PlayerAction ScrollUIElementUp;

		public PlayerAction ScrollUIElementDown;

		public PlayerAction CameraPanMode;

		public PlayerAction PanLeft;

		public PlayerAction PanRight;

		public PlayerAction PanForward;

		public PlayerAction PanBack;

		public PlayerAction PanUp;

		public PlayerAction PanDown;

		public PlayerAction CameraRotateMode;

		public PlayerAction DragModeVertical;

		public PlayerAction DragUp;

		public PlayerAction DragDown;

		public PlayerAction PettingGrabSwap;

		public PlayerAction PettingGrabSwapGamepad;

		public PlayerAction CycleNextDog;

		public PlayerAction CyclePreviousDog;

		public PlayerAction BuildModeToggle;

		public PlayerAction PhotoModeToggle;

		public PlayerAction RotateHeldObjectRight;

		public PlayerAction RotateHeldObjectLeft;

		public PlayerAction IncreaseHeldObjectScale;

		public PlayerAction DecreaseHeldObjectScale;

		public PlayerAction DestroyHeldObject;

		public PlayerAction Pause;

		public PlayerAction GamepadCursorX;

		public PlayerAction GamepadCursorY;

		public PlayerAction GamepadCameraX;

		public PlayerAction GamepadCameraY;

		public PlayerAction TossHeldObject;

		public PlayerAction CheatConsoleKey1;

		public PlayerAction CheatConsoleKey2;

		public GameActions()
		{
			GamepadCursorX = CreatePlayerAction(ControlCommandToString(ControlCommand.GAMEPAD_CURSOR_X));
			GamepadCursorX.AddBinding(new DeviceBindingSource(InputControlType.LeftStickX));
			GamepadCursorY = CreatePlayerAction(ControlCommandToString(ControlCommand.GAMEPAD_CURSOR_Y));
			GamepadCursorY.AddBinding(new DeviceBindingSource(InputControlType.LeftStickY));
			GamepadCameraX = CreatePlayerAction(ControlCommandToString(ControlCommand.GAMEPAD_CAMERA_X));
			GamepadCameraX.AddBinding(new DeviceBindingSource(InputControlType.RightStickX));
			GamepadCameraY = CreatePlayerAction(ControlCommandToString(ControlCommand.GAMEPAD_CAMERA_Y));
			GamepadCameraY.AddBinding(new DeviceBindingSource(InputControlType.RightStickY));
			Interact = CreatePlayerAction(ControlCommandToString(ControlCommand.INTERACT));
			Interact.AddDefaultBinding(Mouse.LeftButton);
			Interact.AddDefaultBinding(InputControlType.Action1);
			Cancel = CreatePlayerAction(ControlCommandToString(ControlCommand.CANCEL));
			Cancel.AddDefaultBinding(Mouse.RightButton);
			Cancel.AddDefaultBinding(InputControlType.Action2);
			CloseMenu = CreatePlayerAction(ControlCommandToString(ControlCommand.CLOSE_MENU));
			CloseMenu.AddDefaultBinding(Key.Escape);
			CloseMenu.AddDefaultBinding(InputControlType.Action2);
			Pause = CreatePlayerAction(ControlCommandToString(ControlCommand.PAUSE));
			Pause.AddDefaultBinding(Key.Escape);
			Pause.AddDefaultBinding(InputControlType.Options);
			ZoomIn = CreatePlayerAction(ControlCommandToString(ControlCommand.ZOOM_IN));
			ZoomIn.AddDefaultBinding(Key.Equals);
			ZoomIn.AddDefaultBinding(Mouse.PositiveScrollWheel);
			ZoomIn.AddDefaultBinding(InputControlType.LeftTrigger);
			ZoomOut = CreatePlayerAction(ControlCommandToString(ControlCommand.ZOOM_OUT));
			ZoomOut.AddDefaultBinding(Key.Minus);
			ZoomOut.AddDefaultBinding(Mouse.NegativeScrollWheel);
			ZoomOut.AddDefaultBinding(InputControlType.RightTrigger);
			ScrollUIElementUp = CreatePlayerAction(ControlCommandToString(ControlCommand.SCROLL_UI_ELEMENT_UP));
			ScrollUIElementUp.AddDefaultBinding(Mouse.NegativeScrollWheel);
			ScrollUIElementDown = CreatePlayerAction(ControlCommandToString(ControlCommand.SCROLL_UI_ELEMENT_DOWN));
			ScrollUIElementDown.AddDefaultBinding(Mouse.PositiveScrollWheel);
			CameraPanMode = CreatePlayerAction(ControlCommandToString(ControlCommand.CAMERA_PAN_MODE));
			CameraPanMode.AddDefaultBinding(Mouse.MiddleButton);
			PanLeft = CreatePlayerAction(ControlCommandToString(ControlCommand.PAN_LEFT));
			PanLeft.AddDefaultBinding(Key.A);
			PanLeft.AddDefaultBinding(InputControlType.DPadLeft);
			PanRight = CreatePlayerAction(ControlCommandToString(ControlCommand.PAN_RIGHT));
			PanRight.AddDefaultBinding(Key.D);
			PanRight.AddDefaultBinding(InputControlType.DPadRight);
			PanForward = CreatePlayerAction(ControlCommandToString(ControlCommand.PAN_FORWARD));
			PanForward.AddDefaultBinding(Key.W);
			PanForward.AddDefaultBinding(InputControlType.DPadUp);
			PanBack = CreatePlayerAction(ControlCommandToString(ControlCommand.PAN_BACK));
			PanBack.AddDefaultBinding(Key.S);
			PanBack.AddDefaultBinding(InputControlType.DPadDown);
			PanUp = CreatePlayerAction(ControlCommandToString(ControlCommand.PAN_UP));
			PanDown = CreatePlayerAction(ControlCommandToString(ControlCommand.PAN_DOWN));
			CameraRotateMode = CreatePlayerAction(ControlCommandToString(ControlCommand.CAMERA_ROTATE_MODE));
			CameraRotateMode.AddDefaultBinding(Mouse.RightButton);
			DragModeVertical = CreatePlayerAction(ControlCommandToString(ControlCommand.DRAG_MODE_VERTICAL));
			DragModeVertical.AddDefaultBinding(Key.Control);
			DragUp = CreatePlayerAction(ControlCommandToString(ControlCommand.DRAG_UP));
			DragUp.AddDefaultBinding(Mouse.PositiveScrollWheel);
			DragUp.AddDefaultBinding(InputControlType.RightTrigger);
			DragDown = CreatePlayerAction(ControlCommandToString(ControlCommand.DRAG_DOWN));
			DragDown.AddDefaultBinding(Mouse.NegativeScrollWheel);
			DragDown.AddDefaultBinding(InputControlType.LeftTrigger);
			PettingGrabSwap = CreatePlayerAction(ControlCommandToString(ControlCommand.PETTING_GRAB_SWAP));
			PettingGrabSwap.AddDefaultBinding(Key.Shift);
			PettingGrabSwapGamepad = CreatePlayerAction(ControlCommandToString(ControlCommand.PETTING_GRAB_SWAP_GAMEPAD));
			PettingGrabSwapGamepad.AddDefaultBinding(InputControlType.Action3);
			CycleNextDog = CreatePlayerAction(ControlCommandToString(ControlCommand.CYCLE_DOG_NEXT));
			CycleNextDog.AddDefaultBinding(Key.Space);
			CycleNextDog.AddDefaultBinding(InputControlType.RightBumper);
			CyclePreviousDog = CreatePlayerAction(ControlCommandToString(ControlCommand.CYCLE_DOG_PREVIOUS));
			CyclePreviousDog.AddDefaultBinding(InputControlType.LeftBumper);
			BuildModeToggle = CreatePlayerAction(ControlCommandToString(ControlCommand.BUILD_MODE_TOGGLE));
			BuildModeToggle.AddDefaultBinding(Key.F5);
			PhotoModeToggle = CreatePlayerAction(ControlCommandToString(ControlCommand.PHOTO_MODE_TOGGLE));
			PhotoModeToggle.AddDefaultBinding(Key.F6);
			CheatConsoleKey1 = CreatePlayerAction(ControlCommandToString(ControlCommand.CHEAT_CONSOLE_1));
			CheatConsoleKey1.AddDefaultBinding(Key.Tab);
			CheatConsoleKey2 = CreatePlayerAction(ControlCommandToString(ControlCommand.CHEAT_CONSOLE_2));
			CheatConsoleKey2.AddDefaultBinding(Key.Slash);
			CheatConsoleKey2.AddDefaultBinding(Key.Backslash);
			RotateHeldObjectRight = CreatePlayerAction(ControlCommandToString(ControlCommand.ROTATE_HELD_OBJECT_RIGHT));
			RotateHeldObjectRight.AddDefaultBinding(Key.R);
			RotateHeldObjectRight.AddDefaultBinding(InputControlType.RightBumper);
			RotateHeldObjectLeft = CreatePlayerAction(ControlCommandToString(ControlCommand.ROTATE_HELD_OBJECT_LEFT));
			RotateHeldObjectLeft.AddDefaultBinding(InputControlType.LeftBumper);
			IncreaseHeldObjectScale = CreatePlayerAction(ControlCommandToString(ControlCommand.INC_HELD_OBJECT_SCALE));
			IncreaseHeldObjectScale.AddDefaultBinding(Mouse.PositiveScrollWheel);
			IncreaseHeldObjectScale.AddDefaultBinding(InputControlType.RightTrigger);
			DecreaseHeldObjectScale = CreatePlayerAction(ControlCommandToString(ControlCommand.DEC_HELD_OBJECT_SCALE));
			DecreaseHeldObjectScale.AddDefaultBinding(Mouse.NegativeScrollWheel);
			DecreaseHeldObjectScale.AddDefaultBinding(InputControlType.LeftTrigger);
			DestroyHeldObject = CreatePlayerAction(ControlCommandToString(ControlCommand.DESTROY_HELD_OBJECT));
			if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX)
			{
				DestroyHeldObject.AddDefaultBinding(Key.Backspace);
			}
			DestroyHeldObject.AddDefaultBinding(Key.Delete);
			TossHeldObject = CreatePlayerAction(ControlCommandToString(ControlCommand.TOSS_HELD_OBJECT));
			TossHeldObject.AddDefaultBinding(Mouse.RightButton);
		}
	}

	private ControlCommand currentControlCommandBeingMapped;

	private BindingSourceType currentSourceTypeBeingMapped;

	private CommandMappingOption currentOptionRef;

	private List<ControlCommand> gamepadOnlyCommands = new List<ControlCommand> { ControlCommand.PETTING_GRAB_SWAP_GAMEPAD };

	private List<ControlCommand> keyboardMouseOnlyCommands = new List<ControlCommand>
	{
		ControlCommand.SCROLL_UI_ELEMENT_UP,
		ControlCommand.SCROLL_UI_ELEMENT_DOWN,
		ControlCommand.CAMERA_PAN_MODE,
		ControlCommand.CAMERA_ROTATE_MODE,
		ControlCommand.DRAG_MODE_VERTICAL,
		ControlCommand.PETTING_GRAB_SWAP,
		ControlCommand.CHEAT_CONSOLE_1,
		ControlCommand.CHEAT_CONSOLE_2
	};

	private List<ControlCommand> toggleCommands = new List<ControlCommand>
	{
		ControlCommand.GAMEPAD_CURSOR_X,
		ControlCommand.GAMEPAD_CURSOR_Y,
		ControlCommand.GAMEPAD_CAMERA_X,
		ControlCommand.GAMEPAD_CAMERA_Y
	};

	private ControlsMenuController controlGUIRef;

	public static string ControlCommandToString(ControlCommand commandType)
	{
		switch (commandType)
		{
		case ControlCommand.GAMEPAD_CURSOR_X:
			return "Cursor Movement X";
		case ControlCommand.GAMEPAD_CURSOR_Y:
			return "Cursor Movement Y";
		case ControlCommand.GAMEPAD_CAMERA_X:
			return "Camera Movement X";
		case ControlCommand.GAMEPAD_CAMERA_Y:
			return "Camera Movement Y";
		case ControlCommand.INTERACT:
			return "Interact";
		case ControlCommand.CANCEL:
			return "Cancel";
		case ControlCommand.CLOSE_MENU:
			return "Close Menu";
		case ControlCommand.ZOOM_IN:
			return "Zoom In";
		case ControlCommand.ZOOM_OUT:
			return "Zoom Out";
		case ControlCommand.SCROLL_UI_ELEMENT_UP:
			return "Scroll UI List Up";
		case ControlCommand.SCROLL_UI_ELEMENT_DOWN:
			return "Scroll UI List Down";
		case ControlCommand.CAMERA_PAN_MODE:
			return "Camera Mode: Pan";
		case ControlCommand.PAN_LEFT:
			return "Camera Pan Left";
		case ControlCommand.PAN_RIGHT:
			return "Camera Pan Right";
		case ControlCommand.PAN_FORWARD:
			return "Camera Pan Forward";
		case ControlCommand.PAN_BACK:
			return "Camera Pan Back";
		case ControlCommand.PAN_UP:
			return "Camera Pan Up";
		case ControlCommand.PAN_DOWN:
			return "Camera Pan Down";
		case ControlCommand.CAMERA_ROTATE_MODE:
			return "Camera Mode: Rotate";
		case ControlCommand.DRAG_MODE_VERTICAL:
			return "Drag Mode: Vertical";
		case ControlCommand.DRAG_UP:
			return "Drag Object Up";
		case ControlCommand.DRAG_DOWN:
			return "Drag Object Down";
		case ControlCommand.PETTING_GRAB_SWAP:
			return "Petting/Grab Swap (Hold)";
		case ControlCommand.PETTING_GRAB_SWAP_GAMEPAD:
			return "Petting/Grab Swap";
		case ControlCommand.CYCLE_DOG_NEXT:
			return "Select Next Dog";
		case ControlCommand.CYCLE_DOG_PREVIOUS:
			return "Select Previous Dog";
		case ControlCommand.BUILD_MODE_TOGGLE:
			return "Build Mode Toggle";
		case ControlCommand.PHOTO_MODE_TOGGLE:
			return "Photo Mode Toggle";
		case ControlCommand.CHEAT_CONSOLE_1:
			return "Cheat Console 1";
		case ControlCommand.CHEAT_CONSOLE_2:
			return "Cheat Console 2";
		case ControlCommand.ROTATE_HELD_OBJECT_RIGHT:
			return "Rotate Object Right (Placement Mode)";
		case ControlCommand.ROTATE_HELD_OBJECT_LEFT:
			return "Rotate Object Left (Placement Mode)";
		case ControlCommand.INC_HELD_OBJECT_SCALE:
			return "Increment Object Scale (Placement Mode)";
		case ControlCommand.DEC_HELD_OBJECT_SCALE:
			return "Decrement Object Scale (Placement Mode)";
		case ControlCommand.DESTROY_HELD_OBJECT:
			return "Destroy Held Object";
		case ControlCommand.PAUSE:
			return "Open/Close Options Menu (Play Mode)";
		case ControlCommand.TOSS_HELD_OBJECT:
			return "Toss Held Object";
		default:
			Debug.LogError("No string fond for commandType: " + commandType);
			return "ERROR";
		}
	}

	public static string ControlCommandToLocalizedString(ControlCommand commandType)
	{
		switch (commandType)
		{
		case ControlCommand.INTERACT:
			return ScriptLocalization.GUI.GUI_CONTROLS_INTERACT;
		case ControlCommand.CANCEL:
			return ScriptLocalization.GUI.GUI_CONTROLS_CANCEL;
		case ControlCommand.CLOSE_MENU:
			return ScriptLocalization.GUI.GUI_CONTROLS_CLOSE;
		case ControlCommand.ZOOM_IN:
			return ScriptLocalization.GUI.GUI_CONTROLS_ZOOMIN;
		case ControlCommand.ZOOM_OUT:
			return ScriptLocalization.GUI.GUI_CONTROLS_ZOOMOUT;
		case ControlCommand.SCROLL_UI_ELEMENT_UP:
			return ScriptLocalization.GUI.GUI_CONTROLS_SCROLLUIUP;
		case ControlCommand.SCROLL_UI_ELEMENT_DOWN:
			return ScriptLocalization.GUI.GUI_CONTROLS_SCROLLUIDOWN;
		case ControlCommand.CAMERA_PAN_MODE:
			return ScriptLocalization.GUI.GUI_CONTROLS_CAMMODEPAN;
		case ControlCommand.PAN_LEFT:
			return ScriptLocalization.GUI.GUI_CONTROLS_PANLEFT;
		case ControlCommand.PAN_RIGHT:
			return ScriptLocalization.GUI.GUI_CONTROLS_PANRIGHT;
		case ControlCommand.PAN_FORWARD:
			return ScriptLocalization.GUI.GUI_CONTROLS_PANFWRD;
		case ControlCommand.PAN_BACK:
			return ScriptLocalization.GUI.GUI_CONTROLS_PANBACK;
		case ControlCommand.PAN_UP:
			return ScriptLocalization.GUI.GUI_CONTROLS_PANUP;
		case ControlCommand.PAN_DOWN:
			return ScriptLocalization.GUI.GUI_CONTROLS_PANDOWN;
		case ControlCommand.CAMERA_ROTATE_MODE:
			return ScriptLocalization.GUI.GUI_CONTROLS_CAMMODEROT;
		case ControlCommand.DRAG_MODE_VERTICAL:
			return ScriptLocalization.GUI.GUI_CONTROLS_DRAGMODEVERT;
		case ControlCommand.DRAG_UP:
			return ScriptLocalization.GUI.GUI_CONTROLS_DRAGUP;
		case ControlCommand.DRAG_DOWN:
			return ScriptLocalization.GUI.GUI_CONTROLS_DRAGDOWN;
		case ControlCommand.PETTING_GRAB_SWAP:
			return ScriptLocalization.GUI.GUI_CONTROLS_PETGRABSWAP;
		case ControlCommand.PETTING_GRAB_SWAP_GAMEPAD:
			return ScriptLocalization.GUI.GUI_CONTROLS_PETGRABSWAPGP;
		case ControlCommand.CYCLE_DOG_NEXT:
			return ScriptLocalization.GUI.GUI_CONTROLS_NEXTDOG;
		case ControlCommand.CYCLE_DOG_PREVIOUS:
			return ScriptLocalization.GUI.GUI_CONTROLS_PREVDOG;
		case ControlCommand.BUILD_MODE_TOGGLE:
			return ScriptLocalization.GUI.GUI_CONTROLS_BUILDTOGGLE;
		case ControlCommand.PHOTO_MODE_TOGGLE:
			return ScriptLocalization.GUI.GUI_CONTROLS_PHOTOTOGGLE;
		case ControlCommand.ROTATE_HELD_OBJECT_RIGHT:
			return ScriptLocalization.GUI.GUI_CONTROLS_ROTRIGHT;
		case ControlCommand.ROTATE_HELD_OBJECT_LEFT:
			return ScriptLocalization.GUI.GUI_CONTROLS_ROTLEFT;
		case ControlCommand.INC_HELD_OBJECT_SCALE:
			return ScriptLocalization.GUI.GUI_CONTROLS_SCALE_INCREASE;
		case ControlCommand.DEC_HELD_OBJECT_SCALE:
			return ScriptLocalization.GUI.GUI_CONTROLS_SCALE_DECREASE;
		case ControlCommand.DESTROY_HELD_OBJECT:
			return ScriptLocalization.GUI.GUI_CONTROLS_DESTROYHELD;
		case ControlCommand.PAUSE:
			return ScriptLocalization.GUI.GUI_CONTROLS_OPENCLOSEOPTIONS;
		case ControlCommand.TOSS_HELD_OBJECT:
			return ScriptLocalization.GUI.GUI_CONTROLS_TOSSHELD;
		case ControlCommand.CHEAT_CONSOLE_1:
			return ScriptLocalization.GUI.GUI_CONTROLS_CONSOLE1;
		case ControlCommand.CHEAT_CONSOLE_2:
			return ScriptLocalization.GUI.GUI_CONTROLS_CONSOLE2;
		default:
			Debug.LogError("No string fond for commandType: " + commandType);
			return "ERROR";
		}
	}

	public static string GetLocalizedMouseBindingName(string foundName)
	{
		switch (foundName)
		{
		case "LeftButton":
			return ScriptLocalization.Bindings.BINDING_MOUSE_LEFTCLICK;
		case "RightButton":
			return ScriptLocalization.Bindings.BINDING_MOUSE_RIGHTCLICK;
		case "MiddleButton":
			return ScriptLocalization.Bindings.BINDING_MOUSE_MIDDLECLICK;
		case "PositiveScrollWheel":
			return ScriptLocalization.Bindings.BINDING_MOUSE_SCROLLPOS;
		case "NegativeScrollWheel":
			return ScriptLocalization.Bindings.BINDING_MOUSE_SCROLLNEG;
		case "Button4":
			return ScriptLocalization.Bindings.BINDING_MOUSE_BUTTON4;
		case "Button5":
			return ScriptLocalization.Bindings.BINDING_MOUSE_BUTTON5;
		case "Button6":
			return ScriptLocalization.Bindings.BINDING_MOUSE_BUTTON6;
		case "Button7":
			return ScriptLocalization.Bindings.BINDING_MOUSE_BUTTON7;
		case "Button8":
			return ScriptLocalization.Bindings.BINDING_MOUSE_BUTTON8;
		case "Button9":
			return ScriptLocalization.Bindings.BINDING_MOUSE_BUTTON9;
		default:
			return foundName;
		}
	}

	public static string GetLocalizedKeyboardBindingName(string foundName)
	{
		switch (foundName)
		{
		case "Shift":
			return ScriptLocalization.Bindings.BINDING_KEY_SHIFT;
		case "Left Shift":
			return ScriptLocalization.Bindings.BINDING_KEY_LEFTSHIFT;
		case "Right Shift":
			return ScriptLocalization.Bindings.BINDING_KEY_RIGHTSHIFT;
		case "Alt":
			return ScriptLocalization.Bindings.BINDING_KEY_ALT;
		case "Option":
			return ScriptLocalization.Bindings.BINDING_KEY_ALT;
		case "Left Alt":
			return ScriptLocalization.Bindings.BINDING_KEY_LEFTALT;
		case "Left Option":
			return ScriptLocalization.Bindings.BINDING_KEY_LEFTALT;
		case "Right Alt":
			return ScriptLocalization.Bindings.BINDING_KEY_RIGHTALT;
		case "Left Control Right Alt":
			return ScriptLocalization.Bindings.BINDING_KEY_RIGHTALT;
		case "Right Option":
			return ScriptLocalization.Bindings.BINDING_KEY_RIGHTALT;
		case "Command":
			return ScriptLocalization.Bindings.BINDING_KEY_CMND;
		case "Left Command":
			return ScriptLocalization.Bindings.BINDING_KEY_LEFTCMND;
		case "Right Command":
			return ScriptLocalization.Bindings.BINDING_KEY_RIGHTCMND;
		case "Control":
			return ScriptLocalization.Bindings.BINDING_KEY_CTRL;
		case "Left Control":
			return ScriptLocalization.Bindings.BINDING_KEY_LEFTCTRL;
		case "Right Control":
			return ScriptLocalization.Bindings.BINDING_KEY_RIGHTCTRL;
		case "Escape":
			return ScriptLocalization.Bindings.BINDING_KEY_ESC;
		case "Backspace":
			return ScriptLocalization.Bindings.BINDING_KEY_BACKSPACE;
		case "Tab":
			return ScriptLocalization.Bindings.BINDING_KEY_TAB;
		case "Return":
			return ScriptLocalization.Bindings.BINDING_KEY_ENTER;
		case "Space":
			return ScriptLocalization.Bindings.BINDING_KEY_SPACEBAR;
		case "Insert":
			return ScriptLocalization.Bindings.BINDING_KEY_INSERT;
		case "Delete":
			return ScriptLocalization.Bindings.BINDING_KEY_DEL;
		case "Forward Delete":
			return ScriptLocalization.Bindings.BINDING_KEY_DEL;
		case "Home":
			return ScriptLocalization.Bindings.BINDING_KEY_HOME;
		case "End":
			return ScriptLocalization.Bindings.BINDING_KEY_END;
		case "PageUp":
			return ScriptLocalization.Bindings.BINDING_KEY_PGUP;
		case "PageDown":
			return ScriptLocalization.Bindings.BINDING_KEY_PGDOWN;
		case "Left Arrow":
			return ScriptLocalization.Bindings.BINDING_KEY_LEFTARROW;
		case "Right Arrow":
			return ScriptLocalization.Bindings.BINDING_KEY_RIGHTARROW;
		case "Up Arrow":
			return ScriptLocalization.Bindings.BINDING_KEY_UPARROW;
		case "Down Arrow":
			return ScriptLocalization.Bindings.BINDING_KEY_DOWNARROW;
		case "Num 0":
			return "0";
		case "Num 1":
			return "1";
		case "Num 2":
			return "2";
		case "Num 3":
			return "3";
		case "Num 4":
			return "4";
		case "Num 5":
			return "5";
		case "Num 6":
			return "6";
		case "Num 7":
			return "7";
		case "Num 8":
			return "8";
		case "Num 9":
			return "9";
		case "Pad 0":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD0;
		case "Pad 1":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD1;
		case "Pad 2":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD2;
		case "Pad 3":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD3;
		case "Pad 4":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD4;
		case "Pad 5":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD5;
		case "Pad 6":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD6;
		case "Pad 7":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD7;
		case "Pad 8":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD8;
		case "Pad 9":
			return ScriptLocalization.Bindings.BINDING_KEY_PAD9;
		case "Numlock":
			return ScriptLocalization.Bindings.BINDING_KEY_NUMLOCK;
		case "Pad Divide":
			return ScriptLocalization.Bindings.BINDING_KEY_PADDIV;
		case "Pad Multiply":
			return ScriptLocalization.Bindings.BINDING_KEY_PADMULT;
		case "Pad Minus":
			return ScriptLocalization.Bindings.BINDING_KEY_PADMINUS;
		case "Pad Plus":
			return ScriptLocalization.Bindings.BINDING_KEY_PADPLUS;
		case "Pad Enter":
			return ScriptLocalization.Bindings.BINDING_KEY_PADENTER;
		case "Pad Period":
			return ScriptLocalization.Bindings.BINDING_KEY_PADPERIOD;
		case "Clear":
			return ScriptLocalization.Bindings.BINDING_KEY_CLEAR;
		case "Pad Equals":
			return ScriptLocalization.Bindings.BINDING_KEY_PADEQUALS;
		case "Alt Graphic":
			return ScriptLocalization.Bindings.BINDING_KEY_ALTGRPH;
		case "Caps Lock":
			return ScriptLocalization.Bindings.BINDING_KEY_CAPS;
		case "Backquote":
			return "`";
		case "Minus":
			return "-";
		case "Equals":
			return "=";
		case "Left Bracket":
			return "[";
		case "Right Bracket":
			return "]";
		case "Backslash":
			return "\\";
		case "Semicolon":
			return ";";
		case "Quote":
			return "'";
		case "Comma":
			return ",";
		case "Period":
			return ".";
		case "Slash":
			return "/";
		case "Exclamation":
			return "!";
		case "Tilde":
			return "~";
		case "At":
			return "@";
		case "Hash":
			return "#";
		case "Dollar":
			return "$";
		case "Percent":
			return "%";
		case "Caret":
			return "^";
		case "Ampersand":
			return "&";
		case "Asterisk":
			return "*";
		case "Left Paren":
			return "(";
		case "Right Paren":
			return ")";
		case "Underscore":
			return "_";
		case "Plus":
			return "+";
		case "LeftBrace":
			return "{";
		case "RightBrace":
			return "}";
		case "Pipe":
			return "|";
		case "Colon":
			return ":";
		case "Double Quote":
			return "\"";
		case "Less Than":
			return "<";
		case "Greater Than":
			return ">";
		case "Question Mark":
			return "?";
		default:
			return foundName;
		}
	}

	public static string GetLocalizedGamepadBindingName(string foundName)
	{
		string text = "";
		for (int i = 0; i < foundName.Length; i++)
		{
			if (foundName[i] != ' ')
			{
				text += foundName[i];
			}
		}
		foundName = text;
		switch (foundName)
		{
		case "LeftStickLeft":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_LEFTSTICKLEFT;
		case "LeftStickRight":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_LEFTSTICKRIGHT;
		case "LeftStickUp":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_LEFTSTICKUP;
		case "LeftStickDown":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_LEFTSTICKDOWN;
		case "RightStickLeft":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_RIGHTSTICKLEFT;
		case "RightStickRight":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_RIGHTSTICKRIGHT;
		case "RightStickUp":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_RIGHTSTICKUP;
		case "RightStickDown":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_RIGHTSTICKDOWN;
		case "DPadUp":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_DUP;
		case "DPadDown":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_DDOWN;
		case "DPadLeft":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_DLEFT;
		case "DPadRight":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_DRIGHT;
		case "LeftTrigger":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_TRIGGERLEFT;
		case "RightTrigger":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_TRIGGERRIGHT;
		case "LeftBumper":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_BUMPERLEFT;
		case "RightBumper":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_BUMPERRIGHT;
		case "Action1":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION1;
		case "Action2":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION2;
		case "Action3":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION3;
		case "Action4":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION4;
		case "Action5":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION5;
		case "Action6":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION6;
		case "Action7":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION7;
		case "Action8":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION8;
		case "Action9":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION9;
		case "Action10":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION10;
		case "Action11":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION11;
		case "Action12":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ACTION12;
		case "Back":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_BACK;
		case "Start":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_START;
		case "Select":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_SELECT;
		case "System":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_SYSTEM;
		case "Options":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_OPTIONS;
		case "Pause":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_PAUSE;
		case "Menu":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_MENU;
		case "Share":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_SHARE;
		case "Home":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_HOME;
		case "View":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_VIEW;
		case "Power":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_POWER;
		case "Capture":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_CAPTURE;
		case "Assistant":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_ASSIST;
		case "Plus":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_PLUS;
		case "Minus":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_MINUS;
		case "Create":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_CREATE;
		case "Mute":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_MUTE;
		case "PedalLeft":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_PEDALLEFT;
		case "PedalRight":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_PEDALRIGHT;
		case "PedalMiddle":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_PEDALMIDDLE;
		case "GearUp":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_GEARUP;
		case "GearDown":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_GEARDOWN;
		case "ThrottleUp":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_THROTTLEUP;
		case "ThrottleDown":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_THROTTLEDOWN;
		case "TouchPadTap":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_TOUCHTAP;
		case "TouchPadButton":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_TOUCHBUTTON;
		case "Cross":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_CROSS;
		case "Circle":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_CIRCLE;
		case "Square":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_SQUARE;
		case "Triangle":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_TRIANGLE;
		case "LeftStickButton":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_LEFTSTICKBUTTON;
		case "RightStickButton":
			return ScriptLocalization.Bindings.BINDING_GAMEPAD_RIGHTSTICKBUTTON;
		default:
			return foundName;
		}
	}

	private void OnEnable()
	{
		CreateActions();
		GameControls.StoreZoomStrings();
	}

	public void Initialize()
	{
		LoadSavedControlMappings();
	}

	public void AssignGUIRef(ControlsMenuController newRef)
	{
		controlGUIRef = newRef;
	}

	public bool IsCommandGamepadOnly(ControlCommand command)
	{
		return gamepadOnlyCommands.Contains(command);
	}

	public bool IsCommandMouseKeyboardOnly(ControlCommand command)
	{
		return keyboardMouseOnlyCommands.Contains(command);
	}

	public bool IsCommandToggle(ControlCommand command)
	{
		return toggleCommands.Contains(command);
	}

	public void ResetStickToggle()
	{
		GameControls.isLeftStickDefault = true;
		GameControls.actions.GamepadCursorX.ClearBindings();
		GameControls.actions.GamepadCursorY.ClearBindings();
		GameControls.actions.GamepadCameraX.ClearBindings();
		GameControls.actions.GamepadCameraY.ClearBindings();
		GameControls.actions.GamepadCursorX.AddBinding(new DeviceBindingSource(InputControlType.LeftStickX));
		GameControls.actions.GamepadCursorY.AddBinding(new DeviceBindingSource(InputControlType.LeftStickY));
		GameControls.actions.GamepadCameraX.AddBinding(new DeviceBindingSource(InputControlType.RightStickX));
		GameControls.actions.GamepadCameraY.AddBinding(new DeviceBindingSource(InputControlType.RightStickY));
		StopCurrentBinding();
		GameControls.needsScrollValueCheck = true;
	}

	public void SwapSticks()
	{
		GameControls.isLeftStickDefault = !GameControls.isLeftStickDefault;
		GameControls.actions.GamepadCursorX.ClearBindings();
		GameControls.actions.GamepadCursorY.ClearBindings();
		GameControls.actions.GamepadCameraX.ClearBindings();
		GameControls.actions.GamepadCameraY.ClearBindings();
		if (GameControls.isLeftStickDefault)
		{
			GameControls.actions.GamepadCursorX.AddBinding(new DeviceBindingSource(InputControlType.LeftStickX));
			GameControls.actions.GamepadCursorY.AddBinding(new DeviceBindingSource(InputControlType.LeftStickY));
			GameControls.actions.GamepadCameraX.AddBinding(new DeviceBindingSource(InputControlType.RightStickX));
			GameControls.actions.GamepadCameraY.AddBinding(new DeviceBindingSource(InputControlType.RightStickY));
		}
		else
		{
			GameControls.actions.GamepadCursorX.AddBinding(new DeviceBindingSource(InputControlType.RightStickX));
			GameControls.actions.GamepadCursorY.AddBinding(new DeviceBindingSource(InputControlType.RightStickY));
			GameControls.actions.GamepadCameraX.AddBinding(new DeviceBindingSource(InputControlType.LeftStickX));
			GameControls.actions.GamepadCameraY.AddBinding(new DeviceBindingSource(InputControlType.LeftStickY));
		}
	}

	private void CreateActions()
	{
		GameControls.actions = new GameActions();
		GameControls.actions.ListenOptions.OnBindingAdded = OnBindingAdded;
		GameControls.actions.ListenOptions.OnBindingEnded = OnBindingEnded;
		GameControls.actions.ListenOptions.OnBindingFound = OnBindingFound;
		GameControls.actions.ListenOptions.OnBindingRejected = OnBindingRejected;
		GameControls.actions.ListenOptions.IncludeUnknownControllers = true;
		GameControls.actions.ListenOptions.IncludeNonStandardControls = true;
		GameControls.actions.ListenOptions.AllowDuplicateBindingsPerSet = true;
		GameControls.actions.ListenOptions.IncludeModifiersAsFirstClassKeys = true;
	}

	private void LoadSavedControlMappings()
	{
		SavedControlsFile loadedControlMappings = ObjectRegistration.GetRegistrationScript().saveLoadManager.GetLoadedControlMappings();
		if (loadedControlMappings == null)
		{
			return;
		}
		ControlMapping mapping;
		if (!SteamManager.Initialized)
		{
			mapping = loadedControlMappings.defaultUserMapping;
		}
		else
		{
			ulong steamID = SteamUser.GetSteamID().m_SteamID;
			Dictionary<ulong, ControlMapping> dictionary = new Dictionary<ulong, ControlMapping>();
			if (loadedControlMappings.steamUserIDToControlMappingDict != null)
			{
				loadedControlMappings.steamUserIDToControlMappingDict.Load(dictionary);
			}
			mapping = ((!dictionary.ContainsKey(steamID)) ? new ControlMapping() : dictionary[steamID]);
		}
		LoadControlMapping(mapping);
	}

	private void LoadControlMapping(ControlMapping mapping)
	{
		if (mapping == null)
		{
			return;
		}
		if (mapping.toggleSticksDefault != GameControls.isLeftStickDefault)
		{
			SwapSticks();
		}
		for (int i = 0; i < mapping.mappedCommands.Count; i++)
		{
			PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(ControlCommandToString(mapping.mappedCommands[i].command));
			if (playerActionByName == null)
			{
				Debug.LogError("COMMAND NOT FOUND " + mapping.mappedCommands[i].command);
				continue;
			}
			if (mapping.mappedCommands[i].customKeyMapping != Key.None)
			{
				playerActionByName.ClearBindings(BindingSourceType.KeyBindingSource);
				Key[] keys = new Key[1] { mapping.mappedCommands[i].customKeyMapping };
				playerActionByName.AddBinding(new KeyBindingSource(keys));
			}
			if (mapping.mappedCommands[i].customMouseMapping != Mouse.None)
			{
				playerActionByName.ClearBindings(BindingSourceType.MouseBindingSource);
				playerActionByName.AddBinding(new MouseBindingSource(mapping.mappedCommands[i].customMouseMapping));
			}
			if (mapping.mappedCommands[i].customControllerMapping != InputControlType.None)
			{
				playerActionByName.ClearBindings(BindingSourceType.DeviceBindingSource);
				playerActionByName.AddBinding(new DeviceBindingSource(mapping.mappedCommands[i].customControllerMapping));
			}
			if (mapping.mappedCommands[i].keyMappingCleared)
			{
				ClearBinding(mapping.mappedCommands[i].command, BindingSourceType.KeyBindingSource);
			}
			if (mapping.mappedCommands[i].mouseMappingCleared)
			{
				ClearBinding(mapping.mappedCommands[i].command, BindingSourceType.MouseBindingSource);
			}
			if (mapping.mappedCommands[i].controllerMappingCleared)
			{
				ClearBinding(mapping.mappedCommands[i].command, BindingSourceType.DeviceBindingSource);
			}
		}
	}

	public IEnumerator SaveControlMapping()
	{
		SaveLoadManager saveLoadManager = ObjectRegistration.GetRegistrationScript().saveLoadManager;
		ulong? steamID = null;
		if (SteamManager.Initialized)
		{
			steamID = SteamUser.GetSteamID().m_SteamID;
		}
		ControlMapping controlMappingToSave = GetControlMappingToSave();
		yield return StartCoroutine(saveLoadManager.SaveControlMapping(controlMappingToSave, steamID));
	}

	private ControlMapping GetControlMappingToSave()
	{
		ControlMapping controlMapping = new ControlMapping();
		controlMapping.toggleSticksDefault = GameControls.isLeftStickDefault;
		foreach (ControlCommand value in EnumUtils.GetValues<ControlCommand>())
		{
			PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(ControlCommandToString(value));
			if (playerActionByName == null)
			{
				Debug.LogError("COMMAND NOT FOUND " + value);
			}
			else
			{
				if (IsCommandToggle(value) || playerActionByName.IsSetToDefaultBindings(BindingSourceType.None))
				{
					continue;
				}
				List<BindingSource> allCustomBindings = playerActionByName.GetAllCustomBindings();
				for (int i = 0; i < allCustomBindings.Count; i++)
				{
					CommandMapping commandMapping = new CommandMapping();
					commandMapping.command = value;
					if (allCustomBindings[i].BindingSourceType == BindingSourceType.KeyBindingSource)
					{
						KeyBindingSource keyBindingSource = (KeyBindingSource)allCustomBindings[i];
						commandMapping.customKeyMapping = keyBindingSource.Control.GetInclude(0);
					}
					else if (allCustomBindings[i].BindingSourceType == BindingSourceType.MouseBindingSource)
					{
						MouseBindingSource mouseBindingSource = (MouseBindingSource)allCustomBindings[i];
						commandMapping.customMouseMapping = mouseBindingSource.Control;
					}
					else if (allCustomBindings[i].BindingSourceType == BindingSourceType.DeviceBindingSource)
					{
						DeviceBindingSource deviceBindingSource = (DeviceBindingSource)allCustomBindings[i];
						commandMapping.customControllerMapping = deviceBindingSource.Control;
					}
					controlMapping.mappedCommands.Add(commandMapping);
				}
				bool flag = false;
				CommandMapping commandMapping2 = new CommandMapping();
				commandMapping2.command = value;
				if (playerActionByName.IsBindingTypeCleared(BindingSourceType.KeyBindingSource))
				{
					flag = true;
					commandMapping2.keyMappingCleared = true;
				}
				if (playerActionByName.IsBindingTypeCleared(BindingSourceType.MouseBindingSource))
				{
					flag = true;
					commandMapping2.mouseMappingCleared = true;
				}
				if (playerActionByName.IsBindingTypeCleared(BindingSourceType.DeviceBindingSource))
				{
					flag = true;
					commandMapping2.controllerMappingCleared = true;
				}
				if (flag)
				{
					controlMapping.mappedCommands.Add(commandMapping2);
				}
			}
		}
		return controlMapping;
	}

	public int GetNumberOfActiveMouseKeyboardBindingsForCommand(ControlCommand command)
	{
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(ControlCommandToString(command));
		if (playerActionByName == null)
		{
			Debug.LogError("COMMAND NOT FOUND " + command);
			return 0;
		}
		int num = 0;
		for (int i = 0; i < playerActionByName.Bindings.Count; i++)
		{
			if (playerActionByName.Bindings[i].BindingSourceType == BindingSourceType.MouseBindingSource || playerActionByName.Bindings[i].BindingSourceType == BindingSourceType.KeyBindingSource)
			{
				num++;
			}
		}
		return num;
	}

	public bool DoesCommandHaveAnyDefaultBindings(ControlCommand command)
	{
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(ControlCommandToString(command));
		if (playerActionByName == null)
		{
			Debug.LogError("COMMAND NOT FOUND " + command);
			return false;
		}
		return playerActionByName.HasAnyDefaultBinding();
	}

	public string GetCurrentActiveBindingForCommand(ControlCommand command, CursorController cursorRef)
	{
		if (!cursorRef.IsSystemMouseActive())
		{
			return GetCurrentGamepadBindingForCommand(command);
		}
		string currentKeyboardBindingForCommand = GetCurrentKeyboardBindingForCommand(command);
		if (currentKeyboardBindingForCommand.Length > 0)
		{
			return currentKeyboardBindingForCommand;
		}
		return GetCurrentMouseBindingForCommand(command);
	}

	public string GetCurrentKeyboardBindingForCommand(ControlCommand command)
	{
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(ControlCommandToString(command));
		if (playerActionByName == null)
		{
			return "NOT FOUND";
		}
		string foundName = "";
		for (int i = 0; i < playerActionByName.Bindings.Count; i++)
		{
			if (playerActionByName.Bindings[i].BindingSourceType == BindingSourceType.KeyBindingSource)
			{
				foundName = playerActionByName.Bindings[i].Name;
			}
		}
		return GetLocalizedKeyboardBindingName(foundName);
	}

	public string GetCurrentMouseBindingForCommand(ControlCommand command)
	{
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(ControlCommandToString(command));
		if (playerActionByName == null)
		{
			return "NOT FOUND";
		}
		string foundName = "";
		for (int i = 0; i < playerActionByName.Bindings.Count; i++)
		{
			if (playerActionByName.Bindings[i].BindingSourceType == BindingSourceType.MouseBindingSource)
			{
				foundName = playerActionByName.Bindings[i].Name;
			}
		}
		return GetLocalizedMouseBindingName(foundName);
	}

	public string GetCurrentGamepadBindingForCommand(ControlCommand command)
	{
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(ControlCommandToString(command));
		if (playerActionByName == null)
		{
			return "NOT FOUND";
		}
		string foundName = "";
		for (int i = 0; i < playerActionByName.Bindings.Count; i++)
		{
			if (playerActionByName.Bindings[i].BindingSourceType == BindingSourceType.DeviceBindingSource)
			{
				foundName = playerActionByName.Bindings[i].Name;
			}
		}
		return GetLocalizedGamepadBindingName(foundName);
	}

	public void ResetBinding(ControlCommand command, BindingSourceType sourceType)
	{
		string actionName = ControlCommandToString(command);
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(actionName);
		if (playerActionByName == null)
		{
			Debug.LogError("COMMAND NOT FOUND " + command);
			return;
		}
		playerActionByName.ResetBindings(sourceType);
		StopCurrentBinding();
		GameControls.needsScrollValueCheck = true;
	}

	public void ClearBinding(ControlCommand command, BindingSourceType sourceType)
	{
		StopCurrentBinding();
		string actionName = ControlCommandToString(command);
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(actionName);
		if (playerActionByName == null)
		{
			Debug.LogError("COMMAND NOT FOUND " + command);
			return;
		}
		for (int i = 0; i < playerActionByName.Bindings.Count; i++)
		{
			if (playerActionByName.Bindings[i].BindingSourceType == sourceType)
			{
				playerActionByName.RemoveBinding(playerActionByName.Bindings[i]);
			}
		}
		GameControls.needsScrollValueCheck = true;
	}

	public void EnterBindMode(ControlCommand command, CommandMappingOption optionRef, ControlType controlType)
	{
		StopCurrentBinding();
		string actionName = ControlCommandToString(command);
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(actionName);
		if (playerActionByName == null)
		{
			Debug.LogError("COMMAND NOT FOUND " + command);
			return;
		}
		currentOptionRef = optionRef;
		GameControls.actions.ListenOptions.IncludeMouseButtons = controlType == ControlType.MOUSE;
		GameControls.actions.ListenOptions.IncludeMouseScrollWheel = controlType == ControlType.MOUSE;
		BindingSourceType sourceType = BindingSourceType.None;
		switch (controlType)
		{
		case ControlType.MOUSE:
			sourceType = BindingSourceType.MouseBindingSource;
			break;
		case ControlType.KEYBOARD:
			sourceType = BindingSourceType.KeyBindingSource;
			break;
		case ControlType.GAMEPAD:
			sourceType = BindingSourceType.DeviceBindingSource;
			break;
		}
		playerActionByName.ListenForBinding(sourceType);
		currentSourceTypeBeingMapped = sourceType;
		currentControlCommandBeingMapped = command;
	}

	public void OnBindingAdded(PlayerAction playerAction, BindingSource bindingSource)
	{
		RefreshCurrentOption();
	}

	public void RefreshCurrentOption()
	{
		if (currentOptionRef != null)
		{
			currentOptionRef.Refresh();
		}
	}

	public void ReportSelectedBindingCleared(ControlType controlType)
	{
		if (currentOptionRef != null)
		{
			currentOptionRef.ReportBindingCleared(controlType);
		}
	}

	public bool OnBindingFound(PlayerAction playerAction, BindingSource source)
	{
		if (playerAction.Name == ControlCommandToString(ControlCommand.INTERACT))
		{
			if (GameControls.actions.Cancel.FindBinding(source) != null || GameControls.actions.CloseMenu.FindBinding(source) != null)
			{
				return false;
			}
		}
		else if ((playerAction.Name == ControlCommandToString(ControlCommand.CANCEL) || playerAction.Name == ControlCommandToString(ControlCommand.CLOSE_MENU)) && GameControls.actions.Interact.FindBinding(source) != null)
		{
			return false;
		}
		return true;
	}

	public void OnBindingEnded(PlayerAction playerAction)
	{
		StopCurrentBinding();
		currentOptionRef = null;
		controlGUIRef.OnBindingEnded();
		GameControls.needsScrollValueCheck = true;
	}

	public void OnBindingRejected(PlayerAction playerAction, BindingSource bindingSource, BindingSourceRejectionType bindingSourceRejectionType)
	{
		if (bindingSourceRejectionType == BindingSourceRejectionType.IncorrectSourceType)
		{
			OnBindingEnded(playerAction);
			ResetBinding(currentControlCommandBeingMapped, currentSourceTypeBeingMapped);
		}
	}

	public bool IsCommandSetToDefaultMouseKeyboardBindings(ControlCommand command)
	{
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(ControlCommandToString(command));
		if (playerActionByName == null)
		{
			Debug.LogError("COMMAND NOT FOUND " + command);
			return false;
		}
		if (!playerActionByName.IsSetToDefaultBindings(BindingSourceType.MouseBindingSource))
		{
			return false;
		}
		if (!playerActionByName.IsSetToDefaultBindings(BindingSourceType.KeyBindingSource))
		{
			return false;
		}
		return true;
	}

	public bool IsCommandSetToDefaultGamepadBindings(ControlCommand command)
	{
		PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(ControlCommandToString(command));
		if (playerActionByName == null)
		{
			Debug.LogError("COMMAND NOT FOUND " + command);
			return false;
		}
		return playerActionByName.IsSetToDefaultBindings(BindingSourceType.DeviceBindingSource);
	}

	public void StopCurrentBinding()
	{
		if (!(currentOptionRef == null))
		{
			string actionName = ControlCommandToString(currentOptionRef.command);
			PlayerAction playerActionByName = GameControls.actions.GetPlayerActionByName(actionName);
			if (playerActionByName == null)
			{
				Debug.LogError("COMMAND NOT FOUND " + currentOptionRef.command);
				return;
			}
			playerActionByName.StopListeningForBinding();
			currentOptionRef = null;
		}
	}
}
