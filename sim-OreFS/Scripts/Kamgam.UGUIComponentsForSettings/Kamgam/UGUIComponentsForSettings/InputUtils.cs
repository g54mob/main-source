using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;

namespace Kamgam.UGUIComponentsForSettings
{
	public static class InputUtils
	{
		public static Key[] Keys;

		private static List<UniversalKeyCode> _tmpUniversalKeyResults = new List<UniversalKeyCode>();

		private static Dictionary<UniversalKeyCode, string> keyNameDictionary = new Dictionary<UniversalKeyCode, string>();

		private static List<(Key, UniversalKeyCode)> _inputSystemKeyMap = new List<(Key, UniversalKeyCode)>
		{
			(Key.None, UniversalKeyCode.None),
			(Key.Space, UniversalKeyCode.Space),
			(Key.Enter, UniversalKeyCode.Return),
			(Key.Tab, UniversalKeyCode.Tab),
			(Key.Backquote, UniversalKeyCode.BackQuote),
			(Key.Quote, UniversalKeyCode.Quote),
			(Key.Semicolon, UniversalKeyCode.Semicolon),
			(Key.Comma, UniversalKeyCode.Comma),
			(Key.Period, UniversalKeyCode.Period),
			(Key.Slash, UniversalKeyCode.Slash),
			(Key.Backslash, UniversalKeyCode.Backslash),
			(Key.LeftBracket, UniversalKeyCode.LeftBracket),
			(Key.RightBracket, UniversalKeyCode.RightBracket),
			(Key.Minus, UniversalKeyCode.Minus),
			(Key.Equals, UniversalKeyCode.Equals),
			(Key.A, UniversalKeyCode.A),
			(Key.B, UniversalKeyCode.B),
			(Key.C, UniversalKeyCode.C),
			(Key.D, UniversalKeyCode.D),
			(Key.E, UniversalKeyCode.E),
			(Key.F, UniversalKeyCode.F),
			(Key.G, UniversalKeyCode.G),
			(Key.H, UniversalKeyCode.H),
			(Key.I, UniversalKeyCode.I),
			(Key.J, UniversalKeyCode.J),
			(Key.K, UniversalKeyCode.K),
			(Key.L, UniversalKeyCode.L),
			(Key.M, UniversalKeyCode.M),
			(Key.N, UniversalKeyCode.N),
			(Key.O, UniversalKeyCode.O),
			(Key.P, UniversalKeyCode.P),
			(Key.Q, UniversalKeyCode.Q),
			(Key.R, UniversalKeyCode.R),
			(Key.S, UniversalKeyCode.S),
			(Key.T, UniversalKeyCode.T),
			(Key.U, UniversalKeyCode.U),
			(Key.V, UniversalKeyCode.V),
			(Key.W, UniversalKeyCode.W),
			(Key.X, UniversalKeyCode.X),
			(Key.Y, UniversalKeyCode.Y),
			(Key.Z, UniversalKeyCode.Z),
			(Key.Digit0, UniversalKeyCode.Digit0),
			(Key.Digit1, UniversalKeyCode.Digit1),
			(Key.Digit2, UniversalKeyCode.Digit2),
			(Key.Digit3, UniversalKeyCode.Digit3),
			(Key.Digit4, UniversalKeyCode.Digit4),
			(Key.Digit5, UniversalKeyCode.Digit5),
			(Key.Digit6, UniversalKeyCode.Digit6),
			(Key.Digit7, UniversalKeyCode.Digit7),
			(Key.Digit8, UniversalKeyCode.Digit8),
			(Key.Digit9, UniversalKeyCode.Digit9),
			(Key.LeftShift, UniversalKeyCode.LeftShift),
			(Key.RightShift, UniversalKeyCode.RightShift),
			(Key.LeftAlt, UniversalKeyCode.LeftAlt),
			(Key.RightAlt, UniversalKeyCode.RightAlt),
			(Key.LeftCtrl, UniversalKeyCode.LeftControl),
			(Key.RightCtrl, UniversalKeyCode.RightControl),
			(Key.LeftMeta, UniversalKeyCode.LeftCommand),
			(Key.RightMeta, UniversalKeyCode.RightCommand),
			(Key.ContextMenu, UniversalKeyCode.Menu),
			(Key.Escape, UniversalKeyCode.Escape),
			(Key.LeftArrow, UniversalKeyCode.LeftArrow),
			(Key.RightArrow, UniversalKeyCode.RightArrow),
			(Key.UpArrow, UniversalKeyCode.UpArrow),
			(Key.DownArrow, UniversalKeyCode.DownArrow),
			(Key.Backspace, UniversalKeyCode.Backspace),
			(Key.PageDown, UniversalKeyCode.PageDown),
			(Key.PageUp, UniversalKeyCode.PageUp),
			(Key.Home, UniversalKeyCode.Home),
			(Key.End, UniversalKeyCode.End),
			(Key.Insert, UniversalKeyCode.Insert),
			(Key.Delete, UniversalKeyCode.Delete),
			(Key.CapsLock, UniversalKeyCode.CapsLock),
			(Key.NumLock, UniversalKeyCode.NumLock),
			(Key.PrintScreen, UniversalKeyCode.Print),
			(Key.ScrollLock, UniversalKeyCode.ScrollLock),
			(Key.Pause, UniversalKeyCode.Pause),
			(Key.NumpadEnter, UniversalKeyCode.NumpadEnter),
			(Key.NumpadDivide, UniversalKeyCode.NumpadDivide),
			(Key.NumpadMultiply, UniversalKeyCode.NumpadMultiply),
			(Key.NumpadPlus, UniversalKeyCode.NumpadPlus),
			(Key.NumpadMinus, UniversalKeyCode.NumpadMinus),
			(Key.NumpadPeriod, UniversalKeyCode.NumpadPeriod),
			(Key.NumpadEquals, UniversalKeyCode.NumpadEquals),
			(Key.Numpad0, UniversalKeyCode.Numpad0),
			(Key.Numpad1, UniversalKeyCode.Numpad1),
			(Key.Numpad2, UniversalKeyCode.Numpad2),
			(Key.Numpad3, UniversalKeyCode.Numpad3),
			(Key.Numpad4, UniversalKeyCode.Numpad4),
			(Key.Numpad5, UniversalKeyCode.Numpad5),
			(Key.Numpad6, UniversalKeyCode.Numpad6),
			(Key.Numpad7, UniversalKeyCode.Numpad7),
			(Key.Numpad8, UniversalKeyCode.Numpad8),
			(Key.Numpad9, UniversalKeyCode.Numpad9),
			(Key.F1, UniversalKeyCode.F1),
			(Key.F2, UniversalKeyCode.F2),
			(Key.F3, UniversalKeyCode.F3),
			(Key.F4, UniversalKeyCode.F4),
			(Key.F5, UniversalKeyCode.F5),
			(Key.F6, UniversalKeyCode.F6),
			(Key.F7, UniversalKeyCode.F7),
			(Key.F8, UniversalKeyCode.F8),
			(Key.F9, UniversalKeyCode.F9),
			(Key.F10, UniversalKeyCode.F10),
			(Key.F11, UniversalKeyCode.F11),
			(Key.F12, UniversalKeyCode.F12),
			(Key.OEM1, UniversalKeyCode.Unknown),
			(Key.OEM2, UniversalKeyCode.Unknown),
			(Key.OEM3, UniversalKeyCode.Unknown),
			(Key.OEM4, UniversalKeyCode.Unknown),
			(Key.OEM5, UniversalKeyCode.Unknown),
			(Key.IMESelected, UniversalKeyCode.Unknown)
		};

		public static bool IsGamePadKey(UniversalKeyCode keyCode)
		{
			return keyCode switch
			{
				UniversalKeyCode.JoystickButton0 => true, 
				UniversalKeyCode.JoystickButton1 => true, 
				UniversalKeyCode.JoystickButton2 => true, 
				UniversalKeyCode.JoystickButton3 => true, 
				UniversalKeyCode.JoystickButton4 => true, 
				UniversalKeyCode.JoystickButton5 => true, 
				UniversalKeyCode.JoystickButton6 => true, 
				UniversalKeyCode.JoystickButton7 => true, 
				UniversalKeyCode.JoystickButton8 => true, 
				UniversalKeyCode.JoystickButton9 => true, 
				UniversalKeyCode.JoystickButton10 => true, 
				UniversalKeyCode.JoystickButton11 => true, 
				UniversalKeyCode.JoystickButton12 => true, 
				UniversalKeyCode.JoystickButton13 => true, 
				UniversalKeyCode.JoystickButton14 => true, 
				UniversalKeyCode.JoystickButton15 => true, 
				UniversalKeyCode.JoystickButton16 => true, 
				UniversalKeyCode.JoystickButton17 => true, 
				UniversalKeyCode.JoystickButton18 => true, 
				UniversalKeyCode.JoystickButton19 => true, 
				UniversalKeyCode.GamePadNorth => true, 
				UniversalKeyCode.GamePadSouth => true, 
				UniversalKeyCode.GamePadWest => true, 
				UniversalKeyCode.GamePadEast => true, 
				UniversalKeyCode.GamePadStart => true, 
				UniversalKeyCode.GamePadSelect => true, 
				UniversalKeyCode.GamePadLeftShoulder => true, 
				UniversalKeyCode.GamePadRightShoulder => true, 
				UniversalKeyCode.GamePadLeftTrigger => true, 
				UniversalKeyCode.GamePadRightTrigger => true, 
				UniversalKeyCode.GamePadDPadUp => true, 
				UniversalKeyCode.GamePadDPadDown => true, 
				UniversalKeyCode.GamePadDPadLeft => true, 
				UniversalKeyCode.GamePadDPadRight => true, 
				UniversalKeyCode.GamePadLeftStickButton => true, 
				UniversalKeyCode.GamePadRightStickButton => true, 
				UniversalKeyCode.GamePadLeftStickUp => true, 
				UniversalKeyCode.GamePadLeftStickDown => true, 
				UniversalKeyCode.GamePadLeftStickLeft => true, 
				UniversalKeyCode.GamePadLeftStickRight => true, 
				UniversalKeyCode.GamePadRightStickUp => true, 
				UniversalKeyCode.GamePadRightStickDown => true, 
				UniversalKeyCode.GamePadRightStickLeft => true, 
				UniversalKeyCode.GamePadRightStickRight => true, 
				_ => false, 
			};
		}

