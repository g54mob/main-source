using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct BeamAttackStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._beamAttackStateGroup.HasComponent(entity) && c._attackCooldownGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity))
		{
			return c._nearbyEntitiesBufferGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.RangeAttack))
		{
			return;
		}
		AttackCooldownTimerCD value = c._attackCooldownGroup[entity];
		if (value.Value.isRunning && !value.Value.IsTimerElapsed(d._elapsedTime))
		{
			c._attackCooldownGroup[entity] = value;
			return;
		}
		BeamAttackStateCD value2 = c._beamAttackStateGroup[entity];
		DynamicBuffer<BeamBuffer> dynamicBuffer = c._beamBufferGroup[entity];
		LocalTransform localTransform = c._localTransformGroup[entity];
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer2 = c._nearbyEntitiesBufferGroup[entity];
		BehaviourTagsCD attackerBehaviourTags = c._behaviourTagsGroup[entity];
		Entity entity2 = Entity.Null;
		if (c._lastAttackerGroup.TryGetComponent(entity, out var componentData))
		{
			entity2 = componentData.Value;
		}
		int length = dynamicBuffer2.Length;
		for (int i = 0; i < length + 1; i++)
		{
			bool flag = false;
			Entity entity3 = Entity.Null;
			if (i == length)
			{
				if (!(entity2 != Entity.Null))
				{
					continue;
				}
				flag = true;
				entity3 = entity2;
			}
			else
			{
				entity3 = dynamicBuffer2[i].entity;
			}
			Entity entity4 = entity3;
			EntityPartCD componentData3;
			if (c._playerGhostExtrapolatedGroup.TryGetComponent(entity3, out var componentData2))
			{
				entity4 = componentData2.playerGhost;
			}
			else if (c._entityPartGroup.TryGetComponent(entity3, out componentData3))
			{
				entity4 = componentData3.mainEntity;
			}
			else if (!flag && c._playerGhostGroup.HasComponent(entity3))
			{
				continue;
			}
			FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
			if (!c._objectDataGroup.HasComponent(entity4) || (c._entityDestroyedGroup.HasComponent(entity4) && c._entityDestroyedGroup.IsComponentEnabled(entity4)) || c._physicsExcludeGroup.HasAndIsComponentEnabled(entity4))
			{
				continue;
			}
			FactionCD targetFaction = (c._factionGroup.HasComponent(entity4) ? c._factionGroup[entity4] : default(FactionCD));
			if (!factionCD.CanAttack(targetFaction, d.worldInfo) || (c._tileGroup.HasComponent(entity4) && c._tileGroup[entity4].tileType.IsWalkableTile()) || c._propertiesGroup[entity4].Has(-440732150) || (c._objectCategoryGroup.TryGetComponent(entity4, out var componentData4) && BehaviourTagsCD.CantAttack(attackerBehaviourTags, componentData4)))
			{
				continue;
			}
			float3 position = localTransform.Position;
			float3 position2 = c._localTransformGroup[entity3].Position;
			float3 x = position2 - position;
			float num = math.length(x);
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
			if (d.collisionWorld.CastRay(input))
			{
				continue;
			}
			float3 float5 = math.normalizesafe(position2 - position);
			bool flag2 = false;
			for (int j = 0; (float)j < num * 2f; j++)
			{
				int2 worldPosition = (position + float5 * j * 0.5f).RoundToInt2();
				if (d.tileLookup.GetTopType(worldPosition).IsBlockingTile(includeLowColliders: false))
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				value2.internalState = 0;
				value2.internalTimer.Stop();
				value2.targetEntity = entity3;
				value2.targetDirection = math.normalizesafe(x);
				dynamicBuffer.Clear();
				stateInfo.EnterState(StateID.RangeAttack);
				break;
			}
		}
		c._beamAttackStateGroup[entity] = value2;
		c._attackCooldownGroup[entity] = value;
	}
}
