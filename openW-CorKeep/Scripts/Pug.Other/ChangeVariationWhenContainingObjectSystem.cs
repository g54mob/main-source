using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct ChangeVariationWhenContainingObjectSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct ChangeVariationWhenContainingObjectJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ChangeVariationWhenContainingObjectCD> __ChangeVariationWhenContainingObjectCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ChangeVariationWhenContainingObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ChangeVariationWhenContainingObjectCD>(isReadOnly: true);
					__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ChangeVariationWhenContainingObjectCD_RO_ComponentTypeHandle.Update(ref state);
					__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ChangeVariationWhenContainingObjectCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
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
			public void Run(ref ChangeVariationWhenContainingObjectJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ChangeVariationWhenContainingObjectJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ChangeVariationWhenContainingObjectJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ChangeVariationWhenContainingObjectJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ChangeVariationWhenContainingObjectJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ChangeVariationWhenContainingObjectJob job, EntityManager entityManager)
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

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		[ReadOnly]
		public BufferLookup<ItemsToAddToNewObjectBuffer> addItemsBufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedItemsBufferLooup;

		[ReadOnly]
		public BlobAssetReference<PugDatabase.PugDatabaseBank> database;

		public ComponentLookup<ObjectDataCD> objectDataLookup;

		public BufferLookup<EffectEventBuffer> effectEventBufferLookup;

		public Entity effectEventBufferEntity;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in ChangeVariationWhenContainingObjectCD triggerObject, in DynamicBuffer<ContainedObjectsBuffer> containedObjects, in LocalTransform translation, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer)
		{
			if (triggerObject.objectID == ObjectID.None)
			{
				return;
			}
			for (int i = 0; i < containedObjects.Length; i++)
			{
				if (containedObjects[i].objectData.objectID != triggerObject.objectID)
				{
					continue;
				}
				if (triggerObject.reinstantiateToNewObjectId != ObjectID.None)
				{
					ecb.DestroyEntity(entity);
					Entity e;
					if (addItemsBufferLookup.TryGetBuffer(entity, out var bufferData))
					{
						NativeList<ObjectDataCD> items = new NativeList<ObjectDataCD>(bufferData.Length, Allocator.Temp);
						foreach (ItemsToAddToNewObjectBuffer item in bufferData)
						{
							ItemsToAddToNewObjectBuffer current = item;
							items.Add(in current.objectData);
						}
						e = EntityUtility.CreateEntityWithItems(ecb, translation.Position, triggerObject.reinstantiateToNewObjectId, 1, items, database, containedItemsBufferLooup, triggerObject.variationToChangeTo);
						items.Dispose();
					}
					else
					{
						e = EntityUtility.CreateEntity(ecb, translation.Position, triggerObject.reinstantiateToNewObjectId, 1, database, triggerObject.variationToChangeTo);
					}
					if (triggerObject.addLootFromTableToNewObject != LootTableID.Empty)
					{
						ecb.AddComponent(e, new AddRandomLootCD
						{
							lootTableID = triggerObject.addLootFromTableToNewObject
						});
					}
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(triggerObject.reinstantiateToNewObjectId, database, triggerObject.variationToChangeTo);
					if (directionLookup.HasComponent(primaryPrefabEntity) && directionLookup.TryGetComponent(entity, out var componentData))
					{
						ecb.SetComponent(e, componentData);
					}
				}
				else
				{
					objectDataLookup.GetRefRW(entity).ValueRW.variation = triggerObject.variationToChangeTo;
					AnimationUtilities.TriggerAnimation(238408899, currentTick, animationBuffer, ref animationBufferPointer);
					ecb.RemoveComponent<ChangeVariationWhenContainingObjectCD>(entity);
				}
				if (triggerObject.playEffectOnReinstantiate != EffectID.None)
				{
					effectEventBufferLookup[effectEventBufferEntity].Add(new EffectEventBuffer
					{
						Value = new EffectEventCD
						{
							effectID = triggerObject.playEffectOnReinstantiate,
							position1 = translation.Position
						}
					});
				}
				break;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ChangeVariationWhenContainingObjectCD_RO_ComponentTypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref ChangeVariationWhenContainingObjectCD triggerObject = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChangeVariationWhenContainingObjectCD>(nativeArrayPtr2, i);
					DynamicBuffer<ContainedObjectsBuffer> containedObjects = bufferAccessor[i];
					ref LocalTransform translation = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor2[i];
					Execute(entity, in triggerObject, in containedObjects, in translation, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i));
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
						ref ChangeVariationWhenContainingObjectCD triggerObject2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChangeVariationWhenContainingObjectCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<ContainedObjectsBuffer> containedObjects2 = bufferAccessor[nextRangeBegin];
						ref LocalTransform translation2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, in triggerObject2, in containedObjects2, in translation2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, nextRangeBegin));
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
					ref ChangeVariationWhenContainingObjectCD triggerObject3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChangeVariationWhenContainingObjectCD>(nativeArrayPtr2, j);
					DynamicBuffer<ContainedObjectsBuffer> containedObjects3 = bufferAccessor[j];
					ref LocalTransform translation3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor2[j];
					Execute(entity3, in triggerObject3, in containedObjects3, in translation3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j));
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
					ref ChangeVariationWhenContainingObjectCD triggerObject4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChangeVariationWhenContainingObjectCD>(nativeArrayPtr2, k);
					DynamicBuffer<ContainedObjectsBuffer> containedObjects4 = bufferAccessor[k];
					ref LocalTransform translation4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor2[k];
					Execute(entity4, in triggerObject4, in containedObjects4, in translation4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k));
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
		public BufferLookup<ItemsToAddToNewObjectBuffer> __ItemsToAddToNewObjectBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		public BufferLookup<EffectEventBuffer> __EffectEventBuffer_RW_BufferLookup;

		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RW_ComponentLookup;

		public ChangeVariationWhenContainingObjectJob.InternalCompilerQueryAndHandleData __ChangeVariationWhenContainingObjectSystem_ChangeVariationWhenContainingObjectJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__ItemsToAddToNewObjectBuffer_RO_BufferLookup = state.GetBufferLookup<ItemsToAddToNewObjectBuffer>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			__EffectEventBuffer_RW_BufferLookup = state.GetBufferLookup<EffectEventBuffer>();
			__ObjectDataCD_RW_ComponentLookup = state.GetComponentLookup<ObjectDataCD>();
			__ChangeVariationWhenContainingObjectSystem_ChangeVariationWhenContainingObjectJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000FAD_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000FAD_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000FAD_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000FAE_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000FAE_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000FAE_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00000FAF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00000FAF_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000FAF_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_00000FB0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00000FB0_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00000FB0_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private BlobAssetReference<PugDatabase.PugDatabaseBank> _database;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1117404952_0;

	private EntityQuery __query_1117404952_1;

	private EntityQuery __query_1117404952_2;

	private EntityQuery __query_1117404952_3;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (!_database.IsCreated)
		{
			_database = __query_1117404952_0.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		}
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_1117404952_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		__query_1117404952_2.TryGetSingleton<NetworkTime>(out var value);
		__ScheduleViaJobChunkExtension_0(new ChangeVariationWhenContainingObjectJob
		{
			directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			addItemsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ItemsToAddToNewObjectBuffer_RO_BufferLookup, ref state),
			containedItemsBufferLooup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
			effectEventBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__EffectEventBuffer_RW_BufferLookup, ref state),
			effectEventBufferEntity = __query_1117404952_3.GetSingletonEntity(),
			objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RW_ComponentLookup, ref state),
			database = _database,
			ecb = ecb,
			currentTick = value.ServerTick
		}, __TypeHandle.__ChangeVariationWhenContainingObjectSystem_ChangeVariationWhenContainingObjectJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_0(ChangeVariationWhenContainingObjectJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__ChangeVariationWhenContainingObjectSystem_ChangeVariationWhenContainingObjectJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__ChangeVariationWhenContainingObjectSystem_ChangeVariationWhenContainingObjectJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ChangeVariationWhenContainingObjectSystem_ChangeVariationWhenContainingObjectJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__ChangeVariationWhenContainingObjectSystem_ChangeVariationWhenContainingObjectJob_WithDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1117404952_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1117404952_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1117404952_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1117404952_3 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000FAD_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000FAE_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00000FAF_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00000FB0_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ChangeVariationWhenContainingObjectSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChangeVariationWhenContainingObjectSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChangeVariationWhenContainingObjectSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChangeVariationWhenContainingObjectSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ChangeVariationWhenContainingObjectSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
