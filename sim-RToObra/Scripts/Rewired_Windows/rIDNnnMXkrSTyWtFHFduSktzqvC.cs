using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct rIDNnnMXkrSTyWtFHFduSktzqvC : IEquatable<rIDNnnMXkrSTyWtFHFduSktzqvC>
{
	private int OPMSyXhRnZZeefJcOMUKcGvwiCQ;

	public rIDNnnMXkrSTyWtFHFduSktzqvC(bool boolValue)
	{
		OPMSyXhRnZZeefJcOMUKcGvwiCQ = (boolValue ? 1 : 0);
	}

	public bool Equals(rIDNnnMXkrSTyWtFHFduSktzqvC other)
	{
		return OPMSyXhRnZZeefJcOMUKcGvwiCQ == other.OPMSyXhRnZZeefJcOMUKcGvwiCQ;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (obj is rIDNnnMXkrSTyWtFHFduSktzqvC)
		{
			return Equals((rIDNnnMXkrSTyWtFHFduSktzqvC)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return OPMSyXhRnZZeefJcOMUKcGvwiCQ;
	}

	public static bool operator ==(rIDNnnMXkrSTyWtFHFduSktzqvC left, rIDNnnMXkrSTyWtFHFduSktzqvC right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(rIDNnnMXkrSTyWtFHFduSktzqvC left, rIDNnnMXkrSTyWtFHFduSktzqvC right)
	{
		return !left.Equals(right);
	}

	public static implicit operator bool(rIDNnnMXkrSTyWtFHFduSktzqvC booleanValue)
	{
		return booleanValue.OPMSyXhRnZZeefJcOMUKcGvwiCQ != 0;
	}

	public static implicit operator rIDNnnMXkrSTyWtFHFduSktzqvC(bool boolValue)
	{
		return new rIDNnnMXkrSTyWtFHFduSktzqvC(boolValue);
	}

	public override string ToString()
	{
		return string.Format("{0}", OPMSyXhRnZZeefJcOMUKcGvwiCQ != 0);
	}
}
