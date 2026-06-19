using PlayerEquipment;
using PlayerState;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class HoeSlot : EquipmentSlot
{
	public enum HoeAction
	{
		NONE = 0,
		HARVEST_PLANTS = 1,
		HOE_GROUND = 2,
		FLATTEN_GROUND = 3,
		DIG_UP_NON_GROUND_TILES = 4
	}

	private const float DIG_COOLDOWN = 0.4f;

	public PlacementHandlerDigging placementHandler;

	protected override EquipmentSlotType slotType => EquipmentSlotType.HoeSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.Rotate_Pressed))
		{
			EquipmentSlot.ChangeSize(in equipmentUpdateAspect, equipmentUpdateSharedData.databaseBank);
		}
		NativeList<PlacementHandler.EntityAndInfoFromPlacement> diggableEntityAndInfos = new NativeList<PlacementHandler.EntityAndInfoFromPlacement>(Allocator.Temp);
		PlacementHandler.UpdatePlaceablePosition(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		UpdateCanPlaceGround(ref equipmentUpdateAspect.placementCD.ValueRW, equipmentUpdateSharedData.tileAccessor);
		if (equipmentUpdateAspect.equippedObjectCD.ValueRO.isBroken || !secondInteractHeld)
		{
			diggableEntityAndInfos.Dispose();
			return false;
		}
		if (hasItemInMouse)
		{
			return false;
		}
		Dig(ref diggableEntityAndInfos, in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData);
		diggableEntityAndInfos.Dispose();
		return true;
	}

	private static void UpdateCanPlaceGround(ref PlacementCD placementCD, TileAccessor tileAccessor)
	{
		int canPlaceGround;
		if (placementCD.canPlaceObject)
		{
			TileType tileType = tileAccessor.GetTop(placementCD.bestPositionToPlaceAt.ToInt2()).tileType;
			canPlaceGround = ((tileType == TileType.dugUpGround || tileType == TileType.wateredGround) ? 1 : 0);
		}
		else
		{
			canPlaceGround = 0;
		}
		placementCD.canPlaceGround = (byte)canPlaceGround != 0;
	}

	private static void Dig(ref NativeList<PlacementHandler.EntityAndInfoFromPlacement> diggableEntityAndInfos, in EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		PlacementCD valueRO = equipmentUpdateAspect.placementCD.ValueRO;
		if (!valueRO.canPlaceObject)
		{
			return;
		}
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData, 0.4f);
		ObjectDataCD objectDataCD = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, objectDataCD.variation);
		float2 float5 = (float2)entityObjectInfo.prefabTileSize / 2f;
		float3 positionToPlaceAt = valueRO.bestPositionToPlaceAt + new float3(float5.x - 0.5f, 0f, float5.y - 0.5f);
		equipmentUpdateAspect.digStateCD.ValueRW.positionToPlaceAt = positionToPlaceAt;
		equipmentUpdateAspect.flattenStateCD.ValueRW.positionToPlaceAt = positionToPlaceAt;
		HoeAction hoeAction = HoeAction.FLATTEN_GROUND;
		foreach (PlacementHandler.EntityAndInfoFromPlacement diggableEntityAndInfo in diggableEntityAndInfos)
		{
			if (diggableEntityAndInfo.entity != Entity.Null && EntityIsPlantReadyForHarvest(diggableEntityAndInfo.entity, equipmentUpdateLookupData))
			{
				hoeAction = HoeAction.HARVEST_PLANTS;
				break;
			}
			bool flag = diggableEntityAndInfo.tileType == TileType.ground;
			TileType tileType = diggableEntityAndInfo.tileType;
			bool flag2 = tileType == TileType.wateredGround || tileType == TileType.dugUpGround;
			if (flag && hoeAction != HoeAction.DIG_UP_NON_GROUND_TILES)
			{
				hoeAction = HoeAction.HOE_GROUND;
			}
			else if (flag2 && hoeAction != HoeAction.HOE_GROUND && hoeAction != HoeAction.DIG_UP_NON_GROUND_TILES)
			{
				hoeAction = HoeAction.FLATTEN_GROUND;
			}
			else if (!flag && !flag2)
			{
				hoeAction = HoeAction.DIG_UP_NON_GROUND_TILES;
			}
		}
		if (hoeAction == HoeAction.FLATTEN_GROUND)
		{
			equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.Flatten);
		}
		else
		{
			equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.Dig);
		}
		bool isWorldModeCreative = equipmentUpdateSharedData.worldInfoCD.IsWorldModeEnabled(WorldMode.Creative);
		DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer = equipmentUpdateLookupData.tileUpdateBufferLookup[equipmentUpdateSharedData.tileUpdateBufferEntity];
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		_ = ref equipmentUpdateAspect.equippedObjectCD.ValueRO;
		foreach (PlacementHandler.EntityAndInfoFromPlacement diggableEntityAndInfo2 in diggableEntityAndInfos)
		{
			int2 int5 = diggableEntityAndInfo2.pos.ToInt2();
			if (tileAccessor.HasType(int5, TileType.immune))
			{
				continue;
			}
			bool flag3 = false;
			if (hoeAction == HoeAction.HOE_GROUND && diggableEntityAndInfo2.tileType == TileType.ground)
			{
				int tileSet = 0;
				if (PugDatabase.TryGetTileItemInfo(TileType.dugUpGround, (Tileset)diggableEntityAndInfo2.tileset, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD).objectID != ObjectID.None)
				{
					tileSet = diggableEntityAndInfo2.tileset;
				}
				EntityUtility.AddTile(tileSet, TileType.dugUpGround, int5, isWorldModeCreative, tileUpdateBuffer);
				flag3 = true;
			}
			else
			{
				bool flag4 = diggableEntityAndInfo2.tileType == TileType.dugUpGround || diggableEntityAndInfo2.tileType == TileType.wateredGround;
				bool flag5 = diggableEntityAndInfo2.tileType == TileType.ground;
				bool flag6 = !flag4 && !flag5;
				if (diggableEntityAndInfo2.entity != Entity.Null && ((hoeAction == HoeAction.FLATTEN_GROUND && flag4) || (hoeAction == HoeAction.HARVEST_PLANTS && EntityIsPlantReadyForHarvest(diggableEntityAndInfo2.entity, equipmentUpdateLookupData)) || (hoeAction == HoeAction.DIG_UP_NON_GROUND_TILES && flag6)))
				{
					if (hoeAction == HoeAction.DIG_UP_NON_GROUND_TILES || (hoeAction == HoeAction.HARVEST_PLANTS && equipmentUpdateSharedData.isServer))
					{
						Unity.Mathematics.Random rng = new Unity.Mathematics.Random(equipmentUpdateAspect.randomCD.ValueRO.Value.NextUInt());
						EntityUtility.Destroy(diggableEntityAndInfo2.entity, dontDrop: false, equipmentUpdateAspect.entity, equipmentUpdateLookupData.healthLookup, equipmentUpdateLookupData.entityDestroyedLookup, equipmentUpdateLookupData.dontDropSelfLookup, equipmentUpdateLookupData.dontDropLootLookup, equipmentUpdateLookupData.killedByPlayerLookup, equipmentUpdateLookupData.plantLookup, equipmentUpdateLookupData.summarizedConditionEffectsBufferLookup, ref rng, equipmentUpdateLookupData.moveToPredictedByEntityDestroyedLookup, equipmentUpdateSharedData.currentTick);
					}
					TileCD top = tileAccessor.GetTop(int5);
					if (diggableEntityAndInfo2.objectID == ObjectID.DiggingSpot && top.tileset == 0)
					{
						EntityUtility.AddTile(0, TileType.dugUpGround, int5, isWorldModeCreative, tileUpdateBuffer);
					}
					flag3 = true;
					PlayerController.OnHarvest(equipmentUpdateAspect.entity, ref equipmentUpdateAspect.hungerCD.ValueRW, in equipmentUpdateAspect.playerStateCD.ValueRO, equipmentUpdateSharedData.ecb, equipmentUpdateSharedData.isServer, diggableEntityAndInfo2.entity, wasInstantlyDestroyed: true, equipmentUpdateLookupData.plantLookup, equipmentUpdateLookupData.growingLookup, equipmentUpdateLookupData.objectDataLookup, equipmentUpdateLookupData.healthLookup, equipmentUpdateLookupData.summarizedConditionsBufferLookup, equipmentUpdateSharedData.achievementArchetype, equipmentUpdateLookupData.objectPropertiesLookup);
				}
				else if ((hoeAction == HoeAction.DIG_UP_NON_GROUND_TILES && flag6) || (hoeAction == HoeAction.FLATTEN_GROUND && flag4))
				{
					PlayerController.DigUpTile(diggableEntityAndInfo2.tileType, diggableEntityAndInfo2.tileset, diggableEntityAndInfo2.pos, equipmentUpdateAspect.entity, tileUpdateBuffer, equipmentUpdateSharedData.tileAccessor, equipmentUpdateSharedData.databaseBank, equipmentUpdateSharedData.ecb, equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD, equipmentUpdateLookupData.tileLookup, equipmentUpdateSharedData.isFirstTimeFullyPredictingTick);
					flag3 = true;
				}
				if (hoeAction == HoeAction.FLATTEN_GROUND && diggableEntityAndInfo2.tileType == TileType.wateredGround)
				{
					EntityUtility.RemoveTile(0, TileType.dugUpGround, int5, tileUpdateBuffer, equipmentUpdateSharedData.tileAccessor);
					flag3 = true;
				}
			}
			if (flag3)
			{
				PlayDigEffects(diggableEntityAndInfo2.pos + new float3(0f, 1f, 0f) * 0.1f, hoeAction == HoeAction.HOE_GROUND, equipmentUpdateAspect, equipmentUpdateSharedData);
			}
			float num = entityObjectInfo.prefabTileSize.x;
			float num2 = entityObjectInfo.prefabTileSize.y;
			float num3 = 0.5f;
			float num4 = -0.5f;
			float3 float6 = new float3(num / 2f + num4, 0f, num2 / 2f + num4);
			float3 size = new float3(num + num3, 1f, num2 + num3);
			equipmentUpdateAspect.critterDamageFromPlacingCD.ValueRW = new CritterDamageFromPlacingCD
			{
				triggered = true,
				pos = int5.ToFloat3() - float6,
				size = size,
				canDamageFlyingCritter = false,
				killEvenIfSquashBugsIsOff = true
			};
		}
		equipmentUpdateLookupData.reduceDurabilityOfEquippedTagLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
		equipmentUpdateLookupData.reduceDurabilityOfEquippedTagLookup.GetRefRW(equipmentUpdateAspect.entity).ValueRW.triggerCounter++;
	}

	private static bool EntityIsPlantReadyForHarvest(Entity entity, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(entity, out var componentData);
		if (!equipmentUpdateLookupData.plantLookup.HasComponent(entity) || !equipmentUpdateLookupData.growingLookup.TryGetComponent(entity, out var componentData2) || !componentData2.HasFinishedGrowing(componentData))
		{
			if (equipmentUpdateLookupData.objectDataLookup.TryGetComponent(entity, out var componentData3))
			{
				return componentData3.objectID == ObjectID.Mushroom;
			}
			return false;
		}
		return true;
	}

	private static void PlayDigEffects(Vector3 position, bool isDiggingUp, EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData)
	{
		EffectID effectID = (isDiggingUp ? EffectID.DigGround : EffectID.DigDugUpGround);
		equipmentUpdateAspect.ghostEffectEventBuffer.AddToRingBuffer(ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
		{
			Tick = equipmentUpdateSharedData.currentTick,
			value = new EffectEventCD
			{
				effectID = effectID,
				position1 = position
			}
		});
	}

	public override void OnFree()
	{
		placementHandler.Disable();
		base.OnFree();
	}

	public override void OnEquip(PlayerController player)
	{
		placementHandler.Enable();
		base.OnEquip(player);
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
