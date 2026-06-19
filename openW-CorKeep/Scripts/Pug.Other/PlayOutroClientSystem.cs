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

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class PlayOutroClientSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PlayOutroRPC : IRpcCommand, IComponentData, IQueryTypeParameter
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_361147443_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ReceiveRpcCommandRequest Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ReceiveRpcCommandRequest>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ReceiveRpcCommandRequest> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<ReceiveRpcCommandRequest>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public ReceiveRpcCommandRequest Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ReceiveRpcCommandRequest>();
		}
	}

	private struct TypeHandle
	{
		public IFE_361147443_0.TypeHandle __IFE_361147443_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_361147443_0_TypeHandle = new IFE_361147443_0.TypeHandle(ref state);
		}
	}

	private NativeQueue<PlayOutroRPC> rpcQueue;

	private EntityArchetype rpcArchetype;

	private EntityQuery connectionsQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_361147443_0;

	private EntityQuery __query_361147443_1;

	public void TriggerOutroForAllPlayers()
	{
		base.EntityManager.CreateEntity(typeof(PlayOutroRPC), typeof(SendRpcCommandRequest));
	}

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		rpcQueue = new NativeQueue<PlayOutroRPC>(Allocator.Persistent);
		rpcArchetype = base.EntityManager.CreateArchetype(typeof(PlayOutroRPC), typeof(SendRpcCommandRequest));
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(NetworkId) };
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		connectionsQuery = GetEntityQuery(entityQueryDesc2);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		rpcQueue.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
		int num = connectionsQuery.CalculateEntityCount();
		PlayOutroRPC item;
		while (rpcQueue.TryDequeue(out item))
		{
			Entity e = entityCommandBuffer.CreateEntity(rpcArchetype);
			entityCommandBuffer.SetComponent(e, item);
		}
		foreach (ReceiveRpcCommandRequest item2 in IFE_361147443_0.Query(__query_361147443_0, __TypeHandle.__IFE_361147443_0_TypeHandle, ref base.CheckedStateRef))
		{
			item2.Consume();
			PlayerController player = Manager.main.player;
			if (!(player == null) && num == 1)
			{
				player.PlayOutro();
			}
		}
		EntityQuery _query_361147443_ = __query_361147443_1;
		if (num == 1)
		{
			base.EntityManager.DestroyEntity(_query_361147443_);
		}
		entityCommandBuffer.Playback(base.EntityManager);
		entityCommandBuffer.Dispose();
		base.OnUpdate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayOutroRPC>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_361147443_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ReceiveRpcCommandRequest, PlayOutroRPC>();
		__query_361147443_1 = entityQueryBuilder2.Build(ref state);
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
	public PlayOutroClientSystem()
	{
	}
}
