using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class jxXVRtrKctCszoSimyXlnxDYhtOW
{
	public const int UVPYmRgLDZWrFOeqyIGoAJWqpDJP = 2048;

	public unsafe static void ZBbGANvmLVRrqLiiLYsFvEdpstQv(IntPtr P_0, int P_1, Guid P_2, out IntPtr P_3, MndfuDfWnbszkTmnTPSZnWvaJpehA P_4)
	{
		HgnaIMWLxDFBogoGAwoPjgchNwNZA hgnaIMWLxDFBogoGAwoPjgchNwNZA;
		fixed (IntPtr* ptr = &P_3)
		{
			void* ptr2 = ptr;
			hgnaIMWLxDFBogoGAwoPjgchNwNZA = HgnaIMWLxDFBogoGAwoPjgchNwNZA.novAKpQUqNNolfQYKOuutEDBCrVR(WsHFWDAwRCmlUyGqBvKXJRnGlVpg((void*)P_0, P_1, &P_2, ptr2, (void*)(P_4?.cOaLXRsqVRuSojLsgpkROlcJOCEr ?? IntPtr.Zero)));
		}
		hgnaIMWLxDFBogoGAwoPjgchNwNZA.FtNmXGTwjjuRLXbQooQDVQXVbiejA();
	}

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Create")]
	[SuppressUnmanagedCodeSecurity]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int WsHFWDAwRCmlUyGqBvKXJRnGlVpg(void* P_0, int P_1, void* P_2, void* P_3, void* P_4);
}
