using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct FKpUUKpxWqVWVqLSTppLuedJkJtg : IEquatable<FKpUUKpxWqVWVqLSTppLuedJkJtg>
{
	private int kVcxjFSIlYQDDJTMWAKvGeGMUlvQ;

	public FKpUUKpxWqVWVqLSTppLuedJkJtg(bool P_0)
	{
		kVcxjFSIlYQDDJTMWAKvGeGMUlvQ = (P_0 ? 1 : 0);
	}

	public bool Equals(FKpUUKpxWqVWVqLSTppLuedJkJtg other)
	{
		return kVcxjFSIlYQDDJTMWAKvGeGMUlvQ == other.kVcxjFSIlYQDDJTMWAKvGeGMUlvQ;
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is FKpUUKpxWqVWVqLSTppLuedJkJtg)
		{
			return Equals((FKpUUKpxWqVWVqLSTppLuedJkJtg)P_0);
		}
		return false;
	}

	public int fEwcDhFDzGumYFCZRxsMimpbheAt()
	{
		return kVcxjFSIlYQDDJTMWAKvGeGMUlvQ;
	}

	[SpecialName]
	public static bool KnRQEmwHYQnLlhpqQiYLhcNhPfug(FKpUUKpxWqVWVqLSTppLuedJkJtg P_0, FKpUUKpxWqVWVqLSTppLuedJkJtg P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool aVrCGbDxOYyGJCHKjqMUEaQwsGZeb(FKpUUKpxWqVWVqLSTppLuedJkJtg P_0, FKpUUKpxWqVWVqLSTppLuedJkJtg P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool bPhBTDiXwPSGeHgqUdzKHurTqKRxA(FKpUUKpxWqVWVqLSTppLuedJkJtg P_0)
	{
		return P_0.kVcxjFSIlYQDDJTMWAKvGeGMUlvQ != 0;
	}

	[SpecialName]
	public static FKpUUKpxWqVWVqLSTppLuedJkJtg bPhBTDiXwPSGeHgqUdzKHurTqKRxA(bool P_0)
	{
		return new FKpUUKpxWqVWVqLSTppLuedJkJtg(P_0);
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		return $"{kVcxjFSIlYQDDJTMWAKvGeGMUlvQ != 0}";
	}
}
