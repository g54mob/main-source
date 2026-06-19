using System.Collections.Generic;
using PlayerEquipment;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;

public class PlacementHandlerDigging : PlacementHandler
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

	public List<Tileset> hoeableGroundTilesets;

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
		bool flag2 = equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType == EquipmentSlotType.HoeSlot;
		bool flag3 = flag2;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				int3 int5 = pos + new int3(i, 0, j);
				EntityAndInfoFromPlacement value = default(EntityAndInfoFromPlacement);
				float3 position = int5;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				if (tileAccessor.HasType(pos.ToInt2(), TileType.immune))
				{
					continue;
				}
				NativeList<EntityAndInfoFromPlacement> nativeList = new NativeList<EntityAndInfoFromPlacement>(Allocator.Temp);
				boxColliderCastJob.HalfExtents.z = 0.3f;
				boxColliderCastJob.Position = position;
				boxColliderCastJob.CollidesWith = collidesWith.Value;
				boxColliderCastJob.ExecuteFake();
				for (int k = 0; k < colliderHits.Length; k++)
				{
					if (equipmentUpdateLookupData.playerGhostLookup.HasComponent(colliderHits[k].Entity))
					{
						flag4 = true;
						break;
					}
				}
				boxColliderCastJob.HalfExtents.z = 0.2f;
				boxColliderCastJob.CollidesWith = collidesWith.Value;
				boxColliderCastJob.Position = position;
				boxColliderCastJob.ExecuteFake();
				for (int l = 0; l < colliderHits.Length; l++)
				{
					if (equipmentUpdateAspect.entity == colliderHits[l].Entity || equipmentUpdateLookupData.playerGhostLookup.HasComponent(colliderHits[l].Entity) || equipmentUpdateLookupData.petLookup.HasComponent(colliderHits[l].Entity))
					{
						continue;
					}
					if (equipmentUpdateLookupData.groundDecorationLookup.HasComponent(colliderHits[l].Entity))
					{
						flag5 = true;
						continue;
					}
					if (equipmentUpdateLookupData.eventTerminalLookup.HasComponent(colliderHits[l].Entity))
					{
						flag6 = true;
						break;
					}
					if (equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(colliderHits[l].Entity, out var componentData) && componentData.Has(-1171081164))
					{
						continue;
					}
					if (!equipmentUpdateLookupData.objectDataLookup.HasComponent(colliderHits[l].Entity))
					{
						if (equipmentUpdateLookupData.tileLookup.TryGetComponent(colliderHits[l].Entity, out var componentData2))
						{
							if (componentData2.tileType != TileType.pit && componentData2.tileType != TileType.water)
							{
								flag6 = true;
								break;
							}
							continue;
						}
						flag6 = true;
						break;
					}
					ObjectDataCD objectDataCD = equipmentUpdateLookupData.objectDataLookup[colliderHits[l].Entity];
					ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, objectDataCD.variation);
					if (equipmentUpdateLookupData.diggableLookup.HasComponent(colliderHits[l].Entity) && (equipmentUpdateLookupData.tileLookup.HasComponent(colliderHits[l].Entity) || equipmentUpdateLookupData.pseudoTileLookup.HasComponent(colliderHits[l].Entity)))
					{
						if (equipmentUpdateLookupData.tileLookup.TryGetComponent(colliderHits[l].Entity, out var componentData3))
						{
							if ((flag || componentData3.tileset != 2) && (componentData3.tileType != TileType.ground || CanDig((Tileset)componentData3.tileset, flag2, flag, in equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO)))
							{
								nativeList.Add(new EntityAndInfoFromPlacement(entityObjectInfo.objectID, entityObjectInfo.tileType, entityObjectInfo.tileset, colliderHits[l].Entity, int5));
							}
							continue;
						}
						PseudoTileCD pseudoTileCD = equipmentUpdateLookupData.pseudoTileLookup[colliderHits[l].Entity];
						if (pseudoTileCD.tileType != TileType.ancientCircuitPlate && (pseudoTileCD.tileType != TileType.ground || CanDig((Tileset)pseudoTileCD.tileset, flag2, flag, in equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO)))
						{
							Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(value.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
							if (value.objectID == ObjectID.None || !equipmentUpdateLookupData.surfacePriorityLookup.TryGetComponent(primaryPrefabEntity, out var componentData4) || !equipmentUpdateLookupData.surfacePriorityLookup.TryGetComponent(colliderHits[l].Entity, out var componentData5) || componentData4.Value <= componentData5.Value)
							{
								value = new EntityAndInfoFromPlacement(entityObjectInfo.objectID, entityObjectInfo.tileType, entityObjectInfo.tileset, colliderHits[l].Entity, int5);
							}
						}
					}
					else if (equipmentUpdateLookupData.diggableLookup.HasComponent(colliderHits[l].Entity) && !equipmentUpdateLookupData.tileLookup.HasComponent(colliderHits[l].Entity))
					{
						if (!flag2 || (!equipmentUpdateLookupData.destructibleLookup.HasComponent(colliderHits[l].Entity) && (!equipmentUpdateLookupData.surfacePriorityLookup.TryGetComponent(colliderHits[l].Entity, out var componentData6) || componentData6.Value >= TileType.ground.GetSurfacePriorityFromJob()) && !equipmentUpdateLookupData.rootPlantLookup.HasComponent(colliderHits[l].Entity)))
						{
							Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(value.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
							if ((value.objectID == ObjectID.None || !equipmentUpdateLookupData.plantLookup.HasComponent(primaryPrefabEntity2) || equipmentUpdateLookupData.plantLookup.HasComponent(colliderHits[l].Entity)) && (value.objectID == ObjectID.None || !equipmentUpdateLookupData.surfacePriorityLookup.TryGetComponent(primaryPrefabEntity2, out var componentData7) || !equipmentUpdateLookupData.surfacePriorityLookup.TryGetComponent(colliderHits[l].Entity, out var componentData8) || componentData7.Value <= componentData8.Value))
							{
								value = new EntityAndInfoFromPlacement(entityObjectInfo.objectID, entityObjectInfo.tileType, entityObjectInfo.tileset, colliderHits[l].Entity, int5);
							}
						}
					}
					else if (!equipmentUpdateLookupData.playerGhostLookup.HasComponent(colliderHits[l].Entity) && !equipmentUpdateLookupData.tileLookup.HasComponent(colliderHits[l].Entity) && !equipmentUpdateLookupData.critterLookup.HasComponent(colliderHits[l].Entity) && (equipmentUpdateLookupData.requiresDrillLookup.HasComponent(colliderHits[l].Entity) || (!flag2 && !equipmentUpdateLookupData.dontBlockDiggingLookup.HasComponent(colliderHits[l].Entity))))
					{
						flag6 = true;
						break;
					}
				}
				if (flag6)
				{
					continue;
				}
				bool flag7 = value.objectID == ObjectID.None;
				bool flag8 = value.objectID != ObjectID.None && value.objectID == ObjectID.DiggingSpot;
				TileCD top = tileAccessor.GetTop(int5.ToInt2());
				bool flag9 = false;
				if (value.objectID != ObjectID.None)
				{
					flag9 = equipmentUpdateLookupData.surfacePriorityLookup.TryGetComponent(value.entity, out var componentData9) && componentData9.Value < top.tileType.GetSurfacePriorityFromJob();
				}
				if (value.objectID == ObjectID.None || flag8 || flag9)
				{
					if (flag5)
					{
						if (top.tileType != TileType.ground && top.tileType != TileType.floorCrack && top.tileType != TileType.dugUpGround && top.tileType != TileType.wateredGround)
						{
							ObjectDataCD objectDataCD2 = PugDatabase.TryGetTileItemInfo(top.tileType, (Tileset)top.tileset, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD);
							Entity primaryPrefabEntity3 = PugDatabase.GetPrimaryPrefabEntity(objectDataCD2.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
							if (objectDataCD2.objectID != ObjectID.None && equipmentUpdateLookupData.diggableLookup.HasComponent(primaryPrefabEntity3))
							{
								nativeList.Add(new EntityAndInfoFromPlacement(objectDataCD2.objectID, top.tileType, top.tileset, Entity.Null, int5));
							}
						}
						if (nativeList.Length > 0)
						{
							for (int m = 0; m < nativeList.Length; m++)
							{
								if (nativeList[m].tileType == top.tileType)
								{
									value = nativeList[m];
									break;
								}
							}
						}
					}
					else if (!flag8 || (top.tileType != TileType.ground && top.tileType != TileType.dugUpGround && top.tileType != TileType.wateredGround))
					{
						if ((top.tileType == TileType.ground || top.tileType == TileType.chrysalis || top.tileType == TileType.groundSlime || top.tileType == TileType.dugUpGround || top.tileType == TileType.wateredGround || top.tileType == TileType.floor || (top.tileType == TileType.bridge && !flag2) || top.tileType == TileType.rail || top.tileType == TileType.rug || top.tileType == TileType.litFloor || top.tileType == TileType.looseFlooring) && (top.tileType != TileType.ground || CanDig((Tileset)top.tileset, flag2, flag, in equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO)))
						{
							ObjectDataCD objectDataCD3 = PugDatabase.TryGetTileItemInfo(top.tileType, (Tileset)top.tileset, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD);
							if (objectDataCD3.objectID != ObjectID.None)
							{
								nativeList.Add(new EntityAndInfoFromPlacement(objectDataCD3.objectID, top.tileType, top.tileset, Entity.Null, int5));
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
				if (value.objectID == ObjectID.None)
				{
					continue;
				}
				if (flag4)
				{
					if (!flag7 || flag3 || !value.tileType.CantBeDugWithShovelWhileStandingOn())
					{
						diggableEntityAndInfos.Add(in value);
						num++;
					}
				}
				else
				{
					diggableEntityAndInfos.Add(in value);
					num++;
				}
			}
		}
		return (num > 0) ? (width * height) : 0;
	}

	private static bool CanDig(Tileset tileset, bool isHoe, bool isGodMode, in EquipmentSlotConstantCD equipmentSlotConstantCD)
	{
		if (isHoe)
		{
			for (int i = 0; i < equipmentSlotConstantCD.hoeableGroundTilesets.Value.Length; i++)
			{
				if (equipmentSlotConstantCD.hoeableGroundTilesets.Value[i] == tileset)
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
}
