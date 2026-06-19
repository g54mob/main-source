using CommandMinion;
using Interaction;
using PlayerEquipment;
using PlayerState;
using Pug.Conversion;
using Unity.Entities;
using Unity.NetCode;
using Unity.Physics;
using Unity.Physics.Authoring;
using UnityEngine;

public class PlayerAuthoringConverter : SingleAuthoringComponentConverter<PlayerAuthoring>
{
	protected override void Convert(PlayerAuthoring authoring)
	{
		EnsureHasComponent<AutoPickUpItemCD>();
		EnsureHasComponent<PlayerGhost>();
		EnsureHasComponent<ClientInput>();
		EnsureHasComponent<ClientInputHistoryCD>();
		EnsureHasComponent<ClientInputData>();
		EnsureHasComponent<ClientInputForLatestFrameCD>();
		EnsureHasBuffer<InputBufferData<ClientInputData>>();
		EnsureHasComponent<CoinAmountCD>();
		EnsureHasComponent<PlayerMovementForceCD>();
		EnsureHasComponent<LeashingCD>();
		EnsureHasComponent<PlayerInvincibilityCD>();
		EnsureHasComponent<IncreaseDurabilityOfEquippedTriggerCD>(componentIsEnabled: false);
		EnsureHasComponent<ReduceDurabilityOfEquippedTriggerCD>(componentIsEnabled: false);
		EnsureHasComponent<ReduceDurabilityOfAllEquipmentTriggerCD>(componentIsEnabled: false);
		EnsureHasComponent<PlayerOrientationCD>();
		EnsureHasComponent<DisablePhysicsCD>(componentIsEnabled: false);
		EnsureHasComponent<HealOverTimeConditionCD>();
		EnsureHasComponent<CharacterTypeCD>();
		EnsureHasComponent<PlayerEmoteEffectsCD>();
		EnsureHasComponent<CurrentBiomeCD>();
		if (base.IsServer)
		{
			EnsureHasComponent<CurrentSubBiomeCD>();
		}
		EnsureHasComponent<LastDamageTakenTimeCD>();
		EnsureHasComponent<MinionCountTrackerCD>();
		EnsureHasComponent<InteractorCD>();
		EnsureHasComponent<NextInteractorCD>();
		EnsureHasComponent<LocalInteractorCD>();
		CapsuleGeometryAuthoring collisionCapsuleGeometry = GetCollisionCapsuleGeometry(authoring);
		AddComponentData(new PlayerColliderCD
		{
			capsuleRadius = collisionCapsuleGeometry.Radius,
			capsuleHeight = collisionCapsuleGeometry.Height,
			capsuleCenterOffset = collisionCapsuleGeometry.Center
		});
		EnsureHasComponent<UIActionsCD>();
		EnsureHasBuffer<UIActionBuffer>();
		EnsureHasComponent<WaitingForEatableSlotConsumeResultCD>(componentIsEnabled: false);
		EnsureHasComponent<WaitingForCastingOpenItemResultCD>(componentIsEnabled: false);
		EnsureHasComponent<CritterDamageFromPlacingCD>();
		AddComponentData(new PlacementCD
		{
			rotationVariationToPlace = 2
		});
		EnsureHasBuffer<PlacementSizeByEquipmentTypeBuffer>();
		for (int i = 0; i < 5; i++)
		{
			AddToBuffer(new PlacementSizeByEquipmentTypeBuffer
			{
				sizeVariationToPlace = 254
			});
		}
		EnsureHasComponent<GodModeCD>(componentIsEnabled: false);
		EnsureHasComponent<PlayerSpawnCD>();
		EnsureHasComponent<PlayerUnstuckCD>();
		EnsureHasComponent<ConditionsFromMovementCD>();
		AddComponentData(new QuickSwapTorchCD
		{
			swappedTorchFromIndex = -1
		});
		EnsureHasComponent<ControllingOtherEntityCD>();
		EnsureHasComponent<EffectiveVelocityCD>();
		EnsureHasComponent<SimulationTickStartPositionCD>();
		EnsureHasComponent<CommandDataInterpolationDelay>();
		PlayerController component = authoring.GetComponent<EntityMonoBehaviourData>().objectInfo.prefabInfos[0].prefab.GetComponent<PlayerController>();
		AddComponentData(new PlayerMovementCD
		{
			movementSpeed = component.movementSpeed,
			noClipMovementSpeedMultipler = component.noClipMovementSpeedMultipler
		});
		EnsureHasComponent<VelocityAffectedCD>();
		AddComponentData(new HungerCD
		{
			hunger = 70,
			canConsumeHunger = true
		});
		_ = PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		AddComponentData(new DealDamageToCrittersCD
		{
			squashBugs = false
		});
		EnsureHasBuffer<SkillConditionsBuffer>();
		EnsureHasBuffer<SkillTalentConditionsBuffer>();
		EnsureHasBuffer<SkillBuffer>();
		ConvertPlayerStates(authoring);
		ConvertPlayerAttack(authoring);
		EnsureHasComponent<ClientInputNonPartialStateCD>();
		EnsureHasBuffer<PlayerChainTargetsBuffer>();
		EnsureHasBuffer<DealDamageToEntityBuffer>();
		EnsureHasComponent<PlayerRecentAttackersBufferPointerCD>();
		EnsureHasBuffer<PlayerRecentAttackersBuffer>();
		for (int j = 0; j < 8; j++)
		{
			AddToBuffer(default(PlayerRecentAttackersBuffer));
		}
		EnsureHasComponent<CurrentTileCD>();
		EnsureHasComponent<PlacementIndicationVisualStateCD>();
		EnsureHasComponent<AimIndicatorCachedStatesCD>();
		AddComponentData(new KeepAreaLoadedCD
		{
			KeepLoadedRadius = 300f,
			StartLoadRadius = 250f,
			ImmediateLoadRadius = 200f
		});
		EnsureHasComponent<TriggerSelectEnemyToAttackForMinionCommandCD>(componentIsEnabled: false);
		EnsureHasComponent<MinionCommandAttackTargetCD>();
		if (base.IsServer)
		{
			EnsureHasComponent<PlayerLastSessionCD>();
		}
	}

