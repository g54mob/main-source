using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct DestroyEntityIfNotOnTileSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithNone(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(TileCD)
	})]
	private struct DestroyEntityIfNotOnTileJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<DestroyEntityIfNotOnTileCD> __DestroyEntityIfNotOnTileCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__DestroyEntityIfNotOnTileCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<DestroyEntityIfNotOnTileCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__DestroyEntityIfNotOnTileCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<TileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DestroyEntityIfNotOnTileCD>();
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
			public void Run(ref DestroyEntityIfNotOnTileJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DestroyEntityIfNotOnTileJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DestroyEntityIfNotOnTileJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DestroyEntityIfNotOnTileJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DestroyEntityIfNotOnTileJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DestroyEntityIfNotOnTileJob job, EntityManager entityManager)
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

		public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;

		public EntityCommandBuffer Ecb;

		public float DeltaTime;

		public uint Seed;

		[ReadOnly]
		public TileAccessor TileAccessor;

		[ReadOnly]
		public ComponentLookup<EnemyCD> EnemyLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> DirectionLookup;

		[ReadOnly]
		public ComponentLookup<SurfacePriorityCD> SurfacePriorityLookup;

		public ComponentLookup<HealthCD> HealthLookup;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> DontDropLootLookup;

		[ReadOnly]
		public ComponentLookup<CustomSceneObjectCD> CustomSceneLootLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, ref DestroyEntityIfNotOnTileCD destroyCD, in LocalTransform transform, in ObjectDataCD objectData, in ObjectPropertiesCD properties)
		{
			destroyCD.timer -= DeltaTime;
			if (destroyCD.timer > 0f || (CustomSceneLootLookup.HasComponent(entity) && objectData.objectID != ObjectID.FishShoal && !properties.Has(-1544243617)))
			{
				return;
			}
			Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex((uint)(entity.Index ^ entity.Version) ^ Seed);
			bool flag = EnemyLookup.HasComponent(entity);
			destroyCD.timer = (flag ? random.NextFloat(2f, 4f) : random.NextFloat(1f, 2f));
			bool flag2 = false;
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectData.objectID, Database);
			int2 size = entityObjectInfo.prefabTileSize;
			int2 offset = entityObjectInfo.prefabCornerOffset;
			if (DirectionLookup.TryGetComponent(entity, out var componentData))
			{
				componentData.GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
			}
			TileCD tileCD = default(TileCD);
			bool flag3 = properties.Has(-387040359);
			bool flag4 = properties.Has(-1171401773);
			bool flag5 = properties.Has(1087164581);
			bool flag6 = properties.Has(794428061);
			bool flag7 = properties.Has(-1544243617);
			bool flag8 = properties.Has(-1229871138);
			bool flag9 = properties.Has(-2085468759);
			for (int i = offset.x; i < size.x + offset.x; i++)
			{
				for (int j = offset.y; j < size.y + offset.y; j++)
				{
					flag2 = true;
					int2 int5 = transform.Position.RoundToInt2() + new int2(i, j);
					TileCD top = TileAccessor.GetTop(int5);
					ObjectID objectID = PugDatabase.GetObjectID(top.tileset, top.tileType, Database);
					bool flag10 = flag3 || flag4 || flag5 || flag6 || flag7;
					bool flag11 = top.tileType == TileType.water && top.tileset != 3;
					SurfacePriorityCD componentData2;
					bool flag12 = flag4 && (flag11 || (SurfacePriorityLookup.TryGetComponent(entity, out componentData2) && componentData2.Value < TileType.water.GetSurfacePriorityFromJob() && TileAccessor.HasType(int5, TileType.water)));
					bool flag13 = top.tileType == TileType.water && top.tileset == 3;
					bool flag14 = flag5 && flag13;
					bool flag15 = top.tileType == TileType.pit;
					bool flag16 = flag6 && flag15;
					bool variationZeroIsNoDirection = properties.Has(-377237680);
					bool flag17 = top.tileType == TileType.wall;
					bool flag18 = flag7 && top.tileType != TileType.wall && TileAccessor.HasType(int5 - DirectionBasedOnVariationCD.GetDirectionFromVariation(objectData.variation, variationZeroIsNoDirection), TileType.wall);
					bool flag19 = (flag3 && (top.tileType.IsWalkableTile() || (flag8 && top.tileType.IsBlockingOnWalkableTile()))) || flag12 || flag14 || flag16 || flag18;
					bool flag20 = !flag8 && top.tileType.IsBlockingOnWalkableTile();
					if (flag9 && top.tileType.IsLowCollider())
					{
						flag19 = true;
						flag20 = false;
					}
					if (flag && top.tileType.HasThinCollider())
					{
						flag19 = true;
						flag20 = false;
					}
					bool flag21 = tileCD.tileType == TileType.water && tileCD.tileset != 3;
					bool num = tileCD.tileType != TileType.none && flag21 != flag11;
					bool flag22 = tileCD.tileType == TileType.water && tileCD.tileset == 3;
					bool flag23 = tileCD.tileType != TileType.none && flag22 != flag13;
					bool flag24 = tileCD.tileType == TileType.pit;
					bool flag25 = tileCD.tileType != TileType.none && flag24 != flag15;
					bool flag26 = tileCD.tileType == TileType.wall;
					bool flag27 = tileCD.tileType != TileType.none && flag26 != flag17;
					tileCD = top;
					if (num || flag23 || flag25 || flag27)
					{
						flag2 = false;
					}
					else if ((flag10 && !flag19) || flag20)
					{
						flag2 = false;
					}
					else if (flag10)
					{
						if (properties.TryGetList(1985931659, out NativeArray<ObjectID> value, (AllocatorManager.AllocatorHandle)Allocator.Temp))
						{
							foreach (ObjectID item in value)
							{
								if (objectID == item)
								{
									flag2 = false;
									break;
								}
							}
						}
					}
					else
					{
						flag2 = false;
						if (properties.TryGetList(-179233515, out NativeArray<ObjectID> value2, (AllocatorManager.AllocatorHandle)Allocator.Temp))
						{
							foreach (ObjectID item2 in value2)
							{
								if (objectID == item2)
								{
									flag2 = true;
									break;
								}
							}
						}
					}
					if (!flag2)
					{
						break;
					}
				}
				if (!flag2)
				{
					break;
				}
			}
			if (!flag2)
			{
				if (HealthLookup.HasComponent(entity))
				{
					HealthLookup[entity] = new HealthCD
					{
						health = 0,
						maxHealth = 1
					};
				}
				else
				{
					Ecb.SetComponentEnabled<EntityDestroyedCD>(entity, value: true);
				}
				if (flag && DontDropLootLookup.HasComponent(entity))
				{
					Ecb.SetComponentEnabled<DontDropLootCD>(entity, value: true);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__DestroyEntityIfNotOnTileCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyEntityIfNotOnTileCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyEntityIfNotOnTileCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyEntityIfNotOnTileCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyEntityIfNotOnTileCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, k));
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

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SurfacePriorityCD> __SurfacePriorityCD_RO_ComponentLookup;

		public ComponentLookup<HealthCD> __HealthCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> __DontDropLootCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CustomSceneObjectCD> __CustomSceneObjectCD_RO_ComponentLookup;

		public DestroyEntityIfNotOnTileJob.InternalCompilerQueryAndHandleData __DestroyEntityIfNotOnTileSystem_DestroyEntityIfNotOnTileJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__SurfacePriorityCD_RO_ComponentLookup = state.GetComponentLookup<SurfacePriorityCD>(isReadOnly: true);
			__HealthCD_RW_ComponentLookup = state.GetComponentLookup<HealthCD>();
			__DontDropLootCD_RO_ComponentLookup = state.GetComponentLookup<DontDropLootCD>(isReadOnly: true);
			__CustomSceneObjectCD_RO_ComponentLookup = state.GetComponentLookup<CustomSceneObjectCD>(isReadOnly: true);
			__DestroyEntityIfNotOnTileSystem_DestroyEntityIfNotOnTileJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000016FB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000016FB_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000016FB_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TileAccessor _tileAccessor;

	private static readonly ProfilerMarker Marker = new ProfilerMarker("DestroyUpdate");

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1872979273_0;

	private EntityQuery __query_1872979273_1;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
	}

	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		_tileAccessor.Update(ref state);
		DestroyEntityIfNotOnTileJob job = new DestroyEntityIfNotOnTileJob
		{
			Database = __query_1872979273_0.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob,
			Ecb = __query_1872979273_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged),
			DeltaTime = state.WorldUnmanaged.Time.DeltaTime,
			Seed = PugRandom.GetSeed(),
			TileAccessor = _tileAccessor,
			EnemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
			DirectionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			SurfacePriorityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SurfacePriorityCD_RO_ComponentLookup, ref state),
			HealthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref state),
			DontDropLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RO_ComponentLookup, ref state),
			CustomSceneLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CustomSceneObjectCD_RO_ComponentLookup, ref state)
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__DestroyEntityIfNotOnTileSystem_DestroyEntityIfNotOnTileJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(DestroyEntityIfNotOnTileJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DestroyEntityIfNotOnTileSystem_DestroyEntityIfNotOnTileJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DestroyEntityIfNotOnTileSystem_DestroyEntityIfNotOnTileJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DestroyEntityIfNotOnTileSystem_DestroyEntityIfNotOnTileJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DestroyEntityIfNotOnTileSystem_DestroyEntityIfNotOnTileJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1872979273_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1872979273_1 = entityQueryBuilder2.Build(ref state);
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
		((DestroyEntityIfNotOnTileSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000016FB_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((DestroyEntityIfNotOnTileSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((DestroyEntityIfNotOnTileSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((DestroyEntityIfNotOnTileSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DestroyEntityIfNotOnTileSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
