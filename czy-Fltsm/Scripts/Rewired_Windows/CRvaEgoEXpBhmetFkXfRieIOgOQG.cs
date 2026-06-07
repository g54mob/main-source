using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal static class CRvaEgoEXpBhmetFkXfRieIOgOQG
{
	public static string KYYjNruvWHRInCzpPUXuomPmZWmE(IntPtr P_0, int P_1)
	{
		if (P_1 <= 0)
		{
			return null;
		}
		if (P_1 < 2 || Marshal.ReadByte(P_0, P_1 - 1) != 0 || Marshal.ReadByte(P_0, P_1 - 2) != 0)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(P_1 + 2);
			NativeTools.CopyMemory(P_0, intPtr, 0, 0, P_1);
			Marshal.WriteInt16(intPtr, P_1, 0);
			string result = Marshal.PtrToStringUni(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}
		return YWkGsIHYlDIguwYLNWmfoYKPjfCBA(Marshal.PtrToStringUni(P_0));
	}

	public static string CBOCWDdYXJBVmFxLOudnvBjMbXGFA(IntPtr P_0, int P_1)
	{
		return YWkGsIHYlDIguwYLNWmfoYKPjfCBA(Marshal.PtrToStringUni(P_0, P_1));
	}

	public static string YWkGsIHYlDIguwYLNWmfoYKPjfCBA(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return P_0;
		}
		if (P_0.Length == 0)
		{
			return P_0;
		}
		if (P_0[P_0.Length - 1] != 0)
		{
			return P_0;
		}
		return P_0.Substring(0, P_0.Length - 1);
	}
}
