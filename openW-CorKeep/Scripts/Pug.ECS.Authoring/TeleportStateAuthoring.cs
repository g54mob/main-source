using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class TeleportStateAuthoring : MonoBehaviour
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

	public float allowedRadiusToMoveFromPosition;
}
