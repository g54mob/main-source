using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace PugWorldGen
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.Editor | WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	[UpdateAfter(typeof(DungeonAssignSeedSystem))]
	[UpdateAfter(typeof(DungeonPlaceRoomsSystem))]
	public struct DungeonPlacePathsSystem : ISystem, ISystemCompilerGenerated
	{
		private struct Path
		{
			public int FromRoom;

			public int ToRoom;
		}

		[BurstCompile]
		[WithAll(new Type[] { typeof(DungeonGenerationInitializationCD) })]
		private struct GeneratePathsJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public BufferTypeHandle<DungeonPathBuffer> __PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle;

					public BufferTypeHandle<DungeonRoomBuffer> __PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<DungeonAreaCD> __PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<DungeonPathPlacementBuffer> __PugWorldGen_DungeonPathPlacementBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonPathBuffer>();
						__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<DungeonRoomBuffer>();
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DungeonAreaCD>(isReadOnly: true);
						__PugWorldGen_DungeonPathPlacementBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DungeonPathPlacementBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle.Update(ref state);
						__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle.Update(ref state);
						__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle.Update(ref state);
						__PugWorldGen_DungeonPathPlacementBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonAreaCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonPathPlacementBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<DungeonGenerationInitializationCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonPathBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DungeonRoomBuffer>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
					entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					if (assignDefaultQuery)
					{
						__AssignQueries(ref state);
					}
					__TypeHandle.__AssignHandles(ref state);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void Run(ref GeneratePathsJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref GeneratePathsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref GeneratePathsJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref GeneratePathsJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref GeneratePathsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref GeneratePathsJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			public NativeParallelMultiHashMap<int, int> RoomAdjacencyList;

			public NativeList<Path> ReusablePathList;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(ref DynamicBuffer<DungeonPathBuffer> pathBuffer, ref DynamicBuffer<DungeonRoomBuffer> roomBuffer, in DungeonAreaCD dungeonArea, in DynamicBuffer<DungeonPathPlacementBuffer> pathConfigurations)
			{
				Unity.Mathematics.Random rng = new Unity.Mathematics.Random(0xFEE70 ^ dungeonArea.seed);
				if (roomBuffer.Length == 0)
				{
					return;
				}
				RoomAdjacencyList.Clear();
				ReusablePathList.Clear();
				ReusablePathList.Capacity = math.max(ReusablePathList.Capacity, roomBuffer.Length * roomBuffer.Length);
				for (int i = 0; i < pathConfigurations.Length; i++)
				{
					DungeonPathPlacement value = pathConfigurations[i].Value;
					switch (value.placement)
					{
					case PathPlacementAlgorithm.Random:
						PlacePathsRandom(value, ref rng, ref pathBuffer, ref RoomAdjacencyList, in roomBuffer, ref ReusablePathList);
						break;
					case PathPlacementAlgorithm.All:
						PlacePathsAll(value, ref rng, ref pathBuffer, ref RoomAdjacencyList, in roomBuffer, ref ReusablePathList);
						break;
					case PathPlacementAlgorithm.MinSpanningTree:
						PlacePathsSpanningTree(value, ref pathBuffer, ref RoomAdjacencyList, in roomBuffer, ref ReusablePathList);
						break;
					case PathPlacementAlgorithm.LongestPath:
						PlacePathsLongestDistance(value, ref pathBuffer, ref RoomAdjacencyList, in roomBuffer);
						break;
					case PathPlacementAlgorithm.ShortestPath:
						PlacePathsShortestDistance(value, ref pathBuffer, ref RoomAdjacencyList, in roomBuffer);
						break;
					default:
						UnityEngine.Debug.LogError("Dungeon path algo has no implementation");
						break;
					case PathPlacementAlgorithm.None:
						break;
					}
					for (int j = 0; j < roomBuffer.Length; j++)
					{
						int num = RoomAdjacencyList.CountValuesForKey(j);
						if (num == 1)
						{
							roomBuffer.ElementAt(j).room.flags |= RoomFlags.End;
						}
						else
						{
							roomBuffer.ElementAt(j).room.flags &= ~RoomFlags.End;
						}
						if (num > 1)
						{
							roomBuffer.ElementAt(j).room.flags |= RoomFlags.Connecting;
						}
						else
						{
							roomBuffer.ElementAt(j).room.flags &= ~RoomFlags.Connecting;
						}
					}
				}
				RoomAdjacencyList.Clear();
				ReusablePathList.Clear();
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				BufferAccessor<DungeonPathBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__PugWorldGen_DungeonPathBuffer_RW_BufferTypeHandle);
				BufferAccessor<DungeonRoomBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__PugWorldGen_DungeonRoomBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PugWorldGen_DungeonAreaCD_RO_ComponentTypeHandle);
				BufferAccessor<DungeonPathPlacementBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__PugWorldGen_DungeonPathPlacementBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						DynamicBuffer<DungeonPathBuffer> pathBuffer = bufferAccessor[i];
						DynamicBuffer<DungeonRoomBuffer> roomBuffer = bufferAccessor2[i];
						Execute(ref pathBuffer, ref roomBuffer, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, i), bufferAccessor3[i]);
						num++;
					}
					return;
				}
				if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int nextRangeBegin = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
					{
						while (nextRangeBegin < nextRangeEnd)
						{
							DynamicBuffer<DungeonPathBuffer> pathBuffer2 = bufferAccessor[nextRangeBegin];
							DynamicBuffer<DungeonRoomBuffer> roomBuffer2 = bufferAccessor2[nextRangeBegin];
							Execute(ref pathBuffer2, ref roomBuffer2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, nextRangeBegin), bufferAccessor3[nextRangeBegin]);
							nextRangeBegin++;
							num++;
						}
					}
					return;
				}
				ulong num2 = chunkEnabledMask.ULong0;
				int num3 = math.min(64, count);
				for (int j = 0; j < num3; j++)
				{
					if ((num2 & 1) != 0L)
					{
						DynamicBuffer<DungeonPathBuffer> pathBuffer3 = bufferAccessor[j];
						DynamicBuffer<DungeonRoomBuffer> roomBuffer3 = bufferAccessor2[j];
						Execute(ref pathBuffer3, ref roomBuffer3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, j), bufferAccessor3[j]);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						DynamicBuffer<DungeonPathBuffer> pathBuffer4 = bufferAccessor[k];
						DynamicBuffer<DungeonRoomBuffer> roomBuffer4 = bufferAccessor2[k];
						Execute(ref pathBuffer4, ref roomBuffer4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DungeonAreaCD>(nativeArrayPtr, k), bufferAccessor3[k]);
						num++;
					}
					num2 >>= 1;
				}
			}

			private JobHandle __ThrowCodeGenException()
			{
				throw new Exception("This method should have been replaced by source gen.");
			}

			public void Run()
			{
				__ThrowCodeGenException();
			}

			public void RunByRef()
			{
				__ThrowCodeGenException();
			}

			public void Run(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public void RunByRef(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public void Schedule()
			{
				__ThrowCodeGenException();
			}

			public void ScheduleByRef()
			{
				__ThrowCodeGenException();
			}

			public void Schedule(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public void ScheduleByRef(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			public void ScheduleParallel()
			{
				__ThrowCodeGenException();
			}

			public void ScheduleParallelByRef()
			{
				__ThrowCodeGenException();
			}

			public void ScheduleParallel(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public void ScheduleParallelByRef(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct IncreasingPathLengthComparer : IComparer<Path>
		{
			public DynamicBuffer<DungeonRoomBuffer> Rooms;

			public int Compare(Path x, Path y)
			{
				int2 obj = Rooms[x.FromRoom].room.position - Rooms[x.ToRoom].room.position;
				int2 int5 = Rooms[y.FromRoom].room.position - Rooms[y.ToRoom].room.position;
				return math.lengthsq(obj).CompareTo(math.lengthsq(int5));
			}
		}

		private struct IncreasingExternalValuesComparer : IComparer<int>
		{
			public NativeArray<int> Values;

			public int Compare(int x, int y)
			{
				return Values[x].CompareTo(Values[y]);
			}
		}

		private struct DecreasingExternalValuesComparer : IComparer<int>
		{
			public NativeArray<int> Values;

			public int Compare(int x, int y)
			{
				return -Values[x].CompareTo(Values[y]);
			}
		}

		private struct TypeHandle
		{
			public GeneratePathsJob.InternalCompilerQueryAndHandleData __PugWorldGen_DungeonPlacePathsSystem_GeneratePathsJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PugWorldGen_DungeonPlacePathsSystem_GeneratePathsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000019E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000019E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000019E_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_0000019F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000019F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000019F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private const int SEED_OFFSET = 1044080;

		private EntityQuery _generatePathQuery;

		private TypeHandle __TypeHandle;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<DungeonGenerationInitializationCD>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			NativeParallelMultiHashMap<int, int> roomAdjacencyList = new NativeParallelMultiHashMap<int, int>(1024, state.WorldUnmanaged.UpdateAllocator.ToAllocator);
			NativeList<Path> reusablePathList = new NativeList<Path>(1024, state.WorldUnmanaged.UpdateAllocator.ToAllocator);
			GeneratePathsJob job = new GeneratePathsJob
			{
				RoomAdjacencyList = roomAdjacencyList,
				ReusablePathList = reusablePathList
			};
			state.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__PugWorldGen_DungeonPlacePathsSystem_GeneratePathsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		private static void PlacePathsAll(DungeonPathPlacement config, ref Unity.Mathematics.Random rng, ref DynamicBuffer<DungeonPathBuffer> pathBuffer, ref NativeParallelMultiHashMap<int, int> roomAdjacencyList, in DynamicBuffer<DungeonRoomBuffer> roomBuffer, ref NativeList<Path> pathList)
		{
			pathList.Clear();
			GetAllValidPaths(config, in roomBuffer, ref pathList);
			PugRandom.ShuffleListKindOfRandomly(pathList, ref rng);
			foreach (Path path in pathList)
			{
				if (!IntersectsExistingPath(config, path.FromRoom, path.ToRoom, in roomAdjacencyList, in roomBuffer))
				{
					CreateNewPath(in config, path.FromRoom, path.ToRoom, ref pathBuffer, ref roomAdjacencyList, in roomBuffer);
				}
			}
		}

		private static void PlacePathsRandom(DungeonPathPlacement config, ref Unity.Mathematics.Random rng, ref DynamicBuffer<DungeonPathBuffer> pathBuffer, ref NativeParallelMultiHashMap<int, int> roomAdjacencyList, in DynamicBuffer<DungeonRoomBuffer> roomBuffer, ref NativeList<Path> pathList)
		{
			pathList.Clear();
			GetAllValidPaths(config, in roomBuffer, ref pathList);
			PugRandom.ShuffleListKindOfRandomly(pathList, ref rng);
			int num = rng.NextInt(config.amount.min, config.amount.max + 1);
			if (num == 0)
			{
				return;
			}
			int num2 = 0;
			foreach (Path path in pathList)
			{
				if (!IntersectsExistingPath(config, path.FromRoom, path.ToRoom, in roomAdjacencyList, in roomBuffer))
				{
					CreateNewPath(in config, path.FromRoom, path.ToRoom, ref pathBuffer, ref roomAdjacencyList, in roomBuffer);
					num2++;
					if (num2 >= num)
					{
						break;
					}
				}
			}
		}

		private static void PlacePathsSpanningTree(DungeonPathPlacement config, ref DynamicBuffer<DungeonPathBuffer> pathBuffer, ref NativeParallelMultiHashMap<int, int> roomAdjacencyList, in DynamicBuffer<DungeonRoomBuffer> roomBuffer, ref NativeList<Path> pathList)
		{
			pathList.Clear();
			GetAllValidPaths(config, in roomBuffer, ref pathList);
			NativeUnionFind nativeUnionFind = new NativeUnionFind(roomBuffer.Length, Allocator.Temp);
			try
			{
				pathList.Sort(new IncreasingPathLengthComparer
				{
					Rooms = roomBuffer
				});
				foreach (Path path in pathList)
				{
					if (!nativeUnionFind.AreInSameSet(path.FromRoom, path.ToRoom) && !IntersectsExistingPath(config, path.FromRoom, path.ToRoom, in roomAdjacencyList, in roomBuffer))
					{
						CreateNewPath(in config, path.FromRoom, path.ToRoom, ref pathBuffer, ref roomAdjacencyList, in roomBuffer);
						nativeUnionFind.Merge(path.FromRoom, path.ToRoom);
					}
				}
			}
			finally
			{
				((IDisposable)nativeUnionFind/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private static void PlacePathsLongestDistance(DungeonPathPlacement config, ref DynamicBuffer<DungeonPathBuffer> pathBuffer, ref NativeParallelMultiHashMap<int, int> roomAdjacencyList, in DynamicBuffer<DungeonRoomBuffer> roomBuffer)
		{
			FindDistanceBfs(config.pathStartRoomType, ref roomAdjacencyList, in roomBuffer, out var roomDistance);
			NativeArray<int> array = new NativeArray<int>(roomBuffer.Length, Allocator.Temp);
			for (int i = 0; i < roomBuffer.Length; i++)
			{
				array[i] = i;
			}
			array.Sort(new DecreasingExternalValuesComparer
			{
				Values = roomDistance
			});
			for (int j = 0; j < roomBuffer.Length; j++)
			{
				if (!roomBuffer[j].room.flags.Matches(config.pathEndRoomType) || roomDistance[j] != int.MaxValue)
				{
					continue;
				}
				foreach (int item in array)
				{
					if (roomDistance[item] != int.MaxValue)
					{
						RoomCD room = roomBuffer[item].room;
						if (!config.pathEndRoomType.Matches(room.flags) && !IntersectsExistingPath(config, j, item, in roomAdjacencyList, in roomBuffer))
						{
							CreateNewPath(in config, j, item, ref pathBuffer, ref roomAdjacencyList, in roomBuffer);
							break;
						}
					}
				}
			}
			roomDistance.Dispose();
			array.Dispose();
		}

		private static void PlacePathsShortestDistance(DungeonPathPlacement config, ref DynamicBuffer<DungeonPathBuffer> pathBuffer, ref NativeParallelMultiHashMap<int, int> roomAdjacencyList, in DynamicBuffer<DungeonRoomBuffer> roomBuffer)
		{
			FindDistanceBfs(config.pathStartRoomType, ref roomAdjacencyList, in roomBuffer, out var roomDistance);
			NativeArray<int> array = new NativeArray<int>(roomBuffer.Length, Allocator.Temp);
			for (int i = 0; i < roomBuffer.Length; i++)
			{
				array[i] = i;
			}
			array.Sort(new IncreasingExternalValuesComparer
			{
				Values = roomDistance
			});
			for (int j = 0; j < roomBuffer.Length; j++)
			{
				if (!roomBuffer[j].room.flags.Matches(config.pathEndRoomType))
				{
					continue;
				}
				foreach (int item in array)
				{
					RoomCD room = roomBuffer[item].room;
					if (!config.pathEndRoomType.Matches(room.flags))
					{
						if (roomDistance[item] + 1 >= roomDistance[j])
						{
							break;
						}
						if (!IntersectsExistingPath(config, j, item, in roomAdjacencyList, in roomBuffer))
						{
							CreateNewPath(in config, j, item, ref pathBuffer, ref roomAdjacencyList, in roomBuffer);
							break;
						}
					}
				}
			}
			roomDistance.Dispose();
			array.Dispose();
		}

		private static void CreateNewPath(in DungeonPathPlacement config, int from, int to, ref DynamicBuffer<DungeonPathBuffer> pathBuffer, ref NativeParallelMultiHashMap<int, int> roomAdjacencyList, in DynamicBuffer<DungeonRoomBuffer> roomBuffer)
		{
			roomAdjacencyList.Add(from, to);
			roomAdjacencyList.Add(to, from);
			PathCD path = new PathCD
			{
				from = roomBuffer[from].room.position,
				to = roomBuffer[to].room.position,
				flags = (roomBuffer[from].room.flags | roomBuffer[to].room.flags),
				width = config.width
			};
			pathBuffer.Add(new DungeonPathBuffer
			{
				path = path,
				spawnTemplate = BlobAssetReference<SpawnTemplateBlob>.Null
			});
		}

		private static void FindDistanceBfs(RoomFlags startRoomType, ref NativeParallelMultiHashMap<int, int> roomAdjacencyList, in DynamicBuffer<DungeonRoomBuffer> roomBuffer, out NativeArray<int> roomDistance)
		{
			roomDistance = new NativeArray<int>(roomBuffer.Length, Allocator.Temp);
			for (int i = 0; i < roomBuffer.Length; i++)
			{
				roomDistance[i] = int.MaxValue;
			}
			using NativeQueue<int> nativeQueue = new NativeQueue<int>(Allocator.Temp);
			for (int j = 0; j < roomBuffer.Length; j++)
			{
				if (startRoomType.Matches(roomBuffer[j].room.flags))
				{
					roomDistance[j] = 0;
					nativeQueue.Enqueue(j);
				}
			}
			int item;
			while (nativeQueue.TryDequeue(out item))
			{
				foreach (int item2 in roomAdjacencyList.GetValuesForKey(item))
				{
					if (roomDistance[item2] == int.MaxValue)
					{
						roomDistance[item2] = roomDistance[item] + 1;
						nativeQueue.Enqueue(item2);
					}
				}
			}
		}

		private static void GetAllValidPaths(DungeonPathPlacement config, in DynamicBuffer<DungeonRoomBuffer> roomBuffer, ref NativeList<Path> pathList)
		{
			for (int i = 0; i < roomBuffer.Length; i++)
			{
				for (int j = i + 1; j < roomBuffer.Length; j++)
				{
					RoomCD room = roomBuffer[i].room;
					RoomCD room2 = roomBuffer[j].room;
					if (config.roomType.Matches(room.flags) && config.roomType.Matches(room2.flags))
					{
						int2 position = room.position;
						int2 position2 = room2.position;
						if ((!config.straightPaths || !math.all(math.abs(position - position2) > 0)) && !IntersectsRoom(config, position, position2, in roomBuffer))
						{
							Path value = new Path
							{
								FromRoom = i,
								ToRoom = j
							};
							pathList.Add(in value);
						}
					}
				}
			}
		}

		private static bool IntersectsExistingPath(DungeonPathPlacement config, int from, int to, in NativeParallelMultiHashMap<int, int> roomAdjacencyList, in DynamicBuffer<DungeonRoomBuffer> roomBuffer)
		{
			int2 position = roomBuffer[from].room.position;
			int2 position2 = roomBuffer[to].room.position;
			foreach (KeyValue<int, int> roomAdjacency in roomAdjacencyList)
			{
				int key = roomAdjacency.Key;
				int value = roomAdjacency.Value;
				RoomFlags otherFlags = roomBuffer[key].room.flags | roomBuffer[value].room.flags;
				if (key != from && key != to && value != from && value != to && !config.canIntersectPaths.Matches(otherFlags) && MathUtilities.LinesIntersect(position, position2, roomBuffer[key].room.position, roomBuffer[value].room.position))
				{
					return true;
				}
			}
			return false;
		}

		private static bool IntersectsRoom(DungeonPathPlacement config, int2 fromPos, int2 toPos, in DynamicBuffer<DungeonRoomBuffer> roomBuffer)
		{
			for (int i = 0; i < roomBuffer.Length; i++)
			{
				RoomCD room = roomBuffer[i].room;
				if (!room.flags.Matches(RoomFlags.Fill) && !config.canIntersectRooms.Matches(room.flags) && math.any(fromPos != room.position) && math.any(toPos != room.position) && MathUtilities.IntersectsCircle(fromPos, toPos, room.position, (float)room.size + 2f))
				{
					return true;
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(GeneratePathsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PugWorldGen_DungeonPlacePathsSystem_GeneratePathsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PugWorldGen_DungeonPlacePathsSystem_GeneratePathsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PugWorldGen_DungeonPlacePathsSystem_GeneratePathsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PugWorldGen_DungeonPlacePathsSystem_GeneratePathsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			new EntityQueryBuilder(Allocator.Temp).Dispose();
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
			__codegen__OnCreate_0000019E_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000019F_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((DungeonPlacePathsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((DungeonPlacePathsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((DungeonPlacePathsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
