using System;

internal struct yjPfaBdabNevfXjXnnKOrPuijTi
{
	private uint xfpiqPJnDwOhTuISiZUvQhZfJWs;

	private ulong qkJbDCCLZnafKjDIiGwmAdFmxeUD;

	private static readonly bool LSXKhNWqaYXRhGEFFUMCjrDtClE;

	public static readonly int jCrESXpCSpMEOgJbFAsGAKUQCWML;

	static yjPfaBdabNevfXjXnnKOrPuijTi()
	{
		LSXKhNWqaYXRhGEFFUMCjrDtClE = IntPtr.Size == 8;
		jCrESXpCSpMEOgJbFAsGAKUQCWML = (LSXKhNWqaYXRhGEFFUMCjrDtClE ? 8 : 4);
	}

	public static yjPfaBdabNevfXjXnnKOrPuijTi TYlxuGmSJRngTlXtymyHFDIVxCx(byte[] P_0, int P_1)
	{
		yjPfaBdabNevfXjXnnKOrPuijTi result = default(yjPfaBdabNevfXjXnnKOrPuijTi);
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			result.qkJbDCCLZnafKjDIiGwmAdFmxeUD = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.xfpiqPJnDwOhTuISiZUvQhZfJWs = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator uint(yjPfaBdabNevfXjXnnKOrPuijTi obj)
	{
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			return (uint)obj.qkJbDCCLZnafKjDIiGwmAdFmxeUD;
		}
		return obj.xfpiqPJnDwOhTuISiZUvQhZfJWs;
	}

	public static implicit operator ulong(yjPfaBdabNevfXjXnnKOrPuijTi obj)
	{
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			return obj.qkJbDCCLZnafKjDIiGwmAdFmxeUD;
		}
		return obj.xfpiqPJnDwOhTuISiZUvQhZfJWs;
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
