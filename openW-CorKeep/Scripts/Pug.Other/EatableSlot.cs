using Inventory;
using PlayerEquipment;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public class EatableSlot : EquipmentSlot
{
	private const float EAT_DEFAULT_COOLDOWN = 0.4f;

	protected override EquipmentSlotType slotType => EquipmentSlotType.EatableSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (!secondInteractHeld)
		{
			return false;
		}
		if (hasItemInMouse)
		{
			return false;
		}
		if (equipmentUpdateLookupData.petCandyLookup.TryGetComponent(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData))
		{
			FeedPet(componentData, equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData);
		}
		else
		{
			EatItem(equipmentUpdateAspect, equipmentUpdateSharedData, equipmentUpdateLookupData);
		}
		return true;
	}

	private static void EatItem(EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		float cooldownTime = 0.4f;
		if (equipmentUpdateLookupData.cooldownLookup.TryGetComponent(equipmentPrefab, out var componentData) && (equipmentUpdateAspect.CharacterType.ValueRO.characterType != CharacterType.Casual || !componentData.casualCharacterIgnoresCustomCooldown))
		{
			cooldownTime = componentData.cooldown;
		}
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect.equippedObjectCD.ValueRO, ref equipmentUpdateAspect.playerAttackCooldownCD.ValueRW, equipmentUpdateAspect.syncedSharedCooldownTimers, equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate, in equipmentUpdateSharedData.databaseBank, equipmentUpdateLookupData.cooldownLookup, cooldownTime);
		ObjectDataCD objectDataCD = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		if (PlayerController.CanConsumeEntityInSlot(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, objectDataCD, 1, equipmentUpdateLookupData.cattleLookup))
		{
			float3 position = equipmentUpdateLookupData.localTransformLookup[equipmentUpdateAspect.entity].Position;
			DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = equipmentUpdateLookupData.inventoryUpdateBuffer[equipmentUpdateSharedData.inventoryUpdateBufferEntity];
			dynamicBuffer.Add(new InventoryChangeBuffer
			{
				inventoryChangeData = Create.ConsumeEntityAt(equipmentUpdateAspect.entity, equipmentUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, 1, destroy: true, equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity), position, objectDataCD.variation),
				playerEntity = equipmentUpdateAspect.entity
			});
			equipmentUpdateLookupData.waitingForEatableSlotConsumeResultLookup.GetRefRW(equipmentUpdateAspect.entity).ValueRW.consumeResultIndex = dynamicBuffer.Length - 1;
			equipmentUpdateLookupData.waitingForEatableSlotConsumeResultLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
			if (equipmentUpdateLookupData.potionLookup.HasComponent(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab))
			{
				SpawnDrinkParticles(objectDataCD.objectID, position, equipmentUpdateAspect, equipmentUpdateSharedData);
			}
			else
			{
				SpawnEatParticles(objectDataCD.objectID, position, equipmentUpdateAspect, equipmentUpdateSharedData);
			}
		}
	}

	private static void FeedPet(PetCandyCD petCandyCD, EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		int slotIndex = equipmentUpdateAspect.petOwnerCD.ValueRO.SlotIndex;
		ObjectDataCD objectDataCD = equipmentUpdateLookupData.containedObjectsBufferLookup[equipmentUpdateAspect.entity][slotIndex].objectData;
		Entity petEntity = equipmentUpdateAspect.petOwnerCD.ValueRO.PetEntity;
		if (objectDataCD.objectID == ObjectID.None || petEntity == Entity.Null)
		{
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = equipmentUpdateSharedData.currentTick,
				value = new EffectEventCD
				{
					entity = equipmentUpdateAspect.entity,
					localOnlyEffect = 1,
					effectID = EffectID.Emote,
					value1 = 26
				}
			};
			ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
			return;
		}
		float3 position = equipmentUpdateLookupData.localTransformLookup[equipmentUpdateAspect.entity].Position;
		float3 position2 = equipmentUpdateLookupData.localTransformLookup[petEntity].Position;
		if (math.lengthsq(position - position2) > 4f)
		{
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = equipmentUpdateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW2 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = equipmentUpdateSharedData.currentTick,
				value = new EffectEventCD
				{
					entity = equipmentUpdateAspect.entity,
					localOnlyEffect = 1,
					effectID = EffectID.Emote,
					value1 = 25
				}
			};
			ghostEffectEventBuffer2.AddToRingBuffer(ref valueRW2, in item);
			return;
		}
		if (PetExtensions.IsAtMaxLevel(objectDataCD.amount))
		{
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = equipmentUpdateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW3 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = equipmentUpdateSharedData.currentTick,
				value = new EffectEventCD
				{
					entity = equipmentUpdateAspect.entity,
					localOnlyEffect = 1,
					effectID = EffectID.Emote,
					value1 = 24
				}
			};
			ghostEffectEventBuffer3.AddToRingBuffer(ref valueRW3, in item);
			return;
		}
		float cooldownTime = 0.4f;
		if (equipmentUpdateLookupData.cooldownLookup.TryGetComponent(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData))
		{
			cooldownTime = componentData.cooldown;
		}
		EquipmentSlot.StartCooldownForItem(in equipmentUpdateAspect.equippedObjectCD.ValueRO, ref equipmentUpdateAspect.playerAttackCooldownCD.ValueRW, equipmentUpdateAspect.syncedSharedCooldownTimers, equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate, in equipmentUpdateSharedData.databaseBank, equipmentUpdateLookupData.cooldownLookup, cooldownTime);
		ObjectDataCD objectDataCD2 = equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		if (PlayerController.CanConsumeEntityInSlot(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, objectDataCD2, 1, equipmentUpdateLookupData.cattleLookup))
		{
			DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = equipmentUpdateLookupData.inventoryUpdateBuffer[equipmentUpdateSharedData.inventoryUpdateBufferEntity];
			dynamicBuffer.Add(new InventoryChangeBuffer
			{
				inventoryChangeData = Create.ConsumeEntityAt(equipmentUpdateAspect.entity, equipmentUpdateAspect.equippedObjectCD.ValueRO.equippedSlotIndex, 1, destroy: true, equipmentUpdateLookupData.godModeLookup.IsComponentEnabled(equipmentUpdateAspect.entity), position, objectDataCD2.variation),
				playerEntity = equipmentUpdateAspect.entity
			});
			equipmentUpdateLookupData.waitingForEatableSlotConsumeResultLookup.GetRefRW(equipmentUpdateAspect.entity).ValueRW.consumeResultIndex = dynamicBuffer.Length - 1;
			equipmentUpdateLookupData.waitingForEatableSlotConsumeResultLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
			if (equipmentUpdateLookupData.petLookup.TryGetComponent(petEntity, out var componentData2) && equipmentUpdateLookupData.playAnimationStateLookup.HasComponent(petEntity) && equipmentUpdateLookupData.simulateLookup.IsComponentEnabled(petEntity))
			{
				int2 i = Direction.FromVector(position - position2, 0f).i2;
				ref PlayAnimationStateCD valueRW4 = ref equipmentUpdateLookupData.playAnimationStateLookup.GetRefRW(petEntity).ValueRW;
				valueRW4.duration = componentData2.happyAnimDuration;
				valueRW4.animId = -1091730487;
				valueRW4.facingDirection = i;
				valueRW4.internalState = 0;
				valueRW4.timer = default(ThreadSafeTimerSimple);
				equipmentUpdateLookupData.playAnimationStateLookup.SetComponentEnabled(petEntity, value: true);
			}
			SpawnEatParticles(objectDataCD2.objectID, position2, equipmentUpdateAspect, equipmentUpdateSharedData);
			float3 position3 = position2 + new float3(0f, 0.7f, 0f);
			equipmentUpdateAspect.ghostEffectEventBuffer.AddToRingBuffer(ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW, new GhostEffectEventBuffer
			{
				Tick = equipmentUpdateSharedData.currentTick,
				value = new EffectEventCD
				{
					entity = equipmentUpdateAspect.entity,
					localOnlyEffect = 1,
					effectID = EffectID.PetGainExperience,
					value1 = petCandyCD.xp,
					position1 = position3
				}
			});
		}
	}

	private static void SpawnEatParticles(ObjectID objectID, float3 position, EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData)
	{
		EffectID effectID = objectID switch
		{
			ObjectID.Mushroom => EffectID.EatMushroom, 
			ObjectID.HeartBerry => EffectID.EatHeartBerry, 
			_ => EffectID.EatDefault, 
		};
		DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
		ref GhostEffectEventBufferPointerCD valueRW = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
		GhostEffectEventBuffer item = new GhostEffectEventBuffer
		{
			Tick = equipmentUpdateSharedData.currentTick,
			value = new EffectEventCD
			{
				effectID = effectID,
				position1 = position
			}
		};
		ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
	}

	private static void SpawnDrinkParticles(ObjectID objectID, float3 position, EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData)
	{
		EffectID effectID = EffectID.DrinkPotionDefault;
		DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
		ref GhostEffectEventBufferPointerCD valueRW = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
		GhostEffectEventBuffer item = new GhostEffectEventBuffer
		{
			Tick = equipmentUpdateSharedData.currentTick,
			value = new EffectEventCD
			{
				effectID = effectID,
				position1 = position
			}
		};
		ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
	}
}
