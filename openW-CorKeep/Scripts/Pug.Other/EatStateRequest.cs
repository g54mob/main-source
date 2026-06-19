using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct EatStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._eatStateGroup.HasComponent(entity) && c._nearbyEntitiesBufferGroup.HasComponent(entity) && c._behaviourTagsGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity))
		{
			return c._objectDataGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.Eat))
		{
			return;
		}
		EatStateCD value = c._eatStateGroup[entity];
		if (c._objectDataGroup[entity].amount >= value.maxFoodUntilFull)
		{
			return;
		}
		BehaviourTagsCD eaterBehaviourTags = c._behaviourTagsGroup[entity];
		float3 position = c._localTransformGroup[entity].Position;
		DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = c._nearbyEntitiesBufferGroup[entity];
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			Entity entity2 = dynamicBuffer[i].entity;
			if (!c._objectDataGroup.HasComponent(entity2))
			{
				continue;
			}
			bool flag = false;
			float2 float5 = c._localTransformGroup[entity2].Position.ToFloat2();
			ObjectDataCD objectDataCD = c._objectDataGroup[entity2];
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, d.database, objectDataCD.variation);
			int2 size = entityObjectInfo.prefabTileSize;
			int2 offset = entityObjectInfo.prefabCornerOffset;
			if (c._directionGroup.HasComponent(entity2))
			{
				c._directionGroup[entity2].GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
			}
			for (int j = offset.y; j < offset.y + size.y; j++)
			{
				for (int k = offset.x; k < offset.x + size.x; k++)
				{
					if (math.distancesq(float5 + new float2(k, j), position.ToFloat2()) <= value.sqDistanceToEat)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			ObjectID objectIdToEat = ObjectID.None;
			if (c._equippedObjectGroup.TryGetComponent(entity2, out var componentData))
			{
				ContainedObjectsBuffer containedObject = componentData.containedObject;
				if (containedObject.objectID != ObjectID.None)
				{
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObject.objectID, d.database);
					if (c._objectCategoryTagsGroup.TryGetComponent(primaryPrefabEntity, out var componentData2) && BehaviourTagsCD.Eats(eaterBehaviourTags, componentData2))
					{
						flag2 = true;
						flag3 = true;
						objectIdToEat = componentData.containedObject.objectID;
					}
				}
			}
			if (c._objectDataGroup.HasComponent(entity2) && c._objectDataGroup[entity2].objectID == ObjectID.CattleFeedTray && c._containedObjectsBufferGroup.HasComponent(entity2))
			{
				NativeList<int> nativeList = new NativeList<int>(Allocator.Temp);
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = c._containedObjectsBufferGroup[entity2];
				for (int l = 0; l < dynamicBuffer2.Length; l++)
				{
					if (dynamicBuffer2[l].amount > 0)
					{
						Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(dynamicBuffer2[l].objectID, d.database);
						if (c._objectCategoryTagsGroup.TryGetComponent(primaryPrefabEntity2, out var componentData3) && BehaviourTagsCD.Eats(eaterBehaviourTags, componentData3))
						{
							nativeList.Add(in l);
						}
					}
				}
				if (nativeList.Length > 0)
				{
					objectIdToEat = dynamicBuffer2[nativeList[d._rng.NextInt(0, nativeList.Length)]].objectID;
					flag2 = true;
					flag4 = true;
				}
				nativeList.Dispose();
			}
			if (!flag2 && c._objectCategoryTagsGroup.TryGetComponent(entity2, out var componentData4) && BehaviourTagsCD.Eats(eaterBehaviourTags, componentData4))
			{
				flag2 = true;
			}
			if (flag2)
			{
				value.internalState = 0;
				value.entityToEatFrom = entity2;
				if (flag3)
				{
					value.objectToEatType = EatStateCD.ObjectToEatType.HeldEntity;
					value.objectIdToEat = objectIdToEat;
				}
				else if (flag4)
				{
					value.objectToEatType = EatStateCD.ObjectToEatType.ContainedEntity;
					value.objectIdToEat = objectIdToEat;
				}
				else
				{
					value.objectToEatType = EatStateCD.ObjectToEatType.Entity;
					value.objectIdToEat = ObjectID.None;
				}
				stateInfo.EnterState(StateID.Eat);
				break;
			}
		}
		c._eatStateGroup[entity] = value;
	}
}
