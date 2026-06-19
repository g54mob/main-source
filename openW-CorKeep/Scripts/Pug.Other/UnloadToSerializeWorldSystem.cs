using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SerializationSystemGroup))]
[UpdateAfter(typeof(SerializeWorldSystem))]
[UpdateBefore(typeof(DeserializeComponentsSystem))]
public struct UnloadToSerializeWorldSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct CalculateMinMaxPositionJob : IJobChunk
	{
		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> LocalTransform;

		public ComponentTypeHandle<SerializedChunkMinMaxPosition> SerializedChunkMinMaxPosition;

		public uint LastSystemVersion;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			SerializedChunkMinMaxPosition chunkComponentData = chunk.GetChunkComponentData(ref SerializedChunkMinMaxPosition);
			if (chunk.DidChange(LocalTransform, LastSystemVersion) || chunk.DidOrderChange(LastSystemVersion) || math.all((chunkComponentData.Max == 0) & (chunkComponentData.Min == 0)))
			{
				int2 int5 = new int2(int.MaxValue, int.MaxValue);
				int2 int6 = new int2(int.MinValue, int.MinValue);
				NativeArray<LocalTransform> nativeArray = chunk.GetNativeArray(LocalTransform);
				for (int i = 0; i < chunk.Count; i++)
				{
					int2 y = (int2)nativeArray[i].Position.xz;
					int5 = math.min(int5, y);
					int6 = math.max(int6, y);
				}
				chunk.SetChunkComponentData(ref SerializedChunkMinMaxPosition, new SerializedChunkMinMaxPosition
				{
					Min = int5,
					Max = int6
				});
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(KeepAreaLoadedCD),
		typeof(LocalTransform)
	})]
	private struct FindEnabledPositions : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<KeepAreaLoadedCD> __KeepAreaLoadedCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__KeepAreaLoadedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<KeepAreaLoadedCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__KeepAreaLoadedCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<KeepAreaLoadedCD>();
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
			public void Run(ref FindEnabledPositions job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FindEnabledPositions job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FindEnabledPositions job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FindEnabledPositions job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FindEnabledPositions job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FindEnabledPositions job, EntityManager entityManager)
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

		public NativeList<PugGeometry.Circle> KeepAreaLoaded;

		public NativeList<PugGeometry.Circle> LoadArea;

		public NativeList<PugGeometry.Circle> LoadAreaImmediately;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(in LocalTransform localTransform, in KeepAreaLoadedCD keepAreaLoaded)
		{
			int2 int5 = localTransform.Position.RoundToInt2();
			KeepAreaLoaded.Add(PugGeometry.Circle.FromCenterRadius(int5, keepAreaLoaded.KeepLoadedRadius));
			LoadArea.Add(PugGeometry.Circle.FromCenterRadius(int5, keepAreaLoaded.StartLoadRadius));
			LoadAreaImmediately.Add(PugGeometry.Circle.FromCenterRadius(int5, keepAreaLoaded.ImmediateLoadRadius));
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__KeepAreaLoadedCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<KeepAreaLoadedCD>(nativeArrayPtr2, i));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<KeepAreaLoadedCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<KeepAreaLoadedCD>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<KeepAreaLoadedCD>(nativeArrayPtr2, k));
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

	[BurstCompile]
	private struct UnloadChunksTooFarAway : IJobChunk
	{
		public EntityCommandBuffer ECB;

		[ReadOnly]
		public NativeList<PugGeometry.Circle> KeepAreaLoaded;

		public NativeList<SerializedChunkData> Chunks;

		[ReadOnly]
		public EntityTypeHandle EntityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SerializedChunkMinMaxPosition> SerializedMinMaxPositionHandle;

		[ReadOnly]
		public ComponentTypeHandle<SerializedChunkData> SerializedChunkHandle;

		public EntityArchetype UnloadedChunkArchetype;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> LocalTransformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> ObjectDataTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DirectionCD> DirectionTypeHandle;

		public ObjectLookupWriterCD ObjectLookupWriter;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			SerializedChunkData chunkComponentData = chunk.GetChunkComponentData(SerializedChunkHandle);
			if (chunkComponentData.ChunkListIndex < 0 || chunkComponentData.StartIndex == 0)
			{
				return;
			}
			SerializedChunkMinMaxPosition chunkComponentData2 = chunk.GetChunkComponentData(SerializedMinMaxPositionHandle);
			if (math.all((chunkComponentData2.Min == int2.zero) & (chunkComponentData2.Max == int2.zero)))
			{
				return;
			}
			PugGeometry.AxisAlignedBoundingBox aabb = new PugGeometry.AxisAlignedBoundingBox
			{
				Low = chunkComponentData2.Min,
				High = chunkComponentData2.Max
			};
			foreach (PugGeometry.Circle item in KeepAreaLoaded)
			{
				if (item.Overlaps(aabb))
				{
					return;
				}
			}
			int chunkListIndex = chunkComponentData.ChunkListIndex;
			chunkComponentData.ChunkListIndex = -2;
			Chunks[chunkListIndex] = chunkComponentData;
			Entity e = ECB.CreateEntity(UnloadedChunkArchetype);
			ECB.SetComponent(e, new UnloadedChunkCD
			{
				ChunkListIndex = chunkListIndex,
				MinPosition = chunkComponentData2.Min,
				MaxPosition = chunkComponentData2.Max
			});
			NativeArray<Entity> nativeArray = chunk.GetNativeArray(EntityTypeHandle);
			ECB.DestroyEntity(nativeArray);
			NativeArray<LocalTransform> nativeArray2 = chunk.GetNativeArray(ref LocalTransformTypeHandle);
			NativeArray<ObjectDataCD> nativeArray3 = chunk.GetNativeArray(ref ObjectDataTypeHandle);
			if (!nativeArray2.IsCreated || !nativeArray3.IsCreated)
			{
				return;
			}
			NativeArray<DirectionCD> nativeArray4 = chunk.GetNativeArray(ref DirectionTypeHandle);
			if (nativeArray4.IsCreated)
			{
				for (int i = 0; i < chunk.Count; i++)
				{
					ObjectLookupWriter.Add(ECB, nativeArray3[i].objectID, nativeArray3[i].variation, nativeArray2[i].Position, hasDirection: true, nativeArray4[i]);
				}
			}
			else
			{
				for (int j = 0; j < chunk.Count; j++)
				{
					ObjectLookupWriter.Add(ECB, nativeArray3[j].objectID, nativeArray3[j].variation, nativeArray2[j].Position, hasDirection: false, default(DirectionCD));
				}
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct FindUnloadedChunksToLoad : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<UnloadedChunkCD> __UnloadedChunkCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__UnloadedChunkCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<UnloadedChunkCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__UnloadedChunkCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<UnloadedChunkCD>().Build(ref state);
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
			public void Run(ref FindUnloadedChunksToLoad job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FindUnloadedChunksToLoad job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FindUnloadedChunksToLoad job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FindUnloadedChunksToLoad job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FindUnloadedChunksToLoad job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FindUnloadedChunksToLoad job, EntityManager entityManager)
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

		public EntityCommandBuffer ECB;

		public ExclusiveEntityTransaction EntityTransactionSerializedWorld;

		[ReadOnly]
		public NativeList<PugGeometry.Circle> LoadArea;

		[ReadOnly]
		public NativeList<PugGeometry.Circle> LoadAreaImmediately;

		public NativeList<Entity> SerializedEntities;

		public NativeList<SerializeWorldDataCD.FreeEntityRange> FreeSerializedEntities;

		public NativeList<SerializedChunkData> Chunks;

		public NativeList<int> FreeChunks;

		private int _chunksLoadedThisTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, in UnloadedChunkCD unloadedChunk)
		{
			if (OverlapsAny(new PugGeometry.AxisAlignedBoundingBox
			{
				Low = unloadedChunk.MinPosition,
				High = unloadedChunk.MaxPosition
			}, (_chunksLoadedThisTick >= 10) ? LoadAreaImmediately : LoadArea))
			{
				_chunksLoadedThisTick++;
				ECB.DestroyEntity(entity);
				SerializedChunkData serializedChunkData = Chunks[unloadedChunk.ChunkListIndex];
				Chunks[unloadedChunk.ChunkListIndex] = default(SerializedChunkData);
				FreeChunks.Add(in unloadedChunk.ChunkListIndex);
				ref NativeList<SerializeWorldDataCD.FreeEntityRange> freeSerializedEntities = ref FreeSerializedEntities;
				SerializeWorldDataCD.FreeEntityRange value = new SerializeWorldDataCD.FreeEntityRange
				{
					StartIndex = serializedChunkData.StartIndex,
					Capacity = serializedChunkData.Capacity
				};
				freeSerializedEntities.Add(in value);
				for (int i = 0; i < serializedChunkData.Count; i++)
				{
					Entity entity2 = SerializedEntities[serializedChunkData.StartIndex + i];
					EntityTransactionSerializedWorld.AddComponent(entity2, ComponentType.ReadOnly<SerializedEntityPendingLoadCD>());
				}
			}
		}

		private static bool OverlapsAny(PugGeometry.AxisAlignedBoundingBox aabb, NativeList<PugGeometry.Circle> circles)
		{
			for (int i = 0; i < circles.Length; i++)
			{
				if (circles[i].Overlaps(aabb))
				{
					return true;
				}
			}
			return false;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__UnloadedChunkCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UnloadedChunkCD>(nativeArrayPtr2, i));
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
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UnloadedChunkCD>(nativeArrayPtr2, nextRangeBegin));
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
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UnloadedChunkCD>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<UnloadedChunkCD>(nativeArrayPtr2, k));
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

	[BurstCompile]
	private struct EndEntityTransactionJob : IJob
	{
		public EntityManager EntityManager;

		public void Execute()
		{
			EntityManager.EndExclusiveEntityTransaction();
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		public ComponentTypeHandle<SerializedChunkMinMaxPosition> __SerializedChunkMinMaxPosition_RW_ComponentTypeHandle;

		public FindEnabledPositions.InternalCompilerQueryAndHandleData __UnloadToSerializeWorldSystem_FindEnabledPositions_WithoutDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SerializedChunkMinMaxPosition> __SerializedChunkMinMaxPosition_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SerializedChunkData> __SerializedChunkData_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DirectionCD> __DirectionCD_RO_ComponentTypeHandle;

		public FindUnloadedChunksToLoad.InternalCompilerQueryAndHandleData __UnloadToSerializeWorldSystem_FindUnloadedChunksToLoad_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__SerializedChunkMinMaxPosition_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SerializedChunkMinMaxPosition>();
			__UnloadToSerializeWorldSystem_FindEnabledPositions_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__SerializedChunkMinMaxPosition_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SerializedChunkMinMaxPosition>(isReadOnly: true);
			__SerializedChunkData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SerializedChunkData>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DirectionCD>(isReadOnly: true);
			__UnloadToSerializeWorldSystem_FindUnloadedChunksToLoad_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000035FD_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000035FD_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000035FD_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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

	private EntityArchetype _unloadedChunkArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_959651964_0;

	private EntityQuery __query_959651964_1;

	private EntityQuery __query_959651964_2;

	private EntityQuery __query_959651964_3;

	private EntityQuery __query_959651964_4;

	private EntityQuery __query_959651964_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		NativeArray<ComponentType> types = new NativeArray<ComponentType>(1, Allocator.Temp);
		types[0] = ComponentType.ReadOnly<UnloadedChunkCD>();
		_unloadedChunkArchetype = state.EntityManager.CreateArchetype(types);
		types.Dispose();
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<SerializeWorldDataCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<ObjectLookupWriterCD>();
	}

	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer eCB = __query_959651964_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		SerializeWorldDataCD singleton = __query_959651964_4.GetSingleton<SerializeWorldDataCD>();
		NativeList<Entity> serializedEntities = singleton.serializedEntities;
		NativeList<SerializedChunkData> chunks = singleton.chunks;
		CalculateMinMaxPositionJob jobData = new CalculateMinMaxPositionJob
		{
			LocalTransform = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle, ref state),
			SerializedChunkMinMaxPosition = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__SerializedChunkMinMaxPosition_RW_ComponentTypeHandle, ref state),
			LastSystemVersion = state.LastSystemVersion
		};
		EntityQuery _query_959651964_ = __query_959651964_0;
		state.Dependency = JobChunkExtensions.Schedule(jobData, _query_959651964_, state.Dependency);
		EntityQuery _query_959651964_2 = __query_959651964_1;
		FindEnabledPositions job = new FindEnabledPositions
		{
			KeepAreaLoaded = new NativeList<PugGeometry.Circle>(12, state.WorldUpdateAllocator),
			LoadArea = new NativeList<PugGeometry.Circle>(12, state.WorldUpdateAllocator),
			LoadAreaImmediately = new NativeList<PugGeometry.Circle>(12, state.WorldUpdateAllocator)
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, _query_959651964_2, state.Dependency, ref state, hasUserDefinedQuery: true);
		if (singleton.State == SerializeWorldState.UpdatingOutputWorld)
		{
			UnloadChunksTooFarAway jobData2 = new UnloadChunksTooFarAway
			{
				ECB = eCB,
				KeepAreaLoaded = job.KeepAreaLoaded,
				Chunks = chunks,
				EntityTypeHandle = InternalCompilerInterface.GetEntityTypeHandle(ref __TypeHandle.__Unity_Entities_Entity_TypeHandle, ref state),
				SerializedMinMaxPositionHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__SerializedChunkMinMaxPosition_RO_ComponentTypeHandle, ref state),
				SerializedChunkHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__SerializedChunkData_RO_ComponentTypeHandle, ref state),
				UnloadedChunkArchetype = _unloadedChunkArchetype,
				ObjectLookupWriter = __query_959651964_5.GetSingleton<ObjectLookupWriterCD>(),
				ObjectDataTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle, ref state),
				DirectionTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__DirectionCD_RO_ComponentTypeHandle, ref state),
				LocalTransformTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle, ref state)
			};
			EntityQuery _query_959651964_3 = __query_959651964_2;
			state.Dependency = JobChunkExtensions.Schedule(jobData2, _query_959651964_3, state.Dependency);
		}
		if (singleton.State == SerializeWorldState.Idle)
		{
			eCB.AddComponent<AreaLoadedCD>(_query_959651964_2, EntityQueryCaptureMode.AtRecord);
			FindUnloadedChunksToLoad job2 = new FindUnloadedChunksToLoad
			{
				ECB = eCB,
				EntityTransactionSerializedWorld = singleton.entityManager.BeginExclusiveEntityTransaction(),
				LoadArea = job.LoadArea,
				LoadAreaImmediately = job.LoadAreaImmediately,
				SerializedEntities = serializedEntities,
				FreeSerializedEntities = singleton.freeRangeList,
				Chunks = chunks,
				FreeChunks = singleton.freeChunks
			};
			state.Dependency = __ScheduleViaJobChunkExtension_1(job2, __TypeHandle.__UnloadToSerializeWorldSystem_FindUnloadedChunksToLoad_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			EndEntityTransactionJob jobData3 = new EndEntityTransactionJob
			{
				EntityManager = singleton.entityManager
			};
			state.Dependency = IJobExtensions.Schedule(jobData3, state.Dependency);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(FindEnabledPositions job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__UnloadToSerializeWorldSystem_FindEnabledPositions_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__UnloadToSerializeWorldSystem_FindEnabledPositions_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__UnloadToSerializeWorldSystem_FindEnabledPositions_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__UnloadToSerializeWorldSystem_FindEnabledPositions_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(FindUnloadedChunksToLoad job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__UnloadToSerializeWorldSystem_FindUnloadedChunksToLoad_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__UnloadToSerializeWorldSystem_FindUnloadedChunksToLoad_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__UnloadToSerializeWorldSystem_FindUnloadedChunksToLoad_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__UnloadToSerializeWorldSystem_FindUnloadedChunksToLoad_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllChunkComponent<SerializedChunkMinMaxPosition>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_959651964_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<KeepAreaLoadedCD, LocalTransform>();
		__query_959651964_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllChunkComponent<SerializedChunkMinMaxPosition>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_959651964_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_959651964_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SerializeWorldDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_959651964_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectLookupWriterCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_959651964_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000035FD_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((UnloadToSerializeWorldSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UnloadToSerializeWorldSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UnloadToSerializeWorldSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}
}
