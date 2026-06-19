using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

public struct NetworkCommandResponseRpc : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public NetworkCommand command;

	public FixedString128Bytes string0;

	public int int0;

	public int int1;

	public ulong ulong1;
}
