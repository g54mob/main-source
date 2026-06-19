using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;

namespace Interaction
{
	[UpdateInGroup(typeof(LocalPresentationCueSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct InteractableVisualUpdateSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_1994867561_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<LocalInteractorCD>> Get(int index)
				{
					return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<LocalInteractorCD>>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<LocalInteractorCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				private ComponentTypeHandle<LocalInteractorCD> item1_ComponentTypeHandle_RW;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<LocalInteractorCD>();
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RW.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<LocalInteractorCD>>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<LocalInteractorCD>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRW<LocalInteractorCD>();
			}
		}

		private struct TypeHandle
		{
			public IFE_1994867561_0.TypeHandle __IFE_1994867561_0_TypeHandle;

			[ReadOnly]
			public ComponentLookup<InteractableObjectReferenceCD> __InteractableObjectReferenceCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<InteractorCD> __Interaction_InteractorCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<GhostOwnerIsLocal> __Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_1994867561_0_TypeHandle = new IFE_1994867561_0.TypeHandle(ref state);
				__InteractableObjectReferenceCD_RO_ComponentLookup = state.GetComponentLookup<InteractableObjectReferenceCD>(isReadOnly: true);
				__Interaction_InteractorCD_RO_ComponentLookup = state.GetComponentLookup<InteractorCD>(isReadOnly: true);
				__Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup = state.GetComponentLookup<GhostOwnerIsLocal>(isReadOnly: true);
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1994867561_0;

		public void OnUpdate(ref SystemState state)
		{
			ComponentLookup<InteractableObjectReferenceCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__InteractableObjectReferenceCD_RO_ComponentLookup, ref state);
			ComponentLookup<InteractorCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Interaction_InteractorCD_RO_ComponentLookup, ref state);
			foreach (var (uncheckedRefRW2, entity2) in IFE_1994867561_0.Query(__query_1994867561_0, __TypeHandle.__IFE_1994867561_0_TypeHandle, ref state))
			{
				if (!InternalCompilerInterface.IsComponentEnabledAfterCompletingDependency(ref __TypeHandle.__Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup, ref state, entity2))
				{
					continue;
				}
				ref readonly InteractorCD valueRO = ref componentLookup2.GetRefRO(entity2).ValueRO;
				Entity lastClosestInteractable = uncheckedRefRW2.ValueRO.lastClosestInteractable;
				Entity currentClosestInteractable = valueRO.currentClosestInteractable;
				if (lastClosestInteractable == currentClosestInteractable)
				{
					continue;
				}
				bool playerIsAllowedToInteract = componentLookup2.IsComponentEnabled(entity2);
				if (componentLookup.TryGetComponent(lastClosestInteractable, out var componentData))
				{
					InteractableObject value = componentData.Value.Value;
					if (value != null)
					{
						value.UpdateVisuals(playerIsAllowedToInteract, isSelectedByPlayer: false);
					}
				}
				uncheckedRefRW2.ValueRW.lastClosestInteractable = currentClosestInteractable;
				if (componentLookup.TryGetComponent(currentClosestInteractable, out var componentData2))
				{
					InteractableObject value2 = componentData2.Value.Value;
					if (value2 != null)
					{
						value2.UpdateVisuals(playerIsAllowedToInteract, isSelectedByPlayer: true);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithPresent<InteractorCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalInteractorCD>();
			__query_1994867561_0 = entityQueryBuilder2.Build(ref state);
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
			((InteractableVisualUpdateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((InteractableVisualUpdateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
