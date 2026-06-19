using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
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

[BurstCompile]
[UpdateInGroup(typeof(StateUpdateGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct JumpAttackStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(LocalTransform),
		typeof(PhysicsVelocity),
		typeof(AnimationOrientationCD),
		typeof(AnimationBuffer),
		typeof(AnimationBufferPointer),
		typeof(ObjectPropertiesCD)
	})]
	private struct JumpAttackStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<JumpAttackStateCD> __JumpAttackStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AttackCooldownTimerCD> __AttackCooldownTimerCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__JumpAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<JumpAttackStateCD>();
					__AttackCooldownTimerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AttackCooldownTimerCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__JumpAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AttackCooldownTimerCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsVelocity>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationOrientationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<JumpAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AttackCooldownTimerCD>();
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
			public void Run(ref JumpAttackStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref JumpAttackStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref JumpAttackStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref JumpAttackStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref JumpAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref JumpAttackStateJob job, EntityManager entityManager)
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

		public AttackSystem.Helper _attackHelper;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> behaviourTagsLookUp;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> newCombatantsBuffer;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> conditionEffectsBufferLookup;

		public EntityCommandBuffer ecb;

		public Entity effectEventBufferSingleton;

		public NetworkTick currentTick;

		public int _jumpAnimId;

		public float deltaTime;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, RefRW<StateInfoCD> stateInfoRef, RefRW<JumpAttackStateCD> jumpAttackStateRef, RefRW<AttackCooldownTimerCD> attackCooldownTimerRef)
		{
			RefRW<LocalTransform> refRW = _attackHelper.localTransformLookup.GetRefRW(entity);
			ref StateInfoCD valueRW = ref stateInfoRef.ValueRW;
			ref JumpAttackStateCD valueRW2 = ref jumpAttackStateRef.ValueRW;
			ref AnimationOrientationCD valueRW3 = ref _attackHelper.animationOrientationLookup.GetRefRW(entity).ValueRW;
			ref AttackCooldownTimerCD valueRW4 = ref attackCooldownTimerRef.ValueRW;
			ref PhysicsVelocity valueRW5 = ref _attackHelper.physicsVelocityAccessor.GetRefRW(entity).ValueRW;
			ref AnimationBufferPointer valueRW6 = ref _attackHelper.animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			DynamicBuffer<AnimationBuffer> animationBuffer = _attackHelper.animationBufferLookup[entity];
			ObjectPropertiesCD objectPropertiesCD = _attackHelper.propertiesLookup[entity];
			if (!valueRW.IsCurrentState(StateID.JumpAttack))
			{
				return;
			}
			if (valueRW2.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(_jumpAnimId, currentTick, animationBuffer, ref valueRW6);
				valueRW3.SetFacingDirectionFromVector(valueRW2.jumpDirection);
				valueRW2.internalState = 1;
				valueRW2.internalTimer.Start(time, objectPropertiesCD.Get<float>(-1158321326));
			}
			else if (valueRW2.internalState == 1 && valueRW2.internalTimer.IsTimerElapsed(time))
			{
				if (_attackHelper.localTransformLookup.TryGetComponent(valueRW2.target, out var componentData))
				{
					float3 position = componentData.Position;
					valueRW2.jumpDirection = math.normalizesafe(position - refRW.ValueRO.Position);
				}
				if (newCombatantsBuffer.HasComponent(valueRW2.target))
				{
					ecb.AppendToBuffer(valueRW2.target, new NewCombatantsBuffer
					{
						Target = entity
					});
				}
				valueRW2.internalState = 2;
				valueRW2.internalTimer.Start(time, objectPropertiesCD.Get<float>(-758567886));
				float3 attackOffset = new float3(0f, 0.5f, 0f);
				float pushback = 1.3f;
				float reversePushback = 0.8f;
				behaviourTagsLookUp.TryGetComponent(entity, out var componentData2);
				AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
				{
					effectEventBufferSingleton = effectEventBufferSingleton,
					attacker = entity,
					attackOffset = attackOffset,
					castDirection = valueRW2.jumpDirection,
					radius = 0.375f,
					damage = valueRW2.jumpDamage,
					playerDamage = valueRW2.jumpDamage,
					pushback = pushback,
					reversePushback = reversePushback,
					skipWallAndRootsLootDropOnDestroy = true,
					attackTime = objectPropertiesCD.Get<float>(-758567886),
					canOnlyAttackType = (objectPropertiesCD.Has(464195389) ? CanOnlyAttackType.EnemyAndPlayer : CanOnlyAttackType.All),
					behaviourTags = componentData2
				};
				if (_attackHelper.Attack(ecb, in p, out var _))
				{
					valueRW2.stopJumpAttack = true;
				}
			}
			else if (valueRW2.internalState == 2 && !valueRW2.internalTimer.IsTimerElapsed(time) && valueRW2.internalTimer.isRunning && !valueRW2.stopJumpAttack)
			{
				float num = objectPropertiesCD.Get<float>(2006508332);
				valueRW5.AddLinear2D(valueRW2.jumpDirection * num * deltaTime * valueRW2.internalTimer.GetInvElapsedRatio(time));
				float3 attackOffset2 = new float3(0f, 0.5f, 0f);
				float pushback2 = 1.3f;
				float reversePushback2 = 0.8f;
				behaviourTagsLookUp.TryGetComponent(entity, out var componentData3);
				AttackSystem.Helper.Parameters p2 = new AttackSystem.Helper.Parameters
				{
					effectEventBufferSingleton = effectEventBufferSingleton,
					attacker = entity,
					attackOffset = attackOffset2,
					radius = 0.375f,
					damage = valueRW2.jumpDamage,
					playerDamage = valueRW2.jumpDamage,
					pushback = pushback2,
					castDirection = valueRW2.jumpDirection,
					reversePushback = reversePushback2,
					skipWallAndRootsLootDropOnDestroy = true,
					attackTime = objectPropertiesCD.Get<float>(-758567886),
					canOnlyAttackType = (objectPropertiesCD.Has(464195389) ? CanOnlyAttackType.EnemyAndPlayer : CanOnlyAttackType.All),
					behaviourTags = componentData3
				};
				if (_attackHelper.Attack(ecb, in p2, out var _))
				{
					valueRW2.stopJumpAttack = true;
				}
			}
			else if (valueRW2.internalState == 2 && (valueRW2.internalTimer.IsTimerElapsed(time) || valueRW2.stopJumpAttack))
			{
				valueRW2.internalState = 3;
				float num2 = 1f / (1f + (conditionEffectsBufferLookup.HasComponent(entity) ? ((float)conditionEffectsBufferLookup[entity][40].value / 1000f + (float)conditionEffectsBufferLookup[entity][65].value / 1000f) : 0f));
				valueRW2.internalTimer.Start(time, 0.5f * num2);
			}
			else if (valueRW2.internalState == 3 && valueRW2.internalTimer.IsTimerElapsed(time))
			{
				Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex((uint)((double)(entity.Index + 1) + time * 1000000.0));
				float num3 = 1f / (1f + (conditionEffectsBufferLookup.HasComponent(entity) ? ((float)conditionEffectsBufferLookup[entity][40].value / 1000f + (float)conditionEffectsBufferLookup[entity][65].value / 1000f) : 0f));
				float newLifespan = random.NextFloat(objectPropertiesCD.Get<float>(284634554), objectPropertiesCD.Get<float>(-587573579)) * num3;
				valueRW4.Value.Start(time, newLifespan);
				valueRW.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr ptr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__JumpAttackStateCD_RW_ComponentTypeHandle);
			IntPtr ptr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AttackCooldownTimerCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					RefRW<StateInfoCD> refRW = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, i);
					RefRW<JumpAttackStateCD> refRW2 = InternalCompilerInterface.GetRefRW<JumpAttackStateCD>(ptr2, i);
					RefRW<AttackCooldownTimerCD> refRW3 = InternalCompilerInterface.GetRefRW<AttackCooldownTimerCD>(ptr3, i);
					Execute(entity, refRW, refRW2, refRW3);
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
						RefRW<StateInfoCD> refRW4 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, nextRangeBegin);
						RefRW<JumpAttackStateCD> refRW5 = InternalCompilerInterface.GetRefRW<JumpAttackStateCD>(ptr2, nextRangeBegin);
						RefRW<AttackCooldownTimerCD> refRW6 = InternalCompilerInterface.GetRefRW<AttackCooldownTimerCD>(ptr3, nextRangeBegin);
						Execute(entity2, refRW4, refRW5, refRW6);
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
					RefRW<StateInfoCD> refRW7 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, j);
					RefRW<JumpAttackStateCD> refRW8 = InternalCompilerInterface.GetRefRW<JumpAttackStateCD>(ptr2, j);
					RefRW<AttackCooldownTimerCD> refRW9 = InternalCompilerInterface.GetRefRW<AttackCooldownTimerCD>(ptr3, j);
					Execute(entity3, refRW7, refRW8, refRW9);
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
					RefRW<StateInfoCD> refRW10 = InternalCompilerInterface.GetRefRW<StateInfoCD>(ptr, k);
					RefRW<JumpAttackStateCD> refRW11 = InternalCompilerInterface.GetRefRW<JumpAttackStateCD>(ptr2, k);
					RefRW<AttackCooldownTimerCD> refRW12 = InternalCompilerInterface.GetRefRW<AttackCooldownTimerCD>(ptr3, k);
					Execute(entity4, refRW10, refRW11, refRW12);
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
		public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<NewCombatantsBuffer> __NewCombatantsBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		public JumpAttackStateJob.InternalCompilerQueryAndHandleData __JumpAttackStateSystem_JumpAttackStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
			__NewCombatantsBuffer_RO_BufferLookup = state.GetBufferLookup<NewCombatantsBuffer>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__JumpAttackStateSystem_JumpAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00003AEC_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00003AEC_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00003AEC_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00003AED_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003AED_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003AED_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_00003AEE_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00003AEE_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00003AEE_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStartRunning_00003AEF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00003AEF_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00003AEF_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_00003AF0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00003AF0_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00003AF0_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private AttackSystem.Helper _attackHelper;

	private int _jumpAnimId;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_258804459_0;

	private EntityQuery __query_258804459_1;

	private EntityQuery __query_258804459_2;

	private EntityQuery __query_258804459_3;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		_jumpAnimId = -1481439722;
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<JumpAttackStateCD>();
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (!__query_258804459_0.TryGetSingleton<ClientServerTickRate>(out var value))
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
		if (!__query_258804459_0.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		__query_258804459_1.TryGetSingleton<NetworkTime>(out var value2);
		_attackHelper.Update(ref state, value2.ServerTick, (uint)value.SimulationTickRate);
		EntityCommandBuffer ecb = __query_258804459_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		JumpAttackStateJob job = new JumpAttackStateJob
		{
			_attackHelper = _attackHelper,
			behaviourTagsLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state),
			newCombatantsBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NewCombatantsBuffer_RO_BufferLookup, ref state),
			conditionEffectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			ecb = ecb,
			effectEventBufferSingleton = __query_258804459_3.GetSingletonEntity(),
			currentTick = value2.ServerTick,
			_jumpAnimId = _jumpAnimId,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime,
			time = state.WorldUnmanaged.Time.ElapsedTime
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(ref job, __TypeHandle.__JumpAttackStateSystem_JumpAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ref JumpAttackStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__JumpAttackStateSystem_JumpAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__JumpAttackStateSystem_JumpAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__JumpAttackStateSystem_JumpAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__JumpAttackStateSystem_JumpAttackStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_258804459_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_258804459_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_258804459_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_258804459_3 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00003AEC_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003AED_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00003AEE_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00003AEF_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00003AF0_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((JumpAttackStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((JumpAttackStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((JumpAttackStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((JumpAttackStateSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((JumpAttackStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((JumpAttackStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
