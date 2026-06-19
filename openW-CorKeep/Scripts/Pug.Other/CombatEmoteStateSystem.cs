using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[RequireMatchingQueriesForUpdate]
public struct CombatEmoteStateSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1623607580_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<AnimationBuffer> item3_BufferAccessor;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			public IntPtr item6_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<CombatEmoteStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>, ObjectPropertiesCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<CombatEmoteStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>, ObjectPropertiesCD>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<CombatEmoteStateCD>(item2_IntPtr, index), item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationOrientationCD>(item5_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ObjectPropertiesCD>(item6_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<CombatEmoteStateCD> item2_ComponentTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item3_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item4_ComponentTypeHandle_RW;

			private ComponentTypeHandle<AnimationOrientationCD> item5_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<ObjectPropertiesCD> item6_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<CombatEmoteStateCD>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item5_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationOrientationCD>();
				item6_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_BufferTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RW.Update(ref systemState);
				item5_ComponentTypeHandle_RW.Update(ref systemState);
				item6_ComponentTypeHandle_RO.Update(ref systemState);
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
					item5_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item5_ComponentTypeHandle_RW),
					item6_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item6_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<CombatEmoteStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>, ObjectPropertiesCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<CombatEmoteStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>, ObjectPropertiesCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<CombatEmoteStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRO<ObjectPropertiesCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1623607580_0.TypeHandle __IFE_1623607580_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1623607580_0_TypeHandle = new IFE_1623607580_0.TypeHandle(ref state);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000039B9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000039B9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000039B9_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1623607580_0;

	private EntityQuery __query_1623607580_1;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		__query_1623607580_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<CombatEmoteStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>, ObjectPropertiesCD> item7 in IFE_1623607580_0.Query(__query_1623607580_0, __TypeHandle.__IFE_1623607580_0_TypeHandle, ref state))
		{
			item7.Deconstruct(out var item, out var item2, out var item3, out var item4, out var item5, out var item6, out var entity);
			InternalCompilerInterface.UncheckedRefRW<StateInfoCD> uncheckedRefRW = item;
			InternalCompilerInterface.UncheckedRefRW<CombatEmoteStateCD> uncheckedRefRW2 = item2;
			DynamicBuffer<AnimationBuffer> animationBuffer = item3;
			InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer> uncheckedRefRW3 = item4;
			InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD> uncheckedRefRW4 = item5;
			ObjectPropertiesCD objectPropertiesCD = item6;
			Entity entity2 = entity;
			ref StateInfoCD valueRW = ref uncheckedRefRW.ValueRW;
			if (!valueRW.IsCurrentState(StateID.CombatEmoting))
			{
				continue;
			}
			ref CombatEmoteStateCD valueRW2 = ref uncheckedRefRW2.ValueRW;
			ref AnimationOrientationCD valueRW3 = ref uncheckedRefRW4.ValueRW;
			ref AnimationBufferPointer valueRW4 = ref uncheckedRefRW3.ValueRW;
			using NativeArray<CombatEmoteAnimationData> nativeArray = objectPropertiesCD.GetList<CombatEmoteAnimationData>(1971396561, Allocator.Temp);
			if (valueRW2.optionalTarget != Entity.Null && InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, valueRW2.optionalTarget))
			{
				float3 position = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, entity2).Position;
				float3 facingDirectionFromVector = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, valueRW2.optionalTarget).Position - position;
				valueRW3.SetFacingDirectionFromVector(facingDirectionFromVector);
			}
			CombatEmoteAnimationData combatEmoteAnimationData = nativeArray[valueRW2.animationIndexToPlay];
			if (valueRW2.internalState == CombatEmoteStateCD.InternalState.Init && combatEmoteAnimationData.preCombatMaxDuration > 0f)
			{
				AnimationUtilities.TriggerAnimation(-601574123, serverTick, animationBuffer, ref valueRW4);
				valueRW2.internalState = CombatEmoteStateCD.InternalState.PreEmoteIdle;
				valueRW2.durationTimer.Start(elapsedTime, rng.NextFloat(combatEmoteAnimationData.preCombatMinDuration, combatEmoteAnimationData.preCombatMaxDuration));
			}
			else if (valueRW2.internalState <= CombatEmoteStateCD.InternalState.PreEmoteIdle && (!valueRW2.durationTimer.isRunning || valueRW2.durationTimer.IsTimerElapsed(elapsedTime)))
			{
				AnimationUtilities.TriggerAnimation(combatEmoteAnimationData.animationId, serverTick, animationBuffer, ref valueRW4);
				valueRW2.internalState = CombatEmoteStateCD.InternalState.PlayingEmote;
				valueRW2.durationTimer.Start(elapsedTime, combatEmoteAnimationData.duration);
			}
			else if (valueRW2.internalState == CombatEmoteStateCD.InternalState.PlayingEmote && valueRW2.durationTimer.IsTimerElapsed(elapsedTime))
			{
				valueRW.LeaveState();
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CombatEmoteStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
		__query_1623607580_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1623607580_1 = entityQueryBuilder2.Build(ref state);
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
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000039B9_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((CombatEmoteStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CombatEmoteStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
