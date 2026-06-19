using System;
using System.Collections.Generic;
using System.Diagnostics;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public static class PugDatabase
{
	[AssumeReadOnly]
	public struct DatabaseBankCD : IComponentData, IQueryTypeParameter
	{
		public BlobAssetReference<PugDatabaseBank> databaseBankBlob;
	}

	public struct PugDatabaseBank
	{
		public BlobArray<EntityObjectInfo> objectInfos;
	}

	public struct EntityObjectInfo
	{
		public ObjectID objectID;

		public ObjectType objectType;

		public int initialAmount;

		public int variation;

		public bool variationIsDynamic;

		public int variationToToggleTo;

		public Rarity rarity;

		public int sellValue;

		public float buyValueMultiplier;

		public LootTableID lootTableID;

		public CraftingSettings CraftingSettings;

		public float craftingTime;

		public bool isStackable;

		public int2 prefabTileSize;

		public int2 prefabCornerOffset;

		public bool centerIsAtEntityPosition;

		public BlobArray<ObjectWithAmount> requiredObjectsToCraft;

		public float salvageMultiplier;

		public BlobArray<Entity> prefabEntities;

		public int tileset;

		public TileType tileType;
	}

	public struct EntityPrefabInfo
	{
		public ObjectID objectID;

		public Entity entity;

		public int variation;
	}

	public struct EntityLootData
	{
		public ObjectID objectID;

		public int amount;
	}

	public class MaterialInfo
	{
		public ObjectID objectID;

		public int amountNeeded;

		public int amountAvailable;

		public Entity nearbyChestWithMaterial;

		public Sprite nearbyChestIcon;

		public MaterialInfo(ObjectID objectID, int amountNeeded, int amountAvailable, Entity nearbyChestWithMaterial, Sprite nearbyChestIcon)
		{
			this.objectID = objectID;
			this.amountNeeded = amountNeeded;
			this.amountAvailable = amountAvailable;
			this.nearbyChestWithMaterial = nearbyChestWithMaterial;
			this.nearbyChestIcon = nearbyChestIcon;
		}
	}

	public struct MaterialInfoData : IComparable<MaterialInfoData>
	{
		public ObjectID objectID;

		public int amountNeeded;

		public int amountAvailable;

		public Entity nearbyChestWithMaterial;

		public MaterialInfoData(ObjectID objectID, int amountNeeded, int amountAvailable, Entity nearbyChestWithMaterial)
		{
			this.objectID = objectID;
			this.amountNeeded = amountNeeded;
			this.amountAvailable = amountAvailable;
			this.nearbyChestWithMaterial = nearbyChestWithMaterial;
		}

		public int CompareTo(MaterialInfoData other)
		{
			return other.amountNeeded.CompareTo(amountNeeded);
		}
	}

	private static World lastWorld;

	[ClearOnReload]
	public static bool inited;

	[ClearOnReload]
	public static List<IEntityMonoBehaviourData> entityMonobehaviours;

	[ClearOnReload]
	public static Dictionary<ObjectDataCD, ObjectInfo> objectsByType;

	[ClearOnReload]
	public static Dictionary<TileType, Dictionary<int, ObjectDataCD>> objectDatasByTileTypeAndTileSet;

	[ClearOnReload]
	public static int objectDatasByTileTypeAndTileSetNumEntries;

	private static BlobArray<Entity> defaultEntityArray;

	[ClearOnReload]
	private static Dictionary<ObjectDataCD, Entity> objectPrefabEntityLookup;

	private static World world
	{
		get
		{
			if (Manager.ecs.ClientWorld != null)
			{
				return Manager.ecs.ClientWorld;
			}
			return Manager.ecs.ServerWorld;
		}
	}

	public static void UpdateEntityMonos(List<MonoBehaviour> entityMonos)
	{
		if (!inited)
		{
			entityMonobehaviours = new List<IEntityMonoBehaviourData>(entityMonos.Count);
			objectsByType = new Dictionary<ObjectDataCD, ObjectInfo>(entityMonos.Count);
			objectDatasByTileTypeAndTileSet = new Dictionary<TileType, Dictionary<int, ObjectDataCD>>();
			objectDatasByTileTypeAndTileSetNumEntries = 0;
			inited = true;
		}
		foreach (MonoBehaviour entityMono in entityMonos)
		{
			if (!(entityMono is IEntityMonoBehaviourData { ObjectInfo: var objectInfo } entityMonoBehaviourData))
			{
				continue;
			}
			entityMonobehaviours.Add(entityMonoBehaviourData);
			ObjectDataCD key = new ObjectDataCD
			{
				objectID = objectInfo.objectID,
				amount = objectInfo.initialAmount,
				variation = objectInfo.variation
			};
			objectsByType.TryAdd(key, objectInfo);
			if (objectInfo.tileType == TileType.none || objectInfo.tileset < 0)
			{
				continue;
			}
			ObjectDataCD value = new ObjectDataCD
			{
				objectID = objectInfo.objectID,
				variation = objectInfo.variation,
				amount = objectInfo.initialAmount
			};
			if (objectDatasByTileTypeAndTileSet.ContainsKey(objectInfo.tileType))
			{
				if (!objectDatasByTileTypeAndTileSet[objectInfo.tileType].ContainsKey(objectInfo.tileset))
				{
					objectDatasByTileTypeAndTileSet[objectInfo.tileType].Add(objectInfo.tileset, value);
				}
			}
			else
			{
				objectDatasByTileTypeAndTileSet.Add(objectInfo.tileType, new Dictionary<int, ObjectDataCD> { { objectInfo.tileset, value } });
				objectDatasByTileTypeAndTileSetNumEntries++;
			}
		}
	}

	public static void SetupTileWithTilesetLookup(ref TileWithTilesetToObjectDataMapCD tileWithTilesetToObjectDataMapCD)
	{
		tileWithTilesetToObjectDataMapCD.lookup = new NativeHashMap<TileTypeTileSetTuple, ObjectDataCD>(objectDatasByTileTypeAndTileSetNumEntries, Allocator.Persistent);
		foreach (KeyValuePair<TileType, Dictionary<int, ObjectDataCD>> item in objectDatasByTileTypeAndTileSet)
		{
			foreach (KeyValuePair<int, ObjectDataCD> item2 in item.Value)
			{
				tileWithTilesetToObjectDataMapCD.lookup.Add((item.Key, (Tileset)item2.Key), item2.Value);
			}
		}
	}

	public static bool TryGetObjectInfo(ObjectID objectID, out ObjectInfo objectInfo, int variation = 0)
	{
		objectInfo = null;
		ObjectDataCD key = new ObjectDataCD
		{
			objectID = objectID,
			amount = 1,
			variation = variation
		};
		if (objectsByType.TryGetValue(key, out objectInfo))
		{
			return true;
		}
		key.variation = 0;
		if (objectsByType.TryGetValue(key, out objectInfo))
		{
			return true;
		}
		return false;
	}

	public static ObjectInfo GetObjectInfo(ObjectID objectID, int variation = 0)
	{
		if (TryGetObjectInfo(objectID, out var objectInfo, variation))
		{
			return objectInfo;
		}
		return null;
	}

	public static bool HasObject(ObjectID objectID, int variation = 0)
	{
		ObjectDataCD key = new ObjectDataCD
		{
			objectID = objectID,
			amount = 1,
			variation = variation
		};
		if (!objectsByType.ContainsKey(key))
		{
			key = new ObjectDataCD
			{
				objectID = objectID,
				amount = 1,
				variation = 0
			};
			if (!objectsByType.ContainsKey(key))
			{
				return false;
			}
		}
		return true;
	}

	public static ObjectInfo TryGetTileItemInfo(TileType tileType, int tileset)
	{
		if (tileType == TileType.none)
		{
			return null;
		}
		if (objectDatasByTileTypeAndTileSet.ContainsKey(tileType) && objectDatasByTileTypeAndTileSet[tileType].ContainsKey(tileset))
		{
			ObjectDataCD key = objectDatasByTileTypeAndTileSet[tileType][tileset];
			return objectsByType[key];
		}
		return null;
	}

	public static ObjectDataCD TryGetTileItemInfo(TileType tileType, Tileset tileset, in TileWithTilesetToObjectDataMapCD tileWithTilesetToObjectDataMapCD)
	{
		tileWithTilesetToObjectDataMapCD.lookup.TryGetValue((tileType, tileset), out var item);
		return item;
	}

	private static int BinarySearchFirstEntry(ObjectID id, BlobAssetReference<PugDatabaseBank> bank)
	{
		ref BlobArray<EntityObjectInfo> objectInfos = ref bank.Value.objectInfos;
		int num = 0;
		int num2 = objectInfos.Length;
		while (num < num2)
		{
			int num3 = (num + num2) / 2;
			if (objectInfos[num3].objectID < id)
			{
				num = num3 + 1;
			}
			else
			{
				num2 = num3;
			}
		}
		if (num >= objectInfos.Length || objectInfos[num].objectID != id)
		{
			return -1;
		}
		return num;
	}

	public static bool HasObject(ObjectID id, BlobAssetReference<PugDatabaseBank> bank, int variation = 0)
	{
		int i = BinarySearchFirstEntry(id, bank);
		if (i == -1)
		{
			return false;
		}
		for (ref BlobArray<EntityObjectInfo> objectInfos = ref bank.Value.objectInfos; i < objectInfos.Length && objectInfos[i].objectID == id; i++)
		{
			if (objectInfos[i].variation == variation || objectInfos[i].variationIsDynamic)
			{
				return true;
			}
		}
		return false;
	}

	public static ref EntityObjectInfo GetEntityObjectInfo(ObjectID id, BlobAssetReference<PugDatabaseBank> bank, int variation = 0)
	{
		int i = BinarySearchFirstEntry(id, bank);
		ref BlobArray<EntityObjectInfo> objectInfos = ref bank.Value.objectInfos;
		if (i >= 0)
		{
			for (; i < objectInfos.Length && objectInfos[i].objectID == id; i++)
			{
				if (objectInfos[i].variation == variation || objectInfos[i].variationIsDynamic)
				{
					return ref objectInfos[i];
				}
			}
		}
		if (variation == 0)
		{
			return ref objectInfos[0];
		}
		return ref GetEntityObjectInfo(id, bank);
	}

	public static float3 GetEntityLocalCenter(ObjectID id, BlobAssetReference<PugDatabaseBank> bank, int variation = 0, float direction = 0f)
	{
		ref EntityObjectInfo entityObjectInfo = ref GetEntityObjectInfo(id, bank, variation);
		if (entityObjectInfo.centerIsAtEntityPosition)
		{
			return float3.zero;
		}
		int2 int5 = (((double)math.abs(direction) < 0.5) ? entityObjectInfo.prefabTileSize.xy : entityObjectInfo.prefabTileSize.yx);
		return entityObjectInfo.prefabCornerOffset.ToFloat3() + (int5 - 1).ToFloat3() / 2f;
	}

	public static int2 GetEntitySize(ObjectID id, BlobAssetReference<PugDatabaseBank> bank, int variation = 0)
	{
		return GetEntityObjectInfo(id, bank, variation).prefabTileSize;
	}

	public static bool TileExists(int tileset, TileType tileType, BlobAssetReference<PugDatabaseBank> bank)
	{
		if (tileType == TileType.none)
		{
			return false;
		}
		ref BlobArray<EntityObjectInfo> objectInfos = ref bank.Value.objectInfos;
		for (int i = 0; i < objectInfos.Length; i++)
		{
			if (objectInfos[i].tileset == tileset && objectInfos[i].tileType == tileType)
			{
				return true;
			}
		}
		return false;
	}

	public static ObjectID GetObjectID(int tileset, TileType tileType, BlobAssetReference<PugDatabaseBank> bank)
	{
		return GetObjectData(tileset, tileType, bank).objectID;
	}

	public static ObjectDataCD GetObjectData(int tileset, TileType tileType, BlobAssetReference<PugDatabaseBank> bank)
	{
		if (tileType == TileType.none)
		{
			return default(ObjectDataCD);
		}
		ref BlobArray<EntityObjectInfo> objectInfos = ref bank.Value.objectInfos;
		for (int i = 0; i < objectInfos.Length; i++)
		{
			if (objectInfos[i].tileset == tileset && objectInfos[i].tileType == tileType)
			{
				return new ObjectDataCD
				{
					objectID = objectInfos[i].objectID,
					variation = objectInfos[i].variation,
					amount = 1
				};
			}
		}
		return default(ObjectDataCD);
	}

	public static Entity GetPrimaryPrefabEntity(ObjectID id, BlobAssetReference<PugDatabaseBank> bank, int variation = 0)
	{
		int i = BinarySearchFirstEntry(id, bank);
		if (i < 0)
		{
			return Entity.Null;
		}
		for (ref BlobArray<EntityObjectInfo> objectInfos = ref bank.Value.objectInfos; i < objectInfos.Length && objectInfos[i].objectID == id; i++)
		{
			if ((objectInfos[i].variationIsDynamic || objectInfos[i].variation == variation) && objectInfos[i].prefabEntities.Length > 0)
			{
				return objectInfos[i].prefabEntities[0];
			}
		}
		return Entity.Null;
	}

	private static void InitObjectPrefabEntityLookup()
	{
		if (lastWorld == PugDatabase.world)
		{
			return;
		}
		World world = (lastWorld = PugDatabase.world);
		objectPrefabEntityLookup = new Dictionary<ObjectDataCD, Entity>();
		using EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(ObjectDataCD), typeof(Prefab));
		NativeArray<Entity> nativeArray = entityQuery.ToEntityArray(Allocator.Temp);
		for (int i = 0; i < nativeArray.Length; i++)
		{
			if (!world.EntityManager.HasComponent<CustomScenePrefab>(nativeArray[i]))
			{
				ObjectDataCD componentData = world.EntityManager.GetComponentData<ObjectDataCD>(nativeArray[i]);
				if (!objectPrefabEntityLookup.ContainsKey(componentData))
				{
					objectPrefabEntityLookup.Add(componentData, nativeArray[i]);
				}
			}
		}
		nativeArray.Dispose();
	}

	private static bool TryGetObjectPrefabEntity(ObjectDataCD objectData, out Entity entity)
	{
		InitObjectPrefabEntityLookup();
		if (objectPrefabEntityLookup.TryGetValue(objectData, out entity))
		{
			return true;
		}
		ObjectDataCD key = new ObjectDataCD
		{
			objectID = objectData.objectID,
			variation = 0,
			amount = 1
		};
		if (objectPrefabEntityLookup.TryGetValue(key, out entity))
		{
			return true;
		}
		entity = Entity.Null;
		return false;
	}

	public static bool HasComponent<T>(ObjectID objectID, int variation = 0)
	{
		return HasComponent<T>(new ObjectDataCD
		{
			objectID = objectID,
			amount = 1,
			variation = variation
		});
	}

	public static bool HasComponent<T>(ObjectDataCD objectData)
	{
		if (objectData.objectID != ObjectID.None && TryGetObjectPrefabEntity(objectData, out var entity))
		{
			return world.EntityManager.HasComponent<T>(entity);
		}
		return false;
	}

	public static T GetComponent<T>(ObjectID objectID, int variation = 0) where T : unmanaged, IComponentData
	{
		return GetComponent<T>(new ObjectDataCD
		{
			objectID = objectID,
			amount = 1,
			variation = variation
		});
	}

	public static T GetComponent<T>(ObjectDataCD objectData) where T : unmanaged, IComponentData
	{
		if (!TryGetObjectPrefabEntity(objectData, out var entity))
		{
			return default(T);
		}
		return world.EntityManager.GetComponentData<T>(entity);
	}

	public static bool TryGetComponent<T>(ObjectID objectID, out T component) where T : unmanaged, IComponentData
	{
		return TryGetComponent<T>(new ObjectDataCD
		{
			objectID = objectID,
			amount = 1,
			variation = 0
		}, out component);
	}

	public static bool TryGetComponent<T>(ObjectDataCD objectData, out T component) where T : unmanaged, IComponentData
	{
		if (!TryGetObjectPrefabEntity(objectData, out var entity) || !world.EntityManager.HasComponent<T>(entity))
		{
			component = default(T);
			return false;
		}
		component = world.EntityManager.GetComponentData<T>(entity);
		return true;
	}

	public static DynamicBuffer<T> GetBuffer<T>(ObjectID objectID) where T : unmanaged, IBufferElementData
	{
		return GetBuffer<T>(new ObjectDataCD
		{
			objectID = objectID,
			amount = 1,
			variation = 0
		});
	}

	public static DynamicBuffer<T> GetBuffer<T>(ObjectDataCD objectData) where T : unmanaged, IBufferElementData
	{
		if (!TryGetObjectPrefabEntity(objectData, out var entity))
		{
			return default(DynamicBuffer<T>);
		}
		return world.EntityManager.GetBuffer<T>(entity);
	}

	public static bool AmountIsDurabilityOrFullnessOrXp(ObjectID objectID, int variation = 0)
	{
		ObjectDataCD objectData = new ObjectDataCD
		{
			objectID = objectID,
			variation = variation
		};
		if (!HasComponent<DurabilityCD>(objectData) && !HasComponent<FullnessCD>(objectData))
		{
			return HasComponent<PetCD>(objectData);
		}
		return true;
	}

	public static bool AmountIsDurabilityOrFullnessOrXp(DatabaseBankCD databaseBankCD, ComponentLookup<DurabilityCD> durabilityLookup, ComponentLookup<FullnessCD> fullnessLookup, ComponentLookup<PetCD> petLookup, ObjectID objectID, int variation = 0)
	{
		Entity primaryPrefabEntity = GetPrimaryPrefabEntity(objectID, databaseBankCD.databaseBankBlob, variation);
		if (!durabilityLookup.HasComponent(primaryPrefabEntity) && !fullnessLookup.HasComponent(primaryPrefabEntity))
		{
			return petLookup.HasComponent(primaryPrefabEntity);
		}
		return true;
	}

	public static ref BlobArray<ObjectWithAmount> GetRequiredObjectsToCraft(ObjectID id, BlobAssetReference<PugDatabaseBank> bank)
	{
		int i = BinarySearchFirstEntry(id, bank);
		ref BlobArray<EntityObjectInfo> objectInfos = ref bank.Value.objectInfos;
		if (i >= 0)
		{
			for (; i < objectInfos.Length && objectInfos[i].objectID == id; i++)
			{
				if (objectInfos[i].variation == 0)
				{
					return ref objectInfos[i].requiredObjectsToCraft;
				}
			}
		}
		return ref objectInfos[0].requiredObjectsToCraft;
	}

	public static int2 GetLootTableDropAmountSpan(LootTableID lootTableID, BlobAssetReference<LootTableBankBlob> bank)
	{
		for (int i = 0; i < bank.Value.lootTables.Length; i++)
		{
			if (bank.Value.lootTables[i].lootTableID == lootTableID)
			{
				return new int2(bank.Value.lootTables[i].minUniqueDrops, bank.Value.lootTables[i].maxUniqueDrops);
			}
		}
		return new int2(0, 0);
	}

	[Conditional("UNITY_EDITOR")]
	private static void EmitMissingLootTableIDError(LootTableID lootTableID)
	{
		UnityEngine.Debug.LogError($"Missing loot table with ID {lootTableID}. Please check your loot table bank.");
	}

	public static NativeList<EntityLootData> GetRandomLoot(LootTableID lootTableID, ref Unity.Mathematics.Random rand, BlobAssetReference<LootTableBankBlob> lootTableBank, BlobAssetReference<PugDatabaseBank> databaseBank, Biome biome, float amountMultiplier = 1f, Rarity minimumRarity = Rarity.Poor)
	{
		int2 lootTableDropAmountSpan = GetLootTableDropAmountSpan(lootTableID, lootTableBank);
		return GetRandomLoot(lootTableID, lootTableDropAmountSpan.x, lootTableDropAmountSpan.y, ref rand, lootTableBank, databaseBank, biome, amountMultiplier, minimumRarity);
	}

	public static NativeList<EntityLootData> GetRandomLoot(LootTableID lootTableID, int minAmount, int maxAmount, ref Unity.Mathematics.Random rand, BlobAssetReference<LootTableBankBlob> lootTableBank, BlobAssetReference<PugDatabaseBank> databaseBank, Biome currentBiome, float amountMultiplier = 1f, Rarity minimumRarity = Rarity.Poor, Allocator allocator = Allocator.Temp)
	{
		int num = (int)math.round((float)rand.NextInt(minAmount, maxAmount + 1) * amountMultiplier);
		NativeList<EntityLootData> result = new NativeList<EntityLootData>(num, allocator);
		if (num == 0 || lootTableID == LootTableID.Empty)
		{
			return result;
		}
		for (int i = 0; i < lootTableBank.Value.lootTables.Length; i++)
		{
			if (lootTableBank.Value.lootTables[i].lootTableID != lootTableID)
			{
				continue;
			}
			float num2 = rand.NextFloat(0f, 1f);
			for (int j = 0; j < lootTableBank.Value.lootTables[i].guaranteedDropsLootTable.Length; j++)
			{
				if (!(num2 <= lootTableBank.Value.lootTables[i].guaranteedDropsLootTable[j].accumulatedDropChance))
				{
					continue;
				}
				Biome onlyDropsInBiome = lootTableBank.Value.lootTables[i].guaranteedDropsLootTable[j].onlyDropsInBiome;
				if (onlyDropsInBiome != Biome.None && onlyDropsInBiome != currentBiome)
				{
					break;
				}
				ObjectID objectID = lootTableBank.Value.lootTables[i].guaranteedDropsLootTable[j].objectID;
				int amount;
				int num3;
				if (objectID == ObjectID.None)
				{
					amount = 0;
					num3 = 0;
				}
				else if (GetEntityObjectInfo(objectID, databaseBank).isStackable)
				{
					Pug.UnityExtensions.RangeInt amount2 = lootTableBank.Value.lootTables[i].guaranteedDropsLootTable[j].amount;
					amount = rand.NextInt(amount2.min, amount2.max + 1);
					num3 = 1;
				}
				else
				{
					Pug.UnityExtensions.RangeInt amount3 = lootTableBank.Value.lootTables[i].guaranteedDropsLootTable[j].amount;
					num3 = rand.NextInt(amount3.min, amount3.max + 1);
					amount = GetEntityObjectInfo(objectID, databaseBank).initialAmount;
				}
				for (int k = 0; k < num3; k++)
				{
					result.Add(new EntityLootData
					{
						objectID = objectID,
						amount = amount
					});
					if (lootTableBank.Value.lootTables[i].dontAllowDuplicates)
					{
						break;
					}
				}
				break;
			}
			for (int l = result.Length; l < num; l++)
			{
				float num4 = 0f;
				for (int m = 0; m < lootTableBank.Value.lootTables[i].lootTable.Length; m++)
				{
					if (GetEntityObjectInfo(lootTableBank.Value.lootTables[i].lootTable[m].objectID, databaseBank).rarity >= minimumRarity)
					{
						num4 += lootTableBank.Value.lootTables[i].lootTable[m].weight;
					}
				}
				num2 = rand.NextFloat(0f, num4);
				float num5 = 0f;
				for (int n = 0; n < lootTableBank.Value.lootTables[i].lootTable.Length; n++)
				{
					ObjectID objectID2 = lootTableBank.Value.lootTables[i].lootTable[n].objectID;
					ref EntityObjectInfo entityObjectInfo = ref GetEntityObjectInfo(objectID2, databaseBank);
					if (entityObjectInfo.rarity < minimumRarity)
					{
						continue;
					}
					num5 += lootTableBank.Value.lootTables[i].lootTable[n].weight;
					if (!(num2 <= num5))
					{
						continue;
					}
					Biome onlyDropsInBiome2 = lootTableBank.Value.lootTables[i].lootTable[n].onlyDropsInBiome;
					if (onlyDropsInBiome2 != Biome.None && onlyDropsInBiome2 != currentBiome)
					{
						break;
					}
					bool flag = true;
					if (lootTableBank.Value.lootTables[i].dontAllowDuplicates)
					{
						for (int num6 = 0; num6 < result.Length; num6++)
						{
							if (result[num6].objectID == objectID2)
							{
								flag = false;
								break;
							}
						}
					}
					if (!flag)
					{
						break;
					}
					int amount4;
					int num7;
					if (objectID2 == ObjectID.None)
					{
						amount4 = 0;
						num7 = 0;
					}
					else if (entityObjectInfo.isStackable)
					{
						Pug.UnityExtensions.RangeInt amount5 = lootTableBank.Value.lootTables[i].lootTable[n].amount;
						amount4 = rand.NextInt(amount5.min, amount5.max + 1);
						num7 = 1;
					}
					else
					{
						Pug.UnityExtensions.RangeInt amount6 = lootTableBank.Value.lootTables[i].lootTable[n].amount;
						num7 = rand.NextInt(amount6.min, amount6.max + 1);
						amount4 = entityObjectInfo.initialAmount;
					}
					for (int num8 = 0; num8 < num7; num8++)
					{
						result.Add(new EntityLootData
						{
							objectID = objectID2,
							amount = amount4
						});
						if (lootTableBank.Value.lootTables[i].dontAllowDuplicates)
						{
							break;
						}
					}
					break;
				}
			}
			break;
		}
		return result;
	}
}
