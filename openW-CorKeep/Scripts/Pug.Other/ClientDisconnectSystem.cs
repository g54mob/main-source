using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PimDeWitte.UnityMainThreadDispatcher;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeginSimulationSystemGroup))]
public class ClientDisconnectSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_19794926_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public InternalCompilerInterface.UncheckedRefRO<ConnectionState> Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetUncheckedRefRO<ConnectionState>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ConnectionState> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ConnectionState>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<InternalCompilerInterface.UncheckedRefRO<ConnectionState>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public InternalCompilerInterface.UncheckedRefRO<ConnectionState> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<ConnectionState>();
		}
	}

	private struct TypeHandle
	{
		public IFE_19794926_0.TypeHandle __IFE_19794926_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_19794926_0_TypeHandle = new IFE_19794926_0.TypeHandle(ref state);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_19794926_0;

	private EntityQuery __query_19794926_1;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate(__query_19794926_1);
	}

	[Preserve]
	protected override void OnUpdate()
	{
		foreach (InternalCompilerInterface.UncheckedRefRO<ConnectionState> item in IFE_19794926_0.Query(__query_19794926_0, __TypeHandle.__IFE_19794926_0_TypeHandle, ref base.CheckedStateRef))
		{
			if (item.ValueRO.CurrentState == ConnectionState.State.Disconnected)
			{
				string reason = "Error/Unknown";
				switch (item.ValueRO.DisconnectReason)
				{
				case NetworkStreamDisconnectReason.Timeout:
					reason = "Error/Timeout";
					break;
				case NetworkStreamDisconnectReason.MaxConnectionAttempts:
					reason = "Error/MaxConnectionAttempts";
					break;
				case NetworkStreamDisconnectReason.ConnectionClose:
				case NetworkStreamDisconnectReason.ClosedByRemote:
					reason = "Error/ConnectionClose";
					break;
				case NetworkStreamDisconnectReason.BadProtocolVersion:
				case NetworkStreamDisconnectReason.InvalidRpc:
					reason = "Error/BadProtocolVersion";
					break;
				}
				Debug.Log("Client disconnected because " + reason);
				UnityMainThreadDispatcher.Instance().Enqueue(delegate
				{
					Manager.load.ExitGameOnNetworkError(reason);
				});
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ConnectionState>();
		__query_19794926_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		__query_19794926_0.SetChangedVersionFilter(new ComponentType[1]
		{
			new ComponentType(typeof(ConnectionState))
		});
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConnectionState>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<NetworkStreamConnection>();
		__query_19794926_1 = entityQueryBuilder2.Build(ref state);
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
	public ClientDisconnectSystem()
	{
	}
}
