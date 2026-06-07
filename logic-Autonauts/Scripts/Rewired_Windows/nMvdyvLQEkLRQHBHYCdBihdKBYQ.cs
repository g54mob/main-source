using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct nMvdyvLQEkLRQHBHYCdBihdKBYQ
{
	[FieldOffset(0)]
	private int xfpiqPJnDwOhTuISiZUvQhZfJWs;

	[FieldOffset(0)]
	private long qkJbDCCLZnafKjDIiGwmAdFmxeUD;

	[FieldOffset(0)]
	private IntPtr cHHeOghCiuFcJJVXJmDpbilSMWQ;

	private static readonly bool LSXKhNWqaYXRhGEFFUMCjrDtClE;

	public static readonly int jCrESXpCSpMEOgJbFAsGAKUQCWML;

	static nMvdyvLQEkLRQHBHYCdBihdKBYQ()
	{
		jCrESXpCSpMEOgJbFAsGAKUQCWML = IntPtr.Size;
		LSXKhNWqaYXRhGEFFUMCjrDtClE = jCrESXpCSpMEOgJbFAsGAKUQCWML == 8;
	}

	public static nMvdyvLQEkLRQHBHYCdBihdKBYQ TYlxuGmSJRngTlXtymyHFDIVxCx(byte[] P_0, int P_1)
	{
		nMvdyvLQEkLRQHBHYCdBihdKBYQ result = default(nMvdyvLQEkLRQHBHYCdBihdKBYQ);
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			result.qkJbDCCLZnafKjDIiGwmAdFmxeUD = BitConverter.ToInt64(P_0, P_1);
			result.cHHeOghCiuFcJJVXJmDpbilSMWQ = new IntPtr(result.qkJbDCCLZnafKjDIiGwmAdFmxeUD);
		}
		else
		{
			while (true)
			{
				result.xfpiqPJnDwOhTuISiZUvQhZfJWs = BitConverter.ToInt32(P_0, P_1);
				result.cHHeOghCiuFcJJVXJmDpbilSMWQ = new IntPtr(result.xfpiqPJnDwOhTuISiZUvQhZfJWs);
				int num = 776944048;
				while (true)
				{
					switch (num ^ 0x2E4F39B1)
					{
					case 0:
						num = 776944051;
						continue;
					case 2:
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

	public static implicit operator nMvdyvLQEkLRQHBHYCdBihdKBYQ(IntPtr obj)
	{
		nMvdyvLQEkLRQHBHYCdBihdKBYQ result = new nMvdyvLQEkLRQHBHYCdBihdKBYQ
		{
			cHHeOghCiuFcJJVXJmDpbilSMWQ = obj
		};
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			result.qkJbDCCLZnafKjDIiGwmAdFmxeUD = obj.ToInt64();
			goto IL_0025;
		}
		goto IL_004e;
		IL_004e:
		result.xfpiqPJnDwOhTuISiZUvQhZfJWs = obj.ToInt32();
		int num = -1466335545;
		goto IL_002a;
		IL_0025:
		num = -1466335548;
		goto IL_002a;
		IL_002a:
		while (true)
		{
			switch (num ^ -1466335546)
			{
			case 0:
				break;
			case 2:
				num = -1466335545;
				continue;
			case 3:
				goto IL_004e;
			default:
				return result;
			}
			break;
		}
		goto IL_0025;
	}

	public static implicit operator IntPtr(nMvdyvLQEkLRQHBHYCdBihdKBYQ obj)
	{
		return obj.cHHeOghCiuFcJJVXJmDpbilSMWQ;
	}

	public override string ToString()
	{
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			return qkJbDCCLZnafKjDIiGwmAdFmxeUD.ToString();
		}
		return xfpiqPJnDwOhTuISiZUvQhZfJWs.ToString();
	}
}
