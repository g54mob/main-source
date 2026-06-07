using System;
using System.Runtime.CompilerServices;

internal struct tiwdjfTrZwfsRbippBJRJQewSiRz : IEquatable<tiwdjfTrZwfsRbippBJRJQewSiRz>
{
	public static readonly tiwdjfTrZwfsRbippBJRJQewSiRz RHehBwDLhoBlJseolcvUnZfDCgeS = new tiwdjfTrZwfsRbippBJRJQewSiRz(0, 0);

	public int XHAcjfYHxobupnkeqiFjdRtqsftl;

	public int hOOUxyzjPSHmCugYimIocEeoCnOZ;

	public tiwdjfTrZwfsRbippBJRJQewSiRz(int P_0, int P_1)
	{
		XHAcjfYHxobupnkeqiFjdRtqsftl = P_0;
		hOOUxyzjPSHmCugYimIocEeoCnOZ = P_1;
	}

	public bool Equals(tiwdjfTrZwfsRbippBJRJQewSiRz other)
	{
		if (other.XHAcjfYHxobupnkeqiFjdRtqsftl == XHAcjfYHxobupnkeqiFjdRtqsftl)
		{
			return other.hOOUxyzjPSHmCugYimIocEeoCnOZ == hOOUxyzjPSHmCugYimIocEeoCnOZ;
		}
		return false;
	}

	public bool JRxBWnhQlwwPGktFTDexAbegXFrzB(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(tiwdjfTrZwfsRbippBJRJQewSiRz))
		{
			return false;
		}
		return Equals((tiwdjfTrZwfsRbippBJRJQewSiRz)P_0);
	}

	public int fEwcDhFDzGumYFCZRxsMimpbheAt()
	{
		return (XHAcjfYHxobupnkeqiFjdRtqsftl * 397) ^ hOOUxyzjPSHmCugYimIocEeoCnOZ;
	}

	[SpecialName]
	public static bool KnRQEmwHYQnLlhpqQiYLhcNhPfug(tiwdjfTrZwfsRbippBJRJQewSiRz P_0, tiwdjfTrZwfsRbippBJRJQewSiRz P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool aVrCGbDxOYyGJCHKjqMUEaQwsGZeb(tiwdjfTrZwfsRbippBJRJQewSiRz P_0, tiwdjfTrZwfsRbippBJRJQewSiRz P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
	{
		return $"({XHAcjfYHxobupnkeqiFjdRtqsftl},{hOOUxyzjPSHmCugYimIocEeoCnOZ})";
	}
}
