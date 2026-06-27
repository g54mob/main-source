using System;
using System.Runtime.CompilerServices;

internal class jYwNOUTGZCVFxAeQPEEzLFOrjZQn : IEquatable<jYwNOUTGZCVFxAeQPEEzLFOrjZQn>
{
	private IntPtr tCOfMWNFllRjQzzFTKDnqMghVJBV;

	public IntPtr QokGQjcgFrKLADCILpmwUGLhwNau => tCOfMWNFllRjQzzFTKDnqMghVJBV;

	public bool KLbyMtLOVSvxctZMSXfNUEgNBrvf => tCOfMWNFllRjQzzFTKDnqMghVJBV != IntPtr.Zero;

	public jYwNOUTGZCVFxAeQPEEzLFOrjZQn(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentException("srcPtr cannot be IntPtr.Zero");
		}
		tCOfMWNFllRjQzzFTKDnqMghVJBV = P_0;
	}

	public virtual bool EeFmsnNTiERSahmYodlPjNnPUoAlA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!(P_0 is jYwNOUTGZCVFxAeQPEEzLFOrjZQn))
		{
			return false;
		}
		return ((jYwNOUTGZCVFxAeQPEEzLFOrjZQn)P_0).tCOfMWNFllRjQzzFTKDnqMghVJBV == tCOfMWNFllRjQzzFTKDnqMghVJBV;
	}

	public virtual int nXmzTSHGJCHvkGDJYDfHClqCwvSBA()
	{
		return base.GetHashCode();
	}

	public bool Equals(jYwNOUTGZCVFxAeQPEEzLFOrjZQn other)
	{
		if (other == null)
		{
			return false;
		}
		return tCOfMWNFllRjQzzFTKDnqMghVJBV == other.tCOfMWNFllRjQzzFTKDnqMghVJBV;
	}

	bool IEquatable<jYwNOUTGZCVFxAeQPEEzLFOrjZQn>.Equals(jYwNOUTGZCVFxAeQPEEzLFOrjZQn other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	[SpecialName]
	public static bool ZfEcnEcsPmAgDYPSxyTUUiKyjVbq(jYwNOUTGZCVFxAeQPEEzLFOrjZQn P_0, jYwNOUTGZCVFxAeQPEEzLFOrjZQn P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return true;
		}
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool cjiqFpIJYIOYRjoySkkhNxRKmjJc(jYwNOUTGZCVFxAeQPEEzLFOrjZQn P_0, jYwNOUTGZCVFxAeQPEEzLFOrjZQn P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return false;
		}
		if (P_0 == null || P_1 == null)
		{
			return true;
		}
		return !P_0.Equals(P_1);
	}
}
