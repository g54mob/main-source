using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Physics;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeginSimulationSystemGroup))]
public struct RotateColliderSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct RotateColliderJob : IJobChunk
	{
		public ComponentTypeHandle<PhysicsCollider> physicsColliderHandle;

		public ComponentTypeHandle<SwapColliderInternalCD> swapColliderInternalCDHandle;

		[ReadOnly]
		public ComponentTypeHandle<DirectionCD> directionCDHandle;

		[ReadOnly]
		public BufferTypeHandle<PhysicsRotations> physicsRotationsHandle;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			NativeArray<PhysicsCollider> nativeArray = chunk.GetNativeArray(ref physicsColliderHandle);
			NativeArray<SwapColliderInternalCD> nativeArray2 = chunk.GetNativeArray(ref swapColliderInternalCDHandle);
			NativeArray<DirectionCD> nativeArray3 = chunk.GetNativeArray(ref directionCDHandle);
			BufferAccessor<PhysicsRotations> bufferAccessor = chunk.GetBufferAccessor(ref physicsRotationsHandle);
			if (nativeArray2.IsCreated)
			{
				for (int i = 0; i < chunk.Count; i++)
				{
					PhysicsCollider value = nativeArray[i];
					SwapColliderInternalCD value2 = nativeArray2[i];
					DirectionCD directionCD = nativeArray3[i];
					DynamicBuffer<PhysicsRotations> dynamicBuffer = bufferAccessor[i];
					if (value2.hasSwapped)
					{
						int variationFromDirection = DirectionBasedOnVariationCD.GetVariationFromDirection(directionCD.direction.RoundToInt2());
						value2.colliderRef = dynamicBuffer[variationFromDirection].Value;
						nativeArray2[i] = value2;
					}
					else
					{
						int variationFromDirection2 = DirectionBasedOnVariationCD.GetVariationFromDirection(directionCD.direction.RoundToInt2());
						value.Value = dynamicBuffer[variationFromDirection2].Value;
						nativeArray[i] = value;
					}
				}
			}
			else
			{
				for (int j = 0; j < chunk.Count; j++)
				{
					PhysicsCollider value3 = nativeArray[j];
					DirectionCD directionCD2 = nativeArray3[j];
					DynamicBuffer<PhysicsRotations> dynamicBuffer2 = bufferAccessor[j];
					int variationFromDirection3 = DirectionBasedOnVariationCD.GetVariationFromDirection(directionCD2.direction.RoundToInt2());
					value3.Value = dynamicBuffer2[variationFromDirection3].Value;
					nativeArray[j] = value3;
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
		public ComponentTypeHandle<PhysicsCollider> __Unity_Physics_PhysicsCollider_RW_ComponentTypeHandle;

		public ComponentTypeHandle<SwapColliderInternalCD> __SwapColliderInternalCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DirectionCD> __DirectionCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<PhysicsRotations> __PhysicsRotations_RO_BufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Physics_PhysicsCollider_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsCollider>();
			__SwapColliderInternalCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SwapColliderInternalCD>();
			__DirectionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DirectionCD>(isReadOnly: true);
			__PhysicsRotations_RO_BufferTypeHandle = state.GetBufferTypeHandle<PhysicsRotations>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000032DF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000032DF_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000032DF_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000032E0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000032E0_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000032E0_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery _entityQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_929522094_0;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		_entityQuery = __query_929522094_0;
		_entityQuery.AddOrderVersionFilter();
		_entityQuery.AddChangedVersionFilter(ComponentType.ReadOnly<DirectionCD>());
		state.RequireForUpdate(_entityQuery);
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		state.Dependency = JobChunkExtensions.Schedule(new RotateColliderJob
		{
			physicsColliderHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Physics_PhysicsCollider_RW_ComponentTypeHandle, ref state),
			swapColliderInternalCDHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__SwapColliderInternalCD_RW_ComponentTypeHandle, ref state),
			directionCDHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__DirectionCD_RO_ComponentTypeHandle, ref state),
			physicsRotationsHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__PhysicsRotations_RO_BufferTypeHandle, ref state)
		}, _entityQuery, state.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PhysicsCollider>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DirectionCD, PhysicsRotations>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_929522094_0 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000032DF_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000032E0_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((RotateColliderSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RotateColliderSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RotateColliderSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
