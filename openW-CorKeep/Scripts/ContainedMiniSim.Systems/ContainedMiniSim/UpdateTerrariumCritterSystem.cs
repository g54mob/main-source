using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ContainedMiniSim.Components;
using Pug.ECS.Hybrid;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

namespace ContainedMiniSim
{
	[RequireMatchingQueriesForUpdate]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(LocalPresentationCueSystemGroup))]
	public struct UpdateTerrariumCritterSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_439903556_0
		{
			public struct ResolvedChunk
			{
				public BufferAccessor<ContainedObjectsBuffer> item1_BufferAccessor;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<DynamicBuffer<ContainedObjectsBuffer>> Get(int index)
				{
					return new QueryEnumerableWithEntity<DynamicBuffer<ContainedObjectsBuffer>>(item1_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				private BufferTypeHandle<ContainedObjectsBuffer> item1_BufferTypeHandle_RW;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<ContainedObjectsBuffer>();
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_BufferTypeHandle_RW.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item1_BufferTypeHandle_RW),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<DynamicBuffer<ContainedObjectsBuffer>>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<DynamicBuffer<ContainedObjectsBuffer>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_439903556_1
		{
			public struct ResolvedChunk
			{
				public BufferAccessor<ContainedMiniSimElementVisualBuffer> item1_BufferAccessor;

				public BufferAccessor<ContainedMiniSimElementLastVisualBuffer> item2_BufferAccessor;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<DynamicBuffer<ContainedMiniSimElementVisualBuffer>, DynamicBuffer<ContainedMiniSimElementLastVisualBuffer>> Get(int index)
				{
					return new QueryEnumerableWithEntity<DynamicBuffer<ContainedMiniSimElementVisualBuffer>, DynamicBuffer<ContainedMiniSimElementLastVisualBuffer>>(item1_BufferAccessor[index], item2_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				private BufferTypeHandle<ContainedMiniSimElementVisualBuffer> item1_BufferTypeHandle_RW;

				private BufferTypeHandle<ContainedMiniSimElementLastVisualBuffer> item2_BufferTypeHandle_RW;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<ContainedMiniSimElementVisualBuffer>();
					item2_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<ContainedMiniSimElementLastVisualBuffer>();
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

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<DynamicBuffer<ContainedMiniSimElementVisualBuffer>, DynamicBuffer<ContainedMiniSimElementLastVisualBuffer>>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<DynamicBuffer<ContainedMiniSimElementVisualBuffer>, DynamicBuffer<ContainedMiniSimElementLastVisualBuffer>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRW<ContainedMiniSimElementVisualBuffer>();
				state.EntityManager.CompleteDependencyBeforeRW<ContainedMiniSimElementLastVisualBuffer>();
			}
		}

		private struct TypeHandle
		{
			public IFE_439903556_0.TypeHandle __IFE_439903556_0_TypeHandle;

			public IFE_439903556_1.TypeHandle __IFE_439903556_1_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_439903556_0_TypeHandle = new IFE_439903556_0.TypeHandle(ref state);
				__IFE_439903556_1_TypeHandle = new IFE_439903556_1.TypeHandle(ref state);
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_439903556_0;

		private EntityQuery __query_439903556_1;

		public void OnUpdate(ref SystemState state)
		{
			Entity entity;
			foreach (QueryEnumerableWithEntity<DynamicBuffer<ContainedObjectsBuffer>> item4 in IFE_439903556_0.Query(__query_439903556_0, __TypeHandle.__IFE_439903556_0_TypeHandle, ref state))
			{
				item4.Deconstruct(out var item, out entity);
				DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = item;
				Entity entity2 = entity;
				if (Manager.memory.GetEntityMono(entity2) is IMiniSimCritterPresenter miniSimCritterPresenter)
				{
					miniSimCritterPresenter.UpdateDisplayedObjects(containedObjectsBuffer);
				}
			}
			foreach (QueryEnumerableWithEntity<DynamicBuffer<ContainedMiniSimElementVisualBuffer>, DynamicBuffer<ContainedMiniSimElementLastVisualBuffer>> item5 in IFE_439903556_1.Query(__query_439903556_1, __TypeHandle.__IFE_439903556_1_TypeHandle, ref state))
			{
				item5.Deconstruct(out var item2, out var item3, out entity);
				DynamicBuffer<ContainedMiniSimElementVisualBuffer> dynamicBuffer = item2;
				DynamicBuffer<ContainedMiniSimElementLastVisualBuffer> dynamicBuffer2 = item3;
				Entity entity3 = entity;
				if (!(Manager.memory.GetEntityMono(entity3) is IMiniSimCritterPresenter miniSimCritterPresenter2))
				{
					continue;
				}
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					ContainedMiniSimElementVisualBuffer containedMiniSimElementVisualBuffer = dynamicBuffer[i];
					miniSimCritterPresenter2.UpdateSimulationPosition(i, containedMiniSimElementVisualBuffer.elementVisual.position);
					ref ContainedMiniSimElementLastVisualBuffer reference = ref dynamicBuffer2.ElementAt(i);
					if (containedMiniSimElementVisualBuffer.elementVisual.animationCounter > reference.lastAnimationCounter)
					{
						reference.lastAnimationCounter = containedMiniSimElementVisualBuffer.elementVisual.animationCounter;
						miniSimCritterPresenter2.PlayAnimationForVisual(i, containedMiniSimElementVisualBuffer.elementVisual.animation, containedMiniSimElementVisualBuffer.elementVisual.orientationHash, containedMiniSimElementVisualBuffer.elementVisual.flipX);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<TerrariumTagCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityMonoBehaviourCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedObjectsBuffer>();
			__query_439903556_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			__query_439903556_0.SetChangedVersionFilter(new ComponentType[2]
			{
				new ComponentType(typeof(EntityMonoBehaviourCD)),
				new ComponentType(typeof(ContainedObjectsBuffer))
			});
			entityQueryBuilder2 = entityQueryBuilder.WithAll<TerrariumTagCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedMiniSimElementVisualBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedMiniSimElementLastVisualBuffer>();
			__query_439903556_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
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
			((UpdateTerrariumCritterSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((UpdateTerrariumCritterSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
