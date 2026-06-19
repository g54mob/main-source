using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[BurstCompile]
public struct VulnerableStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2123980619_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<AnimationBuffer> item3_BufferAccessor;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			public BufferAccessor<SummarizedConditionEffectsBuffer> item6_BufferAccessor;

			public IntPtr item7_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<VulnerableStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, LocalTransform, DynamicBuffer<SummarizedConditionEffectsBuffer>, HealthCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<VulnerableStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, LocalTransform, DynamicBuffer<SummarizedConditionEffectsBuffer>, HealthCD>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<VulnerableStateCD>(item2_IntPtr, index), item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<LocalTransform>(item5_IntPtr, index), item6_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<HealthCD>(item7_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<VulnerableStateCD> item2_ComponentTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item3_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item4_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<LocalTransform> item5_ComponentTypeHandle_RO;

			private BufferTypeHandle<SummarizedConditionEffectsBuffer> item6_BufferTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<HealthCD> item7_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<VulnerableStateCD>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item5_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				item6_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>();
				item7_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_BufferTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RW.Update(ref systemState);
				item5_ComponentTypeHandle_RO.Update(ref systemState);
				item6_BufferTypeHandle_RW.Update(ref systemState);
				item7_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW),
					item3_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item3_BufferTypeHandle_RW),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RW),
					item5_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item5_ComponentTypeHandle_RO),
					item6_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item6_BufferTypeHandle_RW),
					item7_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item7_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<VulnerableStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, LocalTransform, DynamicBuffer<SummarizedConditionEffectsBuffer>, HealthCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<VulnerableStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, LocalTransform, DynamicBuffer<SummarizedConditionEffectsBuffer>, HealthCD> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<StateInfoCD>();
			state.EntityManager.CompleteDependencyBeforeRW<VulnerableStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
			state.EntityManager.CompleteDependencyBeforeRW<SummarizedConditionEffectsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<HealthCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_2123980619_0.TypeHandle __IFE_2123980619_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_2123980619_0_TypeHandle = new IFE_2123980619_0.TypeHandle(ref state);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000041BB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000041BB_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000041BB_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000041BC_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000041BC_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000041BC_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_000041BD_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000041BD_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000041BD_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
	internal delegate void __codegen__OnStartRunning_000041BE_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_000041BE_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000041BE_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_000041BF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_000041BF_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000041BF_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private int _preVulnerableAnimID;

	private int _vulnerableAnimID;

	private int _endVulnerableAnimID;

	private int _idleAnimID;

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2123980619_0;

	private EntityQuery __query_2123980619_1;

	private EntityQuery __query_2123980619_2;

	private EntityQuery __query_2123980619_3;

	private EntityQuery __query_2123980619_4;

	private EntityQuery __query_2123980619_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		_preVulnerableAnimID = -1498481396;
		_vulnerableAnimID = 425101933;
		_endVulnerableAnimID = -2008574808;
		_idleAnimID = -601574123;
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<VulnerableStateCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (!__query_2123980619_1.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		_attackHelper = new AttackSystem.Helper(ref state, value.SimulationTickRate);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_2123980619_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		Entity singletonEntity = __query_2123980619_3.GetSingletonEntity();
		Entity singletonEntity2 = __query_2123980619_4.GetSingletonEntity();
		if (!__query_2123980619_1.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		__query_2123980619_5.TryGetSingleton<NetworkTime>(out var value2);
		NetworkTick serverTick = value2.ServerTick;
		_attackHelper.Update(ref state, value2.ServerTick, (uint)value.SimulationTickRate);
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<VulnerableStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, LocalTransform, DynamicBuffer<SummarizedConditionEffectsBuffer>, HealthCD> item8 in IFE_2123980619_0.Query(__query_2123980619_0, __TypeHandle.__IFE_2123980619_0_TypeHandle, ref state))
		{
			item8.Deconstruct(out var item, out var item2, out var item3, out var item4, out var item5, out var item6, out var item7, out var entity);
			InternalCompilerInterface.UncheckedRefRW<StateInfoCD> uncheckedRefRW = item;
			InternalCompilerInterface.UncheckedRefRW<VulnerableStateCD> uncheckedRefRW2 = item2;
			DynamicBuffer<AnimationBuffer> dynamicBuffer = item3;
			InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer> uncheckedRefRW3 = item4;
			LocalTransform localTransform = item5;
			DynamicBuffer<SummarizedConditionEffectsBuffer> dynamicBuffer2 = item6;
			HealthCD healthCD = item7;
			Entity entity2 = entity;
			ref VulnerableStateCD valueRW = ref uncheckedRefRW2.ValueRW;
			ref AnimationBufferPointer valueRW2 = ref uncheckedRefRW3.ValueRW;
			ref StateInfoCD valueRW3 = ref uncheckedRefRW.ValueRW;
			if (!valueRW3.IsCurrentState(StateID.Vulnerable))
			{
				valueRW.internalState = 0;
				valueRW.isVulnerable = false;
				valueRW.isInVulnerableState = false;
				continue;
			}
			if (valueRW.internalState == 0)
			{
				if (valueRW.preAnticipationDuration > 0f)
				{
					AnimationUtilities.TriggerAnimation(_preVulnerableAnimID, serverTick, dynamicBuffer, ref valueRW2);
					valueRW.internalTimer.Start(elapsedTime, valueRW.preAnticipationDuration);
				}
				valueRW.internalState = 1;
				valueRW.isInVulnerableState = true;
			}
			if (valueRW.internalState == 1 && (!valueRW.internalTimer.isRunning || valueRW.internalTimer.IsTimerElapsed(elapsedTime)))
			{
				valueRW.healthRatioOnEnterState = healthCD.Normalized;
				valueRW.internalState = 2;
				AnimationUtilities.TriggerAnimation(_vulnerableAnimID, serverTick, dynamicBuffer, ref valueRW2);
				valueRW.internalTimer.Start(elapsedTime, valueRW.anticipationDuration);
				EntityUtility.AddNewCondition(entity2, ecb, new ConditionData
				{
					conditionID = ConditionID.Vulnerable,
					duration = 10f,
					value = 1
				});
				valueRW.isVulnerable = true;
			}
			else if (valueRW.internalState == 2 && valueRW.internalTimer.IsTimerElapsed(elapsedTime))
			{
				valueRW.internalState = 3;
				valueRW.internalTimer.Start(elapsedTime, valueRW.vulnerableDuration);
				if (valueRW.pushBackNearbyEntitiesForce > 0f && valueRW.pushBackNearbyEntitiesForceRadius > 0f)
				{
					AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
					{
						effectEventBufferSingleton = singletonEntity2,
						attacker = entity2,
						radius = valueRW.pushBackNearbyEntitiesForceRadius,
						damage = 0,
						playerDamage = 0,
						pushback = valueRW.pushBackNearbyEntitiesForce,
						performAttackEvenIfZeroDamage = true
					};
					_attackHelper.Attack(ecb, in p);
				}
				if (!(valueRW.destroyTilesWithinRadius > 0f))
				{
					continue;
				}
				int num = (int)math.round(valueRW.destroyTilesWithinRadius);
				float3 position = localTransform.Position;
				int2 int5 = position.RoundToInt2();
				for (int i = -num; i <= num; i++)
				{
					for (int j = -num; j <= num; j++)
					{
						int2 int6 = new int2(i, j) + int5;
						if (math.distance(int6.ToFloat3(), position) <= valueRW.destroyTilesWithinRadius)
						{
							ecb.AppendToBuffer(singletonEntity, new TileDamageBuffer
							{
								causedByEntity = entity2,
								damage = 10000,
								position = int6,
								skipWallAndRootsLootDropOnDestroy = true,
								canHitLowColliders = true,
								bypassDamageReduction = true
							});
						}
					}
				}
			}
			else if (valueRW.internalState == 3 && (valueRW.internalTimer.IsTimerElapsed(elapsedTime) || valueRW.healthRatioOnEnterState - healthCD.Normalized > valueRW.maxHealthRatioLostToLeaveState))
			{
				valueRW.isVulnerable = false;
				valueRW.isInVulnerableState = false;
				AnimationUtilities.TriggerAnimation(_endVulnerableAnimID, serverTick, dynamicBuffer, ref valueRW2);
				EntityUtility.RemoveCondition(entity2, ecb, ConditionID.Vulnerable);
				EntityUtility.AddNewCondition(entity2, ecb, new ConditionData
				{
					conditionID = ConditionID.ProtectiveArmor,
					duration = float.PositiveInfinity,
					value = (int)math.round((float)InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state, entity2).maxHealth * 0.3f)
				});
				valueRW.internalState = 4;
				valueRW.internalTimer.Start(elapsedTime, valueRW.endDuration);
			}
			else
			{
				if (valueRW.internalState != 4)
				{
					continue;
				}
				if (valueRW.internalTimer.GetElapsedTime(elapsedTime) > 0.5f && dynamicBuffer2[98].value <= 0)
				{
					valueRW.internalState = 0;
					valueRW.internalTimer.Stop();
				}
				else if (valueRW.internalTimer.IsTimerElapsed(elapsedTime))
				{
					if (dynamicBuffer.GetLastAddedElement(in valueRW2).animID != _idleAnimID)
					{
						AnimationUtilities.TriggerAnimation(_idleAnimID, serverTick, dynamicBuffer, ref valueRW2);
					}
					valueRW3.LeaveState();
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<VulnerableStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SummarizedConditionEffectsBuffer>();
		__query_2123980619_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2123980619_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2123980619_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2123980619_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2123980619_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2123980619_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000041BB_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000041BC_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000041BD_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_000041BE_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_000041BF_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((VulnerableStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((VulnerableStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((VulnerableStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((VulnerableStateSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((VulnerableStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((VulnerableStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
