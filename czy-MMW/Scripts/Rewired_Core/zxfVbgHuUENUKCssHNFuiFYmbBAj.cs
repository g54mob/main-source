using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct zxfVbgHuUENUKCssHNFuiFYmbBAj : IEquatable<zxfVbgHuUENUKCssHNFuiFYmbBAj>
{
	public KeyboardKeyCode DYmNLHpdUfvjIyPyEOUhVDkihJgl;

	public ModifierKey WvmgVaKJAFHrtHqgqbOzHSQKKvUUb;

	public ModifierKey AUrvsVAbJZFXGamesdJxInFzZlXL;

	public ModifierKey MROwmeehhXXgkdTHszQEYoiWUJsJ;

	public zxfVbgHuUENUKCssHNFuiFYmbBAj(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3)
	{
		DYmNLHpdUfvjIyPyEOUhVDkihJgl = P_0;
		WvmgVaKJAFHrtHqgqbOzHSQKKvUUb = P_1;
		AUrvsVAbJZFXGamesdJxInFzZlXL = P_2;
		MROwmeehhXXgkdTHszQEYoiWUJsJ = P_3;
	}

	public void nLzjPLwjmXfNruCyLrjeVRQhCRdg()
	{
		if (DYmNLHpdUfvjIyPyEOUhVDkihJgl != KeyboardKeyCode.None)
		{
			DYmNLHpdUfvjIyPyEOUhVDkihJgl = KeyboardKeyCode.None;
		}
		if (WvmgVaKJAFHrtHqgqbOzHSQKKvUUb != ModifierKey.None)
		{
			WvmgVaKJAFHrtHqgqbOzHSQKKvUUb = ModifierKey.None;
		}
		if (AUrvsVAbJZFXGamesdJxInFzZlXL != ModifierKey.None)
		{
			AUrvsVAbJZFXGamesdJxInFzZlXL = ModifierKey.None;
		}
		if (MROwmeehhXXgkdTHszQEYoiWUJsJ != ModifierKey.None)
		{
			MROwmeehhXXgkdTHszQEYoiWUJsJ = ModifierKey.None;
		}
	}

	public bool Equals(zxfVbgHuUENUKCssHNFuiFYmbBAj other)
	{
		if (DYmNLHpdUfvjIyPyEOUhVDkihJgl == other.DYmNLHpdUfvjIyPyEOUhVDkihJgl && WvmgVaKJAFHrtHqgqbOzHSQKKvUUb == other.WvmgVaKJAFHrtHqgqbOzHSQKKvUUb && AUrvsVAbJZFXGamesdJxInFzZlXL == other.AUrvsVAbJZFXGamesdJxInFzZlXL)
		{
			return MROwmeehhXXgkdTHszQEYoiWUJsJ == other.MROwmeehhXXgkdTHszQEYoiWUJsJ;
		}
		return false;
	}

	bool IEquatable<zxfVbgHuUENUKCssHNFuiFYmbBAj>.Equals(zxfVbgHuUENUKCssHNFuiFYmbBAj other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool csnKBFlkERxMkWbNpAbQESpEDMeh(object P_0)
	{
		if (P_0 == null || !(P_0 is zxfVbgHuUENUKCssHNFuiFYmbBAj))
		{
			return false;
		}
		return Equals((zxfVbgHuUENUKCssHNFuiFYmbBAj)P_0);
	}

	public int tfNspIxMomycsKfBUrQzfBbacFdQ()
	{
		return (((17 * 29 + DYmNLHpdUfvjIyPyEOUhVDkihJgl.GetHashCode()) * 29 + WvmgVaKJAFHrtHqgqbOzHSQKKvUUb.GetHashCode()) * 29 + AUrvsVAbJZFXGamesdJxInFzZlXL.GetHashCode()) * 29 + MROwmeehhXXgkdTHszQEYoiWUJsJ.GetHashCode();
	}

	[SpecialName]
	public static bool ritJAyRxXNhtZasPYATZBMgCaRNbA(zxfVbgHuUENUKCssHNFuiFYmbBAj P_0, zxfVbgHuUENUKCssHNFuiFYmbBAj P_1)
	{
		if (P_0.DYmNLHpdUfvjIyPyEOUhVDkihJgl == P_1.DYmNLHpdUfvjIyPyEOUhVDkihJgl && P_0.WvmgVaKJAFHrtHqgqbOzHSQKKvUUb == P_1.WvmgVaKJAFHrtHqgqbOzHSQKKvUUb && P_0.AUrvsVAbJZFXGamesdJxInFzZlXL == P_1.AUrvsVAbJZFXGamesdJxInFzZlXL)
		{
			return P_0.MROwmeehhXXgkdTHszQEYoiWUJsJ == P_1.MROwmeehhXXgkdTHszQEYoiWUJsJ;
		}
		return false;
	}

	[SpecialName]
	public static bool hnZcLYuHBwewphPgxiBwLTVSqbjq(zxfVbgHuUENUKCssHNFuiFYmbBAj P_0, zxfVbgHuUENUKCssHNFuiFYmbBAj P_1)
	{
		return !ritJAyRxXNhtZasPYATZBMgCaRNbA(P_0, P_1);
	}
}
