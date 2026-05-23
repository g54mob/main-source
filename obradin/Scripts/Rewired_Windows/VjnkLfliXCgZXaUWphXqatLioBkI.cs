using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class VjnkLfliXCgZXaUWphXqatLioBkI
{
	public const int FUPfXeLuKfHAARzYWlgbVNHBfGY = 2048;

	public unsafe static void ShdFOHHKorASzvRKncbqFEJGkAWG(IntPtr P_0, int P_1, Guid P_2, out IntPtr P_3, gZHsmLYRWYRWOYtXCrCKGLdQONK P_4)
	{
		jYVOPQCYHiqgKMeoByaWkMeLSnl jYVOPQCYHiqgKMeoByaWkMeLSnl2;
		fixed (IntPtr* ptr = &P_3)
		{
			jYVOPQCYHiqgKMeoByaWkMeLSnl2 = YRiKcDqCyMDetzccptbOdetJWqD((void*)P_0, P_1, &P_2, ptr, (void*)((P_4 == null) ? IntPtr.Zero : P_4.NativePointer));
		}
		jYVOPQCYHiqgKMeoByaWkMeLSnl2.ekcBiXGMbYMGcLEdCGmXypFMzRo();
	}

	[DllImport("Rewired_DirectInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "DirectInput8_Create")]
	[SuppressUnmanagedCodeSecurity]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YRiKcDqCyMDetzccptbOdetJWqD(void* P_0, int P_1, void* P_2, void* P_3, void* P_4);
}
