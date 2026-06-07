using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class TCCMweqAdjuaBiYJALRzkIxXePae
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class VaPIAFfXHCzNBwfnbmUgJQwDLCywA
	{
		public int wEKbIhawfxcJicxeBJEVIetRHkuo;

		public int izGgPtePKvhmNabEVoKPGElsEHvJ;

		public int XAOdJckgPDIAyDdeUbUMBrYECslXB;

		public int mWMVdMHYFHDamnPaIxYRfoaWbNtQ;

		public int iYfKoNnnqRJTvfykwJiZFduBKael;

		public byte BuQZMAkKwXliMdRwbVjPvSTsqfpl;

		public byte PaitJnOazzrhMwqIzAQolgCpFARb;

		public byte tPNdPVDdapWPJhfesvNCfFYjNVhFA;

		public byte XTHRmAIfqtFinNRWdhaEUpXzhgSi;

		public byte zQNSqzOlGYojbnCGsDoXDFOApRvq;

		public byte KgVeOgCzzzDyxXmAPjeAYpbLXnOeA;

		public byte UJeuqpqGEfPLYHhTwmfVhAouEFqv;

		public byte slJyPGvmObZVBjcrDqhcUqPcCyuV;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string poaLFxfLhriMDegSNhFXxVsbyKGLA;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct wipHLpMegfjRcqwpdEMfNCSOAFh
	{
		public int IOBaoCGtVfCyjAnDFpoTjBDIFpFhd;

		public int mPQrBGzZgDhRkTbZLShHKQCNILTQ;

		public int jwHOesCiVKKYgHMWODQubKbXNDad;

		public int tooswjZTIeSPTPyhjaFVPabcYHcO;

		public int UfCUNziiOwvIeFQmGdMVlDdQIqBR;

		public int mSREvitzLOugsUqKPXewPUcMpKPd;

		public int fLhjSiEDgdoqBztFeNKUSJeBEKNFA;

		public int DyDNqqqBEfjaDNOnpHbqPZYccakV;

		public int czghiUxiAkIOuYxjywMSLHBiNudR;

		public int XkyNLjECyWyrVIhhLwBPPiAPScBB;

		public int twoPkkcDMRsLbNvXlmiluRMooSXv;

		public char qXOnrXZBfeUfNkmxnGRwWGygweRE;

		public char UXNLSlFgHEaIRzdIwEPLaVMWJBXQ;

		public char ecPXvMZtPpRXkwrvkIFVNWbcJqNK;

		public char BYQEdLefeenhjcUlCKCkMlcfOCiHe;

		public byte yMLwDLocMBVoylnmYGaCFwSlBJvbb;

		public byte wwqNwuhyRAzDHDAasEqLNwrxwCrn;

		public byte NkGOtKfSChSuXtFyAUBFwSCwVxPH;

		public byte dPWatAFMZTnKisuDrSVCaciWvDhi;

		public byte XcSIqnpHUiLilVfYMCfjqGysbSTg;
	}

	internal enum odgYzHPEzzfHmPYacOTQtrxyqCUR
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr pBXXuYYkgGQOIadwSHfjQJgalLHG(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool PZUQfpoYvocAyTPLPTpbSnkFbQrEA(IntPtr hwnd, IntPtr lParam);

	private static IntPtr TRIchPGmtcZUQlsLaurZrObyKjcjb = IntPtr.Zero;

	private static List<IntPtr> kywvksSVWuYyjDrFxzdYtibwcfXE;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int MNXTLjHIbtjXDrsyYDPIcYkRfwZI(out YjzMyIFSchpLWIrAOzRrsLVNghQc P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int oJhHiPiexVBRZWFHUKhOzqVbmtrl(out YjzMyIFSchpLWIrAOzRrsLVNghQc P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int bvWbVEWyuJqpgiSBUbsdLuEEMtLH(ref YjzMyIFSchpLWIrAOzRrsLVNghQc P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int cyUWVyZYSBjmmKsqUJzHedlykfGr(ref YjzMyIFSchpLWIrAOzRrsLVNghQc P_0);

	public static IntPtr GEhgMQhgkzMjwDhoicewHMAwlfNiA(HandleRef P_0, odgYzHPEzzfHmPYacOTQtrxyqCUR P_1)
	{
		if (IntPtr.Size == 4)
		{
			return DbIaOjejWPMaaQhuoRvZTVOnGZlz(P_0, P_1);
		}
		return qcFqjUOBsURXJCEswhCyccvXMYQP(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr trgEaBtgzVZsYiheNCAdxHmRhYfFA();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr DbIaOjejWPMaaQhuoRvZTVOnGZlz(HandleRef P_0, odgYzHPEzzfHmPYacOTQtrxyqCUR P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr qcFqjUOBsURXJCEswhCyccvXMYQP(HandleRef P_0, odgYzHPEzzfHmPYacOTQtrxyqCUR P_1);

	public static IntPtr ChCdRiBgTsbOvjJzGLJBzvRelCeOB(HandleRef P_0, odgYzHPEzzfHmPYacOTQtrxyqCUR P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return CUZfbAHJEElqjuYADhOVFFCIjRLB(P_0, P_1, P_2);
		}
		return ITwUHBtWCKZbFmlTSHbvIbyUebaA(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr tcEqMiHEBkIGjCNbqmgMplZkGudT(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr CUZfbAHJEElqjuYADhOVFFCIjRLB(HandleRef P_0, odgYzHPEzzfHmPYacOTQtrxyqCUR P_1, IntPtr P_2);

	public static bool AHJTSdvBYMfVuiCdjWQBAwfCiEQb(HandleRef P_0, bool P_1)
	{
		return YymOEgRkekgaxQhJHjTJevfufZBYA(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool YymOEgRkekgaxQhJHjTJevfufZBYA(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr ITwUHBtWCKZbFmlTSHbvIbyUebaA(HandleRef P_0, odgYzHPEzzfHmPYacOTQtrxyqCUR P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr pFbIRWBQzQdRfapMoVHqBaiQrHJM(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr EKLBwGlBxDoymPXyKGZTXbdgMSMP(string P_0);

	public static IntPtr mveKgocOBrxACAbIBhtaMsCbOaoy(IntPtr P_0, odgYzHPEzzfHmPYacOTQtrxyqCUR P_1)
	{
		if (IntPtr.Size == 4)
		{
			return jClWDKDWIotuTNOdixZURiWLotbK(P_0, P_1);
		}
		return woXPpUlmfpzJwhopGMsgbwbKNvAp(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr jClWDKDWIotuTNOdixZURiWLotbK(IntPtr P_0, odgYzHPEzzfHmPYacOTQtrxyqCUR P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr woXPpUlmfpzJwhopGMsgbwbKNvAp(IntPtr P_0, odgYzHPEzzfHmPYacOTQtrxyqCUR P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool ouOUecBGuoaqzkqBlngZdZoagBjV(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr bcoyjaxipalOzdbUmMZZDfUHrMQt();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint ECmuUIPfAruAOZokbnYtVFxVaCgE();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool scstWeEoOfVVThyfTdtuYEebHhCJA(IntPtr P_0, IntPtr P_1);

	private static bool agXIZGSgQeevNFCcbpLlujILRzFG(IntPtr P_0, IntPtr P_1)
	{
		lock (kywvksSVWuYyjDrFxzdYtibwcfXE)
		{
			kywvksSVWuYyjDrFxzdYtibwcfXE.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint qxSjalLdsSOOkdvcrTBVDNOdJoy(IntPtr P_0, out uint P_1);

	public static IntPtr IVNPpdPRnkVjJdcFgrQgVPOZGQPIA()
	{
		if (TRIchPGmtcZUQlsLaurZrObyKjcjb != IntPtr.Zero)
		{
			return TRIchPGmtcZUQlsLaurZrObyKjcjb;
		}
		kywvksSVWuYyjDrFxzdYtibwcfXE = new List<IntPtr>();
		uint num = ECmuUIPfAruAOZokbnYtVFxVaCgE();
		PZUQfpoYvocAyTPLPTpbSnkFbQrEA pZUQfpoYvocAyTPLPTpbSnkFbQrEA = agXIZGSgQeevNFCcbpLlujILRzFG;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(pZUQfpoYvocAyTPLPTpbSnkFbQrEA);
		scstWeEoOfVVThyfTdtuYEebHhCJA(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(pZUQfpoYvocAyTPLPTpbSnkFbQrEA);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < kywvksSVWuYyjDrFxzdYtibwcfXE.Count; i++)
		{
			if (ouOUecBGuoaqzkqBlngZdZoagBjV(kywvksSVWuYyjDrFxzdYtibwcfXE[i]))
			{
				qxSjalLdsSOOkdvcrTBVDNOdJoy(kywvksSVWuYyjDrFxzdYtibwcfXE[i], out var num2);
				if (num2 == num)
				{
					TRIchPGmtcZUQlsLaurZrObyKjcjb = kywvksSVWuYyjDrFxzdYtibwcfXE[i];
					kywvksSVWuYyjDrFxzdYtibwcfXE.Clear();
					return TRIchPGmtcZUQlsLaurZrObyKjcjb;
				}
			}
		}
		return bcoyjaxipalOzdbUmMZZDfUHrMQt();
	}
}
