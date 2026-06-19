using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugScan;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	public class DungeonSpawnUniqueSystem : PugSimulationSystemBase
	{
		private struct SpawnEntryPrefabRefCD : IComponentData, IQueryTypeParameter
		{
			public Entity Value;
		}

		private struct AfterSpawnCleanup : ICleanupComponentData, IComponentData, IQueryTypeParameter
		{
			public Entity AreaEntity;

			public Entity LoadAreaEntity;
		}

		private struct HasPendingSpawns : IComponentData, IQueryTypeParameter
		{
			public int Count;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_490693096_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<ProceduralSpawnArea> Get(int index)
				{
					return new QueryEnumerableWithEntity<ProceduralSpawnArea>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ProceduralSpawnArea>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<ProceduralSpawnArea> item1_ComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
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

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ProceduralSpawnArea>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<ProceduralSpawnArea> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<ProceduralSpawnArea>();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_490693096_1
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public BufferAccessor<BlockedSpawnAreaBuffer> item2_BufferAccessor;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public (ProceduralSpawnArea, DynamicBuffer<BlockedSpawnAreaBuffer>) Get(int index)
				{
					return (InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ProceduralSpawnArea>(item1_IntPtr, index), item2_BufferAccessor[index]);
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<ProceduralSpawnArea> item1_ComponentTypeHandle_RO;

				private BufferTypeHandle<BlockedSpawnAreaBuffer> item2_BufferTypeHandle_RW;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
					item2_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<BlockedSpawnAreaBuffer>();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO.Update(ref systemState);
					item2_BufferTypeHandle_RW.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
						item2_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item2_BufferTypeHandle_RW)
					};
				}
			}

			public struct Enumerator : IEnumerator<(ProceduralSpawnArea, DynamicBuffer<BlockedSpawnAreaBuffer>)>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public (ProceduralSpawnArea, DynamicBuffer<BlockedSpawnAreaBuffer>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<ProceduralSpawnArea>();
				state.EntityManager.CompleteDependencyBeforeRW<BlockedSpawnAreaBuffer>();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_490693096_2
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public IntPtr item2_IntPtr;

				public IntPtr item3_IntPtr;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<LocalTransform, SpawnEntryPrefabRefCD, SpawnAreaEntityRefCD> Get(int index)
				{
					return new QueryEnumerableWithEntity<LocalTransform, SpawnEntryPrefabRefCD, SpawnAreaEntityRefCD>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<LocalTransform>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<SpawnEntryPrefabRefCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<SpawnAreaEntityRefCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<LocalTransform> item1_ComponentTypeHandle_RO;

				[ReadOnly]
				private ComponentTypeHandle<SpawnEntryPrefabRefCD> item2_ComponentTypeHandle_RO;

				[ReadOnly]
				private ComponentTypeHandle<SpawnAreaEntityRefCD> item3_ComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<SpawnEntryPrefabRefCD>(isReadOnly: true);
					item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<SpawnAreaEntityRefCD>(isReadOnly: true);
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO.Update(ref systemState);
					item2_ComponentTypeHandle_RO.Update(ref systemState);
					item3_ComponentTypeHandle_RO.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
						item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
						item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RO),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<LocalTransform, SpawnEntryPrefabRefCD, SpawnAreaEntityRefCD>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<LocalTransform, SpawnEntryPrefabRefCD, SpawnAreaEntityRefCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
				state.EntityManager.CompleteDependencyBeforeRO<SpawnEntryPrefabRefCD>();
				state.EntityManager.CompleteDependencyBeforeRO<SpawnAreaEntityRefCD>();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_490693096_3
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
		private readonly struct IFE_490693096_4
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<HasPendingSpawns> Get(int index)
				{
					return new QueryEnumerableWithEntity<HasPendingSpawns>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<HasPendingSpawns>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<HasPendingSpawns> item1_ComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<HasPendingSpawns>(isReadOnly: true);
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

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<HasPendingSpawns>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<HasPendingSpawns> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<HasPendingSpawns>();
			}
		}

		private struct TypeHandle
		{
			public IFE_490693096_0.TypeHandle __IFE_490693096_0_TypeHandle;

			public IFE_490693096_1.TypeHandle __IFE_490693096_1_TypeHandle;

			public IFE_490693096_2.TypeHandle __IFE_490693096_2_TypeHandle;

			public IFE_490693096_3.TypeHandle __IFE_490693096_3_TypeHandle;

			public IFE_490693096_4.TypeHandle __IFE_490693096_4_TypeHandle;

			[ReadOnly]
			public ComponentLookup<Disabled> __Unity_Entities_Disabled_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CanBeScannedCD> __CanBeScannedCD_RO_ComponentLookup;

			public ComponentLookup<HasPendingSpawns> __PugWorldGen_DungeonSpawnUniqueSystem_HasPendingSpawns_RW_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_490693096_0_TypeHandle = new IFE_490693096_0.TypeHandle(ref state);
				__IFE_490693096_1_TypeHandle = new IFE_490693096_1.TypeHandle(ref state);
				__IFE_490693096_2_TypeHandle = new IFE_490693096_2.TypeHandle(ref state);
				__IFE_490693096_3_TypeHandle = new IFE_490693096_3.TypeHandle(ref state);
				__IFE_490693096_4_TypeHandle = new IFE_490693096_4.TypeHandle(ref state);
				__Unity_Entities_Disabled_RO_ComponentLookup = state.GetComponentLookup<Disabled>(isReadOnly: true);
				__CanBeScannedCD_RO_ComponentLookup = state.GetComponentLookup<CanBeScannedCD>(isReadOnly: true);
				__PugWorldGen_DungeonSpawnUniqueSystem_HasPendingSpawns_RW_ComponentLookup = state.GetComponentLookup<HasPendingSpawns>();
			}
		}

		private EntityQuery _spawnPositionsQ;

		private EntityArchetype _spawnedDungeonArchetype;

		private EntityArchetype _loadAreaArchetype;

		private NativeParallelHashMap<FixedString32Bytes, Entity> _dungeonMarkers;

		private Entity _initialLoadingEntity;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_490693096_0;

		private EntityQuery __query_490693096_1;

		private EntityQuery __query_490693096_2;

		private EntityQuery __query_490693096_3;

		private EntityQuery __query_490693096_4;

		private EntityQuery __query_490693096_5;

		private EntityQuery __query_490693096_6;

		private EntityQuery __query_490693096_7;

		[Preserve]
		protected override void OnCreate()
		{
			UpdatesInRunGroup();
			AllowToRunBeforeInit();
			RequireForUpdate<UniqueDungeonSpawnPosition>();
			RequireForUpdate<UniqueDungeonInitDoneCD>();
			_spawnedDungeonArchetype = base.EntityManager.CreateArchetype(typeof(LocalTransform), typeof(DungeonNameSerializedCD));
			_spawnPositionsQ = base.EntityManager.CreateEntityQuery(typeof(SpawnUniqueDungeonAtAreaCD), typeof(ProceduralSpawnArea));
			_loadAreaArchetype = base.EntityManager.CreateArchetype(typeof(LocalTransform), typeof(KeepAreaLoadedCD), typeof(SpawnEntryPrefabRefCD), typeof(SpawnAreaEntityRefCD));
			_initialLoadingEntity = base.EntityManager.CreateEntity(typeof(InitialLoadingCD));
			EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
			entityQueryDesc.Any = new ComponentType[3]
			{
				ComponentType.ReadOnly<InitialLoadingCD>(),
				ComponentType.ReadOnly<SpawnUniqueDungeonAtAreaCD>(),
				ComponentType.ReadOnly<AfterSpawnCleanup>()
			};
			EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
			RequireForUpdate(GetEntityQuery(entityQueryDesc2));
			base.OnCreate();
		}

		[Preserve]
		protected override void OnStartRunning()
		{
			base.OnStartRunning();
			base.EntityManager.DestroyEntity(_initialLoadingEntity);
			_initialLoadingEntity = Entity.Null;
			if (_dungeonMarkers.IsCreated)
			{
				return;
			}
			using NativeArray<UniqueDungeonSpawnPosition> nativeArray = __query_490693096_5.GetSingletonBuffer<UniqueDungeonSpawnPosition>().ToNativeArray(Allocator.Temp);
			_dungeonMarkers = new NativeParallelHashMap<FixedString32Bytes, Entity>(nativeArray.Length, Allocator.Persistent);
			foreach (UniqueDungeonSpawnPosition item in nativeArray)
			{
				int2 position = item.Position;
				PugWorldGenCD spawnEntry = item.SpawnEntry;
				if (spawnEntry.markerEntity != Entity.Null && (!spawnEntry.destroyMarkerAfterSpawn || !item.HasBeenSpawned))
				{
					Entity entity = base.EntityManager.Instantiate(spawnEntry.markerEntity);
					base.EntityManager.SetComponentData(entity, LocalTransform.FromPosition(position.ToFloat3()));
					base.EntityManager.AddComponent<DontSerializeCD>(entity);
					_dungeonMarkers.Add(spawnEntry.name, entity);
				}
			}
		}

		[Preserve]
		protected override void OnDestroy()
		{
			if (_dungeonMarkers.IsCreated)
			{
				_dungeonMarkers.Dispose();
			}
			base.OnDestroy();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			if (!__query_490693096_6.HasSingleton<InitialLoadingDoneCD>())
			{
				return;
			}
			EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
			WorldGenerationType value = __query_490693096_7.GetSingleton<WorldGenerationTypeCD>().Value;
			if (value == WorldGenerationType.Creative)
			{
				base.EntityManager.AddComponent<LegacySpawnDungeonInAreaCD>(_spawnPositionsQ);
				base.EntityManager.RemoveComponent<SpawnUniqueDungeonAtAreaCD>(_spawnPositionsQ);
				base.OnUpdate();
				return;
			}
			EntityArchetype spawnedDungeonArchetype = _spawnedDungeonArchetype;
			DynamicBuffer<UniqueDungeonSpawnPosition> singletonBuffer = __query_490693096_5.GetSingletonBuffer<UniqueDungeonSpawnPosition>();
			Entity entity;
			SpawnEntryPrefabRefCD item2;
			SpawnAreaEntityRefCD item3;
			HasPendingSpawns item4;
			foreach (QueryEnumerableWithEntity<ProceduralSpawnArea> item9 in IFE_490693096_0.Query(__query_490693096_0, __TypeHandle.__IFE_490693096_0_TypeHandle, ref base.CheckedStateRef))
			{
				item9.Deconstruct(out var item, out entity);
				ProceduralSpawnArea proceduralSpawnArea = item;
				Entity entity2 = entity;
				int num = 0;
				PugGeometry.AxisAlignedBoundingBox b = PugGeometry.AxisAlignedBoundingBox.FromLowerCornerAndSize(proceduralSpawnArea.Position.ToFloat2(), proceduralSpawnArea.Size.x);
				for (int i = 0; i < singletonBuffer.Length; i++)
				{
					if (singletonBuffer[i].HasBeenSpawned)
					{
						continue;
					}
					int2 position = singletonBuffer[i].Position;
					PugGeometry.AxisAlignedBoundingBox a = PugGeometry.AxisAlignedBoundingBox.FromCenterAndRadius(position.ToFloat2(), singletonBuffer[i].SpawnEntry.radius);
					if (!singletonBuffer[i].SpawnEntry.spawnImmediatelyOnLoad && !PugGeometry.AxisAlignedBoundingBox.Overlaps(a, b))
					{
						continue;
					}
					PugWorldGenCD spawnEntry = singletonBuffer[i].SpawnEntry;
					Debug.Log($"Spawning {spawnEntry.name}");
					Entity e = entityCommandBuffer.CreateEntity(_loadAreaArchetype);
					entityCommandBuffer.SetComponent(e, LocalTransform.FromPosition(position.ToFloat3()));
					entityCommandBuffer.SetComponent(e, new KeepAreaLoadedCD
					{
						KeepLoadedRadius = spawnEntry.radius + 10,
						StartLoadRadius = spawnEntry.radius,
						ImmediateLoadRadius = spawnEntry.radius
					});
					item2 = new SpawnEntryPrefabRefCD
					{
						Value = spawnEntry.entity
					};
					entityCommandBuffer.SetComponent(e, item2);
					item3 = new SpawnAreaEntityRefCD
					{
						Value = entity2
					};
					entityCommandBuffer.SetComponent(e, item3);
					Entity e2 = entityCommandBuffer.CreateEntity(spawnedDungeonArchetype);
					entityCommandBuffer.SetComponent(e2, LocalTransform.FromPosition(position.ToFloat3()));
					entityCommandBuffer.SetComponent(e2, DungeonNameSerializedCD.FromFixedString32Bytes(spawnEntry.name));
					if (_dungeonMarkers.ContainsKey(spawnEntry.name) && spawnEntry.destroyMarkerAfterSpawn)
					{
						Debug.Log($"Removing fake marker for {spawnEntry.name}");
						Entity entity3 = _dungeonMarkers[spawnEntry.name];
						entityCommandBuffer.DestroyEntity(entity3);
						_dungeonMarkers.Remove(spawnEntry.name);
						if (!InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Entities_Disabled_RO_ComponentLookup, ref base.CheckedStateRef, entity3) && InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__CanBeScannedCD_RO_ComponentLookup, ref base.CheckedStateRef, entity3))
						{
							Debug.Log("Setting new object as scanned");
							Entity e3 = entityCommandBuffer.CreateEntity();
							entityCommandBuffer.AddComponent(e3, new PugScanCD
							{
								objectToScan = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__CanBeScannedCD_RO_ComponentLookup, ref base.CheckedStateRef, entity3).objectData
							});
						}
					}
					singletonBuffer.ElementAt(i).HasBeenSpawned = true;
					num++;
				}
				item4 = new HasPendingSpawns
				{
					Count = num
				};
				entityCommandBuffer.AddComponent(entity2, item4);
			}
			foreach (var item10 in IFE_490693096_1.Query(__query_490693096_1, __TypeHandle.__IFE_490693096_1_TypeHandle, ref base.CheckedStateRef))
			{
				ProceduralSpawnArea item5 = item10.Item1;
				DynamicBuffer<BlockedSpawnAreaBuffer> item6 = item10.Item2;
				PugGeometry.AxisAlignedBoundingBox b2 = PugGeometry.AxisAlignedBoundingBox.FromLowerCornerAndSize(item5.Position.ToFloat2(), item5.Size.x);
				foreach (UniqueDungeonSpawnPosition item11 in singletonBuffer)
				{
					if (PugGeometry.AxisAlignedBoundingBox.Overlaps(PugGeometry.AxisAlignedBoundingBox.FromCenterAndRadius(item11.Position.ToFloat2(), item11.SpawnEntry.radius), b2))
					{
						item6.Add(new BlockedSpawnAreaBuffer(item11.Position, item11.SpawnEntry.radius));
					}
				}
			}
			AfterSpawnCleanup item8;
			foreach (QueryEnumerableWithEntity<LocalTransform, SpawnEntryPrefabRefCD, SpawnAreaEntityRefCD> item12 in IFE_490693096_2.Query(__query_490693096_2, __TypeHandle.__IFE_490693096_2_TypeHandle, ref base.CheckedStateRef))
			{
				item12.Deconstruct(out var item7, out item2, out item3, out entity);
				LocalTransform component = item7;
				SpawnEntryPrefabRefCD spawnEntryPrefabRefCD = item2;
				SpawnAreaEntityRefCD spawnAreaEntityRefCD = item3;
				Entity entity4 = entity;
				Entity e4 = entityCommandBuffer.Instantiate(spawnEntryPrefabRefCD.Value);
				entityCommandBuffer.SetComponent(e4, component);
				item8 = new AfterSpawnCleanup
				{
					AreaEntity = spawnAreaEntityRefCD.Value,
					LoadAreaEntity = entity4
				};
				entityCommandBuffer.AddComponent(e4, item8);
				item3 = new SpawnAreaEntityRefCD
				{
					Value = spawnAreaEntityRefCD.Value
				};
				entityCommandBuffer.SetComponent(e4, item3);
				entityCommandBuffer.RemoveComponent<SpawnEntryPrefabRefCD>(entity4);
				entityCommandBuffer.RemoveComponent<SpawnAreaEntityRefCD>(entity4);
			}
			foreach (QueryEnumerableWithEntity<AfterSpawnCleanup> item13 in IFE_490693096_3.Query(__query_490693096_3, __TypeHandle.__IFE_490693096_3_TypeHandle, ref base.CheckedStateRef))
			{
				item13.Deconstruct(out item8, out entity);
				AfterSpawnCleanup afterSpawnCleanup = item8;
				Entity e5 = entity;
				InternalCompilerInterface.GetComponentRWAfterCompletingDependency(ref __TypeHandle.__PugWorldGen_DungeonSpawnUniqueSystem_HasPendingSpawns_RW_ComponentLookup, ref base.CheckedStateRef, afterSpawnCleanup.AreaEntity).ValueRW.Count--;
				entityCommandBuffer.DestroyEntity(afterSpawnCleanup.LoadAreaEntity);
				entityCommandBuffer.RemoveComponent<AfterSpawnCleanup>(e5);
			}
			foreach (QueryEnumerableWithEntity<HasPendingSpawns> item14 in IFE_490693096_4.Query(__query_490693096_4, __TypeHandle.__IFE_490693096_4_TypeHandle, ref base.CheckedStateRef))
			{
				item14.Deconstruct(out item4, out entity);
				HasPendingSpawns hasPendingSpawns = item4;
				Entity e6 = entity;
				if (hasPendingSpawns.Count == 0)
				{
					entityCommandBuffer.RemoveComponent<SpawnUniqueDungeonAtAreaCD>(e6);
					entityCommandBuffer.RemoveComponent<HasPendingSpawns>(e6);
					if (value == WorldGenerationType.Classic)
					{
						entityCommandBuffer.AddComponent<LegacySpawnDungeonInAreaCD>(e6);
					}
					else
					{
						entityCommandBuffer.AddComponent<SpawnDungeonsAndScenesInArea>(e6);
					}
				}
			}
			entityCommandBuffer.Playback(base.EntityManager);
			entityCommandBuffer.Dispose();
			base.OnUpdate();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<HasPendingSpawns>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<SpawnUniqueDungeonAtAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ProceduralSpawnArea>();
			__query_490693096_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithNone<HasPendingSpawns>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<SpawnUniqueDungeonAtAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ProceduralSpawnArea>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BlockedSpawnAreaBuffer>();
			__query_490693096_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<KeepAreaLoadedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<AreaLoadedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<SpawnEntryPrefabRefCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<SpawnAreaEntityRefCD>();
			__query_490693096_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithNone<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<AfterSpawnCleanup>();
			__query_490693096_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnUniqueDungeonAtAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<HasPendingSpawns>();
			__query_490693096_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAllRW<UniqueDungeonSpawnPosition>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_490693096_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InitialLoadingDoneCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_490693096_6 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_490693096_7 = entityQueryBuilder2.Build(ref state);
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
		public DungeonSpawnUniqueSystem()
		{
		}
	}
}
