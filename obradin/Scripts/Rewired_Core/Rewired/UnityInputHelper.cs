using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal static class UnityInputHelper
	{
		private class QQEwgSISBYcbcOEZsateDYLbKJg
		{
			public string[] HFStzJyQGytgUBWpFJOoXXXwNYX;

			public string[] USQZpFcFQqBJUckpyitMKctsvSza;

			public QQEwgSISBYcbcOEZsateDYLbKJg(int joystickIndex)
			{
				HFStzJyQGytgUBWpFJOoXXXwNYX = new string[29];
				for (int i = 0; i < HFStzJyQGytgUBWpFJOoXXXwNYX.Length; i++)
				{
					HFStzJyQGytgUBWpFJOoXXXwNYX[i] = UnityTools.GetUnityInputAxisName(joystickIndex, i);
				}
				if (joystickIndex + 1 > 8)
				{
					USQZpFcFQqBJUckpyitMKctsvSza = new string[20];
					for (int j = 0; j < USQZpFcFQqBJUckpyitMKctsvSza.Length; j++)
					{
						USQZpFcFQqBJUckpyitMKctsvSza[j] = UnityTools.GetUnityInputButtonName(joystickIndex, j);
					}
				}
			}
		}

		private static QQEwgSISBYcbcOEZsateDYLbKJg[] AVRtfMRpOzQlHvmKXxpZoBGaQUn;

		static UnityInputHelper()
		{
			AVRtfMRpOzQlHvmKXxpZoBGaQUn = new QQEwgSISBYcbcOEZsateDYLbKJg[11];
			int num2 = default(int);
			while (true)
			{
				int num = 1905017263;
				while (true)
				{
					switch (num ^ 0x718C41AE)
					{
					case 2:
						break;
					case 1:
						num2 = 0;
						num = 1905017261;
						continue;
					case 0:
						AVRtfMRpOzQlHvmKXxpZoBGaQUn[num2] = new QQEwgSISBYcbcOEZsateDYLbKJg(num2);
						num2++;
						num = 1905017261;
						continue;
					default:
						if (num2 >= AVRtfMRpOzQlHvmKXxpZoBGaQUn.Length)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public static float GetJoystickAxisValueByJoystickId(int joystickId, int axisIndex)
		{
			if (joystickId <= 0 || joystickId > 11)
			{
				return 0f;
			}
			if (axisIndex >= 29)
			{
				return 0f;
			}
			return Input.GetAxis(AVRtfMRpOzQlHvmKXxpZoBGaQUn[joystickId - 1].HFStzJyQGytgUBWpFJOoXXXwNYX[axisIndex]);
		}

		public static float GetJoystickAxisRawValueByJoystickId(int joystickId, int axisIndex)
		{
			if (joystickId <= 0 || joystickId > 11)
			{
				return 0f;
			}
			if (axisIndex >= 29)
			{
				return 0f;
			}
			return Input.GetAxisRaw(AVRtfMRpOzQlHvmKXxpZoBGaQUn[joystickId - 1].HFStzJyQGytgUBWpFJOoXXXwNYX[axisIndex]);
		}

		public static float GetJoystickAxisValueByJoystickIndex(int joystickIndex, int axisIndex)
		{
			return GetJoystickAxisValueByJoystickId(joystickIndex + 1, axisIndex);
		}

		public static float GetJoystickAxisRawValueByJoystickIndex(int joystickIndex, int axisIndex)
		{
			return GetJoystickAxisRawValueByJoystickId(joystickIndex + 1, axisIndex);
		}

		public static bool GetJoystickButtonValueByJoystickId(int joystickId, int buttonIndex)
		{
			int num = default(int);
			int num2;
			if (joystickId > 0)
			{
				if (joystickId > 11)
				{
					goto IL_0009;
				}
				if (buttonIndex >= 20)
				{
					return false;
				}
				num = joystickId - 1;
				num2 = -1142361820;
				goto IL_000e;
			}
			goto IL_0027;
			IL_0009:
			num2 = -1142361819;
			goto IL_000e;
			IL_000e:
			switch (num2 ^ -1142361820)
			{
			case 2:
				break;
			case 1:
				goto IL_0027;
			default:
				goto IL_003b;
			}
			goto IL_0009;
			IL_003b:
			if (joystickId <= 8)
			{
				KeyCode key = (KeyCode)(350 + 20 * num + buttonIndex);
				return Input.GetKey(key);
			}
			return Input.GetButton(AVRtfMRpOzQlHvmKXxpZoBGaQUn[num].USQZpFcFQqBJUckpyitMKctsvSza[buttonIndex]);
			IL_0027:
			return false;
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
