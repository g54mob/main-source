using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct SlimeBossJumpStateRequest : IStateRequester
{
	private const float MAX_DISTANCE_FROM_SPAWN_POINT_MAX = 25f;

	private const float SQR_ATTACK_DISTANCE = 400f;

	private const float SQR_INITIAL_ATTACK_DISTANCE = 36f;

	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._slimeBossJumpStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._spawnPointGroup.HasComponent(entity))
		{
			return c._healthGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.SlimeBossJump) || stateInfo.HasState(StateID.SlimeBossTauntJump))
		{
			return;
		}
		SlimeBossJumpStateCD value = c._slimeBossJumpStateGroup[entity];
		LocalTransform localTransform = c._localTransformGroup[entity];
		SpawnPointCD spawnPointCD = c._spawnPointGroup[entity];
		HealthCD healthCD = c._healthGroup[entity];
		FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
		float2 float5 = math.normalizesafe(d._rng.NextFloat2(-1, 1)) * 4f;
		float3 float6 = localTransform.Position + new float3(float5.x, 0f, float5.y);
		Entity entity2 = Entity.Null;
		float num = float.MaxValue;
		float num2 = ((healthCD.health < healthCD.maxHealth) ? 400f : 36f);
		for (int i = 0; i < d.playerExtrapolatedEntities.Length; i++)
		{
			LocalTransform localTransform2 = c._localTransformGroup[d.playerExtrapolatedEntities[i]];
			float num3 = math.distancesq(localTransform2.Position, localTransform.Position);
			if (!(num3 < num) || !(num3 < num2))
			{
				continue;
			}
			Entity playerGhost = c._playerGhostExtrapolatedGroup[d.playerExtrapolatedEntities[i]].playerGhost;
			if (!c._physicsExcludeGroup.HasAndIsComponentEnabled(playerGhost))
			{
				FactionCD targetFaction = (c._factionGroup.HasComponent(playerGhost) ? c._factionGroup[playerGhost] : default(FactionCD));
				if (factionCD.CanAttack(targetFaction, d.worldInfo))
				{
					entity2 = d.playerExtrapolatedEntities[i];
					float6 = localTransform2.Position;
					num = num3;
				}
			}
		}
		if (entity2 == Entity.Null && c._nearbyEntitiesBufferGroup.HasComponent(entity))
		{
			for (int j = 0; j < c._nearbyEntitiesBufferGroup[entity].Length; j++)
			{
				Entity entity3 = c._nearbyEntitiesBufferGroup[entity][j].entity;
				if (!c._localTransformGroup.HasComponent(entity3))
				{
					continue;
				}
				LocalTransform localTransform3 = c._localTransformGroup[entity3];
				float num4 = math.distancesq(localTransform3.Position, localTransform.Position);
				if (!(num4 < num) || !(num4 < num2) || c._physicsExcludeGroup.HasAndIsComponentEnabled(entity3))
				{
					continue;
				}
				FactionCD targetFaction2 = (c._factionGroup.HasComponent(entity3) ? c._factionGroup[entity3] : default(FactionCD));
				if (factionCD.CanAttack(targetFaction2, d.worldInfo))
				{
					BehaviourTagsCD attackerBehaviourTags = (c._behaviourTagsGroup.HasComponent(entity) ? c._behaviourTagsGroup[entity] : default(BehaviourTagsCD));
					ObjectCategoryTagsCD targetTags = (c._objectCategoryGroup.HasComponent(entity3) ? c._objectCategoryGroup[entity3] : default(ObjectCategoryTagsCD));
					if (BehaviourTagsCD.WantsToAndCanAttack(attackerBehaviourTags, targetTags))
					{
						entity2 = entity3;
						float6 = localTransform3.Position;
						num = num4;
					}
				}
			}
		}
		if (entity2 == Entity.Null && value.cooldownTimer.isRunning && !value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
		{
			c._slimeBossJumpStateGroup[entity] = value;
			return;
		}
		value.cooldownTimer.Stop();
		float num5 = math.distance(spawnPointCD.position, float6);
		float num6 = 25f;
		if (entity2 == Entity.Null || num5 > num6)
		{
			value.targetPos = spawnPointCD.position;
			entity2 = Entity.Null;
		}
		else
		{
			value.targetPos = float6;
		}
		float num7 = math.distance(spawnPointCD.position, localTransform.Position);
		bool flag = num7 < 2f;
		if (entity2 == Entity.Null && flag)
		{
			value.cooldownTimer.Start(d._elapsedTime, 10f);
		}
		value.internalState = 0;
		if (value.isReseting)
		{
			value.target = Entity.Null;
			value.targetPos = spawnPointCD.position;
			stateInfo.EnterState(StateID.SlimeBossTauntJump);
			if (num7 <= 5f)
			{
				value.isReseting = false;
			}
		}
		else
		{
			value.isReseting = value.target != Entity.Null && entity2 == Entity.Null && num7 > 5f;
			value.target = entity2;
			if (value.isReseting || entity2 == Entity.Null)
			{
				stateInfo.EnterState(StateID.SlimeBossTauntJump);
			}
			else
			{
				stateInfo.EnterState(StateID.SlimeBossJump);
			}
		}
		c._slimeBossJumpStateGroup[entity] = value;
	}
}
