using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct DKOWFwZLYxzTvGcIpcEhZRAXgkcF : IEquatable<DKOWFwZLYxzTvGcIpcEhZRAXgkcF>
{
	public KeyboardKeyCode KLbheRHnVAOFPkpbjxXNDdCXRyFN;

	public ModifierKey nzfZvDQnXKqkICFGlyOrPWOlmguD;

	public ModifierKey YTTRFWBQsmcWJbGBSbSislQmCzHgA;

	public ModifierKey cEzMDCmFUSaoGnwAGIGDxrRWOOsj;

	public DKOWFwZLYxzTvGcIpcEhZRAXgkcF(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3)
	{
		KLbheRHnVAOFPkpbjxXNDdCXRyFN = P_0;
		nzfZvDQnXKqkICFGlyOrPWOlmguD = P_1;
		YTTRFWBQsmcWJbGBSbSislQmCzHgA = P_2;
		cEzMDCmFUSaoGnwAGIGDxrRWOOsj = P_3;
	}

	public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
	{
		if (KLbheRHnVAOFPkpbjxXNDdCXRyFN != KeyboardKeyCode.None)
		{
			KLbheRHnVAOFPkpbjxXNDdCXRyFN = KeyboardKeyCode.None;
		}
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

	public bool Equals(DKOWFwZLYxzTvGcIpcEhZRAXgkcF other)
	{
		if (KLbheRHnVAOFPkpbjxXNDdCXRyFN == other.KLbheRHnVAOFPkpbjxXNDdCXRyFN && nzfZvDQnXKqkICFGlyOrPWOlmguD == other.nzfZvDQnXKqkICFGlyOrPWOlmguD && YTTRFWBQsmcWJbGBSbSislQmCzHgA == other.YTTRFWBQsmcWJbGBSbSislQmCzHgA)
		{
			return cEzMDCmFUSaoGnwAGIGDxrRWOOsj == other.cEzMDCmFUSaoGnwAGIGDxrRWOOsj;
		}
		return false;
	}

	public bool TvJQzMlVPLhyIecdRkvLnWEMaWmi(object P_0)
	{
		if (P_0 == null || !(P_0 is DKOWFwZLYxzTvGcIpcEhZRAXgkcF))
		{
			return false;
		}
		return Equals((DKOWFwZLYxzTvGcIpcEhZRAXgkcF)P_0);
	}

	public int jROUJCkrZlfAQIulVmsymiTeCVVw()
	{
		return (((17 * 29 + KLbheRHnVAOFPkpbjxXNDdCXRyFN.GetHashCode()) * 29 + nzfZvDQnXKqkICFGlyOrPWOlmguD.GetHashCode()) * 29 + YTTRFWBQsmcWJbGBSbSislQmCzHgA.GetHashCode()) * 29 + cEzMDCmFUSaoGnwAGIGDxrRWOOsj.GetHashCode();
	}

	[SpecialName]
	public static bool UMllGJHDplfJjbuFOEqrrpEyJqjfb(DKOWFwZLYxzTvGcIpcEhZRAXgkcF P_0, DKOWFwZLYxzTvGcIpcEhZRAXgkcF P_1)
	{
		if (P_0.KLbheRHnVAOFPkpbjxXNDdCXRyFN == P_1.KLbheRHnVAOFPkpbjxXNDdCXRyFN && P_0.nzfZvDQnXKqkICFGlyOrPWOlmguD == P_1.nzfZvDQnXKqkICFGlyOrPWOlmguD && P_0.YTTRFWBQsmcWJbGBSbSislQmCzHgA == P_1.YTTRFWBQsmcWJbGBSbSislQmCzHgA)
		{
			return P_0.cEzMDCmFUSaoGnwAGIGDxrRWOOsj == P_1.cEzMDCmFUSaoGnwAGIGDxrRWOOsj;
		}
		return false;
	}

	[SpecialName]
	public static bool kxLIeKMQgrsHFQBkrSwwqokvfUIi(DKOWFwZLYxzTvGcIpcEhZRAXgkcF P_0, DKOWFwZLYxzTvGcIpcEhZRAXgkcF P_1)
	{
		return !UMllGJHDplfJjbuFOEqrrpEyJqjfb(P_0, P_1);
	}
}
