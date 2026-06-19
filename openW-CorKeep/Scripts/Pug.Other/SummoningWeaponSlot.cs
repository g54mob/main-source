using Inventory;
using PlayerEquipment;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public class SummoningWeaponSlot : EquipmentSlot
{
	protected override EquipmentSlotType slotType => EquipmentSlotType.SummoningWeaponSlot;

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		if (hasItemInMouse)
		{
			return false;
		}
		if (!secondInteractHeld)
		{
			return false;
		}
		Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		equipmentUpdateLookupData.secondaryUseLookup.TryGetComponent(equipmentPrefab, out var componentData);
		ref EquipmentSlotCD valueRW = ref equipmentUpdateAspect.equipmentSlotCD.ValueRW;
		valueRW.secondaryUse = componentData;
		bool flag = true;
		if (EquipmentSlot.GetManaCost(equipmentUpdateAspect.entity, equipmentPrefab, equipmentUpdateAspect.equippedObjectCD.ValueRO, equipmentUpdateAspect.equipmentSlotCD.ValueRO, equipmentUpdateLookupData.consumeManaLookup, equipmentUpdateLookupData.levelEntitiesLookup, equipmentUpdateLookupData.levelLookup, equipmentUpdateLookupData.objectPropertiesLookup, equipmentUpdateLookupData.summarizedConditionsBufferLookup, checkingCostForSecondary: true) > equipmentUpdateAspect.manaCD.ValueRO.mana)
		{
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
					value1 = 33
				}
			};
			ghostEffectEventBuffer.AddToRingBuffer(ref valueRW2, in item);
			flag = false;
		}
		if (flag && valueRW.secondaryUse.summonsMinion)
		{
			valueRW.summonMinion = true;
			equipmentUpdateLookupData.attackWithEquipmentLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
			return true;
		}
		return false;
	}

	public static void AttackWithItem(in ClientInput clientInput, in AttackWithEquipmentAspect attackWithEquipmentAspect, AttackWithEquipmentShared attackWithEquipmentShared, AttackWithEquipmentLookup attackWithEquipmentLookup)
	{
		EquipmentSlotCD valueRO = attackWithEquipmentAspect.equipmentSlotCD.ValueRO;
		if (!valueRO.secondaryUse.hasSecondaryUse || !valueRO.summonMinion)
		{
			EquipmentSlot.AttackWithItem(in attackWithEquipmentAspect, attackWithEquipmentShared, attackWithEquipmentLookup);
			return;
		}
		Entity equipmentPrefab = attackWithEquipmentAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		EquipmentSlot.ConsumeAnyRequiredMana(attackWithEquipmentLookup, attackWithEquipmentAspect);
		float cooldownTime = 0.6f;
		if (attackWithEquipmentLookup.cooldownLookup.TryGetComponent(equipmentPrefab, out var componentData))
		{
			cooldownTime = componentData.cooldown;
		}
		EquipmentSlot.StartCooldownForItem(in attackWithEquipmentAspect.equippedObjectCD.ValueRO, ref attackWithEquipmentAspect.attackCooldownTimerCD.ValueRW, attackWithEquipmentAspect.syncedSharedCooldownTimersCD, attackWithEquipmentShared.currentTick, attackWithEquipmentShared.tickRate, in attackWithEquipmentShared.databaseBank, attackWithEquipmentLookup.cooldownLookup, cooldownTime);
		attackWithEquipmentAspect.animationOrientationCD.ValueRW.facingDirection = Direction.FromVector(clientInput.aimDirection, 0f);
		attackWithEquipmentLookup.queueHitLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: true);
		ObjectDataCD objectDataCD = attackWithEquipmentAspect.equippedObjectCD.ValueRO.containedObject.objectData;
		if (attackWithEquipmentShared.isFirstTimeFullyPredictingTick)
		{
			float3 position = attackWithEquipmentAspect.localTransform.ValueRO.Position + clientInput.aimDirection.ToFloat3();
			if (attackWithEquipmentLookup.commandMinionWeaponLookup.HasComponent(attackWithEquipmentAspect.equippedObjectCD.ValueRO.equipmentPrefab))
			{
				position = RangeWeaponSlot.CalculateAimMarkerTargetPosition(in attackWithEquipmentAspect.localTransform.ValueRO.Position, in clientInput, 12f, in attackWithEquipmentShared.collisionWorld, attackWithEquipmentAspect.placementIndicatorCD.ValueRO.relativePlayerPosition, in attackWithEquipmentShared.tileAccessor, raycastToTarget: true, attackWithEquipmentLookup.doorLookup, attackWithEquipmentLookup.affectObjectWhenMelodyPlayedLookup);
			}
			MinionHandlerSystem.SpawnMinion(attackWithEquipmentAspect.entity, in attackWithEquipmentAspect.equippedObjectCD.ValueRO, position, attackWithEquipmentLookup.levelLookup, attackWithEquipmentLookup.secondaryUseLookup, in attackWithEquipmentShared.databaseBank.databaseBankBlob, attackWithEquipmentShared.ecb, attackWithEquipmentLookup.healthLookup, attackWithEquipmentLookup.randomLookup);
		}
		ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, attackWithEquipmentShared.databaseBank.databaseBankBlob, objectDataCD.variation);
		if (attackWithEquipmentLookup.durabilityLookup.HasComponent(equipmentPrefab))
		{
			attackWithEquipmentLookup.reduceDurabilityOfEquippedLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: true);
			attackWithEquipmentLookup.reduceDurabilityOfEquippedLookup.GetRefRW(attackWithEquipmentAspect.entity).ValueRW.triggerCounter++;
		}
		else if (entityObjectInfo.rarity != Rarity.Legendary)
		{
			attackWithEquipmentLookup.inventoryChangeBufferLookup[attackWithEquipmentShared.inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
			{
				inventoryChangeData = Create.ConsumeEntityAt(attackWithEquipmentAspect.entity, attackWithEquipmentAspect.equippedObjectCD.ValueRO.equippedSlotIndex, 1, destroy: true, attackWithEquipmentLookup.godModeLookup.IsComponentEnabled(attackWithEquipmentAspect.entity)),
				playerEntity = attackWithEquipmentAspect.entity
			});
		}
	}

	public static bool UpdateEquipmentCommandMinion(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData, bool hasItemInMouse)
	{
		bool flag = clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_Pressed);
		if (hasItemInMouse || !interactHeld)
		{
			return false;
		}
		if (flag)
		{
			equipmentUpdateLookupData.triggerSelectNewEnemyToAttackCommandLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
		}
		return true;
	}
}
