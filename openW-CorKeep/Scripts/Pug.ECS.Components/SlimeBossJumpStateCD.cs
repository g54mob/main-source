using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;

public struct SlimeBossJumpStateCD : IComponentData, IQueryTypeParameter
{
	public float3 targetPos;

	public Entity target;

	public int internalState;

	public ThreadSafeTimerSimple internalTimer;

	public ThreadSafeTimerSimple cooldownTimer;

	public bool isReseting;

	public float anticipationTime;

	public float enragedAnticipationTime;

	public float maxAirTime;

	public float enragedMaxAirTime;

	public float landTime;

	public int damage;

	public float jumpMoveSpeed;

	public float enragedJumpMoveSpeed;

	public Tileset slimeTileset;
}
