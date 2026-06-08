using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class ixegfHBaMxnBoCPrkXxioKnitVNp
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class NwKxOlLjfvYCtLpbtHdcFpYuXrgt
	{
		public int vZKepwvXvsiArxTuRtkFOotEIyR;

		public int SIkuUEdrgoEkfaZFOZDYABgCudcm;

		public int mfJEtuyGPcyUpNHfUfrJDcPcLUWF;

		public int tvKEgzlysmwoYjzKxTfrnsDXsuM;

		public int taPGZkxwMJrBCdAjjrCVMjHugBCi;

		public byte XJjUGUzNnkikaFUnGbzhEPyIPGei;

		public byte HvWUIEwbanVhUdHthyNDClUhdaX;

		public byte ShqILfbPqchwqkNMtxQjDtYyDEM;

		public byte UwFaNgArTpCwkZVoFdXOoScbHTrk;

		public byte BcqAuqZLJMbBUbCHSVxQQmJRqNZD;

		public byte pyIEaWETKLAtbqpMvrnRpeRBlXc;

		public byte GnsGKuDFByqoGIqSfXNzCRzrDfk;

		public byte kjugYZgLwjwZEdiyxGMpkUFqwOY;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string gCFsXuyMfqtDhIkCkJmAFcGzHFEd;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct UnCfoGHguKoBuTfDeLLsNTUVRuhU
	{
		public int baEugVhVAgaxUqmjkTWkSOsWgJD;

		public int DsIkKgAPIhXqZEzrYktApFldshw;

		public int xOAFLqNtjsqXOJfCusHLvJdgFMw;

		public int AyEecBMgKnCEZIfZaQkGoLThSwh;

		public int TkiDqIJUTOKTrxjvwoxvFrbfIzMT;

		public int hNOncCLGqKdEklEkiHNMEijvUTm;

		public int cyjaryjCHxWeHROVEmATDpWrxARZ;

		public int NwXPwONbDtLcmjHxlSESdnjzVEy;

		public int WsaKLzBFvVfSQMJqCbcDcXALgGi;

		public int ySqzqctPGEEPlaNnsLMHLHcTAiBn;

		public int tuLulmkUrgRAJjFtripqwjFBDUu;

		public char jwHlyHaEbdtvDrMzICbzLtVgYLK;

		public char dRIcOSWIhzXcSZYjCTqfJOaxkTy;

		public char IQwrNHnkyWfAYaEBgdoaaXgXtN;

		public char zHcNfGujuubnTtmfIJLltLgqsRC;

		public byte guVKwWtoYUAOPXwyfKKyuoHvtbc;

		public byte hFSAGabgYhNIfZHnhtdzypMQsHA;

		public byte aJOgBlWmJDtHVNJQJBGAkXaPnwHR;

		public byte MpNGxGqxqQnxBTBitEYwpjGSFqI;

		public byte cQwPJGZmkBGqodHZoickBywCeGnN;
	}

	internal enum CmhOLkbdNKnGmhyPEBdMZgEmbxWB
	{
		UeJwAFZBRXUmpWqkpXpTmRxhklJ = -4,
		ldBMvnHPKKjjxqRfLNDyUSFKJLx = -6,
		MSRROQoJAGXvnIziBUmgsDLsIlqJ = -8,
		pniblxbFNTnWZBcqEZwkVtZcdpQl = -16,
		TwwKuSnXuHWquldPAiyaTuHHwah = -20,
		UynuAOUhpOqKDbdgzihoJRQIkneu = -21,
		owljquRHNdNmtOlRNSdQpFpVNTt = -12
	}

	internal delegate IntPtr KFzaeeWLfsGcKrSTWsARjjmTaRa(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool gPACwgVMWcbYYJdkFlKvMGwFWOk(IntPtr hwnd, IntPtr lParam);

	private static IntPtr tgscWlofBLLBkdMeipMoaRDEnIt = IntPtr.Zero;

	private static List<IntPtr> AwkxiWFlkjdAHEZUxEASXhOMLBH;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int qiOcfEKPRImPCDEIxFfyOQSUZgB(out dQNxrbTqOrCWxtICVRZoUaufKJU P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int AItSaumVDYleJcNqNYmawrPvPDw(out dQNxrbTqOrCWxtICVRZoUaufKJU P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int TemGizbjbObWvHVZfMXpgjGYLlu(ref dQNxrbTqOrCWxtICVRZoUaufKJU P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int zLSmjdoMQTgNAcUpgAKjGZofmpWg(ref dQNxrbTqOrCWxtICVRZoUaufKJU P_0);

	public static IntPtr aBykNhFOmeeFXkLSUSFtbCoMARC(HandleRef P_0, CmhOLkbdNKnGmhyPEBdMZgEmbxWB P_1)
	{
		if (IntPtr.Size == 4)
		{
			return UbuFuUXEkWgdOJUyHKxciQawVhp(P_0, P_1);
		}
		return ImxwPWypaWLvRwCjTlTTzbmrmun(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr xJiluLyqduCSBjHpzgsnxPWPCbo();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr UbuFuUXEkWgdOJUyHKxciQawVhp(HandleRef P_0, CmhOLkbdNKnGmhyPEBdMZgEmbxWB P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr ImxwPWypaWLvRwCjTlTTzbmrmun(HandleRef P_0, CmhOLkbdNKnGmhyPEBdMZgEmbxWB P_1);

	public static IntPtr HKQsEhmRzHHEChfVIFHCvpcQinY(HandleRef P_0, CmhOLkbdNKnGmhyPEBdMZgEmbxWB P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return ediqsUhnWBsowyNHEIArsnKmQvX(P_0, P_1, P_2);
		}
		return NzbKOYUzywKivIiWZbdfIdkKjhGM(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr ajBRninqayjXQAsgwbLJygGyxhGt(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr ediqsUhnWBsowyNHEIArsnKmQvX(HandleRef P_0, CmhOLkbdNKnGmhyPEBdMZgEmbxWB P_1, IntPtr P_2);

	public static bool KrWoSDmosfSKvZRAlBGrxeryBKmH(HandleRef P_0, bool P_1)
	{
		return KrWoSDmosfSKvZRAlBGrxeryBKmH(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool KrWoSDmosfSKvZRAlBGrxeryBKmH(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr NzbKOYUzywKivIiWZbdfIdkKjhGM(HandleRef P_0, CmhOLkbdNKnGmhyPEBdMZgEmbxWB P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr htGKfzUHnOyagIDCZibcgouKFyGY(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr IuAwvUdBDYyPPecBZcYuZGwOpdP(string P_0);

	public static IntPtr aBykNhFOmeeFXkLSUSFtbCoMARC(IntPtr P_0, CmhOLkbdNKnGmhyPEBdMZgEmbxWB P_1)
	{
		if (IntPtr.Size == 4)
		{
			return UbuFuUXEkWgdOJUyHKxciQawVhp(P_0, P_1);
		}
		return ImxwPWypaWLvRwCjTlTTzbmrmun(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr UbuFuUXEkWgdOJUyHKxciQawVhp(IntPtr P_0, CmhOLkbdNKnGmhyPEBdMZgEmbxWB P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr ImxwPWypaWLvRwCjTlTTzbmrmun(IntPtr P_0, CmhOLkbdNKnGmhyPEBdMZgEmbxWB P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool punIMLhHllGjATCFuAtzdfuyDkbA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr muhCqTEVIjETTjnhyNfamybWpngK();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint yHmCwRODlGCxugdMHATkAPLZRpCr();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool yyHVzAUIHqoxnAkQITgfYBUbvJP(IntPtr P_0, IntPtr P_1);

	private static bool XTToRVaIssWjAxXySjHotxDgnQu(IntPtr P_0, IntPtr P_1)
	{
		lock (AwkxiWFlkjdAHEZUxEASXhOMLBH)
		{
			AwkxiWFlkjdAHEZUxEASXhOMLBH.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint AuUIQRskTaEjhXGtTShCoAEJyuP(IntPtr P_0, out uint P_1);

	public static IntPtr AUFWjjIkwWerQKSUjdsylUuMVyM()
	{
		if (tgscWlofBLLBkdMeipMoaRDEnIt != IntPtr.Zero)
		{
			return tgscWlofBLLBkdMeipMoaRDEnIt;
		}
		AwkxiWFlkjdAHEZUxEASXhOMLBH = new List<IntPtr>();
		uint num = yHmCwRODlGCxugdMHATkAPLZRpCr();
		gPACwgVMWcbYYJdkFlKvMGwFWOk gPACwgVMWcbYYJdkFlKvMGwFWOk2 = XTToRVaIssWjAxXySjHotxDgnQu;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate((Delegate)gPACwgVMWcbYYJdkFlKvMGwFWOk2);
		yyHVzAUIHqoxnAkQITgfYBUbvJP(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(gPACwgVMWcbYYJdkFlKvMGwFWOk2);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < AwkxiWFlkjdAHEZUxEASXhOMLBH.Count; i++)
		{
			if (punIMLhHllGjATCFuAtzdfuyDkbA(AwkxiWFlkjdAHEZUxEASXhOMLBH[i]))
			{
				AuUIQRskTaEjhXGtTShCoAEJyuP(AwkxiWFlkjdAHEZUxEASXhOMLBH[i], out var num2);
				if (num2 == num)
				{
					tgscWlofBLLBkdMeipMoaRDEnIt = AwkxiWFlkjdAHEZUxEASXhOMLBH[i];
					AwkxiWFlkjdAHEZUxEASXhOMLBH.Clear();
					return tgscWlofBLLBkdMeipMoaRDEnIt;
				}
			}
		}
		return muhCqTEVIjETTjnhyNfamybWpngK();
	}
}
