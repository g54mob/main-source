using System;

internal struct jBqjlYjuKrEARPqTVvqMuawsDrAd
{
	private uint cUtmMOFnIqDzzgeABJxsXqjVGGT;

	private ulong rCmFDZIAvDQRicrqCijyaqooZceg;

	private static readonly bool KnrDKmSJKMVrlCkefBRCskKtpQT;

	public static readonly int kBAhMOEbyJqqiAiFfGtMWTzCtIgJ;

	static jBqjlYjuKrEARPqTVvqMuawsDrAd()
	{
		KnrDKmSJKMVrlCkefBRCskKtpQT = IntPtr.Size == 8;
		kBAhMOEbyJqqiAiFfGtMWTzCtIgJ = (KnrDKmSJKMVrlCkefBRCskKtpQT ? 8 : 4);
	}

	public static jBqjlYjuKrEARPqTVvqMuawsDrAd KzYVtPsQfzeDlvcDIxbFIktRwxL(byte[] P_0, int P_1)
	{
		jBqjlYjuKrEARPqTVvqMuawsDrAd result = default(jBqjlYjuKrEARPqTVvqMuawsDrAd);
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			result.rCmFDZIAvDQRicrqCijyaqooZceg = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.cUtmMOFnIqDzzgeABJxsXqjVGGT = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator uint(jBqjlYjuKrEARPqTVvqMuawsDrAd obj)
	{
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			return (uint)obj.rCmFDZIAvDQRicrqCijyaqooZceg;
		}
		return obj.cUtmMOFnIqDzzgeABJxsXqjVGGT;
	}

	public static implicit operator ulong(jBqjlYjuKrEARPqTVvqMuawsDrAd obj)
	{
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			return obj.rCmFDZIAvDQRicrqCijyaqooZceg;
		}
		return obj.cUtmMOFnIqDzzgeABJxsXqjVGGT;
	}

	public override string ToString()
	{
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			return rCmFDZIAvDQRicrqCijyaqooZceg.ToString();
		}
		return cUtmMOFnIqDzzgeABJxsXqjVGGT.ToString();
	}
}
