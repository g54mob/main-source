using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PredictionSmoothing;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics.GraphicsIntegration;
using Unity.Transforms;

namespace MotionSmoothing
{
	[RequireMatchingQueriesForUpdate]
	[BurstCompile]
	[UpdateBefore(typeof(MotionSmoothingSystem))]
	[UpdateInGroup(typeof(TransformSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct MotionSmoothingSwapInterpolationTargetSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct SwapSmoothingStartJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<PhysicsGraphicalInterpolationBuffer> __Unity_Physics_GraphicsIntegration_PhysicsGraphicalInterpolationBuffer_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PhysicsGraphicalSmoothing> __Unity_Physics_GraphicsIntegration_PhysicsGraphicalSmoothing_RO_ComponentTypeHandle;

					public ComponentTypeHandle<PhysicsVelocityInterpolatedValuesCD> __MotionSmoothing_PhysicsVelocityInterpolatedValuesCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<PhysicsAccelerationInterpolatedValuesCD> __MotionSmoothing_PhysicsAccelerationInterpolatedValuesCD_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Physics_GraphicsIntegration_PhysicsGraphicalInterpolationBuffer_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsGraphicalInterpolationBuffer>(isReadOnly: true);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
						__Unity_Physics_GraphicsIntegration_PhysicsGraphicalSmoothing_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsGraphicalSmoothing>(isReadOnly: true);
						__MotionSmoothing_PhysicsVelocityInterpolatedValuesCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocityInterpolatedValuesCD>();
						__MotionSmoothing_PhysicsAccelerationInterpolatedValuesCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsAccelerationInterpolatedValuesCD>();
					}

					public void Update(ref SystemState state)
					{
						__Unity_Physics_GraphicsIntegration_PhysicsGraphicalInterpolationBuffer_RO_ComponentTypeHandle.Update(ref state);
						__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
						__Unity_Physics_GraphicsIntegration_PhysicsGraphicalSmoothing_RO_ComponentTypeHandle.Update(ref state);
						__MotionSmoothing_PhysicsVelocityInterpolatedValuesCD_RW_ComponentTypeHandle.Update(ref state);
						__MotionSmoothing_PhysicsAccelerationInterpolatedValuesCD_RW_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsGraphicalInterpolationBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsGraphicalSmoothing>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsVelocityInterpolatedValuesCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsAccelerationInterpolatedValuesCD>();
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
				public void Run(ref SwapSmoothingStartJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref SwapSmoothingStartJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref SwapSmoothingStartJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref SwapSmoothingStartJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref SwapSmoothingStartJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref SwapSmoothingStartJob job, EntityManager entityManager)
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

			public int physicsTicksSinceLastRun;

			public float fixedDeltaTime;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(in PhysicsGraphicalInterpolationBuffer physicsGraphicalInterpolationBuffer, in LocalTransform localTransform, in PhysicsGraphicalSmoothing physicsGraphicalSmoothing, ref PhysicsVelocityInterpolatedValuesCD physicsVelocityInterpolatedValuesCD, ref PhysicsAccelerationInterpolatedValuesCD physicsAccelerationInterpolatedValuesCD)
			{
				physicsVelocityInterpolatedValuesCD.Previous = physicsVelocityInterpolatedValuesCD.Current;
				physicsAccelerationInterpolatedValuesCD.Previous = physicsAccelerationInterpolatedValuesCD.Current;
				float3 pos = physicsGraphicalInterpolationBuffer.PreviousTransform.pos;
				float3 position = localTransform.Position;
				if (physicsGraphicalSmoothing.ApplySmoothing == 1)
				{
					physicsVelocityInterpolatedValuesCD.Current = (position - pos) / fixedDeltaTime;
					physicsAccelerationInterpolatedValuesCD.Current = (physicsVelocityInterpolatedValuesCD.Current - physicsVelocityInterpolatedValuesCD.Previous) / fixedDeltaTime;
				}
				else
				{
					physicsVelocityInterpolatedValuesCD.Current = physicsVelocityInterpolatedValuesCD.Previous;
					physicsAccelerationInterpolatedValuesCD.Current = physicsAccelerationInterpolatedValuesCD.Previous;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Physics_GraphicsIntegration_PhysicsGraphicalInterpolationBuffer_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Physics_GraphicsIntegration_PhysicsGraphicalSmoothing_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MotionSmoothing_PhysicsVelocityInterpolatedValuesCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MotionSmoothing_PhysicsAccelerationInterpolatedValuesCD_RW_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalInterpolationBuffer>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalSmoothing>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocityInterpolatedValuesCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsAccelerationInterpolatedValuesCD>(nativeArrayPtr5, i));
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
							Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalInterpolationBuffer>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalSmoothing>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocityInterpolatedValuesCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsAccelerationInterpolatedValuesCD>(nativeArrayPtr5, nextRangeBegin));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalInterpolationBuffer>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalSmoothing>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocityInterpolatedValuesCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsAccelerationInterpolatedValuesCD>(nativeArrayPtr5, j));
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalInterpolationBuffer>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsGraphicalSmoothing>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocityInterpolatedValuesCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsAccelerationInterpolatedValuesCD>(nativeArrayPtr5, k));
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
			public SwapSmoothingStartJob.InternalCompilerQueryAndHandleData __MotionSmoothing_MotionSmoothingSwapInterpolationTargetSystem_SwapSmoothingStartJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__MotionSmoothing_MotionSmoothingSwapInterpolationTargetSystem_SwapSmoothingStartJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00000008_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00000008_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000008_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00000009_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00000009_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000009_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private NetworkTick _lastUpdateTick;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_610265898_0;

		private EntityQuery __query_610265898_1;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<LastRecordedPhysicsStepsForPredictionSmoothingCD>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			RefRW<LastRecordedPhysicsStepsForPredictionSmoothingCD> singletonRW = __query_610265898_0.GetSingletonRW<LastRecordedPhysicsStepsForPredictionSmoothingCD>();
			if (singletonRW.ValueRO.physicsTicks != 0)
			{
				float fixedDeltaTime = 1f / (float)__query_610265898_1.GetSingleton<ClientServerTickRate>().SimulationTickRate;
				state.Dependency = __ScheduleViaJobChunkExtension_0(new SwapSmoothingStartJob
				{
					physicsTicksSinceLastRun = singletonRW.ValueRO.physicsTicks,
					fixedDeltaTime = fixedDeltaTime
				}, __TypeHandle.__MotionSmoothing_MotionSmoothingSwapInterpolationTargetSystem_SwapSmoothingStartJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(SwapSmoothingStartJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__MotionSmoothing_MotionSmoothingSwapInterpolationTargetSystem_SwapSmoothingStartJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__MotionSmoothing_MotionSmoothingSwapInterpolationTargetSystem_SwapSmoothingStartJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__MotionSmoothing_MotionSmoothingSwapInterpolationTargetSystem_SwapSmoothingStartJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__MotionSmoothing_MotionSmoothingSwapInterpolationTargetSystem_SwapSmoothingStartJob_WithDefaultQuery_JobEntityTypeHandle.ScheduleParallel(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<LastRecordedPhysicsStepsForPredictionSmoothingCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_610265898_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_610265898_1 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00000008_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00000009_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((MotionSmoothingSwapInterpolationTargetSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((MotionSmoothingSwapInterpolationTargetSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((MotionSmoothingSwapInterpolationTargetSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
