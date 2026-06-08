using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct FalmQVTJKnCRzOnsKpwWBjXTJHN
{
	[FieldOffset(0)]
	private uint cUtmMOFnIqDzzgeABJxsXqjVGGT;

	[FieldOffset(0)]
	private ulong rCmFDZIAvDQRicrqCijyaqooZceg;

	[FieldOffset(0)]
	private IntPtr jOsDqfkjWEFGfbHnJxKnmsCEQWaa;

	private static readonly bool KnrDKmSJKMVrlCkefBRCskKtpQT;

	public static readonly int kBAhMOEbyJqqiAiFfGtMWTzCtIgJ;

	static FalmQVTJKnCRzOnsKpwWBjXTJHN()
	{
		kBAhMOEbyJqqiAiFfGtMWTzCtIgJ = IntPtr.Size;
		KnrDKmSJKMVrlCkefBRCskKtpQT = kBAhMOEbyJqqiAiFfGtMWTzCtIgJ == 8;
	}

	public static FalmQVTJKnCRzOnsKpwWBjXTJHN KzYVtPsQfzeDlvcDIxbFIktRwxL(byte[] P_0, int P_1)
	{
		FalmQVTJKnCRzOnsKpwWBjXTJHN result = default(FalmQVTJKnCRzOnsKpwWBjXTJHN);
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			result.rCmFDZIAvDQRicrqCijyaqooZceg = BitConverter.ToUInt64(P_0, P_1);
			result.jOsDqfkjWEFGfbHnJxKnmsCEQWaa = new IntPtr((long)result.rCmFDZIAvDQRicrqCijyaqooZceg);
		}
		else
		{
			while (true)
			{
				result.cUtmMOFnIqDzzgeABJxsXqjVGGT = BitConverter.ToUInt32(P_0, P_1);
				result.jOsDqfkjWEFGfbHnJxKnmsCEQWaa = new IntPtr((int)result.cUtmMOFnIqDzzgeABJxsXqjVGGT);
				int num = -966818257;
				while (true)
				{
					switch (num ^ -966818257)
					{
					case 2:
						num = -966818258;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0050;
					}
					break;
				}
				continue;
				end_IL_0050:
				break;
			}
		}
		return result;
	}

	public static implicit operator IntPtr(FalmQVTJKnCRzOnsKpwWBjXTJHN obj)
	{
		return obj.jOsDqfkjWEFGfbHnJxKnmsCEQWaa;
	}

	public static implicit operator FalmQVTJKnCRzOnsKpwWBjXTJHN(IntPtr obj)
	{
		FalmQVTJKnCRzOnsKpwWBjXTJHN result = new FalmQVTJKnCRzOnsKpwWBjXTJHN
		{
			jOsDqfkjWEFGfbHnJxKnmsCEQWaa = obj
		};
		while (true)
		{
			int num = -1463089351;
			while (true)
			{
				switch (num ^ -1463089352)
				{
				case 0:
					break;
				case 1:
					if (KnrDKmSJKMVrlCkefBRCskKtpQT)
					{
						result.rCmFDZIAvDQRicrqCijyaqooZceg = (ulong)obj.ToInt64();
						num = -1463089350;
						continue;
					}
					goto case 3;
				case 3:
					result.cUtmMOFnIqDzzgeABJxsXqjVGGT = (uint)obj.ToInt32();
					num = -1463089350;
					continue;
				default:
					return result;
				}
				break;
			}
		}
	}

	public override string ToString()
	{
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			return rCmFDZIAvDQRicrqCijyaqooZceg.ToString();
		}
		return cUtmMOFnIqDzzgeABJxsXqjVGGT.ToString();
	}

	public int ZsJkqVsBoQgdHDnTiHucqOuhZPd()
	{
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			return (int)rCmFDZIAvDQRicrqCijyaqooZceg;
		}
		return (int)cUtmMOFnIqDzzgeABJxsXqjVGGT;
	}
}
