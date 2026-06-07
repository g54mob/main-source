using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class tlfLBPuqgJySwCjSltjrpFZlYYxH
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class rFasLuFKriFsgHIWQmEuTxljwYpH
	{
		public int GntkUgYBZcuVOJLkFbPANojvQnz;

		public int YRtzeSqcHZfdiABxeUETHUoCyMwg;

		public int nTdAtXcclrMUBZoTxuhOqcRgCIkQ;

		public int MozIojXGtxMyJZgJjhkLukpoIvup;

		public int SFEYjkbgQpONEJZBVEtLGWxbiMfk;

		public byte pbhBEzmkWvhzxLeLOwhZmYSElQuO;

		public byte lIBqfwQJORdhIGGJQCwYoCvNNpRS;

		public byte DumlIwlnGZbFkgDXZJxOeONfFraac;

		public byte lbgbIdOFOTuVUlPbWMTQZgIJNNNO;

		public byte ZiiHeAYcYiuoIDfTZKEBOTycrtwC;

		public byte qkkMXVhKBDguIEkvuCwMiGwvHNNV;

		public byte erJAbEozcPpNbfroTrKLayfUcxlR;

		public byte SCulWpxHsVNFeDuSuJDgXDOSrGtx;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string FkLdIMgpTHBEgVYhmlxXOTdNFeHAA;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct EVBaDsvNsQfIuSMRUDuQgjUomlCI
	{
		public int igyofptabDgiKBRgKFORBUCbZBeKA;

		public int WWfeKzCfKhvXBblsqnXJzZZhThIeA;

		public int RQgdLVMbAgcOTIpjtitGWsBvynzmA;

		public int DVRDnUjBcUTXkLtAOOlTFEmAPjryA;

		public int obrDHUevmKTpZdILpDFVsPemlOYU;

		public int QnoaJFncHcSgXeyLckdsGxViURIV;

		public int BuYUZJOnYJsNeVCmDasCLDdbciKhA;

		public int jcqCRTssKRidkvkAKZGoYxDGQyfi;

		public int GTFXjjbNoKRYTouIRqeWMvKEqCyv;

		public int hRDWlqIpmgesQyeMoMPTKanfwntG;

		public int JsNgpXquineBKjnaIKInOfHWNmKvA;

		public char AfrkxYFOvQWcwGuJUqUoBARYCnYF;

		public char qgcCYCFwbiUcaBRfNhdVatRsxbOZ;

		public char ITyKbtTfFBPSJMIKHkDFQBmIftQG;

		public char hCbQmuhsCIjlKwKKhFmugezgfeOvA;

		public byte ErwfOsyTmxhyNNqDxtSIbBTNPxip;

		public byte IpNSJBxipkrmypmLVSjDEeyXapmh;

		public byte jxZLpIpqTUYoKRRfhoVdrNKyvIkA;

		public byte NTjppUDjAhhZYUojMgYudbwiPolc;

		public byte bxvdDYvNfYhJSAjrjMwbjSpEjTIDA;
	}

	internal enum AwRkygDXJHIRLlsPRnpIyZuCoeVQ
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr FUgACvQYliEofCYNjhNfRfuCXMSC(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool pilfqYAsJMJUNJrkuoZfGTbavosnB(IntPtr hwnd, IntPtr lParam);

	private static IntPtr pxlLcguoDAjOnBGqPMLNiDgOONhtA = IntPtr.Zero;

	private static List<IntPtr> UfJcyXYmvESkBrQICXvQyDdSQPSI;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ygeMiYFbTBZNyZSBrxmQznjvHJYH(out yRQRevBfkRkzvmHYnbPvhFUfXWoN P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ECOUBakNWnFfguGqxLlYetSFEhsJ(out yRQRevBfkRkzvmHYnbPvhFUfXWoN P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int RNtaIlIFEvciXWGsxhVfCuNqiiYv(ref yRQRevBfkRkzvmHYnbPvhFUfXWoN P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int CPrJCZHtijicRsNPdqVLftoIADPs(ref yRQRevBfkRkzvmHYnbPvhFUfXWoN P_0);

	public static IntPtr gnKtNfdnSRZpRfkRBwKcFOBGWZQs(HandleRef P_0, AwRkygDXJHIRLlsPRnpIyZuCoeVQ P_1)
	{
		if (IntPtr.Size == 4)
		{
			return vgvjJOpqspXkLXlHFiNPYsXNnowl(P_0, P_1);
		}
		return GvstLpQKkmXAguIBViskrUulapLm(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr XLFvvmdyZvMgzWaRslsjgLrbXsyR();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr vgvjJOpqspXkLXlHFiNPYsXNnowl(HandleRef P_0, AwRkygDXJHIRLlsPRnpIyZuCoeVQ P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr GvstLpQKkmXAguIBViskrUulapLm(HandleRef P_0, AwRkygDXJHIRLlsPRnpIyZuCoeVQ P_1);

	public static IntPtr umdlYTeOhIISMboAuMdRwFSHrmnT(HandleRef P_0, AwRkygDXJHIRLlsPRnpIyZuCoeVQ P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return kkfitMBojilEJCszcLpIKuOwFzGh(P_0, P_1, P_2);
		}
		return clkNKyjrcaVSYEEYshfnROuSOOaf(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr FvpfSPTtPOKgSsGpBQXAmWiGYOyd(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr kkfitMBojilEJCszcLpIKuOwFzGh(HandleRef P_0, AwRkygDXJHIRLlsPRnpIyZuCoeVQ P_1, IntPtr P_2);

	public static bool qieKKzvNlmjLiYgfQkzWTFfwUIFF(HandleRef P_0, bool P_1)
	{
		return gtNGVVCPSGqgKfkwJodNdesNErUKB(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool gtNGVVCPSGqgKfkwJodNdesNErUKB(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr clkNKyjrcaVSYEEYshfnROuSOOaf(HandleRef P_0, AwRkygDXJHIRLlsPRnpIyZuCoeVQ P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr JBAAIfBFFgIDWWMrLQxaBWdaNnWaA(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr kOatxhjPrxeDTdJXtjGJCmqEiFTh(string P_0);

	public static IntPtr IBFPYydUDlvPobPkZsnRBDBMFhd(IntPtr P_0, AwRkygDXJHIRLlsPRnpIyZuCoeVQ P_1)
	{
		if (IntPtr.Size == 4)
		{
			return PGAfWrDAiUIqskhCNohGLYPhHOmAA(P_0, P_1);
		}
		return GVaduxDvBNKDDnNQxUGqVogqOLRcA(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr PGAfWrDAiUIqskhCNohGLYPhHOmAA(IntPtr P_0, AwRkygDXJHIRLlsPRnpIyZuCoeVQ P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr GVaduxDvBNKDDnNQxUGqVogqOLRcA(IntPtr P_0, AwRkygDXJHIRLlsPRnpIyZuCoeVQ P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool OLnHATFKWYsBKWEwQQzBebdSzimF(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr RUDjiDpqTEdAUJfpZNhTSbLhOkRu();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint alFfDbNpJHgUxxeBKJqlYaIlUZfg();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool OKLfNHIUuNAZcVBKuWZsGTbTUXDUA(IntPtr P_0, IntPtr P_1);

	private static bool EemDbHKeEYwyrhBcUHlrdBwxhQYb(IntPtr P_0, IntPtr P_1)
	{
		lock (UfJcyXYmvESkBrQICXvQyDdSQPSI)
		{
			UfJcyXYmvESkBrQICXvQyDdSQPSI.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint GZADwRtFTQAIpCWQXLBXWlYufRdi(IntPtr P_0, out uint P_1);

	public static IntPtr mqkgeOIJFAfnsnNyXtaqJYRvjsOHA()
	{
		if (pxlLcguoDAjOnBGqPMLNiDgOONhtA != IntPtr.Zero)
		{
			return pxlLcguoDAjOnBGqPMLNiDgOONhtA;
		}
		UfJcyXYmvESkBrQICXvQyDdSQPSI = new List<IntPtr>();
		uint num = alFfDbNpJHgUxxeBKJqlYaIlUZfg();
		pilfqYAsJMJUNJrkuoZfGTbavosnB obj = EemDbHKeEYwyrhBcUHlrdBwxhQYb;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(obj);
		OKLfNHIUuNAZcVBKuWZsGTbTUXDUA(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(obj);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < UfJcyXYmvESkBrQICXvQyDdSQPSI.Count; i++)
		{
			if (OLnHATFKWYsBKWEwQQzBebdSzimF(UfJcyXYmvESkBrQICXvQyDdSQPSI[i]))
			{
				GZADwRtFTQAIpCWQXLBXWlYufRdi(UfJcyXYmvESkBrQICXvQyDdSQPSI[i], out var num2);
				if (num2 == num)
				{
					pxlLcguoDAjOnBGqPMLNiDgOONhtA = UfJcyXYmvESkBrQICXvQyDdSQPSI[i];
					UfJcyXYmvESkBrQICXvQyDdSQPSI.Clear();
					return pxlLcguoDAjOnBGqPMLNiDgOONhtA;
				}
			}
		}
		return RUDjiDpqTEdAUJfpZNhTSbLhOkRu();
	}
}
