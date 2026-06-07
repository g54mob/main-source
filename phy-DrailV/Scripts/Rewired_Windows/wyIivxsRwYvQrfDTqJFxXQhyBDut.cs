using System;
using System.Runtime.CompilerServices;

internal struct wyIivxsRwYvQrfDTqJFxXQhyBDut : IEquatable<wyIivxsRwYvQrfDTqJFxXQhyBDut>
{
	public static readonly wyIivxsRwYvQrfDTqJFxXQhyBDut RHehBwDLhoBlJseolcvUnZfDCgeS = new wyIivxsRwYvQrfDTqJFxXQhyBDut(0, 0);

	public static readonly wyIivxsRwYvQrfDTqJFxXQhyBDut kVxYLzSxBBkDqfykqfQrFXMXcttV = RHehBwDLhoBlJseolcvUnZfDCgeS;

	public int gxJIBqAQdiyAMmXguRqDxGkQCqUl;

	public int QxJWgmYYskAoNDIDObyygnCJDtcGb;

	public wyIivxsRwYvQrfDTqJFxXQhyBDut(int P_0, int P_1)
	{
		gxJIBqAQdiyAMmXguRqDxGkQCqUl = P_0;
		QxJWgmYYskAoNDIDObyygnCJDtcGb = P_1;
	}

	public bool Equals(wyIivxsRwYvQrfDTqJFxXQhyBDut other)
	{
		if (other.gxJIBqAQdiyAMmXguRqDxGkQCqUl == gxJIBqAQdiyAMmXguRqDxGkQCqUl)
		{
			return other.QxJWgmYYskAoNDIDObyygnCJDtcGb == QxJWgmYYskAoNDIDObyygnCJDtcGb;
		}
		return false;
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(wyIivxsRwYvQrfDTqJFxXQhyBDut))
		{
			return false;
		}
		return Equals((wyIivxsRwYvQrfDTqJFxXQhyBDut)P_0);
	}

	public int fEwcDhFDzGumYFCZRxsMimpbheAt()
	{
		return (gxJIBqAQdiyAMmXguRqDxGkQCqUl * 397) ^ QxJWgmYYskAoNDIDObyygnCJDtcGb;
	}

	[SpecialName]
	public static bool KnRQEmwHYQnLlhpqQiYLhcNhPfug(wyIivxsRwYvQrfDTqJFxXQhyBDut P_0, wyIivxsRwYvQrfDTqJFxXQhyBDut P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool aVrCGbDxOYyGJCHKjqMUEaQwsGZeb(wyIivxsRwYvQrfDTqJFxXQhyBDut P_0, wyIivxsRwYvQrfDTqJFxXQhyBDut P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		return $"({gxJIBqAQdiyAMmXguRqDxGkQCqUl},{QxJWgmYYskAoNDIDObyygnCJDtcGb})";
	}
}
