using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Automation;
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

namespace RayAttackState
{
	[BurstCompile]
	[UpdateInGroup(typeof(StateUpdateGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	public struct RayAttackStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[]
		{
			typeof(LocalTransform),
			typeof(RandomCD)
		})]
		private struct RayAttackStateJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

					public ComponentTypeHandle<RayAttackStateCD> __RayAttackState_RayAttackStateCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
						__RayAttackState_RayAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RayAttackStateCD>();
						__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
						__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
						__NearbyEntitiesBufferCD_RO_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
						__RayAttackState_RayAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
						__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
						__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
						__NearbyEntitiesBufferCD_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectPropertiesCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<NearbyEntitiesBufferCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<RandomCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RayAttackStateCD>();
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
				public void Run(ref RayAttackStateJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref RayAttackStateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref RayAttackStateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref RayAttackStateJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref RayAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref RayAttackStateJob job, EntityManager entityManager)
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

			public AttackSystem.Helper attackHelper;

			public NativeList<ColliderCastHit> colliderCastHitsCached;

			public EntityCommandBuffer ecb;

			public Entity effectEventBufferSingleton;

			public NetworkTick currentTick;

			public uint tickRate;

			[ReadOnly]
			public ComponentLookup<ElectricityCD> electricityLookup;

			[ReadOnly]
			public ComponentLookup<DirectionCD> directionLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref StateInfoCD stateInfo, ref RayAttackStateCD rayAttackStateCD, in ObjectPropertiesCD objectPropertiesCD, in BehaviourTagsCD behaviourTagsCD, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntitiesBuffer)
			{
				if (stateInfo.IsCurrentState(StateID.RayAttack))
				{
					ref RandomCD valueRW = ref attackHelper.randomLookup.GetRefRW(entity).ValueRW;
					switch (rayAttackStateCD.state)
					{
					case RayAttackStateCD.State.Initializing:
						Initializing(ref rayAttackStateCD, ref valueRW);
						break;
					case RayAttackStateCD.State.Intro:
						Intro(ref rayAttackStateCD, ref valueRW, in entity);
						break;
					case RayAttackStateCD.State.Active:
						Active(entity, ref rayAttackStateCD, ref valueRW, in objectPropertiesCD, in behaviourTagsCD, in nearbyEntitiesBuffer);
						break;
					case RayAttackStateCD.State.Ending:
						Ending(ref rayAttackStateCD, ref stateInfo);
						break;
					}
				}
			}

			private void Initializing(ref RayAttackStateCD rayAttackStateCD, ref RandomCD randomCD)
			{
				rayAttackStateCD.state = RayAttackStateCD.State.Intro;
				rayAttackStateCD.stateTimer.Start(currentTick, rayAttackStateCD.introTimeSeconds, tickRate);
			}

			private void Intro(ref RayAttackStateCD rayAttackStateCD, ref RandomCD randomCD, in Entity entity)
			{
				if (rayAttackStateCD.stateTimer.IsTimerElapsed(currentTick))
				{
					rayAttackStateCD.state = RayAttackStateCD.State.Active;
					if (rayAttackStateCD.randomInitialAngle)
					{
						rayAttackStateCD.startRadianAngle = randomCD.Value.NextFloat(0f, MathF.PI * 2f);
					}
					else
					{
						rayAttackStateCD.startRadianAngle = (directionLookup.TryGetComponent(entity, out var componentData) ? (0f - math.atan2(componentData.direction.x, componentData.direction.z) + MathF.PI / 2f) : 0f);
					}
					float seconds = (float.IsInfinity(rayAttackStateCD.activeTimeSeconds) ? 0f : rayAttackStateCD.activeTimeSeconds);
					rayAttackStateCD.stateTimer.Start(currentTick, seconds, tickRate);
				}
			}

