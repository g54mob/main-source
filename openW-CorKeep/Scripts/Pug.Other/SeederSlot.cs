using Inventory;
using PlayerEquipment;
using PlayerState;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public class SeederSlot : EquipmentSlot
{
	private const float SLOT_COOLDOWN = 0.35f;

	public PlacementHandlerSeeder placementHandler;

	protected override EquipmentSlotType slotType => EquipmentSlotType.SeederSlot;

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
		PlaceItem(ref diggableEntityAndInfos, in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData);
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

	private static void PlaceItem(ref NativeList<PlacementHandler.EntityAndInfoFromPlacement> entitiesToSeed, in EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		ref PlacementCD valueRW = ref equipmentUpdateAspect.placementCD.ValueRW;
		if (!valueRW.canPlaceObject)
		{
			return;
		}
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData, 0.35f);
		_ = ref equipmentUpdateAspect.equippedObjectCD.ValueRO;
		PugDatabase.GetEntityObjectInfo(equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData.objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
		bool flag = false;
		DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = equipmentUpdateLookupData.containedObjectsBufferLookup[equipmentUpdateAspect.entity];
		int num = 0;
		int index = 0;
		ObjectID objectID = ObjectID.None;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			if (dynamicBuffer[i].objectID == ObjectID.None)
			{
				continue;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(dynamicBuffer[i].objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob, dynamicBuffer[i].variation);
			if (!equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(primaryPrefabEntity, out var componentData) || !componentData.Has(-440732150))
			{
				continue;
			}
			for (int j = 0; j < entitiesToSeed.Length; j++)
			{
				if (PlacementHandlerSeeder.CanPlantInGround(entitiesToSeed[j].objectID, equipmentUpdateLookupData.objectPropertiesLookup, equipmentUpdateSharedData, dynamicBuffer[i].objectID))
				{
					index = i;
					num = dynamicBuffer[i].amount;
					objectID = dynamicBuffer[i].objectID;
					break;
				}
			}
			if (objectID != ObjectID.None)
			{
				break;
			}
		}
		foreach (PlacementHandler.EntityAndInfoFromPlacement item2 in entitiesToSeed)
		{
			int2 x = item2.pos.ToInt2();
			Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(objectID, equipmentUpdateSharedData.databaseBank.databaseBankBlob);
			if (!equipmentUpdateLookupData.objectPropertiesLookup.TryGetComponent(primaryPrefabEntity2, out var componentData2) || item2.objectID == ObjectID.None || !componentData2.TryGetList(-789473209, out NativeArray<ObjectID> value, (AllocatorManager.AllocatorHandle)Allocator.Temp))
			{
				continue;
			}
			bool flag2 = false;
			foreach (ObjectID item3 in value)
			{
				if (item3 == item2.objectID)
				{
					flag2 = true;
					break;
				}
			}
			value.Dispose();
			if (!flag2 || num <= 0)
			{
				continue;
			}
			valueRW.currentPrefabVariation = 0;
			if (componentData2.TryGet<int>(1273594437, out var value2) && value2 > 0)
			{
				float num2 = 3f + (float)equipmentUpdateLookupData.summarizedConditionsBufferLookup[equipmentUpdateAspect.entity][126].value;
				if (num2 > 0f)
				{
					float num3 = equipmentUpdateAspect.randomCD.ValueRW.Value.NextFloat();
					float num4 = num2 / 100f;
					if (num3 < num4)
					{
						valueRW.currentPrefabVariation = value2;
					}
				}
			}
			flag = true;
			num--;
			DynamicBuffer<InventoryChangeBuffer> dynamicBuffer2 = equipmentUpdateLookupData.inventoryUpdateBuffer[equipmentUpdateSharedData.inventoryUpdateBufferEntity];
			equipmentUpdateAspect.placeObjectStateCD.ValueRW.positionToPlaceAt = x.ToFloat3();
			valueRW.positionLastPlacedAt = x.ToInt3();
			dynamicBuffer2.Add(new InventoryChangeBuffer
			{
				inventoryChangeData = Create.ConsumeEntityAt(equipmentUpdateAspect.entity, index, 1, destroy: false, equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity), x.ToFloat3(), valueRW.currentPrefabVariation),
				playerEntity = equipmentUpdateAspect.entity
			});
			PlaceSeedEffects(x.ToFloat3() + new float3(0f, 1f, 0f) * 0.1f, equipmentUpdateAspect, equipmentUpdateSharedData);
		}
		if (flag)
		{
			equipmentUpdateAspect.digStateCD.ValueRW.positionToPlaceAt = valueRW.bestPositionToPlaceAt;
			equipmentUpdateAspect.playerStateCD.ValueRW.PushState(PlayerStateEnum.Dig);
			equipmentUpdateLookupData.reduceDurabilityOfEquippedTagLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
			equipmentUpdateLookupData.reduceDurabilityOfEquippedTagLookup.GetRefRW(equipmentUpdateAspect.entity).ValueRW.triggerCounter++;
			return;
		}
		DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
		ref GhostEffectEventBufferPointerCD valueRW2 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
		GhostEffectEventBuffer item = new GhostEffectEventBuffer
		{
			Tick = equipmentUpdateSharedData.currentTick,
			value = new EffectEventCD
			{
				entity = equipmentUpdateAspect.entity,
				localOnlyEffect = 1,
				effectID = EffectID.Emote,
				value1 = 37
			}
		};
		ghostEffectEventBuffer.AddToRingBuffer(ref valueRW2, in item);
	}

	private static void PlaceSeedEffects(float3 position, EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData)
	{
		DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
		ref GhostEffectEventBufferPointerCD valueRW = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
		GhostEffectEventBuffer item = new GhostEffectEventBuffer
		{
			Tick = equipmentUpdateSharedData.currentTick,
			value = new EffectEventCD
			{
				effectID = EffectID.DigGround,
				position1 = position
			}
		};
		ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
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
