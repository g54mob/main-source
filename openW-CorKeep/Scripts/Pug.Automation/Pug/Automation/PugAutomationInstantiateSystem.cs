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
using Unity.Transforms;
using UnityEngine;

namespace Pug.Automation
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	[BurstCompile]
	public struct PugAutomationInstantiateSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_602361812_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public IntPtr item2_IntPtr;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationMinerConfigCD>, ObjectDataCD> Get(int index)
				{
					return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationMinerConfigCD>, ObjectDataCD>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<PugAutomationMinerConfigCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ObjectDataCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				private ComponentTypeHandle<PugAutomationMinerConfigCD> item1_ComponentTypeHandle_RW;

				[ReadOnly]
				private ComponentTypeHandle<ObjectDataCD> item2_ComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<PugAutomationMinerConfigCD>();
					item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RW.Update(ref systemState);
					item2_ComponentTypeHandle_RO.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
						item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationMinerConfigCD>, ObjectDataCD>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationMinerConfigCD>, ObjectDataCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRW<PugAutomationMinerConfigCD>();
				state.EntityManager.CompleteDependencyBeforeRO<ObjectDataCD>();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_602361812_1
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public IntPtr item2_IntPtr;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<PugAutomationCD, ElectricityCD> Get(int index)
				{
					return new QueryEnumerableWithEntity<PugAutomationCD, ElectricityCD>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<PugAutomationCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ElectricityCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<PugAutomationCD> item1_ComponentTypeHandle_RO;

				[ReadOnly]
				private ComponentTypeHandle<ElectricityCD> item2_ComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PugAutomationCD>(isReadOnly: true);
					item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ElectricityCD>(isReadOnly: true);
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO.Update(ref systemState);
					item2_ComponentTypeHandle_RO.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
						item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<PugAutomationCD, ElectricityCD>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<PugAutomationCD, ElectricityCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<PugAutomationCD>();
				state.EntityManager.CompleteDependencyBeforeRO<ElectricityCD>();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_602361812_2
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<PugAutomationCD> Get(int index)
				{
					return new QueryEnumerableWithEntity<PugAutomationCD>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<PugAutomationCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<PugAutomationCD> item1_ComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PugAutomationCD>(isReadOnly: true);
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<PugAutomationCD>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<PugAutomationCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<PugAutomationCD>();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_602361812_3
		{
			public struct ResolvedChunk
			{
				public BufferAccessor<SmallEntityRefBuffer> item1_BufferAccessor;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<DynamicBuffer<SmallEntityRefBuffer>> Get(int index)
				{
					return new QueryEnumerableWithEntity<DynamicBuffer<SmallEntityRefBuffer>>(item1_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				private BufferTypeHandle<SmallEntityRefBuffer> item1_BufferTypeHandle_RW;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<SmallEntityRefBuffer>();
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

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<DynamicBuffer<SmallEntityRefBuffer>>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<DynamicBuffer<SmallEntityRefBuffer>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRW<SmallEntityRefBuffer>();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_602361812_4
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				public IntPtr item2_IntPtr;

				public IntPtr item3_IntPtr;

				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationCD>, LocalTransform, ObjectDataCD> Get(int index)
				{
					return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationCD>, LocalTransform, ObjectDataCD>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<PugAutomationCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<LocalTransform>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ObjectDataCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
				}
			}

			public struct TypeHandle
			{
				private ComponentTypeHandle<PugAutomationCD> item1_ComponentTypeHandle_RW;

				[ReadOnly]
				private ComponentTypeHandle<LocalTransform> item2_ComponentTypeHandle_RO;

				[ReadOnly]
				private ComponentTypeHandle<ObjectDataCD> item3_ComponentTypeHandle_RO;

				private EntityTypeHandle Entity_TypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<PugAutomationCD>();
					item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					Entity_TypeHandle = systemState.GetEntityTypeHandle();
				}

				public void Update(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RW.Update(ref systemState);
					item2_ComponentTypeHandle_RO.Update(ref systemState);
					item3_ComponentTypeHandle_RO.Update(ref systemState);
					Entity_TypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
						item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
						item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RO),
						Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
					};
				}
			}

			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationCD>, LocalTransform, ObjectDataCD>>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationCD>, LocalTransform, ObjectDataCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRW<PugAutomationCD>();
				state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
				state.EntityManager.CompleteDependencyBeforeRO<ObjectDataCD>();
			}
		}

		private struct TypeHandle
		{
			public IFE_602361812_0.TypeHandle __IFE_602361812_0_TypeHandle;

			public IFE_602361812_1.TypeHandle __IFE_602361812_1_TypeHandle;

			public IFE_602361812_2.TypeHandle __IFE_602361812_2_TypeHandle;

			public IFE_602361812_3.TypeHandle __IFE_602361812_3_TypeHandle;

			public IFE_602361812_4.TypeHandle __IFE_602361812_4_TypeHandle;

			[ReadOnly]
			public BufferLookup<SmallEntityCrafterRefBuffer> __Pug_Automation_SmallEntityCrafterRefBuffer_RO_BufferLookup;

			public BufferLookup<SmallEntityRefBuffer> __Pug_Automation_SmallEntityRefBuffer_RW_BufferLookup;

			public ComponentLookup<PugAutomationEnabledMoverSyncedCD> __Pug_Automation_PugAutomationEnabledMoverSyncedCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MoveeBigEntityCD> __Pug_Automation_MoveeBigEntityCD_RO_ComponentLookup;

			public ComponentLookup<PugAutomationMoversSharedConfigCD> __Pug_Automation_PugAutomationMoversSharedConfigCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DirectionBasedOnVariationCD> __DirectionBasedOnVariationCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CategoryFilteringCD> __CategoryFilteringCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PugAutomationMinerConfigCD> __Pug_Automation_PugAutomationMinerConfigCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CraftingCD> __CraftingCD_RO_ComponentLookup;

			public BufferLookup<CraftingTimerSlotBuffer> __CraftingTimerSlotBuffer_RW_BufferLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_602361812_0_TypeHandle = new IFE_602361812_0.TypeHandle(ref state);
				__IFE_602361812_1_TypeHandle = new IFE_602361812_1.TypeHandle(ref state);
				__IFE_602361812_2_TypeHandle = new IFE_602361812_2.TypeHandle(ref state);
				__IFE_602361812_3_TypeHandle = new IFE_602361812_3.TypeHandle(ref state);
				__IFE_602361812_4_TypeHandle = new IFE_602361812_4.TypeHandle(ref state);
				__Pug_Automation_SmallEntityCrafterRefBuffer_RO_BufferLookup = state.GetBufferLookup<SmallEntityCrafterRefBuffer>(isReadOnly: true);
				__Pug_Automation_SmallEntityRefBuffer_RW_BufferLookup = state.GetBufferLookup<SmallEntityRefBuffer>();
				__Pug_Automation_PugAutomationEnabledMoverSyncedCD_RW_ComponentLookup = state.GetComponentLookup<PugAutomationEnabledMoverSyncedCD>();
				__Pug_Automation_ElectricityCD_RO_ComponentLookup = state.GetComponentLookup<ElectricityCD>(isReadOnly: true);
				__Pug_Automation_MoveeBigEntityCD_RO_ComponentLookup = state.GetComponentLookup<MoveeBigEntityCD>(isReadOnly: true);
				__Pug_Automation_PugAutomationMoversSharedConfigCD_RW_ComponentLookup = state.GetComponentLookup<PugAutomationMoversSharedConfigCD>();
				__DirectionBasedOnVariationCD_RO_ComponentLookup = state.GetComponentLookup<DirectionBasedOnVariationCD>(isReadOnly: true);
				__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
				__CategoryFilteringCD_RO_ComponentLookup = state.GetComponentLookup<CategoryFilteringCD>(isReadOnly: true);
				__Pug_Automation_PugAutomationMinerConfigCD_RO_ComponentLookup = state.GetComponentLookup<PugAutomationMinerConfigCD>(isReadOnly: true);
				__CraftingCD_RO_ComponentLookup = state.GetComponentLookup<CraftingCD>(isReadOnly: true);
				__CraftingTimerSlotBuffer_RW_BufferLookup = state.GetBufferLookup<CraftingTimerSlotBuffer>();
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_0000013C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_0000013C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000013C_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_0000013D_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000013D_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000013D_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
		internal delegate void __codegen__OnDestroy_0000013E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnDestroy_0000013E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_0000013E_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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

		private EntityArchetype defaultMoverArchetype;

		private EntityArchetype harvestAndMoverArchetype;

		private EntityArchetype moveAndPlanterArchetype;

		private EntityArchetype moverOrchestratorArchetype;

		private EntityArchetype moveeArchetype;

		private EntityArchetype storageArchetype;

		private EntityArchetype mineableArchetype;

		private EntityArchetype minerArchetype;

		private EntityArchetype crafterArchetype;

		private EntityArchetype fisherArchetype;

		private EntityArchetype critterCatchingArchetype;

		private EntityArchetype extractorArchetype;

		private EntityArchetype incineratorArchetype;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_602361812_0;

		private EntityQuery __query_602361812_1;

		private EntityQuery __query_602361812_2;

		private EntityQuery __query_602361812_3;

		private EntityQuery __query_602361812_4;

		private EntityQuery __query_602361812_5;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			FixedList128Bytes<ComponentType> fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<MoverCD>(),
				ComponentType.ReadWrite<MoverTimerCD>(),
				ComponentType.ReadWrite<MoverFilterCD>(),
				ComponentType.ReadWrite<EnabledMoverFromSharedStateCD>(),
				ComponentType.ReadWrite<PickupInStartOfMoveCD>(),
				ComponentType.ReadWrite<DropInEndOfMoveCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>()
			};
			NativeArray<ComponentType> types = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<MoverCD>(),
				ComponentType.ReadWrite<MoverTimerCD>(),
				ComponentType.ReadWrite<MoverFilterCD>(),
				ComponentType.ReadWrite<EnabledMoverFromSharedStateCD>(),
				ComponentType.ReadWrite<HarvestInStartOfMoveCD>(),
				ComponentType.ReadWrite<DropInEndOfMoveCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>()
			};
			NativeArray<ComponentType> types2 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<MoverCD>(),
				ComponentType.ReadWrite<MoverTimerCD>(),
				ComponentType.ReadWrite<MoverFilterCD>(),
				ComponentType.ReadWrite<EnabledMoverFromSharedStateCD>(),
				ComponentType.ReadWrite<PickupInStartOfMoveCD>(),
				ComponentType.ReadWrite<PlantInEndOfMoveCD>(),
				ComponentType.ReadWrite<PlantTriggerCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>()
			};
			NativeArray<ComponentType> types3 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<MoverOrchestratorCD>(),
				ComponentType.ReadWrite<MoversWithSharedStateBuffer>(),
				ComponentType.ReadWrite<CycleEnabledMoversTriggerCD>(),
				ComponentType.ReadWrite<EnableSharedMoversTriggerCD>(),
				ComponentType.ReadWrite<DeactivateSharedMoversTriggerCD>(),
				ComponentType.ReadWrite<DeactivateSharedMoversTriggerEntityCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>()
			};
			NativeArray<ComponentType> types4 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<MoveeCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>(),
				ComponentType.ReadWrite<BigEntityIsEnabledCD>()
			};
			NativeArray<ComponentType> types5 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<StorageCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>()
			};
			NativeArray<ComponentType> types6 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<MineableCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>()
			};
			NativeArray<ComponentType> types7 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<MinerCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>()
			};
			NativeArray<ComponentType> types8 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<SmallCrafterCD>(),
				ComponentType.ReadWrite<CrafterForSlotCD>(),
				ComponentType.ReadWrite<PugTimerRefCD>(),
				ComponentType.ReadWrite<PugTimerUserCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>(),
				ComponentType.ReadWrite<BigEntityCraftingDataChangedTriggerCD>()
			};
			NativeArray<ComponentType> types9 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<FisherCD>(),
				ComponentType.ReadWrite<CrafterForSlotCD>(),
				ComponentType.ReadWrite<PugTimerRefCD>(),
				ComponentType.ReadWrite<PugTimerUserCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>(),
				ComponentType.ReadWrite<BigEntityCraftingDataChangedTriggerCD>()
			};
			NativeArray<ComponentType> types10 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<CritterCatcherCD>(),
				ComponentType.ReadWrite<CrafterForSlotCD>(),
				ComponentType.ReadWrite<PugTimerRefCD>(),
				ComponentType.ReadWrite<PugTimerUserCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>(),
				ComponentType.ReadWrite<BigEntityCraftingDataChangedTriggerCD>()
			};
			NativeArray<ComponentType> types11 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<SmallExtractorCD>(),
				ComponentType.ReadWrite<CrafterForSlotCD>(),
				ComponentType.ReadWrite<PugTimerRefCD>(),
				ComponentType.ReadWrite<PugTimerUserCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>(),
				ComponentType.ReadWrite<BigEntityCraftingDataChangedTriggerCD>()
			};
			NativeArray<ComponentType> types12 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			fixedList128Bytes = new FixedList128Bytes<ComponentType>
			{
				ComponentType.ReadWrite<SmallIncineratorCD>(),
				ComponentType.ReadWrite<CrafterForSlotCD>(),
				ComponentType.ReadWrite<PugTimerRefCD>(),
				ComponentType.ReadWrite<PugTimerUserCD>(),
				ComponentType.ReadWrite<BigEntityRefCD>(),
				ComponentType.ReadWrite<BigEntityCraftingDataChangedTriggerCD>()
			};
			NativeArray<ComponentType> types13 = fixedList128Bytes.ToNativeArray(state.WorldUpdateAllocator);
			defaultMoverArchetype = state.EntityManager.CreateArchetype(types);
			harvestAndMoverArchetype = state.EntityManager.CreateArchetype(types2);
			moveAndPlanterArchetype = state.EntityManager.CreateArchetype(types3);
			moverOrchestratorArchetype = state.EntityManager.CreateArchetype(types4);
			moveeArchetype = state.EntityManager.CreateArchetype(types5);
			storageArchetype = state.EntityManager.CreateArchetype(types6);
			mineableArchetype = state.EntityManager.CreateArchetype(types7);
			minerArchetype = state.EntityManager.CreateArchetype(types8);
			crafterArchetype = state.EntityManager.CreateArchetype(types9);
			fisherArchetype = state.EntityManager.CreateArchetype(types10);
			critterCatchingArchetype = state.EntityManager.CreateArchetype(types11);
			extractorArchetype = state.EntityManager.CreateArchetype(types12);
			incineratorArchetype = state.EntityManager.CreateArchetype(types13);
			state.RequireForUpdate<InitialLoadingDoneCD>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		}

		[BurstCompile]
		public void OnDestroy(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = __query_602361812_5.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
			NativeList<Entity> nativeList = new NativeList<Entity>(Allocator.Temp);
			ObjectDataCD item2;
			Entity entity;
			foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationMinerConfigCD>, ObjectDataCD> item8 in IFE_602361812_0.Query(__query_602361812_0, __TypeHandle.__IFE_602361812_0_TypeHandle, ref state))
			{
				item8.Deconstruct(out var item, out item2, out entity);
				InternalCompilerInterface.UncheckedRefRW<PugAutomationMinerConfigCD> uncheckedRefRW = item;
				ObjectDataCD objectDataCD = item2;
				Entity value = entity;
				int2 directionFromVariation = DirectionBasedOnVariationCD.GetDirectionFromVariation(objectDataCD.variation);
				if (!math.all(directionFromVariation == uncheckedRefRW.ValueRO.offset))
				{
					nativeList.Add(in value);
					uncheckedRefRW.ValueRW.offset = directionFromVariation;
				}
			}
			PugAutomationCD item3;
			foreach (QueryEnumerableWithEntity<PugAutomationCD, ElectricityCD> item9 in IFE_602361812_1.Query(__query_602361812_1, __TypeHandle.__IFE_602361812_1_TypeHandle, ref state))
			{
				item9.Deconstruct(out item3, out var item4, out entity);
				PugAutomationCD pugAutomationCD = item3;
				ElectricityCD electricityCD = item4;
				Entity value2 = entity;
				if (electricityCD.hasEnoughElectricityToPowerStuff ^ pugAutomationCD.isActive)
				{
					nativeList.Add(in value2);
				}
			}
			foreach (QueryEnumerableWithEntity<PugAutomationCD> item10 in IFE_602361812_2.Query(__query_602361812_2, __TypeHandle.__IFE_602361812_2_TypeHandle, ref state))
			{
				item10.Deconstruct(out item3, out entity);
				Entity value3 = entity;
				nativeList.Add(in value3);
			}
			EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
			foreach (QueryEnumerableWithEntity<DynamicBuffer<SmallEntityRefBuffer>> item11 in IFE_602361812_3.Query(__query_602361812_3, __TypeHandle.__IFE_602361812_3_TypeHandle, ref state))
			{
				item11.Deconstruct(out var item5, out entity);
				DynamicBuffer<SmallEntityRefBuffer> dynamicBuffer = item5;
				Entity entity2 = entity;
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					entityCommandBuffer.DestroyEntity(dynamicBuffer[i].Value);
				}
				entityCommandBuffer.RemoveComponent<SmallEntityRefBuffer>(entity2);
				if (InternalCompilerInterface.HasBufferAfterCompletingDependency(ref __TypeHandle.__Pug_Automation_SmallEntityCrafterRefBuffer_RO_BufferLookup, ref state, entity2))
				{
					entityCommandBuffer.RemoveComponent<SmallEntityCrafterRefBuffer>(entity2);
				}
			}
			for (int j = 0; j < nativeList.Length; j++)
			{
				DynamicBuffer<SmallEntityRefBuffer> bufferAfterCompletingDependency = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__Pug_Automation_SmallEntityRefBuffer_RW_BufferLookup, ref state, nativeList[j]);
				for (int k = 0; k < bufferAfterCompletingDependency.Length; k++)
				{
					entityCommandBuffer.DestroyEntity(bufferAfterCompletingDependency[k].Value);
				}
				bufferAfterCompletingDependency.Clear();
			}
			state.EntityManager.RemoveComponent<SmallEntityRefBuffer>(nativeList);
			state.EntityManager.RemoveComponent<SmallEntityCrafterRefBuffer>(nativeList);
			nativeList.Dispose();
			entityCommandBuffer.Playback(state.EntityManager);
			entityCommandBuffer.Dispose();
			entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
			ComponentLookup<PugAutomationEnabledMoverSyncedCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PugAutomationEnabledMoverSyncedCD_RW_ComponentLookup, ref state);
			foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<PugAutomationCD>, LocalTransform, ObjectDataCD> item12 in IFE_602361812_4.Query(__query_602361812_4, __TypeHandle.__IFE_602361812_4_TypeHandle, ref state))
			{
				item12.Deconstruct(out var item6, out var item7, out item2, out entity);
				InternalCompilerInterface.UncheckedRefRW<PugAutomationCD> uncheckedRefRW2 = item6;
				LocalTransform localTransform = item7;
				ObjectDataCD objectDataCD2 = item2;
				Entity entity3 = entity;
				DynamicBuffer<SmallEntityRefBuffer> smallEntityBuffer = entityCommandBuffer.AddBuffer<SmallEntityRefBuffer>(entity3);
				int2 int5 = localTransform.Position.RoundToInt2();
				uncheckedRefRW2.ValueRW.isActive = !InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentLookup, ref state, entity3) || InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentLookup, ref state, entity3).hasEnoughElectricityToPowerStuff;
				if ((uncheckedRefRW2.ValueRO.type & AutomationType.Movee) != AutomationType.None)
				{
					MoveeBigEntityCD componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Pug_Automation_MoveeBigEntityCD_RO_ComponentLookup, ref state, entity3);
					float2 float5 = componentAfterCompletingDependency.target;
					if (float.IsNaN(float5.x) || float.IsNaN(float5.y) || (componentAfterCompletingDependency.moveTimer != -1 && math.distance(float5, localTransform.Position.ToFloat2()) > 50f))
					{
						float5 = localTransform.Position.ToFloat2();
						Debug.LogError("Movee target position is invalid for entity resetting to current position.");
					}
					MoveeCD component = new MoveeCD
					{
						position = localTransform.Position.ToFloat2(),
						target = float5,
						moveTimer = componentAfterCompletingDependency.moveTimer
					};
					Entity entity4 = entityCommandBuffer.CreateEntity(moveeArchetype);
					entityCommandBuffer.SetComponent(entity4, component);
					entityCommandBuffer.SetComponent(entity4, new BigEntityRefCD
					{
						Value = entity3
					});
					smallEntityBuffer.Add(new SmallEntityRefBuffer
					{
						Value = entity4
					});
				}
				if ((uncheckedRefRW2.ValueRO.type & AutomationType.Mover) != AutomationType.None && uncheckedRefRW2.ValueRO.isActive)
				{
					RefRW<PugAutomationMoversSharedConfigCD> componentRWAfterCompletingDependency = InternalCompilerInterface.GetComponentRWAfterCompletingDependency(ref __TypeHandle.__Pug_Automation_PugAutomationMoversSharedConfigCD_RW_ComponentLookup, ref state, entity3);
					int2 dir = new int2(0, -1);
					if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__DirectionBasedOnVariationCD_RO_ComponentLookup, ref state, entity3))
					{
						dir = DirectionBasedOnVariationCD.GetDirectionFromVariation(objectDataCD2.variation);
					}
					else if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state, entity3))
					{
						dir = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state, entity3).direction.RoundToInt2();
					}
					CategoryFilteringCD categoryFilteringCD = default(CategoryFilteringCD);
					if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__CategoryFilteringCD_RO_ComponentLookup, ref state, entity3))
					{
						categoryFilteringCD = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__CategoryFilteringCD_RO_ComponentLookup, ref state, entity3);
					}
					PugAutomationMoversSharedConfigCD valueRO = componentRWAfterCompletingDependency.ValueRO;
					int num = -1;
					RefRW<PugAutomationEnabledMoverSyncedCD> refRWOptional = componentLookup.GetRefRWOptional(entity3);
					int nextCycleIncrement = 0;
					if (refRWOptional.IsValid)
					{
						nextCycleIncrement = refRWOptional.ValueRO.nextMoverCycleIncrement;
						num = refRWOptional.ValueRO.moverIndex;
						int num2 = 0;
						if (valueRO.DefaultMovers.IsCreated)
						{
							num2 += valueRO.DefaultMovers.Value.Length;
						}
						if (valueRO.HarvestAndMovers.IsCreated)
						{
							num2 += valueRO.HarvestAndMovers.Value.Length;
						}
						if (valueRO.MoveAndPlanters.IsCreated)
						{
							num2 += valueRO.MoveAndPlanters.Value.Length;
						}
						if (num < 0 || num >= num2)
						{
							num = -1;
						}
					}
					Entity allowOnlyOneMoverOptionalOrchestratorEntity = Entity.Null;
					DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer = default(DynamicBuffer<MoversWithSharedStateBuffer>);
					if (valueRO.SharedConfig.Value.allowOnlyOneActiveMoverAtATime)
					{
						allowOnlyOneMoverOptionalOrchestratorEntity = SetupNewOrchestrator(moverOrchestratorArchetype, entity3, entityCommandBuffer, smallEntityBuffer, out moversWithSharedStateBuffer, num, nextCycleIncrement);
					}
					int totalMoverIndex = 0;
					if (valueRO.DefaultMovers.IsCreated)
					{
						SetupMovers(defaultMoverArchetype, ref valueRO.DefaultMovers.Value, ref valueRO.SharedConfig.Value, entity3, int5, dir, allowOnlyOneMoverOptionalOrchestratorEntity, moversWithSharedStateBuffer, entityCommandBuffer, smallEntityBuffer, in categoryFilteringCD, ref totalMoverIndex, num, refRWOptional);
					}
					if (valueRO.HarvestAndMovers.IsCreated)
					{
						SetupMovers(harvestAndMoverArchetype, ref valueRO.HarvestAndMovers.Value, ref valueRO.SharedConfig.Value, entity3, int5, dir, allowOnlyOneMoverOptionalOrchestratorEntity, moversWithSharedStateBuffer, entityCommandBuffer, smallEntityBuffer, in categoryFilteringCD, ref totalMoverIndex, num, refRWOptional);
					}
					if (valueRO.MoveAndPlanters.IsCreated)
					{
						SetupMovers(moveAndPlanterArchetype, ref valueRO.MoveAndPlanters.Value, ref valueRO.SharedConfig.Value, entity3, int5, dir, allowOnlyOneMoverOptionalOrchestratorEntity, moversWithSharedStateBuffer, entityCommandBuffer, smallEntityBuffer, in categoryFilteringCD, ref totalMoverIndex, num, refRWOptional);
					}
				}
				if ((uncheckedRefRW2.ValueRO.type & AutomationType.Storage) != AutomationType.None)
				{
					ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectDataCD2.objectID, databaseBankBlob, objectDataCD2.variation);
					int2 offset = entityObjectInfo.prefabCornerOffset;
					int2 size = entityObjectInfo.prefabTileSize;
					if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state, entity3))
					{
						InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state, entity3).GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
					}
					for (int l = int5.x + offset.x; l < int5.x + offset.x + size.x; l++)
					{
						for (int m = int5.y + offset.y; m < int5.y + offset.y + size.y; m++)
						{
							Entity entity5 = entityCommandBuffer.CreateEntity(storageArchetype);
							entityCommandBuffer.SetComponent(entity5, new StorageCD
							{
								position = new int2(l, m),
								inventoryEntity = entity3
							});
							entityCommandBuffer.SetComponent(entity5, new BigEntityRefCD
							{
								Value = entity3
							});
							smallEntityBuffer.Add(new SmallEntityRefBuffer
							{
								Value = entity5
							});
						}
					}
				}
				if ((uncheckedRefRW2.ValueRO.type & AutomationType.Mineable) != AutomationType.None)
				{
					ref PugDatabase.EntityObjectInfo entityObjectInfo2 = ref PugDatabase.GetEntityObjectInfo(objectDataCD2.objectID, databaseBankBlob, objectDataCD2.variation);
					int2 offset2 = entityObjectInfo2.prefabCornerOffset;
					int2 size2 = entityObjectInfo2.prefabTileSize;
					if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state, entity3))
					{
						InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state, entity3).GetPrefabOffsetAndTileSize(offset2, size2, out offset2, out size2);
					}
					for (int n = int5.x + offset2.x; n < int5.x + offset2.x + size2.x; n++)
					{
						for (int num3 = int5.y + offset2.y; num3 < int5.y + offset2.y + size2.y; num3++)
						{
							Entity entity6 = entityCommandBuffer.CreateEntity(mineableArchetype);
							entityCommandBuffer.SetComponent(entity6, new MineableCD
							{
								position = new int2(n, num3)
							});
							entityCommandBuffer.SetComponent(entity6, new BigEntityRefCD
							{
								Value = entity3
							});
							smallEntityBuffer.Add(new SmallEntityRefBuffer
							{
								Value = entity6
							});
						}
					}
				}
				if ((uncheckedRefRW2.ValueRO.type & AutomationType.Miner) != AutomationType.None && uncheckedRefRW2.ValueRO.isActive)
				{
					PugAutomationMinerConfigCD componentAfterCompletingDependency2 = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Pug_Automation_PugAutomationMinerConfigCD_RO_ComponentLookup, ref state, entity3);
					Entity entity7 = entityCommandBuffer.CreateEntity(minerArchetype);
					entityCommandBuffer.SetComponent(entity7, new MinerCD
					{
						position = int5 + componentAfterCompletingDependency2.offset,
						damage = componentAfterCompletingDependency2.damage,
						cooldown = componentAfterCompletingDependency2.cooldown,
						timer = componentAfterCompletingDependency2.cooldown
					});
					entityCommandBuffer.SetComponent(entity7, new BigEntityRefCD
					{
						Value = entity3
					});
					smallEntityBuffer.Add(new SmallEntityRefBuffer
					{
						Value = entity7
					});
				}
				if ((uncheckedRefRW2.ValueRO.type & AutomationType.Crafter) != AutomationType.None && uncheckedRefRW2.ValueRO.isActive)
				{
					CraftingType craftingType = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__CraftingCD_RO_ComponentLookup, ref state, entity3).craftingType;
					EntityArchetype entityArchetype;
					switch (craftingType)
					{
					case CraftingType.Simple:
					case CraftingType.ProcessResources:
					case CraftingType.BossStatue:
					case CraftingType.Cooking:
					case CraftingType.Cattle:
					case CraftingType.BiomeBossStatue:
						entityArchetype = crafterArchetype;
						break;
					case CraftingType.Extract:
						entityArchetype = extractorArchetype;
						break;
					case CraftingType.Incinerate:
						entityArchetype = incineratorArchetype;
						break;
					case CraftingType.Fishing:
						entityArchetype = fisherArchetype;
						break;
					case CraftingType.CritterCatching:
						entityArchetype = critterCatchingArchetype;
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					EntityArchetype archetype = entityArchetype;
					ComponentType componentType;
					switch (craftingType)
					{
					case CraftingType.Simple:
					case CraftingType.ProcessResources:
					case CraftingType.BossStatue:
					case CraftingType.Cooking:
					case CraftingType.Cattle:
					case CraftingType.BiomeBossStatue:
						componentType = ComponentType.ReadWrite<CraftingTimerTriggerCD>();
						break;
					case CraftingType.Extract:
						componentType = ComponentType.ReadWrite<IsExtractorTimerTriggerCD>();
						break;
					case CraftingType.Incinerate:
						componentType = ComponentType.ReadWrite<IsIncineratorTimerTriggerCD>();
						break;
					case CraftingType.Fishing:
						componentType = ComponentType.ReadWrite<IsFishingTimerTriggerCD>();
						break;
					case CraftingType.CritterCatching:
						componentType = ComponentType.ReadWrite<IsCritterCatchingTimerTriggerCD>();
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					ComponentType triggerType = componentType;
					int length = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__CraftingTimerSlotBuffer_RW_BufferLookup, ref state, entity3).Length;
					DynamicBuffer<SmallEntityCrafterRefBuffer> dynamicBuffer2 = entityCommandBuffer.AddBuffer<SmallEntityCrafterRefBuffer>(entity3);
					for (int num4 = 0; num4 < length; num4++)
					{
						Entity entity8 = entityCommandBuffer.CreateEntity(archetype);
						entityCommandBuffer.SetComponent(entity8, new CrafterForSlotCD
						{
							slotIndex = num4
						});
						entityCommandBuffer.SetComponent(entity8, new PugTimerUserCD
						{
							triggerType = triggerType
						});
						entityCommandBuffer.SetComponent(entity8, new BigEntityRefCD
						{
							Value = entity3
						});
						smallEntityBuffer.Add(new SmallEntityRefBuffer
						{
							Value = entity8
						});
						dynamicBuffer2.Add(new SmallEntityCrafterRefBuffer
						{
							smallEntity = entity8
						});
					}
				}
			}
			entityCommandBuffer.Playback(state.EntityManager);
			entityCommandBuffer.Dispose();
		}

		private static Entity SetupNewOrchestrator(EntityArchetype moverOrchestratorArchetype, Entity entity, EntityCommandBuffer ecb, DynamicBuffer<SmallEntityRefBuffer> smallEntityBuffer, out DynamicBuffer<MoversWithSharedStateBuffer> moversWithSharedStateBuffer, int activeMoverIndex = -1, int nextCycleIncrement = 0)
		{
			Entity entity2 = ecb.CreateEntity(moverOrchestratorArchetype);
			ecb.SetComponentEnabled<EnableSharedMoversTriggerCD>(entity2, value: false);
			ecb.SetComponentEnabled<DeactivateSharedMoversTriggerCD>(entity2, value: false);
			ecb.SetComponent(entity2, new BigEntityRefCD
			{
				Value = entity
			});
			ecb.SetComponent(entity2, new MoverOrchestratorCD
			{
				enabledMoverIndex = activeMoverIndex,
				nextMoverCycleIncrement = nextCycleIncrement
			});
			smallEntityBuffer.Add(new SmallEntityRefBuffer
			{
				Value = entity2
			});
			moversWithSharedStateBuffer = ecb.SetBuffer<MoversWithSharedStateBuffer>(entity2);
			return entity2;
		}

		private void SetupMovers(EntityArchetype moverArchetype, ref BlobArray<PugAutomationMoverConfigElementData> moverArray, ref PugAutomationMoversSharedConfigData sharedConfig, Entity entity, int2 position, int2 dir, Entity allowOnlyOneMoverOptionalOrchestratorEntity, DynamicBuffer<MoversWithSharedStateBuffer> orchestratorMoverBuffer, EntityCommandBuffer ecb, DynamicBuffer<SmallEntityRefBuffer> smallEntityBuffer, in CategoryFilteringCD categoryFilteringCD, ref int totalMoverIndex, int activeMoverFromSerialization, RefRW<PugAutomationEnabledMoverSyncedCD> pugAutomationMoverOrchestratorSynced)
		{
			for (int i = 0; i < moverArray.Length; i++)
			{
				int2 int5 = EntityUtility.RotateVectorFromDefaultDownRotation(moverArray[i].affectedPosition, dir);
				int2 movePos = position + int5;
				int2 moveVector = EntityUtility.RotateVectorFromDefaultDownRotation(moverArray[i].moveVector, dir);
				if (pugAutomationMoverOrchestratorSynced.IsValid && activeMoverFromSerialization == totalMoverIndex)
				{
					pugAutomationMoverOrchestratorSynced.ValueRW.moveVector = moveVector;
				}
				bool activeMoverFromSerialization2 = activeMoverFromSerialization == -1 || activeMoverFromSerialization == totalMoverIndex;
				SetupNewMover(moverArchetype, moverOrchestratorArchetype, entity, allowOnlyOneMoverOptionalOrchestratorEntity, orchestratorMoverBuffer, movePos, moveVector, ecb, ref sharedConfig, smallEntityBuffer, categoryFilteringCD, activeMoverFromSerialization2, moverArray.Length);
				totalMoverIndex++;
			}
		}

		private static void SetupNewMover(EntityArchetype moverArchetype, EntityArchetype moverOrchestratorArchetype, Entity entity, Entity allowOnlyOneMoverOptionalOrchestratorEntity, DynamicBuffer<MoversWithSharedStateBuffer> orchestratorMoverBuffer, int2 movePos, int2 moveVector, EntityCommandBuffer ecb, ref PugAutomationMoversSharedConfigData sharedConfig, DynamicBuffer<SmallEntityRefBuffer> smallEntityBuffer, CategoryFilteringCD categoryFilteringCD, bool activeMoverFromSerialization, int moversFromConfig)
		{
			Entity entity2 = ecb.CreateEntity(moverArchetype);
			Entity entity3 = allowOnlyOneMoverOptionalOrchestratorEntity;
			if (entity3 == Entity.Null)
			{
				entity3 = SetupNewOrchestrator(moverOrchestratorArchetype, entity, ecb, smallEntityBuffer, out orchestratorMoverBuffer);
			}
			ecb.SetComponent(entity2, new BigEntityRefCD
			{
				Value = entity
			});
			smallEntityBuffer.Add(new SmallEntityRefBuffer
			{
				Value = entity2
			});
			int indexInOrchestrator = orchestratorMoverBuffer.Add(new MoversWithSharedStateBuffer
			{
				moverEntity = entity2,
				cachedStart = movePos,
				cachedDirection = moveVector
			});
			ecb.SetComponent(entity2, new MoverCD
			{
				moveTime = sharedConfig.moveTime,
				start = movePos,
				stop = movePos + moveVector,
				cooldownTime = sharedConfig.cooldownTime,
				allowPickupFromInventories = sharedConfig.allowPickupFromInventories,
				inventoryEntity = (sharedConfig.pickUp ? entity : Entity.Null),
				moverOrchestratorEntity = entity3,
				splitsIntoOnMove = (sharedConfig.splitOnMove ? moversFromConfig : 0),
				cycleEnabledMoverAfterActivation = sharedConfig.enableInRoundRobinAfterActivation,
				enableAllMoversAfterActivation = sharedConfig.enableAllMoversAfterActivation,
				indexInOrchestrator = indexInOrchestrator
			});
			ecb.SetComponent(entity2, new MoverFilterCD
			{
				filterCategory = categoryFilteringCD.filterCategory
			});
			ecb.SetComponentEnabled<PlantTriggerCD>(entity2, value: false);
			ecb.SetComponentEnabled<EnabledMoverFromSharedStateCD>(entity2, activeMoverFromSerialization);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DirectionBasedOnVariationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<SmallEntityRefBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PugAutomationMinerConfigCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_602361812_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			__query_602361812_0.SetChangedVersionFilter(new ComponentType[1]
			{
				new ComponentType(typeof(ObjectDataCD))
			});
			entityQueryBuilder2 = entityQueryBuilder.WithAll<SmallEntityRefBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<PugAutomationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ElectricityCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_602361812_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			__query_602361812_1.SetChangedVersionFilter(new ComponentType[1]
			{
				new ComponentType(typeof(ElectricityCD))
			});
			entityQueryBuilder2 = entityQueryBuilder.WithAll<SmallEntityRefBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<PugAutomationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_602361812_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithNone<PugAutomationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SmallEntityRefBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_602361812_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithNone<SmallEntityRefBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PugAutomationCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
			__query_602361812_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_602361812_5 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_0000013C_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000013D_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			__codegen__OnDestroy_0000013E_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((PugAutomationInstantiateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationInstantiateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationInstantiateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((PugAutomationInstantiateSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}
	}
}
