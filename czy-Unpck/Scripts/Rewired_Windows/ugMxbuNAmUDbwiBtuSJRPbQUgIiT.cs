using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct ugMxbuNAmUDbwiBtuSJRPbQUgIiT
{
	[FieldOffset(0)]
	private int cUtmMOFnIqDzzgeABJxsXqjVGGT;

	[FieldOffset(0)]
	private long rCmFDZIAvDQRicrqCijyaqooZceg;

	[FieldOffset(0)]
	private IntPtr jOsDqfkjWEFGfbHnJxKnmsCEQWaa;

	private static readonly bool KnrDKmSJKMVrlCkefBRCskKtpQT;

	public static readonly int kBAhMOEbyJqqiAiFfGtMWTzCtIgJ;

	static ugMxbuNAmUDbwiBtuSJRPbQUgIiT()
	{
		kBAhMOEbyJqqiAiFfGtMWTzCtIgJ = IntPtr.Size;
		while (true)
		{
			int num = -946301866;
			while (true)
			{
				switch (num ^ -946301865)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_0028;
				case 2:
					return;
				}
				break;
				IL_0028:
				KnrDKmSJKMVrlCkefBRCskKtpQT = kBAhMOEbyJqqiAiFfGtMWTzCtIgJ == 8;
				num = -946301867;
			}
		}
	}

	public static ugMxbuNAmUDbwiBtuSJRPbQUgIiT KzYVtPsQfzeDlvcDIxbFIktRwxL(byte[] P_0, int P_1)
	{
		ugMxbuNAmUDbwiBtuSJRPbQUgIiT result = default(ugMxbuNAmUDbwiBtuSJRPbQUgIiT);
		while (true)
		{
			int num = -1607475540;
			while (true)
			{
				switch (num ^ -1607475539)
				{
				case 2:
					break;
				case 1:
					if (KnrDKmSJKMVrlCkefBRCskKtpQT)
					{
						result.rCmFDZIAvDQRicrqCijyaqooZceg = BitConverter.ToInt64(P_0, P_1);
						num = -1607475539;
						continue;
					}
					goto case 4;
				case 0:
					result.jOsDqfkjWEFGfbHnJxKnmsCEQWaa = new IntPtr(result.rCmFDZIAvDQRicrqCijyaqooZceg);
					num = -1607475538;
					continue;
				case 4:
					result.cUtmMOFnIqDzzgeABJxsXqjVGGT = BitConverter.ToInt32(P_0, P_1);
					result.jOsDqfkjWEFGfbHnJxKnmsCEQWaa = new IntPtr(result.cUtmMOFnIqDzzgeABJxsXqjVGGT);
					num = -1607475538;
					continue;
				default:
					return result;
				}
				break;
			}
		}
	}

	public static implicit operator ugMxbuNAmUDbwiBtuSJRPbQUgIiT(IntPtr obj)
	{
		ugMxbuNAmUDbwiBtuSJRPbQUgIiT result = new ugMxbuNAmUDbwiBtuSJRPbQUgIiT
		{
			jOsDqfkjWEFGfbHnJxKnmsCEQWaa = obj
		};
		if (KnrDKmSJKMVrlCkefBRCskKtpQT)
		{
			result.rCmFDZIAvDQRicrqCijyaqooZceg = obj.ToInt64();
		}
		else
		{
			while (true)
			{
				result.cUtmMOFnIqDzzgeABJxsXqjVGGT = obj.ToInt32();
				int num = 24350543;
				while (true)
				{
					switch (num ^ 0x1738F4F)
					{
					case 2:
						num = 24350542;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0045;
					}
					break;
				}
				continue;
				end_IL_0045:
				break;
			}
		}
		return result;
	}

	public static implicit operator IntPtr(ugMxbuNAmUDbwiBtuSJRPbQUgIiT obj)
	{
		return obj.jOsDqfkjWEFGfbHnJxKnmsCEQWaa;
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
