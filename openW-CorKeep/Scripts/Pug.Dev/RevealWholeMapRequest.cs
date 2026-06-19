using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct RevealWholeMapRequest : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public int2 playerPosition;

	public int generationRadius;
}
