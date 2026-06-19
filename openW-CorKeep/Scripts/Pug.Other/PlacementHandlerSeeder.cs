using System.Collections.Generic;
using PlayerEquipment;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;

public class PlacementHandlerSeeder : PlacementHandler
{
	private struct BoxColliderCastJob
	{
		public CollisionWorld CollisionWorld;

		public float3 Position;

		public float3 HalfExtents;

		public uint CollidesWith;

		public NativeList<DistanceHit> ColliderHits;

		public void ExecuteFake()
		{
			ColliderHits.Clear();
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = CollidesWith
			};
			CollisionWorld.OverlapBox(Position, quaternion.identity, HalfExtents, ref ColliderHits, filter);
		}
	}

	public List<Tileset> nonDiggableGroundTilesets;

	public List<Tileset> seedableGroundTilesets;

	public static int CanPlaceObjectAtPosition(Entity placementPrefab, int3 pos, int width, int height, ref NativeList<EntityAndInfoFromPlacement> diggableEntityAndInfos, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		PhysicsWorld physicsWorld = equipmentUpdateSharedData.physicsWorld;
		equipmentUpdateSharedData.physicsWorldHistory.GetCollisionWorldFromTick(equipmentUpdateSharedData.currentTick, 1u, ref physicsWorld, out var collWorld);
		using NativeList<DistanceHit> colliderHits = new NativeList<DistanceHit>(Allocator.Temp);
		BoxColliderCastJob boxColliderCastJob = new BoxColliderCastJob
		{
			CollisionWorld = collWorld,
			HalfExtents = new float3(0.2f, 1f, 0f),
			ColliderHits = colliderHits
		};
		int num = 0;
		PhysicsCategoryTags collidesWith = equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO.equipmentData.Value.GetEquipmentInfo(equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType).collidesWith;
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		bool flag = equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity);
		bool isHoe = equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType == EquipmentSlotType.HoeSlot;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				int3 int5 = pos + new int3(i, 0, j);
				EntityAndInfoFromPlacement value = default(EntityAndInfoFromPlacement);
				float3 position = int5;
				bool flag2 = false;
				bool flag3 = false;
				if (tileAccessor.HasType(pos.ToInt2(), TileType.immune))
				{
					continue;
				}
				NativeList<EntityAndInfoFromPlacement> nativeList = new NativeList<EntityAndInfoFromPlacement>(Allocator.Temp);
				boxColliderCastJob.HalfExtents.z = 0.3f;
				boxColliderCastJob.Position = position;
				boxColliderCastJob.CollidesWith = collidesWith.Value;
				boxColliderCastJob.ExecuteFake();
				boxColliderCastJob.HalfExtents.z = 0.2f;
				boxColliderCastJob.CollidesWith = collidesWith.Value;
				boxColliderCastJob.Position = position;
				boxColliderCastJob.ExecuteFake();
				for (int k = 0; k < colliderHits.Length; k++)
				{
					if (equipmentUpdateAspect.entity == colliderHits[k].Entity || equipmentUpdateLookupData.playerGhostLookup.HasComponent(colliderHits[k].Entity))
					{
						continue;
					}
					if (equipmentUpdateLookupData.plantLookup.HasComponent(colliderHits[k].Entity))
					{
						flag3 = true;
					}
					else
					{
						if (equipmentUpdateLookupData.critterLookup.HasComponent(colliderHits[k].Entity) || equipmentUpdateLookupData.petLookup.HasComponent(colliderHits[k].Entity))
						{
							continue;
						}
						if (equipmentUpdateLookupData.groundDecorationLookup.HasComponent(colliderHits[k].Entity))
						{
							flag2 = true;
							continue;
						}
						if (equipmentUpdateLookupData.eventTerminalLookup.HasComponent(colliderHits[k].Entity))
						{
							flag3 = true;
							break;
						}
						if (equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(colliderHits[k].Entity, out var componentData))
						{
							if (componentData.Has(-1171081164))
							{
								continue;
							}
							if (componentData.Has(-440732150) || componentData.Has(1497889171))
							{
								flag3 = true;
								continue;
							}
						}
						if (!equipmentUpdateLookupData.objectDataLookup.HasComponent(colliderHits[k].Entity))
						{
							if (equipmentUpdateLookupData.tileLookup.TryGetComponent(colliderHits[k].Entity, out var componentData2))
							{
								if (componentData2.tileType == TileType.pit || componentData2.tileType == TileType.water)
								{
									continue;
								}
								flag3 = true;
								break;
							}
							flag3 = true;
							break;
						}
						ObjectDataCD objectDataCD = equipmentUpdateLookupData.objectDataLookup[colliderHits[k].Entity];
						ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, objectDataCD.variation);
						if (!equipmentUpdateLookupData.diggableLookup.HasComponent(colliderHits[k].Entity) || (!equipmentUpdateLookupData.tileLookup.HasComponent(colliderHits[k].Entity) && !equipmentUpdateLookupData.pseudoTileLookup.HasComponent(colliderHits[k].Entity)))
						{
							continue;
						}
						if (equipmentUpdateLookupData.tileLookup.TryGetComponent(colliderHits[k].Entity, out var componentData3))
						{
							if ((flag || componentData3.tileset != 2) && (componentData3.tileType != TileType.ground || CanPlant((Tileset)componentData3.tileset, isHoe, flag, in equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO)))
							{
								nativeList.Add(new EntityAndInfoFromPlacement(entityObjectInfo.objectID, entityObjectInfo.tileType, entityObjectInfo.tileset, colliderHits[k].Entity, int5));
							}
							continue;
						}
						PseudoTileCD pseudoTileCD = equipmentUpdateLookupData.pseudoTileLookup[colliderHits[k].Entity];
						if (pseudoTileCD.tileType != TileType.ancientCircuitPlate && (pseudoTileCD.tileType != TileType.ground || CanPlant((Tileset)pseudoTileCD.tileset, isHoe, flag, in equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO)))
						{
							value = new EntityAndInfoFromPlacement(entityObjectInfo.objectID, entityObjectInfo.tileType, entityObjectInfo.tileset, colliderHits[k].Entity, int5);
						}
					}
				}
				if (flag3)
				{
					continue;
				}
				bool flag4 = value.objectID != ObjectID.None && value.objectID == ObjectID.DiggingSpot;
				TileCD top = tileAccessor.GetTop(int5.ToInt2());
				bool flag5 = false;
				if (value.objectID != ObjectID.None)
				{
					flag5 = equipmentUpdateLookupData.surfacePriorityLookup.TryGetComponent(value.entity, out var componentData4) && componentData4.Value < top.tileType.GetSurfacePriorityFromJob();
				}
				if (value.objectID == ObjectID.None || flag4 || flag5)
				{
					if (flag2)
					{
						if (top.tileType != TileType.ground && top.tileType != TileType.floorCrack && top.tileType != TileType.dugUpGround && top.tileType != TileType.wateredGround)
						{
							ObjectDataCD objectDataCD2 = PugDatabase.TryGetTileItemInfo(top.tileType, (Tileset)top.tileset, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD);
							Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectDataCD2.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
							if (objectDataCD2.objectID != ObjectID.None && equipmentUpdateLookupData.diggableLookup.HasComponent(primaryPrefabEntity))
							{
								nativeList.Add(new EntityAndInfoFromPlacement(objectDataCD2.objectID, top.tileType, top.tileset, Entity.Null, int5));
							}
						}
						if (nativeList.Length > 0)
						{
							for (int l = 0; l < nativeList.Length; l++)
							{
								if (nativeList[l].tileType == top.tileType)
								{
									value = nativeList[l];
									break;
								}
							}
						}
					}
					else if (!flag4 || (top.tileType != TileType.dugUpGround && top.tileType != TileType.wateredGround))
					{
						if ((top.tileType == TileType.dugUpGround || top.tileType == TileType.wateredGround) && (top.tileType != TileType.ground || CanPlant((Tileset)top.tileset, isHoe, flag, in equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO)))
						{
							ObjectDataCD objectDataCD3 = PugDatabase.TryGetTileItemInfo(top.tileType, (Tileset)top.tileset, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD);
							if (objectDataCD3.objectID != ObjectID.None)
							{
								nativeList.Add(new EntityAndInfoFromPlacement(objectDataCD3.objectID, top.tileType, top.tileset, Entity.Null, int5));
							}
						}
						DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = equipmentUpdateLookupData.containedObjectsBufferLookup[equipmentUpdateAspect.entity];
						for (int m = 0; m < dynamicBuffer.Length; m++)
						{
							if (dynamicBuffer[m].objectID != ObjectID.None)
							{
								Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(dynamicBuffer[m].objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, dynamicBuffer[m].variation);
								if (equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(primaryPrefabEntity2, out var componentData5) && componentData5.Has(-440732150))
								{
									break;
								}
							}
						}
						if (nativeList.Length > 0)
						{
							for (int n = 0; n < nativeList.Length; n++)
							{
								if (nativeList[n].tileType == top.tileType)
								{
									value = nativeList[n];
									break;
								}
							}
						}
					}
				}
				if (value.objectID != ObjectID.None)
				{
					diggableEntityAndInfos.Add(in value);
					num++;
				}
			}
		}
		return (num > 0) ? (width * height) : 0;
	}

	private static bool CanPlant(Tileset tileset, bool isHoe, bool isGodMode, in EquipmentSlotConstantCD equipmentSlotConstantCD)
	{
		if (isHoe)
		{
			for (int i = 0; i < equipmentSlotConstantCD.seedableGroundTilesets.Value.Length; i++)
			{
				if (equipmentSlotConstantCD.seedableGroundTilesets.Value[i] == tileset)
				{
					return true;
				}
			}
			return false;
		}
		if (tileset == Tileset.Obsidian && isGodMode)
		{
			return true;
		}
		for (int j = 0; j < equipmentSlotConstantCD.nonDiggableGroundTilesets.Value.Length; j++)
		{
			if (equipmentSlotConstantCD.nonDiggableGroundTilesets.Value[j] == tileset)
			{
				return false;
			}
		}
		return true;
	}

	public static bool CanPlantInGround(ObjectID groundID, ComponentLookup<ObjectPropertiesCD> propertiesLookup, EquipmentUpdateSharedData equipmentUpdateSharedData, ObjectID seedID)
	{
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(seedID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
		if (propertiesLookup.TryGetComponent(primaryPrefabEntity, out var componentData) && componentData.TryGetList(-789473209, out NativeArray<ObjectID> value, (AllocatorManager.AllocatorHandle)Allocator.Temp))
		{
			foreach (ObjectID item in value)
			{
				if (item == groundID)
				{
					return true;
				}
			}
		}
		return false;
	}
}