			private void Active(Entity entity, ref RayAttackStateCD rayAttackStateCD, ref RandomCD randomCD, in ObjectPropertiesCD objectPropertiesCD, in BehaviourTagsCD behaviourTagsCD, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntitiesBuffer)
			{
				UpdateAttack(entity, ref rayAttackStateCD, ref randomCD, in objectPropertiesCD, in behaviourTagsCD, in nearbyEntitiesBuffer);
				CheckForFinishActiveState(ref rayAttackStateCD, in entity);
			}

			private void UpdateAttack(Entity entity, ref RayAttackStateCD rayAttackStateCD, ref RandomCD randomCD, in ObjectPropertiesCD objectPropertiesCD, in BehaviourTagsCD behaviourTagsCD, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntitiesBuffer)
			{
				if (!rayAttackStateCD.attackTimer.isRunning || rayAttackStateCD.attackTimer.IsTimerElapsed(currentTick))
				{
					rayAttackStateCD.attackTimer.Start(currentTick, rayAttackStateCD.attackTimeSeconds, tickRate);
					LocalTransform localTransform = attackHelper.localTransformLookup[entity];
					IsBeamHittingSomething(colliderCastHitsCached, in rayAttackStateCD, in localTransform, currentTick, tickRate, ref attackHelper.physicsWorld.CollisionWorld, attackHelper.minionLookup, attackHelper.enemyLookup, attackHelper.playerGhostLookup, attackHelper.tileLookup, ref attackHelper.tileAccessor, out var beamStartPoint, out var beamEndPoint, ignorePlayers: true, in entity);
					float3 attackOffset = beamStartPoint - localTransform.Position;
					float3 x = beamEndPoint - beamStartPoint;
					bool isStatic = objectPropertiesCD.Has(-801784616);
					AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
					{
						effectEventBufferSingleton = effectEventBufferSingleton,
						attacker = entity,
						attackOffset = attackOffset,
						castDirection = math.normalizesafe(x),
						castDistance = math.length(x),
						radius = rayAttackStateCD.rayRadius,
						damage = rayAttackStateCD.damage,
						playerDamage = rayAttackStateCD.damage,
						skipWallAndRootsLootDropOnDestroy = true,
						attackTime = rayAttackStateCD.attackTimeSeconds + 1f / (float)tickRate,
						behaviourTags = behaviourTagsCD,
						isStatic = isStatic,
						canOnlyAttackType = CanOnlyAttackType.EnemyAndPlayer,
						isRanged = true
					};
					attackHelper.Attack(ecb, in p);
				}
			}

			private void CheckForFinishActiveState(ref RayAttackStateCD rayAttackStateCD, in Entity entity)
			{
				bool num = float.IsInfinity(rayAttackStateCD.activeTimeSeconds);
				ElectricityCD componentData;
				bool flag = electricityLookup.TryGetComponent(entity, out componentData) && componentData.hasEnoughElectricityToPowerStuff;
				bool flag2 = electricityLookup.HasComponent(entity);
				if ((!num || (!flag && flag2)) && rayAttackStateCD.stateTimer.IsTimerElapsed(currentTick))
				{
					rayAttackStateCD.state = RayAttackStateCD.State.Ending;
					rayAttackStateCD.stateTimer.Start(currentTick, rayAttackStateCD.endingTimeSeconds, tickRate);
				}
			}

