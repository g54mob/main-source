using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[Serializable]
[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ObjectDataCD : IComponentData, IQueryTypeParameter, IEquatable<ObjectDataCD>
{
	[GhostField]
	public ObjectID objectID;

	[GhostField]
	public int amount;

	[GhostField]
	public int variation;

	[GhostField]
	public int variationUpdateCount;

	public bool Equals(ObjectDataCD other)
	{
		if (objectID == other.objectID)
		{
			return variation == other.variation;
		}
		return false;
	}

	public bool EqualsExact(ObjectDataCD other)
	{
		if (objectID == other.objectID && amount == other.amount && variation == other.variation)
		{
			return variationUpdateCount == other.variationUpdateCount;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)math.hash(new int2((int)objectID, variation));
	}

	public override string ToString()
	{
		return Enum.GetName(typeof(ObjectID), objectID) + ": amount=" + amount + ", variation=" + variation;
	}

	public static implicit operator ObjectData(ObjectDataCD o)
	{
		return new ObjectData
		{
			objectID = o.objectID,
			variation = o.variation,
			amount = o.amount
		};
	}

	public static implicit operator ObjectDataCD(ObjectData c)
	{
		return new ObjectDataCD
		{
			objectID = c.objectID,
			variation = c.variation,
			amount = c.amount
		};
	}
}
