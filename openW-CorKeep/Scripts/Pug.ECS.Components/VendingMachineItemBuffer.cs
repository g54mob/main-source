using System;
using Unity.Entities;

[Serializable]
[InternalBufferCapacity(0)]
public struct VendingMachineItemBuffer : IBufferElementData
{
	public ObjectID objectID;
}
