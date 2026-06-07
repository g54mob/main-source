using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils;

internal static class FTdbbIUhAgYSHUHmiEJUirkRZXhf
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool VUOyecQilnajryEIxsDMvpKpBRTaA(IntPtr hwnd, IntPtr lParam);

	private static IntPtr uCREEOIItLnNLXAgreJIpsHQMVhf = IntPtr.Zero;

	private static int UNDWjWIOiVETLSVEHzxfctdaMdcY;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int PZETtoYDlEEAybGbeFJoRYThRbuiA();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr lQAFBdZaFdwWZCyCdsNkrvYYRQDs();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint CjBjgvrBuFLidBEQcLqiXexLUgyL();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int GRVHNDoEsLsIPlSCmqMskKqiPdvK(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int lMkflDUONrzCcfepkpIEPMcZDLSC(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int NFQpXlpEweUHSBoLZIqdeJsSeoJGb(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool byAkPEkwqJTnHwynesrxVXauSJmA(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr cVFVjSbLprIlNfqJrjKzTkHRHmabA(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr FfxsOcSbfWvThjhhNoOGJSjPTAst(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr NfJIPUqkEcAvSjVAnNKcqGWyvnAK();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr nQYsbwAndwndCXVqAfYFGHXkEUyW(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr hjmyYvEothBmudlvhUgmkierJSJu(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool GaGgSphHHSAtqcmLEUVvWrSTMtnpb(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr dUqAOxkOPCJLukKVsQbmmmWDuvuBA(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int bbOsBDLWnQJMgnYphBtFfLksHyNi();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool wKfpWqphAxuMHzvtjajLsDTrpMsx(IntPtr P_0, out bool P_1);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr cwIbzcgeYdiMhdhQnChfdRqRDdfSA(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr NTgTVRbGhNAoZbbhmkBsNcfhpjzSA(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr RZaMbLGjHPExccAbLkmNpontDKPm(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool AQLTGeeWAKCmdKEqAwedFRqGFjgR(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr mcHRHwHEMLAsDHBLuxLvggbIcvql();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr FEESiASIhYFaVfbTuOdOIaRNZMlz();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr DusapxwwStwmAFEWSdmyAkcNCjJcb();

	public static IntPtr sboTJMTtQpIrdaDieGCOxLcNwErd(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return rWXRVmoafVGAkuJZdpbVgsRKxfAy(P_0, P_1);
		}
		return MfmrBOomaVJeIhxjhjLGfCugIuzM(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr rWXRVmoafVGAkuJZdpbVgsRKxfAy(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr MfmrBOomaVJeIhxjhjLGfCugIuzM(IntPtr P_0, int P_1);

	public static IntPtr veBESITQlinQbnuypOCImPdVRaMx(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return MsNxQamRqpvGCIfLdnzGpqYonYip(P_0, P_1, P_2);
		}
		return tRVFQBKtbQGIamcRvjpbDLOeYUrOB(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr tRVFQBKtbQGIamcRvjpbDLOeYUrOB(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr MsNxQamRqpvGCIfLdnzGpqYonYip(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr BdAUJsrpdcZdJbmFuXDjDiSBhzvv(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool tdFFxOVtFaolJXJxvfPiRgiECMcH(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint ewVCXgFetGaDJhSnIxSGylPgBliFb(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint FCmdpkHkcvhBIJGnRHDwfyCbPLpab(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint xzXAXzWWkGoqyqgXFtylrwXQJGsB(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint LlvzpGNQNuQIRhHGUjJTkNQfGoGF(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int RYkuXADoeOCKpLJIynbEzthelGBr(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int cYvnzvuKjGALxsGlWOFtcZnHzIHj(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool iKAhLIUMDQdGEefFwqbOpciuPOahb(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool htCNVrJrVaOuVTlhHxACMzATbuKy(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int jdCwmEEItDfPyFpYyVHZVordGlLgb(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool IuYDFbnJrsKKZFLyvHmHXFlrAMVQ(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool qSThbjlIiirAQkBHAwyjgvUPmxpP(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool mZmvuaUkBilqcHlWytOWlcUQBaEd(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BjwddmgHGlUzfbCDIeTnOneKZHmsA(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KiRZCzRmVYTUFCbcQFIyjWblAmrcA(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr BbbkiXEXYEAJFQEbovsZWmAmpJKF(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool yWpjEmHCIwjZizpNTEnAdrFVvbiqA(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool BjignxAFddSKdPHlJMTnAZfPeeCHb(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* BnXhOlvYQwsSXhvQMvUkWlIkigmR(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr RNZatXahTijbHVSYkOqfWgdwoGiY(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr eFPuZFRfBKMHnbDutwtSDqZCwFFx(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool FushcvtBEkGQcmfmfhOqVHWxLAvf(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool kNrsxCtoWQTARbIiIvdJSGDimpjO(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool bRpdMmvCiZSETdLOVcbVYjgnqVKf(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool AVVjthjFfIChXbQoFIlJtnksKixE(out vngxFcEtcgLernSmRjFLWbynMHSQ P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr nQhCOTYIEvRXGhyZgtjCeirIibzj(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short IatHGQiOBEaetDmWFLthvQVmgcKg(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short WKRCGfzHIhGpixXCgXSQEDqBtKfx(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool BOkQoSxVneNJqEahjdOPfVxqsYALA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool twcdSxgcRlBMZgRoRfMnKTJiLKYGA(IntPtr P_0, out vngxFcEtcgLernSmRjFLWbynMHSQ P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool tsEjuaHDfPQBSilFNpKxmTffVNHu(IntPtr P_0, out OhSxWWiKozRvNaYKgWPsnvMYgjO P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool JdkrHlPCRSoEtJNDlCOiPmZdfHUF(IntPtr P_0, out OhSxWWiKozRvNaYKgWPsnvMYgjO P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint dDebsAIlMEPVChQfqALazNYNcBqbb(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint ofmVCSxlLmztSclkAWQxervllRuK(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr BzrofXeFSfuNqrPJjrlvLOftusep(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool bTgflcCSpupkYeBSSCMPUqapVYBE(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool aMfjHZcaRTEaGMgEyfEfYMWsIJAN(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool hyAmVqhgdJMNxMIImLUQvjDyDpDd(void* P_0, void* P_1, int P_2)
	{
		return aMfjHZcaRTEaGMgEyfEfYMWsIJAN(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr NwoSuizDgFairJkCGeEaeWUEahWaB()
	{
		if (!UnityTools.isEditor && uCREEOIItLnNLXAgreJIpsHQMVhf != IntPtr.Zero)
		{
			return uCREEOIItLnNLXAgreJIpsHQMVhf;
		}
		return uCREEOIItLnNLXAgreJIpsHQMVhf = mcHRHwHEMLAsDHBLuxLvggbIcvql();
	}

	public static bool JlVnXHbxbrozGMzJjhOGmPjJDSGj()
	{
		try
		{
			if (UNDWjWIOiVETLSVEHzxfctdaMdcY == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					UNDWjWIOiVETLSVEHzxfctdaMdcY = 2;
				}
				else if (wKfpWqphAxuMHzvtjajLsDTrpMsx(lQAFBdZaFdwWZCyCdsNkrvYYRQDs(), out flag))
				{
					if (flag)
					{
						UNDWjWIOiVETLSVEHzxfctdaMdcY = 2;
					}
					else
					{
						UNDWjWIOiVETLSVEHzxfctdaMdcY = 1;
					}
				}
			}
		}
		catch
		{
			UNDWjWIOiVETLSVEHzxfctdaMdcY = 1;
		}
		return UNDWjWIOiVETLSVEHzxfctdaMdcY == 2;
	}
}
