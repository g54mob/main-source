using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct MeleeAttackStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._meleeAttackStateGroup.HasComponent(entity) && c._attackCooldownGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._nearbyEntitiesTrackerGroup.HasComponent(entity) && c._nearbyEntitiesBufferGroup.HasComponent(entity))
		{
			return c._behaviourTagsGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		MeleeAttackStateCD value = c._meleeAttackStateGroup[entity];
		if (value.isDisabled || stateInfo.HasState(StateID.MeleeAttack) || stateInfo.HasState(StateID.RangeAttack))
		{
			c._meleeAttackStateGroup[entity] = value;
			return;
		}
		AttackCooldownTimerCD value2 = c._attackCooldownGroup[entity];
		if (value2.Value.isRunning && !value2.Value.IsTimerElapsed(d._elapsedTime))
		{
			c._meleeAttackStateGroup[entity] = value;
			c._attackCooldownGroup[entity] = value2;
			return;
		}
		ObjectPropertiesCD objectPropertiesCD = c._propertiesGroup[entity];
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
		NativeList<Entity> nativeList = new NativeList<Entity>(Allocator.Temp);
		Entity entity2 = Entity.Null;
		ChaseStateCD componentData = default(ChaseStateCD);
		if (stateInfo.IsCurrentState(StateID.Chase))
		{
			c._chaseStateGroup.TryGetComponent(entity, out componentData);
		}
		OwnerReferenceCD componentData2;
		bool flag = c._ownerGroup.TryGetComponent(entity, out componentData2);
		bool flag2 = c._minionGroup.HasComponent(entity);
		bool flag3 = c._petGroup.HasComponent(entity);
		if (flag2 && flag && c._moveToPositionFromCommandGroup.TryGetComponent(entity, out var componentData3) && componentData3.target != Entity.Null)
		{
			Entity value3 = componentData3.target;
			nativeList.Add(in value3);
			if (componentData.targetEntity == value3)
			{
				entity2 = value3;
			}
			if (c._playerGhostGroup.TryGetComponent(value3, out var componentData4))
			{
				nativeList.Add(in componentData4.playerGhostExtrapolated);
				if (componentData.targetEntity == componentData4.playerGhostExtrapolated)
				{
					entity2 = componentData4.playerGhostExtrapolated;
				}
			}
		}
		int length = nativeList.Length;
		if (flag)
		{
			Entity owner = componentData2.owner;
			if (c._combatantTrackerBuffer.TryGetBuffer(owner, out var bufferData))
			{
				for (int i = 0; i < bufferData.Length; i++)
				{
					CombatantsTrackerBuffer combatantsTrackerBuffer = bufferData[i];
					nativeList.Add(in combatantsTrackerBuffer.Target);
					if (c._playerGhostGroup.TryGetComponent(bufferData[i].Target, out var componentData5))
					{
						nativeList.Add(in componentData5.playerGhostExtrapolated);
					}
				}
			}
		}
		_ = nativeList.Length;
		c._lastAttackerGroup.TryGetComponent(entity, out var componentData6);
		if (!flag || flag2)
		{
			for (int j = 0; j < dynamicBuffer.Length; j++)
			{
				NearbyEntitiesBufferCD nearbyEntitiesBufferCD = dynamicBuffer[j];
				nativeList.Add(in nearbyEntitiesBufferCD.entity);
			}
			if (componentData6.Value != Entity.Null)
			{
				nativeList.Add(in componentData6.Value);
			}
		}
		BehaviourTagsCD attackerBehaviourTags = c._behaviourTagsGroup[entity];
		LocalTransform localTransform = c._localTransformGroup[entity];
		FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
		bool flag4 = false;
		for (int k = 0; k < nativeList.Length; k++)
		{
			Entity entity3 = nativeList[k];
			Entity entity4 = entity3;
			if (entity2 != Entity.Null && entity4 != entity2)
			{
				continue;
			}
			if (c._playerGhostExtrapolatedGroup.HasComponent(entity3))
			{
				entity4 = c._playerGhostExtrapolatedGroup[entity3].playerGhost;
			}
			else if (c._entityPartGroup.HasComponent(entity3))
			{
				entity4 = c._entityPartGroup[entity3].mainEntity;
			}
			else if (c._playerGhostGroup.HasComponent(entity3))
			{
				continue;
			}
			bool flag5 = k < length;
			if (((flag3 || flag2) && !flag5 && c._bossGroup.HasComponent(entity4) && c._isInCombatGroup.TryGetComponent(entity4, out var componentData7) && !componentData7.isInCombat && !c._snakeMovementGroup.HasComponent(entity4)) || !c._healthGroup.HasComponent(entity4) || (float)c._healthGroup[entity4].health <= 0f || (c._immuneToDamage.TryGetComponent(entity3, out var componentData8) && componentData8.Value == ImmuneToDamageState.Immune) || !c._objectDataGroup.HasComponent(entity4) || (c._entityDestroyedGroup.HasComponent(entity4) && c._entityDestroyedGroup.IsComponentEnabled(entity4)))
			{
				continue;
			}
			FactionCD targetFaction = (c._factionGroup.HasComponent(entity4) ? c._factionGroup[entity4] : default(FactionCD));
			if (!factionCD.CanAttack(targetFaction, d.worldInfo) || (c._tileGroup.HasComponent(entity4) && c._tileGroup[entity4].tileType.IsWalkableTile()) || c._propertiesGroup[entity4].Has(-440732150) || c._critterGroup.HasComponent(entity4))
			{
				continue;
			}
			bool flag6 = false;
			bool flag7 = true;
			if (c._objectCategoryGroup.HasComponent(entity4))
			{
				ObjectCategoryTagsCD targetTags = c._objectCategoryGroup[entity4];
				flag6 = !BehaviourTagsCD.CantAttack(attackerBehaviourTags, targetTags);
				if (stateInfo.IsCurrentState(StateID.Chase) && c._chaseStateGroup[entity].targetEntity != entity4)
				{
					flag7 = BehaviourTagsCD.WantsToAttack(attackerBehaviourTags, targetTags);
				}
			}
			if (!flag6 || !flag7 || (c._petGroup.HasComponent(entity) && c._shieldGroup.HasComponent(entity4) && c._shieldGroup[entity4].active))
			{
				continue;
			}
			flag4 = true;
			float3 position = localTransform.Position;
			float3 position2 = c._localTransformGroup[entity3].Position;
			float3 x = position2 - position;
			float num = (c._combatRadiusGroup.HasComponent(entity3) ? c._combatRadiusGroup[entity3].radius : 0f);
			if (!(math.length(x) - num < objectPropertiesCD.Get<float>(645227842)))
			{
				continue;
			}
			if (!objectPropertiesCD.Has(-1837969767))
			{
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1u
				};
				RaycastInput input = new RaycastInput
				{
					Start = position + new float3(0f, 0.5f, 0f),
					End = position2 + new float3(0f, 0.5f, 0f),
					Filter = filter
				};
				if (d.collisionWorld.CastRay(input, out var closestHit) && closestHit.Entity != entity3)
				{
					continue;
				}
			}
			if (!objectPropertiesCD.Has(-2072102458))
			{
				bool flag8 = false;
				int2 int5 = position.RoundToInt2();
				int2 end = position2.RoundToInt2();
				int2 pos = int5;
				do
				{
					if (d.tileLookup.GetTopType(pos).IsWallTile())
					{
						flag8 = true;
						break;
					}
				}
				while (MathUtilities.NextPosOnLine(int5, end, ref pos));
				if (flag8)
				{
					continue;
				}
			}
			value.hitDone = false;
			value.hitDirection = math.normalizesafe(x);
			value.aimingAtEntity = entity3;
			value.amountOfHitsDone = 0;
			value.internalState = 0;
			value.internalTimer.Stop();
			stateInfo.EnterState(StateID.MeleeAttack);
			break;
		}
		if (!flag4)
		{
			float min = objectPropertiesCD.Get<float>(1106828234);
			float max = objectPropertiesCD.Get<float>(-1913282363);
			value2.Value.Start(d._elapsedTime, d._rng.NextFloat(min, max));
		}
		c._meleeAttackStateGroup[entity] = value;
		c._attackCooldownGroup[entity] = value2;
		nativeList.Dispose();
	}
}
