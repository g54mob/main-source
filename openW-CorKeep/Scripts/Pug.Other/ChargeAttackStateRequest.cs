using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ChargeAttackStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._chargeStateGroup.HasComponent(entity) && c._physicsColliderGroup.HasComponent(entity) && c._nearbyEntitiesBufferGroup.HasComponent(entity))
		{
			return c._behaviourTagsGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.Charge) || stateInfo.IsCurrentState(StateID.Sleep) || stateInfo.IsCurrentState(StateID.MeleeAttack) || stateInfo.IsCurrentState(StateID.RangeAttack) || stateInfo.IsCurrentState(StateID.IdleEmoting) || stateInfo.IsCurrentState(StateID.CombatEmoting))
		{
			return;
		}
		ChargeAttackStateCD value = c._chargeStateGroup[entity];
		ObjectPropertiesCD objectPropertiesCD = c._propertiesGroup[entity];
		if (!value.cooldownTimer.isRunning)
		{
			float min = objectPropertiesCD.Get<float>(2044058172);
			float max = objectPropertiesCD.Get<float>(-1244094157);
			value.cooldownTimer.Start(d._elapsedTime, d._rng.NextFloat(min, max));
			c._chargeStateGroup[entity] = value;
			return;
		}
		if (value.cooldownTimer.isRunning && !value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
		{
			c._chargeStateGroup[entity] = value;
			return;
		}
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
		BehaviourTagsCD attackerBehaviourTags = c._behaviourTagsGroup[entity];
		float3 position = c._localTransformGroup[entity].Position;
		float3 frompos = position + new float3(0f, 0.5f, 0f);
		FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			Entity entity2 = dynamicBuffer[i].entity;
			Entity entity3 = entity2;
			bool flag = false;
			if (c._entityPartGroup.HasComponent(entity2))
			{
				entity3 = c._entityPartGroup[entity2].mainEntity;
			}
			if ((!c._entityDestroyedGroup.HasComponent(entity3) || !c._entityDestroyedGroup.IsComponentEnabled(entity3)) && !c._physicsExcludeGroup.HasAndIsComponentEnabled(entity3) && c._objectDataGroup.HasComponent(entity3))
			{
				if (c._objectCategoryGroup.TryGetComponent(entity3, out var componentData) && BehaviourTagsCD.CantAttack(attackerBehaviourTags, componentData))
				{
					continue;
				}
				FactionCD targetFaction = (c._factionGroup.HasComponent(entity3) ? c._factionGroup[entity3] : default(FactionCD));
				flag = c._objectCategoryGroup.HasComponent(entity3) && ObjectCategoryTagsCD.HasAnyMatches(attackerBehaviourTags.wantsToAttackTagsBitMask, c._objectCategoryGroup[entity3].tagsBitMask) && factionCD.CanAttack(targetFaction, d.worldInfo);
			}
			if (!flag)
			{
				continue;
			}
			float3 position2 = c._localTransformGroup[entity2].Position;
			float num = objectPropertiesCD.Get<float>(1820822350);
			if (num != 0f && math.distance(position2, position) > num)
			{
				continue;
			}
			bool flag2 = objectPropertiesCD.Has(1136787668);
			float3 topos = position2 + new float3(0f, 0.5f, 0f);
			uint layerMaskCollidesWith = (flag2 ? 1u : 131329u);
			RaycastInput raycastInput = PhysicsManager.GetRaycastInput(frompos, topos, uint.MaxValue, layerMaskCollidesWith);
			if (d.collisionWorld.CastRay(raycastInput))
			{
				continue;
			}
			bool flag3 = false;
			int2 int5 = position.RoundToInt2();
			int2 end = position2.RoundToInt2();
			int2 pos = int5;
			do
			{
				if (d.tileLookup.TryGetBlockingTile(pos, out var _, !flag2))
				{
					flag3 = true;
					break;
				}
			}
			while (MathUtilities.NextPosOnLine(int5, end, ref pos));
			if (!flag3)
			{
				value.internalState = ChargeAttackInternalState.ChargeAnticipation;
				value.targetEntity = entity2;
				value.targetDirection = math.normalizesafe(position2 - position);
				value.cooldownTimer.Stop();
				value.internalTimer.Stop();
				stateInfo.EnterState(StateID.Charge);
			}
		}
		c._chargeStateGroup[entity] = value;
	}
}
