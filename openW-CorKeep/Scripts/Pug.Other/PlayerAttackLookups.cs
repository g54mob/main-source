using Inventory;
using PlayerEquipment;
using PlayerState;
using Pug.Properties;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;

public struct PlayerAttackLookups
{
	[ReadOnly]
	public ComponentLookup<DurabilityCD> durabilityLookup;

	[ReadOnly]
	public ComponentLookup<SecondaryUseCD> windupLookup;

	[ReadOnly]
	public ComponentLookup<HasWeaponDamageCD> hasWeaponDamageLookup;

	[ReadOnly]
	public BufferLookup<SummarizedConditionsBuffer> summarizeConiditionsLookup;

	[ReadOnly]
	public BufferLookup<SummarizedConditionEffectsBuffer> summarizeConiditionsEffectsLookup;

	[ReadOnly]
	public ComponentLookup<EnemyCD> enemyLookup;

	[ReadOnly]
	public ComponentLookup<DamageReductionCD> damageReductionLookup;

	[ReadOnly]
	public ComponentLookup<TileCD> tileLookup;

	[ReadOnly]
	public ComponentLookup<DestructibleObjectCD> destructibleObjectLookup;

	[ReadOnly]
	public ComponentLookup<ImmuneToRangeDamageCD> immuneToRangeDamageLookup;

	[ReadOnly]
	public ComponentLookup<BossCD> bossLookup;

	[ReadOnly]
	public ComponentLookup<MinionCD> minionLookup;

	[ReadOnly]
	public ComponentLookup<EntityPartCD> entityPartLookup;

	[ReadOnly]
	public ComponentLookup<CritterCD> critterLookup;

	[ReadOnly]
	public ComponentLookup<MeleeWeaponCD> meleeWeaponLookup;

	[ReadOnly]
	public ComponentLookup<PlantCD> plantLookup;

	[ReadOnly]
	public ComponentLookup<GrowingCD> growingLookup;

	[ReadOnly]
	public ComponentLookup<ObjectDataCD> objectDataLookup;

	[ReadOnly]
	public ComponentLookup<NonHittableCD> nonHittableLookup;

	[ReadOnly]
	public ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup;

	[ReadOnly]
	public ComponentLookup<RootCD> rootLookup;

	[ReadOnly]
	public ComponentLookup<MineableCD> mineableLookup;

	[ReadOnly]
	public ComponentLookup<DirectionCD> directionLookup;

	[ReadOnly]
	public ComponentLookup<ControlledByOtherEntityCD> controlledByOtherEntityLookup;

	[ReadOnly]
	public ComponentLookup<TileColliderCD> tileColliderLookup;

	[ReadOnly]
	public ComponentLookup<PseudoTileCD> pseudoTileLookup;

	[ReadOnly]
	public ComponentLookup<DamageableObjectCD> damageableObjectLookup;

	[ReadOnly]
	public ComponentLookup<IndestructibleCD> indestructibleLookup;

	[ReadOnly]
	public ComponentLookup<FactionCD> factionLookup;

	[ReadOnly]
	public ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup;

	[ReadOnly]
	public ComponentLookup<ShieldCD> shieldLookup;

	[ReadOnly]
	public ComponentLookup<AnimationOrientationCD> animationOrientationLookup;

	[ReadOnly]
	public ComponentLookup<DontBlockPlayerFromHittingObjectsWhenMiningPickEquippedCD> dontBlockPlayerFromHittingObjectsWhenMiningPickEquippedLookup;

	[ReadOnly]
	public ComponentLookup<CattleCD> cattleLookup;

	[ReadOnly]
	public ComponentLookup<MerchantCD> merchantLookup;

	[ReadOnly]
	public ComponentLookup<ProjectileCD> projectileLookup;

	[ReadOnly]
	public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

	[ReadOnly]
	public ComponentLookup<ImmuneToPushBackCD> immuneToPushBackLookup;

	[ReadOnly]
	public ComponentLookup<GroundDecorationCD> groundDecorationLookup;

	[ReadOnly]
	public ComponentLookup<SurfacePriorityCD> surfacePriorityLookup;

	[ReadOnly]
	public ComponentLookup<RequiresDrillCD> requiresDrillLookup;

	[ReadOnly]
	public ComponentLookup<DontDestroyOnZeroHealthCD> dontDestroyOnZeroHealthLookup;

	[ReadOnly]
	public BufferLookup<SnakeSegmentsBuffer> snakeSegmentsBufferLookup;

