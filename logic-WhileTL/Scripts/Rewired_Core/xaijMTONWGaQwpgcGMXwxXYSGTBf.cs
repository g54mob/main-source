using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct xaijMTONWGaQwpgcGMXwxXYSGTBf : IEquatable<xaijMTONWGaQwpgcGMXwxXYSGTBf>
{
	public ModifierKey nzfZvDQnXKqkICFGlyOrPWOlmguD;

	public ModifierKey YTTRFWBQsmcWJbGBSbSislQmCzHgA;

	public ModifierKey cEzMDCmFUSaoGnwAGIGDxrRWOOsj;

	private ModifierKey eLqQPipDQCccAcJjGtKnPvdLRJXEb
	{
		get
		{
			if (P_0 <= 0)
			{
				return nzfZvDQnXKqkICFGlyOrPWOlmguD;
			}
			if (P_0 == 1)
			{
				return YTTRFWBQsmcWJbGBSbSislQmCzHgA;
			}
			if (P_0 >= 2)
			{
				return cEzMDCmFUSaoGnwAGIGDxrRWOOsj;
			}
			return nzfZvDQnXKqkICFGlyOrPWOlmguD;
		}
		set
		{
			if (num <= 0)
			{
				nzfZvDQnXKqkICFGlyOrPWOlmguD = yTTRFWBQsmcWJbGBSbSislQmCzHgA;
			}
			if (num == 1)
			{
				YTTRFWBQsmcWJbGBSbSislQmCzHgA = yTTRFWBQsmcWJbGBSbSislQmCzHgA;
			}
			if (num >= 2)
			{
				cEzMDCmFUSaoGnwAGIGDxrRWOOsj = yTTRFWBQsmcWJbGBSbSislQmCzHgA;
			}
		}
	}

	public xaijMTONWGaQwpgcGMXwxXYSGTBf(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		nzfZvDQnXKqkICFGlyOrPWOlmguD = P_0;
		YTTRFWBQsmcWJbGBSbSislQmCzHgA = P_1;
		cEzMDCmFUSaoGnwAGIGDxrRWOOsj = P_2;
	}

	public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
	{
		if (nzfZvDQnXKqkICFGlyOrPWOlmguD != ModifierKey.None)
		{
			nzfZvDQnXKqkICFGlyOrPWOlmguD = ModifierKey.None;
		}
		if (YTTRFWBQsmcWJbGBSbSislQmCzHgA != ModifierKey.None)
		{
			YTTRFWBQsmcWJbGBSbSislQmCzHgA = ModifierKey.None;
		}
		if (cEzMDCmFUSaoGnwAGIGDxrRWOOsj != ModifierKey.None)
		{
			cEzMDCmFUSaoGnwAGIGDxrRWOOsj = ModifierKey.None;
		}
	}

	public static xaijMTONWGaQwpgcGMXwxXYSGTBf NTxAmacLUGlIUyGmoNWhlsCBEOtgA(ModifierKeyFlags P_0)
	{
		xaijMTONWGaQwpgcGMXwxXYSGTBf result = default(xaijMTONWGaQwpgcGMXwxXYSGTBf);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.CEkjJwEANSHRnNEqjEVVvXjmvXjt(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.CEkjJwEANSHRnNEqjEVVvXjmvXjt(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.CEkjJwEANSHRnNEqjEVVvXjmvXjt(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.CEkjJwEANSHRnNEqjEVVvXjmvXjt(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(xaijMTONWGaQwpgcGMXwxXYSGTBf other)
	{
		if (nzfZvDQnXKqkICFGlyOrPWOlmguD == other.nzfZvDQnXKqkICFGlyOrPWOlmguD && YTTRFWBQsmcWJbGBSbSislQmCzHgA == other.YTTRFWBQsmcWJbGBSbSislQmCzHgA)
		{
			return cEzMDCmFUSaoGnwAGIGDxrRWOOsj == other.cEzMDCmFUSaoGnwAGIGDxrRWOOsj;
		}
		return false;
	}

	public bool TvJQzMlVPLhyIecdRkvLnWEMaWmi(object P_0)
	{
		if (P_0 == null || !(P_0 is xaijMTONWGaQwpgcGMXwxXYSGTBf))
		{
			return false;
		}
		return Equals((xaijMTONWGaQwpgcGMXwxXYSGTBf)P_0);
	}

	public int jROUJCkrZlfAQIulVmsymiTeCVVw()
	{
		return ((17 * 29 + nzfZvDQnXKqkICFGlyOrPWOlmguD.GetHashCode()) * 29 + YTTRFWBQsmcWJbGBSbSislQmCzHgA.GetHashCode()) * 29 + cEzMDCmFUSaoGnwAGIGDxrRWOOsj.GetHashCode();
	}

	[SpecialName]
	public static bool UMllGJHDplfJjbuFOEqrrpEyJqjfb(xaijMTONWGaQwpgcGMXwxXYSGTBf P_0, xaijMTONWGaQwpgcGMXwxXYSGTBf P_1)
	{
		if (P_0.nzfZvDQnXKqkICFGlyOrPWOlmguD == P_1.nzfZvDQnXKqkICFGlyOrPWOlmguD && P_0.YTTRFWBQsmcWJbGBSbSislQmCzHgA == P_1.YTTRFWBQsmcWJbGBSbSislQmCzHgA)
		{
			return P_0.cEzMDCmFUSaoGnwAGIGDxrRWOOsj == P_1.cEzMDCmFUSaoGnwAGIGDxrRWOOsj;
		}
		return false;
	}

	[SpecialName]
	public static bool kxLIeKMQgrsHFQBkrSwwqokvfUIi(xaijMTONWGaQwpgcGMXwxXYSGTBf P_0, xaijMTONWGaQwpgcGMXwxXYSGTBf P_1)
	{
		return !UMllGJHDplfJjbuFOEqrrpEyJqjfb(P_0, P_1);
	}
}
