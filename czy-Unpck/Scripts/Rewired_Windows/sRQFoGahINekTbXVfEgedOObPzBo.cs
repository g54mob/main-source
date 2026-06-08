using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct sRQFoGahINekTbXVfEgedOObPzBo : IEquatable<sRQFoGahINekTbXVfEgedOObPzBo>
{
	private int LrRXfVAsplkrZaPVFRgWeFjScVk;

	public sRQFoGahINekTbXVfEgedOObPzBo(bool boolValue)
	{
		LrRXfVAsplkrZaPVFRgWeFjScVk = (boolValue ? 1 : 0);
	}

	public bool Equals(sRQFoGahINekTbXVfEgedOObPzBo other)
	{
		return LrRXfVAsplkrZaPVFRgWeFjScVk == other.LrRXfVAsplkrZaPVFRgWeFjScVk;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (obj is sRQFoGahINekTbXVfEgedOObPzBo)
		{
			return Equals((sRQFoGahINekTbXVfEgedOObPzBo)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return LrRXfVAsplkrZaPVFRgWeFjScVk;
	}

	public static bool operator ==(sRQFoGahINekTbXVfEgedOObPzBo left, sRQFoGahINekTbXVfEgedOObPzBo right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(sRQFoGahINekTbXVfEgedOObPzBo left, sRQFoGahINekTbXVfEgedOObPzBo right)
	{
		return !left.Equals(right);
	}

	public static implicit operator bool(sRQFoGahINekTbXVfEgedOObPzBo booleanValue)
	{
		return booleanValue.LrRXfVAsplkrZaPVFRgWeFjScVk != 0;
	}

	public static implicit operator sRQFoGahINekTbXVfEgedOObPzBo(bool boolValue)
	{
		return new sRQFoGahINekTbXVfEgedOObPzBo(boolValue);
	}

	public override string ToString()
	{
		return $"{LrRXfVAsplkrZaPVFRgWeFjScVk != 0}";
	}
}
