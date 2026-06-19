using PlayerEquipment;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;

public class PlacementHandlerWatering : PlacementHandler
{
	public static int CanPlaceObjectAtPosition(Entity placementPrefab, int3 pos, int width, int height, NativeHashMap<int3, bool> tilesChecked, ref NativeList<EntityAndInfoFromPlacement> entitiesToRemoveByWater, EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		int num = 0;
		valueRW.waterSourceEntity = Entity.Null;
		entitiesToRemoveByWater.Clear();
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
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
				TileCD top = tileAccessor.GetTop(int5.ToInt2());
				bool flag = top.tileType == TileType.dugUpGround || (top.tileType == TileType.water && top.tileset != 3);
				if (top.tileType == TileType.water && top.tileset != 3)
				{
					tilesChecked.Add(int5, item: true);
					return width * height;
				}
				PhysicsWorld physicsWorld = equipmentUpdateSharedData.physicsWorld;
				equipmentUpdateSharedData.physicsWorldHistory.GetCollisionWorldFromTick(equipmentUpdateSharedData.currentTick, 1u, ref physicsWorld, out var collWorld);
				float3 float5 = int5 + new float3(0f, 1f, 0f) * 0.5f;
				NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				if (collWorld.CastCollider(PhysicsManager.GetColliderCastInput(float5, float5, PhysicsManager.GetBoxCollider(float3.zero, new float3(0.4f, 0.4f, 0.4f), collidesWith.Value, colliderCacheCD)), ref allHits) && allHits.Length > 0)
				{
					bool flag2 = flag;
					for (int k = 0; k < allHits.Length; k++)
					{
						if (equipmentUpdateLookupData.waterSourceLookup.HasComponent(allHits[k].Entity))
						{
							valueRW.waterSourceEntity = allHits[k].Entity;
							flag2 = true;
							break;
						}
						if (equipmentUpdateLookupData.canBeRemovedByWaterLookup.HasComponent(allHits[k].Entity))
						{
							entitiesToRemoveByWater.Add(new EntityAndInfoFromPlacement(allHits[k].Entity, int5));
							flag2 = true;
							break;
						}
						equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(allHits[k].Entity, out var componentData);
						bool flag3 = componentData.IsValid && componentData.Has(-1171081164);
						if (!equipmentUpdateLookupData.tileLookup.HasComponent(allHits[k].Entity) && (!componentData.IsValid || !componentData.Has(-440732150)) && !equipmentUpdateLookupData.plantLookup.HasComponent(allHits[k].Entity) && !equipmentUpdateLookupData.critterLookup.HasComponent(allHits[k].Entity) && !equipmentUpdateLookupData.cattleLookup.HasComponent(allHits[k].Entity) && !equipmentUpdateLookupData.petLookup.HasComponent(allHits[k].Entity) && !equipmentUpdateLookupData.playerGhostLookup.HasComponent(allHits[k].Entity) && !flag3 && entitiesToRemoveByWater.Length != 0)
						{
							flag2 = false;
							break;
						}
					}
					if (flag2)
					{
						tilesChecked.Add(int5, item: true);
						num++;
					}
					else
					{
						tilesChecked.Add(int5, item: false);
					}
					allHits.Dispose();
				}
				else
				{
					allHits.Dispose();
					if (flag)
					{
						tilesChecked.Add(int5, item: true);
						num++;
					}
					else
					{
						tilesChecked.Add(int5, item: false);
					}
				}
			}
		}
		if (num <= 0)
		{
			return 0;
		}
		return width * height;
	}
}
