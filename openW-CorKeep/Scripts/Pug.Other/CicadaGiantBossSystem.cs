using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
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
using UnityEngine;

[BurstCompile]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct CicadaGiantBossSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	private static class GiantCicadaAttackPoints
	{
		public static readonly float3 ArmSlamLeftFar = new float3(-7f, 0f, -6f);

		public static readonly float3 ArmSlamLeft = new float3(-4.3f, 0f, -4f);

		public static readonly float3 ArmSlamMiddleClose = new float3(0f, 0f, -3f);

		public static readonly float3 ArmSlamRight = new float3(4.3f, 0f, -4f);

		public static readonly float3 ArmSlamRightFar = new float3(7f, 0f, -6f);

		public static readonly float3 ArmSlamMiddleFar = new float3(0f, 0f, -6.5f);
	}

	private static class GiantCicadaTimeUntilImpact
	{
		public static readonly float ArmSlamLeftFar = 1.3f;

		public static readonly float ArmSlamRightFar = 1.3f;

		public static readonly float ArmSlamMiddleClose = 1.3f;

		public static readonly float ArmSlamRight = 1.3f;

		public static readonly float ArmSlamLeft = 1.3f;

		public static readonly float ArmSlamMiddleFar = 1.3f;
	}

	private static class GiantCicadaAttackRadius
	{
		public static readonly float ArmSlamLeftFar = 3f;

		public static readonly float ArmSlamRightFar = 3f;

		public static readonly float ArmSlamMiddleClose = 3f;

		public static readonly float ArmSlamRight = 3f;

		public static readonly float ArmSlamLeft = 3f;

		public static readonly float ArmSlamMiddleFar = 3f;
	}

	[BurstCompile]
	[WithAll(new Type[] { typeof(GiantCicadaBossCD) })]
	[WithDisabled(new Type[] { typeof(EntityDestroyedCD) })]
	private struct GiantCicadaBossAppearJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GiantCicadaBossAppearStateCD> __GiantCicadaBossAppearStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GiantCicadaBossHasAppearedCD> __GiantCicadaBossHasAppearedCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GiantCicadaSlamArmsStateCD> __GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GiantCicadaBossCD> __GiantCicadaBossCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__GiantCicadaBossAppearStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaBossAppearStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__GiantCicadaBossHasAppearedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaBossHasAppearedCD>();
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
					__GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaSlamArmsStateCD>();
					__GiantCicadaBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaBossCD>();
				}

				public void Update(ref SystemState state)
				{
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__GiantCicadaBossAppearStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__GiantCicadaBossHasAppearedCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
					__GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle.Update(ref state);
					__GiantCicadaBossCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GiantCicadaBossAppearStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GiantCicadaBossHasAppearedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GiantCicadaSlamArmsStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GiantCicadaBossCD>();
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
			public void Run(ref GiantCicadaBossAppearJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref GiantCicadaBossAppearJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref GiantCicadaBossAppearJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref GiantCicadaBossAppearJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref GiantCicadaBossAppearJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref GiantCicadaBossAppearJob job, EntityManager entityManager)
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

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public double time;

		public Entity tileDamageBufferEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref StateInfoCD stateInfo, ref GiantCicadaBossAppearStateCD appearStateRef, DynamicBuffer<AnimationBuffer> animationRef, RefRW<AnimationBufferPointer> animationBufferPointer, ref GiantCicadaBossHasAppearedCD hasAppearedRef, LocalTransform transform, ref GiantCicadaSlamArmsStateCD armSlamState, ref GiantCicadaBossCD giantCicada)
		{
			if (appearStateRef.internalState == 3)
			{
				appearStateRef.internalState = 4;
				hasAppearedRef.Value = true;
				giantCicada.voidAttackCooldownTimer.Start(time, 30f);
			}
			if (stateInfo.IsCurrentState(StateID.GiantCicadaBossAppear))
			{
				if (appearStateRef.internalState == 1)
				{
					giantCicada.internalState = GiantCicadaBossInternalState.Immune;
					AnimationUtilities.TriggerAnimation(-1878077465, currentTick, animationRef, ref animationBufferPointer.ValueRW);
					appearStateRef.internalState = 2;
					appearStateRef.timer.Start(time, appearStateRef.appearDuration);
					HydraBossSystem.DestroyTilesWithinRadius(4f, transform.Position + new float3(0f, 0f, 3f), ecb, tileDamageBufferEntity);
				}
				else if (appearStateRef.timer.IsTimerElapsed(time) && appearStateRef.internalState == 2)
				{
					appearStateRef.internalState = 3;
					stateInfo.LeaveState();
					giantCicada.internalState = GiantCicadaBossInternalState.Vulnerable;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GiantCicadaBossAppearStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GiantCicadaBossHasAppearedCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GiantCicadaBossCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref StateInfoCD stateInfo = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, i);
					ref GiantCicadaBossAppearStateCD appearStateRef = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossAppearStateCD>(nativeArrayPtr2, i);
					DynamicBuffer<AnimationBuffer> animationRef = bufferAccessor[i];
					RefRW<AnimationBufferPointer> refRW = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr, i);
					ref GiantCicadaBossHasAppearedCD hasAppearedRef = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr3, i);
					ref LocalTransform reference = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i);
					ref GiantCicadaSlamArmsStateCD armSlamState = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr5, i);
					ref GiantCicadaBossCD giantCicada = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr6, i);
					Execute(ref stateInfo, ref appearStateRef, animationRef, refRW, ref hasAppearedRef, reference, ref armSlamState, ref giantCicada);
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
						ref StateInfoCD stateInfo2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, nextRangeBegin);
						ref GiantCicadaBossAppearStateCD appearStateRef2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossAppearStateCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationRef2 = bufferAccessor[nextRangeBegin];
						RefRW<AnimationBufferPointer> refRW2 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr, nextRangeBegin);
						ref GiantCicadaBossHasAppearedCD hasAppearedRef2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr3, nextRangeBegin);
						ref LocalTransform reference2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, nextRangeBegin);
						ref GiantCicadaSlamArmsStateCD armSlamState2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr5, nextRangeBegin);
						ref GiantCicadaBossCD giantCicada2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr6, nextRangeBegin);
						Execute(ref stateInfo2, ref appearStateRef2, animationRef2, refRW2, ref hasAppearedRef2, reference2, ref armSlamState2, ref giantCicada2);
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
					ref StateInfoCD stateInfo3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, j);
					ref GiantCicadaBossAppearStateCD appearStateRef3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossAppearStateCD>(nativeArrayPtr2, j);
					DynamicBuffer<AnimationBuffer> animationRef3 = bufferAccessor[j];
					RefRW<AnimationBufferPointer> refRW3 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr, j);
					ref GiantCicadaBossHasAppearedCD hasAppearedRef3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr3, j);
					ref LocalTransform reference3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j);
					ref GiantCicadaSlamArmsStateCD armSlamState3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr5, j);
					ref GiantCicadaBossCD giantCicada3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr6, j);
					Execute(ref stateInfo3, ref appearStateRef3, animationRef3, refRW3, ref hasAppearedRef3, reference3, ref armSlamState3, ref giantCicada3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					ref StateInfoCD stateInfo4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, k);
					ref GiantCicadaBossAppearStateCD appearStateRef4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossAppearStateCD>(nativeArrayPtr2, k);
					DynamicBuffer<AnimationBuffer> animationRef4 = bufferAccessor[k];
					RefRW<AnimationBufferPointer> refRW4 = InternalCompilerInterface.GetRefRW<AnimationBufferPointer>(ptr, k);
					ref GiantCicadaBossHasAppearedCD hasAppearedRef4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr3, k);
					ref LocalTransform reference4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k);
					ref GiantCicadaSlamArmsStateCD armSlamState4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr5, k);
					ref GiantCicadaBossCD giantCicada4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr6, k);
					Execute(ref stateInfo4, ref appearStateRef4, animationRef4, refRW4, ref hasAppearedRef4, reference4, ref armSlamState4, ref giantCicada4);
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
	[WithAll(new Type[]
	{
		typeof(BehaviourTagsCD),
		typeof(AnimationBuffer),
		typeof(AnimationBufferPointer),
		typeof(LocalTransform),
		typeof(GiantCicadaBossCD)
	})]
	[WithDisabled(new Type[] { typeof(EntityDestroyedCD) })]
	private struct GiantCicadaSlamArmsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GiantCicadaSlamArmsStateCD> __GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GiantCicadaBossCD> __GiantCicadaBossCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EnemyStagesStateCD> __EnemyStagesStateCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<CoreBossVoidImmuneZoneBuffer> __CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle;

				public ComponentTypeHandle<CoreBossSpawnVoidStateCD> __CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaSlamArmsStateCD>();
					__GiantCicadaBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaBossCD>();
					__EnemyStagesStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EnemyStagesStateCD>(isReadOnly: true);
					__CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<CoreBossVoidImmuneZoneBuffer>(isReadOnly: true);
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossSpawnVoidStateCD>();
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle.Update(ref state);
					__GiantCicadaBossCD_RW_ComponentTypeHandle.Update(ref state);
					__EnemyStagesStateCD_RO_ComponentTypeHandle.Update(ref state);
					__CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle.Update(ref state);
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnemyStagesStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CoreBossVoidImmuneZoneBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GiantCicadaSlamArmsStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GiantCicadaBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossSpawnVoidStateCD>();
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
			public void Run(ref GiantCicadaSlamArmsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref GiantCicadaSlamArmsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref GiantCicadaSlamArmsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref GiantCicadaSlamArmsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref GiantCicadaSlamArmsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref GiantCicadaSlamArmsJob job, EntityManager entityManager)
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

		private const float NEARBY_NYMPHS_CHECK_RANGE = 500f;

		public AttackSystem.Helper attackHelper;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public ComponentLookup<ShootMortarProjectileStateCD> shootMortarStateLookup;

		public ComponentLookup<ChargeAttackStateCD> chargeAttackStateLookup;

		public Unity.Mathematics.Random rng;

		public Entity tileDamageBufferEntity;

		public Entity effectEventBufferSingleton;

		public EntityCommandBuffer ecb;

		public double time;

		public NativeList<Entity> nymphsArray;

		public NativeList<Entity> cicadasArray;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(in Entity entity, ref StateInfoCD stateInfo, ref GiantCicadaSlamArmsStateCD armSlamState, ref GiantCicadaBossCD giantCicada, in EnemyStagesStateCD enemyStagesState, in DynamicBuffer<CoreBossVoidImmuneZoneBuffer> immunityZones, ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD, in DynamicBuffer<SummarizedConditionsBuffer> conditions)
		{
			if (!stateInfo.IsCurrentState(StateID.GiantCicadaBossSlamArms))
			{
				return;
			}
			BehaviourTagsCD attackTags = attackHelper.behaviourTagsLookup[entity];
			DynamicBuffer<AnimationBuffer> animationBuffer = attackHelper.animationBufferLookup[entity];
			ref LocalTransform valueRW = ref attackHelper.localTransformLookup.GetRefRW(entity).ValueRW;
			ref AnimationBufferPointer valueRW2 = ref attackHelper.animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			if (armSlamState.internalState == ArmSlamInternalState.PlayersAbove && armSlamState.animationStageTimer.IsTimerElapsed(time) && giantCicada.voidAttackCooldownTimer.GetRemainingTime(time) < 12f && conditions[248].value == 0)
			{
				giantCicada.voidAttackCooldownTimer.Start(time, 30f);
				coreBossSpawnVoidStateCD.voidZoneType = VoidZoneType.AttackAreas;
				coreBossSpawnVoidStateCD.cooldownTimer.Start(time, 0.2f);
				coreBossSpawnVoidStateCD.isDisabled = false;
				armSlamState.animationStageTimer.Start(time, 3f);
				AnimationUtilities.TriggerAnimation(573175182, attackHelper.currentTick, animationBuffer, ref valueRW2);
				stateInfo.LeaveState();
				armSlamState.internalState = ArmSlamInternalState.PlayersAboveTriggered;
			}
			if (armSlamState.internalState == ArmSlamInternalState.PlayersTooFarAway && armSlamState.animationStageTimer.IsTimerElapsed(time))
			{
				armSlamState.playerFarAwayCounter++;
				giantCicada.internalState = GiantCicadaBossInternalState.Immune;
				stateInfo.LeaveState();
				armSlamState.internalState = ArmSlamInternalState.PlayersTooFarAwayTriggered;
				if (armSlamState.playerFarAwayCounter >= 3)
				{
					armSlamState.playerFarAwayCounter = 0;
					int num = 0;
					foreach (Entity item in nymphsArray)
					{
						if (math.distancesq(valueRW.Position, attackHelper.localTransformLookup[item].Position) <= 500f)
						{
							num++;
						}
					}
					SpawnNymphs(ecb, valueRW.Position, databaseBankCD.databaseBankBlob, rng, num);
					AnimationUtilities.TriggerAnimation(573175182, attackHelper.currentTick, animationBuffer, ref valueRW2);
					armSlamState.animationStageTimer.Start(time, 4f);
				}
				else
				{
					AnimationUtilities.TriggerAnimation(80170468, attackHelper.currentTick, animationBuffer, ref valueRW2);
					armSlamState.animationStageTimer.Start(time, 2f);
				}
			}
			if (armSlamState.internalState == ArmSlamInternalState.Start && armSlamState.animationStageTimer.IsTimerElapsed(time))
			{
				armSlamState.playerFarAwayCounter = 0;
				armSlamState.armSlamCounter++;
				armSlamState.internalState = ArmSlamInternalState.Anticipate;
				armSlamState.animationStageTimer.Start(time, armSlamState.armSlamAnticipation * enemyStagesState.GetMultiplierDecreasingAsHealthDecreases());
				giantCicada.internalState = GiantCicadaBossInternalState.Vulnerable;
			}
			else if (armSlamState.internalState == ArmSlamInternalState.Anticipate && armSlamState.animationStageTimer.IsTimerElapsed(time))
			{
				armSlamState.internalState = ArmSlamInternalState.AnimationStarted;
				AnimationUtilities.TriggerAnimation(GetAnimationID(armSlamState.armSlamType), attackHelper.currentTick, animationBuffer, ref valueRW2);
				float animationTimeUntilImpact = GetAnimationTimeUntilImpact(armSlamState.armSlamType);
				armSlamState.animationStageTimer.Start(time, animationTimeUntilImpact * enemyStagesState.GetMultiplierDecreasingAsHealthDecreases());
			}
			else if (armSlamState.internalState == ArmSlamInternalState.AnimationStarted && armSlamState.animationStageTimer.IsTimerElapsed(time))
			{
				armSlamState.internalState = ArmSlamInternalState.AnimationImpact;
				float3 attackPosition = GetAttackPosition(armSlamState.armSlamType);
				AttackHitTheGround(entity, attackTags, valueRW, armSlamState, attackPosition);
				float animationTimeUntilImpact2 = GetAnimationTimeUntilImpact(armSlamState.armSlamType);
				armSlamState.animationStageTimer.Start(time, (armSlamState.armSlamAnimationDuration - animationTimeUntilImpact2) * enemyStagesState.GetMultiplierDecreasingAsHealthDecreases());
				if (armSlamState.armSlamCounter % 2 == 0)
				{
					foreach (Entity item2 in cicadasArray)
					{
						SnakeMovementStateCD component = attackHelper.snakeMovementStateLookup[item2];
						if (component.isDisabled)
						{
							component.isDisabled = false;
							ecb.SetComponent(item2, component);
							ShootMortarProjectileStateCD component2 = shootMortarStateLookup[item2];
							component2.minCooldown = 8f;
							component2.maxCooldown = 14f;
							ecb.SetComponent(item2, component2);
							break;
						}
					}
				}
				if (armSlamState.armSlamCounter % 4 != 3 || !armSlamState.spawnNymphsTimer.IsTimerElapsed(time))
				{
					return;
				}
				if (enemyStagesState.currentStage == enemyStagesState.maxStages - 1 && armSlamState.armSlamCounter == 7)
				{
					SpawnCicadas(ecb, valueRW.Position, databaseBankCD.databaseBankBlob, attackHelper.snakeMovementStateLookup, shootMortarStateLookup, chargeAttackStateLookup, time);
					return;
				}
				int num2 = 0;
				foreach (Entity item3 in nymphsArray)
				{
					if (math.distancesq(valueRW.Position, attackHelper.localTransformLookup[item3].Position) <= 500f)
					{
						num2++;
					}
				}
				SpawnNymphs(ecb, valueRW.Position, databaseBankCD.databaseBankBlob, rng, num2);
			}
			else if (armSlamState.internalState == ArmSlamInternalState.AnimationImpact && armSlamState.animationStageTimer.IsTimerElapsed(time))
			{
				armSlamState.internalState = ArmSlamInternalState.AnimationEnd;
				armSlamState.animationStageTimer.Start(time, 0.3f);
			}
			else
			{
				if (armSlamState.internalState != ArmSlamInternalState.AnimationEnd || !armSlamState.animationStageTimer.IsTimerElapsed(time))
				{
					return;
				}
				armSlamState.internalState = ArmSlamInternalState.Start;
				armSlamState.animationStageTimer.Stop();
				stateInfo.LeaveState();
				if (enemyStagesState.currentStage <= 2 && armSlamState.armSlamCounter % 8 == 0 && coreBossSpawnVoidStateCD.isDisabled && giantCicada.voidAttackCooldownTimer.IsTimerElapsed(time) && conditions[248].value == 0)
				{
					giantCicada.voidAttackCooldownTimer.Start(time, 30f);
					if (rng.NextFloat() > 0.35f)
					{
						coreBossSpawnVoidStateCD.voidZoneType = VoidZoneType.AttackAreas;
					}
					else
					{
						coreBossSpawnVoidStateCD.voidZoneType = VoidZoneType.MovingCircle;
					}
					coreBossSpawnVoidStateCD.cooldownTimer.Start(time, 0f);
					coreBossSpawnVoidStateCD.isDisabled = false;
					armSlamState.spawnNymphsTimer.Start(time, coreBossSpawnVoidStateCD.duration);
				}
			}
		}

		private void AttackHitTheGround(Entity entity, BehaviourTagsCD attackTags, LocalTransform transform, GiantCicadaSlamArmsStateCD armSlamState, float3 localOffset)
		{
			float attackRadius = GetAttackRadius(armSlamState.armSlamType);
			AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
			{
				effectEventBufferSingleton = effectEventBufferSingleton,
				attacker = entity,
				isRanged = false,
				attackOffset = localOffset,
				canHitLowTriggers = true,
				radius = attackRadius,
				damage = armSlamState.armSlamDamage,
				playerDamage = armSlamState.armSlamDamage,
				pushback = -3f,
				bypassMaxDamagePerHit = true,
				skipWallAndRootsLootDropOnDestroy = true,
				skipLootDropOnDestroy = false,
				behaviourTags = attackTags,
				attackTime = 0.2f,
				treatDodgeAsHit = true
			};
			attackHelper.Attack(ecb, in p);
			HydraBossSystem.DestroyTilesWithinRadius(4f, transform.Position + localOffset, ecb, tileDamageBufferEntity);
		}

		[BurstDiscard]
		[Conditional("UNITY_EDITOR")]
		private void DrawDebugSlamMarker(LocalTransform transform, float3 attackPoint, float attackRadius)
		{
			float3 float5 = transform.Position.ToRender() + attackPoint;
			float3 float6 = float5 + new float3(attackRadius, 0f, 0f);
			UnityEngine.Debug.DrawLine(float5, float6, Color.red, 0.6f);
			UnityEngine.Debug.DrawLine(float5 + new float3(0f, 0f, attackRadius), float5 - new float3(0f, 0f, attackRadius), Color.red, 0.6f);
			UnityEngine.Debug.DrawLine(float5 + new float3(attackRadius, 0f, 0f), float5 - new float3(attackRadius, 0f, 0f), Color.red, 0.6f);
		}

		private float3 GetAttackPosition(GiantCicadaMeleeAttacks armSlamType)
		{
			return armSlamType switch
			{
				GiantCicadaMeleeAttacks.ArmSlamLeftFar => GiantCicadaAttackPoints.ArmSlamLeftFar, 
				GiantCicadaMeleeAttacks.ArmSlamLeft => GiantCicadaAttackPoints.ArmSlamLeft, 
				GiantCicadaMeleeAttacks.ArmSlamMiddleClose => GiantCicadaAttackPoints.ArmSlamMiddleClose, 
				GiantCicadaMeleeAttacks.ArmSlamRight => GiantCicadaAttackPoints.ArmSlamRight, 
				GiantCicadaMeleeAttacks.ArmSlamRightFar => GiantCicadaAttackPoints.ArmSlamRightFar, 
				GiantCicadaMeleeAttacks.ArmSlamMiddleFar => GiantCicadaAttackPoints.ArmSlamMiddleFar, 
				_ => new float3(0f, 0f, 0f), 
			};
		}

		private int GetAnimationID(GiantCicadaMeleeAttacks armSlamType)
		{
			return armSlamType switch
			{
				GiantCicadaMeleeAttacks.ArmSlamLeftFar => -55886041, 
				GiantCicadaMeleeAttacks.ArmSlamLeft => -290922184, 
				GiantCicadaMeleeAttacks.ArmSlamMiddleClose => 1203776827, 
				GiantCicadaMeleeAttacks.ArmSlamRight => -550114330, 
				GiantCicadaMeleeAttacks.ArmSlamRightFar => 267198559, 
				GiantCicadaMeleeAttacks.ArmSlamMiddleFar => -624168705, 
				_ => 1203776827, 
			};
		}

		private float GetAttackRadius(GiantCicadaMeleeAttacks armSlamType)
		{
			return armSlamType switch
			{
				GiantCicadaMeleeAttacks.ArmSlamLeftFar => GiantCicadaAttackRadius.ArmSlamLeftFar, 
				GiantCicadaMeleeAttacks.ArmSlamLeft => GiantCicadaAttackRadius.ArmSlamLeft, 
				GiantCicadaMeleeAttacks.ArmSlamMiddleClose => GiantCicadaAttackRadius.ArmSlamMiddleClose, 
				GiantCicadaMeleeAttacks.ArmSlamRight => GiantCicadaAttackRadius.ArmSlamRight, 
				GiantCicadaMeleeAttacks.ArmSlamRightFar => GiantCicadaAttackRadius.ArmSlamRightFar, 
				GiantCicadaMeleeAttacks.ArmSlamMiddleFar => GiantCicadaAttackRadius.ArmSlamMiddleFar, 
				_ => 4f, 
			};
		}

		private float GetAnimationTimeUntilImpact(GiantCicadaMeleeAttacks armSlamType)
		{
			return armSlamType switch
			{
				GiantCicadaMeleeAttacks.ArmSlamLeftFar => GiantCicadaTimeUntilImpact.ArmSlamLeftFar, 
				GiantCicadaMeleeAttacks.ArmSlamLeft => GiantCicadaTimeUntilImpact.ArmSlamLeft, 
				GiantCicadaMeleeAttacks.ArmSlamMiddleClose => GiantCicadaTimeUntilImpact.ArmSlamMiddleClose, 
				GiantCicadaMeleeAttacks.ArmSlamRight => GiantCicadaTimeUntilImpact.ArmSlamRight, 
				GiantCicadaMeleeAttacks.ArmSlamRightFar => GiantCicadaTimeUntilImpact.ArmSlamRightFar, 
				GiantCicadaMeleeAttacks.ArmSlamMiddleFar => GiantCicadaTimeUntilImpact.ArmSlamMiddleFar, 
				_ => 3f, 
			};
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GiantCicadaBossCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EnemyStagesStateCD_RO_ComponentTypeHandle);
			BufferAccessor<CoreBossVoidImmuneZoneBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyStagesStateCD>(nativeArrayPtr5, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr6, i), bufferAccessor2[i]);
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
						Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyStagesStateCD>(nativeArrayPtr5, nextRangeBegin), bufferAccessor[nextRangeBegin], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr6, nextRangeBegin), bufferAccessor2[nextRangeBegin]);
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
					Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyStagesStateCD>(nativeArrayPtr5, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr6, j), bufferAccessor2[j]);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyStagesStateCD>(nativeArrayPtr5, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr6, k), bufferAccessor2[k]);
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
	[WithAll(new Type[] { typeof(GiantCicadaBossCD) })]
	[WithDisabled(new Type[] { typeof(EntityDestroyedCD) })]
	private struct GiantCicadaBossHandleWeakSpotJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GiantCicadaBossCD> __GiantCicadaBossCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GiantCicadaBossHasAppearedCD> __GiantCicadaBossHasAppearedCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__GiantCicadaBossCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaBossCD>(isReadOnly: true);
					__GiantCicadaBossHasAppearedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaBossHasAppearedCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__GiantCicadaBossCD_RO_ComponentTypeHandle.Update(ref state);
					__GiantCicadaBossHasAppearedCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<GiantCicadaBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<GiantCicadaBossHasAppearedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
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
			public void Run(ref GiantCicadaBossHandleWeakSpotJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref GiantCicadaBossHandleWeakSpotJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref GiantCicadaBossHandleWeakSpotJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref GiantCicadaBossHandleWeakSpotJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref GiantCicadaBossHandleWeakSpotJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref GiantCicadaBossHandleWeakSpotJob job, EntityManager entityManager)
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

		public ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(in Entity entity, in GiantCicadaBossCD giantCicadaRef, in GiantCicadaBossHasAppearedCD hasAppearedRef, in LocalTransform transform)
		{
			if (!hasAppearedRef.Value)
			{
				return;
			}
			if (giantCicadaRef.weakSpotEntity == Entity.Null)
			{
				Entity entity2 = EntityUtility.CreateEntity(ecb, ObjectID.GiantCicadaBossShield, 1, databaseBankCD.databaseBankBlob);
				float3 position = transform.Position + new float3(0f, 0f, 0f);
				ecb.SetComponent(entity2, LocalTransform.FromPosition(position));
				ecb.SetComponent(entity2, new EntityPartCD
				{
					mainEntity = entity,
					showHitFeedbackOnThisPart = false,
					handleImmuneToDamageOnThisPart = true
				});
				ecb.AppendToBuffer(entity, (LinkedEntityGroup)entity2);
				ecb.SetComponent(entity, new GiantCicadaBossCD
				{
					weakSpotEntity = entity2
				});
			}
			else if (!(giantCicadaRef.weakSpotEntity == Entity.Null))
			{
				ImmuneToDamageCD componentData;
				bool flag = !immuneToDamageLookup.TryGetComponent(giantCicadaRef.weakSpotEntity, out componentData) || componentData.Value == ImmuneToDamageState.Vulnerable;
				ImmuneToDamageState immuneToDamageState = giantCicadaRef.internalState switch
				{
					GiantCicadaBossInternalState.Vulnerable => ImmuneToDamageState.Vulnerable, 
					GiantCicadaBossInternalState.Immune => ImmuneToDamageState.Immune, 
					_ => componentData.Value, 
				};
				if (!(immuneToDamageState == ImmuneToDamageState.Vulnerable && flag) && (immuneToDamageState != ImmuneToDamageState.Immune || flag))
				{
					componentData.Value = immuneToDamageState;
					ecb.SetComponent(giantCicadaRef.weakSpotEntity, componentData);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__GiantCicadaBossCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__GiantCicadaBossHasAppearedCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i));
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
						Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, nextRangeBegin));
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
					Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k));
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
	[WithAll(new Type[] { typeof(GiantCicadaBossCD) })]
	[WithDisabled(new Type[] { typeof(EntityDestroyedCD) })]
	private struct GiantCicadaStagesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<GiantCicadaBossCD> __GiantCicadaBossCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GiantCicadaBossHasAppearedCD> __GiantCicadaBossHasAppearedCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EnemyStagesStateCD> __EnemyStagesStateCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<CoreBossSpawnVoidStateCD> __CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GiantCicadaSlamArmsStateCD> __GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
					__GiantCicadaBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaBossCD>();
					__GiantCicadaBossHasAppearedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaBossHasAppearedCD>(isReadOnly: true);
					__EnemyStagesStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EnemyStagesStateCD>(isReadOnly: true);
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossSpawnVoidStateCD>();
					__GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GiantCicadaSlamArmsStateCD>();
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
					__GiantCicadaBossCD_RW_ComponentTypeHandle.Update(ref state);
					__GiantCicadaBossHasAppearedCD_RO_ComponentTypeHandle.Update(ref state);
					__EnemyStagesStateCD_RO_ComponentTypeHandle.Update(ref state);
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle.Update(ref state);
					__GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<GiantCicadaBossHasAppearedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnemyStagesStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GiantCicadaBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossSpawnVoidStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GiantCicadaSlamArmsStateCD>();
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
			public void Run(ref GiantCicadaStagesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref GiantCicadaStagesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref GiantCicadaStagesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref GiantCicadaStagesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref GiantCicadaStagesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref GiantCicadaStagesJob job, EntityManager entityManager)
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

		public ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup;

		public ComponentLookup<ShootMortarProjectileStateCD> shootMortarStateLookup;

		public ComponentLookup<ChargeAttackStateCD> chargeAttackStateLookup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(in Entity entity, in StateInfoCD stateInfo, ref GiantCicadaBossCD giantCicadaRef, in GiantCicadaBossHasAppearedCD hasAppearedRef, in EnemyStagesStateCD enemyStagesState, ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD, ref GiantCicadaSlamArmsStateCD armSlamState, in DynamicBuffer<SummarizedConditionsBuffer> conditions)
		{
			if (!hasAppearedRef.Value)
			{
				return;
			}
			if (!stateInfo.IsCurrentState(StateID.StageTransition))
			{
				giantCicadaRef.shouldSpawnGuardsNow = true;
			}
			else if (giantCicadaRef.shouldSpawnGuardsNow)
			{
				giantCicadaRef.shouldSpawnGuardsNow = false;
				giantCicadaRef.internalState = GiantCicadaBossInternalState.Immune;
				SpawnCicadas(ecb, localTransformLookup[entity].Position, databaseBankCD.databaseBankBlob, snakeMovementStateLookup, shootMortarStateLookup, chargeAttackStateLookup, time, enemyStagesState.currentStage, armSlamState.amountOfValidPlayers);
				armSlamState.spawnNymphsTimer.Start(time, 30f);
				if (coreBossSpawnVoidStateCD.cooldownTimer.GetElapsedTime(time) + 5f > coreBossSpawnVoidStateCD.duration && giantCicadaRef.voidAttackCooldownTimer.IsTimerElapsed(time) && conditions[248].value == 0)
				{
					giantCicadaRef.voidAttackCooldownTimer.Start(time, 30f);
					coreBossSpawnVoidStateCD.voidZoneType = VoidZoneType.MovingCircle;
					coreBossSpawnVoidStateCD.cooldownTimer.Start(time, 0f);
					coreBossSpawnVoidStateCD.isDisabled = false;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GiantCicadaBossCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__GiantCicadaBossHasAppearedCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EnemyStagesStateCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GiantCicadaSlamArmsStateCD_RW_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyStagesStateCD>(nativeArrayPtr5, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr6, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr7, i), bufferAccessor[i]);
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
						Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyStagesStateCD>(nativeArrayPtr5, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr6, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr7, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
					Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyStagesStateCD>(nativeArrayPtr5, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr6, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr7, j), bufferAccessor[j]);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaBossHasAppearedCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyStagesStateCD>(nativeArrayPtr5, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr6, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GiantCicadaSlamArmsStateCD>(nativeArrayPtr7, k), bufferAccessor[k]);
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
	[WithAny(new Type[] { typeof(GiantCicadaBossCD) })]
	private struct SpawnVoidJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<CoreBossSpawnVoidStateCD> __CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<CoreBossVoidImmuneZoneBuffer> __CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossSpawnVoidStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<CoreBossVoidImmuneZoneBuffer>(isReadOnly: true);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<GiantCicadaBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CoreBossVoidImmuneZoneBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossSpawnVoidStateCD>();
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
			public void Run(ref SpawnVoidJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnVoidJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnVoidJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnVoidJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnVoidJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnVoidJob job, EntityManager entityManager)
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
		public ComponentLookup<AuraDistanceOverrideCD> auraDistanceOverrideLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public NetworkTick currentTick;

		public uint tickRate;

		public EntityCommandBuffer ecb;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfoCD, ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, in DynamicBuffer<CoreBossVoidImmuneZoneBuffer> immunityZones, in DynamicBuffer<SummarizedConditionsBuffer> conditions)
		{
			if (coreBossSpawnVoidStateCD.voidZoneType == VoidZoneType.AttackAreas)
			{
				for (int i = 0; i < immunityZones.Length; i++)
				{
					Entity zone = immunityZones[i].zone;
					if (auraDistanceOverrideLookup.TryGetComponent(zone, out var componentData) && destroyTimerLookup.TryGetComponent(zone, out var componentData2))
					{
						float elapsedSeconds = componentData2.timer.GetElapsedSeconds(currentTick, tickRate);
						float num = (float)componentData2.timer.targetTicks / (float)tickRate;
						float x = math.clamp(elapsedSeconds / num, 0f, 1f);
						x = math.smoothstep(0f, 1f, x);
						float num2 = 0.3f;
						float distance;
						if (x < num2)
						{
							float x2 = x / num2;
							x2 = math.smoothstep(0f, 1f, x2);
							distance = math.lerp(14f, 3.5f, x2);
						}
						else
						{
							float num3 = (x - num2) / (1f - num2);
							num3 = 1f - math.exp(-5f * num3);
							distance = math.lerp(3.5f, 1.5f, num3);
						}
						componentData.distance = distance;
						ecb.SetComponent(zone, componentData);
					}
				}
			}
			else if (coreBossSpawnVoidStateCD.voidZoneType == VoidZoneType.MovingCircle)
			{
				float3 position = localTransformLookup[entity].Position;
				for (int j = 0; j < immunityZones.Length; j++)
				{
					Entity zone2 = immunityZones[j].zone;
					if (auraDistanceOverrideLookup.TryGetComponent(zone2, out var componentData3) && destroyTimerLookup.TryGetComponent(zone2, out var componentData4))
					{
						float elapsedSeconds2 = componentData4.timer.GetElapsedSeconds(currentTick, tickRate);
						float num4 = (float)componentData4.timer.targetTicks / (float)tickRate;
						float t = ((elapsedSeconds2 > 0f) ? math.clamp(elapsedSeconds2 / num4, 0.1f, 1f) : 1f);
						componentData3.distance = math.lerp(10f, 6f, t);
						ecb.SetComponent(zone2, componentData3);
						if (localTransformLookup.TryGetComponent(zone2, out var componentData5))
						{
							float3 position2 = componentData5.Position;
							float num5 = 1f / (float)tickRate;
							float z = 0.8f * num5;
							float3 position3 = position2 + new float3(0f, 0f, z);
							position3.z = math.min(position3.z, position.z - 2f);
							ecb.SetComponent(zone2, LocalTransform.FromPosition(position3));
						}
					}
				}
			}
			else
			{
				for (int k = 0; k < immunityZones.Length; k++)
				{
					Entity zone3 = immunityZones[k].zone;
					if (auraDistanceOverrideLookup.TryGetComponent(zone3, out var componentData6) && destroyTimerLookup.TryGetComponent(zone3, out var componentData7))
					{
						float elapsedSeconds3 = componentData7.timer.GetElapsedSeconds(currentTick, tickRate);
						float num6 = (float)componentData7.timer.targetTicks / (float)tickRate;
						float t2 = math.clamp(elapsedSeconds3 / num6, 0f, 1f);
						componentData6.distance = math.lerp(7f, 5f, t2);
						ecb.SetComponent(zone3, componentData6);
					}
				}
			}
			if (!stateInfoCD.IsCurrentState(StateID.CoreBossSpawnVoid))
			{
				if (conditions[248].value < 0 && (stateInfoCD.IsCurrentState(StateID.Death) || stateInfoCD.IsCurrentState(StateID.Vulnerable)))
				{
					EntityUtility.RemoveCondition(entity, ecb, ConditionID.AuraApplyVoidDamagePercentageOverTime);
				}
			}
			else if (coreBossSpawnVoidStateCD.internalState == CoreBossSpawnVoidInternalState.None)
			{
				coreBossSpawnVoidStateCD.internalState = CoreBossSpawnVoidInternalState.Anticipating;
				coreBossSpawnVoidStateCD.timer.Start(time, coreBossSpawnVoidStateCD.durationUntilSpawn);
			}
			else if (coreBossSpawnVoidStateCD.internalState == CoreBossSpawnVoidInternalState.Anticipating && coreBossSpawnVoidStateCD.timer.IsTimerElapsed(time))
			{
				coreBossSpawnVoidStateCD.internalState = CoreBossSpawnVoidInternalState.Spawning;
				coreBossSpawnVoidStateCD.timer.Start(time, coreBossSpawnVoidStateCD.durationAfterSpawn);
				float3 position4 = localTransformLookup[entity].Position;
				DynamicBuffer<CoreBossVoidImmuneZoneBuffer> dynamicBuffer = ecb.SetBuffer<CoreBossVoidImmuneZoneBuffer>(entity);
				dynamicBuffer.Clear();
				if (coreBossSpawnVoidStateCD.voidZoneType == VoidZoneType.AttackAreas)
				{
					NativeArray<float3> nativeArray = new NativeArray<float3>(6, Allocator.Temp);
					nativeArray[0] = GiantCicadaAttackPoints.ArmSlamLeft;
					nativeArray[1] = GiantCicadaAttackPoints.ArmSlamLeftFar;
					nativeArray[2] = GiantCicadaAttackPoints.ArmSlamMiddleClose;
					nativeArray[3] = GiantCicadaAttackPoints.ArmSlamRight;
					nativeArray[4] = GiantCicadaAttackPoints.ArmSlamRightFar;
					nativeArray[5] = GiantCicadaAttackPoints.ArmSlamMiddleFar;
					NativeArray<float3> nativeArray2 = nativeArray;
					try
					{
						foreach (float3 item in nativeArray2)
						{
							Entity prefabEntity;
							Entity entity2 = EntityUtility.CreateEntity(ecb, position4 + item, ObjectID.CoreBossVoidImmuneZone, 1, databaseBankCD.databaseBankBlob, out prefabEntity);
							ecb.SetComponent(entity2, new OwnerReferenceCD
							{
								owner = entity
							});
							dynamicBuffer.Add(new CoreBossVoidImmuneZoneBuffer
							{
								zone = entity2
							});
							DestroyTimerCD component = destroyTimerLookup[prefabEntity];
							component.timer.SetTargetTicks(coreBossSpawnVoidStateCD.duration, tickRate);
							ecb.SetComponent(entity2, component);
						}
					}
					finally
					{
						nativeArray2.Dispose();
					}
				}
				else if (coreBossSpawnVoidStateCD.voidZoneType == VoidZoneType.MovingCircle)
				{
					Entity prefabEntity2;
					Entity entity3 = EntityUtility.CreateEntity(ecb, position4 + new float3(0f, 0f, -10f), ObjectID.CoreBossVoidImmuneZone, 1, databaseBankCD.databaseBankBlob, out prefabEntity2);
					ecb.SetComponent(entity3, new OwnerReferenceCD
					{
						owner = entity
					});
					dynamicBuffer.Add(new CoreBossVoidImmuneZoneBuffer
					{
						zone = entity3
					});
					DestroyTimerCD component2 = destroyTimerLookup[prefabEntity2];
					component2.timer.SetTargetTicks(coreBossSpawnVoidStateCD.duration, tickRate);
					ecb.SetComponent(entity3, component2);
				}
				else
				{
					Entity prefabEntity3;
					Entity entity4 = EntityUtility.CreateEntity(ecb, position4 + new float3(0f, 0f, -7.5f), ObjectID.CoreBossVoidImmuneZone, 1, databaseBankCD.databaseBankBlob, out prefabEntity3);
					ecb.SetComponent(entity4, new OwnerReferenceCD
					{
						owner = entity
					});
					dynamicBuffer.Add(new CoreBossVoidImmuneZoneBuffer
					{
						zone = entity4
					});
					DestroyTimerCD component3 = destroyTimerLookup[prefabEntity3];
					component3.timer.SetTargetTicks(coreBossSpawnVoidStateCD.duration, tickRate);
					ecb.SetComponent(entity4, component3);
				}
				EntityUtility.AddNewCondition(entity, ecb, new ConditionData
				{
					conditionID = ConditionID.AuraApplyVoidDamagePercentageOverTime,
					duration = coreBossSpawnVoidStateCD.duration,
					value = -20
				});
			}
			else if (coreBossSpawnVoidStateCD.internalState == CoreBossSpawnVoidInternalState.Spawning && coreBossSpawnVoidStateCD.timer.IsTimerElapsed(time))
			{
				coreBossSpawnVoidStateCD.internalState = CoreBossSpawnVoidInternalState.Ending;
			}
			else if (coreBossSpawnVoidStateCD.internalState == CoreBossSpawnVoidInternalState.Ending)
			{
				coreBossSpawnVoidStateCD.internalState = CoreBossSpawnVoidInternalState.None;
				coreBossSpawnVoidStateCD.isDisabled = true;
				stateInfoCD.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			BufferAccessor<CoreBossVoidImmuneZoneBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref StateInfoCD stateInfoCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i);
					ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr3, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, ref stateInfoCD, ref coreBossSpawnVoidStateCD, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), bufferAccessor2[i], bufferAccessor3[i]);
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
						ref StateInfoCD stateInfoCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin);
						ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref stateInfoCD2, ref coreBossSpawnVoidStateCD2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, nextRangeBegin), bufferAccessor2[nextRangeBegin], bufferAccessor3[nextRangeBegin]);
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
					ref StateInfoCD stateInfoCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j);
					ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr3, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, ref stateInfoCD3, ref coreBossSpawnVoidStateCD3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), bufferAccessor2[j], bufferAccessor3[j]);
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
					ref StateInfoCD stateInfoCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k);
					ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr3, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, ref stateInfoCD4, ref coreBossSpawnVoidStateCD4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), bufferAccessor2[k], bufferAccessor3[k]);
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
		public GiantCicadaBossAppearJob.InternalCompilerQueryAndHandleData __CicadaGiantBossSystem_GiantCicadaBossAppearJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentLookup;

		public ComponentLookup<ChargeAttackStateCD> __ChargeAttackStateCD_RW_ComponentLookup;

		public GiantCicadaSlamArmsJob.InternalCompilerQueryAndHandleData __CicadaGiantBossSystem_GiantCicadaSlamArmsJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		public ComponentLookup<SnakeMovementStateCD> __SnakeMovementStateCD_RW_ComponentLookup;

		public GiantCicadaStagesJob.InternalCompilerQueryAndHandleData __CicadaGiantBossSystem_GiantCicadaStagesJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<ImmuneToDamageCD> __ImmuneToDamageCD_RW_ComponentLookup;

		public GiantCicadaBossHandleWeakSpotJob.InternalCompilerQueryAndHandleData __CicadaGiantBossSystem_GiantCicadaBossHandleWeakSpotJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<AuraDistanceOverrideCD> __AuraDistanceOverrideCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> __DestroyTimerCD_RO_ComponentLookup;

		public SpawnVoidJob.InternalCompilerQueryAndHandleData __CicadaGiantBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__CicadaGiantBossSystem_GiantCicadaBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ShootMortarProjectileStateCD_RW_ComponentLookup = state.GetComponentLookup<ShootMortarProjectileStateCD>();
			__ChargeAttackStateCD_RW_ComponentLookup = state.GetComponentLookup<ChargeAttackStateCD>();
			__CicadaGiantBossSystem_GiantCicadaSlamArmsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__SnakeMovementStateCD_RW_ComponentLookup = state.GetComponentLookup<SnakeMovementStateCD>();
			__CicadaGiantBossSystem_GiantCicadaStagesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ImmuneToDamageCD_RW_ComponentLookup = state.GetComponentLookup<ImmuneToDamageCD>();
			__CicadaGiantBossSystem_GiantCicadaBossHandleWeakSpotJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__AuraDistanceOverrideCD_RO_ComponentLookup = state.GetComponentLookup<AuraDistanceOverrideCD>(isReadOnly: true);
			__DestroyTimerCD_RO_ComponentLookup = state.GetComponentLookup<DestroyTimerCD>(isReadOnly: true);
			__CicadaGiantBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000006A6_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000006A6_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000006A6_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000006A7_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000006A7_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000006A7_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_000006A8_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_000006A8_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000006A8_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_000006A9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_000006A9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000006A9_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private const int MAX_NYMPHS_SPAWNED = 14;

	private const int SPAWN_NYMPHS_EVERY_X_HIT = 4;

	private const float VOID_ATTACK_COOLDOWN = 30f;

	private const float VOID_ATTACK_COOLDOWN_DECREASE_WHEN_PLAYER_IS_BEHIND = 12f;

	private PhysicsCollider _beamCollider;

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_72373892_0;

	private EntityQuery __query_72373892_1;

	private EntityQuery __query_72373892_2;

	private EntityQuery __query_72373892_3;

	private EntityQuery __query_72373892_4;

	private EntityQuery __query_72373892_5;

	private EntityQuery __query_72373892_6;

	private static void SpawnCicadas(EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob, ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup, ComponentLookup<ShootMortarProjectileStateCD> mortarStateLookup, ComponentLookup<ChargeAttackStateCD> chargeAttackStateLookup, double time, int currentStage = 99, int amountOfPlayers = 1)
	{
		int num = ((currentStage != 2 && currentStage != 1) ? ((amountOfPlayers > 1) ? 3 : 2) : ((amountOfPlayers > 1) ? 5 : 3));
		if (currentStage > 2)
		{
			int num2 = ((amountOfPlayers != 1) ? 3 : 2);
			num = num2;
		}
		else
		{
			num = amountOfPlayers switch
			{
				1 => 3, 
				2 => 4, 
				_ => 5, 
			};
		}
		for (int i = 0; i < num; i++)
		{
			float3 position2 = position;
			Direction.Id id = Direction.Id.back_left;
			switch (num)
			{
			case 2:
				switch (i)
				{
				case 0:
					position2 += new float3(-11f, 0f, -1f);
					id = Direction.Id.back_right;
					break;
				case 1:
					position2 += new float3(11f, 0f, -1f);
					id = Direction.Id.back_left;
					break;
				}
				break;
			case 3:
				switch (i)
				{
				case 0:
					position2 += new float3(-11f, 0f, -1f);
					id = Direction.Id.back_right;
					break;
				case 1:
					position2 += new float3(11f, 0f, -1f);
					id = Direction.Id.back_left;
					break;
				case 2:
					position2 += new float3(0f, 0f, -16f);
					id = Direction.Id.forward;
					break;
				}
				break;
			case 4:
				switch (i)
				{
				case 0:
					position2 += new float3(-11f, 0f, -1f);
					id = Direction.Id.back_right;
					break;
				case 1:
					position2 += new float3(11f, 0f, -1f);
					id = Direction.Id.back_left;
					break;
				case 2:
					position2 += new float3(-13f, 0f, -13f);
					id = Direction.Id.forward_right;
					break;
				case 3:
					position2 += new float3(13f, 0f, -13f);
					id = Direction.Id.forward_left;
					break;
				}
				break;
			case 5:
				switch (i)
				{
				case 0:
					position2 += new float3(-11f, 0f, -1f);
					id = Direction.Id.back_right;
					break;
				case 1:
					position2 += new float3(11f, 0f, -1f);
					id = Direction.Id.back_left;
					break;
				case 2:
					position2 += new float3(-13f, 0f, -13f);
					id = Direction.Id.forward_right;
					break;
				case 3:
					position2 += new float3(13f, 0f, -13f);
					id = Direction.Id.forward_left;
					break;
				case 4:
					position2 += new float3(0f, 0f, -18f);
					id = Direction.Id.forward;
					break;
				}
				break;
			}
			Entity prefabEntity;
			Entity e = EntityUtility.CreateEntity(ecb, position2, ObjectID.DesertCicadaEnemy, 1, databaseBankBlob, out prefabEntity);
			ecb.SetComponent(e, new AnimationOrientationCD
			{
				facingDirection = id
			});
			SnakeMovementStateCD component = snakeMovementStateLookup[prefabEntity];
			component.externallyRequestedPhase = SnakeMovementPhaseType.COMBAT;
			component.externallyRequestedTargetPoint = new float3(0f, 0f, -6f);
			component.isDisabled = true;
			ecb.SetComponent(e, component);
			ShootMortarProjectileStateCD component2 = mortarStateLookup[prefabEntity];
			component2.minCooldown = 2.5f;
			component2.maxCooldown = 3.5f;
			ecb.SetComponent(e, component2);
			ChargeAttackStateCD component3 = chargeAttackStateLookup[prefabEntity];
			component3.cooldownTimer.Start(time, 20f);
			ecb.SetComponent(e, component3);
		}
	}

	private static void SpawnNymphs(EntityCommandBuffer ecb, float3 position, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob, Unity.Mathematics.Random rng, int amountOfCloseNymphs)
	{
		int num = Mathf.Clamp(14 - amountOfCloseNymphs, 0, 6);
		if (num > 0)
		{
			float num2 = 2.5f;
			float num3 = 5f;
			float num4 = 9.5f;
			NativeArray<float3> list = new NativeArray<float3>(6, Allocator.Temp);
			list[0] = new float3(0f - num4, 0f, 0f - num2);
			list[1] = new float3(0f - num4 - 1f, 0f, 0f - num2 - num3);
			list[2] = new float3(0f - num4, 0f, 0f - num2 - num3 * 2f);
			list[3] = new float3(num4, 0f, 0f - num2);
			list[4] = new float3(num4 + 1f, 0f, 0f - num2 - num3);
			list[5] = new float3(num4, 0f, 0f - num2 - num3 * 2f);
			PugRandom.ShuffleListKindOfRandomly(list, ref rng);
			for (int i = 0; i < num; i++)
			{
				float3 position2 = position + list[i];
				Entity e = EntityUtility.CreateEntity(ecb, ObjectID.CicadaNymph, 1, databaseBankBlob);
				ecb.AddComponent(e, default(DontDropLootCD));
				ecb.SetComponent(e, LocalTransform.FromPosition(position2));
			}
		}
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<TileUpdateBuffer>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<ClientServerTickRate>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		int simulationTickRate = __query_72373892_2.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		_attackHelper = new AttackSystem.Helper(ref state, simulationTickRate);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_72373892_3.TryGetSingleton<NetworkTime>(out var value);
		EntityCommandBuffer ecb = __query_72373892_4.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		NetworkTick serverTick = value.ServerTick;
		uint simulationTickRate = (uint)__query_72373892_2.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		_attackHelper.Update(ref state, value.ServerTick, simulationTickRate);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new GiantCicadaBossAppearJob
		{
			ecb = ecb,
			currentTick = serverTick,
			time = elapsedTime,
			tileDamageBufferEntity = __query_72373892_5.GetSingletonEntity()
		}, __TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		JobHandle outJobHandle;
		NativeList<Entity> nymphsArray = __query_72373892_0.ToEntityListAsync(state.WorldUpdateAllocator, out outJobHandle);
		JobHandle outJobHandle2;
		NativeList<Entity> cicadasArray = __query_72373892_1.ToEntityListAsync(state.WorldUpdateAllocator, out outJobHandle2);
		JobHandle dependency = JobHandle.CombineDependencies(outJobHandle, outJobHandle2, state.Dependency);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new GiantCicadaSlamArmsJob
		{
			attackHelper = _attackHelper,
			databaseBankCD = __query_72373892_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
			shootMortarStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentLookup, ref state),
			chargeAttackStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ChargeAttackStateCD_RW_ComponentLookup, ref state),
			ecb = ecb,
			time = elapsedTime,
			rng = PugRandom.GetRng(),
			nymphsArray = nymphsArray,
			cicadasArray = cicadasArray,
			tileDamageBufferEntity = __query_72373892_5.GetSingletonEntity()
		}, __TypeHandle.__CicadaGiantBossSystem_GiantCicadaSlamArmsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new GiantCicadaStagesJob
		{
			ecb = ecb,
			databaseBankCD = __query_72373892_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
			time = elapsedTime,
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			chargeAttackStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ChargeAttackStateCD_RW_ComponentLookup, ref state),
			snakeMovementStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SnakeMovementStateCD_RW_ComponentLookup, ref state),
			shootMortarStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentLookup, ref state)
		}, __TypeHandle.__CicadaGiantBossSystem_GiantCicadaStagesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_3(new GiantCicadaBossHandleWeakSpotJob
		{
			immuneToDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ImmuneToDamageCD_RW_ComponentLookup, ref state),
			ecb = ecb,
			databaseBankCD = __query_72373892_6.GetSingleton<PugDatabase.DatabaseBankCD>()
		}, __TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossHandleWeakSpotJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_4(new SpawnVoidJob
		{
			auraDistanceOverrideLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AuraDistanceOverrideCD_RO_ComponentLookup, ref state),
			destroyTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DestroyTimerCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			databaseBankCD = __query_72373892_6.GetSingleton<PugDatabase.DatabaseBankCD>(),
			currentTick = value.ServerTick,
			tickRate = simulationTickRate,
			ecb = ecb,
			time = elapsedTime
		}, __TypeHandle.__CicadaGiantBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(GiantCicadaBossAppearJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossAppearJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(GiantCicadaSlamArmsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CicadaGiantBossSystem_GiantCicadaSlamArmsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CicadaGiantBossSystem_GiantCicadaSlamArmsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CicadaGiantBossSystem_GiantCicadaSlamArmsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CicadaGiantBossSystem_GiantCicadaSlamArmsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(GiantCicadaStagesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CicadaGiantBossSystem_GiantCicadaStagesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CicadaGiantBossSystem_GiantCicadaStagesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CicadaGiantBossSystem_GiantCicadaStagesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CicadaGiantBossSystem_GiantCicadaStagesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(GiantCicadaBossHandleWeakSpotJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossHandleWeakSpotJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossHandleWeakSpotJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossHandleWeakSpotJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CicadaGiantBossSystem_GiantCicadaBossHandleWeakSpotJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(SpawnVoidJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CicadaGiantBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CicadaGiantBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CicadaGiantBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CicadaGiantBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<CicadaNymphCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
		__query_72373892_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CicadaEnemyCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
		__query_72373892_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_72373892_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_72373892_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_72373892_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_72373892_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_72373892_6 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000006A6_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000006A7_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_000006A8_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_000006A9_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((CicadaGiantBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CicadaGiantBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CicadaGiantBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CicadaGiantBossSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CicadaGiantBossSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
