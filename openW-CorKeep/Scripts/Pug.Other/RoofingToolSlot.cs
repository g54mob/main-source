using PlayerEquipment;
using PlayerState;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public class RoofingToolSlot : EquipmentSlot
{
	private const float ROOFING_COOLDOWN = 0.4f;

	public PlacementHandlerRoofingTool placementHandler;

	protected override EquipmentSlotType slotType => EquipmentSlotType.RoofingToolSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.Rotate_Pressed))
		{
			EquipmentSlot.ChangeSize(in equipmentUpdateAspect, equipmentUpdateSharedData.databaseBank);
		}
		NativeList<PlacementHandler.EntityAndInfoFromPlacement> diggableEntityAndInfos = new NativeList<PlacementHandler.EntityAndInfoFromPlacement>(Allocator.Temp);
		PlacementHandler.UpdatePlaceablePosition(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		diggableEntityAndInfos.Dispose();
		UpdateCanPlaceRoofHole(equipmentUpdateAspect, equipmentUpdateSharedData);
		if (equipmentUpdateAspect.equippedObjectCD.ValueRO.isBroken || !secondInteractHeld)
		{
			return false;
		}
		if (hasItemInMouse)
		{
			return false;
		}
		ToggleRoof(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData);
		return true;
	}

	private static void UpdateCanPlaceRoofHole(EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		valueRW.canPlaceRoofHole = false;
		if (valueRW.canPlaceObject)
		{
			TileType tileType = equipmentUpdateSharedData.tileAccessor.GetTop(valueRW.bestPositionToPlaceAt.ToInt2()).tileType;
			if (tileType == TileType.dugUpGround || tileType == TileType.wateredGround)
			{
				valueRW.canPlaceRoofHole = true;
			}
		}
	}

	private static void ToggleRoof(in EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		ObjectDataCD objectDataCD = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, objectDataCD.variation);
		if (!valueRW.canPlaceObject || entityObjectInfo.objectID == ObjectID.None)
		{
			return;
		}
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData, 0.4f);
		int2 tileSizeFromVariation = EquipmentSlot.GetTileSizeFromVariation(in equipmentUpdateAspect.equipmentSlotCD.ValueRO, in equipmentUpdateAspect.placementSizeByEquipmentTypeBuffer, entityObjectInfo.prefabTileSize);
		float2 float5 = (float2)tileSizeFromVariation / 2f;
		float3 positionToPlaceAt = valueRW.bestPositionToPlaceAt + new float3(float5.x - 0.5f, 0f, float5.y - 0.5f);
		equipmentUpdateAspect.flattenStateCD.ValueRW.positionToPlaceAt = positionToPlaceAt;
		int3 bestPositionToPlaceAt = valueRW.bestPositionToPlaceAt;
		bool flag = false;
		bool flag2 = true;
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		for (int i = 0; i < tileSizeFromVariation.x; i++)
		{
			for (int j = 0; j < tileSizeFromVariation.y; j++)
			{
				int2 worldPosition = (bestPositionToPlaceAt + new int3(i, 0, j)).ToInt2();
				bool flag3 = tileAccessor.GetTop(worldPosition).tileType.IsWallTile();
				if (!tileAccessor.HasType(worldPosition, TileType.roofHole) && !flag3)
				{
					flag2 = false;
					break;
				}
			}
			if (!flag2)
			{
				break;
			}
		}
		if (!flag2)
		{
			flag = true;
		}
		equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.Flatten);
		bool isWorldModeCreative = equipmentUpdateSharedData.worldInfoCD.IsWorldModeEnabled(WorldMode.Creative);
		DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer = equipmentUpdateLookupData.tileUpdateBufferLookup[equipmentUpdateSharedData.tileUpdateBufferEntity];
		for (int k = 0; k < tileSizeFromVariation.x; k++)
		{
			for (int l = 0; l < tileSizeFromVariation.y; l++)
			{
				int2 int5 = (bestPositionToPlaceAt + new int3(k, 0, l)).ToInt2();
				if (!tileAccessor.GetTop(int5).tileType.IsWallTile())
				{
					bool flag4 = tileAccessor.HasType(int5, TileType.roofHole);
					if (flag && !flag4)
					{
						EntityUtility.AddTile(0, TileType.roofHole, int5, isWorldModeCreative, tileUpdateBuffer);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
						ref GhostEffectEventBufferPointerCD valueRW2 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
						GhostEffectEventBuffer item = new GhostEffectEventBuffer
						{
							Tick = equipmentUpdateSharedData.currentTick,
							value = new EffectEventCD
							{
								effectID = EffectID.RoofingToolEffect,
								position1 = int5.ToFloat3(),
								value1 = 1
							}
						};
						ghostEffectEventBuffer.AddToRingBuffer(ref valueRW2, in item);
					}
					else if (!flag && flag4)
					{
						EntityUtility.RemoveTile(0, TileType.roofHole, int5, tileUpdateBuffer, tileAccessor);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = equipmentUpdateAspect.ghostEffectEventBuffer;
						ref GhostEffectEventBufferPointerCD valueRW3 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
						GhostEffectEventBuffer item = new GhostEffectEventBuffer
						{
							Tick = equipmentUpdateSharedData.currentTick,
							value = new EffectEventCD
							{
								effectID = EffectID.RoofingToolEffect,
								position1 = int5.ToFloat3(),
								value1 = 0
							}
						};
						ghostEffectEventBuffer2.AddToRingBuffer(ref valueRW3, in item);
					}
				}
			}
		}
		equipmentUpdateLookupData.reduceDurabilityOfEquippedTagLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
		equipmentUpdateLookupData.reduceDurabilityOfEquippedTagLookup.GetRefRW(equipmentUpdateAspect.entity).ValueRW.triggerCounter++;
	}

	public override void OnFree()
	{
		placementHandler.Disable();
		base.OnFree();
	}

	public override void OnEquip(PlayerController player)
	{
		base.OnEquip(player);
		placementHandler.Enable();
	}

	public override void OnUnequip(PlayerController player)
	{
		placementHandler.Disable();
		base.OnUnequip(player);
	}

	public override void OnPickUp(PlayerController player, bool fireSceneEvent)
	{
		base.OnPickUp(player, fireSceneEvent);
		placementHandler.Disable();
	}
}
