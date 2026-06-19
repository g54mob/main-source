using PlayerEquipment;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;

public class PlacementHandlerPainting : PlacementHandler
{
	public static int CanPlaceObjectAtPosition(Entity placementEntity, int3 pos, int width, int height, NativeHashMap<int3, bool> tilesChecked, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		int num = 0;
		valueRW.entityToPaint = Entity.Null;
		valueRW.tileToPaint = default(TileCD);
		float3 position = equipmentUpdateLookupData.localTransformLookup.GetRefRO(equipmentUpdateAspect.entity).ValueRO.Position;
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		PhysicsWorld physicsWorld = equipmentUpdateSharedData.physicsWorld;
		equipmentUpdateSharedData.physicsWorldHistory.GetCollisionWorldFromTick(equipmentUpdateSharedData.currentTick, 1u, ref physicsWorld, out var collWorld);
		if (!equipmentUpdateLookupData.paintToolLookup.TryGetComponent(placementEntity, out var componentData))
		{
			return 0;
		}
		ColliderCacheCD colliderCacheCD = equipmentUpdateSharedData.colliderCacheCD;
		PhysicsCategoryTags collidesWith = equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO.equipmentData.Value.GetEquipmentInfo(equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType).collidesWith;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				int3 int5 = pos + new int3(i, 0, j);
				if (tilesChecked.ContainsKey(int5))
				{
					if (tilesChecked[int5])
					{
						num++;
					}
					continue;
				}
				bool flag = false;
				Entity entity = Entity.Null;
				float num2 = float.MaxValue;
				float num3 = math.distance(int5, position);
				TileCD top = tileAccessor.GetTop(new int2(int5.x, int5.z));
				ObjectDataCD objectDataCD = PugDatabase.TryGetTileItemInfo(top.tileType, (Tileset)top.tileset, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD);
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectDataCD.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, objectDataCD.variation);
				bool flag2 = top.tileType.IsWallOrThinWall() && equipmentUpdateLookupData.paintableObjectLookup.HasComponent(primaryPrefabEntity);
				float3 float5 = int5 + new float3(0f, 1f, 0f) * 0.5f;
				NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				if (collWorld.CastCollider(PhysicsManager.GetColliderCastInput(float5, float5, PhysicsManager.GetBoxCollider(float3.zero, new float3(0.4f, 0.4f, 0.4f), collidesWith.Value, colliderCacheCD)), ref allHits) && allHits.Length > 0)
				{
					for (int k = 0; k < allHits.Length; k++)
					{
						Entity entity2 = allHits[k].Entity;
						if (!equipmentUpdateLookupData.paintableObjectLookup.HasComponent(entity2) || equipmentUpdateLookupData.tileLookup.HasComponent(entity2))
						{
							continue;
						}
						if (equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(entity2, out var componentData2) && componentData2.Has(-1171081164) && equipmentUpdateLookupData.localTransformLookup.TryGetComponent(entity2, out var componentData3))
						{
							if (top.tileType.IsWallOrThinWall())
							{
								float num4 = math.distance(componentData3.Position, position);
								if (num4 < num2 && (!flag2 || num4 < num3))
								{
									num2 = num4;
									entity = entity2;
								}
							}
							continue;
						}
						if (equipmentUpdateLookupData.localTransformLookup.TryGetComponent(entity2, out var componentData4) && equipmentUpdateLookupData.objectDataLookup.TryGetComponent(entity2, out var componentData5))
						{
							ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(componentData5.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, componentData5.variation);
							if (math.distancesq(int5, componentData4.Position) > 0.1f)
							{
								int2 prefabTileSize = entityObjectInfo.prefabTileSize;
								if (prefabTileSize.x == 1 && prefabTileSize.y == 1)
								{
									continue;
								}
							}
						}
						flag = true;
						valueRW.entityToPaint = entity2;
						break;
					}
				}
				allHits.Dispose();
				if (!flag && entity != Entity.Null && equipmentUpdateLookupData.paintableObjectLookup.TryGetComponent(entity, out var componentData6) && componentData6.color != (PaintableColor)componentData.paintIndex)
				{
					valueRW.entityToPaint = entity;
					flag = true;
				}
				int num5 = -1;
				if (equipmentUpdateLookupData.surfacePriorityLookup.TryGetComponent(valueRW.entityToPaint, out var componentData7))
				{
					num5 = componentData7.Value;
				}
				if ((!flag || num5 != -1) && objectDataCD.objectID != ObjectID.None && equipmentUpdateLookupData.paintableObjectLookup.HasComponent(primaryPrefabEntity) && top.tileType.GetSurfacePriorityFromJob() > num5 && PaintToolSlot.PaintIndexToTileset(componentData.paintIndex, top) != (Tileset)top.tileset)
				{
					valueRW.tileToPaint = top;
					valueRW.entityToPaint = Entity.Null;
					flag = true;
				}
				if (flag)
				{
					num++;
					tilesChecked.Add(int5, item: true);
				}
			}
		}
		return num;
	}
}