		public static UniversalKeyCode KeyCodeToUniversalKeyCode(KeyCode keyCode)
		{
			return KeyCodeToUniversalKeyCode(keyCode, convertJoyStickToGamePad: true);
		}

		public static UniversalKeyCode KeyCodeToUniversalKeyCode(KeyCode keyCode, bool convertJoyStickToGamePad)
		{
			switch (keyCode)
			{
			case KeyCode.None:
				return UniversalKeyCode.None;
			case KeyCode.Backspace:
				return UniversalKeyCode.Backspace;
			case KeyCode.Delete:
				return UniversalKeyCode.Delete;
			case KeyCode.Tab:
				return UniversalKeyCode.Tab;
			case KeyCode.Clear:
				return UniversalKeyCode.Clear;
			case KeyCode.Return:
				return UniversalKeyCode.Return;
			case KeyCode.Pause:
				return UniversalKeyCode.Pause;
			case KeyCode.Escape:
				return UniversalKeyCode.Escape;
			case KeyCode.Space:
				return UniversalKeyCode.Space;
			case KeyCode.Keypad0:
				return UniversalKeyCode.Numpad0;
			case KeyCode.Keypad1:
				return UniversalKeyCode.Numpad1;
			case KeyCode.Keypad2:
				return UniversalKeyCode.Numpad2;
			case KeyCode.Keypad3:
				return UniversalKeyCode.Numpad3;
			case KeyCode.Keypad4:
				return UniversalKeyCode.Numpad4;
			case KeyCode.Keypad5:
				return UniversalKeyCode.Numpad5;
			case KeyCode.Keypad6:
				return UniversalKeyCode.Numpad6;
			case KeyCode.Keypad7:
				return UniversalKeyCode.Numpad7;
			case KeyCode.Keypad8:
				return UniversalKeyCode.Numpad8;
			case KeyCode.Keypad9:
				return UniversalKeyCode.Numpad9;
			case KeyCode.KeypadPeriod:
				return UniversalKeyCode.NumpadPeriod;
			case KeyCode.KeypadDivide:
				return UniversalKeyCode.NumpadDivide;
			case KeyCode.KeypadMultiply:
				return UniversalKeyCode.NumpadMultiply;
			case KeyCode.KeypadMinus:
				return UniversalKeyCode.NumpadMinus;
			case KeyCode.KeypadPlus:
				return UniversalKeyCode.NumpadPlus;
			case KeyCode.KeypadEnter:
				return UniversalKeyCode.NumpadEnter;
			case KeyCode.KeypadEquals:
				return UniversalKeyCode.NumpadEquals;
			case KeyCode.UpArrow:
				return UniversalKeyCode.UpArrow;
			case KeyCode.DownArrow:
				return UniversalKeyCode.DownArrow;
			case KeyCode.RightArrow:
				return UniversalKeyCode.RightArrow;
			case KeyCode.LeftArrow:
				return UniversalKeyCode.LeftArrow;
			case KeyCode.Insert:
				return UniversalKeyCode.Insert;
			case KeyCode.Home:
				return UniversalKeyCode.Home;
			case KeyCode.End:
				return UniversalKeyCode.End;
			case KeyCode.PageUp:
				return UniversalKeyCode.PageUp;
			case KeyCode.PageDown:
				return UniversalKeyCode.PageDown;
			case KeyCode.F1:
				return UniversalKeyCode.F1;
			case KeyCode.F2:
				return UniversalKeyCode.F2;
			case KeyCode.F3:
				return UniversalKeyCode.F3;
			case KeyCode.F4:
				return UniversalKeyCode.F4;
			case KeyCode.F5:
				return UniversalKeyCode.F5;
			case KeyCode.F6:
				return UniversalKeyCode.F6;
			case KeyCode.F7:
				return UniversalKeyCode.F7;
			case KeyCode.F8:
				return UniversalKeyCode.F8;
			case KeyCode.F9:
				return UniversalKeyCode.F9;
			case KeyCode.F10:
				return UniversalKeyCode.F10;
			case KeyCode.F11:
				return UniversalKeyCode.F11;
			case KeyCode.F12:
				return UniversalKeyCode.F12;
			case KeyCode.F13:
				return UniversalKeyCode.Unknown;
			case KeyCode.F14:
				return UniversalKeyCode.Unknown;
			case KeyCode.F15:
				return UniversalKeyCode.Unknown;
			case KeyCode.Alpha0:
				return UniversalKeyCode.Digit0;
			case KeyCode.Alpha1:
				return UniversalKeyCode.Digit1;
			case KeyCode.Alpha2:
				return UniversalKeyCode.Digit2;
			case KeyCode.Alpha3:
				return UniversalKeyCode.Digit3;
			case KeyCode.Alpha4:
				return UniversalKeyCode.Digit4;
			case KeyCode.Alpha5:
				return UniversalKeyCode.Digit5;
			case KeyCode.Alpha6:
				return UniversalKeyCode.Digit6;
			case KeyCode.Alpha7:
				return UniversalKeyCode.Digit7;
			case KeyCode.Alpha8:
				return UniversalKeyCode.Digit8;
			case KeyCode.Alpha9:
				return UniversalKeyCode.Digit9;
			case KeyCode.Exclaim:
				return UniversalKeyCode.Unknown;
			case KeyCode.DoubleQuote:
				return UniversalKeyCode.Unknown;
			case KeyCode.Hash:
				return UniversalKeyCode.Unknown;
			case KeyCode.Dollar:
				return UniversalKeyCode.Unknown;
			case KeyCode.Percent:
				return UniversalKeyCode.Unknown;
			case KeyCode.Ampersand:
				return UniversalKeyCode.Unknown;
			case KeyCode.Quote:
				return UniversalKeyCode.Quote;
			case KeyCode.LeftParen:
				return UniversalKeyCode.Unknown;
			case KeyCode.RightParen:
				return UniversalKeyCode.Unknown;
			case KeyCode.Asterisk:
				return UniversalKeyCode.Unknown;
			case KeyCode.Plus:
				return UniversalKeyCode.Plus;
			case KeyCode.Comma:
				return UniversalKeyCode.Comma;
			case KeyCode.Minus:
				return UniversalKeyCode.Minus;
			case KeyCode.Period:
				return UniversalKeyCode.Period;
			case KeyCode.Slash:
				return UniversalKeyCode.Slash;
			case KeyCode.Colon:
				return UniversalKeyCode.Unknown;
			case KeyCode.Semicolon:
				return UniversalKeyCode.Semicolon;
			case KeyCode.Less:
				return UniversalKeyCode.None;
			case KeyCode.Equals:
				return UniversalKeyCode.Equals;
			case KeyCode.Greater:
				return UniversalKeyCode.Unknown;
			case KeyCode.Question:
				return UniversalKeyCode.Unknown;
			case KeyCode.At:
				return UniversalKeyCode.Unknown;
			case KeyCode.LeftBracket:
				return UniversalKeyCode.LeftBracket;
			case KeyCode.Backslash:
				return UniversalKeyCode.Backslash;
			case KeyCode.RightBracket:
				return UniversalKeyCode.RightBracket;
			case KeyCode.Caret:
				return UniversalKeyCode.None;
			case KeyCode.Underscore:
				return UniversalKeyCode.Unknown;
			case KeyCode.BackQuote:
				return UniversalKeyCode.Unknown;
			case KeyCode.A:
				return UniversalKeyCode.A;
			case KeyCode.B:
				return UniversalKeyCode.B;
			case KeyCode.C:
				return UniversalKeyCode.C;
			case KeyCode.D:
				return UniversalKeyCode.D;
			case KeyCode.E:
				return UniversalKeyCode.E;
			case KeyCode.F:
				return UniversalKeyCode.F;
			case KeyCode.G:
				return UniversalKeyCode.G;
			case KeyCode.H:
				return UniversalKeyCode.H;
			case KeyCode.I:
				return UniversalKeyCode.I;
			case KeyCode.J:
				return UniversalKeyCode.J;
			case KeyCode.K:
				return UniversalKeyCode.K;
			case KeyCode.L:
				return UniversalKeyCode.L;
			case KeyCode.M:
				return UniversalKeyCode.M;
			case KeyCode.N:
				return UniversalKeyCode.N;
			case KeyCode.O:
				return UniversalKeyCode.O;
			case KeyCode.P:
				return UniversalKeyCode.P;
			case KeyCode.Q:
				return UniversalKeyCode.Q;
			case KeyCode.R:
				return UniversalKeyCode.R;
			case KeyCode.S:
				return UniversalKeyCode.S;
			case KeyCode.T:
				return UniversalKeyCode.T;
			case KeyCode.U:
				return UniversalKeyCode.U;
			case KeyCode.V:
				return UniversalKeyCode.V;
			case KeyCode.W:
				return UniversalKeyCode.W;
			case KeyCode.X:
				return UniversalKeyCode.X;
			case KeyCode.Y:
				return UniversalKeyCode.Y;
			case KeyCode.Z:
				return UniversalKeyCode.Z;
			case KeyCode.LeftCurlyBracket:
				return UniversalKeyCode.Unknown;
			case KeyCode.Pipe:
				return UniversalKeyCode.Unknown;
			case KeyCode.RightCurlyBracket:
				return UniversalKeyCode.Unknown;
			case KeyCode.Tilde:
				return UniversalKeyCode.Unknown;
			case KeyCode.Numlock:
				return UniversalKeyCode.NumLock;
			case KeyCode.CapsLock:
				return UniversalKeyCode.CapsLock;
			case KeyCode.ScrollLock:
				return UniversalKeyCode.ScrollLock;
			case KeyCode.RightShift:
				return UniversalKeyCode.RightShift;
			case KeyCode.LeftShift:
				return UniversalKeyCode.LeftShift;
			case KeyCode.RightControl:
				return UniversalKeyCode.RightControl;
			case KeyCode.LeftControl:
				return UniversalKeyCode.LeftControl;
			case KeyCode.RightAlt:
				return UniversalKeyCode.RightAlt;
			case KeyCode.LeftAlt:
				return UniversalKeyCode.LeftAlt;
			case KeyCode.LeftMeta:
				return UniversalKeyCode.LeftCommand;
			case KeyCode.LeftWindows:
				return UniversalKeyCode.LeftWindows;
			case KeyCode.RightMeta:
				return UniversalKeyCode.RightCommand;
			case KeyCode.RightWindows:
				return UniversalKeyCode.RightWindows;
			case KeyCode.AltGr:
				return UniversalKeyCode.AltGr;
			case KeyCode.Help:
				return UniversalKeyCode.Unknown;
			case KeyCode.Print:
				return UniversalKeyCode.Print;
			case KeyCode.SysReq:
				return UniversalKeyCode.Unknown;
			case KeyCode.Break:
				return UniversalKeyCode.Unknown;
			case KeyCode.Menu:
				return UniversalKeyCode.Menu;
			case KeyCode.Mouse0:
				return UniversalKeyCode.MouseLeft;
			case KeyCode.Mouse1:
				return UniversalKeyCode.MouseMiddle;
			case KeyCode.Mouse2:
				return UniversalKeyCode.MouseRight;
			case KeyCode.Mouse3:
				return UniversalKeyCode.MouseBack;
			case KeyCode.Mouse4:
				return UniversalKeyCode.MouseForward;
			default:
				if (convertJoyStickToGamePad)
				{
					switch (keyCode)
					{
					case KeyCode.JoystickButton0:
						return UniversalKeyCode.GamePadSouth;
					case KeyCode.JoystickButton1:
						return UniversalKeyCode.GamePadEast;
					case KeyCode.JoystickButton2:
						return UniversalKeyCode.GamePadWest;
					case KeyCode.JoystickButton3:
						return UniversalKeyCode.GamePadNorth;
					case KeyCode.JoystickButton4:
						return UniversalKeyCode.GamePadLeftShoulder;
					case KeyCode.JoystickButton5:
						return UniversalKeyCode.GamePadRightShoulder;
					case KeyCode.JoystickButton6:
						return UniversalKeyCode.GamePadSelect;
					case KeyCode.JoystickButton7:
						return UniversalKeyCode.GamePadStart;
					case KeyCode.JoystickButton8:
						return UniversalKeyCode.GamePadLeftStickButton;
					case KeyCode.JoystickButton9:
						return UniversalKeyCode.GamePadRightStickButton;
					case KeyCode.JoystickButton10:
						return UniversalKeyCode.JoystickButton10;
					}
				}
				else
				{
					switch (keyCode)
					{
					case KeyCode.JoystickButton0:
						return UniversalKeyCode.JoystickButton0;
					case KeyCode.JoystickButton1:
						return UniversalKeyCode.JoystickButton1;
					case KeyCode.JoystickButton2:
						return UniversalKeyCode.JoystickButton2;
					case KeyCode.JoystickButton3:
						return UniversalKeyCode.JoystickButton3;
					case KeyCode.JoystickButton4:
						return UniversalKeyCode.JoystickButton4;
					case KeyCode.JoystickButton5:
						return UniversalKeyCode.JoystickButton5;
					case KeyCode.JoystickButton6:
						return UniversalKeyCode.JoystickButton6;
					case KeyCode.JoystickButton7:
						return UniversalKeyCode.JoystickButton7;
					case KeyCode.JoystickButton8:
						return UniversalKeyCode.JoystickButton8;
					case KeyCode.JoystickButton9:
						return UniversalKeyCode.JoystickButton9;
					case KeyCode.JoystickButton10:
						return UniversalKeyCode.JoystickButton10;
					}
				}
				return UniversalKeyCode.Unknown;
			}
		}

