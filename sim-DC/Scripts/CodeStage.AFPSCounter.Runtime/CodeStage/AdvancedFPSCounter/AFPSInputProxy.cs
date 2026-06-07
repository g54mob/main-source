using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeStage.AdvancedFPSCounter
{
	public static class AFPSInputProxy
	{
		private static Key cachedHotKey;

		private static KeyCode lastHotKeyLegacy;

		public static Vector2 mousePosition => default(Vector2);

		public static bool GetHotKeyDown(KeyCode key)
		{
			return false;
		}

		public static bool GetControlKey()
		{
			return false;
		}

		public static bool GetAltKey()
		{
			return false;
		}

		public static bool GetShiftKey()
		{
			return false;
		}

		private static Key ConvertLegacyKeyCode(KeyCode keyCode)
		{
			return default(Key);
		}

		public static bool GetMouseButton(int i)
		{
			return false;
		}

		public static bool GetMouseButtonUp(int i)
		{
			return false;
		}
	}
}