			private void Ending(ref RayAttackStateCD rayAttackStateCD, ref StateInfoCD stateInfo)
			{
				if (rayAttackStateCD.stateTimer.IsTimerElapsed(currentTick))
				{
					stateInfo.LeaveState();
					rayAttackStateCD.state = RayAttackStateCD.State.Initializing;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RayAttackState_RayAttackStateCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
				BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RayAttackStateCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, i), bufferAccessor[i]);
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
							Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RayAttackStateCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
						Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RayAttackStateCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, j), bufferAccessor[j]);
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
						Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RayAttackStateCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr5, k), bufferAccessor[k]);
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
			public ComponentLookup<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

			public RayAttackStateJob.InternalCompilerQueryAndHandleData __RayAttackState_RayAttackStateSystem_RayAttackStateJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Pug_Automation_ElectricityCD_RO_ComponentLookup = state.GetComponentLookup<ElectricityCD>(isReadOnly: true);
				__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
				__RayAttackState_RayAttackStateSystem_RayAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00006DE0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00006DE0_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00006DE0_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00006DE1_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00006DE1_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00006DE1_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnStartRunning_00006DE2_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_00006DE2_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00006DE2_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

		private const float BEAM_STEP_SIZE = 0.2f;

		public const float BEAM_HEIGHT_OFFSET = 0.5f;

		private AttackSystem.Helper _attackHelper;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_955356695_0;

		private EntityQuery __query_955356695_1;

		private EntityQuery __query_955356695_2;

		private EntityQuery __query_955356695_3;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsBeamHittingSomething(NativeList<ColliderCastHit> colliderCastHitsCached, in RayAttackStateCD rayAttackStateCD, in LocalTransform localTransform, NetworkTick currentTick, uint tickRate, ref CollisionWorld collisionWorld, ComponentLookup<MinionCD> minionLookup, ComponentLookup<EnemyCD> enemyLookup, ComponentLookup<PlayerGhost> playerGhostLookup, ComponentLookup<TileCD> tileLookup, ref TileAccessor tileAccessor, out float3 beamStartPoint, out float3 beamEndPoint, bool ignorePlayers, in Entity entity)
		{
			float3 attackDirection = GetAttackDirection(in rayAttackStateCD, currentTick, tickRate);
			float offsetFromCenter = rayAttackStateCD.offsetFromCenter;
			beamStartPoint = GetBeamStartPoint(in localTransform, attackDirection, offsetFromCenter);
			bool flag = float.IsInfinity(rayAttackStateCD.activeTimeSeconds);
			float elapsedSeconds = rayAttackStateCD.stateTimer.GetElapsedSeconds(currentTick, tickRate);
			float remainingSeconds = rayAttackStateCD.stateTimer.GetRemainingSeconds(in currentTick, tickRate);
			float num = ((rayAttackStateCD.expandTime > 0f) ? math.clamp(elapsedSeconds / rayAttackStateCD.expandTime, 0f, 1f) : 1f);
			float num2 = ((rayAttackStateCD.shrinkTime > 0f && !flag) ? math.clamp(remainingSeconds / rayAttackStateCD.shrinkTime, 0f, 1f) : 1f);
			float num3 = num * num2 * rayAttackStateCD.rayLength;
			beamEndPoint = beamStartPoint + attackDirection * num3;
			float3 originalEnd = beamEndPoint;
			bool isHittingSomething = false;
			CheckCollisionFromRay(colliderCastHitsCached, beamStartPoint, ref beamEndPoint, attackDirection, rayAttackStateCD.rayRadius, ref isHittingSomething, tileLookup, enemyLookup, minionLookup, playerGhostLookup, ref collisionWorld, in entity);
			CheckCollisionWithWalls(beamStartPoint, ref beamEndPoint, originalEnd, ref isHittingSomething, ref tileAccessor);
			return isHittingSomething;
		}

		private static float3 GetAttackDirection(in RayAttackStateCD rayAttackStateCD, NetworkTick currentTick, uint tickRate)
		{
			float x = rayAttackStateCD.startRadianAngle + rayAttackStateCD.stateTimer.GetElapsedSeconds(currentTick, tickRate) * rayAttackStateCD.rotateRadiansPerSecond;
			return new float3(math.cos(x), 0f, math.sin(x));
		}

		private static float3 GetBeamStartPoint(in LocalTransform localTransform, float3 currentDirection, float offsetFromCenter)
		{
			float3 result = localTransform.Position + currentDirection * offsetFromCenter;
			result.y = 0.5f;
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void CheckCollisionFromRay(NativeList<ColliderCastHit> colliderCastHitsCached, float3 startPoint, ref float3 endPoint, float3 direction, float radius, ref bool isHittingSomething, ComponentLookup<TileCD> tileLookup, ComponentLookup<EnemyCD> enemyLookup, ComponentLookup<MinionCD> minionLookup, ComponentLookup<PlayerGhost> playerGhostLookup, ref CollisionWorld collisionWorld, in Entity entity)
		{
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 1u,
				GroupIndex = 0
			};
			colliderCastHitsCached.Clear();
			float3 x = endPoint - startPoint;
			if (!collisionWorld.SphereCastAll(startPoint, radius, math.normalizesafe(x), math.length(x), ref colliderCastHitsCached, filter))
			{
				return;
			}
			float num = 1f;
			for (int i = 0; i < colliderCastHitsCached.Length; i++)
			{
				ColliderCastHit colliderCastHit = colliderCastHitsCached[i];
				if ((!tileLookup.HasComponent(colliderCastHit.Entity) || tileLookup[colliderCastHit.Entity].tileType != TileType.ground) && !(colliderCastHit.Entity == entity) && !enemyLookup.HasComponent(colliderCastHit.Entity) && !playerGhostLookup.HasComponent(colliderCastHit.Entity) && !minionLookup.HasComponent(colliderCastHit.Entity) && colliderCastHit.Fraction < num)
				{
					endPoint = colliderCastHit.Position + direction * 0.05f;
					num = colliderCastHit.Fraction;
					isHittingSomething = true;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void CheckCollisionWithWalls(float3 beamStartPoint, ref float3 toWorldPos, float3 originalEnd, ref bool isHittingSomething, ref TileAccessor tileAccessor)
		{
			float3 x = toWorldPos - beamStartPoint;
			float3 float5 = math.normalizesafe(toWorldPos - beamStartPoint);
			int num = (int)(math.length(x) / 0.2f);
			float3 float6 = beamStartPoint;
			for (int i = 0; i < num; i++)
			{
				float6 += float5 * 0.2f;
				if (tileAccessor.GetTop(float6.RoundToInt2()).tileType.IsWallTile())
				{
					toWorldPos = float6;
					isHittingSomething = true;
					_ = math.length(toWorldPos - beamStartPoint) / math.length(beamStartPoint - originalEnd);
					break;
				}
			}
		}

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<EffectEventBuffer>();
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<ClientServerTickRate>();
			AttackSystem.Helper.RequireForUpdate(ref state);
		}

		[BurstCompile]
		public void OnStartRunning(ref SystemState state)
		{
			int simulationTickRate = __query_955356695_0.GetSingleton<ClientServerTickRate>().SimulationTickRate;
			_attackHelper = new AttackSystem.Helper(ref state, simulationTickRate);
		}

		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_955356695_1.TryGetSingleton<NetworkTime>(out var value);
			uint simulationTickRate = (uint)__query_955356695_0.GetSingleton<ClientServerTickRate>().SimulationTickRate;
			_attackHelper.Update(ref state, value.ServerTick, simulationTickRate);
			ComponentLookup<ElectricityCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentLookup, ref state);
			ComponentLookup<DirectionCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state);
			EntityCommandBuffer ecb = __query_955356695_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new RayAttackStateJob
			{
				attackHelper = _attackHelper,
				colliderCastHitsCached = new NativeList<ColliderCastHit>(16, state.WorldUpdateAllocator),
				ecb = ecb,
				effectEventBufferSingleton = __query_955356695_3.GetSingletonEntity(),
				currentTick = value.ServerTick,
				tickRate = simulationTickRate,
				electricityLookup = componentLookup,
				directionLookup = componentLookup2
			}, __TypeHandle.__RayAttackState_RayAttackStateSystem_RayAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(RayAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__RayAttackState_RayAttackStateSystem_RayAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__RayAttackState_RayAttackStateSystem_RayAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__RayAttackState_RayAttackStateSystem_RayAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__RayAttackState_RayAttackStateSystem_RayAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_955356695_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_955356695_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_955356695_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_955356695_3 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00006DE0_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00006DE1_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_00006DE2_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			((RayAttackStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((RayAttackStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((RayAttackStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((RayAttackStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((RayAttackStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}
