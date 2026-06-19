using Inventory;
using PlayerEquipment;
using PlayerState;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class WaterCanSlot : PlaceObjectSlot
{
	private const int WATER_CONSUMPTION_PER_USE = 5;

	private new const float SLOT_COOLDOWN = 0.35f;

	protected override EquipmentSlotType slotType => EquipmentSlotType.WaterCanSlot;

	public new static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.Rotate_Pressed))
		{
			EquipmentSlot.ChangeSize(in equipmentUpdateAspect, equipmentUpdateSharedData.databaseBank);
		}
		NativeList<PlacementHandler.EntityAndInfoFromPlacement> diggableEntityAndInfos = new NativeList<PlacementHandler.EntityAndInfoFromPlacement>(Allocator.Temp);
		PlacementHandler.UpdatePlaceablePosition(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		if (!secondInteractHeld)
		{
			diggableEntityAndInfos.Dispose();
			return false;
		}
		if (hasItemInMouse)
		{
			return false;
		}
		PlaceItem(ref diggableEntityAndInfos, in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData);
		diggableEntityAndInfos.Dispose();
		return true;
	}

	private static void PlaceItem(ref NativeList<PlacementHandler.EntityAndInfoFromPlacement> entitiesToRemoveByWater, in EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		if (!valueRW.canPlaceObject)
		{
			return;
		}
		int3 bestPositionToPlaceAt = valueRW.bestPositionToPlaceAt;
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData, 0.35f);
		Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		ObjectDataCD objectDataCD = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
		int2 int5 = entityObjectInfo.prefabTileSize;
		if (entityObjectInfo.prefabTileSize.x > 1 && equipmentUpdateLookupData.sizeVariationLookup.HasComponent(equipmentPrefab))
		{
			int5 = EquipmentSlot.GetTileSizeFromVariation(in equipmentUpdateAspect.equipmentSlotCD.ValueRO, in equipmentUpdateAspect.placementSizeByEquipmentTypeBuffer, entityObjectInfo.prefabTileSize);
		}
		int2 prefabCornerOffset = entityObjectInfo.prefabCornerOffset;
		bool flag = true;
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		if (objectDataCD.amount > 0)
		{
			for (int i = prefabCornerOffset.x; i < int5.x + prefabCornerOffset.x; i++)
			{
				for (int j = prefabCornerOffset.y; j < int5.y + prefabCornerOffset.y; j++)
				{
					int2 worldPosition = bestPositionToPlaceAt.ToInt2() + new int2(i, j);
					if (tileAccessor.GetTop(worldPosition).tileType == TileType.dugUpGround)
					{
						flag = false;
						break;
					}
				}
			}
		}
		bool flag2 = false;
		int3 bestPositionToPlaceAt2 = valueRW.bestPositionToPlaceAt;
		float num = float.MaxValue;
		float3 position = equipmentUpdateLookupData.localTransformLookup.GetRefRO(equipmentUpdateAspect.entity).ValueRO.Position;
		if (objectDataCD.amount > 0 && entitiesToRemoveByWater.Length > 0)
		{
			RemoveEntitiesByWater(in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData, ref entitiesToRemoveByWater);
			flag2 = true;
			flag = false;
		}
		else
		{
			bool isWorldModeCreative = equipmentUpdateSharedData.worldInfoCD.IsWorldModeEnabled(WorldMode.Creative);
			DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer = equipmentUpdateLookupData.tileUpdateBufferLookup[equipmentUpdateSharedData.tileUpdateBufferEntity];
			for (int k = 0; k < int5.x; k++)
			{
				for (int l = 0; l < int5.y; l++)
				{
					int2 int6 = bestPositionToPlaceAt.ToInt2() + new int2(k, l);
					TileCD top = tileAccessor.GetTop(int6);
					if (flag && ((top.tileType == TileType.water && top.tileset != 3) || valueRW.waterSourceEntity != Entity.Null))
					{
						float num2 = math.distance(position, int6.ToFloat3());
						if (num2 < num)
						{
							num = num2;
							bestPositionToPlaceAt2 = new int3(int6.x, 0, int6.y);
						}
						flag2 = true;
					}
					else if (top.tileType == TileType.dugUpGround && !flag && objectDataCD.amount > 0)
					{
						EntityUtility.AddTile(top.tileset, TileType.wateredGround, int6, isWorldModeCreative, tileUpdateBuffer);
						flag2 = true;
					}
				}
			}
		}
		if (flag2)
		{
			DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = equipmentUpdateLookupData.inventoryUpdateBuffer[equipmentUpdateSharedData.inventoryUpdateBufferEntity];
			if (flag)
			{
				int maxFullness = equipmentUpdateLookupData.fullnessLookup[equipmentPrefab].maxFullness;
				dynamicBuffer.Add(new InventoryChangeBuffer
				{
					inventoryChangeData = Create.SetAmount(equipmentUpdateAspect.entity, equipmentUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, objectDataCD.objectID, maxFullness),
					playerEntity = equipmentUpdateAspect.entity
				});
				valueRW.bestPositionToPlaceAt = bestPositionToPlaceAt2;
				ref RefillWaterStateCD valueRW2 = ref equipmentUpdateAspect.refillWaterStateCD.ValueRW;
				valueRW2.waterSourceEntity = valueRW.waterSourceEntity;
				valueRW2.tileset = 0;
				equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.RefillWater);
			}
			else if (objectDataCD.amount > 0)
			{
				if (equipmentUpdateAspect.randomCD.ValueRW.Value.NextFloat() > (float)EntityUtility.GetConditionValue(ConditionID.ChanceToNotConsumeWaterCan, equipmentUpdateAspect.entity, equipmentUpdateLookupData.summarizedConditionsBufferLookup) / 100f)
				{
					int amount = math.max(objectDataCD.amount - 5, 0);
					dynamicBuffer.Add(new InventoryChangeBuffer
					{
						inventoryChangeData = Create.SetAmount(equipmentUpdateAspect.entity, equipmentUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, objectDataCD.objectID, amount),
						playerEntity = equipmentUpdateAspect.entity
					});
				}
				ref PlaceWaterStateCD valueRW3 = ref equipmentUpdateAspect.placeWaterStateCD.ValueRW;
				valueRW3.tileset = 0;
				valueRW3.bestPositionToPlaceAt = valueRW.bestPositionToPlaceAt;
				equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.PlaceWater);
			}
		}
		else
		{
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW4 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = equipmentUpdateSharedData.currentTick,
				value = new EffectEventCD
				{
					entity = equipmentUpdateAspect.entity,
					localOnlyEffect = 1,
					effectID = EffectID.Emote,
					value1 = 1
				}
			};
			ghostEffectEventBuffer.AddToRingBuffer(ref valueRW4, in item);
		}
	}

	private static void RemoveEntitiesByWater(in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, ref NativeList<PlacementHandler.EntityAndInfoFromPlacement> entitiesToRemoveByWater)
	{
		foreach (PlacementHandler.EntityAndInfoFromPlacement item in entitiesToRemoveByWater)
		{
			if (equipmentUpdateSharedData.isServer)
			{
				EntityUtility.Destroy(item.entity, dontDrop: true, equipmentUpdateAspect.entity, equipmentUpdateLookupData.healthLookup, equipmentUpdateLookupData.entityDestroyedLookup, equipmentUpdateLookupData.dontDropSelfLookup, equipmentUpdateLookupData.dontDropLootLookup, equipmentUpdateLookupData.killedByPlayerLookup, equipmentUpdateLookupData.plantLookup, equipmentUpdateLookupData.summarizedConditionEffectsBufferLookup, ref equipmentUpdateAspect.randomCD.ValueRW.Value, equipmentUpdateLookupData.moveToPredictedByEntityDestroyedLookup, equipmentUpdateSharedData.currentTick);
			}
			equipmentUpdateAspect.ghostEffectEventBuffer.AddToRingBuffer(ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
			{
				Tick = equipmentUpdateSharedData.currentTick,
				value = new EffectEventCD
				{
					effectID = EffectID.BurnSmoke,
					position1 = new float3(item.pos.x, -0.5f, item.pos.z)
				}
			});
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
		if (!componentData.canPlaceObject)
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
				TileInfo topTile = tileLayerLookup.GetTopTile(int5 + new int2(i, j));
				if (topTile.tileType == TileType.water && topTile.tileset != 3)
				{
					return true;
				}
			}
		}
		return false;
	}
}
