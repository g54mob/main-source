using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal static class GTPAhGInkBQTUcszeVNtCWZheShf
{
	public static string eafrxYrHibsUpicgkqFhVdRebFP(IntPtr P_0, int P_1)
	{
		if (P_1 <= 0)
		{
			goto IL_0004;
		}
		int num;
		int num2;
		if (P_1 < 2)
		{
			num = -942998701;
			num2 = num;
		}
		else
		{
			num = -942998704;
			num2 = num;
		}
		goto IL_0009;
		IL_0004:
		num = -942998703;
		goto IL_0009;
		IL_0009:
		IntPtr intPtr = default(IntPtr);
		string result = default(string);
		while (true)
		{
			switch (num ^ -942998704)
			{
			case 4:
				break;
			case 1:
				return null;
			case 0:
			{
				int num3;
				if (Marshal.ReadByte(P_0, P_1 - 1) == 0)
				{
					num = -942998702;
					num3 = num;
				}
				else
				{
					num = -942998701;
					num3 = num;
				}
				continue;
			}
			case 3:
				intPtr = Marshal.AllocHGlobal(P_1 + 2);
				NativeTools.CopyMemory(P_0, intPtr, 0, 0, P_1);
				Marshal.WriteInt16(intPtr, P_1, 0);
				result = Marshal.PtrToStringUni(intPtr);
				num = -942998699;
				continue;
			case 2:
				if (Marshal.ReadByte(P_0, P_1 - 2) != 0)
				{
					num = -942998701;
					continue;
				}
				return Marshal.PtrToStringUni(P_0);
			default:
				Marshal.FreeHGlobal(intPtr);
				return result;
			}
			break;
		}
		goto IL_0004;
	}
}
