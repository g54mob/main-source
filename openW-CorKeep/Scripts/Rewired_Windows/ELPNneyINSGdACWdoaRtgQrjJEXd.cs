using System;
using System.Runtime.CompilerServices;

internal struct ELPNneyINSGdACWdoaRtgQrjJEXd : IEquatable<ELPNneyINSGdACWdoaRtgQrjJEXd>
{
	public static readonly ELPNneyINSGdACWdoaRtgQrjJEXd sdpcIRDEiQPblcAmkWolsnzSbGabc = new ELPNneyINSGdACWdoaRtgQrjJEXd(0, 0);

	public int KQKgKStsnRAUnxhWqufBBHhTjnW;

	public int TaxwQrRGFjsJxKQONItrsjBiJVWo;

	public ELPNneyINSGdACWdoaRtgQrjJEXd(int P_0, int P_1)
	{
		KQKgKStsnRAUnxhWqufBBHhTjnW = P_0;
		TaxwQrRGFjsJxKQONItrsjBiJVWo = P_1;
	}

	public bool Equals(ELPNneyINSGdACWdoaRtgQrjJEXd other)
	{
		if (other.KQKgKStsnRAUnxhWqufBBHhTjnW == KQKgKStsnRAUnxhWqufBBHhTjnW)
		{
			return other.TaxwQrRGFjsJxKQONItrsjBiJVWo == TaxwQrRGFjsJxKQONItrsjBiJVWo;
		}
		return false;
	}

	bool IEquatable<ELPNneyINSGdACWdoaRtgQrjJEXd>.Equals(ELPNneyINSGdACWdoaRtgQrjJEXd other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool kcBEPYxlcdpdfJyNJneKjyeADhGH(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(ELPNneyINSGdACWdoaRtgQrjJEXd))
		{
			return false;
		}
		return Equals((ELPNneyINSGdACWdoaRtgQrjJEXd)P_0);
	}

	public int DKWfdnoUcUJbYPZzkDSClInypqgU()
	{
		return (KQKgKStsnRAUnxhWqufBBHhTjnW * 397) ^ TaxwQrRGFjsJxKQONItrsjBiJVWo;
	}

	[SpecialName]
	public static bool FotrPulGKnRJDVidzcUGuZscPeVG(ELPNneyINSGdACWdoaRtgQrjJEXd P_0, ELPNneyINSGdACWdoaRtgQrjJEXd P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool zBnsgUGcfSeiwDGNaVzmzAYIKLIQ(ELPNneyINSGdACWdoaRtgQrjJEXd P_0, ELPNneyINSGdACWdoaRtgQrjJEXd P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string GRfPiiBddhNxYctGgrJoqKkMYATm()
	{
		return $"({KQKgKStsnRAUnxhWqufBBHhTjnW},{TaxwQrRGFjsJxKQONItrsjBiJVWo})";
	}
}
