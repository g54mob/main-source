using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct DKIIzhMACWIemCHikiFxBDRSyXEo : IEquatable<DKIIzhMACWIemCHikiFxBDRSyXEo>
{
	private int tvTOcjYYkzLDHeKtIyZCQERyHbVF;

	public DKIIzhMACWIemCHikiFxBDRSyXEo(bool P_0)
	{
		tvTOcjYYkzLDHeKtIyZCQERyHbVF = (P_0 ? 1 : 0);
	}

	public bool Equals(DKIIzhMACWIemCHikiFxBDRSyXEo other)
	{
		return tvTOcjYYkzLDHeKtIyZCQERyHbVF == other.tvTOcjYYkzLDHeKtIyZCQERyHbVF;
	}

	bool IEquatable<DKIIzhMACWIemCHikiFxBDRSyXEo>.Equals(DKIIzhMACWIemCHikiFxBDRSyXEo other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool tKJyjbwkGcTDyYRmBGLvAgyBnhmt(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is DKIIzhMACWIemCHikiFxBDRSyXEo)
		{
			return Equals((DKIIzhMACWIemCHikiFxBDRSyXEo)P_0);
		}
		return false;
	}

	public int UPiVGLYawAHudgpigSPKZmhrGyrp()
	{
		return tvTOcjYYkzLDHeKtIyZCQERyHbVF;
	}

	[SpecialName]
	public static bool bQKXIIBnOMDGCBLfwsZKfyReSuWpb(DKIIzhMACWIemCHikiFxBDRSyXEo P_0, DKIIzhMACWIemCHikiFxBDRSyXEo P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool BpmcGheOGqAhhVqryPbSIAXCngrLA(DKIIzhMACWIemCHikiFxBDRSyXEo P_0, DKIIzhMACWIemCHikiFxBDRSyXEo P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool iAZgQodaeZKIDPkZqcQploJqnRgiA(DKIIzhMACWIemCHikiFxBDRSyXEo P_0)
	{
		return P_0.tvTOcjYYkzLDHeKtIyZCQERyHbVF != 0;
	}

	[SpecialName]
	public static DKIIzhMACWIemCHikiFxBDRSyXEo xTdGctIDPqwzRnTrquyiyFuqCYuI(bool P_0)
	{
		return new DKIIzhMACWIemCHikiFxBDRSyXEo(P_0);
	}

	public string iMNskdTUBbNSlruKMCsTKGCBGTmZ()
	{
		return $"{tvTOcjYYkzLDHeKtIyZCQERyHbVF != 0}";
	}
}
