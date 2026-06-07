using System;
using System.Runtime.InteropServices;
using System.Security;

internal class jltqidpcseDngtzbGSRBkcseLdeY
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int QjOzkXqjhGbQYmoXYHNKyzSkQoRF(int arg0, void* arg1);

	private static bool ZzVGpaAgXchgKeSSJRxNxiTXLAoGA;

	private static vptKaDMnFSuEIXNdBaSgiToTnjpHb OoBmsnQpKPGdakuAlEoBFQmUhWmZA;

	private static string muHqcrnkDksslRMiBiEikdXFuWcS;

	private static IntPtr dsWJgFUiSpyfyCsdrhYnrkxqArdr;

	private static QjOzkXqjhGbQYmoXYHNKyzSkQoRF CapkzboKPLCbzCjaUxTWKsXZOaPm;

	private static urijYWHRYDjHpUIBTAkzPvMbdjsX NZXSTDglmYRvSNAXFSwLOlKDPxyC;

	public static bool ViwoQVBqNLSHojKtWXDcHnONWejG => ZzVGpaAgXchgKeSSJRxNxiTXLAoGA;

	public static vptKaDMnFSuEIXNdBaSgiToTnjpHb BMtbPxEmstqRrlNtJAiRHdmhNphqA
	{
		get
		{
			return OoBmsnQpKPGdakuAlEoBFQmUhWmZA;
		}
		set
		{
			OoBmsnQpKPGdakuAlEoBFQmUhWmZA = ooBmsnQpKPGdakuAlEoBFQmUhWmZA;
		}
	}

	public static string nXbqHITzWgrOObuHuwlnniThcIFCA => muHqcrnkDksslRMiBiEikdXFuWcS;

	public static QjOzkXqjhGbQYmoXYHNKyzSkQoRF QgITUziuJMABpwIsqnYDteYIlETC => CapkzboKPLCbzCjaUxTWKsXZOaPm;

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int jgJnKRtbOGxtdgWMHuSZhGmREcKq(int P_0, void* P_1);

	private unsafe static int ZsvcxJnGYpoDMHwtXJvkPKPxOkUR(int P_0, void* P_1)
	{
		return jgJnKRtbOGxtdgWMHuSZhGmREcKq(P_0, P_1);
	}

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int diaDlEFkoKOFKAawKnRNbxXEVGfIb(int P_0, void* P_1);

	private unsafe static int NPonKBBXanNHyGBXMOrFaSCVYhi(int P_0, void* P_1)
	{
		return diaDlEFkoKOFKAawKnRNbxXEVGfIb(P_0, P_1);
	}

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int GSekFcGGpsZSIkweedfdSnTYhyTL(int P_0, void* P_1);

	private unsafe static int MrrSWRcRBPqBpBOnBimozGbNJuWQ(int P_0, void* P_1)
	{
		return GSekFcGGpsZSIkweedfdSnTYhyTL(P_0, P_1);
	}

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int fTzcrdbPLWHPtEeMshrsDySgzFRZB(int P_0, void* P_1);

	private unsafe static int PqRhvUKdrCPUdbGRrfWCJtsXHLKn(int P_0, void* P_1)
	{
		return fTzcrdbPLWHPtEeMshrsDySgzFRZB(P_0, P_1);
	}

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dEWJZOmpcFUAnIpqqiRxFjSAEKur(int P_0, void* P_1);

	private unsafe static int eBqRYrIPERfVYTNnuiQzpmhCtBOo(int P_0, void* P_1)
	{
		return dEWJZOmpcFUAnIpqqiRxFjSAEKur(P_0, P_1);
	}

	public static bool zcRemXbcLIzabLElYDpEOtQwSsSV(out vptKaDMnFSuEIXNdBaSgiToTnjpHb P_0, out string P_1, out int P_2)
	{
		P_2 = 0;
		P_1 = "None";
		P_0 = vptKaDMnFSuEIXNdBaSgiToTnjpHb.None;
		ZzVGpaAgXchgKeSSJRxNxiTXLAoGA = false;
		CapkzboKPLCbzCjaUxTWKsXZOaPm = null;
		if (hwlMPxhNxhSFjwmBhevQYgiUktXc())
		{
			OoBmsnQpKPGdakuAlEoBFQmUhWmZA = vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_4;
			muHqcrnkDksslRMiBiEikdXFuWcS = "Xinput1_4.dll";
		}
		else if (RsdvopUYuJMZBKZbqzrRspsHiUwb())
		{
			OoBmsnQpKPGdakuAlEoBFQmUhWmZA = vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_3;
			muHqcrnkDksslRMiBiEikdXFuWcS = "Xinput1_3.dll";
		}
		else if (ZIPFYLDHkBczxQjHaMsPeedGOhJEA())
		{
			OoBmsnQpKPGdakuAlEoBFQmUhWmZA = vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_2;
			muHqcrnkDksslRMiBiEikdXFuWcS = "Xinput1_2.dll";
		}
		else if (MmybJUadLuNaMBLAfmViRiXwknaab())
		{
			OoBmsnQpKPGdakuAlEoBFQmUhWmZA = vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_1_1;
			muHqcrnkDksslRMiBiEikdXFuWcS = "Xinput1_1.dll";
		}
		else
		{
			if (!dxaRdHRDEdjlwtmpurbXgStqyVml())
			{
				P_2 = 1;
				return false;
			}
			OoBmsnQpKPGdakuAlEoBFQmUhWmZA = vptKaDMnFSuEIXNdBaSgiToTnjpHb.XINPUT_9_1_0;
			muHqcrnkDksslRMiBiEikdXFuWcS = "Xinput9_1_0.dll";
		}
		P_1 = muHqcrnkDksslRMiBiEikdXFuWcS;
		P_0 = OoBmsnQpKPGdakuAlEoBFQmUhWmZA;
		if (ZzVGpaAgXchgKeSSJRxNxiTXLAoGA && !cZSTWAwZugKPTkzaAVdNQbFdJzMI())
		{
			ZzVGpaAgXchgKeSSJRxNxiTXLAoGA = false;
		}
		if (!LvDYeWUNZcrGdlGoaAMNtnmeBIDJA())
		{
			LAhexqcezVSVmKRXymkcEAngYMQCc();
			return false;
		}
		return true;
	}

	private unsafe static bool hwlMPxhNxhSFjwmBhevQYgiUktXc()
	{
		try
		{
			fixed (urijYWHRYDjHpUIBTAkzPvMbdjsX* nZXSTDglmYRvSNAXFSwLOlKDPxyC = &NZXSTDglmYRvSNAXFSwLOlKDPxyC)
			{
				void* ptr = nZXSTDglmYRvSNAXFSwLOlKDPxyC;
				eBqRYrIPERfVYTNnuiQzpmhCtBOo(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool RsdvopUYuJMZBKZbqzrRspsHiUwb()
	{
		try
		{
			fixed (urijYWHRYDjHpUIBTAkzPvMbdjsX* nZXSTDglmYRvSNAXFSwLOlKDPxyC = &NZXSTDglmYRvSNAXFSwLOlKDPxyC)
			{
				void* ptr = nZXSTDglmYRvSNAXFSwLOlKDPxyC;
				PqRhvUKdrCPUdbGRrfWCJtsXHLKn(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool ZIPFYLDHkBczxQjHaMsPeedGOhJEA()
	{
		try
		{
			fixed (urijYWHRYDjHpUIBTAkzPvMbdjsX* nZXSTDglmYRvSNAXFSwLOlKDPxyC = &NZXSTDglmYRvSNAXFSwLOlKDPxyC)
			{
				void* ptr = nZXSTDglmYRvSNAXFSwLOlKDPxyC;
				MrrSWRcRBPqBpBOnBimozGbNJuWQ(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool MmybJUadLuNaMBLAfmViRiXwknaab()
	{
		try
		{
			fixed (urijYWHRYDjHpUIBTAkzPvMbdjsX* nZXSTDglmYRvSNAXFSwLOlKDPxyC = &NZXSTDglmYRvSNAXFSwLOlKDPxyC)
			{
				void* ptr = nZXSTDglmYRvSNAXFSwLOlKDPxyC;
				NPonKBBXanNHyGBXMOrFaSCVYhi(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool dxaRdHRDEdjlwtmpurbXgStqyVml()
	{
		try
		{
			fixed (urijYWHRYDjHpUIBTAkzPvMbdjsX* nZXSTDglmYRvSNAXFSwLOlKDPxyC = &NZXSTDglmYRvSNAXFSwLOlKDPxyC)
			{
				void* ptr = nZXSTDglmYRvSNAXFSwLOlKDPxyC;
				ZsvcxJnGYpoDMHwtXJvkPKPxOkUR(255, ptr);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool cZSTWAwZugKPTkzaAVdNQbFdJzMI()
	{
		_ = ZzVGpaAgXchgKeSSJRxNxiTXLAoGA;
		return false;
	}

	private static bool LvDYeWUNZcrGdlGoaAMNtnmeBIDJA()
	{
		try
		{
			_ = new MfBGKQHiQJSofUpHMtinVyKcMQYE().HssrrySHiNxIjRzaAsLIdCHlpsIn;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void LAhexqcezVSVmKRXymkcEAngYMQCc()
	{
		if (ZzVGpaAgXchgKeSSJRxNxiTXLAoGA)
		{
			CapkzboKPLCbzCjaUxTWKsXZOaPm = null;
		}
	}
}
