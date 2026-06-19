using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using UnityEngine.Events;

namespace Interaction
{
	[UpdateInGroup(typeof(LocalPresentationCueSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct LocalInteractionSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_525796290_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public EnabledMask item2_EnabledMask;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public (InternalCompilerInterface.UncheckedRefRO<InteractableObjectReferenceCD>, EnabledRefRW<LocalExitInteractionTriggerCD>) Get(int index)
				{
					return (InternalCompilerInterface.UnsafeGetUncheckedRefRO<InteractableObjectReferenceCD>(item1_IntPtr, index), item2_EnabledMask.GetEnabledRefRW<LocalExitInteractionTriggerCD>(index));
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<InteractableObjectReferenceCD> item1_ComponentTypeHandle_RO;

				private ComponentTypeHandle<LocalExitInteractionTriggerCD> item2_ComponentTypeHandle_RW;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<InteractableObjectReferenceCD>(isReadOnly: true);
					item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<LocalExitInteractionTriggerCD>();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO.Update(ref systemState);
					item2_ComponentTypeHandle_RW.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
						item2_EnabledMask = archetypeChunk.GetEnabledMask(ref item2_ComponentTypeHandle_RW)
					};
				}
			}

			public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRO<InteractableObjectReferenceCD>, EnabledRefRW<LocalExitInteractionTriggerCD>)>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public (InternalCompilerInterface.UncheckedRefRO<InteractableObjectReferenceCD>, EnabledRefRW<LocalExitInteractionTriggerCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<InteractableObjectReferenceCD>();
				state.EntityManager.CompleteDependencyBeforeRW<LocalExitInteractionTriggerCD>();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_525796290_1
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public EnabledMask item2_EnabledMask;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public (InternalCompilerInterface.UncheckedRefRO<InteractableObjectReferenceCD>, EnabledRefRW<LocalUseInteractionTriggerCD>) Get(int index)
				{
					return (InternalCompilerInterface.UnsafeGetUncheckedRefRO<InteractableObjectReferenceCD>(item1_IntPtr, index), item2_EnabledMask.GetEnabledRefRW<LocalUseInteractionTriggerCD>(index));
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<InteractableObjectReferenceCD> item1_ComponentTypeHandle_RO;

				private ComponentTypeHandle<LocalUseInteractionTriggerCD> item2_ComponentTypeHandle_RW;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<InteractableObjectReferenceCD>(isReadOnly: true);
					item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<LocalUseInteractionTriggerCD>();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO.Update(ref systemState);
					item2_ComponentTypeHandle_RW.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
						item2_EnabledMask = archetypeChunk.GetEnabledMask(ref item2_ComponentTypeHandle_RW)
					};
				}
			}

			public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRO<InteractableObjectReferenceCD>, EnabledRefRW<LocalUseInteractionTriggerCD>)>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public (InternalCompilerInterface.UncheckedRefRO<InteractableObjectReferenceCD>, EnabledRefRW<LocalUseInteractionTriggerCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<InteractableObjectReferenceCD>();
				state.EntityManager.CompleteDependencyBeforeRW<LocalUseInteractionTriggerCD>();
			}
		}

		private struct TypeHandle
		{
			public IFE_525796290_0.TypeHandle __IFE_525796290_0_TypeHandle;

			public IFE_525796290_1.TypeHandle __IFE_525796290_1_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_525796290_0_TypeHandle = new IFE_525796290_0.TypeHandle(ref state);
				__IFE_525796290_1_TypeHandle = new IFE_525796290_1.TypeHandle(ref state);
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_525796290_0;

		private EntityQuery __query_525796290_1;

		public void OnUpdate(ref SystemState state)
		{
			foreach (var item5 in IFE_525796290_0.Query(__query_525796290_0, __TypeHandle.__IFE_525796290_0_TypeHandle, ref state))
			{
				InternalCompilerInterface.UncheckedRefRO<InteractableObjectReferenceCD> item = item5.Item1;
				EnabledRefRW<LocalExitInteractionTriggerCD> item2 = item5.Item2;
				item2.ValueRW = false;
				InteractableObject value = item.ValueRO.Value.Value;
				if (value == null)
				{
					continue;
				}
				foreach (UnityEvent onTriggerExitAction in value.onTriggerExitActions)
				{
					onTriggerExitAction.Invoke();
				}
			}
			foreach (var item6 in IFE_525796290_1.Query(__query_525796290_1, __TypeHandle.__IFE_525796290_1_TypeHandle, ref state))
			{
				InternalCompilerInterface.UncheckedRefRO<InteractableObjectReferenceCD> item3 = item6.Item1;
				EnabledRefRW<LocalUseInteractionTriggerCD> item4 = item6.Item2;
				item4.ValueRW = false;
				InteractableObject value2 = item3.ValueRO.Value.Value;
				if (value2 == null)
				{
					continue;
				}
				foreach (UnityEvent onUseAction in value2.onUseActions)
				{
					onUseAction.Invoke();
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<InteractableObjectReferenceCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalExitInteractionTriggerCD>();
			__query_525796290_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			__query_525796290_0.SetChangedVersionFilter(new ComponentType[1]
			{
				new ComponentType(typeof(LocalExitInteractionTriggerCD))
			});
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InteractableObjectReferenceCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalUseInteractionTriggerCD>();
			__query_525796290_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			__query_525796290_1.SetChangedVersionFilter(new ComponentType[1]
			{
				new ComponentType(typeof(LocalUseInteractionTriggerCD))
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
			((LocalInteractionSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((LocalInteractionSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
