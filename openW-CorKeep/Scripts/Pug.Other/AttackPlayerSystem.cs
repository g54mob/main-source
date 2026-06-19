using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using PlayerCommand;
using PlayerEquipment;
using PlayerState;
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
using Unity.NetCode.LowLevel;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
[UpdateAfter(typeof(ProjectileMovementSystem))]
[UpdateBefore(typeof(UpdateHealthSystemGroup))]
[UpdateBefore(typeof(PlayerAttackSystem))]
[UpdateBefore(typeof(SetEntitiesDestroyedSystem))]
[UpdateBefore(typeof(CheckForDeadPlayerSystem))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct AttackPlayerSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	private struct PlayerConnection
	{
		public Entity targetEntity;
	}

	public struct RegisterPlayerHitShared
	{
		[ReadOnly]
		public PhysicsWorld physicsWorld;

		[ReadOnly]
		public PhysicsWorldHistorySingleton physicsWorldHistory;

		[ReadOnly]
		public NativeParallelHashMap<SpawnedGhost, Entity>.ReadOnly SpawnedGhostMap;

		public WorldInfoCD worldInfo;

		public NetworkTick currentTick;

		public ConditionsTableCD conditionsTableCD;

		public bool isFirstTimeFullyPredictingTick;

		public EntityCommandBuffer ecb;

		public PugDatabase.DatabaseBankCD databaseBank;

		public uint tickRate;

		public Entity inventoryChangeBufferEntity;

		public AttackSystemData attackSystemData;
	}

	public struct RegisterPlayerHitLookup
	{
		public ComponentLookup<PlayerStateCD> playerStateLookup;

		public BufferLookup<SummarizedConditionsBuffer> summarizeConiditionsLookup;

		public ComponentLookup<FactionCD> factionLookup;

		public ComponentLookup<LocalTransform> localTransformLookup;

		public ComponentLookup<ObjectCategoryTagsCD> objectCategoryTagsLookup;

		public ComponentLookup<EntityPartCD> entityPartLookup;

		public ComponentLookup<GhostInstance> ghostInstanceLookup;

		public ComponentLookup<HealthCD> healthLookup;

		public ComponentLookup<ObjectTypeCD> objectTypeLookup;

		public BufferLookup<SummarizedConditionEffectsBuffer> summarizeConiditionsEffectsLookup;

		public BufferLookup<ConditionsBuffer> conditionsBufferLookup;

		public ComponentLookup<UseOffHandStateCD> useOffHandStateLookup;

		public BufferLookup<AnimationBuffer> animationBufferLookup;

		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		public ComponentLookup<AnimationOrientationCD> animationOrientationLookup;

		public ComponentLookup<ImmuneToPushBackCD> immuneToPushBackLookup;

		public ComponentLookup<PhysicsVelocity> physicsVelocityLookup;

		public ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup;

		public ComponentLookup<AttackContinuouslyCD> attackContinuouslyLookup;

		public ComponentLookup<ProjectileCD> projectileLookup;

		public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

		public ComponentLookup<GhostOwner> ghostOwnerLookup;

		public ComponentLookup<BehaviourTagsCD> behaviourTagsLookup;

		public ComponentLookup<PlayerInvincibilityCD> playerInvincibilityLookup;

		public ComponentLookup<PhysicsMass> physicsMassLookup;

		public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup;

		public ComponentLookup<ManaCD> manaLookup;

		public ComponentLookup<MagicBarrierCD> magicBarrierLookup;

		public ComponentLookup<LastDamageTakenTimeCD> lastDamageTakenTimeLookup;

		public ComponentLookup<RandomCD> randomLookup;

		public ComponentLookup<MortarProjectileCD> mortarProjectileLookup;

		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		public ComponentLookup<ObjectDataCD> objectDataLookup;

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

		[ReadOnly]
		public ComponentLookup<PhaseTransitionStateCD> phaseTransitionStateLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> simulateLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		[ReadOnly]
		public ComponentLookup<MortarProjectileDamageEffectCD> mortarProjectileDamageEffectLookup;

		[ReadOnly]
		public ComponentLookup<PiercingProjectileCD> piercingProjectileLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> petLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> minionLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> bossLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		public static RegisterPlayerHitLookup Create(ref SystemState state)
		{
			return new RegisterPlayerHitLookup
			{
				playerStateLookup = state.GetComponentLookup<PlayerStateCD>(),
				summarizeConiditionsLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(),
				factionLookup = state.GetComponentLookup<FactionCD>(),
				localTransformLookup = state.GetComponentLookup<LocalTransform>(),
				objectCategoryTagsLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(),
				entityPartLookup = state.GetComponentLookup<EntityPartCD>(),
				ghostInstanceLookup = state.GetComponentLookup<GhostInstance>(),
				healthLookup = state.GetComponentLookup<HealthCD>(),
				objectTypeLookup = state.GetComponentLookup<ObjectTypeCD>(),
				summarizeConiditionsEffectsLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(),
				conditionsBufferLookup = state.GetBufferLookup<ConditionsBuffer>(),
				useOffHandStateLookup = state.GetComponentLookup<UseOffHandStateCD>(),
				animationBufferLookup = state.GetBufferLookup<AnimationBuffer>(),
				animationBufferPointerLookup = state.GetComponentLookup<AnimationBufferPointer>(),
				animationOrientationLookup = state.GetComponentLookup<AnimationOrientationCD>(),
				immuneToPushBackLookup = state.GetComponentLookup<ImmuneToPushBackCD>(),
				physicsVelocityLookup = state.GetComponentLookup<PhysicsVelocity>(),
				immuneToDamageLookup = state.GetComponentLookup<ImmuneToDamageCD>(),
				attackContinuouslyLookup = state.GetComponentLookup<AttackContinuouslyCD>(),
				projectileLookup = state.GetComponentLookup<ProjectileCD>(),
				destroyTimerLookup = state.GetComponentLookup<DestroyTimerCD>(),
				ghostOwnerLookup = state.GetComponentLookup<GhostOwner>(),
				behaviourTagsLookup = state.GetComponentLookup<BehaviourTagsCD>(),
				playerInvincibilityLookup = state.GetComponentLookup<PlayerInvincibilityCD>(),
				physicsMassLookup = state.GetComponentLookup<PhysicsMass>(),
				ghostEffectEventBufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>(),
				ghostEffectEventBufferPointerLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>(),
				manaLookup = state.GetComponentLookup<ManaCD>(),
				magicBarrierLookup = state.GetComponentLookup<MagicBarrierCD>(),
				lastDamageTakenTimeLookup = state.GetComponentLookup<LastDamageTakenTimeCD>(),
				randomLookup = state.GetComponentLookup<RandomCD>(),
				mortarProjectileLookup = state.GetComponentLookup<MortarProjectileCD>(),
				ownerLookup = state.GetComponentLookup<OwnerReferenceCD>(),
				objectDataLookup = state.GetComponentLookup<ObjectDataCD>(),
				reduceDurabilityOfAllEquipmentTriggerLookup = state.GetComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD>(),
				godModeLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true),
				inventoryChangeBuffer = state.GetBufferLookup<InventoryChangeBuffer>(),
				equipmentLookup = state.GetComponentLookup<EquipmentCD>(isReadOnly: true),
				dealDamageToEntityBuffer = state.GetBufferLookup<DealDamageToEntityBuffer>(),
				containedObjectsBuffer = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true),
				receivedPushbackLookup = state.GetComponentLookup<ReceivedPushbackCD>(),
				moveToPredictedByCombatInteractionLookup = state.GetComponentLookup<MoveToPredictedByCombatOrInventoryInteractionCD>(),
				moveToPredictedByPushbackLookup = state.GetComponentLookup<MoveToPredictedByPushbackCD>(),
				phaseTransitionStateLookup = state.GetComponentLookup<PhaseTransitionStateCD>(isReadOnly: true),
				simulateLookup = state.GetComponentLookup<Simulate>(isReadOnly: true),
				playerGhostLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true),
				mortarProjectileDamageEffectLookup = state.GetComponentLookup<MortarProjectileDamageEffectCD>(isReadOnly: true),
				piercingProjectileLookup = state.GetComponentLookup<PiercingProjectileCD>(isReadOnly: true),
				petLookup = state.GetComponentLookup<PetCD>(isReadOnly: true),
				minionLookup = state.GetComponentLookup<MinionCD>(isReadOnly: true),
				bossLookup = state.GetComponentLookup<BossCD>(isReadOnly: true),
				enemyLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true)
			};
		}

		public void Update(ref SystemState state)
		{
			playerStateLookup.Update(ref state);
			summarizeConiditionsLookup.Update(ref state);
			factionLookup.Update(ref state);
			localTransformLookup.Update(ref state);
			objectCategoryTagsLookup.Update(ref state);
			entityPartLookup.Update(ref state);
			ghostInstanceLookup.Update(ref state);
			healthLookup.Update(ref state);
			objectTypeLookup.Update(ref state);
			summarizeConiditionsEffectsLookup.Update(ref state);
			conditionsBufferLookup.Update(ref state);
			useOffHandStateLookup.Update(ref state);
			animationBufferLookup.Update(ref state);
			animationBufferPointerLookup.Update(ref state);
			animationOrientationLookup.Update(ref state);
			immuneToPushBackLookup.Update(ref state);
			physicsVelocityLookup.Update(ref state);
			immuneToDamageLookup.Update(ref state);
			attackContinuouslyLookup.Update(ref state);
			projectileLookup.Update(ref state);
			destroyTimerLookup.Update(ref state);
			ghostOwnerLookup.Update(ref state);
			behaviourTagsLookup.Update(ref state);
			playerInvincibilityLookup.Update(ref state);
			physicsMassLookup.Update(ref state);
			ghostEffectEventBufferLookup.Update(ref state);
			ghostEffectEventBufferPointerLookup.Update(ref state);
			manaLookup.Update(ref state);
			magicBarrierLookup.Update(ref state);
			lastDamageTakenTimeLookup.Update(ref state);
			randomLookup.Update(ref state);
			mortarProjectileLookup.Update(ref state);
			ownerLookup.Update(ref state);
			objectDataLookup.Update(ref state);
			reduceDurabilityOfAllEquipmentTriggerLookup.Update(ref state);
			godModeLookup.Update(ref state);
			inventoryChangeBuffer.Update(ref state);
			equipmentLookup.Update(ref state);
			dealDamageToEntityBuffer.Update(ref state);
			containedObjectsBuffer.Update(ref state);
			receivedPushbackLookup.Update(ref state);
			moveToPredictedByCombatInteractionLookup.Update(ref state);
			moveToPredictedByPushbackLookup.Update(ref state);
			phaseTransitionStateLookup.Update(ref state);
			simulateLookup.Update(ref state);
			playerGhostLookup.Update(ref state);
			mortarProjectileDamageEffectLookup.Update(ref state);
			piercingProjectileLookup.Update(ref state);
			petLookup.Update(ref state);
			minionLookup.Update(ref state);
			bossLookup.Update(ref state);
			enemyLookup.Update(ref state);
		}
	}

	[BurstCompile]
	[WithAll(new Type[] { typeof(PlayerGhost) })]
	private struct CreatePlayerConnectionListJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<PlayerGhost>().Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref CreatePlayerConnectionListJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CreatePlayerConnectionListJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CreatePlayerConnectionListJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CreatePlayerConnectionListJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CreatePlayerConnectionListJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CreatePlayerConnectionListJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public NativeList<PlayerConnection> connections;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity)
		{
			ref NativeList<PlayerConnection> reference = ref connections;
			PlayerConnection value = new PlayerConnection
			{
				targetEntity = entity
			};
			reference.Add(in value);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity);
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2);
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4);
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct ClearHitPlayerLookupJob : IJob
	{
		public AttackSystemData attackSystemData;

		public void Execute()
		{
			attackSystemData.PlayerHitLookup.Clear();
		}
	}

	[BurstCompile]
	private struct TryAttackPlayerFromRPCJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AttackPlayerRPC> __AttackPlayerRPC_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_NetCode_ReceiveRpcCommandRequest_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ReceiveRpcCommandRequest>();
					__AttackPlayerRPC_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AttackPlayerRPC>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_NetCode_ReceiveRpcCommandRequest_RW_ComponentTypeHandle.Update(ref state);
					__AttackPlayerRPC_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ReceiveRpcCommandRequest>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AttackPlayerRPC>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref TryAttackPlayerFromRPCJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref TryAttackPlayerFromRPCJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref TryAttackPlayerFromRPCJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref TryAttackPlayerFromRPCJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref TryAttackPlayerFromRPCJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref TryAttackPlayerFromRPCJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		[ReadOnly]
		public NativeList<PlayerConnection> connections;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		[ReadOnly]
		public ComponentLookup<ClientInput> clientInputLookup;

		[ReadOnly]
		public ComponentLookup<SnapshotData> snapshotDataLookup;

		[ReadOnly]
		public BufferLookup<SnapshotDataBuffer> snapshotDataBufferLookup;

		[ReadOnly]
		public ComponentLookup<PredictedGhost> predictedGhostLookup;

		public BufferLookup<PlayerRecentAttackersBuffer> playerRecentAttackersBufferLookup;

		public ComponentLookup<PlayerRecentAttackersBufferPointerCD> playerRecentAttackersBufferPointerLookup;

		public BufferLookup<AttackPlayerPositionBuffer> attackPlayerPositionBufferLookup;

		public RegisterPlayerHitShared registerPlayerHitShared;

		public NetworkTick serverTick;

		public uint tickRate;

		public bool isFirstPredictionTick;

		public bool isServerLocal;

		public ClientServerTickRate clientServerTickRate;

		public RegisterPlayerHitLookup registerPlayerHitLookup;

		public NativeList<ColliderCastHit> colliderCastHits;

		public TileAccessor tileAccessor;

		[NativeDisableContainerSafetyRestriction]
		public SnapshotDataLookupHelper spawnBufferLookupHelper;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref ReceiveRpcCommandRequest receive, ref AttackPlayerRPC rpc)
		{
			receive.Consume();
			EntityCommandBuffer ecb = registerPlayerHitShared.ecb;
			if (isFirstPredictionTick && rpc.endServerTick.IsOlderThan(serverTick) && serverTick.TicksSince(rpc.endServerTick) > clientServerTickRate.SimulationTickRate)
			{
				ecb.DestroyEntity(entity);
			}
			else
			{
				if (!registerPlayerHitShared.SpawnedGhostMap.TryGetValue(rpc.attackerGhost, out var item))
				{
					return;
				}
				if (!registerPlayerHitLookup.localTransformLookup.TryGetComponent(item, out var componentData))
				{
					ecb.DestroyEntity(entity);
					return;
				}
				float3 float5 = componentData.Position + rpc.attackOffset;
				NativeArray<AttackPlayerPositionBuffer> buffer = default(NativeArray<AttackPlayerPositionBuffer>);
				SnapshotDataBufferComponentLookup snapshotDataBufferComponentLookup = default(SnapshotDataBufferComponentLookup);
				DynamicBuffer<SnapshotDataBuffer> bufferData = default(DynamicBuffer<SnapshotDataBuffer>);
				SnapshotData componentData2 = default(SnapshotData);
				GhostInstance componentData3 = default(GhostInstance);
				if (isServerLocal)
				{
					DynamicBuffer<AttackPlayerPositionBuffer> dynamicBuffer = attackPlayerPositionBufferLookup[entity];
					dynamicBuffer.Add(new AttackPlayerPositionBuffer
					{
						tick = serverTick,
						tickFraction = 1f,
						position = float5,
						dead = (entityDestroyedLookup.HasAndIsComponentEnabled(item) && !registerPlayerHitLookup.projectileLookup.HasComponent(item))
					});
					buffer = dynamicBuffer.AsNativeArray();
				}
				else
				{
					if (!snapshotDataBufferLookup.TryGetBuffer(item, out bufferData))
					{
						UnityEngine.Debug.LogError("no shapshot data buffer");
						return;
					}
					if (!snapshotDataLookup.TryGetComponent(item, out componentData2))
					{
						UnityEngine.Debug.LogError("no shapshot data");
						return;
					}
					if (!registerPlayerHitLookup.ghostInstanceLookup.TryGetComponent(item, out componentData3))
					{
						UnityEngine.Debug.LogError("no ghost instance");
						return;
					}
					if (!registerPlayerHitLookup.projectileLookup.HasComponent(item) && entityDestroyedLookup.HasAndIsComponentEnabled(item))
					{
						return;
					}
					snapshotDataBufferComponentLookup = spawnBufferLookupHelper.CreateSnapshotBufferLookup();
				}
				if (rpc.startServerTick.IsNewerThan(serverTick))
				{
					return;
				}
				Entity entity2 = item;
				if (registerPlayerHitLookup.entityPartLookup.TryGetComponent(item, out var componentData4))
				{
					entity2 = componentData4.mainEntity;
				}
				if (entityDestroyedLookup.HasAndIsComponentEnabled(item) && enemyLookup.HasComponent(entity2))
				{
					return;
				}
				bool flag = false;
				for (int i = 0; i < connections.Length && !flag; i++)
				{
					PlayerConnection playerConnection = connections[i];
					if (!clientInputLookup.TryGetComponent(playerConnection.targetEntity, out var componentData5))
					{
						UnityEngine.Debug.LogError("no client input");
						continue;
					}
					byte deterministicInterpolationDelay = componentData5.deterministicInterpolationDelay;
					int num = serverTick.TicksSince(rpc.startServerTick);
					if (num < deterministicInterpolationDelay || num > deterministicInterpolationDelay + rpc.endServerTick.TicksSince(rpc.startServerTick))
					{
						continue;
					}
					DynamicBuffer<PlayerRecentAttackersBuffer> buffer2 = playerRecentAttackersBufferLookup[playerConnection.targetEntity];
					if (buffer2.HasRecentlyBeenAttackedByEntity(entity2, serverTick, tickRate))
					{
						continue;
					}
					NetworkTick networkTick = serverTick;
					networkTick.Subtract(deterministicInterpolationDelay);
					float3 outPosition;
					if (isServerLocal)
					{
						if (!buffer.TryGetPositionAtTick(networkTick, out outPosition, out var isDead))
						{
							if (entityDestroyedLookup.HasAndIsComponentEnabled(item))
							{
								continue;
							}
							outPosition = float5;
						}
						else if (isDead)
						{
							continue;
						}
					}
					else
					{
						if (!snapshotDataBufferComponentLookup.TryGetComponentDataFromSnapshotHistory<LocalTransform>(componentData3.ghostType, componentData2, in bufferData, out componentData, networkTick, 1f))
						{
							continue;
						}
						outPosition = componentData.Position + rpc.attackOffset;
					}
					colliderCastHits.Clear();
					PhysicsWorld physicsWorld = registerPlayerHitShared.physicsWorld;
					registerPlayerHitShared.physicsWorldHistory.GetCollisionWorldFromTick(registerPlayerHitShared.currentTick, 0u, ref physicsWorld, out var collWorld);
					bool flag2 = false;
					CollisionFilter filter = new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = 2u
					};
					bool isDead2;
					if (rpc.boxHorizontalWidth > 0f)
					{
						flag2 = collWorld.BoxCastAll(outPosition, rpc.rotation, new float3(rpc.boxHorizontalWidth, 1f, rpc.boxVerticalWidth), rpc.direction, rpc.castDistance, ref colliderCastHits, filter);
					}
					else
					{
						float3 outPosition2 = outPosition;
						float3 direction = rpc.direction;
						float maxDistance = rpc.castDistance;
						if (registerPlayerHitLookup.projectileLookup.HasComponent(item))
						{
							outPosition2 = rpc.startPosition + rpc.attackOffset;
						}
						else if (rpc.castDistance == 0f)
						{
							NetworkTick tick = networkTick;
							tick.Decrement();
							if (!isServerLocal)
							{
								outPosition2 = (snapshotDataBufferComponentLookup.TryGetComponentDataFromSnapshotHistory<LocalTransform>(componentData3.ghostType, componentData2, in bufferData, out componentData, tick, 1f) ? (componentData.Position + rpc.attackOffset) : outPosition);
							}
							else if (!buffer.TryGetPositionAtTick(tick, out outPosition2, out isDead2))
							{
								outPosition2 = outPosition;
							}
							if (math.all(outPosition == outPosition2))
							{
								outPosition2 = rpc.startPosition + rpc.attackOffset;
							}
							if (math.all(outPosition == outPosition2))
							{
								outPosition2 = outPosition - rpc.direction * 0.01f;
							}
							direction = math.normalizesafe(outPosition - outPosition2);
							maxDistance = math.distance(outPosition, outPosition2);
						}
						flag2 = collWorld.SphereCastAll(outPosition2, rpc.radius, direction, maxDistance, ref colliderCastHits, filter);
					}
					if (!flag2)
					{
						continue;
					}
					for (int j = 0; j < colliderCastHits.Length; j++)
					{
						ColliderCastHit colliderCastHit = colliderCastHits[j];
						Entity entity3 = colliderCastHit.Entity;
						if (entity3 != playerConnection.targetEntity)
						{
							continue;
						}
						if (!registerPlayerHitLookup.healthLookup.TryGetComponent(entity3, out var componentData6))
						{
							UnityEngine.Debug.LogError("no health on player");
							break;
						}
						if (componentData6.health <= 0)
						{
							break;
						}
						float3 pos = collWorld.Bodies[colliderCastHit.RigidBodyIndex].WorldFromBody.pos;
						float3 float6 = colliderCastHit.Position;
						if (rpc.castDistance == 0f)
						{
							float6 = pos;
						}
						RefRW<RandomCD> refRW;
						if (registerPlayerHitLookup.simulateLookup.HasAndIsComponentDisabled(playerConnection.targetEntity))
						{
							if (!predictedGhostLookup.HasComponent(playerConnection.targetEntity))
							{
								refRW = registerPlayerHitLookup.randomLookup.GetRefRW(entity3);
								Unity.Mathematics.Random random = refRW.ValueRO.Value;
								flag = RegisterFakePlayerHit(colliderCastHit.Entity, colliderCastHit.Entity, in registerPlayerHitShared, in registerPlayerHitLookup, item, outPosition - rpc.attackOffset, float6, pos, tileAccessor, rpc.damage, rpc.direction, rpc.reverseDamage, ref random, rpc.pushback, rpc.reversePushback, rpc.isExplosive, rpc.isExplosiveDamageFromBomb, out isDead2, rpc.triggerAnimationOnHit, rpc.isRanged, rpc.isBoss, rpc.isMinion, rpc.isPet, rpc.checkVisibility);
							}
							break;
						}
						refRW = registerPlayerHitLookup.randomLookup.GetRefRW(entity3);
						ref Unity.Mathematics.Random value = ref refRW.ValueRW.Value;
						flag = RegisterPlayerHit(colliderCastHit.Entity, colliderCastHit.Entity, in registerPlayerHitShared, in registerPlayerHitLookup, item, outPosition - rpc.attackOffset, float6, pos, tileAccessor, rpc.damage, rpc.damageEffectType, rpc.direction, rpc.reverseDamage, ref value, rpc.pushback, rpc.reversePushback, rpc.isExplosive, rpc.isExplosiveDamageFromBomb, out var didDodge, rpc.triggerAnimationOnHit, rpc.isRanged, rpc.isBoss, rpc.isMinion, rpc.isPet, treatDodgeAsHit: false, rpc.checkVisibility);
						if (flag || didDodge)
						{
							buffer2.AddAttacker(ref playerRecentAttackersBufferPointerLookup.GetRefRW(playerConnection.targetEntity).ValueRW, entity2, serverTick, tickRate);
							if (flag)
							{
								registerPlayerHitShared.attackSystemData.PlayerHitLookup.Add(rpc.attackerGhost, float6);
							}
							break;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AttackPlayerRPC_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackPlayerRPC>(nativeArrayPtr3, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackPlayerRPC>(nativeArrayPtr3, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackPlayerRPC>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AttackPlayerRPC>(nativeArrayPtr3, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		public CreatePlayerConnectionListJob.InternalCompilerQueryAndHandleData __AttackPlayerSystem_CreatePlayerConnectionListJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClientInput> __ClientInput_RO_ComponentLookup;

		public BufferLookup<AttackPlayerPositionBuffer> __AttackPlayerPositionBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<SnapshotData> __Unity_NetCode_SnapshotData_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SnapshotDataBuffer> __Unity_NetCode_SnapshotDataBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<PredictedGhost> __Unity_NetCode_PredictedGhost_RO_ComponentLookup;

		public BufferLookup<PlayerRecentAttackersBuffer> __PlayerRecentAttackersBuffer_RW_BufferLookup;

		public ComponentLookup<PlayerRecentAttackersBufferPointerCD> __PlayerRecentAttackersBufferPointerCD_RW_ComponentLookup;

		public TryAttackPlayerFromRPCJob.InternalCompilerQueryAndHandleData __AttackPlayerSystem_TryAttackPlayerFromRPCJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__AttackPlayerSystem_CreatePlayerConnectionListJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__ClientInput_RO_ComponentLookup = state.GetComponentLookup<ClientInput>(isReadOnly: true);
			__AttackPlayerPositionBuffer_RW_BufferLookup = state.GetBufferLookup<AttackPlayerPositionBuffer>();
			__Unity_NetCode_SnapshotData_RO_ComponentLookup = state.GetComponentLookup<SnapshotData>(isReadOnly: true);
			__Unity_NetCode_SnapshotDataBuffer_RO_BufferLookup = state.GetBufferLookup<SnapshotDataBuffer>(isReadOnly: true);
			__Unity_NetCode_PredictedGhost_RO_ComponentLookup = state.GetComponentLookup<PredictedGhost>(isReadOnly: true);
			__PlayerRecentAttackersBuffer_RW_BufferLookup = state.GetBufferLookup<PlayerRecentAttackersBuffer>();
			__PlayerRecentAttackersBufferPointerCD_RW_ComponentLookup = state.GetComponentLookup<PlayerRecentAttackersBufferPointerCD>();
			__AttackPlayerSystem_TryAttackPlayerFromRPCJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000002D7_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000002D7_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000002D7_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStartRunning_000002D8_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_000002D8_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000002D8_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_000002D9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_000002D9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000002D9_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	private RegisterPlayerHitLookup _registerPlayerHitLookup;

	private TileAccessor _tileAccessor;

	private SnapshotDataLookupHelper _spawnBufferHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1392775730_0;

	private EntityQuery __query_1392775730_1;

	private EntityQuery __query_1392775730_2;

	private EntityQuery __query_1392775730_3;

	private EntityQuery __query_1392775730_4;

	private EntityQuery __query_1392775730_5;

	private EntityQuery __query_1392775730_6;

	private EntityQuery __query_1392775730_7;

	private EntityQuery __query_1392775730_8;

	private EntityQuery __query_1392775730_9;

	private EntityQuery __query_1392775730_10;

	private EntityQuery __query_1392775730_11;

	private EntityQuery __query_1392775730_12;

	public static bool RegisterFakePlayerHit(Entity playerEntity, Entity effectEventEntity, in RegisterPlayerHitShared registerPlayerHitShared, in RegisterPlayerHitLookup registerPlayerHitLookup, Entity attacker, float3 attackerPosition, float3 hitWorldPosition, float3 playerPosition, TileAccessor tileAccessor, int damage, float3 direction, int reverseDamage, ref Unity.Mathematics.Random random, float pushback, float reversePushback, bool isExplosiveDamage, bool isExplosiveDamageFromBomb, out bool didDodge, int triggerAnimationOnHit = 0, bool isRanged = false, bool isBoss = false, bool attackerIsMinion = false, bool attackerIsPet = false, bool treatDodgeAsHit = false, bool checkVisibility = false, bool isReverseDamage = false)
	{
		didDodge = false;
		PlayerStateCD playerStateCD = registerPlayerHitLookup.playerStateLookup[playerEntity];
		if (PlayerController.IsDyingOrDead(playerStateCD) || playerStateCD.HasAnyState(PlayerStateEnum.NoClip) || registerPlayerHitLookup.godModeLookup.IsComponentEnabled(playerEntity) || EntityUtility.GetConditionValue(ConditionID.ImmuneToDamageAfterRespawn, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup) > 0 || EntityUtility.GetConditionValue(ConditionID.ImmuneToDamageAfterLogin, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup) > 0)
		{
			return false;
		}
		registerPlayerHitLookup.factionLookup.TryGetComponent(attacker, out var componentData);
		registerPlayerHitLookup.factionLookup.TryGetComponent(playerEntity, out var componentData2);
		if (!componentData.CanAttack(componentData2, registerPlayerHitShared.worldInfo))
		{
			return false;
		}
		if (isExplosiveDamage && !isExplosiveDamageFromBomb)
		{
			FactionCD factionCD = componentData;
			if (registerPlayerHitLookup.ownerLookup.TryGetComponent(attacker, out var componentData3) && registerPlayerHitLookup.factionLookup.TryGetComponent(componentData3.owner, out var componentData4))
			{
				factionCD = componentData4;
			}
			if (factionCD.IsFriendlyFire(componentData2, registerPlayerHitShared.worldInfo))
			{
				damage = (int)math.round((float)damage * 0.19999999f);
				pushback *= 0.35000002f;
			}
		}
		bool flag = false;
		CollisionFilter filter = new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 1u
		};
		float3 float5 = hitWorldPosition;
		float5.y = 0.5f;
		float3 float6 = playerPosition;
		float6.y = 0.5f;
		RaycastInput input = new RaycastInput
		{
			Start = float5,
			End = float6,
			Filter = filter
		};
		NativeList<Unity.Physics.RaycastHit> allHits = new NativeList<Unity.Physics.RaycastHit>(Allocator.Temp);
		if (registerPlayerHitShared.physicsWorld.CollisionWorld.CastRay(input, ref allHits))
		{
			for (int i = 0; i < allHits.Length; i++)
			{
				if (checkVisibility && allHits[i].Entity != attacker && registerPlayerHitLookup.objectDataLookup.HasComponent(allHits[i].Entity) && (!registerPlayerHitLookup.ownerLookup.HasComponent(attacker) || registerPlayerHitLookup.ownerLookup[attacker].owner != allHits[i].Entity))
				{
					flag = true;
					break;
				}
				if (registerPlayerHitLookup.objectCategoryTagsLookup.TryGetComponent(allHits[i].Entity, out var componentData5) && ObjectCategoryTagsCD.HasTag(componentData5.tagsBitMask, ObjectCategoryTag.DamageCantGoThrough))
				{
					flag = true;
					break;
				}
			}
		}
		allHits.Dispose();
		if (!flag && checkVisibility)
		{
			float3 x = float6 - float5;
			float3 x2 = math.normalizesafe(x);
			float maxDist = math.length(x);
			if (SinglePugMap.RaycastWalls(float5.ToFloat2(), x2.ToFloat2(), maxDist, out var _, tileAccessor))
			{
				flag = true;
			}
		}
		if (flag)
		{
			return false;
		}
		EntityPartCD componentData6;
		Entity entity = ((registerPlayerHitLookup.entityPartLookup.TryGetComponent(attacker, out componentData6) && componentData6.mainEntity != Entity.Null) ? componentData6.mainEntity : attacker);
		registerPlayerHitLookup.healthLookup.TryGetComponent(playerEntity, out var componentData7);
		registerPlayerHitLookup.healthLookup.TryGetComponent(entity, out var componentData8);
		registerPlayerHitLookup.objectTypeLookup.TryGetComponent(playerEntity, out var componentData9);
		registerPlayerHitLookup.manaLookup.TryGetComponent(playerEntity, out var componentData10);
		registerPlayerHitLookup.magicBarrierLookup.TryGetComponent(playerEntity, out var componentData11);
		registerPlayerHitLookup.phaseTransitionStateLookup.TryGetComponent(playerEntity, out var componentData12);
		NativeList<ConditionData> appliedConditions = new NativeList<ConditionData>(Allocator.Temp);
		NativeList<ConditionData> appliedConditionsOnAttacker = new NativeList<ConditionData>(Allocator.Temp);
		NativeList<ConditionID> removedConditions = new NativeList<ConditionID>(Allocator.Temp);
		NativeList<ConditionID> removedConditionsFromAttacker = new NativeList<ConditionID>(Allocator.Temp);
		NativeArray<SummarizedConditionsBuffer> conditionValuesArray = EntityUtility.GetConditionValuesArray(entity, registerPlayerHitLookup.summarizeConiditionsLookup);
		NativeArray<SummarizedConditionEffectsBuffer> conditionEffectsValuesArray = EntityUtility.GetConditionEffectsValuesArray(entity, registerPlayerHitLookup.summarizeConiditionsEffectsLookup);
		NativeArray<SummarizedConditionEffectsBuffer> conditionEffectsValuesArray2 = EntityUtility.GetConditionEffectsValuesArray(playerEntity, registerPlayerHitLookup.summarizeConiditionsEffectsLookup);
		NativeArray<SummarizedConditionsBuffer> conditionValuesArray2 = EntityUtility.GetConditionValuesArray(playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup);
		bool receiverIsInMinecart = playerStateCD.HasAnyState(PlayerStateEnum.MinecartRiding);
		EntityUtility.CalculateDamage(EntityUtility.GetOwnerInfo(registerPlayerHitLookup.entityPartLookup, registerPlayerHitLookup.ownerLookup, registerPlayerHitLookup.summarizeConiditionsLookup, registerPlayerHitLookup.playerGhostLookup, registerPlayerHitLookup.petLookup, registerPlayerHitLookup.minionLookup, registerPlayerHitLookup.bossLookup, registerPlayerHitLookup.healthLookup, registerPlayerHitLookup.enemyLookup, attacker), conditionValuesArray, conditionEffectsValuesArray, conditionValuesArray2, conditionEffectsValuesArray2, ref random, damage, isRanged, isMagic: false, isDigging: false, isReverseDamage, isBoss, attackerIsMinion, attackerIsPet, receiverIsBoss: false, receiverIsPlayer: true, recieverIsImmuneToRange: false, attackWoundup: false, componentData9, recieverIsDestructible: false, receiverIsInMinecart, isExplosive: false, componentData7, componentData8, componentData10, componentData11, componentData, out var _, appliedConditions, appliedConditionsOnAttacker, removedConditions, removedConditionsFromAttacker, componentData12, out didDodge, out var _, out var _, out var _, out var _, out var _, out var _, out var _, out var _);
		if (registerPlayerHitLookup.useOffHandStateLookup[playerEntity].IsParrying(registerPlayerHitShared.currentTick))
		{
			didDodge = false;
		}
		removedConditionsFromAttacker.Dispose();
		appliedConditionsOnAttacker.Dispose();
		if (didDodge && !treatDodgeAsHit)
		{
			return false;
		}
		if (triggerAnimationOnHit == -414722770)
		{
			registerPlayerHitLookup.healthLookup.GetRefRW(attacker).ValueRW.health = 0;
			registerPlayerHitLookup.localTransformLookup.GetRefRW(attacker).ValueRW.Position = hitWorldPosition;
			if (registerPlayerHitLookup.moveToPredictedByCombatInteractionLookup.HasComponent(entity))
			{
				registerPlayerHitLookup.moveToPredictedByCombatInteractionLookup.GetRefRW(attacker).ValueRW.SetLastInteractionTick(registerPlayerHitShared.currentTick);
			}
		}
		return true;
	}

	public static bool RegisterPlayerHit(Entity playerEntity, Entity effectEventEntity, in RegisterPlayerHitShared registerPlayerHitShared, in RegisterPlayerHitLookup registerPlayerHitLookup, Entity attacker, float3 attackerPosition, float3 hitWorldPosition, float3 playerPosition, TileAccessor tileAccessor, int damage, DamageEffectType damageEffectType, float3 direction, int reverseDamage, ref Unity.Mathematics.Random random, float pushback, float reversePushback, bool isExplosiveDamage, bool isExplosiveDamageFromBomb, out bool didDodge, int triggerAnimationOnHit = 0, bool isRanged = false, bool isBoss = false, bool isMinion = false, bool isPet = false, bool treatDodgeAsHit = false, bool checkVisibility = false, bool isReverseDamage = false)
	{
		didDodge = false;
		PlayerStateCD playerStateCD = registerPlayerHitLookup.playerStateLookup[playerEntity];
		if (PlayerController.IsDyingOrDead(playerStateCD) || playerStateCD.HasAnyState(PlayerStateEnum.NoClip) || registerPlayerHitLookup.godModeLookup.IsComponentEnabled(playerEntity) || EntityUtility.GetConditionValue(ConditionID.ImmuneToDamageAfterRespawn, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup) > 0 || EntityUtility.GetConditionValue(ConditionID.ImmuneToDamageAfterLogin, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup) > 0)
		{
			return false;
		}
		registerPlayerHitLookup.factionLookup.TryGetComponent(attacker, out var componentData);
		registerPlayerHitLookup.factionLookup.TryGetComponent(playerEntity, out var componentData2);
		if (!componentData.CanAttack(componentData2, registerPlayerHitShared.worldInfo))
		{
			return false;
		}
		if (isExplosiveDamage && !isExplosiveDamageFromBomb)
		{
			FactionCD factionCD = componentData;
			if (registerPlayerHitLookup.ownerLookup.TryGetComponent(attacker, out var componentData3) && registerPlayerHitLookup.factionLookup.TryGetComponent(componentData3.owner, out var componentData4))
			{
				factionCD = componentData4;
			}
			if (factionCD.IsFriendlyFire(componentData2, registerPlayerHitShared.worldInfo))
			{
				damage = (int)math.round((float)damage * 0.19999999f);
				pushback *= 0.35000002f;
			}
		}
		bool flag = false;
		CollisionFilter filter = new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 1u
		};
		float3 float5 = (checkVisibility ? attackerPosition : hitWorldPosition);
		float5.y = 0.5f;
		float3 float6 = playerPosition;
		float6.y = 0.5f;
		RaycastInput input = new RaycastInput
		{
			Start = float5,
			End = float6,
			Filter = filter
		};
		NativeList<Unity.Physics.RaycastHit> allHits = new NativeList<Unity.Physics.RaycastHit>(Allocator.Temp);
		if (registerPlayerHitShared.physicsWorld.CollisionWorld.CastRay(input, ref allHits))
		{
			for (int i = 0; i < allHits.Length; i++)
			{
				if (checkVisibility && allHits[i].Entity != attacker && registerPlayerHitLookup.objectDataLookup.HasComponent(allHits[i].Entity) && (!registerPlayerHitLookup.ownerLookup.HasComponent(attacker) || registerPlayerHitLookup.ownerLookup[attacker].owner != allHits[i].Entity))
				{
					flag = true;
					break;
				}
				if (registerPlayerHitLookup.objectCategoryTagsLookup.TryGetComponent(allHits[i].Entity, out var componentData5) && ObjectCategoryTagsCD.HasTag(componentData5.tagsBitMask, ObjectCategoryTag.DamageCantGoThrough))
				{
					flag = true;
					break;
				}
			}
		}
		allHits.Dispose();
		if (!flag && checkVisibility)
		{
			float3 x = float6 - float5;
			float3 x2 = math.normalizesafe(x);
			float maxDist = math.length(x);
			if (SinglePugMap.RaycastWalls(float5.ToFloat2(), x2.ToFloat2(), maxDist, out var _, tileAccessor))
			{
				flag = true;
			}
		}
		if (flag)
		{
			return false;
		}
		EntityPartCD componentData6;
		Entity entity = ((registerPlayerHitLookup.entityPartLookup.TryGetComponent(attacker, out componentData6) && componentData6.mainEntity != Entity.Null) ? componentData6.mainEntity : attacker);
		registerPlayerHitLookup.healthLookup.TryGetComponent(playerEntity, out var componentData7);
		registerPlayerHitLookup.healthLookup.TryGetComponent(entity, out var componentData8);
		registerPlayerHitLookup.objectTypeLookup.TryGetComponent(playerEntity, out var componentData9);
		registerPlayerHitLookup.manaLookup.TryGetComponent(playerEntity, out var componentData10);
		registerPlayerHitLookup.magicBarrierLookup.TryGetComponent(playerEntity, out var componentData11);
		registerPlayerHitLookup.phaseTransitionStateLookup.TryGetComponent(playerEntity, out var componentData12);
		NativeList<ConditionData> appliedConditions = new NativeList<ConditionData>(Allocator.Temp);
		NativeList<ConditionData> appliedConditionsOnAttacker = new NativeList<ConditionData>(Allocator.Temp);
		NativeList<ConditionID> removedConditions = new NativeList<ConditionID>(Allocator.Temp);
		NativeList<ConditionID> removedConditionsFromAttacker = new NativeList<ConditionID>(Allocator.Temp);
		NativeArray<SummarizedConditionsBuffer> conditionValuesArray = EntityUtility.GetConditionValuesArray(entity, registerPlayerHitLookup.summarizeConiditionsLookup);
		NativeArray<SummarizedConditionEffectsBuffer> conditionEffectsValuesArray = EntityUtility.GetConditionEffectsValuesArray(entity, registerPlayerHitLookup.summarizeConiditionsEffectsLookup);
		NativeArray<SummarizedConditionEffectsBuffer> conditionEffectsValuesArray2 = EntityUtility.GetConditionEffectsValuesArray(playerEntity, registerPlayerHitLookup.summarizeConiditionsEffectsLookup);
		NativeArray<SummarizedConditionsBuffer> conditionValuesArray2 = EntityUtility.GetConditionValuesArray(playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup);
		bool receiverIsInMinecart = playerStateCD.HasAnyState(PlayerStateEnum.MinecartRiding);
		int num = EntityUtility.CalculateDamage(EntityUtility.GetOwnerInfo(registerPlayerHitLookup.entityPartLookup, registerPlayerHitLookup.ownerLookup, registerPlayerHitLookup.summarizeConiditionsLookup, registerPlayerHitLookup.playerGhostLookup, registerPlayerHitLookup.petLookup, registerPlayerHitLookup.minionLookup, registerPlayerHitLookup.bossLookup, registerPlayerHitLookup.healthLookup, registerPlayerHitLookup.enemyLookup, attacker), conditionValuesArray, conditionEffectsValuesArray, conditionValuesArray2, conditionEffectsValuesArray2, ref random, damage, isRanged, isMagic: false, isDigging: false, isReverseDamage, isBoss, isMinion, isPet, receiverIsBoss: false, receiverIsPlayer: true, recieverIsImmuneToRange: false, attackWoundup: false, componentData9, recieverIsDestructible: false, receiverIsInMinecart, isExplosiveDamage, componentData7, componentData8, componentData10, componentData11, componentData, out var didCrit, appliedConditions, appliedConditionsOnAttacker, removedConditions, removedConditionsFromAttacker, componentData12, out didDodge, out var attackerHealthChange, out var _, out var _, out var _, out var _, out var _, out var _, out var _);
		DynamicBuffer<ConditionsBuffer> bufferData;
		bool flag2 = registerPlayerHitLookup.conditionsBufferLookup.TryGetBuffer(entity, out bufferData);
		registerPlayerHitLookup.summarizeConiditionsLookup.TryGetBuffer(entity, out var bufferData2);
		UseOffHandStateCD useOffHandStateCD = registerPlayerHitLookup.useOffHandStateLookup[playerEntity];
		Entity entity2 = (registerPlayerHitLookup.ghostEffectEventBufferLookup.HasComponent(effectEventEntity) ? effectEventEntity : playerEntity);
		RefRW<GhostEffectEventBufferPointerCD> refRW = registerPlayerHitLookup.ghostEffectEventBufferPointerLookup.GetRefRW(entity2);
		bool flag3 = useOffHandStateCD.IsParrying(registerPlayerHitShared.currentTick);
		if (flag3)
		{
			didDodge = false;
		}
		if (PlayerController.IsShielded(playerStateCD, useOffHandStateCD) && (!registerPlayerHitLookup.objectDataLookup.TryGetComponent(entity, out var componentData13) || componentData13.objectID != ObjectID.WallBoss))
		{
			int num2 = (int)math.round((float)num * useOffHandStateCD.shieldedAmount);
			num -= num2;
			if (flag3)
			{
				num = 0;
				for (int num3 = appliedConditions.Length - 1; num3 >= 0; num3--)
				{
					if (appliedConditions[num3].conditionID == ConditionID.Poisoned || appliedConditions[num3].conditionID == ConditionID.Burning || appliedConditions[num3].conditionID == ConditionID.SlowedBySlime || appliedConditions[num3].conditionID == ConditionID.SlipperyMovement || appliedConditions[num3].conditionID == ConditionID.Stunned)
					{
						appliedConditions.RemoveAtSwapBack(num3);
					}
				}
			}
			if (flag3 && conditionEffectsValuesArray.IsCreated && conditionEffectsValuesArray[60].value == 0)
			{
				ConditionData value = new ConditionData
				{
					conditionID = ConditionID.Stunned,
					duration = 2f,
					value = 1,
					valueMultiplier = 1f
				};
				appliedConditionsOnAttacker.Add(in value);
			}
			if (flag3)
			{
				DynamicBuffer<GhostEffectEventBuffer> buffer = registerPlayerHitLookup.ghostEffectEventBufferLookup[entity2];
				ref GhostEffectEventBufferPointerCD valueRW = ref refRW.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = registerPlayerHitShared.currentTick,
					value = new EffectEventCD
					{
						effectID = EffectID.Parry,
						entity = playerEntity,
						entity2 = entity
					}
				};
				buffer.AddToRingBuffer(ref valueRW, in item);
			}
			num = math.max(num, 0);
			DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = registerPlayerHitLookup.inventoryChangeBuffer[registerPlayerHitShared.inventoryChangeBufferEntity];
			int offHandIndex = registerPlayerHitLookup.equipmentLookup[playerEntity].offHandIndex;
			ContainedObjectsBuffer containedObjectsBuffer = registerPlayerHitLookup.containedObjectsBuffer[playerEntity][offHandIndex];
			registerPlayerHitLookup.playerGhostLookup.TryGetComponent(playerEntity, out var _);
			dynamicBuffer.Add(new InventoryChangeBuffer
			{
				inventoryChangeData = Create.SetAmount(playerEntity, offHandIndex, containedObjectsBuffer.objectID, math.max(containedObjectsBuffer.amount - 1, 0)),
				playerEntity = playerEntity
			});
			float num4 = (float)EntityUtility.GetConditionValue(ConditionID.ChanceToApplyPoisonOnBlock, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup) / 100f;
			if (conditionEffectsValuesArray.IsCreated && random.NextFloat() < num4 && EntityUtility.GetConditionEffectValue(ConditionEffect.ImmuneToPoison, entity, registerPlayerHitLookup.summarizeConiditionsEffectsLookup) == 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.Poisoned,
					value = 1,
					duration = 15f
				}, bufferData, registerPlayerHitShared.conditionsTableCD, registerPlayerHitShared.currentTick, registerPlayerHitShared.tickRate, bufferData2);
			}
			float num5 = ((!flag3) ? 1 : 2);
			Direction facingDirection = registerPlayerHitLookup.animationOrientationLookup[playerEntity].facingDirection;
			float num6 = (float)EntityUtility.GetConditionValue(ConditionID.ChanceToShootShockWaveOnBlock, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup) * num5 / 100f;
			if (random.NextFloat() < num6 && registerPlayerHitShared.isFirstTimeFullyPredictingTick)
			{
				float3 direction2 = math.mul(quaternion.RotateY(math.radians(30f)), facingDirection.f3);
				ClientSystem.SpawnProjectile(in registerPlayerHitShared, in registerPlayerHitLookup, ObjectID.ShockWaveProjectile, playerPosition, direction2, playerEntity, num2, weaponIsReinforced: false, ref random, 0, controlledByPlayer: false);
				direction2 = math.mul(quaternion.RotateY(math.radians(-30f)), facingDirection.f3);
				ClientSystem.SpawnProjectile(in registerPlayerHitShared, in registerPlayerHitLookup, ObjectID.ShockWaveProjectile, playerPosition, direction2, playerEntity, num2, weaponIsReinforced: false, ref random, 0, controlledByPlayer: false);
				ClientSystem.SpawnProjectile(in registerPlayerHitShared, in registerPlayerHitLookup, ObjectID.ShockWaveProjectile, playerPosition, facingDirection.f3, playerEntity, num2, weaponIsReinforced: false, ref random, 0, controlledByPlayer: false);
			}
			int conditionValue = EntityUtility.GetConditionValue(ConditionID.DealAoeFireDamageOnBlock, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup);
			if (conditionValue > 0 && registerPlayerHitShared.isFirstTimeFullyPredictingTick)
			{
				ClientSystem.SpawnMortar(in registerPlayerHitShared, in registerPlayerHitLookup, ObjectID.FireAoeDamage, playerPosition, playerPosition, playerEntity, conditionValue, 0, ref random);
			}
		}
		DynamicBuffer<ConditionsBuffer> conditionsBuffer = registerPlayerHitLookup.conditionsBufferLookup[playerEntity];
		DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer = registerPlayerHitLookup.summarizeConiditionsLookup[playerEntity];
		for (int j = 0; j < appliedConditions.Length; j++)
		{
			EntityUtility.AddOrRefreshCondition(appliedConditions[j], conditionsBuffer, registerPlayerHitShared.conditionsTableCD, registerPlayerHitShared.currentTick, registerPlayerHitShared.tickRate, summarizedConditionsBuffer);
		}
		appliedConditions.Dispose();
		for (int k = 0; k < removedConditions.Length; k++)
		{
			EntityUtility.RemoveCondition(removedConditions[k], conditionsBuffer);
		}
		removedConditions.Dispose();
		if (flag2)
		{
			for (int l = 0; l < appliedConditionsOnAttacker.Length; l++)
			{
				EntityUtility.AddOrRefreshCondition(appliedConditionsOnAttacker[l], bufferData, registerPlayerHitShared.conditionsTableCD, registerPlayerHitShared.currentTick, registerPlayerHitShared.tickRate, bufferData2);
			}
			for (int m = 0; m < removedConditionsFromAttacker.Length; m++)
			{
				EntityUtility.RemoveCondition(removedConditionsFromAttacker[m], bufferData);
			}
		}
		removedConditionsFromAttacker.Dispose();
		appliedConditionsOnAttacker.Dispose();
		int conditionValue2 = EntityUtility.GetConditionValue(ConditionID.MovementSpeedBoostAfterDodge, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup);
		if (didDodge && conditionValue2 > 0)
		{
			EntityUtility.AddOrRefreshCondition(new ConditionData
			{
				conditionID = ConditionID.ShortMovementSpeedBoost,
				value = conditionValue2,
				duration = 5f
			}, conditionsBuffer, registerPlayerHitShared.conditionsTableCD, registerPlayerHitShared.currentTick, registerPlayerHitShared.tickRate, summarizedConditionsBuffer);
		}
		int conditionValue3 = EntityUtility.GetConditionValue(ConditionID.GainAttackSpeedBoostAfterDodge, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup);
		if (didDodge && conditionValue3 > 0)
		{
			EntityUtility.AddOrRefreshCondition(new ConditionData
			{
				conditionID = ConditionID.AttackSpeedBoostAfterDodge,
				value = conditionValue3,
				duration = 5f
			}, conditionsBuffer, registerPlayerHitShared.conditionsTableCD, registerPlayerHitShared.currentTick, registerPlayerHitShared.tickRate, summarizedConditionsBuffer);
		}
		int num7 = num;
		if (!didDodge)
		{
			num7 = PlayerController.DealDamageToPlayer(playerEntity, attacker, num, damageEffectType, hitWorldPosition, attackerPosition, direction, pushback, isExplosiveDamage, registerPlayerHitLookup.playerStateLookup, registerPlayerHitLookup.lastDamageTakenTimeLookup, registerPlayerHitLookup.playerInvincibilityLookup, registerPlayerHitLookup.healthLookup, registerPlayerHitLookup.localTransformLookup, registerPlayerHitLookup.magicBarrierLookup, registerPlayerHitLookup.manaLookup, registerPlayerHitLookup.summarizeConiditionsLookup, registerPlayerHitLookup.summarizeConiditionsEffectsLookup, registerPlayerHitLookup.ghostEffectEventBufferLookup, registerPlayerHitLookup.ghostEffectEventBufferPointerLookup, registerPlayerHitLookup.ghostInstanceLookup, registerPlayerHitLookup.receivedPushbackLookup, registerPlayerHitLookup.factionLookup, registerPlayerHitLookup.ownerLookup, registerPlayerHitShared.worldInfo, registerPlayerHitShared.currentTick, registerPlayerHitShared.tickRate);
			registerPlayerHitLookup.reduceDurabilityOfAllEquipmentTriggerLookup.SetComponentEnabled(playerEntity, value: true);
			registerPlayerHitLookup.reduceDurabilityOfAllEquipmentTriggerLookup.GetRefRW(playerEntity).ValueRW.damage += num;
			if (EntityUtility.GetConditionValue(ConditionID.SpawnExplosionOnDamageTaken, playerEntity, registerPlayerHitLookup.summarizeConiditionsLookup) > 0 && registerPlayerHitShared.isFirstTimeFullyPredictingTick && (!registerPlayerHitShared.worldInfo.guestMode || (registerPlayerHitLookup.playerGhostLookup.TryGetComponent(playerEntity, out var componentData15) && componentData15.adminPrivileges > 0)))
			{
				int value2 = registerPlayerHitLookup.summarizeConiditionsEffectsLookup[playerEntity][119].value;
				ClientSystem.SpawnExplosion(in registerPlayerHitShared, in registerPlayerHitLookup, ObjectID.SulfurSetPuffExplosion, playerPosition, playerEntity, value2, 2f, ref random);
			}
		}
		if (((num7 > 0) | didDodge) || flag3)
		{
			_ = registerPlayerHitLookup.useOffHandStateLookup[playerEntity];
			if (registerPlayerHitLookup.ghostEffectEventBufferLookup.HasBuffer(entity2))
			{
				DynamicBuffer<GhostEffectEventBuffer> buffer2 = registerPlayerHitLookup.ghostEffectEventBufferLookup[entity2];
				ref GhostEffectEventBufferPointerCD valueRW2 = ref refRW.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = registerPlayerHitShared.currentTick,
					value = new EffectEventCD
					{
						entity = playerEntity,
						effectID = (didDodge ? EffectID.Dodge : (flag3 ? EffectID.Parry : (didCrit ? EffectID.CritNumber : EffectID.RedDamageNumber))),
						value1 = num7,
						value2 = (int)damageEffectType,
						entity2 = attacker
					}
				};
				buffer2.AddToRingBuffer(ref valueRW2, in item);
			}
		}
		if (didDodge && !treatDodgeAsHit)
		{
			return false;
		}
		if (triggerAnimationOnHit == -414722770)
		{
			reverseDamage = 1000000;
			registerPlayerHitLookup.localTransformLookup.GetRefRW(attacker).ValueRW.Position = hitWorldPosition;
			if (registerPlayerHitLookup.moveToPredictedByCombatInteractionLookup.HasComponent(entity))
			{
				registerPlayerHitLookup.moveToPredictedByCombatInteractionLookup.GetRefRW(attacker).ValueRW.SetLastInteractionTick(registerPlayerHitShared.currentTick);
			}
		}
		if (flag3 && !registerPlayerHitLookup.immuneToPushBackLookup.HasComponent(entity))
		{
			reversePushback += 1f;
		}
		if (reversePushback != 0f)
		{
			float2 float7 = -direction.xz;
			if (math.all(float7 == float2.zero))
			{
				float7 = math.normalizesafe(attackerPosition.xz - playerPosition.xz);
			}
			if (math.any(float7 != float2.zero) && registerPlayerHitLookup.physicsVelocityLookup.HasComponent(entity))
			{
				NetworkTick currentTick = registerPlayerHitShared.currentTick;
				currentTick.Increment();
				registerPlayerHitLookup.physicsVelocityLookup.GetRefRW(entity).ValueRW.Linear = float3.zero;
				EntityUtility.TryAddPushback(entity, float7 * reversePushback, currentTick, registerPlayerHitShared.tickRate, registerPlayerHitLookup.immuneToPushBackLookup, registerPlayerHitLookup.receivedPushbackLookup, registerPlayerHitLookup.moveToPredictedByPushbackLookup, hitWorldPosition);
				if (registerPlayerHitLookup.moveToPredictedByCombatInteractionLookup.HasComponent(entity))
				{
					registerPlayerHitLookup.moveToPredictedByCombatInteractionLookup.GetRefRW(entity).ValueRW.SetLastInteractionTick(registerPlayerHitShared.currentTick);
				}
			}
		}
		if (triggerAnimationOnHit != 0 && registerPlayerHitLookup.animationBufferLookup.HasComponent(entity))
		{
			AnimationUtilities.TriggerAnimation(triggerAnimationOnHit, registerPlayerHitShared.currentTick, registerPlayerHitLookup.animationBufferLookup[entity], ref registerPlayerHitLookup.animationBufferPointerLookup.GetRefRW(entity).ValueRW);
		}
		ImmuneToDamageCD componentData16;
		bool flag4 = registerPlayerHitLookup.immuneToDamageLookup.TryGetComponent(entity, out componentData16) && componentData16.Value == ImmuneToDamageState.Immune;
		if (registerPlayerHitLookup.simulateLookup.HasAndIsComponentEnabled(playerEntity))
		{
			if (attackerHealthChange != 0 && !isReverseDamage && !flag4 && !registerPlayerHitLookup.attackContinuouslyLookup.HasComponent(entity))
			{
				registerPlayerHitLookup.dealDamageToEntityBuffer[playerEntity].Add(new DealDamageToEntityBuffer
				{
					entity = entity,
					wasHitWhenAtPosition = attackerPosition,
					damage = -attackerHealthChange,
					hitPosition = hitWorldPosition,
					isRanged = false,
					isMagic = false,
					hitEntityPart = Entity.Null,
					shoudShowHitFeedbackOnHitEntityPart = false,
					attackType = DealDamageToEntityBuffer.AttackType.ReverseDirectDamage,
					isThorns = true
				});
			}
			if (reverseDamage > 0 && !isReverseDamage && registerPlayerHitLookup.simulateLookup.HasAndIsComponentEnabled(playerEntity))
			{
				registerPlayerHitLookup.dealDamageToEntityBuffer[playerEntity].Add(new DealDamageToEntityBuffer
				{
					entity = entity,
					wasHitWhenAtPosition = attackerPosition,
					damage = reverseDamage,
					hitPosition = hitWorldPosition,
					isRanged = false,
					isMagic = false,
					hitEntityPart = Entity.Null,
					shoudShowHitFeedbackOnHitEntityPart = false,
					attackType = DealDamageToEntityBuffer.AttackType.ReverseDirectDamage
				});
			}
		}
		return true;
	}

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<SpawnedGhostEntityMap>();
		state.RequireForUpdate<GhostCollection>();
		state.RequireForUpdate<InventoryChangeBuffer>();
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<NetworkId>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate(__query_1392775730_0);
		_registerPlayerHitLookup = RegisterPlayerHitLookup.Create(ref state);
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_spawnBufferHelper = new SnapshotDataLookupHelper(ref state, __query_1392775730_1.GetSingletonEntity(), __query_1392775730_2.GetSingletonEntity());
		_tileAccessor = new TileAccessor(ref state);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_1392775730_3.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		ClientServerTickRate singleton = __query_1392775730_4.GetSingleton<ClientServerTickRate>();
		EntityCommandBuffer ecb = __query_1392775730_5.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		_registerPlayerHitLookup.Update(ref state);
		_tileAccessor.Update(ref state);
		NativeList<PlayerConnection> connections = new NativeList<PlayerConnection>(state.WorldUpdateAllocator);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new CreatePlayerConnectionListJob
		{
			connections = connections
		}, __TypeHandle.__AttackPlayerSystem_CreatePlayerConnectionListJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		RegisterPlayerHitShared registerPlayerHitShared = new RegisterPlayerHitShared
		{
			ecb = ecb,
			currentTick = value.ServerTick,
			databaseBank = __query_1392775730_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
			physicsWorld = __query_1392775730_7.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld,
			physicsWorldHistory = __query_1392775730_8.GetSingleton<PhysicsWorldHistorySingleton>(),
			worldInfo = __query_1392775730_9.GetSingleton<WorldInfoCD>(),
			conditionsTableCD = __query_1392775730_10.GetSingleton<ConditionsTableCD>(),
			isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
			tickRate = (uint)singleton.SimulationTickRate,
			inventoryChangeBufferEntity = __query_1392775730_11.GetSingletonEntity(),
			SpawnedGhostMap = __query_1392775730_2.GetSingleton<SpawnedGhostEntityMap>().Value,
			attackSystemData = __query_1392775730_12.GetSingleton<AttackSystemData>()
		};
		state.Dependency = IJobExtensions.Schedule(new ClearHitPlayerLookupJob
		{
			attackSystemData = registerPlayerHitShared.attackSystemData
		}, state.Dependency);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new TryAttackPlayerFromRPCJob
		{
			connections = connections,
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
			clientInputLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ClientInput_RO_ComponentLookup, ref state),
			attackPlayerPositionBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__AttackPlayerPositionBuffer_RW_BufferLookup, ref state),
			snapshotDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_SnapshotData_RO_ComponentLookup, ref state),
			snapshotDataBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Unity_NetCode_SnapshotDataBuffer_RO_BufferLookup, ref state),
			predictedGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_PredictedGhost_RO_ComponentLookup, ref state),
			playerRecentAttackersBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PlayerRecentAttackersBuffer_RW_BufferLookup, ref state),
			playerRecentAttackersBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerRecentAttackersBufferPointerCD_RW_ComponentLookup, ref state),
			registerPlayerHitShared = registerPlayerHitShared,
			tileAccessor = _tileAccessor,
			serverTick = serverTick,
			tickRate = (uint)singleton.SimulationTickRate,
			isFirstPredictionTick = value.IsFirstPredictionTick,
			isServerLocal = state.WorldUnmanaged.IsServer(),
			clientServerTickRate = singleton,
			registerPlayerHitLookup = _registerPlayerHitLookup,
			colliderCastHits = new NativeList<ColliderCastHit>(state.WorldUpdateAllocator),
			spawnBufferLookupHelper = _spawnBufferHelper
		}, __TypeHandle.__AttackPlayerSystem_TryAttackPlayerFromRPCJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(CreatePlayerConnectionListJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__AttackPlayerSystem_CreatePlayerConnectionListJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__AttackPlayerSystem_CreatePlayerConnectionListJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__AttackPlayerSystem_CreatePlayerConnectionListJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__AttackPlayerSystem_CreatePlayerConnectionListJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(TryAttackPlayerFromRPCJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__AttackPlayerSystem_TryAttackPlayerFromRPCJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__AttackPlayerSystem_TryAttackPlayerFromRPCJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__AttackPlayerSystem_TryAttackPlayerFromRPCJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__AttackPlayerSystem_TryAttackPlayerFromRPCJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<AttackSystemData>();
		__query_1392775730_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostCollection>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnedGhostEntityMap>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldHistorySingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_11 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<AttackSystemData>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1392775730_12 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((AttackPlayerSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000002D7_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_000002D8_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_000002D9_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((AttackPlayerSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AttackPlayerSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AttackPlayerSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((AttackPlayerSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
