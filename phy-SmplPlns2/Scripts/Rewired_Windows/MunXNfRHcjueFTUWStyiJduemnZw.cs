using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class MunXNfRHcjueFTUWStyiJduemnZw
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class OHmFaQucvOVHPUtzjpDzvUryXBVf
	{
		public int bsfKiwFHHnrksRpmDUqUjqFuwhJn;

		public int jpxDnmRcivwnPXoUXbTOftRVGTCq;

		public int YoblKnDFxVvUoSZqUktHUzibudMt;

		public int vhwpVaErNmQqAqkStdMWXGpUkOF;

		public int vHKrjUMREDHmdCdamDcEuhCeIRFbA;

		public byte UjxdAXbHMRyfSMKatemAYGnTBpUZA;

		public byte IRRxkGnkEtatbCZehafJkQCUZEhuA;

		public byte oWqAQAGJMxLNXQxmosPBowoCGEMi;

		public byte QjwDEVEnQplFbjoGgjYZtdrCEinLb;

		public byte odgeFitRgUotxOXIsZLYyecdQqOH;

		public byte HnsFhrACLtsHdTAWFNlRUHZsisvG;

		public byte PzLArgeHkpvRSJcHgnRMSOKJnUDCb;

		public byte baJAPtEuxrBXfUjHsIjurvJZbXjA;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string yBFdMuQmHpLWRRMKRliAoXKSoTno;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct dTTUuSEjsktTHZxqlGCPEVdxPLqi
	{
		public int FVqfgRMhhnwpnYRxfLjIiclmezOj;

		public int zYpIkXUeERCJooDFPSMGbdiihEwBA;

		public int aokALdFrKQVMcDoQGkkVfAsanGBzA;

		public int caPzssewkiVDDmsjbcPKmWDPAbVi;

		public int ZynbXwDDuqypwNicAcKWWWHtTlcfA;

		public int tloEFpFIRWFwyLbcPgkfmaqnLqaKA;

		public int cwURAxtLMluAZIDNmnrLhGEiiRks;

		public int GlmqKlDOevmiLirzdHSjmiaZofZu;

		public int nKNbBNKWuiESyltuyfCJkBbRlhWI;

		public int OcBxWOpuySfafhSlHHQOyYSoXiTL;

		public int ojTbEtLyyVBSvuBNpRCmRQeXHkuH;

		public char lnlWuycIdakYHTfchbfzjSkHFnkcA;

		public char BOaCEgjkzMVaHiQYsQkGRLufESsLA;

		public char tQcFCTwwhlCLmPErgqrYwkRZkCoy;

		public char IEnaHKYhUypxfbcrAtEnAyYvNGsf;

		public byte vTeAEYTmdRassGsnGJjRXekWWqSH;

		public byte zJRmGlIrxEbXDgykkZpCwDZYVzGJ;

		public byte AbhlFPGHozhCHFQiOFzWGXqhVOoJB;

		public byte sBtixHgVxNCnmVvNvbfLRuSnPkMQ;

		public byte QRxaJeKYjeaVxCsKCzjksTWTTcaSA;
	}

	internal enum jVAoMBoFzyNugseuvwVmUJPpFxfA
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr oRuFCDnFCSHWAVwnGBwifnUDJiwIA(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool KMtoVoPdRgfIuwnXDTQmrDAgrXOr(IntPtr hwnd, IntPtr lParam);

	private static IntPtr AadwHCNURkEDWNpZkQDGlVFPypHi = IntPtr.Zero;

	private static List<IntPtr> fNTWghzYryEsmwbhlQwNMCSBFrcN;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int DciQIueVTvTVJAIyQdaLDYUseacu(out RdMIVTawyrwfKNvpWLAeqXtcqzKJA P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int dAYRAIJKLBGJDCrFOpIVuEdWwjSY(out RdMIVTawyrwfKNvpWLAeqXtcqzKJA P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int allMcVvcOXaqoKPNCrCoiogzaLurA(ref RdMIVTawyrwfKNvpWLAeqXtcqzKJA P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int jzgAboAyHKeilPqUEEEJeLBGglcA(ref RdMIVTawyrwfKNvpWLAeqXtcqzKJA P_0);

	public static IntPtr RsSZDLEiYhgrscEoqhZzfKuNzckU(HandleRef P_0, jVAoMBoFzyNugseuvwVmUJPpFxfA P_1)
	{
		if (IntPtr.Size == 4)
		{
			return UKfLyPUcYBmqyGqaeMMCeaUUIOwB(P_0, P_1);
		}
		return ftmOnJpcYKtVHfQuaDttFJDwlTtdA(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr sbLpBYIwLLeqKBNuDhswQdAoXFIK();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr UKfLyPUcYBmqyGqaeMMCeaUUIOwB(HandleRef P_0, jVAoMBoFzyNugseuvwVmUJPpFxfA P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr ftmOnJpcYKtVHfQuaDttFJDwlTtdA(HandleRef P_0, jVAoMBoFzyNugseuvwVmUJPpFxfA P_1);

	public static IntPtr JRbYQpNiryIVjkHfHsoAKrROVdLf(HandleRef P_0, jVAoMBoFzyNugseuvwVmUJPpFxfA P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return JixXiqwxpSkjqLmSRcOTCatlMsgcb(P_0, P_1, P_2);
		}
		return BjqzDIOegAuJbLbtRacwBnJNrhElA(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr gtdOvxkktyaYpnDtkONNOxpJVzQs(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr JixXiqwxpSkjqLmSRcOTCatlMsgcb(HandleRef P_0, jVAoMBoFzyNugseuvwVmUJPpFxfA P_1, IntPtr P_2);

	public static bool TgwzAXUvbWgbLDBYfZdJtNEthlxeA(HandleRef P_0, bool P_1)
	{
		return LHFDkzqEOcdsvfSTRRcOMuZZGIqO(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool LHFDkzqEOcdsvfSTRRcOMuZZGIqO(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr BjqzDIOegAuJbLbtRacwBnJNrhElA(HandleRef P_0, jVAoMBoFzyNugseuvwVmUJPpFxfA P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr kSAUGLoOXKJJrPuYquMrmlEdGZyI(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr TzeMdTIYVDfgseMkEtqUuDXRYPzQ(string P_0);

	public static IntPtr bmNIBpJNlzojQttATVAxfcuQofDx(IntPtr P_0, jVAoMBoFzyNugseuvwVmUJPpFxfA P_1)
	{
		if (IntPtr.Size == 4)
		{
			return eJOCbVkgaiuFLekpucrFcNkkrJQG(P_0, P_1);
		}
		return haqAeVCVJvUBeAtbApBpElXvNynq(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr eJOCbVkgaiuFLekpucrFcNkkrJQG(IntPtr P_0, jVAoMBoFzyNugseuvwVmUJPpFxfA P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr haqAeVCVJvUBeAtbApBpElXvNynq(IntPtr P_0, jVAoMBoFzyNugseuvwVmUJPpFxfA P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool rJbsNbcZQghyvLNTnPNMWGGPhCMGA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr sTFopAQVmfCnPKKeNoEHuaqsPveA();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint ZTNxjHuJDriuUcnutUYecLfehzJs();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool ppTVxxhaczHWBUetZAMhtaOSSmzy(IntPtr P_0, IntPtr P_1);

	private static bool ftwhBVlHsgfyLDwinKAcpPgskOgab(IntPtr P_0, IntPtr P_1)
	{
		lock (fNTWghzYryEsmwbhlQwNMCSBFrcN)
		{
			fNTWghzYryEsmwbhlQwNMCSBFrcN.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint lvSwRhETTkWTSHFpeBIKghbzeKTjA(IntPtr P_0, out uint P_1);

	public static IntPtr VEuqgyuYZgzfZMhJqtppuDiqZqul()
	{
		if (AadwHCNURkEDWNpZkQDGlVFPypHi != IntPtr.Zero)
		{
			return AadwHCNURkEDWNpZkQDGlVFPypHi;
		}
		fNTWghzYryEsmwbhlQwNMCSBFrcN = new List<IntPtr>();
		uint num = ZTNxjHuJDriuUcnutUYecLfehzJs();
		KMtoVoPdRgfIuwnXDTQmrDAgrXOr kMtoVoPdRgfIuwnXDTQmrDAgrXOr = ftwhBVlHsgfyLDwinKAcpPgskOgab;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(kMtoVoPdRgfIuwnXDTQmrDAgrXOr);
		ppTVxxhaczHWBUetZAMhtaOSSmzy(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(kMtoVoPdRgfIuwnXDTQmrDAgrXOr);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < fNTWghzYryEsmwbhlQwNMCSBFrcN.Count; i++)
		{
			if (rJbsNbcZQghyvLNTnPNMWGGPhCMGA(fNTWghzYryEsmwbhlQwNMCSBFrcN[i]))
			{
				lvSwRhETTkWTSHFpeBIKghbzeKTjA(fNTWghzYryEsmwbhlQwNMCSBFrcN[i], out var num2);
				if (num2 == num)
				{
					AadwHCNURkEDWNpZkQDGlVFPypHi = fNTWghzYryEsmwbhlQwNMCSBFrcN[i];
					fNTWghzYryEsmwbhlQwNMCSBFrcN.Clear();
					return AadwHCNURkEDWNpZkQDGlVFPypHi;
				}
			}
		}
		return sTFopAQVmfCnPKKeNoEHuaqsPveA();
	}
}
