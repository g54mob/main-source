using PlayerEquipment;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;

public class PlacementHandlerBucket : PlacementHandler
{
	public static int CanPlaceObjectAtPosition(Entity placementPrefab, int3 pos, int width, int height, NativeHashMap<int3, bool> tilesChecked, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		int num = 0;
		bool flag = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.amount > 0;
		valueRW.waterSourceEntity = Entity.Null;
		PhysicsWorld physicsWorld = equipmentUpdateSharedData.physicsWorld;
		equipmentUpdateSharedData.physicsWorldHistory.GetCollisionWorldFromTick(equipmentUpdateSharedData.currentTick, 1u, ref physicsWorld, out var collWorld);
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
				if (top.tileType == TileType.water || (top.tileType == TileType.pit && flag))
				{
					tilesChecked.Add(int5, item: true);
					return width * height;
				}
				float3 float5 = int5 + new float3(0f, 1f, 0f) * 0.5f;
				NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				if (collWorld.CastCollider(PhysicsManager.GetColliderCastInput(float5, float5, PhysicsManager.GetBoxCollider(float3.zero, new float3(0.4f, 0.4f, 0.4f), collidesWith.Value, colliderCacheCD)), ref allHits) && allHits.Length > 0)
				{
					for (int k = 0; k < allHits.Length; k++)
					{
						if (equipmentUpdateLookupData.waterSourceLookup.HasComponent(allHits[k].Entity))
						{
							valueRW.waterSourceEntity = allHits[k].Entity;
							tilesChecked.Add(int5, item: true);
							return width * height;
						}
					}
					tilesChecked.Add(int5, item: false);
				}
				allHits.Dispose();
			}
		}
		if (!flag)
		{
			return num;
		}
		return width * height;
	}
}
