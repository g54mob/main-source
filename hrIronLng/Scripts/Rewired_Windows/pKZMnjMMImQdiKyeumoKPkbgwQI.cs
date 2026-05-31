using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class pKZMnjMMImQdiKyeumoKPkbgwQI
{
	public unsafe static int WPimmLUNirHddOMGogIEehnEPAPc(AZmbvcVIunYbHEntMIOGHkdhIws[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = tbueYrAGJSYIgANkQLFlYGMDsNi(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tbueYrAGJSYIgANkQLFlYGMDsNi(void* P_0, void* P_1, int P_2);

	public unsafe static int mwMKDgrBrcPjXwXLTxoVdEkzDkb(CtNYpbJCDqfBuwgobuGKPnMOhUT[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = JafjHdndvSPhZmgkIXNkfNDxnTJ(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JafjHdndvSPhZmgkIXNkfNDxnTJ(void* P_0, void* P_1, int P_2);

	public unsafe static int uXdQxHDpZlhDnraSJLluJrIrfUF(IntPtr P_0, yDzOYwhrGcjGweXvPzNXXJeRUPD P_1, IntPtr P_2, ref int P_3)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = mXDZUTxRaAbJaYHMTciUcgkPHHmy((void*)P_0, (int)P_1, (void*)P_2, ptr);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int mXDZUTxRaAbJaYHMTciUcgkPHHmy(void* P_0, int P_1, void* P_2, void* P_3);

	public unsafe static gKQaduAqSOGwbLhlzfnbbSwcienb tnkrQmbACuXnOzOegYrmbelFiJ(CtNYpbJCDqfBuwgobuGKPnMOhUT[] P_0, int P_1, int P_2)
	{
		gKQaduAqSOGwbLhlzfnbbSwcienb result;
		fixed (IntPtr* ptr = P_0)
		{
			result = QJuqgMblUZkoTVTgvlRazDuUDzC(ptr, P_1, P_2);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern gKQaduAqSOGwbLhlzfnbbSwcienb QJuqgMblUZkoTVTgvlRazDuUDzC(void* P_0, int P_1, int P_2);

	public unsafe static int WgZDhIiQBPfslnwjTubhPxUhEtU(oJqDOpLSpzXpieFwwDGOPDuUBLb[] P_0, ref int P_1, int P_2)
	{
		int result;
		fixed (IntPtr* ptr = P_0)
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_1))
			{
				result = yuyzKBPOKfJsphNKuyVRsDAyJaw(ptr, ptr2, P_2);
			}
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yuyzKBPOKfJsphNKuyVRsDAyJaw(void* P_0, void* P_1, int P_2);

	public unsafe static int tYywPmEMznZgYESvREorQiNjYWS(IntPtr P_0, vJEfxIGFfCJqylTBjQxgDpIzhTAl P_1, IntPtr P_2, ref int P_3, int P_4)
	{
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref P_3))
		{
			result = DgTpGWCnYdfHEGBsVrzhJjQGfeZ((void*)P_0, (int)P_1, (void*)P_2, ptr, P_4);
		}
		return result;
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DgTpGWCnYdfHEGBsVrzhJjQGfeZ(void* P_0, int P_1, void* P_2, void* P_3, int P_4);
}
