using System;
using System.Globalization;

internal struct eLjhMuojQzFDgfYcYzYZKFebPvJ
{
	private IntPtr RiJJwonoFtegPDbhiqPwweexFSgf;

	public static readonly eLjhMuojQzFDgfYcYzYZKFebPvJ dxogOPZTjJkMCZRqwHORwFHluia = new eLjhMuojQzFDgfYcYzYZKFebPvJ(0);

	public eLjhMuojQzFDgfYcYzYZKFebPvJ(IntPtr size)
	{
		RiJJwonoFtegPDbhiqPwweexFSgf = size;
	}

	private unsafe eLjhMuojQzFDgfYcYzYZKFebPvJ(void* size)
	{
		RiJJwonoFtegPDbhiqPwweexFSgf = new IntPtr(size);
	}

	public eLjhMuojQzFDgfYcYzYZKFebPvJ(int size)
	{
		RiJJwonoFtegPDbhiqPwweexFSgf = new IntPtr(size);
	}

	public eLjhMuojQzFDgfYcYzYZKFebPvJ(long size)
	{
		RiJJwonoFtegPDbhiqPwweexFSgf = new IntPtr(size);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { RiJJwonoFtegPDbhiqPwweexFSgf });
	}

	public string iSLKngyzvSeBOWhcUVCKwoJrNEm(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { RiJJwonoFtegPDbhiqPwweexFSgf.ToString(P_0) });
	}

	public override int GetHashCode()
	{
		return RiJJwonoFtegPDbhiqPwweexFSgf.ToInt32();
	}

	public bool lpfGDOSkHRGqZKIqCGEaicWfABrw(eLjhMuojQzFDgfYcYzYZKFebPvJ P_0)
	{
		return RiJJwonoFtegPDbhiqPwweexFSgf == P_0.RiJJwonoFtegPDbhiqPwweexFSgf;
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!object.ReferenceEquals(value.GetType(), typeof(eLjhMuojQzFDgfYcYzYZKFebPvJ)))
		{
			return false;
		}
		return lpfGDOSkHRGqZKIqCGEaicWfABrw((eLjhMuojQzFDgfYcYzYZKFebPvJ)value);
	}

	public static eLjhMuojQzFDgfYcYzYZKFebPvJ operator +(eLjhMuojQzFDgfYcYzYZKFebPvJ left, eLjhMuojQzFDgfYcYzYZKFebPvJ right)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(left.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt64() + right.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt64());
	}

	public static eLjhMuojQzFDgfYcYzYZKFebPvJ operator +(eLjhMuojQzFDgfYcYzYZKFebPvJ value)
	{
		return value;
	}

	public static eLjhMuojQzFDgfYcYzYZKFebPvJ operator -(eLjhMuojQzFDgfYcYzYZKFebPvJ left, eLjhMuojQzFDgfYcYzYZKFebPvJ right)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(left.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt64() - right.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt64());
	}

	public static eLjhMuojQzFDgfYcYzYZKFebPvJ operator -(eLjhMuojQzFDgfYcYzYZKFebPvJ value)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(-value.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt64());
	}

	public static eLjhMuojQzFDgfYcYzYZKFebPvJ operator *(int scale, eLjhMuojQzFDgfYcYzYZKFebPvJ value)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(scale * value.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt64());
	}

	public static eLjhMuojQzFDgfYcYzYZKFebPvJ operator *(eLjhMuojQzFDgfYcYzYZKFebPvJ value, int scale)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(scale * value.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt64());
	}

	public static eLjhMuojQzFDgfYcYzYZKFebPvJ operator /(eLjhMuojQzFDgfYcYzYZKFebPvJ value, int scale)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(value.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt64() / scale);
	}

	public static bool operator ==(eLjhMuojQzFDgfYcYzYZKFebPvJ left, eLjhMuojQzFDgfYcYzYZKFebPvJ right)
	{
		return left.lpfGDOSkHRGqZKIqCGEaicWfABrw(right);
	}

	public static bool operator !=(eLjhMuojQzFDgfYcYzYZKFebPvJ left, eLjhMuojQzFDgfYcYzYZKFebPvJ right)
	{
		return !left.lpfGDOSkHRGqZKIqCGEaicWfABrw(right);
	}

	public static implicit operator int(eLjhMuojQzFDgfYcYzYZKFebPvJ value)
	{
		return value.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt32();
	}

	public static implicit operator long(eLjhMuojQzFDgfYcYzYZKFebPvJ value)
	{
		return value.RiJJwonoFtegPDbhiqPwweexFSgf.ToInt64();
	}

	public static implicit operator eLjhMuojQzFDgfYcYzYZKFebPvJ(int value)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(value);
	}

	public static implicit operator eLjhMuojQzFDgfYcYzYZKFebPvJ(long value)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(value);
	}

	public static implicit operator eLjhMuojQzFDgfYcYzYZKFebPvJ(IntPtr value)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(value);
	}

	public static implicit operator IntPtr(eLjhMuojQzFDgfYcYzYZKFebPvJ value)
	{
		return value.RiJJwonoFtegPDbhiqPwweexFSgf;
	}

	public unsafe static implicit operator eLjhMuojQzFDgfYcYzYZKFebPvJ(void* value)
	{
		return new eLjhMuojQzFDgfYcYzYZKFebPvJ(value);
	}

	public unsafe static implicit operator void*(eLjhMuojQzFDgfYcYzYZKFebPvJ value)
	{
		return (void*)value.RiJJwonoFtegPDbhiqPwweexFSgf;
	}
}
