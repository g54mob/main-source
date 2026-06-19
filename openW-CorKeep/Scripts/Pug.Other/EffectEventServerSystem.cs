using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct EffectEventServerSystem : ISystem, ISystemCompilerGenerated
{
	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EffectEventRpc> __EffectEventRpc_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentLookup = state.GetComponentLookup<ReceiveRpcCommandRequest>(isReadOnly: true);
			__EffectEventRpc_RO_ComponentLookup = state.GetComponentLookup<EffectEventRpc>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00001C4E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00001C4E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00001C4E_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00001C4F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001C4F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001C4F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private const float effectDistance = 30f;

	private EntityArchetype rpcArchetype;

	private EntityQuery receivedEffectsQ;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_208701721_0;

	private EntityQuery __query_208701721_1;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.EntityManager.CreateSingletonBuffer<EffectEventBuffer>();
		NativeArray<ComponentType> nativeArray = new NativeArray<ComponentType>(2, Allocator.Temp);
		nativeArray[0] = ComponentType.ReadOnly<EffectEventRpc>();
		nativeArray[1] = ComponentType.ReadOnly<SendRpcToNearbyPlayers>();
		using NativeArray<ComponentType> types = nativeArray;
		rpcArchetype = state.EntityManager.CreateArchetype(types);
		nativeArray = new NativeArray<ComponentType>(2, Allocator.Temp);
		nativeArray[0] = ComponentType.ReadOnly<EffectEventRpc>();
		nativeArray[1] = ComponentType.ReadOnly<ReceiveRpcCommandRequest>();
		using NativeArray<ComponentType> componentTypes = nativeArray;
		receivedEffectsQ = state.GetEntityQuery(componentTypes);
		state.RequireForUpdate<EffectEventBuffer>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		DynamicBuffer<EffectEventBuffer> singletonBuffer = __query_208701721_0.GetSingletonBuffer<EffectEventBuffer>();
		if (singletonBuffer.Length == 0 && receivedEffectsQ.IsEmpty)
		{
			return;
		}
		using NativeArray<Entity> entities = receivedEffectsQ.ToEntityArray(Allocator.Temp);
		EntityCommandBuffer entityCommandBuffer = __query_208701721_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		for (int i = 0; i < singletonBuffer.Length; i++)
		{
			EffectEventCD value = singletonBuffer[i].Value;
			float3 position = ((value.entity != Entity.Null && InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, value.entity)) ? InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, value.entity).Position : value.position1);
			Entity e = entityCommandBuffer.CreateEntity(rpcArchetype);
			entityCommandBuffer.SetComponent(e, new EffectEventRpc
			{
				Value = value
			});
			entityCommandBuffer.SetComponent(e, new SendRpcToNearbyPlayers
			{
				position = position,
				distance = 30f
			});
		}
		singletonBuffer.Clear();
		for (int j = 0; j < entities.Length; j++)
		{
			Entity entity = entities[j];
			Entity sourceConnection = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentLookup, ref state, entity).SourceConnection;
			EffectEventRpc componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__EffectEventRpc_RO_ComponentLookup, ref state, entity);
			Entity e2 = entityCommandBuffer.CreateEntity(rpcArchetype);
			entityCommandBuffer.SetComponent(e2, componentAfterCompletingDependency);
			entityCommandBuffer.SetComponent(e2, new SendRpcToNearbyPlayers
			{
				position = componentAfterCompletingDependency.Value.position1,
				distance = 30f,
				connection = sourceConnection
			});
		}
		state.EntityManager.DestroyEntity(entities);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_208701721_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_208701721_1 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00001C4E_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00001C4F_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((EffectEventServerSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EffectEventServerSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EffectEventServerSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
