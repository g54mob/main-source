using Pug.Automation;
using Pug.Properties;
using RayAttackState;
using Unity.Collections;
using Unity.Entities;
using Unity.Physics;
using Unity.Transforms;

public struct StateRequestContainers
{
	public ComponentLookup<GiantCicadaBossAppearStateCD> _giantCicadaAppearStateGroup;

	public ComponentLookup<BirdBossAppearStateCD> _birdAppearStateGroup;

	public ComponentLookup<TeleportStateCD> _teleportStateGroup;

	public ComponentLookup<SeasonalLootCD> _seasonalLootGroup;

	public ComponentLookup<BossCD> _bossGroup;

	public ComponentLookup<OctopusBossAppearStateCD> _octopusAppearStateGroup;

	public ComponentLookup<ScarabBossAppearStateCD> _scarabAppearStateGroup;

	public ComponentLookup<ScarabBossChargeStateCD> _scarabChargeStateGroup;

	public ComponentLookup<EnrageStateCD> _enrageStateGroup;

	public ComponentLookup<LarvaHiveBossHatchEggStateCD> _larvaHiveBossHatchEggStateGroup;

	public ComponentLookup<ExplodeStateCD> _explodeStateGroup;

	public ComponentLookup<EvolveStateCD> _evolveStateGroup;

	public ComponentLookup<PlaceObjectStateCD> _placeObjectStateGroup;

	public BufferLookup<TargetMortarPositionBuffer> _targetMortarPositionBufferGroup;

	public ComponentLookup<ShootMortarProjectileStateCD> _mortarStateGroup;

	public BufferLookup<MortarShotsBuffer> _mortarShotPositionBufferGroup;

	public ComponentLookup<TookDamageStateCD> _tookDamageStateGroup;

	public ComponentLookup<JumpAttackStateCD> _jumpAttackStateGroup;

	public ComponentLookup<HealOtherEntityStateCD> _healOtherStateGroup;

	public ComponentLookup<BeamAttackStateCD> _beamAttackStateGroup;

	public ComponentLookup<RayAttackStateCD> _rayAttackStateGroup;

	public BufferLookup<BeamBuffer> _beamBufferGroup;

	public ComponentLookup<ChargeAttackStateCD> _chargeStateGroup;

	public ComponentLookup<MeleeAttackStateCD> _meleeAttackStateGroup;

	public ComponentLookup<AttackCooldownTimerCD> _attackCooldownGroup;

	public ComponentLookup<AttackContinuouslyCD> _attackContinuouslyStateGroup;

	public ComponentLookup<RangeAttackStateCD> _rangeStateGroup;

	public ComponentLookup<SlimeBossJumpStateCD> _slimeBossJumpStateGroup;

	public ComponentLookup<GiantCicadaSlamArmsStateCD> _slamArmsStateGroup;

	public ComponentLookup<BirdBossSpawnStonesStateCD> _spawnStonesGroup;

	public ComponentLookup<BreedStateCD> _breedStateGroup;

	public ComponentLookup<BreedToggleCD> _breedToggleGroup;

	public ComponentLookup<EatStateCD> _eatStateGroup;

	public ComponentLookup<LeashedCD> _leashedGroup;

	public ComponentLookup<IdleWhenNearbyPlayerStateCD> _idleNearbyPlayerStateGroup;

	public ComponentLookup<CombatEmoteStateCD> _combatEmoteStateGroup;

	public ComponentLookup<PathFindCD> _pathFindGroup;

	public ComponentLookup<PathFindAStarCD> _pathFindAStarGroup;

	public ComponentLookup<FollowPheromoneStateCD> _followPheromoneGroup;

	public ComponentLookup<DamageObjectStateCD> _damageObjectStateGroup;

	public ComponentLookup<HatchWhenPlayerNearbyStateCD> _hatchWhenPlayerNearbyStateGroup;

	public ComponentLookup<ActivatedByElectricityStateCD> _activatedByElectricityGroup;

	public ComponentLookup<SleepStateCD> _sleepStateGroup;

	public ComponentLookup<IdleEmoteStateCD> _idleEmoteStateGroup;

	public ComponentLookup<AlertEmoteStateCD> _alertEmoteStateGroup;

	public ComponentLookup<PetWalkStateCD> _petWalkStateGroup;

	public ComponentLookup<RandomFollowStateCD> _randomFollowStateGroup;

