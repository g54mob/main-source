using Unity.Entities;
using Unity.NetCode;

public struct NetworkCommandRpc : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public NetworkCommand command;

	public Entity entity0;

	public int int0;
}
