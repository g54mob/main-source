using System;

internal struct NthYJJdmVgKATgikKXnZnwwRHUk : IEquatable<NthYJJdmVgKATgikKXnZnwwRHUk>
{
	public static readonly NthYJJdmVgKATgikKXnZnwwRHUk mlHwKYEqjUXizzlBBRzwZZoggsm = new NthYJJdmVgKATgikKXnZnwwRHUk(0, 0);

	public static readonly NthYJJdmVgKATgikKXnZnwwRHUk XyYaPHDqLlsQUwLUOYaXzDXevXl = mlHwKYEqjUXizzlBBRzwZZoggsm;

	public int XVmTnCLlrQbTubpRSjRvTRrxzEWd;

	public int hxcLeAFGkKKZrEJuoceMBiBealeC;

	public NthYJJdmVgKATgikKXnZnwwRHUk(int width, int height)
	{
		XVmTnCLlrQbTubpRSjRvTRrxzEWd = width;
		hxcLeAFGkKKZrEJuoceMBiBealeC = height;
	}

	public bool Equals(NthYJJdmVgKATgikKXnZnwwRHUk other)
	{
		if (other.XVmTnCLlrQbTubpRSjRvTRrxzEWd == XVmTnCLlrQbTubpRSjRvTRrxzEWd)
		{
			return other.hxcLeAFGkKKZrEJuoceMBiBealeC == hxcLeAFGkKKZrEJuoceMBiBealeC;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(NthYJJdmVgKATgikKXnZnwwRHUk))
		{
			return false;
		}
		return Equals((NthYJJdmVgKATgikKXnZnwwRHUk)obj);
	}

	public override int GetHashCode()
	{
		return (XVmTnCLlrQbTubpRSjRvTRrxzEWd * 397) ^ hxcLeAFGkKKZrEJuoceMBiBealeC;
	}

	public static bool operator ==(NthYJJdmVgKATgikKXnZnwwRHUk left, NthYJJdmVgKATgikKXnZnwwRHUk right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(NthYJJdmVgKATgikKXnZnwwRHUk left, NthYJJdmVgKATgikKXnZnwwRHUk right)
	{
		return !left.Equals(right);
	}

	public override string ToString()
	{
		return $"({XVmTnCLlrQbTubpRSjRvTRrxzEWd},{hxcLeAFGkKKZrEJuoceMBiBealeC})";
	}
}
