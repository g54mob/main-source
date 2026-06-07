using System.Collections.Generic;
using ImGuiNET;
using UImGui.Assets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UImGui.Platform
{
	internal sealed class InputSystemPlatform : PlatformBase
	{
		private readonly List<char> _textInput = new List<char>();

		private int[] _mainKeys;

		private Keyboard _keyboard;

		public InputSystemPlatform(CursorShapesAsset cursorShapes, IniSettingsAsset iniSettings)
			: base(cursorShapes, iniSettings)
		{
		}

		public unsafe override bool Initialize(ImGuiIOPtr io, UIOConfig config, string platformName)
		{
			InputSystem.onDeviceChange += OnDeviceChange;
			base.Initialize(io, config, platformName);
			io.BackendFlags |= ImGuiBackendFlags.HasMouseCursors;
			PlatformCallbacks.SetClipboardFunctions(PlatformCallbacks.GetClipboardTextCallback, PlatformCallbacks.SetClipboardTextCallback);
			SetupKeyboard(io, Keyboard.current);
			return true;
		}

		public override void Shutdown(ImGuiIOPtr io)
		{
			base.Shutdown(io);
			InputSystem.onDeviceChange -= OnDeviceChange;
		}

		public override void PrepareFrame(ImGuiIOPtr io, Rect displayRect)
		{
			base.PrepareFrame(io, displayRect);
			UpdateKeyboard(io, Keyboard.current);
			UpdateMouse(io, Mouse.current);
			UpdateCursor(io, ImGui.GetMouseCursor());
			UpdateGamepad(io, Gamepad.current);
		}

		private static void UpdateMouse(ImGuiIOPtr io, Mouse mouse)
		{
			if (mouse != null)
			{
				if (io.WantSetMousePos)
				{
					mouse.WarpCursorPosition(Utils.ImGuiToScreen(in io.MousePos));
				}
				io.MousePos = Utils.ScreenToImGui(mouse.position.ReadValue());
				Vector2 vector = mouse.scroll.ReadValue() / 120f;
				io.MouseWheel = vector.y;
				io.MouseWheelH = vector.x;
				io.MouseDown[0] = mouse.leftButton.isPressed;
				io.MouseDown[1] = mouse.rightButton.isPressed;
				io.MouseDown[2] = mouse.middleButton.isPressed;
			}
		}

		private static void UpdateGamepad(ImGuiIOPtr io, Gamepad gamepad)
		{
			io.BackendFlags = ((gamepad == null) ? (io.BackendFlags & ~ImGuiBackendFlags.HasGamepad) : (io.BackendFlags | ImGuiBackendFlags.HasGamepad));
			if (gamepad != null && (io.ConfigFlags & ImGuiConfigFlags.NavEnableGamepad) != ImGuiConfigFlags.None)
			{
				io.NavInputs[0] = gamepad.buttonSouth.ReadValue();
				io.NavInputs[1] = gamepad.buttonEast.ReadValue();
				io.NavInputs[3] = gamepad.buttonWest.ReadValue();
				io.NavInputs[2] = gamepad.buttonNorth.ReadValue();
				io.NavInputs[4] = gamepad.dpad.left.ReadValue();
				io.NavInputs[5] = gamepad.dpad.right.ReadValue();
				io.NavInputs[6] = gamepad.dpad.up.ReadValue();
				io.NavInputs[7] = gamepad.dpad.down.ReadValue();
				io.NavInputs[12] = gamepad.leftShoulder.ReadValue();
				io.NavInputs[13] = gamepad.rightShoulder.ReadValue();
				io.NavInputs[14] = gamepad.leftShoulder.ReadValue();
				io.NavInputs[15] = gamepad.rightShoulder.ReadValue();
				io.NavInputs[8] = gamepad.leftStick.left.ReadValue();
				io.NavInputs[9] = gamepad.leftStick.right.ReadValue();
				io.NavInputs[10] = gamepad.leftStick.up.ReadValue();
				io.NavInputs[11] = gamepad.leftStick.down.ReadValue();
			}
		}

		private void SetupKeyboard(ImGuiIOPtr io, Keyboard keyboard)
		{
			RangeAccessor<int> keyMap;
			if (_keyboard != null)
			{
				for (int i = 0; i < 652; i++)
				{
					keyMap = io.KeyMap;
					keyMap[i] = -1;
				}
				_keyboard.onTextInput -= _textInput.Add;
			}
			_keyboard = keyboard;
			int[] array = new int[22];
			keyMap = io.KeyMap;
			array[0] = (keyMap[546] = 15);
			keyMap = io.KeyMap;
			array[1] = (keyMap[548] = 17);
			keyMap = io.KeyMap;
			array[2] = (keyMap[567] = 36);
			keyMap = io.KeyMap;
			array[3] = (keyMap[569] = 38);
			keyMap = io.KeyMap;
			array[4] = (keyMap[570] = 39);
			keyMap = io.KeyMap;
			array[5] = (keyMap[571] = 40);
			keyMap = io.KeyMap;
			array[6] = (keyMap[512] = 3);
			keyMap = io.KeyMap;
			array[7] = (keyMap[513] = 61);
			keyMap = io.KeyMap;
			array[8] = (keyMap[514] = 62);
			keyMap = io.KeyMap;
			array[9] = (keyMap[515] = 63);
			keyMap = io.KeyMap;
			array[10] = (keyMap[516] = 64);
			keyMap = io.KeyMap;
			array[11] = (keyMap[517] = 67);
			keyMap = io.KeyMap;
			array[12] = (keyMap[518] = 66);
			keyMap = io.KeyMap;
			array[13] = (keyMap[519] = 68);
			keyMap = io.KeyMap;
			array[14] = (keyMap[520] = 69);
			keyMap = io.KeyMap;
			array[15] = (keyMap[521] = 70);
			keyMap = io.KeyMap;
			array[16] = (keyMap[522] = 71);
			keyMap = io.KeyMap;
			array[17] = (keyMap[523] = 65);
			keyMap = io.KeyMap;
			array[18] = (keyMap[524] = 1);
			keyMap = io.KeyMap;
			array[19] = (keyMap[526] = 60);
			keyMap = io.KeyMap;
			array[20] = (keyMap[525] = 2);
			keyMap = io.KeyMap;
			array[21] = (keyMap[615] = 77);
			_mainKeys = array;
			_keyboard.onTextInput += _textInput.Add;
		}

		private void UpdateKeyboard(ImGuiIOPtr io, Keyboard keyboard)
		{
			if (keyboard != null)
			{
				for (int i = 0; i < _mainKeys.Length; i++)
				{
					int num = _mainKeys[i];
					io.KeysDown[num] = keyboard[(Key)num].isPressed;
				}
				io.KeyShift = keyboard[Key.LeftShift].isPressed || keyboard[Key.RightShift].isPressed;
				io.KeyCtrl = keyboard[Key.LeftCtrl].isPressed || keyboard[Key.RightCtrl].isPressed;
				io.KeyAlt = keyboard[Key.LeftAlt].isPressed || keyboard[Key.RightAlt].isPressed;
				io.KeySuper = keyboard[Key.LeftMeta].isPressed || keyboard[Key.RightMeta].isPressed;
				int j = 0;
				for (int count = _textInput.Count; j < count; j++)
				{
					io.AddInputCharacter(_textInput[j]);
				}
				_textInput.Clear();
			}
		}

		private void OnDeviceChange(InputDevice device, InputDeviceChange change)
		{
			if (device is Keyboard keyboard)
			{
				if (change == InputDeviceChange.ConfigurationChanged)
				{
					SetupKeyboard(ImGui.GetIO(), keyboard);
				}
				if (Keyboard.current != _keyboard)
				{
					SetupKeyboard(ImGui.GetIO(), Keyboard.current);
				}
			}
		}
	}
}