	private CapsuleGeometryAuthoring GetCollisionCapsuleGeometry(PlayerAuthoring authoring)
	{
		PhysicsShapeAuthoring[] components = authoring.GetComponents<PhysicsShapeAuthoring>();
		PhysicsShapeAuthoring physicsShapeAuthoring = null;
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].ShapeType != ShapeType.Capsule)
			{
				continue;
			}
			CollisionResponsePolicy collisionResponse = components[i].CollisionResponse;
			if (collisionResponse == CollisionResponsePolicy.Collide || collisionResponse == CollisionResponsePolicy.CollideRaiseCollisionEvents)
			{
				if (physicsShapeAuthoring != null)
				{
					Debug.LogError("Multiple capsule colliders with collision response on player not supported");
				}
				physicsShapeAuthoring = components[i];
			}
		}
		if (!(physicsShapeAuthoring != null))
		{
			return default(CapsuleGeometryAuthoring);
		}
		return physicsShapeAuthoring.GetCapsuleProperties();
	}

	private void ConvertPlayerStates(PlayerAuthoring authoring)
	{
		EnsureHasComponent<PlayerStateCD>();
		uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		AddComponentData(new WalkStateCD
		{
			reorientationDelay = new TickTimer(authoring.walkingReorientationDelay, simulationTickRate)
		});
		AddComponentData(new FishingStateCD
		{
			castTimer = new TickTimer(1f, simulationTickRate),
			throwTimer = new TickTimer(1f / 3f, simulationTickRate),
			pullUpTimer = new TickTimer(0.75f, simulationTickRate),
			allowedToLeaveStateTimer = new TickTimer(0.1f, simulationTickRate)
		});
		AddComponentData(default(WaitingForConsumedBaitResultCD), componentIsEnabled: false);
		AddComponentData(default(DelayedFishLootCD), componentIsEnabled: false);
		AddComponentData(default(BoatRidingStateCD));
		AddComponentData(new FishingMiniGameStateCD
		{
			beginMiniGameTimer = new TickTimer(0.5f, simulationTickRate)
		});
		BlobAssetReference<BlobCurve> blobAsset = BlobCurve.Create(authoring.vehicleDriftingAmountCurve);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		AddComponentData(new VehicleRidingStateCD
		{
			reorientationDelay = new TickTimer(1f / 15f, simulationTickRate),
			attackDestructiblesTimer = new TickTimer(0.02f, simulationTickRate),
			vehicleDriftingAmountCurve = blobAsset
		});
		EnsureHasComponent<ReleaseStateCD>();
		AddComponentData(new AnticipationCD
		{
			AnticipationDuration = new TickTimer(5f / 14f, simulationTickRate),
			cooldowmTimer = new TickTimer(0.45f, simulationTickRate),
			firstAttack = true
		});
		EnsureHasComponent<UseOffHandStateCD>();
		AddComponentData(new DeathStateCD
		{
			respawnTimer = new TickTimer(6f, simulationTickRate)
		});
		AddComponentData(new TeleportingStateCD
		{
			teleportingTimer = new TickTimer(6.1f, simulationTickRate)
		});
		EnsureHasComponent<CastingStateCD>();
		EnsureHasComponent<SpawningFromCoreStateCD>();
		EnsureHasComponent<PlayerSleepStateCD>();
		AddComponentData(new MinecartRidingStateCD
		{
			timeSinceBreakingTimer = new TickTimer(0.2f, simulationTickRate)
		});
		AddComponentData(new SittingStateCD
		{
			allowedToLeaveStateTimer = new TickTimer(0.15f, simulationTickRate),
			tryingToLeaveStateTimer = new TickTimer(0.15f, simulationTickRate)
		});
		AddComponentData(new RefillWaterStateCD
		{
			refillWaterDuration = new TickTimer(7f / 60f, simulationTickRate),
			particleDelay = new TickTimer(1f / 60f, simulationTickRate)
		});
		AddComponentData(new PlaceWaterStateCD
		{
			placeWaterDuration = new TickTimer(7f / 60f, simulationTickRate),
			particleDelay = new TickTimer(1f / 60f, simulationTickRate)
		});
		EnsureHasComponent<DigStateCD>();
		EnsureHasComponent<FlattenStateCD>();
		EnsureHasComponent<PlaceObjectPlayerStateCD>();
	}

	private void ConvertPlayerAttack(PlayerAuthoring authoring)
	{
		EnsureHasComponent<PlayerAttackCD>();
		EnsureHasComponent<PlayerRoutineCD>();
		EnsureHasComponent<PlayerAttackCooldownCD>();
		EnsureHasComponent<BeamWeaponAttackCD>();
		EnsureHasBuffer<PlayerPreviouslyHitEnemiesBuffer>();
		AddComponentData(default(AttackWithEquipmentTag), componentIsEnabled: false);
		AddComponentData(default(QueueHitTriggerCD), componentIsEnabled: false);
		EnsureHasComponent<RangedWeaponSpawnProjectileTriggerTag>(componentIsEnabled: false);
		EnsureHasComponent<BeamWeaponSpawnProjectileTriggerTag>(componentIsEnabled: false);
		EnsureHasBuffer<SyncedPlayerSharedCooldownTimersCD>();
		for (int i = 0; i < 24; i++)
		{
			AddToBuffer(default(SyncedPlayerSharedCooldownTimersCD));
		}
	}
}
