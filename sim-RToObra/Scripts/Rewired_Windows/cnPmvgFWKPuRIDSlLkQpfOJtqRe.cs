using System;
using System.Globalization;

internal struct cnPmvgFWKPuRIDSlLkQpfOJtqRe
{
	private IntPtr XVnIVwOfVXTkdEoDpphKDCMddTX;

	public static readonly cnPmvgFWKPuRIDSlLkQpfOJtqRe rMIFSTyyRdDLwOqbnprfBfzxivL = new cnPmvgFWKPuRIDSlLkQpfOJtqRe(0);

	public cnPmvgFWKPuRIDSlLkQpfOJtqRe(IntPtr size)
	{
		XVnIVwOfVXTkdEoDpphKDCMddTX = size;
	}

	private unsafe cnPmvgFWKPuRIDSlLkQpfOJtqRe(void* size)
	{
		XVnIVwOfVXTkdEoDpphKDCMddTX = new IntPtr(size);
	}

	public cnPmvgFWKPuRIDSlLkQpfOJtqRe(int size)
	{
		XVnIVwOfVXTkdEoDpphKDCMddTX = new IntPtr(size);
	}

	public cnPmvgFWKPuRIDSlLkQpfOJtqRe(long size)
	{
		XVnIVwOfVXTkdEoDpphKDCMddTX = new IntPtr(size);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", XVnIVwOfVXTkdEoDpphKDCMddTX);
	}

	public string yRtDbyVDfwgkaXWMVmTyFkjlBxN(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", XVnIVwOfVXTkdEoDpphKDCMddTX.ToString(P_0));
	}

	public override int GetHashCode()
	{
		return XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt32();
	}

	public bool toLtuUpVSfLorNAOBqtEBqxdEiK(cnPmvgFWKPuRIDSlLkQpfOJtqRe P_0)
	{
		return XVnIVwOfVXTkdEoDpphKDCMddTX == P_0.XVnIVwOfVXTkdEoDpphKDCMddTX;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!object.ReferenceEquals(value.GetType(), typeof(cnPmvgFWKPuRIDSlLkQpfOJtqRe)))
		{
			return false;
		}
		return toLtuUpVSfLorNAOBqtEBqxdEiK((cnPmvgFWKPuRIDSlLkQpfOJtqRe)value);
	}

	public static cnPmvgFWKPuRIDSlLkQpfOJtqRe operator +(cnPmvgFWKPuRIDSlLkQpfOJtqRe left, cnPmvgFWKPuRIDSlLkQpfOJtqRe right)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(left.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt64() + right.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt64());
	}

	public static cnPmvgFWKPuRIDSlLkQpfOJtqRe operator +(cnPmvgFWKPuRIDSlLkQpfOJtqRe value)
	{
		return value;
	}

	public static cnPmvgFWKPuRIDSlLkQpfOJtqRe operator -(cnPmvgFWKPuRIDSlLkQpfOJtqRe left, cnPmvgFWKPuRIDSlLkQpfOJtqRe right)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(left.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt64() - right.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt64());
	}

	public static cnPmvgFWKPuRIDSlLkQpfOJtqRe operator -(cnPmvgFWKPuRIDSlLkQpfOJtqRe value)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(-value.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt64());
	}

	public static cnPmvgFWKPuRIDSlLkQpfOJtqRe operator *(int scale, cnPmvgFWKPuRIDSlLkQpfOJtqRe value)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(scale * value.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt64());
	}

	public static cnPmvgFWKPuRIDSlLkQpfOJtqRe operator *(cnPmvgFWKPuRIDSlLkQpfOJtqRe value, int scale)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(scale * value.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt64());
	}

	public static cnPmvgFWKPuRIDSlLkQpfOJtqRe operator /(cnPmvgFWKPuRIDSlLkQpfOJtqRe value, int scale)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(value.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt64() / scale);
	}

	public static bool operator ==(cnPmvgFWKPuRIDSlLkQpfOJtqRe left, cnPmvgFWKPuRIDSlLkQpfOJtqRe right)
	{
		return left.toLtuUpVSfLorNAOBqtEBqxdEiK(right);
	}

	public static bool operator !=(cnPmvgFWKPuRIDSlLkQpfOJtqRe left, cnPmvgFWKPuRIDSlLkQpfOJtqRe right)
	{
		return !left.toLtuUpVSfLorNAOBqtEBqxdEiK(right);
	}

	public static implicit operator int(cnPmvgFWKPuRIDSlLkQpfOJtqRe value)
	{
		return value.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt32();
	}

	public static implicit operator long(cnPmvgFWKPuRIDSlLkQpfOJtqRe value)
	{
		return value.XVnIVwOfVXTkdEoDpphKDCMddTX.ToInt64();
	}

	public static implicit operator cnPmvgFWKPuRIDSlLkQpfOJtqRe(int value)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(value);
	}

	public static implicit operator cnPmvgFWKPuRIDSlLkQpfOJtqRe(long value)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(value);
	}

	public static implicit operator cnPmvgFWKPuRIDSlLkQpfOJtqRe(IntPtr value)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(value);
	}

	public static implicit operator IntPtr(cnPmvgFWKPuRIDSlLkQpfOJtqRe value)
	{
		return value.XVnIVwOfVXTkdEoDpphKDCMddTX;
	}

	public unsafe static implicit operator cnPmvgFWKPuRIDSlLkQpfOJtqRe(void* value)
	{
		return new cnPmvgFWKPuRIDSlLkQpfOJtqRe(value);
	}

	public unsafe static implicit operator void*(cnPmvgFWKPuRIDSlLkQpfOJtqRe value)
	{
		return (void*)value.XVnIVwOfVXTkdEoDpphKDCMddTX;
	}
}
