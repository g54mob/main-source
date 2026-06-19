using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[RequireMatchingQueriesForUpdate]
public class NetworkCommandServerSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HasSentInitialBanAndAdminListCD : IComponentData, IQueryTypeParameter
	{
	}

	private struct NetworkCommandServerSystem_59CC188E_LambdaJob_0_Job : IJobChunk
	{
		public NetworkCommandServerSystem __this;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		private void OriginalLambdaBody(Entity entity)
		{
			ecb.AddComponent<HasSentInitialBanAndAdminListCD>(entity);
			foreach (PlayerBanEntry item in Manager.networking.GetBansInternal())
			{
				Entity e = ecb.CreateEntity(__this._responseRpcArchetype);
				ecb.SetComponent(e, new NetworkCommandResponseRpc
				{
					command = NetworkCommand.PlayerBan,
					string0 = item.Name,
					int0 = item.index,
					ulong1 = item.steamId
				});
				ecb.SetComponent(e, new SendRpcCommandRequest
				{
					TargetConnection = entity
				});
			}
			foreach (PlayerAdminEntry item2 in Manager.networking.GetAdminsInternal())
			{
				Entity e2 = ecb.CreateEntity(__this._responseRpcArchetype);
				ecb.SetComponent(e2, new NetworkCommandResponseRpc
				{
					command = NetworkCommand.AddOrUpdateAdmin,
					string0 = item2.Name,
					int0 = item2.index,
					int1 = item2.privileges,
					ulong1 = item2.steamId
				});
				ecb.SetComponent(e2, new SendRpcCommandRequest
				{
					TargetConnection = entity
				});
			}
			if (!string.IsNullOrEmpty(__this._currentGameId))
			{
				Entity e3 = ecb.CreateEntity(__this._responseRpcArchetype);
				ecb.SetComponent(e3, new NetworkCommandResponseRpc
				{
					command = NetworkCommand.RecreateGameId,
					string0 = __this._currentGameId,
					int0 = Manager.networking.MaxPlayersCount
				});
				ecb.SetComponent(e3, new SendRpcCommandRequest
				{
					TargetConnection = entity
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<NetworkCommandServerSystem_59CC188E_LambdaJob_0_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct NetworkCommandServerSystem_59CC188E_LambdaJob_1_Job : IJobChunk
	{
		public NetworkCommandServerSystem __this;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		private void OriginalLambdaBody(Entity entity)
		{
			Entity e = ecb.CreateEntity(__this._responseRpcArchetype);
			ecb.SetComponent(e, new NetworkCommandResponseRpc
			{
				command = NetworkCommand.RecreateGameId,
				string0 = (__this._currentGameId ?? ""),
				int0 = Manager.networking.MaxPlayersCount
			});
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<NetworkCommandServerSystem_59CC188E_LambdaJob_1_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct NetworkCommandServerSystem_59CC188E_LambdaJob_2_Job : IJobChunk
	{
		public NetworkCommandServerSystem __this;

		public EntityCommandBuffer ecb;

		public ComponentLookup<WorldInfoCD> worldInfoLookup;

		public bool hasWorldInfo;

		public Entity worldInfoEntity;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<NetworkCommandRpc> __rpcTypeHandle;

		[ReadOnly]
		public ComponentLookup<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerCustomizationCD> __PlayerCustomizationCD_ComponentLookup;

		private void OriginalLambdaBody(Entity entity, in NetworkCommandRpc rpc)
		{
			ecb.DestroyEntity(entity);
			ReceiveRpcCommandRequest receiveRpcCommandRequest = (__Unity_NetCode_ReceiveRpcCommandRequest_ComponentLookup.HasComponent(entity) ? __Unity_NetCode_ReceiveRpcCommandRequest_ComponentLookup[entity] : default(ReceiveRpcCommandRequest));
			if (rpc.command == NetworkCommand.ChangePvPTeam)
			{
				if (!(rpc.entity0 == Entity.Null) && __FactionCD_ComponentLookup.HasComponent(rpc.entity0))
				{
					_ = __PlayerGhost_ComponentLookup[rpc.entity0];
					_ = __PlayerCustomizationCD_ComponentLookup[rpc.entity0];
					FactionCD component = __FactionCD_ComponentLookup[rpc.entity0];
					component.ChangePvPTeam();
					ecb.SetComponent(rpc.entity0, component);
				}
				return;
			}
			if (receiveRpcCommandRequest.SourceConnection != Entity.Null && Manager.networking.GetAdminPrivileges(receiveRpcCommandRequest.SourceConnection, __this.World, 0uL) <= 0)
			{
				Debug.LogWarning("Ignoring admin command from non-admin player");
				return;
			}
			switch (rpc.command)
			{
			case NetworkCommand.PlayerBan:
			{
				if (rpc.entity0 == Entity.Null)
				{
					break;
				}
				PlayerGhost playerGhost = __PlayerGhost_ComponentLookup[rpc.entity0];
				Entity connection = playerGhost.connection;
				if (Manager.networking.GetAdminPrivileges(connection, __this.World, playerGhost.onlineId) == 0)
				{
					FixedString32Bytes fs = __PlayerCustomizationCD_ComponentLookup[rpc.entity0].customization.name;
					int num = Manager.networking.BanPlayerInternal(fs.Value, connection, __this.World, playerGhost.onlineId);
					if (num != -1)
					{
						Entity e2 = ecb.CreateEntity(__this._responseRpcArchetype);
						ecb.SetComponent(e2, new NetworkCommandResponseRpc
						{
							command = rpc.command,
							string0 = fs,
							int0 = num,
							ulong1 = playerGhost.onlineId
						});
					}
				}
				break;
			}
			case NetworkCommand.PlayerUnban:
			{
				Manager.networking.UnbanPlayerInternal(rpc.int0);
				int int5 = rpc.int0;
				Entity e = ecb.CreateEntity(__this._responseRpcArchetype);
				ecb.SetComponent(e, new NetworkCommandResponseRpc
				{
					command = rpc.command,
					int0 = int5
				});
				break;
			}
			case NetworkCommand.RecreateGameId:
				Manager.networking.RecreateGameIDInternal();
				break;
			case NetworkCommand.AddOrUpdateAdmin:
			{
				if (rpc.entity0 == Entity.Null)
				{
					break;
				}
				PlayerGhost playerGhost2 = __PlayerGhost_ComponentLookup[rpc.entity0];
				Entity connection3 = playerGhost2.connection;
				if (Manager.networking.GetAdminPrivileges(connection3, __this.World, playerGhost2.onlineId) == 0)
				{
					FixedString32Bytes fs2 = __PlayerCustomizationCD_ComponentLookup[rpc.entity0].customization.name;
					int num3 = Manager.networking.AddAdminInternal(fs2.Value, connection3, __this.World, 1, playerGhost2.onlineId);
					if (num3 != -1)
					{
						Entity e4 = ecb.CreateEntity(__this._responseRpcArchetype);
						ecb.SetComponent(e4, new NetworkCommandResponseRpc
						{
							command = rpc.command,
							string0 = fs2,
							int0 = num3,
							int1 = 1,
							ulong1 = playerGhost2.onlineId
						});
					}
				}
				break;
			}
			case NetworkCommand.RemoveAdmin:
			{
				int num2 = -1;
				if (__PlayerGhost_ComponentLookup.HasComponent(rpc.entity0))
				{
					Entity connection2 = __PlayerGhost_ComponentLookup[rpc.entity0].connection;
					num2 = Manager.networking.RemoveAdminInternal(connection2, __this.World);
				}
				else if (Manager.networking.RemoveAdminInternal(rpc.int0))
				{
					num2 = rpc.int0;
				}
				if (num2 > 0)
				{
					Entity e3 = ecb.CreateEntity(__this._responseRpcArchetype);
					ecb.SetComponent(e3, new NetworkCommandResponseRpc
					{
						command = rpc.command,
						int0 = num2
					});
				}
				break;
			}
			case NetworkCommand.SetGuestMode:
				if (hasWorldInfo)
				{
					worldInfoLookup.GetRefRW(worldInfoEntity).ValueRW.guestMode = rpc.int0 != 0;
				}
				break;
			case NetworkCommand.SetPvPMode:
				if (hasWorldInfo)
				{
					worldInfoLookup.GetRefRW(worldInfoEntity).ValueRW.pvpEnabled = rpc.int0 != 0;
				}
				break;
			case NetworkCommand.SetDisableSimulation:
				if (hasWorldInfo)
				{
					worldInfoLookup.GetRefRW(worldInfoEntity).ValueRW.simulationDisabled = rpc.int0 != 0;
				}
				break;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NetworkCommandRpc>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NetworkCommandRpc>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NetworkCommandRpc>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NetworkCommandRpc>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<NetworkCommandServerSystem_59CC188E_LambdaJob_2_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<NetworkCommandRpc> __NetworkCommandRpc_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerCustomizationCD> __PlayerCustomizationCD_RO_ComponentLookup;

		public ComponentLookup<WorldInfoCD> __WorldInfoCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__NetworkCommandRpc_RO_ComponentTypeHandle = state.GetComponentTypeHandle<NetworkCommandRpc>(isReadOnly: true);
			__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentLookup = state.GetComponentLookup<ReceiveRpcCommandRequest>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__PlayerCustomizationCD_RO_ComponentLookup = state.GetComponentLookup<PlayerCustomizationCD>(isReadOnly: true);
			__WorldInfoCD_RW_ComponentLookup = state.GetComponentLookup<WorldInfoCD>();
		}
	}

	private EntityArchetype _responseRpcArchetype;

	private string _currentGameId;

	private bool _updateNames;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_370378745_0;

	private EntityQuery __query_370378745_1;

	private EntityQuery __query_370378745_2;

	private EntityQuery __query_370378745_3;

	public void UpdateNames()
	{
		_updateNames = true;
	}

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		AllowToRunBeforeInit();
		_responseRpcArchetype = base.EntityManager.CreateArchetype(typeof(NetworkCommandResponseRpc), typeof(SendRpcCommandRequest));
		_currentGameId = Manager.networking.CurrentSessionID;
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
		if (_updateNames)
		{
			_updateNames = false;
			foreach (PlayerAdminEntry item in Manager.networking.GetAdminsInternal())
			{
				Entity e = ecb.CreateEntity(_responseRpcArchetype);
				ecb.SetComponent(e, new NetworkCommandResponseRpc
				{
					command = NetworkCommand.AddOrUpdateAdmin,
					string0 = item.Name,
					int0 = item.index,
					int1 = item.privileges,
					ulong1 = item.steamId
				});
			}
		}
		NetworkCommandServerSystem_59CC188E_LambdaJob_0_Execute(ref ecb);
		if (_currentGameId != Manager.networking.CurrentSessionID && !string.IsNullOrEmpty(Manager.networking.CurrentSessionID))
		{
			_currentGameId = Manager.networking.CurrentSessionID;
			NetworkCommandServerSystem_59CC188E_LambdaJob_1_Execute(ref ecb);
		}
		ComponentLookup<WorldInfoCD> worldInfoLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WorldInfoCD_RW_ComponentLookup, ref base.CheckedStateRef);
		Entity value;
		bool hasWorldInfo = __query_370378745_3.TryGetSingletonEntity<WorldInfoCD>(out value);
		NetworkCommandServerSystem_59CC188E_LambdaJob_2_Execute(ref ecb, ref worldInfoLookup, ref hasWorldInfo, ref value);
		ecb.Playback(base.EntityManager);
		ecb.Dispose();
		base.OnUpdate();
	}

	private void NetworkCommandServerSystem_59CC188E_LambdaJob_0_Execute(ref EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		NetworkCommandServerSystem_59CC188E_LambdaJob_0_Job value = new NetworkCommandServerSystem_59CC188E_LambdaJob_0_Job
		{
			__this = this,
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle
		};
		if (!__query_370378745_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			NetworkCommandServerSystem_59CC188E_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_370378745_0, jobPtr);
		}
		ecb = value.ecb;
	}

	private void NetworkCommandServerSystem_59CC188E_LambdaJob_1_Execute(ref EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		NetworkCommandServerSystem_59CC188E_LambdaJob_1_Job value = new NetworkCommandServerSystem_59CC188E_LambdaJob_1_Job
		{
			__this = this,
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle
		};
		if (!__query_370378745_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			NetworkCommandServerSystem_59CC188E_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_370378745_1, jobPtr);
		}
		ecb = value.ecb;
	}

	private void NetworkCommandServerSystem_59CC188E_LambdaJob_2_Execute(ref EntityCommandBuffer ecb, ref ComponentLookup<WorldInfoCD> worldInfoLookup, ref bool hasWorldInfo, ref Entity worldInfoEntity)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__NetworkCommandRpc_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__FactionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerGhost_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerCustomizationCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		NetworkCommandServerSystem_59CC188E_LambdaJob_2_Job value = new NetworkCommandServerSystem_59CC188E_LambdaJob_2_Job
		{
			__this = this,
			ecb = ecb,
			worldInfoLookup = worldInfoLookup,
			hasWorldInfo = hasWorldInfo,
			worldInfoEntity = worldInfoEntity,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__rpcTypeHandle = __TypeHandle.__NetworkCommandRpc_RO_ComponentTypeHandle,
			__Unity_NetCode_ReceiveRpcCommandRequest_ComponentLookup = __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentLookup,
			__FactionCD_ComponentLookup = __TypeHandle.__FactionCD_RO_ComponentLookup,
			__PlayerGhost_ComponentLookup = __TypeHandle.__PlayerGhost_RO_ComponentLookup,
			__PlayerCustomizationCD_ComponentLookup = __TypeHandle.__PlayerCustomizationCD_RO_ComponentLookup
		};
		if (!__query_370378745_2.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			NetworkCommandServerSystem_59CC188E_LambdaJob_2_Job.RunWithoutJobSystem(ref __query_370378745_2, jobPtr);
		}
		ecb = value.ecb;
		worldInfoLookup = value.worldInfoLookup;
		hasWorldInfo = value.hasWorldInfo;
		worldInfoEntity = value.worldInfoEntity;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<HasSentInitialBanAndAdminListCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<NetworkStreamConnection>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<NetworkStreamInGame>();
		__query_370378745_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkStreamConnection>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<NetworkStreamInGame>();
		__query_370378745_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<SendRpcCommandRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<NetworkCommandRpc>();
		__query_370378745_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_370378745_3 = entityQueryBuilder2.Build(ref state);
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
	public NetworkCommandServerSystem()
	{
	}
}
