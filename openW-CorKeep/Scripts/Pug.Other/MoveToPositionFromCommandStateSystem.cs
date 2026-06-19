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
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(StateUpdateGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct MoveToPositionFromCommandStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(LocalTransform),
		typeof(PhysicsVelocity),
		typeof(AnimationOrientationCD),
		typeof(AnimationBufferPointer),
		typeof(AnimationBuffer),
		typeof(ObjectPropertiesCD)
	})]
	private struct MoveToPositionFromCommandStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPositionFromCommandStateCD> __MoveToPositionFromCommandStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__MoveToPositionFromCommandStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPositionFromCommandStateCD>();
					__MovementSpeedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__MoveToPositionFromCommandStateCD_RW_ComponentTypeHandle.Update(ref state);
					__MovementSpeedCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MovementSpeedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsVelocity>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationOrientationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPositionFromCommandStateCD>();
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
			public void Run(ref MoveToPositionFromCommandStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MoveToPositionFromCommandStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MoveToPositionFromCommandStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MoveToPositionFromCommandStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MoveToPositionFromCommandStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MoveToPositionFromCommandStateJob job, EntityManager entityManager)
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

		private const int MAX_CONSECUTIVE_DAMAGE_ATTEMPTS = 8;

		[ReadOnly]
		public TileAccessor TileAccessor;

		[ReadOnly]
		public ComponentLookup<PathFindCD> PathFindLookup;

		[ReadOnly]
		public ComponentLookup<MiningMinionCD> MiningMinionLookup;

		[ReadOnly]
		public ComponentLookup<MeleeAttackStateCD> MeleeAttackStateLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> BehaviourTagsLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> DamageReductionLookup;

		[ReadOnly]
		public BufferLookup<PathFindNodeBuffer> PathFindNodeBufferLookup;

		public EntityCommandBuffer Ecb;

		public AttackSystem.Helper AttackHelper;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> Database;

		public TileWithTilesetToObjectDataMapCD TileToObjectDataLookup;

		public Entity EffectEventBufferSingleton;

		public Entity TileDamageBufferEntity;

		public NetworkTick CurrentTick;

		public float DeltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfo, ref MoveToPositionFromCommandStateCD moveToPositionFromCommandStateCD, in MovementSpeedCD movementSpeedCD)
		{
			if (!stateInfo.IsCurrentState(StateID.MoveToPositionFromCommand))
			{
				return;
			}
			if (moveToPositionFromCommandStateCD.timer > 0f)
			{
				moveToPositionFromCommandStateCD.timer -= DeltaTime;
				return;
			}
			ref readonly LocalTransform valueRO = ref AttackHelper.localTransformLookup.GetRefRO(entity).ValueRO;
			ref PhysicsVelocity valueRW = ref AttackHelper.physicsVelocityAccessor.GetRefRW(entity).ValueRW;
			ref AnimationOrientationCD valueRW2 = ref AttackHelper.animationOrientationLookup.GetRefRW(entity).ValueRW;
			DynamicBuffer<AnimationBuffer> dynamicBuffer = AttackHelper.animationBufferLookup[entity];
			ref AnimationBufferPointer valueRW3 = ref AttackHelper.animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			ref readonly ObjectPropertiesCD valueRO2 = ref AttackHelper.propertiesLookup.GetRefRO(entity).ValueRO;
			float3 position = valueRO.Position;
			Entity pathFindingEntity = moveToPositionFromCommandStateCD.pathFindingEntity;
			if (!PathFindLookup.TryGetComponent(pathFindingEntity, out var componentData) || !PathFindNodeBufferLookup.TryGetBuffer(pathFindingEntity, out var bufferData))
			{
				return;
			}
			if (!PathFindUtility.GetDirection(in componentData, bufferData, position.xz, out var direction))
			{
				if (!componentData.ShouldRefreshPath() && componentData.HasCalculatedPathForTarget())
				{
					AnimationUtilities.TriggerAnimation(-601574123, CurrentTick, dynamicBuffer, ref valueRW3);
					stateInfo.LeaveState();
					moveToPositionFromCommandStateCD.pendingMove = false;
					moveToPositionFromCommandStateCD.lastFinishedMoveToPositionTick = CurrentTick;
				}
				return;
			}
			float3 float5 = direction.ToFloat3();
			if (MiningMinionLookup.TryGetComponent(entity, out var componentData2))
			{
				switch (moveToPositionFromCommandStateCD.damageObjectState)
				{
				case MoveToPositionFromCommandStateCD.InternalState.Init:
				{
					if (!SinglePugMap.RaycastWalls(position.ToFloat2(), float5.ToFloat2(), 0.5f, out var _, TileAccessor))
					{
						moveToPositionFromCommandStateCD.consecutiveDamageAttempts = 0;
						break;
					}
					if (moveToPositionFromCommandStateCD.consecutiveDamageAttempts >= 8)
					{
						AnimationUtilities.TriggerAnimation(-601574123, CurrentTick, dynamicBuffer, ref valueRW3);
						stateInfo.LeaveState();
						moveToPositionFromCommandStateCD.pendingMove = false;
						moveToPositionFromCommandStateCD.lastFinishedMoveToPositionTick = CurrentTick;
						break;
					}
					AnimationUtilities.TriggerAnimation(1203776827, CurrentTick, dynamicBuffer, ref valueRW3);
					moveToPositionFromCommandStateCD.consecutiveDamageAttempts++;
					moveToPositionFromCommandStateCD.damageObjectState = MoveToPositionFromCommandStateCD.InternalState.Anticipation;
					moveToPositionFromCommandStateCD.timer = valueRO2.Get<float>(-1905185935);
					return;
				}
				case MoveToPositionFromCommandStateCD.InternalState.Anticipation:
				{
					if (SinglePugMap.RaycastWalls(position.ToFloat2(), float5.ToFloat2(), 0.5f, out var hitInfo, TileAccessor))
					{
						TileCD top = TileAccessor.GetTop(hitInfo.tile);
						if (CalculateTileDamage(top, componentData2.damage) <= 0)
						{
							moveToPositionFromCommandStateCD.consecutiveDamageAttempts = 8;
						}
						Ecb.AppendToBuffer(TileDamageBufferEntity, new TileDamageBuffer
						{
							causedByEntity = entity,
							damage = componentData2.damage,
							position = hitInfo.tile,
							skipWallAndRootsLootDropOnDestroy = false,
							canHitLowColliders = true
						});
						int meleeDamage = MeleeAttackStateLookup[entity].meleeDamage;
						AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
						{
							effectEventBufferSingleton = EffectEventBufferSingleton,
							attacker = entity,
							isRanged = false,
							attackOffset = float5 * valueRO2.Get<float>(-1904742027),
							radius = valueRO2.Get<float>(357566566),
							damage = meleeDamage,
							playerDamage = meleeDamage,
							skipWallAndRootsLootDropOnDestroy = true,
							behaviourTags = BehaviourTagsLookup[entity]
						};
						AttackHelper.Attack(Ecb, in p);
						moveToPositionFromCommandStateCD.damageObjectState = MoveToPositionFromCommandStateCD.InternalState.Attacking;
						moveToPositionFromCommandStateCD.timer = valueRO2.Get<float>(1367151486);
						return;
					}
					break;
				}
				case MoveToPositionFromCommandStateCD.InternalState.Attacking:
					moveToPositionFromCommandStateCD.damageObjectState = MoveToPositionFromCommandStateCD.InternalState.Init;
					break;
				}
			}
			if (math.any(float5 != float3.zero))
			{
				int num = -281135240;
				if (dynamicBuffer.GetLastAddedElement(in valueRW3).animID != num)
				{
					AnimationUtilities.TriggerAnimation(num, CurrentTick, dynamicBuffer, ref valueRW3);
				}
				valueRW2.SetFacingDirectionFromVector(float5);
			}
			float moveSpeedMultiplier = valueRO2.Get<float>(1477335750);
			float num2 = MoveToPositionFromCommandStateUtility.CalculateMovementSpeed(movementSpeedCD.speed, moveSpeedMultiplier);
			valueRW.AddLinear2D(float5 * num2 * DeltaTime);
		}

		private int CalculateTileDamage(TileCD tile, int baseDamage)
		{
			ObjectDataCD objectDataCD = PugDatabase.TryGetTileItemInfo(tile.tileType, (Tileset)tile.tileset, in TileToObjectDataLookup);
			if (objectDataCD.objectID == ObjectID.None)
			{
				return 0;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectDataCD.objectID, Database, objectDataCD.variation);
			if (primaryPrefabEntity == Entity.Null)
			{
				return 0;
			}
			DamageReductionLookup.TryGetComponent(primaryPrefabEntity, out var componentData);
			return TileDamageSystem.CalculateTileDamageAfterReduction(baseDamage, componentData);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPositionFromCommandStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPositionFromCommandStateCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr4, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPositionFromCommandStateCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr4, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPositionFromCommandStateCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr4, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPositionFromCommandStateCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr4, k));
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
		public ComponentLookup<PathFindCD> __PathFindCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MiningMinionCD> __MiningMinionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MeleeAttackStateCD> __MeleeAttackStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> __DamageReductionCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<PathFindNodeBuffer> __PathFindNodeBuffer_RO_BufferLookup;

		public MoveToPositionFromCommandStateJob.InternalCompilerQueryAndHandleData __MoveToPositionFromCommandStateSystem_MoveToPositionFromCommandStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__PathFindCD_RO_ComponentLookup = state.GetComponentLookup<PathFindCD>(isReadOnly: true);
			__MiningMinionCD_RO_ComponentLookup = state.GetComponentLookup<MiningMinionCD>(isReadOnly: true);
			__MeleeAttackStateCD_RO_ComponentLookup = state.GetComponentLookup<MeleeAttackStateCD>(isReadOnly: true);
			__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
			__DamageReductionCD_RO_ComponentLookup = state.GetComponentLookup<DamageReductionCD>(isReadOnly: true);
			__PathFindNodeBuffer_RO_BufferLookup = state.GetBufferLookup<PathFindNodeBuffer>(isReadOnly: true);
			__MoveToPositionFromCommandStateSystem_MoveToPositionFromCommandStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00003C68_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00003C68_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00003C68_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00003C69_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003C69_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003C69_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00003C6A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00003C6A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00003C6A_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_00003C6B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00003C6B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00003C6B_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1034649778_0;

	private EntityQuery __query_1034649778_1;

	private EntityQuery __query_1034649778_2;

	private EntityQuery __query_1034649778_3;

	private EntityQuery __query_1034649778_4;

	private EntityQuery __query_1034649778_5;

	private EntityQuery __query_1034649778_6;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<TileWithTilesetToObjectDataMapCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
		if (!__query_1034649778_0.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		if (!_attackHelper.isCreated)
		{
			_attackHelper = new AttackSystem.Helper(ref state, value.SimulationTickRate);
		}
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		_tileAccessor.Update(ref state);
		__query_1034649778_1.TryGetSingleton<NetworkTime>(out var value);
		_attackHelper.Update(ref state, value.ServerTick, (uint)__query_1034649778_0.GetSingleton<ClientServerTickRate>().SimulationTickRate);
		EntityCommandBuffer ecb = __query_1034649778_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		Entity singletonEntity = __query_1034649778_3.GetSingletonEntity();
		Entity singletonEntity2 = __query_1034649778_4.GetSingletonEntity();
		state.Dependency = __ScheduleViaJobChunkExtension_0(new MoveToPositionFromCommandStateJob
		{
			TileAccessor = _tileAccessor,
			PathFindLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PathFindCD_RO_ComponentLookup, ref state),
			MiningMinionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MiningMinionCD_RO_ComponentLookup, ref state),
			MeleeAttackStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MeleeAttackStateCD_RO_ComponentLookup, ref state),
			BehaviourTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state),
			DamageReductionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DamageReductionCD_RO_ComponentLookup, ref state),
			PathFindNodeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PathFindNodeBuffer_RO_BufferLookup, ref state),
			Ecb = ecb,
			AttackHelper = _attackHelper,
			Database = __query_1034649778_5.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob,
			TileToObjectDataLookup = __query_1034649778_6.GetSingleton<TileWithTilesetToObjectDataMapCD>(),
			EffectEventBufferSingleton = singletonEntity2,
			TileDamageBufferEntity = singletonEntity,
			CurrentTick = value.ServerTick,
			DeltaTime = state.WorldUnmanaged.Time.DeltaTime
		}, __TypeHandle.__MoveToPositionFromCommandStateSystem_MoveToPositionFromCommandStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(MoveToPositionFromCommandStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__MoveToPositionFromCommandStateSystem_MoveToPositionFromCommandStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__MoveToPositionFromCommandStateSystem_MoveToPositionFromCommandStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__MoveToPositionFromCommandStateSystem_MoveToPositionFromCommandStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__MoveToPositionFromCommandStateSystem_MoveToPositionFromCommandStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1034649778_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1034649778_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1034649778_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1034649778_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1034649778_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1034649778_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileWithTilesetToObjectDataMapCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1034649778_6 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00003C68_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003C69_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00003C6A_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00003C6B_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((MoveToPositionFromCommandStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MoveToPositionFromCommandStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MoveToPositionFromCommandStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MoveToPositionFromCommandStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MoveToPositionFromCommandStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