	public ComponentLookup<RoamingStateCD> _roamingStateGroup;

	public ComponentLookup<RandomWalkStateCD> _randomWalkStateGroup;

	public ComponentLookup<IdleInCombatStateCD> _idleInCombatStateGroup;

	public ComponentLookup<BirdBossFlyingAboveStateCD> _birdBossFlyingGroup;

	public ComponentLookup<OctopusBossLurkingBelowStateCD> _lurkingBelowGroup;

	public ComponentLookup<ScarabBossBuriedStateCD> _scarabBossBuriedGroup;

	public ComponentLookup<BushStateCD> _bushStateGroup;

	public ComponentLookup<ChaseStateCD> _chaseStateGroup;

	public ComponentLookup<BirdBossSpawnBeamsStateCD> _birdBossSpawnBeamsGroup;

	public ComponentLookup<CoreBossSpawnBeamsStateCD> _coreBossSpawnBeamsGroup;

	public ComponentLookup<CoreBossSpawnVoidStateCD> _coreBossSpawnVoidGroup;

	public ComponentLookup<OctopusBossSpawnTentaclesStateCD> _spawnTentacleGroup;

	public ComponentLookup<OctopusBossCD> _octopusBossGroup;

	public ComponentLookup<EnemyStagesStateCD> _enemyStagesGroup;

	public ComponentLookup<PhaseTransitionStateCD> _phaseTransitionGroup;

	public ComponentLookup<HydraBossBuriedCombatStateCD> _hydraBossBuriedCombatStateGroup;

	public ComponentLookup<HydraBossBuriedRoamingStateCD> _hydraBossBuriedRoamingStateGroup;

	public ComponentLookup<VulnerableStateCD> _vulnerableStateGroup;

	public ComponentLookup<MoveToPositionFromCommandStateCD> _moveToPositionFromCommandGroup;

	[ReadOnly]
	public ComponentLookup<OwnerReferenceCD> _ownerGroup;

	[ReadOnly]
	public ComponentLookup<CombatRadiusCD> _combatRadiusGroup;

	[ReadOnly]
	public ComponentLookup<EntityDestroyedCD> _entityDestroyedGroup;

	[ReadOnly]
	public ComponentLookup<BossLarvaSpawnStateCD> _bossLarvaSpawnStateGroup;

	[ReadOnly]
	public ComponentLookup<LocalTransform> _localTransformGroup;

	[ReadOnly]
	public ComponentLookup<GiantCicadaBossHasAppearedCD> _giantCicadaHasAppearedGroup;

	[ReadOnly]
	public ComponentLookup<BirdBossHasAppearedCD> _birdHasAppearedGroup;

	[ReadOnly]
	public ComponentLookup<BossSpawnLocationCD> _bossSpawnLocationGroup;

	[ReadOnly]
	public ComponentLookup<ObjectDataCD> _objectDataGroup;

	[ReadOnly]
	public ComponentLookup<IsInCombatCD> _isInCombatGroup;

	[ReadOnly]
	public ComponentLookup<OctopusBossHasAppearedCD> _octopusHasAppearedGroup;

	[ReadOnly]
	public ComponentLookup<ScarabBossHasAppearedCD> _scarabHasAppearedGroup;

	[ReadOnly]
	public ComponentLookup<DistanceToPlayerCD> _distanceToPlayerGroup;

	[ReadOnly]
	public ComponentLookup<LarvaHiveEggHatchStateCD> _larvaHiveHatchStateGroup;

	[ReadOnly]
	public ComponentLookup<HealthCD> _healthGroup;

	[ReadOnly]
	public ComponentLookup<StunnedStateCD> _stunnedStateGroup;

	[ReadOnly]
	public ComponentLookup<NearbyEntitiesTrackerCD> _nearbyEntitiesTrackerGroup;

	[ReadOnly]
	public BufferLookup<NearbyEntitiesBufferCD> _nearbyEntitiesBufferGroup;

	[ReadOnly]
	public ComponentLookup<BehaviourTagsCD> _behaviourTagsGroup;

	[ReadOnly]
	public ComponentLookup<FactionCD> _factionGroup;

	[ReadOnly]
	public ComponentLookup<ObjectCategoryTagsCD> _objectCategoryTagsGroup;

	[ReadOnly]
	public ComponentLookup<PlayerGhost> _playerGhostGroup;

	[ReadOnly]
	public ComponentLookup<PlayerGhostExtrapolated> _playerGhostExtrapolatedGroup;

