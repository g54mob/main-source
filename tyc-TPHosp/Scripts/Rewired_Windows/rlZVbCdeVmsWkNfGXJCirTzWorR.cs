using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct rlZVbCdeVmsWkNfGXJCirTzWorR : IEquatable<rlZVbCdeVmsWkNfGXJCirTzWorR>
{
	private int SPuqcgCaDbXcYmhrTAgcPbmmGvph;

	public rlZVbCdeVmsWkNfGXJCirTzWorR(bool boolValue)
	{
		SPuqcgCaDbXcYmhrTAgcPbmmGvph = (boolValue ? 1 : 0);
	}

	public bool Equals(rlZVbCdeVmsWkNfGXJCirTzWorR other)
	{
		return SPuqcgCaDbXcYmhrTAgcPbmmGvph == other.SPuqcgCaDbXcYmhrTAgcPbmmGvph;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (obj is rlZVbCdeVmsWkNfGXJCirTzWorR)
		{
			return Equals((rlZVbCdeVmsWkNfGXJCirTzWorR)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return SPuqcgCaDbXcYmhrTAgcPbmmGvph;
	}

	public static bool operator ==(rlZVbCdeVmsWkNfGXJCirTzWorR left, rlZVbCdeVmsWkNfGXJCirTzWorR right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(rlZVbCdeVmsWkNfGXJCirTzWorR left, rlZVbCdeVmsWkNfGXJCirTzWorR right)
	{
		return !left.Equals(right);
	}

	public static implicit operator bool(rlZVbCdeVmsWkNfGXJCirTzWorR booleanValue)
	{
		return booleanValue.SPuqcgCaDbXcYmhrTAgcPbmmGvph != 0;
	}

	public static implicit operator rlZVbCdeVmsWkNfGXJCirTzWorR(bool boolValue)
	{
		return new rlZVbCdeVmsWkNfGXJCirTzWorR(boolValue);
	}

	public override string ToString()
	{
		return $"{SPuqcgCaDbXcYmhrTAgcPbmmGvph != 0}";
	}
}
