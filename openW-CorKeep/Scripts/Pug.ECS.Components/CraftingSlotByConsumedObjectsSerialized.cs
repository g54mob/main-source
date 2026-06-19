using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
public struct CraftingSlotByConsumedObjectsSerialized : IBufferElementData
{
	public ContainedObjectsSerializedBuffer ConsumedObject;

	public ContainedObjectsAuxIndexSerializedBuffer ConsumedObjectAuxIndex;
}
