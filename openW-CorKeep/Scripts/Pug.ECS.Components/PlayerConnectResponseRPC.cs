using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

public struct PlayerConnectResponseRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public bool rejected;

	public bool minorVersionMismatch;

	public bool streamIntegrationEnabled;

	public FixedString64Bytes reason;

	public Hash128 serverGuid;

	public Hash128 serverSessionId;

	public FixedString64Bytes serverName;

	public uint serverSeed;

	public int season;

	public WorldMode worldMode;

	public WorldGenerationType worldGenerationType;

	public FixedArray64 biomeCompassDirections;

	public FixedString64Bytes serverVersionString;
}
