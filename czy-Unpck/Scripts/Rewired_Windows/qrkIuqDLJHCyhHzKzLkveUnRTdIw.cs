using System;

internal struct qrkIuqDLJHCyhHzKzLkveUnRTdIw
{
	private uint cUtmMOFnIqDzzgeABJxsXqjVGGT;

	private ulong rCmFDZIAvDQRicrqCijyaqooZceg;

	private static readonly bool KnrDKmSJKMVrlCkefBRCskKtpQT;

	public static readonly int kBAhMOEbyJqqiAiFfGtMWTzCtIgJ;

	static qrkIuqDLJHCyhHzKzLkveUnRTdIw()
	{
		KnrDKmSJKMVrlCkefBRCskKtpQT = IntPtr.Size == 8;
		kBAhMOEbyJqqiAiFfGtMWTzCtIgJ = (KnrDKmSJKMVrlCkefBRCskKtpQT ? 8 : 4);
	}

	public static qrkIuqDLJHCyhHzKzLkveUnRTdIw KzYVtPsQfzeDlvcDIxbFIktRwxL(byte[] P_0, int P_1)
	{
		qrkIuqDLJHCyhHzKzLkveUnRTdIw result = default(qrkIuqDLJHCyhHzKzLkveUnRTdIw);
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

	public static implicit operator uint(qrkIuqDLJHCyhHzKzLkveUnRTdIw obj)
	{
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			return (uint)obj.rCmFDZIAvDQRicrqCijyaqooZceg;
		}
		return obj.cUtmMOFnIqDzzgeABJxsXqjVGGT;
	}

	public static implicit operator ulong(qrkIuqDLJHCyhHzKzLkveUnRTdIw obj)
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
