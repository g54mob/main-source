using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

[WorldSystemFilter(WorldSystemFilterFlags.ThinClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public struct ThinClientConnectSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1533195933_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<PlayerConnectResponseRPC, ReceiveRpcCommandRequest> Get(int index)
			{
				return new QueryEnumerableWithEntity<PlayerConnectResponseRPC, ReceiveRpcCommandRequest>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<PlayerConnectResponseRPC>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ReceiveRpcCommandRequest>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<PlayerConnectResponseRPC> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<ReceiveRpcCommandRequest> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlayerConnectResponseRPC>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<PlayerConnectResponseRPC, ReceiveRpcCommandRequest>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<PlayerConnectResponseRPC, ReceiveRpcCommandRequest> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<PlayerConnectResponseRPC>();
			state.EntityManager.CompleteDependencyBeforeRO<ReceiveRpcCommandRequest>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1533195933_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<NetworkId> Get(int index)
			{
				return new QueryEnumerableWithEntity<NetworkId>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<NetworkId>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<NetworkId> item1_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<NetworkId>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<NetworkId>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<NetworkId> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<NetworkId>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1533195933_0.TypeHandle __IFE_1533195933_0_TypeHandle;

		public IFE_1533195933_1.TypeHandle __IFE_1533195933_1_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1533195933_0_TypeHandle = new IFE_1533195933_0.TypeHandle(ref state);
			__IFE_1533195933_1_TypeHandle = new IFE_1533195933_1.TypeHandle(ref state);
		}
	}

	private bool hasSentConnectRequest;

	private bool isConnected;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1533195933_0;

	private EntityQuery __query_1533195933_1;

	private EntityQuery __query_1533195933_2;

	private EntityQuery __query_1533195933_3;

	private EntityQuery __query_1533195933_4;

	private EntityQuery __query_1533195933_5;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<BeginFixedStepSimulationEntityCommandBufferSystem.Singleton>();
	}

	public unsafe void OnUpdate(ref SystemState state)
	{
		if (!__query_1533195933_2.HasSingleton<NetworkStreamConnection>())
		{
			__query_1533195933_3.GetSingletonRW<NetworkStreamDriver>().ValueRW.Connect(state.EntityManager, Manager.networking.GetLocalEndpoint());
		}
		else
		{
			if (!__query_1533195933_4.HasSingleton<NetworkId>())
			{
				return;
			}
			if (!hasSentConnectRequest)
			{
				using (EntityQuery entityQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(GhostCollectionPrefab)))
				{
					if (entityQuery.IsEmpty)
					{
						Debug.LogError("No ghost collection in default world, can't calculate hash");
					}
					else
					{
						DynamicBuffer<GhostCollectionPrefab> buffer = World.DefaultGameObjectInjectionWorld.EntityManager.GetBuffer<GhostCollectionPrefab>(entityQuery.GetSingletonEntity());
						if (buffer.IsEmpty)
						{
							Debug.LogError("No ghosts in ghost collection in default world, can't calculate hash");
						}
						else
						{
							hasSentConnectRequest = true;
							ulong num = 0uL;
							for (int i = 0; i < buffer.Length; i++)
							{
								num ^= buffer[i].Hash;
							}
							Debug.Log($"send connect with hash {num} for {buffer.Length} ghosts");
							EntityArchetype archetype = state.EntityManager.CreateArchetype(typeof(PlayerConnectRequestRPC), typeof(SendRpcCommandRequest));
							Entity entity = state.EntityManager.CreateEntity(archetype);
							PlayerConnectRequestRPC componentData = new PlayerConnectRequestRPC
							{
								isOwner = false,
								ghostCollectionHash = num
							};
							componentData.SetVersion(Manager.version, Manager.minorVersion);
							componentData.platform = (byte)Manager.platform.Platform;
							componentData.allowCrossPlay = Manager.platform.parentalControlManager.AllowCrossPlay(showUI: false);
							state.EntityManager.SetComponentData(entity, componentData);
						}
					}
					return;
				}
			}
			Entity entity2;
			if (!isConnected)
			{
				EntityCommandBuffer entityCommandBuffer = __query_1533195933_5.GetSingleton<BeginFixedStepSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
				{
					foreach (QueryEnumerableWithEntity<PlayerConnectResponseRPC, ReceiveRpcCommandRequest> item4 in IFE_1533195933_0.Query(__query_1533195933_0, __TypeHandle.__IFE_1533195933_0_TypeHandle, ref state))
					{
						item4.Deconstruct(out var item, out var _, out entity2);
						PlayerConnectResponseRPC playerConnectResponseRPC = item;
						Entity e = entity2;
						entityCommandBuffer.DestroyEntity(e);
						FixedString64Bytes reason;
						if (playerConnectResponseRPC.rejected)
						{
							reason = playerConnectResponseRPC.reason;
							Debug.Log("Server rejected connection with reason " + reason.Value);
							break;
						}
						string[] obj = new string[5] { "Connected to server ", null, null, null, null };
						reason = playerConnectResponseRPC.serverName;
						obj[1] = reason.Value;
						obj[2] = " (";
						Unity.Entities.Hash128 serverGuid = playerConnectResponseRPC.serverGuid;
						obj[3] = serverGuid.ToString();
						obj[4] = ")";
						Debug.Log(string.Concat(obj));
						isConnected = true;
						Entity e2 = entityCommandBuffer.CreateEntity();
						entityCommandBuffer.AddComponent(e2, new ServerSeedCD
						{
							Value = playerConnectResponseRPC.serverSeed
						});
					}
					return;
				}
			}
			if (!(Manager.sceneHandler != null) || !Manager.sceneHandler.isInGame)
			{
				return;
			}
			EntityCommandBuffer entityCommandBuffer2 = __query_1533195933_5.GetSingleton<BeginFixedStepSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			foreach (QueryEnumerableWithEntity<NetworkId> item5 in IFE_1533195933_1.Query(__query_1533195933_1, __TypeHandle.__IFE_1533195933_1_TypeHandle, ref state))
			{
				item5.Deconstruct(out var _, out entity2);
				Entity e3 = entity2;
				UnityEngine.Hash128 hash = UnityEngine.Hash128.Parse(state.World.ToString());
				byte[] strippedAndSerializedCharacterData = Manager.saves.GetStrippedAndSerializedCharacterData();
				StartGameRPC component = new StartGameRPC
				{
					playerGuid = hash,
					totalDataSize = (uint)strippedAndSerializedCharacterData.Length,
					isThinClient = true
				};
				int num2 = strippedAndSerializedCharacterData.Length;
				int num3 = 0;
				fixed (byte* ptr = strippedAndSerializedCharacterData)
				{
					while (num2 > 0)
					{
						int num4 = math.min(component.dataPart.Size, num2);
						UnsafeUtility.MemCpy(component.dataPart.GetUnsafePtr(), ptr + num3, num4);
						component.dataPartSize = (uint)num4;
						component.dataPartStart = (uint)num3;
						Entity e4 = entityCommandBuffer2.CreateEntity();
						entityCommandBuffer2.AddComponent<SendRpcCommandRequest>(e4);
						entityCommandBuffer2.AddComponent(e4, component);
						num3 += num4;
						num2 -= num4;
					}
				}
				entityCommandBuffer2.AddComponent<NetworkStreamInGame>(e3);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerConnectResponseRPC>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		__query_1533195933_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<NetworkStreamInGame>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<NetworkId>();
		__query_1533195933_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkStreamConnection>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1533195933_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<NetworkStreamDriver>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1533195933_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkId>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1533195933_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginFixedStepSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1533195933_5 = entityQueryBuilder2.Build(ref state);
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
		((ThinClientConnectSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((ThinClientConnectSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ThinClientConnectSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
