using System;
using System.Runtime.CompilerServices;

internal struct YSoRtluPGFsjxVkWPSGZIdccKHHp : IEquatable<YSoRtluPGFsjxVkWPSGZIdccKHHp>
{
	public static readonly YSoRtluPGFsjxVkWPSGZIdccKHHp yVKKftkwhpodNobIdfqblupqORlo = new YSoRtluPGFsjxVkWPSGZIdccKHHp(0, 0);

	public static readonly YSoRtluPGFsjxVkWPSGZIdccKHHp MrJspjyHnpShuuOoYXxTYdYYiRRt = yVKKftkwhpodNobIdfqblupqORlo;

	public int oeMpaZOFPVbTGajvfeURfbcXXqTy;

	public int JKsFtZUHWBICRDXwEnAuPcotzvFH;

	public YSoRtluPGFsjxVkWPSGZIdccKHHp(int P_0, int P_1)
	{
		oeMpaZOFPVbTGajvfeURfbcXXqTy = P_0;
		JKsFtZUHWBICRDXwEnAuPcotzvFH = P_1;
	}

	public bool Equals(YSoRtluPGFsjxVkWPSGZIdccKHHp other)
	{
		if (other.oeMpaZOFPVbTGajvfeURfbcXXqTy == oeMpaZOFPVbTGajvfeURfbcXXqTy)
		{
			return other.JKsFtZUHWBICRDXwEnAuPcotzvFH == JKsFtZUHWBICRDXwEnAuPcotzvFH;
		}
		return false;
	}

	bool IEquatable<YSoRtluPGFsjxVkWPSGZIdccKHHp>.Equals(YSoRtluPGFsjxVkWPSGZIdccKHHp other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool SVRVMxipkwPLlxebWrKBIiUobQwDA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(YSoRtluPGFsjxVkWPSGZIdccKHHp))
		{
			return false;
		}
		return Equals((YSoRtluPGFsjxVkWPSGZIdccKHHp)P_0);
	}

	public int gPnReoIZWWvzeYpWwoHqklPRHoUe()
	{
		return (oeMpaZOFPVbTGajvfeURfbcXXqTy * 397) ^ JKsFtZUHWBICRDXwEnAuPcotzvFH;
	}

	[SpecialName]
	public static bool huWoZTeBWJGCxfoYDCbXaQLEIfAmb(YSoRtluPGFsjxVkWPSGZIdccKHHp P_0, YSoRtluPGFsjxVkWPSGZIdccKHHp P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool aQbeVAvSuwYQWqmMvfzpRgMmgpPk(YSoRtluPGFsjxVkWPSGZIdccKHHp P_0, YSoRtluPGFsjxVkWPSGZIdccKHHp P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string aRsHhfwnZGbKodkaabeUkkDQrEqdb()
	{
		return $"({oeMpaZOFPVbTGajvfeURfbcXXqTy},{JKsFtZUHWBICRDXwEnAuPcotzvFH})";
	}
}
