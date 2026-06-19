using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerState;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class PlayRespawnSequenceClientSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PlayRespawnSequenceRPC : IRpcCommand, IComponentData, IQueryTypeParameter
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1641264710_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public InternalCompilerInterface.UncheckedRefRW<ReceiveRpcCommandRequest> Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetUncheckedRefRW<ReceiveRpcCommandRequest>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<ReceiveRpcCommandRequest> item1_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ReceiveRpcCommandRequest>();
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

		public struct Enumerator : IEnumerator<InternalCompilerInterface.UncheckedRefRW<ReceiveRpcCommandRequest>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public InternalCompilerInterface.UncheckedRefRW<ReceiveRpcCommandRequest> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<ReceiveRpcCommandRequest>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1641264710_0.TypeHandle __IFE_1641264710_0_TypeHandle;

		[ReadOnly]
		public ComponentLookup<CharacterTypeCD> __CharacterTypeCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DeathStateCD> __PlayerState_DeathStateCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1641264710_0_TypeHandle = new IFE_1641264710_0.TypeHandle(ref state);
			__CharacterTypeCD_RO_ComponentLookup = state.GetComponentLookup<CharacterTypeCD>(isReadOnly: true);
			__PlayerState_DeathStateCD_RO_ComponentLookup = state.GetComponentLookup<DeathStateCD>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1641264710_0;

	private EntityQuery __query_1641264710_1;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		ComponentLookup<CharacterTypeCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CharacterTypeCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<DeathStateCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_DeathStateCD_RO_ComponentLookup, ref base.CheckedStateRef);
		foreach (InternalCompilerInterface.UncheckedRefRW<ReceiveRpcCommandRequest> item in IFE_1641264710_0.Query(__query_1641264710_0, __TypeHandle.__IFE_1641264710_0_TypeHandle, ref base.CheckedStateRef))
		{
			item.ValueRW.Consume();
			PlayerController player = Manager.main.player;
			if (!(player == null))
			{
				Entity entity = player.entity;
				if (componentLookup.TryGetComponent(entity, out var componentData) && componentLookup2.TryGetComponent(entity, out var componentData2))
				{
					Death.StartRespawnSequence(player, componentData, componentData2);
				}
			}
		}
		EntityQuery _query_1641264710_ = __query_1641264710_1;
		base.EntityManager.DestroyEntity(_query_1641264710_);
		base.OnUpdate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayRespawnSequenceRPC>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ReceiveRpcCommandRequest>();
		__query_1641264710_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayRespawnSequenceRPC, ReceiveRpcCommandRequest>();
		__query_1641264710_1 = entityQueryBuilder2.Build(ref state);
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
	public PlayRespawnSequenceClientSystem()
	{
	}
}
