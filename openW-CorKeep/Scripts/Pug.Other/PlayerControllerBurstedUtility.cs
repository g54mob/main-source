using Pug.Automation;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;

public static class PlayerControllerBurstedUtility
{
	public static void GetAnyVelocityAffectorForce(in float3 worldPosition, ref VelocityAffectedCD velocityAffectedCD, in CollisionFilter velocityAffectorFilter, in ComponentLookup<DirectionBasedOnVariationCD> directionBasedOnVariationLookup, ComponentLookup<VelocityAffectorCD> velocityAffectorLookup, in ComponentLookup<ElectricityCD> electricityLookup, in ComponentLookup<LocalTransform> translationLookup, in ComponentLookup<ObjectDataCD> objectLookup, ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> moveToPredictedByCombatInteractionLookup, in ComponentLookup<Simulate> simulateLookup, in CollisionWorld collisionWorld, NetworkTick currentTick, out float2 result)
	{
		result = float2.zero;
		PointDistanceInput input = new PointDistanceInput
		{
			Position = worldPosition,
			Filter = velocityAffectorFilter
		};
		NativeList<DistanceHit> allHits = new NativeList<DistanceHit>(1, Allocator.Temp);
		if (!collisionWorld.CalculateDistance(input, ref allHits))
		{
			allHits.Dispose();
			velocityAffectedCD.lastAffector = Entity.Null;
			return;
		}
		Entity entity = Entity.Null;
		VelocityAffectorCD value = default(VelocityAffectorCD);
		int num = -1;
		for (int i = 0; i < allHits.Length; i++)
		{
			Entity entity2 = allHits[i].Entity;
			if (directionBasedOnVariationLookup.HasComponent(entity2) && velocityAffectorLookup.TryGetComponent(entity2, out var componentData) && componentData.priority > num && (!componentData.requiresElectricity || !electricityLookup.TryGetComponent(entity2, out var componentData2) || componentData2.electricityAmount > 0))
			{
				value = componentData;
				entity = entity2;
				num = value.priority;
			}
		}
		allHits.Dispose();
		if (entity == Entity.Null)
		{
			velocityAffectedCD.lastAffector = Entity.Null;
			return;
		}
		ref BlobArray<VelocityAffectorMoveOptionElementData> value2 = ref value.moveOptions.Value;
		if (velocityAffectedCD.lastAffector != entity || velocityAffectedCD.lastAffectorOptionIndex == -1)
		{
			value.lastIndex++;
			value.lastIndex %= value2.Length;
			velocityAffectedCD.lastAffectorOptionIndex = value.lastIndex;
			if (moveToPredictedByCombatInteractionLookup.HasComponent(entity))
			{
				moveToPredictedByCombatInteractionLookup.GetRefRW(entity).ValueRW.SetLastInteractionTick(currentTick);
			}
			if (simulateLookup.HasAndIsComponentEnabled(entity))
			{
				velocityAffectorLookup[entity] = value;
			}
		}
		velocityAffectedCD.lastAffectorOptionIndex %= value2.Length;
		ObjectDataCD objectDataCD = objectLookup[entity];
		float3 position = translationLookup[entity].Position;
		int2 directionFromVariation = DirectionBasedOnVariationCD.GetDirectionFromVariation(objectDataCD.variation);
		int2 int5 = EntityUtility.RotateVectorFromDefaultDownRotation(value2[velocityAffectedCD.lastAffectorOptionIndex].moveForce, directionFromVariation);
		float3 float5 = worldPosition;
		float3 x = (((float)math.abs(int5.x) > 0.1f) ? new float3(0f, 0f, math.round(position.z) - float5.z) : new float3(math.round(position.x) - float5.x, 0f, 0f));
		x = ((math.length(x) > 0.1f) ? math.normalizesafe(x, float3.zero) : float3.zero);
		result = (math.normalizesafe(math.normalizesafe(new float3(int5.x, 0f, int5.y)) + x, float3.zero) * math.length(int5) * 0.18f).ToFloat2();
		velocityAffectedCD.lastAffector = entity;
	}