		public static KeyCode UniversalKeyCodeToKeyCode(UniversalKeyCode universalKeyCode)
		{
			switch (universalKeyCode)
			{
			case UniversalKeyCode.None:
				return KeyCode.None;
			case UniversalKeyCode.Backspace:
				return KeyCode.Backspace;
			case UniversalKeyCode.Delete:
				return KeyCode.Delete;
			case UniversalKeyCode.Tab:
				return KeyCode.Tab;
			case UniversalKeyCode.Clear:
				return KeyCode.Clear;
			case UniversalKeyCode.Return:
				return KeyCode.Return;
			case UniversalKeyCode.Pause:
				return KeyCode.Pause;
			case UniversalKeyCode.Escape:
				return KeyCode.Escape;
			case UniversalKeyCode.Space:
				return KeyCode.Space;
			case UniversalKeyCode.Numpad0:
				return KeyCode.Keypad0;
			case UniversalKeyCode.Numpad1:
				return KeyCode.Keypad1;
			case UniversalKeyCode.Numpad2:
				return KeyCode.Keypad2;
			case UniversalKeyCode.Numpad3:
				return KeyCode.Keypad3;
			case UniversalKeyCode.Numpad4:
				return KeyCode.Keypad4;
			case UniversalKeyCode.Numpad5:
				return KeyCode.Keypad5;
			case UniversalKeyCode.Numpad6:
				return KeyCode.Keypad6;
			case UniversalKeyCode.Numpad7:
				return KeyCode.Keypad7;
			case UniversalKeyCode.Numpad8:
				return KeyCode.Keypad8;
			case UniversalKeyCode.Numpad9:
				return KeyCode.Keypad9;
			case UniversalKeyCode.NumpadPeriod:
				return KeyCode.KeypadPeriod;
			case UniversalKeyCode.NumpadDivide:
				return KeyCode.KeypadDivide;
			case UniversalKeyCode.NumpadMultiply:
				return KeyCode.KeypadMultiply;
			case UniversalKeyCode.NumpadMinus:
				return KeyCode.KeypadMinus;
			case UniversalKeyCode.NumpadPlus:
				return KeyCode.KeypadPlus;
			case UniversalKeyCode.NumpadEnter:
				return KeyCode.KeypadEnter;
			case UniversalKeyCode.NumpadEquals:
				return KeyCode.KeypadEquals;
			case UniversalKeyCode.UpArrow:
				return KeyCode.UpArrow;
			case UniversalKeyCode.DownArrow:
				return KeyCode.DownArrow;
			case UniversalKeyCode.RightArrow:
				return KeyCode.RightArrow;
			case UniversalKeyCode.LeftArrow:
				return KeyCode.LeftArrow;
			case UniversalKeyCode.Insert:
				return KeyCode.Insert;
			case UniversalKeyCode.Home:
				return KeyCode.Home;
			case UniversalKeyCode.End:
				return KeyCode.End;
			case UniversalKeyCode.PageUp:
				return KeyCode.PageUp;
			case UniversalKeyCode.PageDown:
				return KeyCode.PageDown;
			case UniversalKeyCode.F1:
				return KeyCode.F1;
			case UniversalKeyCode.F2:
				return KeyCode.F2;
			case UniversalKeyCode.F3:
				return KeyCode.F3;
			case UniversalKeyCode.F4:
				return KeyCode.F4;
			case UniversalKeyCode.F5:
				return KeyCode.F5;
			case UniversalKeyCode.F6:
				return KeyCode.F6;
			case UniversalKeyCode.F7:
				return KeyCode.F7;
			case UniversalKeyCode.F8:
				return KeyCode.F8;
			case UniversalKeyCode.F9:
				return KeyCode.F9;
			case UniversalKeyCode.F10:
				return KeyCode.F10;
			case UniversalKeyCode.F11:
				return KeyCode.F11;
			case UniversalKeyCode.F12:
				return KeyCode.F12;
			case UniversalKeyCode.Digit0:
				return KeyCode.Alpha0;
			case UniversalKeyCode.Digit1:
				return KeyCode.Alpha1;
			case UniversalKeyCode.Digit2:
				return KeyCode.Alpha2;
			case UniversalKeyCode.Digit3:
				return KeyCode.Alpha3;
			case UniversalKeyCode.Digit4:
				return KeyCode.Alpha4;
			case UniversalKeyCode.Digit5:
				return KeyCode.Alpha5;
			case UniversalKeyCode.Digit6:
				return KeyCode.Alpha6;
			case UniversalKeyCode.Digit7:
				return KeyCode.Alpha7;
			case UniversalKeyCode.Digit8:
				return KeyCode.Alpha8;
			case UniversalKeyCode.Digit9:
				return KeyCode.Alpha9;
			case UniversalKeyCode.Quote:
				return KeyCode.Quote;
			case UniversalKeyCode.Plus:
				return KeyCode.Plus;
			case UniversalKeyCode.Comma:
				return KeyCode.Comma;
			case UniversalKeyCode.Minus:
				return KeyCode.Minus;
			case UniversalKeyCode.Period:
				return KeyCode.Period;
			case UniversalKeyCode.Slash:
				return KeyCode.Slash;
			case UniversalKeyCode.Unknown:
			case UniversalKeyCode.Semicolon:
				return KeyCode.Semicolon;
			case UniversalKeyCode.Less:
				return KeyCode.Less;
			case UniversalKeyCode.Equals:
				return KeyCode.Equals;
			case UniversalKeyCode.LeftBracket:
				return KeyCode.LeftBracket;
			case UniversalKeyCode.Backslash:
				return KeyCode.Backslash;
			case UniversalKeyCode.RightBracket:
				return KeyCode.RightBracket;
			case UniversalKeyCode.A:
				return KeyCode.A;
			case UniversalKeyCode.B:
				return KeyCode.B;
			case UniversalKeyCode.C:
				return KeyCode.C;
			case UniversalKeyCode.D:
				return KeyCode.D;
			case UniversalKeyCode.E:
				return KeyCode.E;
			case UniversalKeyCode.F:
				return KeyCode.F;
			case UniversalKeyCode.G:
				return KeyCode.G;
			case UniversalKeyCode.H:
				return KeyCode.H;
			case UniversalKeyCode.I:
				return KeyCode.I;
			case UniversalKeyCode.J:
				return KeyCode.J;
			case UniversalKeyCode.K:
				return KeyCode.K;
			case UniversalKeyCode.L:
				return KeyCode.L;
			case UniversalKeyCode.M:
				return KeyCode.M;
			case UniversalKeyCode.N:
				return KeyCode.N;
			case UniversalKeyCode.O:
				return KeyCode.O;
			case UniversalKeyCode.P:
				return KeyCode.P;
			case UniversalKeyCode.Q:
				return KeyCode.Q;
			case UniversalKeyCode.R:
				return KeyCode.R;
			case UniversalKeyCode.S:
				return KeyCode.S;
			case UniversalKeyCode.T:
				return KeyCode.T;
			case UniversalKeyCode.U:
				return KeyCode.U;
			case UniversalKeyCode.V:
				return KeyCode.V;
			case UniversalKeyCode.W:
				return KeyCode.W;
			case UniversalKeyCode.X:
				return KeyCode.X;
			case UniversalKeyCode.Y:
				return KeyCode.Y;
			case UniversalKeyCode.Z:
				return KeyCode.Z;
			case UniversalKeyCode.NumLock:
				return KeyCode.Numlock;
			case UniversalKeyCode.CapsLock:
				return KeyCode.CapsLock;
			case UniversalKeyCode.ScrollLock:
				return KeyCode.ScrollLock;
			case UniversalKeyCode.RightShift:
				return KeyCode.RightShift;
			case UniversalKeyCode.LeftShift:
				return KeyCode.LeftShift;
			case UniversalKeyCode.RightControl:
				return KeyCode.RightControl;
			case UniversalKeyCode.LeftControl:
				return KeyCode.LeftControl;
			case UniversalKeyCode.RightAlt:
				return KeyCode.RightAlt;
			case UniversalKeyCode.LeftAlt:
				return KeyCode.LeftAlt;
			case UniversalKeyCode.LeftCommand:
				return KeyCode.LeftMeta;
			case UniversalKeyCode.LeftWindows:
				return KeyCode.LeftWindows;
			case UniversalKeyCode.RightCommand:
				return KeyCode.RightMeta;
			case UniversalKeyCode.RightWindows:
				return KeyCode.RightWindows;
			case UniversalKeyCode.AltGr:
				return KeyCode.AltGr;
			case UniversalKeyCode.Print:
				return KeyCode.Print;
			case UniversalKeyCode.Menu:
				return KeyCode.Menu;
			case UniversalKeyCode.MouseLeft:
				return KeyCode.Mouse0;
			case UniversalKeyCode.MouseMiddle:
				return KeyCode.Mouse1;
			case UniversalKeyCode.MouseRight:
				return KeyCode.Mouse2;
			case UniversalKeyCode.MouseBack:
				return KeyCode.Mouse3;
			case UniversalKeyCode.MouseForward:
				return KeyCode.Mouse4;
			case UniversalKeyCode.GamePadSouth:
				return KeyCode.JoystickButton0;
			case UniversalKeyCode.GamePadEast:
				return KeyCode.JoystickButton1;
			case UniversalKeyCode.GamePadWest:
				return KeyCode.JoystickButton2;
			case UniversalKeyCode.GamePadNorth:
				return KeyCode.JoystickButton3;
			case UniversalKeyCode.GamePadLeftShoulder:
				return KeyCode.JoystickButton4;
			case UniversalKeyCode.GamePadRightShoulder:
				return KeyCode.JoystickButton5;
			case UniversalKeyCode.GamePadSelect:
				return KeyCode.JoystickButton6;
			case UniversalKeyCode.GamePadStart:
				return KeyCode.JoystickButton7;
			case UniversalKeyCode.GamePadLeftStickButton:
				return KeyCode.JoystickButton8;
			case UniversalKeyCode.GamePadRightStickButton:
				return KeyCode.JoystickButton9;
			case UniversalKeyCode.JoystickButton0:
				return KeyCode.JoystickButton0;
			case UniversalKeyCode.JoystickButton1:
				return KeyCode.JoystickButton1;
			case UniversalKeyCode.JoystickButton2:
				return KeyCode.JoystickButton2;
			case UniversalKeyCode.JoystickButton3:
				return KeyCode.JoystickButton3;
			case UniversalKeyCode.JoystickButton4:
				return KeyCode.JoystickButton4;
			case UniversalKeyCode.JoystickButton5:
				return KeyCode.JoystickButton5;
			case UniversalKeyCode.JoystickButton6:
				return KeyCode.JoystickButton6;
			case UniversalKeyCode.JoystickButton7:
				return KeyCode.JoystickButton7;
			case UniversalKeyCode.JoystickButton8:
				return KeyCode.JoystickButton8;
			case UniversalKeyCode.JoystickButton9:
				return KeyCode.JoystickButton9;
			case UniversalKeyCode.JoystickButton10:
				return KeyCode.JoystickButton10;
			default:
				return KeyCode.None;
			}
		}

