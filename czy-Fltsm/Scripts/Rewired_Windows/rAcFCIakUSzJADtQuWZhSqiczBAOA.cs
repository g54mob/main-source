using System;
using System.Runtime.CompilerServices;

internal struct rAcFCIakUSzJADtQuWZhSqiczBAOA : IEquatable<rAcFCIakUSzJADtQuWZhSqiczBAOA>
{
	public static readonly rAcFCIakUSzJADtQuWZhSqiczBAOA HyYNKhMicSgQpfHmKVMhdzDmWUlG = new rAcFCIakUSzJADtQuWZhSqiczBAOA(0, 0);

	public int pgdznwCCarpBCGexEtJdXOraKzgu;

	public int iAETVDRDwrGwbjGOZOodkvPnTFSc;

	public rAcFCIakUSzJADtQuWZhSqiczBAOA(int P_0, int P_1)
	{
		pgdznwCCarpBCGexEtJdXOraKzgu = P_0;
		iAETVDRDwrGwbjGOZOodkvPnTFSc = P_1;
	}

	public bool Equals(rAcFCIakUSzJADtQuWZhSqiczBAOA other)
	{
		if (other.pgdznwCCarpBCGexEtJdXOraKzgu == pgdznwCCarpBCGexEtJdXOraKzgu)
		{
			return other.iAETVDRDwrGwbjGOZOodkvPnTFSc == iAETVDRDwrGwbjGOZOodkvPnTFSc;
		}
		return false;
	}

	bool IEquatable<rAcFCIakUSzJADtQuWZhSqiczBAOA>.Equals(rAcFCIakUSzJADtQuWZhSqiczBAOA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool RYoKTclLchecnAmFXUOYDnWRILFgA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(rAcFCIakUSzJADtQuWZhSqiczBAOA))
		{
			return false;
		}
		return Equals((rAcFCIakUSzJADtQuWZhSqiczBAOA)P_0);
	}

	public int izfwpJyOaOaqKkirsxlMvXJfqQbg()
	{
		return (pgdznwCCarpBCGexEtJdXOraKzgu * 397) ^ iAETVDRDwrGwbjGOZOodkvPnTFSc;
	}

	[SpecialName]
	public static bool anUeaYejEtPIVQmnpLBKluhfbHUWA(rAcFCIakUSzJADtQuWZhSqiczBAOA P_0, rAcFCIakUSzJADtQuWZhSqiczBAOA P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool KzIetiSSzUejiaOVycKaazwHXFFFA(rAcFCIakUSzJADtQuWZhSqiczBAOA P_0, rAcFCIakUSzJADtQuWZhSqiczBAOA P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string hTQxnWTzzxaGYZsAucPcmeWXCWAM()
	{
		return $"({pgdznwCCarpBCGexEtJdXOraKzgu},{iAETVDRDwrGwbjGOZOodkvPnTFSc})";
	}
}
