using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct puuEacUIpuAuVMUfhcojUiqxRNuy : IEquatable<puuEacUIpuAuVMUfhcojUiqxRNuy>
{
	public KeyboardKeyCode TvjdQNqGVBrMNinrcGbilRErlPGt;

	public ModifierKey IsdxUuNhHpVQgeXvSbzegHaNPsyL;

	public ModifierKey EbuDoRNkGlGaVKafUPYwcuhylhdCA;

	public ModifierKey QyZchyvfyfoydpzKWPYLwhGRMiOW;

	public puuEacUIpuAuVMUfhcojUiqxRNuy(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3)
	{
		TvjdQNqGVBrMNinrcGbilRErlPGt = P_0;
		IsdxUuNhHpVQgeXvSbzegHaNPsyL = P_1;
		EbuDoRNkGlGaVKafUPYwcuhylhdCA = P_2;
		QyZchyvfyfoydpzKWPYLwhGRMiOW = P_3;
	}

	public void bswBiVrQhbGTgcGzpdMjlPymUgJW()
	{
		if (TvjdQNqGVBrMNinrcGbilRErlPGt != KeyboardKeyCode.None)
		{
			TvjdQNqGVBrMNinrcGbilRErlPGt = KeyboardKeyCode.None;
		}
		if (IsdxUuNhHpVQgeXvSbzegHaNPsyL != ModifierKey.None)
		{
			IsdxUuNhHpVQgeXvSbzegHaNPsyL = ModifierKey.None;
		}
		if (EbuDoRNkGlGaVKafUPYwcuhylhdCA != ModifierKey.None)
		{
			EbuDoRNkGlGaVKafUPYwcuhylhdCA = ModifierKey.None;
		}
		if (QyZchyvfyfoydpzKWPYLwhGRMiOW != ModifierKey.None)
		{
			QyZchyvfyfoydpzKWPYLwhGRMiOW = ModifierKey.None;
		}
	}

	public bool Equals(puuEacUIpuAuVMUfhcojUiqxRNuy other)
	{
		if (TvjdQNqGVBrMNinrcGbilRErlPGt == other.TvjdQNqGVBrMNinrcGbilRErlPGt && IsdxUuNhHpVQgeXvSbzegHaNPsyL == other.IsdxUuNhHpVQgeXvSbzegHaNPsyL && EbuDoRNkGlGaVKafUPYwcuhylhdCA == other.EbuDoRNkGlGaVKafUPYwcuhylhdCA)
		{
			return QyZchyvfyfoydpzKWPYLwhGRMiOW == other.QyZchyvfyfoydpzKWPYLwhGRMiOW;
		}
		return false;
	}

	bool IEquatable<puuEacUIpuAuVMUfhcojUiqxRNuy>.Equals(puuEacUIpuAuVMUfhcojUiqxRNuy other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool qymaNRmZXzIUvYmUTChJJcPRorKDb(object P_0)
	{
		if (P_0 == null || !(P_0 is puuEacUIpuAuVMUfhcojUiqxRNuy))
		{
			return false;
		}
		return Equals((puuEacUIpuAuVMUfhcojUiqxRNuy)P_0);
	}

	public int dIYdEBahpOTdqEOPuWkDTHWpzRtb()
	{
		return (((17 * 29 + TvjdQNqGVBrMNinrcGbilRErlPGt.GetHashCode()) * 29 + IsdxUuNhHpVQgeXvSbzegHaNPsyL.GetHashCode()) * 29 + EbuDoRNkGlGaVKafUPYwcuhylhdCA.GetHashCode()) * 29 + QyZchyvfyfoydpzKWPYLwhGRMiOW.GetHashCode();
	}

	[SpecialName]
	public static bool hfkyNoYtAfKKMcsWgSaUziEZGvxW(puuEacUIpuAuVMUfhcojUiqxRNuy P_0, puuEacUIpuAuVMUfhcojUiqxRNuy P_1)
	{
		if (P_0.TvjdQNqGVBrMNinrcGbilRErlPGt == P_1.TvjdQNqGVBrMNinrcGbilRErlPGt && P_0.IsdxUuNhHpVQgeXvSbzegHaNPsyL == P_1.IsdxUuNhHpVQgeXvSbzegHaNPsyL && P_0.EbuDoRNkGlGaVKafUPYwcuhylhdCA == P_1.EbuDoRNkGlGaVKafUPYwcuhylhdCA)
		{
			return P_0.QyZchyvfyfoydpzKWPYLwhGRMiOW == P_1.QyZchyvfyfoydpzKWPYLwhGRMiOW;
		}
		return false;
	}

	[SpecialName]
	public static bool hQOEnOzCGMThezPfJmWfhhvVPZXG(puuEacUIpuAuVMUfhcojUiqxRNuy P_0, puuEacUIpuAuVMUfhcojUiqxRNuy P_1)
	{
		return !hfkyNoYtAfKKMcsWgSaUziEZGvxW(P_0, P_1);
	}
}
