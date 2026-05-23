using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class vEnPceFOuPFgXFAvMlsiSCQDETfo
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class rdQnmXhPJKcvbsVKAPxbXCEsWNB
	{
		public int efFasNHUHYrbMHmoCYzZEYGwdgxK;

		public int ZHfkVvWvSGiLGSLLLKKILWPoudO;

		public int xhYxwFBFpSOtCCtzFvsNqRgQdMg;

		public int sQTDaGAHOWXFpcVQcIMhvAwnyFk;

		public int wEOaIZCYmduardcrcKRDoMaGOXeO;

		public byte IBwJJvSiLGRLTVlhRMwjReZljCC;

		public byte YwNEBrDlANgGrKudqZYZRKjZNaji;

		public byte PFbtEOOjKOSBBnkQmEZpDGvSqOk;

		public byte ZRCoOBrghXiVDAKgGUMURwTNDVXL;

		public byte MThvpRodrscMvHeVVoPWsQmdZrd;

		public byte abXZdtheuvZUQnjUwMkRdGavxBG;

		public byte FhxTvTealORWvBzSmCVtEBCRXfC;

		public byte xJhnaLHKgTVpngmNeRbmgaeMges;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string tkYAYZTjLKgcEaDGdLtWVZnLqNar;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct GDGvINHcXfcCDtfbjBzWernIwfpd
	{
		public int kkHzEoYQjEXkrbMuxSXyQOpemlb;

		public int IcBloLdsxDcMoZjuZteExAuFiSK;

		public int sTbORvwPYkRrSWAfsjTIhAGUTGF;

		public int VVJlyoxKXNhciFXtvDACeKuTOyN;

		public int QqjsxhrAbyLwAgslhcuvdwAoGfa;

		public int uMZdufqmIoRMZunwpMOMQFWLgHM;

		public int juoowNjBdVMHmLGBPLRRzyhTTQr;

		public int EWQWYZcEVRoMFoIBgcBOxSADWHW;

		public int JdpNWGkaRpbErNUcDReLwdfthyW;

		public int vhnHzPCWowIoEQJxriZFXOJzsan;

		public int mMcvZgZDYfqeDqnykqceayDxFEm;

		public char oxQdpwIJRPQOivmrZEchgNeDOXoL;

		public char gjHPynxDtHVrrWzuLpwfJZCXNTG;

		public char NiXnauuEUQFdjXTEAmmmuNwGlir;

		public char kpUQlLQQGQhyqHrVWTzfDPYPFo;

		public byte tEIwhzCxekNnyMXeyTBswymDEnI;

		public byte mOVCRFKAyLNeUQShywkxoahoEqka;

		public byte vuRyOEtmptFgajGQIDNIALVafqjm;

		public byte XlCFklPKSiQUkYfcuPhobifeHQi;

		public byte llhdEdEeUzzNPoGBpulyUkFIRKZB;
	}

	internal enum olPxltWHfZKJAeRMSXqGQRjmceX
	{
		PcUtzkkDpdrFQNeiojMbsnsRxgX = -4,
		abKWiIiyuerGGnLlCVIcIvamwNP = -6,
		LMKDZvcRggzSSuDmGhveIokOEnOl = -8,
		wElswMkcvdFdsenmAhziChgkHlcT = -16,
		OKxJntIKdtbxLiDUZvDsVcotaFP = -20,
		FAaMPbrrBmjhihgywImwaBhcSxWU = -21,
		dEcbuVkkpXJgALbBMDPKdtExXRV = -12
	}

	internal delegate IntPtr rpoBSXhWzVUtmAPpKzdMsKEvkEee(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool HAbkHRPFkjNNilhkhNVOIqFfxBH(IntPtr hwnd, IntPtr lParam);

	private static IntPtr kBhJxALdxxcEFwejpLfeqaTmQiT = IntPtr.Zero;

	private static List<IntPtr> TuxEpxwNKHldwBDKenBEHOdyXDd;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int lyPbnwzpjeBnCKExsUcLEjWyNpx(out uOChmCyZoFmzCauMUTYsOaXHzLy P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ZksJkPTQtmCXojSPYBhkcfGVgJl(out uOChmCyZoFmzCauMUTYsOaXHzLy P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int KZdXpUAqDeRUEEfJqtRhioMmNBE(ref uOChmCyZoFmzCauMUTYsOaXHzLy P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int qhBheYePclQmrmzxpEXvXKLTZde(ref uOChmCyZoFmzCauMUTYsOaXHzLy P_0);

	public static IntPtr lGtbpSctgCOVgjcRZOBtxAHmuAs(HandleRef P_0, olPxltWHfZKJAeRMSXqGQRjmceX P_1)
	{
		if (IntPtr.Size == 4)
		{
			return PzfOltkAAacPtOksSZDasDFOHNZe(P_0, P_1);
		}
		return FRqkIxDJGgfWabxbUGIFllFDYyN(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr mEnFhwGTBYqvsGctcXbjNdnhBnQu();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr PzfOltkAAacPtOksSZDasDFOHNZe(HandleRef P_0, olPxltWHfZKJAeRMSXqGQRjmceX P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr FRqkIxDJGgfWabxbUGIFllFDYyN(HandleRef P_0, olPxltWHfZKJAeRMSXqGQRjmceX P_1);

	public static IntPtr UZNlCVZBmfojHyBnPWSLlVNcwin(HandleRef P_0, olPxltWHfZKJAeRMSXqGQRjmceX P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return xlxadbYXsdfPFApJBZZxGwzMNpdP(P_0, P_1, P_2);
		}
		return EZeuPbvoICdHALQOCGubdrPwftsE(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr tjCBaTDOKYOubxworYYRynpKNji(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr xlxadbYXsdfPFApJBZZxGwzMNpdP(HandleRef P_0, olPxltWHfZKJAeRMSXqGQRjmceX P_1, IntPtr P_2);

	public static bool PPHEDoPWIHGlCUXGgCPhdpEYMYIN(HandleRef P_0, bool P_1)
	{
		return PPHEDoPWIHGlCUXGgCPhdpEYMYIN(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool PPHEDoPWIHGlCUXGgCPhdpEYMYIN(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr EZeuPbvoICdHALQOCGubdrPwftsE(HandleRef P_0, olPxltWHfZKJAeRMSXqGQRjmceX P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr gKHweShcNwODPPxOCPmicsPwsWu(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr ZEXnwpEedeGNopCHQePiAZHqBlvH(string P_0);

	public static IntPtr lGtbpSctgCOVgjcRZOBtxAHmuAs(IntPtr P_0, olPxltWHfZKJAeRMSXqGQRjmceX P_1)
	{
		if (IntPtr.Size == 4)
		{
			return PzfOltkAAacPtOksSZDasDFOHNZe(P_0, P_1);
		}
		return FRqkIxDJGgfWabxbUGIFllFDYyN(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr PzfOltkAAacPtOksSZDasDFOHNZe(IntPtr P_0, olPxltWHfZKJAeRMSXqGQRjmceX P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr FRqkIxDJGgfWabxbUGIFllFDYyN(IntPtr P_0, olPxltWHfZKJAeRMSXqGQRjmceX P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool afmLScYaVVFpbIqZjDcpdvLYAuJF(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr ltqLlotzsNusswonjXgwebYwybY();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint xNdJlwtBPsWNRtbIQMFgTxotbpu();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool jcrGGYlacEjDKJBaHHSebSsTepbM(IntPtr P_0, IntPtr P_1);

	private static bool WyOZYeZDYENKrubkTSiuzpeQBjAG(IntPtr P_0, IntPtr P_1)
	{
		lock (TuxEpxwNKHldwBDKenBEHOdyXDd)
		{
			TuxEpxwNKHldwBDKenBEHOdyXDd.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint REVvNeBDdKIIQBKxKMgQotlvyet(IntPtr P_0, out uint P_1);

	public static IntPtr TVCFgKdOWgSUzFpIsdssfCZqoVc()
	{
		if (kBhJxALdxxcEFwejpLfeqaTmQiT != IntPtr.Zero)
		{
			return kBhJxALdxxcEFwejpLfeqaTmQiT;
		}
		TuxEpxwNKHldwBDKenBEHOdyXDd = new List<IntPtr>();
		uint num = xNdJlwtBPsWNRtbIQMFgTxotbpu();
		HAbkHRPFkjNNilhkhNVOIqFfxBH hAbkHRPFkjNNilhkhNVOIqFfxBH = WyOZYeZDYENKrubkTSiuzpeQBjAG;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(hAbkHRPFkjNNilhkhNVOIqFfxBH);
		jcrGGYlacEjDKJBaHHSebSsTepbM(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(hAbkHRPFkjNNilhkhNVOIqFfxBH);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < TuxEpxwNKHldwBDKenBEHOdyXDd.Count; i++)
		{
			if (afmLScYaVVFpbIqZjDcpdvLYAuJF(TuxEpxwNKHldwBDKenBEHOdyXDd[i]))
			{
				uint num2;
				REVvNeBDdKIIQBKxKMgQotlvyet(TuxEpxwNKHldwBDKenBEHOdyXDd[i], out num2);
				if (num2 == num)
				{
					kBhJxALdxxcEFwejpLfeqaTmQiT = TuxEpxwNKHldwBDKenBEHOdyXDd[i];
					TuxEpxwNKHldwBDKenBEHOdyXDd.Clear();
					return kBhJxALdxxcEFwejpLfeqaTmQiT;
				}
			}
		}
		return ltqLlotzsNusswonjXgwebYwybY();
	}
}
