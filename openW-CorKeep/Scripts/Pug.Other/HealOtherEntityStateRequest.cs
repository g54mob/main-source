using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct HealOtherEntityStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._healOtherStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._nearbyEntitiesTrackerGroup.HasComponent(entity) && c._nearbyEntitiesBufferGroup.HasComponent(entity))
		{
			return c._behaviourTagsGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		HealOtherEntityStateCD value = c._healOtherStateGroup[entity];
		if (value.isDisabled || stateInfo.HasState(StateID.HealOtherEntity))
		{
			return;
		}
		LocalTransform localTransform = c._localTransformGroup[entity];
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
		if (value.cooldownTimer.isRunning && !value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
		{
			value.targetEntity = Entity.Null;
			c._healOtherStateGroup[entity] = value;
			return;
		}
		FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
		bool flag = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			Entity entity2 = dynamicBuffer[i].entity;
			Entity entity3 = entity2;
			if (c._playerGhostExtrapolatedGroup.HasComponent(entity2))
			{
				entity3 = c._playerGhostExtrapolatedGroup[entity2].playerGhost;
			}
			else if (c._entityPartGroup.HasComponent(entity2))
			{
				entity3 = c._entityPartGroup[entity2].mainEntity;
			}
			if (!c._isBeingHealedByOtherGroup.HasComponent(entity2))
			{
				continue;
			}
			if (c._healthGroup.HasComponent(entity2))
			{
				HealthCD healthCD = c._healthGroup[entity2];
				bool flag2 = c._conditionEffectBufferGroup.HasComponent(entity2);
				if ((flag2 && healthCD.HasFullHealthIncludingConditions(c._conditionEffectBufferGroup[entity2])) || (!flag2 && healthCD.HasFullHealth))
				{
					continue;
				}
			}
			if (!c._objectDataGroup.HasComponent(entity3) || (c._entityDestroyedGroup.HasComponent(entity3) && c._entityDestroyedGroup.IsComponentEnabled(entity3)))
			{
				continue;
			}
			c._factionGroup.TryGetComponent(entity3, out var componentData);
			if (!factionCD.CanHeal(componentData, d.worldInfo))
			{
				continue;
			}
			flag = true;
			float3 position = localTransform.Position;
			float3 position2 = c._localTransformGroup[entity2].Position;
			if (!(math.length(position2 - position) < value.maxReachDistance))
			{
				continue;
			}
			if (!value.skipVisibilityCheck)
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
				if (d.collisionWorld.CastRay(input))
				{
					continue;
				}
				bool flag3 = false;
				int2 int5 = position.RoundToInt2();
				int2 end = position2.RoundToInt2();
				int2 pos = int5;
				do
				{
					if (d.tileLookup.GetTopType(pos).IsWallTile())
					{
						flag3 = true;
						break;
					}
				}
				while (MathUtilities.NextPosOnLine(int5, end, ref pos));
				if (flag3)
				{
					continue;
				}
			}
			value.targetEntity = entity3;
			value.internalState = 0;
			value.internalTimer.Stop();
			stateInfo.EnterState(StateID.HealOtherEntity);
			break;
		}
		if (!flag)
		{
			value.cooldownTimer.Start(d._elapsedTime, d._rng.NextFloat(value.minCooldown, value.maxCooldown));
		}
		c._healOtherStateGroup[entity] = value;
	}
}
