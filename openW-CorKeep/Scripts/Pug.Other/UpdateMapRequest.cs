using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct UpdateMapRequest : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public int2 MapPosition;
}
