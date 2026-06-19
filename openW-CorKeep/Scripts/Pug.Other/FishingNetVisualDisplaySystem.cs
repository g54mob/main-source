using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.ECS.Hybrid;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

[UpdateInGroup(typeof(PresentationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct FishingNetVisualDisplaySystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_238598657_0
	{
		public struct ResolvedChunk
		{
			public BufferAccessor<ContainedObjectsBuffer> item1_BufferAccessor;

			public BufferAccessor<FishingNetSlotVisualBuffer> item2_BufferAccessor;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<DynamicBuffer<ContainedObjectsBuffer>, DynamicBuffer<FishingNetSlotVisualBuffer>> Get(int index)
			{
				return new QueryEnumerableWithEntity<DynamicBuffer<ContainedObjectsBuffer>, DynamicBuffer<FishingNetSlotVisualBuffer>>(item1_BufferAccessor[index], item2_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<ContainedObjectsBuffer> item1_BufferTypeHandle_RW;

			private BufferTypeHandle<FishingNetSlotVisualBuffer> item2_BufferTypeHandle_RW;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<ContainedObjectsBuffer>();
				item2_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<FishingNetSlotVisualBuffer>();
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW.Update(ref systemState);
				item2_BufferTypeHandle_RW.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item1_BufferTypeHandle_RW),
					item2_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item2_BufferTypeHandle_RW),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<DynamicBuffer<ContainedObjectsBuffer>, DynamicBuffer<FishingNetSlotVisualBuffer>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<DynamicBuffer<ContainedObjectsBuffer>, DynamicBuffer<FishingNetSlotVisualBuffer>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<ContainedObjectsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<FishingNetSlotVisualBuffer>();
		}
	}

	private struct TypeHandle
	{
		public IFE_238598657_0.TypeHandle __IFE_238598657_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_238598657_0_TypeHandle = new IFE_238598657_0.TypeHandle(ref state);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_238598657_0;

	public void OnUpdate(ref SystemState state)
	{
		foreach (var (dynamicBuffer3, dynamicBuffer4, entity2) in IFE_238598657_0.Query(__query_238598657_0, __TypeHandle.__IFE_238598657_0_TypeHandle, ref state))
		{
			if (!(Manager.memory.GetEntityMono(entity2) is IFishingNetVisual fishingNetVisual))
			{
				continue;
			}
			for (int i = 0; i < dynamicBuffer4.Length; i++)
			{
				if (dynamicBuffer4[i].hasBait)
				{
					fishingNetVisual.DisplayBait(i, dynamicBuffer3[i]);
				}
				else
				{
					fishingNetVisual.HideBait(i);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EntityMonoBehaviourCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedObjectsBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<FishingNetSlotVisualBuffer>();
		__query_238598657_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		__query_238598657_0.SetChangedVersionFilter(new ComponentType[2]
		{
			new ComponentType(typeof(EntityMonoBehaviourCD)),
			new ComponentType(typeof(ContainedObjectsBuffer))
		});
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((FishingNetVisualDisplaySystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((FishingNetVisualDisplaySystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
