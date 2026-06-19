using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Scripting;

namespace PugWorldGen
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	public class LegacyDungeonSpawnSystem : PugSimulationSystemBase
	{
		private struct RecentlySpawnedDungeon
		{
			public int2 MapPos;

			public Entity DungeonEntity;
		}

		public struct DungeonCleanup : ICleanupComponentData, IComponentData, IQueryTypeParameter
		{
			public Entity AreaEntityRef;

			public Biome Biome;
		}

		public struct AreaBounds
		{
			public int2 min;

			public int2 max;

			public bool isSet;
		}

		private struct LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_0_Job : IJobChunk
		{
			public bool skipSpawn;

			public EntityCommandBuffer ecb;

			[ReadOnly]
			public TileAccessor tileLookup;

			public Unity.Mathematics.Random rng;

			public Entity dungeonBiomeSpawnBufferEntityLocal;

			[ReadOnly]
			public NativeArray<BlockedSpawnArea> blockedAreas;

			[ReadOnly]
			public ComponentLookup<DungeonAreaCD> dungeonLookup;

			public BufferLookup<DungeonSpawnTableBuffer> spawnBufferLookup;

			public BiomeLookup biomeLookupLocal;

			public int2 subMap2x2PartToSpawn;

			[ReadOnly]
			public NativeParallelHashSet<int2> mapsSpawningThisFrame;

			public NativeList<RecentlySpawnedDungeon> submapsWithSpawningDungeonsLocal;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ProceduralSpawnArea> __areaTypeHandle;

			public BufferLookup<DungeonBiomeSpawnTableBuffer> __PugWorldGen_DungeonBiomeSpawnTableBuffer_BufferLookup;

			private void OriginalLambdaBody(Entity entity, ref LegacySpawnDungeonInAreaCD spawnDungeonInAreaCD, in ProceduralSpawnArea area)
			{
				int2 int5 = area.Position / 64;
				if (math.any((int5 % 2 + 2) % 2 != subMap2x2PartToSpawn))
				{
					return;
				}
				bool flag = false;
				for (int i = 0; i < submapsWithSpawningDungeonsLocal.Length; i++)
				{
					if (math.all(submapsWithSpawningDungeonsLocal[i].MapPos == int5))
					{
						flag = true;
						break;
					}
				}
				Biome biome = biomeLookupLocal.GetBiome(area.Center);
				NativeList<int> nativeList = new NativeList<int>(Allocator.Temp);
				DynamicBuffer<DungeonBiomeSpawnTableBuffer> dynamicBuffer = __PugWorldGen_DungeonBiomeSpawnTableBuffer_BufferLookup[dungeonBiomeSpawnBufferEntityLocal];
				for (int j = 0; j < dynamicBuffer.Length; j++)
				{
					DungeonBiomeSpawnTableBuffer dungeonBiomeSpawnTableBuffer = dynamicBuffer[j];
					Biome classic = dungeonBiomeSpawnTableBuffer.biome.classic;
					bool num = classic == Biome.None || classic == biome;
					float num2 = math.length(area.Center);
					bool flag2 = dungeonBiomeSpawnTableBuffer.minDistanceFromCoreInClassicWorlds == 0 || num2 >= (float)dungeonBiomeSpawnTableBuffer.minDistanceFromCoreInClassicWorlds;
					if (num && flag2)
					{
						nativeList.Add(in j);
					}
				}
				Entity entity2 = Entity.Null;
				if (nativeList.Length > 0)
				{
					int index = nativeList[rng.NextInt(nativeList.Length)];
					nativeList.Dispose();
					entity2 = dynamicBuffer[index].tableEntity;
				}
				bool flag3 = biome != Biome.None && !flag && !skipSpawn && entity2 != Entity.Null;
				bool num3 = flag3 && TrySpawnDungeon(ref ecb, ref rng, entity2, spawnBufferLookup, entity, in area, tileLookup, in mapsSpawningThisFrame, biome, in blockedAreas, in dungeonLookup, ref submapsWithSpawningDungeonsLocal, ref biomeLookupLocal);
				ecb.RemoveComponent<LegacySpawnDungeonInAreaCD>(entity);
				if (!num3)
				{
					if (flag3 || biome == Biome.Slime)
					{
						ecb.AddComponent(entity, new LegacySpawnRandomCustomSceneInAreaCD
						{
							attempts = CustomSceneAttemptsFromBiome(biome)
						});
					}
					else
					{
						ecb.AddComponent<LegacySpawnProceduralInAreaCD>(entity);
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __areaTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						LegacySpawnDungeonInAreaCD spawnDungeonInAreaCD = default(LegacySpawnDungeonInAreaCD);
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref spawnDungeonInAreaCD, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, i));
					}
					return;
				}
				if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int j = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
					{
						for (; j < nextRangeEnd; j++)
						{
							LegacySpawnDungeonInAreaCD spawnDungeonInAreaCD2 = default(LegacySpawnDungeonInAreaCD);
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref spawnDungeonInAreaCD2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, j));
						}
					}
					return;
				}
				ulong num = chunkEnabledMask.ULong0;
				int num2 = math.min(64, count);
				for (int k = 0; k < num2; k++)
				{
					if ((num & 1) != 0L)
					{
						LegacySpawnDungeonInAreaCD spawnDungeonInAreaCD3 = default(LegacySpawnDungeonInAreaCD);
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref spawnDungeonInAreaCD3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						LegacySpawnDungeonInAreaCD spawnDungeonInAreaCD4 = default(LegacySpawnDungeonInAreaCD);
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref spawnDungeonInAreaCD4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ProceduralSpawnArea>(nativeArrayPtr2, l));
					}
					num >>= 1;
				}
			}

			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_0_Job>(jobPtr), ref query);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[NoAlias]
		[BurstCompile]
		private struct LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_1_Job : IJobChunk
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RunWithoutJobSystem_00000219_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

			internal static class RunWithoutJobSystem_00000219_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00000219_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
							return;
						}
					}
					RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
				}
			}

			public EntityCommandBuffer ecb;

			public NativeList<RecentlySpawnedDungeon> submapsWithSpawningDungeonsLocal;

			[ReadOnly]
			public EntityTypeHandle __entityTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DungeonCleanup> __cleanupTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void OriginalLambdaBody(Entity entity, [NoAlias] in DungeonCleanup cleanup)
			{
				ecb.RemoveComponent<DungeonCleanup>(entity);
				if (cleanup.Biome == Biome.Slime)
				{
					ecb.AddComponent(cleanup.AreaEntityRef, new LegacySpawnRandomCustomSceneInAreaCD
					{
						attempts = CustomSceneAttemptsFromBiome(cleanup.Biome)
					});
				}
				else
				{
					ecb.AddComponent<LegacySpawnProceduralInAreaCD>(cleanup.AreaEntityRef);
				}
				for (int num = submapsWithSpawningDungeonsLocal.Length - 1; num >= 0; num--)
				{
					if (submapsWithSpawningDungeonsLocal[num].DungeonEntity == entity)
					{
						submapsWithSpawningDungeonsLocal.RemoveAtSwapBack(num);
					}
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __cleanupTypeHandle);
				int count = chunk.Count;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonCleanup>(nativeArrayPtr2, i));
					}
					return;
				}
				if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int j = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
					{
						for (; j < nextRangeEnd; j++)
						{
							OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonCleanup>(nativeArrayPtr2, j));
						}
					}
					return;
				}
				ulong num = chunkEnabledMask.ULong0;
				int num2 = math.min(64, count);
				for (int k = 0; k < num2; k++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonCleanup>(nativeArrayPtr2, k));
					}
					num >>= 1;
				}
				num = chunkEnabledMask.ULong1;
				for (int l = 64; l < count; l++)
				{
					if ((num & 1) != 0L)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonCleanup>(nativeArrayPtr2, l));
					}
					num >>= 1;
				}
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00000219_0024PostfixBurstDelegate))]
			public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
			{
				RunWithoutJobSystem_00000219_0024BurstDirectCall.Invoke(ref query, jobPtr);
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
			{
				InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_1_Job>(jobPtr), ref query);
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<ProceduralSpawnArea> __ProceduralSpawnArea_RO_ComponentTypeHandle;

			public BufferLookup<DungeonBiomeSpawnTableBuffer> __PugWorldGen_DungeonBiomeSpawnTableBuffer_RW_BufferLookup;

			[ReadOnly]
			public ComponentTypeHandle<DungeonCleanup> __PugWorldGen_LegacyDungeonSpawnSystem_DungeonCleanup_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentLookup<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<DungeonSpawnTableBuffer> __PugWorldGen_DungeonSpawnTableBuffer_RO_BufferLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__ProceduralSpawnArea_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ProceduralSpawnArea>(isReadOnly: true);
				__PugWorldGen_DungeonBiomeSpawnTableBuffer_RW_BufferLookup = state.GetBufferLookup<DungeonBiomeSpawnTableBuffer>();
				__PugWorldGen_LegacyDungeonSpawnSystem_DungeonCleanup_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonCleanup>(isReadOnly: true);
				__PugWorldGen_DungeonAreaCD_RO_ComponentLookup = state.GetComponentLookup<DungeonAreaCD>(isReadOnly: true);
				__PugWorldGen_DungeonSpawnTableBuffer_RO_BufferLookup = state.GetBufferLookup<DungeonSpawnTableBuffer>(isReadOnly: true);
			}
		}

		private const float DUNGEON_EXTRA_RADIUS = 5f;

		private Entity dungeonBiomeSpawnBufferEntity;

		private EntityQuery query;

		private EntityQuery blockedAreasQ;

		private NativeList<RecentlySpawnedDungeon> submapsWithSpawningDungeons;

		private BiomeLookup biomeLookup;

		private uint updateCount;

		private static int4[] directions = new int4[4]
		{
			new int4(-1, 0, 0, 1),
			new int4(0, 0, 1, 1),
			new int4(-1, -1, 0, 0),
			new int4(0, -1, 1, 0)
		};

		private TypeHandle __TypeHandle;

		private EntityQuery __query_779746927_0;

		private EntityQuery __query_779746927_1;

		private EntityQuery __query_779746927_2;

		private EntityQuery __query_779746927_3;

		private EntityQuery __query_779746927_4;

		private EntityQuery __query_779746927_5;

		private EntityQuery __query_779746927_6;

		[Preserve]
		protected override void OnCreate()
		{
			RequireForUpdate(__query_779746927_2);
			UpdatesInRunGroup();
			RequireForUpdate<DungeonBiomeSpawnTableBuffer>();
			blockedAreasQ = GetEntityQuery(ComponentType.ReadOnly<BlockedSpawnAreaCD>());
			submapsWithSpawningDungeons = new NativeList<RecentlySpawnedDungeon>(Allocator.Persistent);
			base.OnCreate();
		}

		[Preserve]
		protected override void OnStartRunning()
		{
			base.OnStartRunning();
			dungeonBiomeSpawnBufferEntity = __query_779746927_3.GetSingletonEntity();
			biomeLookup = (__query_779746927_4.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_779746927_5.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
		}

		[Preserve]
		protected override void OnStopRunning()
		{
			biomeLookup.Dispose();
			base.OnStopRunning();
		}

		[Preserve]
		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (submapsWithSpawningDungeons.IsCreated)
			{
				submapsWithSpawningDungeons.Dispose();
			}
		}

		[Preserve]
		protected override void OnUpdate()
		{
			updateCount++;
			WorldGenerationType value = __query_779746927_6.GetSingleton<WorldGenerationTypeCD>().Value;
			if (value != WorldGenerationType.FullRelease)
			{
				bool skipSpawn = value == WorldGenerationType.Creative;
				EntityCommandBuffer ecb = CreateCommandBuffer();
				TileAccessor tileLookup = CreateTileAccessor();
				Unity.Mathematics.Random rng = PugRandom.GetRng();
				Entity dungeonBiomeSpawnBufferEntityLocal = dungeonBiomeSpawnBufferEntity;
				NativeArray<BlockedSpawnArea> blockedAreas = blockedAreasQ.ToComponentDataArray<BlockedSpawnAreaCD>(Allocator.Temp).Reinterpret<BlockedSpawnArea>();
				ComponentLookup<DungeonAreaCD> dungeonLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentLookup, ref base.CheckedStateRef);
				BufferLookup<DungeonSpawnTableBuffer> spawnBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PugWorldGen_DungeonSpawnTableBuffer_RO_BufferLookup, ref base.CheckedStateRef);
				BiomeLookup biomeLookupLocal = biomeLookup;
				int2 subMap2x2PartToSpawn = (int)(updateCount % 4) switch
				{
					0 => new int2(0, 0), 
					1 => new int2(1, 0), 
					2 => new int2(0, 1), 
					_ => new int2(1, 1), 
				};
				NativeArray<ProceduralSpawnArea> nativeArray = query.ToComponentDataArray<ProceduralSpawnArea>(Allocator.Temp);
				NativeParallelHashSet<int2> mapsSpawningThisFrame = new NativeParallelHashSet<int2>(nativeArray.Length * 2, Allocator.Temp);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					mapsSpawningThisFrame.Add(nativeArray[i].Position / 64);
				}
				nativeArray.Dispose();
				NativeList<RecentlySpawnedDungeon> submapsWithSpawningDungeonsLocal = submapsWithSpawningDungeons;
				LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_0_Execute(ref skipSpawn, ref ecb, ref tileLookup, ref rng, ref dungeonBiomeSpawnBufferEntityLocal, ref blockedAreas, ref dungeonLookup, ref spawnBufferLookup, ref biomeLookupLocal, ref subMap2x2PartToSpawn, ref mapsSpawningThisFrame, ref submapsWithSpawningDungeonsLocal);
				LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_1_Execute(ref ecb, ref submapsWithSpawningDungeonsLocal);
				mapsSpawningThisFrame.Dispose();
				blockedAreas.Dispose();
				base.OnUpdate();
			}
		}

		private static int CustomSceneAttemptsFromBiome(Biome biome)
		{
			if (biome != Biome.Slime)
			{
				return 1;
			}
			return 2;
		}

		private static bool TrySpawnDungeon(ref EntityCommandBuffer ecb, ref Unity.Mathematics.Random rng, Entity spawnTableEntity, BufferLookup<DungeonSpawnTableBuffer> spawnBufferFromEntity, Entity areaEntity, in ProceduralSpawnArea area, TileAccessor tileLookup, in NativeParallelHashSet<int2> mapsSpawningThisFrame, Biome biome, in NativeArray<BlockedSpawnArea> blockedAreas, in ComponentLookup<DungeonAreaCD> dungeonLookup, ref NativeList<RecentlySpawnedDungeon> submapsWithRecentlySpawnedDungeons, ref BiomeLookup biomeLookup)
		{
			if (spawnTableEntity == Entity.Null)
			{
				return false;
			}
			DynamicBuffer<DungeonSpawnTableBuffer> dynamicBuffer = spawnBufferFromEntity[spawnTableEntity];
			int num = 0;
			float num2 = 0f;
			for (num = 0; num < dynamicBuffer.Length; num++)
			{
				float num3 = dungeonLookup[dynamicBuffer[num].prefabEntity].GetMaxRadiusIncludingShape() + 5f;
				if (num2 < num3)
				{
					num2 = num3;
				}
			}
			int num4 = math.max(1, (int)math.ceil(num2 / 32f));
			int2 int5 = area.Position / 64;
			int2 int6 = area.Size / 2;
			int2 int7 = area.Center - int6;
			int2 int8 = area.Center + int6;
			NativeArray<AreaBounds> result = new NativeArray<AreaBounds>(num4, Allocator.Temp);
			result[0] = new AreaBounds
			{
				min = int7,
				max = int8,
				isSet = true
			};
			if (num4 > 1)
			{
				GetLargestSpawnArea(int5, int5, tileLookup, in mapsSpawningThisFrame, directions, num4, int5, ref result);
			}
			float num5 = rng.NextFloat();
			for (num = 0; num < dynamicBuffer.Length; num++)
			{
				if (!(dynamicBuffer[num].spawnValue >= num5))
				{
					continue;
				}
				float num6 = 0f;
				int2 int9 = int7;
				int2 int10 = int8;
				if (dungeonLookup.HasComponent(dynamicBuffer[num].prefabEntity))
				{
					num6 = dungeonLookup[dynamicBuffer[num].prefabEntity].GetMaxRadiusIncludingShape() + 5f;
					int num7 = (int)math.ceil(num6 / 32f) - 1;
					if (num7 > 0 && result[num7].isSet)
					{
						int9 = result[num7].min;
						int10 = result[num7].max;
					}
				}
				int2 min = int9 + new int2(num6);
				int2 int11 = int10 - new int2(num6);
				if (min.x > int11.x || min.y > int11.y)
				{
					continue;
				}
				int2 int12 = int9 / 64;
				int2 int13 = int10 / 64;
				bool flag = false;
				for (int i = int12.x; i < int13.x; i++)
				{
					for (int j = int12.y; j < int13.y; j++)
					{
						for (int k = 0; k < submapsWithRecentlySpawnedDungeons.Length; k++)
						{
							if (math.all(submapsWithRecentlySpawnedDungeons[k].MapPos == new int2(i, j)))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				bool flag2 = false;
				int2 int14 = int2.zero;
				for (int l = 0; l < 5; l++)
				{
					int14 = rng.NextInt2(min, int11 + 1);
					float x = ((biome == Biome.Slime) ? (num6 / 2f) : num6);
					if (!EntityUtility.PointIsBlockedForSpawning(blockedAreas, int14, num6) && biomeLookup.IsOnlyBiomeInRange(int14, (int)math.ceil(x), biome))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					continue;
				}
				Entity entity = ecb.Instantiate(dynamicBuffer[num].prefabEntity);
				ecb.AddComponent(entity, new DungeonCleanup
				{
					AreaEntityRef = areaEntity,
					Biome = biome
				});
				ecb.SetComponent(entity, LocalTransform.FromPosition(int14.ToFloat3()));
				for (int m = int12.x; m < int13.x; m++)
				{
					for (int n = int12.y; n < int13.y; n++)
					{
						submapsWithRecentlySpawnedDungeons.Add(new RecentlySpawnedDungeon
						{
							MapPos = new int2(m, n),
							DungeonEntity = entity
						});
					}
				}
				break;
			}
			result.Dispose();
			return num != dynamicBuffer.Length;
		}

		private static void GetLargestSpawnArea(int2 min, int2 max, TileAccessor tileLookup, in NativeParallelHashSet<int2> mapsSpawningThisFrame, int4[] directions, int wantedSize, int2 startPos, ref NativeArray<AreaBounds> result)
		{
			bool flag = true;
			for (int i = min.x; i <= max.x; i++)
			{
				for (int j = min.y; j <= max.y; j++)
				{
					int2 int5 = new int2(i, j);
					if (math.any(int5 != startPos) && (tileLookup.IsInitialized(int5 * 64) || mapsSpawningThisFrame.Contains(int5)))
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			int x = (max + 1 - min).x;
			result[x - 1] = new AreaBounds
			{
				min = min * 64,
				max = (max + 1) * 64,
				isSet = true
			};
			if (wantedSize > x)
			{
				for (int k = 0; k < directions.Length; k++)
				{
					int2 min2 = min + new int2(directions[k].x, directions[k].y);
					int2 max2 = max + new int2(directions[k].z, directions[k].w);
					GetLargestSpawnArea(min2, max2, tileLookup, in mapsSpawningThisFrame, directions, wantedSize, startPos, ref result);
				}
			}
		}

		private void LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_0_Execute(ref bool skipSpawn, ref EntityCommandBuffer ecb, ref TileAccessor tileLookup, ref Unity.Mathematics.Random rng, ref Entity dungeonBiomeSpawnBufferEntityLocal, ref NativeArray<BlockedSpawnArea> blockedAreas, ref ComponentLookup<DungeonAreaCD> dungeonLookup, ref BufferLookup<DungeonSpawnTableBuffer> spawnBufferLookup, ref BiomeLookup biomeLookupLocal, ref int2 subMap2x2PartToSpawn, ref NativeParallelHashSet<int2> mapsSpawningThisFrame, ref NativeList<RecentlySpawnedDungeon> submapsWithSpawningDungeonsLocal)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_DungeonBiomeSpawnTableBuffer_RW_BufferLookup.Update(ref base.CheckedStateRef);
			LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_0_Job value = new LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_0_Job
			{
				skipSpawn = skipSpawn,
				ecb = ecb,
				tileLookup = tileLookup,
				rng = rng,
				dungeonBiomeSpawnBufferEntityLocal = dungeonBiomeSpawnBufferEntityLocal,
				blockedAreas = blockedAreas,
				dungeonLookup = dungeonLookup,
				spawnBufferLookup = spawnBufferLookup,
				biomeLookupLocal = biomeLookupLocal,
				subMap2x2PartToSpawn = subMap2x2PartToSpawn,
				mapsSpawningThisFrame = mapsSpawningThisFrame,
				submapsWithSpawningDungeonsLocal = submapsWithSpawningDungeonsLocal,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__areaTypeHandle = __TypeHandle.__ProceduralSpawnArea_RO_ComponentTypeHandle,
				__PugWorldGen_DungeonBiomeSpawnTableBuffer_BufferLookup = __TypeHandle.__PugWorldGen_DungeonBiomeSpawnTableBuffer_RW_BufferLookup
			};
			if (!__query_779746927_0.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_779746927_0, jobPtr);
			}
			skipSpawn = value.skipSpawn;
			ecb = value.ecb;
			tileLookup = value.tileLookup;
			rng = value.rng;
			dungeonBiomeSpawnBufferEntityLocal = value.dungeonBiomeSpawnBufferEntityLocal;
			blockedAreas = value.blockedAreas;
			dungeonLookup = value.dungeonLookup;
			spawnBufferLookup = value.spawnBufferLookup;
			biomeLookupLocal = value.biomeLookupLocal;
			subMap2x2PartToSpawn = value.subMap2x2PartToSpawn;
			mapsSpawningThisFrame = value.mapsSpawningThisFrame;
			submapsWithSpawningDungeonsLocal = value.submapsWithSpawningDungeonsLocal;
		}

		private void LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_1_Execute(ref EntityCommandBuffer ecb, ref NativeList<RecentlySpawnedDungeon> submapsWithSpawningDungeonsLocal)
		{
			__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
			__TypeHandle.__PugWorldGen_LegacyDungeonSpawnSystem_DungeonCleanup_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
			LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_1_Job value = new LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_1_Job
			{
				ecb = ecb,
				submapsWithSpawningDungeonsLocal = submapsWithSpawningDungeonsLocal,
				__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
				__cleanupTypeHandle = __TypeHandle.__PugWorldGen_LegacyDungeonSpawnSystem_DungeonCleanup_RO_ComponentTypeHandle
			};
			if (!__query_779746927_1.IsEmptyIgnoreFilter)
			{
				base.CheckedStateRef.CompleteDependency();
				IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
				LegacyDungeonSpawnSystem_5B6A9518_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_779746927_1, jobPtr);
			}
			ecb = value.ecb;
			submapsWithSpawningDungeonsLocal = value.submapsWithSpawningDungeonsLocal;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LegacySpawnDungeonInAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ProceduralSpawnArea>();
			query = (__query_779746927_0 = entityQueryBuilder2.Build(ref state));
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithNone<DungeonAreaCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonCleanup>();
			__query_779746927_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
			__query_779746927_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonBiomeSpawnTableBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_779746927_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_779746927_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_779746927_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_779746927_6 = entityQueryBuilder2.Build(ref state);
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
		public LegacyDungeonSpawnSystem()
		{
		}
	}
}
