using PlayerState;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

public static class CornerSmoothingUtility
{
	public static bool TestMovement(in CollisionWorld collisionWorld, in CornerSmoothingCD cornerSmoothingCD, in PlayerStateCD playerStateCD, float3 pos, Direction dir, out Direction escapeDir)
	{
		BlobAssetReference<CornerSmoothingData> smoothingData = cornerSmoothingCD.smoothingData;
		float num = (dir.isH ? smoothingData.Value.escapeSensorSizeHorizontal : smoothingData.Value.escapeSensorSizeVertical);
		float num2 = (dir.isH ? smoothingData.Value.escapeSensorSpreadHorizontal : smoothingData.Value.escapeSensorSpreadVertical);
		float3 obj = pos + (dir.isV ? smoothingData.Value.forwardSensorDistVertical : smoothingData.Value.forwardSensorDistHorizontal) * dir.f3;
		Direction nextClockwise = dir.nextClockwise;
		Direction nextCounterClockwise = dir.nextCounterClockwise;
		float3 halfExtents = 0.5f * smoothingData.Value.forwardSensorSize;
		float3 halfExtents2 = 0.5f * new float3(num, num, num);
		CollisionFilter collisionFilter = (playerStateCD.HasAnyState(PlayerStateEnum.BoatRiding) ? cornerSmoothingCD.boatCollisionFilter : cornerSmoothingCD.collisionFilter);
		bool flag = IsBoundsBlocked(obj, halfExtents, in collisionFilter, in collisionWorld);
		bool flag2 = IsBoundsBlocked(obj + num2 * nextClockwise.f3, halfExtents2, in collisionFilter, in collisionWorld);
		bool flag3 = IsBoundsBlocked(obj + num2 * nextCounterClockwise.f3, halfExtents2, in collisionFilter, in collisionWorld);
		if (flag2 ^ flag3)
		{
			escapeDir = (flag2 ? nextCounterClockwise : nextClockwise);
		}
		else
		{
			escapeDir = default(Direction);
		}
		return !flag;
	}

	private static bool IsBoundsBlocked(float3 center, float3 halfExtents, in CollisionFilter collisionFilter, in CollisionWorld collisionWorld)
	{
		AnyHitCollector<DistanceHit> collector = new AnyHitCollector<DistanceHit>(0f);
		return collisionWorld.OverlapBoxCustom(center, quaternion.identity, halfExtents, ref collector, collisionFilter, QueryInteraction.IgnoreTriggers);
	}
}
