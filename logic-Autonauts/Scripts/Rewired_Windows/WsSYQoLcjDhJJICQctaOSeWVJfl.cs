using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct WsSYQoLcjDhJJICQctaOSeWVJfl
{
	[FieldOffset(0)]
	private uint xfpiqPJnDwOhTuISiZUvQhZfJWs;

	[FieldOffset(0)]
	private ulong qkJbDCCLZnafKjDIiGwmAdFmxeUD;

	[FieldOffset(0)]
	private IntPtr cHHeOghCiuFcJJVXJmDpbilSMWQ;

	private static readonly bool LSXKhNWqaYXRhGEFFUMCjrDtClE;

	public static readonly int jCrESXpCSpMEOgJbFAsGAKUQCWML;

	static WsSYQoLcjDhJJICQctaOSeWVJfl()
	{
		jCrESXpCSpMEOgJbFAsGAKUQCWML = IntPtr.Size;
		LSXKhNWqaYXRhGEFFUMCjrDtClE = jCrESXpCSpMEOgJbFAsGAKUQCWML == 8;
	}

	public static WsSYQoLcjDhJJICQctaOSeWVJfl TYlxuGmSJRngTlXtymyHFDIVxCx(byte[] P_0, int P_1)
	{
		WsSYQoLcjDhJJICQctaOSeWVJfl result = default(WsSYQoLcjDhJJICQctaOSeWVJfl);
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			result.qkJbDCCLZnafKjDIiGwmAdFmxeUD = BitConverter.ToUInt64(P_0, P_1);
			goto IL_001d;
		}
		goto IL_0061;
		IL_0061:
		result.xfpiqPJnDwOhTuISiZUvQhZfJWs = BitConverter.ToUInt32(P_0, P_1);
		int num = -1867079751;
		goto IL_0022;
		IL_001d:
		num = -1867079745;
		goto IL_0022;
		IL_0022:
		while (true)
		{
			switch (num ^ -1867079750)
			{
			case 2:
				break;
			case 5:
				result.cHHeOghCiuFcJJVXJmDpbilSMWQ = new IntPtr((long)result.qkJbDCCLZnafKjDIiGwmAdFmxeUD);
				num = -1867079750;
				continue;
			case 1:
				goto IL_0061;
			case 0:
				num = -1867079746;
				continue;
			case 3:
				result.cHHeOghCiuFcJJVXJmDpbilSMWQ = new IntPtr((int)result.xfpiqPJnDwOhTuISiZUvQhZfJWs);
				num = -1867079746;
				continue;
			default:
				return result;
			}
			break;
		}
		goto IL_001d;
	}

	public static implicit operator IntPtr(WsSYQoLcjDhJJICQctaOSeWVJfl obj)
	{
		return obj.cHHeOghCiuFcJJVXJmDpbilSMWQ;
	}

	public static implicit operator WsSYQoLcjDhJJICQctaOSeWVJfl(IntPtr obj)
	{
		WsSYQoLcjDhJJICQctaOSeWVJfl result = default(WsSYQoLcjDhJJICQctaOSeWVJfl);
		while (true)
		{
			int num = -527848262;
			while (true)
			{
				switch (num ^ -527848263)
				{
				case 0:
					break;
				case 3:
					result.cHHeOghCiuFcJJVXJmDpbilSMWQ = obj;
					if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
					{
						result.qkJbDCCLZnafKjDIiGwmAdFmxeUD = (ulong)obj.ToInt64();
						num = -527848264;
						continue;
					}
					goto case 4;
				case 1:
					num = -527848261;
					continue;
				case 4:
					result.xfpiqPJnDwOhTuISiZUvQhZfJWs = (uint)obj.ToInt32();
					num = -527848261;
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
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			return qkJbDCCLZnafKjDIiGwmAdFmxeUD.ToString();
		}
		return xfpiqPJnDwOhTuISiZUvQhZfJWs.ToString();
	}

	public int EFoPoIegfgaMlAZTYtQqfztfcBXU()
	{
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			return (int)qkJbDCCLZnafKjDIiGwmAdFmxeUD;
		}
		return (int)xfpiqPJnDwOhTuISiZUvQhZfJWs;
	}
}
