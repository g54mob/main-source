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
public struct ScarabBossSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_238810678_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<TargetMortarPositionBuffer> item3_BufferAccessor;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			public IntPtr item6_IntPtr;

			public IntPtr item7_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD>, InternalCompilerInterface.UncheckedRefRW<ShootMortarProjectileStateCD>, DynamicBuffer<TargetMortarPositionBuffer>, InternalCompilerInterface.UncheckedRefRW<ScarabBossCD>, InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, InternalCompilerInterface.UncheckedRefRO<StateInfoCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<ScarabBossChargeStateCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ShootMortarProjectileStateCD>(item2_IntPtr, index), item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<ScarabBossCD>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<RangeAttackStateCD>(item5_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<EnrageStateCD>(item6_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<StateInfoCD>(item7_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<ScarabBossChargeStateCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ShootMortarProjectileStateCD> item2_ComponentTypeHandle_RW;

			private BufferTypeHandle<TargetMortarPositionBuffer> item3_BufferTypeHandle_RW;

			private ComponentTypeHandle<ScarabBossCD> item4_ComponentTypeHandle_RW;

			private ComponentTypeHandle<RangeAttackStateCD> item5_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<EnrageStateCD> item6_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<StateInfoCD> item7_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ScarabBossChargeStateCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ShootMortarProjectileStateCD>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<TargetMortarPositionBuffer>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ScarabBossCD>();
				item5_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<RangeAttackStateCD>();
				item6_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
				item7_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_BufferTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RW.Update(ref systemState);
				item5_ComponentTypeHandle_RW.Update(ref systemState);
				item6_ComponentTypeHandle_RO.Update(ref systemState);
				item7_ComponentTypeHandle_RO.Update(ref systemState);
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
					item7_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item7_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD>, InternalCompilerInterface.UncheckedRefRW<ShootMortarProjectileStateCD>, DynamicBuffer<TargetMortarPositionBuffer>, InternalCompilerInterface.UncheckedRefRW<ScarabBossCD>, InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, InternalCompilerInterface.UncheckedRefRO<StateInfoCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD>, InternalCompilerInterface.UncheckedRefRW<ShootMortarProjectileStateCD>, DynamicBuffer<TargetMortarPositionBuffer>, InternalCompilerInterface.UncheckedRefRW<ScarabBossCD>, InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, InternalCompilerInterface.UncheckedRefRO<StateInfoCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<ScarabBossChargeStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<ShootMortarProjectileStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<TargetMortarPositionBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<ScarabBossCD>();
			state.EntityManager.CompleteDependencyBeforeRW<RangeAttackStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EnrageStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<StateInfoCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_238810678_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<AnimationBuffer> item3_BufferAccessor;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			public IntPtr item6_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossAppearStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<ScarabBossHasAppearedCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ScarabBossAppearStateCD>(item2_IntPtr, index), item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ScarabBossHasAppearedCD>(item5_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ScarabBossCD>(item6_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ScarabBossAppearStateCD> item2_ComponentTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item3_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item4_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ScarabBossHasAppearedCD> item5_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ScarabBossCD> item6_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ScarabBossAppearStateCD>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item5_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ScarabBossHasAppearedCD>();
				item6_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ScarabBossCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_ComponentTypeHandle_RW.Update(ref systemState);
				item3_BufferTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RW.Update(ref systemState);
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
					item3_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item3_BufferTypeHandle_RW),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RW),
					item5_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item5_ComponentTypeHandle_RW),
					item6_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item6_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossAppearStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<ScarabBossHasAppearedCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossAppearStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<ScarabBossHasAppearedCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<ScarabBossAppearStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRW<ScarabBossHasAppearedCD>();
			state.EntityManager.CompleteDependencyBeforeRW<ScarabBossCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_238810678_2
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<ScarabBossHasAppearedCD, DistanceToPlayerCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<ScarabBossHasAppearedCD, DistanceToPlayerCD>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ScarabBossHasAppearedCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<DistanceToPlayerCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ScarabBossHasAppearedCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<DistanceToPlayerCD> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ScarabBossHasAppearedCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<ScarabBossHasAppearedCD, DistanceToPlayerCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<ScarabBossHasAppearedCD, DistanceToPlayerCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ScarabBossHasAppearedCD>();
			state.EntityManager.CompleteDependencyBeforeRO<DistanceToPlayerCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_238810678_3
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<AnimationBuffer> item3_BufferAccessor;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossBuriedStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<ScarabBossHasAppearedCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ScarabBossBuriedStateCD>(item2_IntPtr, index), item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ScarabBossHasAppearedCD>(item5_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ScarabBossBuriedStateCD> item2_ComponentTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item3_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item4_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ScarabBossHasAppearedCD> item5_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ScarabBossBuriedStateCD>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item5_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ScarabBossHasAppearedCD>();
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

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossBuriedStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<ScarabBossHasAppearedCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossBuriedStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<ScarabBossHasAppearedCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<ScarabBossBuriedStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRW<ScarabBossHasAppearedCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_238810678_4
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public BufferAccessor<AnimationBuffer> item3_BufferAccessor;

			public IntPtr item4_IntPtr;

			public IntPtr item5_IntPtr;

			public IntPtr item6_IntPtr;

			public IntPtr item7_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, BehaviourTagsCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, BehaviourTagsCD>(InternalCompilerInterface.UnsafeGetUncheckedRefRW<StateInfoCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ScarabBossChargeStateCD>(item2_IntPtr, index), item3_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<AnimationBufferPointer>(item4_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<LocalTransform>(item5_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<EnrageStateCD>(item6_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<BehaviourTagsCD>(item7_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<StateInfoCD> item1_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ScarabBossChargeStateCD> item2_ComponentTypeHandle_RW;

			private BufferTypeHandle<AnimationBuffer> item3_BufferTypeHandle_RW;

			private ComponentTypeHandle<AnimationBufferPointer> item4_ComponentTypeHandle_RW;

			private ComponentTypeHandle<LocalTransform> item5_ComponentTypeHandle_RW;

			[ReadOnly]
			private ComponentTypeHandle<EnrageStateCD> item6_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<BehaviourTagsCD> item7_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<StateInfoCD>();
				item2_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ScarabBossChargeStateCD>();
				item3_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<AnimationBuffer>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<AnimationBufferPointer>();
				item5_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<LocalTransform>();
				item6_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
				item7_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
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
				item7_ComponentTypeHandle_RO.Update(ref systemState);
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
					item7_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item7_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, BehaviourTagsCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, BehaviourTagsCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<ScarabBossChargeStateCD>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRW<LocalTransform>();
			state.EntityManager.CompleteDependencyBeforeRO<EnrageStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<BehaviourTagsCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_238810678_0.TypeHandle __IFE_238810678_0_TypeHandle;

		public IFE_238810678_1.TypeHandle __IFE_238810678_1_TypeHandle;

		public IFE_238810678_2.TypeHandle __IFE_238810678_2_TypeHandle;

		public IFE_238810678_3.TypeHandle __IFE_238810678_3_TypeHandle;

		public IFE_238810678_4.TypeHandle __IFE_238810678_4_TypeHandle;

		[ReadOnly]
		public ComponentLookup<BossSpawnLocationCD> __BossSpawnLocationCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ForceInCombatCD> __ForceInCombatCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_238810678_0_TypeHandle = new IFE_238810678_0.TypeHandle(ref state);
			__IFE_238810678_1_TypeHandle = new IFE_238810678_1.TypeHandle(ref state);
			__IFE_238810678_2_TypeHandle = new IFE_238810678_2.TypeHandle(ref state);
			__IFE_238810678_3_TypeHandle = new IFE_238810678_3.TypeHandle(ref state);
			__IFE_238810678_4_TypeHandle = new IFE_238810678_4.TypeHandle(ref state);
			__BossSpawnLocationCD_RO_ComponentLookup = state.GetComponentLookup<BossSpawnLocationCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__ForceInCombatCD_RO_ComponentLookup = state.GetComponentLookup<ForceInCombatCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000ADF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000ADF_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000ADF_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000AE0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000AE0_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000AE0_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00000AE1_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00000AE1_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000AE1_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_00000AE2_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00000AE2_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00000AE2_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private const float MAX_CHARGE_DISTANCE_FROM_SPAWN = 10f;

	private const int NUM_MORTAR_PATTERNS = 7;

	private AttackSystem.Helper _attackHelper;

	private TileAccessor _tileAccessor;

	private int _appearAnimID;

	private int _hiddenAnimID;

	private int _startTeleportAnimID;

	private int _buryAnimID;

	private int _chargeAnimID;

	private int _unearthAnimID;

	private uint _systemSeed;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_238810678_0;

	private EntityQuery __query_238810678_1;

	private EntityQuery __query_238810678_2;

	private EntityQuery __query_238810678_3;

	private EntityQuery __query_238810678_4;

	private EntityQuery __query_238810678_5;

	private EntityQuery __query_238810678_6;

	private EntityQuery __query_238810678_7;

	private EntityQuery __query_238810678_8;

	private EntityQuery __query_238810678_9;

	private EntityQuery __query_238810678_10;

	private EntityQuery __query_238810678_11;

	private EntityQuery __query_238810678_12;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<TileUpdateBuffer>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<WorldInfoCD>();
		_appearAnimID = 1819704882;
		_hiddenAnimID = -2007111235;
		_startTeleportAnimID = -1518581387;
		_buryAnimID = -696149821;
		_chargeAnimID = 1433117748;
		_unearthAnimID = -1664757979;
		state.RequireForUpdate<ScarabBossCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (!__query_238810678_7.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		_attackHelper = new AttackSystem.Helper(ref state, value.SimulationTickRate);
		_tileAccessor = new TileAccessor(ref state);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		EntityCommandBuffer ecb = __query_238810678_8.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		if (!__query_238810678_7.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		__query_238810678_9.TryGetSingleton<NetworkTime>(out var value2);
		NetworkTick serverTick = value2.ServerTick;
		_attackHelper.Update(ref state, value2.ServerTick, (uint)value.SimulationTickRate);
		_tileAccessor.Update(ref state);
		Entity singletonEntity = __query_238810678_10.GetSingletonEntity();
		Entity singletonEntity2 = __query_238810678_11.GetSingletonEntity();
		Entity singletonEntity3 = __query_238810678_12.GetSingletonEntity();
		using NativeArray<Entity> nativeArray = __query_238810678_5.ToEntityArray(Allocator.Temp);
		int num = math.max(1, __query_238810678_6.CalculateEntityCount());
		foreach (var item28 in IFE_238810678_0.Query(__query_238810678_0, __TypeHandle.__IFE_238810678_0_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD> item = item28.Item1;
			InternalCompilerInterface.UncheckedRefRW<ShootMortarProjectileStateCD> item2 = item28.Item2;
			DynamicBuffer<TargetMortarPositionBuffer> item3 = item28.Item3;
			InternalCompilerInterface.UncheckedRefRW<ScarabBossCD> item4 = item28.Item4;
			InternalCompilerInterface.UncheckedRefRW<RangeAttackStateCD> item5 = item28.Item5;
			InternalCompilerInterface.UncheckedRefRO<EnrageStateCD> item6 = item28.Item6;
			InternalCompilerInterface.UncheckedRefRO<StateInfoCD> item7 = item28.Item7;
			ref ShootMortarProjectileStateCD valueRW = ref item2.ValueRW;
			ref RangeAttackStateCD valueRW2 = ref item5.ValueRW;
			ref ScarabBossChargeStateCD valueRW3 = ref item.ValueRW;
			ref ScarabBossCD valueRW4 = ref item4.ValueRW;
			ref readonly StateInfoCD valueRO = ref item7.ValueRO;
			bool isEnraged = item6.ValueRO.isEnraged;
			valueRW.isDisabled = (valueRW3.disabled = valueRO.IsCurrentState(StateID.RangeAttack));
			valueRW2.endDuration = ((!isEnraged) ? 2 : 0);
			float num2 = ((num > 1) ? ((float)num * 0.55f) : 1f);
			valueRW2.timeBetweenShots = math.max(0.15f, 0.5f / num2);
			if (!valueRW4.hasPreparedNextMortarShots && !valueRO.IsCurrentState(StateID.ShootMortarProjectile))
			{
				item3.Clear();
				int num3 = rng.NextInt(6);
				valueRW4.patternCounter++;
				int num4 = (isEnraged ? 3 : 5);
				if (valueRW4.patternCounter % num4 == 0)
				{
					num3 = 6;
				}
				switch (num3)
				{
				case 0:
				case 1:
				{
					valueRW.mortarProjectileID = ObjectID.SandExplosion;
					valueRW.shootAtSelf = true;
					valueRW.maxProjectilesShotPerWave = ((num3 == 0) ? 8 : 20);
					valueRW.maxProjectilesShotPerWaveMultiplier = ((num3 == 0) ? 1.36f : (25f / 34f));
					valueRW.timeBetweenProjectiles = 1f;
					float3 v2 = new float3(0f, 0f, 1f);
					float num9 = 0f;
					float num10 = 45f;
					float num11 = 5f;
					for (int j = 0; j < 52; j++)
					{
						if ((num3 == 0 && j == 0) || (num3 == 1 && j == 44))
						{
							num11 = 5f;
							num10 = 45f;
						}
						else if ((num3 == 0 && j == 8) || (num3 == 1 && j == 34))
						{
							num11 = 8f;
							num10 = 36f;
						}
						else if ((num3 == 0 && j == 18) || (num3 == 1 && j == 20))
						{
							num11 = 11f;
							num10 = 25.714285f;
						}
						else if ((num3 == 0 && j == 32) || (num3 == 1 && j == 0))
						{
							num11 = 14f;
							num10 = 18f;
						}
						float3 float6 = math.mul(quaternion.RotateY(math.radians(num9)), v2);
						item3.Add(new TargetMortarPositionBuffer
						{
							position = float6 * num11
						});
						num9 += num10;
					}
					break;
				}
				case 2:
				case 3:
				{
					valueRW.mortarProjectileID = ObjectID.SandExplosion;
					valueRW.shootAtSelf = true;
					valueRW.maxProjectilesShotPerWave = 6;
					valueRW.maxProjectilesShotPerWaveMultiplier = 1f;
					valueRW.timeBetweenProjectiles = 0.5f;
					float3 v = math.normalizesafe(new float3(rng.NextFloat(-1f, 1f), 0f, rng.NextFloat(-1f, 1f)), new float3(0f, 0f, -1f));
					float num6 = 30f;
					for (int i = 0; i < 72; i++)
					{
						float num7 = 5f + (float)(i % 6) * 4f;
						float num8 = math.floor((float)i / 6f) * num6;
						if (num3 == 3)
						{
							num8 = 0f - num8;
						}
						float3 float5 = math.mul(quaternion.RotateY(math.radians(num8)), v);
						item3.Add(new TargetMortarPositionBuffer
						{
							position = float5 * num7
						});
					}
					break;
				}
				case 4:
					valueRW.maxProjectilesShotPerWave = 1;
					valueRW.maxProjectilesShotPerWaveMultiplier = 1f;
					valueRW.timeBetweenProjectiles = 0.5f;
					valueRW.mortarProjectileID = ObjectID.SandExplosion;
					valueRW.minRandomSpreadDistance = 0f;
					valueRW.maxRandomSpreadDistance = 0f;
					valueRW.minAmountOfProjectiles = 6;
					valueRW.maxAmountOfProjectiles = 6;
					valueRW.shootAtSelf = false;
					break;
				case 5:
					valueRW.maxProjectilesShotPerWave = 1;
					valueRW.maxProjectilesShotPerWaveMultiplier = 1f;
					valueRW.timeBetweenProjectiles = 0.05f;
					valueRW.mortarProjectileID = ObjectID.SandExplosion;
					valueRW.minRandomSpreadDistance = 6f;
					valueRW.maxRandomSpreadDistance = 16f;
					valueRW.minAmountOfProjectiles = 20;
					valueRW.maxAmountOfProjectiles = 20;
					valueRW.shootAtSelf = true;
					break;
				case 6:
				{
					valueRW.maxProjectilesShotPerWave = 1;
					valueRW.maxProjectilesShotPerWaveMultiplier = 1f;
					valueRW.timeBetweenProjectiles = 0f;
					valueRW.mortarProjectileID = ObjectID.SandExplosionWithScarab;
					valueRW.minRandomSpreadDistance = 6f;
					valueRW.maxRandomSpreadDistance = 9f;
					int num5 = num;
					valueRW.maxAmountOfProjectiles = (valueRW.minAmountOfProjectiles = (int)math.min(math.round((1f + (float)(num5 - 1) * 0.3f) * 5f), 15f));
					valueRW.shootAtSelf = true;
					break;
				}
				}
				valueRW4.hasPreparedNextMortarShots = true;
			}
			else if (valueRO.IsCurrentState(StateID.ShootMortarProjectile))
			{
				valueRW4.hasPreparedNextMortarShots = false;
			}
			if (!math.all(valueRW3.positionToStayWithin == float3.zero))
			{
				continue;
			}
			foreach (Entity item29 in nativeArray)
			{
				if (InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__BossSpawnLocationCD_RO_ComponentLookup, ref state, item29).bossID == ObjectID.ScarabBoss)
				{
					valueRW3.positionToStayWithin = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state, item29).Position;
					break;
				}
			}
		}
		foreach (var item30 in IFE_238810678_1.Query(__query_238810678_1, __TypeHandle.__IFE_238810678_1_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRW<StateInfoCD> item8 = item30.Item1;
			InternalCompilerInterface.UncheckedRefRW<ScarabBossAppearStateCD> item9 = item30.Item2;
			DynamicBuffer<AnimationBuffer> item10 = item30.Item3;
			InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer> item11 = item30.Item4;
			InternalCompilerInterface.UncheckedRefRW<ScarabBossHasAppearedCD> item12 = item30.Item5;
			InternalCompilerInterface.UncheckedRefRW<ScarabBossCD> item13 = item30.Item6;
			ref StateInfoCD valueRW5 = ref item8.ValueRW;
			if (!item8.ValueRO.IsCurrentState(StateID.ScarabBossAppear))
			{
				continue;
			}
			ref ScarabBossAppearStateCD valueRW6 = ref item9.ValueRW;
			DynamicBuffer<AnimationBuffer> animationBuffer = item10;
			ref ScarabBossHasAppearedCD valueRW7 = ref item12.ValueRW;
			ref ScarabBossCD valueRW8 = ref item13.ValueRW;
			if (valueRW6.internalState == 0)
			{
				valueRW6.internalState = 1;
				valueRW6.timer.Start(elapsedTime, 3f);
			}
			else if (valueRW6.timer.IsTimerElapsed(elapsedTime) && valueRW6.internalState == 1)
			{
				if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state, valueRW6.thumperEntity) && InternalCompilerInterface.IsComponentEnabledAfterCompletingDependency(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state, valueRW6.thumperEntity))
				{
					AnimationUtilities.TriggerAnimation(_hiddenAnimID, serverTick, animationBuffer, ref item11.ValueRW);
					valueRW6.timer.Stop();
					valueRW5.EnterState(StateID.ScarabBossBuried);
					continue;
				}
				valueRW8.patternCounter = 2;
				AnimationUtilities.TriggerAnimation(_appearAnimID, serverTick, animationBuffer, ref item11.ValueRW);
				valueRW6.internalState = 2;
				valueRW6.timer.Start(elapsedTime, valueRW6.appearDuration);
				valueRW7.Value = true;
				if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state, valueRW6.thumperEntity))
				{
					HealthCD componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state, valueRW6.thumperEntity);
					componentAfterCompletingDependency.health = 0;
					ecb.SetComponent(valueRW6.thumperEntity, componentAfterCompletingDependency);
					ecb.SetComponentEnabled<DontDropSelfCD>(valueRW6.thumperEntity, value: true);
				}
			}
			else if (valueRW6.timer.IsTimerElapsed(elapsedTime) && valueRW6.internalState == 2)
			{
				valueRW6.internalState = 3;
				valueRW5.LeaveState();
			}
		}
		Entity entity;
		foreach (QueryEnumerableWithEntity<ScarabBossHasAppearedCD, DistanceToPlayerCD> item31 in IFE_238810678_2.Query(__query_238810678_2, __TypeHandle.__IFE_238810678_2_TypeHandle, ref state))
		{
			item31.Deconstruct(out var item14, out var item15, out entity);
			ScarabBossHasAppearedCD scarabBossHasAppearedCD = item14;
			DistanceToPlayerCD distanceToPlayerCD = item15;
			Entity entity2 = entity;
			if (scarabBossHasAppearedCD.Value)
			{
				bool flag = InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__ForceInCombatCD_RO_ComponentLookup, ref state, entity2);
				bool flag2 = distanceToPlayerCD.minDistanceSq < 900f;
				if (flag && !flag2)
				{
					ecb.RemoveComponent<ForceInCombatCD>(entity2);
				}
				else if (!flag && flag2)
				{
					ecb.AddComponent<ForceInCombatCD>(entity2);
				}
			}
		}
		foreach (var item32 in IFE_238810678_3.Query(__query_238810678_3, __TypeHandle.__IFE_238810678_3_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRW<StateInfoCD> item16 = item32.Item1;
			InternalCompilerInterface.UncheckedRefRW<ScarabBossBuriedStateCD> item17 = item32.Item2;
			DynamicBuffer<AnimationBuffer> item18 = item32.Item3;
			InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer> item19 = item32.Item4;
			InternalCompilerInterface.UncheckedRefRW<ScarabBossHasAppearedCD> item20 = item32.Item5;
			ref StateInfoCD valueRW9 = ref item16.ValueRW;
			ref ScarabBossBuriedStateCD valueRW10 = ref item17.ValueRW;
			if (!valueRW9.IsCurrentState(StateID.ScarabBossBuried))
			{
				valueRW10.internalState = 0;
				continue;
			}
			DynamicBuffer<AnimationBuffer> animationBuffer2 = item18;
			item20.ValueRW.Value = false;
			valueRW10.cooldownTimer.Start(elapsedTime, 10f);
			if (valueRW10.internalState == 0)
			{
				if (valueRW10.hasEnteredStateOnce)
				{
					AnimationUtilities.TriggerAnimation(_startTeleportAnimID, serverTick, animationBuffer2, ref item19.ValueRW);
					valueRW10.internalState = 1;
				}
				else
				{
					AnimationUtilities.TriggerAnimation(_hiddenAnimID, serverTick, animationBuffer2, ref item19.ValueRW);
					valueRW10.hasEnteredStateOnce = true;
					valueRW10.internalState = 2;
				}
				valueRW10.timer.Start(elapsedTime, 1f);
			}
			else if (valueRW10.internalState == 1 && valueRW10.timer.IsTimerElapsed(elapsedTime))
			{
				valueRW10.internalState = 2;
				AnimationUtilities.TriggerAnimation(_hiddenAnimID, serverTick, animationBuffer2, ref item19.ValueRW);
				valueRW10.timer.Start(elapsedTime, 1f);
			}
			else if (valueRW10.internalState == 2)
			{
				valueRW10.timer.IsTimerElapsed(elapsedTime);
			}
		}
		foreach (QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<StateInfoCD>, InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD>, DynamicBuffer<AnimationBuffer>, InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>, InternalCompilerInterface.UncheckedRefRO<EnrageStateCD>, BehaviourTagsCD> item33 in IFE_238810678_4.Query(__query_238810678_4, __TypeHandle.__IFE_238810678_4_TypeHandle, ref state))
		{
			item33.Deconstruct(out var item21, out var item22, out var item23, out var item24, out var item25, out var item26, out var item27, out entity);
			InternalCompilerInterface.UncheckedRefRW<StateInfoCD> uncheckedRefRW = item21;
			InternalCompilerInterface.UncheckedRefRW<ScarabBossChargeStateCD> uncheckedRefRW2 = item22;
			DynamicBuffer<AnimationBuffer> dynamicBuffer = item23;
			InternalCompilerInterface.UncheckedRefRW<AnimationBufferPointer> uncheckedRefRW3 = item24;
			InternalCompilerInterface.UncheckedRefRW<LocalTransform> uncheckedRefRW4 = item25;
			InternalCompilerInterface.UncheckedRefRO<EnrageStateCD> uncheckedRefRO = item26;
			BehaviourTagsCD behaviourTags = item27;
			Entity attacker = entity;
			ref StateInfoCD valueRW11 = ref uncheckedRefRW.ValueRW;
			ref ScarabBossChargeStateCD valueRW12 = ref uncheckedRefRW2.ValueRW;
			if (!valueRW11.IsCurrentState(StateID.ScarabBossCharge))
			{
				valueRW12.internalState = 0;
				continue;
			}
			DynamicBuffer<AnimationBuffer> animationBuffer3 = dynamicBuffer;
			ref LocalTransform valueRW13 = ref uncheckedRefRW4.ValueRW;
			if (valueRW12.internalState == 0)
			{
				valueRW12.internalState = 1;
				AnimationUtilities.TriggerAnimation(_buryAnimID, serverTick, animationBuffer3, ref uncheckedRefRW3.ValueRW);
				valueRW12.timer.Start(elapsedTime, valueRW12.buryDuration);
			}
			else if (valueRW12.internalState == 1 && valueRW12.timer.IsTimerElapsed(elapsedTime))
			{
				AnimationUtilities.TriggerAnimation(_chargeAnimID, serverTick, animationBuffer3, ref uncheckedRefRW3.ValueRW);
				valueRW12.internalState = 2;
				valueRW12.chargeCounter = rng.NextInt(3, 6);
				valueRW12.targetLocation = valueRW13.Position;
			}
			else if (valueRW12.internalState == 2)
			{
				if (valueRW12.chargeCounter >= 0)
				{
					if (math.distancesq(valueRW12.targetLocation, valueRW13.Position) < 1f)
					{
						float3 float7 = valueRW12.positionToStayWithin;
						if (math.all(float7 == float3.zero))
						{
							float7 = valueRW13.Position;
						}
						valueRW12.targetLocation = float7 + new float3(rng.NextFloat(-10f, 10f), 0f, rng.NextFloat(-10f, 10f));
						valueRW12.chargeCounter--;
					}
					else
					{
						float3 float8 = math.normalizesafe(valueRW12.targetLocation - valueRW13.Position);
						float num12 = (uncheckedRefRO.ValueRO.isEnraged ? 12f : 8f);
						valueRW13.Position += float8 * deltaTime * num12;
					}
					float2 y = new float2(valueRW13.Position.x, valueRW13.Position.z) + new float2(0.5f, 1f);
					int2 int5 = new int2((int)math.round(y.x), (int)math.round(y.y));
					for (int k = -4; k <= 4; k++)
					{
						for (int l = -4; l <= 4; l++)
						{
							int2 int6 = new int2(k, l) + int5;
							if (!(math.distancesq(int6, y) > 16f))
							{
								TileCD top = _tileAccessor.GetTop(int6);
								if (top.tileType != TileType.ground || top.tileset != 26)
								{
									ecb.AppendToBuffer(singletonEntity3, new TileDamageBuffer
									{
										damage = 10000,
										position = int6,
										skipWallAndRootsLootDropOnDestroy = true,
										canHitLowColliders = true
									});
									Remove(ref ecb, singletonEntity2, int6, TileType.pit);
									Remove(ref ecb, singletonEntity2, int6, TileType.water);
									Remove(ref ecb, singletonEntity2, int6, TileType.dugUpGround);
									Remove(ref ecb, singletonEntity2, int6, TileType.wateredGround);
									AddTile(ref ecb, singletonEntity2, int6, TileType.ground, 26);
								}
							}
						}
					}
					AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
					{
						effectEventBufferSingleton = singletonEntity,
						attacker = attacker,
						isRanged = false,
						attackOffset = new float3(0.5f, 0f, 1f),
						canHitLowTriggers = true,
						radius = 2f,
						damage = valueRW12.damage,
						playerDamage = valueRW12.damage,
						pushback = 2f,
						bypassMaxDamagePerHit = true,
						skipWallAndRootsLootDropOnDestroy = true,
						skipLootDropOnDestroy = true,
						behaviourTags = behaviourTags
					};
					_attackHelper.Attack(ecb, in p);
				}
				else
				{
					valueRW12.internalState = 3;
				}
			}
			else if (valueRW12.internalState == 3)
			{
				valueRW12.internalState = 4;
				AnimationUtilities.TriggerAnimation(_unearthAnimID, serverTick, animationBuffer3, ref uncheckedRefRW3.ValueRW);
				valueRW12.timer.Start(elapsedTime, valueRW12.unearthDuration);
			}
			else if (valueRW12.internalState == 4 && valueRW12.timer.IsTimerElapsed(elapsedTime))
			{
				valueRW11.LeaveState();
				valueRW12.cooldownTimer.Start(elapsedTime, rng.NextFloat(valueRW12.minCooldown, valueRW12.maxCooldown));
			}
		}
	}

	private static void AddTile(ref EntityCommandBuffer ecb, Entity tileUpdateBufferEntity, int2 tilePos, TileType tileType, int tileset)
	{
		ecb.AppendToBuffer(tileUpdateBufferEntity, new TileUpdateBuffer
		{
			command = TileUpdateBuffer.Command.Add,
			position = tilePos,
			tile = new TileCD
			{
				tileType = tileType,
				tileset = tileset
			}
		});
	}

	private static void Remove(ref EntityCommandBuffer ecb, Entity tileUpdateBufferEntity, int2 tilePos, TileType tileType, int tileset = 0)
	{
		ecb.AppendToBuffer(tileUpdateBufferEntity, new TileUpdateBuffer
		{
			command = TileUpdateBuffer.Command.Remove,
			position = tilePos,
			tile = new TileCD
			{
				tileType = tileType,
				tileset = tileset
			}
		});
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EnrageStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ScarabBossChargeStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShootMortarProjectileStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<TargetMortarPositionBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ScarabBossCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
		__query_238810678_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ScarabBossAppearStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ScarabBossHasAppearedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ScarabBossCD>();
		__query_238810678_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ScarabBossHasAppearedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
		__query_238810678_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ScarabBossBuriedStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ScarabBossHasAppearedCD>();
		__query_238810678_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EnrageStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ScarabBossChargeStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
		__query_238810678_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BossSpawnLocationCD>();
		__query_238810678_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		__query_238810678_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_238810678_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_238810678_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_238810678_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_238810678_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_238810678_11 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_238810678_12 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000ADF_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000AE0_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00000AE1_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00000AE2_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ScarabBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ScarabBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ScarabBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ScarabBossSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ScarabBossSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
