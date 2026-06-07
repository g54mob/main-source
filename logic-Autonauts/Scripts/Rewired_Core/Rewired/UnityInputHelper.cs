using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class UnityInputHelper
	{
		private class dIUAfFaELYqVDsuWSNpmadBpWMl
		{
			public string[] suEsVcYOaqKlbfPKrZFuofLgCiX;

			public string[] xIIOtOIuEykpnAueUtuKVMbkTfu;

			public dIUAfFaELYqVDsuWSNpmadBpWMl(int joystickIndex)
			{
				suEsVcYOaqKlbfPKrZFuofLgCiX = new string[29];
				for (int i = 0; i < suEsVcYOaqKlbfPKrZFuofLgCiX.Length; i++)
				{
					suEsVcYOaqKlbfPKrZFuofLgCiX[i] = UnityTools.GetUnityInputAxisName(joystickIndex, i);
				}
				if (joystickIndex + 1 > 16)
				{
					xIIOtOIuEykpnAueUtuKVMbkTfu = new string[20];
					for (int j = 0; j < xIIOtOIuEykpnAueUtuKVMbkTfu.Length; j++)
					{
						xIIOtOIuEykpnAueUtuKVMbkTfu[j] = UnityTools.GetUnityInputButtonName(joystickIndex, j);
					}
				}
			}
		}

		private static dIUAfFaELYqVDsuWSNpmadBpWMl[] jkFiqNnyAtbymFOLlvWZRfYeLku;

		static UnityInputHelper()
		{
			jkFiqNnyAtbymFOLlvWZRfYeLku = new dIUAfFaELYqVDsuWSNpmadBpWMl[16];
			int num = 0;
			while (num < jkFiqNnyAtbymFOLlvWZRfYeLku.Length)
			{
				while (true)
				{
					jkFiqNnyAtbymFOLlvWZRfYeLku[num] = new dIUAfFaELYqVDsuWSNpmadBpWMl(num);
					num++;
					int num2 = 834100394;
					while (true)
					{
						switch (num2 ^ 0x31B75CA8)
						{
						case 0:
							num2 = 834100393;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002e;
						}
						break;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
		}

		public static float GetJoystickAxisValueByJoystickId(int joystickId, int axisIndex)
		{
			int num;
			if (joystickId > 0)
			{
				if (joystickId > 16)
				{
					goto IL_0009;
				}
				if (axisIndex >= 29)
				{
					num = -816844798;
					goto IL_000e;
				}
				return Input.GetAxis(jkFiqNnyAtbymFOLlvWZRfYeLku[joystickId - 1].suEsVcYOaqKlbfPKrZFuofLgCiX[axisIndex]);
			}
			goto IL_0027;
			IL_000e:
			switch (num ^ -816844798)
			{
			case 2:
				break;
			case 1:
				goto IL_0027;
			default:
				return 0f;
			}
			goto IL_0009;
			IL_0009:
			num = -816844797;
			goto IL_000e;
			IL_0027:
			return 0f;
		}

		public static float GetJoystickAxisRawValueByJoystickId(int joystickId, int axisIndex)
		{
			if (joystickId > 0)
			{
				while (true)
				{
					int num = 1854603506;
					while (true)
					{
						switch (num ^ 0x6E8B00F0)
						{
						case 0:
							break;
						case 2:
							goto IL_0022;
						default:
							goto end_IL_0004;
						}
						break;
						IL_0022:
						if (joystickId > 16)
						{
							num = 1854603505;
							continue;
						}
						goto IL_0034;
					}
					continue;
					IL_0034:
					if (axisIndex >= 29)
					{
						return 0f;
					}
					return Input.GetAxisRaw(jkFiqNnyAtbymFOLlvWZRfYeLku[joystickId - 1].suEsVcYOaqKlbfPKrZFuofLgCiX[axisIndex]);
					continue;
					end_IL_0004:
					break;
				}
			}
			return 0f;
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
			KeyCode key = default(KeyCode);
			int num2;
			if (joystickId > 0)
			{
				if (joystickId > 16)
				{
					goto IL_0009;
				}
				if (buttonIndex >= 20)
				{
					return false;
				}
				int num = joystickId - 1;
				if (joystickId <= 16)
				{
					key = (KeyCode)(350 + 20 * num + buttonIndex);
					num2 = -24779553;
					goto IL_000e;
				}
				return Input.GetButton(jkFiqNnyAtbymFOLlvWZRfYeLku[num].xIIOtOIuEykpnAueUtuKVMbkTfu[buttonIndex]);
			}
			goto IL_0027;
			IL_0027:
			return false;
			IL_000e:
			switch (num2 ^ -24779554)
			{
			case 0:
				break;
			case 2:
				goto IL_0027;
			default:
				return Input.GetKey(key);
			}
			goto IL_0009;
			IL_0009:
			num2 = -24779556;
			goto IL_000e;
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
