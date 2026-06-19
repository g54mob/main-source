using Unity.Entities;
using Unity.NetCode;

public struct RegenerateTerrainResponse : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public bool Success;
}
