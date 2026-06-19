using Inventory;
using PlacementIndicator;
using PlayerEquipment;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

public class RangeWeaponSlot : EquipmentSlot
{
	protected override EquipmentSlotType slotType => EquipmentSlotType.RangeWeaponSlot;

	public static void AttackWithItem(in ClientInput clientInput, in AttackWithEquipmentAspect attackWithEquipmentAspect, AttackWithEquipmentShared attackWithEquipmentShared, AttackWithEquipmentLookup attackWithEquipmentLookup)
	{
		Entity equipmentPrefab = attackWithEquipmentAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		if (attackWithEquipmentLookup.rangedWeaponLookup.TryGetComponent(equipmentPrefab, out var componentData) && componentData.projectileID != ObjectID.None)
		{
			EquipmentSlot.ConsumeAnyRequiredMana(attackWithEquipmentLookup, attackWithEquipmentAspect);
			float num = 0.6f;
			if (attackWithEquipmentLookup.cooldownLookup.TryGetComponent(equipmentPrefab, out var componentData2))
			{
				num = componentData2.cooldown;
			}
			DynamicBuffer<SummarizedConditionEffectsBuffer> dynamicBuffer = attackWithEquipmentLookup.summarizedConditionEffectBuffer[attackWithEquipmentAspect.entity];
			int value = dynamicBuffer[41].value;
			int value2 = dynamicBuffer[65].value;
			float num2 = math.max(1f + (float)value / 1000f + (float)value2 / 1000f, 0.1f);
			num /= num2;
			EquipmentSlot.StartCooldownForItem(in attackWithEquipmentAspect.equippedObjectCD.ValueRO, ref attackWithEquipmentAspect.attackCooldownTimerCD.ValueRW, attackWithEquipmentAspect.syncedSharedCooldownTimersCD, attackWithEquipmentShared.currentTick, attackWithEquipmentShared.tickRate, in attackWithEquipmentShared.databaseBank, attackWithEquipmentLookup.cooldownLookup, num);
			attackWithEquipmentAspect.animationOrientationCD.ValueRW.facingDirection = Direction.FromVector(clientInput.aimDirection, 0f);
			attackWithEquipmentLookup.queueHitLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: true);
			attackWithEquipmentLookup.rangedWeaponSpawnProjectileTriggerTagLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: true);
			ObjectDataCD objectDataCD = attackWithEquipmentAspect.equippedObjectCD.ValueRO.containedObject.objectData;
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, attackWithEquipmentShared.databaseBank.databaseBankBlob, objectDataCD.variation);
			if (attackWithEquipmentLookup.durabilityLookup.HasComponent(equipmentPrefab))
			{
				attackWithEquipmentLookup.reduceDurabilityOfEquippedLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: true);
				attackWithEquipmentLookup.reduceDurabilityOfEquippedLookup.GetRefRW(attackWithEquipmentAspect.entity).ValueRW.triggerCounter++;
			}
			else if (entityObjectInfo.rarity != Rarity.Legendary && attackWithEquipmentLookup.randomLookup.GetRefRW(attackWithEquipmentAspect.entity).ValueRW.Value.NextFloat() > (float)EntityUtility.GetConditionValue(ConditionID.ChanceToNotConsumeExplosives, attackWithEquipmentAspect.entity, attackWithEquipmentLookup.summarizedConditionsBuffer) / 100f)
			{
				attackWithEquipmentLookup.inventoryChangeBufferLookup[attackWithEquipmentShared.inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
				{
					inventoryChangeData = Create.ConsumeEntityAt(attackWithEquipmentAspect.entity, attackWithEquipmentAspect.equippedObjectCD.ValueRO.equippedSlotIndex, 1, destroy: true, attackWithEquipmentLookup.godModeLookup.IsComponentEnabled(attackWithEquipmentAspect.entity)),
					playerEntity = attackWithEquipmentAspect.entity
				});
			}
		}
	}

	public static void SpawnProjectiles(Entity owner, in SpawnProjectilesHelpData spawnProjectilesHelpData, int totalShots, in RangeWeaponCD weapon, in ClientInput clientInput, Entity equipmentPrefab, in ObjectDataCD objectData, int damage, in EquipmentSlotCD equipmentSlotCD, ref RandomCD randomCD, in LocalTransform localTransform, in GhostOwner ghostOwner, in PlacementIndicatorCD placementIndicatorCD)
	{
		Entity entity = default(Entity);
		if (!spawnProjectilesHelpData.isFirstTimeFullyPredictingTick)
		{
			if (weapon.spawnRandomProjectile)
			{
				randomCD.Value.NextInt();
			}
			if (spawnProjectilesHelpData.mortarProjectileLookup.HasComponent(entity))
			{
				for (int i = 0; i < totalShots; i++)
				{
					randomCD.Value.NextFloat2Direction();
					randomCD.Value.NextFloat();
					PugRandom.InheritRngFromEntity(ref randomCD.Value);
				}
			}
			else
			{
				for (int j = 0; j < totalShots; j++)
				{
					PugRandom.InheritRngFromEntity(ref randomCD.Value);
				}
			}
			return;
		}
		bool flag = equipmentSlotCD.secondaryUse.hasSecondaryUse && equipmentSlotCD.currentWindupTier > 0;
		if (!weapon.spawnRandomProjectile)
		{
			ObjectID objectID = weapon.projectileID;
			if (flag && weapon.windupProjectileID != ObjectID.None)
			{
				objectID = weapon.windupProjectileID;
			}
			ObjectDataCD objectDataCD = new ObjectDataCD
			{
				objectID = objectID
			};
			entity = PugDatabase.GetPrimaryPrefabEntity(objectDataCD.objectID, spawnProjectilesHelpData.databaseBankCD.databaseBankBlob, objectDataCD.variation);
		}
		else
		{
			int index = randomCD.Value.NextInt(0, weapon.randomProjectiles.Length);
			ObjectID objectID2 = weapon.randomProjectiles[index];
			ObjectDataCD objectDataCD = new ObjectDataCD
			{
				objectID = objectID2
			};
			entity = PugDatabase.GetPrimaryPrefabEntity(objectDataCD.objectID, spawnProjectilesHelpData.databaseBankCD.databaseBankBlob, objectDataCD.variation);
		}
		bool flag2 = false;
		if (spawnProjectilesHelpData.durabilityLookup.TryGetComponent(equipmentPrefab, out var componentData))
		{
			flag2 = componentData.IsReinforced(objectData.amount);
		}
		bool shotFromReinforcedWeapon = flag2;
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
		if (spawnProjectilesHelpData.mortarProjectileLookup.HasComponent(entity))
		{
			float3 castPosition = localTransform.Position;
			float3 float5 = CalculateAimMarkerTargetPosition(in castPosition, in clientInput, weapon.mortarTargetRange, in spawnProjectilesHelpData.collisionWorld, placementIndicatorCD.relativePlayerPosition, in spawnProjectilesHelpData.tileAccessor, weapon.mortarRaycastToTarget, spawnProjectilesHelpData.doorLookup, spawnProjectilesHelpData.affectObjectWhenMelodyPlayedLookup);
			float3 float6 = math.normalizesafe(float5 - castPosition);
			bool flag3 = (flag ? weapon.secondaryScaleMortarTimeWithDistance : weapon.scaleMortarTimeWithDistance);
			float minMortarAirTimePercentage = weapon.minMortarAirTimePercentage;
			float2 float7 = (flag ? weapon.secondaryMinMaxRandomSpreadDistance : weapon.minMaxRandomSpreadDistance);
			for (int k = 0; k < totalShots; k++)
			{
				float3 float8 = ((flag && totalShots != 1) ? (castPosition + (float)(k + 1) * weapon.secondaryDistanceBetweenHits * float6) : float5);
				float2 float9 = randomCD.Value.NextFloat2Direction();
				float num = randomCD.Value.NextFloat(float7.x, float7.y);
				float8 += math.normalizesafe(new float3(float9.x, 0f, float9.y)) * num;
				float mortarAirTimePercentage = 1f;
				if (flag3)
				{
					mortarAirTimePercentage = math.length(float8 - castPosition) / weapon.mortarTargetRange;
					mortarAirTimePercentage = math.max(mortarAirTimePercentage, minMortarAirTimePercentage);
				}
				SpawnMortar(entity, castPosition, float8, damage, in equipmentSlotCD, spawnProjectilesHelpData, owner, ref randomCD, weaponLevel, mortarAirTimePercentage, shotFromReinforcedWeapon);
			}
		}
		else
		{
			for (int l = 0; l < totalShots; l++)
			{
				float y = weapon.spreadAngle * (float)l - weapon.spreadAngle * (float)(totalShots - 1) / 2f;
				float3 float10 = Quaternion.Euler(0f, y, 0f) * clientInput.aimDirection.ToFloat3();
				float3 float11 = weapon.spawnOffsetDistance * float10;
				float3 projectileSpawnPos = localTransform.Position + float11;
				SpawnProjectile(entity, projectileSpawnPos, float10, weaponLevel, shotFromReinforcedWeapon, isMagic, spawnProjectilesHelpData, weapon.pierceAtMaxWindup, weapon.bounceAtMaxWindup, damage, equipmentSlotCD, weapon.explosionUseWeaponDamage, owner, ref randomCD, ghostOwner);
			}
		}
	}

	public static float3 CalculateAimMarkerTargetPosition(in float3 castPosition, in ClientInput clientInput, float weaponTargetRange, in CollisionWorld collisionWorld, float2 placementIndicatorRelativePosition, in TileAccessor tileAccessor, bool raycastToTarget, ComponentLookup<DoorCD> doorLookup, ComponentLookup<AffectObjectWhenMelodyPlayedCD> affectObjectWhenMelodyPlayedLookup, bool mouseConfined = true)
	{
		float3 float5;
		float num;
		if (clientInput.prefersKeyboardAndMouse)
		{
			float3 x = clientInput.mouseOrJoystickWorldPoint.ToFloat3() - castPosition;
			float5 = math.normalizesafe(x);
			num = ((!mouseConfined) ? math.length(x) : math.min(weaponTargetRange, math.length(x)));
		}
		else
		{
			float3 x2 = castPosition + placementIndicatorRelativePosition.ToFloat3() - castPosition;
			float5 = math.normalizesafe(x2);
			num = math.min(weaponTargetRange, math.length(x2));
		}
		if (!raycastToTarget)
		{
			return castPosition + float5 * num;
		}
		if (math.lengthsq(float5) > 1.1920929E-07f && SinglePugMap.RaycastWalls(castPosition.xz, float5.xz, num, out var hitInfo, tileAccessor))
		{
			num = hitInfo.distance;
		}
		float radius = 0.1f;
		float num2 = num;
		NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(10, Allocator.Temp);
		CollisionFilter filter = new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 1u
		};
		if (collisionWorld.SphereCastAll(castPosition, radius, float5, num2, ref outHits, filter))
		{
			for (int i = 0; i < outHits.Length; i++)
			{
				if (doorLookup.HasComponent(outHits[i].Entity) || affectObjectWhenMelodyPlayedLookup.HasComponent(outHits[i].Entity))
				{
					float num3 = outHits[i].Fraction * num2;
					if (num3 < num)
					{
						num = num3;
					}
				}
			}
		}
		outHits.Dispose();
		return castPosition + float5 * num;
	}

	private static void SpawnMortar(Entity projectilePrefabEntity, float3 castPosition, float3 targetPosition, int damage, in EquipmentSlotCD equipmentSlotCD, SpawnProjectilesHelpData spawnProjectilesHelpData, Entity owner, ref RandomCD randomCD, int weaponLevel, float mortarAirTimePercentage, bool shotFromReinforcedWeapon)
	{
		EntityCommandBuffer ecb = spawnProjectilesHelpData.ecb;
		MortarProjectileCD component = spawnProjectilesHelpData.mortarProjectileLookup[projectilePrefabEntity];
		float3 position = ((component.goUpTime == 0f) ? targetPosition : castPosition);
		Entity entity = ecb.Instantiate(projectilePrefabEntity);
		ecb.SetComponent(entity, LocalTransform.FromPosition(position));
		component.targetPosition = targetPosition;
		component.airTime *= mortarAirTimePercentage;
		component.totalAirTime = component.goUpTime + component.airTime + component.goDownTime;
		ecb.SetComponent(entity, component);
		ecb.SetComponent(entity, new OwnerReferenceCD
		{
			owner = owner
		});
		sbyte b = -1;
		if (spawnProjectilesHelpData.objectPropertiesLookup.TryGetComponent(projectilePrefabEntity, out var componentData) && componentData.TryGet<ConditionID>(1743293565, out var value))
		{
			b = (sbyte)EntityUtility.GetConditionValue(value, owner, spawnProjectilesHelpData.summarizedConditionsBuffer);
			if (b != 0)
			{
				DynamicBuffer<ConditionsBuffer> conditionsBuffer = spawnProjectilesHelpData.conditionsBufferLookup[owner];
				EntityUtility.RemoveCondition(ConditionID.SequenceExplosionTotalMaxExplosions, conditionsBuffer);
			}
		}
		ecb.SetComponent(entity, new ProjectileSourceCD
		{
			shotFromReinforcedWeapon = shotFromReinforcedWeapon,
			weaponLevel = weaponLevel,
			sequenceExplosionTotalExplosions = b
		});
		if (spawnProjectilesHelpData.mortarProjectileDamageEffectLookup.TryGetComponent(projectilePrefabEntity, out var componentData2))
		{
			componentData2.damage = damage;
			componentData2.tileDamage = damage;
			ecb.SetComponent(entity, componentData2);
		}
		EntityUtility.InheritAttackData(ecb, owner, entity, spawnProjectilesHelpData.conditionsTableCD, spawnProjectilesHelpData.behaviourTagsLookup, spawnProjectilesHelpData.summarizedConditionsBuffer);
		if (spawnProjectilesHelpData.factionLookup.HasComponent(projectilePrefabEntity))
		{
			EntityUtility.InheritFaction(ecb, owner, entity, spawnProjectilesHelpData.factionLookup);
		}
		ecb.SetComponent(entity, new RandomCD
		{
			Value = PugRandom.InheritRngFromEntity(ref randomCD.Value)
		});
	}

	public static void SpawnProjectile(Entity projectilePrefabEntity, float3 projectileSpawnPos, float3 direction, int weaponLevel, bool shotFromReinforcedWeapon, bool isMagic, SpawnProjectilesHelpData spawnProjectilesHelpData, bool pierceAtMaxWindup, bool bounceAtMaxWindup, int damage, EquipmentSlotCD equipmentSlotCD, bool explosionUseWeaponDamage, Entity owner, ref RandomCD randomCD, GhostOwner ghostOwner)
	{
		EntityCommandBuffer ecb = spawnProjectilesHelpData.ecb;
		Entity entity = ecb.Instantiate(projectilePrefabEntity);
		ecb.SetComponent(entity, LocalTransform.FromPosition(projectileSpawnPos));
		float num = 1f;
		if (equipmentSlotCD.secondaryUse.projectileSpeedMultiplier > 1f)
		{
			MovementSpeedCD component = default(MovementSpeedCD);
			if (spawnProjectilesHelpData.movementSpeedLookup.HasComponent(projectilePrefabEntity))
			{
				component = spawnProjectilesHelpData.movementSpeedLookup[projectilePrefabEntity];
			}
			float originalSpeed = component.originalSpeed;
			float projectileSpeedMultiplier = equipmentSlotCD.secondaryUse.projectileSpeedMultiplier;
			num = math.lerp(1f, projectileSpeedMultiplier, equipmentSlotCD.currentWindup);
			float originalSpeed2 = originalSpeed * num;
			component.originalSpeed = originalSpeed2;
			ecb.SetComponent(entity, component);
		}
		ecb.SetComponent(entity, new ProjectileSetupCD
		{
			damage = damage,
			directionRadians = math.atan2(direction.z, direction.x),
			isMagic = isMagic
		});
		ecb.SetComponent(entity, new ProjectileSourceCD
		{
			shotFromReinforcedWeapon = shotFromReinforcedWeapon,
			weaponLevel = weaponLevel,
			sequenceExplosionTotalExplosions = -1
		});
		spawnProjectilesHelpData.piercingProjectileLookup.TryGetComponent(projectilePrefabEntity, out var componentData);
		if (pierceAtMaxWindup && equipmentSlotCD.atMaxWindup)
		{
			componentData.piercesEnemiesAmount = int.MaxValue;
		}
		if (componentData.piercesEnemiesAmount != int.MaxValue)
		{
			componentData.piercesEnemiesAmount += EntityUtility.GetConditionValue(ConditionID.PiercingProjectiles, owner, spawnProjectilesHelpData.summarizedConditionsBuffer);
		}
		if (componentData.piercesEnemiesAmount != 0)
		{
			ecb.SetComponent(entity, componentData);
		}
		if (bounceAtMaxWindup && equipmentSlotCD.atMaxWindup)
		{
			spawnProjectilesHelpData.bouncingProjectileLookup.TryGetComponent(projectilePrefabEntity, out var componentData2);
			componentData2.maxBounceCount = 10;
			ecb.SetComponent(entity, componentData2);
		}
		ecb.SetComponent(entity, ghostOwner);
		ecb.SetComponent(entity, new OwnerReferenceCD
		{
			owner = owner
		});
		ecb.SetComponent(entity, new RandomCD
		{
			Value = PugRandom.InheritRngFromEntity(ref randomCD.Value)
		});
		EntityUtility.InheritAttackData(ecb, owner, entity, spawnProjectilesHelpData.conditionsTableCD, spawnProjectilesHelpData.behaviourTagsLookup, spawnProjectilesHelpData.summarizedConditionsBuffer);
		if (spawnProjectilesHelpData.factionLookup.HasComponent(projectilePrefabEntity))
		{
			EntityUtility.InheritFaction(ecb, owner, entity, spawnProjectilesHelpData.factionLookup);
		}
		if (explosionUseWeaponDamage && spawnProjectilesHelpData.isExplosiveLookup.TryGetComponent(projectilePrefabEntity, out var componentData3))
		{
			componentData3.damage = (int)math.round((float)damage * 0.5f);
			componentData3.tileDamage = damage;
			ecb.SetComponent(entity, componentData3);
		}
	}
}
