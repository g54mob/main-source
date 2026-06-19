using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
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
public struct BeamAttackStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1188196453_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public BufferAccessor<BeamBuffer> item4_BufferAccessor;

			public BufferAccessor<AnimationBuffer> item5_BufferAccessor;

			public IntPtr item6_IntPtr;

			public IntPtr item7_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<BeamAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<AttackCooldownTimerCD>, DynamicBuffer<BeamBuffer>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<BeamAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<AttackCooldownTimerCD>, DynamicBuffer<BeamBuffer>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<BeamAttackStateCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<AttackCooldownTimerCD>(item3_IntPtr, index), item4_BufferAccessor[index], item5_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item6_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationOrientationCD>(item7_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<BeamAttackStateCD> item2_ComponentTypeHandle_RW;

			private ComponentTypeHandle<AttackCooldownTimerCD> item3_ComponentTypeHandle_RW;

			private BufferTypeHandle<BeamBuffer> item4_BufferTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item5_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item6_ComponentTypeHandle_RW;

			private ComponentTypeHandle<AnimationOrientationCD> item7_ComponentTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<BeamAttackStateCD>();
				item3_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AttackCooldownTimerCD>();
				item4_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<BeamBuffer>();
				item5_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item6_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item7_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationOrientationCD>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_ComponentTypeHandle_RW.Update(ref systemState);
				item4_BufferTypeHandle_RW.Update(ref systemState);
				item5_BufferTypeHandle_RW.Update(ref systemState);
				item6_ComponentTypeHandle_RW.Update(ref systemState);
				item7_ComponentTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RW),
					item4_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item4_BufferTypeHandle_RW),
					item5_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item5_BufferTypeHandle_RW),
					item6_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item6_ComponentTypeHandle_RW),
					item7_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item7_ComponentTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<BeamAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<AttackCooldownTimerCD>, DynamicBuffer<BeamBuffer>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<BeamAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<AttackCooldownTimerCD>, DynamicBuffer<BeamBuffer>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<BeamAttackStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AttackCooldownTimerCD>();
			state.EntityManager.CompleteDependencyBeforeRW<BeamBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationOrientationCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1188196453_0.TypeHandle __IFE_1188196453_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1188196453_0_TypeHandle = new IFE_1188196453_0.TypeHandle(ref state);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000038D2_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000038D2_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000038D2_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000038D3_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000038D3_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000038D3_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_000038D4_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000038D4_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000038D4_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
	internal delegate void __codegen__OnStartRunning_000038D5_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_000038D5_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000038D5_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_000038D6_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_000038D6_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000038D6_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private CollisionFilter _filter;

	private int _attackAnimID;

	private AttackSystem.Helper _attackHelper;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1188196453_0;

	private EntityQuery __query_1188196453_1;

	private EntityQuery __query_1188196453_2;

	private EntityQuery __query_1188196453_3;

	private EntityQuery __query_1188196453_4;

	private EntityQuery __query_1188196453_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		_attackAnimID = 669154430;
		_filter = new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 1u
		};
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<BeamAttackStateCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (!__query_1188196453_1.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		_attackHelper = new AttackSystem.Helper(ref state, value.SimulationTickRate);
		_tileAccessor = new TileAccessor(ref state);
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
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		EntityCommandBuffer ecb = __query_1188196453_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		Entity singletonEntity = __query_1188196453_3.GetSingletonEntity();
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		CollisionWorld collisionWorld = __query_1188196453_4.GetSingleton<PhysicsWorldSingleton>().CollisionWorld;
		if (!__query_1188196453_1.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		__query_1188196453_5.TryGetSingleton<NetworkTime>(out var value2);
		NetworkTick serverTick = value2.ServerTick;
		_attackHelper.Update(ref state, value2.ServerTick, (uint)value.SimulationTickRate);
		_tileAccessor.Update(ref state);
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<BeamAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<AttackCooldownTimerCD>, DynamicBuffer<BeamBuffer>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>> item8 in IFE_1188196453_0.Query(__query_1188196453_0, __TypeHandle.__IFE_1188196453_0_TypeHandle, ref state))
		{
			item8.Deconstruct(out var item, out var item2, out var item3, out var item4, out var item5, out var item6, out var item7, out var entity);
			InternalCompilerInterface.UncheckedRefRW<StateInfoCD> uncheckedRefRW = item;
			InternalCompilerInterface.UncheckedRefRW<BeamAttackStateCD> uncheckedRefRW2 = item2;
			InternalCompilerInterface.UncheckedRefRW<AttackCooldownTimerCD> uncheckedRefRW3 = item3;
			DynamicBuffer<BeamBuffer> dynamicBuffer = item4;
			DynamicBuffer<AnimationBuffer> dynamicBuffer2 = item5;
			InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer> uncheckedRefRW4 = item6;
			InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD> uncheckedRefRW5 = item7;
			Entity entity2 = entity;
			ref BeamAttackStateCD valueRW = ref uncheckedRefRW2.ValueRW;
			ref StateInfoCD valueRW2 = ref uncheckedRefRW.ValueRW;
			DynamicBuffer<AnimationBuffer> animationBuffer = dynamicBuffer2;
			ref AnimationOrientationCD valueRW3 = ref uncheckedRefRW5.ValueRW;
			ref AttackCooldownTimerCD valueRW4 = ref uncheckedRefRW3.ValueRW;
			LocalTransform componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, entity2);
			if (!valueRW2.IsCurrentState(StateID.RangeAttack))
			{
				continue;
			}
			if (valueRW.targetEntity != Entity.Null && InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, valueRW.targetEntity) && (valueRW.internalState == 0 || valueRW.internalState == 1))
			{
				float3 float5 = MathUtilities.DominantSideF3(InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, valueRW.targetEntity).Position - componentAfterCompletingDependency.Position);
				valueRW.positionToShootFrom = componentAfterCompletingDependency.Position + float5 * valueRW.spawnAtDistanceInfront;
				valueRW.targetDirection = float5;
				valueRW3.SetFacingDirectionFromVector(valueRW.targetDirection);
			}
			if (valueRW.internalState == 0 && !valueRW.internalTimer.isRunning)
			{
				AnimationUtilities.TriggerAnimation(_attackAnimID, serverTick, animationBuffer, ref uncheckedRefRW4.ValueRW);
				valueRW.internalTimer.Start(elapsedTime, valueRW.anticipationDuration);
				valueRW.internalState = 1;
			}
			else if (valueRW.internalState == 1 && valueRW.internalTimer.isRunning && valueRW.internalTimer.IsTimerElapsed(elapsedTime))
			{
				if (dynamicBuffer.Length == 0)
				{
					dynamicBuffer.Add(new BeamBuffer
					{
						targetDirection = valueRW.targetDirection
					});
					for (int i = 1; i < valueRW.amountOfBeams; i++)
					{
						int num = ((i % 2 != 0) ? i : (-i + 1));
						float3 targetDirection = math.mul(quaternion.RotateY(math.radians(valueRW.angleBetweenBeams * (float)num)), valueRW.targetDirection);
						dynamicBuffer.Add(new BeamBuffer
						{
							targetDirection = targetDirection
						});
					}
				}
				valueRW.internalTimer.Start(elapsedTime, valueRW.attackDuration);
				valueRW.internalState = 2;
			}
			else if (valueRW.internalState == 2 && valueRW.internalTimer.isRunning && !valueRW.internalTimer.IsTimerElapsed(elapsedTime))
			{
				if (valueRW.damageTimer.isRunning && !valueRW.damageTimer.IsTimerElapsed(elapsedTime))
				{
					continue;
				}
				valueRW.damageTimer.Start(elapsedTime, valueRW.timeBetweenDamageTicks);
				for (int j = 0; j < dynamicBuffer.Length; j++)
				{
					BeamBuffer beamBuffer = dynamicBuffer[j];
					float3 float6 = valueRW.positionToShootFrom + new float3(0f, 0.5f, 0f);
					RaycastInput input = new RaycastInput
					{
						Start = float6,
						End = float6 + beamBuffer.targetDirection * valueRW.beamReachDistance,
						Filter = _filter
					};
					beamBuffer.currentReachDistance = valueRW.beamReachDistance;
					if (collisionWorld.CastRay(input, out var closestHit))
					{
						beamBuffer.currentReachDistance = closestHit.Fraction * valueRW.beamReachDistance;
					}
					for (int k = 0; (float)k < beamBuffer.currentReachDistance * 2f; k++)
					{
						int2 worldPosition = (valueRW.positionToShootFrom + beamBuffer.targetDirection * k * 0.5f).RoundToInt2();
						if (_tileAccessor.GetTopType(worldPosition).IsBlockingTile(includeLowColliders: false))
						{
							beamBuffer.currentReachDistance = (float)k * 0.5f;
							break;
						}
					}
					dynamicBuffer.ElementAt(j) = beamBuffer;
					AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
					{
						effectEventBufferSingleton = singletonEntity,
						attacker = entity2,
						attackOffset = beamBuffer.targetDirection * valueRW.spawnAtDistanceInfront,
						radius = valueRW.beamWidth / 2f,
						castDistance = beamBuffer.currentReachDistance,
						castDirection = beamBuffer.targetDirection,
						damage = valueRW.damage,
						playerDamage = valueRW.damage,
						skipWallAndRootsLootDropOnDestroy = true,
						behaviourTags = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state, entity2)
					};
					_attackHelper.Attack(ecb, in p);
				}
			}
			else if (valueRW.internalState == 2 && valueRW.internalTimer.isRunning && valueRW.internalTimer.IsTimerElapsed(elapsedTime))
			{
				float newLifespan = rng.NextFloat(valueRW.minCooldown, valueRW.maxCooldown);
				valueRW4.Value.Start(elapsedTime, newLifespan);
				dynamicBuffer.Clear();
				valueRW2.LeaveState();
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BeamAttackStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AttackCooldownTimerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BeamBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
		__query_1188196453_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1188196453_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1188196453_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1188196453_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1188196453_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1188196453_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000038D2_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000038D3_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000038D4_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_000038D5_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_000038D6_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((BeamAttackStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BeamAttackStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BeamAttackStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BeamAttackStateSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BeamAttackStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BeamAttackStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
