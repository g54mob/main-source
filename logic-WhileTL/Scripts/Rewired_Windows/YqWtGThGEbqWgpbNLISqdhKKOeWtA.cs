using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class YqWtGThGEbqWgpbNLISqdhKKOeWtA
{
	public unsafe static int hNvdifvMuydvvzHlJFkaHRZkfOLib(vKvFfEaUEqcCLatCfsioGxOBRYwwB[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (vKvFfEaUEqcCLatCfsioGxOBRYwwB* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = ALrfkXDrQRrCaLpwbThTbkevmkqnA(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ALrfkXDrQRrCaLpwbThTbkevmkqnA(void* P_0, void* P_1, int P_2);

	public unsafe static int FoReCIGAbbhJVzHigbNzKNOFJoleA(rTYrKTomZpsJmTDLUtskruaoaALV[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (rTYrKTomZpsJmTDLUtskruaoaALV* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = wqfyhtSepcMDjTKLZdddXxltexPN(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wqfyhtSepcMDjTKLZdddXxltexPN(void* P_0, void* P_1, int P_2);

	public unsafe static int XlwDOxckXwHphGgfgIzKrHoBHnNgA(IntPtr P_0, ZHyvCoWKvlnvwNTkgaBjzQzrHSLu P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = LWOxzGUcZDNmjijaKEiKiMzqFex((void*)P_0, (int)P_1, (void*)P_2, ptr2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LWOxzGUcZDNmjijaKEiKiMzqFex(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static JaNvVEJIEJchbSjGQfXLgxYEamlQ EyoywHPTfXloHpSANWMmGoJLRBcu(rTYrKTomZpsJmTDLUtskruaoaALV[] P_0, int P_1, int P_2)
	{
		JaNvVEJIEJchbSjGQfXLgxYEamlQ result;
		fixed (rTYrKTomZpsJmTDLUtskruaoaALV* ptr = P_0)
		{
			void* ptr2 = ptr;
			result = ddriuqUbWWhcPeqXAPJUFeQclfUV(ptr2, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern JaNvVEJIEJchbSjGQfXLgxYEamlQ ddriuqUbWWhcPeqXAPJUFeQclfUV(void* P_0, int P_1, int P_2);

	public unsafe static int dvAhNcDpZGovnYKSchKXtNiNzIOV(HDnhBREyWmXPeHmoTZzebZvcPyvf[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (HDnhBREyWmXPeHmoTZzebZvcPyvf* ptr = P_0)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &P_1)
			{
				void* ptr4 = ptr3;
				result = TFtfdduXKifZxiUsVjKxYRhMhTycA(ptr2, ptr4, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TFtfdduXKifZxiUsVjKxYRhMhTycA(void* P_0, void* P_1, int P_2);

	public unsafe static int UmrFWFnlgceBCrWCcQpHqpiJMEIF(IntPtr P_0, WdZrzicdiXusiaqGKRYGVgaNZeWE P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (int* ptr = &P_3)
		{
			void* ptr2 = ptr;
			result = qEUCKytoAgFVEhzFujBZxwoyoWHk((void*)P_0, (int)P_1, (void*)P_2, ptr2, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qEUCKytoAgFVEhzFujBZxwoyoWHk(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
