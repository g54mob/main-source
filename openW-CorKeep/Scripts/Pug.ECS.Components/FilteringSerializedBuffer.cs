using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
public struct FilteringSerializedBuffer : IBufferElementData
{
	public int filterType;

	public ObjectID filterObject;

	public int filterVariation;
}
