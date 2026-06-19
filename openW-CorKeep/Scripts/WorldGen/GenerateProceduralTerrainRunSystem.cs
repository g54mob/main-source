using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class GenerateProceduralTerrainRunSystem : PugSimulationSystemBase
{
	[InternalBufferCapacity(16)]
	private struct PendingSubMap : IBufferElementData
	{
		public int2 BasePosition;
	}

	private struct AfterSpawnCleanup : ICleanupComponentData, IComponentData, IQueryTypeParameter
	{
		public Entity SpawnCellEntity;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_84466282_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<AfterSpawnCleanup> Get(int index)
			{
				return new QueryEnumerableWithEntity<AfterSpawnCleanup>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<AfterSpawnCleanup>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<AfterSpawnCleanup> item1_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<AfterSpawnCleanup>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<AfterSpawnCleanup>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<AfterSpawnCleanup> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<AfterSpawnCleanup>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_84466282_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SpawnProceduralInAreaCD>, ProceduralSpawnArea> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SpawnProceduralInAreaCD>, ProceduralSpawnArea>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<SpawnProceduralInAreaCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ProceduralSpawnArea>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<SpawnProceduralInAreaCD> item1_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<ProceduralSpawnArea> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<SpawnProceduralInAreaCD>();
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SpawnProceduralInAreaCD>, ProceduralSpawnArea>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<SpawnProceduralInAreaCD>, ProceduralSpawnArea> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<SpawnProceduralInAreaCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ProceduralSpawnArea>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_84466282_2
	{
		public struct ResolvedChunk
		{
			public BufferAccessor<PendingSubMap> item1_BufferAccessor;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<DynamicBuffer<PendingSubMap>> Get(int index)
			{
				return new QueryEnumerableWithEntity<DynamicBuffer<PendingSubMap>>(item1_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<PendingSubMap> item1_BufferTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<PendingSubMap>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item1_BufferTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<DynamicBuffer<PendingSubMap>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<DynamicBuffer<PendingSubMap>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<PendingSubMap>();
		}
	}

	private struct TypeHandle
	{
		public IFE_84466282_0.TypeHandle __IFE_84466282_0_TypeHandle;

		public IFE_84466282_1.TypeHandle __IFE_84466282_1_TypeHandle;

		public IFE_84466282_2.TypeHandle __IFE_84466282_2_TypeHandle;

		public ComponentLookup<SpawnProceduralInAreaCD> __SpawnProceduralInAreaCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_84466282_0_TypeHandle = new IFE_84466282_0.TypeHandle(ref state);
			__IFE_84466282_1_TypeHandle = new IFE_84466282_1.TypeHandle(ref state);
			__IFE_84466282_2_TypeHandle = new IFE_84466282_2.TypeHandle(ref state);
			__SpawnProceduralInAreaCD_RW_ComponentLookup = state.GetComponentLookup<SpawnProceduralInAreaCD>();
		}
	}

	private const float TARGET_SPAWN_DELAY_SECONDS = 2f;

	private const int MAX_CONCURRENT_SUB_MAP_REQUESTS = 4;

	private EntityArchetype _subAreaArchetype;

	private WorldGenManager.ProceduralDataRequester _areaRequester;

	private TileAccessor _tileAccessor;

	private NativeHashMap<int, Entity> _requestToEntity;

	private RateLimiter _rateLimiter;

	private int _pendingSubMapRequests;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_84466282_0;

	private EntityQuery __query_84466282_1;

	private EntityQuery __query_84466282_2;

	private EntityQuery __query_84466282_3;

	private EntityQuery __query_84466282_4;

	private EntityQuery __query_84466282_5;

	private EntityQuery __query_84466282_6;

	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		RequireForUpdate<SubMapRegistry>();
		_requestToEntity = new NativeHashMap<int, Entity>(16, Allocator.Persistent);
		_areaRequester = Manager.worldGen.CreateProceduralDataRequester(4096, 4);
		_subAreaArchetype = base.EntityManager.CreateArchetype(typeof(ProceduralTerrainDataCD), typeof(AfterSpawnCleanup));
		int maxTicksToProcessAll = (int)math.floor((float)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate * 2f);
		_rateLimiter = new RateLimiter(maxTicksToProcessAll);
	}

	[Preserve]
	protected override void OnDestroy()
	{
		_requestToEntity.Dispose();
		_areaRequester.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		base.OnStartRunning();
		_tileAccessor = new TileAccessor(ref base.CheckedStateRef);
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (__query_84466282_5.GetSingleton<WorldGenerationTypeCD>().Value != WorldGenerationType.FullRelease)
		{
			return;
		}
		_tileAccessor.Update(ref base.CheckedStateRef);
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
		Entity entity;
		foreach (QueryEnumerableWithEntity<AfterSpawnCleanup> item6 in IFE_84466282_0.Query(__query_84466282_0, __TypeHandle.__IFE_84466282_0_TypeHandle, ref base.CheckedStateRef))
		{
			item6.Deconstruct(out var item, out entity);
			AfterSpawnCleanup afterSpawnCleanup = item;
			Entity e = entity;
			entityCommandBuffer.RemoveComponent<AfterSpawnCleanup>(e);
			ref SpawnProceduralInAreaCD valueRW = ref InternalCompilerInterface.GetComponentRWAfterCompletingDependency(ref __TypeHandle.__SpawnProceduralInAreaCD_RW_ComponentLookup, ref base.CheckedStateRef, afterSpawnCleanup.SpawnCellEntity).ValueRW;
			valueRW.PendingSubAreas--;
			if (valueRW.PendingSubAreas == 0)
			{
				entityCommandBuffer.RemoveComponent<SpawnProceduralInAreaCD>(afterSpawnCleanup.SpawnCellEntity);
				entityCommandBuffer.RemoveComponent<PendingSubMap>(afterSpawnCleanup.SpawnCellEntity);
				entityCommandBuffer.AddComponent<SpawnRootsInAreaCD>(afterSpawnCleanup.SpawnCellEntity);
			}
			_pendingSubMapRequests--;
		}
		entityCommandBuffer.Playback(base.EntityManager);
		if (__query_84466282_3.IsEmpty)
		{
			EntityCommandBuffer entityCommandBuffer2 = new EntityCommandBuffer(Allocator.Temp);
			using (IFE_84466282_1.Enumerator enumerator2 = IFE_84466282_1.Query(__query_84466282_1, __TypeHandle.__IFE_84466282_1_TypeHandle, ref base.CheckedStateRef).GetEnumerator())
			{
				if (enumerator2.MoveNext())
				{
					enumerator2.Current.Deconstruct(out var item2, out var item3, out entity);
					InternalCompilerInterface.UncheckedRefRW<SpawnProceduralInAreaCD> uncheckedRefRW = item2;
					ProceduralSpawnArea proceduralSpawnArea = item3;
					Entity e2 = entity;
					ref SpawnProceduralInAreaCD valueRW2 = ref uncheckedRefRW.ValueRW;
					Entity singletonEntity = __query_84466282_6.GetSingletonEntity();
					entityCommandBuffer2.AddBuffer<PendingSubMap>(e2);
					for (int i = 0; i < proceduralSpawnArea.Size.y; i += 64)
					{
						for (int j = 0; j < proceduralSpawnArea.Size.x; j += 64)
						{
							int2 int5 = proceduralSpawnArea.Position + new int2(j, i);
							entityCommandBuffer2.AppendToBuffer(e2, new PendingSubMap
							{
								BasePosition = int5
							});
							if (!_tileAccessor.IsInitialized(int5))
							{
								entityCommandBuffer2.AppendToBuffer(singletonEntity, new TileUpdateBuffer
								{
									command = TileUpdateBuffer.Command.Add,
									position = int5
								});
							}
							valueRW2.PendingSubAreas++;
						}
					}
				}
			}
			entityCommandBuffer2.Playback(base.EntityManager);
		}
		int currentPending = __query_84466282_4.CalculateEntityCount() * 16;
		int x = _rateLimiter.UpdateAndGetCurrentTarget(currentPending);
		x = math.min(x, 4 - _pendingSubMapRequests);
		int num = 0;
		foreach (QueryEnumerableWithEntity<DynamicBuffer<PendingSubMap>> item7 in IFE_84466282_2.Query(__query_84466282_2, __TypeHandle.__IFE_84466282_2_TypeHandle, ref base.CheckedStateRef))
		{
			item7.Deconstruct(out var item4, out entity);
			DynamicBuffer<PendingSubMap> dynamicBuffer = item4;
			Entity item5 = entity;
			if (dynamicBuffer.IsEmpty)
			{
				continue;
			}
			while (dynamicBuffer.Length != 0 && num < x)
			{
				PendingSubMap pendingSubMap = dynamicBuffer[dynamicBuffer.Length - 1];
				int num2 = _areaRequester.RequestArea(pendingSubMap.BasePosition.ToVec2Int(), Vector2.one * 64f, 1);
				if (num2 >= 0)
				{
					_requestToEntity.Add(num2, item5);
					dynamicBuffer.RemoveAt(dynamicBuffer.Length - 1);
					_pendingSubMapRequests++;
					num++;
					continue;
				}
				Debug.LogError("Failed to request submap.");
				break;
			}
		}
		EntityCommandBuffer entityCommandBuffer3 = new EntityCommandBuffer(Allocator.Temp);
		WorldGenManager.AreaRequestResult result;
		while (_areaRequester.TryGetAreaRequestResult(out result))
		{
			Entity spawnCellEntity = _requestToEntity[result.Index];
			_requestToEntity.Remove(result.Index);
			int2 int6 = result.ViewPortBase.RoundToInt().ToInt2();
			Entity e3 = entityCommandBuffer3.CreateEntity(_subAreaArchetype);
			entityCommandBuffer3.SetComponent(e3, new ProceduralTerrainDataCD
			{
				Position = int6,
				Size = result.ViewPortSize.RoundToInt().ToInt2(),
				SubMapEntity = _tileAccessor.GetSubMapEntity(int6),
				Data = result.Data
			});
			entityCommandBuffer3.SetComponent(e3, new AfterSpawnCleanup
			{
				SpawnCellEntity = spawnCellEntity
			});
		}
		entityCommandBuffer3.Playback(base.EntityManager);
		base.OnUpdate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<ProceduralTerrainDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AfterSpawnCleanup>();
		__query_84466282_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<PendingSubMap>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ProceduralSpawnArea>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SpawnProceduralInAreaCD>();
		__query_84466282_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PendingSubMap>();
		__query_84466282_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PendingSubMap>();
		__query_84466282_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnProceduralInAreaCD>();
		__query_84466282_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_84466282_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_84466282_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public GenerateProceduralTerrainRunSystem()
	{
	}
}
