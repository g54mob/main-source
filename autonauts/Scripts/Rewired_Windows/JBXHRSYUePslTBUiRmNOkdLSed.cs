using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils;

internal static class JBXHRSYUePslTBUiRmNOkdLSed
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool qikinwRMdddCMTczAhcYsXRMJqL(IntPtr hwnd, IntPtr lParam);

	private static IntPtr etBhGkiynzcvWfnGOFBmufcIzSBq = IntPtr.Zero;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int JLGgBCGxGpJFSLYZADpbNkpqfQER();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint bhPZGUUMRgGZOstafjWcWqgBEdsB();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int WjyQvDNDKWhHKOOdkRkvWrjWVqy(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int veTcbeBxaVwjmDLVKHxfKDjwkNda(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int veTcbeBxaVwjmDLVKHxfKDjwkNda(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool AnAeHuJanzPqZkLPmoGjZJUhxmjb(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KkPwmbNaAKGSELHWQvTjtRmNOWG(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr cuFBIcGTgnQlafsXvuWdxeCQBTwJ(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr gUKmXsNoGigDIWXEACGrdgvXgdn();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr jzJWTIUIZndALgJMLSYbUHSlnYxe(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr YYfSiaChMKlkMWXLCoEpZckUWia(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool RLgFEaVOrxAZJelaMDfUCUaueAsh(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr yoQtBacLUlDUdSyncKeDbkgAmGz(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int OXzeIxEKtZRUVKojhVpdvVQRGnOS();

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr zFMhHQeCuyMuaKJnpjvMYulRIjeh(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr HQHCWOQDNOjtwCmLFfSymBuSFrRY(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr gGxhDgOROiMLYGkWnwoVpXCUwEo(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool sUINSIpoBDQywHGfUGanihFqIuNi(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr bVQBuQKNiTydnjTTUAaqfzWItVQ();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr sjRecMcgTOklbzOJZjMpwunTtII();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr SjhdLgwUpKBDLNKnstwrnFdgWQM();

	public static IntPtr xHBNqgPOuCeQzEsleLDbToBMqGyy(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return VZZoZZNNUwuYqNAYfdXozmXueTX(P_0, P_1);
		}
		return DgOHeVoqSyHhvgJBlYaHcfZdCkX(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr VZZoZZNNUwuYqNAYfdXozmXueTX(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr DgOHeVoqSyHhvgJBlYaHcfZdCkX(IntPtr P_0, int P_1);

	public static IntPtr WrvwiumnVpRrknOzqfIQjkRUvaiT(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return xjLiMJdFcjQCWgtreTDjztrafXt(P_0, P_1, P_2);
		}
		return tzFCxyVXlcvgJHkhPUsBqDIaDOu(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr tzFCxyVXlcvgJHkhPUsBqDIaDOu(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr xjLiMJdFcjQCWgtreTDjztrafXt(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr bCcjOEyrOvbhTiAExpftaOWRWbTS(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool lPDDNqGZsSnODCdEixQmZPafFvx(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint BOnEWFgxPIHNRJLtWeCDpnjZyld(IntPtr P_0, out uint P_1);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint bVxMTZivDFHtTShPGrdWuAdCjlYb(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint VqKTuzcRRekFAIbEWeGCVcXzFGv(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int yRFQFPVwTMIUWkGhSsOgFBGKcZb(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool sFqOmCVcPzfsatNBpySpCKDgTfp(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool lzMErRjTJMnvfnBnYdTpZuQcKjjT(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int mYbhSEuZYXfhTkpztNKCjgplpec(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool iPVRxqZSJlwzGzcuQMgbevqorjK(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool iPVRxqZSJlwzGzcuQMgbevqorjK(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool AXGbVHChdoJrakcCzrYdXSxMNAr(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AXGbVHChdoJrakcCzrYdXSxMNAr(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mmfdHmeHmjpfksPFIFPlYaThpQs(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr mmfdHmeHmjpfksPFIFPlYaThpQs(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IFlmuSnNcORHfRbZdFxXtIIITAU(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool IFlmuSnNcORHfRbZdFxXtIIITAU(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* AJehDOiilOoEoIpWToIXLLYzFNGf(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr AJehDOiilOoEoIpWToIXLLYzFNGf(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr TpBvmGJKTcJZnpGZoNcZLsXxDoc(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool WfjkOuLxElfSBWOqWLboRufdNNB(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool YtcMeuwtkYMRNuXALPjkqdoGKSc(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool UnmUWizmVlqjXECEqkyqwXyQDPg(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool FhudhlMnsjZaURNIfiCdjrMXGQZh(out fbCIljEIqeWnDBsIXmOSKczvIIKv P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr CMeoeVoOGroqwlIFmUJlGJRgwyf(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short uLmHXherdKAqgJpPigYcnDLCvMh(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool HCelXLNAkxRudaKdzikKGrcdQfq(IntPtr P_0, out fbCIljEIqeWnDBsIXmOSKczvIIKv P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool yxoFHbmHkuupeNeoqBQmOPiJFVp(IntPtr P_0, out KdXNtZWhEqUsLCdeMPrOOTiQfav P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool OOMWZWTZLWlzZmTtPPbUTCcWbIa(IntPtr P_0, out KdXNtZWhEqUsLCdeMPrOOTiQfav P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint HnzucBHfgCjfzVgaOukUwHSykyn(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint kAiWTOagLDzrUcyvoLKawAjJpty(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr BDWnVCypAYfvYGGmuoMJMEWMyar(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool kCmAAVpZumHcATfcNSxGfamMFmG(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool nWkFphaDHQGcvihSpxZHGwhfGBn(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool nWkFphaDHQGcvihSpxZHGwhfGBn(void* P_0, void* P_1, int P_2)
	{
		return nWkFphaDHQGcvihSpxZHGwhfGBn(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr BwcrcaWbYgaFuQmgRzzaiBJGcym()
	{
		if (!UnityTools.isEditor && etBhGkiynzcvWfnGOFBmufcIzSBq != IntPtr.Zero)
		{
			return etBhGkiynzcvWfnGOFBmufcIzSBq;
		}
		return etBhGkiynzcvWfnGOFBmufcIzSBq = bVQBuQKNiTydnjTTUAaqfzWItVQ();
	}
}
