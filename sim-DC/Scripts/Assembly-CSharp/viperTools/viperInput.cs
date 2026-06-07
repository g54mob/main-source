using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace viperTools
{
	public class viperInput : MonoBehaviour
	{
		public void Start()
		{
		}

		public static bool IsLetterAZ(KeyCode k)
		{
			return false;
		}

		public static void RegisterKeyStrokeCallback(Action<char> action, bool enable)
		{
		}

		public static Key ConvertKeyCodeToKey(KeyCode k)
		{
			return default(Key);
		}

		public static bool KeyDown(KeyCode k)
		{
			return false;
		}

		public static bool KeyUp(KeyCode k)
		{
			return false;
		}

		public static bool KeyPress(KeyCode k)
		{
			return false;
		}

		public static bool PointerDown(int mouseBtn = 0)
		{
			return false;
		}

		public static bool PointerUp(int mouseBtn = 0)
		{
			return false;
		}

		public static bool Fire1()
		{
			return false;
		}

		public static bool AButtonDown()
		{
			return false;
		}

		public static bool AButtonUp()
		{
			return false;
		}

		public static bool BButtonDown()
		{
			return false;
		}

		public static bool BButtonUp()
		{
			return false;
		}

		public static bool AnyPhysicalKey()
		{
			return false;
		}

		public static string GetPhysicalKey()
		{
			return null;
		}

		public static string ConvertToLegacyAxis(AXIS_INPUT axis)
		{
			return null;
		}

		public static string[] GetControllerNames()
		{
			return null;
		}

		public static float GetAllAxis()
		{
			return 0f;
		}

		public static float GetAxis(AXIS_INPUT axis)
		{
			return 0f;
		}

		public static Vector2 GetPlayerJoystickInput(int p)
		{
			return default(Vector2);
		}

		public static bool GetPlayerAButton(int p)
		{
			return false;
		}

		public static bool GetPlayerBButton(int p)
		{
			return false;
		}

		public static int NumControllers()
		{
			return 0;
		}

		public static void ResetAllAxis()
		{
		}

		public static Vector2 GetPointerPos()
		{
			return default(Vector2);
		}
	}
}
