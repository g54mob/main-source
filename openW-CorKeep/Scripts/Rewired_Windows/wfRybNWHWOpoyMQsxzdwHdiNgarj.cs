using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Rewired.Utils;

internal static class wfRybNWHWOpoyMQsxzdwHdiNgarj
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool rrsDKGzFNxUVVIEBHmQnImsINaOS(IntPtr hwnd, IntPtr lParam);

	private static IntPtr FxIwnYAEpGJLPWlWSTBiVKSwNWCI = IntPtr.Zero;

	private static int AawDiPAKTwRSyllpFaODCLEbruXab;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int RuupWsmYUcCRDNKlfZeyCzmaVrao();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr eHUXAvuvtBbMoNfiVqQyBPvstGjc();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint GofkkXbTqzdeZEaMRMllmAdBeGNp();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int RFvyfXupWOAmscEtkSJudvMSteKFA(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int pFUaURMMaaAyRYQbdeQeDfPSovAg(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int kfXfboaHTLtTFPzykRQmyzXxeEHQ(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ROogMdXXhshqxFMRxLLLIHdfvKPPB(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr jaVdiaJudJJfVoAzzZxAGQjnMdvVA(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr vEEVugfYeiufSHCLOVTsBzKlueoJ(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr SxexwRhnbfBMODZKoeFvKGqfAfKgA();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr GClCUNzceTwlTLFVkOIJjBvDSlXE(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr rcGowPtGHupizvDpeHIDRqPxKnr(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool NxGmLubuGqrTzfkWldHyiIwWnsjBA(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr FUYDWWGLjOymPsaswuVvRGEhFnqIA(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int QlkKhysNAhSczxhxmFSGtirSWcdM();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool IrXHebhRduJnpsHtzzWZQPFFOKq(IntPtr P_0, out bool P_1);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool udaRiOQJUkawgGlHEFdJwwgVNklP(IntPtr P_0, [In] ref NativeOverlapped P_1, out uint P_2, bool P_3);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool LsVJwDseSUPYmNZhnjlXuiqWdkCY(IntPtr P_0, IntPtr P_1, out uint P_2, bool P_3);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr jaDChetZFpzOyxlnmnqSxXglgmSC(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mhPiWxGFMTaHPNmlHzVFqaGWcelp(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr sxmNCbrqitKAzZyYDgZRHwRJEcOj(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool DMvAUFjKyFctLeYQJbzqFQHBryokA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr qndvUZYlinfKCfXcOLlTcfReWHYX();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr iXYhHBOvACgdjYXNyPeoXSMfsxpV();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr qBcPlmeDfgHLMerisBIrLbCpsbZk();

	public static IntPtr RNTSeQytKTJGCLajzgACfVAgLGOX(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return GYQQCXbFSvQdUWkBYZClPfcdwxLO(P_0, P_1);
		}
		return YoYqptQdenQZNqQRPITIiPHuhNWe(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr GYQQCXbFSvQdUWkBYZClPfcdwxLO(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr YoYqptQdenQZNqQRPITIiPHuhNWe(IntPtr P_0, int P_1);

	public static IntPtr YVOjPRbBZZNHElKwRkkPJlZDirJU(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return DyghQnWfrEiLGywOUinWlqyBrSKx(P_0, P_1, P_2);
		}
		return oFxbjqpsOHNnHRVPQVxCPeoqhyqL(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr oFxbjqpsOHNnHRVPQVxCPeoqhyqL(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr DyghQnWfrEiLGywOUinWlqyBrSKx(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr iHDpCsOCLqLmCvanxKXOSKQreNLQ(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool SjAZlvOZIZutmkoYTdjASZCoaYoD(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint NqZuxoxsvUSaDwsLKCDJceVFfoglA(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint afUcndjYCRpulkDCzGFPHBeGOKlUA(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint luxBOZWrzBanrMXOWTCgFhdOppOw(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint yZMbpPSPZkieUfgedYkJbJSmxUvp(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int aGFGGJILrKdgqqmmVkKQOcBSswlq(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int qtIrHLtaNwZAlffSokcsLnBJluWC(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool kdKBMVrjewCnuaOUSikCzHcMDxXgA(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool nhpbxNDKtncgQDyQapsXadfongHD(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int CoQNiNJmurxksRgofwmCczerfpem(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool NjegAvjFOjsqGQZouoQMBDhzBEhb(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool tYcWgaagWkWjIihsxksnoSdfLDBt(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool KOclVWMuUCRzAPzaCXTKfgFqBzGc(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool aDQWOpphJqHxlnGrfpJlcpvGAWMn(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KalZWPiqOuieVbdwqvRsFmARaoBC(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr AjPemVLsfpgQXdGbkXHzLbaLWmOK(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SuiLrhAuqcwGkkhYTOqmBJJzCKEU(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool ZcNgxXKqWROYoDqUfnVauLJPPXgI(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* CxgRhypoilPooAcDDAPLPfNqHwSL(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr qffEDslzJyewftLimtfansDtJUay(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr chXBmiUNCmdZtQUgOkpMbZHGpnOT(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool FBlFbaTzdSdkaREMDhReugVYDCXh(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool glWqqexbvEGpVyixGHFPIaofrWge(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool wJXDxCWzXGIJoIAnrbbCRExjkPdL(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ZIcSLJufeSekWAevnLkxoilsiPrPA(out WtheLCHlqxIfJcckbPJWrMXUecAfc P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr iLXaeXGyHXCDmRKGFpkiFCCZzcHSA(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short EowqDHTVKOSBtyHHcvfHkOHDhiNS(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short NqmtgKAUkoAbYdQBzaGTeOTEXjIU(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool vVrySohacmbHeSEgSeHPdJPJwreN(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool JTDTUlEUlsTDgTbUSbFbSoIcDPqz(IntPtr P_0, out WtheLCHlqxIfJcckbPJWrMXUecAfc P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool CGjenjabkFDyRDMjfYhxzvvBuuCVA(IntPtr P_0, out ThaEHJHRuxNOscsdomkrNbcSSKpJ P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool aJPyRYisTtYIPjmetXEgUDZagxuH(IntPtr P_0, out ThaEHJHRuxNOscsdomkrNbcSSKpJ P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint eWhlyEFyZNsSabbFBjkCxUdsIHkIA(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint qoXZrGmoKrOstRUmAkdCAgkRODbS(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr VvQVoTCfJxdwEFMiyUqYpXJjdHZjA(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool XCEeDIGpUsjrWTuzPjxlaqBtjfDBA(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool nKdiTfgozSSfAPPIDTVXEexjrvtQ(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool MciMPrnkCfvZUkqITjExYzzUNnkm(void* P_0, void* P_1, int P_2)
	{
		return nKdiTfgozSSfAPPIDTVXEexjrvtQ(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr DcEMACVJnwLAmZDRlamEsMKnjWNHA()
	{
		if (!UnityTools.isEditor && FxIwnYAEpGJLPWlWSTBiVKSwNWCI != IntPtr.Zero)
		{
			return FxIwnYAEpGJLPWlWSTBiVKSwNWCI;
		}
		return FxIwnYAEpGJLPWlWSTBiVKSwNWCI = qndvUZYlinfKCfXcOLlTcfReWHYX();
	}

	public static bool xEfsYdnMGnNHVefceInGEDtxZhCe()
	{
		try
		{
			if (AawDiPAKTwRSyllpFaODCLEbruXab == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					AawDiPAKTwRSyllpFaODCLEbruXab = 2;
				}
				else if (IrXHebhRduJnpsHtzzWZQPFFOKq(eHUXAvuvtBbMoNfiVqQyBPvstGjc(), out flag))
				{
					if (flag)
					{
						AawDiPAKTwRSyllpFaODCLEbruXab = 2;
					}
					else
					{
						AawDiPAKTwRSyllpFaODCLEbruXab = 1;
					}
				}
			}
		}
		catch
		{
			AawDiPAKTwRSyllpFaODCLEbruXab = 1;
		}
		return AawDiPAKTwRSyllpFaODCLEbruXab == 2;
	}
}
