using System;
using System.Runtime.CompilerServices;

internal class xARIgSRqIQgbRdkBdnwpgUwwtJmcA : IEquatable<xARIgSRqIQgbRdkBdnwpgUwwtJmcA>
{
	private IntPtr bFpXhQZJupMPuFfMjbnhHrOsePpgb;

	public IntPtr GtFTvfgmMdcpqKtBhuEwpBxkHNOSA => bFpXhQZJupMPuFfMjbnhHrOsePpgb;

	public bool UXUHXpHHZSqFSTAUwYxXJJMKwDDR => bFpXhQZJupMPuFfMjbnhHrOsePpgb != IntPtr.Zero;

	public xARIgSRqIQgbRdkBdnwpgUwwtJmcA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentException("srcPtr cannot be IntPtr.Zero");
		}
		bFpXhQZJupMPuFfMjbnhHrOsePpgb = P_0;
	}

	public virtual bool YuXVjXFtOlcYdBBMJNDaERCdgwZA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!(P_0 is xARIgSRqIQgbRdkBdnwpgUwwtJmcA))
		{
			return false;
		}
		return ((xARIgSRqIQgbRdkBdnwpgUwwtJmcA)P_0).bFpXhQZJupMPuFfMjbnhHrOsePpgb == bFpXhQZJupMPuFfMjbnhHrOsePpgb;
	}

	public virtual int jqLzAERfWQwDQyoUcnPJaLAZvnwM()
	{
		return base.GetHashCode();
	}

	public bool Equals(xARIgSRqIQgbRdkBdnwpgUwwtJmcA other)
	{
		if (other == null)
		{
			return false;
		}
		return bFpXhQZJupMPuFfMjbnhHrOsePpgb == other.bFpXhQZJupMPuFfMjbnhHrOsePpgb;
	}

	bool IEquatable<xARIgSRqIQgbRdkBdnwpgUwwtJmcA>.Equals(xARIgSRqIQgbRdkBdnwpgUwwtJmcA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	[SpecialName]
	public static bool ZXxzGCiNQoeOpCuDTnfKWXqlgHRmA(xARIgSRqIQgbRdkBdnwpgUwwtJmcA P_0, xARIgSRqIQgbRdkBdnwpgUwwtJmcA P_1)
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
	public static bool axBNHbIQUODeeVetkfUaCxXZYcVM(xARIgSRqIQgbRdkBdnwpgUwwtJmcA P_0, xARIgSRqIQgbRdkBdnwpgUwwtJmcA P_1)
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
