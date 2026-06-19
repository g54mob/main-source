using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct GoToObjectRequest : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public Entity EntityToMove;

	public ObjectID ObjectID;

	public float2 Position;
}
