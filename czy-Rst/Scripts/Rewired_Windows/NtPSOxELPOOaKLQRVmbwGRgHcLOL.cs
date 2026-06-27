using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Rewired.Utils;

internal static class NtPSOxELPOOaKLQRVmbwGRgHcLOL
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool INqGiictGtnaxoRUxCTpYXiGcipYA(IntPtr hwnd, IntPtr lParam);

	private static IntPtr kkOKcmIngKoytJFskYlkQmAyLJdI = IntPtr.Zero;

	private static int bgsIdKQQqWdKmiibCFNjMCblkiLA;

	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int aKyUwGmhVuJaxEqqBhfsPUmwaxPCA();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr TPMtriaFgLGRkWBubAxCGYVmsbjO();

	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint rttUDjfQKrOplRRBxBnrdDfHSGqk();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int wXnMFjsjDWyFMBjyIMQkuhOGcwpAA(string P_0, int P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int UCKKcdYgtclXnNlmBjMcWGTCIors(IntPtr P_0, ref int P_1, ref int P_2, ref int P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int PZHEZQcwWNpgnKAxWwDwwjRxkCyaA(IntPtr P_0, ref int P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool aqcEoBBUmkDJVNwCFNKLYyxdaKyr(IntPtr P_0, byte[] P_1, int P_2, out int P_3, out int P_4, out int P_5);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr IEHjKUuoaFbWjdBiHOuQPHfpqbMFb(IntPtr P_0, int P_1, UIntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr CCOpJWnzhaLLuOSogSduKSqpgfRh(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr nquNWfpVohBdqERXAoWpJEslthtw();

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr dwtaxxpgzPDyxUDMCLQHwClPDOiw(uint P_0, UIntPtr P_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr GqeCSEjORZqAGgqSDFGIYBqLcUAgA(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool wrAzlEpaDaIaBjeDXMQadHsYQqALA(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ijIhysUVgKVzblJrQERlCEMrrNPf(IntPtr P_0);

	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int jTgaFAeeHfONPYcsSMPEngdKMcGNA();

	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool psjbjClCQfoaFgFMPWqWKGNZMKnN(IntPtr P_0, out bool P_1);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool XboVIcQsNkCHKPQSgFmLxUgZIyOK(IntPtr P_0, [In] ref NativeOverlapped P_1, out uint P_2, bool P_3);

	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool ywZaUjBsFKQdMBOggTqJCfgxQmfoc(IntPtr P_0, IntPtr P_1, out uint P_2, bool P_3);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr OxLokIriEreMIskeAwsEoLFfvwlM(int P_0, string P_1, string P_2, int P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr LqPQRXEXvNibWGmPxkDcrEnQsGgB(IntPtr P_0);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr ZbkzNNpkblrnJGjZtfxTUzPDENnL(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool uUtmfVjpZSEzGNXcvycgDRVXuZJB(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr PaxRujERhpkvykPpeVqRrgJaBFrHA();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr JrCdfdMwLKEKFFBMQyfyaEIpLjGFA();

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr PVuzEAmmgekMahdvMMEpEdClaksR();

	public static IntPtr alFiKiwdRZmHoKVsTFwKkICuGwbj(IntPtr P_0, int P_1)
	{
		if (IntPtr.Size == 4)
		{
			return zESTcnnzTvjSgJhAoELdDMunVfmsA(P_0, P_1);
		}
		return zIWQbZAykbdlvpmBnXrIzEDmxltj(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr zESTcnnzTvjSgJhAoELdDMunVfmsA(IntPtr P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr zIWQbZAykbdlvpmBnXrIzEDmxltj(IntPtr P_0, int P_1);

	public static IntPtr bjEbnxbrUZsmgPsdjHxNsSVZYnqQA(IntPtr P_0, int P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return yksLHSYsTAkiKdHXqmKhmsxHYhoB(P_0, P_1, P_2);
		}
		return JBhTAnnLCHKlTYGeaKEKUuaiuCVG(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr JBhTAnnLCHKlTYGeaKEKUuaiuCVG(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr yksLHSYsTAkiKdHXqmKhmsxHYhoB(IntPtr P_0, int P_1, IntPtr P_2);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr FwPVcEMWEsBDuuQsXsOGLuWlLNmo(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool rzGvcBYYWTLREzIdzwpSDbDuIuBv(IntPtr P_0, IntPtr P_1);

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	[SuppressUnmanagedCodeSecurity]
	private static extern uint aNLqXCxAeEfPjjlGmJMTItNVxqVZA(IntPtr P_0, out uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint XcKDTfxNlTXPCpBdRIIDMcgWIsSE(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint YlkZtIpsPMcPRsVuNPaADnCzPzJ(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint ZAKPfQJGmiVoyNjTilHCcMenQCLA(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int JiBhejaMqSXVKAfzfHNOVPJSemIYA(IntPtr P_0, uint P_1, IntPtr P_2, out uint P_3, uint P_4);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int BFMDltrerajaPyNaAAvwhShXPjhCb(IntPtr P_0, ref uint P_1, uint P_2);

	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool HGdgfYxfqXAObnHmylMdgsASxyDA(bool P_0);

	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool CanBjrLCNnfRmGQlAIqmrwjkRpwP(uint P_0, uint P_1, ref int P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ntMjhzJDjrCxEIElPrQCzkevzPHJ(int P_0);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool oziYVinGIlZVMHfUSDfIGNNhEFbgA(IntPtr P_0, IntPtr P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool EIscnSeBKsfBejbYPlhxpnwdZNme(void* P_0, void* P_1, uint P_2, uint P_3);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool frWBPbMJfEdeFBCgkiOVviusoXObA(void* P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RvOuNurIegIGLqixNIHrdpZWKhvd(byte[] P_0, IntPtr P_1, uint P_2, uint P_3, uint P_4);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr rijzIxicdaCVxwziCCaiGNkRoesm(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern IntPtr jZZAddNHlbHDxkMPOPGnGMcLDWfx(void* P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool xMyxwXUxKoFMTlZBjXjwKJQrUitd(byte[] P_0);

	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool yUBASrWFqFlFOWTJPkyUxBvDXXGB(void* P_0);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern void* dAojlOzkdbeMGPvWnXrBAVucNdxG(void* P_0, uint P_1, void* P_2, void* P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr JZngbWdzUuCHTGypGAymoeVVtWXOB(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr VaZAOkENNmsDILnEgcgYkBAGjUdC(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool sVnfpUBiLUGlQKLehwGunBVUNBuJ(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool RmIUxQpMsWpxxpgvsMzDZduvrdBL(int P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool JNLpicUKoUnYKJqeDsItCzrzyCDc(int P_0, int P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool sVyRlxiLdQjBkBpkHPldkhpiOFCbA(out vlfgncxvllnAvfZfdwCSJhJwTmvu P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr XBNmGvceETjoKcLLdzbobVCDUcevA(uint P_0, bool P_1, uint P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short vQkUdrJZZUSkFbfUGIkRfVHZLwqN(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern short aNwrGaSQfqFQeuKEXkRLzwXUDvhx(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool CBzWvYlDpiAVWLjveYmLkxNJpBJI(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool ifDjvBKqaiexGCZRaKydZQmqDEJd(IntPtr P_0, out vlfgncxvllnAvfZfdwCSJhJwTmvu P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool dhjIPJzJjPHPbPkasogzeMnBigtBA(IntPtr P_0, out qbkmXxJfjjyFQragMfjpSdaEJOIr P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool XXBCzeytpfvFbumhXUsiLGHcylVH(IntPtr P_0, out qbkmXxJfjjyFQragMfjpSdaEJOIr P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint BrnzYoLeKZGhAjuIlgxSeenGmRHZB(uint P_0, uint P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern uint HzFKRwciTvmJBUrheMmEVIqLwDCq(uint P_0, uint P_1, IntPtr P_2);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	[SuppressUnmanagedCodeSecurity]
	public static extern IntPtr wjApOdCNGviNyGJdYxrKemDjjBqtA(int P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	[SuppressUnmanagedCodeSecurity]
	public static extern bool iAEIfcvBJqyKuzfmrjkpghVnWzwIA(IntPtr P_0);

	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	[SuppressUnmanagedCodeSecurity]
	public unsafe static extern bool AtrcrHDgyKmIoZKDjZATIZvvitKAA(void* P_0, void* P_1, UIntPtr P_2);

	public unsafe static bool fMoAnRfpDlbeglhJffNpIHpaKZLec(void* P_0, void* P_1, int P_2)
	{
		return AtrcrHDgyKmIoZKDjZATIZvvitKAA(P_0, P_1, new UIntPtr((uint)P_2));
	}

	public static IntPtr mfAwakXZewqnIYzQRlaMvZSxMEgj()
	{
		if (!UnityTools.isEditor && kkOKcmIngKoytJFskYlkQmAyLJdI != IntPtr.Zero)
		{
			return kkOKcmIngKoytJFskYlkQmAyLJdI;
		}
		return kkOKcmIngKoytJFskYlkQmAyLJdI = PaxRujERhpkvykPpeVqRrgJaBFrHA();
	}

	public static bool ASjKXoxXNvqAtnGsQbNSPfBtRBnX()
	{
		try
		{
			if (bgsIdKQQqWdKmiibCFNjMCblkiLA == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					bgsIdKQQqWdKmiibCFNjMCblkiLA = 2;
				}
				else if (psjbjClCQfoaFgFMPWqWKGNZMKnN(TPMtriaFgLGRkWBubAxCGYVmsbjO(), out flag))
				{
					if (flag)
					{
						bgsIdKQQqWdKmiibCFNjMCblkiLA = 2;
					}
					else
					{
						bgsIdKQQqWdKmiibCFNjMCblkiLA = 1;
					}
				}
			}
		}
		catch
		{
			bgsIdKQQqWdKmiibCFNjMCblkiLA = 1;
		}
		return bgsIdKQQqWdKmiibCFNjMCblkiLA == 2;
	}
}
