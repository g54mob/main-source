using System;
using System.Runtime.CompilerServices;

internal struct iaFgqMjmibqdOqrnymmJnLtWgzABb : IEquatable<iaFgqMjmibqdOqrnymmJnLtWgzABb>
{
	public static readonly iaFgqMjmibqdOqrnymmJnLtWgzABb YnjLaWceJJkGqQylWSFbeFsWEjkn = new iaFgqMjmibqdOqrnymmJnLtWgzABb(0, 0);

	public static readonly iaFgqMjmibqdOqrnymmJnLtWgzABb mZkDaCckFBdnHrWVhkFTOXFePlWSA = YnjLaWceJJkGqQylWSFbeFsWEjkn;

	public int AxnyIeSpelzqlAYkIaULgvIfEBGg;

	public int ftVSWwACzjaQwfXwfAFgOydJeRGq;

	public iaFgqMjmibqdOqrnymmJnLtWgzABb(int P_0, int P_1)
	{
		AxnyIeSpelzqlAYkIaULgvIfEBGg = P_0;
		ftVSWwACzjaQwfXwfAFgOydJeRGq = P_1;
	}

	public bool Equals(iaFgqMjmibqdOqrnymmJnLtWgzABb other)
	{
		if (other.AxnyIeSpelzqlAYkIaULgvIfEBGg == AxnyIeSpelzqlAYkIaULgvIfEBGg)
		{
			return other.ftVSWwACzjaQwfXwfAFgOydJeRGq == ftVSWwACzjaQwfXwfAFgOydJeRGq;
		}
		return false;
	}

	bool IEquatable<iaFgqMjmibqdOqrnymmJnLtWgzABb>.Equals(iaFgqMjmibqdOqrnymmJnLtWgzABb other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool iOcjNEwHKGGNKaFYtsoPtHVAqynfA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(iaFgqMjmibqdOqrnymmJnLtWgzABb))
		{
			return false;
		}
		return Equals((iaFgqMjmibqdOqrnymmJnLtWgzABb)P_0);
	}

	public int ALWCOBARbyWrJiJYNjUkpqyptjBs()
	{
		return (AxnyIeSpelzqlAYkIaULgvIfEBGg * 397) ^ ftVSWwACzjaQwfXwfAFgOydJeRGq;
	}

	[SpecialName]
	public static bool XPlfKyggivAGCMYdkCVBNHAerTDCA(iaFgqMjmibqdOqrnymmJnLtWgzABb P_0, iaFgqMjmibqdOqrnymmJnLtWgzABb P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool SVCbjIvYRCIbGCxNQTzkUBCCOjKe(iaFgqMjmibqdOqrnymmJnLtWgzABb P_0, iaFgqMjmibqdOqrnymmJnLtWgzABb P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string EmHYgKcqncnMZXGRBlWAvaQyXitV()
	{
		return $"({AxnyIeSpelzqlAYkIaULgvIfEBGg},{ftVSWwACzjaQwfXwfAFgOydJeRGq})";
	}
}
