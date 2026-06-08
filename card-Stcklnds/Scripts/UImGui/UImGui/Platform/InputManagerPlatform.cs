using ImGuiNET;
using UImGui.Assets;
using UnityEngine;

namespace UImGui.Platform
{
	internal sealed class InputManagerPlatform : PlatformBase
	{
		private readonly Event _textInputEvent = new Event();

		private int[] _mainKeys;

		public InputManagerPlatform(CursorShapesAsset cursorShapes, IniSettingsAsset iniSettings)
			: base(cursorShapes, iniSettings)
		{
		}

		public override bool Initialize(ImGuiIOPtr io, UIOConfig config, string platformName)
		{
			base.Initialize(io, config, platformName);
			SetupKeyboard(io);
			return true;
		}

		public override void PrepareFrame(ImGuiIOPtr io, Rect displayRect)
		{
			base.PrepareFrame(io, displayRect);
			UpdateKeyboard(io);
			UpdateMouse(io);
			UpdateCursor(io, ImGui.GetMouseCursor());
		}

		private void SetupKeyboard(ImGuiIOPtr io)
		{
			int[] array = new int[22];
			RangeAccessor<int> keyMap = io.KeyMap;
			array[0] = (keyMap[546] = 97);
			keyMap = io.KeyMap;
			array[1] = (keyMap[548] = 99);
			keyMap = io.KeyMap;
			array[2] = (keyMap[567] = 118);
			keyMap = io.KeyMap;
			array[3] = (keyMap[569] = 120);
			keyMap = io.KeyMap;
			array[4] = (keyMap[570] = 121);
			keyMap = io.KeyMap;
			array[5] = (keyMap[571] = 122);
			keyMap = io.KeyMap;
			array[6] = (keyMap[512] = 9);
			keyMap = io.KeyMap;
			array[7] = (keyMap[513] = 276);
			keyMap = io.KeyMap;
			array[8] = (keyMap[514] = 275);
			keyMap = io.KeyMap;
			array[9] = (keyMap[515] = 273);
			keyMap = io.KeyMap;
			array[10] = (keyMap[516] = 274);
			keyMap = io.KeyMap;
			array[11] = (keyMap[517] = 280);
			keyMap = io.KeyMap;
			array[12] = (keyMap[518] = 281);
			keyMap = io.KeyMap;
			array[13] = (keyMap[519] = 278);
			keyMap = io.KeyMap;
			array[14] = (keyMap[520] = 279);
			keyMap = io.KeyMap;
			array[15] = (keyMap[521] = 277);
			keyMap = io.KeyMap;
			array[16] = (keyMap[522] = 127);
			keyMap = io.KeyMap;
			array[17] = (keyMap[523] = 8);
			keyMap = io.KeyMap;
			array[18] = (keyMap[524] = 32);
			keyMap = io.KeyMap;
			array[19] = (keyMap[526] = 27);
			keyMap = io.KeyMap;
			array[20] = (keyMap[525] = 13);
			keyMap = io.KeyMap;
			array[21] = (keyMap[615] = 271);
			_mainKeys = array;
		}

		private void UpdateKeyboard(ImGuiIOPtr io)
		{
			for (int i = 0; i < _mainKeys.Length; i++)
			{
				int num = _mainKeys[i];
				io.KeysDown[num] = Input.GetKey((KeyCode)num);
			}
			io.KeyShift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
			io.KeyCtrl = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
			io.KeyAlt = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
			io.KeySuper = Input.GetKey(KeyCode.LeftMeta) || Input.GetKey(KeyCode.RightMeta) || Input.GetKey(KeyCode.LeftWindows) || Input.GetKey(KeyCode.RightWindows);
			while (Event.PopEvent(_textInputEvent))
			{
				if (_textInputEvent.rawType == EventType.KeyDown && _textInputEvent.character != 0 && _textInputEvent.character != '\n')
				{
					io.AddInputCharacter(_textInputEvent.character);
				}
			}
		}

		private static void UpdateMouse(ImGuiIOPtr io)
		{
			io.MousePos = Utils.ScreenToImGui((Vector2)Input.mousePosition);
			io.MouseWheel = Input.mouseScrollDelta.y;
			io.MouseWheelH = Input.mouseScrollDelta.x;
			io.MouseDown[0] = Input.GetMouseButton(0);
			io.MouseDown[1] = Input.GetMouseButton(1);
			io.MouseDown[2] = Input.GetMouseButton(2);
		}
	}
}
