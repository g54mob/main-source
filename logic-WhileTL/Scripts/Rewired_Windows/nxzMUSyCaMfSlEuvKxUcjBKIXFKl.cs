using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils;

internal static class nxzMUSyCaMfSlEuvKxUcjBKIXFKl
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool vuKPbwsLSFIaDeRoXuGyikjaZHsf(IntPtr hwnd, IntPtr lParam);

	private static IntPtr UZrpHbOeJXmTKqlpektZUmPTDHyP = IntPtr.Zero;

	private static int WCKBHUVbxmjknvTTVNNRcXIYDgVF;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int jbyTMPJAyDqdCHAcuIDOkXMjsFzpA();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr JbMQxbaRMuhSOpYUyloehxnMzBwb();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint BBxNJBcTdGcpSxpDTVkTjLJYNyRR();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int gYQXEXhsqhDGRHQAmrQNrITRGHY(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int BLplujBxQhrXkUuekRWUcAMnHKWR(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int BLplujBxQhrXkUuekRWUcAMnHKWR(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool kpmnGlWRJXQrXMxeOknEgBtoepKs(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr auxjvkfBmkEyYEyxsDaSAyBCXszj(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr UbtVizwfEZVrwqkqBuCEWczXAgNJ(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ASuDQfGnqQJnMRXzcksGCYQKiwWGA();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr JTrKEPkNpFAiLMuzvapIeblmHJKR(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr gGZDpzcBykDYUZkiuBoWgwJNJzRz(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool bfAxTlpOJDjlZrxDuPTvpPDhSHVt(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr SuokmlYvvNdGvPLNQiCuAaFFepMn(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int uSLRFeqRJboiTrSSBnHUonbEWmln();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool xjEFbdFKENSDojGzjTOKfasrIdBiB(IntPtr P_0, out bool P_1);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr FiiqONyFMYvImEUYZONhJVICvuTn(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr xxnLCNeffeHMqlMuhgYDmLXLkzqj(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr EZTqBnkzbQyCIRRRBSABASmBtlVj(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool KncfVZCHlnVGaGAWkdKMOFojVdkmA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr DCadOTokGhHDbeZucONDYkhNgovl();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr EuzvGHEilgAQvqNejqPULzYSeVvk();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr gBBqUdSFcejTTQUMOBCKULCrNSfi();

	public static IntPtr RRpaxjhmOuyozjnUYCvOBsgPZsHm(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return ftnfWOdtkWMgqhMpLLfTuIutVGkOA(P_0, P_1);
		}
		return taeYGeCsbCdnWpurDeoFDeumjiDB(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr ftnfWOdtkWMgqhMpLLfTuIutVGkOA(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr taeYGeCsbCdnWpurDeoFDeumjiDB(IntPtr P_0, int P_1);

	public static IntPtr iuBfpjKtdDmHquXCKKybLgqZrfVt(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return DTjnxSXgGXgwQjXOSbrOUuExmwQr(P_0, P_1, P_2);
		}
		return ZfXtwhfiCLJQASZbycHVrqdIVub(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr ZfXtwhfiCLJQASZbycHVrqdIVub(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr DTjnxSXgGXgwQjXOSbrOUuExmwQr(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr BaQZBZYOkFIZFBZnHXQWdjxQojki(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool TinvKjqGKwSiJPjdWHcDEcXyZkKjA(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint lLHZWFIPNslnJGUcHIilCmMOhoOI(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint hNvdifvMuydvvzHlJFkaHRZkfOLib(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint FoReCIGAbbhJVzHigbNzKNOFJoleA(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint tvcAScCmlSUQKBezwgYddwwiIZMNA(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int UmrFWFnlgceBCrWCcQpHqpiJMEIF(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int dvAhNcDpZGovnYKSchKXtNiNzIOV(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool MPORzxfDADZRagTgBKbjhxtfAvAH(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool RbwqeUbJjoaNtUgWuslWVLfdHuMdA(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int GRFyFNWTqfmVTzUYPOwfGYKyQfXu(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool SUteybhVpFaBUjqPqWSAaRRtvwxoA(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool SUteybhVpFaBUjqPqWSAaRRtvwxoA(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool wHwCsYwQLGEfktdxBCFSbqWBtIMPA(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool wHwCsYwQLGEfktdxBCFSbqWBtIMPA(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KrNcqhAjCHJXmdAasVjCvvqukwNU(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr KrNcqhAjCHJXmdAasVjCvvqukwNU(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool qKnlgxZolCnrHYbOpztOWUtFOQjl(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool qKnlgxZolCnrHYbOpztOWUtFOQjl(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* kOWSMNILZyuswXUxppwsgUboUTpL(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr kOWSMNILZyuswXUxppwsgUboUTpL(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr vwxDlNzjxIBtvAwqWLKgQaaiotDaA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool cVDnWpjgbLJTHVRvafMFaImaSOie(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool srGDjvGYImcoLuhnrDhNCRPITDLob(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool opCVrHVfhZYFaNpGSQdPFNLXMSTd(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool zWIgrmwkMRKwUIQlToXEIphSPJoh(out ZCyrceaIGGUJPbqldbcnePGyMRtXA P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr cxSAjYFEaPqWqYyuOapQijanTzKGb(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short QoSEmfILxcyimIkoUKFNOmCPgCAE(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short rhyRmmFveqBVzOdBiZaZjDjHpsLD(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool CEXQmKBOtVkqaxzaaMYZfkNjbesG(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool liCiISzfiFcvpnerVwWtpHGgJVJS(IntPtr P_0, out ZCyrceaIGGUJPbqldbcnePGyMRtXA P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool MQCdQcUgQAAUiAwLYBaTgdPASASKA(IntPtr P_0, out abrFAEsQiEEsHPrDgEzxnmXHfwQP P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool eVyFQZbFvqXTPdxQdghxqvTRFVDu(IntPtr P_0, out abrFAEsQiEEsHPrDgEzxnmXHfwQP P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint xWHrLKjwZwVizYaBkCQhNehdtMUg(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint AHUFELGodbgDGfOUQnwJTVIWQkVM(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr btggEJCiScBgAVDbUQuwnfvFfGSD(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ESQPECNYYWnCESVAxuShOFMPfYxD(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool LcaEYeAdvayPwpGOFBoudhPaVNWK(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool LcaEYeAdvayPwpGOFBoudhPaVNWK(void* P_0, void* P_1, int P_2)
	{
		return LcaEYeAdvayPwpGOFBoudhPaVNWK(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr vXOctowsgMjuwZXcfPERVmiXpeTg()
	{
		if (!UnityTools.isEditor && UZrpHbOeJXmTKqlpektZUmPTDHyP != IntPtr.Zero)
		{
			return UZrpHbOeJXmTKqlpektZUmPTDHyP;
		}
		return UZrpHbOeJXmTKqlpektZUmPTDHyP = DCadOTokGhHDbeZucONDYkhNgovl();
	}

	public static bool UACaiNdWAAcBVoOSWHwhWdBXCKxg()
	{
		try
		{
			if (WCKBHUVbxmjknvTTVNNRcXIYDgVF == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					WCKBHUVbxmjknvTTVNNRcXIYDgVF = 2;
				}
				else if (xjEFbdFKENSDojGzjTOKfasrIdBiB(JbMQxbaRMuhSOpYUyloehxnMzBwb(), out flag))
				{
					if (flag)
					{
						WCKBHUVbxmjknvTTVNNRcXIYDgVF = 2;
					}
					else
					{
						WCKBHUVbxmjknvTTVNNRcXIYDgVF = 1;
					}
				}
			}
		}
		catch
		{
			WCKBHUVbxmjknvTTVNNRcXIYDgVF = 1;
		}
		return WCKBHUVbxmjknvTTVNNRcXIYDgVF == 2;
	}
}
