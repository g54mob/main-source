using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;

[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup), OrderFirst = true)]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[BurstCompile]
public struct PetHandlerSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(PetCD),
		typeof(ObjectDataCD)
	})]
	[WithPresent(new Type[] { typeof(EntityDestroyedCD) })]
	private struct RecordActivePetsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__OwnerReferenceCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<OwnerReferenceCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__OwnerReferenceCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithPresent<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<OwnerReferenceCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PetCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
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
			public void Run(ref RecordActivePetsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RecordActivePetsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RecordActivePetsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RecordActivePetsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RecordActivePetsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RecordActivePetsJob job, EntityManager entityManager)
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

		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<Disabled> disabledLookup;

		public NativeParallelHashMap<Entity, Entity> ownerToPetMap;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in OwnerReferenceCD ownerReference)
		{
			if (!entityDestroyedLookup.IsComponentEnabled(entity))
			{
				if (ownerReference.owner != Entity.Null && entityDestroyedLookup.HasComponent(ownerReference.owner) && !disabledLookup.HasComponent(ownerReference.owner) && !ownerToPetMap.ContainsKey(ownerReference.owner))
				{
					ownerToPetMap.Add(ownerReference.owner, entity);
				}
				else
				{
					entityDestroyedLookup.SetComponentEnabled(entity, value: true);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__OwnerReferenceCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<OwnerReferenceCD>(nativeArrayPtr2, k));
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
	[WithAll(new Type[] { typeof(PetOwnerCD) })]
	private struct CheckPetAllowedToSpawnJob : IJobChunk
	{
		public ComponentTypeHandle<PetOwnerCD> PetOwnerTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PlayerStateCD> PlayerStateTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EntityDestroyedCD> EntityDestroyedTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> HealthTypeHandle;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			NativeArray<PetOwnerCD> nativeArray = chunk.GetNativeArray(ref PetOwnerTypeHandle);
			for (int i = 0; i < chunk.Count; i++)
			{
				PetOwnerCD value = nativeArray[i];
				value.AllowPetToSpawn = true;
				nativeArray[i] = value;
			}
			if (chunk.Has(ref PlayerStateTypeHandle))
			{
				PlayerStateEnum state = PlayerStateEnum.NoClip | PlayerStateEnum.MinecartRiding | PlayerStateEnum.BoatRiding | PlayerStateEnum.VehicleRiding;
				NativeArray<PlayerStateCD> nativeArray2 = chunk.GetNativeArray(ref PlayerStateTypeHandle);
				for (int j = 0; j < chunk.Count; j++)
				{
					if (nativeArray2[j].HasAnyState(state))
					{
						PetOwnerCD value2 = nativeArray[j];
						value2.AllowPetToSpawn = false;
						nativeArray[j] = value2;
					}
				}
			}
			if (chunk.Has(ref EntityDestroyedTypeHandle))
			{
				for (int k = 0; k < chunk.Count; k++)
				{
					if (chunk.IsComponentEnabled(ref EntityDestroyedTypeHandle, k))
					{
						PetOwnerCD value3 = nativeArray[k];
						value3.AllowPetToSpawn = false;
						nativeArray[k] = value3;
					}
				}
			}
			if (!chunk.Has(ref HealthTypeHandle))
			{
				return;
			}
			NativeArray<HealthCD> nativeArray3 = chunk.GetNativeArray(ref HealthTypeHandle);
			for (int l = 0; l < chunk.Count; l++)
			{
				if (nativeArray3[l].health <= 0)
				{
					PetOwnerCD value4 = nativeArray[l];
					value4.AllowPetToSpawn = false;
					nativeArray[l] = value4;
				}
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct HandlePetSpawnAndDespawnJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<PetOwnerCD> __PetOwnerCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PetOwnerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PetOwnerCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PetOwnerCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PetOwnerCD>();
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
			public void Run(ref HandlePetSpawnAndDespawnJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HandlePetSpawnAndDespawnJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HandlePetSpawnAndDespawnJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HandlePetSpawnAndDespawnJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HandlePetSpawnAndDespawnJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HandlePetSpawnAndDespawnJob job, EntityManager entityManager)
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

		[ReadOnly]
		public TileAccessor TileAccessor;

		[ReadOnly]
		public CollisionWorld CollisionWorld;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;

		[ReadOnly]
		public NativeParallelHashMap<Entity, Entity>.ReadOnly OwnerToPetMap;

		public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<PetCD> PetLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> ObjectDataLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> SimulateLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> LocalTransformLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref PetOwnerCD petOwnerCD, in LocalTransform transform, in DynamicBuffer<ContainedObjectsBuffer> inventory)
		{
			ContainedObjectsBuffer containedObjectsBuffer = ((inventory.Length > petOwnerCD.SlotIndex) ? inventory[petOwnerCD.SlotIndex] : default(ContainedObjectsBuffer));
			Entity item;
			bool flag = OwnerToPetMap.TryGetValue(entity, out item);
			petOwnerCD.PetEntity = Entity.Null;
			int2 result;
			if (!petOwnerCD.AllowPetToSpawn)
			{
				if (flag && SimulateLookup.HasAndIsComponentEnabled(item))
				{
					EntityDestroyedLookup.SetComponentEnabled(item, value: true);
				}
			}
			else if (flag)
			{
				PetCD petCD = PetLookup[item];
				ObjectDataCD objectDataCD = ObjectDataLookup[item];
				int inventoryAuxDataIndex = petCD.inventoryAuxDataIndex;
				if ((inventoryAuxDataIndex != 0 && inventoryAuxDataIndex != containedObjectsBuffer.auxDataIndex) || objectDataCD.objectID != containedObjectsBuffer.objectData.objectID)
				{
					if (SimulateLookup.HasAndIsComponentEnabled(item))
					{
						EntityDestroyedLookup.SetComponentEnabled(item, value: true);
					}
				}
				else
				{
					petOwnerCD.PetEntity = item;
				}
			}
			else if (containedObjectsBuffer.objectID != ObjectID.None && PugDatabase.GetEntityObjectInfo(containedObjectsBuffer.objectID, Database).objectType == ObjectType.Pet && TryGetAvailableTile(transform.Position.RoundToInt2(), out result))
			{
				Entity e = EntityUtility.CreateEntity(Ecb, containedObjectsBuffer.objectID, containedObjectsBuffer.amount, Database);
				Ecb.SetComponent(e, new ObjectDataCD
				{
					objectID = containedObjectsBuffer.objectID,
					amount = containedObjectsBuffer.amount,
					variation = containedObjectsBuffer.variation
				});
				Ecb.SetComponent(e, new OwnerReferenceCD
				{
					owner = entity
				});
				Ecb.SetComponent(e, LocalTransform.FromPosition(result.ToFloat3()));
			}
		}

		private bool TryGetAvailableTile(int2 origin, out int2 result, int maxRange = 2)
		{
			NativeHashSet<int2> occupiedTiles = new NativeHashSet<int2>(maxRange * maxRange, Allocator.Temp);
			MarkNearbyBlockingTiles(origin, maxRange, occupiedTiles);
			MarkNearbyColliders(origin, maxRange, occupiedTiles);
			result = default(int2);
			float num = float.PositiveInfinity;
			for (int i = -maxRange; i <= maxRange; i++)
			{
				for (int j = -maxRange; j <= maxRange; j++)
				{
					int2 int5 = origin + new int2(i, j);
					float num2 = math.lengthsq(origin - int5);
					if (!(num2 > num) && !occupiedTiles.Contains(int5))
					{
						num = num2;
						result = int5;
					}
				}
			}
			occupiedTiles.Dispose();
			return float.IsFinite(num);
		}

		private void MarkNearbyBlockingTiles(int2 origin, int maxRange, NativeHashSet<int2> occupiedTiles)
		{
			for (int i = -maxRange; i <= maxRange; i++)
			{
				for (int j = -maxRange; j <= maxRange; j++)
				{
					int2 int5 = origin + new int2(i, j);
					if (TileAccessor.TryGetBlockingTile(int5, out var _))
					{
						occupiedTiles.Add(int5);
					}
				}
			}
		}

		private void MarkNearbyColliders(int2 origin, int maxRange, NativeHashSet<int2> occupiedTiles)
		{
			NativeList<int> allHits = new NativeList<int>(maxRange * maxRange, Allocator.Temp);
			OverlapAabbInput input = new OverlapAabbInput
			{
				Aabb = new Aabb
				{
					Min = origin.ToFloat3() - maxRange,
					Max = origin.ToFloat3() + maxRange
				},
				Filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 131349u
				}
			};
			if (!CollisionWorld.OverlapAabb(input, ref allHits))
			{
				allHits.Dispose();
				return;
			}
			foreach (int item in allHits)
			{
				Entity entity = CollisionWorld.Bodies[item].Entity;
				if (!LocalTransformLookup.TryGetComponent(entity, out var componentData) || !ObjectDataLookup.TryGetComponent(entity, out var componentData2))
				{
					continue;
				}
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(componentData2.objectID, Database, componentData2.variation);
				int2 int5 = componentData.Position.RoundToInt2() + entityObjectInfo.prefabCornerOffset;
				int2 int6 = int5 + entityObjectInfo.prefabTileSize;
				for (int i = int5.x; i < int6.x; i++)
				{
					for (int j = int5.y; j < int6.y; j++)
					{
						occupiedTiles.Add(new int2(i, j));
					}
				}
			}
			allHits.Dispose();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PetOwnerCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), bufferAccessor[i]);
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), bufferAccessor[j]);
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), bufferAccessor[k]);
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
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct UpdatePetToInventoryJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PetOwnerCD> __PetOwnerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ContainedObjectsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>();
					__PetOwnerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PetOwnerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ContainedObjectsBuffer_RW_BufferTypeHandle.Update(ref state);
					__PetOwnerCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PetOwnerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedObjectsBuffer>();
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
			public void Run(ref UpdatePetToInventoryJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdatePetToInventoryJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdatePetToInventoryJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdatePetToInventoryJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdatePetToInventoryJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdatePetToInventoryJob job, EntityManager entityManager)
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

		public ComponentLookup<PetCD> petLookup;

		public BufferLookup<AddPetExperienceBuffer> addPetExperienceBufferLookup;

		public NativeParallelHashMap<Entity, Entity>.ReadOnly ownerToPetMap;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref DynamicBuffer<ContainedObjectsBuffer> inventory, in PetOwnerCD petOwner)
		{
			if (!ownerToPetMap.TryGetValue(entity, out var item))
			{
				return;
			}
			bool flag = inventory.Length > petOwner.SlotIndex;
			ContainedObjectsBuffer value = (flag ? inventory[petOwner.SlotIndex] : default(ContainedObjectsBuffer));
			if (!petLookup.TryGetComponent(item, out var componentData))
			{
				return;
			}
			if (componentData.inventoryAuxDataIndex != value.auxDataIndex)
			{
				componentData.inventoryAuxDataIndex = value.auxDataIndex;
				petLookup.GetRefRW(item).ValueRW.inventoryAuxDataIndex = value.auxDataIndex;
			}
			if (!flag || !addPetExperienceBufferLookup.TryGetBuffer(item, out var bufferData) || bufferData.Length <= 0)
			{
				return;
			}
			if (!PetExtensions.IsAtMaxLevel(value.objectData.amount))
			{
				for (int i = 0; i < bufferData.Length; i++)
				{
					AddPetExperienceBuffer addPetExperienceBuffer = bufferData[i];
					value.objectData.amount += addPetExperienceBuffer.amount;
				}
				inventory[petOwner.SlotIndex] = value;
			}
			bufferData.Clear();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PetOwnerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<ContainedObjectsBuffer> inventory = bufferAccessor[i];
					Execute(entity, ref inventory, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr2, i));
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
						DynamicBuffer<ContainedObjectsBuffer> inventory2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref inventory2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr2, nextRangeBegin));
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
					DynamicBuffer<ContainedObjectsBuffer> inventory3 = bufferAccessor[j];
					Execute(entity3, ref inventory3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr2, j));
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
					DynamicBuffer<ContainedObjectsBuffer> inventory4 = bufferAccessor[k];
					Execute(entity4, ref inventory4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr2, k));
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
	private struct UpdatePetByXPJob : IJobChunk
	{
		public ComponentTypeHandle<MeleeAttackStateCD> meleeAttackStateCDTypeHandle;

		public ComponentTypeHandle<RangeAttackStateCD> rangeAttackStateCDTypeHandle;

		public ComponentTypeHandle<JumpAttackStateCD> jumpAttackStateCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PetCD> petCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<OwnerReferenceCD> ownerCDTypeHandle;

		[ReadOnly]
		public EntityTypeHandle entityTypeHandle;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedObjectsBufferLookup;

		[ReadOnly]
		public BufferLookup<InventoryBuffer> inventoryLookup;

		[ReadOnly]
		public ComponentLookup<PetOwnerCD> petOwnerLookup;

		public ComponentLookup<FactionCD> factionLookup;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			NativeArray<MeleeAttackStateCD> nativeArray = chunk.GetNativeArray(meleeAttackStateCDTypeHandle);
			NativeArray<RangeAttackStateCD> nativeArray2 = chunk.GetNativeArray(rangeAttackStateCDTypeHandle);
			NativeArray<JumpAttackStateCD> nativeArray3 = chunk.GetNativeArray(jumpAttackStateCDTypeHandle);
			NativeArray<PetCD> nativeArray4 = chunk.GetNativeArray(petCDTypeHandle);
			NativeArray<OwnerReferenceCD> nativeArray5 = chunk.GetNativeArray(ownerCDTypeHandle);
			NativeArray<Entity> nativeArray6 = chunk.GetNativeArray(entityTypeHandle);
			bool isCreated = nativeArray.IsCreated;
			bool isCreated2 = nativeArray2.IsCreated;
			bool isCreated3 = nativeArray3.IsCreated;
			for (int i = 0; i < chunk.Count; i++)
			{
				OwnerReferenceCD ownerReferenceCD = nativeArray5[i];
				if (!(ownerReferenceCD.owner == Entity.Null) && containedObjectsBufferLookup.TryGetBuffer(ownerReferenceCD.owner, out var bufferData) && inventoryLookup.TryGetBuffer(ownerReferenceCD.owner, out var _) && petOwnerLookup.TryGetComponent(ownerReferenceCD.owner, out var componentData) && bufferData.Length > componentData.SlotIndex)
				{
					ContainedObjectsBuffer containedObjectsBuffer = bufferData[componentData.SlotIndex];
					PetCD petCD = nativeArray4[i];
					int damage = PetExtensions.GetDamage(containedObjectsBuffer.amount, petCD.petType);
					if (isCreated)
					{
						MeleeAttackStateCD value = nativeArray[i];
						value.meleeDamage = damage;
						nativeArray[i] = value;
					}
					if (isCreated2)
					{
						RangeAttackStateCD value2 = nativeArray2[i];
						value2.rangeDamage = damage;
						nativeArray2[i] = value2;
					}
					if (isCreated3)
					{
						JumpAttackStateCD value3 = nativeArray3[i];
						value3.jumpDamage = damage;
						nativeArray3[i] = value3;
					}
					if (factionLookup.HasComponent(nativeArray6[i]) && factionLookup.TryGetComponent(ownerReferenceCD.owner, out var componentData2))
					{
						factionLookup.GetRefRW(nativeArray6[i]).ValueRW.pvpTeam = componentData2.pvpTeam;
					}
				}
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Disabled> __Unity_Entities_Disabled_RO_ComponentLookup;

		public RecordActivePetsJob.InternalCompilerQueryAndHandleData __PetHandlerSystem_RecordActivePetsJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentTypeHandle<PetOwnerCD> __PetOwnerCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<PetCD> __PetCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		public HandlePetSpawnAndDespawnJob.InternalCompilerQueryAndHandleData __PetHandlerSystem_HandlePetSpawnAndDespawnJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<PetCD> __PetCD_RW_ComponentLookup;

		public BufferLookup<AddPetExperienceBuffer> __AddPetExperienceBuffer_RW_BufferLookup;

		public UpdatePetToInventoryJob.InternalCompilerQueryAndHandleData __PetHandlerSystem_UpdatePetToInventoryJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentTypeHandle<MeleeAttackStateCD> __MeleeAttackStateCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<RangeAttackStateCD> __RangeAttackStateCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<JumpAttackStateCD> __JumpAttackStateCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PetCD> __PetCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<InventoryBuffer> __InventoryBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<PetOwnerCD> __PetOwnerCD_RO_ComponentLookup;

		public ComponentLookup<FactionCD> __FactionCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__EntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>();
			__Unity_Entities_Disabled_RO_ComponentLookup = state.GetComponentLookup<Disabled>(isReadOnly: true);
			__PetHandlerSystem_RecordActivePetsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__PetOwnerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PetOwnerCD>();
			__PlayerState_PlayerStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EntityDestroyedCD>(isReadOnly: true);
			__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
			__PetCD_RO_ComponentLookup = state.GetComponentLookup<PetCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__PetHandlerSystem_HandlePetSpawnAndDespawnJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__PetCD_RW_ComponentLookup = state.GetComponentLookup<PetCD>();
			__AddPetExperienceBuffer_RW_BufferLookup = state.GetBufferLookup<AddPetExperienceBuffer>();
			__PetHandlerSystem_UpdatePetToInventoryJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__MeleeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MeleeAttackStateCD>();
			__RangeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RangeAttackStateCD>();
			__JumpAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<JumpAttackStateCD>();
			__PetCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PetCD>(isReadOnly: true);
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__OwnerReferenceCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<OwnerReferenceCD>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			__InventoryBuffer_RO_BufferLookup = state.GetBufferLookup<InventoryBuffer>(isReadOnly: true);
			__PetOwnerCD_RO_ComponentLookup = state.GetComponentLookup<PetOwnerCD>(isReadOnly: true);
			__FactionCD_RW_ComponentLookup = state.GetComponentLookup<FactionCD>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000297F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000297F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000297F_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00002980_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00002980_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00002980_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00002981_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00002981_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00002981_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_00002982_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00002982_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00002982_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_666335372_0;

	private EntityQuery __query_666335372_1;

	private EntityQuery __query_666335372_2;

	private EntityQuery __query_666335372_3;

	private EntityQuery __query_666335372_4;

	private EntityQuery __query_666335372_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<SubMapRegistry>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		_tileAccessor.Update(ref state);
		NetworkTime singleton = __query_666335372_2.GetSingleton<NetworkTime>();
		NativeParallelHashMap<Entity, Entity> ownerToPetMap = new NativeParallelHashMap<Entity, Entity>(32, state.WorldUpdateAllocator);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new RecordActivePetsJob
		{
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentLookup, ref state),
			disabledLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Disabled_RO_ComponentLookup, ref state),
			ownerToPetMap = ownerToPetMap
		}, __TypeHandle.__PetHandlerSystem_RecordActivePetsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = JobChunkExtensions.Schedule(new CheckPetAllowedToSpawnJob
		{
			PetOwnerTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PetOwnerCD_RW_ComponentTypeHandle, ref state),
			PlayerStateTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentTypeHandle, ref state),
			EntityDestroyedTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentTypeHandle, ref state),
			HealthTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle, ref state)
		}, __query_666335372_0, state.Dependency);
		EntityCommandBuffer ecb = __query_666335372_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new HandlePetSpawnAndDespawnJob
		{
			Ecb = ecb,
			TileAccessor = _tileAccessor,
			CollisionWorld = __query_666335372_4.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
			Database = __query_666335372_5.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob,
			OwnerToPetMap = ownerToPetMap.AsReadOnly(),
			EntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentLookup, ref state),
			PetLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RO_ComponentLookup, ref state),
			ObjectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			SimulateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state),
			LocalTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state)
		}, __TypeHandle.__PetHandlerSystem_HandlePetSpawnAndDespawnJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new UpdatePetToInventoryJob
		{
			petLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCD_RW_ComponentLookup, ref state),
			addPetExperienceBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__AddPetExperienceBuffer_RW_BufferLookup, ref state),
			ownerToPetMap = ownerToPetMap.AsReadOnly()
		}, __TypeHandle.__PetHandlerSystem_UpdatePetToInventoryJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		if (VariableSystemUpdate.ShouldUpdate(ref state, singleton, 8, 2f))
		{
			EntityQuery _query_666335372_ = __query_666335372_1;
			state.Dependency = JobChunkExtensions.Schedule(new UpdatePetByXPJob
			{
				meleeAttackStateCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__MeleeAttackStateCD_RW_ComponentTypeHandle, ref state),
				rangeAttackStateCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__RangeAttackStateCD_RW_ComponentTypeHandle, ref state),
				jumpAttackStateCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__JumpAttackStateCD_RW_ComponentTypeHandle, ref state),
				petCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PetCD_RO_ComponentTypeHandle, ref state),
				entityTypeHandle = InternalCompilerInterface.GetEntityTypeHandle(ref __TypeHandle.__Unity_Entities_Entity_TypeHandle, ref state),
				ownerCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentTypeHandle, ref state),
				containedObjectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
				inventoryLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventoryBuffer_RO_BufferLookup, ref state),
				petOwnerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetOwnerCD_RO_ComponentLookup, ref state),
				factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RW_ComponentLookup, ref state)
			}, _query_666335372_, state.Dependency);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(RecordActivePetsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PetHandlerSystem_RecordActivePetsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PetHandlerSystem_RecordActivePetsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PetHandlerSystem_RecordActivePetsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PetHandlerSystem_RecordActivePetsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(HandlePetSpawnAndDespawnJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PetHandlerSystem_HandlePetSpawnAndDespawnJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PetHandlerSystem_HandlePetSpawnAndDespawnJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PetHandlerSystem_HandlePetSpawnAndDespawnJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PetHandlerSystem_HandlePetSpawnAndDespawnJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(UpdatePetToInventoryJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PetHandlerSystem_UpdatePetToInventoryJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PetHandlerSystem_UpdatePetToInventoryJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PetHandlerSystem_UpdatePetToInventoryJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PetHandlerSystem_UpdatePetToInventoryJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PetOwnerCD>();
		__query_666335372_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PetCD, OwnerReferenceCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<MeleeAttackStateCD, RangeAttackStateCD, JumpAttackStateCD, FactionCD>();
		__query_666335372_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_666335372_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_666335372_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_666335372_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_666335372_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000297F_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00002980_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00002981_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00002982_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((PetHandlerSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PetHandlerSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PetHandlerSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PetHandlerSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PetHandlerSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
