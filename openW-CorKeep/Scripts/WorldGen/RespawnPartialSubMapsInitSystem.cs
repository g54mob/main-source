using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using PugWorldGen;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct RespawnPartialSubMapsInitSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_126642942_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<SubMapCD>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<SubMapCD>>(InternalCompilerInterface.UnsafeGetUncheckedRefRO<SubMapCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<SubMapCD> item1_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<SubMapCD>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<SubMapCD>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<SubMapCD>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<SubMapCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_126642942_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public BufferAccessor<SubMapLayerBuffer> item2_BufferAccessor;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<SubMapCD>(item1_IntPtr, index), item2_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<SubMapCD> item1_ComponentTypeHandle_RW;

			private BufferTypeHandle<SubMapLayerBuffer> item2_BufferTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<SubMapCD>();
				item2_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<SubMapLayerBuffer>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_BufferTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item2_BufferTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<SubMapCD>();
			state.EntityManager.CompleteDependencyBeforeRW<SubMapLayerBuffer>();
		}
	}

	private struct TypeHandle
	{
		public IFE_126642942_0.TypeHandle __IFE_126642942_0_TypeHandle;

		public IFE_126642942_1.TypeHandle __IFE_126642942_1_TypeHandle;

		public BufferLookup<SubMapLayerBuffer> __SubMapLayerBuffer_RW_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_126642942_0_TypeHandle = new IFE_126642942_0.TypeHandle(ref state);
			__IFE_126642942_1_TypeHandle = new IFE_126642942_1.TypeHandle(ref state);
			__SubMapLayerBuffer_RW_BufferLookup = state.GetBufferLookup<SubMapLayerBuffer>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00000070_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000070_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000070_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_00000071_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00000071_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00000071_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	private EntityArchetype _newAreaSpawnCellArchetype;

	private EntityArchetype _respawnAreaSpawnCellArchetype;

	private NativeHashSet<int2> _triggeredSpawnCells;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_126642942_0;

	private EntityQuery __query_126642942_1;

	private EntityQuery __query_126642942_2;

	private EntityQuery __query_126642942_3;

	private EntityQuery __query_126642942_4;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<WorldGenerationTypeCD>();
		state.RequireForUpdate<WorldHasBeenDeserializedCD>();
		state.RequireForUpdate<UniqueDungeonInitDoneCD>();
		state.RequireForUpdate<UniqueDungeonSpawnPosition>();
		state.RequireForUpdate(__query_126642942_2);
		_newAreaSpawnCellArchetype = state.EntityManager.CreateArchetype(ComponentType.ReadOnly<ProceduralSpawnArea>(), ComponentType.ReadOnly<SpawnUniqueDungeonAtAreaCD>(), ComponentType.ReadOnly<BlockedSpawnAreaBuffer>(), ComponentType.ReadOnly<BlockSaveCD>());
		_respawnAreaSpawnCellArchetype = state.EntityManager.CreateArchetype(ComponentType.ReadOnly<ProceduralSpawnArea>(), ComponentType.ReadOnly<SpawnUniqueDungeonAtAreaCD>(), ComponentType.ReadOnly<BlockedSpawnAreaBuffer>(), ComponentType.ReadOnly<PartialRespawnArea>(), ComponentType.ReadOnly<BlockSaveCD>());
		_triggeredSpawnCells = new NativeHashSet<int2>(0, Allocator.Persistent);
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		if (_triggeredSpawnCells.IsCreated)
		{
			_triggeredSpawnCells.Dispose();
		}
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
		if (__query_126642942_3.GetSingleton<WorldGenerationTypeCD>().Value != WorldGenerationType.FullRelease)
		{
			state.Enabled = false;
			return;
		}
		NativeHashMap<int2, Entity> nativeHashMap = new NativeHashMap<int2, Entity>(1024, Allocator.Temp);
		Entity entity;
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<SubMapCD>> item6 in IFE_126642942_0.Query(__query_126642942_0, __TypeHandle.__IFE_126642942_0_TypeHandle, ref state))
		{
			item6.Deconstruct(out var item, out entity);
			InternalCompilerInterface.UncheckedRefRO<SubMapCD> uncheckedRefRO = item;
			Entity item2 = entity;
			nativeHashMap.TryAdd(uncheckedRefRO.ValueRO.index, item2);
		}
		NativeHashSet<int2> nativeHashSet = new NativeHashSet<int2>(64, Allocator.Temp);
		foreach (UniqueDungeonSpawnPosition item7 in __query_126642942_4.GetSingletonBuffer<UniqueDungeonSpawnPosition>())
		{
			if (!item7.HasBeenSpawned)
			{
				int2 subMapIndex = GetSubMapIndex(item7.Position);
				int2 spawnCellIndex = GetSpawnCellIndex(subMapIndex);
				nativeHashSet.Add(spawnCellIndex);
			}
		}
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SubMapCD>, DynamicBuffer<SubMapLayerBuffer>> item8 in IFE_126642942_1.Query(__query_126642942_1, __TypeHandle.__IFE_126642942_1_TypeHandle, ref state))
		{
			item8.Deconstruct(out var item3, out var _, out entity);
			InternalCompilerInterface.UncheckedRefRW<SubMapCD> uncheckedRefRW = item3;
			Entity e = entity;
			ref SubMapCD valueRW = ref uncheckedRefRW.ValueRW;
			int2 int5 = valueRW.index * 64;
			entityCommandBuffer.AddComponent(e, LocalTransform.FromPosition(int5.ToFloat3()));
			entityCommandBuffer.AddComponent(e, new ProceduralSpawnArea
			{
				Position = int5,
				Size = 64
			});
			int2 spawnCellIndex2 = GetSpawnCellIndex(valueRW.index);
			if (_triggeredSpawnCells.Contains(spawnCellIndex2))
			{
				continue;
			}
			_triggeredSpawnCells.Add(spawnCellIndex2);
			if (valueRW.wasCreatedThisSession)
			{
				Entity e2 = entityCommandBuffer.CreateEntity(_newAreaSpawnCellArchetype);
				entityCommandBuffer.SetComponent(e2, new ProceduralSpawnArea
				{
					Position = spawnCellIndex2 * 256 - 128,
					Size = 256
				});
				continue;
			}
			SubMapLayer sl = default(SubMapLayer);
			int2 int6 = (spawnCellIndex2 << 2) - 2;
			bool flag = false;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					int2 int7 = new int2(j, i);
					int2 key = int6 + int7;
					SubMapLayer hasMissingTile = default(SubMapLayer);
					if (!nativeHashMap.TryGetValue(key, out var item5))
					{
						hasMissingTile = hasMissingTile.Invert();
						flag = true;
					}
					else if (HasMissingTiles(InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__SubMapLayerBuffer_RW_BufferLookup, ref state, item5), out hasMissingTile))
					{
						flag = true;
					}
					int num = 16;
					for (int k = 0; k < num; k++)
					{
						for (int l = 0; l < num; l++)
						{
							int2 int8 = new int2(l, k) << 2;
							bool flag2 = true;
							for (int m = 0; m < 4; m++)
							{
								for (int n = 0; n < 4; n++)
								{
									int2 pos = int8 + new int2(n, m);
									if (!hasMissingTile.Get(pos))
									{
										flag2 = false;
										break;
									}
								}
							}
							if (flag2)
							{
								sl.Set(int7 * num + new int2(l, k));
							}
						}
					}
				}
			}
			if (nativeHashSet.Contains(spawnCellIndex2))
			{
				flag = true;
			}
			if (flag)
			{
				Entity e3 = entityCommandBuffer.CreateEntity(_respawnAreaSpawnCellArchetype);
				entityCommandBuffer.SetComponent(e3, new ProceduralSpawnArea
				{
					Position = spawnCellIndex2 * 256 - 128,
					Size = 256
				});
				entityCommandBuffer.SetComponent(e3, new PartialRespawnArea
				{
					LowResShouldRespawnFlags = sl
				});
			}
		}
		entityCommandBuffer.Playback(state.EntityManager);
		entityCommandBuffer.Dispose();
	}

	private int2 GetSubMapIndex(int2 worldPosition)
	{
		return (worldPosition & -64) >> 6;
	}

	private int2 GetSpawnCellIndex(int2 submapIndex)
	{
		int num = 2;
		return submapIndex + num >> 2;
	}

	private bool HasMissingTiles(DynamicBuffer<SubMapLayerBuffer> layerBuffer, out SubMapLayer hasMissingTile)
	{
		SubMapLayer sl = default(SubMapLayer);
		for (int i = 0; i < layerBuffer.Length; i++)
		{
			if (!layerBuffer[i].data.layer.tileType.ShouldNotExistOnItsOwn())
			{
				for (int j = 0; j < 64; j++)
				{
					sl.Row(j) |= layerBuffer[i].data.GetRow(j);
				}
			}
		}
		hasMissingTile = sl.Invert();
		for (int k = 0; k < 64; k++)
		{
			if (hasMissingTile.GetRow(k) != 0L)
			{
				return true;
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SubMapCD>();
		__query_126642942_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<ProceduralSpawnArea>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SubMapCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SubMapLayerBuffer>();
		__query_126642942_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SubMapCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<ProceduralSpawnArea>();
		__query_126642942_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_126642942_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<UniqueDungeonSpawnPosition>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_126642942_4 = entityQueryBuilder2.Build(ref state);
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
		((RespawnPartialSubMapsInitSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000070_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00000071_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((RespawnPartialSubMapsInitSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RespawnPartialSubMapsInitSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RespawnPartialSubMapsInitSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}
