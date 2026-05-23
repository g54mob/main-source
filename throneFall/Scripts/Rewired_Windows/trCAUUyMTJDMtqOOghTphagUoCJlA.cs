using System;
using System.Runtime.CompilerServices;

internal class trCAUUyMTJDMtqOOghTphagUoCJlA : IEquatable<trCAUUyMTJDMtqOOghTphagUoCJlA>
{
	private IntPtr bsuTgCcGnaoOGNTSiIIvBbQCAOSj;

	public IntPtr QdUTNzZPdgWbShApevfibcvGGmji => bsuTgCcGnaoOGNTSiIIvBbQCAOSj;

	public bool IjZbpjaBMJrgoZONxRKNxQAeqUwM => bsuTgCcGnaoOGNTSiIIvBbQCAOSj != IntPtr.Zero;

	public trCAUUyMTJDMtqOOghTphagUoCJlA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentException("srcPtr cannot be IntPtr.Zero");
		}
		bsuTgCcGnaoOGNTSiIIvBbQCAOSj = P_0;
	}

	public virtual bool OOvcpnkouPFPksRQZBwDlcFmzbFmA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!(P_0 is trCAUUyMTJDMtqOOghTphagUoCJlA))
		{
			return false;
		}
		return ((trCAUUyMTJDMtqOOghTphagUoCJlA)P_0).bsuTgCcGnaoOGNTSiIIvBbQCAOSj == bsuTgCcGnaoOGNTSiIIvBbQCAOSj;
	}

	public virtual int nUGeKYsdPFelcyHLzyoPCVSjsDLH()
	{
		return base.GetHashCode();
	}

	public bool Equals(trCAUUyMTJDMtqOOghTphagUoCJlA other)
	{
		if (other == null)
		{
			return false;
		}
		return bsuTgCcGnaoOGNTSiIIvBbQCAOSj == other.bsuTgCcGnaoOGNTSiIIvBbQCAOSj;
	}

	bool IEquatable<trCAUUyMTJDMtqOOghTphagUoCJlA>.Equals(trCAUUyMTJDMtqOOghTphagUoCJlA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	[SpecialName]
	public static bool BiuaHYTZipbbNwHCUMAIrOoBKqkJ(trCAUUyMTJDMtqOOghTphagUoCJlA P_0, trCAUUyMTJDMtqOOghTphagUoCJlA P_1)
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
	public static bool wfSzDfbiHFHHERSslotkqsNdGpiP(trCAUUyMTJDMtqOOghTphagUoCJlA P_0, trCAUUyMTJDMtqOOghTphagUoCJlA P_1)
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
