using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct TileCrackSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_554165310_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public CrackableTileCleanupCD Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<CrackableTileCleanupCD>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<CrackableTileCleanupCD> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<CrackableTileCleanupCD>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<CrackableTileCleanupCD>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public CrackableTileCleanupCD Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<CrackableTileCleanupCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_554165310_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<CrackableTileCD, LocalTransform> Get(int index)
			{
				return new QueryEnumerableWithEntity<CrackableTileCD, LocalTransform>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<CrackableTileCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<LocalTransform>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<CrackableTileCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<LocalTransform> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<CrackableTileCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<CrackableTileCD, LocalTransform>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<CrackableTileCD, LocalTransform> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<CrackableTileCD>();
			state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_554165310_2
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<CrackableTileCD>, LocalTransform, HealthCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<CrackableTileCD>, LocalTransform, HealthCD>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<CrackableTileCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<LocalTransform>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<HealthCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<CrackableTileCD> item1_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<LocalTransform> item2_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<HealthCD> item3_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<CrackableTileCD>();
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				item3_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<CrackableTileCD>, LocalTransform, HealthCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<CrackableTileCD>, LocalTransform, HealthCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<CrackableTileCD>();
			state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
			state.EntityManager.CompleteDependencyBeforeRO<HealthCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_554165310_0.TypeHandle __IFE_554165310_0_TypeHandle;

		public IFE_554165310_1.TypeHandle __IFE_554165310_1_TypeHandle;

		public IFE_554165310_2.TypeHandle __IFE_554165310_2_TypeHandle;

		public ComponentLookup<ActiveCracksCD> __ActiveCracksCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_554165310_0_TypeHandle = new IFE_554165310_0.TypeHandle(ref state);
			__IFE_554165310_1_TypeHandle = new IFE_554165310_1.TypeHandle(ref state);
			__IFE_554165310_2_TypeHandle = new IFE_554165310_2.TypeHandle(ref state);
			__ActiveCracksCD_RW_ComponentLookup = state.GetComponentLookup<ActiveCracksCD>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00004325_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00004325_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00004325_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_554165310_0;

	private EntityQuery __query_554165310_1;

	private EntityQuery __query_554165310_2;

	private EntityQuery __query_554165310_3;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
	}

	public void OnUpdate(ref SystemState state)
	{
		EntityQuery _query_554165310_ = __query_554165310_3;
		if (Manager.sceneHandler == null || !Manager.sceneHandler.isInGame || Manager.multiMap == null)
		{
			state.EntityManager.RemoveComponent<CrackableTileCleanupCD>(_query_554165310_);
			return;
		}
		SinglePugMap multiMap = Manager.multiMap;
		foreach (CrackableTileCleanupCD item5 in IFE_554165310_0.Query(__query_554165310_0, __TypeHandle.__IFE_554165310_0_TypeHandle, ref state))
		{
			multiMap.ClearTileOfType(item5.tilePos, item5.tileType);
		}
		state.EntityManager.RemoveComponent<CrackableTileCleanupCD>(_query_554165310_);
		ComponentLookup<ActiveCracksCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ActiveCracksCD_RW_ComponentLookup, ref state);
		LocalTransform item2;
		Entity entity;
		foreach (QueryEnumerableWithEntity<CrackableTileCD, LocalTransform> item6 in IFE_554165310_1.Query(__query_554165310_1, __TypeHandle.__IFE_554165310_1_TypeHandle, ref state))
		{
			item6.Deconstruct(out var item, out item2, out entity);
			CrackableTileCD crackableTileCD = item;
			LocalTransform localTransform = item2;
			Entity entity2 = entity;
			int2 worldPosition = localTransform.Position.RoundToInt2();
			multiMap.ClearTileOfType(worldPosition, crackableTileCD.crackTileType);
			componentLookup.SetComponentEnabled(entity2, value: false);
		}
		TileAccessor tileAccessor = new TileAccessor(ref state);
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<CrackableTileCD>, LocalTransform, HealthCD> item7 in IFE_554165310_2.Query(__query_554165310_2, __TypeHandle.__IFE_554165310_2_TypeHandle, ref state))
		{
			item7.Deconstruct(out var item3, out item2, out var item4, out entity);
			InternalCompilerInterface.UncheckedRefRW<CrackableTileCD> uncheckedRefRW = item3;
			LocalTransform localTransform2 = item2;
			HealthCD healthCD = item4;
			Entity entity3 = entity;
			ref CrackableTileCD valueRW = ref uncheckedRefRW.ValueRW;
			int2 worldPosition2 = localTransform2.Position.RoundToInt2();
			int num = (tileAccessor.HasType(worldPosition2, valueRW.baseTileType) ? GetCrackLevel((float)healthCD.health / (float)healthCD.maxHealth) : 0);
			if (valueRW.currentLevel != num)
			{
				if (num == 0)
				{
					multiMap.ClearTileOfType(localTransform2.Position.RoundToInt2(), valueRW.crackTileType);
					componentLookup.SetComponentEnabled(entity3, value: false);
				}
				else
				{
					multiMap.SetTile(worldPosition2, (int)valueRW.crackTileset, valueRW.crackTileType, num - 1);
					componentLookup.SetComponentEnabled(entity3, value: true);
				}
				valueRW.currentLevel = num;
			}
		}
	}

	private static int GetCrackLevel(float healthNormalized)
	{
		if (healthNormalized <= 0f)
		{
			return 0;
		}
		if (healthNormalized <= 0.33f)
		{
			return 3;
		}
		if (healthNormalized <= 0.67f)
		{
			return 2;
		}
		if (healthNormalized < 0.999f)
		{
			return 1;
		}
		return 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<CrackableTileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<CrackableTileCleanupCD>();
		__query_554165310_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ActiveCracksCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<CrackableTileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		__query_554165310_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CrackableTileCD>();
		__query_554165310_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CrackableTileCleanupCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<CrackableTileCD>();
		__query_554165310_3 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00004325_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((TileCrackSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((TileCrackSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((TileCrackSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}
}
