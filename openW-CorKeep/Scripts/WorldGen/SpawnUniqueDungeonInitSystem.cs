using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using PugWorldGen;
using PugWorldGen.CoreKeeper;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class SpawnUniqueDungeonInitSystem : SystemBase
{
	private struct SpawnArea
	{
		public int2 BasePosition;

		public int2 Size;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct Trigger : IComponentData, IQueryTypeParameter
	{
	}

	private enum State
	{
		Idle = 0,
		WaitingForPoints = 1,
		WaitingForArea = 2
	}

	private struct SpawnCandidate
	{
		public struct Score : IComparable<Score>
		{
			public int IsInUnexploredArea;

			public int BiomeMatch;

			public float Distance;

			public int CompareTo(Score other)
			{
				if (BiomeMatch != other.BiomeMatch)
				{
					return BiomeMatch.CompareTo(other.BiomeMatch);
				}
				if (IsInUnexploredArea != other.IsInUnexploredArea)
				{
					return IsInUnexploredArea.CompareTo(other.IsInUnexploredArea);
				}
				return Distance.CompareTo(other.Distance);
			}

			public override string ToString()
			{
				return $"Score(BiomeMatch: {BiomeMatch}, IsInUnexploredArea: {IsInUnexploredArea}, Distance: {Distance})";
			}
		}

		public int2 Position;

		public Score PlacementScore;

		public PugWorldGenCD SpawnEntry;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2094639253_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (LocalTransform, DungeonNameSerializedCD) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<LocalTransform>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<DungeonNameSerializedCD>(item2_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<LocalTransform> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<DungeonNameSerializedCD> item2_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<DungeonNameSerializedCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(LocalTransform, DungeonNameSerializedCD)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (LocalTransform, DungeonNameSerializedCD) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<DungeonNameSerializedCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2094639253_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public SubMapCD Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<SubMapCD>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<SubMapCD> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<SubMapCD>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<SubMapCD>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public SubMapCD Current => _resolvedChunk.Get(_currentEntityIndex);

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
	private readonly struct IFE_2094639253_2
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<PugWorldGenCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<PugWorldGenCD>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<PugWorldGenCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<PugWorldGenCD> item1_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PugWorldGenCD>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<PugWorldGenCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<PugWorldGenCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<PugWorldGenCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_2094639253_0.TypeHandle __IFE_2094639253_0_TypeHandle;

		public IFE_2094639253_1.TypeHandle __IFE_2094639253_1_TypeHandle;

		public IFE_2094639253_2.TypeHandle __IFE_2094639253_2_TypeHandle;

		[ReadOnly]
		public ComponentLookup<BossLarvaCD> __BossLarvaCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PugWorldGenCD> __PugWorldGen_PugWorldGenCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_2094639253_0_TypeHandle = new IFE_2094639253_0.TypeHandle(ref state);
			__IFE_2094639253_1_TypeHandle = new IFE_2094639253_1.TypeHandle(ref state);
			__IFE_2094639253_2_TypeHandle = new IFE_2094639253_2.TypeHandle(ref state);
			__BossLarvaCD_RO_ComponentLookup = state.GetComponentLookup<BossLarvaCD>(isReadOnly: true);
			__PugWorldGen_PugWorldGenCD_RO_ComponentLookup = state.GetComponentLookup<PugWorldGenCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void ComputeBiomeBounds_0000011A_0024PostfixBurstDelegate(in BiomeSamplesCD biomeSamples, ref NativeArray<SpawnArea> bounds);

	internal static class ComputeBiomeBounds_0000011A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ComputeBiomeBounds_0000011A_0024PostfixBurstDelegate>(ComputeBiomeBounds).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in BiomeSamplesCD biomeSamples, ref NativeArray<SpawnArea> bounds)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref BiomeSamplesCD, ref NativeArray<SpawnArea>, void>)functionPointer)(ref biomeSamples, ref bounds);
					return;
				}
			}
			ComputeBiomeBounds_0024BurstManaged(in biomeSamples, ref bounds);
		}
	}

	private const int MAX_SAMPLING_ATTEMPTS = 10000;

	private const int SEED_DEPENDENT_STARTING_RANGE = 100000;

	private const int TARGET_CANDIDATE_POINTS = 500;

	private const int POINT_SAMPLES_PER_CANDIDATE = 5;

	private WorldGenManager.ProceduralDataRequester _proceduralDataRequester;

	private PugRandom.HaltonSequenceGenerator2D _haltonSequenceGenerator;

	private NativeHashMap<FixedString32Bytes, int2> _existingDungeonPositions;

	private NativeHashSet<int2> _existingSubMapIndices;

	private NativeArray<SpawnArea> _biomeBounds;

	private SpawnArea _ring4Area;

	private StaticallyBlockedAreas _staticallyBlockedAreas;

	private NativePriorityQueue<Entity> _spawnEntryQueue;

	private NativeList<SpawnCandidate> _spawnCandidates;

	private State _state;

	private int _pendingRequests;

	private List<PugWorld.DebugMarker> _debugMarkers = new List<PugWorld.DebugMarker>();

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2094639253_0;

	private EntityQuery __query_2094639253_1;

	private EntityQuery __query_2094639253_2;

	private EntityQuery __query_2094639253_3;

	private EntityQuery __query_2094639253_4;

	private EntityQuery __query_2094639253_5;

	private EntityQuery __query_2094639253_6;

	private EntityQuery __query_2094639253_7;

	private EntityQuery __query_2094639253_8;

	private EntityQuery __query_2094639253_9;

	private EntityQuery __query_2094639253_10;

	private EntityQuery __query_2094639253_11;

	private EntityQuery __query_2094639253_12;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<WorldHasBeenDeserializedCD>();
		RequireForUpdate<PugWorldGenCD>();
		RequireForUpdate<WorldGenerationTypeCD>();
		RequireForUpdate<Trigger>();
		RequireForUpdate<WorldScaleCD>();
		RequireForUpdate<PugDatabase.DatabaseBankCD>();
		RequireForUpdate<BiomeSamplesCD>();
		_haltonSequenceGenerator = default(PugRandom.HaltonSequenceGenerator2D);
		_state = State.Idle;
		base.EntityManager.CreateSingleton<Trigger>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		if (__query_2094639253_4.GetSingleton<WorldGenerationTypeCD>().Value != WorldGenerationType.FullRelease || _proceduralDataRequester.IsCreated)
		{
			return;
		}
		int steps = PugRandom.GetRng(__query_2094639253_5.GetSingleton<ServerSeedCD>().Value).NextInt(100000);
		_haltonSequenceGenerator.FastForward(steps);
		_existingDungeonPositions = new NativeHashMap<FixedString32Bytes, int2>(64, Allocator.Persistent);
		foreach (var item3 in IFE_2094639253_0.Query(__query_2094639253_0, __TypeHandle.__IFE_2094639253_0_TypeHandle, ref base.CheckedStateRef))
		{
			LocalTransform item = item3.Item1;
			FixedString32Bytes fixedString32Bytes = DungeonNameSerializedCD.AsFixedString32Bytes(item3.Item2);
			if (!_existingDungeonPositions.TryAdd(fixedString32Bytes, item.Position.RoundToInt2()))
			{
				UnityEngine.Debug.LogError($"{fixedString32Bytes} occurs several times in the save file");
			}
		}
		_existingSubMapIndices = new NativeHashSet<int2>(64, Allocator.Persistent);
		foreach (SubMapCD item4 in IFE_2094639253_1.Query(__query_2094639253_1, __TypeHandle.__IFE_2094639253_1_TypeHandle, ref base.CheckedStateRef))
		{
			if (!item4.wasCreatedThisSession)
			{
				_existingSubMapIndices.Add(item4.index);
			}
		}
		_proceduralDataRequester = Manager.worldGen.CreateProceduralDataRequester(2500);
		_spawnEntryQueue = new NativePriorityQueue<Entity>(64, Allocator.Persistent);
		_spawnCandidates = new NativeList<SpawnCandidate>(500, Allocator.Persistent);
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = __query_2094639253_6.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		CoreKeeperWorldParameters worldGenerationParametersReference = Manager.saves.GetWorldGenerationParametersReference();
		ComponentLookup<BossLarvaCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossLarvaCD_RO_ComponentLookup, ref base.CheckedStateRef);
		_staticallyBlockedAreas = StaticallyBlockedAreas.Create(databaseBankBlob, worldGenerationParametersReference, componentLookup, Allocator.Persistent);
		CoreKeeperWorldParameters worldGenerationParametersReference2 = Manager.saves.GetWorldGenerationParametersReference();
		int num = (int)math.ceil((worldGenerationParametersReference2.ring4Size + worldGenerationParametersReference2.ring4Chaos) * worldGenerationParametersReference2.worldScale);
		num += 32;
		_ring4Area = new SpawnArea
		{
			BasePosition = -num,
			Size = 2 * num
		};
		_biomeBounds = new NativeArray<SpawnArea>(12, Allocator.Persistent);
		ComputeBiomeBounds(__query_2094639253_7.GetSingleton<BiomeSamplesCD>(), ref _biomeBounds);
		for (Biome biome = Biome.None; biome < Biome.__MAX_VALUE__; biome++)
		{
			int index = (int)biome;
			if (math.any(_biomeBounds[index].Size == 0))
			{
				UnityEngine.Debug.LogWarning($"No samples found for biome {biome}. Defaulting bounds to ring 4 area. This may cause issues with dungeon placement.");
				_biomeBounds[index] = _ring4Area;
			}
		}
		if (!__query_2094639253_8.HasSingleton<UniqueDungeonSpawnPosition>())
		{
			base.EntityManager.CreateSingletonBuffer<UniqueDungeonSpawnPosition>();
		}
		if (_spawnEntryQueue.IsEmpty)
		{
			DynamicBuffer<UniqueDungeonSpawnPosition> singletonBuffer = __query_2094639253_9.GetSingletonBuffer<UniqueDungeonSpawnPosition>();
			DynamicBuffer<ActivatedContentBundlesBuffer> singletonBuffer2 = __query_2094639253_10.GetSingletonBuffer<ActivatedContentBundlesBuffer>();
			foreach (var (spawnEntry, value) in IFE_2094639253_2.Query(__query_2094639253_2, __TypeHandle.__IFE_2094639253_2_TypeHandle, ref base.CheckedStateRef))
			{
				if (spawnEntry.placementType == UniqueScenePlacementType.ExactPosition && MatchesActiveContentBundles(spawnEntry, singletonBuffer2))
				{
					if (_existingDungeonPositions.TryGetValue(spawnEntry.name, out var item2))
					{
						singletonBuffer.Add(new UniqueDungeonSpawnPosition
						{
							Position = item2,
							SpawnEntry = spawnEntry,
							HasBeenSpawned = true
						});
					}
					else
					{
						int2 position = (int2)math.round(spawnEntry.spawnPosition.fullRelease.ToFloat2() * __query_2094639253_11.GetSingleton<WorldScaleCD>().Value);
						singletonBuffer.Add(new UniqueDungeonSpawnPosition
						{
							Position = position,
							SpawnEntry = spawnEntry
						});
					}
				}
				_spawnEntryQueue.Enqueue(value, spawnEntry.sortIndex);
			}
		}
		if (_spawnEntryQueue.IsEmpty)
		{
			UnityEngine.Debug.LogWarning("SpawnUniqueDungeonInitSystem ran, but there was no work to do.");
		}
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnStopRunning()
	{
		if (__query_2094639253_4.GetSingleton<WorldGenerationTypeCD>().Value == WorldGenerationType.FullRelease && _spawnEntryQueue.IsEmpty)
		{
			if (__query_2094639253_4.GetSingleton<WorldGenerationTypeCD>().Value == WorldGenerationType.FullRelease && !__query_2094639253_12.HasSingleton<UniqueDungeonInitDoneCD>())
			{
				base.EntityManager.CreateSingleton<UniqueDungeonInitDoneCD>();
			}
			if (_existingDungeonPositions.IsCreated)
			{
				_existingDungeonPositions.Dispose();
				_existingDungeonPositions = default(NativeHashMap<FixedString32Bytes, int2>);
			}
			if (_existingSubMapIndices.IsCreated)
			{
				_existingSubMapIndices.Dispose();
				_existingSubMapIndices = default(NativeHashSet<int2>);
			}
			if (_proceduralDataRequester.IsCreated)
			{
				_proceduralDataRequester.Dispose();
				_proceduralDataRequester = default(WorldGenManager.ProceduralDataRequester);
			}
			if (_spawnEntryQueue.IsCreated)
			{
				_spawnEntryQueue.Dispose();
				_spawnEntryQueue = default(NativePriorityQueue<Entity>);
			}
			if (_spawnCandidates.IsCreated)
			{
				_spawnCandidates.Dispose();
				_spawnCandidates = default(NativeList<SpawnCandidate>);
			}
			if (_staticallyBlockedAreas.IsCreated)
			{
				_staticallyBlockedAreas.Dispose();
				_staticallyBlockedAreas = default(StaticallyBlockedAreas);
			}
			if (_biomeBounds.IsCreated)
			{
				_biomeBounds.Dispose();
				_biomeBounds = default(NativeArray<SpawnArea>);
			}
			base.OnStopRunning();
		}
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (__query_2094639253_4.GetSingleton<WorldGenerationTypeCD>().Value != WorldGenerationType.FullRelease || _spawnEntryQueue.IsEmpty)
		{
			base.EntityManager.DestroyEntity(__query_2094639253_3);
			return;
		}
		float value = __query_2094639253_11.GetSingleton<WorldScaleCD>().Value;
		BiomeSamplesCD singleton = __query_2094639253_7.GetSingleton<BiomeSamplesCD>();
		if (_state == State.WaitingForPoints && _proceduralDataRequester.TryGetPointsRequestResult(out var result))
		{
			GetFirstFromQueue(out var _, out var spawnEntry);
			for (int i = 0; i < _spawnCandidates.Length; i++)
			{
				SpawnCandidate value2 = _spawnCandidates[i];
				int2 item = (value2.Position & -64) >> 6;
				bool flag = !_existingSubMapIndices.Contains(item);
				int biomeMatch = CountBiomeMatches(spawnEntry, 5 * i, result.Data);
				float distance = ComputeDistanceScore(spawnEntry, math.length(value2.Position) / value);
				value2.PlacementScore = new SpawnCandidate.Score
				{
					IsInUnexploredArea = (flag ? 1 : 0),
					BiomeMatch = biomeMatch,
					Distance = distance
				};
				_spawnCandidates[i] = value2;
			}
			SpawnCandidate spawnCandidate = _spawnCandidates[0];
			foreach (SpawnCandidate spawnCandidate2 in _spawnCandidates)
			{
				SpawnCandidate.Score placementScore = spawnCandidate2.PlacementScore;
				if (placementScore.CompareTo(spawnCandidate.PlacementScore) > 0)
				{
					spawnCandidate = spawnCandidate2;
				}
			}
			__query_2094639253_9.GetSingletonBuffer<UniqueDungeonSpawnPosition>().Add(new UniqueDungeonSpawnPosition
			{
				Position = spawnCandidate.Position,
				SpawnEntry = spawnCandidate.SpawnEntry
			});
			_spawnCandidates.Clear();
			MarkFirstAsProcessed();
			_state = State.Idle;
		}
		while (_state == State.Idle && !_spawnEntryQueue.IsEmpty)
		{
			GetFirstFromQueue(out var _, out var spawnEntry2);
			if (spawnEntry2.placementType == UniqueScenePlacementType.ExactPosition)
			{
				MarkFirstAsProcessed();
				_haltonSequenceGenerator.FastForward(10000);
				continue;
			}
			DynamicBuffer<ActivatedContentBundlesBuffer> singletonBuffer = __query_2094639253_10.GetSingletonBuffer<ActivatedContentBundlesBuffer>();
			if (!MatchesActiveContentBundles(spawnEntry2, singletonBuffer))
			{
				MarkFirstAsProcessed();
				_haltonSequenceGenerator.FastForward(10000);
				continue;
			}
			DynamicBuffer<UniqueDungeonSpawnPosition> singletonBuffer2 = __query_2094639253_9.GetSingletonBuffer<UniqueDungeonSpawnPosition>();
			if (_existingDungeonPositions.TryGetValue(spawnEntry2.name, out var item2))
			{
				singletonBuffer2.Add(new UniqueDungeonSpawnPosition
				{
					Position = item2,
					SpawnEntry = spawnEntry2,
					HasBeenSpawned = true
				});
				MarkFirstAsProcessed();
				_haltonSequenceGenerator.FastForward(10000);
				continue;
			}
			_spawnCandidates.Clear();
			SpawnArea spawnArea = spawnEntry2.positionSampling switch
			{
				UniqueScenePositionSampling.InsideRing4 => _ring4Area, 
				UniqueScenePositionSampling.InsideBiomeBounds => _biomeBounds[(int)spawnEntry2.biome.fullRelease], 
				_ => throw new ArgumentOutOfRangeException("positionSampling", spawnEntry2.positionSampling, null), 
			};
			int j;
			for (j = 0; j < 10000; j++)
			{
				if (_spawnCandidates.Length >= 500)
				{
					break;
				}
				int2 position = (spawnArea.BasePosition + _haltonSequenceGenerator.Next() * spawnArea.Size).RoundToInt2();
				if (!spawnEntry2.allowOverlappingSpawnCellBorders)
				{
					position = RestrictToCell(position, spawnEntry2.radius);
				}
				if (IsAllowedSpawnPosition(position, spawnEntry2.radius, value, singletonBuffer2, singleton))
				{
					ref NativeList<SpawnCandidate> spawnCandidates = ref _spawnCandidates;
					SpawnCandidate value3 = new SpawnCandidate
					{
						Position = position,
						SpawnEntry = spawnEntry2
					};
					spawnCandidates.Add(in value3);
				}
			}
			_haltonSequenceGenerator.FastForward(10000 - j);
			if (_spawnCandidates.Length == 0)
			{
				UnityEngine.Debug.LogError($"No suitable spawn positions found for unique dungeon {spawnEntry2.name}.");
				MarkFirstAsProcessed();
				continue;
			}
			if (_spawnCandidates.Length < 500)
			{
				UnityEngine.Debug.LogWarning($"Only {_spawnCandidates.Length} suitable spawn positions found for unique dungeon {spawnEntry2.name}.");
			}
			NativeArray<Vector2> points = new NativeArray<Vector2>(_spawnCandidates.Length * 5, Allocator.Temp);
			for (int k = 0; k < _spawnCandidates.Length; k++)
			{
				int num = k * 5;
				points[num] = new Vector2(_spawnCandidates[k].Position.x, _spawnCandidates[k].Position.y) + new Vector2(0.5f, 0.5f);
				points[num + 1] = points[num] + new Vector2(1f, 1f) * spawnEntry2.radius;
				points[num + 2] = points[num] + new Vector2(-1f, 1f) * spawnEntry2.radius;
				points[num + 3] = points[num] + new Vector2(1f, -1f) * spawnEntry2.radius;
				points[num + 4] = points[num] + new Vector2(-1f, -1f) * spawnEntry2.radius;
			}
			_proceduralDataRequester.RequestPoints(points);
			points.Dispose();
			_state = State.WaitingForPoints;
			break;
		}
		if (_spawnEntryQueue.IsEmpty)
		{
			base.EntityManager.DestroyEntity(__query_2094639253_3);
		}
	}

	private void GetFirstFromQueue(out Entity entity, out PugWorldGenCD spawnEntry)
	{
		if (_spawnEntryQueue.IsEmpty)
		{
			entity = Entity.Null;
			spawnEntry = default(PugWorldGenCD);
		}
		else
		{
			entity = _spawnEntryQueue.First;
			spawnEntry = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__PugWorldGen_PugWorldGenCD_RO_ComponentLookup, ref base.CheckedStateRef, entity);
		}
	}

	private void MarkFirstAsProcessed()
	{
		float priority;
		Entity entity = _spawnEntryQueue.Dequeue(out priority);
		base.EntityManager.DestroyEntity(entity);
	}

	private static bool MatchesActiveContentBundles(PugWorldGenCD spawnEntry, DynamicBuffer<ActivatedContentBundlesBuffer> activatedContentBundles)
	{
		if (!activatedContentBundles.Contains(new ActivatedContentBundlesBuffer
		{
			ContentBundle = spawnEntry.contentBundle
		}))
		{
			if (!spawnEntry.contentBundle.ToString().Contains("EasterEgg", StringComparison.InvariantCultureIgnoreCase))
			{
				UnityEngine.Debug.Log($"Skip {spawnEntry.name}: content bundle {ContentBundleDataBlock.GetBundleName(spawnEntry.contentBundle)} not activated.");
			}
			return false;
		}
		if (spawnEntry.replacedByBundle.TryGetValue(out var output) && activatedContentBundles.Contains(new ActivatedContentBundlesBuffer
		{
			ContentBundle = output
		}))
		{
			UnityEngine.Debug.Log($"Skip {spawnEntry.name}: replaced by content bundle {ContentBundleDataBlock.GetBundleName(output)} which is activated.");
			return false;
		}
		return true;
	}

	private static int2 RestrictToCell(int2 position, int radius)
	{
		position += 128;
		int2 obj = (position & -256) + radius;
		float2 float5 = (position & 255).ToFloat2() / 256f;
		position = obj + (float5 * (256 - 2 * radius)).RoundToInt2();
		position -= 128;
		return position;
	}

	private bool IsAllowedSpawnPosition(int2 position, int radius, float worldScale, DynamicBuffer<UniqueDungeonSpawnPosition> placedDungeons, BiomeSamplesCD biomeSamples)
	{
		if (biomeSamples.GetBiome(position) == Biome.None)
		{
			return false;
		}
		PugGeometry.Circle circle = PugGeometry.Circle.FromCenterRadius(position.ToFloat2() / worldScale, radius);
		if (_staticallyBlockedAreas.Overlaps(circle))
		{
			return false;
		}
		foreach (UniqueDungeonSpawnPosition item in placedDungeons)
		{
			if (math.length(item.Position - position) < (float)(radius + item.SpawnEntry.radius))
			{
				return false;
			}
		}
		return true;
	}

	private static bool OverlapsBlockedArea(float2 scaledPosition, int radius, NativeArray<PugGeometry.CircleBand> blockedAreas)
	{
		foreach (PugGeometry.CircleBand item in blockedAreas)
		{
			if (item.DistanceToPoint(scaledPosition) < (float)radius)
			{
				return true;
			}
		}
		return false;
	}

	private static int CountBiomeMatches(PugWorldGenCD worldGen, int startIndex, NativeArray<Color32> data)
	{
		int num = 0;
		for (int i = 0; i < 5; i++)
		{
			int index = startIndex + i;
			Biome biome = CoreKeeperWorld.GetBiome(data[index].g) switch
			{
				PugWorldGen.CoreKeeper.Biome.Dirt => Biome.Slime, 
				PugWorldGen.CoreKeeper.Biome.Clay => Biome.Larva, 
				PugWorldGen.CoreKeeper.Biome.Stone => Biome.Stone, 
				PugWorldGen.CoreKeeper.Biome.Forest => Biome.Nature, 
				PugWorldGen.CoreKeeper.Biome.Sea => Biome.Sea, 
				PugWorldGen.CoreKeeper.Biome.Desert => Biome.Desert, 
				PugWorldGen.CoreKeeper.Biome.Crystal => Biome.Crystal, 
				PugWorldGen.CoreKeeper.Biome.Passage => Biome.Passage, 
				PugWorldGen.CoreKeeper.Biome.Excavation => Biome.Excavation, 
				_ => Biome.None, 
			};
			if (worldGen.biome.fullRelease == Biome.None || biome == worldGen.biome.fullRelease)
			{
				num++;
			}
		}
		return num;
	}

	private float ComputeDistanceScore(PugWorldGenCD worldGen, float radiusNormalizedDistance)
	{
		return 1f - math.min(math.abs((float)worldGen.targetDistanceFromCore.fullRelease - radiusNormalizedDistance) / 200f, 1f);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(ComputeBiomeBounds_0000011A_0024PostfixBurstDelegate))]
	private static void ComputeBiomeBounds(in BiomeSamplesCD biomeSamples, ref NativeArray<SpawnArea> bounds)
	{
		ComputeBiomeBounds_0000011A_0024BurstDirectCall.Invoke(in biomeSamples, ref bounds);
	}

	[Conditional("DEBUG_SPAWN_UNIQUE_DUNGEON_INIT_SYSTEM")]
	private void DebugClearMarkers()
	{
		foreach (PugWorld.DebugMarker debugMarker in _debugMarkers)
		{
			PugWorld.RemoveDebugMarker(debugMarker);
		}
		_debugMarkers.Clear();
	}

	[Conditional("DEBUG_SPAWN_UNIQUE_DUNGEON_INIT_SYSTEM")]
	private void DebugDrawCells()
	{
		int num = (int)math.ceil((float)Manager.worldGen.GetScaledWorldRadiusBound() / 256f);
		Vector2 vector = Vector2.one * 256f / 2f;
		Vector2 size = vector - Vector2.one * 2f;
		Color color = Color.red.ColorWithNewAlpha(0.1f);
		Color color2 = Color.green.ColorWithNewAlpha(0.1f);
		for (int i = -num; i <= num; i++)
		{
			for (int j = -num; j <= num; j++)
			{
				Vector2 position = new Vector2(j, i) * 256f;
				_debugMarkers.Add(PugWorld.AddDebugRect(position, vector, color));
				_debugMarkers.Add(PugWorld.AddDebugRect(position, size, color2));
			}
		}
	}

	[Conditional("DEBUG_SPAWN_UNIQUE_DUNGEON_INIT_SYSTEM")]
	private void DebugDrawBlockedAreas()
	{
		foreach (StaticallyBlockedAreas.CircleBandOrAABB blockedArea in _staticallyBlockedAreas.BlockedAreas)
		{
			if (blockedArea.CircleBand.TryGetValue(out var output))
			{
				Vector2 position = new Vector2(output.Center.x, output.Center.y);
				float radius = output.Radius - output.Width;
				float radius2 = output.Radius + output.Width;
				_debugMarkers.Add(PugWorld.AddDebugCircle(position, radius, Color.red));
				_debugMarkers.Add(PugWorld.AddDebugCircle(position, radius2, Color.red));
			}
			if (blockedArea.AABB.TryGetValue(out var output2))
			{
				float2 float5 = output2.Size / 2f;
				float2 float6 = output2.Low + float5;
				_debugMarkers.Add(PugWorld.AddDebugRect(float6, float5, Color.red));
			}
		}
	}

	[Conditional("DEBUG_SPAWN_UNIQUE_DUNGEON_INIT_SYSTEM")]
	private void DebugDrawExistingDungeons()
	{
		foreach (UniqueDungeonSpawnPosition item in __query_2094639253_9.GetSingletonBuffer<UniqueDungeonSpawnPosition>())
		{
			Vector2 position = new Vector2(item.Position.x, item.Position.y);
			int radius = item.SpawnEntry.radius;
			FixedString32Bytes name = item.SpawnEntry.name;
			_debugMarkers.Add(PugWorld.AddDebugCircle(position, radius, Color.red, name.ToString()));
		}
	}

	[Conditional("DEBUG_SPAWN_UNIQUE_DUNGEON_INIT_SYSTEM")]
	private void DebugDrawCandidate(int2 position, bool rejected)
	{
		_debugMarkers.Add(PugWorld.AddDebugCircle(new Vector2(position.x, position.y), 4f, rejected ? Color.gray : Color.blue));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonNameSerializedCD>();
		__query_2094639253_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SubMapCD>();
		__query_2094639253_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugWorldGenCD>();
		__query_2094639253_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<Trigger>();
		__query_2094639253_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2094639253_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2094639253_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2094639253_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2094639253_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<UniqueDungeonSpawnPosition>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2094639253_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<UniqueDungeonSpawnPosition>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2094639253_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ActivatedContentBundlesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2094639253_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldScaleCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2094639253_11 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<UniqueDungeonInitDoneCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2094639253_12 = entityQueryBuilder2.Build(ref state);
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
	public SpawnUniqueDungeonInitSystem()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void ComputeBiomeBounds_0024BurstManaged(in BiomeSamplesCD biomeSamples, ref NativeArray<SpawnArea> bounds)
	{
		NativeArray<int2> nativeArray = new NativeArray<int2>(12, Allocator.Temp);
		NativeArray<int2> nativeArray2 = new NativeArray<int2>(12, Allocator.Temp);
		for (int i = 0; i < 12; i++)
		{
			nativeArray[i] = new int2(int.MaxValue, int.MaxValue);
			nativeArray2[i] = new int2(int.MinValue, int.MinValue);
		}
		int2 value = biomeSamples.BasePosition.Value;
		for (int j = 0; j < biomeSamples.SamplesPerDimension; j++)
		{
			for (int k = 0; k < biomeSamples.SamplesPerDimension; k++)
			{
				int index = j * biomeSamples.SamplesPerDimension + k;
				int index2 = biomeSamples.Samples[index];
				int2 int5 = value + new int2(k, j) * 16;
				nativeArray[index2] = math.min(nativeArray[index2], int5);
				nativeArray2[index2] = math.max(nativeArray2[index2], int5 + 16);
			}
		}
		for (int l = 0; l < 12; l++)
		{
			SpawnArea value2 = new SpawnArea
			{
				BasePosition = nativeArray[l],
				Size = nativeArray2[l] - nativeArray[l]
			};
			if (math.any(value2.Size < 0))
			{
				value2 = default(SpawnArea);
			}
			bounds[l] = value2;
		}
		nativeArray.Dispose();
		nativeArray2.Dispose();
	}
}
