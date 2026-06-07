using System;

public struct KeyPair : IEquatable<KeyPair>
{
	public readonly EntityId key1;

	public readonly EntityId key2;

	public KeyPair(EntityId k1, EntityId k2)
	{
		key1 = k1;
		key2 = k2;
	}

	public override bool Equals(object other)
	{
		if (other is KeyPair other2)
		{
			return Equals(other2);
		}
		return false;
	}

	public bool Equals(KeyPair other)
	{
		if (key1.intId == other.key1.intId && key1.type == other.key1.type && key2.intId == other.key2.intId)
		{
			return key2.type == other.key2.type;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return key1.GetHashCode() + key2.GetHashCode();
	}
}
