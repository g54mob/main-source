using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class UnityInputHelper
	{
		private class whhigTrjsdBNmgvvrHnbCWGeGwjc
		{
			public string[] jvtuzgHGpVYYUcKiWEJhKXATgvN;

			public string[] aJtpRSRHtDeqCDIJtCvHanoFDlsc;

			public whhigTrjsdBNmgvvrHnbCWGeGwjc(int joystickIndex)
			{
				jvtuzgHGpVYYUcKiWEJhKXATgvN = new string[29];
				for (int i = 0; i < jvtuzgHGpVYYUcKiWEJhKXATgvN.Length; i++)
				{
					jvtuzgHGpVYYUcKiWEJhKXATgvN[i] = UnityTools.GetUnityInputAxisName(joystickIndex, i);
				}
				if (joystickIndex + 1 > 16)
				{
					aJtpRSRHtDeqCDIJtCvHanoFDlsc = new string[20];
					for (int j = 0; j < aJtpRSRHtDeqCDIJtCvHanoFDlsc.Length; j++)
					{
						aJtpRSRHtDeqCDIJtCvHanoFDlsc[j] = UnityTools.GetUnityInputButtonName(joystickIndex, j);
					}
				}
			}
		}

		private static whhigTrjsdBNmgvvrHnbCWGeGwjc[] kjwFdZmRbOPrZUBwYofYzTFLQnc;

		static UnityInputHelper()
		{
			kjwFdZmRbOPrZUBwYofYzTFLQnc = new whhigTrjsdBNmgvvrHnbCWGeGwjc[16];
			for (int i = 0; i < kjwFdZmRbOPrZUBwYofYzTFLQnc.Length; i++)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i] = new whhigTrjsdBNmgvvrHnbCWGeGwjc(i);
			}
		}

		public static float GetJoystickAxisValueByJoystickId(int joystickId, int axisIndex)
		{
			if (joystickId <= 0 || joystickId > 16)
			{
				return 0f;
			}
			if (axisIndex >= 29)
			{
				return 0f;
			}
			return Input.GetAxis(kjwFdZmRbOPrZUBwYofYzTFLQnc[joystickId - 1].jvtuzgHGpVYYUcKiWEJhKXATgvN[axisIndex]);
		}

		public static float GetJoystickAxisRawValueByJoystickId(int joystickId, int axisIndex)
		{
			if (joystickId <= 0 || joystickId > 16)
			{
				return 0f;
			}
			if (axisIndex >= 29)
			{
				return 0f;
			}
			return Input.GetAxisRaw(kjwFdZmRbOPrZUBwYofYzTFLQnc[joystickId - 1].jvtuzgHGpVYYUcKiWEJhKXATgvN[axisIndex]);
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
			if (joystickId <= 0 || joystickId > 16)
			{
				return false;
			}
			if (buttonIndex >= 20)
			{
				return false;
			}
			int num = joystickId - 1;
			if (joystickId <= 16)
			{
				KeyCode key = (KeyCode)(350 + 20 * num + buttonIndex);
				return Input.GetKey(key);
			}
			return Input.GetButton(kjwFdZmRbOPrZUBwYofYzTFLQnc[num].aJtpRSRHtDeqCDIJtCvHanoFDlsc[buttonIndex]);
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
