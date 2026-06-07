using System.Runtime.InteropServices;

internal class vfuAiKLVRYGaNsyitTmuTXodeUQA
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate int IXWpUKCBWnRzUbuGaUTrHYrmIPnQ(int arg0, void* arg1);

	private static bool TreLOnxLkTjXuBDhActJYAkjlsj;

	private static xfzjGOmskvZtGUvshJSLmbDHsoTQ drMEPgIYTrrCgTjCGNwYdvHbdbbA;

	private static string OMLaLUWYzbOTyvSPHlbGQLUhJvye;

	private static IXWpUKCBWnRzUbuGaUTrHYrmIPnQ qwcSAVoQBbCiHlDFhlkSFLIOBYigA;

	private static iEoHiNBpxuqYdDLSfjoMCydwpsYiB xEOzZioojZfucEhrTviBlbXoKGon;

	public static bool ndkiLucqiNiogGxsBykcfgjXVeJD => TreLOnxLkTjXuBDhActJYAkjlsj;

	public static xfzjGOmskvZtGUvshJSLmbDHsoTQ HCSPLIPKlUEHoHivvmDYJleKFSzO => drMEPgIYTrrCgTjCGNwYdvHbdbbA;

	public static IXWpUKCBWnRzUbuGaUTrHYrmIPnQ pKCtecQkuOCIVFtsHUGGpDIhkxpd => qwcSAVoQBbCiHlDFhlkSFLIOBYigA;

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int FgUImZjvKqzxxItedOHxuEpEmmYE(int P_0, void* P_1);

	private unsafe static int bJJOnCbOsHqpSbUUsrcplbTLfKig(int P_0, void* P_1)
	{
		return FgUImZjvKqzxxItedOHxuEpEmmYE(P_0, P_1);
	}

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int ANwjQvUHroNuRIFBKjVnbaSvtExt(int P_0, void* P_1);

	private unsafe static int vllfjwlibnhYmgNOyEJMKBJxdXtAb(int P_0, void* P_1)
	{
		return ANwjQvUHroNuRIFBKjVnbaSvtExt(P_0, P_1);
	}

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int KXNYihwbkTCCCOOuQfKQFIRlaMkEb(int P_0, void* P_1);

	private unsafe static int RprKtNFYlzAFbtPxWxSTuHMJUpNI(int P_0, void* P_1)
	{
		return KXNYihwbkTCCCOOuQfKQFIRlaMkEb(P_0, P_1);
	}

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int dyygTKxKiXPVSgPYAtphrSjHwXpU(int P_0, void* P_1);

	private unsafe static int QQULRsPMDpauvqeembgeBDjQLLHSA(int P_0, void* P_1)
	{
		return dyygTKxKiXPVSgPYAtphrSjHwXpU(P_0, P_1);
	}

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int fURdZDDyPqIhZvdJpzvjLzfGrgjf(int P_0, void* P_1);

	private unsafe static int DtdvPoCzRDUAiWaJCGhnENWyKjbn(int P_0, void* P_1)
	{
		return fURdZDDyPqIhZvdJpzvjLzfGrgjf(P_0, P_1);
	}

	public static bool wOYaABcPQWsWdiovhXznSUTJjLFnA(out xfzjGOmskvZtGUvshJSLmbDHsoTQ P_0, out string P_1, out int P_2)
	{
		P_2 = 0;
		P_1 = "None";
		P_0 = xfzjGOmskvZtGUvshJSLmbDHsoTQ.None;
		TreLOnxLkTjXuBDhActJYAkjlsj = false;
		qwcSAVoQBbCiHlDFhlkSFLIOBYigA = null;
		if (yLRRlEfEKDrVXDJvkNYXDKUdGKGN())
		{
			drMEPgIYTrrCgTjCGNwYdvHbdbbA = xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_4;
			OMLaLUWYzbOTyvSPHlbGQLUhJvye = "Xinput1_4.dll";
		}
		else if (kKjmSBZlPLGWrbuwcQWbCFdGNOeJB())
		{
			drMEPgIYTrrCgTjCGNwYdvHbdbbA = xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_3;
			OMLaLUWYzbOTyvSPHlbGQLUhJvye = "Xinput1_3.dll";
		}
		else if (AdsggghkhuBRFhWYYMffguDhAkggA())
		{
			drMEPgIYTrrCgTjCGNwYdvHbdbbA = xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_2;
			OMLaLUWYzbOTyvSPHlbGQLUhJvye = "Xinput1_2.dll";
		}
		else if (NqMtRqtPdTEreHAfMZXuNBBJaAMs())
		{
			drMEPgIYTrrCgTjCGNwYdvHbdbbA = xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_1;
			OMLaLUWYzbOTyvSPHlbGQLUhJvye = "Xinput1_1.dll";
		}
		else
		{
			if (!sFlFbyVvXICVcElzMqIZKUZPZCbMA())
			{
				P_2 = 1;
				return false;
			}
			drMEPgIYTrrCgTjCGNwYdvHbdbbA = xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_9_1_0;
			OMLaLUWYzbOTyvSPHlbGQLUhJvye = "Xinput9_1_0.dll";
		}
		P_1 = OMLaLUWYzbOTyvSPHlbGQLUhJvye;
		P_0 = drMEPgIYTrrCgTjCGNwYdvHbdbbA;
		if (TreLOnxLkTjXuBDhActJYAkjlsj && !vvqJENcyosEYaDnDjYqtnWEqUBYe())
		{
			TreLOnxLkTjXuBDhActJYAkjlsj = false;
		}
		if (!EuMIWeocJLjgtWXFNCXKRwWrlDkO())
		{
			zWOBhHwDucLGLyXdXGBOlbpiEUhx();
			return false;
		}
		return true;
	}

	private unsafe static bool yLRRlEfEKDrVXDJvkNYXDKUdGKGN()
	{
		try
		{
			fixed (iEoHiNBpxuqYdDLSfjoMCydwpsYiB* ptr = &xEOzZioojZfucEhrTviBlbXoKGon)
			{
				void* ptr2 = ptr;
				DtdvPoCzRDUAiWaJCGhnENWyKjbn(255, ptr2);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool kKjmSBZlPLGWrbuwcQWbCFdGNOeJB()
	{
		try
		{
			fixed (iEoHiNBpxuqYdDLSfjoMCydwpsYiB* ptr = &xEOzZioojZfucEhrTviBlbXoKGon)
			{
				void* ptr2 = ptr;
				QQULRsPMDpauvqeembgeBDjQLLHSA(255, ptr2);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool AdsggghkhuBRFhWYYMffguDhAkggA()
	{
		try
		{
			fixed (iEoHiNBpxuqYdDLSfjoMCydwpsYiB* ptr = &xEOzZioojZfucEhrTviBlbXoKGon)
			{
				void* ptr2 = ptr;
				RprKtNFYlzAFbtPxWxSTuHMJUpNI(255, ptr2);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool NqMtRqtPdTEreHAfMZXuNBBJaAMs()
	{
		try
		{
			fixed (iEoHiNBpxuqYdDLSfjoMCydwpsYiB* ptr = &xEOzZioojZfucEhrTviBlbXoKGon)
			{
				void* ptr2 = ptr;
				vllfjwlibnhYmgNOyEJMKBJxdXtAb(255, ptr2);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private unsafe static bool sFlFbyVvXICVcElzMqIZKUZPZCbMA()
	{
		try
		{
			fixed (iEoHiNBpxuqYdDLSfjoMCydwpsYiB* ptr = &xEOzZioojZfucEhrTviBlbXoKGon)
			{
				void* ptr2 = ptr;
				bJJOnCbOsHqpSbUUsrcplbTLfKig(255, ptr2);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static bool vvqJENcyosEYaDnDjYqtnWEqUBYe()
	{
		_ = TreLOnxLkTjXuBDhActJYAkjlsj;
		return false;
	}

	private static bool EuMIWeocJLjgtWXFNCXKRwWrlDkO()
	{
		try
		{
			_ = new OxXoFPtoxevzpTAOmpYSoCvcDCol().yMpQJKKzhNEfuakaflNCiCzEWDCW;
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void zWOBhHwDucLGLyXdXGBOlbpiEUhx()
	{
		if (TreLOnxLkTjXuBDhActJYAkjlsj)
		{
			qwcSAVoQBbCiHlDFhlkSFLIOBYigA = null;
		}
	}
}
