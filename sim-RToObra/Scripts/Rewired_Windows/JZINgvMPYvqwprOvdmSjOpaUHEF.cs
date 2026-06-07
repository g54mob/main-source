using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal static class JZINgvMPYvqwprOvdmSjOpaUHEF
{
	public static string xasgtlUXWJTxElKqvjYdHbuAJXr(IntPtr P_0, int P_1)
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
		goto IL_0042;
		IL_0020:
		int num = -1563860769;
		goto IL_0025;
		IL_0025:
		IntPtr intPtr = default(IntPtr);
		string result = default(string);
		while (true)
		{
			switch (num ^ -1563860772)
			{
			case 0:
				break;
			case 3:
				goto IL_0042;
			case 1:
				NativeTools.CopyMemory(P_0, intPtr, 0, 0, P_1);
				Marshal.WriteInt16(intPtr, P_1, 0);
				result = Marshal.PtrToStringUni(intPtr);
				num = -1563860770;
				continue;
			default:
				Marshal.FreeHGlobal(intPtr);
				return result;
			}
			break;
		}
		goto IL_0020;
		IL_0042:
		intPtr = Marshal.AllocHGlobal(P_1 + 2);
		num = -1563860771;
		goto IL_0025;
	}
}
