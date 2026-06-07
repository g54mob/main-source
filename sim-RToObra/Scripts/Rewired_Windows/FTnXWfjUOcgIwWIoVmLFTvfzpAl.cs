using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils;

internal static class FTnXWfjUOcgIwWIoVmLFTvfzpAl
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool shVbpIFiMTgDEtkcDrKNtHUvBcT(IntPtr hwnd, IntPtr lParam);

	private static IntPtr kBhJxALdxxcEFwejpLfeqaTmQiT = IntPtr.Zero;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ZHkWegKkSvKuDTQhpfqvpgbWHQK();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint xNdJlwtBPsWNRtbIQMFgTxotbpu();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int QOAILtgNWApaBLZDTFFvRIripZw(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int dQvuVKSgjHmddSnVbhYbSrJYNBb(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int dQvuVKSgjHmddSnVbhYbSrJYNBb(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool CGqESGZbhdniQCUdFYplSYYNkpp(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr IKrAvHdmYKQBHpIgrDhfAueAtCST(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr uTplZMrKyndcfesvCSQlgyAcdJw(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mtaCGWyOOcpWJDWaloEjsqxbRjh();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr nbWEcUpRnIJQZIkqtGzNOUTfGlG(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr MTFrEHzYfAtFVVjonOlqIiOwgsF(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ZLGPdGiyprAKYnpIlvLKBreKKva(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ejctkADOPziKiHSMRHERauagKiz(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int CWDLWLxnbBLPIzLmGjFrGhIllMG();

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr jNuYIqhcmelPxUZCMpgEtbljzfi(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr JehMNotHFOLsrrqtqsCsWxweptH(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr gKHweShcNwODPPxOCPmicsPwsWu(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool afmLScYaVVFpbIqZjDcpdvLYAuJF(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr ltqLlotzsNusswonjXgwebYwybY();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mEnFhwGTBYqvsGctcXbjNdnhBnQu();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr EQLEaKXUUIaGUFMZLjvtCylSgIKD();

	public static IntPtr lGtbpSctgCOVgjcRZOBtxAHmuAs(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return PzfOltkAAacPtOksSZDasDFOHNZe(P_0, P_1);
		}
		return FRqkIxDJGgfWabxbUGIFllFDYyN(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr PzfOltkAAacPtOksSZDasDFOHNZe(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr FRqkIxDJGgfWabxbUGIFllFDYyN(IntPtr P_0, int P_1);

	public static IntPtr UZNlCVZBmfojHyBnPWSLlVNcwin(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return xlxadbYXsdfPFApJBZZxGwzMNpdP(P_0, P_1, P_2);
		}
		return dzzgZUeSBmqrIMIHmMQZfEQCFXc(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr dzzgZUeSBmqrIMIHmMQZfEQCFXc(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr xlxadbYXsdfPFApJBZZxGwzMNpdP(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr bKIXJkDmQtqgIRUkQtoxPoAzxEL(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool jcrGGYlacEjDKJBaHHSebSsTepbM(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint REVvNeBDdKIIQBKxKMgQotlvyet(IntPtr P_0, out uint P_1);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint hyXCInTsFRbuYDvtlexSlnriFjW(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint ZjwBSLABDoLfBCBkAfqQKMRjLKkx(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int kvhKHhgxRGGFJnqFhveyEJWkyVp(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ehWXBQyEyfWofsXbCPaCLcSKPVt(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool xuigMncLQCkusKLNtHcxhhIAnhz(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int czXBYmTEKXgZGhiFCEuUwMtZaPa(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool okdwpSqfXdmiPsDUjirnhIeMJfY(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool okdwpSqfXdmiPsDUjirnhIeMJfY(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool EQsBsfEfzqeGhvfoMNjbOAzebPxc(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EQsBsfEfzqeGhvfoMNjbOAzebPxc(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr qhBheYePclQmrmzxpEXvXKLTZde(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr qhBheYePclQmrmzxpEXvXKLTZde(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool KZdXpUAqDeRUEEfJqtRhioMmNBE(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool KZdXpUAqDeRUEEfJqtRhioMmNBE(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* EIGYxeLvnSHdhLGwiCCJOMARTTC(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr EIGYxeLvnSHdhLGwiCCJOMARTTC(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr RXdhwooNbwMixybOLiNmQXBZsAi(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool MTLRdQcRClpwCZyOxoNyYsvXJTH(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool CUSCdQRrmWJNKrIuyTTcfmgisOs(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool OKWDLCKdBnztYHmcFhsgKbqsdHaW(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool LLCPeVpyyxSrJClcSEIvbcStNYVE(out rskqRFjyYkswSlwkkUjOlbpRWdE P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr YbWBdtRZYjFjbilhVSLvRpJIDif(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short mLMEYNTbxGERbKYjVOksmBTudvjB(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ZwMcexekMdKMytRmAjoIXVbNbKoc(IntPtr P_0, out rskqRFjyYkswSlwkkUjOlbpRWdE P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool oBWeGLEXoaGztOCCFKCsfXgcjBri(IntPtr P_0, out UKheKfgnSuCTUaVEhhHQJFgeipto P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool IyeSwiwFyCcKXtVfwDYzCaGyWcj(IntPtr P_0, out UKheKfgnSuCTUaVEhhHQJFgeipto P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint LgBTrvwYlANuiMcSfxwUvsEMTyr(uint P_0, uint P_1);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool xAoyAHJdFUADrInDWUpVTFeRMMfa(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool xAoyAHJdFUADrInDWUpVTFeRMMfa(void* P_0, void* P_1, int P_2)
	{
		return xAoyAHJdFUADrInDWUpVTFeRMMfa(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr TVCFgKdOWgSUzFpIsdssfCZqoVc()
	{
		if (!UnityTools.isEditor && kBhJxALdxxcEFwejpLfeqaTmQiT != IntPtr.Zero)
		{
			return kBhJxALdxxcEFwejpLfeqaTmQiT;
		}
		return kBhJxALdxxcEFwejpLfeqaTmQiT = ltqLlotzsNusswonjXgwebYwybY();
	}
}
