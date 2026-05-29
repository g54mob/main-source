using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal static class PamfrXpXIdpBicuXCMSnRCymMDB
{
	public static string vYOolJlGKPrAHmuOGpjjEBcqxDv(IntPtr P_0, int P_1)
	{
		if (P_1 <= 0)
		{
			return null;
		}
		if (P_1 >= 2 && Marshal.ReadByte(P_0, P_1 - 1) == 0)
		{
			if (Marshal.ReadByte(P_0, P_1 - 2) == 0)
			{
				return Marshal.PtrToStringUni(P_0);
			}
			goto IL_0020;
		}
		goto IL_003e;
		IL_0020:
		int num = -507199711;
		goto IL_0025;
		IL_0025:
		IntPtr intPtr = default(IntPtr);
		switch (num ^ -507199712)
		{
		case 0:
			break;
		case 1:
			goto IL_003e;
		default:
		{
			string result = Marshal.PtrToStringUni(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}
		}
		goto IL_0020;
		IL_003e:
		intPtr = Marshal.AllocHGlobal(P_1 + 2);
		NativeTools.CopyMemory(P_0, intPtr, 0, 0, P_1);
		Marshal.WriteInt16(intPtr, P_1, 0);
		num = -507199710;
		goto IL_0025;
	}
}
