using Inventory;
using PlayerEquipment;
using PlayerState;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using PugTilemap.Quads;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PlaceObjectSlot : EquipmentSlot
{
	public const float SLOT_COOLDOWN = 0.25f;

	public const float PLACE_STOP_DURATION = 0.05f;

	public PlacementHandler placementHandler;

	protected override EquipmentSlotType slotType => EquipmentSlotType.PlaceObjectSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.Rotate_Pressed))
		{
			Rotate(in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		}
		Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		if (equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(equipmentPrefab, out var componentData) && componentData.Has(1718179513))
		{
			AlignWithPlayer(in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		}
		NativeList<PlacementHandler.EntityAndInfoFromPlacement> diggableEntityAndInfos = new NativeList<PlacementHandler.EntityAndInfoFromPlacement>(Allocator.Temp);
		PlacementHandler.UpdatePlaceablePosition(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, ref diggableEntityAndInfos, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData);
		diggableEntityAndInfos.Dispose();
		if (!secondInteractHeld)
		{
			return false;
		}
		if (hasItemInMouse)
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
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, objectDataCD.variation);
		bool flag = entityObjectInfo.objectType == ObjectType.Critter;
		int2 prefabCornerOffset = entityObjectInfo.prefabCornerOffset;
		int3 int5 = valueRW.bestPositionToPlaceAt - new int3(prefabCornerOffset.x, 0, prefabCornerOffset.y);
		Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		if (!CanPlaceItem(equipmentPrefab, ref entityObjectInfo, int5, in equipmentUpdateAspect, in equipmentUpdateSharedData, in equipmentUpdateLookupData))
		{
			return;
		}
		int3 int6 = int5;
		if (valueRW.timeSincePlaced.isRunning && valueRW.timeSincePlaced.GetElapsedSeconds(equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate) < 1f && math.all(int6 == valueRW.positionLastPlacedAt) && !IsPlacingWallAfterPreviouslyPlacedGround(in valueRW, ref entityObjectInfo))
		{
			Debug.LogWarning("Trying to place in same spot or the same entity too quick, gotta wait for server.");
			return;
		}
		if (!flag)
		{
			valueRW.timeSincePlaced.Start(equipmentUpdateSharedData.currentTick);
		}
		float3 float5 = float3.zero;
		ObjectDataCD objectDataCD2 = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		valueRW.positionLastPlacedAt = int6;
		if (!PlayerController.CanConsumeEntityInSlot(equipmentPrefab, objectDataCD2, 1, equipmentUpdateLookupData.cattleLookup))
		{
			return;
		}
		if (!equipmentUpdateSharedData.worldInfoCD.IsWorldModeEnabled(WorldMode.Creative) && entityObjectInfo.objectType != ObjectType.PlaceablePrefab && entityObjectInfo.objectType != ObjectType.Critter && !equipmentUpdateLookupData.cattleLookup.HasComponent(equipmentPrefab))
		{
			Debug.LogError("Tried to consume an item that is not a placeable prefab or critter and we're not a creative mode character, aborting");
			return;
		}
		ref PugDatabase.EntityObjectInfo entityObjectInfo2 = ref PugDatabase.GetEntityObjectInfo(objectDataCD2.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, objectDataCD2.variation);
		float2 float6 = (float2)entityObjectInfo2.prefabTileSize / 2f;
		float3 float7 = new float3(float6.x - 0.5f, 0f, float6.y - 0.5f);
		float3 positionToPlaceAt = valueRW.bestPositionToPlaceAt + float7;
		if (valueRW.rotationVariationToPlace > 0)
		{
			DirectionCD.RotateTransform(quaternion.identity, float7, valueRW.rotationVariationToPlace, entityObjectInfo2.prefabCornerOffset, entityObjectInfo2.prefabTileSize, out var _, out var newTranslation);
			positionToPlaceAt = valueRW.bestPositionToPlaceAt + newTranslation;
		}
		equipmentUpdateAspect.placeObjectStateCD.ValueRW.positionToPlaceAt = positionToPlaceAt;
		equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.PlaceObject);
		float cooldown = (equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity) ? 0.15f : 0.25f);
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData, cooldown);
		float3 float8 = valueRW.bestPositionToPlaceAt;
		bool killEvenIfSquashBugsIsOff = true;
		float3 position = equipmentUpdateLookupData.localTransformLookup[equipmentUpdateAspect.entity].Position;
		TileAccessor tileAccessor = equipmentUpdateSharedData.tileAccessor;
		if (equipmentUpdateLookupData.tileLookup.HasComponent(equipmentPrefab))
		{
			TileType tileTypeToPlace = GetTileTypeToPlace(int5, ref entityObjectInfo, in equipmentUpdateSharedData.tileAccessor, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD);
			DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer = equipmentUpdateLookupData.tileUpdateBufferLookup[equipmentUpdateSharedData.tileUpdateBufferEntity];
			EntityUtility.AddTile(entityObjectInfo.tileset, tileTypeToPlace, new int2(int5.x, int5.z), equipmentUpdateSharedData.worldInfoCD.IsWorldModeEnabled(WorldMode.Creative), tileUpdateBuffer);
			equipmentUpdateLookupData.inventoryUpdateBuffer[equipmentUpdateSharedData.inventoryUpdateBufferEntity].Add(new InventoryChangeBuffer
			{
				inventoryChangeData = Create.ConsumeEntityAt(equipmentUpdateAspect.entity, equipmentUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, 1, destroy: true, equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity), position, objectDataCD2.variation),
				playerEntity = equipmentUpdateAspect.entity
			});
			valueRW.previouslyPlacedTileType = tileTypeToPlace;
		}
		else
		{
			float3 float9 = new float3(int5.x, 0f, int5.z);
			if (!equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(equipmentPrefab, out var componentData))
			{
				Debug.LogError("tried to place an item without object properties");
				return;
			}
			componentData.TryGet<int>(245919617, out valueRW.currentPrefabVariation);
			DynamicBuffer<AdaptiveEntityBuffer> bufferData;
			ObjectPropertiesCD componentData2;
			int value;
			if (flag)
			{
				valueRW.currentPrefabVariation = 1;
			}
			else if (equipmentUpdateLookupData.adaptiveEntityBufferLookup.TryGetBuffer(equipmentPrefab, out bufferData))
			{
				if (bufferData.IsCreated && bufferData.Length > 0)
				{
					int2 int7 = float9.RoundToInt2();
					TileCD top = tileAccessor.GetTop(int7 + AdjacentDir.GetInt2(1));
					TileCD top2 = tileAccessor.GetTop(int7 + AdjacentDir.GetInt2(16));
					TileCD top3 = tileAccessor.GetTop(int7 + AdjacentDir.GetInt2(64));
					TileCD top4 = tileAccessor.GetTop(int7 + AdjacentDir.GetInt2(4));
					PlacementHandler.AdaptiveVariationCanBePlaced(valueRW.currentPrefabVariation, out valueRW.currentPrefabVariation, bufferData, top, top2, top3, top4);
				}
			}
			else if (valueRW.placeObjectOnWall)
			{
				bool variationZeroIsNoDirection = componentData.IsValid && componentData.Has(-377237680);
				valueRW.currentPrefabVariation = DirectionBasedOnVariationCD.GetVariationFromDirection(valueRW.wallSideToPlaceObject, variationZeroIsNoDirection);
				float9 += valueRW.wallSideToPlaceObject.ToFloat3();
			}
			else if (equipmentUpdateLookupData.directionBasedOnVariationLookup.HasComponent(equipmentPrefab))
			{
				valueRW.currentPrefabVariation = valueRW.rotationVariationToPlace;
			}
			else if (equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(equipmentPrefab, out componentData2) && componentData2.TryGet<int>(1273594437, out value))
			{
				killEvenIfSquashBugsIsOff = false;
				if (value > 0)
				{
					float num = 3f + (float)equipmentUpdateLookupData.summarizedConditionsBufferLookup[equipmentUpdateAspect.entity][126].value;
					if (num > 0f)
					{
						float num2 = equipmentUpdateAspect.randomCD.ValueRW.Value.NextFloat();
						float num3 = num / 100f;
						if (num2 < num3)
						{
							valueRW.currentPrefabVariation = value;
						}
					}
				}
			}
			if (PlacementHandler.ObjectCanBeRotated(equipmentPrefab, equipmentUpdateLookupData.directionBasedOnVariationLookup, equipmentUpdateLookupData.objectPropertiesLookup, equipmentUpdateLookupData.directionLookup) && PlacementHandler.ShouldRotatePhysics(equipmentPrefab, equipmentUpdateLookupData.directionLookup))
			{
				float5 = DirectionBasedOnVariationCD.GetDirectionFromVariation(valueRW.rotationVariationToPlace).ToFloat3();
			}
			else if (PlacementHandler.ObjectCanBeToggledToNewNonRotationOption(equipmentPrefab, equipmentUpdateLookupData.objectPropertiesLookup))
			{
				valueRW.currentPrefabVariation = valueRW.nonRotationVariationToPlace;
			}
			int amount = 1;
			if (entityObjectInfo2.objectType == ObjectType.Creature)
			{
				amount = objectDataCD2.amount;
				valueRW.currentPrefabVariation = objectDataCD2.variation;
			}
			bool flag2 = equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity);
			if (!flag2 && equipmentUpdateLookupData.hasExplodedLookup.HasComponent(equipmentPrefab) && !equipmentUpdateLookupData.proximityTriggerLookup.HasComponent(equipmentPrefab) && !equipmentUpdateLookupData.electricityLookup.HasComponent(equipmentPrefab))
			{
				float num4 = equipmentUpdateAspect.randomCD.ValueRW.Value.NextFloat();
				int value2 = equipmentUpdateLookupData.summarizedConditionsBufferLookup[equipmentUpdateAspect.entity][305].value;
				flag2 = num4 < (float)value2 / 100f;
			}
			equipmentUpdateLookupData.inventoryUpdateBuffer[equipmentUpdateSharedData.inventoryUpdateBufferEntity].Add(new InventoryChangeBuffer
			{
				inventoryChangeData = Create.ConsumeEntityAt(equipmentUpdateAspect.entity, equipmentUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, amount, destroy: false, flag2, float9, valueRW.currentPrefabVariation, float5),
				playerEntity = equipmentUpdateAspect.entity
			});
		}
		if (!flag)
		{
			int2 prefabTileSize = entityObjectInfo.prefabTileSize;
			float3 pos = valueRW.bestPositionToPlaceAt + new float3(prefabTileSize.x, 0f, prefabTileSize.y) / 2f - new float3(0.5f, 0f, 0.5f);
			float3 size = new float3(prefabTileSize.x, 1f, prefabTileSize.y);
			equipmentUpdateAspect.critterDamageFromPlacingCD.ValueRW = new CritterDamageFromPlacingCD
			{
				triggered = true,
				pos = pos,
				size = size,
				canDamageFlyingCritter = true,
				killEvenIfSquashBugsIsOff = killEvenIfSquashBugsIsOff
			};
		}
		if (entityObjectInfo.tileType != TileType.none)
		{
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW2 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = equipmentUpdateSharedData.currentTick,
				value = new EffectEventCD
				{
					effectID = EffectID.PlaceTile,
					position1 = float8,
					value1 = (int)entityObjectInfo.tileType
				}
			};
			ghostEffectEventBuffer.AddToRingBuffer(ref valueRW2, in item);
		}
		else if (flag)
		{
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = equipmentUpdateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW3 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = equipmentUpdateSharedData.currentTick,
				value = new EffectEventCD
				{
					effectID = EffectID.PlaceCritter,
					position1 = float8 - new float3(0f, 0.5f, 0f)
				}
			};
			ghostEffectEventBuffer2.AddToRingBuffer(ref valueRW3, in item);
		}
		else
		{
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = equipmentUpdateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW4 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = equipmentUpdateSharedData.currentTick,
				value = new EffectEventCD
				{
					effectID = EffectID.PlaceObject,
					position1 = float8,
					value1 = (int)entityObjectInfo.objectID,
					vector1 = float5
				}
			};
			ghostEffectEventBuffer3.AddToRingBuffer(ref valueRW4, in item);
		}
	}

	private static bool CanPlaceItem(Entity placementPrefab, ref PugDatabase.EntityObjectInfo objectToPlaceInfo, int3 pos, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		if (!equipmentUpdateLookupData.tileLookup.HasComponent(placementPrefab))
		{
			valueRW.tilePlacementTimer.Stop(equipmentUpdateSharedData.currentTick);
			return true;
		}
		TileType tileTypeToPlace = GetTileTypeToPlace(pos, ref objectToPlaceInfo, in equipmentUpdateSharedData.tileAccessor, in equipmentUpdateSharedData.tileWithTilesetToObjectDataMapCD);
		int num;
		if (!equipmentUpdateAspect.clientInput.ValueRO.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_Pressed) && (tileTypeToPlace == TileType.wall || tileTypeToPlace == TileType.ground) && (tileTypeToPlace != TileType.wall || valueRW.previouslyPlacedTileType != TileType.wall) && (tileTypeToPlace != TileType.ground || valueRW.previouslyPlacedTileType != TileType.ground) && valueRW.tilePlacementTimer.isRunning)
		{
			num = (valueRW.tilePlacementTimer.IsTimerElapsed(equipmentUpdateSharedData.currentTick) ? 1 : 0);
			if (num == 0)
			{
				goto IL_00ca;
			}
		}
		else
		{
			num = 1;
		}
		valueRW.tilePlacementTimer.Start(equipmentUpdateSharedData.currentTick, 0.65f, equipmentUpdateSharedData.tickRate);
		goto IL_00ca;
		IL_00ca:
		return (byte)num != 0;
	}

	private static TileType GetTileTypeToPlace(int3 pos, ref PugDatabase.EntityObjectInfo objectToPlaceInfo, in TileAccessor tileAccessor, in TileWithTilesetToObjectDataMapCD tileWithTilesetToObjectDataMapCD)
	{
		int2 worldPosition = pos.ToInt2();
		if (objectToPlaceInfo.tileType == TileType.wall && !tileAccessor.HasType(worldPosition, TileType.ground) && !tileAccessor.HasType(worldPosition, TileType.bridge) && PugDatabase.TryGetTileItemInfo(TileType.ground, (Tileset)objectToPlaceInfo.tileset, in tileWithTilesetToObjectDataMapCD).objectID != ObjectID.None)
		{
			return TileType.ground;
		}
		return objectToPlaceInfo.tileType;
	}

	private static bool IsPlacingWallAfterPreviouslyPlacedGround(in PlacementCD placementCD, ref PugDatabase.EntityObjectInfo objectToPlaceInfo)
	{
		if (placementCD.previouslyPlacedTileType == TileType.ground)
		{
			return objectToPlaceInfo.tileType == TileType.wall;
		}
		return false;
	}

	public static void Rotate(in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		if (PlacementHandler.ObjectCanBeRotated(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, equipmentUpdateLookupData.directionBasedOnVariationLookup, equipmentUpdateLookupData.objectPropertiesLookup, equipmentUpdateLookupData.directionLookup))
		{
			ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
			valueRW.rotationVariationToPlace = (valueRW.rotationVariationToPlace + 1) % 4;
		}
		else if (PlacementHandler.ObjectCanBeToggledToNewNonRotationOption(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, equipmentUpdateLookupData.objectPropertiesLookup))
		{
			int value = 0;
			if (equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData))
			{
				componentData.TryGet<int>(-1876849774, out value);
			}
			ref PlacementCD valueRW2 = ref equipmentUpdateAspect.placementCD.ValueRW;
			valueRW2.nonRotationVariationToPlace = (valueRW2.nonRotationVariationToPlace + 1) % value;
		}
	}

	public static void AlignWithPlayer(in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		if (PlacementHandler.ObjectCanBeRotated(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, equipmentUpdateLookupData.directionBasedOnVariationLookup, equipmentUpdateLookupData.objectPropertiesLookup, equipmentUpdateLookupData.directionLookup))
		{
			ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
			Direction facingDirection = equipmentUpdateAspect.animationOrientationCD.ValueRO.facingDirection;
			valueRW.rotationVariationToPlace = DirectionBasedOnVariationCD.GetVariationFromDirection(new int2((int)facingDirection.vec2.x, (int)facingDirection.vec2.y));
		}
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