	[ReadOnly]
	public ComponentLookup<ClaimedByPlayerGuidCD> claimedByPlayerGUIDLookup;

	[ReadOnly]
	public ComponentLookup<PlayerGhost> playerGhostLookup;

	[ReadOnly]
	public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

	[ReadOnly]
	public ComponentLookup<BehaviourTagsCD> behaviourTagsLookup;

	[ReadOnly]
	public ComponentLookup<GhostOwner> ghostOwnerLookup;

	[ReadOnly]
	public ComponentLookup<BirdBossBeamCD> birdBossLookup;

	[ReadOnly]
	public ComponentLookup<AttackContinuouslyCD> attackContinuouslyLookup;

	[ReadOnly]
	public ComponentLookup<LastAttackerCD> lastAttackerLookup;

	[ReadOnly]
	public BufferLookup<NewCombatantsBuffer> newCombatantsBufferLookup;

	[ReadOnly]
	public ComponentLookup<ExplodeStateCD> explodeStateLookup;

	[ReadOnly]
	public ComponentLookup<TookDamageStateCD> tookDamageStateLookup;

	[ReadOnly]
	public ComponentLookup<SleepStateCD> sleepStateLookup;

	[ReadOnly]
	public ComponentLookup<PlayerStateCD> playerStateLookup;

	[ReadOnly]
	public ComponentLookup<PlayerInvincibilityCD> playerInvincibilityLookup;

	[ReadOnly]
	public ComponentLookup<PhysicsMass> physicsMassLookup;

	[ReadOnly]
	public ComponentLookup<GhostInstance> ghostInstanceLookup;

	[ReadOnly]
	public ComponentLookup<PredictedGhost> predictedGhostLookup;

	[ReadOnly]
	public ComponentLookup<UseOffHandStateCD> useOffHandStateLookup;

	[ReadOnly]
	public ComponentLookup<ObjectTypeCD> objectTypeLookup;

	[ReadOnly]
	public ComponentLookup<AnimateDontDestroyOnZeroHealthCD> animateDontDestroyOnZeroHealthLookup;

	[ReadOnly]
	public ComponentLookup<CustomAttackSoundCD> customAttackSoundLookup;

	[ReadOnly]
	public ComponentLookup<PetCD> petLookup;

	[ReadOnly]
	public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

	[ReadOnly]
	public ComponentLookup<SecondaryUseCD> secondaryUseLookup;

	[ReadOnly]
	public ComponentLookup<LeaveTrailCD> leaveTrailLookup;

	[ReadOnly]
	public ComponentLookup<LevelCD> levelLookup;

	[ReadOnly]
	public ComponentLookup<Simulate> simulateLookup;

	[ReadOnly]
	public ComponentLookup<MortarProjectileCD> mortarProjectileLookup;

	[ReadOnly]
	public ComponentLookup<GodModeCD> godModeLookup;

	[ReadOnly]
	public ComponentLookup<EquipmentCD> equipmentLookup;

	[ReadOnly]
	public ComponentLookup<OwnerReferenceCD> ownerLookup;

	[ReadOnly]
	public BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup;

	[ReadOnly]
	public ComponentLookup<UseLagCompensationCD> useLagCompensationLookup;

	[ReadOnly]
	public ComponentLookup<PhaseTransitionStateCD> phaseTransitionStateLookup;

	[ReadOnly]
	public ComponentLookup<PlayerGraveCD> playerGraveLookup;

	[ReadOnly]
	public ComponentLookup<AttackableWithMeleeCD> attackableWithMeleeLookup;

	[ReadOnly]
	public ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup;

	[ReadOnly]
	public ComponentLookup<PiercingProjectileCD> piercingProjectileLookup;

	[ReadOnly]
	public ComponentLookup<DropAllItemsOnHitCD> dropAllItemsOnHitLookup;

	[ReadOnly]
	public ComponentLookup<BeamWeaponCD> beamWeaponLookup;

	[ReadOnly]
	public ComponentLookup<IgnoreImmuneZoneCD> ignoreImmunityZoneLookup;

	[ReadOnly]
	public ComponentLookup<MoveFreelyWeaponCD> moveFreelyWeaponLookup;

	public ComponentLookup<LocalTransform> localTransformLookup;

	public BufferLookup<AnimationBuffer> animationBufferLookup;

	public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

	public ComponentLookup<HealthCD> healthLookup;

