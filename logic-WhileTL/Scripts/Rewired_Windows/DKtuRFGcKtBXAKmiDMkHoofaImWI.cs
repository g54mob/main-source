using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

internal class DKtuRFGcKtBXAKmiDMkHoofaImWI
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class ussIMhHIynBRJrdELsPaBFNNRhgw
	{
		public int GfRqGwZLfkYIZazbVTmqsUvNtfGJ;

		public int nviDKJVskpmXpKCKUyvepkRKixlA;

		public int VpQwXuOaDmCCBGlcWGkyGeLhTIPL;

		public int KlHLXrPkgyUquivNpKcOXiXSRzZq;

		public int EFAYkeBOYVTjiumanvBqgnRzGNTg;

		public byte mumNMuPbyhmCTNyETYCphwUPRnkA;

		public byte oxTPIAQmWfpuzkmmlyaCcMsinEmb;

		public byte rXnCMhRSegwhAhITrDpOjlYlnLTQ;

		public byte pJSUnigXonwQCIlYBafpMitiExkD;

		public byte mpbpfinPBMAFeEBCWMYlWCDQmWYFA;

		public byte IJPviWcpEBfLTzhXbSteTEJGKDfk;

		public byte jEliLodzZyzqyHNLtxoCIopuAKrnA;

		public byte JXxItTYkanrmqmPjpyjMUKPnQdXQ;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string RuKaMmMSxwrLRPYTycJzbJAcfIJq;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct wUFRhgXGYeSqYSaOmmpkdZwhaMfh
	{
		public int WSXWdFDkLyoswtfviieZciGNRfKS;

		public int iORYvmeTJhoHnNraORPrHKNcafbz;

		public int UdNIGarfnkPoeGRHcSVoTHbdAKdBA;

		public int hURxjVkCgnQOzXDIsxlbCfNaUBeP;

		public int yYvvuYaNAYJcHkeBaCmSXdmNoDXd;

		public int QfNeqIApsEqnCbefDoehwibmwCbWB;

		public int NHewRieHKvcGrVQjUpzmJGreNeKd;

		public int euYXUejhtrDVUyrUtxlhXWfoQKhS;

		public int dpzfPhifrTihaWRtMlIugQKGShngc;

		public int DarvRmPWtSTLLAiSmzdgbkkMfrUg;

		public int QISIdcIqvitZbeEytBOLfGJKQSlFA;

		public char KHAxJJKflnhnruBcEXCCdGXxCKVhA;

		public char SZXqZKqvbjmgiSiuIwPGzkcaNMtO;

		public char dpNTjBhkmsjUkXQBVxCVIIZpFmGq;

		public char QXpHEIYbagsrfiWqGcuMVRqzaWXv;

		public byte RLUdZYLjSGWLbSfljpcFOyTaatlf;

		public byte YdJDHcKNSrsHXWOytDUOeAQbVzFCc;

		public byte PwDCzjiNsFNDvIGDPtOzzVkSfSQh;

		public byte tDWNNIQmeMPbnCJzpVzZTDGVDSHU;

		public byte LAleSUfesLEiMaSYuQFZVOgtmVuPA;
	}

	internal enum iULbZudjvvimtxzAlbKaQpKNQueLA
	{
		WndProc = -4,
		HInstance = -6,
		HwndParent = -8,
		Style = -16,
		ExtendedStyle = -20,
		UserData = -21,
		Id = -12
	}

	internal delegate IntPtr aQTBvNrOlHEqqhEKmjnDAYQhnqbBc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	private delegate bool NixGVGWlnqDlzdKdGeiHIWNqJwFTA(IntPtr hwnd, IntPtr lParam);

	private static IntPtr UZrpHbOeJXmTKqlpektZUmPTDHyP = IntPtr.Zero;

	private static List<IntPtr> vzjlCvhcLjAjOPRIlffrjGpVIUKB;

	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int DVDfzMsIVCLqmKUNfxaRyGSZpMWy(out KSIgbzdSCfIFBsXlRuHToyViELZc P_0, IntPtr P_1, int P_2, int P_3, int P_4);

	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int dagAZsbSVAPxhnIKFHdNaKxkVCIEA(out KSIgbzdSCfIFBsXlRuHToyViELZc P_0, IntPtr P_1, int P_2, int P_3);

	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int qKnlgxZolCnrHYbOpztOWUtFOQjl(ref KSIgbzdSCfIFBsXlRuHToyViELZc P_0);

	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	[SuppressUnmanagedCodeSecurity]
	public static extern int KrNcqhAjCHJXmdAasVjCvvqukwNU(ref KSIgbzdSCfIFBsXlRuHToyViELZc P_0);

	public static IntPtr RRpaxjhmOuyozjnUYCvOBsgPZsHm(HandleRef P_0, iULbZudjvvimtxzAlbKaQpKNQueLA P_1)
	{
		if (IntPtr.Size == 4)
		{
			return ftnfWOdtkWMgqhMpLLfTuIutVGkOA(P_0, P_1);
		}
		return taeYGeCsbCdnWpurDeoFDeumjiDB(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr EuzvGHEilgAQvqNejqPULzYSeVvk();

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr ftnfWOdtkWMgqhMpLLfTuIutVGkOA(HandleRef P_0, iULbZudjvvimtxzAlbKaQpKNQueLA P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr taeYGeCsbCdnWpurDeoFDeumjiDB(HandleRef P_0, iULbZudjvvimtxzAlbKaQpKNQueLA P_1);

	public static IntPtr iuBfpjKtdDmHquXCKKybLgqZrfVt(HandleRef P_0, iULbZudjvvimtxzAlbKaQpKNQueLA P_1, IntPtr P_2)
	{
		if (IntPtr.Size == 4)
		{
			return DTjnxSXgGXgwQjXOSbrOUuExmwQr(P_0, P_1, P_2);
		}
		return wQiVAMugseAaLJuTXTCOBOcZTiHO(P_0, P_1, P_2);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr PVOAwsRaieHBiflfswkqRIKfiiBSA(HandleRef P_0, IntPtr P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr DTjnxSXgGXgwQjXOSbrOUuExmwQr(HandleRef P_0, iULbZudjvvimtxzAlbKaQpKNQueLA P_1, IntPtr P_2);

	public static bool nCXRsLWIczkSLCbHhQlEZfplvLdw(HandleRef P_0, bool P_1)
	{
		return nCXRsLWIczkSLCbHhQlEZfplvLdw(P_0, P_1 ? 1 : 0);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool nCXRsLWIczkSLCbHhQlEZfplvLdw(HandleRef P_0, int P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr wQiVAMugseAaLJuTXTCOBOcZTiHO(HandleRef P_0, iULbZudjvvimtxzAlbKaQpKNQueLA P_1, IntPtr P_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr EZTqBnkzbQyCIRRRBSABASmBtlVj(IntPtr P_0, IntPtr P_1, int P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr fnNgpKIPJGqolvpYTLtNMveNFeOqA(string P_0);

	public static IntPtr RRpaxjhmOuyozjnUYCvOBsgPZsHm(IntPtr P_0, iULbZudjvvimtxzAlbKaQpKNQueLA P_1)
	{
		if (IntPtr.Size == 4)
		{
			return ftnfWOdtkWMgqhMpLLfTuIutVGkOA(P_0, P_1);
		}
		return taeYGeCsbCdnWpurDeoFDeumjiDB(P_0, P_1);
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr ftnfWOdtkWMgqhMpLLfTuIutVGkOA(IntPtr P_0, iULbZudjvvimtxzAlbKaQpKNQueLA P_1);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr taeYGeCsbCdnWpurDeoFDeumjiDB(IntPtr P_0, iULbZudjvvimtxzAlbKaQpKNQueLA P_1);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool KncfVZCHlnVGaGAWkdKMOFojVdkmA(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr DCadOTokGhHDbeZucONDYkhNgovl();

	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint BBxNJBcTdGcpSxpDTVkTjLJYNyRR();

	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool TinvKjqGKwSiJPjdWHcDEcXyZkKjA(IntPtr P_0, IntPtr P_1);

	private static bool uaYbAHUGawxfggNlSGOVZlHhhajFA(IntPtr P_0, IntPtr P_1)
	{
		lock (vzjlCvhcLjAjOPRIlffrjGpVIUKB)
		{
			vzjlCvhcLjAjOPRIlffrjGpVIUKB.Add(P_0);
		}
		return true;
	}

	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint lLHZWFIPNslnJGUcHIilCmMOhoOI(IntPtr P_0, out uint P_1);

	public static IntPtr vXOctowsgMjuwZXcfPERVmiXpeTg()
	{
		if (UZrpHbOeJXmTKqlpektZUmPTDHyP != IntPtr.Zero)
		{
			return UZrpHbOeJXmTKqlpektZUmPTDHyP;
		}
		vzjlCvhcLjAjOPRIlffrjGpVIUKB = new List<IntPtr>();
		uint num = BBxNJBcTdGcpSxpDTVkTjLJYNyRR();
		NixGVGWlnqDlzdKdGeiHIWNqJwFTA nixGVGWlnqDlzdKdGeiHIWNqJwFTA = uaYbAHUGawxfggNlSGOVZlHhhajFA;
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate((Delegate)nixGVGWlnqDlzdKdGeiHIWNqJwFTA);
		TinvKjqGKwSiJPjdWHcDEcXyZkKjA(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(nixGVGWlnqDlzdKdGeiHIWNqJwFTA);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < vzjlCvhcLjAjOPRIlffrjGpVIUKB.Count; i++)
		{
			if (KncfVZCHlnVGaGAWkdKMOFojVdkmA(vzjlCvhcLjAjOPRIlffrjGpVIUKB[i]))
			{
				lLHZWFIPNslnJGUcHIilCmMOhoOI(vzjlCvhcLjAjOPRIlffrjGpVIUKB[i], out var num2);
				if (num2 == num)
				{
					UZrpHbOeJXmTKqlpektZUmPTDHyP = vzjlCvhcLjAjOPRIlffrjGpVIUKB[i];
					vzjlCvhcLjAjOPRIlffrjGpVIUKB.Clear();
					return UZrpHbOeJXmTKqlpektZUmPTDHyP;
				}
			}
		}
		return DCadOTokGhHDbeZucONDYkhNgovl();
	}
}
