using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal static class UnityInputHelper
	{
		private class PdLaHgFQjNHffHlLDbODmnriFoDxD
		{
			public string[] KEDjKHwyahDuXcTCSIcFnJhOTqLN;

			public string[] TfXhkdHigndULcPdipMrFYFFSpcge;

			public PdLaHgFQjNHffHlLDbODmnriFoDxD(int P_0)
			{
				KEDjKHwyahDuXcTCSIcFnJhOTqLN = new string[29];
				for (int i = 0; i < KEDjKHwyahDuXcTCSIcFnJhOTqLN.Length; i++)
				{
					KEDjKHwyahDuXcTCSIcFnJhOTqLN[i] = UnityTools.GetUnityInputAxisName(P_0, i);
				}
				if (P_0 + 1 > 16)
				{
					TfXhkdHigndULcPdipMrFYFFSpcge = new string[20];
					for (int j = 0; j < TfXhkdHigndULcPdipMrFYFFSpcge.Length; j++)
					{
						TfXhkdHigndULcPdipMrFYFFSpcge[j] = UnityTools.GetUnityInputButtonName(P_0, j);
					}
				}
			}
		}

		private static PdLaHgFQjNHffHlLDbODmnriFoDxD[] FUWUMuBhggyFQEOUCASaOJmITfwR;

		static UnityInputHelper()
		{
			FUWUMuBhggyFQEOUCASaOJmITfwR = new PdLaHgFQjNHffHlLDbODmnriFoDxD[16];
			for (int i = 0; i < FUWUMuBhggyFQEOUCASaOJmITfwR.Length; i++)
			{
				FUWUMuBhggyFQEOUCASaOJmITfwR[i] = new PdLaHgFQjNHffHlLDbODmnriFoDxD(i);
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
			return Input.GetAxis(FUWUMuBhggyFQEOUCASaOJmITfwR[joystickId - 1].KEDjKHwyahDuXcTCSIcFnJhOTqLN[axisIndex]);
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
			return Input.GetAxisRaw(FUWUMuBhggyFQEOUCASaOJmITfwR[joystickId - 1].KEDjKHwyahDuXcTCSIcFnJhOTqLN[axisIndex]);
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
				return Input.GetKey((KeyCode)(350 + 20 * num + buttonIndex));
			}
			return Input.GetButton(FUWUMuBhggyFQEOUCASaOJmITfwR[num].TfXhkdHigndULcPdipMrFYFFSpcge[buttonIndex]);
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