	public ComponentLookup<PhysicsVelocity> physicsVelocityLookup;

	public BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

	public ComponentLookup<ReduceDurabilityOfEquippedTriggerCD> reduceDurabilityOfEquippedLookup;

	public BufferLookup<TileDamageBuffer> tileDamageBufferLookup;

	public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

	public ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup;

	public BufferLookup<ConditionsBuffer> conditionsBufferLookup;

	public ComponentLookup<ManaCD> manaLookup;

	public ComponentLookup<MagicBarrierCD> magicBarrierLookup;

	public ComponentLookup<IncreaseDurabilityOfEquippedTriggerCD> increaseDurabilityOfEquippedLookup;

	public ComponentLookup<LastDamageTakenTimeCD> lastDamageTakenTimeLookup;

	public ComponentLookup<RandomCD> randomLookup;

	public ComponentLookup<DamageEffectCD> damageEffectLookup;

	public BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup;

	public ComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD> reduceDurabilityOfAllEquipmentTriggerLookup;

	public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

	public BufferLookup<DealDamageToEntityBuffer> dealDamageToEntityBufferLookup;

	public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

	public ComponentLookup<DontDropSelfCD> dontDropSelfLookup;

	public ComponentLookup<DontDropLootCD> dontDropLootLookup;

	public ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup;

	public ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> moveToPredictedByCombatInteractionLookup;

	public ComponentLookup<MoveToPredictedByEntityDestroyedCD> moveToPredictedByEntityDestroyedLookup;

	public ComponentLookup<MoveToPredictedByPushbackCD> moveToPredictedByPushbackLookup;

	public ComponentLookup<IsExplosiveCD> isExplosiveLookup;

