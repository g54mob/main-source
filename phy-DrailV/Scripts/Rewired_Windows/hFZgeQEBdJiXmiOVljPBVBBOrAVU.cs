using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class hFZgeQEBdJiXmiOVljPBVBBOrAVU
{
	public const int dyrIEJghoaUPppKVChhCpPZthczX = 2048;

	public unsafe static void wdDhdqoMGqWiYPPqxbATqaLcNxxj(IntPtr P_0, int P_1, Guid P_2, out IntPtr P_3, YutCLanOuXTAhakKQUOtqCxgUWzR P_4)
	{
		DbnCtpkhshHcbMgtFHqviAcvNRIz dbnCtpkhshHcbMgtFHqviAcvNRIz;
		fixed (IntPtr* ptr = &P_3)
		{
			void* ptr2 = ptr;
			dbnCtpkhshHcbMgtFHqviAcvNRIz = DbnCtpkhshHcbMgtFHqviAcvNRIz.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(kyYxdsHLqJQRDFIzjqbzFWehKNaV((void*)P_0, P_1, &P_2, ptr2, (void*)(P_4?.GMaPHoiZAJyngdXeSoVFwLOeWHKm ?? IntPtr.Zero)));
		}
		dbnCtpkhshHcbMgtFHqviAcvNRIz.AiQfqmvlXZCQZcniQgqmSYHkqARaA();
	}

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Create")]
	[SuppressUnmanagedCodeSecurity]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int kyYxdsHLqJQRDFIzjqbzFWehKNaV(void* P_0, int P_1, void* P_2, void* P_3, void* P_4);
}
