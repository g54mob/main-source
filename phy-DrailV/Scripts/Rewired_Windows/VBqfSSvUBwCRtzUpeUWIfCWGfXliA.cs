using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Rewired.Utils;

internal static class VBqfSSvUBwCRtzUpeUWIfCWGfXliA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool TGhEpkdHTiCvDiRJfqbiJVHmBNSG(IntPtr hwnd, IntPtr lParam);

	private static IntPtr EiBBsdJiTwHqmUCtjqJHAQyKnVevA = IntPtr.Zero;

	private static int SnmeDYhQzDCBXZOVQrKPmPyHZYXH;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int zIMejHkjugMAcAvqadzCcBnXgPptB();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr BMclUhGqBRMpuVaCjcTcdPSBZdDn();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint TTTfeRgYhxZYyZYJAhIRdDoXAcVjA();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int gkymVCPVmXusybdQHNpKxFpOYONK(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ZwXCBfflEOQwWgcqpHfAGkvEcIGrb(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ZwXCBfflEOQwWgcqpHfAGkvEcIGrb(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool cHUFdbggRaGbdUiaFbAQGgKapfKOc(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr cjLSLyParBFnuybrhxtYEyNHXonD(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr YVNkJrMBKcayMGCeEdGQFMWUcQBpA(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr UyKRjhXtqbnAuxGdtlMSGVvDAsQR();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr VbBwlNWAtazRfajhacWADkEtAZYLA(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr iBfyAbOQkDijynhslxOWaLcSYhXr(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool bKyJsdFlPyvOdPZTvjsdfBwcfBFQ(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr GGLlzipncQfHvXqNEFqWiiClBYH(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int edvDucgUPOhHfBHWjQvAUqEUZmlZA();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool dOelUvuuIuwaOskbMBgGsKBZGfJHA(IntPtr P_0, out bool P_1);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool ZeDgZvfImvmDNmehqeKOIIrmPEGk(IntPtr P_0, [In] ref NativeOverlapped P_1, out uint P_2, bool P_3);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool ZeDgZvfImvmDNmehqeKOIIrmPEGk(IntPtr P_0, IntPtr P_1, out uint P_2, bool P_3);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr VPAAvBAEAzTlSdoCOwlhrBrVduJab(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr hFTupFUbvBBwKZtwkEKBsQqQWggv(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr KEdRdjYbfzDgmzXyUeeZOTgKfIRD(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool YeMoeJrefQilMdoGlusMNFTcHjypA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr LuMAgVUYOAkCNOfeteoTMKUCSohw();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr CcHOlRojVXldFYFssbKCLJdVkkvF();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr uJlHmdwEmZILzmHAFnPMQfvwLnfH();

	public static IntPtr TJDQMdBXYDlRTRbQTzNOJNPOaLXS(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return zXXlzABvgfNNIqYzGPWDKdFyDEso(P_0, P_1);
		}
		return nOGdZYmjerQSZXySKEzaPNyjdwcD(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr zXXlzABvgfNNIqYzGPWDKdFyDEso(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr nOGdZYmjerQSZXySKEzaPNyjdwcD(IntPtr P_0, int P_1);

	public static IntPtr uCbZWteKxiuFGCiMTFQvFyBKgzHo(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return PiHAlIzAqoTcmPWeVFxACrUkanOd(P_0, P_1, P_2);
		}
		return VTLelpPshvsMviUGuKYwLBYeSgXf(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr VTLelpPshvsMviUGuKYwLBYeSgXf(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr PiHAlIzAqoTcmPWeVFxACrUkanOd(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr NOihoLoxqwVghdptMGzKfhOXMsqxA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool NaFLrnMHAHfZzxndNfEXCgsxGaOEb(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint ldjgPssVJFWlpyeXWotKCnHNnALb(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint lcHRDtPeeFSnTRRvSWLuRlgzMSRf(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint DwprhCsqxIuxtfZspjUdJuzGeGjf(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint pCKlSsanpfjqafrnbuGxwBxnBeGD(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int YUXaaUNBjBGBuRoEbFqJjwUEnGCNA(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int hMeScaxaRxNWFiESpdaHIdXWuMMJA(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool YfkgArZEUsogIOqiSgqhjKysKEMd(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool XvUaJYHNnVgqPBqKJhVErTEiqeYJB(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int GzzDgJataKbslNPOWYXlGilxHlRw(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool WjRmLlRnzooaaYfRfOmSRJakFupM(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool WjRmLlRnzooaaYfRfOmSRJakFupM(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool wpGLTQYBIzSQGPdZCvCairlAQWFc(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool wpGLTQYBIzSQGPdZCvCairlAQWFc(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr UzbRFrkAWqotEJtonZKAbNVroyTH(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr UzbRFrkAWqotEJtonZKAbNVroyTH(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool sSDUEfhbxnIuzkQpcDMMMIfAIobE(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool sSDUEfhbxnIuzkQpcDMMMIfAIobE(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* aGyIdXyBRNTROlPzmAOqiBWrnInN(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr aGyIdXyBRNTROlPzmAOqiBWrnInN(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr zEHyMBRdrjpWNSUmRmmeugBddzBdA(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool eQbCEhRousMavbnBhlZTuQppsCwy(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool cZgsEpgPIRFRzThjeFLHNZcSmFFo(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool qhyaalzRvshBvzQlTazLLmgOSzXE(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool hHsaHkEWAqSpycyfUjYWKeKLmRuq(out zMEltZKvhNBHUFyDKRqiiLhnsXKs P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr mfyPAQqXwgHfMIkcNHVUgtXuuvGrA(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short UIivVgcbNLNfYsBwTcPVUaDQAgYx(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short lqQytorDxVcgNsDpjcnZIpkQJjNGb(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool SkblAsrxBwDeSByXliNHvHWujmuD(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool dQmVAGRyTgYyBVdSGaghhxbnJGTG(IntPtr P_0, out zMEltZKvhNBHUFyDKRqiiLhnsXKs P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool UviztwmCsnhAMwDxNKwRpyRHUmCe(IntPtr P_0, out aRZgAkkxJJdjQDIJhTFilAsRxdob P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool cECYlZPepHLotRDMwcDrfiuMpNLEA(IntPtr P_0, out aRZgAkkxJJdjQDIJhTFilAsRxdob P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint fdIISZyRZanLcJNfadxNTOghTQG(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint IayylJsbhMFqkeVMJoSXJLbLfmRoA(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr jKQHHVuTcRaegrhHBdggbmEQchAFA(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool YkweqOvVOdEWsmDRmSdfAOaGdppj(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool VuAtacyvSDBAOFEJIxkefiuxVUOb(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool VuAtacyvSDBAOFEJIxkefiuxVUOb(void* P_0, void* P_1, int P_2)
	{
		return VuAtacyvSDBAOFEJIxkefiuxVUOb(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr vscZBvMucbOyMfqJkbaPPOFWbTRj()
	{
		if (!UnityTools.isEditor && EiBBsdJiTwHqmUCtjqJHAQyKnVevA != IntPtr.Zero)
		{
			return EiBBsdJiTwHqmUCtjqJHAQyKnVevA;
		}
		return EiBBsdJiTwHqmUCtjqJHAQyKnVevA = LuMAgVUYOAkCNOfeteoTMKUCSohw();
	}

	public static bool GIeaJNZxQzAJbIcWJVvzQrwCbSjo()
	{
		try
		{
			if (SnmeDYhQzDCBXZOVQrKPmPyHZYXH == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					SnmeDYhQzDCBXZOVQrKPmPyHZYXH = 2;
				}
				else if (dOelUvuuIuwaOskbMBgGsKBZGfJHA(BMclUhGqBRMpuVaCjcTcdPSBZdDn(), out flag))
				{
					if (flag)
					{
						SnmeDYhQzDCBXZOVQrKPmPyHZYXH = 2;
					}
					else
					{
						SnmeDYhQzDCBXZOVQrKPmPyHZYXH = 1;
					}
				}
			}
		}
		catch
		{
			SnmeDYhQzDCBXZOVQrKPmPyHZYXH = 1;
		}
		return SnmeDYhQzDCBXZOVQrKPmPyHZYXH == 2;
	}
}
