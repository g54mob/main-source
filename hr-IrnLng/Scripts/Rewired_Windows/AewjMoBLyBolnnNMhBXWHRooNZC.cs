using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils;

internal static class AewjMoBLyBolnnNMhBXWHRooNZC
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool mCKOMzJXqkWuhGlJaXLdYRmyReP(IntPtr hwnd, IntPtr lParam);

	private static IntPtr rMuaLDfFTUuFIHvODEHxuSzlVRy = IntPtr.Zero;

	private static int lFLWVokMbduvlSKiwTnfYNnwdPR;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int GLpAprmAcQelAyLVDrjulEcJfNdF();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr gHDXEVVVFxMlIOzxBpPEPPDoFnPD();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint aBoBNdLUrXDhQQzscRMlJddohqFB();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int BkDyZkKLcnKTMwzbvXTiBecneAN(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int uYuBqLqyCmpJibKXPCpgIDwPwEU(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int uYuBqLqyCmpJibKXPCpgIDwPwEU(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool RNrcKNntTYGAVjPZtQCwOcJKyjQ(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr PImNzAQXmzNqQppIDhjgqOzuuNj(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr dZqAJLfTUQEFcnNRynYsBwZbdWJF(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr rUnEGVUuSFlIIkITLWHyiuPmsZY();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr iRcQAvPNrYkJLdyIGEjkUVFQPqY(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr PSEjYHZtgxSPOmOVJWLmEFtrdKB(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool SGVTDZAFqCnrRGsVRhHHLxFZNkL(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr zOpggHrgbSahpFogbDWQpsjbcbEi(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int HsSVMQNFJeDuLUqfgNfsKVXaCez();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool OdDvyFnIJQBeytAGqkQwYcSmxmR(IntPtr P_0, out bool P_1);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr kEvQuzDwQXAIgzidonnNbfqogyV(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr OpqeVvFwxxcPoKKVWAIvDGjhfkkX(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr lmIFqBFHfPjoSGqaevsdloGxHlNe(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool tnpXovapZeMTkjrIXoysdQnNfdq(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr uapcxzBOCaDXbFTZHierdwXxuwtY();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr tQkqbzntvxhEpDXXGKbmrrmyrsj();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr LIKQoBfcynFjNAdlxkpqEkuDgNzq();

	public static IntPtr mIcfmROfUnqGxOdljRQshbYfeZD(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return IusSLkScnLiYofYAeHTdcCnJITk(P_0, P_1);
		}
		return AghYAcxDqPGxhOiXchSIHjUCUza(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr IusSLkScnLiYofYAeHTdcCnJITk(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr AghYAcxDqPGxhOiXchSIHjUCUza(IntPtr P_0, int P_1);

	public static IntPtr DRWfdJpjpYgVyRfznqMBraKjmlX(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return mjiNnqkcOKAcOdIbfWPwwmsLqoEb(P_0, P_1, P_2);
		}
		return wZiyLFMLjBtVVhRxMCOOjnLTDYN(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr wZiyLFMLjBtVVhRxMCOOjnLTDYN(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr mjiNnqkcOKAcOdIbfWPwwmsLqoEb(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mHJDbtyZENNTsOeuvwaPPccyYs(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool aQeWLyLAJbiJSaGaxYhkYpuMiQI(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint EnKDFzjKNtdtPxoBsAaDicsmmhI(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint WPimmLUNirHddOMGogIEehnEPAPc(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint mwMKDgrBrcPjXwXLTxoVdEkzDkb(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint CpjpWEnKlJLIOeGWTdmFcIIOsFMS(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int tYywPmEMznZgYESvREorQiNjYWS(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int WgZDhIiQBPfslnwjTubhPxUhEtU(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool fLLIVJOcKKUDoBKXsXiBJmBDDSK(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool izvqGuMVvxVdtpffXHZyruPHNcW(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int pCIXxPnkogJNwAtiuOTKosMWxNB(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool fiogCLYcjMTzKHtkTyAuplrPuKr(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool fiogCLYcjMTzKHtkTyAuplrPuKr(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool BdfpoeTUNFBrsEhAyWjaUPcxSSI(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BdfpoeTUNFBrsEhAyWjaUPcxSSI(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ltYrwThCYSvFcWfZDRVcBMIMdeP(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr ltYrwThCYSvFcWfZDRVcBMIMdeP(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool VXehdLcArHUbNrOrWHBeozHxpYx(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool VXehdLcArHUbNrOrWHBeozHxpYx(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* NkVYbWlJhbiisqSiWSjGINYWQOr(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr NkVYbWlJhbiisqSiWSjGINYWQOr(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr SOcfzfErbBzztTmDbkNOGKUExqT(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool VfAgrTGCiOVDFhgeRXTdFKuAtMip(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool JTFvILvdEvufHYmGQRTthqvnDhJ(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool DmXVZZcybGUAPeeUffyhpwnnUMZ(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool UNVbkCbPOSyQIerMafQiPsTwAZmU(out uZnqpMDzWBFfVWkOCMMLjIuYPQh P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ZNVvimhjgOKOeJFVlPbkJZYPvKU(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short flLvKQzCPnXcurXRbLwjkLKxQuU(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short EgrHVWeqxnqXldbAHRprvVxzdxDY(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool lGEIMckzpEMogUqZFYitDPUHCzk(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ICJtwqKDsECflbWCoByBkHyMvLVO(IntPtr P_0, out uZnqpMDzWBFfVWkOCMMLjIuYPQh P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool nWNMUExEEPEGqadepwWpENreKECZ(IntPtr P_0, out XJwmEgVpkZbeNumcRaFRTtrzgxQ P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool FPdQBpWzlrVkFIinUHJZANlrMDN(IntPtr P_0, out XJwmEgVpkZbeNumcRaFRTtrzgxQ P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint KLWgfiEsFzvHvrDcXCeDKhPTarCD(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint zTZYWjdohuZIGOOlrKytjEwieoX(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr UixsgzhgsjPRAyUunbkEXLVdwvG(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool bJZuPkeKQPqpMlOaCqAZokjbIlj(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool iWdjIApMtbjmqUSnoOlIDKbObPO(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool iWdjIApMtbjmqUSnoOlIDKbObPO(void* P_0, void* P_1, int P_2)
	{
		return iWdjIApMtbjmqUSnoOlIDKbObPO(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr YABwwXHSsTojcscsIpnzfwQpmnR()
	{
		if (!UnityTools.isEditor && rMuaLDfFTUuFIHvODEHxuSzlVRy != IntPtr.Zero)
		{
			return rMuaLDfFTUuFIHvODEHxuSzlVRy;
		}
		return rMuaLDfFTUuFIHvODEHxuSzlVRy = uapcxzBOCaDXbFTZHierdwXxuwtY();
	}

	public static bool fMLbqtKOCPvcPfZfxjnLngbxRCxh()
	{
		try
		{
			if (lFLWVokMbduvlSKiwTnfYNnwdPR == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					lFLWVokMbduvlSKiwTnfYNnwdPR = 2;
				}
				else if (OdDvyFnIJQBeytAGqkQwYcSmxmR(gHDXEVVVFxMlIOzxBpPEPPDoFnPD(), out flag))
				{
					if (flag)
					{
						lFLWVokMbduvlSKiwTnfYNnwdPR = 2;
					}
					else
					{
						lFLWVokMbduvlSKiwTnfYNnwdPR = 1;
					}
				}
			}
		}
		catch
		{
			lFLWVokMbduvlSKiwTnfYNnwdPR = 1;
		}
		return lFLWVokMbduvlSKiwTnfYNnwdPR == 2;
	}
}
