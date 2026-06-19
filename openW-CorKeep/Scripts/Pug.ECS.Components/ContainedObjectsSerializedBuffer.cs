using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[TypeManager.ForcedMemoryOrdering(4322402440950630264uL)]
[TypeManager.OverrideTypeHash(8817826183114497276uL)]
public struct ContainedObjectsSerializedBuffer : IBufferElementData
{
	public ObjectDataSerializedCD ObjectData;

	public static implicit operator ContainedObjectsSerializedBuffer(ObjectDataSerializedCD o)
	{
		return new ContainedObjectsSerializedBuffer
		{
			ObjectData = o
		};
	}

	public static implicit operator ObjectDataSerializedCD(ContainedObjectsSerializedBuffer c)
	{
		return c.ObjectData;
	}
}
