using PlayerEquipment;
using PlayerState;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PaintToolSlot : PlaceObjectSlot
{
	protected override EquipmentSlotType slotType => EquipmentSlotType.PaintToolSlot;

	public new static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.Rotate_Pressed))
		{
			PlaceObjectSlot.Rotate(in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		}
		NativeList<PlacementHandler.EntityAndInfoFromPlacement> diggableEntityAndInfos = new NativeList<PlacementHandler.EntityAndInfoFromPlacement>(Allocator.Temp);
		PlacementHandler.UpdatePlaceablePosition(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		diggableEntityAndInfos.Dispose();
		if (!secondInteractHeld)
		{
			return false;
		}
		PlaceItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData);
		return true;
	}

	private static void PlaceItem(in EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		PlacementCD valueRO = equipmentUpdateAspect.placementCD.ValueRO;
		if (!valueRO.canPlaceObject)
		{
			return;
		}
		ObjectDataCD objectDataCD = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		int3 bestPositionToPlaceAt = valueRO.bestPositionToPlaceAt;
		float cooldown = (equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity) ? 0.15f : 0.25f);
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData, cooldown);
		Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		if (!equipmentUpdateLookupData.paintToolLookup.TryGetComponent(equipmentPrefab, out var componentData))
		{
			Debug.LogError("Trying to paint with a tool that has no PaintToolCD component.");
			return;
		}
		int paintIndex = componentData.paintIndex;
		if (objectDataCD.amount <= 0)
		{
			return;
		}
		float3 float5 = bestPositionToPlaceAt;
		ObjectID entityToPaintEffectID = ObjectID.None;
		if (valueRO.entityToPaint != Entity.Null)
		{
			if (equipmentUpdateSharedData.isServer && equipmentUpdateLookupData.paintableObjectLookup.HasComponent(valueRO.entityToPaint))
			{
				equipmentUpdateLookupData.paintableObjectLookup.GetRefRW(valueRO.entityToPaint).ValueRW.color = (PaintableColor)paintIndex;
			}
			entityToPaintEffectID = objectDataCD.objectID;
		}
		else if (valueRO.tileToPaint.tileType != TileType.none)
		{
			int num = (int)PaintIndexToTileset(paintIndex, valueRO.tileToPaint);
			if (PugDatabase.TryGetTileItemInfo(valueRO.tileToPaint.tileType, (Tileset)num, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD).objectID != ObjectID.None)
			{
				bool isWorldModeCreative = equipmentUpdateSharedData.worldInfoCD.IsWorldModeEnabled(WorldMode.Creative);
				DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer = equipmentUpdateLookupData.tileUpdateBufferLookup[equipmentUpdateSharedData.tileUpdateBufferEntity];
				EntityUtility.AddTile(num, valueRO.tileToPaint.tileType, new int2(bestPositionToPlaceAt.x, bestPositionToPlaceAt.z), isWorldModeCreative, tileUpdateBuffer);
			}
			else
			{
				Debug.LogError($"No paintable entity prefab exists for {valueRO.tileToPaint.tileType} with tileset {num} so skip painting.");
			}
		}
		PlayEffect(entityToPaintEffectID, valueRO.entityToPaint, paintIndex, float5, equipmentUpdateAspect, equipmentUpdateSharedData);
		equipmentUpdateAspect.placeObjectStateCD.ValueRW.positionToPlaceAt = valueRO.bestPositionToPlaceAt;
		equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.PlaceObject);
	}

	public static Tileset PaintIndexToTileset(int colorIndex, TileCD tileInfo)
	{
		if (tileInfo.tileset == 34 || PlacementHandler.IsPaintedGlass(tileInfo.tileset))
		{
			switch (colorIndex)
			{
			case 0:
				return Tileset.Glass;
			case 1:
				return Tileset.GlassYellow;
			case 2:
				return Tileset.GlassGreen;
			case 3:
				return Tileset.GlassRed;
			case 4:
				return Tileset.GlassPurple;
			case 5:
				return Tileset.GlassBlue;
			case 6:
				return Tileset.GlassBrown;
			case 7:
				return Tileset.Glass;
			case 8:
				return Tileset.GlassBlack;
			case 9:
				return Tileset.GlassOrange;
			case 10:
				return Tileset.GlassCyan;
			case 11:
				return Tileset.GlassPink;
			case 12:
				return Tileset.GlassGrey;
			case 13:
				return Tileset.GlassPeach;
			case 14:
				return Tileset.GlassTeal;
			}
		}
		else
		{
			switch (colorIndex)
			{
			case 0:
				return Tileset.BaseBuildingUnpainted;
			case 1:
				return Tileset.BaseBuildingYellow;
			case 2:
				return Tileset.BaseBuildingGreen;
			case 3:
				return Tileset.BaseBuildingRed;
			case 4:
				return Tileset.BaseBuildingPurple;
			case 5:
				return Tileset.BaseBuildingBlue;
			case 6:
				return Tileset.BaseBuildingBrown;
			case 7:
				return Tileset.BaseBuildingWhite;
			case 8:
				return Tileset.BaseBuildingBlack;
			case 9:
				return Tileset.BaseBuildingOrange;
			case 10:
				return Tileset.BaseBuildingCyan;
			case 11:
				return Tileset.BaseBuildingPink;
			case 12:
				return Tileset.BaseBuildingGrey;
			case 13:
				return Tileset.BaseBuildingPeach;
			case 14:
				return Tileset.BaseBuildingTeal;
			}
		}
		Debug.LogError($"Tried painting with color index {colorIndex} which has no corresponding tileset.");
		return Tileset.BaseBuildingUnpainted;
	}

	private static void PlayEffect(ObjectID entityToPaintEffectID, Entity entityToPaint, int colorIndex, Vector3 effectPos, EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData)
	{
		int value = colorIndex switch
		{
			1 => 78, 
			2 => 76, 
			3 => 31, 
			4 => 28, 
			5 => 77, 
			6 => 30, 
			8 => 107, 
			9 => 31, 
			10 => 77, 
			11 => 28, 
			12 => 107, 
			13 => 28, 
			14 => 77, 
			_ => 27, 
		};
		DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
		ref GhostEffectEventBufferPointerCD valueRW = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
		GhostEffectEventBuffer item = new GhostEffectEventBuffer
		{
			Tick = equipmentUpdateSharedData.currentTick,
			value = new EffectEventCD
			{
				effectID = EffectID.Paint,
				position1 = effectPos,
				value1 = value,
				value2 = (int)entityToPaintEffectID,
				entity = entityToPaint
			}
		};
		ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
	}
}
