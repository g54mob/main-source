using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

public struct StartGameRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public Hash128 playerGuid;

	public FixedArray512 dataPart;

	public uint dataPartStart;

	public uint dataPartSize;

	public uint totalDataSize;

	public ulong onlineID;

	public FixedString32Bytes onlineName;

	public bool isThinClient;

	public byte platform;
}
