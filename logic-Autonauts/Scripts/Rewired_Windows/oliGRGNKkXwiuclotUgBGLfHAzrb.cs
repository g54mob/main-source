using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class oliGRGNKkXwiuclotUgBGLfHAzrb
{
	public unsafe static int BPLpGwHAjAXazyEQjUcPsyqfBme(LADuiFGLyWwoVgUpRvCDCAvWPRP[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = qbZtdUPMkxnakiDBVYVsVzNwQvF(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qbZtdUPMkxnakiDBVYVsVzNwQvF(void* P_0, void* P_1, int P_2);

	public unsafe static int bVxMTZivDFHtTShPGrdWuAdCjlYb(RzgDDUDQfFvpevEasDYTCEFKxZga[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = CSBhiagZZCqnhOCgdANIHqEaNkqK(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int CSBhiagZZCqnhOCgdANIHqEaNkqK(void* P_0, void* P_1, int P_2);

	public unsafe static int beAvBqIfnQADpXrEEhLtEMDYIoqA(IntPtr P_0, fkKENruIJFtZgOgHQXnQULUeJLi P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = zwyPCksrOpzugeaKOeLTxdpucYZ((void*)P_0, (int)P_1, (void*)P_2, ptr);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int zwyPCksrOpzugeaKOeLTxdpucYZ(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static hffboTtMgbbEhgBbkOhyJBfJupGf uASjbShpTjrAZivdbJaNrLkIbIX(RzgDDUDQfFvpevEasDYTCEFKxZga[] P_0, int P_1, int P_2)
	{
		hffboTtMgbbEhgBbkOhyJBfJupGf result;
		fixed (IntPtr* ptr = P_0)
		{
			result = VkDhrzwqRqYaBpoeepRbqxRpwtp(ptr, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern hffboTtMgbbEhgBbkOhyJBfJupGf VkDhrzwqRqYaBpoeepRbqxRpwtp(void* P_0, int P_1, int P_2);

	public unsafe static int XNeyCrfrrexZfNQrOuysQuPKIBz(xkJqMOEQeGTfwKaRfpLTGoGtuOK[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = nVDrsgMieYAvnbTNpSuMrfSHLMXi(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nVDrsgMieYAvnbTNpSuMrfSHLMXi(void* P_0, void* P_1, int P_2);

	public unsafe static int yRFQFPVwTMIUWkGhSsOgFBGKcZb(IntPtr P_0, gIniJfYyHnUmyxkBerOleDUKGaz P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = MziNQrFauGnlGwgeQkneGgJnHric((void*)P_0, (int)P_1, (void*)P_2, ptr, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MziNQrFauGnlGwgeQkneGgJnHric(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
