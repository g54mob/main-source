using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct TeleportStateCD : IComponentData, IQueryTypeParameter
{
	public bool canOnlyTeleportBackToSpawn;

	public bool canOnlyTeleportToNonBlockedGround;

	public bool canTeleportToPitAndWater;

	public float startTeleportDuration;

	public float endTeleportDuration;

	public float minCooldown;

	public float maxCooldown;

	public float minTeleportDistanceFromPlayer;

	public float maxTeleportDistanceFromPlayer;

	public int2 updateTilesAtAreaMinCorner;

	public int2 updateTilesAtAreaMaxCorner;

	public float3 targetDestination;

	public float allowedRadiusToMoveFromPosition;

	public float3 positionToStayWithin;

	[GhostField]
	public int internalState;

	public ThreadSafeTimerSimple timer;

	public ThreadSafeTimerSimple cooldownTimer;
}
