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
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class DestroyEntityIfPlacementNotValidSystem : PugSimulationSystemBase
{
	[BurstCompile]
	private struct DestroyEntityIfPlacementNotValidJob : IJobEntity, IJobChunk
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
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
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
			public void Run(ref DestroyEntityIfPlacementNotValidJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DestroyEntityIfPlacementNotValidJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DestroyEntityIfPlacementNotValidJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DestroyEntityIfPlacementNotValidJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DestroyEntityIfPlacementNotValidJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DestroyEntityIfPlacementNotValidJob job, EntityManager entityManager)
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

		public EntityCommandBuffer Ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;

		[ReadOnly]
		public TileAccessor TileLookup;

		[ReadOnly]
		public CollisionWorld CollisionWorld;

		[ReadOnly]
		public ComponentLookup<DirectionCD> DirectionLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsVelocity> PhysicsVelocityLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> ObjectDataLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> ObjectPropertiesLookup;

		[ReadOnly]
		public ComponentLookup<SurfacePriorityCD> SurfacePriorityLookup;

		public ComponentLookup<HealthCD> HealthLookup;

		public CollisionFilter CollisionFilter;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, ref DestroyEntityIfNotOnTileCD destroyCD, in LocalTransform transform, in ObjectDataCD objectData, in ObjectPropertiesCD properties)
		{
			bool flag = true;
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectData.objectID, Database);
			int2 size = entityObjectInfo.prefabTileSize;
			int2 offset = entityObjectInfo.prefabCornerOffset;
			bool flag2 = properties.Has(-1544243617);
			if (DirectionLookup.TryGetComponent(entity, out var componentData))
			{
				componentData.GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
			}
			bool flag3 = properties.Has(119039444);
			bool flag4 = properties.Has(-1832234709);
			TileCD tileCD = default(TileCD);
			for (int i = offset.x; i < size.x + offset.x; i++)
			{
				for (int j = offset.y; j < size.y + offset.y; j++)
				{
					float3 float5 = transform.Position + new float3(i, 0f, j);
					bool flag5 = false;
					ObjectID id = ObjectID.None;
					if (!flag3)
					{
						NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
						if (CollisionWorld.OverlapSphere(float5 + new float3(0f, 0.25f, 0f), 0f, ref outHits, CollisionFilter))
						{
							for (int k = 0; k < outHits.Length; k++)
							{
								Entity entity2 = outHits[k].Entity;
								if (entity2 == entity || PhysicsVelocityLookup.HasComponent(entity2) || !ObjectDataLookup.HasComponent(entity2))
								{
									continue;
								}
								bool flag6 = false;
								ObjectID objectID = ObjectDataLookup[entity2].objectID;
								if (objectID == objectData.objectID)
								{
									flag6 = true;
								}
								else if (!ObjectPropertiesLookup.HasComponent(entity2) || !ObjectPropertiesLookup[entity2].Has(-975748197))
								{
									flag6 = true;
								}
								else
								{
									ObjectPropertiesCD objectPropertiesCD = ObjectPropertiesLookup[entity2];
									flag6 = !objectPropertiesCD.Has(119039444) || (objectPropertiesCD.Has(-1832234709) && flag2) || (flag4 && objectPropertiesCD.Has(-1171081164));
								}
								if (!flag6)
								{
									continue;
								}
								bool flag7 = false;
								if (properties.TryGetList(-179233515, out NativeArray<ObjectID> value, (AllocatorManager.AllocatorHandle)Allocator.Temp))
								{
									foreach (ObjectID item in value)
									{
										if (objectID == item)
										{
											flag7 = true;
											break;
										}
									}
								}
								if (!flag7 && ObjectPropertiesLookup.HasComponent(entity2) && ObjectPropertiesLookup[entity2].TryGetList(-789473209, out NativeArray<ObjectID> value2, (AllocatorManager.AllocatorHandle)Allocator.Temp))
								{
									foreach (ObjectID item2 in value2)
									{
										if (item2 == objectData.objectID)
										{
											flag7 = true;
											break;
										}
									}
								}
								if (!flag7)
								{
									flag5 = true;
									id = objectID;
									break;
								}
							}
						}
						outHits.Dispose();
					}
					bool num = properties.Has(-387040359);
					bool flag8 = properties.Has(-1171401773);
					bool flag9 = properties.Has(1087164581);
					bool flag10 = properties.Has(794428061);
					bool flag11 = properties.Has(-1229871138);
					bool flag12 = properties.Has(-2085468759);
					bool flag13 = true;
					int2 int5 = float5.RoundToInt2();
					TileCD top = TileLookup.GetTop(int5);
					ObjectID objectID2 = PugDatabase.GetObjectID(top.tileset, top.tileType, Database);
					bool flag14 = num || flag8 || flag9 || flag10 || flag2;
					bool flag15 = top.tileType == TileType.water && top.tileset != 3;
					SurfacePriorityCD componentData2;
					bool flag16 = flag8 && (flag15 || (SurfacePriorityLookup.TryGetComponent(entity, out componentData2) && componentData2.Value < TileType.water.GetSurfacePriorityFromJob() && TileLookup.HasType(int5, TileType.water)));
					bool flag17 = top.tileType == TileType.water && top.tileset == 3;
					bool flag18 = flag9 && flag17;
					bool flag19 = top.tileType == TileType.pit;
					bool flag20 = flag10 && flag19;
					bool flag21 = top.tileType == TileType.wall;
					bool flag22 = flag2 && top.tileType != TileType.wall && TileLookup.HasType(int5 - DirectionBasedOnVariationCD.GetDirectionFromVariation(objectData.variation, properties.Has(-377237680)), TileType.wall);
					bool flag23 = (num && (top.tileType.IsWalkableTile() || (flag11 && top.tileType.IsBlockingOnWalkableTile()))) || flag16 || flag18 || flag20 || flag22;
					bool flag24 = !flag11 && top.tileType.IsBlockingOnWalkableTile();
					if (flag12 && top.tileType.IsLowCollider())
					{
						flag23 = true;
						flag24 = false;
					}
					bool flag25 = tileCD.tileType == TileType.water && tileCD.tileset != 3;
					bool num2 = tileCD.tileType != TileType.none && flag25 != flag15;
					bool flag26 = tileCD.tileType == TileType.water && tileCD.tileset == 3;
					bool flag27 = tileCD.tileType != TileType.none && flag26 != flag17;
					bool flag28 = tileCD.tileType == TileType.pit;
					bool flag29 = tileCD.tileType != TileType.none && flag28 != flag19;
					bool flag30 = tileCD.tileType == TileType.wall;
					bool flag31 = tileCD.tileType != TileType.none && flag30 != flag21;
					tileCD = top;
					if (num2 || flag27 || flag29 || flag31)
					{
						flag13 = false;
					}
					else if ((flag14 && !flag23) || flag24)
					{
						flag13 = false;
					}
					else if (flag14)
					{
						if (properties.TryGetList(1985931659, out NativeArray<ObjectID> value3, (AllocatorManager.AllocatorHandle)Allocator.Temp))
						{
							foreach (ObjectID item3 in value3)
							{
								if (objectID2 == item3)
								{
									flag13 = false;
									break;
								}
							}
						}
					}
					else
					{
						flag13 = false;
						if (properties.TryGetList(-179233515, out NativeArray<ObjectID> value4, (AllocatorManager.AllocatorHandle)Allocator.Temp))
						{
							foreach (ObjectID item4 in value4)
							{
								if (objectID2 == item4)
								{
									flag13 = true;
									Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(id, Database);
									SurfacePriorityCD componentData3;
									int num3 = (SurfacePriorityLookup.TryGetComponent(primaryPrefabEntity, out componentData3) ? componentData3.Value : int.MaxValue);
									Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(objectID2, Database);
									SurfacePriorityCD componentData4;
									int num4 = (SurfacePriorityLookup.TryGetComponent(primaryPrefabEntity2, out componentData4) ? componentData4.Value : int.MaxValue);
									if (num3 < num4)
									{
										flag5 = false;
									}
									break;
								}
							}
						}
					}
					if (!flag13 || flag5)
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
			}
			Ecb.RemoveComponent<DestroyEntityIfPlacementNotValidCD>(entity);
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
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SurfacePriorityCD> __SurfacePriorityCD_RO_ComponentLookup;

		public ComponentLookup<HealthCD> __HealthCD_RW_ComponentLookup;

		public DestroyEntityIfPlacementNotValidJob.InternalCompilerQueryAndHandleData __DestroyEntityIfPlacementNotValidSystem_DestroyEntityIfPlacementNotValidJob_WithoutDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__Unity_Physics_PhysicsVelocity_RO_ComponentLookup = state.GetComponentLookup<PhysicsVelocity>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
			__SurfacePriorityCD_RO_ComponentLookup = state.GetComponentLookup<SurfacePriorityCD>(isReadOnly: true);
			__HealthCD_RW_ComponentLookup = state.GetComponentLookup<HealthCD>();
			__DestroyEntityIfPlacementNotValidSystem_DestroyEntityIfPlacementNotValidJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
		}
	}

	private CollisionFilter _collisionFilter = new CollisionFilter
	{
		BelongsTo = uint.MaxValue,
		CollidesWith = 131905u
	};

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1451301169_0;

	[Preserve]
	protected override void OnCreate()
	{
		_queryRequiredForUpdate = __query_1451301169_0;
		NeedDatabase();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		TileAccessor tileLookup = CreateTileAccessor();
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		CollisionFilter collisionFilter = _collisionFilter;
		BlobAssetReference<PugDatabase.PugDatabaseBank> blobAssetReference = database;
		ComponentLookup<DirectionCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<PhysicsVelocity> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsVelocity_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<ObjectDataCD> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<ObjectPropertiesCD> componentLookup4 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<SurfacePriorityCD> componentLookup5 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SurfacePriorityCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<HealthCD> componentLookup6 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref base.CheckedStateRef);
		DestroyEntityIfPlacementNotValidJob job = new DestroyEntityIfPlacementNotValidJob
		{
			Ecb = ecb,
			TileLookup = tileLookup,
			CollisionWorld = collisionWorld,
			CollisionFilter = collisionFilter,
			Database = blobAssetReference,
			DirectionLookup = componentLookup,
			PhysicsVelocityLookup = componentLookup2,
			ObjectDataLookup = componentLookup3,
			ObjectPropertiesLookup = componentLookup4,
			SurfacePriorityLookup = componentLookup5,
			HealthLookup = componentLookup6
		};
		base.Dependency = __ScheduleViaJobChunkExtension_0(job, _queryRequiredForUpdate, base.Dependency, ref base.CheckedStateRef, hasUserDefinedQuery: true);
		base.OnUpdate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(DestroyEntityIfPlacementNotValidJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DestroyEntityIfPlacementNotValidSystem_DestroyEntityIfPlacementNotValidJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DestroyEntityIfPlacementNotValidSystem_DestroyEntityIfPlacementNotValidJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DestroyEntityIfPlacementNotValidSystem_DestroyEntityIfPlacementNotValidJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DestroyEntityIfPlacementNotValidSystem_DestroyEntityIfPlacementNotValidJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<DestroyEntityIfNotOnTileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DestroyEntityIfPlacementNotValidCD, LocalTransform, ObjectDataCD, ObjectPropertiesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD, EnemyCD>();
		__query_1451301169_0 = entityQueryBuilder2.Build(ref state);
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
	public DestroyEntityIfPlacementNotValidSystem()
	{
	}
}
