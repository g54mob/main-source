using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PlayerGhost : IComponentData, IQueryTypeParameter
{
	public Entity connection;

	[GhostField]
	public Hash128 playerGuid;

	[GhostField]
	public int playerIndex;

	[GhostField]
	public int adminPrivileges;

	public float2 cameraPosition;

	public Entity playerGhostExtrapolated;

	public float2 smoothedVelocity;

	[GhostField]
	public ulong onlineId;

	[GhostField]
	public FixedString32Bytes onlineName;

	[GhostField]
	public byte platform;
}
