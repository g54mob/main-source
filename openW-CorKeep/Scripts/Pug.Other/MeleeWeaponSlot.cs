using PlayerEquipment;
using Unity.Entities;
using Unity.Mathematics;

public class MeleeWeaponSlot : EquipmentSlot
{
	protected override EquipmentSlotType slotType => EquipmentSlotType.MeleeWeaponSlot;

	public static void AttackWithItem(in ClientInput clientInput, in AttackWithEquipmentAspect attackWithEquipmentAspect, AttackWithEquipmentShared attackWithEquipmentShared, AttackWithEquipmentLookup attackWithEquipmentLookup)
	{
		EquipmentSlot.ConsumeAnyRequiredMana(attackWithEquipmentLookup, attackWithEquipmentAspect);
		float cooldownTime = CalculateCooldown(in attackWithEquipmentAspect, in attackWithEquipmentShared, in attackWithEquipmentLookup);
		EquipmentSlot.StartCooldownForItem(in attackWithEquipmentAspect.equippedObjectCD.ValueRO, ref attackWithEquipmentAspect.attackCooldownTimerCD.ValueRW, attackWithEquipmentAspect.syncedSharedCooldownTimersCD, attackWithEquipmentShared.currentTick, attackWithEquipmentShared.tickRate, in attackWithEquipmentShared.databaseBank, attackWithEquipmentLookup.cooldownLookup, cooldownTime);
		MeleeAttackFX(in attackWithEquipmentAspect, in attackWithEquipmentShared, attackWithEquipmentLookup);
		attackWithEquipmentLookup.queueHitLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: true);
	}

	public static void MeleeAttackFX(in AttackWithEquipmentAspect attackWithEquipmentAspect, in AttackWithEquipmentShared attackWithEquipmentShared, AttackWithEquipmentLookup attackWithEquipmentLookup)
	{
		float currentWindupMultiplier = attackWithEquipmentAspect.equipmentSlotCD.ValueRO.currentWindupMultiplier;
		if (!(currentWindupMultiplier < 1.2f))
		{
			Entity equipmentPrefab = attackWithEquipmentAspect.equippedObjectCD.ValueRO.equipmentPrefab;
			bool isBroken = attackWithEquipmentAspect.equippedObjectCD.ValueRO.isBroken;
			float3 centerOfHitCollider = EquipmentSlot.GetCenterOfHitCollider(equipmentPrefab, in attackWithEquipmentAspect.equipmentSlotCD.ValueRO, in attackWithEquipmentAspect.animationOrientationCD.ValueRO, in attackWithEquipmentLookup.meleeWeaponLookup, isBroken, currentWindupMultiplier);
			float3 sizeOfHitCollider = EquipmentSlot.GetSizeOfHitCollider(equipmentPrefab, in attackWithEquipmentAspect.equipmentSlotCD.ValueRO, in attackWithEquipmentAspect.animationOrientationCD.ValueRO, in attackWithEquipmentLookup.meleeWeaponLookup, isBroken, currentWindupMultiplier);
			float x = math.max(sizeOfHitCollider.x, sizeOfHitCollider.z);
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = attackWithEquipmentAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW = ref attackWithEquipmentAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = attackWithEquipmentShared.currentTick,
				value = new EffectEventCD
				{
					entity = attackWithEquipmentAspect.entity,
					effectID = EffectID.AttackFX,
					value1 = (int)attackWithEquipmentAspect.equippedObjectCD.ValueRO.containedObject.objectID,
					position1 = centerOfHitCollider,
					value2 = (int)attackWithEquipmentAspect.animationOrientationCD.ValueRO.facingDirection.id,
					vector1 = new float3(x, 0f, 0f)
				}
			};
			ghostEffectEventBuffer.AddToRingBuffer(ref valueRW, in item);
		}
	}

	public static float CalculateCooldown(in AttackWithEquipmentAspect attackWithEquipmentAspect, in AttackWithEquipmentShared attackWithEquipmentShared, in AttackWithEquipmentLookup attackWithEquipmentLookup)
	{
		float num = 0.4f;
		if (attackWithEquipmentLookup.cooldownLookup.TryGetComponent(attackWithEquipmentAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData))
		{
			num = componentData.cooldown;
		}
		EquippedObjectCD valueRO = attackWithEquipmentAspect.equippedObjectCD.ValueRO;
		ObjectType objectType = PugDatabase.GetEntityObjectInfo(valueRO.containedObject.objectID, attackWithEquipmentShared.databaseBank.databaseBankBlob, valueRO.containedObject.objectData.variation).objectType;
		DynamicBuffer<SummarizedConditionEffectsBuffer> dynamicBuffer = attackWithEquipmentLookup.summarizedConditionEffectBuffer[attackWithEquipmentAspect.entity];
		if (objectType == ObjectType.MiningPick || objectType == ObjectType.Sledge || objectType == ObjectType.DrillTool)
		{
			int value = dynamicBuffer[39].value;
			float num2 = math.max(1f + (float)value / 1000f, 0.1f);
			return num / num2;
		}
		int value2 = dynamicBuffer[40].value;
		int value3 = dynamicBuffer[65].value;
		float num3 = math.max(1f + (float)value2 / 1000f + (float)value3 / 1000f, 0.1f);
		return num / num3;
	}
}
