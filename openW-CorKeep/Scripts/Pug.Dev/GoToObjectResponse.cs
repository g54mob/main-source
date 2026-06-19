using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct GoToObjectResponse : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public enum ResponseType
	{
		NotFound = 0,
		Entity = 1,
		InInventory = 2,
		Marker = 3
	}

	public ResponseType Type;

	public ObjectID ObjectID;

	public float2 Position;
}
