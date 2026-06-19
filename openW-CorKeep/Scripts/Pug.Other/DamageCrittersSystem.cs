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
using Unity.Transforms;

[BurstCompile]
[UpdateBefore(typeof(PlayerAttackSystem))]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct DamageCrittersSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(Simulate) })]
	private struct DamageCritterJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<DealDamageToCrittersCD> __DealDamageToCrittersCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerMovementCD> __PlayerMovementCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public ComponentTypeHandle<CritterDamageFromPlacingCD> __CritterDamageFromPlacingCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<DealDamageToEntityBuffer> __DealDamageToEntityBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__DealDamageToCrittersCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<DealDamageToCrittersCD>();
					__PlayerMovementCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerMovementCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__CritterDamageFromPlacingCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CritterDamageFromPlacingCD>();
					__DealDamageToEntityBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DealDamageToEntityBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__DealDamageToCrittersCD_RW_ComponentTypeHandle.Update(ref state);
					__PlayerMovementCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__CritterDamageFromPlacingCD_RW_ComponentTypeHandle.Update(ref state);
					__DealDamageToEntityBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerMovementCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DealDamageToCrittersCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CritterDamageFromPlacingCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DealDamageToEntityBuffer>();
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
			public void Run(ref DamageCritterJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DamageCritterJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DamageCritterJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DamageCritterJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DamageCritterJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DamageCritterJob job, EntityManager entityManager)
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

		public int ticksPerUpdate;

		public float fixedDeltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref DealDamageToCrittersCD dealDamageToCrittersCD, in PlayerMovementCD playerMovementCD, in LocalTransform localTransform, ref CritterDamageFromPlacingCD critterDamageFromPlacingCD, ref DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer)
		{
			if (critterDamageFromPlacingCD.triggered)
			{
				critterDamageFromPlacingCD.triggered = false;
				dealDamageToEntityBuffer.Add(new DealDamageToEntityBuffer
				{
					attackType = DealDamageToEntityBuffer.AttackType.CritterDamage,
					hitPosition = critterDamageFromPlacingCD.pos,
					optionalFromPosition = critterDamageFromPlacingCD.pos,
					critterDamageSize = critterDamageFromPlacingCD.size,
					critterDamageCanDamageFlying = critterDamageFromPlacingCD.canDamageFlyingCritter,
					critterDamageKillEvenIfSquashBugsIsOff = critterDamageFromPlacingCD.killEvenIfSquashBugsIsOff
				});
			}
			float2 float5 = dealDamageToCrittersCD.lastDamagePos;
			float2 float6 = localTransform.Position.ToFloat2();
			float num = math.length(float5 - float6);
			if (!(math.length(playerMovementCD.targetMovementVelocity) < 0.01f) || !(num < 0.01f))
			{
				float num2 = 2.64f * playerMovementCD.movementSpeed;
				float num3 = fixedDeltaTime * (num2 / 60f) * (float)ticksPerUpdate;
				if (num > num3)
				{
					float5 = float6;
				}
				dealDamageToCrittersCD.lastDamagePos = float6;
				dealDamageToEntityBuffer.Add(new DealDamageToEntityBuffer
				{
					attackType = DealDamageToEntityBuffer.AttackType.CritterDamage,
					optionalFromPosition = float5.ToFloat3(),
					hitPosition = float6.ToFloat3(),
					critterDamageSize = new float3(0.5f, 1f, 0.3f),
					critterDamageCanDamageFlying = false,
					critterDamageKillEvenIfSquashBugsIsOff = false
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__DealDamageToCrittersCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerMovementCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CritterDamageFromPlacingCD_RW_ComponentTypeHandle);
			BufferAccessor<DealDamageToEntityBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__DealDamageToEntityBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref DealDamageToCrittersCD dealDamageToCrittersCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DealDamageToCrittersCD>(nativeArrayPtr, i);
					ref PlayerMovementCD playerMovementCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr2, i);
					ref LocalTransform localTransform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i);
					ref CritterDamageFromPlacingCD critterDamageFromPlacingCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CritterDamageFromPlacingCD>(nativeArrayPtr4, i);
					DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer = bufferAccessor[i];
					Execute(ref dealDamageToCrittersCD, in playerMovementCD, in localTransform, ref critterDamageFromPlacingCD, ref dealDamageToEntityBuffer);
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
						ref DealDamageToCrittersCD dealDamageToCrittersCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DealDamageToCrittersCD>(nativeArrayPtr, nextRangeBegin);
						ref PlayerMovementCD playerMovementCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr2, nextRangeBegin);
						ref LocalTransform localTransform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin);
						ref CritterDamageFromPlacingCD critterDamageFromPlacingCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CritterDamageFromPlacingCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(ref dealDamageToCrittersCD2, in playerMovementCD2, in localTransform2, ref critterDamageFromPlacingCD2, ref dealDamageToEntityBuffer2);
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
					ref DealDamageToCrittersCD dealDamageToCrittersCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DealDamageToCrittersCD>(nativeArrayPtr, j);
					ref PlayerMovementCD playerMovementCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr2, j);
					ref LocalTransform localTransform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j);
					ref CritterDamageFromPlacingCD critterDamageFromPlacingCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CritterDamageFromPlacingCD>(nativeArrayPtr4, j);
					DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer3 = bufferAccessor[j];
					Execute(ref dealDamageToCrittersCD3, in playerMovementCD3, in localTransform3, ref critterDamageFromPlacingCD3, ref dealDamageToEntityBuffer3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					ref DealDamageToCrittersCD dealDamageToCrittersCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DealDamageToCrittersCD>(nativeArrayPtr, k);
					ref PlayerMovementCD playerMovementCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr2, k);
					ref LocalTransform localTransform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k);
					ref CritterDamageFromPlacingCD critterDamageFromPlacingCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CritterDamageFromPlacingCD>(nativeArrayPtr4, k);
					DynamicBuffer<DealDamageToEntityBuffer> dealDamageToEntityBuffer4 = bufferAccessor[k];
					Execute(ref dealDamageToCrittersCD4, in playerMovementCD4, in localTransform4, ref critterDamageFromPlacingCD4, ref dealDamageToEntityBuffer4);
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
		public DamageCritterJob.InternalCompilerQueryAndHandleData __DamageCrittersSystem_DamageCritterJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__DamageCrittersSystem_DamageCritterJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00001605_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001605_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001605_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_569239142_0;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_569239142_0.TryGetSingleton<NetworkTime>(out var value);
		if (VariableSystemUpdate.ShouldUpdate(ref state, value, 3, 3f, out var ticksPerUpdate))
		{
			state.Dependency = __ScheduleViaJobChunkExtension_0(new DamageCritterJob
			{
				ticksPerUpdate = ticksPerUpdate,
				fixedDeltaTime = state.WorldUnmanaged.Time.DeltaTime
			}, __TypeHandle.__DamageCrittersSystem_DamageCritterJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(DamageCritterJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DamageCrittersSystem_DamageCritterJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DamageCrittersSystem_DamageCritterJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DamageCrittersSystem_DamageCritterJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DamageCrittersSystem_DamageCritterJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_569239142_0 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnUpdate_00001605_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((DamageCrittersSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DamageCrittersSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
