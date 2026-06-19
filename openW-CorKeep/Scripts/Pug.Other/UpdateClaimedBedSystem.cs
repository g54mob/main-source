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

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct UpdateClaimedBedSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1897117119_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<ClaimedByCharacterGuidCD>, InternalCompilerInterface.UncheckedRefRW<ClaimedByPlayerGuidCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<ClaimedByCharacterGuidCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ClaimedByPlayerGuidCD>(item2_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<ClaimedByCharacterGuidCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ClaimedByPlayerGuidCD> item2_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ClaimedByCharacterGuidCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ClaimedByPlayerGuidCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<ClaimedByCharacterGuidCD>, InternalCompilerInterface.UncheckedRefRW<ClaimedByPlayerGuidCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<ClaimedByCharacterGuidCD>, InternalCompilerInterface.UncheckedRefRW<ClaimedByPlayerGuidCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<ClaimedByCharacterGuidCD>();
			state.EntityManager.CompleteDependencyBeforeRW<ClaimedByPlayerGuidCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1897117119_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public InternalCompilerInterface.UncheckedRefRO<CharacterClaimedBedCD> Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetUncheckedRefRO<CharacterClaimedBedCD>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<CharacterClaimedBedCD> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<CharacterClaimedBedCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<InternalCompilerInterface.UncheckedRefRO<CharacterClaimedBedCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public InternalCompilerInterface.UncheckedRefRO<CharacterClaimedBedCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<CharacterClaimedBedCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1897117119_0.TypeHandle __IFE_1897117119_0_TypeHandle;

		public IFE_1897117119_1.TypeHandle __IFE_1897117119_1_TypeHandle;

		[ReadOnly]
		public ComponentLookup<CharacterGuidCD> __CharacterGuidCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CharacterClaimedBedCD> __CharacterClaimedBedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGuidCD> __PlayerGuidCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerClaimedBed> __PlayerClaimedBed_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1897117119_0_TypeHandle = new IFE_1897117119_0.TypeHandle(ref state);
			__IFE_1897117119_1_TypeHandle = new IFE_1897117119_1.TypeHandle(ref state);
			__CharacterGuidCD_RO_ComponentLookup = state.GetComponentLookup<CharacterGuidCD>(isReadOnly: true);
			__CharacterClaimedBedCD_RO_ComponentLookup = state.GetComponentLookup<CharacterClaimedBedCD>(isReadOnly: true);
			__PlayerGuidCD_RO_ComponentLookup = state.GetComponentLookup<PlayerGuidCD>(isReadOnly: true);
			__PlayerClaimedBed_RO_ComponentLookup = state.GetComponentLookup<PlayerClaimedBed>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000045E3_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000045E3_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000045E3_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_1897117119_0;

	private EntityQuery __query_1897117119_1;

	private EntityQuery __query_1897117119_2;

	private EntityQuery __query_1897117119_3;

	private EntityQuery __query_1897117119_4;

	private EntityQuery __query_1897117119_5;

	private EntityQuery __query_1897117119_6;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityQuery _query_1897117119_ = __query_1897117119_2;
		EntityQuery _query_1897117119_2 = __query_1897117119_3;
		bool flag = !_query_1897117119_.IsEmpty;
		bool flag2 = !_query_1897117119_2.IsEmpty;
		if (!flag && !flag2)
		{
			return;
		}
		EntityCommandBuffer entityCommandBuffer = __query_1897117119_6.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		if (flag)
		{
			using NativeArray<Entity> nativeArray = __query_1897117119_4.ToEntityArray(Allocator.Temp);
			using NativeArray<Entity> nativeArray2 = __query_1897117119_5.ToEntityArray(Allocator.Temp);
			foreach (var (uncheckedRefRW, uncheckedRefRW2) in IFE_1897117119_0.Query(__query_1897117119_0, __TypeHandle.__IFE_1897117119_0_TypeHandle, ref state))
			{
				if (!uncheckedRefRW.ValueRO.isClaimed && !uncheckedRefRW2.ValueRO.isClaimed)
				{
					continue;
				}
				for (int i = 0; i < nativeArray.Length; i++)
				{
					Entity entity = nativeArray[i];
					if (InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__CharacterGuidCD_RO_ComponentLookup, ref state, entity).Value == uncheckedRefRW.ValueRO.characterGuid)
					{
						if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__CharacterClaimedBedCD_RO_ComponentLookup, ref state, entity))
						{
							entityCommandBuffer.SetComponent(entity, new CharacterClaimedBedCD
							{
								claimedBedEntity = Entity.Null
							});
						}
						break;
					}
				}
				for (int j = 0; j < nativeArray2.Length; j++)
				{
					Entity entity2 = nativeArray2[j];
					if (InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__PlayerGuidCD_RO_ComponentLookup, ref state, entity2).Value == uncheckedRefRW2.ValueRO.playerGuid)
					{
						if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__PlayerClaimedBed_RO_ComponentLookup, ref state, entity2))
						{
							entityCommandBuffer.SetComponent(entity2, new PlayerClaimedBed
							{
								claimedBedEntity = Entity.Null,
								position = default(float2)
							});
						}
						break;
					}
				}
				uncheckedRefRW.ValueRW = default(ClaimedByCharacterGuidCD);
				uncheckedRefRW2.ValueRW = default(ClaimedByPlayerGuidCD);
			}
		}
		if (!flag2)
		{
			return;
		}
		foreach (InternalCompilerInterface.UncheckedRefRO<CharacterClaimedBedCD> item in IFE_1897117119_1.Query(__query_1897117119_1, __TypeHandle.__IFE_1897117119_1_TypeHandle, ref state))
		{
			if (!(item.ValueRO.claimedBedEntity == Entity.Null))
			{
				entityCommandBuffer.SetComponent(item.ValueRO.claimedBedEntity, new ClaimedByCharacterGuidCD
				{
					characterGuid = default(Hash128)
				});
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<BedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ClaimedByCharacterGuidCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ClaimedByPlayerGuidCD>();
		__query_1897117119_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<CharacterClaimedBedCD>();
		__query_1897117119_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClaimedByCharacterGuidCD, ClaimedByPlayerGuidCD, EntityDestroyedCD, BedCD>();
		__query_1897117119_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CharacterClaimedBedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
		__query_1897117119_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CharacterGuidCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_1897117119_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGuidCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_1897117119_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1897117119_6 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnUpdate_000045E3_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UpdateClaimedBedSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateClaimedBedSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
