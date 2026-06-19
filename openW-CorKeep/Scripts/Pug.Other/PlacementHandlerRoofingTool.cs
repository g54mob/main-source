using PlayerEquipment;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;

public class PlacementHandlerRoofingTool : PlacementHandler
{
	public static int CanPlaceObjectAtPosition(Entity placementPrefab, int3 pos, int width, int height, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ColliderCacheCD colliderCacheCD = equipmentUpdateSharedData.colliderCacheCD;
		int num = 0;
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		PhysicsWorld physicsWorld = equipmentUpdateSharedData.physicsWorld;
		equipmentUpdateSharedData.physicsWorldHistory.GetCollisionWorldFromTick(equipmentUpdateSharedData.currentTick, 1u, ref physicsWorld, out var collWorld);
		PhysicsCategoryTags collidesWith = equipmentUpdateAspect.equipmentSlotConstantCD.ValueRO.equipmentData.Value.GetEquipmentInfo(equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType).collidesWith;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				int3 int5 = pos + new int3(i, 0, j);
				if (!tileAccessor.GetTop(int5.ToInt2()).tileType.IsWallTile())
				{
					num++;
				}
				PhysicsCollider boxCollider = PhysicsManager.GetBoxCollider(new float3(0f, 0f, 0f), new float3(0.4f, 2f, 0.4f), collidesWith.Value, colliderCacheCD);
				float3 float5 = int5 + new float3(0f, 1f, 0f) * 0.5f;
				NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				bool flag = false;
				if (collWorld.CastCollider(PhysicsManager.GetColliderCastInput(float5, float5, boxCollider), ref allHits))
				{
					for (int k = 0; k < allHits.Length; k++)
					{
						if (equipmentUpdateLookupData.eventTerminalLookup.HasComponent(allHits[k].Entity))
						{
							flag = true;
							break;
						}
					}
				}
				allHits.Dispose();
				if (flag)
				{
					return 0;
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
