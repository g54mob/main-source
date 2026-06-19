using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ScarabBossAppearStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._scarabAppearStateGroup.HasComponent(entity) && c._bossGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._scarabHasAppearedGroup.HasComponent(entity))
		{
			return c._isInCombatGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.ScarabBossAppear) || c._scarabHasAppearedGroup[entity].Value)
		{
			return;
		}
		ScarabBossAppearStateCD value = c._scarabAppearStateGroup[entity];
		if (c._isInCombatGroup[entity].isInCombat)
		{
			value.internalState = 0;
			stateInfo.EnterState(StateID.ScarabBossAppear);
		}
		Entity entity2 = Entity.Null;
		bool flag = false;
		for (int i = 0; i < d.spawnLocationEntities.Length; i++)
		{
			Entity entity3 = d.spawnLocationEntities[i];
			if (c._bossSpawnLocationGroup[entity3].bossID != ObjectID.ScarabBoss)
			{
				continue;
			}
			for (int j = 0; j < c._nearbyEntitiesBufferGroup[entity3].Length; j++)
			{
				Entity entity4 = c._nearbyEntitiesBufferGroup[entity3][j].entity;
				if (c._objectDataGroup.HasComponent(entity4) && c._objectDataGroup[entity4].objectID == ObjectID.Thumper)
				{
					entity2 = entity4;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (flag)
		{
			LocalTransform component = c._localTransformGroup[entity2];
			ecb.SetComponent(entity, component);
			value.thumperEntity = entity2;
			value.internalState = 0;
			stateInfo.EnterState(StateID.ScarabBossAppear);
		}
		c._scarabAppearStateGroup[entity] = value;
	}
}
