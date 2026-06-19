using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class CreateCharacterGuidSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1117233664_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public InternalCompilerInterface.UncheckedRefRW<CharacterGuidCD> Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetUncheckedRefRW<CharacterGuidCD>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<CharacterGuidCD> item1_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<CharacterGuidCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<InternalCompilerInterface.UncheckedRefRW<CharacterGuidCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public InternalCompilerInterface.UncheckedRefRW<CharacterGuidCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<CharacterGuidCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1117233664_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public InternalCompilerInterface.UncheckedRefRW<PlayerGuidCD> Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetUncheckedRefRW<PlayerGuidCD>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<PlayerGuidCD> item1_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<PlayerGuidCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<InternalCompilerInterface.UncheckedRefRW<PlayerGuidCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public InternalCompilerInterface.UncheckedRefRW<PlayerGuidCD> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<PlayerGuidCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1117233664_0.TypeHandle __IFE_1117233664_0_TypeHandle;

		public IFE_1117233664_1.TypeHandle __IFE_1117233664_1_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1117233664_0_TypeHandle = new IFE_1117233664_0.TypeHandle(ref state);
			__IFE_1117233664_1_TypeHandle = new IFE_1117233664_1.TypeHandle(ref state);
		}
	}

	private EntityQuery _createCharacterGuidQ;

	private EntityQuery _createPlayerGuidQ;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1117233664_0;

	private EntityQuery __query_1117233664_1;

	private EntityQuery __query_1117233664_2;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		foreach (InternalCompilerInterface.UncheckedRefRW<CharacterGuidCD> item in IFE_1117233664_0.Query(__query_1117233664_0, __TypeHandle.__IFE_1117233664_0_TypeHandle, ref base.CheckedStateRef))
		{
			item.ValueRW.Value = PugRandom.GenerateGuid();
		}
		foreach (InternalCompilerInterface.UncheckedRefRW<PlayerGuidCD> item2 in IFE_1117233664_1.Query(__query_1117233664_1, __TypeHandle.__IFE_1117233664_1_TypeHandle, ref base.CheckedStateRef))
		{
			item2.ValueRW.Value = PugRandom.GenerateGuid();
		}
		EntityQuery _query_1117233664_ = __query_1117233664_2;
		base.EntityManager.RemoveComponent<CreateNewGuidCD>(_query_1117233664_);
		base.OnUpdate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<CreateNewGuidCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CharacterGuidCD>();
		__query_1117233664_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CreateNewGuidCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerGuidCD>();
		__query_1117233664_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CreateNewGuidCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<CharacterGuidCD, PlayerGuidCD>();
		__query_1117233664_2 = entityQueryBuilder2.Build(ref state);
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
	public CreateCharacterGuidSystem()
	{
	}
}
