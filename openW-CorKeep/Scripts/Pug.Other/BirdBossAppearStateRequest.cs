using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct BirdBossAppearStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._birdAppearStateGroup.HasComponent(entity) && c._teleportStateGroup.HasComponent(entity) && c._seasonalLootGroup.HasComponent(entity) && c._bossGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._birdHasAppearedGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.BirdBossAppear) || c._birdHasAppearedGroup[entity].Value)
		{
			return;
		}
		BirdBossAppearStateCD value = c._birdAppearStateGroup[entity];
		TeleportStateCD value2 = c._teleportStateGroup[entity];
		SeasonalLootCD componentData;
		bool flag = c._seasonalLootGroup.TryGetComponent(entity, out componentData);
		BossCD value3 = c._bossGroup[entity];
		if (c._isInCombatGroup[entity].isInCombat)
		{
			value.internalState = 0;
			stateInfo.EnterState(StateID.BirdBossAppear);
		}
		Entity entity2 = Entity.Null;
		bool flag2 = false;
		bool flag3 = false;
		Entity entity3 = Entity.Null;
		for (int i = 0; i < d.spawnLocationEntities.Length; i++)
		{
			entity3 = d.spawnLocationEntities[i];
			if (c._bossSpawnLocationGroup[entity3].bossID != ObjectID.BirdBoss)
			{
				continue;
			}
			for (int j = 0; j < c._nearbyEntitiesBufferGroup[entity3].Length; j++)
			{
				Entity entity4 = c._nearbyEntitiesBufferGroup[entity3][j].entity;
				if (c._objectDataGroup.HasComponent(entity4))
				{
					ObjectID objectID = c._objectDataGroup[entity4].objectID;
					if (objectID == ObjectID.LargeShinyGlimmeringObject || objectID == ObjectID.EasterGoldenEgg)
					{
						entity2 = entity4;
						flag2 = true;
						flag3 = objectID == ObjectID.EasterGoldenEgg;
						break;
					}
				}
			}
			if (flag2)
			{
				break;
			}
		}
		if (flag2)
		{
			LocalTransform component = c._localTransformGroup[entity2];
			ecb.SetComponent(entity, component);
			float3 position = c._localTransformGroup[entity3].Position;
			value2.positionToStayWithin = position;
			value.glimmeringObject = entity2;
			ObjectDataCD component2 = c._objectDataGroup[entity];
			component2.variation = (flag3 ? 1 : 0);
			ecb.SetComponent(entity, component2);
			value3.spawnOptionalChest = flag3;
			componentData.requirementToDropFulfilled = flag3;
			value.internalState = 0;
			stateInfo.EnterState(StateID.BirdBossAppear);
		}
		c._birdAppearStateGroup[entity] = value;
		c._teleportStateGroup[entity] = value2;
		if (flag)
		{
			c._seasonalLootGroup[entity] = componentData;
		}
		c._bossGroup[entity] = value3;
	}
}
