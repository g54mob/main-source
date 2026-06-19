using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct StateBehaviourModifierSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct OrbitalTurretBehaviourJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<ShieldCD> __ShieldCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RangeAttackStateCD> __RangeAttackStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<OrbitalTurretBehaviourCD> __OrbitalTurretBehaviourCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ShieldCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ShieldCD>();
					__RangeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RangeAttackStateCD>();
					__OrbitalTurretBehaviourCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<OrbitalTurretBehaviourCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ShieldCD_RW_ComponentTypeHandle.Update(ref state);
					__RangeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__OrbitalTurretBehaviourCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShieldCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OrbitalTurretBehaviourCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
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
			public void Run(ref OrbitalTurretBehaviourJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref OrbitalTurretBehaviourJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref OrbitalTurretBehaviourJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref OrbitalTurretBehaviourJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref OrbitalTurretBehaviourJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref OrbitalTurretBehaviourJob job, EntityManager entityManager)
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
		public ComponentLookup<IsCloneCD> isCloneLookup;

		public NetworkTick currentTick;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref ShieldCD shieldCD, ref RangeAttackStateCD rangeAttackStateCD, ref OrbitalTurretBehaviourCD orbitalTurretBehaviourCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, in StateInfoCD stateInfo)
		{
			bool flag = rangeAttackStateCD.internalState != RangeAttackInternalState.CeasingToShoot || rangeAttackStateCD.internalTimer.GetElapsedTime(time) < 1f;
			shieldCD.active = stateInfo.IsCurrentState(StateID.RangeAttack) && flag;
			if (!shieldCD.active && stateInfo.IsCurrentState(StateID.RangeAttack) && animationBuffer.GetLastAddedElement(in animationBufferPointer).animID != -601574123)
			{
				AnimationUtilities.TriggerAnimation(-601574123, currentTick, animationBuffer, ref animationBufferPointer);
			}
			if (stateInfo.IsCurrentState(StateID.RangeAttack) && orbitalTurretBehaviourCD.hasUpdated)
			{
				orbitalTurretBehaviourCD.hasUpdated = false;
			}
			else if (!stateInfo.IsCurrentState(StateID.RangeAttack) && !orbitalTurretBehaviourCD.hasUpdated)
			{
				orbitalTurretBehaviourCD.hasUpdated = true;
				rangeAttackStateCD.timeBetweenShots = 0.2f;
				rangeAttackStateCD.attackDuration = 2f;
				rangeAttackStateCD.minDistanceFromTargetToAllowAttack = 0f;
				rangeAttackStateCD.projectileFollowsTarget = false;
				rangeAttackStateCD.spreadAngle = 2f;
				rangeAttackStateCD.spreadType = ProjectileSpreadType.Random;
				rangeAttackStateCD.allowReAimingWhileShooting = false;
				rangeAttackStateCD.dontAllowReAimingDuringAntipation = isCloneLookup.HasAndIsComponentEnabled(entity);
				rangeAttackStateCD.animOverride = 678043229;
				rangeAttackStateCD.anticipationDuration = 1.5f;
				rangeAttackStateCD.endDuration = 2f;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ShieldCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RangeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__OrbitalTurretBehaviourCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref ShieldCD shieldCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShieldCD>(nativeArrayPtr2, i);
					ref RangeAttackStateCD rangeAttackStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr3, i);
					ref OrbitalTurretBehaviourCD orbitalTurretBehaviourCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OrbitalTurretBehaviourCD>(nativeArrayPtr4, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, ref shieldCD, ref rangeAttackStateCD, ref orbitalTurretBehaviourCD, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr6, i));
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
						ref ShieldCD shieldCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShieldCD>(nativeArrayPtr2, nextRangeBegin);
						ref RangeAttackStateCD rangeAttackStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr3, nextRangeBegin);
						ref OrbitalTurretBehaviourCD orbitalTurretBehaviourCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OrbitalTurretBehaviourCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref shieldCD2, ref rangeAttackStateCD2, ref orbitalTurretBehaviourCD2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr6, nextRangeBegin));
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
					ref ShieldCD shieldCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShieldCD>(nativeArrayPtr2, j);
					ref RangeAttackStateCD rangeAttackStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr3, j);
					ref OrbitalTurretBehaviourCD orbitalTurretBehaviourCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OrbitalTurretBehaviourCD>(nativeArrayPtr4, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, ref shieldCD3, ref rangeAttackStateCD3, ref orbitalTurretBehaviourCD3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr6, j));
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
					ref ShieldCD shieldCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShieldCD>(nativeArrayPtr2, k);
					ref RangeAttackStateCD rangeAttackStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr3, k);
					ref OrbitalTurretBehaviourCD orbitalTurretBehaviourCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OrbitalTurretBehaviourCD>(nativeArrayPtr4, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, ref shieldCD4, ref rangeAttackStateCD4, ref orbitalTurretBehaviourCD4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr6, k));
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
	[WithAll(new Type[] { typeof(CicadaEnemyCD) })]
	[WithChangeFilter(new Type[] { typeof(EnrageStateCD) })]
	private struct CicadaEnemyEnrageSpeedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EnrageStateCD> __EnrageStateCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__MovementSpeedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>();
					__EnrageStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__MovementSpeedCD_RW_ComponentTypeHandle.Update(ref state);
					__EnrageStateCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EnrageStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CicadaEnemyCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementSpeedCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
				{
					new ComponentType(typeof(EnrageStateCD))
				});
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
			public void Run(ref CicadaEnemyEnrageSpeedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CicadaEnemyEnrageSpeedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CicadaEnemyEnrageSpeedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CicadaEnemyEnrageSpeedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CicadaEnemyEnrageSpeedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CicadaEnemyEnrageSpeedJob job, EntityManager entityManager)
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

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref MovementSpeedCD movementSpeedCD, in EnrageStateCD enrageCD)
		{
			movementSpeedCD.speed = (enrageCD.isEnraged ? (movementSpeedCD.originalSpeed * 1.3f) : movementSpeedCD.originalSpeed);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MovementSpeedCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EnrageStateCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr2, i));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr2, k));
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
	[WithAll(new Type[] { typeof(CicadaEnemyCD) })]
	[WithChangeFilter(new Type[] { typeof(HealthCD) })]
	private struct CicadaEnemyDamagedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<NearbyEntitiesTrackerCD> __NearbyEntitiesTrackerCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<SnakeMovementStateCD> __SnakeMovementStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<NearbyEntitiesTrackerCD>();
					__SnakeMovementStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeMovementStateCD>();
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle.Update(ref state);
					__SnakeMovementStateCD_RW_ComponentTypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CicadaEnemyCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NearbyEntitiesTrackerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeMovementStateCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
				{
					new ComponentType(typeof(HealthCD))
				});
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
			public void Run(ref CicadaEnemyDamagedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CicadaEnemyDamagedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CicadaEnemyDamagedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CicadaEnemyDamagedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CicadaEnemyDamagedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CicadaEnemyDamagedJob job, EntityManager entityManager)
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

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref NearbyEntitiesTrackerCD nearbyEntitiesTrackerCD, ref SnakeMovementStateCD snakeMovementStateCD, in HealthCD healthCD, in ObjectDataCD objectDataCD)
		{
			if (objectDataCD.objectID == ObjectID.NatureCicadaEnemy)
			{
				bool flag = healthCD.health < healthCD.maxHealth;
				snakeMovementStateCD.externallyRequestedPhase = (flag ? SnakeMovementPhaseType.NONE : SnakeMovementPhaseType.PATROL);
				nearbyEntitiesTrackerCD.radius = (flag ? 20f : 5f);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SnakeMovementStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, i));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, nextRangeBegin));
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
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, k));
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
	private struct RobotPatrollerBehaviourJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<RobotPatrollerBehaviourCD> __RobotPatrollerBehaviourCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__RobotPatrollerBehaviourCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RobotPatrollerBehaviourCD>();
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ShootMortarProjectileStateCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__RobotPatrollerBehaviourCD_RW_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RobotPatrollerBehaviourCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShootMortarProjectileStateCD>();
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
			public void Run(ref RobotPatrollerBehaviourJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RobotPatrollerBehaviourJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RobotPatrollerBehaviourJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RobotPatrollerBehaviourJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RobotPatrollerBehaviourJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RobotPatrollerBehaviourJob job, EntityManager entityManager)
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

		private const int OilProjectiles = 2;

		private const int FireProjectiles = 1;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref RobotPatrollerBehaviourCD robotPatrollerBehaviourCD, in StateInfoCD stateInfoCD, ref ShootMortarProjectileStateCD shootMortarProjectileStateCD)
		{
			bool flag = stateInfoCD.IsCurrentState(StateID.ShootMortarProjectile);
			bool wasInShootMortarState = robotPatrollerBehaviourCD.wasInShootMortarState;
			robotPatrollerBehaviourCD.wasInShootMortarState = flag;
			if (!flag && wasInShootMortarState)
			{
				robotPatrollerBehaviourCD.mortarStateCounter++;
				robotPatrollerBehaviourCD.mortarStateCounter %= 3;
				int num = 2;
				if (robotPatrollerBehaviourCD.mortarStateCounter == 0)
				{
					shootMortarProjectileStateCD.mortarProjectileID = ObjectID.RobotPatrollerMeteorOilProjectile;
					shootMortarProjectileStateCD.minAmountOfProjectiles = 3;
					shootMortarProjectileStateCD.maxAmountOfProjectiles = 3;
					shootMortarProjectileStateCD.goDownTime = 1f;
					shootMortarProjectileStateCD.minRandomSpreadDistance = 0.5f;
					shootMortarProjectileStateCD.maxRandomSpreadDistance = 2f;
					shootMortarProjectileStateCD.mortarDamage = robotPatrollerBehaviourCD.oilMortarDamage;
					shootMortarProjectileStateCD.mortarTileDamage = robotPatrollerBehaviourCD.oilMortarTileDamage;
				}
				else if (robotPatrollerBehaviourCD.mortarStateCounter == num)
				{
					shootMortarProjectileStateCD.mortarProjectileID = ObjectID.RobotPatrollerMeteorFireProjectile;
					shootMortarProjectileStateCD.minAmountOfProjectiles = 1;
					shootMortarProjectileStateCD.maxAmountOfProjectiles = 1;
					shootMortarProjectileStateCD.goDownTime = 1.5f;
					shootMortarProjectileStateCD.minRandomSpreadDistance = 0f;
					shootMortarProjectileStateCD.maxRandomSpreadDistance = 0f;
					shootMortarProjectileStateCD.mortarDamage = robotPatrollerBehaviourCD.fireMortarDamage;
					shootMortarProjectileStateCD.mortarTileDamage = robotPatrollerBehaviourCD.fireMortarTileDamage;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RobotPatrollerBehaviourCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotPatrollerBehaviourCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr4, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotPatrollerBehaviourCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr4, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotPatrollerBehaviourCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr4, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotPatrollerBehaviourCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr4, k));
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
	public struct RobotMinerBehaviourJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<ShieldCD> __ShieldCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ChargeAttackStateCD> __ChargeAttackStateCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<IsInCombatCD> __IsInCombatCD_RO_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__ShieldCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ShieldCD>();
					__ChargeAttackStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ChargeAttackStateCD>(isReadOnly: true);
					__IsInCombatCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<IsInCombatCD>(isReadOnly: true);
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__ShieldCD_RW_ComponentTypeHandle.Update(ref state);
					__ChargeAttackStateCD_RO_ComponentTypeHandle.Update(ref state);
					__IsInCombatCD_RO_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ChargeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsInCombatCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShieldCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
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
			public void Run(ref RobotMinerBehaviourJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RobotMinerBehaviourJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RobotMinerBehaviourJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RobotMinerBehaviourJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RobotMinerBehaviourJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RobotMinerBehaviourJob job, EntityManager entityManager)
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

		public NetworkTick currentTick;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref ShieldCD shieldCD, in ChargeAttackStateCD chargeAttackStateCD, in IsInCombatCD isInCombatCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, in StateInfoCD stateInfo)
		{
			bool flag = !isInCombatCD.isInCombat && (stateInfo.IsCurrentState(StateID.RandomWalking) || stateInfo.IsCurrentState(StateID.Idle));
			shieldCD.active = !stateInfo.IsCurrentState(StateID.Death) && !flag && !stateInfo.IsCurrentState(StateID.DamageObject) && !stateInfo.IsCurrentState(StateID.Charge);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ShieldCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ChargeAttackStateCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__IsInCombatCD_RO_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref ShieldCD shieldCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShieldCD>(nativeArrayPtr, i);
					ref ChargeAttackStateCD chargeAttackStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChargeAttackStateCD>(nativeArrayPtr2, i);
					ref IsInCombatCD isInCombatCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr3, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(ref shieldCD, in chargeAttackStateCD, in isInCombatCD, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, i));
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
						ref ShieldCD shieldCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShieldCD>(nativeArrayPtr, nextRangeBegin);
						ref ChargeAttackStateCD chargeAttackStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChargeAttackStateCD>(nativeArrayPtr2, nextRangeBegin);
						ref IsInCombatCD isInCombatCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(ref shieldCD2, in chargeAttackStateCD2, in isInCombatCD2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, nextRangeBegin));
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
					ref ShieldCD shieldCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShieldCD>(nativeArrayPtr, j);
					ref ChargeAttackStateCD chargeAttackStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChargeAttackStateCD>(nativeArrayPtr2, j);
					ref IsInCombatCD isInCombatCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr3, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(ref shieldCD3, in chargeAttackStateCD3, in isInCombatCD3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					ref ShieldCD shieldCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShieldCD>(nativeArrayPtr, k);
					ref ChargeAttackStateCD chargeAttackStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChargeAttackStateCD>(nativeArrayPtr2, k);
					ref IsInCombatCD isInCombatCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr3, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(ref shieldCD4, in chargeAttackStateCD4, in isInCombatCD4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, k));
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
		[ReadOnly]
		public ComponentLookup<IsCloneCD> __IsCloneCD_RO_ComponentLookup;

		public OrbitalTurretBehaviourJob.InternalCompilerQueryAndHandleData __StateBehaviourModifierSystem_OrbitalTurretBehaviourJob_WithDefaultQuery_JobEntityTypeHandle;

		public CicadaEnemyEnrageSpeedJob.InternalCompilerQueryAndHandleData __StateBehaviourModifierSystem_CicadaEnemyEnrageSpeedJob_WithDefaultQuery_JobEntityTypeHandle;

		public CicadaEnemyDamagedJob.InternalCompilerQueryAndHandleData __StateBehaviourModifierSystem_CicadaEnemyDamagedJob_WithDefaultQuery_JobEntityTypeHandle;

		public RobotPatrollerBehaviourJob.InternalCompilerQueryAndHandleData __StateBehaviourModifierSystem_RobotPatrollerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle;

		public RobotMinerBehaviourJob.InternalCompilerQueryAndHandleData __StateBehaviourModifierSystem_RobotMinerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IsCloneCD_RO_ComponentLookup = state.GetComponentLookup<IsCloneCD>(isReadOnly: true);
			__StateBehaviourModifierSystem_OrbitalTurretBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__StateBehaviourModifierSystem_CicadaEnemyEnrageSpeedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__StateBehaviourModifierSystem_CicadaEnemyDamagedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__StateBehaviourModifierSystem_RobotPatrollerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__StateBehaviourModifierSystem_RobotMinerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00003F0D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003F0D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003F0D_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1080708479_0;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_1080708479_0.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new OrbitalTurretBehaviourJob
		{
			isCloneLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsCloneCD_RO_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime
		}, __TypeHandle.__StateBehaviourModifierSystem_OrbitalTurretBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(default(CicadaEnemyEnrageSpeedJob), __TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyEnrageSpeedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(default(CicadaEnemyDamagedJob), __TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyDamagedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_3(default(RobotPatrollerBehaviourJob), __TypeHandle.__StateBehaviourModifierSystem_RobotPatrollerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_4(new RobotMinerBehaviourJob
		{
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime
		}, __TypeHandle.__StateBehaviourModifierSystem_RobotMinerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(OrbitalTurretBehaviourJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__StateBehaviourModifierSystem_OrbitalTurretBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__StateBehaviourModifierSystem_OrbitalTurretBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__StateBehaviourModifierSystem_OrbitalTurretBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__StateBehaviourModifierSystem_OrbitalTurretBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(CicadaEnemyEnrageSpeedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyEnrageSpeedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyEnrageSpeedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyEnrageSpeedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyEnrageSpeedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(CicadaEnemyDamagedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyDamagedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyDamagedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyDamagedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__StateBehaviourModifierSystem_CicadaEnemyDamagedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(RobotPatrollerBehaviourJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__StateBehaviourModifierSystem_RobotPatrollerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__StateBehaviourModifierSystem_RobotPatrollerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__StateBehaviourModifierSystem_RobotPatrollerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__StateBehaviourModifierSystem_RobotPatrollerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(RobotMinerBehaviourJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__StateBehaviourModifierSystem_RobotMinerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__StateBehaviourModifierSystem_RobotMinerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__StateBehaviourModifierSystem_RobotMinerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__StateBehaviourModifierSystem_RobotMinerBehaviourJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1080708479_0 = entityQueryBuilder2.Build(ref state);
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
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003F0D_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((StateBehaviourModifierSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((StateBehaviourModifierSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
