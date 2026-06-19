using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct hGiuMJygNZCtXeTXrjpnhYdAHitdc : IEquatable<hGiuMJygNZCtXeTXrjpnhYdAHitdc>
{
	public KeyboardKeyCode FhrbQqASlulJXIfTyHiyArVTvaBuA;

	public ModifierKey OgnCNNlxtOVEalRDScywcSpxiZdG;

	public ModifierKey INaAmeCzwAitPadVYkHgMeaOqWsdA;

	public ModifierKey ALTBfZiPEIelrxkwKjJPMuVtJPRSA;

	public hGiuMJygNZCtXeTXrjpnhYdAHitdc(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3)
	{
		FhrbQqASlulJXIfTyHiyArVTvaBuA = P_0;
		OgnCNNlxtOVEalRDScywcSpxiZdG = P_1;
		INaAmeCzwAitPadVYkHgMeaOqWsdA = P_2;
		ALTBfZiPEIelrxkwKjJPMuVtJPRSA = P_3;
	}

	public void vYeaggGFNOARsGnJHlDtutlmOFIqB()
	{
		if (FhrbQqASlulJXIfTyHiyArVTvaBuA != KeyboardKeyCode.None)
		{
			FhrbQqASlulJXIfTyHiyArVTvaBuA = KeyboardKeyCode.None;
		}
		if (OgnCNNlxtOVEalRDScywcSpxiZdG != ModifierKey.None)
		{
			OgnCNNlxtOVEalRDScywcSpxiZdG = ModifierKey.None;
		}
		if (INaAmeCzwAitPadVYkHgMeaOqWsdA != ModifierKey.None)
		{
			INaAmeCzwAitPadVYkHgMeaOqWsdA = ModifierKey.None;
		}
		if (ALTBfZiPEIelrxkwKjJPMuVtJPRSA != ModifierKey.None)
		{
			ALTBfZiPEIelrxkwKjJPMuVtJPRSA = ModifierKey.None;
		}
	}

	public bool Equals(hGiuMJygNZCtXeTXrjpnhYdAHitdc other)
	{
		if (FhrbQqASlulJXIfTyHiyArVTvaBuA == other.FhrbQqASlulJXIfTyHiyArVTvaBuA && OgnCNNlxtOVEalRDScywcSpxiZdG == other.OgnCNNlxtOVEalRDScywcSpxiZdG && INaAmeCzwAitPadVYkHgMeaOqWsdA == other.INaAmeCzwAitPadVYkHgMeaOqWsdA)
		{
			return ALTBfZiPEIelrxkwKjJPMuVtJPRSA == other.ALTBfZiPEIelrxkwKjJPMuVtJPRSA;
		}
		return false;
	}

	bool IEquatable<hGiuMJygNZCtXeTXrjpnhYdAHitdc>.Equals(hGiuMJygNZCtXeTXrjpnhYdAHitdc other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool eSmeLsMudYFBrARmXmqJesUlkGJGb(object P_0)
	{
		if (P_0 == null || !(P_0 is hGiuMJygNZCtXeTXrjpnhYdAHitdc))
		{
			return false;
		}
		return Equals((hGiuMJygNZCtXeTXrjpnhYdAHitdc)P_0);
	}

	public int twMgpbKrXhIhrPayoaZiRsUJQQCv()
	{
		return (((17 * 29 + FhrbQqASlulJXIfTyHiyArVTvaBuA.GetHashCode()) * 29 + OgnCNNlxtOVEalRDScywcSpxiZdG.GetHashCode()) * 29 + INaAmeCzwAitPadVYkHgMeaOqWsdA.GetHashCode()) * 29 + ALTBfZiPEIelrxkwKjJPMuVtJPRSA.GetHashCode();
	}

	[SpecialName]
	public static bool nyyNVHojaKNlKzoiyhKWraPrWgkk(hGiuMJygNZCtXeTXrjpnhYdAHitdc P_0, hGiuMJygNZCtXeTXrjpnhYdAHitdc P_1)
	{
		if (P_0.FhrbQqASlulJXIfTyHiyArVTvaBuA == P_1.FhrbQqASlulJXIfTyHiyArVTvaBuA && P_0.OgnCNNlxtOVEalRDScywcSpxiZdG == P_1.OgnCNNlxtOVEalRDScywcSpxiZdG && P_0.INaAmeCzwAitPadVYkHgMeaOqWsdA == P_1.INaAmeCzwAitPadVYkHgMeaOqWsdA)
		{
			return P_0.ALTBfZiPEIelrxkwKjJPMuVtJPRSA == P_1.ALTBfZiPEIelrxkwKjJPMuVtJPRSA;
		}
		return false;
	}

	[SpecialName]
	public static bool bXGlAzJnqvgOaBgZTlprmpstVkEHA(hGiuMJygNZCtXeTXrjpnhYdAHitdc P_0, hGiuMJygNZCtXeTXrjpnhYdAHitdc P_1)
	{
		return !nyyNVHojaKNlKzoiyhKWraPrWgkk(P_0, P_1);
	}
}
