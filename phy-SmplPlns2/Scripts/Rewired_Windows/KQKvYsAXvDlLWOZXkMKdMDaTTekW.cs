using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Rewired.Utils;

internal static class KQKvYsAXvDlLWOZXkMKdMDaTTekW
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool ZSjeJrzzoqpJhUbKYejcTDiWReFn(IntPtr hwnd, IntPtr lParam);

	private static IntPtr fYVxUhGKKXXntMOkVVqtQJOwVWJl = IntPtr.Zero;

	private static int wyvjImUtwnfaMnugOvzWMiIlneGo;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int fUlknHuuvfthvFugwVCjPagwlwzk();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr YpVdpdbqWCnFeBxgMBHHGCRqDpZKA();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint upcyUkxreqkZzUOTSojgrPtVFQIo();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int reoPlqmjWFSxCKwkbqhpoQrYsPQc(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int FFTPAyMqZxqsdQkocfLxIPJYHcXU(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int KLANLLqfsAGznDRrdnzzdOFrrOOM(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool tQhijCRMubORFIUPwwIGMpojCpKE(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr PcUWDYqMNQRbGGeZiULuXhOldmPb(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr JyLEhNrpXhFQoRQOBdqnFQWvAgblA(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr wQhYfenhAiuygDkFfmmsNgmldpFJ();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr cjwYgkxpBUEUvZCOpFfMkptXuEYy(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr PptZSHpqlWhHOffAyssJGIcFRSiec(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool jNPzXXtgnddTXjJVuqmxTiuAgKsj(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr zwRitJYGvBUpjmhjrmyVEEVhfxbc(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int uRhCHVeNfkGMPpAernpJcijKlyar();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool csyAnBAjkwsbHOpIwOKVUILVjSLyA(IntPtr P_0, out bool P_1);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool EIvCdlQjxfAYWAcMLWUWjDcHUukN(IntPtr P_0, [In] ref NativeOverlapped P_1, out uint P_2, bool P_3);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool fkKdEakPxFEwCFvyqBEOjpiEfmHDA(IntPtr P_0, IntPtr P_1, out uint P_2, bool P_3);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr HiOGyTfoemXVQnFgdDKFjqRvNgRzA(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr APYgMEClpMAjbPgqYQKInnYSCmmAA(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr WGvpdUpbFaGwZHDDQyBKvABTqGPvA(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool rKeHuqboZOOXhKcHSiUjBBFDjuhoA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr YGisaiGeNqqRwntxVYjYtjNyNnJF();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr QuHAhcGIxVQVVSOUxUBrOQWrNheu();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr AibyfVejWlavgkstvckwcMQlHaQgb();

	public static IntPtr vxQmmxwilIJheBcwiXxHghIgwKFs(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return uYHovmjlzoXGaOLWLvugWlyzbyCC(P_0, P_1);
		}
		return uUTSAKUsCovotqVVIdjNbbXeMhRR(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr uYHovmjlzoXGaOLWLvugWlyzbyCC(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr uUTSAKUsCovotqVVIdjNbbXeMhRR(IntPtr P_0, int P_1);

	public static IntPtr ycRDdmfaaIQpstrpIFFQSOTVxbGv(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return zrlGZOWUOLHjwwpHPdEPwxeVCWNS(P_0, P_1, P_2);
		}
		return CeaJDFvqlOAFpcDQHMuXwCeeWsjBA(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr CeaJDFvqlOAFpcDQHMuXwCeeWsjBA(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr zrlGZOWUOLHjwwpHPdEPwxeVCWNS(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr GMWsqRMNqrGJcvKgysuDPVCjDNWH(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool kFZSnCOaiEpSWeRlIiSNNjPueghJA(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint nTAVTXpUDJCbdafAJqKYffDReuhh(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint OdRkZKbazOYSHqMXinyOIZyCcEmw(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint VceligKXAYdHDKRFXbrrICrEnpPsA(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint IyRjJiOzwthMifOporVEstYuHYcL(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int UyOukaYhORCIYoddURpRRLFMpaon(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int CgBJZgixLzNdNTzerIFjTEbPozLRA(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool QgDIekrPBbpHIiwFRdVLuUwYejQV(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool NIauLqJqhqWSuJcndqOblvtsshCS(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ajBOvwTePqLBYFJfsEPHxqyplzfk(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool pmreEbDdsgxKOPGIjgXHrGHjCHJsA(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool JYjRkLuXxbIkymYdcFZurgnlJHAn(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool itNBVoDKXPdzBlZcVZmEemwulHyQ(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CLJfaQbygdiDTbzigkyqfWvASMJq(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr myugpmFgDzkGfLbmtKEzOxgRYoIO(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr wfMtGuDpBsKCxjlBrdycQRuVLULN(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool muhOtOEXLvvIWkYPWFllQJFbgARX(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool thKqIkGMrESwAHIBuNEvbEJHpBtP(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* gGlprXbbBmXlMACGOBhMbCDgDNBab(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ULafHFngkhDQNxdrxyUhwXZnLYlR(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr QaGIENCNdlOxFIqzHCGRuMDUtdDY(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool vguRdLDOYDVBIDTRYrQxdMHYQDAY(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool UwDUQRfaYNlmxkptLVmIHnitDlfU(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool GnSHrjQosXXoUEdsiMAJYMdzUqqu(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool hHjhOsyLyNAQiawMuPOolvbsLfcf(out yvmnbQjDLoRvQsjOUsVFFNnaiTOB P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KOEHysroCvnEYNZMRadPGuReGWG(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short korvYgNVnDxxHoRUpQvOzdNVcbWi(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short nTpEmdABblNQonGUcrIYpZSEzkVD(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool NcibMJizVdeFYlChVgkCUcZBGdbOA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ndStfWCYGrhpSTQJPUkyXjWuBHdQ(IntPtr P_0, out yvmnbQjDLoRvQsjOUsVFFNnaiTOB P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool mytFSopRSfKfvGaFVUwryvZAqNbb(IntPtr P_0, out fhzmgqLvPwRrSigefCPuEOcUnAmcb P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool SFUuKbqeTiYalvkzspirFNRgYeht(IntPtr P_0, out fhzmgqLvPwRrSigefCPuEOcUnAmcb P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint OMiEatLraEuAUhwUQRfRevbaNPjh(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint IIFPpgdBqQUNXnoLKUDHyEJDNeD(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr huLKYyYmAgYIoGBjbRRPynZxDcSI(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool haLfpQfzqjLqOaeaSCkojNxtjUlb(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool RmgatSmiYVfTgJTRMYcINwbhozmk(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool cubDhCdrdoHzybsJMljyrXxGQNtsA(void* P_0, void* P_1, int P_2)
	{
		return RmgatSmiYVfTgJTRMYcINwbhozmk(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr dYTsadZkMhizYZtWgRTZblGzQsAK()
	{
		if (!UnityTools.isEditor && fYVxUhGKKXXntMOkVVqtQJOwVWJl != IntPtr.Zero)
		{
			return fYVxUhGKKXXntMOkVVqtQJOwVWJl;
		}
		return fYVxUhGKKXXntMOkVVqtQJOwVWJl = YGisaiGeNqqRwntxVYjYtjNyNnJF();
	}

	public static bool RRqeMfExvySlnKgkfsrPMRTdwRPjA()
	{
		try
		{
			if (wyvjImUtwnfaMnugOvzWMiIlneGo == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					wyvjImUtwnfaMnugOvzWMiIlneGo = 2;
				}
				else if (csyAnBAjkwsbHOpIwOKVUILVjSLyA(YpVdpdbqWCnFeBxgMBHHGCRqDpZKA(), out flag))
				{
					if (flag)
					{
						wyvjImUtwnfaMnugOvzWMiIlneGo = 2;
					}
					else
					{
						wyvjImUtwnfaMnugOvzWMiIlneGo = 1;
					}
				}
			}
		}
		catch
		{
			wyvjImUtwnfaMnugOvzWMiIlneGo = 1;
		}
		return wyvjImUtwnfaMnugOvzWMiIlneGo == 2;
	}
}
