using UnityEngine;

namespace MyBox
{
	public static class MyInput
	{
		public static bool GetNumberDown(int num)
		{
			return false;
		}

		public static int GetNumberDown(KeyCode key)
		{
			return 0;
		}

		public static int GetNumberDown()
		{
			return 0;
		}

		public static string ToReadableString(this KeyCode key, bool full = false)
		{
			return null;
		}

		public static bool AnyKeyDown(KeyCode key1, KeyCode key2)
		{
			return false;
		}

		public static bool AnyKeyDown(KeyCode key1, KeyCode key2, KeyCode key3)
		{
			return false;
		}

		public static bool IsLeft()
		{
			return false;
		}

		public static bool IsRight()
		{
			return false;
		}

		public static bool IsUp()
		{
			return false;
		}

		public static bool IsDown()
		{
			return false;
		}

		public static int KeypadDirection()
		{
			return 0;
		}

		public static int KeypadX()
		{
			return 0;
		}

		public static int KeypadY()
		{
			return 0;
		}
	}
}
