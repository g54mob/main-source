using System;
using MessagePack;

[Serializable]
[MessagePackObject(false)]
public readonly struct MapTimestampHash
{
	[Key(0)]
	public readonly ulong H1;

	[Key(1)]
	public readonly ulong H2;

	public MapTimestampHash(ulong h1, ulong h2)
	{
		H1 = h1;
		H2 = h2;
	}

	public static bool operator ==(in MapTimestampHash lhs, in MapTimestampHash rhs)
	{
		if (lhs.H1 == rhs.H1)
		{
			return lhs.H2 == rhs.H2;
		}
		return false;
	}

	public static bool operator !=(in MapTimestampHash lhs, in MapTimestampHash rhs)
	{
		return !(lhs == rhs);
	}

	public override bool Equals(object o)
	{
		if (o != null && GetType() == o.GetType())
		{
			return this == (MapTimestampHash)o;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return H1.GetHashCode() ^ H2.GetHashCode();
	}

	public override string ToString()
	{
		return $"0x{H1:x8}{H1:x8}";
	}
}
