using System;
using System.Collections;
using System.Collections.Generic;
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
public struct SendRpcToNearbyPlayersSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2070119446_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SendRpcToNearbyPlayers>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SendRpcToNearbyPlayers>>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<SendRpcToNearbyPlayers>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<SendRpcToNearbyPlayers> item1_ComponentTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<SendRpcToNearbyPlayers>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SendRpcToNearbyPlayers>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SendRpcToNearbyPlayers>> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<SendRpcToNearbyPlayers>();
		}
	}

	private struct TypeHandle
	{
		public IFE_2070119446_0.TypeHandle __IFE_2070119446_0_TypeHandle;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

		public ComponentLookup<PlayerGhost> __PlayerGhost_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_2070119446_0_TypeHandle = new IFE_2070119446_0.TypeHandle(ref state);
			__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
			__PlayerGhost_RW_ComponentLookup = state.GetComponentLookup<PlayerGhost>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00003368_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003368_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003368_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_2070119446_0;

	private EntityQuery __query_2070119446_1;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<SendRpcToNearbyPlayers>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		NativeArray<Entity> nativeArray = __query_2070119446_1.ToEntityArray(Allocator.Temp);
		NativeArray<float3> nativeArray2 = new NativeArray<float3>(nativeArray.Length, Allocator.Temp);
		NativeArray<Entity> nativeArray3 = new NativeArray<Entity>(nativeArray.Length, Allocator.Temp);
		ComponentLookup<LocalTransform> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state);
		ComponentLookup<PlayerGhost> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RW_ComponentLookup, ref state);
		for (int i = 0; i < nativeArray.Length; i++)
		{
			nativeArray2[i] = componentLookup[nativeArray[i]].Position;
			nativeArray3[i] = componentLookup2[nativeArray[i]].connection;
		}
		nativeArray.Dispose();
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SendRpcToNearbyPlayers>> item2 in IFE_2070119446_0.Query(__query_2070119446_0, __TypeHandle.__IFE_2070119446_0_TypeHandle, ref state))
		{
			item2.Deconstruct(out var item, out var entity);
			InternalCompilerInterface.UncheckedRefRW<SendRpcToNearbyPlayers> uncheckedRefRW = item;
			Entity e = entity;
			float num = ((uncheckedRefRW.ValueRO.distance == 0f) ? 400f : (uncheckedRefRW.ValueRO.distance * uncheckedRefRW.ValueRO.distance));
			uncheckedRefRW.ValueRW.position.y = 0f;
			entityCommandBuffer.RemoveComponent<SendRpcToNearbyPlayers>(e);
			for (int j = 0; j < nativeArray2.Length; j++)
			{
				float3 x = nativeArray2[j];
				x.y = 0f;
				Entity entity2 = nativeArray3[j];
				if ((!uncheckedRefRW.ValueRO.includeConnection) ? (entity2 != uncheckedRefRW.ValueRO.connection && math.distancesq(x, uncheckedRefRW.ValueRO.position) < num) : (uncheckedRefRW.ValueRO.connection == entity2))
				{
					Entity e2 = entityCommandBuffer.Instantiate(e);
					entityCommandBuffer.AddComponent(e2, new SendRpcCommandRequest
					{
						TargetConnection = entity2
					});
				}
			}
			if (uncheckedRefRW.ValueRO.alsoCreateForServer)
			{
				entityCommandBuffer.AddComponent<ReceiveRpcCommandRequest>(e);
			}
			else
			{
				entityCommandBuffer.DestroyEntity(e);
			}
		}
		nativeArray2.Dispose();
		nativeArray3.Dispose();
		entityCommandBuffer.Playback(state.EntityManager);
		entityCommandBuffer.Dispose();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<SendRpcToNearbyPlayers>();
		__query_2070119446_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		__query_2070119446_1 = entityQueryBuilder2.Build(ref state);
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
		((SendRpcToNearbyPlayersSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003368_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SendRpcToNearbyPlayersSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SendRpcToNearbyPlayersSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
