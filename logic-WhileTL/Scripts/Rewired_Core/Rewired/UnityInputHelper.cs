using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal static class UnityInputHelper
	{
		private class cGZOZxuMPBUEDWGrYEmrwMGYgopS
		{
			public string[] pvHNgMKSWvFRvLaLvOpzsGxXmHFe;

			public string[] yiLCnoEiYpxfzsmLEpoLBCiFaluJA;

			public cGZOZxuMPBUEDWGrYEmrwMGYgopS(int P_0)
			{
				pvHNgMKSWvFRvLaLvOpzsGxXmHFe = new string[29];
				for (int i = 0; i < pvHNgMKSWvFRvLaLvOpzsGxXmHFe.Length; i++)
				{
					pvHNgMKSWvFRvLaLvOpzsGxXmHFe[i] = UnityTools.GetUnityInputAxisName(P_0, i);
				}
				if (P_0 + 1 > 16)
				{
					yiLCnoEiYpxfzsmLEpoLBCiFaluJA = new string[20];
					for (int j = 0; j < yiLCnoEiYpxfzsmLEpoLBCiFaluJA.Length; j++)
					{
						yiLCnoEiYpxfzsmLEpoLBCiFaluJA[j] = UnityTools.GetUnityInputButtonName(P_0, j);
					}
				}
			}
		}

		private static cGZOZxuMPBUEDWGrYEmrwMGYgopS[] elKJbbxESyfcuzfcxFoUDTJZIhcJA;

		static UnityInputHelper()
		{
			elKJbbxESyfcuzfcxFoUDTJZIhcJA = new cGZOZxuMPBUEDWGrYEmrwMGYgopS[16];
			for (int i = 0; i < elKJbbxESyfcuzfcxFoUDTJZIhcJA.Length; i++)
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[i] = new cGZOZxuMPBUEDWGrYEmrwMGYgopS(i);
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
			return Input.GetAxis(elKJbbxESyfcuzfcxFoUDTJZIhcJA[joystickId - 1].pvHNgMKSWvFRvLaLvOpzsGxXmHFe[axisIndex]);
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
			return Input.GetAxisRaw(elKJbbxESyfcuzfcxFoUDTJZIhcJA[joystickId - 1].pvHNgMKSWvFRvLaLvOpzsGxXmHFe[axisIndex]);
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
			return Input.GetButton(elKJbbxESyfcuzfcxFoUDTJZIhcJA[num].yiLCnoEiYpxfzsmLEpoLBCiFaluJA[buttonIndex]);
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
