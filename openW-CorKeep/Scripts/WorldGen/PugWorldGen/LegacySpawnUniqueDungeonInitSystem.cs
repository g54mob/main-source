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
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	public class LegacySpawnUniqueDungeonInitSystem : PugSimulationSystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct Trigger : IComponentData, IQueryTypeParameter
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_1626600799_0
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

		private struct TypeHandle
		{
			public IFE_1626600799_0.TypeHandle __IFE_1626600799_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_1626600799_0_TypeHandle = new IFE_1626600799_0.TypeHandle(ref state);
			}
		}

		private const int MAX_RETRIES = 100;

		private static readonly DataBlockAddress ClassicBundle = new DataBlockAddress("7507d88e-fd7a-7444-1b18-3816c6fbe382");

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1626600799_0;

		private EntityQuery __query_1626600799_1;

		private EntityQuery __query_1626600799_2;

		private EntityQuery __query_1626600799_3;

		private EntityQuery __query_1626600799_4;

		private EntityQuery __query_1626600799_5;

		[Preserve]
		protected override void OnCreate()
		{
			UpdatesInRunGroup();
			NeedServerSeed();
			AllowToRunBeforeInit();
			RequireForUpdate<BiomeRangesCD>();
			RequireForUpdate<WorldGenerationTypeCD>();
			RequireForUpdate<WorldHasBeenDeserializedCD>();
			base.EntityManager.AddComponent<Trigger>(base.EntityManager.CreateEntity());
			base.OnCreate();
		}

		[Preserve]
		protected override void OnStartRunning()
		{
			base.OnStartRunning();
			if (__query_1626600799_2.HasSingleton<UniqueDungeonInitDoneCD>())
			{
				return;
			}
			switch (__query_1626600799_3.GetSingleton<WorldGenerationTypeCD>().Value)
			{
			case WorldGenerationType.FullRelease:
				return;
			case WorldGenerationType.Creative:
				base.EntityManager.CreateSingletonBuffer<UniqueDungeonSpawnPosition>();
				base.EntityManager.CreateSingleton<UniqueDungeonInitDoneCD>();
				return;
			}
			base.EntityManager.CreateSingletonBuffer<UniqueDungeonSpawnPosition>();
			DynamicBuffer<UniqueDungeonSpawnPosition> singletonBuffer = __query_1626600799_4.GetSingletonBuffer<UniqueDungeonSpawnPosition>();
			uint num = serverSeed;
			FixedList512Bytes<BiomeRanges> value = __query_1626600799_5.GetSingleton<BiomeRangesCD>().Value;
			NativeArray<int> nativeArray = new NativeArray<int>(Enum.GetNames(typeof(Biome)).Length, Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				nativeArray[i] = 2500;
			}
			nativeArray[3] = 22500;
			nativeArray[2] = 22500;
			nativeArray[5] = 62500;
			nativeArray[7] = 90000;
			nativeArray[8] = 90000;
			using NativeHashMap<FixedString32Bytes, int2> nativeHashMap = new NativeHashMap<FixedString32Bytes, int2>(64, Allocator.Temp);
			foreach (var item3 in IFE_1626600799_0.Query(__query_1626600799_0, __TypeHandle.__IFE_1626600799_0_TypeHandle, ref base.CheckedStateRef))
			{
				LocalTransform item = item3.Item1;
				FixedString32Bytes fixedString32Bytes = DungeonNameSerializedCD.AsFixedString32Bytes(item3.Item2);
				if (!nativeHashMap.TryAdd(fixedString32Bytes, item.Position.RoundToInt2()))
				{
					Debug.LogError($"{fixedString32Bytes} occurs several times in the save file");
				}
			}
			NativeArray<PugWorldGenCD> array;
			using (EntityQuery entityQuery = base.EntityManager.CreateEntityQuery(typeof(PugWorldGenCD)))
			{
				array = entityQuery.ToComponentDataArray<PugWorldGenCD>(Allocator.Temp);
			}
			array.Sort();
			foreach (PugWorldGenCD item4 in array)
			{
				if (item4.contentBundle != ClassicBundle)
				{
					Debug.Log($"Skip {item4.name} because classic worlds don't support the {item4.contentBundle} content bundle");
					continue;
				}
				if (nativeHashMap.TryGetValue(item4.name, out var item2))
				{
					singletonBuffer.Add(new UniqueDungeonSpawnPosition
					{
						Position = item2,
						SpawnEntry = item4,
						HasBeenSpawned = true
					});
					continue;
				}
				if (item4.placementType == UniqueScenePlacementType.ExactPosition)
				{
					singletonBuffer.Add(new UniqueDungeonSpawnPosition
					{
						Position = item4.spawnPosition.classic,
						SpawnEntry = item4
					});
					continue;
				}
				Biome classic = item4.biome.classic;
				BiomeRanges biomeRanges;
				if (classic == Biome.None)
				{
					biomeRanges = BiomeRanges.All;
				}
				else
				{
					if ((int)classic >= value.Length)
					{
						Debug.LogError("skipping spawn because of missing biome");
						continue;
					}
					biomeRanges = value[(int)classic];
				}
				if (item4.placementType == UniqueScenePlacementType.DistanceFromCoreInBiome)
				{
					biomeRanges.start = item4.targetDistanceFromCore.classic;
					biomeRanges.end = item4.targetDistanceFromCore.classic;
				}
				if (item4.placementType == UniqueScenePlacementType.AnywhereInBiome)
				{
					Biome classic2 = item4.biome.classic;
					if (classic2 == Biome.Nature || classic2 == Biome.Sea || classic2 == Biome.Desert)
					{
						biomeRanges.end = biomeRanges.start * 2f;
					}
				}
				FixedString32Bytes name = item4.name;
				Unity.Mathematics.Random rng = Unity.Mathematics.Random.CreateFromIndex(num ^ (uint)name.GetHashCode());
				int num2 = nativeArray[(int)classic];
				bool flag = false;
				int2 result = default(int2);
				for (int j = 0; j < 100; j++)
				{
					int num3 = ((classic != Biome.Slime) ? 10 : 0);
					if (!BiomeRanges.TryGetRandomPositionWithinBiomeRanges(ref rng, biomeRanges, num3, out result))
					{
						break;
					}
					bool flag2 = false;
					foreach (UniqueDungeonSpawnPosition item5 in singletonBuffer)
					{
						if (!item5.SpawnEntry.name.Equals(item4.name) && math.distancesq(result, item5.Position) < (float)num2)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Debug.LogWarning($"Couldn't find free space to place dungeon {item4.name} but spawning (delayed) anyway at {result}");
				}
				singletonBuffer.Add(new UniqueDungeonSpawnPosition
				{
					Position = result,
					SpawnEntry = item4
				});
			}
			base.EntityManager.CreateSingleton<UniqueDungeonInitDoneCD>();
			array.Dispose();
			nativeArray.Dispose();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(__query_1626600799_1);
			base.OnUpdate();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonNameSerializedCD>();
			__query_1626600799_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAny<Trigger>();
			__query_1626600799_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<UniqueDungeonInitDoneCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1626600799_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1626600799_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAllRW<UniqueDungeonSpawnPosition>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1626600799_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1626600799_5 = entityQueryBuilder2.Build(ref state);
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
		public LegacySpawnUniqueDungeonInitSystem()
		{
		}
	}
}
