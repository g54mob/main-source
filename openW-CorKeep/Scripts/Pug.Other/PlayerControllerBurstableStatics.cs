using Unity.Mathematics;
using Unity.Physics;

public static class PlayerControllerBurstableStatics
{
	public static readonly CollisionFilter velocityAffectorFilter = new CollisionFilter
	{
		BelongsTo = uint.MaxValue,
		CollidesWith = 16384u
	};

	public static readonly CollisionFilter forceFromNearbyFilter = new CollisionFilter
	{
		BelongsTo = uint.MaxValue,
		CollidesWith = 10240u
	};

	public static readonly CollisionFilter requiredObjectFilter = new CollisionFilter
	{
		BelongsTo = uint.MaxValue,
		CollidesWith = 131329u
	};

	public static readonly float3 PLAYER_SPAWN_POSITION = new float3(0f, 0f, -0.138f);
}
