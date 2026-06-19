using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class UnityInputHelper
	{
		private class AqxyEIXEAxbStEXiCzxzdnxMMccrA
		{
			public string[] PfHMdLiqbytaggYdwjJFozquZjzf;

			public string[] snVsyTInthbPZZOxZHrVOsXXXIrB;

			public AqxyEIXEAxbStEXiCzxzdnxMMccrA(int P_0)
			{
				PfHMdLiqbytaggYdwjJFozquZjzf = new string[29];
				for (int i = 0; i < PfHMdLiqbytaggYdwjJFozquZjzf.Length; i++)
				{
					PfHMdLiqbytaggYdwjJFozquZjzf[i] = UnityTools.GetUnityInputAxisName(P_0, i);
				}
				if (P_0 + 1 > 16)
				{
					snVsyTInthbPZZOxZHrVOsXXXIrB = new string[20];
					for (int j = 0; j < snVsyTInthbPZZOxZHrVOsXXXIrB.Length; j++)
					{
						snVsyTInthbPZZOxZHrVOsXXXIrB[j] = UnityTools.GetUnityInputButtonName(P_0, j);
					}
				}
			}
		}

		private static AqxyEIXEAxbStEXiCzxzdnxMMccrA[] EDcWQyJEaMvaeqeHvxeGAoufuUfO;

		static UnityInputHelper()
		{
			EDcWQyJEaMvaeqeHvxeGAoufuUfO = new AqxyEIXEAxbStEXiCzxzdnxMMccrA[16];
			for (int i = 0; i < EDcWQyJEaMvaeqeHvxeGAoufuUfO.Length; i++)
			{
				EDcWQyJEaMvaeqeHvxeGAoufuUfO[i] = new AqxyEIXEAxbStEXiCzxzdnxMMccrA(i);
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
			return Input.GetAxis(EDcWQyJEaMvaeqeHvxeGAoufuUfO[joystickId - 1].PfHMdLiqbytaggYdwjJFozquZjzf[axisIndex]);
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
			return Input.GetAxisRaw(EDcWQyJEaMvaeqeHvxeGAoufuUfO[joystickId - 1].PfHMdLiqbytaggYdwjJFozquZjzf[axisIndex]);
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
			return Input.GetButton(EDcWQyJEaMvaeqeHvxeGAoufuUfO[num].snVsyTInthbPZZOxZHrVOsXXXIrB[buttonIndex]);
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
