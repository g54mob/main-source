using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct gKQaduAqSOGwbLhlzfnbbSwcienb : IEquatable<gKQaduAqSOGwbLhlzfnbbSwcienb>
{
	private int HyXQDhXIhmBwtUdzivGPkeTxLxb;

	public gKQaduAqSOGwbLhlzfnbbSwcienb(bool boolValue)
	{
		HyXQDhXIhmBwtUdzivGPkeTxLxb = (boolValue ? 1 : 0);
	}

	public bool Equals(gKQaduAqSOGwbLhlzfnbbSwcienb other)
	{
		return HyXQDhXIhmBwtUdzivGPkeTxLxb == other.HyXQDhXIhmBwtUdzivGPkeTxLxb;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (obj is gKQaduAqSOGwbLhlzfnbbSwcienb)
		{
			return Equals((gKQaduAqSOGwbLhlzfnbbSwcienb)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HyXQDhXIhmBwtUdzivGPkeTxLxb;
	}

	public static bool operator ==(gKQaduAqSOGwbLhlzfnbbSwcienb left, gKQaduAqSOGwbLhlzfnbbSwcienb right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(gKQaduAqSOGwbLhlzfnbbSwcienb left, gKQaduAqSOGwbLhlzfnbbSwcienb right)
	{
		return !left.Equals(right);
	}

	public static implicit operator bool(gKQaduAqSOGwbLhlzfnbbSwcienb booleanValue)
	{
		return booleanValue.HyXQDhXIhmBwtUdzivGPkeTxLxb != 0;
	}

	public static implicit operator gKQaduAqSOGwbLhlzfnbbSwcienb(bool boolValue)
	{
		return new gKQaduAqSOGwbLhlzfnbbSwcienb(boolValue);
	}

	public override string ToString()
	{
		return $"{HyXQDhXIhmBwtUdzivGPkeTxLxb != 0}";
	}
}
