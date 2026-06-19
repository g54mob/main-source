using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PredictionSmoothing;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.GraphicsIntegration;
using Unity.Transforms;

namespace MotionSmoothing
{
	[RequireMatchingQueriesForUpdate]
	[BurstCompile]
	[UpdateInGroup(typeof(TransformSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct MotionSmoothingSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct SmoothVelocityJob : IJobChunk
		{
			public ComponentTypeHandle<PhysicsVelocitySmoothedCD> PhysicsVelocitySmoothed;

			[ReadOnly]
			public ComponentTypeHandle<PhysicsVelocityInterpolatedValuesCD> PhysicsVelocityInterpolation;

			public ComponentTypeHandle<PhysicsAccelerationSmoothedCD> PhysicsAccelerationSmoothed;

			[ReadOnly]
			public ComponentTypeHandle<PhysicsAccelerationInterpolatedValuesCD> PhysicsAccelerationInterpolation;

			[ReadOnly]
			public BufferLookup<MostRecentFixedTime> MostRecentFixedTime;

			[ReadOnly]
			public SharedComponentTypeHandle<PhysicsWorldIndex> PhysicsWorldIndex;

			public Entity MostRecentFixedTimeEntity;

			public double ElapsedTime;

			public int PhysicsTicksToInterpolate;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				int value = (int)chunk.GetSharedComponent(PhysicsWorldIndex).Value;
				DynamicBuffer<MostRecentFixedTime> dynamicBuffer = MostRecentFixedTime[MostRecentFixedTimeEntity];
				if (dynamicBuffer.Length <= value)
				{
					return;
				}
				MostRecentFixedTime mostRecentFixedTime = dynamicBuffer[value];
				float num = (float)(ElapsedTime - mostRecentFixedTime.ElapsedTime);
				float num2 = (float)mostRecentFixedTime.DeltaTime;
				if (!(num < 0f) && num2 != 0f)
				{
					float t = math.clamp(num / num2, 0f, 1f);
					NativeArray<PhysicsVelocitySmoothedCD> nativeArray = chunk.GetNativeArray(PhysicsVelocitySmoothed);
					NativeArray<PhysicsVelocityInterpolatedValuesCD> nativeArray2 = chunk.GetNativeArray(PhysicsVelocityInterpolation);
					int i = 0;
					for (int count = chunk.Count; i < count; i++)
					{
						PhysicsVelocityInterpolatedValuesCD physicsVelocityInterpolatedValuesCD = nativeArray2[i];
						nativeArray[i] = new PhysicsVelocitySmoothedCD
						{
							Value = math.lerp(physicsVelocityInterpolatedValuesCD.Previous, physicsVelocityInterpolatedValuesCD.Current, t)
						};
					}
					NativeArray<PhysicsAccelerationSmoothedCD> nativeArray3 = chunk.GetNativeArray(PhysicsAccelerationSmoothed);
					NativeArray<PhysicsAccelerationInterpolatedValuesCD> nativeArray4 = chunk.GetNativeArray(PhysicsAccelerationInterpolation);
					int j = 0;
					for (int count2 = chunk.Count; j < count2; j++)
					{
						PhysicsAccelerationInterpolatedValuesCD physicsAccelerationInterpolatedValuesCD = nativeArray4[j];
						nativeArray3[j] = new PhysicsAccelerationSmoothedCD
						{
							Value = math.lerp(physicsAccelerationInterpolatedValuesCD.Previous, physicsAccelerationInterpolatedValuesCD.Current, t)
						};
					}
				}
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct TypeHandle
		{
			public ComponentTypeHandle<PhysicsVelocitySmoothedCD> __MotionSmoothing_PhysicsVelocitySmoothedCD_RW_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<PhysicsVelocityInterpolatedValuesCD> __MotionSmoothing_PhysicsVelocityInterpolatedValuesCD_RO_ComponentTypeHandle;

			public ComponentTypeHandle<PhysicsAccelerationSmoothedCD> __MotionSmoothing_PhysicsAccelerationSmoothedCD_RW_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<PhysicsAccelerationInterpolatedValuesCD> __MotionSmoothing_PhysicsAccelerationInterpolatedValuesCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public BufferLookup<MostRecentFixedTime> __Unity_Physics_GraphicsIntegration_MostRecentFixedTime_RO_BufferLookup;

			public SharedComponentTypeHandle<PhysicsWorldIndex> __Unity_Physics_PhysicsWorldIndex_SharedComponentTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__MotionSmoothing_PhysicsVelocitySmoothedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocitySmoothedCD>();
				__MotionSmoothing_PhysicsVelocityInterpolatedValuesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocityInterpolatedValuesCD>(isReadOnly: true);
				__MotionSmoothing_PhysicsAccelerationSmoothedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsAccelerationSmoothedCD>();
				__MotionSmoothing_PhysicsAccelerationInterpolatedValuesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsAccelerationInterpolatedValuesCD>(isReadOnly: true);
				__Unity_Physics_GraphicsIntegration_MostRecentFixedTime_RO_BufferLookup = state.GetBufferLookup<MostRecentFixedTime>(isReadOnly: true);
				__Unity_Physics_PhysicsWorldIndex_SharedComponentTypeHandle = state.GetSharedComponentTypeHandle<PhysicsWorldIndex>();
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00000035_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00000035_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000035_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00000036_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00000036_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000036_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private int _physicsTicksToInterpolate;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_489745496_0;

		private EntityQuery __query_489745496_1;

		private EntityQuery __query_489745496_2;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<MostRecentFixedTime>();
			state.RequireForUpdate<LastRecordedPhysicsStepsForPredictionSmoothingCD>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			RefRW<LastRecordedPhysicsStepsForPredictionSmoothingCD> singletonRW = __query_489745496_1.GetSingletonRW<LastRecordedPhysicsStepsForPredictionSmoothingCD>();
			if (singletonRW.ValueRO.physicsTicks != 0)
			{
				_physicsTicksToInterpolate = singletonRW.ValueRO.physicsTicks;
			}
			state.Dependency = JobChunkExtensions.ScheduleParallel(new SmoothVelocityJob
			{
				PhysicsVelocitySmoothed = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__MotionSmoothing_PhysicsVelocitySmoothedCD_RW_ComponentTypeHandle, ref state),
				PhysicsVelocityInterpolation = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__MotionSmoothing_PhysicsVelocityInterpolatedValuesCD_RO_ComponentTypeHandle, ref state),
				PhysicsAccelerationSmoothed = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__MotionSmoothing_PhysicsAccelerationSmoothedCD_RW_ComponentTypeHandle, ref state),
				PhysicsAccelerationInterpolation = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__MotionSmoothing_PhysicsAccelerationInterpolatedValuesCD_RO_ComponentTypeHandle, ref state),
				MostRecentFixedTime = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Unity_Physics_GraphicsIntegration_MostRecentFixedTime_RO_BufferLookup, ref state),
				PhysicsWorldIndex = InternalCompilerInterface.GetSharedComponentTypeHandle(ref __TypeHandle.__Unity_Physics_PhysicsWorldIndex_SharedComponentTypeHandle, ref state),
				MostRecentFixedTimeEntity = __query_489745496_2.GetSingletonEntity(),
				ElapsedTime = state.WorldUnmanaged.Time.ElapsedTime,
				PhysicsTicksToInterpolate = _physicsTicksToInterpolate
			}, __query_489745496_0, state.Dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsVelocitySmoothedCD, PhysicsVelocityInterpolatedValuesCD, PhysicsAccelerationSmoothedCD, PhysicsAccelerationInterpolatedValuesCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsWorldIndex>();
			__query_489745496_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAllRW<LastRecordedPhysicsStepsForPredictionSmoothingCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_489745496_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<MostRecentFixedTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_489745496_2 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00000035_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00000036_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((MotionSmoothingSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((MotionSmoothingSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((MotionSmoothingSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
