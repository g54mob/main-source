using PlayerEquipment;
using Pug.Properties;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.NetCode.LowLevel.Unsafe;
using Unity.Physics;
using Unity.Physics.Authoring;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class EquipmentSlot : PoolableSimple
{
	[HideInInspector]
	public int inventoryIndexReference;

	[FormerlySerializedAs("weaponWindup")]
	public SecondaryUseCD weaponSecondaryUse;

	public PhysicsCategoryTags collidesWith;

	private const float baseHitColliderSize = 1f;

	public const float HIT_COOLDOWN = 0.4f;

	private const uint hitCollidesWith = 135007u;

	private const uint hitCollidesWithNonPvP = 135005u;

	public PlayerController slotOwner { get; private set; }

	public float windupMoveSpeedMultiplier { get; private set; } = 0.5f;

	public ContainedObjectsBuffer containedObject
	{
		get
		{
			if (inventoryIndexReference < 0 || !(slotOwner != null))
			{
				return default(ContainedObjectsBuffer);
			}
			return slotOwner.GetInventorySlot(inventoryIndexReference);
		}
	}

	public ObjectDataCD objectData => containedObject.objectData;

	protected virtual EquipmentSlotType slotType => EquipmentSlotType.NonUsableSlot;

	public EquipmentSlotType GetSlotType()
	{
		return slotType;
	}

	public static bool UpdateEquipment(bool interactHeld, bool secondInteractHeld, in ClientInput clientInput, in EquipmentUpdateAspect equipmentUpdateAspect, in EquipmentUpdateSharedData equipmentUpdateSharedData, in LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		Entity equipmentPrefab = equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab;
		equipmentUpdateLookupData.secondaryUseLookup.TryGetComponent(equipmentPrefab, out var componentData);
		equipmentUpdateLookupData.warmupLookup.TryGetComponent(equipmentPrefab, out var componentData2);
		ref EquipmentSlotCD valueRW = ref equipmentUpdateAspect.equipmentSlotCD.ValueRW;
		valueRW.secondaryUse = componentData;
		valueRW.warmupCD = componentData2;
		bool flag = true;
		bool checkingCostForSecondary = secondInteractHeld && !interactHeld;
		int manaCost = GetManaCost(equipmentUpdateAspect.entity, equipmentPrefab, equipmentUpdateAspect.equippedObjectCD.ValueRO, equipmentUpdateAspect.equipmentSlotCD.ValueRO, equipmentUpdateLookupData.consumeManaLookup, equipmentUpdateLookupData.levelEntitiesLookup, equipmentUpdateLookupData.levelLookup, equipmentUpdateLookupData.objectPropertiesLookup, equipmentUpdateLookupData.summarizedConditionsBufferLookup, checkingCostForSecondary);
		bool isBroken = equipmentUpdateAspect.equippedObjectCD.ValueRO.isBroken;
		if (manaCost > equipmentUpdateAspect.manaCD.ValueRO.mana)
		{
			if (interactHeld || secondInteractHeld)
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
			}
			flag = false;
		}
		bool result = false;
		if (flag && interactHeld)
		{
			result = true;
			if (!isBroken && valueRW.warmupCD.warmupTime > 0f && !valueRW.warmupTimer.isRunning)
			{
				valueRW.warmupTimer.Start(equipmentUpdateSharedData.currentTick, valueRW.warmupCD.warmupTime, equipmentUpdateSharedData.tickRate);
			}
			else if (!valueRW.warmupTimer.isRunning || valueRW.warmupTimer.IsTimerElapsed(equipmentUpdateSharedData.currentTick))
			{
				equipmentUpdateLookupData.attackWithEquipmentLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
			}
		}
		else if (!isBroken && flag && valueRW.secondaryUse.hasSecondaryUse && valueRW.secondaryUse.hasWindup && valueRW.secondaryUse.windupTiers > 0)
		{
			if (secondInteractHeld || valueRW.windupTimer.isRunning)
			{
				result = true;
				if (!valueRW.windupTimer.isRunning)
				{
					valueRW.windupTimer.Start(equipmentUpdateSharedData.currentTick, valueRW.secondaryUse.windupTime, equipmentUpdateSharedData.tickRate);
				}
				Windup(ref valueRW, equipmentUpdateSharedData);
			}
			if (!secondInteractHeld && valueRW.windupTimer.isRunning)
			{
				equipmentUpdateLookupData.attackWithEquipmentLookup.SetComponentEnabled(equipmentUpdateAspect.entity, value: true);
			}
		}
		return result;
	}

	public static void LateUpdateEquipment(in ClientInput clientInput, in EquipmentLateUpdateAspect equipmentUpdateAspect, in LookupEquipmentLateUpdateData lookupData, EquipmentLateUpdateSharedData sharedData)
	{
		ref EquipmentSlotCD valueRW = ref equipmentUpdateAspect.equipmentCD.ValueRW;
		if (valueRW.windupTimer.isRunning)
		{
			if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown))
			{
				EndWindup(in equipmentUpdateAspect, in lookupData, sharedData);
			}
			else if (valueRW.secondaryUse.hasSecondaryUse && valueRW.secondaryUse.windupTiers > 0 && !clientInput.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_HeldDown))
			{
				EndWindup(in equipmentUpdateAspect, in lookupData, sharedData);
			}
		}
		if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_HeldDown) && valueRW.secondaryUse.summonsMinion)
		{
			if (valueRW.windupTimer.isRunning)
			{
				EndWindup(in equipmentUpdateAspect, in lookupData, sharedData);
			}
			equipmentUpdateAspect.equipmentCD.ValueRW.summonMinion = false;
		}
		if (valueRW.warmupTimer.isRunning && !clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown))
		{
			EndWarmup(in equipmentUpdateAspect, in lookupData, sharedData);
		}
	}

	private static void Windup(ref EquipmentSlotCD equipmentSlotCD, EquipmentUpdateSharedData equipmentUpdateSharedData)
	{
		int targetTicks = (int)equipmentSlotCD.windupTimer.targetTicks;
		int num = math.min(targetTicks, equipmentSlotCD.windupTimer.GetElapsedTicks(equipmentUpdateSharedData.currentTick));
		equipmentSlotCD.currentWindup = equipmentSlotCD.windupTimer.GetPercentageFinished(equipmentUpdateSharedData.currentTick);
		equipmentSlotCD.currentWindupMultiplier = 1f + equipmentSlotCD.currentWindup;
		if (num >= targetTicks && !equipmentSlotCD.atMaxWindup)
		{
			equipmentSlotCD.atMaxWindup = true;
		}
		if (num >= targetTicks / equipmentSlotCD.secondaryUse.windupTiers * (equipmentSlotCD.currentWindupTier + 1))
		{
			equipmentSlotCD.currentWindupTier++;
		}
	}

	protected static void ChangeSize(in EquipmentUpdateAspect equipmentUpdateAspect, PugDatabase.DatabaseBankCD databaseBank)
	{
		ChangeSize(in equipmentUpdateAspect, PugDatabase.GetEntityObjectInfo(equipmentUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData.objectID, databaseBank.databaseBankBlob).prefabTileSize);
	}

	private static void ChangeSize(in EquipmentUpdateAspect equipmentUpdateAspect, int2 prefabTileSize)
	{
		if (prefabTileSize.x > 1)
		{
			ref PlacementSizeByEquipmentTypeBuffer elementForEquipment = ref equipmentUpdateAspect.placementSizeByEquipmentTypeBuffer.GetElementForEquipment(equipmentUpdateAspect.equipmentSlotCD.ValueRO.slotType);
			int num = math.min(elementForEquipment.sizeVariationToPlace, prefabTileSize.x - 1);
			elementForEquipment.sizeVariationToPlace = (byte)((num + 1) % prefabTileSize.x);
		}
	}

	public static int2 GetTileSizeFromVariation(in EquipmentSlotCD equipmentSlotCD, in DynamicBuffer<PlacementSizeByEquipmentTypeBuffer> placementSizeByEquipmentTypeBuffer, int2 prefabTileSize)
	{
		return GetTileSizeFromVariation(placementSizeByEquipmentTypeBuffer.GetElementForEquipment(equipmentSlotCD.slotType).sizeVariationToPlace, prefabTileSize);
	}

	public static int2 GetTileSizeFromVariation(int sizeVariationToPlace, int2 prefabTileSize)
	{
		return math.min(sizeVariationToPlace, prefabTileSize.x - 1) + 1;
	}

	public static void EndWindup(in EquipmentLateUpdateAspect equipmentUpdateAspect, in LookupEquipmentLateUpdateData lookupEquipmentData, EquipmentLateUpdateSharedData sharedEquipmentData)
	{
		ref EquipmentSlotCD valueRW = ref equipmentUpdateAspect.equipmentCD.ValueRW;
		if (valueRW.atMaxWindup && lookupEquipmentData.customAttackSoundLookup.TryGetComponent(equipmentUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData) && componentData.strongAttackSoundId != 0)
		{
			float x = math.clamp(math.pow(valueRW.currentWindup, 6f), 0f, 1f);
			DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = equipmentUpdateAspect.ghostEffectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW2 = ref equipmentUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = sharedEquipmentData.tick,
				value = new EffectEventCD
				{
					effectID = EffectID.StrongAttackSound,
					value1 = componentData.strongAttackSoundId,
					vector1 = new float3(x, 0f, 0f),
					position1 = equipmentUpdateAspect.localTransform.ValueRO.Position
				}
			};
			ghostEffectEventBuffer.AddToRingBuffer(ref valueRW2, in item);
		}
		valueRW.windupTimer.Stop(sharedEquipmentData.tick);
		valueRW.currentWindup = 0f;
		valueRW.currentWindupMultiplier = 1f;
		valueRW.currentWindupTier = 0;
		valueRW.atMaxWindup = false;
	}

	private static void EndWarmup(in EquipmentLateUpdateAspect equipmentUpdateAspect, in LookupEquipmentLateUpdateData lookupEquipmentData, EquipmentLateUpdateSharedData sharedEquipmentData)
	{
		equipmentUpdateAspect.equipmentCD.ValueRW.warmupTimer.Stop(sharedEquipmentData.tick);
	}

	public virtual void OnPickUp(PlayerController player, bool fireSceneEvent)
	{
		slotOwner = player;
		base.transform.parent = player.carryableHandle.transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		base.gameObject.SetActive(value: false);
	}

	public virtual void OnEquip(PlayerController player)
	{
		base.gameObject.SetActive(value: true);
	}

	public virtual void OnUnequip(PlayerController player)
	{
		weaponSecondaryUse = default(SecondaryUseCD);
		base.gameObject.SetActive(value: false);
	}

	public override void OnFree()
	{
		slotOwner = null;
		base.OnFree();
	}

	public static void AttackWithItem(in AttackWithEquipmentAspect attackWithEquipmentAspect, AttackWithEquipmentShared attackWithEquipmentShared, AttackWithEquipmentLookup attackWithEquipmentLookup)
	{
		float cooldownTime;
		if (attackWithEquipmentLookup.godModeLookup.IsComponentEnabled(attackWithEquipmentAspect.entity))
		{
			cooldownTime = 0.25f;
		}
		else
		{
			cooldownTime = 0.4f;
			DynamicBuffer<SummarizedConditionEffectsBuffer> dynamicBuffer = attackWithEquipmentLookup.summarizedConditionEffectBuffer[attackWithEquipmentAspect.entity];
			int value = dynamicBuffer[40].value;
			int value2 = dynamicBuffer[65].value;
			float num = math.max(1f + (float)value / 1000f + (float)value2 / 1000f, 0.1f);
			cooldownTime /= num;
		}
		attackWithEquipmentLookup.queueHitLookup.SetComponentEnabled(attackWithEquipmentAspect.entity, value: true);
		StartCooldownForItem(in attackWithEquipmentAspect.equippedObjectCD.ValueRO, ref attackWithEquipmentAspect.attackCooldownTimerCD.ValueRW, attackWithEquipmentAspect.syncedSharedCooldownTimersCD, attackWithEquipmentShared.currentTick, attackWithEquipmentShared.tickRate, in attackWithEquipmentShared.databaseBank, attackWithEquipmentLookup.cooldownLookup, cooldownTime, isRegularHit: true);
	}

	public static bool IsAttackOnCooldown(ref PlayerAttackCooldownCD playerAttackCooldownCD, in NetworkTick networkTick)
	{
		if (playerAttackCooldownCD.cooldown.isRunning)
		{
			return !playerAttackCooldownCD.cooldown.IsTimerElapsed(networkTick);
		}
		return false;
	}

	public static float GetHitCooldownRemaining(EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData lookupEquipmentUpdateData)
	{
		return GetHitCooldownRemaining(in equipmentUpdateAspect.equipmentSlotCD.ValueRO, in equipmentUpdateAspect.playerAttackCooldownCD.ValueRO, in equipmentUpdateAspect.equippedObjectCD.ValueRO, in equipmentUpdateSharedData.databaseBank, in lookupEquipmentUpdateData.cooldownLookup, equipmentUpdateAspect.syncedSharedCooldownTimers, in equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate);
	}

	public static float GetHitCooldownRemaining(in EquipmentSlotCD equipmentSlotCD, in PlayerAttackCooldownCD playerAttackCooldownCD, in EquippedObjectCD equippedObjectCD, in PugDatabase.DatabaseBankCD databaseBank, in ComponentLookup<CooldownCD> cooldownLookup, DynamicBuffer<SyncedPlayerSharedCooldownTimersCD> syncedSharedCooldownTimers, in NetworkTick currentTick, uint tickRate)
	{
		EquipmentSlotType equipmentSlotType = equipmentSlotCD.slotType;
		if (equipmentSlotType == EquipmentSlotType.RangeWeaponSlot || equipmentSlotType == EquipmentSlotType.SummoningWeaponSlot || equipmentSlotType == EquipmentSlotType.MeleeWeaponSlot || equipmentSlotType == EquipmentSlotType.BeamWeaponSlot)
		{
			return GetCooldownRemainingForItem(in equippedObjectCD, in databaseBank, in cooldownLookup, syncedSharedCooldownTimers, in currentTick, tickRate);
		}
		if (!playerAttackCooldownCD.cooldown.HasStarted)
		{
			return 0f;
		}
		return playerAttackCooldownCD.cooldown.GetRemainingSeconds(in currentTick, tickRate);
	}

	public static void StartCooldownForItem(in EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData, float cooldown)
	{
		StartCooldownForItem(in equipmentUpdateAspect.equippedObjectCD.ValueRO, ref equipmentUpdateAspect.playerAttackCooldownCD.ValueRW, equipmentUpdateAspect.syncedSharedCooldownTimers, equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate, in equipmentUpdateSharedData.databaseBank, equipmentUpdateLookupData.cooldownLookup, cooldown);
	}

	public static void StartCooldownForItem(in EquippedObjectCD equippedObjectCD, ref PlayerAttackCooldownCD playerAttackCooldownCD, DynamicBuffer<SyncedPlayerSharedCooldownTimersCD> syncedSharedCooldownTimersCD, NetworkTick currentTick, uint tickRate, in PugDatabase.DatabaseBankCD databaseBankCD, ComponentLookup<CooldownCD> cooldownLookup, float cooldownTime, bool isRegularHit = false)
	{
		CooldownCD cooldownForItem = GetCooldownForItem(in equippedObjectCD, in databaseBankCD, in cooldownLookup);
		int index = (int)(isRegularHit ? SyncedSharedCooldownType.MeleeWeaponSlot : cooldownForItem.syncedSharedCooldownType);
		syncedSharedCooldownTimersCD.ElementAt(index).cooldown.Start(currentTick, cooldownTime, tickRate);
		playerAttackCooldownCD.cooldown.Start(currentTick, math.min(cooldownTime, 0.5f), tickRate);
	}

	public static bool IsItemOnCooldown(in EquippedObjectCD equippedObjectCD, in PugDatabase.DatabaseBankCD databaseBank, in ComponentLookup<CooldownCD> cooldownLookup, DynamicBuffer<SyncedPlayerSharedCooldownTimersCD> syncedSharedCooldownTimers, in NetworkTick currentTick)
	{
		int syncedSharedCooldownType = (int)GetCooldownForItem(in equippedObjectCD, in databaseBank, in cooldownLookup).syncedSharedCooldownType;
		ref readonly SyncedPlayerSharedCooldownTimersCD reference = ref syncedSharedCooldownTimers.ElementAtRO(syncedSharedCooldownType);
		if (reference.cooldown.isRunning)
		{
			return !reference.cooldown.IsTimerElapsed(currentTick);
		}
		return false;
	}

	public static float GetCooldownRemainingForItem(in EquipmentUpdateAspect equipmentUpdateAspect, EquipmentUpdateSharedData equipmentUpdateSharedData, LookupEquipmentUpdateData equipmentUpdateLookupData)
	{
		return GetCooldownRemainingForItem(in equipmentUpdateAspect.equippedObjectCD.ValueRO, in equipmentUpdateSharedData.databaseBank, in equipmentUpdateLookupData.cooldownLookup, equipmentUpdateAspect.syncedSharedCooldownTimers, in equipmentUpdateSharedData.currentTick, equipmentUpdateSharedData.tickRate);
	}

	public static float GetCooldownRemainingForItem(in EquippedObjectCD equippedObjectCD, in PugDatabase.DatabaseBankCD databaseBank, in ComponentLookup<CooldownCD> cooldownLookup, DynamicBuffer<SyncedPlayerSharedCooldownTimersCD> syncedSharedCooldownTimers, in NetworkTick currentTick, uint tickRate)
	{
		int syncedSharedCooldownType = (int)GetCooldownForItem(in equippedObjectCD, in databaseBank, in cooldownLookup).syncedSharedCooldownType;
		ref SyncedPlayerSharedCooldownTimersCD reference = ref syncedSharedCooldownTimers.ElementAt(syncedSharedCooldownType);
		if (!reference.cooldown.HasStarted)
		{
			return 0f;
		}
		return reference.cooldown.GetRemainingSeconds(in currentTick, tickRate);
	}

	public static float GetNormalizedCooldownRemainingForItem(in ObjectDataCD objectData)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return 0f;
		}
		if (PugDatabase.GetObjectInfo(objectData.objectID, objectData.variation) == null)
		{
			return 0f;
		}
		CooldownCD cooldownForItem = GetCooldownForItem(in objectData);
		if (!EntityUtility.TryGetBuffer(player.entity, player.world, out DynamicBuffer<SyncedPlayerSharedCooldownTimersCD> value))
		{
			return 0f;
		}
		float fraction;
		NetworkTick currentTickOnClient = EntityUtility.GetCurrentTickOnClient(player.entity, player.world, out fraction);
		if (value.Length > 0)
		{
			int syncedSharedCooldownType = (int)cooldownForItem.syncedSharedCooldownType;
			TickTimer cooldown = value[syncedSharedCooldownType].cooldown;
			if (!cooldown.isRunning || cooldown.IsTimerElapsed(currentTickOnClient))
			{
				return 0f;
			}
			return cooldown.GetInvElapsedRatio(currentTickOnClient);
		}
		return 0f;
	}

	private static CooldownCD GetCooldownForItem(in EquippedObjectCD equippedObjectCD, in PugDatabase.DatabaseBankCD databaseBank, in ComponentLookup<CooldownCD> cooldownLookup)
	{
		if (!cooldownLookup.TryGetComponent(equippedObjectCD.equipmentPrefab, out var componentData))
		{
			PlayerController.GetCooldownTypeFromSlotType(PugDatabase.GetEntityObjectInfo(equippedObjectCD.containedObject.objectID, databaseBank.databaseBankBlob, equippedObjectCD.containedObject.variation).objectType, out var syncedSharedCooldownType);
			return new CooldownCD
			{
				syncedSharedCooldownType = syncedSharedCooldownType
			};
		}
		return componentData;
	}

	private static CooldownCD GetCooldownForItem(in ObjectDataCD objectData)
	{
		CooldownCD result = default(CooldownCD);
		if (!PugDatabase.HasComponent<CooldownCD>(objectData))
		{
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectData.objectID, objectData.variation);
			if (objectInfo == null)
			{
				return result;
			}
			PlayerController.GetCooldownTypeFromSlotType(objectInfo.objectType, out var syncedSharedCooldownType);
			return new CooldownCD
			{
				syncedSharedCooldownType = syncedSharedCooldownType
			};
		}
		return PugDatabase.GetComponent<CooldownCD>(objectData);
	}

	public static PhysicsCollider GetHitCollider(Entity equipmentPrefab, in EquipmentSlotCD equipmentSlotCD, in AnimationOrientationCD animationOrientationCD, in ColliderCacheCD colliderCache, in ComponentLookup<MeleeWeaponCD> meleeWeaponLookup, in WorldInfoCD worldInfo, bool _broken, float _windupMult)
	{
		float3 centerOfHitCollider = GetCenterOfHitCollider(equipmentPrefab, in equipmentSlotCD, in animationOrientationCD, in meleeWeaponLookup, _broken, _windupMult);
		float3 sizeOfHitCollider = GetSizeOfHitCollider(equipmentPrefab, in equipmentSlotCD, in animationOrientationCD, in meleeWeaponLookup, _broken, _windupMult);
		float radius = sizeOfHitCollider.x / 2f;
		uint layerMaskCollidesWith = (worldInfo.pvpEnabled ? 135007u : 135005u);
		if (!_broken && meleeWeaponLookup.TryGetComponent(equipmentPrefab, out var componentData))
		{
			switch (componentData.attackFXType)
			{
			case AttackFXType.Shockwave:
				return PhysicsManager.GetSphereCollider(centerOfHitCollider, radius, layerMaskCollidesWith, colliderCache);
			case AttackFXType.Arc:
				if (componentData.arcAngle == ArcAngle.arc360)
				{
					return PhysicsManager.GetSphereCollider(centerOfHitCollider, radius, layerMaskCollidesWith, colliderCache);
				}
				return PhysicsManager.GetBoxCollider(centerOfHitCollider, sizeOfHitCollider, layerMaskCollidesWith, colliderCache);
			default:
				return PhysicsManager.GetBoxCollider(centerOfHitCollider, sizeOfHitCollider, layerMaskCollidesWith, colliderCache);
			}
		}
		return PhysicsManager.GetBoxCollider(centerOfHitCollider, sizeOfHitCollider, layerMaskCollidesWith, colliderCache);
	}

	public static float3 GetCenterOfHitCollider(Entity equipmentPrefab, in EquipmentSlotCD equipmentSlotCD, in AnimationOrientationCD animationOrientationCD, in ComponentLookup<MeleeWeaponCD> meleeWeaponLookup, bool weaponIsBroken, float windupMult = 1f)
	{
		float num = 1f;
		float num2 = 0f;
		float num3 = 0f;
		bool flag = false;
		if (!weaponIsBroken && meleeWeaponLookup.TryGetComponent(equipmentPrefab, out var componentData))
		{
			if (componentData.colliderCenteredOnWindup && windupMult > 1f)
			{
				return new float3(0f, 0f, 0f);
			}
			num = componentData.baseHitColliderSize;
			num2 = componentData.extraHitColliderReachSize;
			num3 = ((componentData.arcAngle == ArcAngle.arc180 || componentData.arcAngle == ArcAngle.arc270) ? 1f : 0f);
			if (componentData.arcAngle == ArcAngle.arc360 && componentData.attackFXType == AttackFXType.Arc)
			{
				flag = true;
			}
		}
		float num4 = windupMult;
		if (equipmentSlotCD.secondaryUse.windupAreaSizeMultiplier > 0f)
		{
			num4 += (windupMult - 1f) * (equipmentSlotCD.secondaryUse.windupAreaSizeMultiplier - 1f);
			if (num4 > 1f && equipmentSlotCD.secondaryUse.hasSecondaryUse)
			{
				if (num2 <= 0f)
				{
					num *= num4 - (num4 - 1f) * (num3 / 2f);
				}
				else if (num2 > 0f)
				{
					num2 *= num4 * 1.3f;
				}
			}
		}
		float3 result = animationOrientationCD.facingDirection.vec3 * ((num + num2) / 2f);
		if (flag)
		{
			float num5 = windupMult - 1f;
			float3 float5 = new float3(0f, 0f, 0f);
			if (num5 > 0f)
			{
				result = float5;
			}
		}
		return result;
	}

	public static float3 GetSizeOfHitCollider(Entity equipmentPrefab, in EquipmentSlotCD equipmentSlotCD, in AnimationOrientationCD animationOrientationCD, in ComponentLookup<MeleeWeaponCD> meleeWeaponLookup, bool weaponIsBroken, float windupMult = 1f)
	{
		float num = 1f;
		float num2 = 0f;
		float num3 = 0f;
		bool flag = false;
		if (!weaponIsBroken)
		{
			if (meleeWeaponLookup.TryGetComponent(equipmentPrefab, out var componentData))
			{
				num = componentData.baseHitColliderSize;
				num2 = componentData.extraHitColliderReachSize;
				num3 = ((componentData.arcAngle == ArcAngle.arc180 || componentData.arcAngle == ArcAngle.arc270) ? 1f : 0f);
				if (componentData.arcAngle == ArcAngle.arc360 && componentData.attackFXType == AttackFXType.Arc)
				{
					flag = true;
				}
			}
			float num4 = windupMult;
			if (equipmentSlotCD.secondaryUse.windupAreaSizeMultiplier > 0f)
			{
				num4 += (windupMult - 1f) * (equipmentSlotCD.secondaryUse.windupAreaSizeMultiplier - 1f);
				if (num4 > 1f && equipmentSlotCD.secondaryUse.hasSecondaryUse)
				{
					if (num2 <= 0f)
					{
						num *= num4 - (num4 - 1f) * (num3 / 2f);
					}
					else if (num2 > 0f)
					{
						num2 *= num4 * 1.3f;
					}
				}
			}
		}
		Vector3 vec = animationOrientationCD.facingDirection.vec3;
		float3 float5 = new float3((num + Mathf.Abs(vec.x) * num2) * (1f + Mathf.Abs(vec.z) * num3), 1f, (num + Mathf.Abs(vec.z) * num2) * (1f + Mathf.Abs(vec.x) * num3));
		if (flag)
		{
			float3 float6 = new float3(num + num2, 1f, num + num2);
			return (1f - windupMult) * float5 + windupMult * float6;
		}
		return float5;
	}

	public static void ConsumeAnyRequiredMana(AttackWithEquipmentLookup attackWithEquipmentLookup, AttackWithEquipmentAspect attackWithEquipmentAspect, bool checkingCostForSecondary = false)
	{
		if (!attackWithEquipmentAspect.playerManaCD.ValueRO.isUnlimited)
		{
			int manaCost = GetManaCost(attackWithEquipmentAspect.entity, attackWithEquipmentAspect.equippedObjectCD.ValueRO.equipmentPrefab, attackWithEquipmentAspect.equippedObjectCD.ValueRO, attackWithEquipmentAspect.equipmentSlotCD.ValueRO, attackWithEquipmentLookup.consumesManaLookup, attackWithEquipmentLookup.levelEntitiesBufferLookup, attackWithEquipmentLookup.levelLookup, attackWithEquipmentLookup.objectPropertiesLookup, attackWithEquipmentLookup.summarizedConditionsBuffer, checkingCostForSecondary);
			if (manaCost != 0)
			{
				ManaCD valueRO = attackWithEquipmentAspect.playerManaCD.ValueRO;
				attackWithEquipmentAspect.playerManaCD.ValueRW.mana = math.clamp(valueRO.mana - manaCost, 0, valueRO.maxMana);
				attackWithEquipmentAspect.playerManaCD.ValueRW.delay = true;
			}
		}
	}

	public static int GetManaCost(Entity owner, Entity equipmentPrefab, EquippedObjectCD equippedObjectCD, EquipmentSlotCD equipmentSlotCD, ComponentLookup<ConsumesManaCD> consumesManaLookup, BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup, ComponentLookup<LevelCD> levelLookup, ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup, BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBuffer, bool checkingCostForSecondary = false)
	{
		if (equipmentSlotCD.secondaryUse.summonsMinion && !checkingCostForSecondary && !equipmentSlotCD.summonMinion)
		{
			return 0;
		}
		int num = 0;
		Entity levelEntity = EntityUtility.GetLevelEntity(equipmentPrefab, equippedObjectCD.containedObject.objectData, levelEntitiesBufferLookup, levelLookup);
		ConsumesManaCD componentData2;
		if (levelEntity != Entity.Null)
		{
			if (consumesManaLookup.TryGetComponent(levelEntity, out var componentData))
			{
				num = componentData.manaCost;
			}
		}
		else if (consumesManaLookup.TryGetComponent(equipmentPrefab, out componentData2))
		{
			num = componentData2.manaCost;
		}
		if (num != 0)
		{
			if (checkingCostForSecondary)
			{
				num = (equipmentSlotCD.secondaryUse.hasWindup ? ((int)math.round((float)num * equipmentSlotCD.secondaryUse.manaCostMultiplier)) : num);
			}
			else
			{
				float num2 = 0f;
				if (objectPropertiesLookup.TryGetComponent(equipmentPrefab, out var componentData3) && componentData3.TryGet<ConditionID>(1351250308, out var value))
				{
					num2 = (float)EntityUtility.GetConditionValue(value, owner, summarizedConditionsBuffer) / 100f;
				}
				num = (equipmentSlotCD.secondaryUse.hasWindup ? ((int)math.round(math.lerp(1f, equipmentSlotCD.secondaryUse.manaCostMultiplier, equipmentSlotCD.currentWindup) * (1f + num2) * (float)num)) : ((int)math.round((float)num * (1f + num2))));
			}
		}
		return num;
	}

	private void ApplyTriggerEffect(ref TriggerEffectCD triggerEffect)
	{
	}

	private void RevertTriggerEffect()
	{
	}
}
