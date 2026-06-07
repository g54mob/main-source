using System.Collections;
using Assets.Scripts.Flight;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class ClientPingScript : NetworkBehaviour
	{
		public readonly SyncDictionary<int, double> _clientPings = new SyncDictionary<int, double>(new SyncTypeSettings(0.5f));

		[SerializeField]
		private float _timeBetweenPings = 5f;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EClientPingScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EClientPingScriptGame_002Edll_Excuted;

		public double GetClientRoundTripTime(int clientId)
		{
			_clientPings.TryGetValue(clientId, out var value);
			return value;
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			StartCoroutine(UpdateServerForever());
		}

		protected virtual IEnumerator UpdateServerForever()
		{
			while (true)
			{
				yield return new WaitForSeconds(_timeBetweenPings);
				SendPingToServer(base.LocalConnection, FlightSceneScript.Instance.FlightSceneNetwork.RoundTripTime);
			}
		}

		[ServerRpc(RequireOwnership = false)]
		private void SendPingToServer(NetworkConnection connection, float ping)
		{
			RpcWriter___Server_SendPingToServer___530160725(connection, ping);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EClientPingScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002EClientPingScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				_clientPings.InitializeEarly(this, 0u, isSyncObject: true);
				RegisterServerRpc(0u, RpcReader___Server_SendPingToServer___530160725);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EClientPingScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002EClientPingScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
				_clientPings.InitializeLate();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Server_SendPingToServer___530160725(NetworkConnection connection, float ping)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteNetworkConnection(connection);
			pooledWriter.WriteSingle(ping);
			SendServerRpc(0u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___SendPingToServer___530160725(NetworkConnection P_0, float P_1)
		{
			_clientPings[P_0.ClientId] = P_1;
		}

		private void RpcReader___Server_SendPingToServer___530160725(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			float num = PooledReader0.ReadSingle();
			if (base.IsServerInitialized)
			{
				RpcLogic___SendPingToServer___530160725(networkConnection, num);
			}
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}
	}
}
