using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class UnityInputHelper
	{
		private class OeBWPjWdJgAeqiyNqwrsnKzyVwVN
		{
			public string[] ReTfQYcjCClrSfRODjReSSrvAkjB;

			public string[] KgNDeofgOGnDWISzFibSmnVDlhDY;

			public OeBWPjWdJgAeqiyNqwrsnKzyVwVN(int joystickIndex)
			{
				ReTfQYcjCClrSfRODjReSSrvAkjB = new string[29];
				for (int i = 0; i < ReTfQYcjCClrSfRODjReSSrvAkjB.Length; i++)
				{
					ReTfQYcjCClrSfRODjReSSrvAkjB[i] = UnityTools.GetUnityInputAxisName(joystickIndex, i);
				}
				if (joystickIndex + 1 > 16)
				{
					KgNDeofgOGnDWISzFibSmnVDlhDY = new string[20];
					for (int j = 0; j < KgNDeofgOGnDWISzFibSmnVDlhDY.Length; j++)
					{
						KgNDeofgOGnDWISzFibSmnVDlhDY[j] = UnityTools.GetUnityInputButtonName(joystickIndex, j);
					}
				}
			}
		}

		private static OeBWPjWdJgAeqiyNqwrsnKzyVwVN[] GpKTUjLMGVeIHJzINAjLhtehdVC;

		static UnityInputHelper()
		{
			GpKTUjLMGVeIHJzINAjLhtehdVC = new OeBWPjWdJgAeqiyNqwrsnKzyVwVN[16];
			for (int i = 0; i < GpKTUjLMGVeIHJzINAjLhtehdVC.Length; i++)
			{
				GpKTUjLMGVeIHJzINAjLhtehdVC[i] = new OeBWPjWdJgAeqiyNqwrsnKzyVwVN(i);
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
			return Input.GetAxis(GpKTUjLMGVeIHJzINAjLhtehdVC[joystickId - 1].ReTfQYcjCClrSfRODjReSSrvAkjB[axisIndex]);
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
			return Input.GetAxisRaw(GpKTUjLMGVeIHJzINAjLhtehdVC[joystickId - 1].ReTfQYcjCClrSfRODjReSSrvAkjB[axisIndex]);
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
			return Input.GetButton(GpKTUjLMGVeIHJzINAjLhtehdVC[num].KgNDeofgOGnDWISzFibSmnVDlhDY[buttonIndex]);
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
