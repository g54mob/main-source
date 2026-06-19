using System.Text.RegularExpressions;
using UnityEngine;

namespace MyBox
{
	public static class MyInput
	{
		public static bool GetNumberDown(int num)
		{
			switch (num)
			{
			case 0:
				if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
				{
					return true;
				}
				break;
			case 1:
				if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
				{
					return true;
				}
				break;
			case 2:
				if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
				{
					return true;
				}
				break;
			case 3:
				if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
				{
					return true;
				}
				break;
			case 4:
				if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
				{
					return true;
				}
				break;
			case 5:
				if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
				{
					return true;
				}
				break;
			case 6:
				if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
				{
					return true;
				}
				break;
			case 7:
				if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
				{
					return true;
				}
				break;
			case 8:
				if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
				{
					return true;
				}
				break;
			case 9:
				if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
				{
					return true;
				}
				break;
			}
			return false;
		}

		public static int GetNumberDown(KeyCode key)
		{
			switch (key)
			{
			case KeyCode.Alpha0:
			case KeyCode.Keypad0:
				return 0;
			case KeyCode.Alpha1:
			case KeyCode.Keypad1:
				return 1;
			case KeyCode.Alpha2:
			case KeyCode.Keypad2:
				return 2;
			case KeyCode.Alpha3:
			case KeyCode.Keypad3:
				return 3;
			case KeyCode.Alpha4:
			case KeyCode.Keypad4:
				return 4;
			case KeyCode.Alpha5:
			case KeyCode.Keypad5:
				return 5;
			case KeyCode.Alpha6:
			case KeyCode.Keypad6:
				return 6;
			case KeyCode.Alpha7:
			case KeyCode.Keypad7:
				return 7;
			case KeyCode.Alpha8:
			case KeyCode.Keypad8:
				return 8;
			case KeyCode.Alpha9:
			case KeyCode.Keypad9:
				return 9;
			default:
				return -1;
			}
		}

		public static int GetNumberDown()
		{
			if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
			{
				return 0;
			}
			if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
			{
				return 1;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
			{
				return 2;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
			{
				return 3;
			}
			if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
			{
				return 4;
			}
			if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
			{
				return 5;
			}
			if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
			{
				return 6;
			}
			if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
			{
				return 7;
			}
			if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
			{
				return 8;
			}
			if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
			{
				return 9;
			}
			return -1;
		}

		public static string ToReadableString(this KeyCode key, bool full = false)
		{
			switch (key)
			{
			case KeyCode.Mouse0:
				if (!full)
				{
					return "LMB";
				}
				return "Left Mouse Button";
			case KeyCode.Mouse1:
				if (!full)
				{
					return "RMB";
				}
				return "Right Mouse Button";
			case KeyCode.Mouse2:
				if (!full)
				{
					return "MMB";
				}
				return "Middle Mouse Button";
			default:
				return Regex.Replace(key.ToString(), "(\\B[A-Z])", " $1");
			}
		}

		public static bool AnyKeyDown(KeyCode key1, KeyCode key2)
		{
			if (!Input.GetKeyDown(key1))
			{
				return Input.GetKeyDown(key2);
			}
			return true;
		}

		public static bool AnyKeyDown(KeyCode key1, KeyCode key2, KeyCode key3)
		{
			if (!AnyKeyDown(key1, key2))
			{
				return Input.GetKeyDown(key3);
			}
			return true;
		}

		public static bool IsLeft()
		{
			return AnyKeyDown(KeyCode.A, KeyCode.LeftArrow, KeyCode.Keypad4);
		}

		public static bool IsRight()
		{
			return AnyKeyDown(KeyCode.D, KeyCode.RightArrow, KeyCode.Keypad6);
		}

		public static bool IsUp()
		{
			return AnyKeyDown(KeyCode.W, KeyCode.UpArrow, KeyCode.Keypad8);
		}

		public static bool IsDown()
		{
			return AnyKeyDown(KeyCode.S, KeyCode.DownArrow, KeyCode.Keypad2);
		}

		public static int KeypadDirection()
		{
			if (IsLeft())
			{
				return 4;
			}
			if (IsRight())
			{
				return 6;
			}
			if (IsUp())
			{
				return 8;
			}
			if (IsDown())
			{
				return 2;
			}
			if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				return 1;
			}
			if (Input.GetKeyDown(KeyCode.Keypad3))
			{
				return 3;
			}
			if (Input.GetKeyDown(KeyCode.Keypad7))
			{
				return 7;
			}
			if (Input.GetKeyDown(KeyCode.Keypad9))
			{
				return 9;
			}
			return 0;
		}

		public static int KeypadX()
		{
			if (IsLeft())
			{
				return -1;
			}
			if (IsRight())
			{
				return 1;
			}
			if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				return -1;
			}
			if (Input.GetKeyDown(KeyCode.Keypad7))
			{
				return -1;
			}
			if (Input.GetKeyDown(KeyCode.Keypad3))
			{
				return 1;
			}
			if (Input.GetKeyDown(KeyCode.Keypad9))
			{
				return 1;
			}
			return 0;
		}

		public static int KeypadY()
		{
			if (IsUp())
			{
				return 1;
			}
			if (IsDown())
			{
				return -1;
			}
			if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				return -1;
			}
			if (Input.GetKeyDown(KeyCode.Keypad3))
			{
				return -1;
			}
			if (Input.GetKeyDown(KeyCode.Keypad7))
			{
				return 1;
			}
			if (Input.GetKeyDown(KeyCode.Keypad9))
			{
				return 1;
			}
			return 0;
		}
	}
}
