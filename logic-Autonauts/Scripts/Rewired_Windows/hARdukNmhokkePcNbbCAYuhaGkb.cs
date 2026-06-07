using System;

internal struct hARdukNmhokkePcNbbCAYuhaGkb
{
	private int xfpiqPJnDwOhTuISiZUvQhZfJWs;

	private long qkJbDCCLZnafKjDIiGwmAdFmxeUD;

	private static readonly bool LSXKhNWqaYXRhGEFFUMCjrDtClE;

	public static readonly int jCrESXpCSpMEOgJbFAsGAKUQCWML;

	static hARdukNmhokkePcNbbCAYuhaGkb()
	{
		LSXKhNWqaYXRhGEFFUMCjrDtClE = IntPtr.Size == 8;
		jCrESXpCSpMEOgJbFAsGAKUQCWML = (LSXKhNWqaYXRhGEFFUMCjrDtClE ? 8 : 4);
	}

	public static hARdukNmhokkePcNbbCAYuhaGkb TYlxuGmSJRngTlXtymyHFDIVxCx(byte[] P_0, int P_1)
	{
		hARdukNmhokkePcNbbCAYuhaGkb result = default(hARdukNmhokkePcNbbCAYuhaGkb);
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

	public static implicit operator int(hARdukNmhokkePcNbbCAYuhaGkb obj)
	{
		if (LSXKhNWqaYXRhGEFFUMCjrDtClE)
		{
			return (int)obj.qkJbDCCLZnafKjDIiGwmAdFmxeUD;
		}
		return obj.xfpiqPJnDwOhTuISiZUvQhZfJWs;
	}

	public static implicit operator long(hARdukNmhokkePcNbbCAYuhaGkb obj)
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
