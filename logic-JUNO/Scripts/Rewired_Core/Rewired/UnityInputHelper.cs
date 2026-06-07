using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class UnityInputHelper
	{
		private class APvCUhnIoONfxOEWWDmlbSmmaRtO
		{
			public string[] NaVbAchIXLFoeQjVygkDaohJIqoqB;

			public string[] yaDQyqyyVOnsTGkmZBMhIJlvAsRV;

			public APvCUhnIoONfxOEWWDmlbSmmaRtO(int P_0)
			{
				NaVbAchIXLFoeQjVygkDaohJIqoqB = new string[29];
				for (int i = 0; i < NaVbAchIXLFoeQjVygkDaohJIqoqB.Length; i++)
				{
					NaVbAchIXLFoeQjVygkDaohJIqoqB[i] = UnityTools.GetUnityInputAxisName(P_0, i);
				}
				if (P_0 + 1 > 16)
				{
					yaDQyqyyVOnsTGkmZBMhIJlvAsRV = new string[20];
					for (int j = 0; j < yaDQyqyyVOnsTGkmZBMhIJlvAsRV.Length; j++)
					{
						yaDQyqyyVOnsTGkmZBMhIJlvAsRV[j] = UnityTools.GetUnityInputButtonName(P_0, j);
					}
				}
			}
		}

		private static APvCUhnIoONfxOEWWDmlbSmmaRtO[] UegOeTlWYffBaxtfpnjAMfpBFfoN;

		static UnityInputHelper()
		{
			UegOeTlWYffBaxtfpnjAMfpBFfoN = new APvCUhnIoONfxOEWWDmlbSmmaRtO[16];
			for (int i = 0; i < UegOeTlWYffBaxtfpnjAMfpBFfoN.Length; i++)
			{
				UegOeTlWYffBaxtfpnjAMfpBFfoN[i] = new APvCUhnIoONfxOEWWDmlbSmmaRtO(i);
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
			return Input.GetAxis(UegOeTlWYffBaxtfpnjAMfpBFfoN[joystickId - 1].NaVbAchIXLFoeQjVygkDaohJIqoqB[axisIndex]);
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
			return Input.GetAxisRaw(UegOeTlWYffBaxtfpnjAMfpBFfoN[joystickId - 1].NaVbAchIXLFoeQjVygkDaohJIqoqB[axisIndex]);
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
			return Input.GetButton(UegOeTlWYffBaxtfpnjAMfpBFfoN[num].yaDQyqyyVOnsTGkmZBMhIJlvAsRV[buttonIndex]);
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
