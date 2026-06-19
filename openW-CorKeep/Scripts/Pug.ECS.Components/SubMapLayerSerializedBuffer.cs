using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
[InternalBufferCapacity(0)]
[TypeManager.ForcedMemoryOrdering(17385121593422961126uL)]
[TypeManager.OverrideTypeHash(8960563578729339433uL)]
public struct SubMapLayerSerializedBuffer : IBufferElementData
{
	public SubMapLayer data;

	public static implicit operator SubMapLayer(SubMapLayerSerializedBuffer e)
	{
		return e.data;
	}

	public static implicit operator SubMapLayerSerializedBuffer(SubMapLayer e)
	{
		return new SubMapLayerSerializedBuffer
		{
			data = e
		};
	}
}
