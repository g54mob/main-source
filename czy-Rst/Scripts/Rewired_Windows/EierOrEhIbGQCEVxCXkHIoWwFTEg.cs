using System;
using System.Runtime.CompilerServices;

internal struct EierOrEhIbGQCEVxCXkHIoWwFTEg
{
	private int nyEoUSakKsvCKstqkOIXlzdSHCOQ;

	private long gjBtFixxxbelAKcwSjservcGUdEc;

	private static readonly bool FmmgWsOmvxdROgtyBNyJfsjyvyw;

	public static readonly int TZNvYCiZrebcDdgwSgmRQNhVHHtR;

	static EierOrEhIbGQCEVxCXkHIoWwFTEg()
	{
		FmmgWsOmvxdROgtyBNyJfsjyvyw = IntPtr.Size == 8;
		TZNvYCiZrebcDdgwSgmRQNhVHHtR = (FmmgWsOmvxdROgtyBNyJfsjyvyw ? 8 : 4);
	}

	public static EierOrEhIbGQCEVxCXkHIoWwFTEg njeiOGmDrPvTrAxyyrgqWayPzpwN(byte[] P_0, int P_1)
	{
		EierOrEhIbGQCEVxCXkHIoWwFTEg result = default(EierOrEhIbGQCEVxCXkHIoWwFTEg);
		if (FmmgWsOmvxdROgtyBNyJfsjyvyw)
		{
			result.gjBtFixxxbelAKcwSjservcGUdEc = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.nyEoUSakKsvCKstqkOIXlzdSHCOQ = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int ofDObbxEKJIMrKXasXJHnUKfWejMA(EierOrEhIbGQCEVxCXkHIoWwFTEg P_0)
	{
		if (FmmgWsOmvxdROgtyBNyJfsjyvyw)
		{
			return (int)P_0.gjBtFixxxbelAKcwSjservcGUdEc;
		}
		return P_0.nyEoUSakKsvCKstqkOIXlzdSHCOQ;
	}

	[SpecialName]
	public static long ofDObbxEKJIMrKXasXJHnUKfWejMA(EierOrEhIbGQCEVxCXkHIoWwFTEg P_0)
	{
		if (FmmgWsOmvxdROgtyBNyJfsjyvyw)
		{
			return P_0.gjBtFixxxbelAKcwSjservcGUdEc;
		}
		return P_0.nyEoUSakKsvCKstqkOIXlzdSHCOQ;
	}

	public string aFSdpQJLcVlBCVSaRsrFgdddQvnWb()
	{
		if (FmmgWsOmvxdROgtyBNyJfsjyvyw)
		{
			return gjBtFixxxbelAKcwSjservcGUdEc.ToString();
		}
		return nyEoUSakKsvCKstqkOIXlzdSHCOQ.ToString();
	}
}
