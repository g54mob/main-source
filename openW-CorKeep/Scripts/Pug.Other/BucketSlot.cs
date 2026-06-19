using PlayerEquipment;
using PlayerState;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BucketSlot : PlaceObjectSlot
{
	private const int WATER_CONSUMPTION_PER_USE = 1;

	private new const float SLOT_COOLDOWN = 0.35f;

	protected override EquipmentSlotType slotType => EquipmentSlotType.BucketSlot;

	public new static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.Rotate_Pressed))
		{
			PlaceObjectSlot.Rotate(in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		}
		NativeList<PlacementHandler.EntityAndInfoFromPlacement> diggableEntityAndInfos = new NativeList<PlacementHandler.EntityAndInfoFromPlacement>(Allocator.Temp);
		PlacementHandler.UpdatePlaceablePosition(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		if (!secondInteractHeld)
		{
			return false;
		}
		PlaceItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData);
		return true;
	}

	private static void PlaceItem(in EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		if (!valueRW.canPlaceObject)
		{
			return;
		}
		ObjectDataCD objectDataCD = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		int3 bestPositionToPlaceAt = valueRW.bestPositionToPlaceAt;
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData, 0.35f);
		int2 prefabTileSize = PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob).prefabTileSize;
		Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		bool flag = objectDataCD.amount == 0 || valueRW.waterSourceEntity != Entity.Null;
		float3 position = equipmentUpdateLookupData.localTransformLookup.GetRefRO(equipmentUpdateAspect.entity).ValueRO.Position;
		bool flag2 = false;
		int3 bestPositionToPlaceAt2 = valueRW.bestPositionToPlaceAt;
		float num = float.MaxValue;
		Tileset tileset = Tileset.Dirt;
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		for (int i = 0; i < prefabTileSize.x; i++)
		{
			for (int j = 0; j < prefabTileSize.y; j++)
			{
				int2 int5 = bestPositionToPlaceAt.ToInt2() + new int2(i, j);
				TileCD top = tileAccessor.GetTop(int5);
				if (flag)
				{
					if (top.tileType == TileType.water || valueRW.waterSourceEntity != Entity.Null)
					{
						float num2 = math.distance(position, int5.ToFloat3());
						if (num2 < num)
						{
							num = num2;
							bestPositionToPlaceAt2 = new int3(int5.x, 0, int5.y);
							tileset = (equipmentUpdateLookupData.waterSourceLookup.TryGetComponent(valueRW.waterSourceEntity, out var componentData) ? componentData.waterTileset : ((Tileset)top.tileset));
						}
						flag2 = true;
					}
					continue;
				}
				if (objectDataCD.amount > 0)
				{
					DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer = equipmentUpdateLookupData.tileUpdateBufferLookup[equipmentUpdateSharedData.tileUpdateBufferEntity];
					if (top.tileType == TileType.water || top.tileType == TileType.pit)
					{
						int num3 = math.max(0, objectDataCD.variation - 1);
						if (PugDatabase.TryGetTileItemInfo(TileType.water, (Tileset)num3, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD).objectID != ObjectID.None)
						{
							EntityUtility.AddTile(num3, TileType.water, int5, equipmentUpdateSharedData.worldInfoCD.IsWorldModeEnabled(WorldMode.Creative), tileUpdateBuffer);
						}
					}
					else if (top.tileType == TileType.dugUpGround && objectDataCD.variation != 3)
					{
						EntityUtility.AddTile(top.tileset, TileType.wateredGround, int5, equipmentUpdateSharedData.worldInfoCD.IsWorldModeEnabled(WorldMode.Creative), tileUpdateBuffer);
					}
				}
				flag2 = true;
			}
		}
		if (flag2)
		{
			InventoryHandler.InventoryRequestData inventoryRequestData = new InventoryHandler.InventoryRequestData
			{
				inventoryEntity = equipmentUpdateAspect.entity,
				inventoryUpdateBuffer = equipmentUpdateLookupData.inventoryUpdateBuffer[equipmentUpdateSharedData.inventoryUpdateBufferEntity]
			};
			int equippedSlotIndex = equipmentUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex;
			if (flag)
			{
				InventoryHandler.SetAmount(equippedSlotIndex, objectDataCD.objectID, equipmentUpdateLookupData.fullnessLookup[equipmentPrefab].maxFullness, in inventoryRequestData);
				InventoryHandler.SetVariation(equippedSlotIndex, objectDataCD.objectID, (int)(tileset + 1), in inventoryRequestData);
				valueRW.bestPositionToPlaceAt = bestPositionToPlaceAt2;
				ref RefillWaterStateCD valueRW2 = ref equipmentUpdateAspect.refillWaterStateCD.ValueRW;
				valueRW2.waterSourceEntity = valueRW.waterSourceEntity;
				valueRW2.tileset = (int)tileset;
				equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.RefillWater);
			}
			else if (objectDataCD.amount > 0)
			{
				int amount = math.max(objectDataCD.amount - 1, 0);
				InventoryHandler.SetAmount(equippedSlotIndex, objectDataCD.objectID, amount, in inventoryRequestData);
				ref PlaceWaterStateCD valueRW3 = ref equipmentUpdateAspect.placeWaterStateCD.ValueRW;
				valueRW3.tileset = objectDataCD.variation - 1;
				InventoryHandler.SetVariation(equippedSlotIndex, objectDataCD.objectID, 0, in inventoryRequestData);
				valueRW3.bestPositionToPlaceAt = valueRW.bestPositionToPlaceAt;
				equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.PlaceWater);
			}
		}
	}

	public static bool CanPickUpWater(ObjectDataCD objectData)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return false;
		}
		PlacementCD componentData = EntityUtility.GetComponentData<PlacementCD>(player.entity, player.world);
		if (!componentData.canPlaceObject || objectData.amount > 0)
		{
			return false;
		}
		int2 int5 = componentData.bestPositionToPlaceAt.ToInt2();
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectData.objectID);
		if (objectInfo == null)
		{
			return false;
		}
		Vector2Int prefabTileSize = objectInfo.prefabTileSize;
		SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
		for (int i = 0; i < prefabTileSize.x; i++)
		{
			for (int j = 0; j < prefabTileSize.y; j++)
			{
				if (tileLayerLookup.GetTopTile(int5 + new int2(i, j)).tileType == TileType.water)
				{
					return true;
				}
			}
		}
		return false;
	}
}
