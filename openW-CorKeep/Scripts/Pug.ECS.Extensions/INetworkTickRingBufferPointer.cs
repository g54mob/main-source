using Unity.Entities;

public interface INetworkTickRingBufferPointer : IComponentData, IQueryTypeParameter
{
	byte NextIndex { get; set; }
}