	public PlayerAttackLookups(ref SystemState state)
	{
		durabilityLookup = state.GetComponentLookup<DurabilityCD>(isReadOnly: true);
		windupLookup = state.GetComponentLookup<SecondaryUseCD>(isReadOnly: true);
		hasWeaponDamageLookup = state.GetComponentLookup<HasWeaponDamageCD>(isReadOnly: true);
		summarizeConiditionsLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
		summarizeConiditionsEffectsLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
		enemyLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
		damageReductionLookup = state.GetComponentLookup<DamageReductionCD>(isReadOnly: true);
		tileLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
		destructibleObjectLookup = state.GetComponentLookup<DestructibleObjectCD>(isReadOnly: true);
		immuneToRangeDamageLookup = state.GetComponentLookup<ImmuneToRangeDamageCD>(isReadOnly: true);
		bossLookup = state.GetComponentLookup<BossCD>(isReadOnly: true);
		minionLookup = state.GetComponentLookup<MinionCD>(isReadOnly: true);
		entityPartLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
		critterLookup = state.GetComponentLookup<CritterCD>(isReadOnly: true);
		meleeWeaponLookup = state.GetComponentLookup<MeleeWeaponCD>(isReadOnly: true);
		plantLookup = state.GetComponentLookup<PlantCD>(isReadOnly: true);
		growingLookup = state.GetComponentLookup<GrowingCD>(isReadOnly: true);
		objectDataLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
		nonHittableLookup = state.GetComponentLookup<NonHittableCD>(isReadOnly: true);
		objectCategoryTagsLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
		rootLookup = state.GetComponentLookup<RootCD>(isReadOnly: true);
		mineableLookup = state.GetComponentLookup<MineableCD>(isReadOnly: true);
		directionLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
		controlledByOtherEntityLookup = state.GetComponentLookup<ControlledByOtherEntityCD>(isReadOnly: true);
		tileColliderLookup = state.GetComponentLookup<TileColliderCD>(isReadOnly: true);
		pseudoTileLookup = state.GetComponentLookup<PseudoTileCD>(isReadOnly: true);
		damageableObjectLookup = state.GetComponentLookup<DamageableObjectCD>(isReadOnly: true);
		indestructibleLookup = state.GetComponentLookup<IndestructibleCD>(isReadOnly: true);
		factionLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
		immuneToDamageLookup = state.GetComponentLookup<ImmuneToDamageCD>(isReadOnly: true);
		shieldLookup = state.GetComponentLookup<ShieldCD>(isReadOnly: true);
		animationOrientationLookup = state.GetComponentLookup<AnimationOrientationCD>(isReadOnly: true);
		dontBlockPlayerFromHittingObjectsWhenMiningPickEquippedLookup = state.GetComponentLookup<DontBlockPlayerFromHittingObjectsWhenMiningPickEquippedCD>(isReadOnly: true);
		cattleLookup = state.GetComponentLookup<CattleCD>(isReadOnly: true);
		merchantLookup = state.GetComponentLookup<MerchantCD>(isReadOnly: true);
		projectileLookup = state.GetComponentLookup<ProjectileCD>(isReadOnly: true);
		entityDestroyedLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		immuneToPushBackLookup = state.GetComponentLookup<ImmuneToPushBackCD>(isReadOnly: true);
		groundDecorationLookup = state.GetComponentLookup<GroundDecorationCD>(isReadOnly: true);
		surfacePriorityLookup = state.GetComponentLookup<SurfacePriorityCD>(isReadOnly: true);
		requiresDrillLookup = state.GetComponentLookup<RequiresDrillCD>(isReadOnly: true);
		dontDestroyOnZeroHealthLookup = state.GetComponentLookup<DontDestroyOnZeroHealthCD>(isReadOnly: true);
		snakeSegmentsBufferLookup = state.GetBufferLookup<SnakeSegmentsBuffer>(isReadOnly: true);
		claimedByPlayerGUIDLookup = state.GetComponentLookup<ClaimedByPlayerGuidCD>(isReadOnly: true);
		playerGhostLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
		destroyTimerLookup = state.GetComponentLookup<DestroyTimerCD>(isReadOnly: true);
		behaviourTagsLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
		ghostOwnerLookup = state.GetComponentLookup<GhostOwner>(isReadOnly: true);
		birdBossLookup = state.GetComponentLookup<BirdBossBeamCD>(isReadOnly: true);
		attackContinuouslyLookup = state.GetComponentLookup<AttackContinuouslyCD>(isReadOnly: true);
		lastAttackerLookup = state.GetComponentLookup<LastAttackerCD>(isReadOnly: true);
		newCombatantsBufferLookup = state.GetBufferLookup<NewCombatantsBuffer>(isReadOnly: true);
		explodeStateLookup = state.GetComponentLookup<ExplodeStateCD>(isReadOnly: true);
		tookDamageStateLookup = state.GetComponentLookup<TookDamageStateCD>(isReadOnly: true);
		sleepStateLookup = state.GetComponentLookup<SleepStateCD>(isReadOnly: true);
		playerStateLookup = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
		playerInvincibilityLookup = state.GetComponentLookup<PlayerInvincibilityCD>(isReadOnly: true);
		physicsMassLookup = state.GetComponentLookup<PhysicsMass>(isReadOnly: true);
		ghostInstanceLookup = state.GetComponentLookup<GhostInstance>(isReadOnly: true);
		predictedGhostLookup = state.GetComponentLookup<PredictedGhost>(isReadOnly: true);
		useOffHandStateLookup = state.GetComponentLookup<UseOffHandStateCD>(isReadOnly: true);
		objectTypeLookup = state.GetComponentLookup<ObjectTypeCD>(isReadOnly: true);
		animateDontDestroyOnZeroHealthLookup = state.GetComponentLookup<AnimateDontDestroyOnZeroHealthCD>(isReadOnly: true);
		customAttackSoundLookup = state.GetComponentLookup<CustomAttackSoundCD>(isReadOnly: true);
		petLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
		objectPropertiesLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
		secondaryUseLookup = state.GetComponentLookup<SecondaryUseCD>(isReadOnly: true);
		leaveTrailLookup = state.GetComponentLookup<LeaveTrailCD>(isReadOnly: true);
		levelLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
		simulateLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
		mortarProjectileLookup = state.GetComponentLookup<MortarProjectileCD>(isReadOnly: true);
		godModeLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
		equipmentLookup = state.GetComponentLookup<EquipmentCD>(isReadOnly: true);
		ownerLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
		containedObjectsBufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
		useLagCompensationLookup = state.GetComponentLookup<UseLagCompensationCD>(isReadOnly: true);
		phaseTransitionStateLookup = state.GetComponentLookup<PhaseTransitionStateCD>(isReadOnly: true);
		playerGraveLookup = state.GetComponentLookup<PlayerGraveCD>(isReadOnly: true);
		attackableWithMeleeLookup = state.GetComponentLookup<AttackableWithMeleeCD>(isReadOnly: true);
		mortarProjectileDamageEffectLookup = state.GetComponentLookup<MortarProjectileDamageEffectCD>(isReadOnly: true);
		piercingProjectileLookup = state.GetComponentLookup<PiercingProjectileCD>(isReadOnly: true);
		dropAllItemsOnHitLookup = state.GetComponentLookup<DropAllItemsOnHitCD>(isReadOnly: true);
		beamWeaponLookup = state.GetComponentLookup<BeamWeaponCD>(isReadOnly: true);
		ignoreImmunityZoneLookup = state.GetComponentLookup<IgnoreImmuneZoneCD>(isReadOnly: true);
		moveFreelyWeaponLookup = state.GetComponentLookup<MoveFreelyWeaponCD>(isReadOnly: true);
		localTransformLookup = state.GetComponentLookup<LocalTransform>();
		animationBufferLookup = state.GetBufferLookup<AnimationBuffer>();
		animationBufferPointerLookup = state.GetComponentLookup<AnimationBufferPointer>();
		healthLookup = state.GetComponentLookup<HealthCD>();
		physicsVelocityLookup = state.GetComponentLookup<PhysicsVelocity>();
		healthChangeBufferLookup = state.GetBufferLookup<HealthChangeBuffer>();
		reduceDurabilityOfEquippedLookup = state.GetComponentLookup<ReduceDurabilityOfEquippedTriggerCD>();
		tileDamageBufferLookup = state.GetBufferLookup<TileDamageBuffer>();
		ghostEffectEventBufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>();
		ghostEffectEventBufferPointerLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
		conditionsBufferLookup = state.GetBufferLookup<ConditionsBuffer>();
		manaLookup = state.GetComponentLookup<ManaCD>();
		magicBarrierLookup = state.GetComponentLookup<MagicBarrierCD>();
		increaseDurabilityOfEquippedLookup = state.GetComponentLookup<IncreaseDurabilityOfEquippedTriggerCD>();
		lastDamageTakenTimeLookup = state.GetComponentLookup<LastDamageTakenTimeCD>();
		randomLookup = state.GetComponentLookup<RandomCD>();
		damageEffectLookup = state.GetComponentLookup<DamageEffectCD>();
		inventoryChangeBufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
		reduceDurabilityOfAllEquipmentTriggerLookup = state.GetComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD>();
		killedByPlayerLookup = state.GetComponentLookup<KilledByPlayerCD>();
		dealDamageToEntityBufferLookup = state.GetBufferLookup<DealDamageToEntityBuffer>();
		tileUpdateBufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
		dontDropSelfLookup = state.GetComponentLookup<DontDropSelfCD>();
		dontDropLootLookup = state.GetComponentLookup<DontDropLootCD>();
		receivedPushbackLookup = state.GetComponentLookup<ReceivedPushbackCD>();
		moveToPredictedByCombatInteractionLookup = state.GetComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD>();
		moveToPredictedByEntityDestroyedLookup = state.GetComponentLookup<MoveToPredictedByEntityDestroyedCD>();
		moveToPredictedByPushbackLookup = state.GetComponentLookup<MoveToPredictedByPushbackCD>();
		isExplosiveLookup = state.GetComponentLookup<IsExplosiveCD>();
	}

