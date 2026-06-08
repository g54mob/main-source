using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class UnityInputHelper
	{
		private class WhIpGAQFsCrIIXhrJzYdoTfaFBI
		{
			public string[] VwUbDdEqpqoVsZYgqEgrjcpevFan;

			public string[] YHGHlHoNtkOhmbsNDxUBNKVvRCH;

			public WhIpGAQFsCrIIXhrJzYdoTfaFBI(int joystickIndex)
			{
				VwUbDdEqpqoVsZYgqEgrjcpevFan = new string[29];
				for (int i = 0; i < VwUbDdEqpqoVsZYgqEgrjcpevFan.Length; i++)
				{
					VwUbDdEqpqoVsZYgqEgrjcpevFan[i] = UnityTools.GetUnityInputAxisName(joystickIndex, i);
				}
				if (joystickIndex + 1 > 16)
				{
					YHGHlHoNtkOhmbsNDxUBNKVvRCH = new string[20];
					for (int j = 0; j < YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length; j++)
					{
						YHGHlHoNtkOhmbsNDxUBNKVvRCH[j] = UnityTools.GetUnityInputButtonName(joystickIndex, j);
					}
				}
			}
		}

		private static WhIpGAQFsCrIIXhrJzYdoTfaFBI[] KjXmBSVldpfwjiNaozEQFsyjEtD;

		static UnityInputHelper()
		{
			KjXmBSVldpfwjiNaozEQFsyjEtD = new WhIpGAQFsCrIIXhrJzYdoTfaFBI[16];
			int num = 0;
			while (num < KjXmBSVldpfwjiNaozEQFsyjEtD.Length)
			{
				while (true)
				{
					KjXmBSVldpfwjiNaozEQFsyjEtD[num] = new WhIpGAQFsCrIIXhrJzYdoTfaFBI(num);
					num++;
					int num2 = 465061632;
					while (true)
					{
						switch (num2 ^ 0x1BB84700)
						{
						case 2:
							num2 = 465061633;
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
					num = -1143354604;
					goto IL_000e;
				}
				return Input.GetAxis(KjXmBSVldpfwjiNaozEQFsyjEtD[joystickId - 1].VwUbDdEqpqoVsZYgqEgrjcpevFan[axisIndex]);
			}
			goto IL_0027;
			IL_000e:
			switch (num ^ -1143354602)
			{
			case 0:
				break;
			case 1:
				goto IL_0027;
			default:
				return 0f;
			}
			goto IL_0009;
			IL_0009:
			num = -1143354601;
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
					int num = 1056759797;
					while (true)
					{
						switch (num ^ 0x3EFCDFF4)
						{
						case 3:
							break;
						case 1:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							return 0f;
						}
						break;
						IL_0026:
						if (joystickId > 16)
						{
							num = 1056759798;
							continue;
						}
						if (axisIndex >= 29)
						{
							num = 1056759796;
							continue;
						}
						return Input.GetAxisRaw(KjXmBSVldpfwjiNaozEQFsyjEtD[joystickId - 1].VwUbDdEqpqoVsZYgqEgrjcpevFan[axisIndex]);
					}
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
			return Input.GetButton(KjXmBSVldpfwjiNaozEQFsyjEtD[num].YHGHlHoNtkOhmbsNDxUBNKVvRCH[buttonIndex]);
		}

		public static bool GetJoystickButtonValueByJoystickIndex(int joystickIndex, int buttonIndex)
		{
			return GetJoystickButtonValueByJoystickId(joystickIndex + 1, buttonIndex);
		}
	}
}
