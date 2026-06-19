using System;

internal struct HrmeACHhkFViOCUaklECPkUAoFB : IEquatable<HrmeACHhkFViOCUaklECPkUAoFB>
{
	public static readonly HrmeACHhkFViOCUaklECPkUAoFB dxogOPZTjJkMCZRqwHORwFHluia = new HrmeACHhkFViOCUaklECPkUAoFB(0, 0);

	public int lSOdwKYaTJSJyAWJnADwkSPKwkp;

	public int ZqYMkLdonrbLPbHprxydzkIAizSD;

	public HrmeACHhkFViOCUaklECPkUAoFB(int x, int y)
	{
		lSOdwKYaTJSJyAWJnADwkSPKwkp = x;
		ZqYMkLdonrbLPbHprxydzkIAizSD = y;
	}

	public bool Equals(HrmeACHhkFViOCUaklECPkUAoFB other)
	{
		if (other.lSOdwKYaTJSJyAWJnADwkSPKwkp == lSOdwKYaTJSJyAWJnADwkSPKwkp)
		{
			return other.ZqYMkLdonrbLPbHprxydzkIAizSD == ZqYMkLdonrbLPbHprxydzkIAizSD;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(HrmeACHhkFViOCUaklECPkUAoFB))
		{
			return false;
		}
		return Equals((HrmeACHhkFViOCUaklECPkUAoFB)obj);
	}

	public override int GetHashCode()
	{
		return (lSOdwKYaTJSJyAWJnADwkSPKwkp * 397) ^ ZqYMkLdonrbLPbHprxydzkIAizSD;
	}

	public static bool operator ==(HrmeACHhkFViOCUaklECPkUAoFB left, HrmeACHhkFViOCUaklECPkUAoFB right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(HrmeACHhkFViOCUaklECPkUAoFB left, HrmeACHhkFViOCUaklECPkUAoFB right)
	{
		return !left.Equals(right);
	}

	public override string ToString()
	{
		return $"({lSOdwKYaTJSJyAWJnADwkSPKwkp},{ZqYMkLdonrbLPbHprxydzkIAizSD})";
	}
}
