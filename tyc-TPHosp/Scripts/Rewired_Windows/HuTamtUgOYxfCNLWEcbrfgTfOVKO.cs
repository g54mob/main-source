using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils;

internal static class HuTamtUgOYxfCNLWEcbrfgTfOVKO
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool cYaESxtkVRLfcDDPKpSRfQltmIp(IntPtr hwnd, IntPtr lParam);

	private static IntPtr idBhrIasrPEVndsAwTtUPkQwgLkE = IntPtr.Zero;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int FVIDwepLQLprvMCLqHFZSKFWcPt();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint lRZhfgKnTUtzdybkVtmGibCzmsR();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int QVgddlDcKyDOrMRvKjqZwGLiCuX(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int fpNJESlsgvmZNVDFoANBCnNOTCQB(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int fpNJESlsgvmZNVDFoANBCnNOTCQB(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool KXMjcWkorXqEsRTHYrkBfEwRujK(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr SxHZhRBnAoiozPdSuBOTBSUtPod(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mEDxUDWsFTZkVlRnFcfPHyDiQeN(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ijWxcUXVEAubzUQGwliDByBhPgO();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr hKNLauShBRuqkTqKxBmLfbcBrJGf(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr YLlrFGEQKczIrOmXyWgTdsUuctV(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool NBqfhOdDnHYnkCuekiBgNsCAHJBU(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr oDEASYmXHLlnWKueUWmjDoWaMhG(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int QizejDMtdtjmseyzJdFBlXujqeb();

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr vPMhkoMjaYCKPbJhDwVwpAXbciPV(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr LAXjwoMVigNTVyFhMoWBfYuXokz(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr wVpQFMKBJQHaxCPyVQlGZaryHrP(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool sHITbadrDpFMBHxnuKMTUMfAszw(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr xfEJcKUyczTGCzXWiEcQNaqykjU();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mXDTfqodRaFAYxMLnlNFQnDhqsp();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr GxdGpOqTKipkqLMfQXpBPIJCDnf();

	public static IntPtr lVNYVAJgwqQqAqYxQMvJOhjcbXV(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return JNZuclZOWKhmTRbSBmvKLybMYRk(P_0, P_1);
		}
		return DtYizneQyIluQgVWZmlpUdQRjEq(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr JNZuclZOWKhmTRbSBmvKLybMYRk(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr DtYizneQyIluQgVWZmlpUdQRjEq(IntPtr P_0, int P_1);

	public static IntPtr WetSLYikTJdBLgzbAdiysCpcqhBU(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return fWNNfzvrcNgxhgjQGvxPZBMSgVE(P_0, P_1, P_2);
		}
		return fLBjtMXAJQDGmHZlrmaxAncIENX(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr fLBjtMXAJQDGmHZlrmaxAncIENX(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr fWNNfzvrcNgxhgjQGvxPZBMSgVE(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr lrsbvidsMJmFyIMSHfBRPgqfrget(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool jfBgsYCWqgyayQlKSGcEdAULXuA(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint LdbhpwcZdcltsPeVLCLaXITphwQ(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint HdDWzONQvcthSwCYPgLtEpUHQDZ(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint pjtXujuwBtsRiMeRyEPuKQToZilB(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint VdMwMLmmJWAgrIVKcSrudndXJqM(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int keNzndDKTkcofuxsaWZKrkjmEAI(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool qvaddCHTeBkNFzOJTYXcwYmYYpY(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool hjAHAxPMRcRXELyngDbVGWcIHcU(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int uNfctehaKjMNmyojDJiaMRFVqtVa(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool iCXvQIDwLZIBbbAusoUJAKSGWgl(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool iCXvQIDwLZIBbbAusoUJAKSGWgl(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool GlIQlrGqdSlMToISBLiDtiPwdSC(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GlIQlrGqdSlMToISBLiDtiPwdSC(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr aarQKQkekDcNXyIHwQtTwtjHteR(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr aarQKQkekDcNXyIHwQtTwtjHteR(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GHHCPAvWTIfriTydtUjPLukwGYd(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool GHHCPAvWTIfriTydtUjPLukwGYd(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* QYoGgmIcdcnmTLQKdkghUtuDWQrR(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr QYoGgmIcdcnmTLQKdkghUtuDWQrR(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr FBHTPoNFROWxClcPCYQvvbzJJnD(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool UQfXEbNYrBNiyMqUebQPhPAFAyK(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool SHoXBCuHgaYqccTMbFpICfQgpRV(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool AzartApJFTItwWGaQWNCAIIeIPR(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool PejAHrYkTvKfpLURpiTDTmjdPie(out jlEgGFCMyUABgeUYboncSgBLIPr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr WAoBFpJqWRwAFwbBUSrFmspUajCn(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short gyquWDavfugAPRFDMYuAFdjgyqU(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short LqWtFRtRQeHkUXWsiPERsYZmvRK(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool iWnAybzvBLsyVukVqBUEgSnScxg(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool JraYAxRCOHhlIcuWZrGemQXTeNZc(IntPtr P_0, out jlEgGFCMyUABgeUYboncSgBLIPr P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool elqsZJwfkSOIZFYaEaUCkjQpUiQ(IntPtr P_0, out QQBoznIKEUwNqAfsulooweEksiS P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool IbKtucDLHgSPwsTtvPvyvQWutDH(IntPtr P_0, out QQBoznIKEUwNqAfsulooweEksiS P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint RBdbNfRPligZYFUoycCeEOkEdxM(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint wMiQagakNllTdsPvOPmMYSRpicL(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ZOAWUuuQbgZujAikWAgvykBqjZU(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool oOsfnjxmaAfQbZygxeUkFITgnGz(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool lMSdiLkkXoQiJoufHQZtgXITTsA(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool lMSdiLkkXoQiJoufHQZtgXITTsA(void* P_0, void* P_1, int P_2)
	{
		return lMSdiLkkXoQiJoufHQZtgXITTsA(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr HHgObSYCASlxDMDexFzCKlSubXT()
	{
		if (!UnityTools.isEditor && idBhrIasrPEVndsAwTtUPkQwgLkE != IntPtr.Zero)
		{
			return idBhrIasrPEVndsAwTtUPkQwgLkE;
		}
		return idBhrIasrPEVndsAwTtUPkQwgLkE = xfEJcKUyczTGCzXWiEcQNaqykjU();
	}
}