		private static void buildKeyCache()
		{
			if (Keys == null)
			{
				Keys = Keyboard.current.allKeys.Select((KeyControl k) => k.keyCode).ToArray();
			}
		}

		public static void ResetStuckKeyStates()
		{
			Keyboard.current.leftAltKey.QueueValueChange(0f);
			Keyboard.current.tabKey.QueueValueChange(0f);
		}

		public static bool AnyKey()
		{
			if (Mouse.current != null && (Mouse.current.leftButton.isPressed || Mouse.current.middleButton.isPressed || Mouse.current.rightButton.isPressed || Mouse.current.forwardButton.isPressed || Mouse.current.backButton.isPressed))
			{
				return true;
			}
			if (Keyboard.current != null && Keyboard.current.anyKey.isPressed)
			{
				return true;
			}
			if (Gamepad.current != null && (Gamepad.current.buttonSouth.isPressed || Gamepad.current.buttonEast.isPressed || Gamepad.current.buttonWest.isPressed || Gamepad.current.buttonNorth.isPressed || Gamepad.current.leftShoulder.isPressed || Gamepad.current.rightShoulder.isPressed || Gamepad.current.selectButton.isPressed || Gamepad.current.startButton.isPressed || Gamepad.current.leftStickButton.isPressed || Gamepad.current.leftStick.left.isPressed || Gamepad.current.leftStick.right.isPressed || Gamepad.current.leftStick.up.isPressed || Gamepad.current.leftStick.down.isPressed || Gamepad.current.rightStickButton.isPressed || Gamepad.current.rightStick.left.isPressed || Gamepad.current.rightStick.right.isPressed || Gamepad.current.rightStick.up.isPressed || Gamepad.current.rightStick.down.isPressed || Gamepad.current.leftTrigger.isPressed || Gamepad.current.rightTrigger.isPressed || Gamepad.current.dpad.left.isPressed || Gamepad.current.dpad.right.isPressed || Gamepad.current.dpad.up.isPressed || Gamepad.current.dpad.down.isPressed))
			{
				return true;
			}
			if (Joystick.current != null && Joystick.current.wasUpdatedThisFrame)
			{
				ReadOnlyArray<InputControl> allControls = Joystick.current.allControls;
				for (int i = 0; i < allControls.Count; i++)
				{
					if (allControls[i] is ButtonControl { isPressed: not false })
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool AnyKeyDown()
		{
			if (Mouse.current != null && (Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.middleButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame || Mouse.current.forwardButton.wasPressedThisFrame || Mouse.current.backButton.wasPressedThisFrame))
			{
				return true;
			}
			if (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && (Gamepad.current.buttonSouth.wasPressedThisFrame || Gamepad.current.buttonEast.wasPressedThisFrame || Gamepad.current.buttonWest.wasPressedThisFrame || Gamepad.current.buttonNorth.wasPressedThisFrame || Gamepad.current.leftShoulder.wasPressedThisFrame || Gamepad.current.rightShoulder.wasPressedThisFrame || Gamepad.current.selectButton.wasPressedThisFrame || Gamepad.current.startButton.wasPressedThisFrame || Gamepad.current.leftStickButton.wasPressedThisFrame || Gamepad.current.leftStick.left.wasPressedThisFrame || Gamepad.current.leftStick.right.wasPressedThisFrame || Gamepad.current.leftStick.up.wasPressedThisFrame || Gamepad.current.leftStick.down.wasPressedThisFrame || Gamepad.current.rightStickButton.wasPressedThisFrame || Gamepad.current.rightStick.left.wasPressedThisFrame || Gamepad.current.rightStick.right.wasPressedThisFrame || Gamepad.current.rightStick.up.wasPressedThisFrame || Gamepad.current.rightStick.down.wasPressedThisFrame || Gamepad.current.leftTrigger.wasPressedThisFrame || Gamepad.current.rightTrigger.wasPressedThisFrame || Gamepad.current.dpad.left.wasPressedThisFrame || Gamepad.current.dpad.right.wasPressedThisFrame || Gamepad.current.dpad.up.wasPressedThisFrame || Gamepad.current.dpad.down.wasPressedThisFrame))
			{
				return true;
			}
			if (Joystick.current != null && Joystick.current.wasUpdatedThisFrame)
			{
				ReadOnlyArray<InputControl> allControls = Joystick.current.allControls;
				for (int i = 0; i < allControls.Count; i++)
				{
					if (allControls[i] is ButtonControl { wasPressedThisFrame: not false })
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool MouseUp()
		{
			if (Mouse.current != null)
			{
				if (!Mouse.current.leftButton.wasReleasedThisFrame && !Mouse.current.middleButton.wasReleasedThisFrame && !Mouse.current.rightButton.wasReleasedThisFrame && !Mouse.current.forwardButton.wasReleasedThisFrame)
				{
					return Mouse.current.backButton.wasReleasedThisFrame;
				}
				return true;
			}
			return false;
		}

		public static bool SubmitDown()
		{
			if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
			{
				return true;
			}
			return false;
		}

		public static bool SubmitUp()
		{
			if (Keyboard.current != null && Keyboard.current.enterKey.wasReleasedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.buttonSouth.wasReleasedThisFrame)
			{
				return true;
			}
			return false;
		}

		public static bool CancelDown()
		{
			if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.selectButton.wasPressedThisFrame)
			{
				return true;
			}
			return false;
		}

		public static bool CancelUp()
		{
			if (Keyboard.current != null && Keyboard.current.escapeKey.wasReleasedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.selectButton.wasReleasedThisFrame)
			{
				return true;
			}
			return false;
		}

		public static bool AnyDirection()
		{
			if (Keyboard.current != null && (Keyboard.current.downArrowKey.isPressed || Keyboard.current.upArrowKey.isPressed || Keyboard.current.leftArrowKey.isPressed || Keyboard.current.rightArrowKey.isPressed))
			{
				return true;
			}
			if (Gamepad.current != null && (Gamepad.current.leftStick.left.isPressed || Gamepad.current.leftStick.right.isPressed || Gamepad.current.leftStick.up.isPressed || Gamepad.current.leftStick.down.isPressed))
			{
				return true;
			}
			return false;
		}

		public static bool UpPressed()
		{
			if (Keyboard.current != null && Keyboard.current.upArrowKey.wasPressedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.leftStick.up.wasPressedThisFrame)
			{
				return true;
			}
			return false;
		}

		public static bool DownPressed()
		{
			if (Keyboard.current != null && Keyboard.current.downArrowKey.wasPressedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.leftStick.down.wasPressedThisFrame)
			{
				return true;
			}
			return false;
		}

		public static bool LeftPressed()
		{
			if (Keyboard.current != null && Keyboard.current.leftArrowKey.wasPressedThisFrame)
			{
				return true;
			}
			if (Keyboard.current != null && Keyboard.current.aKey.wasPressedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.leftStick.left.wasPressedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.dpad.left.wasPressedThisFrame)
			{
				return true;
			}
			return false;
		}

		public static bool RightPressed()
		{
			if (Keyboard.current != null && Keyboard.current.rightArrowKey.wasPressedThisFrame)
			{
				return true;
			}
			if (Keyboard.current != null && Keyboard.current.dKey.wasPressedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.leftStick.right.wasPressedThisFrame)
			{
				return true;
			}
			if (Gamepad.current != null && Gamepad.current.dpad.right.wasPressedThisFrame)
			{
				return true;
			}
			return false;
		}

		public static bool LeftMouse()
		{
			if (Mouse.current != null)
			{
				if (!Mouse.current.leftButton.wasReleasedThisFrame && !Mouse.current.leftButton.wasPressedThisFrame)
				{
					return Mouse.current.leftButton.isPressed;
				}
				return true;
			}
			return false;
		}

		public static bool GetModifierKeyDown(UniversalKeyCode universalKeyCode)
		{
			_tmpUniversalKeyResults.Clear();
			GetModifierKeysDown(_tmpUniversalKeyResults);
			if (_tmpUniversalKeyResults.Count == 0)
			{
				return false;
			}
			return _tmpUniversalKeyResults.Contains(universalKeyCode);
		}

		public static UniversalKeyCode GetModifierKeyDown()
		{
			_tmpUniversalKeyResults.Clear();
			GetModifierKeysDown(_tmpUniversalKeyResults);
			if (_tmpUniversalKeyResults.Count == 0)
			{
				return UniversalKeyCode.None;
			}
			return _tmpUniversalKeyResults[0];
		}

		public static List<UniversalKeyCode> GetModifierKeysDown(List<UniversalKeyCode> results = null)
		{
			if (results == null)
			{
				results = new List<UniversalKeyCode>();
			}
			if (Keyboard.current[Key.LeftShift].wasPressedThisFrame)
			{
				results.Add(UniversalKeyCode.LeftShift);
			}
			if (Keyboard.current[Key.RightShift].wasPressedThisFrame)
			{
				results.Add(UniversalKeyCode.RightShift);
			}
			if (Keyboard.current[Key.Tab].wasPressedThisFrame)
			{
				results.Add(UniversalKeyCode.Tab);
			}
			if (Keyboard.current[Key.LeftCtrl].wasPressedThisFrame)
			{
				results.Add(UniversalKeyCode.LeftControl);
			}
			if (Keyboard.current[Key.RightCtrl].wasPressedThisFrame)
			{
				results.Add(UniversalKeyCode.RightControl);
			}
			if (Keyboard.current[Key.LeftMeta].wasPressedThisFrame)
			{
				results.Add(UniversalKeyCode.LeftCommand);
			}
			if (Keyboard.current[Key.RightMeta].wasPressedThisFrame)
			{
				results.Add(UniversalKeyCode.RightCommand);
			}
			if (Keyboard.current[Key.LeftAlt].wasPressedThisFrame)
			{
				results.Add(UniversalKeyCode.LeftAlt);
			}
			if (Keyboard.current[Key.RightAlt].wasPressedThisFrame)
			{
				results.Add(UniversalKeyCode.RightAlt);
			}
			return results;
		}

		public static bool GetUniversalKeyDown(UniversalKeyCode universalKeyCode)
		{
			_tmpUniversalKeyResults.Clear();
			GetUniversalKeysDown(excludeModifierKeys: false, excludeMouseButtons: false, _tmpUniversalKeyResults);
			if (_tmpUniversalKeyResults.Count == 0)
			{
				return false;
			}
			return _tmpUniversalKeyResults.Contains(universalKeyCode);
		}

		public static UniversalKeyCode GetUniversalKeyDown(bool excludeModifierKeys, bool excludeMouseButtons)
		{
			_tmpUniversalKeyResults.Clear();
			GetUniversalKeysDown(excludeModifierKeys: false, excludeMouseButtons: false, _tmpUniversalKeyResults);
			if (_tmpUniversalKeyResults.Count == 0)
			{
				return UniversalKeyCode.None;
			}
			return _tmpUniversalKeyResults[0];
		}

		public static List<UniversalKeyCode> GetUniversalKeysDown(bool excludeModifierKeys, bool excludeMouseButtons, List<UniversalKeyCode> results = null)
		{
			if (results == null)
			{
				results = new List<UniversalKeyCode>();
			}
			if (!excludeMouseButtons && Mouse.current != null)
			{
				if (Mouse.current.leftButton.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseLeft);
				}
				if (Mouse.current.middleButton.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseMiddle);
				}
				if (Mouse.current.rightButton.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseRight);
				}
				if (Mouse.current.backButton.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseBack);
				}
				if (Mouse.current.forwardButton.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseForward);
				}
			}
			if (Keyboard.current != null && Keyboard.current.wasUpdatedThisFrame)
			{
				buildKeyCache();
				foreach (KeyControl allKey in Keyboard.current.allKeys)
				{
					if ((!excludeModifierKeys || (allKey.keyCode != Key.LeftShift && allKey.keyCode != Key.RightShift && allKey.keyCode != Key.Tab && allKey.keyCode != Key.LeftCtrl && allKey.keyCode != Key.RightCtrl && allKey.keyCode != Key.LeftMeta && allKey.keyCode != Key.RightMeta && allKey.keyCode != Key.LeftAlt && allKey.keyCode != Key.RightAlt)) && allKey.wasPressedThisFrame)
					{
						UniversalKeyCode item = KeyToUniversalKeyCode(allKey.keyCode);
						results.Add(item);
					}
				}
			}
			if (Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame)
			{
				if (Gamepad.current.buttonSouth.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadSouth);
				}
				if (Gamepad.current.buttonEast.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadEast);
				}
				if (Gamepad.current.buttonWest.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadWest);
				}
				if (Gamepad.current.buttonNorth.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadNorth);
				}
				if (Gamepad.current.leftShoulder.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftShoulder);
				}
				if (Gamepad.current.rightShoulder.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightShoulder);
				}
				if (Gamepad.current.selectButton.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadSelect);
				}
				if (Gamepad.current.startButton.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadStart);
				}
				if (Gamepad.current.leftStickButton.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickButton);
				}
				if (Gamepad.current.leftStick.up.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickUp);
				}
				if (Gamepad.current.leftStick.down.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickDown);
				}
				if (Gamepad.current.leftStick.left.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickLeft);
				}
				if (Gamepad.current.leftStick.right.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickRight);
				}
				if (Gamepad.current.rightStickButton.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickButton);
				}
				if (Gamepad.current.rightStick.up.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickUp);
				}
				if (Gamepad.current.rightStick.down.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickDown);
				}
				if (Gamepad.current.rightStick.left.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickLeft);
				}
				if (Gamepad.current.rightStick.right.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickRight);
				}
				if (Gamepad.current.leftTrigger.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftTrigger);
				}
				if (Gamepad.current.rightTrigger.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightTrigger);
				}
				if (Gamepad.current.dpad.left.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadDPadLeft);
				}
				if (Gamepad.current.dpad.right.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadDPadRight);
				}
				if (Gamepad.current.dpad.up.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadDPadUp);
				}
				if (Gamepad.current.dpad.down.wasPressedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadDPadDown);
				}
			}
			if (Joystick.current != null && Joystick.current.wasUpdatedThisFrame)
			{
				ReadOnlyArray<InputControl> allControls = Joystick.current.allControls;
				for (int i = 0; i < allControls.Count; i++)
				{
					if (allControls[i] is ButtonControl { wasPressedThisFrame: not false })
					{
						if (i == 0)
						{
							results.Add(UniversalKeyCode.JoystickButton0);
						}
						if (i == 1)
						{
							results.Add(UniversalKeyCode.JoystickButton1);
						}
						if (i == 2)
						{
							results.Add(UniversalKeyCode.JoystickButton2);
						}
						if (i == 3)
						{
							results.Add(UniversalKeyCode.JoystickButton3);
						}
						if (i == 4)
						{
							results.Add(UniversalKeyCode.JoystickButton4);
						}
						if (i == 5)
						{
							results.Add(UniversalKeyCode.JoystickButton5);
						}
						if (i == 6)
						{
							results.Add(UniversalKeyCode.JoystickButton6);
						}
						if (i == 7)
						{
							results.Add(UniversalKeyCode.JoystickButton7);
						}
						if (i == 8)
						{
							results.Add(UniversalKeyCode.JoystickButton8);
						}
						if (i == 9)
						{
							results.Add(UniversalKeyCode.JoystickButton9);
						}
						if (i == 10)
						{
							results.Add(UniversalKeyCode.JoystickButton10);
						}
					}
				}
			}
			return results;
		}

		public static bool GetUniversalKeyUp(UniversalKeyCode universalKeyCode)
		{
			_tmpUniversalKeyResults.Clear();
			GetUniversalKeysUp(excludeModifierKeys: false, excludeMouseButtons: false, _tmpUniversalKeyResults);
			if (_tmpUniversalKeyResults.Count == 0)
			{
				return false;
			}
			return _tmpUniversalKeyResults.Contains(universalKeyCode);
		}

		public static UniversalKeyCode GetUniversalKeyUp(bool excludeModifierKeys, bool excludeMouseButtons, List<UniversalKeyCode> results = null)
		{
			_tmpUniversalKeyResults.Clear();
			GetUniversalKeysUp(excludeModifierKeys: false, excludeMouseButtons: false, _tmpUniversalKeyResults);
			if (_tmpUniversalKeyResults.Count == 0)
			{
				return UniversalKeyCode.None;
			}
			return _tmpUniversalKeyResults[0];
		}

		public static List<UniversalKeyCode> GetUniversalKeysUp(bool excludeModifierKeys, bool excludeMouseButtons, List<UniversalKeyCode> results = null)
		{
			if (results == null)
			{
				results = new List<UniversalKeyCode>();
			}
			if (!excludeMouseButtons && Mouse.current != null)
			{
				if (Mouse.current.leftButton.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseLeft);
				}
				if (Mouse.current.middleButton.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseMiddle);
				}
				if (Mouse.current.rightButton.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseRight);
				}
				if (Mouse.current.backButton.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseBack);
				}
				if (Mouse.current.forwardButton.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.MouseForward);
				}
			}
			if (Keyboard.current != null && Keyboard.current.wasUpdatedThisFrame)
			{
				buildKeyCache();
				Key[] keys = Keys;
				foreach (Key key in keys)
				{
					if ((!excludeModifierKeys || (!Keyboard.current[Key.LeftShift].wasReleasedThisFrame && !Keyboard.current[Key.RightShift].wasReleasedThisFrame && !Keyboard.current[Key.Tab].wasReleasedThisFrame && !Keyboard.current[Key.LeftCtrl].wasReleasedThisFrame && !Keyboard.current[Key.RightCtrl].wasReleasedThisFrame && !Keyboard.current[Key.LeftMeta].wasReleasedThisFrame && !Keyboard.current[Key.RightMeta].wasReleasedThisFrame && !Keyboard.current[Key.LeftAlt].wasReleasedThisFrame && !Keyboard.current[Key.RightAlt].wasReleasedThisFrame)) && Keyboard.current[key].wasReleasedThisFrame)
					{
						UniversalKeyCode item = KeyToUniversalKeyCode(key);
						results.Add(item);
					}
				}
			}
			if (Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame)
			{
				if (Gamepad.current.buttonSouth.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadSouth);
				}
				if (Gamepad.current.buttonEast.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadEast);
				}
				if (Gamepad.current.buttonWest.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadWest);
				}
				if (Gamepad.current.buttonNorth.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadNorth);
				}
				if (Gamepad.current.leftShoulder.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftShoulder);
				}
				if (Gamepad.current.rightShoulder.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightShoulder);
				}
				if (Gamepad.current.selectButton.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadSelect);
				}
				if (Gamepad.current.startButton.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadStart);
				}
				if (Gamepad.current.leftStickButton.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickButton);
				}
				if (Gamepad.current.leftStick.up.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickUp);
				}
				if (Gamepad.current.leftStick.down.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickDown);
				}
				if (Gamepad.current.leftStick.left.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickLeft);
				}
				if (Gamepad.current.leftStick.right.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickRight);
				}
				if (Gamepad.current.rightStickButton.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickButton);
				}
				if (Gamepad.current.rightStick.up.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickUp);
				}
				if (Gamepad.current.rightStick.down.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickDown);
				}
				if (Gamepad.current.rightStick.left.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickLeft);
				}
				if (Gamepad.current.rightStick.right.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightStickRight);
				}
				if (Gamepad.current.leftTrigger.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadLeftTrigger);
				}
				if (Gamepad.current.rightTrigger.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadRightTrigger);
				}
				if (Gamepad.current.dpad.left.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadDPadLeft);
				}
				if (Gamepad.current.dpad.right.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadDPadRight);
				}
				if (Gamepad.current.dpad.up.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadDPadUp);
				}
				if (Gamepad.current.dpad.down.wasReleasedThisFrame)
				{
					results.Add(UniversalKeyCode.GamePadDPadDown);
				}
			}
			if (Joystick.current != null && Joystick.current.wasUpdatedThisFrame)
			{
				ReadOnlyArray<InputControl> allControls = Joystick.current.allControls;
				for (int j = 0; j < allControls.Count; j++)
				{
					if (allControls[j] is ButtonControl { wasReleasedThisFrame: not false })
					{
						if (j == 0)
						{
							results.Add(UniversalKeyCode.JoystickButton0);
						}
						if (j == 1)
						{
							results.Add(UniversalKeyCode.JoystickButton1);
						}
						if (j == 2)
						{
							results.Add(UniversalKeyCode.JoystickButton2);
						}
						if (j == 3)
						{
							results.Add(UniversalKeyCode.JoystickButton3);
						}
						if (j == 4)
						{
							results.Add(UniversalKeyCode.JoystickButton4);
						}
						if (j == 5)
						{
							results.Add(UniversalKeyCode.JoystickButton5);
						}
						if (j == 6)
						{
							results.Add(UniversalKeyCode.JoystickButton6);
						}
						if (j == 7)
						{
							results.Add(UniversalKeyCode.JoystickButton7);
						}
						if (j == 8)
						{
							results.Add(UniversalKeyCode.JoystickButton8);
						}
						if (j == 9)
						{
							results.Add(UniversalKeyCode.JoystickButton9);
						}
						if (j == 10)
						{
							results.Add(UniversalKeyCode.JoystickButton10);
						}
					}
				}
			}
			return results;
		}

		public static bool GetUniversalKey(UniversalKeyCode universalKeyCode)
		{
			_tmpUniversalKeyResults.Clear();
			GetPressedUniversalKeys(excludeModifierKeys: false, excludeMouseButtons: false, _tmpUniversalKeyResults);
			if (_tmpUniversalKeyResults.Count == 0)
			{
				return false;
			}
			return _tmpUniversalKeyResults.Contains(universalKeyCode);
		}

		public static UniversalKeyCode GetPressedUniversalKey(bool excludeModifierKeys, bool excludeMouseButtons)
		{
			_tmpUniversalKeyResults.Clear();
			GetPressedUniversalKeys(excludeModifierKeys: false, excludeMouseButtons: false, _tmpUniversalKeyResults);
			if (_tmpUniversalKeyResults.Count == 0)
			{
				return UniversalKeyCode.None;
			}
			return _tmpUniversalKeyResults[0];
		}

		public static List<UniversalKeyCode> GetPressedUniversalKeys(bool excludeModifierKeys, bool excludeMouseButtons, List<UniversalKeyCode> results = null)
		{
			if (results == null)
			{
				results = new List<UniversalKeyCode>();
			}
			if (!excludeMouseButtons && Mouse.current != null)
			{
				if (Mouse.current.leftButton.isPressed)
				{
					results.Add(UniversalKeyCode.MouseLeft);
				}
				if (Mouse.current.middleButton.isPressed)
				{
					results.Add(UniversalKeyCode.MouseMiddle);
				}
				if (Mouse.current.rightButton.isPressed)
				{
					results.Add(UniversalKeyCode.MouseRight);
				}
				if (Mouse.current.backButton.isPressed)
				{
					results.Add(UniversalKeyCode.MouseBack);
				}
				if (Mouse.current.forwardButton.isPressed)
				{
					results.Add(UniversalKeyCode.MouseForward);
				}
			}
			if (Keyboard.current != null)
			{
				buildKeyCache();
				Key[] keys = Keys;
				foreach (Key key in keys)
				{
					if ((!excludeModifierKeys || (!Keyboard.current[Key.LeftShift].isPressed && !Keyboard.current[Key.RightShift].isPressed && !Keyboard.current[Key.Tab].isPressed && !Keyboard.current[Key.LeftCtrl].isPressed && !Keyboard.current[Key.RightCtrl].isPressed && !Keyboard.current[Key.LeftMeta].isPressed && !Keyboard.current[Key.RightMeta].isPressed && !Keyboard.current[Key.LeftAlt].isPressed && !Keyboard.current[Key.RightAlt].isPressed)) && Keyboard.current[key].isPressed)
					{
						UniversalKeyCode item = KeyToUniversalKeyCode(key);
						results.Add(item);
					}
				}
			}
			if (Gamepad.current != null)
			{
				if (Gamepad.current.buttonSouth.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadSouth);
				}
				if (Gamepad.current.buttonEast.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadEast);
				}
				if (Gamepad.current.buttonWest.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadWest);
				}
				if (Gamepad.current.buttonNorth.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadNorth);
				}
				if (Gamepad.current.leftShoulder.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadLeftShoulder);
				}
				if (Gamepad.current.rightShoulder.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadRightShoulder);
				}
				if (Gamepad.current.selectButton.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadSelect);
				}
				if (Gamepad.current.startButton.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadStart);
				}
				if (Gamepad.current.leftStickButton.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickButton);
				}
				if (Gamepad.current.leftStick.up.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickUp);
				}
				if (Gamepad.current.leftStick.down.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickDown);
				}
				if (Gamepad.current.leftStick.left.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickLeft);
				}
				if (Gamepad.current.leftStick.right.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadLeftStickRight);
				}
				if (Gamepad.current.rightStickButton.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadRightStickButton);
				}
				if (Gamepad.current.rightStick.up.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadRightStickUp);
				}
				if (Gamepad.current.rightStick.down.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadRightStickDown);
				}
				if (Gamepad.current.rightStick.left.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadRightStickLeft);
				}
				if (Gamepad.current.rightStick.right.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadRightStickRight);
				}
				if (Gamepad.current.leftTrigger.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadLeftTrigger);
				}
				if (Gamepad.current.rightTrigger.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadRightTrigger);
				}
				if (Gamepad.current.dpad.left.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadDPadLeft);
				}
				if (Gamepad.current.dpad.right.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadDPadRight);
				}
				if (Gamepad.current.dpad.up.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadDPadUp);
				}
				if (Gamepad.current.dpad.down.isPressed)
				{
					results.Add(UniversalKeyCode.GamePadDPadDown);
				}
			}
			if (Joystick.current != null)
			{
				ReadOnlyArray<InputControl> allControls = Joystick.current.allControls;
				for (int j = 0; j < allControls.Count; j++)
				{
					if (allControls[j] is ButtonControl { isPressed: not false })
					{
						if (j == 0)
						{
							results.Add(UniversalKeyCode.JoystickButton0);
						}
						if (j == 1)
						{
							results.Add(UniversalKeyCode.JoystickButton1);
						}
						if (j == 2)
						{
							results.Add(UniversalKeyCode.JoystickButton2);
						}
						if (j == 3)
						{
							results.Add(UniversalKeyCode.JoystickButton3);
						}
						if (j == 4)
						{
							results.Add(UniversalKeyCode.JoystickButton4);
						}
						if (j == 5)
						{
							results.Add(UniversalKeyCode.JoystickButton5);
						}
						if (j == 6)
						{
							results.Add(UniversalKeyCode.JoystickButton6);
						}
						if (j == 7)
						{
							results.Add(UniversalKeyCode.JoystickButton7);
						}
						if (j == 8)
						{
							results.Add(UniversalKeyCode.JoystickButton8);
						}
						if (j == 9)
						{
							results.Add(UniversalKeyCode.JoystickButton9);
						}
						if (j == 10)
						{
							results.Add(UniversalKeyCode.JoystickButton10);
						}
					}
				}
			}
			return results;
		}

		public static string UniversalKeyName(UniversalKeyCode keyCode)
		{
			if (keyNameDictionary.Count == 0)
			{
				keyNameDictionary.Add(UniversalKeyCode.None, "-");
				keyNameDictionary.Add(UniversalKeyCode.MouseLeft, "Left Mouse");
				keyNameDictionary.Add(UniversalKeyCode.MouseRight, "Right Mouse");
				keyNameDictionary.Add(UniversalKeyCode.MouseMiddle, "Middle Mouse");
				keyNameDictionary.Add(UniversalKeyCode.MouseBack, "Back Mouse");
				keyNameDictionary.Add(UniversalKeyCode.MouseForward, "Forward Mouse");
				keyNameDictionary.Add(UniversalKeyCode.Backspace, "Backspace");
				keyNameDictionary.Add(UniversalKeyCode.Tab, "Tab");
				keyNameDictionary.Add(UniversalKeyCode.Clear, "Clear");
				keyNameDictionary.Add(UniversalKeyCode.Return, "Return");
				keyNameDictionary.Add(UniversalKeyCode.Pause, "Pause");
				keyNameDictionary.Add(UniversalKeyCode.Escape, "Esc");
				keyNameDictionary.Add(UniversalKeyCode.Space, "Space");
				keyNameDictionary.Add(UniversalKeyCode.Exclaim, "!");
				keyNameDictionary.Add(UniversalKeyCode.DoubleQuote, "\"");
				keyNameDictionary.Add(UniversalKeyCode.Hash, "#");
				keyNameDictionary.Add(UniversalKeyCode.Dollar, "$");
				keyNameDictionary.Add(UniversalKeyCode.Percent, "%");
				keyNameDictionary.Add(UniversalKeyCode.Ampersand, "&");
				keyNameDictionary.Add(UniversalKeyCode.Quote, (Keyboard.current == null) ? "\"" : Keyboard.current.quoteKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.LeftParen, "(");
				keyNameDictionary.Add(UniversalKeyCode.RightParen, ")");
				keyNameDictionary.Add(UniversalKeyCode.Asterisk, "*");
				keyNameDictionary.Add(UniversalKeyCode.Plus, "+");
				keyNameDictionary.Add(UniversalKeyCode.Comma, (Keyboard.current == null) ? "," : Keyboard.current.commaKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Minus, (Keyboard.current == null) ? "-" : Keyboard.current.minusKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Period, (Keyboard.current == null) ? "." : Keyboard.current.periodKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Slash, (Keyboard.current == null) ? "/" : Keyboard.current.slashKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit0, (Keyboard.current == null) ? "0" : Keyboard.current.digit0Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit1, (Keyboard.current == null) ? "1" : Keyboard.current.digit1Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit2, (Keyboard.current == null) ? "2" : Keyboard.current.digit2Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit3, (Keyboard.current == null) ? "3" : Keyboard.current.digit3Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit4, (Keyboard.current == null) ? "4" : Keyboard.current.digit4Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit5, (Keyboard.current == null) ? "5" : Keyboard.current.digit5Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit6, (Keyboard.current == null) ? "6" : Keyboard.current.digit6Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit7, (Keyboard.current == null) ? "7" : Keyboard.current.digit7Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit8, (Keyboard.current == null) ? "8" : Keyboard.current.digit8Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Digit9, (Keyboard.current == null) ? "9" : Keyboard.current.digit9Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Colon, ":");
				keyNameDictionary.Add(UniversalKeyCode.Semicolon, (Keyboard.current == null) ? ";" : Keyboard.current.semicolonKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Less, "<");
				keyNameDictionary.Add(UniversalKeyCode.Equals, (Keyboard.current == null) ? "=" : Keyboard.current.equalsKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Greater, ">");
				keyNameDictionary.Add(UniversalKeyCode.Question, "?");
				keyNameDictionary.Add(UniversalKeyCode.At, "@");
				keyNameDictionary.Add(UniversalKeyCode.LeftBracket, (Keyboard.current == null) ? "(" : Keyboard.current.leftBracketKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Backslash, (Keyboard.current == null) ? "\\" : Keyboard.current.backslashKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.RightBracket, (Keyboard.current == null) ? ")" : Keyboard.current.rightBracketKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Caret, "^");
				keyNameDictionary.Add(UniversalKeyCode.Underscore, "_");
				keyNameDictionary.Add(UniversalKeyCode.BackQuote, (Keyboard.current == null) ? "\"" : Keyboard.current.backquoteKey.displayName);
				keyNameDictionary.Add(UniversalKeyCode.A, (Keyboard.current == null) ? "A" : Keyboard.current.aKey.name.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.B, (Keyboard.current == null) ? "B" : Keyboard.current.bKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.C, (Keyboard.current == null) ? "C" : Keyboard.current.cKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.D, (Keyboard.current == null) ? "D" : Keyboard.current.dKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.E, (Keyboard.current == null) ? "E" : Keyboard.current.eKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F, (Keyboard.current == null) ? "F" : Keyboard.current.fKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.G, (Keyboard.current == null) ? "G" : Keyboard.current.gKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.H, (Keyboard.current == null) ? "H" : Keyboard.current.hKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.I, (Keyboard.current == null) ? "I" : Keyboard.current.iKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.J, (Keyboard.current == null) ? "J" : Keyboard.current.jKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.K, (Keyboard.current == null) ? "K" : Keyboard.current.kKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.L, (Keyboard.current == null) ? "L" : Keyboard.current.lKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.M, (Keyboard.current == null) ? "M" : Keyboard.current.mKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.N, (Keyboard.current == null) ? "N" : Keyboard.current.nKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.O, (Keyboard.current == null) ? "O" : Keyboard.current.oKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.P, (Keyboard.current == null) ? "P" : Keyboard.current.pKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Q, (Keyboard.current == null) ? "Q" : Keyboard.current.qKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.R, (Keyboard.current == null) ? "R" : Keyboard.current.rKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.S, (Keyboard.current == null) ? "S" : Keyboard.current.sKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.T, (Keyboard.current == null) ? "T" : Keyboard.current.tKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.U, (Keyboard.current == null) ? "U" : Keyboard.current.uKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.V, (Keyboard.current == null) ? "V" : Keyboard.current.vKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.W, (Keyboard.current == null) ? "W" : Keyboard.current.wKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.X, (Keyboard.current == null) ? "X" : Keyboard.current.xKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Y, (Keyboard.current == null) ? "Y" : Keyboard.current.yKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Z, (Keyboard.current == null) ? "Z" : Keyboard.current.zKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.LeftCurlyBracket, "{");
				keyNameDictionary.Add(UniversalKeyCode.Pipe, "|");
				keyNameDictionary.Add(UniversalKeyCode.RightCurlyBracket, "}");
				keyNameDictionary.Add(UniversalKeyCode.Tilde, "~");
				keyNameDictionary.Add(UniversalKeyCode.Delete, (Keyboard.current == null) ? "Del" : Keyboard.current.deleteKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Numpad0, "0");
				keyNameDictionary.Add(UniversalKeyCode.Numpad1, "1");
				keyNameDictionary.Add(UniversalKeyCode.Numpad2, "2");
				keyNameDictionary.Add(UniversalKeyCode.Numpad3, "3");
				keyNameDictionary.Add(UniversalKeyCode.Numpad4, "4");
				keyNameDictionary.Add(UniversalKeyCode.Numpad5, "5");
				keyNameDictionary.Add(UniversalKeyCode.Numpad6, "6");
				keyNameDictionary.Add(UniversalKeyCode.Numpad7, "7");
				keyNameDictionary.Add(UniversalKeyCode.Numpad8, "8");
				keyNameDictionary.Add(UniversalKeyCode.Numpad9, "9");
				keyNameDictionary.Add(UniversalKeyCode.NumpadPeriod, ".");
				keyNameDictionary.Add(UniversalKeyCode.NumpadDivide, "/");
				keyNameDictionary.Add(UniversalKeyCode.NumpadMultiply, "*");
				keyNameDictionary.Add(UniversalKeyCode.NumpadMinus, "-");
				keyNameDictionary.Add(UniversalKeyCode.NumpadPlus, "+");
				keyNameDictionary.Add(UniversalKeyCode.NumpadEnter, "Enter");
				keyNameDictionary.Add(UniversalKeyCode.NumpadEquals, "=");
				keyNameDictionary.Add(UniversalKeyCode.UpArrow, "Up Arrow");
				keyNameDictionary.Add(UniversalKeyCode.DownArrow, "Down Arrow");
				keyNameDictionary.Add(UniversalKeyCode.RightArrow, "Right Arrow");
				keyNameDictionary.Add(UniversalKeyCode.LeftArrow, "Left Arrow");
				keyNameDictionary.Add(UniversalKeyCode.Insert, (Keyboard.current == null) ? "Ins" : Keyboard.current.insertKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.Home, "Home");
				keyNameDictionary.Add(UniversalKeyCode.End, "End");
				keyNameDictionary.Add(UniversalKeyCode.PageUp, (Keyboard.current == null) ? "PageUp" : Keyboard.current.pageUpKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.PageDown, (Keyboard.current == null) ? "PageDown" : Keyboard.current.pageDownKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F1, (Keyboard.current == null) ? "F1" : Keyboard.current.f1Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F2, (Keyboard.current == null) ? "F2" : Keyboard.current.f2Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F3, (Keyboard.current == null) ? "F3" : Keyboard.current.f3Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F4, (Keyboard.current == null) ? "F4" : Keyboard.current.f4Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F5, (Keyboard.current == null) ? "F5" : Keyboard.current.f5Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F6, (Keyboard.current == null) ? "F6" : Keyboard.current.f6Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F7, (Keyboard.current == null) ? "F7" : Keyboard.current.f7Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F8, (Keyboard.current == null) ? "F8" : Keyboard.current.f8Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F9, (Keyboard.current == null) ? "F9" : Keyboard.current.f9Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F10, (Keyboard.current == null) ? "F10" : Keyboard.current.f10Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F11, (Keyboard.current == null) ? "F11" : Keyboard.current.f11Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.F12, (Keyboard.current == null) ? "F12" : Keyboard.current.f12Key.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.NumLock, "NumLock");
				keyNameDictionary.Add(UniversalKeyCode.CapsLock, "CapsLock");
				keyNameDictionary.Add(UniversalKeyCode.ScrollLock, "ScrollLock");
				keyNameDictionary.Add(UniversalKeyCode.RightShift, "Shift");
				keyNameDictionary.Add(UniversalKeyCode.LeftShift, "Shift");
				keyNameDictionary.Add(UniversalKeyCode.RightControl, "Ctrl");
				keyNameDictionary.Add(UniversalKeyCode.LeftControl, "Ctrl");
				keyNameDictionary.Add(UniversalKeyCode.RightAlt, "Alt");
				keyNameDictionary.Add(UniversalKeyCode.LeftAlt, "Alt");
				keyNameDictionary.Add(UniversalKeyCode.RightCommand, "Cmd");
				keyNameDictionary.Add(UniversalKeyCode.LeftCommand, "Cmd");
				keyNameDictionary.Add(UniversalKeyCode.LeftWindows, "Win");
				keyNameDictionary.Add(UniversalKeyCode.RightWindows, (Keyboard.current == null) ? "Win" : Keyboard.current.rightWindowsKey.displayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.AltGr, "AltGr");
				keyNameDictionary.Add(UniversalKeyCode.Help, "Help");
				keyNameDictionary.Add(UniversalKeyCode.Print, "Print");
				keyNameDictionary.Add(UniversalKeyCode.SysReq, "SysReq");
				keyNameDictionary.Add(UniversalKeyCode.Break, "Break");
				keyNameDictionary.Add(UniversalKeyCode.Menu, "Menu");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton0, "Joy0");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton1, "Joy1");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton2, "Joy2");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton3, "Joy3");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton4, "Joy4");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton5, "Joy5");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton6, "Joy6");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton7, "Joy7");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton8, "Joy8");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton9, "Joy9");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton10, "Joy10");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton11, "Joy11");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton12, "Joy12");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton13, "Joy13");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton14, "Joy14");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton15, "Joy15");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton16, "Joy16");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton17, "Joy17");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton18, "Joy18");
				keyNameDictionary.Add(UniversalKeyCode.JoystickButton19, "Joy19");
				keyNameDictionary.Add(UniversalKeyCode.GamePadNorth, (Gamepad.current == null) ? "Y" : Gamepad.current.buttonNorth.shortDisplayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.GamePadSouth, (Gamepad.current == null) ? "A" : Gamepad.current.buttonSouth.shortDisplayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.GamePadWest, (Gamepad.current == null) ? "X" : Gamepad.current.buttonWest.shortDisplayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.GamePadEast, (Gamepad.current == null) ? "B" : Gamepad.current.buttonEast.shortDisplayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.GamePadStart, "Start");
				keyNameDictionary.Add(UniversalKeyCode.GamePadSelect, "Select");
				keyNameDictionary.Add(UniversalKeyCode.GamePadLeftShoulder, (Gamepad.current == null) ? "LB" : Gamepad.current.leftShoulder.shortDisplayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.GamePadRightShoulder, (Gamepad.current == null) ? "RB" : Gamepad.current.rightShoulder.shortDisplayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.GamePadLeftTrigger, (Gamepad.current == null) ? "LT" : Gamepad.current.leftTrigger.shortDisplayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.GamePadRightTrigger, (Gamepad.current == null) ? "RT" : Gamepad.current.rightTrigger.shortDisplayName.ToUpper());
				keyNameDictionary.Add(UniversalKeyCode.GamePadDPadUp, "DPad Up");
				keyNameDictionary.Add(UniversalKeyCode.GamePadDPadDown, "DPad Down");
				keyNameDictionary.Add(UniversalKeyCode.GamePadDPadLeft, "DPad Left");
				keyNameDictionary.Add(UniversalKeyCode.GamePadDPadRight, "DPad Right");
				keyNameDictionary.Add(UniversalKeyCode.GamePadLeftStickButton, "Left Stick");
				keyNameDictionary.Add(UniversalKeyCode.GamePadRightStickButton, "Left Stick");
				keyNameDictionary.Add(UniversalKeyCode.GamePadLeftStickUp, "L-Stick Up");
				keyNameDictionary.Add(UniversalKeyCode.GamePadLeftStickDown, "L-Stick Down");
				keyNameDictionary.Add(UniversalKeyCode.GamePadLeftStickLeft, "L-Stick Left");
				keyNameDictionary.Add(UniversalKeyCode.GamePadLeftStickRight, "L-Stick Right");
				keyNameDictionary.Add(UniversalKeyCode.GamePadRightStickUp, "R-Stick Up");
				keyNameDictionary.Add(UniversalKeyCode.GamePadRightStickDown, "R-Stick Down");
				keyNameDictionary.Add(UniversalKeyCode.GamePadRightStickLeft, "R-Stick Left");
				keyNameDictionary.Add(UniversalKeyCode.GamePadRightStickRight, "R-Stick Right");
			}
			if (keyNameDictionary.ContainsKey(keyCode))
			{
				return keyNameDictionary[keyCode];
			}
			return keyCode.ToString();
		}

		public static UniversalKeyCode KeyToUniversalKeyCode(Key key)
		{
			foreach (var item in _inputSystemKeyMap)
			{
				if (item.Item1 == key)
				{
					return item.Item2;
				}
			}
			return UniversalKeyCode.Unknown;
		}

		public static Key? UniversalKeyCodeToKey(UniversalKeyCode universalKeyCode)
		{
			foreach (var item in _inputSystemKeyMap)
			{
				if (item.Item2 == universalKeyCode)
				{
					return item.Item1;
				}
			}
			return null;
		}
	}
}
