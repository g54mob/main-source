using System;

internal struct gtvWtiZMRCqkFBbmWIWmYwnkIAiH : IEquatable<gtvWtiZMRCqkFBbmWIWmYwnkIAiH>
{
	public static readonly gtvWtiZMRCqkFBbmWIWmYwnkIAiH mlHwKYEqjUXizzlBBRzwZZoggsm = new gtvWtiZMRCqkFBbmWIWmYwnkIAiH(0f, 0f);

	public static readonly gtvWtiZMRCqkFBbmWIWmYwnkIAiH XyYaPHDqLlsQUwLUOYaXzDXevXl = mlHwKYEqjUXizzlBBRzwZZoggsm;

	public float XVmTnCLlrQbTubpRSjRvTRrxzEWd;

	public float hxcLeAFGkKKZrEJuoceMBiBealeC;

	public gtvWtiZMRCqkFBbmWIWmYwnkIAiH(float width, float height)
	{
		XVmTnCLlrQbTubpRSjRvTRrxzEWd = width;
		hxcLeAFGkKKZrEJuoceMBiBealeC = height;
	}

	public bool Equals(gtvWtiZMRCqkFBbmWIWmYwnkIAiH other)
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
		if ((object)obj.GetType() != typeof(gtvWtiZMRCqkFBbmWIWmYwnkIAiH))
		{
			return false;
		}
		return Equals((gtvWtiZMRCqkFBbmWIWmYwnkIAiH)obj);
	}

	public override int GetHashCode()
	{
		return (XVmTnCLlrQbTubpRSjRvTRrxzEWd.GetHashCode() * 397) ^ hxcLeAFGkKKZrEJuoceMBiBealeC.GetHashCode();
	}

	public static bool operator ==(gtvWtiZMRCqkFBbmWIWmYwnkIAiH left, gtvWtiZMRCqkFBbmWIWmYwnkIAiH right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(gtvWtiZMRCqkFBbmWIWmYwnkIAiH left, gtvWtiZMRCqkFBbmWIWmYwnkIAiH right)
	{
		return !left.Equals(right);
	}

	public override string ToString()
	{
		return $"({XVmTnCLlrQbTubpRSjRvTRrxzEWd},{hxcLeAFGkKKZrEJuoceMBiBealeC})";
	}
}
