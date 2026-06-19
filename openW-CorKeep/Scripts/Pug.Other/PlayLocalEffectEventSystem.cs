using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(PresentationSystemGroup))]
public struct PlayLocalEffectEventSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_170632147_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public BufferAccessor<GhostEffectEventBuffer> item2_BufferAccessor;

			public BufferAccessor<LocalEffectEventBuffer> item3_BufferAccessor;

			public IntPtr item4_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<GhostLocalSpawnTickCD, DynamicBuffer<GhostEffectEventBuffer>, DynamicBuffer<LocalEffectEventBuffer>, InternalCompilerInterface.UncheckedRefRW<LocalEffectEventBufferPointerCD>> Get(int index)
			{
				return new QueryEnumerableWithEntity<GhostLocalSpawnTickCD, DynamicBuffer<GhostEffectEventBuffer>, DynamicBuffer<LocalEffectEventBuffer>, InternalCompilerInterface.UncheckedRefRW<LocalEffectEventBufferPointerCD>>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<GhostLocalSpawnTickCD>(item1_IntPtr, index), item2_BufferAccessor[index], item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<LocalEffectEventBufferPointerCD>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<GhostLocalSpawnTickCD> item1_ComponentTypeHandle_RO;

			private BufferTypeHandle<GhostEffectEventBuffer> item2_BufferTypeHandle_RW;

			private BufferTypeHandle<LocalEffectEventBuffer> item3_BufferTypeHandle_RW;

			private ComponentTypeHandle<LocalEffectEventBufferPointerCD> item4_ComponentTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<GhostLocalSpawnTickCD>(isReadOnly: true);
				item2_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<GhostEffectEventBuffer>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<LocalEffectEventBuffer>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<LocalEffectEventBufferPointerCD>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_BufferTypeHandle_RW.Update(ref systemState);
				item3_BufferTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item2_BufferTypeHandle_RW),
					item3_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item3_BufferTypeHandle_RW),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<GhostLocalSpawnTickCD, DynamicBuffer<GhostEffectEventBuffer>, DynamicBuffer<LocalEffectEventBuffer>, InternalCompilerInterface.UncheckedRefRW<LocalEffectEventBufferPointerCD>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<GhostLocalSpawnTickCD, DynamicBuffer<GhostEffectEventBuffer>, DynamicBuffer<LocalEffectEventBuffer>, InternalCompilerInterface.UncheckedRefRW<LocalEffectEventBufferPointerCD>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<GhostLocalSpawnTickCD>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<LocalEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<LocalEffectEventBufferPointerCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_170632147_0.TypeHandle __IFE_170632147_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_170632147_0_TypeHandle = new IFE_170632147_0.TypeHandle(ref state);
		}
	}

	private const uint ACCEPTED_MISPREDICTION_TICK_DIFFERENCE = 2u;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_170632147_0;

	private EntityQuery __query_170632147_1;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ClientServerTickRate>();
	}

	public void OnUpdate(ref SystemState state)
	{
		int simulationTickRate = __query_170632147_1.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		foreach (QueryEnumerableWithEntity<GhostLocalSpawnTickCD, DynamicBuffer<GhostEffectEventBuffer>, DynamicBuffer<LocalEffectEventBuffer>, InternalCompilerInterface.UncheckedRefRW<LocalEffectEventBufferPointerCD>> item6 in IFE_170632147_0.Query(__query_170632147_0, __TypeHandle.__IFE_170632147_0_TypeHandle, ref state))
		{
			item6.Deconstruct(out var item, out var item2, out var item3, out var item4, out var entity);
			GhostLocalSpawnTickCD ghostLocalSpawnTickCD = item;
			DynamicBuffer<GhostEffectEventBuffer> dynamicBuffer = item2;
			DynamicBuffer<LocalEffectEventBuffer> dynamicBuffer2 = item3;
			InternalCompilerInterface.UncheckedRefRW<LocalEffectEventBufferPointerCD> uncheckedRefRW = item4;
			Entity callerEntity = entity;
			NetworkTick older = dynamicBuffer2.GetNewestElementTick();
			NetworkTick spawnTick = ghostLocalSpawnTickCD.spawnTick;
			if (!older.IsValid)
			{
				older = spawnTick;
				if (older.IsValid)
				{
					older.Subtract((uint)simulationTickRate);
				}
			}
			bool isValid = older.IsValid;
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				NetworkTick tick = dynamicBuffer[i].Tick;
				if (!tick.IsValid || (isValid && IsOldEffectOutsideMispredictionRange(tick.TicksSince(older))))
				{
					continue;
				}
				bool flag = false;
				for (int j = 0; j < dynamicBuffer2.Length; j++)
				{
					LocalEffectEventBuffer localEffectEventBuffer = dynamicBuffer2[j];
					NetworkTick tick2 = localEffectEventBuffer.Tick;
					if (tick2.IsValid)
					{
						int ticksSincePreviousEffect = tick.TicksSince(tick2);
						if (IsWithinMispredictionRange(ticksSincePreviousEffect) && dynamicBuffer[i].value.AreEqualInRegardsForMisprediction(localEffectEventBuffer.value))
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					DynamicBuffer<LocalEffectEventBuffer> buffer = dynamicBuffer2;
					ref LocalEffectEventBufferPointerCD valueRW = ref uncheckedRefRW.ValueRW;
					LocalEffectEventBuffer item5 = new LocalEffectEventBuffer
					{
						Tick = dynamicBuffer[i].Tick,
						value = dynamicBuffer[i].value
					};
					buffer.AddToRingBuffer(ref valueRW, in item5);
					EffectEventCD value = dynamicBuffer[i].value;
					float3 float5 = Manager.camera.RenderOrigo.ToFloat3();
					value.position1 -= float5;
					EffectEventExtensions.PlayEffect(value, callerEntity, state.World);
				}
			}
		}
		Manager.effects.PlayQueuedPuffs();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsOldEffectOutsideMispredictionRange(int ticksSincePreviousEffect)
	{
		return (long)ticksSincePreviousEffect < -2L;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool IsWithinMispredictionRange(int ticksSincePreviousEffect)
	{
		if ((long)ticksSincePreviousEffect >= -2L)
		{
			return (long)ticksSincePreviousEffect <= 2L;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostLocalSpawnTickCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalEffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalEffectEventBufferPointerCD>();
		__query_170632147_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		__query_170632147_0.SetChangedVersionFilter(new ComponentType[1]
		{
			new ComponentType(typeof(GhostEffectEventBuffer))
		});
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_170632147_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((PlayLocalEffectEventSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((PlayLocalEffectEventSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((PlayLocalEffectEventSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