	[ReadOnly]
	public ComponentLookup<EnemyCD> _enemyGroup;

	[ReadOnly]
	public ComponentLookup<EntityPartCD> _entityPartGroup;

	[ReadOnly]
	public ComponentLookup<TileCD> _tileGroup;

	[ReadOnly]
	public ComponentLookup<SpawnStateCD> _spawnStateGroup;

	[ReadOnly]
	public ComponentLookup<HasRunSpawnStateCD> _hasRunSpawnGroup;

	[ReadOnly]
	public ComponentLookup<DisablePhysicsCD> _physicsExcludeGroup;

	[ReadOnly]
	public ComponentLookup<LastAttackerCD> _lastAttackerGroup;

	[ReadOnly]
	public BufferLookup<SummarizedConditionEffectsBuffer> _conditionEffectBufferGroup;

	[ReadOnly]
	public ComponentLookup<IsBeingBeHealedByOtherEntitiesCD> _isBeingHealedByOtherGroup;

	[ReadOnly]
	public ComponentLookup<ObjectCategoryTagsCD> _objectCategoryGroup;

	[ReadOnly]
	public ComponentLookup<PhysicsCollider> _physicsColliderGroup;

	[ReadOnly]
	public ComponentLookup<CritterCD> _critterGroup;

	[ReadOnly]
	public ComponentLookup<ElectricityCD> _electricityGroup;

	[ReadOnly]
	public ComponentLookup<DirectionBasedOnVariationCD> _directionBasedOnVariationGroup;

	[ReadOnly]
	public ComponentLookup<SpawnPointCD> _spawnPointGroup;

	[ReadOnly]
	public BufferLookup<TeleportLocationsBuffer> _teleportLocationsBufferGroup;

	[ReadOnly]
	public ComponentLookup<EquippedObjectCD> _equippedObjectGroup;

	[ReadOnly]
	public ComponentLookup<PheromoneSensorCD> _pheromoneSensorGroup;

	[ReadOnly]
	public BufferLookup<KilledEnemiesBuffer> _killedEnemiesBufferGroup;

	[ReadOnly]
	public ComponentLookup<DetectCollisionCD> _detectCollisionGroup;

	[ReadOnly]
	public ComponentLookup<IndestructibleCD> _indestructibleGroup;

	[ReadOnly]
	public ComponentLookup<DamageReductionCD> _damageReductionGroup;

	[ReadOnly]
	public ComponentLookup<BossLarvaSpawnStateCD> _bossLarvaSpawnGroup;

	[ReadOnly]
	public ComponentLookup<SnakeMovementStateCD> _snakeMovementGroup;

	[ReadOnly]
	public ComponentLookup<DamageTakenTriggerCD> _damageTakenGroup;

	[ReadOnly]
	public ComponentLookup<PetCD> _petGroup;

	[ReadOnly]
	public BufferLookup<CombatantsTrackerBuffer> _combatantTrackerBuffer;

	[ReadOnly]
	public BufferLookup<ContainedObjectsBuffer> _containedObjectsBufferGroup;

	[ReadOnly]
	public ComponentLookup<DebugTagCD> _debugGroup;

	[ReadOnly]
	public ComponentLookup<DirectionCD> _directionGroup;

	[ReadOnly]
	public ComponentLookup<PlayAnimationStateCD> _playAnimationStateGroup;

	[ReadOnly]
	public ComponentLookup<CattleCD> _cattleGroup;

	[ReadOnly]
	public ComponentLookup<MealsEatenCD> _mealsEatenGroup;

	[ReadOnly]
	public ComponentLookup<ShieldCD> _shieldGroup;

	[ReadOnly]
	public ComponentLookup<ObjectPropertiesCD> _propertiesGroup;

	[ReadOnly]
	public ComponentLookup<MinionCD> _minionGroup;

	[ReadOnly]
	public ComponentLookup<MiningMinionCD> _miningMinionGroup;

	[ReadOnly]
	public ComponentLookup<SpawnTickCD> _spawnTickGroup;

	[ReadOnly]
	public BufferLookup<PathFindNodeBuffer> _pathFindNodeBufferGroup;

	[ReadOnly]
	public ComponentLookup<IgnoreImmuneZoneCD> _IgnoreImmuneZoneGroup;

	[ReadOnly]
	public ComponentLookup<ImmuneToDamageCD> _immuneToDamage;
}
