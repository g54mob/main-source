using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class UnityInputHelper
	{
		private class OlfPCPvSarrKHaLKJawAkvdhchgFA
		{
			public string[] ZcJInIGeTirnKBvFdkRozFeBAVtl;

			public string[] usNaZSasJhzyjkRsUIISXteaKRAH;

			public OlfPCPvSarrKHaLKJawAkvdhchgFA(int P_0)
			{
				ZcJInIGeTirnKBvFdkRozFeBAVtl = new string[29];
				for (int i = 0; i < ZcJInIGeTirnKBvFdkRozFeBAVtl.Length; i++)
				{
					ZcJInIGeTirnKBvFdkRozFeBAVtl[i] = UnityTools.GetUnityInputAxisName(P_0, i);
				}
				if (P_0 + 1 > 16)
				{
					usNaZSasJhzyjkRsUIISXteaKRAH = new string[20];
					for (int j = 0; j < usNaZSasJhzyjkRsUIISXteaKRAH.Length; j++)
					{
						usNaZSasJhzyjkRsUIISXteaKRAH[j] = UnityTools.GetUnityInputButtonName(P_0, j);
					}
				}
			}
		}

		private static OlfPCPvSarrKHaLKJawAkvdhchgFA[] OAgSOflUKMIeSHFfoytxFkgWJTbn;

		static UnityInputHelper()
		{
			OAgSOflUKMIeSHFfoytxFkgWJTbn = new OlfPCPvSarrKHaLKJawAkvdhchgFA[16];
			for (int i = 0; i < OAgSOflUKMIeSHFfoytxFkgWJTbn.Length; i++)
			{
				OAgSOflUKMIeSHFfoytxFkgWJTbn[i] = new OlfPCPvSarrKHaLKJawAkvdhchgFA(i);
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
			return Input.GetAxis(OAgSOflUKMIeSHFfoytxFkgWJTbn[joystickId - 1].ZcJInIGeTirnKBvFdkRozFeBAVtl[axisIndex]);
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
			return Input.GetAxisRaw(OAgSOflUKMIeSHFfoytxFkgWJTbn[joystickId - 1].ZcJInIGeTirnKBvFdkRozFeBAVtl[axisIndex]);
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
			return Input.GetButton(OAgSOflUKMIeSHFfoytxFkgWJTbn[num].usNaZSasJhzyjkRsUIISXteaKRAH[buttonIndex]);
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