	public void Update(ref SystemState state)
	{
		durabilityLookup.Update(ref state);
		windupLookup.Update(ref state);
		hasWeaponDamageLookup.Update(ref state);
		summarizeConiditionsLookup.Update(ref state);
		summarizeConiditionsEffectsLookup.Update(ref state);
		enemyLookup.Update(ref state);
		damageReductionLookup.Update(ref state);
		tileLookup.Update(ref state);
		destructibleObjectLookup.Update(ref state);
		immuneToRangeDamageLookup.Update(ref state);
		bossLookup.Update(ref state);
		minionLookup.Update(ref state);
		entityPartLookup.Update(ref state);
		critterLookup.Update(ref state);
		meleeWeaponLookup.Update(ref state);
		plantLookup.Update(ref state);
		growingLookup.Update(ref state);
		objectDataLookup.Update(ref state);
		localTransformLookup.Update(ref state);
		nonHittableLookup.Update(ref state);
		objectCategoryTagsLookup.Update(ref state);
		rootLookup.Update(ref state);
		mineableLookup.Update(ref state);
		directionLookup.Update(ref state);
		controlledByOtherEntityLookup.Update(ref state);
		tileColliderLookup.Update(ref state);
		pseudoTileLookup.Update(ref state);
		damageableObjectLookup.Update(ref state);
		indestructibleLookup.Update(ref state);
		factionLookup.Update(ref state);
		immuneToDamageLookup.Update(ref state);
		shieldLookup.Update(ref state);
		animationOrientationLookup.Update(ref state);
		dontBlockPlayerFromHittingObjectsWhenMiningPickEquippedLookup.Update(ref state);
		cattleLookup.Update(ref state);
		merchantLookup.Update(ref state);
		projectileLookup.Update(ref state);
		entityDestroyedLookup.Update(ref state);
		immuneToPushBackLookup.Update(ref state);
		groundDecorationLookup.Update(ref state);
		surfacePriorityLookup.Update(ref state);
		requiresDrillLookup.Update(ref state);
		isExplosiveLookup.Update(ref state);
		moveFreelyWeaponLookup.Update(ref state);
		dontDestroyOnZeroHealthLookup.Update(ref state);
		snakeSegmentsBufferLookup.Update(ref state);
		claimedByPlayerGUIDLookup.Update(ref state);
		playerGhostLookup.Update(ref state);
		destroyTimerLookup.Update(ref state);
		behaviourTagsLookup.Update(ref state);
		ghostOwnerLookup.Update(ref state);
		birdBossLookup.Update(ref state);
		attackContinuouslyLookup.Update(ref state);
		lastAttackerLookup.Update(ref state);
		newCombatantsBufferLookup.Update(ref state);
		explodeStateLookup.Update(ref state);
		tookDamageStateLookup.Update(ref state);
		sleepStateLookup.Update(ref state);
		playerStateLookup.Update(ref state);
		playerInvincibilityLookup.Update(ref state);
		physicsMassLookup.Update(ref state);
		ghostInstanceLookup.Update(ref state);
		predictedGhostLookup.Update(ref state);
		useOffHandStateLookup.Update(ref state);
		objectTypeLookup.Update(ref state);
		animateDontDestroyOnZeroHealthLookup.Update(ref state);
		customAttackSoundLookup.Update(ref state);
		petLookup.Update(ref state);
		objectPropertiesLookup.Update(ref state);
		secondaryUseLookup.Update(ref state);
		leaveTrailLookup.Update(ref state);
		levelLookup.Update(ref state);
		simulateLookup.Update(ref state);
		mortarProjectileLookup.Update(ref state);
		godModeLookup.Update(ref state);
		equipmentLookup.Update(ref state);
		containedObjectsBufferLookup.Update(ref state);
		useLagCompensationLookup.Update(ref state);
		phaseTransitionStateLookup.Update(ref state);
		playerGraveLookup.Update(ref state);
		attackableWithMeleeLookup.Update(ref state);
		mortarProjectileDamageEffectLookup.Update(ref state);
		piercingProjectileLookup.Update(ref state);
		dropAllItemsOnHitLookup.Update(ref state);
		beamWeaponLookup.Update(ref state);
		ignoreImmunityZoneLookup.Update(ref state);
		animationBufferLookup.Update(ref state);
		animationBufferPointerLookup.Update(ref state);
		healthLookup.Update(ref state);
		physicsVelocityLookup.Update(ref state);
		healthChangeBufferLookup.Update(ref state);
		reduceDurabilityOfEquippedLookup.Update(ref state);
		tileDamageBufferLookup.Update(ref state);
		ghostEffectEventBufferLookup.Update(ref state);
		ghostEffectEventBufferPointerLookup.Update(ref state);
		conditionsBufferLookup.Update(ref state);
		manaLookup.Update(ref state);
		magicBarrierLookup.Update(ref state);
		increaseDurabilityOfEquippedLookup.Update(ref state);
		lastDamageTakenTimeLookup.Update(ref state);
		randomLookup.Update(ref state);
		damageEffectLookup.Update(ref state);
		inventoryChangeBufferLookup.Update(ref state);
		reduceDurabilityOfAllEquipmentTriggerLookup.Update(ref state);
		ownerLookup.Update(ref state);
		killedByPlayerLookup.Update(ref state);
		dealDamageToEntityBufferLookup.Update(ref state);
		tileUpdateBufferLookup.Update(ref state);
		dontDropSelfLookup.Update(ref state);
		dontDropLootLookup.Update(ref state);
		receivedPushbackLookup.Update(ref state);
		moveToPredictedByCombatInteractionLookup.Update(ref state);
		moveToPredictedByEntityDestroyedLookup.Update(ref state);
		moveToPredictedByPushbackLookup.Update(ref state);
	}
}
