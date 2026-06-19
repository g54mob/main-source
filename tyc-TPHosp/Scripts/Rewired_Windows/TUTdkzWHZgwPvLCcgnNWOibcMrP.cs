using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class TUTdkzWHZgwPvLCcgnNWOibcMrP
{
	public const int VHxGVmewEZLksMQgJQLPWgvHqopd = 2048;

	public unsafe static void ACHgaXaFqNzLRoWaiZKCdCrIhBd(IntPtr P_0, int P_1, Guid P_2, out IntPtr P_3, gEzWBZtKpodhyJneHyYqvTiSSEh P_4)
	{
		llpFqWliQEfHkPmCCWtyJDAPdFG llpFqWliQEfHkPmCCWtyJDAPdFG2;
		fixed (IntPtr* ptr = &P_3)
		{
			llpFqWliQEfHkPmCCWtyJDAPdFG2 = WhQReFRCWsvqQsPCsSDuSgMBeZqA((void*)P_0, P_1, &P_2, ptr, (void*)(P_4?.NativePointer ?? IntPtr.Zero));
		}
		llpFqWliQEfHkPmCCWtyJDAPdFG2.oCKdtZanlshnKAQVdRIdxFviUCRp();
	}

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Create")]
	[SuppressUnmanagedCodeSecurity]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int WhQReFRCWsvqQsPCsSDuSgMBeZqA(void* P_0, int P_1, void* P_2, void* P_3, void* P_4);
}
