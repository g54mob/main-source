using System;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using Jundroo.Common.Utils;
using Unity.Profiling;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkStateRegistryScript : NetworkBehaviour, INetworkStateRegistry
	{
		public class ReceiverState
		{
			public int CurrentState { get; set; }

			public bool IsInitialized => LastMessageId != 0;

			public uint LastMessageId { get; set; }

			public int? PendingState { get; set; }
		}

		private static class Profile
		{
			public static readonly ProfilerMarker OnPostTick = new ProfilerMarker("NetworkStateRegistryScript.OnPostTick");
		}

		private Dictionary<int, INetworkStateReceiver> _localReceivers = new Dictionary<int, INetworkStateReceiver>();

		private List<int> _newReceiverIds = new List<int>();

		private Dictionary<int, ReceiverState> _states = new Dictionary<int, ReceiverState>();

		private Dictionary<int, int> _tickAddStates = new Dictionary<int, int>();

		private Dictionary<int, int> _tickSetStates = new Dictionary<int, int>();

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkStateRegistryScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkStateRegistryScriptGame_002Edll_Excuted;

		public void AddState(INetworkStateReceiver receiver, int addState)
		{
			_tickAddStates.TryGetValue(receiver.ReceiverId, out var value);
			value += addState;
			_tickAddStates[receiver.ReceiverId] = value;
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			base.TimeManager.OnPostTick += OnPostTick;
		}

		public override void OnStopClient()
		{
			base.OnStopClient();
			base.TimeManager.OnPostTick -= OnPostTick;
		}

		public int Register(INetworkStateReceiver receiver, string uniqueName)
		{
			int stableHashCode = StringUtility.GetStableHashCode(uniqueName);
			if (!_localReceivers.ContainsKey(stableHashCode))
			{
				_localReceivers[stableHashCode] = receiver;
				_newReceiverIds.Add(stableHashCode);
				return stableHashCode;
			}
			throw new InvalidOperationException("Receiver with name '" + uniqueName + "' has already been registered");
		}

		public void SetState(INetworkStateReceiver receiver, int state)
		{
			ReceiverState receiverState = GetReceiverState(receiver.ReceiverId);
			if ((!receiverState.PendingState.HasValue && receiverState.CurrentState != state) || (receiverState.PendingState.HasValue && receiverState.PendingState.Value != state))
			{
				_tickSetStates[receiver.ReceiverId] = state;
				receiverState.PendingState = state;
			}
		}

		public void Unregister(INetworkStateReceiver receiver)
		{
			_localReceivers.Remove(receiver.ReceiverId);
			_newReceiverIds.Remove(receiver.ReceiverId);
		}

		[ServerRpc(RequireOwnership = false)]
		private void AddStateServer(int receiverId, int addState, Channel channel = Channel.Reliable)
		{
			RpcWriter___Server_AddStateServer___183887200(receiverId, addState, channel);
		}

		private ReceiverState GetReceiverState(int receiverId)
		{
			if (!_states.TryGetValue(receiverId, out var value))
			{
				value = new ReceiverState();
				_states[receiverId] = value;
				if (base.IsServerStarted)
				{
					value.LastMessageId = 1u;
				}
			}
			return value;
		}

		private void OnPostTick()
		{
			using (Profile.OnPostTick.Auto())
			{
				if (_tickAddStates.Count > 0)
				{
					foreach (KeyValuePair<int, int> tickAddState in _tickAddStates)
					{
						AddStateServer(tickAddState.Key, tickAddState.Value);
					}
					_tickAddStates.Clear();
				}
				if (_tickSetStates.Count > 0)
				{
					foreach (KeyValuePair<int, int> tickSetState in _tickSetStates)
					{
						SetStateServer(tickSetState.Key, tickSetState.Value);
					}
					_tickSetStates.Clear();
				}
				if (_newReceiverIds.Count > 0)
				{
					StateRequestStartServer(base.LocalConnection, _newReceiverIds.ToArray());
					_newReceiverIds.Clear();
				}
			}
		}

		[ObserversRpc(BufferLast = false)]
		private void SetStateClient(int receiverId, int state, uint messageId, Channel channel = Channel.Reliable)
		{
			RpcWriter___Observers_SetStateClient___3257012354(receiverId, state, messageId, channel);
		}

		private void SetStateClientLocal(int receiverId, int state, uint messageId)
		{
			ReceiverState receiverState = GetReceiverState(receiverId);
			if (messageId >= receiverState.LastMessageId)
			{
				if (_localReceivers.TryGetValue(receiverId, out var value))
				{
					value.SetState(state, !receiverState.IsInitialized);
				}
				receiverState.PendingState = null;
				receiverState.LastMessageId = messageId;
				receiverState.CurrentState = state;
			}
		}

		[ServerRpc(RequireOwnership = false)]
		private void SetStateServer(int receiverId, int state, Channel channel = Channel.Reliable)
		{
			RpcWriter___Server_SetStateServer___183887200(receiverId, state, channel);
		}

		[TargetRpc]
		private void StateRequestCompleteClient(NetworkConnection client, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			RpcWriter___Target_StateRequestCompleteClient___748863190(client, data, channel);
		}

		[ServerRpc(RequireOwnership = false)]
		private void StateRequestStartServer(NetworkConnection client, int[] receiverIds, Channel channel = Channel.Reliable)
		{
			RpcWriter___Server_StateRequestStartServer___1484746022(client, receiverIds, channel);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkStateRegistryScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkStateRegistryScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterServerRpc(0u, RpcReader___Server_AddStateServer___183887200);
				RegisterObserversRpc(1u, RpcReader___Observers_SetStateClient___3257012354);
				RegisterServerRpc(2u, RpcReader___Server_SetStateServer___183887200);
				RegisterTargetRpc(3u, RpcReader___Target_StateRequestCompleteClient___748863190);
				RegisterServerRpc(4u, RpcReader___Server_StateRequestStartServer___1484746022);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkStateRegistryScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkStateRegistryScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Server_AddStateServer___183887200(int receiverId, int addState, Channel channel = Channel.Reliable)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(receiverId);
			pooledWriter.WriteInt32(addState);
			SendServerRpc(0u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___AddStateServer___183887200(int P_0, int P_1, Channel P_2)
		{
			ReceiverState receiverState = GetReceiverState(P_0);
			receiverState.CurrentState += P_1;
			receiverState.LastMessageId++;
			SetStateClient(P_0, receiverState.CurrentState, receiverState.LastMessageId, P_2);
		}

		private void RpcReader___Server_AddStateServer___183887200(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			if (base.IsServerInitialized)
			{
				RpcLogic___AddStateServer___183887200(num, num2, channel);
			}
		}

		private void RpcWriter___Observers_SetStateClient___3257012354(int receiverId, int state, uint messageId, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(receiverId);
			pooledWriter.WriteInt32(state);
			pooledWriter.WriteUInt32(messageId);
			SendObserversRpc(1u, pooledWriter, channel2, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___SetStateClient___3257012354(int P_0, int P_1, uint P_2, Channel P_3)
		{
			SetStateClientLocal(P_0, P_1, P_2);
		}

		private void RpcReader___Observers_SetStateClient___3257012354(PooledReader PooledReader0, Channel channel)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			uint num3 = PooledReader0.ReadUInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___SetStateClient___3257012354(num, num2, num3, channel);
			}
		}

		private void RpcWriter___Server_SetStateServer___183887200(int receiverId, int state, Channel channel = Channel.Reliable)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(receiverId);
			pooledWriter.WriteInt32(state);
			SendServerRpc(2u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SetStateServer___183887200(int P_0, int P_1, Channel P_2)
		{
			ReceiverState receiverState = GetReceiverState(P_0);
			receiverState.CurrentState = P_1;
			receiverState.LastMessageId++;
			SetStateClient(P_0, receiverState.CurrentState, receiverState.LastMessageId, P_2);
		}

		private void RpcReader___Server_SetStateServer___183887200(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			int num = PooledReader0.ReadInt32();
			int num2 = PooledReader0.ReadInt32();
			if (base.IsServerInitialized)
			{
				RpcLogic___SetStateServer___183887200(num, num2, channel);
			}
		}

		private void RpcWriter___Target_StateRequestCompleteClient___748863190(NetworkConnection client, ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendTargetRpc(3u, pooledWriter, channel2, DataOrderType.Default, client, excludeServer: false);
			pooledWriter.Store();
		}

		private void RpcLogic___StateRequestCompleteClient___748863190(NetworkConnection P_0, ArraySegment<byte> P_1, Channel P_2)
		{
			PooledReader pooledReader = ReaderPool.Retrieve(P_1, base.NetworkManager);
			ushort num = pooledReader.ReadUInt16();
			for (int i = 0; i < num; i++)
			{
				int receiverId = pooledReader.ReadInt32();
				int state = pooledReader.ReadInt32();
				uint messageId = pooledReader.ReadUInt32();
				SetStateClientLocal(receiverId, state, messageId);
			}
			pooledReader.Store();
		}

		private void RpcReader___Target_StateRequestCompleteClient___748863190(PooledReader PooledReader0, Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___StateRequestCompleteClient___748863190(base.LocalConnection, arraySegment, channel);
			}
		}

		private void RpcWriter___Server_StateRequestStartServer___1484746022(NetworkConnection client, int[] receiverIds, Channel channel = Channel.Reliable)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteNetworkConnection(client);
			GeneratedWriters___Internal.GWrite___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerated(pooledWriter, receiverIds);
			SendServerRpc(4u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___StateRequestStartServer___1484746022(NetworkConnection P_0, int[] P_1, Channel P_2)
		{
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteUInt16((ushort)P_1.Length);
			foreach (int num in P_1)
			{
				ReceiverState receiverState = GetReceiverState(num);
				pooledWriter.WriteInt32(num);
				pooledWriter.WriteInt32(receiverState.CurrentState);
				pooledWriter.WriteUInt32(receiverState.LastMessageId);
			}
			StateRequestCompleteClient(P_0, pooledWriter.GetArraySegment(), P_2);
			pooledWriter.Store();
		}

		private void RpcReader___Server_StateRequestStartServer___1484746022(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			int[] array = GeneratedReaders___Internal.GRead___System_002EInt32_005B_005DFishNet_002ESerializing_002EGenerateds(PooledReader0);
			if (base.IsServerInitialized)
			{
				RpcLogic___StateRequestStartServer___1484746022(networkConnection, array, channel);
			}
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}
	}
}
