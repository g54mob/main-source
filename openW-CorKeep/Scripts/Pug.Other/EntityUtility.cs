using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Inventory;
using PlayerEquipment;
using PlayerState;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;

public static class EntityUtility
{
	public struct EntityComponentLookup
	{
		private EntityStorageInfo entityStorageInfo;

		private EntityManager entityManager;

		public EntityComponentLookup(EntityStorageInfo entityStorageInfo, World world)
		{
			this.entityStorageInfo = entityStorageInfo;
			entityManager = world.EntityManager;
		}

		public bool HasComponentData<T>()
		{
			return entityStorageInfo.Chunk.Has<T>();
		}

		public T GetComponentData<T>(ComponentTypeHandle<T> componentTypeHandle) where T : unmanaged, IComponentData
		{
			entityManager.CompleteDependencyBeforeRO<T>();
			NativeArray<T> nativeArray = entityStorageInfo.Chunk.GetNativeArray(ref componentTypeHandle);
			if (nativeArray.IsCreated)
			{
				return nativeArray[entityStorageInfo.IndexInChunk];
			}
			return default(T);
		}
	}

	public struct OwnerInfo
	{
		public Entity attacker;

		public Entity immediateOwner;

		public Entity playerOwner;

		public Entity petOwner;

		public Entity minionOwner;

		public Entity targetableOwner;

		public Entity entityToBeAffectedByConditionChanges;

		public bool isBoss;

		public bool isMinion;

		public bool isPet;
	}

	public enum TileRayCastType
	{
		Walls = 0,
		Solid = 1,
		NonWalkable = 2
	}

	private static readonly float3 defaultSpawnPosition = new float3(0f, 10f, 0f);

	private const ulong kFNV1A64OffsetBasis = 14695981039346656037uL;

	private const ulong kFNV1A64Prime = 1099511628211uL;

	public static ObjectDataCD GetObjectData(Entity entity, World world)
	{
		return GetComponentData<ObjectDataCD>(entity, world);
	}

	public static ObjectID GetObjectID(Entity entity, World world)
	{
		return GetComponentData<ObjectDataCD>(entity, world).objectID;
	}

	public static int GetAmount(Entity entity, World world)
	{
		return GetComponentData<ObjectDataCD>(entity, world).amount;
	}

	public static int GetVariation(Entity entity, World world)
	{
		return GetComponentData<ObjectDataCD>(entity, world).variation;
	}

	public static ObjectInfo GetObjectInfo(Entity entity, World world)
	{
		ObjectDataCD objectData = GetObjectData(entity, world);
		return PugDatabase.GetObjectInfo(objectData.objectID, objectData.variation);
	}

	public static Entity DuplicateEntity(Entity entity, World world)
	{
		return world.EntityManager.Instantiate(entity);
	}

