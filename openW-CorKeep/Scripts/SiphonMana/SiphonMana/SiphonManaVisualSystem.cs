using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SiphonMana.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

namespace SiphonMana
{
	[UpdateInGroup(typeof(PresentationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct SiphonManaVisualSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_1260842296_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public BufferAccessor<SiphonManaTargetBufferElement> item2_BufferAccessor;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<OwnerReferenceCD>, DynamicBuffer<SiphonManaTargetBufferElement>> Get(int index)
				{
					return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<OwnerReferenceCD>, DynamicBuffer<SiphonManaTargetBufferElement>>(InternalCompilerInterface.UnsafeGetUncheckedRefRO<OwnerReferenceCD>(item1_IntPtr, index), item2_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<OwnerReferenceCD> item1_ComponentTypeHandle_RO;

				private BufferTypeHandle<SiphonManaTargetBufferElement> item2_BufferTypeHandle_RW;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<OwnerReferenceCD>(isReadOnly: true);
					item2_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<SiphonManaTargetBufferElement>();
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO.Update(ref systemState);
					item2_BufferTypeHandle_RW.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
						item2_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item2_BufferTypeHandle_RW),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<OwnerReferenceCD>, DynamicBuffer<SiphonManaTargetBufferElement>>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<OwnerReferenceCD>, DynamicBuffer<SiphonManaTargetBufferElement>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<OwnerReferenceCD>();
				state.EntityManager.CompleteDependencyBeforeRW<SiphonManaTargetBufferElement>();
			}
		}

		private struct TypeHandle
		{
			public IFE_1260842296_0.TypeHandle __IFE_1260842296_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_1260842296_0_TypeHandle = new IFE_1260842296_0.TypeHandle(ref state);
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1260842296_0;

		public void OnUpdate(ref SystemState state)
		{
			foreach (var (uncheckedRefRO2, dynamicBuffer2, entity2) in IFE_1260842296_0.Query(__query_1260842296_0, __TypeHandle.__IFE_1260842296_0_TypeHandle, ref state))
			{
				if (!(Manager.memory.GetEntityMono(entity2) is ISiphonManaPresenter siphonManaPresenter))
				{
					continue;
				}
				bool flag = false;
				for (int i = 0; i < dynamicBuffer2.Length; i++)
				{
					EntityMonoBehaviour entityMonoBehaviour = ((dynamicBuffer2[i].siphonManaTarget != Entity.Null) ? Manager.memory.GetEntityMono(dynamicBuffer2[i].siphonManaTarget) : null);
					if (entityMonoBehaviour != null)
					{
						flag = true;
						siphonManaPresenter.ShowSiphonTargetBeam(i, EntityMonoBehaviour.ToWorldFromRender(entityMonoBehaviour.center));
					}
					else
					{
						siphonManaPresenter.HideSiphonTargetBeam(i);
					}
				}
				EntityMonoBehaviour entityMonoBehaviour2 = ((uncheckedRefRO2.ValueRO.owner != Entity.Null) ? Manager.memory.GetEntityMono(uncheckedRefRO2.ValueRO.owner) : null);
				if (flag && entityMonoBehaviour2 != null)
				{
					siphonManaPresenter.ShowSiphonToOwnerBeam(EntityMonoBehaviour.ToWorldFromRender(entityMonoBehaviour2.center));
				}
				else
				{
					siphonManaPresenter.HideSiphonToOwnerBeam();
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<OwnerReferenceCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SiphonManaTargetBufferElement>();
			__query_1260842296_0 = entityQueryBuilder2.Build(ref state);
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
			((SiphonManaVisualSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((SiphonManaVisualSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
