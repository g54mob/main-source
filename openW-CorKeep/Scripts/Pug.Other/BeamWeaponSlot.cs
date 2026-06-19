using PlayerEquipment;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;

public class BeamWeaponSlot : EquipmentSlot
{
	protected override EquipmentSlotType slotType => EquipmentSlotType.BeamWeaponSlot;

	public static void AttackWithItem(in ClientInput clientInput, in AttackWithEquipmentAspect attackWithEquipmentAspect, AttackWithEquipmentShared attackWithEquipmentShared, AttackWithEquipmentLookup attackWithEquipmentLookup)
	{
		EquipmentSlot.ConsumeAnyRequiredMana(attackWithEquipmentLookup, attackWithEquipmentAspect, attackWithEquipmentAspect.equipmentSlotCD.ValueRO.currentWindup > 0f);
		float num = CalculateCooldown(in attackWithEquipmentAspect, in attackWithEquipmentShared, in attackWithEquipmentLookup);
		EquipmentSlot.StartCooldownForItem(in attackWithEquipmentAspect.equippedObjectCD.ValueRO, ref attackWithEquipmentAspect.attackCooldownTimerCD.ValueRW, attackWithEquipmentAspect.syncedSharedCooldownTimersCD, attackWithEquipmentShared.currentTick, attackWithEquipmentShared.tickRate, in attackWithEquipmentShared.databaseBank, attackWithEquipmentLookup.cooldownLookup, num);
		int conditionValue = EntityUtility.GetConditionValue(ConditionID.IncreaseManaCostAndMagicDamagePercentagePerSecond, attackWithEquipmentAspect.entity, attackWithEquipmentLookup.summarizedConditionsBuffer);
		if (conditionValue > 0 && attackWithEquipmentAspect.equipmentSlotCD.ValueRO.currentWindup <= 0f)
		{
			attackWithEquipmentAspect.attackCooldownTimerCD.ValueRO.cooldown.GetRemainingSeconds(in attackWithEquipmentShared.currentTick, attackWithEquipmentShared.tickRate);
			attackWithEquipmentAspect.newConditionsBuffer.Add(new NewConditionsBuffer
			{
				conditionData = new ConditionData
				{
					conditionID = ConditionID.IncreaseManaCostAndMagicDamagePercentage,
					duration = 2.5f,
					value = conditionValue
				}
			});
		}
		attackWithEquipmentLookup.queueHitLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: true);
		if (attackWithEquipmentAspect.equipmentSlotCD.ValueRO.currentWindup > 0f)
		{
			attackWithEquipmentLookup.beamWeaponSpawnProjectileTriggerTagLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: true);
			return;
		}
		uint num2 = NetworkTimeUtilities.SecondsToTicks(num, attackWithEquipmentShared.tickRate);
		num2++;
		attackWithEquipmentAspect.beamWeaponAttackCD.ValueRW.beamWeaponActiveTimer.Start(attackWithEquipmentShared.currentTick, num2);
	}

	private static float CalculateCooldown(in AttackWithEquipmentAspect attackWithEquipmentAspect, in AttackWithEquipmentShared attackWithEquipmentShared, in AttackWithEquipmentLookup attackWithEquipmentLookup)
	{
		float num = 0.4f;
		if (attackWithEquipmentLookup.cooldownLookup.TryGetComponent(attackWithEquipmentAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData))
		{
			num = componentData.cooldown;
		}
		DynamicBuffer<SummarizedConditionEffectsBuffer> dynamicBuffer = attackWithEquipmentLookup.summarizedConditionEffectBuffer[attackWithEquipmentAspect.entity];
		attackWithEquipmentLookup.hasWeaponDamageLookup.TryGetComponent(attackWithEquipmentAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData2);
		ConditionEffect index = ((!componentData2.isRange) ? ConditionEffect.MeleeAttackSpeed : ConditionEffect.RangeAttackSpeed);
		int value = dynamicBuffer[(int)index].value;
		int value2 = dynamicBuffer[65].value;
		float num2 = math.max(1f + (float)value / 1000f + (float)value2 / 1000f, 0.1f);
		return num / num2;
	}

	public static void SpawnProjectiles(Entity owner, in SpawnProjectilesHelpData spawnProjectilesHelpData, int totalShots, in BeamWeaponCD weapon, in ClientInput clientInput, Entity equipmentPrefab, in ObjectDataCD objectData, int damage, in EquipmentSlotCD equipmentSlotCD, ref RandomCD randomCD, in LocalTransform localTransform, in GhostOwner ghostOwner)
	{
		if (!spawnProjectilesHelpData.isFirstTimeFullyPredictingTick)
		{
			for (int i = 0; i < totalShots; i++)
			{
				PugRandom.InheritRngFromEntity(ref randomCD.Value);
			}
			return;
		}
		ObjectID windupProjectileID = weapon.windupProjectileID;
		ObjectDataCD objectDataCD = new ObjectDataCD
		{
			objectID = windupProjectileID
		};
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectDataCD.objectID, spawnProjectilesHelpData.databaseBankCD.databaseBankBlob, objectDataCD.variation);
		bool flag = false;
		if (spawnProjectilesHelpData.durabilityLookup.TryGetComponent(equipmentPrefab, out var componentData))
		{
			flag = componentData.IsReinforced(objectData.amount);
		}
		bool shotFromReinforcedWeapon = flag;
		int weaponLevel;
		if (objectData.variation > 0)
		{
			weaponLevel = objectData.variation;
		}
		else
		{
			spawnProjectilesHelpData.levelLookup.TryGetComponent(equipmentPrefab, out var componentData2);
			weaponLevel = componentData2.level;
		}
		bool isMagic = spawnProjectilesHelpData.hasWeaponDamageLookup.HasComponent(equipmentPrefab) && spawnProjectilesHelpData.hasWeaponDamageLookup[equipmentPrefab].isMagic;
		for (int j = 0; j < totalShots; j++)
		{
			float y = (float)(weapon.spreadAngle * j) - (float)(weapon.spreadAngle * (totalShots - 1)) / 2f;
			float3 float5 = Quaternion.Euler(0f, y, 0f) * clientInput.aimDirection.ToFloat3();
			float3 float6 = weapon.spawnOffsetDistance * float5;
			float3 projectileSpawnPos = localTransform.Position + float6;
			RangeWeaponSlot.SpawnProjectile(primaryPrefabEntity, projectileSpawnPos, float5, weaponLevel, shotFromReinforcedWeapon, isMagic, spawnProjectilesHelpData, pierceAtMaxWindup: false, bounceAtMaxWindup: false, damage, equipmentSlotCD, explosionUseWeaponDamage: false, owner, ref randomCD, ghostOwner);
		}
	}
}
