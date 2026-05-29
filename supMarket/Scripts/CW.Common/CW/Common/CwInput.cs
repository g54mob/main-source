using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace CW.Common
{
	public static class CwInput
	{
		private static Dictionary<KeyCode, Key> keyMapping;

		[RuntimeInitializeOnLoadMethod]
		private static void Enable()
		{
		}

		private static ButtonControl GetMouseButtonControl(int index)
		{
			return null;
		}

		private static ButtonControl GetButtonControl(KeyCode oldKey)
		{
			return null;
		}

		public static int GetTouchCount()
		{
			return 0;
		}

		public static void GetTouch(int index, out int id, out Vector2 position, out float pressure, out bool set)
		{
			id = default(int);
			position = default(Vector2);
			pressure = default(float);
			set = default(bool);
		}

		public static Vector2 GetMousePosition()
		{
			return default(Vector2);
		}

		public static bool GetKeyWentDown(KeyCode oldKey)
		{
			return false;
		}

		public static bool GetKeyIsHeld(KeyCode oldKey)
		{
			return false;
		}

		public static bool GetKeyWentUp(KeyCode oldKey)
		{
			return false;
		}

		public static bool GetMouseWentDown(int index)
		{
			return false;
		}

		public static bool GetMouseIsHeld(int index)
		{
			return false;
		}

		public static bool GetMouseWentUp(int index)
		{
			return false;
		}

		public static float GetMouseWheelDelta()
		{
			return 0f;
		}

		public static bool GetMouseExists()
		{
			return false;
		}

		public static bool GetKeyboardExists()
		{
			return false;
		}
	}
}
