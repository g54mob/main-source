using System.Runtime.InteropServices;
using Pug.Properties;
using Unity.Collections;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct CombatEmoteSystemRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._combatEmoteStateGroup.HasComponent(entity) && c._isInCombatGroup.HasComponent(entity) && c._behaviourTagsGroup.HasComponent(entity))
		{
			return c._nearbyEntitiesBufferGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.CombatEmoting))
		{
			return;
		}
		ObjectPropertiesCD objectPropertiesCD = c._propertiesGroup[entity];
		CombatEmoteStateCD value = c._combatEmoteStateGroup[entity];
		IsInCombatCD isInCombatCD = c._isInCombatGroup[entity];
		BehaviourTagsCD attackerBehaviourTags = c._behaviourTagsGroup[entity];
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
		using NativeArray<CombatEmoteAnimationData> nativeArray = objectPropertiesCD.GetList<CombatEmoteAnimationData>(1971396561, Allocator.Temp);
		float num = objectPropertiesCD.Get<float>(622656567);
		float min = objectPropertiesCD.Get<float>(-1433175333);
		float max = objectPropertiesCD.Get<float>(1721631188);
		if (isInCombatCD.isInCombat && nativeArray.Length > 0)
		{
			if (!value.cooldownTimer.isRunning)
			{
				if (isInCombatCD.justEnteredCombat && num > 0f)
				{
					if (d._rng.NextFloat() < num)
					{
						value.cooldownTimer.Start(d._elapsedTime, 0f);
					}
				}
				else
				{
					value.cooldownTimer.Start(d._elapsedTime, d._rng.NextFloat(min, max));
				}
			}
			else if (value.cooldownTimer.IsTimerElapsed(d._elapsedTime))
			{
				value.optionalTarget = Entity.Null;
				if (dynamicBuffer.Length > 0)
				{
					NativeList<Entity> nativeList = new NativeList<Entity>(Allocator.Temp);
					for (int i = 0; i < dynamicBuffer.Length; i++)
					{
						Entity value2 = dynamicBuffer[i].entity;
						FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
						if (c._objectDataGroup.HasComponent(value2) && (!c._entityDestroyedGroup.HasComponent(value2) || !c._entityDestroyedGroup.IsComponentEnabled(value2)) && !c._physicsExcludeGroup.HasAndIsComponentEnabled(value2))
						{
							FactionCD targetFaction = (c._factionGroup.HasComponent(value2) ? c._factionGroup[value2] : default(FactionCD));
							if (factionCD.CanAttack(targetFaction, d.worldInfo) && (!c._objectCategoryGroup.HasComponent(value2) || !BehaviourTagsCD.CantAttack(attackerBehaviourTags, c._objectCategoryGroup[value2])))
							{
								nativeList.Add(in value2);
							}
						}
					}
					value.optionalTarget = dynamicBuffer[d._rng.NextInt(0, nativeList.Length)].entity;
					nativeList.Dispose();
				}
				value.internalState = CombatEmoteStateCD.InternalState.Init;
				value.cooldownTimer.Start(d._elapsedTime, d._rng.NextFloat(min, max));
				value.animationIndexToPlay = d._rng.NextInt(0, nativeArray.Length);
				stateInfo.EnterState(StateID.CombatEmoting);
			}
		}
		c._combatEmoteStateGroup[entity] = value;
	}
}
