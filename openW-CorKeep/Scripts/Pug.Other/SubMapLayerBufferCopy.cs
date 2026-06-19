using Unity.Entities;

public struct SubMapLayerBufferCopy : ICleanupBufferElementData, IBufferElementData
{
	public SubMapLayer data;

	public static implicit operator SubMapLayer(SubMapLayerBufferCopy e)
	{
		return e.data;
	}

	public static implicit operator SubMapLayerBufferCopy(SubMapLayer e)
	{
		return new SubMapLayerBufferCopy
		{
			data = e
		};
	}
}
