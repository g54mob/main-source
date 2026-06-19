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
public struct OctopusBossSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2087285749_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr item4_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<EnsureSameGroundTileBeneathEntityCD>, EnrageStateCD, OctopusBossCD) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<RangeAttackStateCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<EnsureSameGroundTileBeneathEntityCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<EnrageStateCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<OctopusBossCD>(item4_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<RangeAttackStateCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<EnsureSameGroundTileBeneathEntityCD> item2_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<EnrageStateCD> item3_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<OctopusBossCD> item4_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<RangeAttackStateCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<EnsureSameGroundTileBeneathEntityCD>();
				item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
				item4_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<OctopusBossCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_ComponentTypeHandle_RO.Update(ref systemState);
				item4_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RO),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<EnsureSameGroundTileBeneathEntityCD>, EnrageStateCD, OctopusBossCD)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRW<EnsureSameGroundTileBeneathEntityCD>, EnrageStateCD, OctopusBossCD) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<EnsureSameGroundTileBeneathEntityCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EnrageStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<OctopusBossCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2087285749_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<AnimationBuffer> item3_BufferAccessor;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossAppearStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<OctopusBossHasAppearedCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<OctopusBossAppearStateCD>(item2_IntPtr, index), item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<OctopusBossHasAppearedCD>(item5_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<OctopusBossAppearStateCD> item2_ComponentTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item3_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item4_ComponentTypeHandle_RW;

			private ComponentTypeHandle<OctopusBossHasAppearedCD> item5_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<OctopusBossAppearStateCD>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item5_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<OctopusBossHasAppearedCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_BufferTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RW.Update(ref systemState);
				item5_ComponentTypeHandle_RW.Update(ref systemState);
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
					item5_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item5_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossAppearStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<OctopusBossHasAppearedCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossAppearStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<OctopusBossHasAppearedCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<OctopusBossAppearStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRW<OctopusBossHasAppearedCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2087285749_2
	{
		public struct ResolvedChunk
		{
			public BufferAccessor<TeleportLocationsBuffer> item1_BufferAccessor;

			public IntPtr item2_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (DynamicBuffer<TeleportLocationsBuffer>, LocalTransform) Get(int index)
			{
				return (item1_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<LocalTransform>(item2_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<TeleportLocationsBuffer> item1_BufferTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<LocalTransform> item2_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<TeleportLocationsBuffer>();
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item1_BufferTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(DynamicBuffer<TeleportLocationsBuffer>, LocalTransform)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (DynamicBuffer<TeleportLocationsBuffer>, LocalTransform) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<TeleportLocationsBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2087285749_3
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<OctopusBossCD>, OctopusBossHasAppearedCD, DistanceToPlayerCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<OctopusBossCD>, OctopusBossHasAppearedCD, DistanceToPlayerCD>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<OctopusBossCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<OctopusBossHasAppearedCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<DistanceToPlayerCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<OctopusBossCD> item1_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<OctopusBossHasAppearedCD> item2_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<DistanceToPlayerCD> item3_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<OctopusBossCD>();
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<OctopusBossHasAppearedCD>(isReadOnly: true);
				item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<OctopusBossCD>, OctopusBossHasAppearedCD, DistanceToPlayerCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<OctopusBossCD>, OctopusBossHasAppearedCD, DistanceToPlayerCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<OctopusBossCD>();
			state.EntityManager.CompleteDependencyBeforeRO<OctopusBossHasAppearedCD>();
			state.EntityManager.CompleteDependencyBeforeRO<DistanceToPlayerCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2087285749_4
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public BufferAccessor<AnimationBuffer> item4_BufferAccessor;

			public IntPtr item5_IntPtr;

			public IntPtr item6_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossLurkingBelowStateCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<OctopusBossHasAppearedCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<OctopusBossLurkingBelowStateCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<OctopusBossCD>(item3_IntPtr, index), item4_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item5_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<OctopusBossHasAppearedCD>(item6_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<OctopusBossLurkingBelowStateCD> item2_ComponentTypeHandle_RW;

			private ComponentTypeHandle<OctopusBossCD> item3_ComponentTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item4_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item5_ComponentTypeHandle_RW;

			private ComponentTypeHandle<OctopusBossHasAppearedCD> item6_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<OctopusBossLurkingBelowStateCD>();
				item3_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<OctopusBossCD>();
				item4_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item5_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item6_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<OctopusBossHasAppearedCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_ComponentTypeHandle_RW.Update(ref systemState);
				item4_BufferTypeHandle_RW.Update(ref systemState);
				item5_ComponentTypeHandle_RW.Update(ref systemState);
				item6_ComponentTypeHandle_RW.Update(ref systemState);
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
					item6_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item6_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossLurkingBelowStateCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<OctopusBossHasAppearedCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossLurkingBelowStateCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<OctopusBossHasAppearedCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<OctopusBossLurkingBelowStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<OctopusBossCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRW<OctopusBossHasAppearedCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_2087285749_5
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr item4_IntPtr;

			public BufferAccessor<NearbyEntitiesBufferCD> item5_BufferAccessor;

			public IntPtr item6_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossSpawnTentaclesStateCD>, InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, DynamicBuffer<NearbyEntitiesBufferCD>, LocalTransform) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<OctopusBossSpawnTentaclesStateCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<RangeAttackStateCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<EnrageStateCD>(item4_IntPtr, index), item5_BufferAccessor[index], InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<LocalTransform>(item6_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<OctopusBossSpawnTentaclesStateCD> item2_ComponentTypeHandle_RW;

			private ComponentTypeHandle<RangeAttackStateCD> item3_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<EnrageStateCD> item4_ComponentTypeHandle_RO;

			private BufferTypeHandle<NearbyEntitiesBufferCD> item5_BufferTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<LocalTransform> item6_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<OctopusBossSpawnTentaclesStateCD>();
				item3_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<RangeAttackStateCD>();
				item4_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
				item5_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<NearbyEntitiesBufferCD>();
				item6_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_ComponentTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RO.Update(ref systemState);
				item5_BufferTypeHandle_RW.Update(ref systemState);
				item6_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RW),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RW),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RO),
					item5_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item5_BufferTypeHandle_RW),
					item6_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item6_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossSpawnTentaclesStateCD>, InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, DynamicBuffer<NearbyEntitiesBufferCD>, LocalTransform)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<OctopusBossSpawnTentaclesStateCD>, InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, DynamicBuffer<NearbyEntitiesBufferCD>, LocalTransform) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<OctopusBossSpawnTentaclesStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<RangeAttackStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EnrageStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<NearbyEntitiesBufferCD>();
			state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
		}
	}

	private struct TypeHandle
	{
		public IFE_2087285749_0.TypeHandle __IFE_2087285749_0_TypeHandle;

		public IFE_2087285749_1.TypeHandle __IFE_2087285749_1_TypeHandle;

		public IFE_2087285749_2.TypeHandle __IFE_2087285749_2_TypeHandle;

		public IFE_2087285749_3.TypeHandle __IFE_2087285749_3_TypeHandle;

		public IFE_2087285749_4.TypeHandle __IFE_2087285749_4_TypeHandle;

		public IFE_2087285749_5.TypeHandle __IFE_2087285749_5_TypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ForceInCombatCD> __ForceInCombatCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_2087285749_0_TypeHandle = new IFE_2087285749_0.TypeHandle(ref state);
			__IFE_2087285749_1_TypeHandle = new IFE_2087285749_1.TypeHandle(ref state);
			__IFE_2087285749_2_TypeHandle = new IFE_2087285749_2.TypeHandle(ref state);
			__IFE_2087285749_3_TypeHandle = new IFE_2087285749_3.TypeHandle(ref state);
			__IFE_2087285749_4_TypeHandle = new IFE_2087285749_4.TypeHandle(ref state);
			__IFE_2087285749_5_TypeHandle = new IFE_2087285749_5.TypeHandle(ref state);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__ForceInCombatCD_RO_ComponentLookup = state.GetComponentLookup<ForceInCombatCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00000A84_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000A84_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000A84_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00000A85_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00000A85_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000A85_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_00000A86_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00000A86_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00000A86_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private const float DISTANCE_SQ_TO_INCLUDE_TELEPORT_LOCATION = 1600f;

	private const int TENTACLE_SPAWN_ATTEMPTS = 5;

	private const int MAX_TENTACLES = 15;

	private const int MAX_TENTACLES_PER_SPAWN = 8;

	private BlobAssetReference<PugDatabase.PugDatabaseBank> _database;

	private TileAccessor _tileAccessor;

	private int _appearAnimID;

	private int _hiddenAnimID;

	private int _startTeleportAnimID;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2087285749_0;

	private EntityQuery __query_2087285749_1;

	private EntityQuery __query_2087285749_2;

	private EntityQuery __query_2087285749_3;

	private EntityQuery __query_2087285749_4;

	private EntityQuery __query_2087285749_5;

	private EntityQuery __query_2087285749_6;

	private EntityQuery __query_2087285749_7;

	private EntityQuery __query_2087285749_8;

	private EntityQuery __query_2087285749_9;

	private EntityQuery __query_2087285749_10;

	private EntityQuery __query_2087285749_11;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		_appearAnimID = 1819704882;
		_hiddenAnimID = -2007111235;
		_startTeleportAnimID = -1518581387;
		state.RequireForUpdate<OctopusBossCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_database = __query_2087285749_8.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		_tileAccessor = new TileAccessor(ref state);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_2087285749_9.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		__query_2087285749_10.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		CollisionWorld collisionWorld = __query_2087285749_11.GetSingleton<PhysicsWorldSingleton>().CollisionWorld;
		_tileAccessor.Update(ref state);
		foreach (var (uncheckedRefRW, uncheckedRefRW2, enrageStateCD, octopusBossCD) in IFE_2087285749_0.Query(__query_2087285749_0, __TypeHandle.__IFE_2087285749_0_TypeHandle, ref state))
		{
			if (enrageStateCD.isEnraged)
			{
				uncheckedRefRW.ValueRW.minCooldown = 1f;
				uncheckedRefRW.ValueRW.maxCooldown = 1f;
				uncheckedRefRW.ValueRW.timeBetweenShots = 0.15f;
				uncheckedRefRW.ValueRW.speedMultiplier = 1.2f;
			}
			else
			{
				uncheckedRefRW.ValueRW.minCooldown = 3f;
				uncheckedRefRW.ValueRW.maxCooldown = 3f;
				uncheckedRefRW.ValueRW.timeBetweenShots = 0.25f;
				uncheckedRefRW.ValueRW.speedMultiplier = 0.9f;
			}
			uncheckedRefRW2.ValueRW.disabled = !octopusBossCD.isFighting;
		}
		foreach (var (uncheckedRefRW3, uncheckedRefRW4, animationBuffer, uncheckedRefRW5, uncheckedRefRW6) in IFE_2087285749_1.Query(__query_2087285749_1, __TypeHandle.__IFE_2087285749_1_TypeHandle, ref state))
		{
			if (uncheckedRefRW3.ValueRO.IsCurrentState(StateID.OctopusBossAppear))
			{
				if (uncheckedRefRW4.ValueRO.internalState == 0)
				{
					AnimationUtilities.TriggerAnimation(_appearAnimID, serverTick, animationBuffer, ref uncheckedRefRW5.ValueRW);
					uncheckedRefRW4.ValueRW.internalState = 1;
					uncheckedRefRW4.ValueRW.timer.Start(elapsedTime, uncheckedRefRW4.ValueRO.appearDuration);
				}
				else if (uncheckedRefRW4.ValueRW.timer.IsTimerElapsed(elapsedTime) && uncheckedRefRW4.ValueRO.internalState == 1)
				{
					uncheckedRefRW6.ValueRW.Value = true;
					uncheckedRefRW4.ValueRW.internalState = 2;
					uncheckedRefRW3.ValueRW.LeaveState();
				}
			}
		}
		using NativeArray<Entity> nativeArray = __query_2087285749_6.ToEntityArray(Allocator.Temp);
		foreach (var (dynamicBuffer, localTransform) in IFE_2087285749_2.Query(__query_2087285749_2, __TypeHandle.__IFE_2087285749_2_TypeHandle, ref state))
		{
			dynamicBuffer.Clear();
			foreach (Entity item4 in nativeArray)
			{
				float3 position = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, item4).Position;
				if (math.distancesq(localTransform.Position, position) <= 1600f)
				{
					dynamicBuffer.Add(new TeleportLocationsBuffer
					{
						position = position
					});
				}
			}
		}
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<OctopusBossCD>, OctopusBossHasAppearedCD, DistanceToPlayerCD> item5 in IFE_2087285749_3.Query(__query_2087285749_3, __TypeHandle.__IFE_2087285749_3_TypeHandle, ref state))
		{
			item5.Deconstruct(out var item, out var item2, out var item3, out var entity);
			InternalCompilerInterface.UncheckedRefRW<OctopusBossCD> uncheckedRefRW7 = item;
			OctopusBossHasAppearedCD octopusBossHasAppearedCD = item2;
			DistanceToPlayerCD distanceToPlayerCD = item3;
			Entity entity2 = entity;
			if (octopusBossHasAppearedCD.Value)
			{
				bool flag = InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__ForceInCombatCD_RO_ComponentLookup, ref state, entity2);
				bool isVisible = distanceToPlayerCD.isVisible;
				if (isVisible)
				{
					uncheckedRefRW7.ValueRW.isFighting = true;
				}
				if (flag && !isVisible)
				{
					ecb.RemoveComponent<ForceInCombatCD>(entity2);
				}
				else if (!flag && isVisible)
				{
					ecb.AddComponent<ForceInCombatCD>(entity2);
				}
			}
		}
		foreach (var (uncheckedRefRW8, uncheckedRefRW9, uncheckedRefRW10, animationBuffer2, uncheckedRefRW11, uncheckedRefRW12) in IFE_2087285749_4.Query(__query_2087285749_4, __TypeHandle.__IFE_2087285749_4_TypeHandle, ref state))
		{
			if (!uncheckedRefRW8.ValueRO.IsCurrentState(StateID.OctopusBossLurkingBelow))
			{
				uncheckedRefRW9.ValueRW.internalState = 0;
				continue;
			}
			uncheckedRefRW12.ValueRW.Value = false;
			if (uncheckedRefRW10.ValueRO.canLeaveFightTimer <= 0f)
			{
				uncheckedRefRW10.ValueRW.isFighting = false;
			}
			uncheckedRefRW9.ValueRW.cooldownTimer.Start(elapsedTime, 10f);
			if (uncheckedRefRW9.ValueRO.internalState == 0)
			{
				if (uncheckedRefRW9.ValueRO.hasEnteredStateOnce)
				{
					AnimationUtilities.TriggerAnimation(_startTeleportAnimID, serverTick, animationBuffer2, ref uncheckedRefRW11.ValueRW);
					uncheckedRefRW9.ValueRW.internalState = 1;
				}
				else
				{
					AnimationUtilities.TriggerAnimation(_hiddenAnimID, serverTick, animationBuffer2, ref uncheckedRefRW11.ValueRW);
					uncheckedRefRW9.ValueRW.hasEnteredStateOnce = true;
					uncheckedRefRW9.ValueRW.internalState = 2;
				}
				uncheckedRefRW9.ValueRW.timer.Start(elapsedTime, 1f);
			}
			else if (uncheckedRefRW9.ValueRO.internalState == 1 && uncheckedRefRW9.ValueRW.timer.IsTimerElapsed(elapsedTime))
			{
				uncheckedRefRW9.ValueRW.internalState = 2;
				AnimationUtilities.TriggerAnimation(_hiddenAnimID, serverTick, animationBuffer2, ref uncheckedRefRW11.ValueRW);
				uncheckedRefRW9.ValueRW.timer.Start(elapsedTime, 1f);
			}
		}
		using NativeArray<Entity> nativeArray2 = __query_2087285749_7.ToEntityArray(Allocator.Temp);
		int num = math.max(1, nativeArray2.Length);
		foreach (var (uncheckedRefRW13, uncheckedRefRW14, uncheckedRefRW15, uncheckedRefRO, dynamicBuffer2, localTransform2) in IFE_2087285749_5.Query(__query_2087285749_5, __TypeHandle.__IFE_2087285749_5_TypeHandle, ref state))
		{
			if (!uncheckedRefRW13.ValueRO.IsCurrentState(StateID.OctopusBossSpawnTentacles))
			{
				continue;
			}
			ref OctopusBossSpawnTentaclesStateCD valueRW = ref uncheckedRefRW14.ValueRW;
			ref readonly EnrageStateCD valueRO = ref uncheckedRefRO.ValueRO;
			valueRW.cooldownTimer.Start(elapsedTime, rng.NextFloat(valueRW.minCooldown, valueRW.maxCooldown));
			if (valueRW.internalState == 0)
			{
				uncheckedRefRW15.ValueRW.isDisabled = true;
				valueRW.internalState = 1;
				valueRW.timer.Start(elapsedTime, valueRW.durationBeforeStartingToSpawn);
			}
			else if (valueRW.internalState == 1 && valueRW.timer.IsTimerElapsed(elapsedTime))
			{
				valueRW.internalState = 2;
				valueRW.timer.Start(elapsedTime, valueRW.durationUntilSpawn);
			}
			else if (valueRW.internalState == 2 && valueRW.timer.IsTimerElapsed(elapsedTime))
			{
				float3 y = localTransform2.Position + new float3(0.5f, 0f, 0.5f);
				int num2 = ((num > 3) ? ((!valueRO.isEnraged) ? 1 : 2) : ((num <= 1) ? (valueRO.isEnraged ? 4 : 3) : (valueRO.isEnraged ? 3 : 2)));
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(ObjectID.OctopusTentacle, _database);
				uint filter = 131347u;
				int num3 = 0;
				for (int i = 0; i < dynamicBuffer2.Length; i++)
				{
					Entity entity3 = dynamicBuffer2[i].entity;
					if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state, entity3) && InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state, entity3).objectID == ObjectID.OctopusTentacle)
					{
						num3++;
					}
				}
				NativeParallelHashSet<int2> nativeParallelHashSet = new NativeParallelHashSet<int2>(num2 * 9, Allocator.Temp);
				int num4 = 0;
				for (int j = 0; j < num; j++)
				{
					if (num3 >= 15)
					{
						break;
					}
					if (num4 >= 8)
					{
						break;
					}
					float3 position2 = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, nativeArray2[j]).Position;
					if (math.distancesq(position2, y) > 400f)
					{
						continue;
					}
					for (int k = 0; k < num2; k++)
					{
						if (num3 >= 15)
						{
							break;
						}
						if (num4 >= 8)
						{
							break;
						}
						for (int l = 0; l < 5; l++)
						{
							float3 float5 = rng.NextFloat3(-1f, 1f);
							float5.y = 0f;
							float3 float6 = math.round(position2 + float5 * rng.NextFloat(2f, 7f));
							int2 int5 = float6.RoundToInt2();
							if (nativeParallelHashSet.Contains(int5))
							{
								continue;
							}
							bool flag2 = true;
							for (int m = entityObjectInfo.prefabCornerOffset.x; m < entityObjectInfo.prefabTileSize.x + entityObjectInfo.prefabCornerOffset.x && flag2; m++)
							{
								for (int n = entityObjectInfo.prefabCornerOffset.y; n < entityObjectInfo.prefabTileSize.y + entityObjectInfo.prefabCornerOffset.y && flag2; n++)
								{
									float3 float7 = float6 + new float3(m, 0f, n);
									flag2 = !_tileAccessor.HasTypeAndTileset(float7.RoundToInt2(), TileType.ground, 2) && !PositionIsBlocked(collisionWorld, float7, 0.49f, filter);
								}
							}
							if (!flag2)
							{
								continue;
							}
							EntityUtility.CreateEntity(ecb, float6, ObjectID.OctopusTentacle, 1, _database);
							for (int num5 = -1; num5 < entityObjectInfo.prefabTileSize.x + 1; num5++)
							{
								for (int num6 = -1; num6 < entityObjectInfo.prefabTileSize.y + 1; num6++)
								{
									nativeParallelHashSet.Add(int5 + new int2(num5, num6));
								}
							}
							num3++;
							num4++;
							break;
						}
					}
				}
				nativeParallelHashSet.Dispose();
				valueRW.internalState = 3;
				valueRW.timer.Start(elapsedTime, valueRW.durationAfterSpawn);
			}
			else if (valueRW.internalState == 3 && valueRW.timer.IsTimerElapsed(elapsedTime))
			{
				valueRW.internalState = 4;
				valueRW.timer.Start(elapsedTime, valueRW.durationBeforeLeaveSpawnState);
			}
			else if (valueRW.internalState == 4 && valueRW.timer.IsTimerElapsed(elapsedTime))
			{
				uncheckedRefRW15.ValueRW.isDisabled = false;
				uncheckedRefRW13.ValueRW.LeaveState();
			}
		}
	}

	private static bool PositionIsBlocked(CollisionWorld collisionWorld, float3 position, float radius, uint filter)
	{
		return collisionWorld.SphereCast(position, radius, float3.zero, 0f, new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = filter
		});
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EnrageStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<OctopusBossCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EnsureSameGroundTileBeneathEntityCD>();
		__query_2087285749_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OctopusBossAppearStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OctopusBossHasAppearedCD>();
		__query_2087285749_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<TeleportLocationsBuffer>();
		__query_2087285749_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<OctopusBossHasAppearedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OctopusBossCD>();
		__query_2087285749_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OctopusBossLurkingBelowStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OctopusBossCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OctopusBossHasAppearedCD>();
		__query_2087285749_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EnrageStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<OctopusBossSpawnTentaclesStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NearbyEntitiesBufferCD>();
		__query_2087285749_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<OctopusBossTeleportLocationCD>();
		__query_2087285749_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		__query_2087285749_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2087285749_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2087285749_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2087285749_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2087285749_11 = entityQueryBuilder2.Build(ref state);
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
		((OctopusBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000A84_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00000A85_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00000A86_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((OctopusBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((OctopusBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((OctopusBossSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((OctopusBossSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
