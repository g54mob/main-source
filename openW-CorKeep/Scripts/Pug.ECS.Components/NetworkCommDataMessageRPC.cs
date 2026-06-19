using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

public struct NetworkCommDataMessageRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public int messageNumber;

	public FixedArray64 messagePart;

	public int startByte;
}
