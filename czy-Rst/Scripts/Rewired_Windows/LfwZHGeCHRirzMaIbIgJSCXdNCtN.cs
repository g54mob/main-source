using System;
using System.Runtime.CompilerServices;

internal struct LfwZHGeCHRirzMaIbIgJSCXdNCtN
{
	private int bnmvCwKDcQztyDKexXrVUEiSRpUE;

	private long uImgUGBBkaMLwnkYXowDqHREtOnFA;

	private static readonly bool XTaZiehhAjlPsigVAEeeSxbHzGMs;

	public static readonly int mRKRUdPnBCHMvOWhcyYqcLCbFfLp;

	static LfwZHGeCHRirzMaIbIgJSCXdNCtN()
	{
		XTaZiehhAjlPsigVAEeeSxbHzGMs = IntPtr.Size == 8;
		mRKRUdPnBCHMvOWhcyYqcLCbFfLp = (XTaZiehhAjlPsigVAEeeSxbHzGMs ? 8 : 4);
	}

	public static LfwZHGeCHRirzMaIbIgJSCXdNCtN wmbXrNBlNCwKeMlGuBFCiKdRaJjXA(byte[] P_0, int P_1)
	{
		LfwZHGeCHRirzMaIbIgJSCXdNCtN result = default(LfwZHGeCHRirzMaIbIgJSCXdNCtN);
		if (XTaZiehhAjlPsigVAEeeSxbHzGMs)
		{
			result.uImgUGBBkaMLwnkYXowDqHREtOnFA = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.bnmvCwKDcQztyDKexXrVUEiSRpUE = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int fGgyWMVzVFAXCLOpkKcqUnNJdgAw(LfwZHGeCHRirzMaIbIgJSCXdNCtN P_0)
	{
		if (XTaZiehhAjlPsigVAEeeSxbHzGMs)
		{
			return (int)P_0.uImgUGBBkaMLwnkYXowDqHREtOnFA;
		}
		return P_0.bnmvCwKDcQztyDKexXrVUEiSRpUE;
	}

	[SpecialName]
	public static long fGgyWMVzVFAXCLOpkKcqUnNJdgAw(LfwZHGeCHRirzMaIbIgJSCXdNCtN P_0)
	{
		if (XTaZiehhAjlPsigVAEeeSxbHzGMs)
		{
			return P_0.uImgUGBBkaMLwnkYXowDqHREtOnFA;
		}
		return P_0.bnmvCwKDcQztyDKexXrVUEiSRpUE;
	}

	public string whLeNzIbdDQQrzCEjjpOGyJAglklc()
	{
		if (XTaZiehhAjlPsigVAEeeSxbHzGMs)
		{
			return uImgUGBBkaMLwnkYXowDqHREtOnFA.ToString();
		}
		return bnmvCwKDcQztyDKexXrVUEiSRpUE.ToString();
	}
}
