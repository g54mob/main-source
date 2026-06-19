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

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct SlimeBossSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_865607152_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<SlimeBossCD>, EnrageStateCD, ObjectDataCD, IsInCombatCD) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<RangeAttackStateCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<SlimeBossCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<EnrageStateCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ObjectDataCD>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<IsInCombatCD>(item5_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<RangeAttackStateCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<SlimeBossCD> item2_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<EnrageStateCD> item3_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<ObjectDataCD> item4_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<IsInCombatCD> item5_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<RangeAttackStateCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<SlimeBossCD>();
				item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
				item4_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
				item5_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<IsInCombatCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_ComponentTypeHandle_RO.Update(ref systemState);
				item4_ComponentTypeHandle_RO.Update(ref systemState);
				item5_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RO),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RO),
					item5_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item5_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<SlimeBossCD>, EnrageStateCD, ObjectDataCD, IsInCombatCD)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<SlimeBossCD>, EnrageStateCD, ObjectDataCD, IsInCombatCD) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<RangeAttackStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<SlimeBossCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EnrageStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ObjectDataCD>();
			state.EntityManager.CompleteDependencyBeforeRO<IsInCombatCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_865607152_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public BufferAccessor<AnimationBuffer> item4_BufferAccessor;

			public IntPtr item5_IntPtr;

			public IntPtr item6_IntPtr;

			public IntPtr item7_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<SlimeBossJumpStateCD>, InternalCompilerInterface.UncheckedRefRW<PhysicsVelocity>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, EnrageStateCD, BehaviourTagsCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<SlimeBossJumpStateCD>, InternalCompilerInterface.UncheckedRefRW<PhysicsVelocity>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, EnrageStateCD, BehaviourTagsCD>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<SlimeBossJumpStateCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<PhysicsVelocity>(item3_IntPtr, index), item4_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item5_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<EnrageStateCD>(item6_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<BehaviourTagsCD>(item7_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<SlimeBossJumpStateCD> item2_ComponentTypeHandle_RW;

			private ComponentTypeHandle<PhysicsVelocity> item3_ComponentTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item4_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item5_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<EnrageStateCD> item6_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<BehaviourTagsCD> item7_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<SlimeBossJumpStateCD>();
				item3_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<PhysicsVelocity>();
				item4_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item5_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item6_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
				item7_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_ComponentTypeHandle_RW.Update(ref systemState);
				item4_BufferTypeHandle_RW.Update(ref systemState);
				item5_ComponentTypeHandle_RW.Update(ref systemState);
				item6_ComponentTypeHandle_RO.Update(ref systemState);
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
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RW),
					item4_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item4_BufferTypeHandle_RW),
					item5_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item5_ComponentTypeHandle_RW),
					item6_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item6_ComponentTypeHandle_RO),
					item7_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item7_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<SlimeBossJumpStateCD>, InternalCompilerInterface.UncheckedRefRW<PhysicsVelocity>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, EnrageStateCD, BehaviourTagsCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<SlimeBossJumpStateCD>, InternalCompilerInterface.UncheckedRefRW<PhysicsVelocity>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, EnrageStateCD, BehaviourTagsCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<SlimeBossJumpStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PhysicsVelocity>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRO<EnrageStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<BehaviourTagsCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_865607152_0.TypeHandle __IFE_865607152_0_TypeHandle;

		public IFE_865607152_1.TypeHandle __IFE_865607152_1_TypeHandle;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_865607152_0_TypeHandle = new IFE_865607152_0.TypeHandle(ref state);
			__IFE_865607152_1_TypeHandle = new IFE_865607152_1.TypeHandle(ref state);
			__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000B44_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000B44_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000B44_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000B45_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000B45_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000B45_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00000B46_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00000B46_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000B46_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_00000B47_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00000B47_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00000B47_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private const float MAX_GROUND_UPDATE_DISTANCE_SQ = 2.25f;

	private const float MAX_WALL_DESTROY_DISTANCE_SQ = 12.25f;

	private AttackSystem.Helper _attackHelper;

	private TileAccessor _tileAccessor;

	private BiomeLookup _biomeLookup;

	private int _jumpAnimID;

	private int _landAnimID;

	private int _enragedJumpAnimID;

	private int _rangeAttackAnim2ID;

	private int _rangeAttackAnim3ID;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_865607152_0;

	private EntityQuery __query_865607152_1;

	private EntityQuery __query_865607152_2;

	private EntityQuery __query_865607152_3;

	private EntityQuery __query_865607152_4;

	private EntityQuery __query_865607152_5;

	private EntityQuery __query_865607152_6;

	private EntityQuery __query_865607152_7;

	private EntityQuery __query_865607152_8;

	private EntityQuery __query_865607152_9;

	private EntityQuery __query_865607152_10;

	private EntityQuery __query_865607152_11;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<TileUpdateBuffer>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate(__query_865607152_2);
		state.RequireForUpdate<WorldInfoCD>();
		_jumpAnimID = -1481439722;
		_landAnimID = -1476340264;
		_enragedJumpAnimID = 459390744;
		_rangeAttackAnim2ID = -324069807;
		_rangeAttackAnim3ID = -1683478841;
		state.RequireForUpdate<SlimeBossCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_biomeLookup = (__query_865607152_4.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_865607152_5.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
		if (!__query_865607152_6.TryGetSingleton<ClientServerTickRate>(out var value2))
		{
			value2.ResolveDefaults();
		}
		_attackHelper = new AttackSystem.Helper(ref state, value2.SimulationTickRate);
		_tileAccessor = new TileAccessor(ref state);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
		_biomeLookup.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		if (!__query_865607152_6.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		__query_865607152_7.TryGetSingleton<NetworkTime>(out var value2);
		_attackHelper.Update(ref state, value2.ServerTick, (uint)value.SimulationTickRate);
		_tileAccessor.Update(ref state);
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		Entity singletonEntity = __query_865607152_8.GetSingletonEntity();
		Entity singletonEntity2 = __query_865607152_9.GetSingletonEntity();
		Entity singletonEntity3 = __query_865607152_10.GetSingletonEntity();
		NetworkTick serverTick = value2.ServerTick;
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		EntityQuery _query_865607152_ = __query_865607152_3;
		int num = math.max(1, _query_865607152_.CalculateEntityCount());
		EntityCommandBuffer ecb = __query_865607152_11.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		foreach (var (uncheckedRefRW, uncheckedRefRW2, enrageStateCD, objectDataCD, isInCombatCD) in IFE_865607152_0.Query(__query_865607152_0, __TypeHandle.__IFE_865607152_0_TypeHandle, ref state))
		{
			if (objectDataCD.objectID != ObjectID.LavaSlimeBoss)
			{
				continue;
			}
			uncheckedRefRW.ValueRW.timeBetweenShots = (enrageStateCD.isEnraged ? 0.183f : 0.275f);
			if (!isInCombatCD.isInCombat)
			{
				uncheckedRefRW2.ValueRW.rangeAttacksTracker = 0;
			}
			if (uncheckedRefRW.ValueRO.internalState == RangeAttackInternalState.CeasingToShoot && uncheckedRefRW2.ValueRO.shouldSetupNewRangeAttack)
			{
				uncheckedRefRW2.ValueRW.rangeAttacksTracker++;
				if (uncheckedRefRW2.ValueRO.rangeAttacksTracker % 4 == 0)
				{
					uncheckedRefRW.ValueRW.projectileID = ObjectID.LavaSlimeBossProjectile;
					float num2 = 1f + (float)(num - 1) * 0.5f;
					uncheckedRefRW.ValueRW.timeBetweenShots = math.max(0.05f, uncheckedRefRW.ValueRO.timeBetweenShots / num2);
					uncheckedRefRW.ValueRW.spawnAtDistanceInfront = 10f;
					uncheckedRefRW.ValueRW.spawnAtDistanceInfrontDeviation = 2f;
					uncheckedRefRW.ValueRW.sameFactionHealingPercentage = 0.2f;
					uncheckedRefRW.ValueRW.projectileTargetsSelf = true;
					uncheckedRefRW.ValueRW.projectileFollowsTarget = true;
					uncheckedRefRW.ValueRW.endDuration = 3.5f;
					uncheckedRefRW.ValueRW.spreadAngle = 360f;
					uncheckedRefRW.ValueRW.animOverride = _rangeAttackAnim2ID;
					uncheckedRefRW.ValueRW.anticipationDuration = 0f;
				}
				else
				{
					uncheckedRefRW.ValueRW.projectileID = ObjectID.FireballProjectile;
					uncheckedRefRW.ValueRW.timeBetweenShots = 0.2f;
					uncheckedRefRW.ValueRW.spawnAtDistanceInfront = 0f;
					uncheckedRefRW.ValueRW.spawnAtDistanceInfrontDeviation = 0f;
					uncheckedRefRW.ValueRW.sameFactionHealingPercentage = 0f;
					uncheckedRefRW.ValueRW.projectileTargetsSelf = false;
					uncheckedRefRW.ValueRW.projectileFollowsTarget = false;
					uncheckedRefRW.ValueRW.endDuration = 2f;
					uncheckedRefRW.ValueRW.spreadAngle = 40f;
					uncheckedRefRW.ValueRW.animOverride = _rangeAttackAnim3ID;
					uncheckedRefRW.ValueRW.anticipationDuration = 1f;
				}
				uncheckedRefRW2.ValueRW.shouldSetupNewRangeAttack = false;
			}
			else if (uncheckedRefRW.ValueRO.internalState == RangeAttackInternalState.PreparingToShoot)
			{
				uncheckedRefRW2.ValueRW.shouldSetupNewRangeAttack = true;
			}
		}
		ComponentLookup<LocalTransform> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state);
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<SlimeBossJumpStateCD>, InternalCompilerInterface.UncheckedRefRW<PhysicsVelocity>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, EnrageStateCD, BehaviourTagsCD> item8 in IFE_865607152_1.Query(__query_865607152_1, __TypeHandle.__IFE_865607152_1_TypeHandle, ref state))
		{
			item8.Deconstruct(out var item, out var item2, out var item3, out var item4, out var item5, out var item6, out var item7, out var entity);
			InternalCompilerInterface.UncheckedRefRW<StateInfoCD> uncheckedRefRW3 = item;
			InternalCompilerInterface.UncheckedRefRW<SlimeBossJumpStateCD> uncheckedRefRW4 = item2;
			InternalCompilerInterface.UncheckedRefRW<PhysicsVelocity> uncheckedRefRW5 = item3;
			DynamicBuffer<AnimationBuffer> animationBuffer = item4;
			InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer> uncheckedRefRW6 = item5;
			EnrageStateCD enrageStateCD2 = item6;
			BehaviourTagsCD behaviourTags = item7;
			Entity entity2 = entity;
			ref readonly StateInfoCD valueRO = ref uncheckedRefRW3.ValueRO;
			ref readonly SlimeBossJumpStateCD valueRO2 = ref uncheckedRefRW4.ValueRO;
			LocalTransform localTransform = componentLookup[entity2];
			if (!valueRO.IsCurrentState(StateID.SlimeBossJump) && !valueRO.IsCurrentState(StateID.SlimeBossTauntJump))
			{
				continue;
			}
			float3 x = valueRO2.targetPos - localTransform.Position;
			float num3 = math.length(x);
			float2 y = new float2(localTransform.Position.x, localTransform.Position.z);
			int2 int5 = localTransform.Position.RoundToInt2();
			if (valueRO2.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(enrageStateCD2.isEnraged ? _enragedJumpAnimID : _jumpAnimID, serverTick, animationBuffer, ref uncheckedRefRW6.ValueRW);
				uncheckedRefRW4.ValueRW.internalState = 1;
				uncheckedRefRW4.ValueRW.internalTimer.Start(elapsedTime, enrageStateCD2.isEnraged ? valueRO2.enragedAnticipationTime : valueRO2.anticipationTime);
			}
			else if (valueRO2.internalState == 1 && uncheckedRefRW4.ValueRW.internalTimer.IsTimerElapsed(elapsedTime))
			{
				if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, valueRO2.target))
				{
					float3 position = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, valueRO2.target).Position;
					uncheckedRefRW4.ValueRW.targetPos = position;
				}
				uncheckedRefRW4.ValueRW.internalState = 2;
				float newLifespan = (enrageStateCD2.isEnraged ? valueRO2.enragedMaxAirTime : valueRO2.maxAirTime);
				uncheckedRefRW4.ValueRW.internalTimer.Start(elapsedTime, newLifespan);
			}
			else if (valueRO2.internalState == 2 && uncheckedRefRW4.ValueRW.internalTimer.GetElapsedTime(elapsedTime) > 0.2f)
			{
				if (num3 < 0.5f || uncheckedRefRW4.ValueRW.internalTimer.IsTimerElapsed(elapsedTime))
				{
					uncheckedRefRW4.ValueRW.internalState = 3;
					AnimationUtilities.TriggerAnimation(_landAnimID, serverTick, animationBuffer, ref uncheckedRefRW6.ValueRW);
					uncheckedRefRW4.ValueRW.internalTimer.Start(elapsedTime, valueRO2.landTime);
				}
			}
			else if (valueRO2.internalState == 3 && uncheckedRefRW4.ValueRW.internalTimer.IsTimerElapsed(elapsedTime))
			{
				float3 attackOffset = new float3(0f, 0f, -0.5f);
				AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
				{
					effectEventBufferSingleton = singletonEntity2,
					attacker = entity2,
					attackOffset = attackOffset,
					canHitLowTriggers = true,
					radius = 0f,
					boxHalfHorizontalWidth = 2.5f,
					boxHalfVerticalWidth = 1.5f,
					damage = valueRO2.damage,
					playerDamage = valueRO2.damage,
					pushback = 2f,
					skipWallAndRootsLootDropOnDestroy = true,
					bypassMaxDamagePerHit = true,
					behaviourTags = behaviourTags
				};
				_attackHelper.Attack(ecb, in p);
				uncheckedRefRW4.ValueRW.internalState = 4;
				int groundTilesetToSpawnForBiome = (int)GetGroundTilesetToSpawnForBiome(_biomeLookup.GetBiome(int5));
				for (int i = -2; i <= 2; i++)
				{
					for (int j = -2; j <= 2; j++)
					{
						int2 int6 = new int2(i, j) + int5;
						if (!(math.distancesq(int6, y) > 2.25f) && !_tileAccessor.HasType(int6, TileType.immune))
						{
							RemoveTileType(int6, TileType.dugUpGround, ref ecb, singletonEntity);
							RemoveTileType(int6, TileType.wateredGround, ref ecb, singletonEntity);
							TileType topType = _tileAccessor.GetTopType(int6);
							if (topType == TileType.pit || topType == TileType.water)
							{
								RemoveTileType(int6, TileType.pit, ref ecb, singletonEntity);
								RemoveTileType(int6, TileType.water, ref ecb, singletonEntity);
								AddTileType(int6, TileType.ground, groundTilesetToSpawnForBiome, ref ecb, singletonEntity);
							}
							RemoveTileType(int6, TileType.groundSlime, ref ecb, singletonEntity);
							if (rng.NextFloat() > 0.3f)
							{
								AddTileType(int6, TileType.groundSlime, (int)valueRO2.slimeTileset, ref ecb, singletonEntity);
							}
						}
					}
				}
			}
			else if (valueRO2.internalState == 4)
			{
				uncheckedRefRW4.ValueRW.internalState = 5;
				uncheckedRefRW4.ValueRW.internalTimer.Start(elapsedTime, enrageStateCD2.isEnraged ? 0.2f : 0.5f);
			}
			else if (valueRO2.internalState == 5 && uncheckedRefRW4.ValueRW.internalTimer.IsTimerElapsed(elapsedTime))
			{
				uncheckedRefRW3.ValueRW.LeaveState();
			}
			if (valueRO2.internalState == 2 && num3 != 0f)
			{
				float num4 = (enrageStateCD2.isEnraged ? valueRO2.enragedJumpMoveSpeed : valueRO2.jumpMoveSpeed);
				float3 float5 = float3.zero;
				if (math.lengthsq(x) > 0.1f)
				{
					float5 = math.normalizesafe(x);
				}
				float3 velocity = float5 * num4 * deltaTime;
				uncheckedRefRW5.ValueRW.AddLinear2D(in velocity);
			}
			int internalState = valueRO2.internalState;
			if (internalState != 2 && internalState != 3)
			{
				continue;
			}
			for (int k = -4; k <= 4; k++)
			{
				for (int l = -4; l <= 4; l++)
				{
					int2 int7 = new int2(k, l) + int5;
					if (!(math.distancesq(int7, y) > 12.25f))
					{
						ecb.AppendToBuffer(singletonEntity3, new TileDamageBuffer
						{
							damage = 10000,
							position = int7,
							skipWallAndRootsLootDropOnDestroy = true,
							canHitLowColliders = true,
							dontHitGroundSlime = true
						});
					}
				}
			}
		}
	}

	private void RemoveTileType(int2 pos, TileType tileType, ref EntityCommandBuffer ecb, Entity tileUpdateBufferSingletonEntity)
	{
		ecb.AppendToBuffer(tileUpdateBufferSingletonEntity, new TileUpdateBuffer
		{
			command = TileUpdateBuffer.Command.Remove,
			position = pos,
			tile = new TileCD
			{
				tileset = 0,
				tileType = tileType
			}
		});
	}

	private void AddTileType(int2 pos, TileType tileType, int tileSet, ref EntityCommandBuffer ecb, Entity tileUpdateBufferSingletonEntity)
	{
		ecb.AppendToBuffer(tileUpdateBufferSingletonEntity, new TileUpdateBuffer
		{
			command = TileUpdateBuffer.Command.Add,
			position = pos,
			tile = new TileCD
			{
				tileset = tileSet,
				tileType = tileType
			}
		});
	}

	private static Tileset GetGroundTilesetToSpawnForBiome(Biome biome)
	{
		return biome switch
		{
			Biome.Slime => Tileset.Dirt, 
			Biome.Larva => Tileset.Clay, 
			Biome.Stone => Tileset.Stone, 
			Biome.Nature => Tileset.Nature, 
			Biome.Sea => Tileset.Sea, 
			Biome.Desert => Tileset.Lava, 
			_ => Tileset.Dirt, 
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EnrageStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsInCombatCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SlimeBossCD>();
		__query_865607152_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnrageStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SlimeBossJumpStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsVelocity>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		__query_865607152_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_865607152_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		__query_865607152_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_865607152_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_865607152_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_865607152_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_865607152_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_865607152_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_865607152_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_865607152_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_865607152_11 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000B44_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000B45_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00000B46_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00000B47_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SlimeBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SlimeBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SlimeBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SlimeBossSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SlimeBossSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
