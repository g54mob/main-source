using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Rewired.Utils;

internal static class JUcffnbUUIpygcbMFvGmfZKcYwgXc
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool EwNRmmpNVfWLJtARXpVtKdSXukHG(IntPtr hwnd, IntPtr lParam);

	private static IntPtr kBrcxkbMjGgCDPrfQGoqeJsEhVXRb = IntPtr.Zero;

	private static int jcRoljWOBwpVaAavFLvLVPgghqIP;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int asHJnYsEMwhALmpztOFaMnGpEfjaA();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr VRzyIgeBzNcwWgqdZATMwBtbYfDsA();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint dnYCljHrNtimHchMkJvnpeJGuWAab();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int mYgoxolCKhxqdVhuRaizgiVrkFr(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int WHdDtvCKaadJNjdfpoDehHvHfiBib(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int FIcoAYydHVYTRydmgkvscmxagEMt(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool mNDLjVZHzyjhbzcTpykVJcXwHSMw(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr SZmhrOcHtDkNBpfrzaCOOWRimbgx(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr EWbrEWtOweIlAyJDEamkZUskwkbr(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr xTIvvHfzpDRYTuIyoyrcKWDyrLcb();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr jmUbLxFdmTcnXBcVcUnPfdBcGEWAB(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr UsXUbQtnODLogEFNxYuUJTGUeKsT(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool cRhOTGrGOaCUbIYMzisqKGWTMokp(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr aTnLxsOrtSbdHRsAcwFfNcsijItk(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int rnPsoGuLCjdJxItvafBInyJZaXyh();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool dUCwKSzaZrfIzfYVjwAWpHfSQQJOA(IntPtr P_0, out bool P_1);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool LLTvqsCCIekfuxDNAzYNiwUYjgqs(IntPtr P_0, [In] ref NativeOverlapped P_1, out uint P_2, bool P_3);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool cgsbrfcLESLVyoFjpAVXqKGXeQJh(IntPtr P_0, IntPtr P_1, out uint P_2, bool P_3);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KJyuTQfqPftcgOancPSMpBviJiRp(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr BuqqpTALODWOPcofXnQXwwyJopwk(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr RDXMWVzQwhCHfuQKLFBFRufUMONV(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool sOWrZrjgeTieDjPUZAAsYqjCeanCA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr FkMFdlEyrjDfWEegOUwXsHjtVDBL();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr RPpAFfKPIQogxbqDeTlsDvqwpBoL();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ZLZaGWbwzmpMIjVooHavHBoFscUrc();

	public static IntPtr yZuhPkslSJlAEoNdjVbEtGyxxAXX(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return hCdXUfpBCbceWtVFKnwlNgEeibCO(P_0, P_1);
		}
		return vzlCxHOXxbyVTNJIXTtOcipjCtNAA(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr hCdXUfpBCbceWtVFKnwlNgEeibCO(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr vzlCxHOXxbyVTNJIXTtOcipjCtNAA(IntPtr P_0, int P_1);

	public static IntPtr vEbOJbfmFJGWUYQmXRBXZMxCxpAI(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return soHLuJIkhOzAQNOOEDMMKbACgSBTA(P_0, P_1, P_2);
		}
		return XHYLkQjbIDqmNujZCNkQZyMvRyxo(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr XHYLkQjbIDqmNujZCNkQZyMvRyxo(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr soHLuJIkhOzAQNOOEDMMKbACgSBTA(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr TrodROKuPcVvGYAxnAeGBQoooROBb(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool bDpfQDGEJBQjuJNoVnGKCYpnjepTA(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint mweiCwhblWdFMPFiOoBxazcYaliB(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint DGpMgHxGUNRnzLvGxJcTTLKDhMoFA(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint EFCNFvOGbFImratKSqhaDNNPFnVEb(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint BBnoejSiZaxhUGfgfPZJdLcnQOcP(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int BUqLzlEsnMtQcLtcPxZAYujBakgl(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int PHlxebfecwNAtWrpovZiXBRQApZw(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool JJblHnrNsgekyeHKCOVIqzQHZjMW(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool QgQggraLMtJvAsuywvAqnyHxyrWLA(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int xlfJQzZKkhHqggssjdXKlqEkbjfcb(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool mpVzzgtaXndtmfnJikFAHXjgyBRw(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool AbRHPQiIAujRMPjatTJrwsPgNHUq(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool lwrWevSnaAcUpgHpGdwTfVOpDFiY(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TjzrHZpUXepulWGttzunubFLrAVn(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr bACWKjmqsuJdPKfjyjYseTAARcMDA(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr pDcFlbFVkrFpLEMGKwihjZSOUQRkc(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool fPPEMBGxsyxRqRyMFvckBwzqUdJF(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool cJuDlpYeCVyReqzWleOkcEpAHZzcA(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* vCNMOUnesftEmtnNZrtFLOvbaBZaA(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr FiCQwApVRqryxYFmoYfgzGraFUlV(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr PeelhAWSQweMxklsKNOMgbdDLbXLc(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ciEFKEZfvQSgwoBCPBAiColHyPMDA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool TatGvCghvKqRBMZwEreNhKEcIbvIb(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool JrkRUcMfHKvVujrjjWEWLMFcbsefA(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool seLObhsqvGdwYVbHjXfRsZVjPeAB(out zSIAQexwslkITPqvFeWWApalwIPF P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr HcstHvuGPDSHuxjEFFjuKGoQGwKR(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short pLNUwfNDUIBQfDPJkFEPEwlIgeMOA(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short mwTfkuCyCmiKMWDdfxhNwxHBxdDg(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool WfGDrWjxsmvamlkmOXePrLjYHhnN(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool cfchARUgvyBGaCyICVanuYilfDpLA(IntPtr P_0, out zSIAQexwslkITPqvFeWWApalwIPF P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool fsOeQDdacFvrXxdvKMEdvCLKcTZk(IntPtr P_0, out yDBkBjLxivCYkZnryBDfTzAZbUcO P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool PekGneaqwjeBPFGiHpacyMvOdgvJb(IntPtr P_0, out yDBkBjLxivCYkZnryBDfTzAZbUcO P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint BRAzViRHHVFTaSaLVTZGjXDliZpT(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint NzgoAaqBQlzOtcUcICCCYHICAHkq(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ulwdvaGBxLxGIvqkCPIOvhcqVYtA(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool qydOpipkYqulWJohFUBbeWhuzaIk(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool UOKWaJeyzSaZIkUMJyULADjuxfsG(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool vwLQGPhsAlAXSBdOJzUzWnJBHhfJ(void* P_0, void* P_1, int P_2)
	{
		return UOKWaJeyzSaZIkUMJyULADjuxfsG(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr qWjERgEBhkYCmLqVtYTSraemSGCkA()
	{
		if (!UnityTools.isEditor && kBrcxkbMjGgCDPrfQGoqeJsEhVXRb != IntPtr.Zero)
		{
			return kBrcxkbMjGgCDPrfQGoqeJsEhVXRb;
		}
		return kBrcxkbMjGgCDPrfQGoqeJsEhVXRb = FkMFdlEyrjDfWEegOUwXsHjtVDBL();
	}

	public static bool OUUznsvjYtGmXBEdgJzYEHpkrHXv()
	{
		try
		{
			if (jcRoljWOBwpVaAavFLvLVPgghqIP == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					jcRoljWOBwpVaAavFLvLVPgghqIP = 2;
				}
				else if (dUCwKSzaZrfIzfYVjwAWpHfSQQJOA(VRzyIgeBzNcwWgqdZATMwBtbYfDsA(), out flag))
				{
					if (flag)
					{
						jcRoljWOBwpVaAavFLvLVPgghqIP = 2;
					}
					else
					{
						jcRoljWOBwpVaAavFLvLVPgghqIP = 1;
					}
				}
			}
		}
		catch
		{
			jcRoljWOBwpVaAavFLvLVPgghqIP = 1;
		}
		return jcRoljWOBwpVaAavFLvLVPgghqIP == 2;
	}
}
