using Unity.Entities;

public struct ItemsToAddToNewObjectBuffer : IBufferElementData
{
	public ObjectDataCD objectData;

	public static implicit operator ItemsToAddToNewObjectBuffer(ObjectDataCD o)
	{
		return new ItemsToAddToNewObjectBuffer
		{
			objectData = o
		};
	}

	public static implicit operator ObjectDataCD(ItemsToAddToNewObjectBuffer c)
	{
		return c.objectData;
	}
}
