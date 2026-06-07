using System;
using System.Runtime.CompilerServices;

internal class pOJFnGeJdiWQwmkAgmdJyuYyiIhd : IEquatable<pOJFnGeJdiWQwmkAgmdJyuYyiIhd>
{
	private IntPtr gpRRWpNgaNJmzGbrEaNwChwYyxtY;

	public IntPtr eRuooOpUXUMNyxAVfhJQXVsDGDql => gpRRWpNgaNJmzGbrEaNwChwYyxtY;

	public bool LOAKUriHGZEbByAroDTyQAHhOjqU => gpRRWpNgaNJmzGbrEaNwChwYyxtY != IntPtr.Zero;

	public pOJFnGeJdiWQwmkAgmdJyuYyiIhd(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentException("srcPtr cannot be IntPtr.Zero");
		}
		gpRRWpNgaNJmzGbrEaNwChwYyxtY = P_0;
	}

	public virtual bool JRxBWnhQlwwPGktFTDexAbegXFrzB(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!(P_0 is pOJFnGeJdiWQwmkAgmdJyuYyiIhd))
		{
			return false;
		}
		return ((pOJFnGeJdiWQwmkAgmdJyuYyiIhd)P_0).gpRRWpNgaNJmzGbrEaNwChwYyxtY == gpRRWpNgaNJmzGbrEaNwChwYyxtY;
	}

	public virtual int fEwcDhFDzGumYFCZRxsMimpbheAt()
	{
		return base.GetHashCode();
	}

	public bool Equals(pOJFnGeJdiWQwmkAgmdJyuYyiIhd other)
	{
		if (other == null)
		{
			return false;
		}
		return gpRRWpNgaNJmzGbrEaNwChwYyxtY == other.gpRRWpNgaNJmzGbrEaNwChwYyxtY;
	}

	[SpecialName]
	public static bool KnRQEmwHYQnLlhpqQiYLhcNhPfug(pOJFnGeJdiWQwmkAgmdJyuYyiIhd P_0, pOJFnGeJdiWQwmkAgmdJyuYyiIhd P_1)
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
	public static bool aVrCGbDxOYyGJCHKjqMUEaQwsGZeb(pOJFnGeJdiWQwmkAgmdJyuYyiIhd P_0, pOJFnGeJdiWQwmkAgmdJyuYyiIhd P_1)
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
