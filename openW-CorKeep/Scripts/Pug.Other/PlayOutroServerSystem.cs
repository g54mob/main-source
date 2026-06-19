using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class PlayOutroServerSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_361147518_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<PlayOutroClientSystem.PlayOutroRPC>, InternalCompilerInterface.UncheckedRefRO<ReceiveRpcCommandRequest>> Get(int index)
			{
				return new QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<PlayOutroClientSystem.PlayOutroRPC>, InternalCompilerInterface.UncheckedRefRO<ReceiveRpcCommandRequest>>(InternalCompilerInterface.UnsafeGetUncheckedRefRO<PlayOutroClientSystem.PlayOutroRPC>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<ReceiveRpcCommandRequest>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<PlayOutroClientSystem.PlayOutroRPC> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<ReceiveRpcCommandRequest> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlayOutroClientSystem.PlayOutroRPC>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<PlayOutroClientSystem.PlayOutroRPC>, InternalCompilerInterface.UncheckedRefRO<ReceiveRpcCommandRequest>>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<PlayOutroClientSystem.PlayOutroRPC>, InternalCompilerInterface.UncheckedRefRO<ReceiveRpcCommandRequest>> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<PlayOutroClientSystem.PlayOutroRPC>();
			state.EntityManager.CompleteDependencyBeforeRO<ReceiveRpcCommandRequest>();
		}
	}

	private struct TypeHandle
	{
		public IFE_361147518_0.TypeHandle __IFE_361147518_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_361147518_0_TypeHandle = new IFE_361147518_0.TypeHandle(ref state);
		}
	}

	private EntityArchetype rpcArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_361147518_0;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		base.OnCreate();
		rpcArchetype = base.EntityManager.CreateArchetype(typeof(PlayOutroClientSystem.PlayOutroRPC), typeof(SendRpcCommandRequest));
		RequireForUpdate<PlayOutroClientSystem.PlayOutroRPC>();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer entityCommandBuffer = CreateCommandBuffer();
		EntityArchetype archetype = rpcArchetype;
		bool guestMode = base.WorldInfo.guestMode;
		ComponentLookup<ConnectionAdminLevelCD> fromEntity = GetComponentLookup<ConnectionAdminLevelCD>(isReadOnly: true);
		foreach (var (_, uncheckedRefRO3, e) in IFE_361147518_0.Query(__query_361147518_0, __TypeHandle.__IFE_361147518_0_TypeHandle, ref base.CheckedStateRef))
		{
			entityCommandBuffer.DestroyEntity(e);
			if (!guestMode || fromEntity.GetAdminLevelOnServer(uncheckedRefRO3.ValueRO.SourceConnection) > 0)
			{
				entityCommandBuffer.CreateEntity(archetype);
			}
		}
		base.OnUpdate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayOutroClientSystem.PlayOutroRPC>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_361147518_0 = entityQueryBuilder2.Build(ref state);
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
	public PlayOutroServerSystem()
	{
	}
}
