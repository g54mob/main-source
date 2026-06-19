using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Inventory;
using PlayerEquipment;
using PlayerState;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class AttackSystem : SystemBase
{
	public struct Helper
	{
		public struct Parameters
		{
			public FixedList32Bytes<ObjectID> cantHitSpecificObjects;

			public BehaviourTagsCD behaviourTags;

			public float3 attackOffset;

			public quaternion rotation;

			public float3 castDirection;

			public Entity effectEventBufferSingleton;

			public Entity attacker;

			public Entity skipHitsOnEntity;

			public float radius;

			public float boxHalfHorizontalWidth;

			public float boxHalfVerticalWidth;

			public float castDistance;

			public int damage;

			public DamageEffectType damageEffectType;

			public int playerDamage;

			public int reverseDamage;

			public float sameFactionHealingPercentage;

			public float pushback;

			public float reversePushback;

			public int triggerAnimationOnClientHit;

			public float attackTime;

			public CanOnlyAttackType canOnlyAttackType;

			public ObjectID cantHitSpecificObject;

			public bool instantlyDestroyObjectsRequiringDrills;

			public bool checkVisibility;

			public bool performAttackEvenIfZeroDamage;

			public bool isMagic;

			public bool treatDodgeAsHit;

			public bool canAttackOwner;

			public bool isExplosive;

			public bool isExplosiveDamageFromBomb;

			public bool isPredicted;

			public bool isExecutedBeforePhysics;

			public bool isRanged;

			public bool bypassMaxDamagePerHit;

			public bool bypassDamageReduction;

			public bool skipWallAndRootsLootDropOnDestroy;

			public bool skipLootDropOnDestroy;

			public bool skipLootDropIfDestroyPlants;

			public bool canHitLowTriggers;

			public bool cannotHitTriggersOrLowObjects;

			public bool cantHitObjectsHangingOnWalls;

			public bool isStatic;

			public bool useDefaultCastDistanceForRpcAttack;

			public bool ignoreLastPlayerHit;

			public bool canOnlyHitCertainNonEnemyObjects;
		}

		private struct HitInfo
		{
			public Entity entity;

			public float3 position;

			public int2 tilePosition;
		}

		public NetworkTick currentTick;

		private NetworkTick startServerTick;

		private uint ticksPerSecond;

		[ReadOnly]
		public PhysicsWorldHistorySingleton physicsWorldHistory;

		[ReadOnly]
		public ComponentLookup<CommandDataInterpolationDelay> interpolationDelayLookup;

		[ReadOnly]
		private NativeParallelHashMap<SpawnedGhost, float3> playerHitLookup;

		[ReadOnly]
		private NativeParallelHashMap<SpawnedGhost, NetworkTick> lastPlayerHit;

		private Entity healthChangeBufferEntity;

		public ComponentLookup<LocalTransform> localTransformLookup;

		public ComponentLookup<ObjectDataCD> objectDataLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> entityPartLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		private ComponentLookup<IndestructibleCD> indestructibleLookup;

		[ReadOnly]
		private ComponentLookup<ImmuneToPushBackCD> immuneToPushBackLookup;

		[ReadOnly]
		private ComponentLookup<CantBeAttackedCD> cantBeAttackedLookup;

		public ComponentLookup<ExplosionCD> explosionLookup;

		public ComponentLookup<ExplodeStateCD> explodeStateLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookup;

		[ReadOnly]
		private ComponentLookup<PseudoTileCD> pseudoTileLookup;

		[ReadOnly]
		private ComponentLookup<OwnerReferenceCD> ownerLookup;

		[ReadOnly]
		private ComponentLookup<BossCD> bossLookup;

		[ReadOnly]
		private ComponentLookup<ObjectCategoryTagsCD> tagsLookup;

		[ReadOnly]
		private ComponentLookup<CritterCD> critterLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> minionLookup;

		public ComponentLookup<HealthCD> healthLookup;

		private ComponentLookup<ManaCD> manaLookup;

		private ComponentLookup<MagicBarrierCD> magicBarrierLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		[ReadOnly]
		private ComponentLookup<ImmuneToRangeDamageCD> immuneToRangeDamageLookup;

		[ReadOnly]
		private ComponentLookup<RequiresDrillCD> requiresDrillLookup;

		private BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

		private ComponentLookup<LastDamageTakenTimeCD> lastDamageTakenTimeLookup;

		public ComponentLookup<RandomCD> randomLookup;

		public ComponentLookup<PlayerAttackCD> playerAttackLookup;

		[ReadOnly]
		private BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBufferLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> petLookup;

		[ReadOnly]
		private ComponentLookup<PetOwnerCD> petOwnerLookup;

		[ReadOnly]
		private ComponentLookup<CattleCD> cattleLookup;

		[ReadOnly]
		private ComponentLookup<IgnoreImmuneZoneCD> ignoreImmuneLookup;

		public ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup;

		public ComponentLookup<PhysicsVelocity> physicsVelocityAccessor;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> damageReductionLookup;

		[ReadOnly]
		public ComponentLookup<DrillCD> drillLookup;

		[ReadOnly]
		public TileAccessor tileAccessor;

		[ReadOnly]
		private ComponentLookup<ObjectTypeCD> objectTypeLookup;

		[ReadOnly]
		private ComponentLookup<DestructibleObjectCD> destructibleLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> propertiesLookup;

		[ReadOnly]
		private ComponentLookup<MortarProjectileCD> mortarProjectileLookup;

		[ReadOnly]
		private ComponentLookup<PhaseTransitionStateCD> phaseTransitionStateLookup;

		[ReadOnly]
		private ComponentLookup<Simulate> simulateLookup;

		[ReadOnly]
		private ComponentLookup<DontCountAsHitForAttackerCD> dontCountAsHitLookup;

		public ComponentLookup<AttackContinuouslyCD> attackContinuouslyLookup;

		[ReadOnly]
		public ConditionsTableCD conditionsTableCD;

		[ReadOnly]
		public PugDatabase.DatabaseBankCD databaseBank;

		[ReadOnly]
		public PhysicsWorld physicsWorld;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> playerStateLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizeConiditionsLookup;

		[ReadOnly]
		public ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup;

		[ReadOnly]
		public ComponentLookup<GhostInstance> ghostInstanceLookup;

		public BufferLookup<ConditionsBuffer> conditionsBufferLookup;

		[ReadOnly]
		public ComponentLookup<UseOffHandStateCD> useOffHandStateLookup;

		public ComponentLookup<AnimationOrientationCD> animationOrientationLookup;

		[ReadOnly]
		public ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

		public ComponentLookup<GhostOwner> ghostOwnerLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> behaviourTagsLookup;

		[ReadOnly]
		public ComponentLookup<PlayerInvincibilityCD> playerInvincibilityLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsMass> physicsMassLookup;

		[ReadOnly]
		public ComponentLookup<WeaponSkillMultiplierCD> weaponSkillMultiplierLookup;

		[ReadOnly]
		public ComponentLookup<ShieldCD> shieldLookup;

		public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup;

		public BufferLookup<NewConditionsBuffer> newConditionsBufferLookup;

		public BufferLookup<RemoveConditionsBuffer> removeConditionsBufferLookup;

		public ComponentLookup<LastAttackerCD> lastAttackerlookup;

		[ReadOnly]
		public ComponentLookup<TookDamageStateCD> tookDamageStateLookup;

		[ReadOnly]
		public ComponentLookup<SleepStateCD> sleepStateLookup;

		public BufferLookup<AnimationBuffer> animationBufferLookup;

		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		public ComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD> reduceDurabilityOfAllEquipmentTriggerLookup;

		[ReadOnly]
		public ComponentLookup<GodModeCD> godModeLookup;

		public BufferLookup<InventoryChangeBuffer> inventoryChangeBuffer;

		[ReadOnly]
		public ComponentLookup<EquipmentCD> equipmentLookup;

		public BufferLookup<DealDamageToEntityBuffer> dealDamageToEntityBuffer;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedObjectsBuffer;

		public ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup;

		public ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> moveToPredictedByCombatInteractionLookup;

		public ComponentLookup<MoveToPredictedByPushbackCD> moveToPredictedByPushbackLookup;

		public BufferLookup<NewCombatantsBuffer> newCombatantsBufferLookup;

		public uint tickRate;

		public ServerSeedCD serverSeedCD;

		[ReadOnly]
		public WorldInfoCD worldInfo;

		[ReadOnly]
		public ComponentLookup<CollectedAndEnabledSoulsMask> soulsMaskLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup;

		public ComponentLookup<PiercingProjectileCD> piercingProjectileLookup;

		public ComponentLookup<ProjectileCD> projectileLookup;

		[ReadOnly]
		public ComponentLookup<RootCD> rootLookup;

		[ReadOnly]
		public ComponentLookup<MineableCD> mineableLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGraveCD> playerGraveLookup;

		[ReadOnly]
		public ComponentLookup<AttackableWithMeleeCD> attackableWithMeleeLookup;

		[ReadOnly]
		public ComponentLookup<MerchantCD> merchantLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<DropAllItemsOnHitCD> dropAllItemsOnHitLookup;

		public Entity inventoryChangeBufferEntity;

		[NativeDisableUnsafePtrRestriction]
		private EntityQuery networkTimeQuery;

		[NativeDisableUnsafePtrRestriction]
		private EntityQuery physicsWorldQuery;

		[NativeDisableUnsafePtrRestriction]
		private EntityQuery physicsWorldHistoryQuery;

		[NativeDisableUnsafePtrRestriction]
		private EntityQuery worldInfoQuery;

		public bool isCreated;

		public bool isServer;

		public bool isFirstTimeFullyPredictingTick;

		public static void RequireForUpdate(ref SystemState state)
		{
			state.RequireForUpdate<ClientServerTickRate>();
			state.RequireForUpdate<PhysicsWorldHistorySingleton>();
			state.RequireForUpdate<HealthChangeBuffer>();
			state.RequireForUpdate<ConditionsTableCD>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<PhysicsWorldSingleton>();
			state.RequireForUpdate<ServerSeedCD>();
			state.RequireForUpdate<WorldInfoCD>();
			state.RequireForUpdate<ConditionsTableCD>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<InventoryChangeBuffer>();
		}

		public Helper(ref SystemState state, int tickRate)
		{
			isCreated = true;
			AttackSystemData singleton = state.GetSingleton<AttackSystemData>();
			currentTick = state.GetSingleton<NetworkTime>().ServerTick;
			startServerTick = state.GetSingleton<NetworkTime>().ServerTick;
			startServerTick.Increment();
			ticksPerSecond = (uint)state.GetSingleton<ClientServerTickRate>().SimulationTickRate;
			physicsWorldHistory = state.GetSingleton<PhysicsWorldHistorySingleton>();
			playerHitLookup = singleton.PlayerHitLookup;
			lastPlayerHit = singleton.LastPlayerHit;
			healthChangeBufferEntity = state.GetSingletonEntity<HealthChangeBuffer>();
			interpolationDelayLookup = state.GetComponentLookup<CommandDataInterpolationDelay>(isReadOnly: true);
			localTransformLookup = state.GetComponentLookup<LocalTransform>();
			objectDataLookup = state.GetComponentLookup<ObjectDataCD>();
			entityPartLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
			factionLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			indestructibleLookup = state.GetComponentLookup<IndestructibleCD>(isReadOnly: true);
			tileLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
			pseudoTileLookup = state.GetComponentLookup<PseudoTileCD>(isReadOnly: true);
			ownerLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			bossLookup = state.GetComponentLookup<BossCD>(isReadOnly: true);
			tagsLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
			critterLookup = state.GetComponentLookup<CritterCD>(isReadOnly: true);
			minionLookup = state.GetComponentLookup<MinionCD>(isReadOnly: true);
			healthLookup = state.GetComponentLookup<HealthCD>();
			manaLookup = state.GetComponentLookup<ManaCD>();
			magicBarrierLookup = state.GetComponentLookup<MagicBarrierCD>();
			enemyLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			immuneToRangeDamageLookup = state.GetComponentLookup<ImmuneToRangeDamageCD>(isReadOnly: true);
			requiresDrillLookup = state.GetComponentLookup<RequiresDrillCD>(isReadOnly: true);
			immuneToPushBackLookup = state.GetComponentLookup<ImmuneToPushBackCD>(isReadOnly: true);
			cantBeAttackedLookup = state.GetComponentLookup<CantBeAttackedCD>(isReadOnly: true);
			explosionLookup = state.GetComponentLookup<ExplosionCD>();
			explodeStateLookup = state.GetComponentLookup<ExplodeStateCD>();
			healthChangeBufferLookup = state.GetBufferLookup<HealthChangeBuffer>();
			summarizedConditionsBufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			summarizedConditionEffectsBufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			petLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
			petOwnerLookup = state.GetComponentLookup<PetOwnerCD>(isReadOnly: true);
			cattleLookup = state.GetComponentLookup<CattleCD>(isReadOnly: true);
			ignoreImmuneLookup = state.GetComponentLookup<IgnoreImmuneZoneCD>(isReadOnly: true);
			snakeMovementStateLookup = state.GetComponentLookup<SnakeMovementStateCD>();
			physicsVelocityAccessor = state.GetComponentLookup<PhysicsVelocity>();
			damageReductionLookup = state.GetComponentLookup<DamageReductionCD>(isReadOnly: true);
			drillLookup = state.GetComponentLookup<DrillCD>(isReadOnly: true);
			tileAccessor = new TileAccessor(ref state);
			objectTypeLookup = state.GetComponentLookup<ObjectTypeCD>(isReadOnly: true);
			destructibleLookup = state.GetComponentLookup<DestructibleObjectCD>(isReadOnly: true);
			propertiesLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
			mortarProjectileLookup = state.GetComponentLookup<MortarProjectileCD>(isReadOnly: true);
			phaseTransitionStateLookup = state.GetComponentLookup<PhaseTransitionStateCD>(isReadOnly: true);
			simulateLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
			dontCountAsHitLookup = state.GetComponentLookup<DontCountAsHitForAttackerCD>(isReadOnly: true);
			attackContinuouslyLookup = state.GetComponentLookup<AttackContinuouslyCD>();
			lastDamageTakenTimeLookup = state.GetComponentLookup<LastDamageTakenTimeCD>();
			randomLookup = state.GetComponentLookup<RandomCD>();
			playerAttackLookup = state.GetComponentLookup<PlayerAttackCD>();
			isServer = state.WorldUnmanaged.IsServer();
			isFirstTimeFullyPredictingTick = state.GetSingleton<NetworkTime>().IsFirstTimeFullyPredictingTick;
			conditionsTableCD = state.GetSingleton<ConditionsTableCD>();
			databaseBank = state.GetSingleton<PugDatabase.DatabaseBankCD>();
			physicsWorld = state.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld;
			playerGhostLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			playerStateLookup = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
			summarizeConiditionsLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			objectCategoryTagsLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
			ghostInstanceLookup = state.GetComponentLookup<GhostInstance>(isReadOnly: true);
			conditionsBufferLookup = state.GetBufferLookup<ConditionsBuffer>();
			useOffHandStateLookup = state.GetComponentLookup<UseOffHandStateCD>(isReadOnly: true);
			animationOrientationLookup = state.GetComponentLookup<AnimationOrientationCD>();
			immuneToDamageLookup = state.GetComponentLookup<ImmuneToDamageCD>(isReadOnly: true);
			destroyTimerLookup = state.GetComponentLookup<DestroyTimerCD>(isReadOnly: true);
			ghostOwnerLookup = state.GetComponentLookup<GhostOwner>();
			behaviourTagsLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
			playerInvincibilityLookup = state.GetComponentLookup<PlayerInvincibilityCD>(isReadOnly: true);
			physicsMassLookup = state.GetComponentLookup<PhysicsMass>(isReadOnly: true);
			weaponSkillMultiplierLookup = state.GetComponentLookup<WeaponSkillMultiplierCD>(isReadOnly: true);
			shieldLookup = state.GetComponentLookup<ShieldCD>(isReadOnly: true);
			ghostEffectEventBufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>();
			ghostEffectEventBufferPointerLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
			newConditionsBufferLookup = state.GetBufferLookup<NewConditionsBuffer>();
			removeConditionsBufferLookup = state.GetBufferLookup<RemoveConditionsBuffer>();
			lastAttackerlookup = state.GetComponentLookup<LastAttackerCD>();
			tookDamageStateLookup = state.GetComponentLookup<TookDamageStateCD>(isReadOnly: true);
			sleepStateLookup = state.GetComponentLookup<SleepStateCD>(isReadOnly: true);
			animationBufferLookup = state.GetBufferLookup<AnimationBuffer>();
			animationBufferPointerLookup = state.GetComponentLookup<AnimationBufferPointer>();
			reduceDurabilityOfAllEquipmentTriggerLookup = state.GetComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD>();
			godModeLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
			inventoryChangeBuffer = state.GetBufferLookup<InventoryChangeBuffer>();
			equipmentLookup = state.GetComponentLookup<EquipmentCD>(isReadOnly: true);
			soulsMaskLookup = state.GetComponentLookup<CollectedAndEnabledSoulsMask>(isReadOnly: true);
			dealDamageToEntityBuffer = state.GetBufferLookup<DealDamageToEntityBuffer>();
			containedObjectsBuffer = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			receivedPushbackLookup = state.GetComponentLookup<ReceivedPushbackCD>();
			moveToPredictedByCombatInteractionLookup = state.GetComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD>();
			moveToPredictedByPushbackLookup = state.GetComponentLookup<MoveToPredictedByPushbackCD>();
			newCombatantsBufferLookup = state.GetBufferLookup<NewCombatantsBuffer>(isReadOnly: true);
			this.tickRate = (uint)tickRate;
			serverSeedCD = state.GetSingleton<ServerSeedCD>();
			worldInfo = state.GetSingleton<WorldInfoCD>();
			conditionsTableCD = state.GetSingleton<ConditionsTableCD>();
			databaseBank = state.GetSingleton<PugDatabase.DatabaseBankCD>();
			inventoryChangeBufferEntity = state.GetSingletonEntity<InventoryChangeBuffer>();
			networkTimeQuery = state.GetEntityQuery(ComponentType.ReadOnly<NetworkTime>());
			physicsWorldQuery = state.GetEntityQuery(ComponentType.ReadOnly<PhysicsWorldSingleton>());
			physicsWorldHistoryQuery = state.GetEntityQuery(ComponentType.ReadOnly<PhysicsWorldHistorySingleton>());
			worldInfoQuery = state.GetEntityQuery(ComponentType.ReadOnly<WorldInfoCD>());
			mortarProjectileDamageEffectLookup = state.GetComponentLookup<MortarProjectileDamageEffectCD>(isReadOnly: true);
			piercingProjectileLookup = state.GetComponentLookup<PiercingProjectileCD>();
			projectileLookup = state.GetComponentLookup<ProjectileCD>();
			rootLookup = state.GetComponentLookup<RootCD>(isReadOnly: true);
			mineableLookup = state.GetComponentLookup<MineableCD>(isReadOnly: true);
			playerGraveLookup = state.GetComponentLookup<PlayerGraveCD>(isReadOnly: true);
			attackableWithMeleeLookup = state.GetComponentLookup<AttackableWithMeleeCD>(isReadOnly: true);
			merchantLookup = state.GetComponentLookup<MerchantCD>(isReadOnly: true);
			entityDestroyedLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			dropAllItemsOnHitLookup = state.GetComponentLookup<DropAllItemsOnHitCD>(isReadOnly: true);
		}

		public void Update(ref SystemState state, NetworkTick serverTick, uint tickRate)
		{
			currentTick = serverTick;
			startServerTick = serverTick;
			startServerTick.Increment();
			ticksPerSecond = tickRate;
			isServer = state.WorldUnmanaged.IsServer();
			isFirstTimeFullyPredictingTick = networkTimeQuery.GetSingleton<NetworkTime>().IsFirstTimeFullyPredictingTick;
			physicsWorld = physicsWorldQuery.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld;
			worldInfo = worldInfoQuery.GetSingleton<WorldInfoCD>();
			physicsWorldHistory = physicsWorldHistoryQuery.GetSingleton<PhysicsWorldHistorySingleton>();
			interpolationDelayLookup.Update(ref state);
			localTransformLookup.Update(ref state);
			objectDataLookup.Update(ref state);
			entityPartLookup.Update(ref state);
			factionLookup.Update(ref state);
			indestructibleLookup.Update(ref state);
			tileLookup.Update(ref state);
			pseudoTileLookup.Update(ref state);
			ownerLookup.Update(ref state);
			bossLookup.Update(ref state);
			tagsLookup.Update(ref state);
			critterLookup.Update(ref state);
			minionLookup.Update(ref state);
			healthLookup.Update(ref state);
			manaLookup.Update(ref state);
			magicBarrierLookup.Update(ref state);
			enemyLookup.Update(ref state);
			immuneToRangeDamageLookup.Update(ref state);
			requiresDrillLookup.Update(ref state);
			healthChangeBufferLookup.Update(ref state);
			immuneToPushBackLookup.Update(ref state);
			cantBeAttackedLookup.Update(ref state);
			explosionLookup.Update(ref state);
			explodeStateLookup.Update(ref state);
			summarizedConditionsBufferLookup.Update(ref state);
			summarizedConditionEffectsBufferLookup.Update(ref state);
			petLookup.Update(ref state);
			petOwnerLookup.Update(ref state);
			cattleLookup.Update(ref state);
			ignoreImmuneLookup.Update(ref state);
			snakeMovementStateLookup.Update(ref state);
			physicsVelocityAccessor.Update(ref state);
			damageReductionLookup.Update(ref state);
			drillLookup.Update(ref state);
			tileAccessor.Update(ref state);
			objectTypeLookup.Update(ref state);
			destructibleLookup.Update(ref state);
			propertiesLookup.Update(ref state);
			mortarProjectileLookup.Update(ref state);
			phaseTransitionStateLookup.Update(ref state);
			simulateLookup.Update(ref state);
			dontCountAsHitLookup.Update(ref state);
			attackContinuouslyLookup.Update(ref state);
			lastDamageTakenTimeLookup.Update(ref state);
			randomLookup.Update(ref state);
			playerAttackLookup.Update(ref state);
			playerGhostLookup.Update(ref state);
			playerStateLookup.Update(ref state);
			summarizeConiditionsLookup.Update(ref state);
			objectCategoryTagsLookup.Update(ref state);
			ghostInstanceLookup.Update(ref state);
			conditionsBufferLookup.Update(ref state);
			useOffHandStateLookup.Update(ref state);
			animationBufferLookup.Update(ref state);
			animationBufferPointerLookup.Update(ref state);
			animationOrientationLookup.Update(ref state);
			immuneToDamageLookup.Update(ref state);
			destroyTimerLookup.Update(ref state);
			ghostOwnerLookup.Update(ref state);
			behaviourTagsLookup.Update(ref state);
			playerInvincibilityLookup.Update(ref state);
			physicsMassLookup.Update(ref state);
			weaponSkillMultiplierLookup.Update(ref state);
			shieldLookup.Update(ref state);
			ghostEffectEventBufferLookup.Update(ref state);
			ghostEffectEventBufferPointerLookup.Update(ref state);
			newConditionsBufferLookup.Update(ref state);
			removeConditionsBufferLookup.Update(ref state);
			lastAttackerlookup.Update(ref state);
			tookDamageStateLookup.Update(ref state);
			sleepStateLookup.Update(ref state);
			reduceDurabilityOfAllEquipmentTriggerLookup.Update(ref state);
			godModeLookup.Update(ref state);
			inventoryChangeBuffer.Update(ref state);
			equipmentLookup.Update(ref state);
			dealDamageToEntityBuffer.Update(ref state);
			containedObjectsBuffer.Update(ref state);
			receivedPushbackLookup.Update(ref state);
			moveToPredictedByCombatInteractionLookup.Update(ref state);
			moveToPredictedByPushbackLookup.Update(ref state);
			newCombatantsBufferLookup.Update(ref state);
			soulsMaskLookup.Update(ref state);
			mortarProjectileDamageEffectLookup.Update(ref state);
			piercingProjectileLookup.Update(ref state);
			projectileLookup.Update(ref state);
			rootLookup.Update(ref state);
			mineableLookup.Update(ref state);
			playerGraveLookup.Update(ref state);
			attackableWithMeleeLookup.Update(ref state);
			merchantLookup.Update(ref state);
			entityDestroyedLookup.Update(ref state);
			dropAllItemsOnHitLookup.Update(ref state);
		}

		public LocalTransform GetLocalTransform(Entity entity)
		{
			return localTransformLookup[entity];
		}

		public PhysicsVelocity GetVelocity(Entity entity)
		{
			return physicsVelocityAccessor[entity];
		}

		public void SetVelocity(Entity entity, PhysicsVelocity velocity)
		{
			physicsVelocityAccessor[entity] = velocity;
		}

		public TileAccessor GetTileAccessor()
		{
			return tileAccessor;
		}

		public bool Attack(EntityCommandBuffer ecb, in Parameters p)
		{
			NativeList<HitInfo> hits = new NativeList<HitInfo>(Allocator.Temp);
			bool result = AttackInternal(ecb, ref hits, in p);
			hits.Dispose();
			return result;
		}

		public bool Attack(EntityCommandBuffer ecb, in Parameters p, out float3 hitPosition)
		{
			NativeList<HitInfo> hits = new NativeList<HitInfo>(Allocator.Temp);
			bool result = AttackInternal(ecb, ref hits, in p);
			hitPosition = ((hits.Length > 0) ? hits[0].position : default(float3));
			hits.Dispose();
			return result;
		}

		public bool Attack(EntityCommandBuffer ecb, in Parameters p, out float3 hitPosition, out Entity hitEntity)
		{
			NativeList<HitInfo> hits = new NativeList<HitInfo>(Allocator.Temp);
			bool result = AttackInternal(ecb, ref hits, in p);
			hitPosition = ((hits.Length > 0) ? hits[0].position : default(float3));
			hitEntity = ((hits.Length > 0) ? hits[0].entity : Entity.Null);
			hits.Dispose();
			return result;
		}

		public bool Attack(EntityCommandBuffer ecb, ref NativeList<float3> hitPositions, in Parameters p)
		{
			NativeList<HitInfo> hits = new NativeList<HitInfo>(Allocator.Temp);
			bool result = AttackInternal(ecb, ref hits, in p);
			for (int i = 0; i < hits.Length; i++)
			{
				HitInfo hitInfo = hits[i];
				hitPositions.Add(in hitInfo.position);
			}
			hits.Dispose();
			return result;
		}

		public bool Attack(EntityCommandBuffer ecb, ref NativeList<int2> tileHitPositions, in Parameters p)
		{
			NativeList<HitInfo> hits = new NativeList<HitInfo>(Allocator.Temp);
			bool result = AttackInternal(ecb, ref hits, in p);
			for (int i = 0; i < hits.Length; i++)
			{
				HitInfo hitInfo = hits[i];
				tileHitPositions.Add(in hitInfo.tilePosition);
			}
			hits.Dispose();
			return result;
		}

		private bool AttackInternal(EntityCommandBuffer ecb, ref NativeList<HitInfo> hits, in Parameters p)
		{
			if (!localTransformLookup.HasComponent(p.attacker))
			{
				return false;
			}
			bool hitSomething = false;
			float3 position = localTransformLookup[p.attacker].Position;
			FactionCD attackerFaction = (factionLookup.HasComponent(p.attacker) ? factionLookup[p.attacker] : default(FactionCD));
			EntityUtility.OwnerInfo ownerInfo = EntityUtility.GetOwnerInfo(entityPartLookup, ownerLookup, summarizeConiditionsLookup, playerGhostLookup, petLookup, minionLookup, bossLookup, healthLookup, enemyLookup, p.attacker);
			BehaviourTagsCD behaviourTags = p.behaviourTags;
			if (p.canOnlyAttackType != CanOnlyAttackType.Object && attackerFaction.CanAttack(new FactionCD
			{
				faction = FactionID.Player,
				originalFaction = FactionID.Player,
				pvpTeam = -2
			}, worldInfo) && !BehaviourTagsCD.CantAttack(behaviourTags, ObjectCategoryTag.Player))
			{
				NetworkTick endServerTick = startServerTick;
				if (p.attackTime > 0f)
				{
					endServerTick.Add((uint)math.ceil(p.attackTime * (float)ticksPerSecond));
				}
				if (!ghostInstanceLookup.TryGetComponent(p.attacker, out var componentData))
				{
					return false;
				}
				SpawnedGhost spawnedGhost = componentData;
				if (!p.isPredicted)
				{
					if (playerHitLookup.ContainsKey(spawnedGhost))
					{
						hitSomething = true;
						HitInfo value = new HitInfo
						{
							entity = Entity.Null,
							position = position
						};
						hits.Add(in value);
					}
					else if ((p.playerDamage > 0 || p.performAttackEvenIfZeroDamage) && (p.ignoreLastPlayerHit || !lastPlayerHit.ContainsKey(spawnedGhost) || startServerTick.IsNewerThan(lastPlayerHit[spawnedGhost])))
					{
						if (!isServer)
						{
							return false;
						}
						AttackPlayerServer.Attack(ecb, spawnedGhost, startServerTick, endServerTick, position, p.attacker, p.attackOffset, p.isRanged, ownerInfo.isBoss, ownerInfo.isMinion, ownerInfo.isPet, p.isStatic, p.radius, p.boxHalfHorizontalWidth, p.boxHalfVerticalWidth, p.rotation, p.playerDamage, p.damageEffectType, p.castDirection, p.useDefaultCastDistanceForRpcAttack ? 0f : p.castDistance, p.reverseDamage, p.pushback, p.reversePushback, p.triggerAnimationOnClientHit, p.checkVisibility, p.isExplosive, p.isExplosiveDamageFromBomb);
					}
				}
			}
			if (p.damage == 0 && !p.performAttackEvenIfZeroDamage)
			{
				return hitSomething;
			}
			uint num = 4294840287u;
			if (!p.canHitLowTriggers)
			{
				num &= 0xFFFFF9FFu;
			}
			if (p.isRanged || p.cannotHitTriggersOrLowObjects)
			{
				num &= 0xFFFDFEBFu;
			}
			CollisionFilter collisionFilter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = num
			};
			NativeArray<SummarizedConditionsBuffer> attackerConditions = default(NativeArray<SummarizedConditionsBuffer>);
			if (summarizedConditionsBufferLookup.HasComponent(ownerInfo.attacker))
			{
				attackerConditions = summarizedConditionsBufferLookup[ownerInfo.attacker].AsNativeArray();
			}
			NativeArray<SummarizedConditionEffectsBuffer> attackerConditionEffects = default(NativeArray<SummarizedConditionEffectsBuffer>);
			if (summarizedConditionEffectsBufferLookup.HasComponent(ownerInfo.attacker))
			{
				attackerConditionEffects = summarizedConditionEffectsBufferLookup[ownerInfo.attacker].AsNativeArray();
			}
			NativeList<ColliderCastHit> hitList = new NativeList<ColliderCastHit>(Allocator.Temp);
			Entity entity = ((ownerInfo.immediateOwner == Entity.Null) ? ownerInfo.attacker : ownerInfo.immediateOwner);
			uint num2 = (p.isExecutedBeforePhysics ? 1u : 0u);
			uint num3 = num2;
			if (interpolationDelayLookup.TryGetComponent(entity, out var componentData2))
			{
				num2 += componentData2.Delay;
			}
			physicsWorldHistory.GetCollisionWorldFromTick(currentTick, num2, ref physicsWorld, out var collWorld);
			CheckForHit(ownerInfo, ecb, ref hits, in p, in collWorld, position, collisionFilter, attackerFaction, ownerInfo, behaviourTags, in attackerConditions, in attackerConditionEffects, num2 != num3, onlyHitPlayers: false, ref hitList, out var gainSkill, ref hitSomething);
			if (num2 != num3)
			{
				num2 = 0u;
				physicsWorldHistory.GetCollisionWorldFromTick(currentTick, num2, ref physicsWorld, out collWorld);
				CheckForHit(ownerInfo, ecb, ref hits, in p, in collWorld, position, collisionFilter, attackerFaction, ownerInfo, behaviourTags, in attackerConditions, in attackerConditionEffects, ignorePlayers: false, onlyHitPlayers: true, ref hitList, out var gainSkill2, ref hitSomething);
				gainSkill = gainSkill || gainSkill2;
			}
			if (gainSkill)
			{
				Entity minionOwner = ownerInfo.minionOwner;
				Entity playerOwner = ownerInfo.playerOwner;
				if (minionOwner != Entity.Null)
				{
					if (playerOwner != Entity.Null)
					{
						PlayerController.AddSkill(playerOwner, SkillID.Summoning, 1, ecb, isServer);
					}
				}
				else if (playerOwner != Entity.Null && !p.isExplosive)
				{
					int amount = 1;
					if (weaponSkillMultiplierLookup.TryGetComponent(p.attacker, out var componentData3))
					{
						amount = (int)math.round(componentData3.skillMultiplier);
					}
					SkillID skillID = (p.isMagic ? SkillID.Magic : (p.isRanged ? SkillID.Range : SkillID.Melee));
					PlayerController.AddSkill(playerOwner, skillID, amount, ecb, isServer);
				}
				else if (playerOwner != Entity.Null && p.isExplosive)
				{
					PlayerController.AddSkill(playerOwner, SkillID.Explosives, 1, ecb, isServer);
				}
			}
			hitList.Dispose();
			return hitSomething;
		}

		private void CheckForHit(EntityUtility.OwnerInfo ownerInfo, EntityCommandBuffer ecb, ref NativeList<HitInfo> hits, in Parameters p, in CollisionWorld collisionWorld, float3 position, CollisionFilter collisionFilter, FactionCD attackerFaction, EntityUtility.OwnerInfo attackOwnerInfo, BehaviourTagsCD behaviourTags, in NativeArray<SummarizedConditionsBuffer> attackerConditions, in NativeArray<SummarizedConditionEffectsBuffer> attackerConditionEffects, bool ignorePlayers, bool onlyHitPlayers, ref NativeList<ColliderCastHit> hitList, out bool gainSkill, ref bool hitSomething)
		{
			bool flag = ((!(p.boxHalfHorizontalWidth > 0f)) ? collisionWorld.SphereCastAll(position + p.attackOffset, p.radius, p.castDirection, p.castDistance, ref hitList, collisionFilter) : collisionWorld.BoxCastAll(position + p.attackOffset, p.rotation, new float3(p.boxHalfHorizontalWidth, 1f, p.boxHalfVerticalWidth), p.castDirection, p.castDistance, ref hitList, collisionFilter));
			gainSkill = false;
			if (!flag)
			{
				return;
			}
			NativeParallelHashSet<Entity> nativeParallelHashSet = new NativeParallelHashSet<Entity>(hitList.Length, Allocator.Temp);
			if (p.skipHitsOnEntity != Entity.Null)
			{
				nativeParallelHashSet.Add(p.skipHitsOnEntity);
			}
			bool flag2 = p.sameFactionHealingPercentage > 0f;
			for (int i = 0; i < hitList.Length; i++)
			{
				ColliderCastHit hit = hitList[i];
				bool flag3 = false;
				bool flag4 = false;
				Entity entity = Entity.Null;
				if (entityPartLookup.HasComponent(hit.Entity))
				{
					EntityPartCD entityPartCD = entityPartLookup[hit.Entity];
					flag3 = entityPartCD.showHitFeedbackOnThisPart;
					flag4 = entityPartCD.handleImmuneToDamageOnThisPart;
					entity = hit.Entity;
					hit.Entity = entityPartCD.mainEntity;
				}
				if (nativeParallelHashSet.Contains(hit.Entity))
				{
					continue;
				}
				nativeParallelHashSet.Add(hit.Entity);
				if (!healthLookup.HasComponent(hit.Entity) || healthLookup[hit.Entity].health <= 0)
				{
					continue;
				}
				if (projectileLookup.HasComponent(hit.Entity) && ghostInstanceLookup.TryGetComponent(hit.Entity, out var componentData))
				{
					NetworkTick spawnTickForBeginECBCreatedGhost = NetworkTimeUtilities.GetSpawnTickForBeginECBCreatedGhost(in componentData, isServer);
					if (spawnTickForBeginECBCreatedGhost.IsValid && currentTick.TicksSince(spawnTickForBeginECBCreatedGhost) < NetworkTimeUtilities.SecondsToTicks(0.5f, tickRate))
					{
						continue;
					}
				}
				FactionCD targetFaction = (factionLookup.HasComponent(hit.Entity) ? factionLookup[hit.Entity] : default(FactionCD));
				bool flag5 = targetFaction.faction == attackerFaction.faction && flag2;
				if (!attackerFaction.CanAttack(targetFaction, worldInfo) && !flag5)
				{
					continue;
				}
				RefRW<RandomCD> refRWOptional = randomLookup.GetRefRWOptional(p.attacker);
				bool spawnThunderBeam;
				if (targetFaction.originalFaction == FactionID.Player && playerGhostLookup.HasComponent(hit.Entity))
				{
					if (ignorePlayers || !p.isPredicted || (p.playerDamage <= 0 && !p.performAttackEvenIfZeroDamage) || (!flag2 && (!(hit.Entity != p.attacker) || (!p.canAttackOwner && !(hit.Entity != attackOwnerInfo.immediateOwner)))))
					{
						continue;
					}
					float3 position2 = localTransformLookup[hit.Entity].Position;
					Entity entity2 = hit.Entity;
					Entity attacker = attackOwnerInfo.attacker;
					AttackPlayerSystem.RegisterPlayerHitShared registerPlayerHitShared = new AttackPlayerSystem.RegisterPlayerHitShared
					{
						ecb = ecb,
						currentTick = currentTick,
						databaseBank = databaseBank,
						physicsWorld = physicsWorld,
						physicsWorldHistory = physicsWorldHistory,
						worldInfo = worldInfo,
						conditionsTableCD = conditionsTableCD,
						isFirstTimeFullyPredictingTick = isFirstTimeFullyPredictingTick,
						tickRate = tickRate,
						inventoryChangeBufferEntity = inventoryChangeBufferEntity
					};
					AttackPlayerSystem.RegisterPlayerHitLookup registerPlayerHitLookup = new AttackPlayerSystem.RegisterPlayerHitLookup
					{
						playerStateLookup = playerStateLookup,
						summarizeConiditionsLookup = summarizeConiditionsLookup,
						factionLookup = factionLookup,
						localTransformLookup = localTransformLookup,
						objectCategoryTagsLookup = objectCategoryTagsLookup,
						entityPartLookup = entityPartLookup,
						ghostInstanceLookup = ghostInstanceLookup,
						healthLookup = healthLookup,
						objectTypeLookup = objectTypeLookup,
						summarizeConiditionsEffectsLookup = summarizedConditionEffectsBufferLookup,
						conditionsBufferLookup = conditionsBufferLookup,
						useOffHandStateLookup = useOffHandStateLookup,
						animationBufferLookup = animationBufferLookup,
						animationBufferPointerLookup = animationBufferPointerLookup,
						animationOrientationLookup = animationOrientationLookup,
						immuneToPushBackLookup = immuneToPushBackLookup,
						immuneToDamageLookup = immuneToDamageLookup,
						destroyTimerLookup = destroyTimerLookup,
						ghostOwnerLookup = ghostOwnerLookup,
						behaviourTagsLookup = behaviourTagsLookup,
						playerInvincibilityLookup = playerInvincibilityLookup,
						physicsMassLookup = physicsMassLookup,
						ghostEffectEventBufferLookup = ghostEffectEventBufferLookup,
						ghostEffectEventBufferPointerLookup = ghostEffectEventBufferPointerLookup,
						physicsVelocityLookup = physicsVelocityAccessor,
						manaLookup = manaLookup,
						magicBarrierLookup = magicBarrierLookup,
						lastDamageTakenTimeLookup = lastDamageTakenTimeLookup,
						randomLookup = randomLookup,
						mortarProjectileLookup = mortarProjectileLookup,
						ownerLookup = ownerLookup,
						objectDataLookup = objectDataLookup,
						reduceDurabilityOfAllEquipmentTriggerLookup = reduceDurabilityOfAllEquipmentTriggerLookup,
						godModeLookup = godModeLookup,
						inventoryChangeBuffer = inventoryChangeBuffer,
						equipmentLookup = equipmentLookup,
						dealDamageToEntityBuffer = dealDamageToEntityBuffer,
						containedObjectsBuffer = containedObjectsBuffer,
						receivedPushbackLookup = receivedPushbackLookup,
						moveToPredictedByCombatInteractionLookup = moveToPredictedByCombatInteractionLookup,
						moveToPredictedByPushbackLookup = moveToPredictedByPushbackLookup,
						phaseTransitionStateLookup = phaseTransitionStateLookup,
						simulateLookup = simulateLookup,
						attackContinuouslyLookup = attackContinuouslyLookup,
						playerGhostLookup = playerGhostLookup,
						mortarProjectileDamageEffectLookup = mortarProjectileDamageEffectLookup,
						piercingProjectileLookup = piercingProjectileLookup,
						petLookup = petLookup,
						projectileLookup = projectileLookup,
						minionLookup = minionLookup,
						bossLookup = bossLookup,
						enemyLookup = enemyLookup
					};
					if (AttackPlayerSystem.RegisterPlayerHit(entity2, attacker, in registerPlayerHitShared, in registerPlayerHitLookup, p.attacker, position, position, position2, tileAccessor, p.playerDamage, p.damageEffectType, p.castDirection, p.reverseDamage, ref refRWOptional.ValueRW.Value, p.pushback, p.reversePushback, p.isExplosive, p.isExplosiveDamageFromBomb, out spawnThunderBeam, p.triggerAnimationOnClientHit, p.isRanged, attackOwnerInfo.isBoss, attackOwnerInfo.isMinion, attackOwnerInfo.isPet, p.treatDodgeAsHit, p.checkVisibility))
					{
						HitInfo value = new HitInfo
						{
							entity = hit.Entity,
							position = hit.Position,
							tilePosition = localTransformLookup[hit.Entity].Position.RoundToInt2()
						};
						hits.Add(in value);
						ownerLookup.TryGetComponent(p.attacker, out var componentData2);
						if (componentData2.owner != hit.Entity || p.playerDamage <= 0)
						{
							gainSkill = true;
						}
						hitSomething = true;
					}
				}
				else
				{
					if (onlyHitPlayers)
					{
						continue;
					}
					bool flag6 = enemyLookup.HasComponent(hit.Entity);
					bool flag7 = cattleLookup.HasComponent(hit.Entity);
					bool flag8 = ignoreImmuneLookup.HasComponent(hit.Entity);
					bool flag9 = BehaviourTagsCD.WantsToAttack(behaviourTags, tagsLookup[hit.Entity]);
					if ((p.canOnlyAttackType == CanOnlyAttackType.EnemyAndPlayer && (!flag6 || flag7) && !flag9) || (p.canOnlyAttackType == CanOnlyAttackType.Object && flag6))
					{
						continue;
					}
					float3 position3 = localTransformLookup[hit.Entity].Position;
					if ((!flag8 && !flag6 && tileAccessor.HasType(position3.RoundToInt2(), TileType.immune)) || (!flag2 && (hit.Entity == p.attacker || hit.Entity == attackOwnerInfo.attacker || (snakeMovementStateLookup.HasComponent(hit.Entity) && snakeMovementStateLookup.HasComponent(p.attacker) && snakeMovementStateLookup[hit.Entity].headRef == p.attacker))) || !objectDataLookup.HasComponent(hit.Entity) || indestructibleLookup.HasAndIsComponentEnabled(hit.Entity) || tileLookup.HasComponent(hit.Entity) || (attackOwnerInfo.playerOwner == Entity.Null && cantBeAttackedLookup.HasComponent(hit.Entity)) || critterLookup.HasComponent(hit.Entity))
					{
						continue;
					}
					ObjectID objectID = objectDataLookup[hit.Entity].objectID;
					if (objectID == ObjectID.Player || objectID == p.cantHitSpecificObject)
					{
						continue;
					}
					FixedList32Bytes<ObjectID> cantHitSpecificObjects = p.cantHitSpecificObjects;
					if (cantHitSpecificObjects.Length > 0)
					{
						bool flag10 = false;
						foreach (ObjectID cantHitSpecificObject in p.cantHitSpecificObjects)
						{
							if (objectID == cantHitSpecificObject)
							{
								flag10 = true;
								break;
							}
						}
						if (flag10)
						{
							continue;
						}
					}
					if ((p.cantHitObjectsHangingOnWalls && propertiesLookup.HasComponent(hit.Entity) && propertiesLookup[hit.Entity].Has(-1171081164)) || (BehaviourTagsCD.CantAttack(behaviourTags, tagsLookup[hit.Entity]) && !flag5) || (p.checkVisibility && RayCastIsBlocked(collisionWorld, hit, p, position)) || (p.canOnlyHitCertainNonEnemyObjects && !EntityUtility.EntityIsValidEnemyToDamage(hit.Entity, enemyLookup, merchantLookup, propertiesLookup, entityDestroyedLookup, healthLookup, playerGhostLookup) && !EntityUtility.EvaluateCanOnlyHitCertainObjects(hit.Entity, damagedByMiningTool: false, tileLookup, objectCategoryTagsLookup, rootLookup, destructibleLookup, mineableLookup, playerGraveLookup, attackableWithMeleeLookup)))
					{
						continue;
					}
					int baseDamage = p.damage;
					if (requiresDrillLookup.HasComponent(hit.Entity) && p.instantlyDestroyObjectsRequiringDrills)
					{
						baseDamage = int.MaxValue;
					}
					if (!dontCountAsHitLookup.HasComponent(hit.Entity))
					{
						hitSomething = true;
					}
					hits.Add(new HitInfo
					{
						entity = hit.Entity,
						position = hit.Position,
						tilePosition = localTransformLookup[hit.Entity].Position.RoundToInt2()
					});
					if (moveToPredictedByCombatInteractionLookup.HasComponent(hit.Entity))
					{
						moveToPredictedByCombatInteractionLookup.GetRefRW(hit.Entity).ValueRW.SetLastInteractionTick(startServerTick);
					}
					immuneToDamageLookup.TryGetComponent(flag4 ? entity : hit.Entity, out var componentData3);
					bool flag11 = componentData3.Value == ImmuneToDamageState.Immune;
					if (flag11 || PlayerController.IsDamageBlockedByEnemy(hit.Entity, p.isRanged, p.isExplosive, p.castDirection, p.attacker, animationOrientationLookup, localTransformLookup, shieldLookup))
					{
						Entity entity3 = (flag3 ? entity : hit.Entity);
						if (ghostEffectEventBufferLookup.TryGetBuffer(attackOwnerInfo.attacker, out var bufferData))
						{
							RefRW<GhostEffectEventBufferPointerCD> refRW = ghostEffectEventBufferPointerLookup.GetRefRW(attackOwnerInfo.attacker);
							if (flag11 && componentData3.effectIDOverride != EffectID.None)
							{
								DynamicBuffer<GhostEffectEventBuffer> buffer = bufferData;
								ref GhostEffectEventBufferPointerCD valueRW = ref refRW.ValueRW;
								GhostEffectEventBuffer item = new GhostEffectEventBuffer
								{
									Tick = startServerTick,
									value = new EffectEventCD
									{
										entity = entity3,
										effectID = componentData3.effectIDOverride
									}
								};
								buffer.AddToRingBuffer(ref valueRW, in item);
							}
							else
							{
								DynamicBuffer<GhostEffectEventBuffer> buffer2 = bufferData;
								ref GhostEffectEventBufferPointerCD valueRW2 = ref refRW.ValueRW;
								GhostEffectEventBuffer item = new GhostEffectEventBuffer
								{
									Tick = startServerTick,
									value = new EffectEventCD
									{
										entity = entity3,
										effectID = EffectID.Parry,
										value1 = 1,
										entity2 = p.attacker
									}
								};
								buffer2.AddToRingBuffer(ref valueRW2, in item);
							}
						}
						continue;
					}
					if (dropAllItemsOnHitLookup.TryGetComponent(hit.Entity, out var componentData4))
					{
						float3 position4 = position3 + componentData4.dropOffset;
						inventoryChangeBuffer[inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
						{
							playerEntity = attackOwnerInfo.playerOwner,
							inventoryChangeData = Create.DropAllItems(hit.Entity, position4, default(Entity), randomOffset: true)
						});
					}
					NativeArray<SummarizedConditionEffectsBuffer> receiverConditionsEffects = default(NativeArray<SummarizedConditionEffectsBuffer>);
					bool flag12 = summarizedConditionEffectsBufferLookup.HasComponent(hit.Entity);
					if (flag12)
					{
						receiverConditionsEffects = summarizedConditionEffectsBufferLookup[hit.Entity].AsNativeArray();
					}
					NativeArray<SummarizedConditionsBuffer> receiverConditions = default(NativeArray<SummarizedConditionsBuffer>);
					if (summarizeConiditionsLookup.HasBuffer(hit.Entity))
					{
						receiverConditions = summarizeConiditionsLookup[hit.Entity].AsNativeArray();
					}
					bool receiverIsBoss = bossLookup.HasComponent(hit.Entity);
					bool receiverIsPlayer = playerGhostLookup.HasComponent(hit.Entity);
					ObjectTypeCD objectType = (objectTypeLookup.HasComponent(hit.Entity) ? objectTypeLookup[hit.Entity] : default(ObjectTypeCD));
					bool flag13 = destructibleLookup.HasComponent(hit.Entity);
					HealthCD receiverHealth = (healthLookup.HasComponent(hit.Entity) ? healthLookup[hit.Entity] : default(HealthCD));
					NativeList<ConditionData> appliedConditions = new NativeList<ConditionData>(Allocator.Temp);
					NativeList<ConditionData> appliedConditionsOnAttacker = new NativeList<ConditionData>(Allocator.Temp);
					NativeList<ConditionID> removedConditions = new NativeList<ConditionID>(Allocator.Temp);
					NativeList<ConditionID> removedConditionsFromAttacker = new NativeList<ConditionID>(Allocator.Temp);
					Unity.Mathematics.Random rngFromEntity = PugRandom.GetRngFromEntity(serverSeedCD.Value, startServerTick, hit.Entity);
					ref Unity.Mathematics.Random reference = ref refRWOptional.IsValid ? ref refRWOptional.ValueRW.Value : ref rngFromEntity;
					bool didCrit = false;
					bool didDodge = false;
					bool flag14 = false;
					int attackerHealthChange = 0;
					int ownerHealthChange = 0;
					int attackerManaChange = 0;
					bool recieverIsImmuneToRange = immuneToRangeDamageLookup.HasComponent(hit.Entity);
					bool spawnOctopusBossProjectile = false;
					bool spawnScarabBossProjectile = false;
					int num;
					if (flag5)
					{
						baseDamage = -(int)math.round((float)receiverHealth.GetMaxHealthWithConditions(flag12 ? summarizedConditionEffectsBufferLookup[hit.Entity] : default(DynamicBuffer<SummarizedConditionEffectsBuffer>)) * p.sameFactionHealingPercentage);
						num = baseDamage;
					}
					else
					{
						Entity playerOwner = attackOwnerInfo.playerOwner;
						HealthCD attackerHealth = (healthLookup.HasComponent(playerOwner) ? healthLookup[playerOwner] : default(HealthCD));
						ManaCD attackerMana = (manaLookup.HasComponent(playerOwner) ? manaLookup[playerOwner] : default(ManaCD));
						MagicBarrierCD attackerBarrier = (magicBarrierLookup.HasComponent(playerOwner) ? magicBarrierLookup[playerOwner] : default(MagicBarrierCD));
						PhaseTransitionStateCD receiverPhaseTransitionState = (phaseTransitionStateLookup.HasComponent(hit.Entity) ? phaseTransitionStateLookup[hit.Entity] : default(PhaseTransitionStateCD));
						bool flag15 = godModeLookup.HasComponent(playerOwner) && godModeLookup.IsComponentEnabled(playerOwner);
						PlayerStateCD componentData5;
						bool receiverIsInMinecart = playerStateLookup.TryGetComponent(hit.Entity, out componentData5) && componentData5.HasAnyState(PlayerStateEnum.MinecartRiding);
						baseDamage = EntityUtility.CalculateDamage(ownerInfo, attackerConditions, attackerConditionEffects, receiverConditions, receiverConditionsEffects, ref reference, baseDamage, p.isRanged, p.isMagic, isDigging: false, isReverseDamage: false, attackOwnerInfo.isBoss, attackOwnerInfo.isMinion, attackOwnerInfo.isPet, receiverIsBoss, receiverIsPlayer, recieverIsImmuneToRange, attackWoundup: false, objectType, flag13, receiverIsInMinecart, p.isExplosive, receiverHealth, attackerHealth, attackerMana, attackerBarrier, attackerFaction, out didCrit, appliedConditions, appliedConditionsOnAttacker, removedConditions, removedConditionsFromAttacker, receiverPhaseTransitionState, out didDodge, out attackerHealthChange, out ownerHealthChange, out attackerManaChange, out spawnThunderBeam, out spawnOctopusBossProjectile, out spawnScarabBossProjectile, out var _, out var _, 0, flag15);
						num = baseDamage;
						if (damageReductionLookup.HasComponent(hit.Entity) && !flag15)
						{
							bool isDamagedByDrill = drillLookup.HasComponent(attackOwnerInfo.attacker);
							num = damageReductionLookup[hit.Entity].GetDamageDealt(baseDamage, p.bypassDamageReduction, p.bypassMaxDamagePerHit, isDamagedByDrill);
							if (num <= 0 && !p.performAttackEvenIfZeroDamage)
							{
								continue;
							}
						}
					}
					if (targetFaction.faction != FactionID.None && targetFaction.faction != FactionID.Merchant && num > 0)
					{
						gainSkill = true;
					}
					bool flag16 = baseDamage < 0;
					EcbInternal(ecb, healthChangeBufferEntity, physicsVelocityAccessor, localTransformLookup, attackOwnerInfo, p.attackOffset, num, p.bypassMaxDamagePerHit, p.bypassDamageReduction, p.skipWallAndRootsLootDropOnDestroy, p.skipLootDropOnDestroy, p.skipLootDropIfDestroyPlants, p.pushback, p.reversePushback, explosionLookup.HasComponent(attackOwnerInfo.attacker), hit, immuneToPushBackLookup, ownerLookup, enemyLookup, lastAttackerlookup, healthChangeBufferLookup, playerGhostLookup, healthLookup, minionLookup, tookDamageStateLookup, sleepStateLookup, animationBufferLookup, animationBufferPointerLookup, receivedPushbackLookup, moveToPredictedByCombatInteractionLookup, moveToPredictedByPushbackLookup, dontCountAsHitLookup, currentTick, tickRate);
					if (receiverConditionsEffects.IsCreated)
					{
						for (int j = 0; j < appliedConditions.Length; j++)
						{
							newConditionsBufferLookup[hit.Entity].Add(new NewConditionsBuffer
							{
								conditionData = appliedConditions[j]
							});
						}
						for (int k = 0; k < removedConditions.Length; k++)
						{
							removeConditionsBufferLookup[hit.Entity].Add(new RemoveConditionsBuffer
							{
								conditionId = removedConditions[k]
							});
						}
						Entity entity4 = (ghostEffectEventBufferLookup.HasBuffer(attackOwnerInfo.attacker) ? attackOwnerInfo.attacker : hit.Entity);
						if (!flag16 && (!p.performAttackEvenIfZeroDamage || num != 0) && objectType.Value != ObjectType.PlaceablePrefab && !flag13 && ghostEffectEventBufferLookup.HasBuffer(entity4) && baseDamage != int.MaxValue)
						{
							Entity entity5 = (flag3 ? entity : hit.Entity);
							RefRW<GhostEffectEventBufferPointerCD> refRW2 = ghostEffectEventBufferPointerLookup.GetRefRW(entity4);
							ghostEffectEventBufferLookup[entity4].AddToRingBuffer(ref refRW2.ValueRW, new GhostEffectEventBuffer
							{
								Tick = currentTick,
								value = new EffectEventCD
								{
									entity = entity5,
									effectID = (didDodge ? EffectID.Dodge : (flag14 ? EffectID.Parry : (didCrit ? EffectID.CritNumber : EffectID.WhiteDamageNumber))),
									value1 = num,
									value2 = (int)p.damageEffectType,
									entity2 = attackOwnerInfo.attacker
								}
							});
						}
					}
					if (attackerConditionEffects.IsCreated && attackOwnerInfo.entityToBeAffectedByConditionChanges != Entity.Null)
					{
						for (int l = 0; l < appliedConditionsOnAttacker.Length; l++)
						{
							newConditionsBufferLookup[attackOwnerInfo.entityToBeAffectedByConditionChanges].Add(new NewConditionsBuffer
							{
								conditionData = appliedConditionsOnAttacker[l]
							});
						}
						for (int m = 0; m < removedConditionsFromAttacker.Length; m++)
						{
							removeConditionsBufferLookup[attackOwnerInfo.entityToBeAffectedByConditionChanges].Add(new RemoveConditionsBuffer
							{
								conditionId = removedConditionsFromAttacker[m]
							});
						}
					}
					if (newCombatantsBufferLookup.HasBuffer(attackOwnerInfo.immediateOwner))
					{
						ecb.AppendToBuffer(attackOwnerInfo.immediateOwner, new NewCombatantsBuffer
						{
							Target = hit.Entity
						});
					}
					attackerHealthChange -= p.reverseDamage;
					if (attackerHealthChange != 0 && healthChangeBufferLookup.HasComponent(attackOwnerInfo.attacker))
					{
						healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
						{
							healthChange = new HealthChange
							{
								entity = attackOwnerInfo.attacker,
								amount = attackerHealthChange,
								bypassMaxDamagePerHit = false,
								skipWallAndRootsLootDropOnDestroy = true,
								causedByEntity = hit.Entity
							}
						});
						attackerHealthChange += p.reverseDamage;
						if (attackerHealthChange != 0 && ghostEffectEventBufferLookup.HasBuffer(attackOwnerInfo.attacker))
						{
							RefRW<GhostEffectEventBufferPointerCD> refRW3 = ghostEffectEventBufferPointerLookup.GetRefRW(attackOwnerInfo.attacker);
							DynamicBuffer<GhostEffectEventBuffer> buffer3 = ghostEffectEventBufferLookup[attackOwnerInfo.attacker];
							ref GhostEffectEventBufferPointerCD valueRW3 = ref refRW3.ValueRW;
							GhostEffectEventBuffer item = new GhostEffectEventBuffer
							{
								Tick = startServerTick,
								value = new EffectEventCD
								{
									entity = attackOwnerInfo.attacker,
									effectID = ((attackerHealthChange > 0) ? EffectID.HealingNumber : EffectID.RedDamageNumber),
									value1 = attackerHealthChange,
									value2 = 0,
									entity2 = p.attacker
								}
							};
							buffer3.AddToRingBuffer(ref valueRW3, in item);
						}
					}
					ownerHealthChange -= p.reverseDamage;
					if (attackOwnerInfo.playerOwner != Entity.Null && ownerHealthChange != 0)
					{
						healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
						{
							healthChange = new HealthChange
							{
								entity = attackOwnerInfo.playerOwner,
								amount = ownerHealthChange,
								bypassMaxDamagePerHit = false,
								skipWallAndRootsLootDropOnDestroy = true,
								causedByEntity = hit.Entity
							}
						});
						ownerHealthChange += p.reverseDamage;
						if (ownerHealthChange != 0 && ghostEffectEventBufferLookup.HasBuffer(attackOwnerInfo.playerOwner))
						{
							RefRW<GhostEffectEventBufferPointerCD> refRW4 = ghostEffectEventBufferPointerLookup.GetRefRW(attackOwnerInfo.playerOwner);
							DynamicBuffer<GhostEffectEventBuffer> buffer4 = ghostEffectEventBufferLookup[attackOwnerInfo.playerOwner];
							ref GhostEffectEventBufferPointerCD valueRW4 = ref refRW4.ValueRW;
							GhostEffectEventBuffer item = new GhostEffectEventBuffer
							{
								Tick = startServerTick,
								value = new EffectEventCD
								{
									entity = attackOwnerInfo.playerOwner,
									effectID = ((ownerHealthChange > 0) ? EffectID.HealingNumber : EffectID.RedDamageNumber),
									value1 = ownerHealthChange,
									value2 = (int)p.damageEffectType,
									entity2 = p.attacker
								}
							};
							buffer4.AddToRingBuffer(ref valueRW4, in item);
						}
					}
					if (num > 0)
					{
						Entity entity6 = attackOwnerInfo.petOwner;
						if (entity6 == Entity.Null && attackOwnerInfo.playerOwner != Entity.Null && petOwnerLookup.TryGetComponent(attackOwnerInfo.playerOwner, out var componentData6))
						{
							entity6 = componentData6.PetEntity;
						}
						if (entity6 != Entity.Null && enemyLookup.HasComponent(hit.Entity))
						{
							ecb.AppendToBuffer(entity6, new AddPetExperienceBuffer
							{
								amount = PetExtensions.GetExperienceFromDamage(num)
							});
						}
					}
					Entity entity7 = attackOwnerInfo.playerOwner;
					if (attackerManaChange != 0 && manaLookup.HasComponent(entity7))
					{
						PlayerController.ApplyPlayerManaChange(in entity7, in manaLookup, attackerManaChange);
					}
					Entity petOwner = attackOwnerInfo.petOwner;
					if (petOwner != Entity.Null && enemyLookup.HasComponent(hit.Entity) && summarizedConditionEffectsBufferLookup.TryGetBuffer(petOwner, out var bufferData2))
					{
						int value2 = bufferData2[118].value;
						if (reference.NextInt(100) < value2 && manaLookup.HasComponent(attackOwnerInfo.playerOwner))
						{
							PlayerController.ApplyPlayerManaChange(in entity7, in manaLookup, 25);
						}
					}
					if (!p.isExplosive && playerAttackLookup.TryGetComponent(attackOwnerInfo.playerOwner, out var componentData7) && (!componentData7.spawnStuffOnHitCooldown.isRunning || componentData7.spawnStuffOnHitCooldown.IsTimerElapsed(currentTick)) && isFirstTimeFullyPredictingTick)
					{
						componentData7.spawnStuffOnHitCooldown.Start(currentTick, 0.1f, tickRate);
						if (objectDataLookup.TryGetComponent(p.attacker, out var componentData8) && componentData8.objectID == ObjectID.OctopusBossPlayerProjectile)
						{
							spawnOctopusBossProjectile = false;
						}
						if (spawnOctopusBossProjectile && soulsMaskLookup[attackOwnerInfo.playerOwner].HasSoulEnabled(SoulID.SoulOfOmoroth))
						{
							EntityUtility.SpawnProjectile(ecb, hit.Position, databaseBank.databaseBankBlob, ObjectID.OctopusBossPlayerProjectile, p.damage, 0f, p.castDirection, 0f, attackOwnerInfo.playerOwner, behaviourTags, summarizedConditionsBufferLookup, attackerFaction, conditionsTableCD, refRWOptional, piercingProjectileLookup);
						}
						if (spawnScarabBossProjectile && soulsMaskLookup[attackOwnerInfo.playerOwner].HasSoulEnabled(SoulID.SoulOfScarab))
						{
							EntityUtility.SpawnProjectile(ecb, localTransformLookup[attackOwnerInfo.playerOwner].Position, databaseBank.databaseBankBlob, ObjectID.ScarabBossPlayerProjectile, (int)math.round((float)p.damage * 2f), 0f, p.castDirection, 0f, attackOwnerInfo.playerOwner, behaviourTags, summarizedConditionsBufferLookup, attackerFaction, conditionsTableCD, refRWOptional, piercingProjectileLookup, 0, 1f, hit.Entity);
						}
					}
					appliedConditions.Dispose();
					appliedConditionsOnAttacker.Dispose();
					removedConditions.Dispose();
					removedConditionsFromAttacker.Dispose();
				}
			}
			nativeParallelHashSet.Dispose();
		}

		private static void EcbInternal(EntityCommandBuffer ecb, Entity healthChangeBufferEntity, ComponentLookup<PhysicsVelocity> physicsVelocityLookup, ComponentLookup<LocalTransform> translationLookup, EntityUtility.OwnerInfo ownerInfo, float3 attackOffset, int damage, bool bypassMaxDamagePerHit, bool bypassDamageReduction, bool skipWallAndRootsLootDropOnDestroy, bool skipLootDropOnDestroy, bool skipLootDropIfDestroyPlants, float pushback, float reversePushback, bool damagedByExplosion, ColliderCastHit hit, ComponentLookup<ImmuneToPushBackCD> immuneToPushBackLookup, ComponentLookup<OwnerReferenceCD> ownerLookup, ComponentLookup<EnemyCD> enemyLookup, ComponentLookup<LastAttackerCD> lastAttackerlookup, BufferLookup<HealthChangeBuffer> healthChangeBufferLookup, ComponentLookup<PlayerGhost> playerGhostLookup, ComponentLookup<HealthCD> healthLookup, ComponentLookup<MinionCD> minionLookup, ComponentLookup<TookDamageStateCD> tookDamageStateLookup, ComponentLookup<SleepStateCD> sleepStateLookup, BufferLookup<AnimationBuffer> animationBufferLookup, ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup, ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup, ComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD> moveToPredictedByCombatInteractionLookup, ComponentLookup<MoveToPredictedByPushbackCD> moveToPredictedByPushbackLookup, ComponentLookup<DontCountAsHitForAttackerCD> dontCountAsHitLookup, NetworkTick currentTick, uint tickRate)
		{
			bool flag = false;
			Entity attacker = ownerInfo.attacker;
			if (pushback != 0f && physicsVelocityLookup.HasComponent(hit.Entity) && !immuneToPushBackLookup.HasComponent(hit.Entity))
			{
				flag = true;
				float3 x = math.normalizesafe(hit.Position - (translationLookup[attacker].Position + attackOffset)) * pushback;
				EntityUtility.TryAddPushback(hit.Entity, x.ToFloat2(), currentTick, tickRate, immuneToPushBackLookup, receivedPushbackLookup, moveToPredictedByPushbackLookup);
				if (moveToPredictedByCombatInteractionLookup.HasComponent(hit.Entity))
				{
					moveToPredictedByCombatInteractionLookup.GetRefRW(hit.Entity).ValueRW.SetLastInteractionTick(currentTick);
				}
			}
			healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
			{
				healthChange = new HealthChange
				{
					entity = hit.Entity,
					amount = -damage,
					bypassMaxDamagePerHit = bypassMaxDamagePerHit,
					skipWallAndRootsLootDropOnDestroy = skipWallAndRootsLootDropOnDestroy,
					skipLootDropOnDestroy = skipLootDropOnDestroy,
					skipLootDropIfDestroyPlants = skipLootDropIfDestroyPlants,
					causedByEntity = attacker,
					wasKnockedBack = flag,
					bypassDamageReduction = true,
					damagedByExplosion = damagedByExplosion,
					wasKilled = (damage >= healthLookup[hit.Entity].health)
				}
			});
			HealthCD healthCD = healthLookup[hit.Entity];
			if (tookDamageStateLookup.HasComponent(hit.Entity) && (!enemyLookup.HasComponent(hit.Entity) || flag) && (!sleepStateLookup.HasComponent(hit.Entity) || healthCD.health < healthCD.maxHealth))
			{
				AnimationUtilities.TriggerAnimation(-1533413595, currentTick, animationBufferLookup[hit.Entity], ref animationBufferPointerLookup.GetRefRW(hit.Entity).ValueRW);
			}
			Entity targetableOwner = ownerInfo.targetableOwner;
			if (enemyLookup.HasComponent(targetableOwner) || playerGhostLookup.HasComponent(targetableOwner) || minionLookup.HasComponent(targetableOwner))
			{
				LastAttackerCD lastAttackerCD = new LastAttackerCD
				{
					Value = targetableOwner,
					timer = 10f
				};
				if (lastAttackerlookup.HasComponent(hit.Entity))
				{
					lastAttackerlookup[hit.Entity] = lastAttackerCD;
				}
				else
				{
					ecb.AddComponent(hit.Entity, lastAttackerCD);
				}
			}
			if (reversePushback != 0f && !immuneToPushBackLookup.HasComponent(attacker) && physicsVelocityLookup.HasComponent(attacker) && !dontCountAsHitLookup.HasComponent(hit.Entity))
			{
				physicsVelocityLookup.GetRefRW(attacker).ValueRW.Linear = float3.zero;
				float3 x2 = math.normalizesafe(translationLookup[attacker].Position + attackOffset - hit.Position) * reversePushback;
				EntityUtility.TryAddPushback(attacker, x2.ToFloat2(), currentTick, tickRate, immuneToPushBackLookup, receivedPushbackLookup, moveToPredictedByPushbackLookup);
				if (moveToPredictedByCombatInteractionLookup.HasComponent(attacker))
				{
					moveToPredictedByCombatInteractionLookup.GetRefRW(attacker).ValueRW.SetLastInteractionTick(currentTick);
				}
			}
		}

		private bool RayCastIsBlocked(CollisionWorld collisionWorld, ColliderCastHit hit, Parameters p, float3 position)
		{
			if (localTransformLookup.HasComponent(hit.Entity))
			{
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1u
				};
				float3 position2 = localTransformLookup[hit.Entity].Position;
				float3 float5 = position + p.attackOffset + new float3(0f, 0.25f, 0f);
				float3 float6 = position2 + new float3(0f, 0.25f, 0f);
				RaycastInput input = new RaycastInput
				{
					Start = float5,
					End = float6,
					Filter = filter
				};
				NativeList<RaycastHit> allHits = new NativeList<RaycastHit>(Allocator.Temp);
				if (collisionWorld.CastRay(input, ref allHits))
				{
					for (int i = 0; i < allHits.Length; i++)
					{
						RaycastHit raycastHit = allHits[i];
						Entity entity = (ownerLookup.HasComponent(p.attacker) ? ownerLookup[p.attacker].owner : Entity.Null);
						Entity entity2 = (entityPartLookup.HasComponent(raycastHit.Entity) ? entityPartLookup[raycastHit.Entity].mainEntity : Entity.Null);
						if (raycastHit.Entity != hit.Entity && p.attacker != raycastHit.Entity && entity != raycastHit.Entity && entity2 != p.attacker && entity2 != entity)
						{
							allHits.Dispose();
							return true;
						}
					}
				}
				allHits.Dispose();
				float3 x = float6 - float5;
				float3 x2 = math.normalizesafe(x);
				float num = math.length(x);
				num = math.max(0.1f, num - 0.8f);
				if (SinglePugMap.RaycastWalls(float5.ToFloat2(), x2.ToFloat2(), num, out var _, tileAccessor))
				{
					return true;
				}
			}
			return false;
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct AttackSystem_36201DD2_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00000375_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00000375_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000375_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public NativeParallelHashMap<SpawnedGhost, NetworkTick> lastPlayerHit;

		[ReadOnly]
		public ComponentTypeHandle<AttackPlayerRPC> __rpcTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in AttackPlayerRPC rpc)
		{
			if (lastPlayerHit.TryGetValue(rpc.attackerGhost, out var item))
			{
				if (rpc.endServerTick.IsNewerThan(item))
				{
					lastPlayerHit[rpc.attackerGhost] = rpc.endServerTick;
				}
			}
			else
			{
				lastPlayerHit.Add(rpc.attackerGhost, rpc.endServerTick);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackPlayerRPC>(nativeArrayPtr, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackPlayerRPC>(nativeArrayPtr, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackPlayerRPC>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackPlayerRPC>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000375_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00000375_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<AttackSystem_36201DD2_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct AttackSystem_36201DD2_LambdaJob_1_Job : IJob
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00000379_0024PostfixBurstDelegate(IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00000379_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000379_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<IntPtr, void>)functionPointer)(jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(jobPtr);
			}
		}

		public NetworkTick serverTick;

		public NativeParallelHashMap<SpawnedGhost, NetworkTick> lastPlayerHit;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody()
		{
			using NativeArray<SpawnedGhost> nativeArray = lastPlayerHit.GetKeyArray(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				SpawnedGhost key = nativeArray[i];
				if (serverTick.IsNewerThan(lastPlayerHit[key]))
				{
					lastPlayerHit.Remove(key);
				}
			}
		}

		public void Execute()
		{
			OriginalLambdaBody();
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000379_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(IntPtr jobPtr)
		{
			RunWithoutJobSystem_00000379_0024BurstDirectCall.Invoke(jobPtr);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(IntPtr jobPtr)
		{
			InternalCompilerInterface.UnsafeAsRef<AttackSystem_36201DD2_LambdaJob_1_Job>(jobPtr).Execute();
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentTypeHandle<AttackPlayerRPC> __AttackPlayerRPC_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__AttackPlayerRPC_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AttackPlayerRPC>(isReadOnly: true);
		}
	}

	private const int manaToGainFromPetTalent = 25;

	private NativeStream queuedAttacks;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2010572059_0;

	private EntityQuery __query_2010572059_1;

	private EntityQuery __query_2010572059_2;

	private EntityQuery __query_2010572059_3;

	[Preserve]
	protected override void OnCreate()
	{
		base.EntityManager.CreateSingleton(new AttackSystemData
		{
			PlayerHitLookup = new NativeParallelHashMap<SpawnedGhost, float3>(128, Allocator.Persistent),
			LastPlayerHit = new NativeParallelHashMap<SpawnedGhost, NetworkTick>(128, Allocator.Persistent)
		});
		RequireForUpdate<WorldInfoCD>();
		RequireForUpdate(__query_2010572059_1);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		AttackSystemData singleton = __query_2010572059_2.GetSingleton<AttackSystemData>();
		singleton.PlayerHitLookup.Dispose();
		singleton.LastPlayerHit.Dispose();
		base.EntityManager.DestroyEntity(__query_2010572059_2.GetSingletonEntity());
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		__query_2010572059_3.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		serverTick.Add(1u);
		NativeParallelHashMap<SpawnedGhost, NetworkTick> lastPlayerHit = __query_2010572059_2.GetSingleton<AttackSystemData>().LastPlayerHit;
		AttackSystem_36201DD2_LambdaJob_1_Execute(ref serverTick, ref lastPlayerHit);
		AttackSystem_36201DD2_LambdaJob_0_Execute(ref lastPlayerHit);
	}

	private void AttackSystem_36201DD2_LambdaJob_0_Execute(ref NativeParallelHashMap<SpawnedGhost, NetworkTick> lastPlayerHit)
	{
		__TypeHandle.__AttackPlayerRPC_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		AttackSystem_36201DD2_LambdaJob_0_Job value = new AttackSystem_36201DD2_LambdaJob_0_Job
		{
			lastPlayerHit = lastPlayerHit,
			__rpcTypeHandle = __TypeHandle.__AttackPlayerRPC_RO_ComponentTypeHandle
		};
		if (!__query_2010572059_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			AttackSystem_36201DD2_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_2010572059_0, jobPtr);
		}
		lastPlayerHit = value.lastPlayerHit;
	}

	private void AttackSystem_36201DD2_LambdaJob_1_Execute(ref NetworkTick serverTick, ref NativeParallelHashMap<SpawnedGhost, NetworkTick> lastPlayerHit)
	{
		AttackSystem_36201DD2_LambdaJob_1_Job value = new AttackSystem_36201DD2_LambdaJob_1_Job
		{
			serverTick = serverTick,
			lastPlayerHit = lastPlayerHit
		};
		base.CheckedStateRef.CompleteDependency();
		AttackSystem_36201DD2_LambdaJob_1_Job.RunWithoutJobSystem(InternalCompilerInterface.AddressOf(ref value));
		serverTick = value.serverTick;
		lastPlayerHit = value.lastPlayerHit;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<AttackPlayerRPC>();
		__query_2010572059_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<AttackPlayerRPC>();
		__query_2010572059_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<AttackSystemData>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2010572059_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2010572059_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public AttackSystem()
	{
	}
}
