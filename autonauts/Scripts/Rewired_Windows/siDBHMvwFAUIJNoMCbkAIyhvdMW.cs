using System;

internal struct siDBHMvwFAUIJNoMCbkAIyhvdMW
{
	private int xfpiqPJnDwOhTuISiZUvQhZfJWs;

	private long qkJbDCCLZnafKjDIiGwmAdFmxeUD;

	private static readonly bool LSXKhNWqaYXRhGEFFUMCjrDtClE;

	public static readonly int jCrESXpCSpMEOgJbFAsGAKUQCWML;

	static siDBHMvwFAUIJNoMCbkAIyhvdMW()
	{
		LSXKhNWqaYXRhGEFFUMCjrDtClE = IntPtr.Size == 8;
		jCrESXpCSpMEOgJbFAsGAKUQCWML = (LSXKhNWqaYXRhGEFFUMCjrDtClE ? 8 : 4);
	}

	public static siDBHMvwFAUIJNoMCbkAIyhvdMW TYlxuGmSJRngTlXtymyHFDIVxCx(byte[] P_0, int P_1)
	{
		siDBHMvwFAUIJNoMCbkAIyhvdMW result = default(siDBHMvwFAUIJNoMCbkAIyhvdMW);
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			result.qkJbDCCLZnafKjDIiGwmAdFmxeUD = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.xfpiqPJnDwOhTuISiZUvQhZfJWs = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	public static implicit operator int(siDBHMvwFAUIJNoMCbkAIyhvdMW obj)
	{
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			return (int)obj.qkJbDCCLZnafKjDIiGwmAdFmxeUD;
		}
		return obj.xfpiqPJnDwOhTuISiZUvQhZfJWs;
	}

	public static implicit operator long(siDBHMvwFAUIJNoMCbkAIyhvdMW obj)
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