	public static void GetAnyForceFromNearbyEntity(in float3 worldPosition, in CollisionFilter forceFromNearbyFilter, in FactionCD factionCD, in ComponentLookup<AddForceToNearbyEntitiesCD> addForceToNearbyEntitiesLookup, in ComponentLookup<LocalTransform> localTransformLookup, in ComponentLookup<FactionCD> factionLookup, in CollisionWorld collisionWorld, in ComponentLookup<OwnerReferenceCD> ownerLookup, in WorldInfoCD worldInfo, ref TileAccessor tileAccessor, NetworkTick currentTick, out float3 result)
	{
		result = float3.zero;
		PointDistanceInput input = new PointDistanceInput
		{
			Position = worldPosition,
			MaxDistance = 10f,
			Filter = forceFromNearbyFilter
		};
		NativeList<DistanceHit> allHits = new NativeList<DistanceHit>(1, Allocator.Temp);
		if (collisionWorld.CalculateDistance(input, ref allHits))
		{
			FactionCD targetFaction = factionCD;
			Entity entity = Entity.Null;
			float num = 0f;
			float num2 = float.MaxValue;
			for (int i = 0; i < allHits.Length; i++)
			{
				Entity entity2 = allHits[i].Entity;
				if (!addForceToNearbyEntitiesLookup.TryGetComponent(entity2, out var componentData) || !localTransformLookup.TryGetComponent(entity2, out var componentData2))
				{
					continue;
				}
				float num3 = componentData.force;
				if (componentData.state == AddForceToNearbyEntitiesCD.State.Active)
				{
					float num4 = 1f;
					if (componentData.stateTimer.isRunning && componentData.stateTimer.targetTicks != 0)
					{
						num4 = componentData.activeForceMultiplierCurve.Evaluate(componentData.stateTimer.GetElapsedRatio(currentTick));
					}
					num3 += componentData.forceDuringActivation * num4;
				}
				if (num3 == 0f)
				{
					continue;
				}
				if (!factionLookup.TryGetComponent(entity2, out var componentData3))
				{
					componentData3 = default(FactionCD);
				}
				if (componentData3.CanAttack(targetFaction, worldInfo))
				{
					float num5 = math.distancesq(componentData2.Position, worldPosition);
					if (num5 < num2 && num5 < componentData.radiusSq && (!componentData.checkLineOfSight || PlayerIsInLineOfSightOfAttacker(entity2, worldPosition, localTransformLookup, ownerLookup, tileAccessor, collisionWorld)))
					{
						entity = entity2;
						num2 = num5;
						num = num3;
					}
				}
			}
			if (entity != Entity.Null && num != 0f)
			{
				float3 position = localTransformLookup[entity].Position;
				float3 float5 = math.normalizesafe(worldPosition - position) * num;
				result = float5 * 0.18f * 0.05f;
			}
		}
		allHits.Dispose();
	}

	private static bool PlayerIsInLineOfSightOfAttacker(Entity attacker, float3 worldPosition, ComponentLookup<LocalTransform> localTransformLookup, ComponentLookup<OwnerReferenceCD> ownerLookup, TileAccessor tileAccessor, CollisionWorld collisionWorld)
	{
		if (!localTransformLookup.TryGetComponent(attacker, out var componentData))
		{
			return false;
		}
		float3 position = componentData.Position;
		CollisionFilter filter = new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 1u
		};
		float3 float5 = position + new float3(0f, 0.5f, 0f);
		float3 float6 = worldPosition + new float3(0f, 0.5f, 0f);
		RaycastInput input = new RaycastInput
		{
			Start = float5,
			End = float6,
			Filter = filter
		};
		NativeList<RaycastHit> allHits = new NativeList<RaycastHit>(Allocator.Temp);
		if (collisionWorld.CastRay(input, ref allHits))
		{
			for (int i = 0; i < allHits.Length; i++)
			{
				if (allHits[i].Entity != attacker && localTransformLookup.TryGetComponent(attacker, out var _) && (!ownerLookup.TryGetComponent(attacker, out var componentData3) || componentData3.owner != allHits[i].Entity))
				{
					allHits.Dispose();
					return false;
				}
			}
		}
		allHits.Dispose();
		float3 x = float6 - float5;
		float3 x2 = math.normalizesafe(x);
		float maxDist = math.length(x);
		if (SinglePugMap.RaycastWalls(float5.ToFloat2(), x2.ToFloat2(), maxDist, out var _, tileAccessor))
		{
			return false;
		}
		return true;
	}
}
