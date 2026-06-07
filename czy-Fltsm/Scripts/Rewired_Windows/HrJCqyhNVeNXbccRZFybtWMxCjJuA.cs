using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class HrJCqyhNVeNXbccRZFybtWMxCjJuA
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class LkQuCZaKMTwbrhokobvguiLhVIXG
	{
		public int cpBPLtPjmccDMdizYtyZletnhbZbb;

		public int gtPNSbNfRkzEfsiHWfVNDinAMZWjA;

		public int JRFgjiNlWISbAtWnLMfYJJEqlrOM;

		public int yaHPQMckMADfAzvzJlbLRWoqAZIj;

		public int wLcBMBIQtGxmJrGbfFwXdfsrGXXWA;

		public byte ZLBYfWBVfIUAubLpsywHFlDQrzIO;

		public byte ZoncHJDffkZWZRqjiBjUoTeBXGtjA;

		public byte lEUzXYMjeWcdmnhvZqEDzMVhQOHA;

		public byte NLAznSfOxsDqTBxTifAAieVNFwnZA;

		public byte hBWqwthORRSBPjkPrfJNcvOaOUKWA;

		public byte CIAmyOMyCuJXbeFUANYFNtOlqjDB;

		public byte EwnyAhBoPiaasHDGbOHFDtaWKQFy;

		public byte awKnCCEABekNpbFoACOiaADSjFHl;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dDpvddAmsorvxmMVAmjLdeqVKJhR;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct eQpZNNExLhVSdmljcsCCFkByWVcN
	{
		public int GGkAEMEMcFZTQbGkKVHblLIruCmc;

		public int ivRpzSKSxMsQSPQASMiDgnSjWAij;

		public int vKMygehtpFajYBxJLjyCNkKpQrLK;

		public int nwtQSveoTpsotZmagcDNbytOWgLI;

		public int IBPYcxBKZvFYQPKnLPERBXrkCzuU;

		public int cNYsmuCluRFRQIUnEWqefxKoocqSA;

		public int vukCsajmtoPTxhfQzVpUcfsxVDwx;

		public int JhUgjgNuTwiBbRmwoWOirUKKKvTX;

		public int qidCCIOLJjIzIcWgvavOrfBCPpMfb;

		public int ZarjnZjzXLMPHUKaMpDZGrwjvNDHb;

		public int fgvMtoZOLYiMPTxQaZSlOPCIHPuL;

		public char kRDGLjhqOpvftayniQzyFiQGAvuJA;

		public char GREXfjaJQLTXlrCVrnaLQaYeNWaq;

		public char wvUpfAszQqRqAypexovNxOlEoQqR;

		public char JhRNkZCnYrMLFSqJJtEoHqPeBbuG;

		public byte ixCjsZFTzOZAgllFXDEIGIDFWPYe;

		public byte agtJnuIpGPUElDmrjiDRxndZcNIbA;

		public byte REFNiIQxNsrUnrDdLKbHUIMClAwR;

		public byte paJUCIoZGMuEUanIwCjKAAieQgSlA;

		public byte PUBVizWOKfQcBVAFPgxdWTeYfqqKA;
	}

	internal enum qpdHeTcaosqLQVOrrgFYXYpOTrpf
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr nVMPxQppzHxvcmxkByPzgOsKuOuj(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool NPXPyrBWkhdfEZVCGGVhiacxPgCm(IntPtr hwnd, IntPtr lParam);

	private static IntPtr RBNTHlXaYhvkcqUDlShXmzvYoaHe = IntPtr.Zero;

	private static List<IntPtr> gRlGXygnEhSnENNeioAOHZeeOtmzb;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int ODSefheJimjenkxvTAiWDKcexckgc(out EFwwcQyBLmDMcEWuPBMzgYNvKnGAb P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int aWiFfPLukIaqnERIROCQLjHFHlIr(out EFwwcQyBLmDMcEWuPBMzgYNvKnGAb P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int hhNkXItQnUgBCueEHmKrzlOgJFoW(ref EFwwcQyBLmDMcEWuPBMzgYNvKnGAb P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int uePlliqkBWLlMKGjBDKFEKzYBmnN(ref EFwwcQyBLmDMcEWuPBMzgYNvKnGAb P_0);

	public static IntPtr SpoAiOUczyjYKHMnhPxgsZUWykkI(HandleRef P_0, qpdHeTcaosqLQVOrrgFYXYpOTrpf P_1)
	{
		if (IntPtr.Size == 4)
		{
			return POXcRzUiPIVZGrBblCIFtlIDOzQF(P_0, P_1);
		}
		return kpUESElfvRvcdScfpsrkSKjvGZxm(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr ffjMMRYaqKCTwgfjYIvlHFudmRAWA();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr POXcRzUiPIVZGrBblCIFtlIDOzQF(HandleRef P_0, qpdHeTcaosqLQVOrrgFYXYpOTrpf P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr kpUESElfvRvcdScfpsrkSKjvGZxm(HandleRef P_0, qpdHeTcaosqLQVOrrgFYXYpOTrpf P_1);

	public static IntPtr WMJfabNAYdjFKHoWQyDLTDFFTTtb(HandleRef P_0, qpdHeTcaosqLQVOrrgFYXYpOTrpf P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return GmVaDnjwIVxOQAaTEjGKVjDiyasbA(P_0, P_1, P_2);
		}
		return KmOBcJHGLZYyNpiuImiriifWVfAcb(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr jpLEMemVKtwfJWagbhBSaNBQYrKTA(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr GmVaDnjwIVxOQAaTEjGKVjDiyasbA(HandleRef P_0, qpdHeTcaosqLQVOrrgFYXYpOTrpf P_1, IntPtr P_2);

	public static bool MkUBfIhGYLMShdmLiAtSagkemntrB(HandleRef P_0, bool P_1)
	{
		return YDhoYgsuntHnPSoGEeEZLuhIOseJ(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool YDhoYgsuntHnPSoGEeEZLuhIOseJ(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr KmOBcJHGLZYyNpiuImiriifWVfAcb(HandleRef P_0, qpdHeTcaosqLQVOrrgFYXYpOTrpf P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr jWsAlMcHaBAqRcuTjiomPpmksGcoA(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr UvGkEWKucOPNOVVrLNcRtIpWqZvJ(string P_0);

	public static IntPtr iJjNseFQIscAkeAJQeIodgAATzDlc(IntPtr P_0, qpdHeTcaosqLQVOrrgFYXYpOTrpf P_1)
	{
		if (IntPtr.Size == 4)
		{
			return jhknyAeRyzZSdBgfneCQvEKvfaKk(P_0, P_1);
		}
		return iwUXcIWYwqiNMzgyRJRgZTrsyZdI(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr jhknyAeRyzZSdBgfneCQvEKvfaKk(IntPtr P_0, qpdHeTcaosqLQVOrrgFYXYpOTrpf P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr iwUXcIWYwqiNMzgyRJRgZTrsyZdI(IntPtr P_0, qpdHeTcaosqLQVOrrgFYXYpOTrpf P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool amLFscevhflTZydIeTTZFEaMOUQX(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr fQfTDmAfyfvFNhGLpgQFdRMvJjlG();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint UrjcIMeioiKXiZBnqpGdejFblfVpc();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool usxmXglnZwcDrxYoWUlesCwHCmtT(IntPtr P_0, IntPtr P_1);

	private static bool mQSmeGvxDvBulDBnkhOpOkOvGWeAA(IntPtr P_0, IntPtr P_1)
	{
		lock (gRlGXygnEhSnENNeioAOHZeeOtmzb)
		{
			gRlGXygnEhSnENNeioAOHZeeOtmzb.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint gSobgyhAybprgDuulwITBlDiyCDfB(IntPtr P_0, out uint P_1);

	public static IntPtr CBWJSpyLepGPtneSpinydICtABgGA()
	{
		if (RBNTHlXaYhvkcqUDlShXmzvYoaHe != IntPtr.Zero)
		{
			return RBNTHlXaYhvkcqUDlShXmzvYoaHe;
		}
		gRlGXygnEhSnENNeioAOHZeeOtmzb = new List<IntPtr>();
		uint num = UrjcIMeioiKXiZBnqpGdejFblfVpc();
		NPXPyrBWkhdfEZVCGGVhiacxPgCm nPXPyrBWkhdfEZVCGGVhiacxPgCm = mQSmeGvxDvBulDBnkhOpOkOvGWeAA;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(nPXPyrBWkhdfEZVCGGVhiacxPgCm);
		usxmXglnZwcDrxYoWUlesCwHCmtT(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(nPXPyrBWkhdfEZVCGGVhiacxPgCm);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < gRlGXygnEhSnENNeioAOHZeeOtmzb.Count; i++)
		{
			if (amLFscevhflTZydIeTTZFEaMOUQX(gRlGXygnEhSnENNeioAOHZeeOtmzb[i]))
			{
				gSobgyhAybprgDuulwITBlDiyCDfB(gRlGXygnEhSnENNeioAOHZeeOtmzb[i], out var num2);
				if (num2 == num)
				{
					RBNTHlXaYhvkcqUDlShXmzvYoaHe = gRlGXygnEhSnENNeioAOHZeeOtmzb[i];
					gRlGXygnEhSnENNeioAOHZeeOtmzb.Clear();
					return RBNTHlXaYhvkcqUDlShXmzvYoaHe;
				}
			}
		}
		return fQfTDmAfyfvFNhGLpgQFdRMvJjlG();
	}
}
