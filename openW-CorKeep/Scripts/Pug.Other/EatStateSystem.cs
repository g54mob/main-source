using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Inventory;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class EatStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct EatStateSystem_6E221D99_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003A09_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003A09_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003A09_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public double time;

		public int idleAnim;

		public int eatAnim;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> localDatabase;

		public EntityCommandBuffer ecb;

		public BufferLookup<ContainedObjectsBuffer> containerLookUp;

		public ComponentLookup<EquippedObjectCD> equippedObjectGroup;

		public ComponentLookup<ObjectDataCD> objectDataGroup;

		public ComponentLookup<MealsEatenCD> mealsEatenGroup;

		public EntityArchetype localRpcArchetype;

		public Entity healthChangeBufferEntity;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		public Entity inventoryChangeBufferEntity;

		public BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup;

		public bool isServerLocal;

		public NetworkTick currentTick;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<EatStateCD> __eatStateTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animCDTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __animationBufferPointerTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __animOrientationTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref EatStateCD eatState, DynamicBuffer<AnimationBuffer> animCD, [NoAlias] ref AnimationBufferPointer animationBufferPointer, [NoAlias] ref AnimationOrientationCD animOrientation)
		{
			if (!stateInfo.IsCurrentState(StateID.Eat))
			{
				return;
			}
			float3 float5 = (__Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(entity) ? __Unity_Transforms_LocalTransform_ComponentLookup[entity].Position : float3.zero);
			if (!objectDataGroup.HasComponent(eatState.entityToEatFrom))
			{
				stateInfo.LeaveState();
				return;
			}
			float2 float6 = __Unity_Transforms_LocalTransform_ComponentLookup[eatState.entityToEatFrom].Position.ToFloat2();
			float2 x = float6;
			ObjectDataCD objectDataCD = objectDataGroup[eatState.entityToEatFrom];
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD.objectID, localDatabase, objectDataCD.variation);
			float num = float.PositiveInfinity;
			int2 size = entityObjectInfo.prefabTileSize;
			int2 offset = entityObjectInfo.prefabCornerOffset;
			if (__DirectionCD_ComponentLookup.HasComponent(eatState.entityToEatFrom))
			{
				__DirectionCD_ComponentLookup[eatState.entityToEatFrom].GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
			}
			for (int i = offset.y; i < offset.y + size.y; i++)
			{
				for (int j = offset.x; j < offset.x + size.x; j++)
				{
					float2 float7 = float6 + new float2(j, i);
					float num2 = math.distancesq(float5.ToFloat2(), float7);
					if (num > num2)
					{
						num = num2;
						x = float7;
					}
				}
			}
			if (eatState.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(idleAnim, currentTick, animCD, ref animationBufferPointer);
				eatState.internalState = 1;
				eatState.timer.Start(time, 1f);
			}
			else if (eatState.internalState == 1 && eatState.timer.IsTimerElapsed(time))
			{
				EatStateCD.ObjectToEatType objectToEatType = eatState.objectToEatType;
				if (num <= eatState.sqDistanceToEat && (!entityDestroyedLookup.HasComponent(eatState.entityToEatFrom) || !entityDestroyedLookup.IsComponentEnabled(eatState.entityToEatFrom)) && (objectToEatType == EatStateCD.ObjectToEatType.Entity || (objectToEatType == EatStateCD.ObjectToEatType.ContainedEntity && containerLookUp.HasComponent(eatState.entityToEatFrom) && InventoryUtility.HasObject(containerLookUp, eatState.entityToEatFrom, eatState.objectIdToEat)) || (objectToEatType == EatStateCD.ObjectToEatType.HeldEntity && equippedObjectGroup.TryGetComponent(eatState.entityToEatFrom, out var componentData) && componentData.containedObject.objectID == eatState.objectIdToEat)))
				{
					AnimationUtilities.TriggerAnimation(eatAnim, currentTick, animCD, ref animationBufferPointer);
					eatState.internalState = 2;
					eatState.timer.Start(time, eatState.duration);
				}
				else
				{
					eatState.internalState = 3;
					eatState.timer.Start(time, 0.5f);
				}
			}
			else if (eatState.internalState == 2 && eatState.timer.IsTimerElapsed(time))
			{
				EatStateCD.ObjectToEatType objectToEatType2 = eatState.objectToEatType;
				if (num <= eatState.sqDistanceToEat && (!entityDestroyedLookup.HasComponent(eatState.entityToEatFrom) || !entityDestroyedLookup.IsComponentEnabled(eatState.entityToEatFrom)) && (objectToEatType2 == EatStateCD.ObjectToEatType.Entity || (objectToEatType2 == EatStateCD.ObjectToEatType.ContainedEntity && containerLookUp.HasComponent(eatState.entityToEatFrom) && InventoryUtility.HasObject(containerLookUp, eatState.entityToEatFrom, eatState.objectIdToEat)) || (objectToEatType2 == EatStateCD.ObjectToEatType.HeldEntity && equippedObjectGroup.TryGetComponent(eatState.entityToEatFrom, out var componentData2) && componentData2.containedObject.objectID == eatState.objectIdToEat)))
				{
					if (mealsEatenGroup.HasComponent(entity))
					{
						MealsEatenCD value = mealsEatenGroup[entity];
						value.Value++;
						mealsEatenGroup[entity] = value;
					}
					ObjectDataCD value2 = objectDataGroup[entity];
					value2.amount++;
					objectDataGroup[entity] = value2;
					switch (objectToEatType2)
					{
					case EatStateCD.ObjectToEatType.Entity:
						if (__HealthCD_ComponentLookup.HasComponent(eatState.entityToEatFrom))
						{
							HealthCD healthCD = __HealthCD_ComponentLookup[eatState.entityToEatFrom];
							ecb.AppendToBuffer(healthChangeBufferEntity, new HealthChangeBuffer
							{
								healthChange = new HealthChange
								{
									entity = eatState.entityToEatFrom,
									amount = -healthCD.health,
									skipLootDropOnDestroy = true,
									bypassDamageReduction = true,
									bypassMaxDamagePerHit = true,
									skipWallAndRootsLootDropOnDestroy = true,
									causedByEntity = entity,
									wasKilled = true
								}
							});
						}
						else if (entityDestroyedLookup.HasComponent(eatState.entityToEatFrom))
						{
							ecb.SetComponentEnabled<EntityDestroyedCD>(eatState.entityToEatFrom, value: true);
						}
						else
						{
							Debug.LogError($"Missing EntityDestroyCD on entity with id: {eatState.entityToEatFrom.Index}");
						}
						break;
					case EatStateCD.ObjectToEatType.HeldEntity:
					case EatStateCD.ObjectToEatType.ContainedEntity:
						if (objectToEatType2 == EatStateCD.ObjectToEatType.HeldEntity)
						{
							AchievementSystem.TriggerAchievement(isServerLocal, ecb, localRpcArchetype, AchievementID.FeedCattle, eatState.entityToEatFrom);
						}
						inventoryChangeBufferLookup[inventoryChangeBufferEntity].Add(new InventoryChangeBuffer
						{
							inventoryChangeData = Create.ConsumeObjectType(eatState.entityToEatFrom, eatState.objectIdToEat, 1)
						});
						break;
					}
				}
				eatState.internalState = 3;
				eatState.timer.Start(time, eatState.eatPostDuration);
			}
			else if (eatState.internalState == 3 && eatState.timer.IsTimerElapsed(time))
			{
				stateInfo.LeaveState();
			}
			float3 facingDirectionFromVector = math.normalizesafe(x.ToFloat3() - float5);
			animOrientation.SetFacingDirectionFromVector(facingDirectionFromVector);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __eatStateTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animCDTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animationBufferPointerTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animOrientationTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EatStateCD>(nativeArrayPtr3, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EatStateCD>(nativeArrayPtr3, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EatStateCD>(nativeArrayPtr3, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EatStateCD>(nativeArrayPtr3, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr5, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003A09_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003A09_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<EatStateSystem_6E221D99_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<EatStateCD> __EatStateCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<EquippedObjectCD> __EquippedObjectCD_RO_ComponentLookup;

		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RW_ComponentLookup;

		public ComponentLookup<MealsEatenCD> __MealsEatenCD_RW_ComponentLookup;

		public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__EatStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EatStateCD>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
			__AnimationOrientationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>();
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__ContainedObjectsBuffer_RW_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>();
			__EquippedObjectCD_RO_ComponentLookup = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
			__ObjectDataCD_RW_ComponentLookup = state.GetComponentLookup<ObjectDataCD>();
			__MealsEatenCD_RW_ComponentLookup = state.GetComponentLookup<MealsEatenCD>();
			__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
		}
	}

	private EntityArchetype rpcArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1990383270_0;

	private EntityQuery __query_1990383270_1;

	private EntityQuery __query_1990383270_2;

	private EntityQuery __query_1990383270_3;

	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		NeedDatabase();
		rpcArchetype = base.EntityManager.CreateArchetype(typeof(AchievementSystem.AchievementRpc), typeof(SendRpcCommandRequest));
		RequireForUpdate<EatStateCD>();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		int idleAnim = -601574123;
		int eatAnim = -1697431782;
		BlobAssetReference<PugDatabase.PugDatabaseBank> localDatabase = database;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		BufferLookup<ContainedObjectsBuffer> containerLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup, ref base.CheckedStateRef);
		ComponentLookup<EquippedObjectCD> equippedObjectGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EquippedObjectCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<ObjectDataCD> objectDataGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RW_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<MealsEatenCD> mealsEatenGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MealsEatenCD_RW_ComponentLookup, ref base.CheckedStateRef);
		EntityArchetype localRpcArchetype = rpcArchetype;
		Entity healthChangeBufferEntity = __query_1990383270_1.GetSingletonEntity();
		ComponentLookup<EntityDestroyedCD> entityDestroyedLookup = GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		Entity inventoryChangeBufferEntity = __query_1990383270_2.GetSingletonEntity();
		BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref base.CheckedStateRef);
		bool isServerLocal = base.isServer;
		__query_1990383270_3.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		EatStateSystem_6E221D99_LambdaJob_0_Execute(ref time, ref idleAnim, ref eatAnim, ref localDatabase, ref ecb, ref containerLookUp, ref equippedObjectGroup, ref objectDataGroup, ref mealsEatenGroup, ref localRpcArchetype, ref healthChangeBufferEntity, ref entityDestroyedLookup, ref inventoryChangeBufferEntity, ref inventoryChangeBufferLookup, ref isServerLocal, ref currentTick);
		base.OnUpdate();
	}

	private void EatStateSystem_6E221D99_LambdaJob_0_Execute(ref double time, ref int idleAnim, ref int eatAnim, ref BlobAssetReference<PugDatabase.PugDatabaseBank> localDatabase, ref EntityCommandBuffer ecb, ref BufferLookup<ContainedObjectsBuffer> containerLookUp, ref ComponentLookup<EquippedObjectCD> equippedObjectGroup, ref ComponentLookup<ObjectDataCD> objectDataGroup, ref ComponentLookup<MealsEatenCD> mealsEatenGroup, ref EntityArchetype localRpcArchetype, ref Entity healthChangeBufferEntity, ref ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ref Entity inventoryChangeBufferEntity, ref BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup, ref bool isServerLocal, ref NetworkTick currentTick)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EatStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DirectionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		EatStateSystem_6E221D99_LambdaJob_0_Job value = new EatStateSystem_6E221D99_LambdaJob_0_Job
		{
			time = time,
			idleAnim = idleAnim,
			eatAnim = eatAnim,
			localDatabase = localDatabase,
			ecb = ecb,
			containerLookUp = containerLookUp,
			equippedObjectGroup = equippedObjectGroup,
			objectDataGroup = objectDataGroup,
			mealsEatenGroup = mealsEatenGroup,
			localRpcArchetype = localRpcArchetype,
			healthChangeBufferEntity = healthChangeBufferEntity,
			entityDestroyedLookup = entityDestroyedLookup,
			inventoryChangeBufferEntity = inventoryChangeBufferEntity,
			inventoryChangeBufferLookup = inventoryChangeBufferLookup,
			isServerLocal = isServerLocal,
			currentTick = currentTick,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__eatStateTypeHandle = __TypeHandle.__EatStateCD_RW_ComponentTypeHandle,
			__animCDTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__animationBufferPointerTypeHandle = __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle,
			__animOrientationTypeHandle = __TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup,
			__DirectionCD_ComponentLookup = __TypeHandle.__DirectionCD_RO_ComponentLookup,
			__HealthCD_ComponentLookup = __TypeHandle.__HealthCD_RO_ComponentLookup
		};
		if (!__query_1990383270_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			EatStateSystem_6E221D99_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1990383270_0, jobPtr);
		}
		time = value.time;
		idleAnim = value.idleAnim;
		eatAnim = value.eatAnim;
		localDatabase = value.localDatabase;
		ecb = value.ecb;
		containerLookUp = value.containerLookUp;
		equippedObjectGroup = value.equippedObjectGroup;
		objectDataGroup = value.objectDataGroup;
		mealsEatenGroup = value.mealsEatenGroup;
		localRpcArchetype = value.localRpcArchetype;
		healthChangeBufferEntity = value.healthChangeBufferEntity;
		entityDestroyedLookup = value.entityDestroyedLookup;
		inventoryChangeBufferEntity = value.inventoryChangeBufferEntity;
		inventoryChangeBufferLookup = value.inventoryChangeBufferLookup;
		isServerLocal = value.isServerLocal;
		currentTick = value.currentTick;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EatStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
		__query_1990383270_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1990383270_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1990383270_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1990383270_3 = entityQueryBuilder2.Build(ref state);
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
	public EatStateSystem()
	{
	}
}
