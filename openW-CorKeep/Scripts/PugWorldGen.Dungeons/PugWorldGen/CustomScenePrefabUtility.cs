using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace PugWorldGen
{
	public static class CustomScenePrefabUtility
	{
		public struct Lookups
		{
			[ReadOnly]
			public ComponentLookup<AddRandomLootCD> AddRandomLootLookup;

			[ReadOnly]
			public ComponentLookup<DirectionCD> DirectionLookup;

			[ReadOnly]
			public ComponentLookup<PaintableObjectCD> PaintableObjectLookup;

			[ReadOnly]
			public BufferLookup<ContainedObjectsBuffer> ContainedObjectsBufferLookup;

			public Lookups(ref SystemState state)
			{
				AddRandomLootLookup = state.GetComponentLookup<AddRandomLootCD>(isReadOnly: true);
				DirectionLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
				PaintableObjectLookup = state.GetComponentLookup<PaintableObjectCD>(isReadOnly: true);
				ContainedObjectsBufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			}

			public void Update(ref SystemState state)
			{
				AddRandomLootLookup.Update(ref state);
				DirectionLookup.Update(ref state);
				PaintableObjectLookup.Update(ref state);
				ContainedObjectsBufferLookup.Update(ref state);
			}
		}

		public struct Data
		{
			[ReadOnly]
			public NativeArray<DataBlockAddress> ActiveContentBundles;

			public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;
		}

		public static Entity CreateWithOverrides(EntityCommandBuffer ecb, int scenePrefabIndex, ref CustomSceneBlob blob, Lookups lookups, Data data)
		{
			Entity entity = ecb.Instantiate(blob.prefabs[scenePrefabIndex]);
			ecb.AddComponent<CustomSceneObjectCD>(entity);
			ApplyOverrides(ecb, entity, scenePrefabIndex, ref blob, lookups, data);
			return entity;
		}

		public static void ApplyOverrides(EntityCommandBuffer ecb, Entity entity, int scenePrefabIndex, ref CustomSceneBlob blob, Lookups lookups, Data data)
		{
			Entity prefabEntity = blob.prefabs[scenePrefabIndex];
			ApplyDirectionOverrides(ecb, entity, prefabEntity, blob.prefabDirections[scenePrefabIndex], lookups);
			ApplyColorOverrides(ecb, entity, prefabEntity, blob.prefabColors[scenePrefabIndex], lookups);
			ref InventoryOverrideData inventoryOverride = ref blob.prefabInventoryOverrides[scenePrefabIndex];
			ApplyInventoryOverrides(ecb, entity, blob.prefabs[scenePrefabIndex], ref inventoryOverride, lookups, data);
		}

		private static void ApplyDirectionOverrides(EntityCommandBuffer ecb, Entity entity, Entity prefabEntity, OptionalValue<float3> directionOverride, Lookups lookups)
		{
			if (directionOverride.TryGetValue(out var output) && lookups.DirectionLookup.TryGetComponent(prefabEntity, out var componentData))
			{
				componentData.direction = output;
				ecb.SetComponent(entity, componentData);
			}
		}

		private static void ApplyColorOverrides(EntityCommandBuffer ecb, Entity entity, Entity prefabEntity, OptionalValue<PaintableColor> colorOverride, Lookups lookups)
		{
			if (colorOverride.TryGetValue(out var output) && lookups.PaintableObjectLookup.TryGetComponent(prefabEntity, out var componentData))
			{
				componentData.color = output;
				ecb.SetComponent(entity, componentData);
			}
		}

		private static void ApplyInventoryOverrides(EntityCommandBuffer ecb, Entity entity, Entity prefabEntity, ref InventoryOverrideData inventoryOverride, Lookups lookups, Data data)
		{
			if (!inventoryOverride.hasAnyInventoryOverride)
			{
				return;
			}
			if (inventoryOverride.hasLootTableOverride)
			{
				AddRandomLootCD component = new AddRandomLootCD
				{
					lootTableID = inventoryOverride.lootTableOverride
				};
				if (lookups.AddRandomLootLookup.HasComponent(prefabEntity))
				{
					ecb.SetComponent(entity, component);
				}
				else
				{
					ecb.AddComponent(entity, component);
				}
			}
			if (!inventoryOverride.hasItemsOverride || !lookups.ContainedObjectsBufferLookup.TryGetBuffer(prefabEntity, out var bufferData))
			{
				return;
			}
			DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = ecb.SetBuffer<ContainedObjectsBuffer>(entity);
			dynamicBuffer.CopyFrom(bufferData);
			for (int i = 0; i < inventoryOverride.itemsToRemove; i++)
			{
				dynamicBuffer[i] = default(ContainedObjectsBuffer);
			}
			int num = 0;
			for (int j = 0; j < inventoryOverride.itemsOverride.Length; j++)
			{
				InitialInventoryItem initialInventoryItem = inventoryOverride.itemsOverride[j];
				if (initialInventoryItem.requiredContentBundle.TryGetValue(out var output) && !Contains(data.ActiveContentBundles, output))
				{
					continue;
				}
				ObjectData item = initialInventoryItem.item;
				if (item.objectID == ObjectID.None)
				{
					item.amount = 0;
				}
				else
				{
					ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(item.objectID, data.Database, item.variation);
					if (entityObjectInfo.objectID == ObjectID.None)
					{
						Debug.LogError($"Object {item.objectID} {item.variation} in not found in database");
						item.amount = 0;
					}
					if (!entityObjectInfo.isStackable)
					{
						item.amount = entityObjectInfo.initialAmount;
					}
				}
				if (num >= dynamicBuffer.Length)
				{
					Debug.LogError($"Not enough space in inventory to add override item {item.objectID} x{item.amount} (variation {item.variation}) to custom scene entity");
					continue;
				}
				dynamicBuffer[num++] = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = item.objectID,
						variation = item.variation,
						amount = item.amount
					}
				};
			}
		}

		private static bool Contains(NativeArray<DataBlockAddress> array, DataBlockAddress value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
				{
					return true;
				}
			}
			return false;
		}
	}
}
