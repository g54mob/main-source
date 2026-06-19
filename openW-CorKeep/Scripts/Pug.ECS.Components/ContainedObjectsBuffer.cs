using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(1)]
public struct ContainedObjectsBuffer : IBufferElementData
{
	[GhostField]
	public ObjectDataCD objectData;

	[GhostField]
	public int auxDataIndex;

	public ObjectID objectID => objectData.objectID;

	public int amount => objectData.amount;

	public int variation => objectData.variation;

	public int variationUpdateCount => objectData.variationUpdateCount;

	public readonly bool Equals(ContainedObjectsBuffer other)
	{
		if (objectData.Equals(other.objectData))
		{
			return auxDataIndex == other.auxDataIndex;
		}
		return false;
	}

	public readonly bool EqualsExact(ContainedObjectsBuffer other)
	{
		if (auxDataIndex == other.auxDataIndex && objectData.objectID == other.objectID && objectData.amount == other.amount && objectData.variation == other.variation)
		{
			return objectData.variationUpdateCount == other.variationUpdateCount;
		}
		return false;
	}

	public readonly bool EqualsIgnoreAmount(ContainedObjectsBuffer other)
	{
		if (auxDataIndex == other.auxDataIndex && objectData.objectID == other.objectID && objectData.variation == other.variation)
		{
			return objectData.variationUpdateCount == other.variationUpdateCount;
		}
		return false;
	}
}
