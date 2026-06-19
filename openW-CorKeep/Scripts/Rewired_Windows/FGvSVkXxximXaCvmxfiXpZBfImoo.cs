using System;
using System.Runtime.CompilerServices;

internal struct FGvSVkXxximXaCvmxfiXpZBfImoo : IEquatable<FGvSVkXxximXaCvmxfiXpZBfImoo>
{
	public static readonly FGvSVkXxximXaCvmxfiXpZBfImoo dsNaIcZGxEAuSxsGFKzdYMudocUC = new FGvSVkXxximXaCvmxfiXpZBfImoo(0, 0);

	public static readonly FGvSVkXxximXaCvmxfiXpZBfImoo RhSsFkXoEUeTxnwYoRRVrjdJAagW = dsNaIcZGxEAuSxsGFKzdYMudocUC;

	public int bIJNZGngmwBlJtBwNqhHSRiUBReC;

	public int GifhXWzEusisMOrbeFOeyFLuhWmO;

	public FGvSVkXxximXaCvmxfiXpZBfImoo(int P_0, int P_1)
	{
		bIJNZGngmwBlJtBwNqhHSRiUBReC = P_0;
		GifhXWzEusisMOrbeFOeyFLuhWmO = P_1;
	}

	public bool Equals(FGvSVkXxximXaCvmxfiXpZBfImoo other)
	{
		if (other.bIJNZGngmwBlJtBwNqhHSRiUBReC == bIJNZGngmwBlJtBwNqhHSRiUBReC)
		{
			return other.GifhXWzEusisMOrbeFOeyFLuhWmO == GifhXWzEusisMOrbeFOeyFLuhWmO;
		}
		return false;
	}

	bool IEquatable<FGvSVkXxximXaCvmxfiXpZBfImoo>.Equals(FGvSVkXxximXaCvmxfiXpZBfImoo other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool LCSOesNgRJyzqgZToIeDnftpAtTHA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(FGvSVkXxximXaCvmxfiXpZBfImoo))
		{
			return false;
		}
		return Equals((FGvSVkXxximXaCvmxfiXpZBfImoo)P_0);
	}

	public int pCkvmhdruhVNhPkLYIjmPaGSaihM()
	{
		return (bIJNZGngmwBlJtBwNqhHSRiUBReC * 397) ^ GifhXWzEusisMOrbeFOeyFLuhWmO;
	}

	[SpecialName]
	public static bool qENwpQDirkpmkbzuddBRvpgVfCdO(FGvSVkXxximXaCvmxfiXpZBfImoo P_0, FGvSVkXxximXaCvmxfiXpZBfImoo P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool fCwMSFMZJPmfZlkMLXUhqjtdLyUc(FGvSVkXxximXaCvmxfiXpZBfImoo P_0, FGvSVkXxximXaCvmxfiXpZBfImoo P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string jIjCHwdNofQsruaIYBUUcJcbZrXQB()
	{
		return $"({bIJNZGngmwBlJtBwNqhHSRiUBReC},{GifhXWzEusisMOrbeFOeyFLuhWmO})";
	}
}
