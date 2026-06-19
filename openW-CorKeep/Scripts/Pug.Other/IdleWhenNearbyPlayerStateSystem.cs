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
using Unity.Transforms;
using UnityEngine.Scripting;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class IdleWhenNearbyPlayerStateSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1298652709_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<AnimationBuffer> item3_BufferAccessor;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<IdleWhenNearbyPlayerStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<IdleWhenNearbyPlayerStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<IdleWhenNearbyPlayerStateCD>(item2_IntPtr, index), item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationOrientationCD>(item5_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<IdleWhenNearbyPlayerStateCD> item2_ComponentTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item3_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item4_ComponentTypeHandle_RW;

			private ComponentTypeHandle<AnimationOrientationCD> item5_ComponentTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<IdleWhenNearbyPlayerStateCD>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item5_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationOrientationCD>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_BufferTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RW.Update(ref systemState);
				item5_ComponentTypeHandle_RW.Update(ref systemState);
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
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<IdleWhenNearbyPlayerStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<IdleWhenNearbyPlayerStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<IdleWhenNearbyPlayerStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationOrientationCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1298652709_0.TypeHandle __IFE_1298652709_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1298652709_0_TypeHandle = new IFE_1298652709_0.TypeHandle(ref state);
			__DisablePhysicsCD_RO_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
		}
	}

	private const float SQR_DISTANCE_TO_PLAYER_TO_STOP_IDLE = 6.25f;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1298652709_0;

	private EntityQuery __query_1298652709_1;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<IdleWhenNearbyPlayerStateCD>();
		base.OnCreate();
	}

	[BurstCompile]
	[Preserve]
	protected override void OnUpdate()
	{
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		double elapsedTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		int animID = -601574123;
		__query_1298652709_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<IdleWhenNearbyPlayerStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD>> item6 in IFE_1298652709_0.Query(__query_1298652709_0, __TypeHandle.__IFE_1298652709_0_TypeHandle, ref base.CheckedStateRef))
		{
			item6.Deconstruct(out var item, out var item2, out var item3, out var item4, out var item5, out var entity);
			InternalCompilerInterface.UncheckedRefRW<StateInfoCD> uncheckedRefRW = item;
			InternalCompilerInterface.UncheckedRefRW<IdleWhenNearbyPlayerStateCD> uncheckedRefRW2 = item2;
			DynamicBuffer<AnimationBuffer> animationBuffer = item3;
			InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer> uncheckedRefRW3 = item4;
			InternalCompilerInterface.UncheckedRefRW<AnimationOrientationCD> uncheckedRefRW4 = item5;
			Entity entity2 = entity;
			ref StateInfoCD valueRW = ref uncheckedRefRW.ValueRW;
			if (!valueRW.IsCurrentState(StateID.IdleWhenNearbyPlayer))
			{
				continue;
			}
			ref IdleWhenNearbyPlayerStateCD valueRW2 = ref uncheckedRefRW2.ValueRW;
			ref AnimationBufferPointer valueRW3 = ref uncheckedRefRW3.ValueRW;
			if (valueRW2.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(animID, serverTick, animationBuffer, ref valueRW3);
				valueRW2.internalState = 1;
			}
			bool num = valueRW2.currentNearPlayer != Entity.Null && (!InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref base.CheckedStateRef, valueRW2.currentNearPlayer) || !InternalCompilerInterface.IsComponentEnabledAfterCompletingDependency(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref base.CheckedStateRef, valueRW2.currentNearPlayer)) && InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref base.CheckedStateRef, valueRW2.currentNearPlayer);
			LocalTransform componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref base.CheckedStateRef, entity2);
			if ((num ? math.distancesq(InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref base.CheckedStateRef, valueRW2.currentNearPlayer).Position, componentAfterCompletingDependency.Position) : 100f) > 6.25f)
			{
				valueRW.LeaveState();
				continue;
			}
			if (!valueRW2.lookAtPlayerTimer.isRunning)
			{
				valueRW2.lookAtPlayerTimer.Start(elapsedTime, rng.NextFloat(0.3f));
			}
			if (valueRW2.lookAtPlayerTimer.IsTimerElapsed(elapsedTime))
			{
				float3 facingDirectionFromVector = math.normalizesafe(InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref base.CheckedStateRef, valueRW2.currentNearPlayer).Position - componentAfterCompletingDependency.Position);
				uncheckedRefRW4.ValueRW.SetFacingDirectionFromVector(facingDirectionFromVector);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<IdleWhenNearbyPlayerStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
		__query_1298652709_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1298652709_1 = entityQueryBuilder2.Build(ref state);
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
	public IdleWhenNearbyPlayerStateSystem()
	{
	}
}
