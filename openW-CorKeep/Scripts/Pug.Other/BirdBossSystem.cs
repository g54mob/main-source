using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using Pug.UnityExtensions;
using PugTilemap;
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
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct BirdBossSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct BirdBossAppearJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<BirdBossAppearStateCD> __BirdBossAppearStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<BirdBossHasAppearedCD> __BirdBossHasAppearedCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__BirdBossAppearStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BirdBossAppearStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__BirdBossHasAppearedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BirdBossHasAppearedCD>();
				}

				public void Update(ref SystemState state)
				{
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__BirdBossAppearStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__BirdBossHasAppearedCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BirdBossAppearStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BirdBossHasAppearedCD>();
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
			public void Run(ref BirdBossAppearJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BirdBossAppearJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BirdBossAppearJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BirdBossAppearJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BirdBossAppearJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BirdBossAppearJob job, EntityManager entityManager)
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
		public ComponentLookup<HealthCD> healthLookup;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(RefRW<StateInfoCD> stateInfoRef, RefRW<BirdBossAppearStateCD> appearStateRef, DynamicBuffer<AnimationBuffer> animationRef, RefRW<AnimationBufferPointer> animationBufferPointer, RefRW<BirdBossHasAppearedCD> hasAppearedRef)
		{
			if (!stateInfoRef.ValueRO.IsCurrentState(StateID.BirdBossAppear))
			{
				return;
			}
			ref readonly BirdBossAppearStateCD valueRO = ref appearStateRef.ValueRO;
			if (valueRO.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(-1476340264, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				appearStateRef.ValueRW.internalState = 1;
				appearStateRef.ValueRW.timer.Start(time, valueRO.landDuration);
				if (healthLookup.TryGetComponent(valueRO.glimmeringObject, out var componentData))
				{
					componentData.health = 0;
					ecb.SetComponent(valueRO.glimmeringObject, componentData);
					ecb.SetComponentEnabled<DontDropSelfCD>(valueRO.glimmeringObject, value: true);
				}
			}
			else if (appearStateRef.ValueRW.timer.IsTimerElapsed(time) && valueRO.internalState == 1)
			{
				hasAppearedRef.ValueRW.Value = true;
				appearStateRef.ValueRW.internalState = 2;
				stateInfoRef.ValueRW.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr ptr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BirdBossAppearStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr ptr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr ptr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BirdBossHasAppearedCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					RefRW<StateInfoCD> refRW = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, i);
					RefRW<BirdBossAppearStateCD> refRW2 = InternalCompilerInterface.GetRefRW<BirdBossAppearStateCD>(ptr2, i);
					DynamicBuffer<AnimationBuffer> animationRef = bufferAccessor[i];
					RefRW<AnimationBufferPointer> refRW3 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, i);
					RefRW<BirdBossHasAppearedCD> refRW4 = InternalCompilerInterface.GetRefRW<BirdBossHasAppearedCD>(ptr4, i);
					Execute(refRW, refRW2, animationRef, refRW3, refRW4);
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
						RefRW<StateInfoCD> refRW5 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, nextRangeBegin);
						RefRW<BirdBossAppearStateCD> refRW6 = InternalCompilerInterface.GetRefRW<BirdBossAppearStateCD>(ptr2, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationRef2 = bufferAccessor[nextRangeBegin];
						RefRW<AnimationBufferPointer> refRW7 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, nextRangeBegin);
						RefRW<BirdBossHasAppearedCD> refRW8 = InternalCompilerInterface.GetRefRW<BirdBossHasAppearedCD>(ptr4, nextRangeBegin);
						Execute(refRW5, refRW6, animationRef2, refRW7, refRW8);
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
					RefRW<StateInfoCD> refRW9 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, j);
					RefRW<BirdBossAppearStateCD> refRW10 = InternalCompilerInterface.GetRefRW<BirdBossAppearStateCD>(ptr2, j);
					DynamicBuffer<AnimationBuffer> animationRef3 = bufferAccessor[j];
					RefRW<AnimationBufferPointer> refRW11 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, j);
					RefRW<BirdBossHasAppearedCD> refRW12 = InternalCompilerInterface.GetRefRW<BirdBossHasAppearedCD>(ptr4, j);
					Execute(refRW9, refRW10, animationRef3, refRW11, refRW12);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					RefRW<StateInfoCD> refRW13 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, k);
					RefRW<BirdBossAppearStateCD> refRW14 = InternalCompilerInterface.GetRefRW<BirdBossAppearStateCD>(ptr2, k);
					DynamicBuffer<AnimationBuffer> animationRef4 = bufferAccessor[k];
					RefRW<AnimationBufferPointer> refRW15 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, k);
					RefRW<BirdBossHasAppearedCD> refRW16 = InternalCompilerInterface.GetRefRW<BirdBossHasAppearedCD>(ptr4, k);
					Execute(refRW13, refRW14, animationRef4, refRW15, refRW16);
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
	private struct BirdBossEnterCombatJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BirdBossHasAppearedCD> __BirdBossHasAppearedCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__BirdBossHasAppearedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BirdBossHasAppearedCD>(isReadOnly: true);
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__BirdBossHasAppearedCD_RO_ComponentTypeHandle.Update(ref state);
					__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BirdBossHasAppearedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
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
			public void Run(ref BirdBossEnterCombatJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BirdBossEnterCombatJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BirdBossEnterCombatJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BirdBossEnterCombatJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BirdBossEnterCombatJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BirdBossEnterCombatJob job, EntityManager entityManager)
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
		public ComponentLookup<ForceInCombatCD> forceInCombatLookup;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in BirdBossHasAppearedCD hasAppeared, in DistanceToPlayerCD distanceToPlayer)
		{
			if (hasAppeared.Value)
			{
				bool flag = forceInCombatLookup.HasComponent(entity);
				bool isVisible = distanceToPlayer.isVisible;
				if (flag && !isVisible)
				{
					ecb.RemoveComponent<ForceInCombatCD>(entity);
				}
				else if (!flag && isVisible)
				{
					ecb.AddComponent<ForceInCombatCD>(entity);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BirdBossHasAppearedCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BirdBossHasAppearedCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BirdBossHasAppearedCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BirdBossHasAppearedCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BirdBossHasAppearedCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, k));
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
	private struct BirdBossFlyingStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<BirdBossFlyingAboveStateCD> __BirdBossFlyingAboveStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<BirdBossHasAppearedCD> __BirdBossHasAppearedCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__BirdBossFlyingAboveStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BirdBossFlyingAboveStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__BirdBossHasAppearedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BirdBossHasAppearedCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__BirdBossFlyingAboveStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__BirdBossHasAppearedCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BirdBossFlyingAboveStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BirdBossHasAppearedCD>();
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
			public void Run(ref BirdBossFlyingStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BirdBossFlyingStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BirdBossFlyingStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BirdBossFlyingStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BirdBossFlyingStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BirdBossFlyingStateJob job, EntityManager entityManager)
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
		public ComponentLookup<BossSpawnLocationCD> bossSpawnLocationLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> trackedEntitiesBuffer;

		public NativeList<Entity> spawnLocationEntities;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public double time;

		public int hiddenAnimID;

		public Unity.Mathematics.Random rng;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, RefRW<StateInfoCD> stateInfoRef, RefRW<BirdBossFlyingAboveStateCD> flyingStateRef, DynamicBuffer<AnimationBuffer> animationRef, RefRW<AnimationBufferPointer> animationBufferPointer, RefRW<BirdBossHasAppearedCD> hasAppearedRef)
		{
			ref readonly StateInfoCD valueRO = ref stateInfoRef.ValueRO;
			ref readonly BirdBossFlyingAboveStateCD valueRO2 = ref flyingStateRef.ValueRO;
			if (!valueRO.IsCurrentState(StateID.BirdBossFlyingAbove))
			{
				flyingStateRef.ValueRW.internalState = 0;
				return;
			}
			hasAppearedRef.ValueRW.Value = false;
			flyingStateRef.ValueRW.cooldownTimer.Start(time, 10f);
			if (valueRO2.internalState == 0)
			{
				if (valueRO2.hasEnteredStateOnce)
				{
					AnimationUtilities.TriggerAnimation(-1518581387, currentTick, animationRef, ref animationBufferPointer.ValueRW);
					flyingStateRef.ValueRW.internalState = 1;
				}
				else
				{
					AnimationUtilities.TriggerAnimation(hiddenAnimID, currentTick, animationRef, ref animationBufferPointer.ValueRW);
					flyingStateRef.ValueRW.hasEnteredStateOnce = true;
					flyingStateRef.ValueRW.internalState = 2;
				}
				flyingStateRef.ValueRW.timer.Start(time, 1f);
			}
			else if (valueRO2.internalState == 1 && flyingStateRef.ValueRW.timer.IsTimerElapsed(time))
			{
				flyingStateRef.ValueRW.internalState = 2;
				AnimationUtilities.TriggerAnimation(hiddenAnimID, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				flyingStateRef.ValueRW.timer.Start(time, 1f);
			}
			else
			{
				if (valueRO2.internalState != 2 || !flyingStateRef.ValueRW.timer.IsTimerElapsed(time))
				{
					return;
				}
				if (valueRO2.flyAnimCooldownTimer.isRunning && !flyingStateRef.ValueRW.flyAnimCooldownTimer.IsTimerElapsed(time))
				{
					if (flyingStateRef.ValueRW.flyAnimCooldownTimer.GetElapsedTime(time) > 4f)
					{
						stateInfoRef.ValueRW.Unlock();
					}
					return;
				}
				Entity entity2 = Entity.Null;
				bool flag = false;
				for (int i = 0; i < spawnLocationEntities.Length; i++)
				{
					entity2 = spawnLocationEntities[i];
					if (bossSpawnLocationLookup[entity2].bossID != ObjectID.BirdBoss)
					{
						continue;
					}
					for (int j = 0; j < trackedEntitiesBuffer[entity2].Length; j++)
					{
						Entity entity3 = trackedEntitiesBuffer[entity2][j].entity;
						if (objectDataLookup.TryGetComponent(entity3, out var componentData) && componentData.objectID == ObjectID.Player)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					stateInfoRef.ValueRW.Lock();
					ecb.SetComponent(entity, localTransformLookup[entity2]);
					AnimationUtilities.TriggerAnimation(1244953283, currentTick, animationRef, ref animationBufferPointer.ValueRW);
					flyingStateRef.ValueRW.flyAnimCooldownTimer.Start(time, rng.NextFloat(20f, 40f));
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr ptr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BirdBossFlyingAboveStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr ptr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr ptr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BirdBossHasAppearedCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					RefRW<StateInfoCD> refRW = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, i);
					RefRW<BirdBossFlyingAboveStateCD> refRW2 = InternalCompilerInterface.GetRefRW<BirdBossFlyingAboveStateCD>(ptr2, i);
					DynamicBuffer<AnimationBuffer> animationRef = bufferAccessor[i];
					RefRW<AnimationBufferPointer> refRW3 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, i);
					RefRW<BirdBossHasAppearedCD> refRW4 = InternalCompilerInterface.GetRefRW<BirdBossHasAppearedCD>(ptr4, i);
					Execute(entity, refRW, refRW2, animationRef, refRW3, refRW4);
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
						RefRW<StateInfoCD> refRW5 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, nextRangeBegin);
						RefRW<BirdBossFlyingAboveStateCD> refRW6 = InternalCompilerInterface.GetRefRW<BirdBossFlyingAboveStateCD>(ptr2, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationRef2 = bufferAccessor[nextRangeBegin];
						RefRW<AnimationBufferPointer> refRW7 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, nextRangeBegin);
						RefRW<BirdBossHasAppearedCD> refRW8 = InternalCompilerInterface.GetRefRW<BirdBossHasAppearedCD>(ptr4, nextRangeBegin);
						Execute(entity2, refRW5, refRW6, animationRef2, refRW7, refRW8);
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
					RefRW<StateInfoCD> refRW9 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, j);
					RefRW<BirdBossFlyingAboveStateCD> refRW10 = InternalCompilerInterface.GetRefRW<BirdBossFlyingAboveStateCD>(ptr2, j);
					DynamicBuffer<AnimationBuffer> animationRef3 = bufferAccessor[j];
					RefRW<AnimationBufferPointer> refRW11 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, j);
					RefRW<BirdBossHasAppearedCD> refRW12 = InternalCompilerInterface.GetRefRW<BirdBossHasAppearedCD>(ptr4, j);
					Execute(entity3, refRW9, refRW10, animationRef3, refRW11, refRW12);
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
					RefRW<StateInfoCD> refRW13 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, k);
					RefRW<BirdBossFlyingAboveStateCD> refRW14 = InternalCompilerInterface.GetRefRW<BirdBossFlyingAboveStateCD>(ptr2, k);
					DynamicBuffer<AnimationBuffer> animationRef4 = bufferAccessor[k];
					RefRW<AnimationBufferPointer> refRW15 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, k);
					RefRW<BirdBossHasAppearedCD> refRW16 = InternalCompilerInterface.GetRefRW<BirdBossHasAppearedCD>(ptr4, k);
					Execute(entity4, refRW13, refRW14, animationRef4, refRW15, refRW16);
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
	[WithAll(new Type[] { typeof(LocalTransform) })]
	private struct BirdBossSpawnBeamsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<BirdBossSpawnBeamsStateCD> __BirdBossSpawnBeamsStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<EnrageStateCD> __EnrageStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__BirdBossSpawnBeamsStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BirdBossSpawnBeamsStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__EnrageStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EnrageStateCD>();
					__NearbyEntitiesBufferCD_RW_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__BirdBossSpawnBeamsStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__EnrageStateCD_RW_ComponentTypeHandle.Update(ref state);
					__NearbyEntitiesBufferCD_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BirdBossSpawnBeamsStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EnrageStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NearbyEntitiesBufferCD>();
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
			public void Run(ref BirdBossSpawnBeamsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BirdBossSpawnBeamsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BirdBossSpawnBeamsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BirdBossSpawnBeamsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BirdBossSpawnBeamsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BirdBossSpawnBeamsJob job, EntityManager entityManager)
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
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<BirdBossBeamCD> birdBossBeamLookup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public double time;

		public Unity.Mathematics.Random rng;

		public int screechAnimID;

		public int idleAnimID;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, RefRW<StateInfoCD> stateInfoRef, RefRW<BirdBossSpawnBeamsStateCD> spawnBeamsStateRef, DynamicBuffer<AnimationBuffer> animationRef, RefRW<AnimationBufferPointer> animationBufferPointer, EnrageStateCD enrageState, DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			if (!stateInfoRef.ValueRO.IsCurrentState(StateID.BirdBossSpawnBeams))
			{
				return;
			}
			LocalTransform localTransform = localTransformLookup[entity];
			ref readonly BirdBossSpawnBeamsStateCD valueRO = ref spawnBeamsStateRef.ValueRO;
			spawnBeamsStateRef.ValueRW.cooldownTimer.Start(time, rng.NextFloat(valueRO.minCooldown, valueRO.maxCooldown));
			if (valueRO.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(screechAnimID, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				spawnBeamsStateRef.ValueRW.internalState = 1;
				spawnBeamsStateRef.ValueRW.timer.Start(time, valueRO.durationUntilBeamSpawn);
			}
			else if (valueRO.internalState == 1 && spawnBeamsStateRef.ValueRW.timer.IsTimerElapsed(time))
			{
				bool flag = nearbyEntities.Length > 0;
				float3 float5 = localTransform.Position + new float3(0.5f, 0f, 0.5f);
				int num = rng.NextInt(0, 4);
				int num2 = ((num == 0) ? 20 : 30);
				NativeParallelHashSet<int2> nativeParallelHashSet = new NativeParallelHashSet<int2>(num2 * 9, Allocator.Temp);
				for (int i = 0; i < num2; i++)
				{
					float3 float6 = float3.zero;
					int2 int5 = int2.zero;
					float3 moveDirection = float3.zero;
					float num3 = 4f;
					float loopDuration = 4f;
					bool moveSideWays = false;
					switch (num)
					{
					case 0:
					{
						float3 x2 = float5;
						if (flag)
						{
							x2 = localTransformLookup[nearbyEntities[rng.NextInt(0, nearbyEntities.Length)].entity].Position;
						}
						float3 float9 = rng.NextFloat3(-1f, 1f);
						float9.y = 0f;
						math.normalizesafe(float9, new float3(1f, 0f, 0f));
						x2 += float9 * rng.NextFloat(0f, 15f);
						float6 = math.round(x2);
						int5 = float6.RoundToInt2();
						moveDirection = GetRandomBeamMoveDirection(rng);
						break;
					}
					case 1:
					{
						float3 x = rng.NextFloat3(-1f, 1f);
						x.y = 0f;
						x = math.normalizesafe(x, new float3(1f, 0f, 0f));
						float6 = float5 + x * 12f;
						int5 = float6.RoundToInt2();
						moveDirection = math.normalizesafe(float5 - float6);
						num3 = 5f;
						loopDuration = 4f;
						moveSideWays = true;
						break;
					}
					case 2:
					{
						int num6 = num2 / 2;
						float3 float10 = ((rng.NextFloat() > 0.5f) ? new float3(0f, 0f, 1f) : new float3(0f, 0f, -1f));
						float3 float11 = new float3(-num6 + i, 0f, 0f);
						float6 = float5 + (float10 * 8f + float11);
						int5 = float6.RoundToInt2();
						moveDirection = -float10;
						num3 = 5f;
						loopDuration = 4f;
						break;
					}
					case 3:
					{
						int num4 = num2 / 2;
						float3 float7 = ((rng.NextFloat() > 0.5f) ? new float3(1f, 0f, 0f) : new float3(-1f, 0f, 0f));
						float3 float8 = new float3(0f, 0f, -num4 + i);
						int num5 = rng.NextInt(-2, 3);
						float6 = float5 + (float7 * (10 + num5) + float8);
						int5 = float6.RoundToInt2();
						moveDirection = -float7;
						num3 = 5f;
						loopDuration = 4f;
						break;
					}
					}
					if (enrageState.isEnraged)
					{
						num3 *= 1.4f;
					}
					bool flag2 = math.distancesq(float5, float6) < 900f;
					if (!(!nativeParallelHashSet.Contains(int5) && flag2))
					{
						continue;
					}
					Entity prefabEntity;
					Entity e = EntityUtility.CreateEntity(ecb, float6, ObjectID.BirdBossBeam, 1, databaseBankCD.databaseBankBlob, out prefabEntity);
					BirdBossBeamCD component = birdBossBeamLookup[prefabEntity];
					component.moveDirection = moveDirection;
					component.moveSpeed = num3;
					component.loopDuration = loopDuration;
					component.moveSideWays = moveSideWays;
					ecb.SetComponent(e, new OwnerReferenceCD
					{
						owner = entity
					});
					ecb.SetComponent(e, component);
					for (int j = -1; j < 1; j++)
					{
						for (int k = -1; k < 1; k++)
						{
							int2 item = int5 + new int2(j, k);
							if (!nativeParallelHashSet.Contains(item))
							{
								nativeParallelHashSet.Add(item);
							}
						}
					}
				}
				nativeParallelHashSet.Dispose();
				spawnBeamsStateRef.ValueRW.internalState = 2;
				spawnBeamsStateRef.ValueRW.timer.Start(time, valueRO.durationAfterBeamSpawn);
			}
			else if (valueRO.internalState == 2 && spawnBeamsStateRef.ValueRW.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(idleAnimID, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				spawnBeamsStateRef.ValueRW.internalState = 3;
			}
			else if (valueRO.internalState == 3)
			{
				stateInfoRef.ValueRW.LeaveState();
			}
		}

		private static float3 GetRandomBeamMoveDirection(Unity.Mathematics.Random rng)
		{
			float num = rng.NextFloat();
			if (num < 0.25f)
			{
				return new float3(1f, 0f, 0f);
			}
			if (num < 0.5f)
			{
				return new float3(-1f, 0f, 0f);
			}
			if (num < 0.75f)
			{
				return new float3(0f, 0f, 1f);
			}
			return new float3(0f, 0f, -1f);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr ptr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BirdBossSpawnBeamsStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr ptr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__EnrageStateCD_RW_ComponentTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__NearbyEntitiesBufferCD_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					RefRW<StateInfoCD> refRW = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, i);
					RefRW<BirdBossSpawnBeamsStateCD> refRW2 = InternalCompilerInterface.GetRefRW<BirdBossSpawnBeamsStateCD>(ptr2, i);
					DynamicBuffer<AnimationBuffer> animationRef = bufferAccessor[i];
					RefRW<AnimationBufferPointer> refRW3 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, i);
					ref EnrageStateCD reference = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr2, i);
					DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities = bufferAccessor2[i];
					Execute(entity, refRW, refRW2, animationRef, refRW3, reference, nearbyEntities);
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
						RefRW<StateInfoCD> refRW4 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, nextRangeBegin);
						RefRW<BirdBossSpawnBeamsStateCD> refRW5 = InternalCompilerInterface.GetRefRW<BirdBossSpawnBeamsStateCD>(ptr2, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationRef2 = bufferAccessor[nextRangeBegin];
						RefRW<AnimationBufferPointer> refRW6 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, nextRangeBegin);
						ref EnrageStateCD reference2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, refRW4, refRW5, animationRef2, refRW6, reference2, nearbyEntities2);
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
					RefRW<StateInfoCD> refRW7 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, j);
					RefRW<BirdBossSpawnBeamsStateCD> refRW8 = InternalCompilerInterface.GetRefRW<BirdBossSpawnBeamsStateCD>(ptr2, j);
					DynamicBuffer<AnimationBuffer> animationRef3 = bufferAccessor[j];
					RefRW<AnimationBufferPointer> refRW9 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, j);
					ref EnrageStateCD reference3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr2, j);
					DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities3 = bufferAccessor2[j];
					Execute(entity3, refRW7, refRW8, animationRef3, refRW9, reference3, nearbyEntities3);
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
					RefRW<StateInfoCD> refRW10 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, k);
					RefRW<BirdBossSpawnBeamsStateCD> refRW11 = InternalCompilerInterface.GetRefRW<BirdBossSpawnBeamsStateCD>(ptr2, k);
					DynamicBuffer<AnimationBuffer> animationRef4 = bufferAccessor[k];
					RefRW<AnimationBufferPointer> refRW12 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, k);
					ref EnrageStateCD reference4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr2, k);
					DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities4 = bufferAccessor2[k];
					Execute(entity4, refRW10, refRW11, animationRef4, refRW12, reference4, nearbyEntities4);
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
	private struct BirdBossSpawnStonesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<BirdBossSpawnStonesStateCD> __BirdBossSpawnStonesStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__BirdBossSpawnStonesStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BirdBossSpawnStonesStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
					__NearbyEntitiesBufferCD_RW_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>();
				}

				public void Update(ref SystemState state)
				{
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__BirdBossSpawnStonesStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
					__NearbyEntitiesBufferCD_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BirdBossSpawnStonesStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NearbyEntitiesBufferCD>();
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
			public void Run(ref BirdBossSpawnStonesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BirdBossSpawnStonesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BirdBossSpawnStonesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BirdBossSpawnStonesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BirdBossSpawnStonesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BirdBossSpawnStonesJob job, EntityManager entityManager)
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
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		public int numberOfPlayers;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public double time;

		public Unity.Mathematics.Random rng;

		public int screechAnimID;

		public int idleAnimID;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(RefRW<StateInfoCD> stateInfoRef, RefRW<BirdBossSpawnStonesStateCD> spawnStonesStateRef, DynamicBuffer<AnimationBuffer> animationRef, RefRW<AnimationBufferPointer> animationBufferPointer, LocalTransform transform, DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			if (!stateInfoRef.ValueRO.IsCurrentState(StateID.BirdBossSpawnStones))
			{
				return;
			}
			ref readonly BirdBossSpawnStonesStateCD valueRO = ref spawnStonesStateRef.ValueRO;
			spawnStonesStateRef.ValueRW.cooldownTimer.Start(time, rng.NextFloat(valueRO.minCooldown, valueRO.maxCooldown));
			if (valueRO.internalState == 0)
			{
				spawnStonesStateRef.ValueRW.internalState = 1;
				spawnStonesStateRef.ValueRW.timer.Start(time, valueRO.durationBeforeStartingToSpawnStones);
			}
			else if (valueRO.internalState == 1 && spawnStonesStateRef.ValueRW.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(screechAnimID, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				spawnStonesStateRef.ValueRW.internalState = 2;
				spawnStonesStateRef.ValueRW.timer.Start(time, valueRO.durationUntilStonesSpawn);
			}
			else if (valueRO.internalState == 2 && spawnStonesStateRef.ValueRW.timer.IsTimerElapsed(time))
			{
				float3 float5 = transform.Position + new float3(0.5f, 0f, 0.5f);
				int num = 0;
				NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				if (collisionWorld.SphereCastAll(float5, 15f, float3.zero, 0f, ref outHits, new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1u
				}))
				{
					for (int i = 0; i < outHits.Length; i++)
					{
						Entity entity = outHits[i].Entity;
						if (objectDataLookup.TryGetComponent(entity, out var componentData) && componentData.objectID == ObjectID.BirdBossStone)
						{
							num++;
						}
					}
				}
				outHits.Dispose();
				int num2 = 12;
				if (num < num2)
				{
					int num3 = ((numberOfPlayers <= 2) ? (numberOfPlayers * 3) : (numberOfPlayers * 2));
					if (num3 + num > num2)
					{
						num3 = num2 - num;
					}
					ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(ObjectID.BirdBossStone, databaseBankCD.databaseBankBlob);
					NativeParallelHashSet<int2> nativeParallelHashSet = new NativeParallelHashSet<int2>(num3 * 9, Allocator.Temp);
					int num4 = 3;
					for (int j = 0; j < num3; j++)
					{
						for (int k = 0; k < num4; k++)
						{
							float3 float6 = rng.NextFloat3(-1f, 1f);
							float6.y = 0f;
							math.normalizesafe(float6, new float3(1f, 0f, 0f));
							float3 float7 = math.round(float5 + float6 * rng.NextFloat(3f, math.clamp(8 + nearbyEntities.Length, 8, 16)));
							int2 int5 = float7.RoundToInt2();
							if (nativeParallelHashSet.Contains(int5))
							{
								continue;
							}
							bool flag = true;
							for (int l = entityObjectInfo.prefabCornerOffset.x; l < entityObjectInfo.prefabTileSize.x + entityObjectInfo.prefabCornerOffset.x; l++)
							{
								for (int m = entityObjectInfo.prefabCornerOffset.y; m < entityObjectInfo.prefabTileSize.y + entityObjectInfo.prefabCornerOffset.y; m++)
								{
									float3 position = float7 + new float3(l, 0f, m);
									if (PositionIsBlocked(collisionWorld, position, 0.49f, 131395u))
									{
										flag = false;
										break;
									}
								}
								if (!flag)
								{
									break;
								}
							}
							if (!flag)
							{
								continue;
							}
							EntityUtility.CreateEntity(ecb, float7, ObjectID.BirdBossStone, 1, databaseBankCD.databaseBankBlob);
							for (int n = -1; n < entityObjectInfo.prefabTileSize.x + 1; n++)
							{
								for (int num5 = -1; num5 < entityObjectInfo.prefabTileSize.y + 1; num5++)
								{
									int2 item = int5 + new int2(n, num5);
									if (!nativeParallelHashSet.Contains(item))
									{
										nativeParallelHashSet.Add(item);
									}
								}
							}
							break;
						}
					}
					nativeParallelHashSet.Dispose();
				}
				spawnStonesStateRef.ValueRW.internalState = 3;
				spawnStonesStateRef.ValueRW.timer.Start(time, valueRO.durationAfterStonesSpawn);
			}
			else if (valueRO.internalState == 3 && spawnStonesStateRef.ValueRW.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(idleAnimID, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				spawnStonesStateRef.ValueRW.internalState = 4;
				spawnStonesStateRef.ValueRW.timer.Start(time, valueRO.durationBeforeLeaveStonesSpawnState);
			}
			else if (valueRO.internalState == 4 && spawnStonesStateRef.ValueRW.timer.IsTimerElapsed(time))
			{
				stateInfoRef.ValueRW.LeaveState();
			}
		}

		private static bool PositionIsBlocked(CollisionWorld collisionWorld, float3 position, float radius, uint filter)
		{
			return collisionWorld.SphereCast(position, radius, float3.zero, 0f, new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = filter
			});
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr ptr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BirdBossSpawnStonesStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr ptr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__NearbyEntitiesBufferCD_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					RefRW<StateInfoCD> refRW = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, i);
					RefRW<BirdBossSpawnStonesStateCD> refRW2 = InternalCompilerInterface.GetRefRW<BirdBossSpawnStonesStateCD>(ptr2, i);
					DynamicBuffer<AnimationBuffer> animationRef = bufferAccessor[i];
					RefRW<AnimationBufferPointer> refRW3 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, i);
					ref LocalTransform reference = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i);
					DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities = bufferAccessor2[i];
					Execute(refRW, refRW2, animationRef, refRW3, reference, nearbyEntities);
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
						RefRW<StateInfoCD> refRW4 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, nextRangeBegin);
						RefRW<BirdBossSpawnStonesStateCD> refRW5 = InternalCompilerInterface.GetRefRW<BirdBossSpawnStonesStateCD>(ptr2, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationRef2 = bufferAccessor[nextRangeBegin];
						RefRW<AnimationBufferPointer> refRW6 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, nextRangeBegin);
						ref LocalTransform reference2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin);
						DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities2 = bufferAccessor2[nextRangeBegin];
						Execute(refRW4, refRW5, animationRef2, refRW6, reference2, nearbyEntities2);
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
					RefRW<StateInfoCD> refRW7 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, j);
					RefRW<BirdBossSpawnStonesStateCD> refRW8 = InternalCompilerInterface.GetRefRW<BirdBossSpawnStonesStateCD>(ptr2, j);
					DynamicBuffer<AnimationBuffer> animationRef3 = bufferAccessor[j];
					RefRW<AnimationBufferPointer> refRW9 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, j);
					ref LocalTransform reference3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j);
					DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities3 = bufferAccessor2[j];
					Execute(refRW7, refRW8, animationRef3, refRW9, reference3, nearbyEntities3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					RefRW<StateInfoCD> refRW10 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, k);
					RefRW<BirdBossSpawnStonesStateCD> refRW11 = InternalCompilerInterface.GetRefRW<BirdBossSpawnStonesStateCD>(ptr2, k);
					DynamicBuffer<AnimationBuffer> animationRef4 = bufferAccessor[k];
					RefRW<AnimationBufferPointer> refRW12 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr3, k);
					ref LocalTransform reference4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k);
					DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities4 = bufferAccessor2[k];
					Execute(refRW10, refRW11, animationRef4, refRW12, reference4, nearbyEntities4);
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
	private struct BirdBossStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<BirdBossBeamCD> __BirdBossBeamCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AttackContinuouslyCD> __AttackContinuouslyCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__BirdBossBeamCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BirdBossBeamCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
					__AttackContinuouslyCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AttackContinuouslyCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__BirdBossBeamCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
					__AttackContinuouslyCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<BirdBossBeamCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AttackContinuouslyCD>();
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
			public void Run(ref BirdBossStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BirdBossStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BirdBossStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BirdBossStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BirdBossStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BirdBossStateJob job, EntityManager entityManager)
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
		public ComponentLookup<HealNearbyEntitiesCD> healNearbyEntitiesLookup;

		[ReadOnly]
		public TileAccessor tileAccessor;

		public Entity tileUpdateBufferEntity;

		public Entity tileDamageBufferEntity;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public float deltaTime;

		public double time;

		public int hiddenAnimID;

		public PhysicsCollider beamCollider;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, RefRW<BirdBossBeamCD> beamRef, DynamicBuffer<AnimationBuffer> animationRef, RefRW<AnimationBufferPointer> animationBufferPointer, RefRW<HealthCD> healthRef, LocalTransform transform, RefRW<AttackContinuouslyCD> attackContinuouslyState)
		{
			ref readonly BirdBossBeamCD valueRO = ref beamRef.ValueRO;
			if (beamRef.ValueRW.internalState == 1 && beamRef.ValueRW.timer.GetElapsedTime(time) > beamRef.ValueRO.startDamageDelay)
			{
				attackContinuouslyState.ValueRW.disableDamage = false;
			}
			if (valueRO.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(-1619438193, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				beamRef.ValueRW.internalState = 1;
				beamRef.ValueRW.timer.Start(time, valueRO.startDuration);
				attackContinuouslyState.ValueRW.disableDamage = true;
			}
			else if (valueRO.internalState == 1 && beamRef.ValueRW.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(-1587601938, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				beamRef.ValueRW.internalState = 2;
				beamRef.ValueRW.timer.Start(time, valueRO.loopDuration);
			}
			else if (valueRO.internalState == 2 && beamRef.ValueRW.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(16528305, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				beamRef.ValueRW.internalState = 3;
				beamRef.ValueRW.timer.Start(time, valueRO.endDuration);
				attackContinuouslyState.ValueRW.disableDamage = true;
			}
			else if (valueRO.internalState == 3 && beamRef.ValueRW.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(hiddenAnimID, currentTick, animationRef, ref animationBufferPointer.ValueRW);
				beamRef.ValueRW.internalState = 4;
				beamRef.ValueRW.timer.Start(time, valueRO.hiddenEndDuration);
			}
			else if (valueRO.internalState == 4 && beamRef.ValueRW.timer.IsTimerElapsed(time))
			{
				healthRef.ValueRW.health = 0;
			}
			if (valueRO.internalState != 2)
			{
				return;
			}
			float3 float5 = valueRO.moveDirection * deltaTime * valueRO.moveSpeed;
			if (valueRO.moveSideWays)
			{
				float5 += math.cross(valueRO.moveDirection, new float3(0f, 1f, 0f)) * deltaTime * (1f * beamRef.ValueRW.timer.GetInvElapsedRatio(time));
			}
			LocalTransform component = transform;
			component.Position += float5;
			ecb.SetComponent(entity, component);
			if (!valueRO.dealDamageTimer.isRunning || beamRef.ValueRW.dealDamageTimer.IsTimerElapsed(time))
			{
				float3 position = transform.Position;
				for (int i = -1; i < 1; i++)
				{
					for (int j = -1; j < 1; j++)
					{
						int2 position2 = (position + new float3((float)i * 0.55f, 0f, (float)j * 0.55f)).RoundToInt2();
						ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
						{
							damage = 1000,
							position = position2,
							skipWallAndRootsLootDropOnDestroy = true,
							dontHitBridges = true,
							canHitLowColliders = true
						});
					}
				}
				int2 int5 = position.RoundToInt2();
				if (!tileAccessor.HasTypeAndTileset(int5, TileType.wall, 2))
				{
					ecb.AppendToBuffer(tileUpdateBufferEntity, new TileUpdateBuffer
					{
						command = TileUpdateBuffer.Command.Add,
						position = int5,
						tile = new TileCD
						{
							tileset = 0,
							tileType = TileType.roofHole
						}
					});
				}
			}
			NativeList<ColliderCastHit> allHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			if (collisionWorld.CastCollider(PhysicsManager.GetColliderCastInput(transform.Position, transform.Position, beamCollider), ref allHits))
			{
				foreach (ColliderCastHit item in allHits)
				{
					Entity entity2 = item.Entity;
					if (healNearbyEntitiesLookup.TryGetComponent(entity2, out var componentData) && !componentData.isActive && componentData.healsTargetsOfFaction == FactionID.Bird)
					{
						componentData.isActive = true;
						ecb.SetComponent(entity2, componentData);
					}
				}
			}
			allHits.Dispose();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BirdBossBeamCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr ptr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr ptr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			IntPtr ptr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AttackContinuouslyCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					RefRW<BirdBossBeamCD> refRW = InternalCompilerInterface.GetRefRW<BirdBossBeamCD>(ptr, i);
					DynamicBuffer<AnimationBuffer> animationRef = bufferAccessor[i];
					RefRW<AnimationBufferPointer> refRW2 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr2, i);
					RefRW<HealthCD> refRW3 = InternalCompilerInterface.GetRefRW<HealthCD>(ptr3, i);
					ref LocalTransform reference = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i);
					RefRW<AttackContinuouslyCD> refRW4 = InternalCompilerInterface.GetRefRW<AttackContinuouslyCD>(ptr4, i);
					Execute(entity, refRW, animationRef, refRW2, refRW3, reference, refRW4);
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
						RefRW<BirdBossBeamCD> refRW5 = InternalCompilerInterface.GetRefRW<BirdBossBeamCD>(ptr, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationRef2 = bufferAccessor[nextRangeBegin];
						RefRW<AnimationBufferPointer> refRW6 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr2, nextRangeBegin);
						RefRW<HealthCD> refRW7 = InternalCompilerInterface.GetRefRW<HealthCD>(ptr3, nextRangeBegin);
						ref LocalTransform reference2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin);
						RefRW<AttackContinuouslyCD> refRW8 = InternalCompilerInterface.GetRefRW<AttackContinuouslyCD>(ptr4, nextRangeBegin);
						Execute(entity2, refRW5, animationRef2, refRW6, refRW7, reference2, refRW8);
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
					RefRW<BirdBossBeamCD> refRW9 = InternalCompilerInterface.GetRefRW<BirdBossBeamCD>(ptr, j);
					DynamicBuffer<AnimationBuffer> animationRef3 = bufferAccessor[j];
					RefRW<AnimationBufferPointer> refRW10 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr2, j);
					RefRW<HealthCD> refRW11 = InternalCompilerInterface.GetRefRW<HealthCD>(ptr3, j);
					ref LocalTransform reference3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j);
					RefRW<AttackContinuouslyCD> refRW12 = InternalCompilerInterface.GetRefRW<AttackContinuouslyCD>(ptr4, j);
					Execute(entity3, refRW9, animationRef3, refRW10, refRW11, reference3, refRW12);
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
					RefRW<BirdBossBeamCD> refRW13 = InternalCompilerInterface.GetRefRW<BirdBossBeamCD>(ptr, k);
					DynamicBuffer<AnimationBuffer> animationRef4 = bufferAccessor[k];
					RefRW<AnimationBufferPointer> refRW14 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr2, k);
					RefRW<HealthCD> refRW15 = InternalCompilerInterface.GetRefRW<HealthCD>(ptr3, k);
					ref LocalTransform reference4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k);
					RefRW<AttackContinuouslyCD> refRW16 = InternalCompilerInterface.GetRefRW<AttackContinuouslyCD>(ptr4, k);
					Execute(entity4, refRW13, animationRef4, refRW14, refRW15, reference4, refRW16);
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
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		public BirdBossAppearJob.InternalCompilerQueryAndHandleData __BirdBossSystem_BirdBossAppearJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<ForceInCombatCD> __ForceInCombatCD_RO_ComponentLookup;

		public BirdBossEnterCombatJob.InternalCompilerQueryAndHandleData __BirdBossSystem_BirdBossEnterCombatJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<BossSpawnLocationCD> __BossSpawnLocationCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferLookup;

		public BirdBossFlyingStateJob.InternalCompilerQueryAndHandleData __BirdBossSystem_BirdBossFlyingStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<BirdBossBeamCD> __BirdBossBeamCD_RO_ComponentLookup;

		public BirdBossSpawnBeamsJob.InternalCompilerQueryAndHandleData __BirdBossSystem_BirdBossSpawnBeamsJob_WithDefaultQuery_JobEntityTypeHandle;

		public BirdBossSpawnStonesJob.InternalCompilerQueryAndHandleData __BirdBossSystem_BirdBossSpawnStonesJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<HealNearbyEntitiesCD> __HealNearbyEntitiesCD_RO_ComponentLookup;

		public BirdBossStateJob.InternalCompilerQueryAndHandleData __BirdBossSystem_BirdBossStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__BirdBossSystem_BirdBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ForceInCombatCD_RO_ComponentLookup = state.GetComponentLookup<ForceInCombatCD>(isReadOnly: true);
			__BirdBossSystem_BirdBossEnterCombatJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__BossSpawnLocationCD_RO_ComponentLookup = state.GetComponentLookup<BossSpawnLocationCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__NearbyEntitiesBufferCD_RO_BufferLookup = state.GetBufferLookup<NearbyEntitiesBufferCD>(isReadOnly: true);
			__BirdBossSystem_BirdBossFlyingStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__BirdBossBeamCD_RO_ComponentLookup = state.GetComponentLookup<BirdBossBeamCD>(isReadOnly: true);
			__BirdBossSystem_BirdBossSpawnBeamsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__BirdBossSystem_BirdBossSpawnStonesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__HealNearbyEntitiesCD_RO_ComponentLookup = state.GetComponentLookup<HealNearbyEntitiesCD>(isReadOnly: true);
			__BirdBossSystem_BirdBossStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000568_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000568_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000568_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000569_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000569_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000569_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_0000056A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_0000056A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000056A_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_0000056B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_0000056B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_0000056B_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private const float BEAM_MAX_SPAWN_SQR_DISTANCE_FROM_BIRD = 900f;

	private PhysicsCollider _beamCollider;

	private TileAccessor _tileAccessor;

	private int _startAnimID;

	private int _loopAnimID;

	private int _endAnimID;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1057056156_0;

	private EntityQuery __query_1057056156_1;

	private EntityQuery __query_1057056156_2;

	private EntityQuery __query_1057056156_3;

	private EntityQuery __query_1057056156_4;

	private EntityQuery __query_1057056156_5;

	private EntityQuery __query_1057056156_6;

	private EntityQuery __query_1057056156_7;

	private EntityQuery __query_1057056156_8;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<TileUpdateBuffer>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<ColliderCacheCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
		ColliderCacheCD singleton = __query_1057056156_2.GetSingleton<ColliderCacheCD>();
		_beamCollider = PhysicsManager.GetSphereCollider(float3.zero, 0.5f, 1u, singleton);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_1057056156_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		int numberOfPlayers = math.max(1, __query_1057056156_0.CalculateEntityCountWithoutFiltering());
		_tileAccessor.Update(ref state);
		CollisionWorld collisionWorld = __query_1057056156_4.GetSingleton<PhysicsWorldSingleton>().CollisionWorld;
		__query_1057056156_5.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		state.Dependency = __ScheduleViaJobChunkExtension_0(new BirdBossAppearJob
		{
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			ecb = ecb,
			currentTick = serverTick,
			time = elapsedTime
		}, __TypeHandle.__BirdBossSystem_BirdBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		int hiddenAnimID = -2007111235;
		state.Dependency = __ScheduleViaJobChunkExtension_1(new BirdBossEnterCombatJob
		{
			forceInCombatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ForceInCombatCD_RO_ComponentLookup, ref state),
			ecb = ecb
		}, __TypeHandle.__BirdBossSystem_BirdBossEnterCombatJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		EntityQuery _query_1057056156_ = __query_1057056156_1;
		JobHandle outJobHandle;
		NativeList<Entity> spawnLocationEntities = _query_1057056156_.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
		JobHandle dependency = JobHandle.CombineDependencies(state.Dependency, outJobHandle);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new BirdBossFlyingStateJob
		{
			bossSpawnLocationLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossSpawnLocationCD_RO_ComponentLookup, ref state),
			objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			trackedEntitiesBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferLookup, ref state),
			spawnLocationEntities = spawnLocationEntities,
			ecb = ecb,
			currentTick = serverTick,
			time = elapsedTime,
			hiddenAnimID = hiddenAnimID,
			rng = PugRandom.GetRng()
		}, __TypeHandle.__BirdBossSystem_BirdBossFlyingStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, dependency, ref state, hasUserDefinedQuery: false);
		int screechAnimID = 46335079;
		int idleAnimID = -601574123;
		state.Dependency = __ScheduleViaJobChunkExtension_3(new BirdBossSpawnBeamsJob
		{
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			birdBossBeamLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BirdBossBeamCD_RO_ComponentLookup, ref state),
			databaseBankCD = __query_1057056156_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb,
			currentTick = serverTick,
			time = elapsedTime,
			rng = PugRandom.GetRng(),
			screechAnimID = screechAnimID,
			idleAnimID = idleAnimID
		}, __TypeHandle.__BirdBossSystem_BirdBossSpawnBeamsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_4(new BirdBossSpawnStonesJob
		{
			objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			numberOfPlayers = numberOfPlayers,
			collisionWorld = collisionWorld,
			databaseBankCD = __query_1057056156_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb,
			currentTick = serverTick,
			time = elapsedTime,
			rng = PugRandom.GetRng(),
			screechAnimID = screechAnimID,
			idleAnimID = idleAnimID
		}, __TypeHandle.__BirdBossSystem_BirdBossSpawnStonesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_5(new BirdBossStateJob
		{
			healNearbyEntitiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealNearbyEntitiesCD_RO_ComponentLookup, ref state),
			tileAccessor = _tileAccessor,
			tileUpdateBufferEntity = __query_1057056156_7.GetSingletonEntity(),
			tileDamageBufferEntity = __query_1057056156_8.GetSingletonEntity(),
			collisionWorld = collisionWorld,
			ecb = ecb,
			currentTick = serverTick,
			deltaTime = deltaTime,
			time = elapsedTime,
			hiddenAnimID = hiddenAnimID,
			beamCollider = _beamCollider
		}, __TypeHandle.__BirdBossSystem_BirdBossStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(BirdBossAppearJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__BirdBossSystem_BirdBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__BirdBossSystem_BirdBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__BirdBossSystem_BirdBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__BirdBossSystem_BirdBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(BirdBossEnterCombatJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__BirdBossSystem_BirdBossEnterCombatJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__BirdBossSystem_BirdBossEnterCombatJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__BirdBossSystem_BirdBossEnterCombatJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__BirdBossSystem_BirdBossEnterCombatJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(BirdBossFlyingStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__BirdBossSystem_BirdBossFlyingStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__BirdBossSystem_BirdBossFlyingStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__BirdBossSystem_BirdBossFlyingStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__BirdBossSystem_BirdBossFlyingStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(BirdBossSpawnBeamsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__BirdBossSystem_BirdBossSpawnBeamsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__BirdBossSystem_BirdBossSpawnBeamsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__BirdBossSystem_BirdBossSpawnBeamsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__BirdBossSystem_BirdBossSpawnBeamsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(BirdBossSpawnStonesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__BirdBossSystem_BirdBossSpawnStonesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__BirdBossSystem_BirdBossSpawnStonesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__BirdBossSystem_BirdBossSpawnStonesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__BirdBossSystem_BirdBossSpawnStonesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_5(BirdBossStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__BirdBossSystem_BirdBossStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__BirdBossSystem_BirdBossStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__BirdBossSystem_BirdBossStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__BirdBossSystem_BirdBossStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		__query_1057056156_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BossSpawnLocationCD>();
		__query_1057056156_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ColliderCacheCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1057056156_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1057056156_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1057056156_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1057056156_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1057056156_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1057056156_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1057056156_8 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000568_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000569_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_0000056A_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_0000056B_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((BirdBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BirdBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BirdBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BirdBossSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BirdBossSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
