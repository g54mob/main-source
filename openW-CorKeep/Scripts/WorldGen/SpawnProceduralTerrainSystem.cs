using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using PugWorldGen;
using PugWorldGen.CoreKeeper;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using WorldGen;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct SpawnProceduralTerrainSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct FindSetPositionsJob : IJob
	{
		public Entity SubMapEntity;

		public NativeReference<SubMapLayer> PositionIsSet;

		[ReadOnly]
		public BufferLookup<SubMapLayerBuffer> SubMapBufferLookup;

		public void Execute()
		{
			SubMapLayer subMapLayer = default(SubMapLayer);
			if (SubMapEntity == Entity.Null)
			{
				PositionIsSet.Value = subMapLayer;
				return;
			}
			foreach (SubMapLayerBuffer item in SubMapBufferLookup[SubMapEntity])
			{
				if (!item.data.layer.tileType.ShouldNotExistOnItsOwn() && item.data.layer.tileType != PugTilemap.TileType.greatWall)
				{
					subMapLayer = subMapLayer.Merge(item.data);
				}
			}
			PositionIsSet.Value = subMapLayer;
		}
	}

	[BurstCompile]
	private struct UpdateSubMapJob : IJob
	{
		public EntityCommandBuffer Ecb;

		public Entity Entity;

		public TileAccessor TileAccessor;

		public NativeParallelMultiHashMap<PugColor32, TileCD> TileTypeMapping;

		[ReadOnly]
		public NativeArray<TileTypeMapping.MappingRule> TileTypeMappingRules;

		public EntityArchetype WaterSpreaderArchetype;

		public int2 Position;

		public int2 Size;

		[ReadOnly]
		public NativeArray<Color32> TerrainData;

		[ReadOnly]
		public NativeReference<SubMapLayer> PositionIsSet;

		public bool GreatWallIsDown;

		public void Execute()
		{
			SubMapLayer sl = PositionIsSet.Value;
			Ecb.DestroyEntity(Entity);
			for (int i = 0; i < Size.y; i++)
			{
				for (int j = 0; j < Size.x; j++)
				{
					int2 int5 = new int2(j, i);
					int2 int6 = Position + int5;
					if (GreatWallIsDown && sl.GetByRef(int5))
					{
						continue;
					}
					int index = i * Size.x + j;
					PugColor32 key = TerrainData[index];
					key.b &= 15;
					key.a &= 224;
					if (!TileTypeMapping.TryGetFirstValue(key, out var item, out var it))
					{
						PugWorldGen.CoreKeeper.TileType tileType = CoreKeeperWorld.GetTileType(key.r);
						if (tileType == PugWorldGen.CoreKeeper.TileType.None)
						{
							continue;
						}
						PugWorldGen.CoreKeeper.Biome biome = CoreKeeperWorld.GetBiome(key.g);
						Utilities.DecodeBitmask(key.b, out var b, out var b2, out var _, out var b4);
						int resourceIndex = key.a >> 5;
						if (biome == PugWorldGen.CoreKeeper.Biome.None)
						{
							biome = PugWorldGen.CoreKeeper.Biome.Dirt;
						}
						bool flag = false;
						foreach (TileTypeMapping.MappingRule tileTypeMappingRule in TileTypeMappingRules)
						{
							if ((tileTypeMappingRule.proceduralTileType == PugWorldGen.CoreKeeper.TileType.None || tileTypeMappingRule.proceduralTileType == tileType) && (tileTypeMappingRule.biome == PugWorldGen.CoreKeeper.Biome.None || tileTypeMappingRule.biome == biome) && MatchesFlagState(tileTypeMappingRule.floorFlag, b) && MatchesFlagState(tileTypeMappingRule.roofHoleFlag, b2) && MatchesFlagState(tileTypeMappingRule.greatWallFlag, b4) && tileTypeMappingRule.resourceIndex.MatchesResourceIndex(resourceIndex))
							{
								TileTypeMapping.Add(key, new TileCD
								{
									tileType = tileTypeMappingRule.outputTile.tileType,
									tileset = (int)tileTypeMappingRule.outputTile.tileset
								});
								flag = true;
							}
						}
						if (Hint.Unlikely(!flag))
						{
							Debug.LogWarning($"Procedural data 0x{key.rgba:X8} ({biome}, {tileType}, 0x{key.r:X2}) at {int6} did not match any mapping rules.");
							TileTypeMapping.Add(key, default(TileCD));
						}
						TileTypeMapping.TryGetFirstValue(key, out item, out it);
					}
					do
					{
						if ((sl.GetByRef(int5) && item.tileType != PugTilemap.TileType.greatWall) || (GreatWallIsDown && item.tileType == PugTilemap.TileType.greatWall) || item.tileType == PugTilemap.TileType.none)
						{
							continue;
						}
						PugTilemap.TileType tileType2;
						if (item.tileset == 2)
						{
							tileType2 = item.tileType;
							if (tileType2 == PugTilemap.TileType.wall || tileType2 == PugTilemap.TileType.ground)
							{
								continue;
							}
						}
						TileAccessor.Set(int6, item);
						tileType2 = item.tileType;
						if (tileType2 == PugTilemap.TileType.water || tileType2 == PugTilemap.TileType.pit)
						{
							Entity e = Ecb.CreateEntity(WaterSpreaderArchetype);
							Ecb.SetComponent(e, new WaterSpreaderCD
							{
								position = int6
							});
						}
					}
					while (TileTypeMapping.TryGetNextValue(out item, ref it));
				}
			}
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_84466467_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<ProceduralTerrainDataCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<ProceduralTerrainDataCD>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ProceduralTerrainDataCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ProceduralTerrainDataCD> item1_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ProceduralTerrainDataCD>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ProceduralTerrainDataCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<ProceduralTerrainDataCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ProceduralTerrainDataCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_84466467_0.TypeHandle __IFE_84466467_0_TypeHandle;

		public BufferLookup<SubMapLayerBuffer> __SubMapLayerBuffer_RW_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_84466467_0_TypeHandle = new IFE_84466467_0.TypeHandle(ref state);
			__SubMapLayerBuffer_RW_BufferLookup = state.GetBufferLookup<SubMapLayerBuffer>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000000F9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000000F9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000000F9_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_000000FA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000000FA_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000000FA_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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

	private const byte USED_FLAGS_MASK_BLUE = 15;

	private const byte USED_FLAGS_MASK_ALPHA = 224;

	private EntityArchetype _waterSpreaderArchetype;

	private NativeParallelMultiHashMap<PugColor32, TileCD> _tileTypeMapping;

	private NativeArray<TileTypeMapping.MappingRule> _tileTypeMappingRules;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_84466467_0;

	private EntityQuery __query_84466467_1;

	private EntityQuery __query_84466467_2;

	public void OnCreate(ref SystemState state)
	{
		TileTypeMapping tileTypeMapping = Resources.Load<TileTypeMapping>("TileTypeMapping");
		_tileTypeMapping = new NativeParallelMultiHashMap<PugColor32, TileCD>(1024, Allocator.Persistent);
		_tileTypeMappingRules = new NativeArray<TileTypeMapping.MappingRule>(tileTypeMapping.mapping.Count, Allocator.Persistent);
		for (int i = 0; i < tileTypeMapping.mapping.Count; i++)
		{
			_tileTypeMappingRules[i] = tileTypeMapping.mapping[i];
		}
		_waterSpreaderArchetype = state.EntityManager.CreateArchetype(typeof(WaterSpreaderCD));
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<ProceduralTerrainDataCD>();
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		_tileTypeMapping.Dispose();
		_tileTypeMappingRules.Dispose();
	}

	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state, isReadOnly: false);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_84466467_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		_tileAccessor.Update(ref state);
		foreach (QueryEnumerableWithEntity<ProceduralTerrainDataCD> item2 in IFE_84466467_0.Query(__query_84466467_0, __TypeHandle.__IFE_84466467_0_TypeHandle, ref state))
		{
			item2.Deconstruct(out var item, out var entity);
			ProceduralTerrainDataCD proceduralTerrainDataCD = item;
			Entity entity2 = entity;
			NativeReference<SubMapLayer> positionIsSet = new NativeReference<SubMapLayer>(state.WorldUpdateAllocator);
			FindSetPositionsJob jobData = new FindSetPositionsJob
			{
				SubMapEntity = proceduralTerrainDataCD.SubMapEntity,
				PositionIsSet = positionIsSet,
				SubMapBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SubMapLayerBuffer_RW_BufferLookup, ref state)
			};
			state.Dependency = IJobExtensions.Schedule(jobData, state.Dependency);
			UpdateSubMapJob jobData2 = new UpdateSubMapJob
			{
				Ecb = ecb,
				Entity = entity2,
				TileAccessor = _tileAccessor,
				TileTypeMapping = _tileTypeMapping,
				TileTypeMappingRules = _tileTypeMappingRules,
				WaterSpreaderArchetype = _waterSpreaderArchetype,
				TerrainData = proceduralTerrainDataCD.Data,
				Position = proceduralTerrainDataCD.Position,
				Size = proceduralTerrainDataCD.Size,
				PositionIsSet = positionIsSet,
				GreatWallIsDown = __query_84466467_2.HasSingleton<TheGreatWallHasBeenLoweredCD>()
			};
			state.Dependency = IJobExtensions.Schedule(jobData2, state.Dependency);
		}
	}

	private static bool MatchesFlagState(TileTypeMapping.FlagState state, bool flag)
	{
		return state switch
		{
			TileTypeMapping.FlagState.Any => true, 
			TileTypeMapping.FlagState.True => flag, 
			TileTypeMapping.FlagState.False => !flag, 
			_ => throw new NotImplementedException(), 
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ProceduralTerrainDataCD>();
		__query_84466467_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_84466467_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TheGreatWallHasBeenLoweredCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_84466467_2 = entityQueryBuilder2.Build(ref state);
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
		((SpawnProceduralTerrainSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000000F9_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000000FA_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((SpawnProceduralTerrainSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((SpawnProceduralTerrainSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SpawnProceduralTerrainSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SpawnProceduralTerrainSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SpawnProceduralTerrainSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}
