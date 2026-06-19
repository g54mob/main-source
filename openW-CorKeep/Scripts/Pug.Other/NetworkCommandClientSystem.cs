using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[RequireMatchingQueriesForUpdate]
public class NetworkCommandClientSystem : PugSimulationSystemBase
{
	public struct PlayerEntry
	{
		public string name;

		public int index;

		public int privileges;

		public ulong onlineId;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_370379057_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public NetworkCommandResponseRpc Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<NetworkCommandResponseRpc>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<NetworkCommandResponseRpc> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<NetworkCommandResponseRpc>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<NetworkCommandResponseRpc>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public NetworkCommandResponseRpc Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<NetworkCommandResponseRpc>();
		}
	}

	private struct TypeHandle
	{
		public IFE_370379057_0.TypeHandle __IFE_370379057_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_370379057_0_TypeHandle = new IFE_370379057_0.TypeHandle(ref state);
		}
	}

	public List<PlayerEntry> bannedPlayers = new List<PlayerEntry>();

	public List<PlayerEntry> adminPlayers = new List<PlayerEntry>();

	private TypeHandle __TypeHandle;

	private EntityQuery __query_370379057_0;

	private EntityQuery __query_370379057_1;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		RequireForUpdate<NetworkCommandResponseRpc>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		foreach (NetworkCommandResponseRpc item2 in IFE_370379057_0.Query(__query_370379057_0, __TypeHandle.__IFE_370379057_0_TypeHandle, ref base.CheckedStateRef))
		{
			switch (item2.command)
			{
			case NetworkCommand.PlayerBan:
			{
				List<PlayerEntry> list = bannedPlayers;
				PlayerEntry item = default(PlayerEntry);
				FixedString128Bytes @string = item2.string0;
				item.name = @string.Value;
				item.index = item2.int0;
				item.onlineId = item2.ulong1;
				list.Add(item);
				break;
			}
			case NetworkCommand.PlayerUnban:
			{
				for (int num2 = bannedPlayers.Count - 1; num2 >= 0; num2--)
				{
					if (bannedPlayers[num2].index == item2.int0)
					{
						bannedPlayers.RemoveAt(num2);
					}
				}
				break;
			}
			case NetworkCommand.AddOrUpdateAdmin:
			{
				PlayerEntry item = default(PlayerEntry);
				FixedString128Bytes @string = item2.string0;
				item.name = @string.Value;
				item.index = item2.int0;
				item.privileges = item2.int1;
				item.onlineId = item2.ulong1;
				PlayerEntry playerEntry = item;
				int i;
				for (i = 0; i < adminPlayers.Count; i++)
				{
					if (adminPlayers[i].onlineId == playerEntry.onlineId || adminPlayers[i].index == playerEntry.index)
					{
						adminPlayers[i] = playerEntry;
						break;
					}
				}
				if (i == adminPlayers.Count)
				{
					adminPlayers.Add(playerEntry);
				}
				break;
			}
			case NetworkCommand.RemoveAdmin:
			{
				for (int num = adminPlayers.Count - 1; num >= 0; num--)
				{
					if (adminPlayers[num].index == item2.int0)
					{
						adminPlayers.RemoveAt(num);
					}
				}
				break;
			}
			case NetworkCommand.RecreateGameId:
			{
				NetworkingManager networking = Manager.networking;
				FixedString128Bytes @string = item2.string0;
				networking.UpdateGameId(@string.Value, item2.int0);
				if (Manager.networking.currentSessionIsDedicatedServer)
				{
					Manager.prefs.AddOrUpdateServer(Manager.networking.serverGuid, Manager.networking.serverName, Manager.networking.CurrentSession);
				}
				break;
			}
			}
		}
		base.EntityManager.DestroyEntity(__query_370379057_1);
		base.OnUpdate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkCommandResponseRpc>();
		__query_370379057_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkCommandResponseRpc>();
		__query_370379057_1 = entityQueryBuilder2.Build(ref state);
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
	public NetworkCommandClientSystem()
	{
	}
}
