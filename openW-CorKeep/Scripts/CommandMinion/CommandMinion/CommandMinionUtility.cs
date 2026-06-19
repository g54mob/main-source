using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;

namespace CommandMinion
{
	public static class CommandMinionUtility
	{
		public static Entity GetClosestAttackTargetInArea(float3 worldCursorPosition, in PhysicsWorldHistorySingleton physicsWorldHistorySingleton, ref PhysicsWorld physicsWorld, NetworkTick currentTick, CommandDataInterpolationDelay interpolationDelay, ComponentLookup<UseLagCompensationCD> useLagCompensationLookup)
		{
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 28u
			};
			ClosestHitCollectorWithComponent<DistanceHit, UseLagCompensationCD> collector = new ClosestHitCollectorWithComponent<DistanceHit, UseLagCompensationCD>(1f, useLagCompensationLookup, ClosestHitCollectorWithComponent<DistanceHit, UseLagCompensationCD>.ComponentMode.Required);
			float3 position = worldCursorPosition + new float3(0f, 0f, -0.5f);
			CollisionWorld collisionWorld = physicsWorld.CollisionWorld;
			physicsWorldHistorySingleton.GetCollisionWorldFromTick(currentTick, interpolationDelay.Delay, ref physicsWorld, out var collWorld);
			collWorld.OverlapSphereCustom(position, 1f, ref collector, filter);
			collector.Mode = ClosestHitCollectorWithComponent<DistanceHit, UseLagCompensationCD>.ComponentMode.Forbidden;
			collisionWorld.OverlapSphereCustom(position, 1f, ref collector, filter);
			return collector.ClosestHit.Entity;
		}
	}
}
