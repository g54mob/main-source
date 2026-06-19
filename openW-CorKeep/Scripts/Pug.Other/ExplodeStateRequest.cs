using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ExplodeStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._explodeStateGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._behaviourTagsGroup.HasComponent(entity))
		{
			return c._healthGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.Explode))
		{
			return;
		}
		ExplodeStateCD value = c._explodeStateGroup[entity];
		if (!c._nearbyEntitiesTrackerGroup.HasComponent(entity) || !c._nearbyEntitiesBufferGroup.HasComponent(entity))
		{
			value.internalState = 0;
			value.internalTimer.Stop();
			stateInfo.EnterState(StateID.Explode);
		}
		else
		{
			if (c._healthGroup[entity].Normalized >= value.minHealthRatioToExplode)
			{
				return;
			}
			LocalTransform localTransform = c._localTransformGroup[entity];
			DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
			BehaviourTagsCD attackerBehaviourTags = c._behaviourTagsGroup[entity];
			FactionCD factionCD = (c._factionGroup.HasComponent(entity) ? c._factionGroup[entity] : default(FactionCD));
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				Entity entity2 = dynamicBuffer[i].entity;
				Entity entity3 = entity2;
				EntityPartCD componentData2;
				if (c._playerGhostExtrapolatedGroup.TryGetComponent(entity2, out var componentData))
				{
					entity3 = componentData.playerGhost;
				}
				else if (c._entityPartGroup.TryGetComponent(entity2, out componentData2))
				{
					entity3 = componentData2.mainEntity;
				}
				else if (c._playerGhostGroup.HasComponent(entity2))
				{
					continue;
				}
				if ((!c._enemyGroup.HasComponent(entity3) && !c._playerGhostGroup.HasComponent(entity3)) || !c._objectDataGroup.HasComponent(entity3) || (c._entityDestroyedGroup.HasComponent(entity3) && c._entityDestroyedGroup.IsComponentEnabled(entity3)))
				{
					continue;
				}
				FactionCD targetFaction = (c._factionGroup.HasComponent(entity3) ? c._factionGroup[entity3] : default(FactionCD));
				if (!factionCD.CanAttack(targetFaction, d.worldInfo))
				{
					continue;
				}
				bool flag = false;
				if (c._objectCategoryTagsGroup.TryGetComponent(entity3, out var componentData3))
				{
					flag = BehaviourTagsCD.WantsToAndCanAttack(attackerBehaviourTags, componentData3);
				}
				if (flag)
				{
					float3 position = localTransform.Position;
					if (math.length(c._localTransformGroup[entity2].Position - position) < value.distanceToExplode)
					{
						value.internalState = 0;
						value.internalTimer.Stop();
						stateInfo.EnterState(StateID.Explode);
						break;
					}
				}
			}
			c._explodeStateGroup[entity] = value;
		}
	}
}
