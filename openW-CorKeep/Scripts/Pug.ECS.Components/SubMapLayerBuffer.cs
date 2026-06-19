using Unity.Entities;

[InternalBufferCapacity(0)]
public struct SubMapLayerBuffer : IBufferElementData
{
	public SubMapLayer data;

	public static implicit operator SubMapLayer(SubMapLayerBuffer e)
	{
		return e.data;
	}

	public static implicit operator SubMapLayerBuffer(SubMapLayer e)
	{
		return new SubMapLayerBuffer
		{
			data = e
		};
	}
}