	public static Entity CreateEntity(World world, Vector3 position, ObjectID objectID, int _amount, BlobAssetReference<PugDatabase.PugDatabaseBank> database, int variation = 0)
	{
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, database, variation);
		if (primaryPrefabEntity == Entity.Null)
		{
			return Entity.Null;
		}
		Entity entity = world.EntityManager.Instantiate(primaryPrefabEntity);
		if (_amount == 0)
		{
			Debug.LogWarning("Spawning entity with amount 0");
		}
		SetAmount(entity, world, _amount);
		world.EntityManager.SetComponentData(entity, LocalTransform.FromPosition(position));
		if (world.EntityManager.HasComponent<RandomCD>(entity))
		{
			world.EntityManager.SetComponentData(entity, (RandomCD)PugRandom.GetRng());
		}
		return entity;
	}

	public static Entity CreateEntity(EntityCommandBuffer.ParallelWriter ecb, int sortKey, float3 position, ObjectID objectID, int _amount, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, int variation = 0)
	{
		Entity prefabEntity;
		return CreateEntity(ecb, sortKey, position, objectID, _amount, entityInfoBank, out prefabEntity, variation);
	}

	public static Entity CreateEntity(EntityCommandBuffer.ParallelWriter ecb, int sortKey, float3 position, ObjectID objectID, int _amount, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, out Entity prefabEntity, int variation = 0)
	{
		prefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, entityInfoBank, variation);
		if (prefabEntity == Entity.Null)
		{
			Debug.LogError($"Could not find entity prefab for {(int)objectID} with variation {variation}. Make sure it is correctly set up in its prefab.");
			return Entity.Null;
		}
		Entity entity = ecb.Instantiate(sortKey, prefabEntity);
		ecb.SetComponent(sortKey, entity, new ObjectDataCD
		{
			objectID = objectID,
			amount = _amount,
			variation = variation
		});
		ecb.SetComponent(sortKey, entity, LocalTransform.FromPosition(position));
		return entity;
	}

	public static Entity CreateEntity(EntityCommandBuffer ecb, ObjectID objectID, int _amount, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, int variation = 0)
	{
		return CreateEntity(ecb, defaultSpawnPosition, objectID, _amount, entityInfoBank, variation);
	}

	public static Entity CreateEntity(EntityCommandBuffer ecb, float3 position, ObjectID objectID, int _amount, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, int variation = 0)
	{
		Entity prefabEntity;
		return CreateEntity(ecb, position, objectID, _amount, entityInfoBank, out prefabEntity, variation);
	}

	public static Entity CreateEntity(EntityCommandBuffer ecb, float3 position, quaternion rotation, ObjectID objectID, int _amount, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, int variation = 0)
	{
		Entity prefabEntity;
		return CreateEntity(ecb, position, rotation, objectID, _amount, entityInfoBank, out prefabEntity, variation);
	}

	public static Entity CreateEntity(EntityCommandBuffer ecb, float3 position, ObjectID objectID, int _amount, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, out Entity prefabEntity, int variation = 0)
	{
		return CreateEntity(ecb, position, quaternion.identity, objectID, _amount, entityInfoBank, out prefabEntity, variation);
	}

	public static Entity CreateEntity(EntityCommandBuffer ecb, float3 position, quaternion rotation, ObjectID objectID, int _amount, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, out Entity prefabEntity, int variation = 0)
	{
		prefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, entityInfoBank, variation);
		if (prefabEntity == Entity.Null)
		{
			Debug.LogError($"Could not find entity prefab for {(int)objectID} with variation {variation}. Make sure it is correctly set up in its prefab.");
			return Entity.Null;
		}
		Entity entity = ecb.Instantiate(prefabEntity);
		ecb.SetComponent(entity, new ObjectDataCD
		{
			objectID = objectID,
			amount = _amount,
			variation = variation
		});
		ecb.SetComponent(entity, LocalTransform.FromPositionRotation(position, rotation));
		return entity;
	}

	public static void ApplyAuxDataToEntity(EntityCommandBuffer ecb, Entity entity, int auxDataIndex, InventoryAuxDataAccessor inventoryAuxAccessor, ComponentLookup<NameCD> nameCDLookup, ComponentLookup<MealsEatenCD> mealsEatenLookUp, ComponentLookup<BreedToggleCD> breedToggleLookup)
	{
		if (auxDataIndex != 0)
		{
			if (inventoryAuxAccessor.TryGetComponentData(auxDataIndex, nameCDLookup, out var data))
			{
				ecb.SetComponent(entity, data);
			}
			if (inventoryAuxAccessor.TryGetComponentData(auxDataIndex, mealsEatenLookUp, out var data2))
			{
				ecb.SetComponent(entity, data2);
			}
			if (inventoryAuxAccessor.TryGetComponentData(auxDataIndex, breedToggleLookup, out var data3))
			{
				ecb.SetComponent(entity, data3);
			}
		}
	}

	public static Entity CreateEntityWithLoot(EntityCommandBuffer ecb, float3 position, ObjectID objectID, int amount, LootTableID lootTableID, ref Unity.Mathematics.Random rand, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, BlobAssetReference<LootTableBankBlob> lootTable, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, Biome biome, int variation = 0)
	{
		Entity entity = CreateEntity(ecb, position, objectID, amount, entityInfoBank, variation);
		if (entity == Entity.Null)
		{
			return Entity.Null;
		}
		if (lootTableID == LootTableID.Empty)
		{
			return entity;
		}
		using NativeList<PugDatabase.EntityLootData> nativeList = PugDatabase.GetRandomLoot(lootTableID, ref rand, lootTable, entityInfoBank, biome);
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, entityInfoBank);
		if (!containedObjectsBufferLookup.HasComponent(primaryPrefabEntity))
		{
			Debug.LogError("trying to add loot to object without container");
			return entity;
		}
		DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectsBufferLookup[primaryPrefabEntity];
		DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = ecb.SetBuffer<ContainedObjectsBuffer>(entity);
		int i = 0;
		for (int j = 0; j < nativeList.Length; j++)
		{
			for (; i < dynamicBuffer.Length && dynamicBuffer[i].objectData.objectID != ObjectID.None; i++)
			{
				dynamicBuffer2.Add(dynamicBuffer[i]);
			}
			if (i >= dynamicBuffer.Length)
			{
				break;
			}
			if (nativeList[j].objectID != ObjectID.None && nativeList[j].amount > 0)
			{
				dynamicBuffer2.Add(new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = nativeList[j].objectID,
						amount = nativeList[j].amount
					}
				});
				i++;
			}
		}
		for (; i < dynamicBuffer.Length; i++)
		{
			dynamicBuffer2.Add(dynamicBuffer[i]);
		}
		return entity;
	}

	public static Entity CreateEntityWithItems(EntityCommandBuffer ecb, float3 position, ObjectID objectID, int amount, NativeList<ObjectDataCD> items, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup, int variation = 0)
	{
		Entity entity = CreateEntity(ecb, position, objectID, amount, entityInfoBank, variation);
		if (entity == Entity.Null)
		{
			return Entity.Null;
		}
		if (!items.IsCreated || items.Length == 0)
		{
			return entity;
		}
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, entityInfoBank);
		if (!containedObjectsBufferLookup.HasComponent(primaryPrefabEntity))
		{
			Debug.LogError("trying to add loot to object without container");
			return entity;
		}
		DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = containedObjectsBufferLookup[primaryPrefabEntity];
		DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer2 = ecb.SetBuffer<ContainedObjectsBuffer>(entity);
		int i = 0;
		for (int j = 0; j < items.Length; j++)
		{
			for (; i < dynamicBuffer.Length && dynamicBuffer[i].objectData.objectID != ObjectID.None; i++)
			{
				dynamicBuffer2.Add(dynamicBuffer[i]);
			}
			if (i >= dynamicBuffer.Length)
			{
				break;
			}
			if (items[j].objectID != ObjectID.None && items[j].amount > 0)
			{
				dynamicBuffer2.Add(new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = items[j].objectID,
						amount = items[j].amount
					}
				});
				i++;
			}
		}
		for (; i < dynamicBuffer.Length; i++)
		{
			dynamicBuffer2.Add(dynamicBuffer[i]);
		}
		return entity;
	}

	public static int DropLoot(EntityCommandBuffer ecb, LootTableID lootTableID, ref Unity.Mathematics.Random rand, float3 initialPos, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, BlobAssetReference<LootTableBankBlob> lootTableBank, Biome biome, float maxPositionOffset = 0f, Entity pullTowardsPlayerEntity = default(Entity), float lootAmountMultiplier = 1f, DynamicBuffer<ContainedObjectsBuffer> optionalInventoryToPutLootIn = default(DynamicBuffer<ContainedObjectsBuffer>), bool skipCreate = false)
	{
		using NativeList<PugDatabase.EntityLootData> nativeList = PugDatabase.GetRandomLoot(lootTableID, ref rand, lootTableBank, entityInfoBank, biome, lootAmountMultiplier);
		for (int i = 0; i < nativeList.Length; i++)
		{
			if (nativeList[i].objectID == ObjectID.None || nativeList[i].amount <= 0)
			{
				continue;
			}
			ContainedObjectsBuffer containedObjectsBuffer = new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = nativeList[i].objectID,
					amount = nativeList[i].amount
				}
			};
			if (optionalInventoryToPutLootIn.IsCreated && i < optionalInventoryToPutLootIn.Length)
			{
				optionalInventoryToPutLootIn[i] = containedObjectsBuffer;
				continue;
			}
			float3 position = initialPos + new float3(rand.NextFloat(0f - maxPositionOffset, maxPositionOffset), 0f, rand.NextFloat(0f - maxPositionOffset, maxPositionOffset));
			if (skipCreate)
			{
				continue;
			}
			Entity entity = CreateEntity(ecb, position, ObjectID.DroppedItem, 1, entityInfoBank);
			if (!(entity == Entity.Null))
			{
				ecb.SetBuffer<ContainedObjectsBuffer>(entity).Add(containedObjectsBuffer);
				if (pullTowardsPlayerEntity != default(Entity))
				{
					ecb.SetComponent(entity, new PickUpItemCD
					{
						state = PickUpItemState.ForcePickUp,
						targetEntity = pullTowardsPlayerEntity,
						ignoreRayChecksForPickup = false
					});
				}
			}
		}
		return nativeList.Length;
	}

	public static void DropLoot(EntityCommandBuffer ecb, LootTableID lootTableID, ref Unity.Mathematics.Random rand, float3 initialPos, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, BlobAssetReference<LootTableBankBlob> lootTableBank, Biome biome, ref DropLootSystem.LootChest lootChest, int lootChestIndex, float maxPositionOffset = 0f, Entity pullTowardsPlayerEntity = default(Entity), float lootAmountMultiplier = 1f, NativeList<DropLootSystem.LootChestItem> optionalInventoryToPutLootIn = default(NativeList<DropLootSystem.LootChestItem>), bool skipCreate = false)
	{
		using NativeList<PugDatabase.EntityLootData> nativeList = PugDatabase.GetRandomLoot(lootTableID, ref rand, lootTableBank, entityInfoBank, biome, lootAmountMultiplier);
		for (int i = 0; i < nativeList.Length; i++)
		{
			if (nativeList[i].objectID == ObjectID.None || nativeList[i].amount <= 0)
			{
				continue;
			}
			ContainedObjectsBuffer containedObjectsBuffer = new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = nativeList[i].objectID,
					amount = nativeList[i].amount
				}
			};
			if (optionalInventoryToPutLootIn.IsCreated && lootChest.currentSlotIndex < lootChest.inventoryLength)
			{
				DropLootSystem.LootChestItem value = new DropLootSystem.LootChestItem
				{
					chestIndex = lootChestIndex,
					itemInfo = containedObjectsBuffer
				};
				optionalInventoryToPutLootIn.Add(in value);
				lootChest.currentSlotIndex++;
				continue;
			}
			float3 position = initialPos + new float3(rand.NextFloat(0f - maxPositionOffset, maxPositionOffset), 0f, rand.NextFloat(0f - maxPositionOffset, maxPositionOffset));
			if (skipCreate)
			{
				continue;
			}
			Entity entity = CreateEntity(ecb, position, ObjectID.DroppedItem, 1, entityInfoBank);
			if (!(entity == Entity.Null))
			{
				ecb.SetBuffer<ContainedObjectsBuffer>(entity).Add(containedObjectsBuffer);
				if (pullTowardsPlayerEntity != default(Entity))
				{
					ecb.SetComponent(entity, new PickUpItemCD
					{
						state = PickUpItemState.ForcePickUp,
						targetEntity = pullTowardsPlayerEntity,
						ignoreRayChecksForPickup = false
					});
				}
			}
		}
	}

	public static void DropLoot(EntityCommandBuffer.ParallelWriter ecb, int entityInQueryIndex, LootTableID lootTableID, ref Unity.Mathematics.Random rand, float3 initialPos, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, BlobAssetReference<LootTableBankBlob> lootTableBank, Biome biome, float maxPositionOffset = 0f, Entity pullTowardsPlayerEntity = default(Entity), float lootAmountMultiplier = 1f)
	{
		NativeList<PugDatabase.EntityLootData> randomLoot = PugDatabase.GetRandomLoot(lootTableID, ref rand, lootTableBank, entityInfoBank, biome, lootAmountMultiplier);
		for (int i = 0; i < randomLoot.Length; i++)
		{
			if (randomLoot[i].objectID == ObjectID.None || randomLoot[i].amount <= 0)
			{
				continue;
			}
			float3 position = initialPos + new float3(rand.NextFloat(0f - maxPositionOffset, maxPositionOffset), 0f, rand.NextFloat(0f - maxPositionOffset, maxPositionOffset));
			Entity entity = CreateEntity(ecb, entityInQueryIndex, position, ObjectID.DroppedItem, 1, entityInfoBank);
			if (entity != Entity.Null)
			{
				ContainedObjectsBuffer elem = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = randomLoot[i].objectID,
						amount = randomLoot[i].amount
					}
				};
				ecb.SetBuffer<ContainedObjectsBuffer>(entityInQueryIndex, entity).Add(elem);
				if (pullTowardsPlayerEntity != default(Entity))
				{
					ecb.SetComponent(entityInQueryIndex, entity, new PickUpItemCD
					{
						state = PickUpItemState.ForcePickUp,
						targetEntity = pullTowardsPlayerEntity,
						ignoreRayChecksForPickup = false
					});
				}
			}
		}
		randomLoot.Dispose();
	}

	public static void CreateAndDropItem(ObjectID objectID, int variation, int amount, float3 position, Entity pullTowardsEntity, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, EntityCommandBuffer ecb)
	{
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectID, databaseLocal, variation);
		if (entityObjectInfo.isStackable)
		{
			ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = objectID,
					amount = amount,
					variation = variation
				}
			};
			DropNewEntity(ecb, containedObject, position, databaseLocal, pullTowardsEntity);
			return;
		}
		ContainedObjectsBuffer containedObject2 = new ContainedObjectsBuffer
		{
			objectData = new ObjectDataCD
			{
				objectID = objectID,
				amount = entityObjectInfo.initialAmount,
				variation = variation
			}
		};
		for (int i = 0; i < amount; i++)
		{
			DropNewEntity(ecb, containedObject2, position, databaseLocal, pullTowardsEntity);
		}
	}

	public static Entity DropNewEntity(EntityCommandBuffer ecb, ContainedObjectsBuffer containedObject, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> entityInfoBank, Entity pullTowardsPlayerEntity = default(Entity), bool ignoreRayChecksForPickup = false)
	{
		Entity entity = CreateEntity(ecb, position, ObjectID.DroppedItem, 1, entityInfoBank);
		if (entity == Entity.Null)
		{
			return Entity.Null;
		}
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(containedObject.objectID, entityInfoBank, containedObject.variation);
		if (entityObjectInfo.objectID != ObjectID.None && entityObjectInfo.objectType == ObjectType.Pet)
		{
			Entity e = ecb.CreateEntity();
			ecb.AddComponent(e, new PetInitializeAuxDataCD
			{
				EntityContainingPet = entity
			});
			ecb.AddComponent<BlockSaveCD>(e);
		}
		ecb.SetBuffer<ContainedObjectsBuffer>(entity).Add(containedObject);
		if (pullTowardsPlayerEntity != default(Entity))
		{
			ecb.SetComponent(entity, new PickUpItemCD
			{
				state = PickUpItemState.ForcePickUp,
				targetEntity = pullTowardsPlayerEntity,
				ignoreRayChecksForPickup = ignoreRayChecksForPickup
			});
		}
		return entity;
	}

	public static Entity DropNewEntity(World world, ContainedObjectsBuffer containedObject, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> database, Entity pullTowardsPlayerEntity = default(Entity))
	{
		Entity entity = CreateEntity(world, position, ObjectID.DroppedItem, 1, database);
		if (entity == Entity.Null)
		{
			return Entity.Null;
		}
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(containedObject.objectID, containedObject.variation);
		if (objectInfo != null && objectInfo.objectType == ObjectType.Pet)
		{
			Entity entity2 = world.EntityManager.CreateEntity(typeof(PetInitializeAuxDataCD), typeof(BlockSaveCD));
			world.EntityManager.SetComponentData(entity2, new PetInitializeAuxDataCD
			{
				EntityContainingPet = entity
			});
		}
		world.EntityManager.GetBuffer<ContainedObjectsBuffer>(entity).ElementAt(0) = containedObject;
		if (pullTowardsPlayerEntity != default(Entity))
		{
			world.EntityManager.SetComponentData(entity, new PickUpItemCD
			{
				state = PickUpItemState.ForcePickUp,
				targetEntity = pullTowardsPlayerEntity,
				ignoreRayChecksForPickup = false
			});
		}
		return entity;
	}

	public static Entity DropPetInCage(EntityCommandBuffer ecb, ContainedObjectsBuffer containedObject, float3 position, PugDatabase.DatabaseBankCD database, Entity sourceEntity, ComponentLookup<NameCD> nameLookup, ComponentLookup<MealsEatenCD> mealsEatenLookup, ComponentLookup<BreedToggleCD> breedToggleLookup, in InventoryAuxDataSystemDataCD inventoryAuxDataSystemData)
	{
		Entity entity = CreateEntity(ecb, position, ObjectID.DroppedItem, 1, database.databaseBankBlob);
		if (entity == Entity.Null)
		{
			return Entity.Null;
		}
		if (sourceEntity != default(Entity))
		{
			if (nameLookup.TryGetComponent(sourceEntity, out var componentData))
			{
				inventoryAuxDataSystemData.SetOrAllocateComponentDataWithECB(ecb, ref containedObject.auxDataIndex, componentData);
			}
			if (mealsEatenLookup.TryGetComponent(sourceEntity, out var componentData2))
			{
				inventoryAuxDataSystemData.SetOrAllocateComponentDataWithECB(ecb, ref containedObject.auxDataIndex, componentData2);
			}
			if (breedToggleLookup.TryGetComponent(sourceEntity, out var componentData3))
			{
				inventoryAuxDataSystemData.SetOrAllocateComponentDataWithECB(ecb, ref containedObject.auxDataIndex, componentData3);
			}
		}
		ecb.SetBuffer<ContainedObjectsBuffer>(entity).Add(containedObject);
		return entity;
	}

	public static void DestroyEntity(Entity entity, World world)
	{
		if (entity != Entity.Null)
		{
			world.EntityManager.DestroyEntity(entity);
		}
	}

	public static void Destroy(Entity entity, bool dontDrop, Entity killedByEntity, ComponentLookup<HealthCD> healthLookup, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ComponentLookup<DontDropSelfCD> dontDropSelfLookup, ComponentLookup<DontDropLootCD> dontDropLootLookup, ComponentLookup<KilledByPlayerCD> killedByPlayerLookup, ComponentLookup<PlantCD> plantLookup, BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectBufferLookup, ref Unity.Mathematics.Random rng, ComponentLookup<MoveToPredictedByEntityDestroyedCD> moveToPredictedByEntityDestroyedLookup, NetworkTick currentTick)
	{
		if (healthLookup.HasComponent(entity))
		{
			healthLookup.GetRefRW(entity).ValueRW.health = 0;
		}
		else
		{
			entityDestroyedLookup.SetComponentEnabled(entity, value: true);
		}
		if (moveToPredictedByEntityDestroyedLookup.HasComponent(entity))
		{
			moveToPredictedByEntityDestroyedLookup.GetRefRW(entity).ValueRW.SetLastInteractionTick(currentTick);
		}
		if (dontDrop)
		{
			if (dontDropSelfLookup.HasComponent(entity))
			{
				dontDropSelfLookup.SetComponentEnabled(entity, value: true);
			}
			if (dontDropLootLookup.HasComponent(entity))
			{
				dontDropLootLookup.SetComponentEnabled(entity, value: true);
			}
		}
		if (killedByPlayerLookup.HasComponent(entity))
		{
			ref KilledByPlayerCD valueRW = ref killedByPlayerLookup.GetRefRW(entity).ValueRW;
			valueRW.playerEntity = killedByEntity;
			valueRW.shouldPullLootToPlayer = true;
			killedByPlayerLookup.SetComponentEnabled(entity, value: true);
		}
		if (plantLookup.HasComponent(entity))
		{
			int num = PugRandom.GenerateRandomExtraItems((float)GetConditionEffectValue(ConditionEffect.HarvestChance, killedByEntity, summarizedConditionEffectBufferLookup) / 1000f, ref rng);
			if (num > 0)
			{
				plantLookup.GetRefRW(entity).ValueRW.numberOfPlantsToDrop += num;
			}
		}
	}

	public static void DropDestructible(Entity entity, Entity pullTowardsEntity, LookupEquipmentUpdateData equipmentUpdateLookupData, EquipmentUpdateSharedData equipmentUpdateSharedData)
	{
		if (equipmentUpdateSharedData.isFirstTimeFullyPredictingTick && equipmentUpdateLookupData.destructibleLookup.HasComponent(entity) && equipmentUpdateLookupData.objectDataLookup.TryGetComponent(entity, out var componentData) && equipmentUpdateLookupData.localTransformLookup.TryGetComponent(entity, out var componentData2))
		{
			float3 position = componentData2.Position;
			ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = componentData.objectID,
					amount = 1,
					variation = 0
				}
			};
			DropNewEntity(equipmentUpdateSharedData.ecb, containedObject, position, equipmentUpdateSharedData.databaseBank.databaseBankBlob, pullTowardsEntity);
		}
		if (equipmentUpdateLookupData.entityDestroyedLookup.HasComponent(entity))
		{
			equipmentUpdateLookupData.entityDestroyedLookup.SetComponentEnabled(entity, value: true);
		}
		if (equipmentUpdateLookupData.dontDropLootLookup.HasComponent(entity))
		{
			equipmentUpdateLookupData.dontDropLootLookup.SetComponentEnabled(entity, value: true);
		}
		if (equipmentUpdateLookupData.triggerAnimationOnDeathLookup.HasComponent(entity))
		{
			equipmentUpdateLookupData.triggerAnimationOnDeathLookup.SetComponentEnabled(entity, value: false);
		}
		if (equipmentUpdateLookupData.hasExplodedLookup.HasComponent(entity))
		{
			equipmentUpdateLookupData.hasExplodedLookup.SetComponentEnabled(entity, value: true);
		}
	}

	[GenerateTestsForBurstCompatibility]
	public static bool EntityIsDeferred(Entity entity)
	{
		return entity.Index < 0;
	}

	public static EntityComponentLookup GetEntityComponentLookup(Entity entity, World world)
	{
		return new EntityComponentLookup(world.EntityManager.GetStorageInfo(entity), world);
	}

	public static bool HasComponentData<TComponent>(Entity entity, World world)
	{
		return world?.EntityManager.HasComponent<TComponent>(entity) ?? false;
	}

	public static bool RemoveComponentData<TComponent>(Entity entity, World world)
	{
		return world.EntityManager.RemoveComponent<TComponent>(entity);
	}

	public static T GetComponentData<T>(Entity entity, World world) where T : unmanaged, IComponentData
	{
		try
		{
			return world.EntityManager.GetComponentData<T>(entity);
		}
		catch (ArgumentException)
		{
			Debug.LogError($"GetComponentData<{typeof(T)}> called on invalid entity {world.EntityManager.GetName(entity)} ({entity})");
			return default(T);
		}
	}

	public static bool TryGetComponentData<T>(Entity entity, World world, out T value) where T : unmanaged, IComponentData
	{
		if (!HasComponentData<T>(entity, world))
		{
			value = default(T);
			return false;
		}
		value = world.EntityManager.GetComponentData<T>(entity);
		return true;
	}

	public static void SetComponentData<T>(Entity entity, World world, T componentData) where T : unmanaged, IComponentData
	{
		world.EntityManager.SetComponentData(entity, componentData);
	}

	public static void AddComponentData<T>(Entity entity, World world, T componentData) where T : unmanaged, IComponentData
	{
		world.EntityManager.AddComponentData(entity, componentData);
	}

	public static void SetComponentEnabled<T>(Entity entity, World world, bool value) where T : unmanaged, IComponentData, IEnableableComponent
	{
		world.EntityManager.SetComponentEnabled<T>(entity, value);
	}

	public static bool IsComponentEnabled<T>(Entity entity, World world) where T : unmanaged, IComponentData, IEnableableComponent
	{
		return world.EntityManager.IsComponentEnabled<T>(entity);
	}

	public static void AddComponentData<T>(Entity entity, World world) where T : unmanaged, IComponentData
	{
		world.EntityManager.AddComponent<T>(entity);
	}

	public static DynamicBuffer<T> AddBuffer<T>(Entity entity, World world) where T : unmanaged, IBufferElementData
	{
		return world.EntityManager.AddBuffer<T>(entity);
	}

	public static DynamicBuffer<T> GetBuffer<T>(Entity entity, World world) where T : unmanaged, IBufferElementData
	{
		return world.EntityManager.GetBuffer<T>(entity, isReadOnly: true);
	}

	public static bool TryGetBuffer<T>(Entity entity, World world, out DynamicBuffer<T> value) where T : unmanaged, IBufferElementData
	{
		if (!HasComponentData<T>(entity, world))
		{
			value = default(DynamicBuffer<T>);
			return false;
		}
		value = world.EntityManager.GetBuffer<T>(entity, isReadOnly: true);
		return true;
	}

	public static void UpdatePosition(Entity entity, World world, Vector3 position)
	{
		if (HasComponentData<LocalTransform>(entity, world))
		{
			SetComponentData(entity, world, LocalTransform.FromPosition(position));
		}
	}

	public static void SetAmount(Entity entity, World world, int newAmount)
	{
		ObjectDataCD objectData = GetObjectData(entity, world);
		objectData.amount = newAmount;
		SetComponentData(entity, world, objectData);
	}

	public static int AddAmount(Entity entity, World world, int amountToIncrease)
	{
		int num = GetAmount(entity, world) + amountToIncrease;
		SetAmount(entity, world, num);
		return num;
	}

	public static bool EntityExists(Entity entity, World world)
	{
		if (entity != Entity.Null)
		{
			return world.EntityManager.Exists(entity);
		}
		return false;
	}

	public static void DealDamage(in PlayerAttackAspect playerAttackAspect, in PlayerAttackShared playerAttackShared, in PlayerAttackLookups playerAttackLookups, Entity targetEntity, Entity hitEntityPart, Entity damagedByEntity, int int0, float3 position0, int int1, float3 position1, bool wasKilled, bool damagedByExplosion)
	{
		bool skipLootDrop = int0 == int.MaxValue;
		DealDamageToEntity(in playerAttackAspect, in playerAttackShared, in playerAttackLookups, targetEntity, int0, damagedByEntity, int1 == 1, position1.x > 0f, wasKilled, damagedByExplosion, position1.y > 0f, skipLootDrop, position1);
		Entity target = ((hitEntityPart != Entity.Null) ? hitEntityPart : targetEntity);
		if (playerAttackLookups.newCombatantsBufferLookup.HasBuffer(damagedByEntity))
		{
			playerAttackShared.ecb.AppendToBuffer(damagedByEntity, new NewCombatantsBuffer
			{
				Target = target
			});
		}
		if (wasKilled && playerAttackLookups.explodeStateLookup.TryGetComponent(targetEntity, out var componentData) && !componentData.explodeEvenIfKilledByPlayerAtTheSameTime && componentData.explosionEntity != Entity.Null)
		{
			playerAttackShared.ecb.DestroyEntity(componentData.explosionEntity);
			componentData.explosionEntity = Entity.Null;
			playerAttackShared.ecb.SetComponent(targetEntity, componentData);
		}
		if (wasKilled && damagedByExplosion && playerAttackLookups.isExplosiveLookup.HasComponent(targetEntity) && playerAttackLookups.simulateLookup.HasAndIsComponentEnabled(targetEntity))
		{
			playerAttackLookups.isExplosiveLookup.GetRefRW(targetEntity).ValueRW.wasKilledByAnotherExplosive = true;
		}
	}

	public static void DealDamageToEntity(in PlayerAttackAspect playerAttackAspect, in PlayerAttackShared playerAttackShared, in PlayerAttackLookups playerAttackLookups, Entity entity, int damage, Entity damagedByEntity, bool knockedback, bool pullLootToPlayer, bool wasKilled, bool damagedByExplosion, bool bypassMaxDamagePerHit, bool skipLootDrop, float3 damagePosition)
	{
		if (playerAttackLookups.healthLookup.HasComponent(entity))
		{
			playerAttackLookups.healthChangeBufferLookup[playerAttackShared.healthChangeBufferEntity].Add(new HealthChangeBuffer
			{
				healthChange = new HealthChange
				{
					entity = entity,
					amount = -damage,
					causedByEntity = damagedByEntity,
					wasKnockedBack = knockedback,
					pullLootToPlayer = pullLootToPlayer,
					wasKilled = wasKilled,
					damagedByExplosion = damagedByExplosion,
					bypassMaxDamagePerHit = bypassMaxDamagePerHit,
					skipLootDropOnDestroy = skipLootDrop,
					skipWallAndRootsLootDropOnDestroy = skipLootDrop
				}
			});
			if (playerAttackLookups.lastAttackerLookup.HasComponent(entity))
			{
				playerAttackShared.ecb.SetComponent(entity, new LastAttackerCD
				{
					Value = damagedByEntity,
					timer = 10f
				});
			}
		}
	}

	public static bool PointIsBlockedForSpawning(NativeArray<BlockedSpawnArea> blockedSpawnAreas, float2 point, float radius = 0f)
	{
		for (int i = 0; i < blockedSpawnAreas.Length; i++)
		{
			float num = blockedSpawnAreas[i].Radius + radius;
			num *= num;
			if (math.distancesq(blockedSpawnAreas[i].Center, point) <= num)
			{
				return true;
			}
		}
		return false;
	}

	public static float DistanceToNearestBlocker(NativeArray<BlockedSpawnArea> blockedSpawnAreas, float2 point)
	{
		float num = float.MaxValue;
		for (int i = 0; i < blockedSpawnAreas.Length; i++)
		{
			float y = math.distance(blockedSpawnAreas[i].Center, point) - blockedSpawnAreas[i].Radius;
			num = math.min(num, y);
		}
		return num;
	}

	public static ConditionsBuffer GetFirstOccurrenceOfCondition(ConditionID conditionID, DynamicBuffer<ConditionsBuffer> conditionsBuffer)
	{
		for (int i = 0; i < conditionsBuffer.Length; i++)
		{
			if (conditionsBuffer[i].condition.conditionData.conditionID == conditionID)
			{
				return conditionsBuffer[i];
			}
		}
		return default(ConditionsBuffer);
	}

	public static void AddNewCondition(Entity entity, EntityCommandBuffer ecb, ConditionData conditionData)
	{
		ecb.AppendToBuffer(entity, new NewConditionsBuffer
		{
			conditionData = conditionData
		});
	}

	public static void AddNewCondition(Entity entity, int sortKey, EntityCommandBuffer.ParallelWriter ecb, ConditionData conditionData)
	{
		ecb.AppendToBuffer(sortKey, entity, new NewConditionsBuffer
		{
			conditionData = conditionData
		});
	}

	public static void RemoveCondition(Entity entity, EntityCommandBuffer ecb, ConditionID conditionId)
	{
		ecb.AppendToBuffer(entity, new RemoveConditionsBuffer
		{
			conditionId = conditionId
		});
	}

	public static void RemoveCondition(Entity entity, int sortKey, EntityCommandBuffer.ParallelWriter ecb, ConditionID conditionId)
	{
		ecb.AppendToBuffer(sortKey, entity, new RemoveConditionsBuffer
		{
			conditionId = conditionId
		});
	}

	public static void AddOrRefreshCondition(Entity entity, World world, ConditionID id, int value, float duration, ConditionsTableCD conditionsTable, NetworkTick currentTick, uint tickRate)
	{
		ConditionData conditionData = new ConditionData
		{
			conditionID = id,
			value = value,
			duration = duration
		};
		DynamicBuffer<ConditionsBuffer> buffer = world.EntityManager.GetBuffer<ConditionsBuffer>(entity);
		DynamicBuffer<SummarizedConditionsBuffer> buffer2 = world.EntityManager.GetBuffer<SummarizedConditionsBuffer>(entity);
		AddOrRefreshCondition(conditionData, buffer, conditionsTable, currentTick, tickRate, buffer2);
	}

	public static void AddOrRefreshCondition(Entity entity, World world, ConditionData conditionData, ConditionsTableCD conditionsTable, NetworkTick currentTick, uint tickRate)
	{
		DynamicBuffer<ConditionsBuffer> buffer = world.EntityManager.GetBuffer<ConditionsBuffer>(entity);
		DynamicBuffer<SummarizedConditionsBuffer> buffer2 = world.EntityManager.GetBuffer<SummarizedConditionsBuffer>(entity);
		AddOrRefreshCondition(conditionData, buffer, conditionsTable, currentTick, tickRate, buffer2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int AddOrRefreshConditionOverrideStacks(ConditionData conditionData, DynamicBuffer<ConditionsBuffer> conditionsBuffer, ConditionsTableCD conditionsTable, NetworkTick currentTick, uint tickRate)
	{
		ConditionsBuffer conditionsBuffer2 = new ConditionsBuffer
		{
			condition = new Condition
			{
				conditionData = conditionData,
				removeTick = NetworkTimeUtilities.SecondsToTick(conditionData.duration, currentTick, tickRate)
			}
		};
		int i;
		for (i = 0; i < conditionsBuffer.Length; i++)
		{
			if (conditionsBuffer[i].condition.conditionData.conditionID == conditionData.conditionID)
			{
				if (conditionsTable.Value.Value.infos[(int)conditionData.conditionID].isAdditiveWithSelf)
				{
					conditionsBuffer2.condition.conditionData.value += conditionsBuffer[i].condition.conditionData.value;
					conditionsBuffer2.condition.conditionData.value = ConditionExtensions.GetConditionValueForAdditiveMaxCaps(conditionsBuffer2.condition.conditionData.conditionID, conditionsBuffer2.condition.conditionData.value);
				}
				conditionsBuffer[i] = conditionsBuffer2;
				break;
			}
		}
		if (i == conditionsBuffer.Length)
		{
			conditionsBuffer.Add(conditionsBuffer2);
		}
		return i;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int AddOrRefreshCondition(ConditionData conditionData, DynamicBuffer<ConditionsBuffer> conditionsBuffer, ConditionsTableCD conditionsTable, NetworkTick currentTick, uint tickRate, DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer)
	{
		bool flag = false;
		ConditionData conditionData2 = conditionData;
		int i;
		for (i = 0; i < conditionsBuffer.Length; i++)
		{
			if (conditionsBuffer[i].condition.conditionData.conditionID != conditionData2.conditionID)
			{
				continue;
			}
			flag = true;
			if (!ShouldOverrideCondition(conditionsBuffer[i], conditionData2, conditionsTable, currentTick, tickRate))
			{
				continue;
			}
			if (conditionsTable.Value.Value.infos[(int)conditionData2.conditionID].isAdditiveWithSelf)
			{
				conditionData2.value += conditionsBuffer[i].condition.conditionData.value;
				conditionData2.value = ConditionExtensions.GetConditionValueForAdditiveMaxCaps(conditionData2.conditionID, conditionData2.value);
			}
			else
			{
				int stacks = ConditionExtensions.GetStacks(conditionData2.conditionID, conditionsBuffer[i].condition.conditionData.value);
				if (stacks > 0)
				{
					stacks++;
					int newConditionValueFromStacks = ConditionExtensions.GetNewConditionValueFromStacks(conditionData2.conditionID, stacks, summarizedConditionsBuffer);
					if (newConditionValueFromStacks != 0)
					{
						conditionData2.value = newConditionValueFromStacks;
					}
				}
			}
			conditionsBuffer[i] = new ConditionsBuffer
			{
				condition = new Condition
				{
					conditionData = conditionData2,
					removeTick = NetworkTimeUtilities.SecondsToTick(conditionData2.duration, currentTick, tickRate)
				}
			};
			break;
		}
		if (!flag)
		{
			conditionsBuffer.Add(new ConditionsBuffer
			{
				condition = new Condition
				{
					conditionData = conditionData2,
					removeTick = NetworkTimeUtilities.SecondsToTick(conditionData2.duration, currentTick, tickRate)
				}
			});
		}
		return i;
	}

	private static bool ShouldOverrideCondition(ConditionsBuffer currentCondition, ConditionData newCondition, ConditionsTableCD conditionsTable, NetworkTick currentTick, uint tickRate)
	{
		if (conditionsTable.GetConditionInfo(newCondition.conditionID).overrideIfRemainingValueIsHigher)
		{
			float num = NetworkTimeUtilities.TimeBetweenTicksInSeconds(currentTick, currentCondition.condition.removeTick, tickRate);
			float num2 = (float)currentCondition.condition.conditionData.value * num;
			float num3 = (float)newCondition.value * newCondition.duration;
			return num2 <= num3;
		}
		return currentCondition.condition.conditionData.duration <= newCondition.duration;
	}

	public static int RemoveStackAndRefreshCondition(int index, ConditionData conditionData, DynamicBuffer<ConditionsBuffer> conditionsBuffer, DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, float refreshNewDuration, NetworkTick currentTick, uint tickRate, int removeStacks = 1)
	{
		int stacks = ConditionExtensions.GetStacks(conditionData.conditionID, conditionsBuffer[index].condition.conditionData.value);
		stacks -= removeStacks;
		if (stacks > 0)
		{
			conditionData.value = ConditionExtensions.GetNewConditionValueFromStacks(conditionData.conditionID, stacks, summarizedConditionsBuffer);
			conditionsBuffer[index] = new ConditionsBuffer
			{
				condition = new Condition
				{
					conditionData = conditionData,
					removeTick = NetworkTimeUtilities.SecondsToTick(refreshNewDuration, currentTick, tickRate)
				}
			};
		}
		return stacks;
	}

	public static void RemoveCondition(ConditionID conditionID, Entity entity, World world)
	{
		DynamicBuffer<ConditionsBuffer> buffer = world.EntityManager.GetBuffer<ConditionsBuffer>(entity);
		RemoveCondition(conditionID, buffer);
	}

	public static void RemoveCondition(ConditionID conditionID, DynamicBuffer<ConditionsBuffer> conditionsBuffer)
	{
		for (int i = 0; i < conditionsBuffer.Length; i++)
		{
			if (conditionsBuffer[i].condition.conditionData.conditionID == conditionID)
			{
				ConditionsBuffer value = conditionsBuffer[i];
				value.condition.toBeRemoved = true;
				conditionsBuffer[i] = value;
				break;
			}
		}
	}

	public static bool ShouldBeRemovedByActiveEffect(ConditionID conditionID, in DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer)
	{
		if (conditionID == ConditionID.Burning)
		{
			return summarizedConditionEffectsBuffer[63].value > 0;
		}
		return false;
	}

	public static void OnBurningApplied(ref DynamicBuffer<ConditionsBuffer> conditionsBuffer, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, ConditionsTableCD ConditionsTable, NetworkTick CurrentTick, uint TickRate)
	{
		int value = summarizedConditionsBuffer[344].value;
		if (value > 0)
		{
			AddOrRefreshCondition(new ConditionData
			{
				conditionID = ConditionID.ApplyBurningFromBurning,
				value = value
			}, conditionsBuffer, ConditionsTable, CurrentTick, TickRate, summarizedConditionsBuffer);
		}
		int value2 = summarizedConditionsBuffer[345].value;
		if (value2 > 0)
		{
			AddOrRefreshCondition(new ConditionData
			{
				conditionID = ConditionID.DamageIncreaseFromBurning,
				value = value2
			}, conditionsBuffer, ConditionsTable, CurrentTick, TickRate, summarizedConditionsBuffer);
		}
	}

	public static void OnBurningRemoved(ref DynamicBuffer<ConditionsBuffer> conditionsBuffer, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer)
	{
		if (summarizedConditionsBuffer[353].value > 0)
		{
			RemoveCondition(ConditionID.ApplyBurningFromBurning, conditionsBuffer);
		}
		if (summarizedConditionsBuffer[354].value > 0)
		{
			RemoveCondition(ConditionID.DamageIncreaseFromBurning, conditionsBuffer);
		}
	}

	public static void SetSkillCondition(DynamicBuffer<SkillConditionsBuffer> skillConditionsBuffer, ConditionData conditionData)
	{
		SkillConditionsBuffer skillConditionsBuffer2 = new SkillConditionsBuffer
		{
			conditionData = conditionData
		};
		for (int i = 0; i < skillConditionsBuffer.Length; i++)
		{
			if (skillConditionsBuffer[i].conditionData.conditionID == conditionData.conditionID)
			{
				skillConditionsBuffer[i] = skillConditionsBuffer2;
				return;
			}
		}
		skillConditionsBuffer.Add(skillConditionsBuffer2);
	}

	public static void SetSkillTalentCondition(Entity entity, World world, ConditionData conditionData)
	{
		if (!world.EntityManager.HasComponent<SkillTalentConditionsBuffer>(entity))
		{
			return;
		}
		DynamicBuffer<SkillTalentConditionsBuffer> buffer = world.EntityManager.GetBuffer<SkillTalentConditionsBuffer>(entity);
		if (conditionData.value != 0)
		{
			SkillTalentConditionsBuffer skillTalentConditionsBuffer = new SkillTalentConditionsBuffer
			{
				conditionData = conditionData
			};
			for (int i = 0; i < buffer.Length; i++)
			{
				if (buffer[i].conditionData.conditionID == conditionData.conditionID)
				{
					buffer[i] = skillTalentConditionsBuffer;
					return;
				}
			}
			buffer.Add(skillTalentConditionsBuffer);
			return;
		}
		for (int j = 0; j < buffer.Length; j++)
		{
			if (buffer[j].conditionData.conditionID == conditionData.conditionID)
			{
				buffer.RemoveAtSwapBack(j);
				break;
			}
		}
	}

	public static void SetSkillTalentCondition(Entity entity, ConditionData conditionData, BufferLookup<SkillTalentConditionsBuffer> skillTalentConditionsBufferLookup)
	{
		if (!skillTalentConditionsBufferLookup.TryGetBuffer(entity, out var bufferData))
		{
			return;
		}
		if (conditionData.value != 0)
		{
			SkillTalentConditionsBuffer skillTalentConditionsBuffer = new SkillTalentConditionsBuffer
			{
				conditionData = conditionData
			};
			for (int i = 0; i < bufferData.Length; i++)
			{
				if (bufferData[i].conditionData.conditionID == conditionData.conditionID)
				{
					bufferData[i] = skillTalentConditionsBuffer;
					return;
				}
			}
			bufferData.Add(skillTalentConditionsBuffer);
			return;
		}
		for (int j = 0; j < bufferData.Length; j++)
		{
			if (bufferData[j].conditionData.conditionID == conditionData.conditionID)
			{
				bufferData.RemoveAtSwapBack(j);
				break;
			}
		}
	}

	public static bool HasCollectedAllSouls(Entity entity, World world)
	{
		bool flag = true;
		foreach (int value in Enum.GetValues(typeof(SoulID)))
		{
			if (value != 0 && value != 7)
			{
				flag &= HasCollectedSoul((SoulID)value, entity, world);
			}
		}
		return flag;
	}

	public static bool HasCollectedSoul(SoulID soulID, Entity entity, World world)
	{
		if (HasComponentData<CollectedSoulsBuffer>(entity, world))
		{
			DynamicBuffer<CollectedSoulsBuffer> buffer = GetBuffer<CollectedSoulsBuffer>(entity, world);
			for (int i = 0; i < buffer.Length; i++)
			{
				if (buffer[i].soulId == soulID)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool HasUnlockedSouls(Entity entity, World world)
	{
		if (HasComponentData<SoulsInfoCD>(entity, world))
		{
			return GetComponentData<SoulsInfoCD>(entity, world).hasUnlockedSouls;
		}
		return false;
	}

	public static void CollectSoul(Entity entity, World world, SoulID soulID)
	{
		if (!world.EntityManager.HasComponent<SoulsConditionsBuffer>(entity) || !world.EntityManager.HasComponent<CollectedSoulsBuffer>(entity))
		{
			return;
		}
		DynamicBuffer<CollectedSoulsBuffer> buffer = world.EntityManager.GetBuffer<CollectedSoulsBuffer>(entity);
		bool flag = false;
		for (int i = 0; i < buffer.Length; i++)
		{
			if (buffer[i].soulId == soulID)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			buffer.Add(new CollectedSoulsBuffer
			{
				soulId = soulID
			});
		}
		ConditionData soulConditionData = SoulsExtensions.GetSoulConditionData(soulID);
		DynamicBuffer<SoulsConditionsBuffer> buffer2 = world.EntityManager.GetBuffer<SoulsConditionsBuffer>(entity);
		SoulsConditionsBuffer soulsConditionsBuffer = new SoulsConditionsBuffer
		{
			conditionData = soulConditionData,
			soulID = soulID
		};
		for (int j = 0; j < buffer2.Length; j++)
		{
			if (buffer2[j].conditionData.conditionID == soulConditionData.conditionID)
			{
				buffer2[j] = soulsConditionsBuffer;
				return;
			}
		}
		buffer2.Add(soulsConditionsBuffer);
	}

	public static void CompleteQuest(Entity entity, World world, QuestID questID)
	{
		Debug.Log("OK Completed should we do something?");
	}

	public static DynamicBuffer<SummarizedConditionEffectsBuffer> GetConditionEffectValues(Entity entity, World world)
	{
		if (world.EntityManager.HasComponent<SummarizedConditionEffectsBuffer>(entity))
		{
			return world.EntityManager.GetBuffer<SummarizedConditionEffectsBuffer>(entity);
		}
		return default(DynamicBuffer<SummarizedConditionEffectsBuffer>);
	}

	public static DynamicBuffer<SummarizedConditionsBuffer> GetConditionValues(Entity entity, World world)
	{
		if (world.EntityManager.HasComponent<SummarizedConditionsBuffer>(entity))
		{
			return world.EntityManager.GetBuffer<SummarizedConditionsBuffer>(entity);
		}
		return default(DynamicBuffer<SummarizedConditionsBuffer>);
	}

	public static NativeArray<SummarizedConditionsBuffer> GetConditionValuesArray(Entity entity, World world)
	{
		DynamicBuffer<SummarizedConditionsBuffer> conditionValues = GetConditionValues(entity, world);
		if (!conditionValues.IsCreated)
		{
			return default(NativeArray<SummarizedConditionsBuffer>);
		}
		return conditionValues.AsNativeArray();
	}

	public static NativeArray<SummarizedConditionsBuffer> GetConditionValuesArray(Entity entity, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup)
	{
		summarizedConditionsBufferLookup.TryGetBuffer(entity, out var bufferData);
		if (!bufferData.IsCreated)
		{
			return default(NativeArray<SummarizedConditionsBuffer>);
		}
		return bufferData.AsNativeArray();
	}

	public static NativeArray<SummarizedConditionEffectsBuffer> GetConditionEffectsValuesArray(Entity entity, World world)
	{
		DynamicBuffer<SummarizedConditionEffectsBuffer> conditionEffectValues = GetConditionEffectValues(entity, world);
		if (!conditionEffectValues.IsCreated)
		{
			return default(NativeArray<SummarizedConditionEffectsBuffer>);
		}
		return conditionEffectValues.AsNativeArray();
	}

	public static NativeArray<SummarizedConditionEffectsBuffer> GetConditionEffectsValuesArray(Entity entity, BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBufferLookup)
	{
		summarizedConditionEffectsBufferLookup.TryGetBuffer(entity, out var bufferData);
		if (!bufferData.IsCreated)
		{
			return default(NativeArray<SummarizedConditionEffectsBuffer>);
		}
		return bufferData.AsNativeArray();
	}

	public static DynamicBuffer<ConditionsBuffer> GetConditions(Entity entity, World world)
	{
		return world.EntityManager.GetBuffer<ConditionsBuffer>(entity);
	}

	public static int GetConditionEffectValue(ConditionEffect conditionEffect, Entity entity, World world)
	{
		if (HasComponentData<SummarizedConditionEffectsBuffer>(entity, world))
		{
			return GetBuffer<SummarizedConditionEffectsBuffer>(entity, world)[(int)conditionEffect].value;
		}
		return 0;
	}

	public static int GetConditionEffectValue(ConditionEffect conditionEffect, Entity entity, BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectBuffer)
	{
		if (summarizedConditionEffectBuffer.TryGetBuffer(entity, out var bufferData))
		{
			return bufferData[(int)conditionEffect].value;
		}
		return 0;
	}

	public static int GetConditionValue(ConditionID conditionID, Entity entity, World world)
	{
		if (HasComponentData<SummarizedConditionsBuffer>(entity, world))
		{
			return GetBuffer<SummarizedConditionsBuffer>(entity, world)[(int)conditionID].value;
		}
		return 0;
	}

	public static int GetConditionValue(ConditionID conditionID, Entity entity, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBuffer)
	{
		if (summarizedConditionsBuffer.TryGetBuffer(entity, out var bufferData))
		{
			return bufferData[(int)conditionID].value;
		}
		return 0;
	}

	public static float GetActiveMovementSpeed(DynamicBuffer<SummarizedConditionEffectsBuffer> conditionsBuffer, MovementSpeedCD moveSpeedCD)
	{
		return math.max(0f, moveSpeedCD.originalSpeed * GetActiveMovementSpeedMultiplier(conditionsBuffer));
	}

	public static float GetActiveMovementSpeed2(MovementSpeedCD moveSpeedCD)
	{
		return math.max(0f, moveSpeedCD.originalSpeed * 1f);
	}

	public static float GetActiveMovementSpeedMultiplier(DynamicBuffer<SummarizedConditionEffectsBuffer> conditionsBuffer)
	{
		int value = conditionsBuffer[2].value;
		return 1f + (float)value / 1000f;
	}

	public static Entity GetLevelEntity(ObjectDataCD objectData)
	{
		if (PugDatabase.HasComponent<LevelEntitiesBuffer>(objectData) && PugDatabase.HasComponent<LevelCD>(objectData))
		{
			int maxLevel = LevelScaling.GetMaxLevel();
			int index = ((objectData.variation > 0) ? math.min(maxLevel, objectData.variation) : PugDatabase.GetComponent<LevelCD>(objectData).level);
			return PugDatabase.GetBuffer<LevelEntitiesBuffer>(objectData)[index].entity;
		}
		return Entity.Null;
	}

	public static Entity GetLevelEntity(Entity prefabEntity, ObjectDataCD objectData, BufferLookup<LevelEntitiesBuffer> levelEntitiesBuffer, ComponentLookup<LevelCD> levelLookup)
	{
		if (levelEntitiesBuffer.TryGetBuffer(prefabEntity, out var bufferData) && levelLookup.TryGetComponent(prefabEntity, out var componentData))
		{
			int maxLevel = LevelScaling.GetMaxLevel();
			int index = ((objectData.variation > 0) ? math.min(maxLevel, objectData.variation) : componentData.level);
			return bufferData[index].entity;
		}
		return Entity.Null;
	}

	public static void PutLeashOnEntity(Entity ownerEntity, Entity leashedEntity, int leashIndex, ComponentLookup<LeashedCD> leashedLookup)
	{
		if (leashedLookup.HasComponent(leashedEntity))
		{
			ref LeashedCD valueRW = ref leashedLookup.GetRefRW(leashedEntity).ValueRW;
			valueRW.leashedToEntity = ownerEntity;
			valueRW.leashIndex = leashIndex;
		}
	}

	public static void ReleaseLeashOnEntity(Entity ownerEntity, Entity leashedEntity, ComponentLookup<LeashedCD> leashedLookup)
	{
		if (leashedLookup.HasComponent(leashedEntity))
		{
			ref LeashedCD valueRW = ref leashedLookup.GetRefRW(leashedEntity).ValueRW;
			if (valueRW.leashedToEntity == ownerEntity)
			{
				valueRW.leashedToEntity = Entity.Null;
			}
		}
	}

	public static void GetDamageInfo(in PlayerAttackAspect playerAttackAspect, in PlayerAttackShared playerAttackShared, in PlayerAttackLookups playerAttackLookups, Entity entity, Entity attacker, int damage, int2 position, bool isRanged, bool isMagic, bool isReverseDamage, NativeArray<SummarizedConditionsBuffer> conditionsAtHit, NativeArray<SummarizedConditionEffectsBuffer> conditionEffectsAtHit, out int damageDone, out int damageDoneBeforeReduction, out bool wasKilled, out float normHealth, NativeList<ConditionData> conditionsToApply, NativeList<ConditionData> conditionsToApplyToAttacker, NativeList<ConditionID> conditionsToRemove, NativeList<ConditionID> conditionsToRemoveFromAttacker, FactionCD attackerFaction, out bool didCrit, out bool didDodge, out int attackerHealthChange, out int ownerHealthChange, out int attackerManaChange, out bool spawnThunderBeam, out bool spawnOctopusBossProjectile, out bool spawnScarabBossProjectile, out bool knockedBack, out bool spawnMinion, bool isExplosiveDamage = false, bool isDigging = false, bool attackWoundup = false, bool bypassMaxDamagePerHit = false, bool godMode = false, int overrideHealth = 0)
	{
		if (godMode)
		{
			damageDone = int.MaxValue;
			damageDoneBeforeReduction = int.MaxValue;
			wasKilled = true;
			normHealth = 0f;
			didCrit = false;
			didDodge = false;
			attackerHealthChange = 0;
			ownerHealthChange = 0;
			attackerManaChange = 0;
			spawnThunderBeam = false;
			spawnOctopusBossProjectile = false;
			spawnScarabBossProjectile = false;
			knockedBack = false;
			spawnMinion = true;
			return;
		}
		HealthCD receiverHealth = playerAttackLookups.healthLookup[entity];
		_ = 0;
		if (!playerAttackLookups.enemyLookup.HasComponent(entity) && !playerAttackLookups.ignoreImmunityZoneLookup.HasComponent(entity) && playerAttackShared.tileAccessor.HasType(position, TileType.immune))
		{
			damageDone = 0;
			damageDoneBeforeReduction = 0;
			wasKilled = false;
			normHealth = (float)receiverHealth.health / (float)receiverHealth.maxHealth;
			didCrit = false;
			didDodge = false;
			attackerHealthChange = 0;
			ownerHealthChange = 0;
			attackerManaChange = 0;
			spawnThunderBeam = false;
			spawnOctopusBossProjectile = false;
			spawnScarabBossProjectile = false;
			knockedBack = false;
			spawnMinion = false;
			return;
		}
		playerAttackLookups.damageReductionLookup.TryGetComponent(entity, out var componentData);
		HealthCD attackerHealth = playerAttackLookups.healthLookup[attacker];
		bool flag = playerAttackLookups.destructibleObjectLookup.HasComponent(entity);
		if (!isExplosiveDamage && !isDigging && (playerAttackLookups.tileLookup.HasComponent(entity) || flag))
		{
			damage = 20;
		}
		bool recieverIsImmuneToRange = playerAttackLookups.immuneToRangeDamageLookup.HasComponent(entity);
		playerAttackLookups.manaLookup.TryGetComponent(attacker, out var componentData2);
		playerAttackLookups.magicBarrierLookup.TryGetComponent(attacker, out var componentData3);
		playerAttackLookups.phaseTransitionStateLookup.TryGetComponent(entity, out var componentData4);
		RefRW<RandomCD> refRWOptional = playerAttackLookups.randomLookup.GetRefRWOptional(playerAttackAspect.entity);
		if (!refRWOptional.IsValid)
		{
			Debug.LogError($"Missing RandomCD for entity: {entity.Index} in GetDamageInfo");
		}
		Unity.Mathematics.Random rngFromEntity = PugRandom.GetRngFromEntity(playerAttackShared.serverSeedCD.Value, playerAttackShared.currentTick, playerAttackAspect.entity);
		ref Unity.Mathematics.Random rnd = ref refRWOptional.IsValid ? ref refRWOptional.ValueRW.Value : ref rngFromEntity;
		bool receiverIsBoss = playerAttackLookups.bossLookup.HasComponent(entity);
		bool attackerIsMinion = playerAttackLookups.minionLookup.HasComponent(attacker);
		bool attackerIsPet = playerAttackLookups.petLookup.HasComponent(attacker);
		bool receiverIsPlayer = playerAttackLookups.playerGhostLookup.HasComponent(entity);
		bool recieverIsDestructible = playerAttackLookups.destructibleObjectLookup.HasComponent(entity);
		playerAttackLookups.objectTypeLookup.TryGetComponent(entity, out var componentData5);
		NativeArray<SummarizedConditionEffectsBuffer> conditionEffectsValuesArray = GetConditionEffectsValuesArray(entity, playerAttackLookups.summarizeConiditionsEffectsLookup);
		NativeArray<SummarizedConditionsBuffer> conditionValuesArray = GetConditionValuesArray(entity, playerAttackLookups.summarizeConiditionsLookup);
		PlayerStateCD componentData6;
		bool receiverIsInMinecart = playerAttackLookups.playerStateLookup.TryGetComponent(entity, out componentData6) && componentData6.HasAnyState(PlayerStateEnum.MinecartRiding);
		damage = CalculateDamage(GetOwnerInfo(playerAttackLookups.entityPartLookup, playerAttackLookups.ownerLookup, playerAttackLookups.summarizeConiditionsLookup, playerAttackLookups.playerGhostLookup, playerAttackLookups.petLookup, playerAttackLookups.minionLookup, playerAttackLookups.bossLookup, playerAttackLookups.healthLookup, playerAttackLookups.enemyLookup, attacker), conditionsAtHit, conditionEffectsAtHit, conditionValuesArray, conditionEffectsValuesArray, ref rnd, damage, isRanged, isMagic, isDigging, isReverseDamage, attackerIsBoss: false, attackerIsMinion, attackerIsPet, receiverIsBoss, receiverIsPlayer, recieverIsImmuneToRange, attackWoundup, componentData5, recieverIsDestructible, receiverIsInMinecart, isExplosiveDamage, receiverHealth, attackerHealth, componentData2, componentData3, attackerFaction, out didCrit, conditionsToApply, conditionsToApplyToAttacker, conditionsToRemove, conditionsToRemoveFromAttacker, componentData4, out didDodge, out attackerHealthChange, out ownerHealthChange, out attackerManaChange, out spawnThunderBeam, out spawnOctopusBossProjectile, out spawnScarabBossProjectile, out knockedBack, out spawnMinion, overrideHealth);
		damageDoneBeforeReduction = damage;
		damageDone = math.max(damage - componentData.reduction, 0);
		if (!bypassMaxDamagePerHit && componentData.maxDamagePerHit > 0 && !isExplosiveDamage)
		{
			damageDone = math.min(damageDone, componentData.maxDamagePerHit);
		}
		wasKilled = damageDone >= receiverHealth.health;
		normHealth = (float)(receiverHealth.health - damageDone) / (float)receiverHealth.maxHealth;
	}

	public static OwnerInfo GetOwnerInfo(ComponentLookup<EntityPartCD> entityPartLookup, ComponentLookup<OwnerReferenceCD> ownerLookup, BufferLookup<SummarizedConditionsBuffer> summarizeConiditionsLookup, ComponentLookup<PlayerGhost> playerGhostLookup, ComponentLookup<PetCD> petLookup, ComponentLookup<MinionCD> minionLookup, ComponentLookup<BossCD> bossLookup, ComponentLookup<HealthCD> healthLookup, ComponentLookup<EnemyCD> enemyLookup, Entity attacker)
	{
		Entity entity = (entityPartLookup.HasComponent(attacker) ? entityPartLookup[attacker].mainEntity : attacker);
		Entity entity2 = (ownerLookup.HasComponent(entity) ? ownerLookup[entity].owner : Entity.Null);
		Entity entity3 = entity;
		OwnerInfo result = new OwnerInfo
		{
			attacker = entity,
			immediateOwner = entity2,
			isBoss = (bossLookup.HasComponent(attacker) || bossLookup.HasComponent(entity2)),
			isMinion = (minionLookup.HasComponent(attacker) || minionLookup.HasComponent(entity2)),
			isPet = (petLookup.HasComponent(attacker) || petLookup.HasComponent(entity2))
		};
		while (entity3 != Entity.Null)
		{
			if (playerGhostLookup.HasComponent(entity3))
			{
				result.playerOwner = entity3;
			}
			if (petLookup.HasComponent(entity3))
			{
				result.petOwner = entity3;
			}
			if (minionLookup.HasComponent(entity3))
			{
				result.minionOwner = entity3;
			}
			if (healthLookup.HasComponent(entity3) && (enemyLookup.HasComponent(entity3) || playerGhostLookup.HasComponent(entity3) || minionLookup.HasComponent(entity3)))
			{
				result.targetableOwner = entity3;
			}
			if (summarizeConiditionsLookup.HasBuffer(entity3))
			{
				result.entityToBeAffectedByConditionChanges = entity3;
			}
			entity3 = (ownerLookup.HasComponent(entity3) ? ownerLookup[entity3].owner : Entity.Null);
		}
		return result;
	}

	public static int CalculateDamage(OwnerInfo ownerInfo, NativeArray<SummarizedConditionsBuffer> attackerConditions, NativeArray<SummarizedConditionEffectsBuffer> attackerConditionEffects, NativeArray<SummarizedConditionsBuffer> receiverConditions, NativeArray<SummarizedConditionEffectsBuffer> receiverConditionsEffects, ref Unity.Mathematics.Random rnd, int baseDamage, bool isRanged, bool isMagic, bool isDigging, bool isReverseDamage, bool attackerIsBoss, bool attackerIsMinion, bool attackerIsPet, bool receiverIsBoss, bool receiverIsPlayer, bool recieverIsImmuneToRange, bool attackWoundup, ObjectTypeCD objectType, bool recieverIsDestructible, bool receiverIsInMinecart, bool isExplosive, HealthCD receiverHealth, HealthCD attackerHealth, ManaCD attackerMana, MagicBarrierCD attackerBarrier, FactionCD attackerFaction, out bool didCrit, NativeList<ConditionData> appliedConditions, NativeList<ConditionData> appliedConditionsOnAttacker, NativeList<ConditionID> removedConditions, NativeList<ConditionID> removedConditionsFromAttacker, PhaseTransitionStateCD receiverPhaseTransitionState, out bool didDodge, out int attackerHealthChange, out int ownerHealthChange, out int attackerManaChange, out bool spawnThunderBeam, out bool spawnOctopusBossProjectile, out bool spawnScarabBossProjectile, out bool knockedBack, out bool spawnMinion, int overrideHealth = 0, bool godMode = false)
	{
		int num = ((overrideHealth > 0) ? overrideHealth : receiverHealth.health);
		bool isCreated = attackerConditionEffects.IsCreated;
		bool isCreated2 = receiverConditionsEffects.IsCreated;
		int damageIncrease = 0;
		int num2 = 0;
		int damageIncreasePercentage = 0;
		float num3 = 1f;
		int num4 = 0;
		int num5 = 0;
		bool flag = false;
		bool flag2 = objectType.Value == ObjectType.PlaceablePrefab || recieverIsDestructible;
		didCrit = false;
		didDodge = false;
		spawnThunderBeam = false;
		spawnOctopusBossProjectile = false;
		spawnScarabBossProjectile = false;
		knockedBack = false;
		spawnMinion = false;
		attackerHealthChange = 0;
		ownerHealthChange = 0;
		attackerManaChange = 0;
		int y = 0;
		int num6 = 0;
		if (godMode)
		{
			return int.MaxValue;
		}
		if (isRanged && recieverIsImmuneToRange)
		{
			return 0;
		}
		if (isCreated2 && !flag2)
		{
			y = receiverConditionsEffects[9].value;
			int value = receiverConditionsEffects[52].value;
			if (value > 0)
			{
				y += (int)math.round((float)y * ((float)value / 1000f * math.max(0f, (float)receiverConditionsEffects[2].value / 1000f)));
			}
			y = (int)math.round((float)y * (1f + (float)receiverConditionsEffects[37].value / 1000f));
			num6 = receiverConditionsEffects[13].value;
		}
		if (isReverseDamage)
		{
			int num7 = math.min(baseDamage, y);
			int num8 = (baseDamage - num7) / baseDamage;
			return (int)((float)baseDamage - (float)num7 * math.lerp(0.75f, 1f, num8));
		}
		didDodge = rnd.NextInt(100) < num6;
		if (didDodge)
		{
			return 0;
		}
		if (isCreated)
		{
			if (!isCreated2 || flag2)
			{
				if (isDigging)
				{
					return attackerConditionEffects[66].value;
				}
				damageIncrease = attackerConditionEffects[7].value;
				num2 = attackerConditionEffects[38].value;
				return (int)math.round((float)(baseDamage + damageIncrease) * math.max(1f + (float)num2 / 100f, 0f));
			}
			GetAttackerDamageIncrease(isRanged, isMagic, attackerConditionEffects, out damageIncrease, out damageIncreasePercentage);
			if (receiverIsBoss)
			{
				num2 += attackerConditionEffects[55].value;
			}
			if (attackerConditionEffects[87].value != 0)
			{
				float num9 = (float)num / (float)receiverHealth.maxHealth;
				num2 += (int)math.round((float)attackerConditionEffects[87].value * num9);
			}
			if (isMagic && attackerConditionEffects[110].value != 0)
			{
				float num10 = (float)attackerMana.mana / (float)attackerMana.maxMana;
				num2 += (int)math.round((float)attackerConditionEffects[110].value * num10);
			}
			if (isMagic && attackerConditionEffects[109].value != 0)
			{
				int num11 = (int)math.round((float)attackerConditionEffects[109].value / 100f * (float)attackerBarrier.barrierHealth);
				damageIncrease += num11;
			}
			if (receiverConditionsEffects[12].value > 0)
			{
				num2 += attackerConditionEffects[61].value;
			}
			if (receiverConditionsEffects[58].value > 0)
			{
				num2 += attackerConditionEffects[85].value;
			}
			if (receiverConditionsEffects[16].value > 0)
			{
				num2 += attackerConditionEffects[72].value;
				num5 += attackerConditionEffects[73].value;
				if (rnd.NextFloat() < (float)attackerConditionEffects[88].value / 100f)
				{
					int num12 = receiverConditionsEffects[16].value * 4;
					removedConditions.Add(ConditionID.Burning);
					damageIncrease += num12;
				}
			}
			if (rnd.NextFloat() < (float)attackerConditionEffects[86].value / 100f)
			{
				num3 *= 3f;
			}
			if (receiverConditionsEffects[99].value > 0)
			{
				num3 *= 2f;
			}
			num4 = attackerConditionEffects[10].value;
			float num13 = (float)attackerConditionEffects[11].value / 100f;
			bool flag3 = receiverConditionsEffects[30].value > 0;
			if (rnd.NextFloat() < num13 && !flag3)
			{
				ConditionData value2 = new ConditionData
				{
					conditionID = ConditionID.Poisoned,
					value = 1,
					duration = 15f
				};
				appliedConditions.Add(in value2);
				int value3 = attackerConditions[157].value;
				if (value3 > 0)
				{
					value2 = new ConditionData
					{
						conditionID = ConditionID.CritChanceIncreaseFromPoisonApply,
						value = value3,
						duration = 5f
					};
					appliedConditionsOnAttacker.Add(in value2);
				}
			}
			float num14 = (float)attackerConditionEffects[122].value / 100f;
			bool num15 = rnd.NextFloat() < num14;
			bool flag4 = receiverConditionsEffects[79].value > 0;
			if (num15 && !flag4 && !receiverIsBoss && !receiverIsPlayer)
			{
				float num16 = 1f + (float)attackerConditionEffects[82].value / 100f;
				ConditionData value2 = new ConditionData
				{
					conditionID = ConditionID.Charmed,
					value = attackerFaction.ToCharmedConditionValue(),
					duration = 20f * num16
				};
				appliedConditions.Add(in value2);
			}
			bool flag5 = receiverConditionsEffects[63].value > 0;
			if (!flag5)
			{
				int value4 = attackerConditionEffects[17].value;
				int num17 = (int)math.round((float)(value4 * attackerConditions[314].value) / 100f);
				value4 += num17;
				if (value4 > 0)
				{
					ConditionData value2 = new ConditionData
					{
						conditionID = ConditionID.Burning,
						value = value4,
						duration = 8.4f
					};
					appliedConditions.Add(in value2);
				}
			}
			if (receiverConditionsEffects[20].value <= 0)
			{
				int value5 = attackerConditionEffects[18].value;
				if (value5 < 0)
				{
					float num18 = 1f - (float)receiverConditionsEffects[89].value / 100f;
					ConditionData value2 = new ConditionData
					{
						conditionID = ConditionID.SlowedBySlime,
						value = (int)math.round((float)value5 * num18),
						duration = 4f
					};
					appliedConditions.Add(in value2);
				}
			}
			int num19 = (isRanged ? attackerConditionEffects[56].value : 0);
			if (num19 < 0 && rnd.NextFloat() < 0.2f)
			{
				if (receiverIsBoss)
				{
					num19 = (int)math.round((float)num19 * 0.5f);
				}
				appliedConditions.Add(new ConditionData
				{
					conditionID = ConditionID.MovementSpeedDecrease,
					value = num19,
					duration = 4f
				});
			}
			int num20 = attackerConditionEffects[64].value;
			if (num20 < 0)
			{
				if (receiverIsBoss)
				{
					num20 = (int)math.round((float)num20 * 0.5f);
				}
				appliedConditions.Add(new ConditionData
				{
					conditionID = ConditionID.MovementSpeedDecrease,
					value = num20,
					duration = 4f
				});
			}
			float num21 = (float)attackerConditionEffects[50].value / 100f;
			bool flag6 = receiverConditionsEffects[49].value > 0;
			if (num21 > 0f && rnd.NextFloat() < num21 && !flag6)
			{
				ConditionData value2 = new ConditionData
				{
					conditionID = ConditionID.SlipperyMovement,
					value = 1,
					duration = 6f
				};
				appliedConditions.Add(in value2);
			}
			if (attackerConditionEffects[25].value > 0 && receiverConditionsEffects[26].value == 0 && !receiverIsInMinecart)
			{
				float num22 = 1f - (float)receiverConditionsEffects[53].value / 100f;
				if (num22 <= 0f)
				{
					num22 = 0.1f;
				}
				appliedConditions.Add(new ConditionData
				{
					conditionID = ConditionID.Snared,
					value = 1,
					duration = 4f * num22
				});
			}
			float num23 = (float)attackerConditionEffects[59].value / 100f;
			float num24 = (float)attackerConditionEffects[83].value / 100f;
			float num25 = (float)attackerConditionEffects[124].value / 100f;
			if (((isRanged && num23 > 0f && rnd.NextFloat() <= num23) || (!isRanged && num24 > 0f && rnd.NextFloat() <= num24) || (num25 > 0f && rnd.NextFloat() <= num25)) && receiverConditionsEffects[58].value == 0 && receiverConditionsEffects[60].value == 0)
			{
				float num26 = 1f - (float)receiverConditionsEffects[53].value / 100f + (float)attackerConditionEffects[84].value / 100f;
				if (num26 <= 0f)
				{
					num26 = 0.1f;
				}
				appliedConditions.Add(new ConditionData
				{
					conditionID = ConditionID.Stunned,
					value = 1,
					duration = 2f * num26
				});
			}
			if (!isRanged && receiverConditionsEffects[69].value > 0 && attackerConditionEffects[49].value == 0)
			{
				ConditionData value2 = new ConditionData
				{
					conditionID = ConditionID.SlipperyMovement,
					value = 1,
					duration = 6f
				};
				appliedConditionsOnAttacker.Add(in value2);
			}
			if (attackerConditions[338].value > 0 && receiverConditions[337].value == 0)
			{
				ConditionData value2 = new ConditionData
				{
					conditionID = ConditionID.DrenchedInOil,
					value = 100,
					duration = 10f
				};
				appliedConditions.Add(in value2);
			}
			int value6 = receiverConditionsEffects[21].value;
			if (value6 > 0 && !isRanged)
			{
				attackerHealthChange -= value6;
			}
			if (attackerConditionEffects[74].value > 0)
			{
				damageIncrease += attackerConditionEffects[21].value;
			}
			int num27 = attackerConditions[299].value;
			if (num27 > 0)
			{
				switch (rnd.NextInt(8))
				{
				case 0:
					if (!flag5)
					{
						ConditionData value2 = new ConditionData
						{
							conditionID = ConditionID.Burning,
							value = num27,
							duration = 8.4f
						};
						appliedConditions.Add(in value2);
					}
					break;
				case 1:
					if (!flag3)
					{
						ConditionData value2 = new ConditionData
						{
							conditionID = ConditionID.Poisoned,
							value = 1,
							duration = 15f
						};
						appliedConditions.Add(in value2);
					}
					break;
				case 2:
					if (receiverConditionsEffects[58].value == 0 && receiverConditionsEffects[60].value == 0)
					{
						ConditionData value2 = new ConditionData
						{
							conditionID = ConditionID.Stunned,
							value = 1,
							duration = 2f
						};
						appliedConditions.Add(in value2);
					}
					break;
				case 3:
					if (receiverIsBoss)
					{
						num27 = (int)math.round((float)num27 * 0.5f);
					}
					appliedConditions.Add(new ConditionData
					{
						conditionID = ConditionID.MovementSpeedDecrease,
						value = num27,
						duration = 4f
					});
					break;
				}
			}
			if (!isRanged)
			{
				int value7 = attackerConditionEffects[24].value;
				if (value7 > 0 && (float)value7 / 100f > rnd.NextFloat())
				{
					knockedBack = true;
				}
			}
			int value8 = attackerConditionEffects[62].value;
			if (value8 > 0 && num < attackerHealth.health && (float)value8 / 100f > rnd.NextFloat())
			{
				flag = true;
			}
			int value9 = attackerConditionEffects[104].value;
			float num28 = rnd.NextFloat();
			if (value9 > 0 && (float)value9 / 100f > num28)
			{
				spawnMinion = true;
			}
		}
		didCrit = rnd.NextInt(100) < num4;
		float num29 = ((didCrit && isCreated) ? (1.5f + (float)(attackerConditionEffects[57].value + num5) / 100f) : 1f);
		if (didCrit && !isRanged && isCreated)
		{
			int value10 = attackerConditionEffects[28].value;
			if (value10 > 0)
			{
				value10 += attackerConditionEffects[75].value;
				spawnThunderBeam = rnd.NextFloat() <= (float)value10 / 100f;
			}
		}
		if (didCrit && isCreated)
		{
			int value11 = attackerConditionEffects[106].value;
			if (value11 > 0)
			{
				attackerManaChange += value11;
			}
			int value12 = attackerConditions[268].value;
			if (value12 > 0)
			{
				ConditionData value2 = new ConditionData
				{
					conditionID = ConditionID.MagicDamagePercentageBoostAfterCrit,
					value = value12 * 10,
					duration = 6f
				};
				appliedConditionsOnAttacker.Add(in value2);
			}
		}
		if (isRanged && isCreated)
		{
			int value13 = attackerConditionEffects[67].value;
			if (value13 > 0)
			{
				value13 += attackerConditionEffects[77].value;
				spawnOctopusBossProjectile = rnd.NextFloat() <= (float)value13 / 100f;
			}
			if (attackerConditions[84].value > 0)
			{
				ConditionData value2 = new ConditionData
				{
					conditionID = ConditionID.RangeDamageIncreaseFromShooting,
					value = 20,
					duration = 8f
				};
				appliedConditionsOnAttacker.Add(in value2);
			}
			float num30 = (float)attackerConditions[88].value / 100f;
			if (rnd.NextFloat() < num30)
			{
				ConditionData value2 = new ConditionData
				{
					conditionID = ConditionID.CriticalHitChanceFromShot,
					value = 100,
					duration = 3f
				};
				appliedConditionsOnAttacker.Add(in value2);
			}
			float num31 = (float)attackerConditions[92].value / 100f;
			if (rnd.NextFloat() < num31)
			{
				ConditionData value2 = new ConditionData
				{
					conditionID = ConditionID.IncreasedMeleeDamageFromShot,
					value = 300,
					duration = 10f
				};
				appliedConditionsOnAttacker.Add(in value2);
			}
		}
		if (isCreated)
		{
			int value14 = attackerConditionEffects[70].value;
			if (value14 > 0)
			{
				value14 += attackerConditionEffects[76].value;
				spawnScarabBossProjectile = rnd.NextFloat() <= (float)value14 / 100f;
			}
		}
		if (isCreated && isExplosive && attackerConditions[340].value > 0)
		{
			ConditionData value2 = new ConditionData
			{
				conditionID = ConditionID.SequenceExplosionTotalMaxExplosions,
				value = 1,
				duration = 5f
			};
			appliedConditionsOnAttacker.Add(in value2);
		}
		int num32 = (isCreated2 ? receiverConditionsEffects[98].value : 0);
		int num33 = (flag ? (num + num32) : ((int)math.round((float)(baseDamage + damageIncrease) * num29 * math.max(1f + (float)damageIncreasePercentage / 1000f, 0f) * math.max(1f + (float)num2 / 100f, 0f) * num3)));
		if (num33 > 0 && !flag)
		{
			int num34 = math.min(num33, y);
			int num35 = (num33 - num34) / num33;
			num33 = (int)((float)num33 - (float)num34 * math.lerp(0.75f, 1f, num35));
			if (isCreated2)
			{
				int value15 = receiverConditionsEffects[97].value;
				if (value15 != 0)
				{
					num33 = (int)math.round((float)num33 * ((1000f + (float)value15) / 1000f));
				}
			}
			if (isCreated2 && attackerIsBoss)
			{
				int value16 = receiverConditionsEffects[29].value;
				if (value16 > 0)
				{
					num33 = (int)math.max(1f, math.round((float)num33 * ((100f - (float)value16) / 100f)));
				}
			}
			if (isCreated2 && !flag2)
			{
				int num36 = (int)(0.1f * (float)math.abs(num33));
				num33 += rnd.NextInt(-num36, num36 + 1);
			}
			if (num33 > 0 && receiverPhaseTransitionState.phase1HealthThreshold > 0f)
			{
				float num37 = (float)math.clamp(receiverHealth.health - num33, 0, receiverHealth.maxHealth) / (float)receiverHealth.maxHealth;
				if (receiverHealth.Normalized > receiverPhaseTransitionState.phase1HealthThreshold && num37 < receiverPhaseTransitionState.phase1HealthThreshold)
				{
					num33 = receiverHealth.health - (int)math.floor((float)receiverHealth.maxHealth * receiverPhaseTransitionState.phase1HealthThreshold) + 1;
				}
			}
		}
		if (!isCreated2 || flag2)
		{
			return num33;
		}
		int value17 = receiverConditionsEffects[137].value;
		int value18 = receiverConditionsEffects[125].value;
		int num38 = 3;
		int num39 = value17 - value18;
		if (num33 > 0 && value17 > 0 && num39 > 0)
		{
			int value19 = math.min(num38 * num33, num39);
			ConditionData value2 = new ConditionData
			{
				conditionID = ConditionID.AmassThenReciprocateDamage,
				value = value19,
				duration = 2f
			};
			appliedConditions.Add(in value2);
		}
		if (attackerIsMinion)
		{
			int value20 = attackerConditionEffects[126].value;
			if (value20 > 0)
			{
				ownerHealthChange += value20;
			}
		}
		else if (attackerIsPet)
		{
			int value21 = attackerConditionEffects[127].value;
			if (value21 > 0)
			{
				ownerHealthChange += value21;
			}
		}
		else if (isCreated && !isRanged)
		{
			int value22 = attackerConditionEffects[19].value;
			if (value22 > 0)
			{
				if (ownerInfo.playerOwner != Entity.Null && ownerInfo.attacker != ownerInfo.playerOwner)
				{
					ownerHealthChange += value22;
				}
				else
				{
					attackerHealthChange += value22;
				}
			}
			int value23 = attackerConditionEffects[141].value;
			if (value23 > 0)
			{
				attackerManaChange += value23;
			}
		}
		return num33;
	}

	public static bool EvaluateCanOnlyHitCertainObjects(Entity hitEntity, bool damagedByMiningTool, ComponentLookup<TileCD> tileLookup, ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup, ComponentLookup<RootCD> rootLookup, ComponentLookup<DestructibleObjectCD> destructibleObjectLookup, ComponentLookup<MineableCD> mineableLookup, ComponentLookup<PlayerGraveCD> playerGraveLookup, ComponentLookup<AttackableWithMeleeCD> attackableWithMeleeLookup)
	{
		TileCD componentData;
		bool num = tileLookup.TryGetComponent(hitEntity, out componentData);
		bool flag = num && componentData.tileType == TileType.bigRoot;
		ObjectCategoryTagsCD componentData2;
		bool flag2 = objectCategoryTagsLookup.TryGetComponent(hitEntity, out componentData2) && ObjectCategoryTagsCD.HasTag(componentData2.tagsBitMask, ObjectCategoryTag.Greenery);
		bool flag3 = num && componentData.tileType.IsWallTile() && damagedByMiningTool;
		bool num2 = rootLookup.HasComponent(hitEntity);
		bool flag4 = destructibleObjectLookup.HasComponent(hitEntity);
		bool flag5 = mineableLookup.HasComponent(hitEntity) && playerGraveLookup.HasComponent(hitEntity);
		bool flag6 = mineableLookup.HasComponent(hitEntity) && attackableWithMeleeLookup.HasComponent(hitEntity);
		return num2 || flag || flag4 || flag5 || flag3 || flag6 || flag2;
	}

	public static bool EntityIsValidEnemyToDamage(Entity entityToCheck, ComponentLookup<EnemyCD> enemyLookup, ComponentLookup<MerchantCD> merchantLookup, ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ComponentLookup<HealthCD> healthLookup, ComponentLookup<PlayerGhost> playerGhostLookup)
	{
		if ((!enemyLookup.HasComponent(entityToCheck) && !merchantLookup.HasComponent(entityToCheck) && (!objectPropertiesLookup.TryGetComponent(entityToCheck, out var componentData) || !componentData.Has(-1005412627))) || entityDestroyedLookup.HasAndIsComponentEnabled(entityToCheck) || healthLookup[entityToCheck].health <= 0)
		{
			return playerGhostLookup.HasComponent(entityToCheck);
		}
		return true;
	}

	public static void GetAttackerDamageIncrease(bool isRanged, bool isMagic, NativeArray<SummarizedConditionEffectsBuffer> attackerConditions, out int damageIncrease, out int damageIncreasePercentage)
	{
		damageIncreasePercentage = attackerConditions[33].value;
		damageIncrease = 0;
		if (isMagic)
		{
			damageIncreasePercentage += (int)math.round(attackerConditions[102].value);
		}
		else if (isRanged)
		{
			damageIncreasePercentage += attackerConditions[22].value;
		}
		else
		{
			damageIncreasePercentage += attackerConditions[8].value;
		}
		if (isRanged)
		{
			damageIncreasePercentage += attackerConditions[117].value;
			damageIncrease += (int)math.round((float)attackerConditions[44].value / 100f * (float)attackerConditions[36].value);
			return;
		}
		damageIncreasePercentage += attackerConditions[116].value;
		int value = attackerConditions[43].value;
		if (value != 0)
		{
			float num = 1f + (float)attackerConditions[38].value / 100f;
			float num2 = (float)(attackerConditions[7].value + 20) * num;
			damageIncrease += (int)math.round((float)value / 100f * num2);
		}
	}

	public static void PlayEffectEventClient(EffectEventCD effect)
	{
		if (Manager.ecs.ClientWorld.IsCreated)
		{
			EffectEventExtensions.PlayEffect(effect, (Manager.main.player != null) ? Manager.main.player.entity : default(Entity), Manager.ecs.ClientWorld);
			float3 float5 = Manager.camera.RenderOrigo.ToFloat3();
			effect.position1 += float5;
			Entity entity = Manager.ecs.ClientWorld.EntityManager.CreateEntity(typeof(EffectEventRpc), typeof(SendRpcCommandRequest));
			if (entity != Entity.Null)
			{
				Manager.ecs.ClientWorld.EntityManager.SetComponentData(entity, new EffectEventRpc
				{
					Value = effect
				});
			}
		}
	}

	public static void PlayEffectEventServer(EntityCommandBuffer ecb, Entity effectEventBufferSingleton, EffectEventCD effect)
	{
		ecb.AppendToBuffer(effectEventBufferSingleton, new EffectEventBuffer
		{
			Value = effect
		});
	}

	public static void PlayEffectEventServer(EntityCommandBuffer.ParallelWriter ecb, int sortKey, Entity effectEventBufferSingleton, EffectEventCD effect)
	{
		ecb.AppendToBuffer(sortKey, effectEventBufferSingleton, new EffectEventBuffer
		{
			Value = effect
		});
	}

	public static void SpawnProjectile(EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> database, ObjectID projectileID, int damage, float sameFactionHealingPercentage, float3 direction, float speedCurveBlendValue, Entity owner, BehaviourTagsCD ownerBehaviourTags, BufferLookup<SummarizedConditionsBuffer> conditionsBufferLookup, FactionCD faction, ConditionsTableCD conditionsTable, RefRW<RandomCD> random, ComponentLookup<PiercingProjectileCD> piercingProjectileLookup, int variation = 0, float speedMultiplier = 1f, Entity entityToFollow = default(Entity))
	{
		Entity prefabEntity;
		Entity entity = CreateEntity(ecb, position, projectileID, 1, database, out prefabEntity, variation);
		if (!(entity == Entity.Null))
		{
			ecb.SetComponent(entity, new ProjectileSetupCD
			{
				damage = damage,
				directionRadians = math.atan2(direction.z, direction.x)
			});
			ecb.SetComponent(entity, new MovementSpeedModifierCD
			{
				Value = speedMultiplier
			});
			ecb.SetComponent(entity, new ProjectileSpeedCurveBlendValueCD
			{
				speedCurveBlendValue = speedCurveBlendValue
			});
			ecb.SetComponent(entity, new OwnerReferenceCD
			{
				owner = owner
			});
			InheritAttackData(ecb, owner, entity, ownerBehaviourTags, conditionsBufferLookup, faction, conditionsTable);
			if (sameFactionHealingPercentage > 0f)
			{
				ecb.AddComponent(entity, new HealingProjectileCD
				{
					sameFactionHealingPercentage = sameFactionHealingPercentage
				});
			}
			if (entityToFollow != Entity.Null)
			{
				ecb.AddComponent(entity, new HomingProjectileCD
				{
					followingEntity = entityToFollow
				});
			}
			if (piercingProjectileLookup.TryGetComponent(prefabEntity, out var componentData) && componentData.piercesEnemiesAmount != int.MaxValue)
			{
				componentData.piercesEnemiesAmount += GetConditionValue(ConditionID.PiercingProjectiles, owner, conditionsBufferLookup);
				ecb.SetComponent(entity, componentData);
			}
			if (!random.IsValid)
			{
				Debug.LogError("Missing RandomCD");
				return;
			}
			ecb.SetComponent(entity, new RandomCD
			{
				Value = PugRandom.InheritRngFromEntity(ref random.ValueRW.Value)
			});
		}
	}

	public static void SpawnProjectile(ComponentLookup<GhostOwner> ghostOwnerLookup, ComponentLookup<BehaviourTagsCD> behaviourTagsLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionBufferLookup, ComponentLookup<FactionCD> factionLookup, EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> database, ObjectID projectileID, int damage, float sameFactionHealingPercentage, float3 direction, Entity owner, ConditionsTableCD conditionsTable, bool shotFromReinforcedWeapon, int level, ref Unity.Mathematics.Random random, ComponentLookup<PiercingProjectileCD> piercingProjectileLookup, bool setGhostOwner = true, Entity entityToFollow = default(Entity))
	{
		Entity prefabEntity;
		Entity entity = CreateEntity(ecb, position, projectileID, 1, database, out prefabEntity);
		if (!(entity == Entity.Null))
		{
			ecb.SetComponent(entity, new ProjectileSetupCD
			{
				damage = damage,
				directionRadians = math.atan2(direction.z, direction.x)
			});
			ecb.SetComponent(entity, new ProjectileSourceCD
			{
				shotFromReinforcedWeapon = shotFromReinforcedWeapon,
				weaponLevel = level
			});
			if (sameFactionHealingPercentage > 0f)
			{
				ecb.AddComponent(entity, new HealingProjectileCD
				{
					sameFactionHealingPercentage = sameFactionHealingPercentage
				});
			}
			if (entityToFollow != Entity.Null)
			{
				ecb.AddComponent(entity, new HomingProjectileCD
				{
					followingEntity = entityToFollow
				});
			}
			if (piercingProjectileLookup.TryGetComponent(prefabEntity, out var componentData) && componentData.piercesEnemiesAmount != int.MaxValue)
			{
				componentData.piercesEnemiesAmount += GetConditionValue(ConditionID.PiercingProjectiles, owner, summarizedConditionBufferLookup);
				ecb.SetComponent(entity, componentData);
			}
			ecb.SetComponent(entity, new OwnerReferenceCD
			{
				owner = owner
			});
			if (setGhostOwner)
			{
				ecb.SetComponent(entity, ghostOwnerLookup[owner]);
			}
			InheritAttackData(ecb, owner, entity, conditionsTable, behaviourTagsLookup, summarizedConditionBufferLookup);
			if (factionLookup.HasComponent(prefabEntity))
			{
				InheritFaction(ecb, owner, entity, factionLookup);
			}
			ecb.SetComponent(entity, new RandomCD
			{
				Value = PugRandom.InheritRngFromEntity(ref random)
			});
		}
	}

	public static void SpawnMortarProjectile(EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> database, ObjectID projectileID, int damage, float3 targetPosition, Entity owner, float goUpTime, float airTime, float goDownTime, float explodeTime, int level, ConditionsTableCD conditionsTable, ref Unity.Mathematics.Random random, ComponentLookup<FactionCD> factionLookup, ComponentLookup<BehaviourTagsCD> behaviourTagsLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBuffer, ComponentLookup<MortarProjectileCD> mortarProjectileLookup, ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup, int variation = 0)
	{
		float3 position2 = ((goUpTime == 0f) ? targetPosition : position);
		Entity prefabEntity;
		Entity entity = CreateEntity(ecb, position2, projectileID, 1, database, out prefabEntity, variation);
		if (!(entity == Entity.Null))
		{
			if (mortarProjectileLookup.TryGetComponent(prefabEntity, out var componentData))
			{
				componentData.goUpTime = goUpTime;
				componentData.targetPosition = targetPosition;
				componentData.airTime = airTime;
				componentData.goDownTime = goDownTime;
				componentData.explodeTime = explodeTime;
				componentData.totalAirTime = goUpTime + airTime + goDownTime;
				ecb.SetComponent(entity, new OwnerReferenceCD
				{
					owner = owner
				});
				ecb.SetComponent(entity, componentData);
				ecb.SetComponent(entity, new ProjectileSourceCD
				{
					weaponLevel = level
				});
			}
			if (mortarProjectileDamageEffectLookup.TryGetComponent(prefabEntity, out var componentData2))
			{
				componentData2.damage = damage;
				ecb.SetComponent(entity, componentData2);
			}
			InheritAttackData(ecb, owner, entity, conditionsTable, behaviourTagsLookup, summarizedConditionsBuffer);
			if (factionLookup.HasComponent(prefabEntity))
			{
				InheritFaction(ecb, owner, entity, factionLookup);
			}
			ecb.SetComponent(entity, new RandomCD
			{
				Value = PugRandom.InheritRngFromEntity(ref random)
			});
		}
	}

	public static Entity SpawnMortarProjectile(EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> database, ObjectID projectileID, int damage, bool hitTiles, int tileDamage, float3 targetPosition, Entity owner, MortarProjectileCD projectile, float goUpTime, float airTime, float goDownTime, float explodeTime, int level, bool canShootOnWaterAndPits, BehaviourTagsCD ownerBehaviourTags, BufferLookup<SummarizedConditionsBuffer> conditionsBufferLookup, FactionCD faction, ConditionsTableCD conditionsTable, ref RandomCD random, ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup)
	{
		float3 position2 = ((goUpTime == 0f) ? targetPosition : position);
		Entity prefabEntity;
		Entity entity = CreateEntity(ecb, position2, projectileID, 1, database, out prefabEntity);
		if (entity == Entity.Null)
		{
			return entity;
		}
		projectile.goUpTime = goUpTime;
		projectile.targetPosition = targetPosition;
		projectile.airTime = airTime;
		projectile.goDownTime = goDownTime;
		projectile.explodeTime = explodeTime;
		projectile.totalAirTime = goUpTime + airTime + goDownTime;
		projectile.canSpawnTilesOnWaterOrPits = canShootOnWaterAndPits;
		if (mortarProjectileDamageEffectLookup.TryGetComponent(prefabEntity, out var componentData))
		{
			componentData.damage = damage;
			componentData.hitTiles = hitTiles;
			componentData.tileDamage = tileDamage;
			ecb.SetComponent(entity, componentData);
		}
		ecb.SetComponent(entity, new OwnerReferenceCD
		{
			owner = owner
		});
		ecb.SetComponent(entity, projectile);
		ecb.SetComponent(entity, new ProjectileSourceCD
		{
			weaponLevel = level
		});
		InheritAttackData(ecb, owner, entity, ownerBehaviourTags, conditionsBufferLookup, faction, conditionsTable);
		ecb.SetComponent(entity, new RandomCD
		{
			Value = PugRandom.InheritRngFromEntity(ref random.Value)
		});
		return entity;
	}

	public static void SpawnThunderBeam(ComponentLookup<BirdBossBeamCD> birdBossBeamLookup, ComponentLookup<AttackContinuouslyCD> attackContinuouslyLookup, ComponentLookup<FactionCD> factionLookup, EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> database, float3 direction, Entity owner, int damage, RefRW<RandomCD> random)
	{
		Entity prefabEntity;
		Entity entity = CreateEntity(ecb, position, ObjectID.BirdBossBeam, 1, database, out prefabEntity);
		if (!(entity == Entity.Null))
		{
			BirdBossBeamCD component = birdBossBeamLookup[prefabEntity];
			AttackContinuouslyCD component2 = attackContinuouslyLookup[prefabEntity];
			component.moveDirection = direction;
			component2.damage = damage;
			ecb.SetComponent(entity, new OwnerReferenceCD
			{
				owner = owner
			});
			ecb.SetComponent(entity, component);
			ecb.SetComponent(entity, component2);
			if (factionLookup.HasComponent(prefabEntity))
			{
				InheritFaction(ecb, owner, entity, factionLookup);
			}
			if (!random.IsValid)
			{
				Debug.LogError("Missing RandomCD");
				return;
			}
			ecb.SetComponent(entity, new RandomCD
			{
				Value = PugRandom.InheritRngFromEntity(ref random.ValueRW.Value)
			});
		}
	}

	public static void SpawnTrail(ComponentLookup<GhostOwner> ghostOwnerLookup, ComponentLookup<AttackContinuouslyCD> attackContinuouslyLookup, ComponentLookup<FactionCD> factionLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionBufferLookup, ComponentLookup<BehaviourTagsCD> behaviorlookup, ConditionsTableCD conditionsTable, EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> database, Entity owner, int damage, ObjectID objectID)
	{
		Entity prefabEntity;
		Entity entity = CreateEntity(ecb, position, objectID, 1, database, out prefabEntity);
		if (!(entity == Entity.Null))
		{
			AttackContinuouslyCD component = attackContinuouslyLookup[prefabEntity];
			component.damage = damage;
			ecb.SetComponent(entity, new OwnerReferenceCD
			{
				owner = owner
			});
			ecb.SetComponent(entity, component);
			if (factionLookup.HasComponent(prefabEntity))
			{
				InheritFaction(ecb, owner, entity, factionLookup);
			}
			InheritAttackData(ecb, owner, entity, conditionsTable, behaviorlookup, summarizedConditionBufferLookup);
			if (ghostOwnerLookup.HasComponent(prefabEntity))
			{
				ecb.SetComponent(entity, ghostOwnerLookup[owner]);
			}
		}
	}

	public static Entity SpawnExplosion(EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> database, ObjectID projectileID, int damage, int tileDamage, Entity owner, float radius, ConditionsTableCD conditionsTable, ref Unity.Mathematics.Random random, ComponentLookup<FactionCD> factionLookup, ComponentLookup<BehaviourTagsCD> behaviourTagsLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBuffer, BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer, ObjectID spawnNapalmObjectID = ObjectID.None, int spawnNapalmVariation = 0, ExplosionPushbackLevel explosionPushback = ExplosionPushbackLevel.Normal, bool cameFromExplosive = false)
	{
		Entity prefabEntity;
		return SpawnExplosion(ecb, position, database, projectileID, damage, tileDamage, owner, radius, conditionsTable, ref random, factionLookup, behaviourTagsLookup, summarizedConditionsBuffer, summarizedConditionEffectsBuffer, out prefabEntity, spawnNapalmObjectID, spawnNapalmVariation, explosionPushback, cameFromExplosive);
	}

	public static Entity SpawnExplosion(EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> database, ObjectID projectileID, int damage, int tileDamage, Entity owner, float radius, ConditionsTableCD conditionsTable, ref Unity.Mathematics.Random random, ComponentLookup<FactionCD> factionLookup, ComponentLookup<BehaviourTagsCD> behaviourTagsLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBuffer, BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer, out Entity prefabEntity, ObjectID spawnNapalmObjectID = ObjectID.None, int spawnNapalmVariation = 0, ExplosionPushbackLevel explosionPushback = ExplosionPushbackLevel.Normal, bool cameFromExplosive = false)
	{
		Entity entity = CreateEntity(ecb, position, projectileID, 1, database, out prefabEntity);
		if (entity == Entity.Null)
		{
			return entity;
		}
		DynamicBuffer<SummarizedConditionEffectsBuffer> bufferData;
		int num = (summarizedConditionEffectsBuffer.TryGetBuffer(owner, out bufferData) ? bufferData[46].value : 0);
		damage = (int)math.round((float)damage * (1f + (float)num / 100f));
		ecb.SetComponent(entity, new ExplosionCD
		{
			damage = damage,
			tileDamage = tileDamage,
			radius = radius,
			spawnNapalmObjectID = spawnNapalmObjectID,
			spawnNapalmVariation = spawnNapalmVariation,
			explosionPushback = explosionPushback,
			cameFromExplosive = cameFromExplosive
		});
		ecb.SetComponent(entity, new OwnerReferenceCD
		{
			owner = owner
		});
		InheritConditionsForExplosion(ecb, owner, entity, summarizedConditionsBuffer);
		if (factionLookup.HasComponent(prefabEntity))
		{
			InheritFaction(ecb, owner, entity, factionLookup);
		}
		ecb.SetComponent(entity, new RandomCD
		{
			Value = PugRandom.InheritRngFromEntity(ref random)
		});
		return entity;
	}

	public static void SpawnFireTrapOrNapalm(ObjectID napalmID, int napalmVariation, float3 position, int level, int increasedBurningDamagePercentage, EntityCommandBuffer ecb, ComponentLookup<ObjectPropertiesCD> objectPropertiesCDLookup, ComponentLookup<AttackContinuouslyCD> attackContinuouslyLookup, BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup, ComponentLookup<LevelCD> levelLookup, BufferLookup<ConditionsBuffer> conditionsBufferLookup, PugDatabase.DatabaseBankCD databaseBankCD, bool isFirstTimeFullyPredictingTick)
	{
		if (!isFirstTimeFullyPredictingTick)
		{
			return;
		}
		Entity prefabEntity;
		Entity entity = CreateEntity(ecb, position, napalmID, 1, databaseBankCD.databaseBankBlob, out prefabEntity, napalmVariation);
		ecb.SetComponent(entity, new LevelCD
		{
			level = level
		});
		ObjectDataCD objectData = new ObjectDataCD
		{
			objectID = napalmID,
			variation = level
		};
		Entity levelEntity = GetLevelEntity(prefabEntity, objectData, levelEntitiesBufferLookup, levelLookup);
		if (levelEntity != Entity.Null)
		{
			ecb.SetBuffer<ConditionsBuffer>(entity);
			conditionsBufferLookup.TryGetBuffer(levelEntity, out var bufferData);
			for (int i = 0; i < bufferData.Length; i++)
			{
				ConditionsBuffer element = bufferData[i];
				int num = (int)math.round((float)(element.condition.conditionData.value * increasedBurningDamagePercentage) / 100f);
				element.condition.conditionData.value += num;
				ecb.AppendToBuffer(entity, element);
			}
		}
		AttackContinuouslyCD valueRO = attackContinuouslyLookup.GetRefRO(prefabEntity).ValueRO;
		objectPropertiesCDLookup.TryGetComponent(prefabEntity, out var componentData);
		if (componentData.TryGet<float>(-555946377, out var value))
		{
			valueRO.damage = AttackContinuouslyAuthoring.LevelToDamage(level, value);
		}
		ecb.SetComponent(entity, valueRO);
	}

	public static void SpawnIgnitable(Entity source, EntityCommandBuffer ecb, int2 tilePos, ObjectID objectID, int variation, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob, ComponentLookup<AttackContinuouslyCD> attackContinuouslyLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionBufferLookup)
	{
		Entity prefabEntity;
		Entity entity = CreateEntity(ecb, tilePos.ToFloat3(), objectID, 1, databaseBankBlob, out prefabEntity, variation);
		if (attackContinuouslyLookup.TryGetComponent(prefabEntity, out var componentData) && attackContinuouslyLookup.TryGetComponent(source, out var componentData2))
		{
			float num = (float)componentData2.damage / (componentData2.attackTime + componentData2.cooldown);
			componentData.damage = (int)math.round(num * (componentData.attackTime + componentData.cooldown));
			ecb.SetComponent(entity, componentData);
		}
		InheritConditionsForIgnitable(ecb, source, entity, summarizedConditionBufferLookup);
	}

	private static void InheritAttackData(EntityCommandBuffer ecb, Entity owner, Entity entity, BehaviourTagsCD ownerBehaviourTags, BufferLookup<SummarizedConditionsBuffer> conditionsBufferLookup, FactionCD factionCD, ConditionsTableCD conditionsTable)
	{
		ecb.SetComponent(entity, ownerBehaviourTags);
		if (conditionsBufferLookup.HasComponent(owner))
		{
			for (int i = 0; i < conditionsBufferLookup[owner].Length; i++)
			{
				int value = conditionsBufferLookup[owner][i].value;
				if (value != 0 && ConditionExtensions.ConditionCanBeInherited((ConditionID)i, conditionsTable))
				{
					ecb.AppendToBuffer(entity, new ConditionsBuffer
					{
						condition = new Condition
						{
							conditionData = new ConditionData
							{
								conditionID = (ConditionID)i,
								duration = -1f,
								value = value
							}
						}
					});
				}
			}
		}
		ecb.SetComponent(entity, new FactionCD
		{
			faction = factionCD.faction,
			originalFaction = factionCD.originalFaction,
			factionsLookUp = factionCD.factionsLookUp,
			pvpTeam = factionCD.pvpTeam
		});
	}

	private static void InheritAttackData(EntityCommandBuffer ecb, World world, Entity owner, Entity entity, ConditionsTableCD conditionsTable)
	{
		if (world.EntityManager.HasComponent<BehaviourTagsCD>(owner))
		{
			BehaviourTagsCD componentData = world.EntityManager.GetComponentData<BehaviourTagsCD>(owner);
			ecb.SetComponent(entity, componentData);
		}
		if (!world.EntityManager.HasComponent<SummarizedConditionsBuffer>(owner))
		{
			return;
		}
		DynamicBuffer<SummarizedConditionsBuffer> buffer = world.EntityManager.GetBuffer<SummarizedConditionsBuffer>(owner);
		for (int i = 0; i < buffer.Length; i++)
		{
			int value = buffer[i].value;
			if (value != 0 && ConditionExtensions.ConditionCanBeInherited((ConditionID)i, conditionsTable))
			{
				ecb.AppendToBuffer(entity, new ConditionsBuffer
				{
					condition = new Condition
					{
						conditionData = new ConditionData
						{
							conditionID = (ConditionID)i,
							duration = -1f,
							value = value
						}
					}
				});
			}
		}
	}

	public static void InheritAttackData(EntityCommandBuffer ecb, Entity owner, Entity entity, ConditionsTableCD conditionsTable, ComponentLookup<BehaviourTagsCD> behaviourTagsLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionBufferLookup)
	{
		if (behaviourTagsLookup.TryGetComponent(owner, out var componentData))
		{
			ecb.SetComponent(entity, componentData);
		}
		if (!summarizedConditionBufferLookup.TryGetBuffer(owner, out var bufferData))
		{
			return;
		}
		for (int i = 0; i < bufferData.Length; i++)
		{
			int value = bufferData[i].value;
			if (value != 0 && ConditionExtensions.ConditionCanBeInherited((ConditionID)i, conditionsTable))
			{
				ecb.AppendToBuffer(entity, new ConditionsBuffer
				{
					condition = new Condition
					{
						conditionData = new ConditionData
						{
							conditionID = (ConditionID)i,
							duration = -1f,
							value = value
						}
					}
				});
			}
		}
	}

	public static void InheritConditionsForExplosion(EntityCommandBuffer ecb, Entity owner, Entity entity, BufferLookup<SummarizedConditionsBuffer> summarizedConditionBufferLookup)
	{
		if (!summarizedConditionBufferLookup.TryGetBuffer(owner, out var bufferData))
		{
			return;
		}
		for (int i = 0; i < bufferData.Length; i++)
		{
			int value = bufferData[i].value;
			if (value != 0 && ExplosionConditions((ConditionID)i))
			{
				ecb.AppendToBuffer(entity, new ConditionsBuffer
				{
					condition = new Condition
					{
						conditionData = new ConditionData
						{
							conditionID = (ConditionID)i,
							duration = -1f,
							value = value
						}
					}
				});
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool ExplosionConditions(ConditionID conditionID)
	{
		return conditionID switch
		{
			ConditionID.ChanceToApplyCharmed => true, 
			ConditionID.ChanceToApplyPoisoned => true, 
			ConditionID.ChanceOnHitToStun => true, 
			ConditionID.IncreaseSequenceExplosionTotalMaxExplosionsOnHit => true, 
			ConditionID.ChanceToSpawnNapalmFromExplosives => true, 
			ConditionID.IncreasedBurningDamagePercentage => true, 
			_ => false, 
		};
	}

	public static void InheritConditionsForBomb(EntityCommandBuffer ecb, Entity owner, Entity entity, BufferLookup<SummarizedConditionsBuffer> summarizedConditionBufferLookup)
	{
		if (!summarizedConditionBufferLookup.TryGetBuffer(owner, out var bufferData))
		{
			return;
		}
		for (int i = 0; i < bufferData.Length; i++)
		{
			int value = bufferData[i].value;
			if (value != 0 && BombConditions((ConditionID)i))
			{
				ecb.AppendToBuffer(entity, new ConditionsBuffer
				{
					condition = new Condition
					{
						conditionData = new ConditionData
						{
							conditionID = (ConditionID)i,
							duration = -1f,
							value = value
						}
					}
				});
			}
		}
	}

	private static bool BombConditions(ConditionID conditionID)
	{
		return conditionID switch
		{
			ConditionID.ChanceToDropExplosivesComponents => true, 
			ConditionID.ChanceToSpawnNapalmFromExplosives => true, 
			ConditionID.IncreasedBurningDamagePercentage => true, 
			ConditionID.ExplosivesApplyOilOnGround => true, 
			ConditionID.IncreasedExplosivesDamage => true, 
			ConditionID.IncreasedExplosivesRadiusPercentage => true, 
			_ => false, 
		};
	}

	public static void InheritConditionsForIgnitable(EntityCommandBuffer ecb, Entity owner, Entity entity, BufferLookup<SummarizedConditionsBuffer> summarizedConditionBufferLookup)
	{
		if (!summarizedConditionBufferLookup.TryGetBuffer(owner, out var bufferData))
		{
			return;
		}
		for (int i = 0; i < bufferData.Length; i++)
		{
			int value = bufferData[i].value;
			if (value != 0 && IgnitableConditions((ConditionID)i))
			{
				ecb.AppendToBuffer(entity, new NewConditionsBuffer
				{
					conditionData = new ConditionData
					{
						conditionID = (ConditionID)i,
						duration = -1f,
						value = value
					}
				});
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IgnitableConditions(ConditionID conditionID)
	{
		return conditionID switch
		{
			ConditionID.ApplyBurning => true, 
			ConditionID.ApplyBurningIfBurning => true, 
			_ => false, 
		};
	}

	private static void InheritFaction(EntityCommandBuffer ecb, World world, Entity owner, Entity entity)
	{
		if (world.EntityManager.HasComponent<FactionCD>(owner))
		{
			FactionCD componentData = world.EntityManager.GetComponentData<FactionCD>(owner);
			ecb.SetComponent(entity, new FactionCD
			{
				faction = componentData.faction,
				originalFaction = componentData.originalFaction,
				factionsLookUp = componentData.factionsLookUp,
				pvpTeam = componentData.pvpTeam,
				befriendedBitMask = componentData.befriendedBitMask
			});
		}
	}

	public static void InheritFaction(EntityCommandBuffer ecb, Entity owner, Entity entity, ComponentLookup<FactionCD> factionLookup)
	{
		if (factionLookup.TryGetComponent(owner, out var componentData))
		{
			InheritFaction(ecb, owner, entity, in componentData);
		}
	}

	public static void InheritFaction(EntityCommandBuffer ecb, Entity owner, Entity entity, in FactionCD factionCD)
	{
		ecb.SetComponent(entity, new FactionCD
		{
			faction = factionCD.faction,
			originalFaction = factionCD.originalFaction,
			factionsLookUp = factionCD.factionsLookUp,
			pvpTeam = factionCD.pvpTeam,
			befriendedBitMask = factionCD.befriendedBitMask
		});
	}

	public static void DoRayCast(TileRayCastType type, float2 worldPosition, float2 direction, float distance, TileAccessor tileAccessor, NativeList<TileHitInfo> tilesToCheck)
	{
		if (!(distance <= 1.1920929E-07f))
		{
			TileHitInfo hitInfo = default(TileHitInfo);
			if (type switch
			{
				TileRayCastType.Walls => SinglePugMap.RaycastWalls(worldPosition, direction, distance, out hitInfo, tileAccessor), 
				TileRayCastType.Solid => SinglePugMap.RaycastSolidTiles(worldPosition, direction, distance, out hitInfo, tileAccessor), 
				TileRayCastType.NonWalkable => SinglePugMap.RaycastNonWalkableTiles(worldPosition, direction, distance, out hitInfo, tileAccessor), 
				_ => false, 
			})
			{
				tilesToCheck.Add(in hitInfo);
			}
		}
	}

	public static void CheckIfIntersectedTile(NativeList<TileHitInfo> tilesToCheck, NativeArray<float2> normals, in float2 prevPos, in float2 rayOrigin, in float2 rayDirection, ref float closestTileDistance, ref float2 normal, ref TileHitInfo tileCollidedWith, bool hasBouncing, int2 prevBouncingTile)
	{
		for (int i = 0; i < tilesToCheck.Length; i++)
		{
			int2 tile = tilesToCheck[i].tile;
			float num = float.MaxValue;
			int2 int5 = tile;
			float num2 = math.length(tile - prevPos);
			if (num2 > closestTileDistance || (hasBouncing && math.any(prevBouncingTile != int2.zero) && math.all(tile == prevBouncingTile)))
			{
				continue;
			}
			for (int j = 0; j < 4; j++)
			{
				float2 float5 = normals[j];
				float2 y = ((j < 2) ? new float2(0f, 1f) : new float2(1f, 0f));
				float2 float6 = int5 + float5 * 0.5f;
				float2 x = rayOrigin - float6;
				float num3 = math.dot(rayDirection, float5);
				float num4 = math.dot(x, float5);
				float num5 = math.dot(x, y);
				if (num3 < -1E-05f)
				{
					float num6 = (0f - num4) / num3;
					float x2 = num5 + num6 * math.dot(rayDirection, y);
					if (num6 > 0f && math.abs(x2) <= 0.5f && num6 < num)
					{
						num = num6;
						normal = float5;
						closestTileDistance = num2;
						tileCollidedWith = tilesToCheck[i];
					}
				}
			}
		}
	}

	public static Vector2Int GetPrefabSize(Entity entity, ObjectInfo objectInfo)
	{
		if (!HasComponentData<DirectionCD>(entity, Manager.ecs.ClientWorld))
		{
			return objectInfo.prefabTileSize;
		}
		return GetComponentData<DirectionCD>(entity, Manager.ecs.ClientWorld).GetPrefabTileSize(objectInfo.prefabTileSize);
	}

	public static int2 GetPrefabSize(Entity entity, ref PugDatabase.EntityObjectInfo objectInfo, ComponentLookup<DirectionCD> directionLookup)
	{
		if (!directionLookup.TryGetComponent(entity, out var componentData))
		{
			return objectInfo.prefabTileSize;
		}
		return componentData.GetPrefabTileSize(objectInfo.prefabTileSize);
	}

	public static Vector2Int GetPrefabOffset(Entity entity, ObjectInfo objectInfo)
	{
		if (!HasComponentData<DirectionCD>(entity, Manager.ecs.ClientWorld))
		{
			return objectInfo.prefabCornerOffset;
		}
		return GetComponentData<DirectionCD>(entity, Manager.ecs.ClientWorld).GetPrefabOffset(objectInfo.prefabCornerOffset);
	}

	public static void GetPrefabSizeAndOffset(Entity entity, ObjectInfo objectInfo, out Vector2Int size, out Vector2Int offset)
	{
		World clientWorld = Manager.ecs.ClientWorld;
		if (!HasComponentData<DirectionCD>(entity, clientWorld))
		{
			size = objectInfo.prefabTileSize;
			offset = objectInfo.prefabCornerOffset;
		}
		else
		{
			DirectionCD componentData = GetComponentData<DirectionCD>(entity, clientWorld);
			offset = componentData.GetPrefabOffset(objectInfo.prefabCornerOffset);
			size = componentData.GetPrefabTileSize(objectInfo.prefabTileSize);
		}
	}

	public static Vector2Int GetPrefabSize(ObjectInfo objectInfo, bool hasDirection, in DirectionCD directionCD)
	{
		if (!hasDirection)
		{
			return objectInfo.prefabTileSize;
		}
		return directionCD.GetPrefabTileSize(objectInfo.prefabTileSize);
	}

	public static Vector2Int GetPrefabOffset(ObjectInfo objectInfo, bool hasDirection, in DirectionCD directionCD)
	{
		if (!hasDirection)
		{
			return objectInfo.prefabCornerOffset;
		}
		return directionCD.GetPrefabOffset(objectInfo.prefabCornerOffset);
	}

	public static int2 GetPrefabOffset(Entity entity, ref PugDatabase.EntityObjectInfo objectInfo, ComponentLookup<DirectionCD> directionLookup)
	{
		if (!directionLookup.TryGetComponent(entity, out var componentData))
		{
			return objectInfo.prefabCornerOffset;
		}
		return componentData.GetPrefabOffset(objectInfo.prefabCornerOffset);
	}

	public static void AddTile(int tileSet, TileType tileType, int2 position, bool isWorldModeCreative, DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer)
	{
		if (tileSet < 0 || tileSet >= 75)
		{
			Debug.LogError($"Trying to add invalid tileset {tileSet} for tileType {(int)tileType}");
			return;
		}
		TileCD tile = new TileCD
		{
			tileset = tileSet,
			tileType = tileType
		};
		if (isWorldModeCreative || (tile.tileset != 2 && ((!math.all(position == new int2(0, 0)) && !math.all(position == new int2(0, 1)) && !math.all(position == new int2(-1, 1)) && !math.all(position == new int2(1, 1))) || tile.tileType == TileType.roofHole)))
		{
			tileUpdateBuffer.Add(new TileUpdateBuffer
			{
				command = TileUpdateBuffer.Command.Add,
				position = position,
				tile = tile
			});
			if (tile.tileType == TileType.wall)
			{
				tileUpdateBuffer.Add(new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Remove,
					position = position,
					tile = new TileCD
					{
						tileType = TileType.roofHole
					}
				});
			}
			else if (tile.tileType == TileType.ground)
			{
				tileUpdateBuffer.Add(new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Remove,
					position = position,
					tile = new TileCD
					{
						tileType = TileType.pit
					}
				});
				tileUpdateBuffer.Add(new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Remove,
					position = position,
					tile = new TileCD
					{
						tileType = TileType.water
					}
				});
			}
		}
	}

	public static void RemoveTile(int tileset, TileType tileType, int2 pos, DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer, TileAccessor tileLookup)
	{
		TileCD tile = new TileCD
		{
			tileset = tileset,
			tileType = tileType
		};
		tileUpdateBuffer.Add(new TileUpdateBuffer
		{
			command = TileUpdateBuffer.Command.Remove,
			position = pos,
			tile = tile
		});
		NativeArray<TileCD> nativeArray = tileLookup.Get(pos, Allocator.Temp);
		NativeList<TileType> neededTile = new NativeList<TileType>(4, Allocator.Temp);
		for (int i = 0; i < nativeArray.Length; i++)
		{
			neededTile.Clear();
			nativeArray[i].tileType.GetNeededTile(ref neededTile);
			for (int j = 0; j < neededTile.Length; j++)
			{
				if (neededTile[j] == tileType)
				{
					tileUpdateBuffer.Add(new TileUpdateBuffer
					{
						command = TileUpdateBuffer.Command.Remove,
						position = pos,
						tile = new TileCD
						{
							tileType = nativeArray[i].tileType
						}
					});
					break;
				}
			}
		}
		if (tile.tileType == TileType.ground)
		{
			tileUpdateBuffer.Add(new TileUpdateBuffer
			{
				command = TileUpdateBuffer.Command.Add,
				position = pos,
				tile = new TileCD
				{
					tileType = TileType.pit
				}
			});
		}
		neededTile.Dispose();
		nativeArray.Dispose();
	}

	public static NetworkTick GetCurrentTickOnClientNoFraction(Entity entity, World world)
	{
		bool num = HasComponentData<PredictedGhost>(entity, world);
		NetworkTime singleton = world.GetExistingSystemManaged<PugQuerySystem>().GetSingleton<NetworkTime>();
		NetworkTick result = (num ? singleton.ServerTick : singleton.InterpolationTick);
		if ((num ? singleton.ServerTickFraction : singleton.InterpolationTickFraction) != 1f)
		{
			result.Decrement();
		}
		return result;
	}

	public static NetworkTick GetCurrentTickOnClientNoFraction(Entity entity, NetworkTime networkTime, ComponentLookup<PredictedGhost> predictedGhostLookup)
	{
		bool num = predictedGhostLookup.HasComponent(entity);
		NetworkTick result = (num ? networkTime.ServerTick : networkTime.InterpolationTick);
		if ((num ? networkTime.ServerTickFraction : networkTime.InterpolationTickFraction) != 1f)
		{
			result.Decrement();
		}
		return result;
	}

	public static NetworkTick GetCurrentTickOnClient(Entity entity, World world, out float fraction)
	{
		bool flag = HasComponentData<PredictedGhost>(entity, world);
		NetworkTime singleton = world.GetExistingSystemManaged<PugQuerySystem>().GetSingleton<NetworkTime>();
		NetworkTick result = (flag ? singleton.ServerTick : singleton.InterpolationTick);
		fraction = (flag ? singleton.ServerTickFraction : singleton.InterpolationTickFraction);
		return result;
	}

	public static NetworkTick GetCurrentTickOnClient(Entity entity, NetworkTime networkTime, ComponentLookup<PredictedGhost> predictedGhostLookup, out float fraction)
	{
		bool flag = predictedGhostLookup.HasComponent(entity);
		NetworkTick result = (flag ? networkTime.ServerTick : networkTime.InterpolationTick);
		fraction = (flag ? networkTime.ServerTickFraction : networkTime.InterpolationTickFraction);
		return result;
	}

	public static float GetCurrentTickOnClient(Entity entity, World world)
	{
		float fraction;
		return (float)GetCurrentTickOnClient(entity, world, out fraction).TickIndexForValidTick + fraction;
	}

	private static int HeapInsert<T, U>(T element, DynamicBuffer<T> buffer, U comparer) where T : unmanaged, IBufferElementData where U : struct, IComparer<T>
	{
		int num = buffer.Length;
		int num2 = buffer.Length >> 1;
		buffer.Add(element);
		while (num > 0 && comparer.Compare(buffer[num2], element) > 0)
		{
			int index = num;
			int index2 = num2;
			T val = buffer[num2];
			T val2 = buffer[num];
			T val3 = (buffer[index] = val);
			val3 = (buffer[index2] = val2);
			num >>= 1;
			num2 >>= 1;
		}
		return num;
	}

	public static int FindSorted<T, U, V>(this ref V buffer, T element, U comparer, out bool exists) where T : unmanaged, IBufferElementData where U : struct, IComparer<T> where V : struct, INativeList<T>
	{
		int num = 0;
		int num2 = buffer.Length;
		while (num < num2)
		{
			int num3 = (num + num2) / 2;
			int num4 = comparer.Compare(element, buffer[num3]);
			if (num4 < 0)
			{
				num2 = num3;
				continue;
			}
			if (num4 > 0)
			{
				num = num3 + 1;
				continue;
			}
			exists = true;
			return num3;
		}
		exists = false;
		return (num + num2) / 2;
	}

	public static void InsertSorted<T, U>(this ref DynamicBuffer<T> buffer, T element, U comparer) where T : unmanaged, IBufferElementData where U : struct, IComparer<T>
	{
		bool exists;
		int index = FindSorted(ref buffer, element, comparer, out exists);
		buffer.Insert(index, element);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void PickupGrave(DynamicBuffer<InventoryChangeBuffer> inventoryChangeBuffer, Entity graveEntity, Entity playerEntity, ComponentLookup<HealthCD> healthLookup, ComponentLookup<KilledByPlayerCD> killedByPlayerLookup, DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, NetworkTick currentTick, SfxID chestOpenSfxID, EntityCommandBuffer ecb, in PlayerGhost playerGhost)
	{
		inventoryChangeBuffer.Add(new InventoryChangeBuffer
		{
			inventoryChangeData = Create.MoveInventory(graveEntity, playerEntity, 0, -1, 10),
			playerEntity = playerEntity
		});
		RefRO<HealthCD> refRO = healthLookup.GetRefRO(graveEntity);
		ecb.SetComponent(graveEntity, new HealthCD
		{
			maxHealth = refRO.ValueRO.maxHealth,
			health = 0
		});
		if (killedByPlayerLookup.HasComponent(graveEntity))
		{
			ecb.SetComponent(graveEntity, new KilledByPlayerCD
			{
				playerEntity = playerEntity,
				shouldPullLootToPlayer = true
			});
			ecb.SetComponentEnabled<KilledByPlayerCD>(graveEntity, value: true);
		}
		ghostEffectEventBuffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, new GhostEffectEventBuffer
		{
			Tick = currentTick,
			value = EffectEventExtensions.CreateSingleAudioSFX(localOnlyEffect: true, chestOpenSfxID, playerEntity)
		});
	}

	public static uint SeedFromSystem(FixedString64Bytes systemName)
	{
		return (uint)FNV1A64(systemName);
	}

	private static ulong FNV1A64(FixedString64Bytes text)
	{
		ulong num = 14695981039346656037uL;
		for (int i = 0; i < text.Length; i++)
		{
			byte b = text[i];
			num = 1099511628211L * (num ^ (byte)(b & 0xFF));
			num = 1099511628211L * (num ^ (byte)(b >> 8));
		}
		return num;
	}

	public static bool IsNewlyCreatedObject(Entity entity, World world, bool interpolated = true)
	{
		if (!TryGetComponentData<SpawnTickCD>(entity, world, out var value))
		{
			return false;
		}
		if (!value.Value.IsValid)
		{
			return true;
		}
		NetworkTime singleton = world.GetExistingSystemManaged<PugQuerySystem>().GetSingleton<NetworkTime>();
		return (interpolated ? singleton.InterpolationTick : singleton.ServerTick).TicksSince(value.Value) < 10;
	}

	public static void TryAddPushback(Entity targetEntity, float2 pushback, NetworkTick currentTick, uint tickRate, ComponentLookup<ImmuneToPushBackCD> immuneToPushbackLookup, ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup, ComponentLookup<MoveToPredictedByPushbackCD> moveToPredictedByPushbackLookup, float3 startPosition = default(float3))
	{
		if (moveToPredictedByPushbackLookup.HasComponent(targetEntity))
		{
			moveToPredictedByPushbackLookup.GetRefRW(targetEntity).ValueRW.SetLastInteractionTick(currentTick);
		}
		ReceivedPushbackCD.TryAddPushback(targetEntity, pushback, startPosition, currentTick, tickRate, immuneToPushbackLookup, receivedPushbackLookup);
	}

	public static int2 RotateVectorFromDefaultDownRotation(int2 vector, int2 rotation)
	{
		int2 obj = new int2(-rotation.y, rotation.x);
		int2 int5 = new int2(-rotation.x, -rotation.y);
		return obj * vector.x + int5 * vector.y;
	}
}
