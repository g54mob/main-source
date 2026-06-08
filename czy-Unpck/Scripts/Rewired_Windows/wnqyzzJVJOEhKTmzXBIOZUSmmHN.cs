using System;

internal struct wnqyzzJVJOEhKTmzXBIOZUSmmHN
{
	private int cUtmMOFnIqDzzgeABJxsXqjVGGT;

	private long rCmFDZIAvDQRicrqCijyaqooZceg;

	private static readonly bool KnrDKmSJKMVrlCkefBRCskKtpQT;

	public static readonly int kBAhMOEbyJqqiAiFfGtMWTzCtIgJ;

	static wnqyzzJVJOEhKTmzXBIOZUSmmHN()
	{
		KnrDKmSJKMVrlCkefBRCskKtpQT = IntPtr.Size == 8;
		kBAhMOEbyJqqiAiFfGtMWTzCtIgJ = (KnrDKmSJKMVrlCkefBRCskKtpQT ? 8 : 4);
	}

	public static wnqyzzJVJOEhKTmzXBIOZUSmmHN KzYVtPsQfzeDlvcDIxbFIktRwxL(byte[] P_0, int P_1)
	{
		wnqyzzJVJOEhKTmzXBIOZUSmmHN result = default(wnqyzzJVJOEhKTmzXBIOZUSmmHN);
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			result.rCmFDZIAvDQRicrqCijyaqooZceg = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.cUtmMOFnIqDzzgeABJxsXqjVGGT = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator int(wnqyzzJVJOEhKTmzXBIOZUSmmHN obj)
	{
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			return (int)obj.rCmFDZIAvDQRicrqCijyaqooZceg;
		}
		return obj.cUtmMOFnIqDzzgeABJxsXqjVGGT;
	}

	public static implicit operator long(wnqyzzJVJOEhKTmzXBIOZUSmmHN obj)
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
