using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class kaKSjRDqyXTrOnqKpcpOqXaZcszV
{
	public unsafe static int mcHHOzHhEDgYWQdAPKbdaoKrcHQlA(TKfiIAMvoMajpzMHXaNGeewCQKDyA[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (TKfiIAMvoMajpzMHXaNGeewCQKDyA* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = dpVgXkeFWtyzrnoIsKTXahAfvOIMB(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dpVgXkeFWtyzrnoIsKTXahAfvOIMB(void* P_0, void* P_1, int P_2);

	public unsafe static int wQeEOfASaRnDWnAMIMXnyLfgUHGm(NiIUnPYpvHjaCXcCqYNIeLExhAsW[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (NiIUnPYpvHjaCXcCqYNIeLExhAsW* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = MxqWtGkhEALFutTrzRbdUUAgkzBv(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MxqWtGkhEALFutTrzRbdUUAgkzBv(void* P_0, void* P_1, int P_2);

	public unsafe static int gCaBVHcFDNAIRjsqxfsDKqoRoDOeA(IntPtr P_0, pTeNfaiQPJQOABjhAtwFmlBqEIsv P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = OCiCBqabyPJdnoicxlyiwOJeQidyA((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OCiCBqabyPJdnoicxlyiwOJeQidyA(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static ppRQyWnmulBELSJBkakjdHwFfqEn dXWHlIKCBGexMFVfyeVwnnjuZXxO(NiIUnPYpvHjaCXcCqYNIeLExhAsW[] P_0, int P_1, int P_2)
	{
		ppRQyWnmulBELSJBkakjdHwFfqEn result;
		fixed (NiIUnPYpvHjaCXcCqYNIeLExhAsW* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = sYfaWwkvGvnXYnijRYpvupxOwsBf(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern ppRQyWnmulBELSJBkakjdHwFfqEn sYfaWwkvGvnXYnijRYpvupxOwsBf(void* P_0, int P_1, int P_2);

	public unsafe static int QmUvVxtgOxURMpbgDNUUyxMFBpdM(lnpeeBWlsKrkONptvHYKoRRtgPSS[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (lnpeeBWlsKrkONptvHYKoRRtgPSS* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = aumJULCawouzOJzuPTeuOZIeWhLp(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int aumJULCawouzOJzuPTeuOZIeWhLp(void* P_0, void* P_1, int P_2);

	public unsafe static int fiWOtwJeuGtdHSTuqjbuFgffZayw(IntPtr P_0, asBOkuGRNrZaGgVhakFwMZKOZMrl P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = SdBcECpAAmEvYCIepkMiFRszCcDUA((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SdBcECpAAmEvYCIepkMiFRszCcDUA(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
