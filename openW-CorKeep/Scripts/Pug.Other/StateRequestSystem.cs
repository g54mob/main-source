using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Automation;
using Pug.Properties;
using Pug.UnityExtensions;
using RayAttackState;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(StateRequestGroup))]
public struct StateRequestSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct RecordExtrapolatedEntitiesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerGhostExtrapolated> __PlayerGhostExtrapolated_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PlayerGhostExtrapolated_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhostExtrapolated>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PlayerGhostExtrapolated_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<PlayerGhostExtrapolated>().Build(ref state);
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
			public void Run(ref RecordExtrapolatedEntitiesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RecordExtrapolatedEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RecordExtrapolatedEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RecordExtrapolatedEntitiesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RecordExtrapolatedEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RecordExtrapolatedEntitiesJob job, EntityManager entityManager)
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

		public NativeList<Entity> playerExtrapolatedEntities;

		public NativeList<Entity> playerEntities;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in PlayerGhostExtrapolated playerGhostExtrapolated)
		{
			playerExtrapolatedEntities.Add(in entity);
			playerEntities.Add(in playerGhostExtrapolated.playerGhost);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhostExtrapolated>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhostExtrapolated>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhostExtrapolated>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhostExtrapolated>(nativeArrayPtr2, k));
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
	private struct UpdateJob : IJobChunk
	{
		public Requesters Requesters;

		public StateRequestData Data;

		public StateRequestContainers Containers;

		public EntityCommandBuffer EntityCommandBuffer;

		[ReadOnly]
		public EntityTypeHandle Entity;

		public ComponentTypeHandle<StateInfoCD> StateInfo;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			if (chunk.Count != 0)
			{
				NativeArray<Entity> nativeArray = chunk.GetNativeArray(Entity);
				NativeArray<bool> shouldUpdate = new NativeArray<bool>(Requesters.Count, Allocator.Temp);
				Requesters.ShouldUpdate(nativeArray[0], ref Data, ref Containers, ref shouldUpdate);
				Requesters.OnUpdate(nativeArray, StateInfo, chunk, EntityCommandBuffer, ref Data, ref Containers, ref shouldUpdate);
				shouldUpdate.Dispose();
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct Requesters
	{
		public DeathStateRequest _death;

		public PlayAnimationStateRequest _playAnimation;

		public BossLarvaSpawnStateRequest _bossLarvaSpawn;

		public GiantCicadaBossAppearStateRequest _giantCicadaBossAppear;

		public BirdBossAppearStateRequest _birdBossAppear;

		public OctopusBossAppearStateRequest _octopusBossAppear;

		public ScarabBossAppearStateRequest _scarabBossAppear;

		public EnemyStagesStateRequest _enemyStages;

		public PhaseTransitionStateRequest _phaseTransition;

		public ScarabBossChargeStateRequest _scarabBossCharge;

		public LarvaHiveEggHatchStateRequest _larvaHiveEggHatch;

		public EnrageStateRequest _enrage;

		public LarvaHiveBossHatchStateRequest _larvaHiveBossHatch;

		public StunnedStateRequest _stunned;

		public ExplodeStateRequest _explode;

		public EvolveStateRequest _evolve;

		public PlaceObjectStateRequest _placeObject;

		public ShootMortarStateRequest _shootMortar;

		public TookDamageStateRequest _tookDamage;

		public SpawnStateRequest _spawn;

		public BushStateRequest _bush;

		public JumpAttackStateRequest _jumpAttack;

		public HealOtherEntityStateRequest _healOtherEntity;

		public BeamAttackStateRequest _beamAttack;

		public RayAttackStateRequest _rayAttack;

		public ChargeAttackStateRequest _chargeAttack;

		public MeleeAttackStateRequest _meleeAttack;

		public AttackContinuouslyStateRequest _attackContinuously;

		public RangeAttackStateRequest _rangeAttack;

		public SlimeBossJumpStateRequest _slimeBossJump;

		public GiantCicadaSlamArmsStateRequest _giantCicadaBossSlamArms;

		public BirdBossSpawnStonesStateRequest _birdBossSpawnStones;

		public BirdBossSpawnBeamsStateRequest _birdBossSpawnBeams;

		public CoreBossSpawnBeamsStateRequest _coreBossSpawnBeams;

		public CoreBossSpawnVoidStateRequest _coreBossSpawnVoid;

		public OctopusBossSpawnTentacleStateRequest _octopusBossSpawnTentacle;

		public TeleportStateRequest _teleport;

		public BreedStateRequest _breed;

		public EatStateRequest _eat;

		public IdleWhenNearbyPlayerStateRequest _idleWhenNearbyPlayer;

		public CombatEmoteSystemRequest _combatEmote;

		public ChaseStateRequest _chase;

		public PheromoneStateRequest _pheromone;

		public DamageObjectStateRequest _damageObject;

		public HatchWhenPlayerNearbyStateRequest _hatchWhenPlayerNearby;

		public ActivatedByElectricityStateRequest _activatedByElectricity;

		public SnakeMovementStateRequest _snakeMovement;

		public SleepStateRequest _sleep;

		public IdleEmoteStateRequest _idleEmote;

		public AlertEmoteStateRequest _alertEmote;

		public PetWalkStateRequest _petWalk;

		public RandomFollowStateRequest _randomFollow;

		public RoamingStateRequest _roaming;

		public RandomWalkStateRequest _randomWalk;

		public IdleInCombatStateRequest _idleInCombat;

		public BirdBossFlyingStateRequest _birdBossFlying;

		public OctopusBossLurkStateRequest _octopusBossLurk;

		public ScarabBossBuriedStateRequest _scarabBossBuried;

		public HydraBossBuriedCombatStateRequest _hydraBossBuriedCombat;

		public HydraBossBuriedRoamingStateRequest _hydraBossBuriedRoaming;

		public VulnerableStateRequest _vulnerable;

		public MoveToPositionFromCommandStateRequest _moveToPositionFromCommand;

		public int Count => 62;

		public void ShouldUpdate(Entity entity, ref StateRequestData data, ref StateRequestContainers ctrs, ref NativeArray<bool> shouldUpdate)
		{
			int num = 0;
			shouldUpdate[num++] = _death.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _playAnimation.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _bossLarvaSpawn.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _giantCicadaBossAppear.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _birdBossAppear.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _octopusBossAppear.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _scarabBossAppear.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _enemyStages.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _phaseTransition.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _scarabBossCharge.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _vulnerable.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _hydraBossBuriedCombat.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _larvaHiveEggHatch.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _enrage.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _larvaHiveBossHatch.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _stunned.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _explode.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _evolve.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _placeObject.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _shootMortar.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _tookDamage.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _spawn.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _bush.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _moveToPositionFromCommand.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _petWalk.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _jumpAttack.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _healOtherEntity.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _beamAttack.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _rayAttack.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _chargeAttack.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _meleeAttack.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _attackContinuously.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _rangeAttack.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _slimeBossJump.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _giantCicadaBossSlamArms.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _birdBossSpawnStones.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _birdBossSpawnBeams.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _coreBossSpawnBeams.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _coreBossSpawnVoid.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _octopusBossSpawnTentacle.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _teleport.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _breed.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _eat.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _idleWhenNearbyPlayer.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _combatEmote.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _chase.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _pheromone.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _damageObject.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _hatchWhenPlayerNearby.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _activatedByElectricity.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _snakeMovement.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _sleep.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _idleEmote.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _alertEmote.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _hydraBossBuriedRoaming.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _randomFollow.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _roaming.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _randomWalk.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _idleInCombat.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _birdBossFlying.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _octopusBossLurk.ShouldUpdate(entity, ref data, ref ctrs);
			shouldUpdate[num++] = _scarabBossBuried.ShouldUpdate(entity, ref data, ref ctrs);
		}

		public void OnUpdate(NativeArray<Entity> entities, ComponentTypeHandle<StateInfoCD> stateInfoTypeHandle, ArchetypeChunk batchInChunk, EntityCommandBuffer ecb, ref StateRequestData data, ref StateRequestContainers ctrs, ref NativeArray<bool> shouldUpdate)
		{
			NativeArray<StateInfoCD> nativeArray = batchInChunk.GetNativeArray(stateInfoTypeHandle);
			int num = 0;
			if (shouldUpdate[num++])
			{
				for (int i = 0; i < batchInChunk.Count; i++)
				{
					StateInfoCD stateInfo = nativeArray[i];
					_death.OnUpdate(entities[i], ecb, ref data, ref ctrs, ref stateInfo);
					nativeArray[i] = stateInfo;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int j = 0; j < batchInChunk.Count; j++)
				{
					StateInfoCD stateInfo2 = nativeArray[j];
					_playAnimation.OnUpdate(entities[j], ecb, ref data, ref ctrs, ref stateInfo2);
					nativeArray[j] = stateInfo2;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int k = 0; k < batchInChunk.Count; k++)
				{
					StateInfoCD stateInfo3 = nativeArray[k];
					_bossLarvaSpawn.OnUpdate(entities[k], ecb, ref data, ref ctrs, ref stateInfo3);
					nativeArray[k] = stateInfo3;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int l = 0; l < batchInChunk.Count; l++)
				{
					StateInfoCD stateInfo4 = nativeArray[l];
					_giantCicadaBossAppear.OnUpdate(entities[l], ecb, ref data, ref ctrs, ref stateInfo4);
					nativeArray[l] = stateInfo4;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int m = 0; m < batchInChunk.Count; m++)
				{
					StateInfoCD stateInfo5 = nativeArray[m];
					_birdBossAppear.OnUpdate(entities[m], ecb, ref data, ref ctrs, ref stateInfo5);
					nativeArray[m] = stateInfo5;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int n = 0; n < batchInChunk.Count; n++)
				{
					StateInfoCD stateInfo6 = nativeArray[n];
					_octopusBossAppear.OnUpdate(entities[n], ecb, ref data, ref ctrs, ref stateInfo6);
					nativeArray[n] = stateInfo6;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num2 = 0; num2 < batchInChunk.Count; num2++)
				{
					StateInfoCD stateInfo7 = nativeArray[num2];
					_scarabBossAppear.OnUpdate(entities[num2], ecb, ref data, ref ctrs, ref stateInfo7);
					nativeArray[num2] = stateInfo7;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num3 = 0; num3 < batchInChunk.Count; num3++)
				{
					StateInfoCD stateInfo8 = nativeArray[num3];
					_enemyStages.OnUpdate(entities[num3], ecb, ref data, ref ctrs, ref stateInfo8);
					nativeArray[num3] = stateInfo8;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num4 = 0; num4 < batchInChunk.Count; num4++)
				{
					StateInfoCD stateInfo9 = nativeArray[num4];
					_phaseTransition.OnUpdate(entities[num4], ecb, ref data, ref ctrs, ref stateInfo9);
					nativeArray[num4] = stateInfo9;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num5 = 0; num5 < batchInChunk.Count; num5++)
				{
					StateInfoCD stateInfo10 = nativeArray[num5];
					_scarabBossCharge.OnUpdate(entities[num5], ecb, ref data, ref ctrs, ref stateInfo10);
					nativeArray[num5] = stateInfo10;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num6 = 0; num6 < batchInChunk.Count; num6++)
				{
					StateInfoCD stateInfo11 = nativeArray[num6];
					_vulnerable.OnUpdate(entities[num6], ecb, ref data, ref ctrs, ref stateInfo11);
					nativeArray[num6] = stateInfo11;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num7 = 0; num7 < batchInChunk.Count; num7++)
				{
					StateInfoCD stateInfo12 = nativeArray[num7];
					_hydraBossBuriedCombat.OnUpdate(entities[num7], ecb, ref data, ref ctrs, ref stateInfo12);
					nativeArray[num7] = stateInfo12;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num8 = 0; num8 < batchInChunk.Count; num8++)
				{
					StateInfoCD stateInfo13 = nativeArray[num8];
					_larvaHiveEggHatch.OnUpdate(entities[num8], ecb, ref data, ref ctrs, ref stateInfo13);
					nativeArray[num8] = stateInfo13;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num9 = 0; num9 < batchInChunk.Count; num9++)
				{
					StateInfoCD stateInfo14 = nativeArray[num9];
					_enrage.OnUpdate(entities[num9], ecb, ref data, ref ctrs, ref stateInfo14);
					nativeArray[num9] = stateInfo14;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num10 = 0; num10 < batchInChunk.Count; num10++)
				{
					StateInfoCD stateInfo15 = nativeArray[num10];
					_larvaHiveBossHatch.OnUpdate(entities[num10], ecb, ref data, ref ctrs, ref stateInfo15);
					nativeArray[num10] = stateInfo15;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num11 = 0; num11 < batchInChunk.Count; num11++)
				{
					StateInfoCD stateInfo16 = nativeArray[num11];
					_stunned.OnUpdate(entities[num11], ecb, ref data, ref ctrs, ref stateInfo16);
					nativeArray[num11] = stateInfo16;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num12 = 0; num12 < batchInChunk.Count; num12++)
				{
					StateInfoCD stateInfo17 = nativeArray[num12];
					_explode.OnUpdate(entities[num12], ecb, ref data, ref ctrs, ref stateInfo17);
					nativeArray[num12] = stateInfo17;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num13 = 0; num13 < batchInChunk.Count; num13++)
				{
					StateInfoCD stateInfo18 = nativeArray[num13];
					_evolve.OnUpdate(entities[num13], ecb, ref data, ref ctrs, ref stateInfo18);
					nativeArray[num13] = stateInfo18;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num14 = 0; num14 < batchInChunk.Count; num14++)
				{
					StateInfoCD stateInfo19 = nativeArray[num14];
					_placeObject.OnUpdate(entities[num14], ecb, ref data, ref ctrs, ref stateInfo19);
					nativeArray[num14] = stateInfo19;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num15 = 0; num15 < batchInChunk.Count; num15++)
				{
					StateInfoCD stateInfo20 = nativeArray[num15];
					_shootMortar.OnUpdate(entities[num15], ecb, ref data, ref ctrs, ref stateInfo20);
					nativeArray[num15] = stateInfo20;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num16 = 0; num16 < batchInChunk.Count; num16++)
				{
					StateInfoCD stateInfo21 = nativeArray[num16];
					_tookDamage.OnUpdate(entities[num16], ecb, ref data, ref ctrs, ref stateInfo21);
					nativeArray[num16] = stateInfo21;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num17 = 0; num17 < batchInChunk.Count; num17++)
				{
					StateInfoCD stateInfo22 = nativeArray[num17];
					_spawn.OnUpdate(entities[num17], ecb, ref data, ref ctrs, ref stateInfo22);
					nativeArray[num17] = stateInfo22;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num18 = 0; num18 < batchInChunk.Count; num18++)
				{
					StateInfoCD stateInfo23 = nativeArray[num18];
					_bush.OnUpdate(entities[num18], ecb, ref data, ref ctrs, ref stateInfo23);
					nativeArray[num18] = stateInfo23;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num19 = 0; num19 < batchInChunk.Count; num19++)
				{
					StateInfoCD stateInfo24 = nativeArray[num19];
					_moveToPositionFromCommand.OnUpdate(entities[num19], ecb, ref data, ref ctrs, ref stateInfo24);
					nativeArray[num19] = stateInfo24;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num20 = 0; num20 < batchInChunk.Count; num20++)
				{
					StateInfoCD stateInfo25 = nativeArray[num20];
					_petWalk.OnUpdate(entities[num20], ecb, ref data, ref ctrs, ref stateInfo25);
					nativeArray[num20] = stateInfo25;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num21 = 0; num21 < batchInChunk.Count; num21++)
				{
					StateInfoCD stateInfo26 = nativeArray[num21];
					_jumpAttack.OnUpdate(entities[num21], ecb, ref data, ref ctrs, ref stateInfo26);
					nativeArray[num21] = stateInfo26;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num22 = 0; num22 < batchInChunk.Count; num22++)
				{
					StateInfoCD stateInfo27 = nativeArray[num22];
					_healOtherEntity.OnUpdate(entities[num22], ecb, ref data, ref ctrs, ref stateInfo27);
					nativeArray[num22] = stateInfo27;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num23 = 0; num23 < batchInChunk.Count; num23++)
				{
					StateInfoCD stateInfo28 = nativeArray[num23];
					_beamAttack.OnUpdate(entities[num23], ecb, ref data, ref ctrs, ref stateInfo28);
					nativeArray[num23] = stateInfo28;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num24 = 0; num24 < batchInChunk.Count; num24++)
				{
					StateInfoCD stateInfo29 = nativeArray[num24];
					_rayAttack.OnUpdate(entities[num24], ecb, ref data, ref ctrs, ref stateInfo29);
					nativeArray[num24] = stateInfo29;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num25 = 0; num25 < batchInChunk.Count; num25++)
				{
					StateInfoCD stateInfo30 = nativeArray[num25];
					_chargeAttack.OnUpdate(entities[num25], ecb, ref data, ref ctrs, ref stateInfo30);
					nativeArray[num25] = stateInfo30;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num26 = 0; num26 < batchInChunk.Count; num26++)
				{
					StateInfoCD stateInfo31 = nativeArray[num26];
					_meleeAttack.OnUpdate(entities[num26], ecb, ref data, ref ctrs, ref stateInfo31);
					nativeArray[num26] = stateInfo31;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num27 = 0; num27 < batchInChunk.Count; num27++)
				{
					StateInfoCD stateInfo32 = nativeArray[num27];
					_attackContinuously.OnUpdate(entities[num27], ecb, ref data, ref ctrs, ref stateInfo32);
					nativeArray[num27] = stateInfo32;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num28 = 0; num28 < batchInChunk.Count; num28++)
				{
					StateInfoCD stateInfo33 = nativeArray[num28];
					_rangeAttack.OnUpdate(entities[num28], ecb, ref data, ref ctrs, ref stateInfo33);
					nativeArray[num28] = stateInfo33;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num29 = 0; num29 < batchInChunk.Count; num29++)
				{
					StateInfoCD stateInfo34 = nativeArray[num29];
					_slimeBossJump.OnUpdate(entities[num29], ecb, ref data, ref ctrs, ref stateInfo34);
					nativeArray[num29] = stateInfo34;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num30 = 0; num30 < batchInChunk.Count; num30++)
				{
					StateInfoCD stateInfo35 = nativeArray[num30];
					_giantCicadaBossSlamArms.OnUpdate(entities[num30], ecb, ref data, ref ctrs, ref stateInfo35);
					nativeArray[num30] = stateInfo35;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num31 = 0; num31 < batchInChunk.Count; num31++)
				{
					StateInfoCD stateInfo36 = nativeArray[num31];
					_birdBossSpawnStones.OnUpdate(entities[num31], ecb, ref data, ref ctrs, ref stateInfo36);
					nativeArray[num31] = stateInfo36;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num32 = 0; num32 < batchInChunk.Count; num32++)
				{
					StateInfoCD stateInfo37 = nativeArray[num32];
					_birdBossSpawnBeams.OnUpdate(entities[num32], ecb, ref data, ref ctrs, ref stateInfo37);
					nativeArray[num32] = stateInfo37;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num33 = 0; num33 < batchInChunk.Count; num33++)
				{
					StateInfoCD stateInfo38 = nativeArray[num33];
					_coreBossSpawnBeams.OnUpdate(entities[num33], ecb, ref data, ref ctrs, ref stateInfo38);
					nativeArray[num33] = stateInfo38;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num34 = 0; num34 < batchInChunk.Count; num34++)
				{
					StateInfoCD stateInfo39 = nativeArray[num34];
					_coreBossSpawnVoid.OnUpdate(entities[num34], ecb, ref data, ref ctrs, ref stateInfo39);
					nativeArray[num34] = stateInfo39;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num35 = 0; num35 < batchInChunk.Count; num35++)
				{
					StateInfoCD stateInfo40 = nativeArray[num35];
					_octopusBossSpawnTentacle.OnUpdate(entities[num35], ecb, ref data, ref ctrs, ref stateInfo40);
					nativeArray[num35] = stateInfo40;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num36 = 0; num36 < batchInChunk.Count; num36++)
				{
					StateInfoCD stateInfo41 = nativeArray[num36];
					_teleport.OnUpdate(entities[num36], ecb, ref data, ref ctrs, ref stateInfo41);
					nativeArray[num36] = stateInfo41;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num37 = 0; num37 < batchInChunk.Count; num37++)
				{
					StateInfoCD stateInfo42 = nativeArray[num37];
					_breed.OnUpdate(entities[num37], ecb, ref data, ref ctrs, ref stateInfo42);
					nativeArray[num37] = stateInfo42;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num38 = 0; num38 < batchInChunk.Count; num38++)
				{
					StateInfoCD stateInfo43 = nativeArray[num38];
					_eat.OnUpdate(entities[num38], ecb, ref data, ref ctrs, ref stateInfo43);
					nativeArray[num38] = stateInfo43;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num39 = 0; num39 < batchInChunk.Count; num39++)
				{
					StateInfoCD stateInfo44 = nativeArray[num39];
					_idleWhenNearbyPlayer.OnUpdate(entities[num39], ecb, ref data, ref ctrs, ref stateInfo44);
					nativeArray[num39] = stateInfo44;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num40 = 0; num40 < batchInChunk.Count; num40++)
				{
					StateInfoCD stateInfo45 = nativeArray[num40];
					_combatEmote.OnUpdate(entities[num40], ecb, ref data, ref ctrs, ref stateInfo45);
					nativeArray[num40] = stateInfo45;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num41 = 0; num41 < batchInChunk.Count; num41++)
				{
					StateInfoCD stateInfo46 = nativeArray[num41];
					_chase.OnUpdate(entities[num41], ecb, ref data, ref ctrs, ref stateInfo46);
					nativeArray[num41] = stateInfo46;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num42 = 0; num42 < batchInChunk.Count; num42++)
				{
					StateInfoCD stateInfo47 = nativeArray[num42];
					_pheromone.OnUpdate(entities[num42], ecb, ref data, ref ctrs, ref stateInfo47);
					nativeArray[num42] = stateInfo47;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num43 = 0; num43 < batchInChunk.Count; num43++)
				{
					StateInfoCD stateInfo48 = nativeArray[num43];
					_damageObject.OnUpdate(entities[num43], ecb, ref data, ref ctrs, ref stateInfo48);
					nativeArray[num43] = stateInfo48;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num44 = 0; num44 < batchInChunk.Count; num44++)
				{
					StateInfoCD stateInfo49 = nativeArray[num44];
					_hatchWhenPlayerNearby.OnUpdate(entities[num44], ecb, ref data, ref ctrs, ref stateInfo49);
					nativeArray[num44] = stateInfo49;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num45 = 0; num45 < batchInChunk.Count; num45++)
				{
					StateInfoCD stateInfo50 = nativeArray[num45];
					_activatedByElectricity.OnUpdate(entities[num45], ecb, ref data, ref ctrs, ref stateInfo50);
					nativeArray[num45] = stateInfo50;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num46 = 0; num46 < batchInChunk.Count; num46++)
				{
					StateInfoCD stateInfo51 = nativeArray[num46];
					_snakeMovement.OnUpdate(entities[num46], ecb, ref data, ref ctrs, ref stateInfo51);
					nativeArray[num46] = stateInfo51;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num47 = 0; num47 < batchInChunk.Count; num47++)
				{
					StateInfoCD stateInfo52 = nativeArray[num47];
					_sleep.OnUpdate(entities[num47], ecb, ref data, ref ctrs, ref stateInfo52);
					nativeArray[num47] = stateInfo52;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num48 = 0; num48 < batchInChunk.Count; num48++)
				{
					StateInfoCD stateInfo53 = nativeArray[num48];
					_idleEmote.OnUpdate(entities[num48], ecb, ref data, ref ctrs, ref stateInfo53);
					nativeArray[num48] = stateInfo53;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num49 = 0; num49 < batchInChunk.Count; num49++)
				{
					StateInfoCD stateInfo54 = nativeArray[num49];
					_alertEmote.OnUpdate(entities[num49], ecb, ref data, ref ctrs, ref stateInfo54);
					nativeArray[num49] = stateInfo54;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num50 = 0; num50 < batchInChunk.Count; num50++)
				{
					StateInfoCD stateInfo55 = nativeArray[num50];
					_hydraBossBuriedRoaming.OnUpdate(entities[num50], ecb, ref data, ref ctrs, ref stateInfo55);
					nativeArray[num50] = stateInfo55;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num51 = 0; num51 < batchInChunk.Count; num51++)
				{
					StateInfoCD stateInfo56 = nativeArray[num51];
					_randomFollow.OnUpdate(entities[num51], ecb, ref data, ref ctrs, ref stateInfo56);
					nativeArray[num51] = stateInfo56;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num52 = 0; num52 < batchInChunk.Count; num52++)
				{
					StateInfoCD stateInfo57 = nativeArray[num52];
					_roaming.OnUpdate(entities[num52], ecb, ref data, ref ctrs, ref stateInfo57);
					nativeArray[num52] = stateInfo57;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num53 = 0; num53 < batchInChunk.Count; num53++)
				{
					StateInfoCD stateInfo58 = nativeArray[num53];
					_randomWalk.OnUpdate(entities[num53], ecb, ref data, ref ctrs, ref stateInfo58);
					nativeArray[num53] = stateInfo58;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num54 = 0; num54 < batchInChunk.Count; num54++)
				{
					StateInfoCD stateInfo59 = nativeArray[num54];
					_idleInCombat.OnUpdate(entities[num54], ecb, ref data, ref ctrs, ref stateInfo59);
					nativeArray[num54] = stateInfo59;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num55 = 0; num55 < batchInChunk.Count; num55++)
				{
					StateInfoCD stateInfo60 = nativeArray[num55];
					_birdBossFlying.OnUpdate(entities[num55], ecb, ref data, ref ctrs, ref stateInfo60);
					nativeArray[num55] = stateInfo60;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num56 = 0; num56 < batchInChunk.Count; num56++)
				{
					StateInfoCD stateInfo61 = nativeArray[num56];
					_octopusBossLurk.OnUpdate(entities[num56], ecb, ref data, ref ctrs, ref stateInfo61);
					nativeArray[num56] = stateInfo61;
				}
			}
			if (shouldUpdate[num++])
			{
				for (int num57 = 0; num57 < batchInChunk.Count; num57++)
				{
					StateInfoCD stateInfo62 = nativeArray[num57];
					_scarabBossBuried.OnUpdate(entities[num57], ecb, ref data, ref ctrs, ref stateInfo62);
					nativeArray[num57] = stateInfo62;
				}
			}
		}
	}

	private struct TypeHandle
	{
		public RecordExtrapolatedEntitiesJob.InternalCompilerQueryAndHandleData __StateRequestSystem_RecordExtrapolatedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentLookup<GiantCicadaBossAppearStateCD> __GiantCicadaBossAppearStateCD_RW_ComponentLookup;

		public ComponentLookup<BirdBossAppearStateCD> __BirdBossAppearStateCD_RW_ComponentLookup;

		public ComponentLookup<TeleportStateCD> __TeleportStateCD_RW_ComponentLookup;

		public ComponentLookup<SeasonalLootCD> __SeasonalLootCD_RW_ComponentLookup;

		public ComponentLookup<BossCD> __BossCD_RW_ComponentLookup;

		public ComponentLookup<OctopusBossAppearStateCD> __OctopusBossAppearStateCD_RW_ComponentLookup;

		public ComponentLookup<ScarabBossAppearStateCD> __ScarabBossAppearStateCD_RW_ComponentLookup;

		public ComponentLookup<ScarabBossChargeStateCD> __ScarabBossChargeStateCD_RW_ComponentLookup;

		public ComponentLookup<EnrageStateCD> __EnrageStateCD_RW_ComponentLookup;

		public ComponentLookup<LarvaHiveBossHatchEggStateCD> __LarvaHiveBossHatchEggStateCD_RW_ComponentLookup;

		public ComponentLookup<ExplodeStateCD> __ExplodeStateCD_RW_ComponentLookup;

		public ComponentLookup<EvolveStateCD> __EvolveStateCD_RW_ComponentLookup;

		public ComponentLookup<PlaceObjectStateCD> __PlaceObjectStateCD_RW_ComponentLookup;

		public BufferLookup<TargetMortarPositionBuffer> __TargetMortarPositionBuffer_RW_BufferLookup;

		public ComponentLookup<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentLookup;

		public BufferLookup<MortarShotsBuffer> __MortarShotsBuffer_RW_BufferLookup;

		public ComponentLookup<TookDamageStateCD> __TookDamageStateCD_RW_ComponentLookup;

		public ComponentLookup<JumpAttackStateCD> __JumpAttackStateCD_RW_ComponentLookup;

		public ComponentLookup<HealOtherEntityStateCD> __HealOtherEntityStateCD_RW_ComponentLookup;

		public ComponentLookup<BeamAttackStateCD> __BeamAttackStateCD_RW_ComponentLookup;

		public ComponentLookup<RayAttackStateCD> __RayAttackState_RayAttackStateCD_RW_ComponentLookup;

		public BufferLookup<BeamBuffer> __BeamBuffer_RW_BufferLookup;

		public ComponentLookup<ChargeAttackStateCD> __ChargeAttackStateCD_RW_ComponentLookup;

		public ComponentLookup<MeleeAttackStateCD> __MeleeAttackStateCD_RW_ComponentLookup;

		public ComponentLookup<AttackCooldownTimerCD> __AttackCooldownTimerCD_RW_ComponentLookup;

		public ComponentLookup<AttackContinuouslyCD> __AttackContinuouslyCD_RW_ComponentLookup;

		public ComponentLookup<RangeAttackStateCD> __RangeAttackStateCD_RW_ComponentLookup;

		public ComponentLookup<SlimeBossJumpStateCD> __SlimeBossJumpStateCD_RW_ComponentLookup;

		public ComponentLookup<GiantCicadaSlamArmsStateCD> __GiantCicadaSlamArmsStateCD_RW_ComponentLookup;

		public ComponentLookup<BirdBossSpawnStonesStateCD> __BirdBossSpawnStonesStateCD_RW_ComponentLookup;

		public ComponentLookup<BreedStateCD> __BreedStateCD_RW_ComponentLookup;

		public ComponentLookup<BreedToggleCD> __BreedToggleCD_RW_ComponentLookup;

		public ComponentLookup<EatStateCD> __EatStateCD_RW_ComponentLookup;

		public ComponentLookup<LeashedCD> __LeashedCD_RW_ComponentLookup;

		public ComponentLookup<IdleWhenNearbyPlayerStateCD> __IdleWhenNearbyPlayerStateCD_RW_ComponentLookup;

		public ComponentLookup<CombatEmoteStateCD> __CombatEmoteStateCD_RW_ComponentLookup;

		public ComponentLookup<PathFindCD> __PathFindCD_RW_ComponentLookup;

		public ComponentLookup<PathFindAStarCD> __PathFindAStarCD_RW_ComponentLookup;

		public ComponentLookup<FollowPheromoneStateCD> __FollowPheromoneStateCD_RW_ComponentLookup;

		public ComponentLookup<DamageObjectStateCD> __DamageObjectStateCD_RW_ComponentLookup;

		public ComponentLookup<HatchWhenPlayerNearbyStateCD> __HatchWhenPlayerNearbyStateCD_RW_ComponentLookup;

		public ComponentLookup<ActivatedByElectricityStateCD> __ActivatedByElectricityStateCD_RW_ComponentLookup;

		public ComponentLookup<SleepStateCD> __SleepStateCD_RW_ComponentLookup;

		public ComponentLookup<IdleEmoteStateCD> __IdleEmoteStateCD_RW_ComponentLookup;

		public ComponentLookup<AlertEmoteStateCD> __AlertEmoteStateCD_RW_ComponentLookup;

		public ComponentLookup<PetWalkStateCD> __PetWalkStateCD_RW_ComponentLookup;

		public ComponentLookup<RandomFollowStateCD> __RandomFollowStateCD_RW_ComponentLookup;

		public ComponentLookup<RandomWalkStateCD> __RandomWalkStateCD_RW_ComponentLookup;

		public ComponentLookup<RoamingStateCD> __RoamingStateCD_RW_ComponentLookup;

		public ComponentLookup<IdleInCombatStateCD> __IdleInCombatStateCD_RW_ComponentLookup;

		public ComponentLookup<BirdBossFlyingAboveStateCD> __BirdBossFlyingAboveStateCD_RW_ComponentLookup;

		public ComponentLookup<OctopusBossLurkingBelowStateCD> __OctopusBossLurkingBelowStateCD_RW_ComponentLookup;

		public ComponentLookup<ScarabBossBuriedStateCD> __ScarabBossBuriedStateCD_RW_ComponentLookup;

		public ComponentLookup<BushStateCD> __BushStateCD_RW_ComponentLookup;

		public ComponentLookup<ChaseStateCD> __ChaseStateCD_RW_ComponentLookup;

		public ComponentLookup<BirdBossSpawnBeamsStateCD> __BirdBossSpawnBeamsStateCD_RW_ComponentLookup;

		public ComponentLookup<CoreBossSpawnBeamsStateCD> __CoreBossSpawnBeamsStateCD_RW_ComponentLookup;

		public ComponentLookup<CoreBossSpawnVoidStateCD> __CoreBossSpawnVoidStateCD_RW_ComponentLookup;

		public ComponentLookup<OctopusBossSpawnTentaclesStateCD> __OctopusBossSpawnTentaclesStateCD_RW_ComponentLookup;

		public ComponentLookup<OctopusBossCD> __OctopusBossCD_RW_ComponentLookup;

		public ComponentLookup<EnemyStagesStateCD> __EnemyStagesStateCD_RW_ComponentLookup;

		public ComponentLookup<PhaseTransitionStateCD> __PhaseTransitionStateCD_RW_ComponentLookup;

		public ComponentLookup<HydraBossBuriedCombatStateCD> __HydraBossBuriedCombatStateCD_RW_ComponentLookup;

		public ComponentLookup<HydraBossBuriedRoamingStateCD> __HydraBossBuriedRoamingStateCD_RW_ComponentLookup;

		public ComponentLookup<VulnerableStateCD> __VulnerableStateCD_RW_ComponentLookup;

		public ComponentLookup<MoveToPositionFromCommandStateCD> __MoveToPositionFromCommandStateCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CombatRadiusCD> __CombatRadiusCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BossLarvaSpawnStateCD> __BossLarvaSpawnStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GiantCicadaBossHasAppearedCD> __GiantCicadaBossHasAppearedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BirdBossHasAppearedCD> __BirdBossHasAppearedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BossSpawnLocationCD> __BossSpawnLocationCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> __IsInCombatCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<OctopusBossHasAppearedCD> __OctopusBossHasAppearedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ScarabBossHasAppearedCD> __ScarabBossHasAppearedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LarvaHiveEggHatchStateCD> __LarvaHiveEggHatchStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<StunnedStateCD> __StunnedStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<NearbyEntitiesTrackerCD> __NearbyEntitiesTrackerCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectCategoryTagsCD> __ObjectCategoryTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> __PlayerGhostExtrapolated_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> __EntityPartCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SpawnStateCD> __SpawnStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HasRunSpawnStateCD> __HasRunSpawnStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LastAttackerCD> __LastAttackerCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<IsBeingBeHealedByOtherEntitiesCD> __IsBeingBeHealedByOtherEntitiesCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsCollider> __Unity_Physics_PhysicsCollider_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CritterCD> __CritterCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionBasedOnVariationCD> __DirectionBasedOnVariationCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SpawnPointCD> __SpawnPointCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<TeleportLocationsBuffer> __TeleportLocationsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<EquippedObjectCD> __EquippedObjectCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PheromoneSensorCD> __PheromoneSensorCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<KilledEnemiesBuffer> __KilledEnemiesBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<DetectCollisionCD> __DetectCollisionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> __IndestructibleCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> __DamageReductionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SnakeMovementStateCD> __SnakeMovementStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageTakenTriggerCD> __DamageTakenTriggerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> __PetCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<CombatantsTrackerBuffer> __CombatantsTrackerBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<DebugTagCD> __DebugTagCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayAnimationStateCD> __PlayAnimationStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CattleCD> __CattleCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MealsEatenCD> __MealsEatenCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ShieldCD> __ShieldCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MinionCD> __MinionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MiningMinionCD> __MiningMinionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SpawnTickCD> __SpawnTickCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<PathFindNodeBuffer> __PathFindNodeBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<IgnoreImmuneZoneCD> __IgnoreImmuneZoneCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ImmuneToDamageCD> __ImmuneToDamageCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__StateRequestSystem_RecordExtrapolatedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__GiantCicadaBossAppearStateCD_RW_ComponentLookup = state.GetComponentLookup<GiantCicadaBossAppearStateCD>();
			__BirdBossAppearStateCD_RW_ComponentLookup = state.GetComponentLookup<BirdBossAppearStateCD>();
			__TeleportStateCD_RW_ComponentLookup = state.GetComponentLookup<TeleportStateCD>();
			__SeasonalLootCD_RW_ComponentLookup = state.GetComponentLookup<SeasonalLootCD>();
			__BossCD_RW_ComponentLookup = state.GetComponentLookup<BossCD>();
			__OctopusBossAppearStateCD_RW_ComponentLookup = state.GetComponentLookup<OctopusBossAppearStateCD>();
			__ScarabBossAppearStateCD_RW_ComponentLookup = state.GetComponentLookup<ScarabBossAppearStateCD>();
			__ScarabBossChargeStateCD_RW_ComponentLookup = state.GetComponentLookup<ScarabBossChargeStateCD>();
			__EnrageStateCD_RW_ComponentLookup = state.GetComponentLookup<EnrageStateCD>();
			__LarvaHiveBossHatchEggStateCD_RW_ComponentLookup = state.GetComponentLookup<LarvaHiveBossHatchEggStateCD>();
			__ExplodeStateCD_RW_ComponentLookup = state.GetComponentLookup<ExplodeStateCD>();
			__EvolveStateCD_RW_ComponentLookup = state.GetComponentLookup<EvolveStateCD>();
			__PlaceObjectStateCD_RW_ComponentLookup = state.GetComponentLookup<PlaceObjectStateCD>();
			__TargetMortarPositionBuffer_RW_BufferLookup = state.GetBufferLookup<TargetMortarPositionBuffer>();
			__ShootMortarProjectileStateCD_RW_ComponentLookup = state.GetComponentLookup<ShootMortarProjectileStateCD>();
			__MortarShotsBuffer_RW_BufferLookup = state.GetBufferLookup<MortarShotsBuffer>();
			__TookDamageStateCD_RW_ComponentLookup = state.GetComponentLookup<TookDamageStateCD>();
			__JumpAttackStateCD_RW_ComponentLookup = state.GetComponentLookup<JumpAttackStateCD>();
			__HealOtherEntityStateCD_RW_ComponentLookup = state.GetComponentLookup<HealOtherEntityStateCD>();
			__BeamAttackStateCD_RW_ComponentLookup = state.GetComponentLookup<BeamAttackStateCD>();
			__RayAttackState_RayAttackStateCD_RW_ComponentLookup = state.GetComponentLookup<RayAttackStateCD>();
			__BeamBuffer_RW_BufferLookup = state.GetBufferLookup<BeamBuffer>();
			__ChargeAttackStateCD_RW_ComponentLookup = state.GetComponentLookup<ChargeAttackStateCD>();
			__MeleeAttackStateCD_RW_ComponentLookup = state.GetComponentLookup<MeleeAttackStateCD>();
			__AttackCooldownTimerCD_RW_ComponentLookup = state.GetComponentLookup<AttackCooldownTimerCD>();
			__AttackContinuouslyCD_RW_ComponentLookup = state.GetComponentLookup<AttackContinuouslyCD>();
			__RangeAttackStateCD_RW_ComponentLookup = state.GetComponentLookup<RangeAttackStateCD>();
			__SlimeBossJumpStateCD_RW_ComponentLookup = state.GetComponentLookup<SlimeBossJumpStateCD>();
			__GiantCicadaSlamArmsStateCD_RW_ComponentLookup = state.GetComponentLookup<GiantCicadaSlamArmsStateCD>();
			__BirdBossSpawnStonesStateCD_RW_ComponentLookup = state.GetComponentLookup<BirdBossSpawnStonesStateCD>();
			__BreedStateCD_RW_ComponentLookup = state.GetComponentLookup<BreedStateCD>();
			__BreedToggleCD_RW_ComponentLookup = state.GetComponentLookup<BreedToggleCD>();
			__EatStateCD_RW_ComponentLookup = state.GetComponentLookup<EatStateCD>();
			__LeashedCD_RW_ComponentLookup = state.GetComponentLookup<LeashedCD>();
			__IdleWhenNearbyPlayerStateCD_RW_ComponentLookup = state.GetComponentLookup<IdleWhenNearbyPlayerStateCD>();
			__CombatEmoteStateCD_RW_ComponentLookup = state.GetComponentLookup<CombatEmoteStateCD>();
			__PathFindCD_RW_ComponentLookup = state.GetComponentLookup<PathFindCD>();
			__PathFindAStarCD_RW_ComponentLookup = state.GetComponentLookup<PathFindAStarCD>();
			__FollowPheromoneStateCD_RW_ComponentLookup = state.GetComponentLookup<FollowPheromoneStateCD>();
			__DamageObjectStateCD_RW_ComponentLookup = state.GetComponentLookup<DamageObjectStateCD>();
			__HatchWhenPlayerNearbyStateCD_RW_ComponentLookup = state.GetComponentLookup<HatchWhenPlayerNearbyStateCD>();
			__ActivatedByElectricityStateCD_RW_ComponentLookup = state.GetComponentLookup<ActivatedByElectricityStateCD>();
			__SleepStateCD_RW_ComponentLookup = state.GetComponentLookup<SleepStateCD>();
			__IdleEmoteStateCD_RW_ComponentLookup = state.GetComponentLookup<IdleEmoteStateCD>();
			__AlertEmoteStateCD_RW_ComponentLookup = state.GetComponentLookup<AlertEmoteStateCD>();
			__PetWalkStateCD_RW_ComponentLookup = state.GetComponentLookup<PetWalkStateCD>();
			__RandomFollowStateCD_RW_ComponentLookup = state.GetComponentLookup<RandomFollowStateCD>();
			__RandomWalkStateCD_RW_ComponentLookup = state.GetComponentLookup<RandomWalkStateCD>();
			__RoamingStateCD_RW_ComponentLookup = state.GetComponentLookup<RoamingStateCD>();
			__IdleInCombatStateCD_RW_ComponentLookup = state.GetComponentLookup<IdleInCombatStateCD>();
			__BirdBossFlyingAboveStateCD_RW_ComponentLookup = state.GetComponentLookup<BirdBossFlyingAboveStateCD>();
			__OctopusBossLurkingBelowStateCD_RW_ComponentLookup = state.GetComponentLookup<OctopusBossLurkingBelowStateCD>();
			__ScarabBossBuriedStateCD_RW_ComponentLookup = state.GetComponentLookup<ScarabBossBuriedStateCD>();
			__BushStateCD_RW_ComponentLookup = state.GetComponentLookup<BushStateCD>();
			__ChaseStateCD_RW_ComponentLookup = state.GetComponentLookup<ChaseStateCD>();
			__BirdBossSpawnBeamsStateCD_RW_ComponentLookup = state.GetComponentLookup<BirdBossSpawnBeamsStateCD>();
			__CoreBossSpawnBeamsStateCD_RW_ComponentLookup = state.GetComponentLookup<CoreBossSpawnBeamsStateCD>();
			__CoreBossSpawnVoidStateCD_RW_ComponentLookup = state.GetComponentLookup<CoreBossSpawnVoidStateCD>();
			__OctopusBossSpawnTentaclesStateCD_RW_ComponentLookup = state.GetComponentLookup<OctopusBossSpawnTentaclesStateCD>();
			__OctopusBossCD_RW_ComponentLookup = state.GetComponentLookup<OctopusBossCD>();
			__EnemyStagesStateCD_RW_ComponentLookup = state.GetComponentLookup<EnemyStagesStateCD>();
			__PhaseTransitionStateCD_RW_ComponentLookup = state.GetComponentLookup<PhaseTransitionStateCD>();
			__HydraBossBuriedCombatStateCD_RW_ComponentLookup = state.GetComponentLookup<HydraBossBuriedCombatStateCD>();
			__HydraBossBuriedRoamingStateCD_RW_ComponentLookup = state.GetComponentLookup<HydraBossBuriedRoamingStateCD>();
			__VulnerableStateCD_RW_ComponentLookup = state.GetComponentLookup<VulnerableStateCD>();
			__MoveToPositionFromCommandStateCD_RW_ComponentLookup = state.GetComponentLookup<MoveToPositionFromCommandStateCD>();
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__CombatRadiusCD_RO_ComponentLookup = state.GetComponentLookup<CombatRadiusCD>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__BossLarvaSpawnStateCD_RO_ComponentLookup = state.GetComponentLookup<BossLarvaSpawnStateCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__GiantCicadaBossHasAppearedCD_RO_ComponentLookup = state.GetComponentLookup<GiantCicadaBossHasAppearedCD>(isReadOnly: true);
			__BirdBossHasAppearedCD_RO_ComponentLookup = state.GetComponentLookup<BirdBossHasAppearedCD>(isReadOnly: true);
			__BossSpawnLocationCD_RO_ComponentLookup = state.GetComponentLookup<BossSpawnLocationCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__IsInCombatCD_RO_ComponentLookup = state.GetComponentLookup<IsInCombatCD>(isReadOnly: true);
			__OctopusBossHasAppearedCD_RO_ComponentLookup = state.GetComponentLookup<OctopusBossHasAppearedCD>(isReadOnly: true);
			__ScarabBossHasAppearedCD_RO_ComponentLookup = state.GetComponentLookup<ScarabBossHasAppearedCD>(isReadOnly: true);
			__DistanceToPlayerCD_RO_ComponentLookup = state.GetComponentLookup<DistanceToPlayerCD>(isReadOnly: true);
			__LarvaHiveEggHatchStateCD_RO_ComponentLookup = state.GetComponentLookup<LarvaHiveEggHatchStateCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__StunnedStateCD_RO_ComponentLookup = state.GetComponentLookup<StunnedStateCD>(isReadOnly: true);
			__NearbyEntitiesTrackerCD_RO_ComponentLookup = state.GetComponentLookup<NearbyEntitiesTrackerCD>(isReadOnly: true);
			__NearbyEntitiesBufferCD_RO_BufferLookup = state.GetBufferLookup<NearbyEntitiesBufferCD>(isReadOnly: true);
			__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__ObjectCategoryTagsCD_RO_ComponentLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__PlayerGhostExtrapolated_RO_ComponentLookup = state.GetComponentLookup<PlayerGhostExtrapolated>(isReadOnly: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__EntityPartCD_RO_ComponentLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
			__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
			__SpawnStateCD_RO_ComponentLookup = state.GetComponentLookup<SpawnStateCD>(isReadOnly: true);
			__HasRunSpawnStateCD_RO_ComponentLookup = state.GetComponentLookup<HasRunSpawnStateCD>(isReadOnly: true);
			__DisablePhysicsCD_RO_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>(isReadOnly: true);
			__LastAttackerCD_RO_ComponentLookup = state.GetComponentLookup<LastAttackerCD>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__IsBeingBeHealedByOtherEntitiesCD_RO_ComponentLookup = state.GetComponentLookup<IsBeingBeHealedByOtherEntitiesCD>(isReadOnly: true);
			__Unity_Physics_PhysicsCollider_RO_ComponentLookup = state.GetComponentLookup<PhysicsCollider>(isReadOnly: true);
			__CritterCD_RO_ComponentLookup = state.GetComponentLookup<CritterCD>(isReadOnly: true);
			__Pug_Automation_ElectricityCD_RO_ComponentLookup = state.GetComponentLookup<ElectricityCD>(isReadOnly: true);
			__DirectionBasedOnVariationCD_RO_ComponentLookup = state.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
			__SpawnPointCD_RO_ComponentLookup = state.GetComponentLookup<SpawnPointCD>(isReadOnly: true);
			__TeleportLocationsBuffer_RO_BufferLookup = state.GetBufferLookup<TeleportLocationsBuffer>(isReadOnly: true);
			__EquippedObjectCD_RO_ComponentLookup = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
			__PheromoneSensorCD_RO_ComponentLookup = state.GetComponentLookup<PheromoneSensorCD>(isReadOnly: true);
			__KilledEnemiesBuffer_RO_BufferLookup = state.GetBufferLookup<KilledEnemiesBuffer>(isReadOnly: true);
			__DetectCollisionCD_RO_ComponentLookup = state.GetComponentLookup<DetectCollisionCD>(isReadOnly: true);
			__IndestructibleCD_RO_ComponentLookup = state.GetComponentLookup<IndestructibleCD>(isReadOnly: true);
			__DamageReductionCD_RO_ComponentLookup = state.GetComponentLookup<DamageReductionCD>(isReadOnly: true);
			__SnakeMovementStateCD_RO_ComponentLookup = state.GetComponentLookup<SnakeMovementStateCD>(isReadOnly: true);
			__DamageTakenTriggerCD_RO_ComponentLookup = state.GetComponentLookup<DamageTakenTriggerCD>(isReadOnly: true);
			__PetCD_RO_ComponentLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
			__CombatantsTrackerBuffer_RO_BufferLookup = state.GetBufferLookup<CombatantsTrackerBuffer>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			__DebugTagCD_RO_ComponentLookup = state.GetComponentLookup<DebugTagCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__PlayAnimationStateCD_RO_ComponentLookup = state.GetComponentLookup<PlayAnimationStateCD>(isReadOnly: true);
			__CattleCD_RO_ComponentLookup = state.GetComponentLookup<CattleCD>(isReadOnly: true);
			__MealsEatenCD_RO_ComponentLookup = state.GetComponentLookup<MealsEatenCD>(isReadOnly: true);
			__ShieldCD_RO_ComponentLookup = state.GetComponentLookup<ShieldCD>(isReadOnly: true);
			__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
			__MinionCD_RO_ComponentLookup = state.GetComponentLookup<MinionCD>(isReadOnly: true);
			__MiningMinionCD_RO_ComponentLookup = state.GetComponentLookup<MiningMinionCD>(isReadOnly: true);
			__SpawnTickCD_RO_ComponentLookup = state.GetComponentLookup<SpawnTickCD>(isReadOnly: true);
			__PathFindNodeBuffer_RO_BufferLookup = state.GetBufferLookup<PathFindNodeBuffer>(isReadOnly: true);
			__IgnoreImmuneZoneCD_RO_ComponentLookup = state.GetComponentLookup<IgnoreImmuneZoneCD>(isReadOnly: true);
			__ImmuneToDamageCD_RO_ComponentLookup = state.GetComponentLookup<ImmuneToDamageCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000040AF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000040AF_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000040AF_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
			__codegen__OnCreate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000040B0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000040B0_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000040B0_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_000040B1_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000040B1_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000040B1_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	private UpdateJob _updateJob;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1994934424_0;

	private EntityQuery __query_1994934424_1;

	private EntityQuery __query_1994934424_2;

	private EntityQuery __query_1994934424_3;

	private EntityQuery __query_1994934424_4;

	private EntityQuery __query_1994934424_5;

	private EntityQuery __query_1994934424_6;

	private EntityQuery __query_1994934424_7;

	private EntityQuery __query_1994934424_8;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<WorldInfoCD>();
		_updateJob.Requesters._pheromone.OnCreate(ref state);
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		_updateJob.Requesters._pheromone.OnDestroy(ref state);
	}

	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		_tileAccessor.Update(ref state);
		__query_1994934424_3.TryGetSingleton<NetworkTime>(out var value);
		_updateJob.Data = new StateRequestData
		{
			_serverTick = value.ServerTick,
			_elapsedTime = state.WorldUnmanaged.Time.ElapsedTime,
			_deltaTime = state.WorldUnmanaged.Time.DeltaTime,
			_rng = PugRandom.GetRng(),
			database = __query_1994934424_4.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob,
			tileLookup = _tileAccessor,
			collisionWorld = __query_1994934424_5.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
			worldInfo = __query_1994934424_6.GetSingleton<WorldInfoCD>(),
			playerEntities = new NativeList<Entity>(state.WorldUpdateAllocator),
			playerExtrapolatedEntities = new NativeList<Entity>(state.WorldUpdateAllocator),
			spawnLocationEntities = new NativeList<Entity>(state.WorldUpdateAllocator),
			tickRate = (uint)__query_1994934424_7.GetSingleton<ClientServerTickRate>().SimulationTickRate
		};
		_updateJob.Data.spawnLocationEntities = __query_1994934424_0.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out var outJobHandle);
		StateRequestData data = _updateJob.Data;
		JobHandle job = __ScheduleViaJobChunkExtension_0(new RecordExtrapolatedEntitiesJob
		{
			playerExtrapolatedEntities = data.playerExtrapolatedEntities,
			playerEntities = data.playerEntities
		}, __TypeHandle.__StateRequestSystem_RecordExtrapolatedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = JobHandle.CombineDependencies(outJobHandle, job);
		BeginSimulationEntityCommandBufferSystem.Singleton singleton = __query_1994934424_8.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
		_updateJob.EntityCommandBuffer = singleton.CreateCommandBuffer(state.WorldUnmanaged);
		_updateJob.Entity = InternalCompilerInterface.GetEntityTypeHandle(ref __TypeHandle.__Unity_Entities_Entity_TypeHandle, ref state);
		_updateJob.StateInfo = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle, ref state);
		EntityQuery _query_1994934424_ = __query_1994934424_1;
		_updateJob.Requesters._pheromone.OnBeforeUpdate(state.EntityManager, state.WorldUnmanaged.Time.DeltaTime, _query_1994934424_, __query_1994934424_4.GetSingleton<PugDatabase.DatabaseBankCD>());
		PopulateStateRequestContainers(ref state, ref _updateJob.Containers);
		state.Dependency = JobChunkExtensions.Schedule(_updateJob, __query_1994934424_2, state.Dependency);
	}

	private void PopulateStateRequestContainers(ref SystemState state, ref StateRequestContainers containers)
	{
		containers._giantCicadaAppearStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GiantCicadaBossAppearStateCD_RW_ComponentLookup, ref state);
		containers._birdAppearStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BirdBossAppearStateCD_RW_ComponentLookup, ref state);
		containers._teleportStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TeleportStateCD_RW_ComponentLookup, ref state);
		containers._seasonalLootGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SeasonalLootCD_RW_ComponentLookup, ref state);
		containers._bossGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RW_ComponentLookup, ref state);
		containers._octopusAppearStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OctopusBossAppearStateCD_RW_ComponentLookup, ref state);
		containers._scarabAppearStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ScarabBossAppearStateCD_RW_ComponentLookup, ref state);
		containers._scarabChargeStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ScarabBossChargeStateCD_RW_ComponentLookup, ref state);
		containers._enrageStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnrageStateCD_RW_ComponentLookup, ref state);
		containers._larvaHiveBossHatchEggStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LarvaHiveBossHatchEggStateCD_RW_ComponentLookup, ref state);
		containers._explodeStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ExplodeStateCD_RW_ComponentLookup, ref state);
		containers._evolveStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EvolveStateCD_RW_ComponentLookup, ref state);
		containers._placeObjectStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlaceObjectStateCD_RW_ComponentLookup, ref state);
		containers._targetMortarPositionBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TargetMortarPositionBuffer_RW_BufferLookup, ref state);
		containers._mortarStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentLookup, ref state);
		containers._mortarShotPositionBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__MortarShotsBuffer_RW_BufferLookup, ref state);
		containers._tookDamageStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TookDamageStateCD_RW_ComponentLookup, ref state);
		containers._jumpAttackStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__JumpAttackStateCD_RW_ComponentLookup, ref state);
		containers._healOtherStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealOtherEntityStateCD_RW_ComponentLookup, ref state);
		containers._beamAttackStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BeamAttackStateCD_RW_ComponentLookup, ref state);
		containers._rayAttackStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RayAttackState_RayAttackStateCD_RW_ComponentLookup, ref state);
		containers._beamBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__BeamBuffer_RW_BufferLookup, ref state);
		containers._chargeStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ChargeAttackStateCD_RW_ComponentLookup, ref state);
		containers._meleeAttackStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MeleeAttackStateCD_RW_ComponentLookup, ref state);
		containers._attackCooldownGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AttackCooldownTimerCD_RW_ComponentLookup, ref state);
		containers._attackContinuouslyStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AttackContinuouslyCD_RW_ComponentLookup, ref state);
		containers._rangeStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RangeAttackStateCD_RW_ComponentLookup, ref state);
		containers._slimeBossJumpStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SlimeBossJumpStateCD_RW_ComponentLookup, ref state);
		containers._slamArmsStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GiantCicadaSlamArmsStateCD_RW_ComponentLookup, ref state);
		containers._spawnStonesGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BirdBossSpawnStonesStateCD_RW_ComponentLookup, ref state);
		containers._breedStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BreedStateCD_RW_ComponentLookup, ref state);
		containers._breedToggleGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BreedToggleCD_RW_ComponentLookup, ref state);
		containers._eatStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EatStateCD_RW_ComponentLookup, ref state);
		containers._leashedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LeashedCD_RW_ComponentLookup, ref state);
		containers._idleNearbyPlayerStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IdleWhenNearbyPlayerStateCD_RW_ComponentLookup, ref state);
		containers._combatEmoteStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CombatEmoteStateCD_RW_ComponentLookup, ref state);
		containers._pathFindGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PathFindCD_RW_ComponentLookup, ref state);
		containers._pathFindAStarGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PathFindAStarCD_RW_ComponentLookup, ref state);
		containers._followPheromoneGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FollowPheromoneStateCD_RW_ComponentLookup, ref state);
		containers._damageObjectStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageObjectStateCD_RW_ComponentLookup, ref state);
		containers._hatchWhenPlayerNearbyStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HatchWhenPlayerNearbyStateCD_RW_ComponentLookup, ref state);
		containers._activatedByElectricityGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ActivatedByElectricityStateCD_RW_ComponentLookup, ref state);
		containers._sleepStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SleepStateCD_RW_ComponentLookup, ref state);
		containers._idleEmoteStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IdleEmoteStateCD_RW_ComponentLookup, ref state);
		containers._alertEmoteStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AlertEmoteStateCD_RW_ComponentLookup, ref state);
		containers._petWalkStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetWalkStateCD_RW_ComponentLookup, ref state);
		containers._randomFollowStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomFollowStateCD_RW_ComponentLookup, ref state);
		containers._randomWalkStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomWalkStateCD_RW_ComponentLookup, ref state);
		containers._roamingStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RoamingStateCD_RW_ComponentLookup, ref state);
		containers._idleInCombatStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IdleInCombatStateCD_RW_ComponentLookup, ref state);
		containers._birdBossFlyingGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BirdBossFlyingAboveStateCD_RW_ComponentLookup, ref state);
		containers._lurkingBelowGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OctopusBossLurkingBelowStateCD_RW_ComponentLookup, ref state);
		containers._scarabBossBuriedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ScarabBossBuriedStateCD_RW_ComponentLookup, ref state);
		containers._bushStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BushStateCD_RW_ComponentLookup, ref state);
		containers._chaseStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ChaseStateCD_RW_ComponentLookup, ref state);
		containers._birdBossSpawnBeamsGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BirdBossSpawnBeamsStateCD_RW_ComponentLookup, ref state);
		containers._coreBossSpawnBeamsGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CoreBossSpawnBeamsStateCD_RW_ComponentLookup, ref state);
		containers._coreBossSpawnVoidGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CoreBossSpawnVoidStateCD_RW_ComponentLookup, ref state);
		containers._spawnTentacleGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OctopusBossSpawnTentaclesStateCD_RW_ComponentLookup, ref state);
		containers._octopusBossGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OctopusBossCD_RW_ComponentLookup, ref state);
		containers._enemyStagesGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyStagesStateCD_RW_ComponentLookup, ref state);
		containers._phaseTransitionGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PhaseTransitionStateCD_RW_ComponentLookup, ref state);
		containers._hydraBossBuriedCombatStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossBuriedCombatStateCD_RW_ComponentLookup, ref state);
		containers._hydraBossBuriedRoamingStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossBuriedRoamingStateCD_RW_ComponentLookup, ref state);
		containers._vulnerableStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VulnerableStateCD_RW_ComponentLookup, ref state);
		containers._moveToPositionFromCommandGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveToPositionFromCommandStateCD_RW_ComponentLookup, ref state);
		containers._ownerGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state);
		containers._combatRadiusGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CombatRadiusCD_RO_ComponentLookup, ref state);
		containers._entityDestroyedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state);
		containers._bossLarvaSpawnStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossLarvaSpawnStateCD_RO_ComponentLookup, ref state);
		containers._localTransformGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state);
		containers._giantCicadaHasAppearedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GiantCicadaBossHasAppearedCD_RO_ComponentLookup, ref state);
		containers._birdHasAppearedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BirdBossHasAppearedCD_RO_ComponentLookup, ref state);
		containers._bossSpawnLocationGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossSpawnLocationCD_RO_ComponentLookup, ref state);
		containers._objectDataGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state);
		containers._isInCombatGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsInCombatCD_RO_ComponentLookup, ref state);
		containers._octopusHasAppearedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OctopusBossHasAppearedCD_RO_ComponentLookup, ref state);
		containers._scarabHasAppearedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ScarabBossHasAppearedCD_RO_ComponentLookup, ref state);
		containers._distanceToPlayerGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentLookup, ref state);
		containers._larvaHiveHatchStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LarvaHiveEggHatchStateCD_RO_ComponentLookup, ref state);
		containers._healthGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state);
		containers._stunnedStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__StunnedStateCD_RO_ComponentLookup, ref state);
		containers._nearbyEntitiesTrackerGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__NearbyEntitiesTrackerCD_RO_ComponentLookup, ref state);
		containers._nearbyEntitiesBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferLookup, ref state);
		containers._behaviourTagsGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state);
		containers._factionGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state);
		containers._objectCategoryTagsGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref state);
		containers._playerGhostGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state);
		containers._playerGhostExtrapolatedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentLookup, ref state);
		containers._enemyGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state);
		containers._entityPartGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityPartCD_RO_ComponentLookup, ref state);
		containers._tileGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state);
		containers._spawnStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SpawnStateCD_RO_ComponentLookup, ref state);
		containers._hasRunSpawnGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HasRunSpawnStateCD_RO_ComponentLookup, ref state);
		containers._physicsExcludeGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref state);
		containers._lastAttackerGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LastAttackerCD_RO_ComponentLookup, ref state);
		containers._conditionEffectBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state);
		containers._isBeingHealedByOtherGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsBeingBeHealedByOtherEntitiesCD_RO_ComponentLookup, ref state);
		containers._objectCategoryGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref state);
		containers._physicsColliderGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsCollider_RO_ComponentLookup, ref state);
		containers._critterGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CritterCD_RO_ComponentLookup, ref state);
		containers._electricityGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentLookup, ref state);
		containers._directionBasedOnVariationGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionBasedOnVariationCD_RO_ComponentLookup, ref state);
		containers._spawnPointGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SpawnPointCD_RO_ComponentLookup, ref state);
		containers._teleportLocationsBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TeleportLocationsBuffer_RO_BufferLookup, ref state);
		containers._equippedObjectGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EquippedObjectCD_RO_ComponentLookup, ref state);
		containers._pheromoneSensorGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PheromoneSensorCD_RO_ComponentLookup, ref state);
		containers._killedEnemiesBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__KilledEnemiesBuffer_RO_BufferLookup, ref state);
		containers._detectCollisionGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DetectCollisionCD_RO_ComponentLookup, ref state);
		containers._indestructibleGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IndestructibleCD_RO_ComponentLookup, ref state);
		containers._damageReductionGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageReductionCD_RO_ComponentLookup, ref state);
		containers._bossLarvaSpawnGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossLarvaSpawnStateCD_RO_ComponentLookup, ref state);
		containers._snakeMovementGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SnakeMovementStateCD_RO_ComponentLookup, ref state);
		containers._damageTakenGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageTakenTriggerCD_RO_ComponentLookup, ref state);
		containers._petGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RO_ComponentLookup, ref state);
		containers._combatantTrackerBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CombatantsTrackerBuffer_RO_BufferLookup, ref state);
		containers._containedObjectsBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state);
		containers._debugGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DebugTagCD_RO_ComponentLookup, ref state);
		containers._directionGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state);
		containers._playAnimationStateGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayAnimationStateCD_RO_ComponentLookup, ref state);
		containers._cattleGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CattleCD_RO_ComponentLookup, ref state);
		containers._mealsEatenGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MealsEatenCD_RO_ComponentLookup, ref state);
		containers._shieldGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ShieldCD_RO_ComponentLookup, ref state);
		containers._propertiesGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state);
		containers._minionGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinionCD_RO_ComponentLookup, ref state);
		containers._miningMinionGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MiningMinionCD_RO_ComponentLookup, ref state);
		containers._spawnTickGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SpawnTickCD_RO_ComponentLookup, ref state);
		containers._pathFindNodeBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PathFindNodeBuffer_RO_BufferLookup, ref state);
		containers._IgnoreImmuneZoneGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IgnoreImmuneZoneCD_RO_ComponentLookup, ref state);
		containers._immuneToDamage = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ImmuneToDamageCD_RO_ComponentLookup, ref state);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(RecordExtrapolatedEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__StateRequestSystem_RecordExtrapolatedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__StateRequestSystem_RecordExtrapolatedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__StateRequestSystem_RecordExtrapolatedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__StateRequestSystem_RecordExtrapolatedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BossSpawnLocationCD>();
		__query_1994934424_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<KilledEnemiesBuffer>();
		__query_1994934424_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<StateInfoCD>();
		__query_1994934424_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1994934424_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1994934424_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1994934424_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1994934424_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1994934424_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1994934424_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		__codegen__OnCreate_000040AF_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000040B0_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000040B1_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((StateRequestSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((StateRequestSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((StateRequestSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((StateRequestSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((StateRequestSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((StateRequestSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}
