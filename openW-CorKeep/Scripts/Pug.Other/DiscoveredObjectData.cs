using System;

[Serializable]
public struct DiscoveredObjectData : IEquatable<DiscoveredObjectData>, IEquatable<ObjectDataCD>
{
	public ObjectID objectID;

	public int variation;

	public static implicit operator ObjectDataCD(DiscoveredObjectData e)
	{
		return new ObjectDataCD
		{
			objectID = e.objectID,
			variation = e.variation
		};
	}

	public static implicit operator DiscoveredObjectData(ObjectDataCD e)
	{
		return new DiscoveredObjectData
		{
			objectID = e.objectID,
			variation = e.variation
		};
	}

	public bool Equals(DiscoveredObjectData other)
	{
		if (objectID == other.objectID)
		{
			return variation == other.variation;
		}
		return false;
	}

	public bool Equals(ObjectDataCD other)
	{
		return Equals((DiscoveredObjectData)other);
	}
}
