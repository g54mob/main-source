using Assets.Scripts.Flight.Damage;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Serializing.Generated;
using FishNet.Transporting;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkDamageableBodyScript : NetworkBehaviour
	{
		[SerializeField]
		private DamageableBody _body;

		private bool _ignoreDamageEvent;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkDamageableBodyScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkDamageableBodyScriptGame_002Edll_Excuted;

		public override void OnStartClient()
		{
			base.OnStartClient();
			if (_body == null)
			{
				_body = GetComponent<DamageableBody>();
			}
			_body.DamageReceived += OnDamageReceived;
		}

		private void OnDamageReceived(object sender, DamageEventArgs e)
		{
			if (!_ignoreDamageEvent && e.PlayerId.HasValue && Game.Instance.NetworkGameManager.IsLocalPlayer(e.PlayerId.Value))
			{
				ReceivedDamageServer(e, base.ClientManager.Connection.ClientId);
			}
		}

		[ObserversRpc]
		private void ReceivedDamageClient(DamageEventArgs e, int skipClientId)
		{
			RpcWriter___Observers_ReceivedDamageClient___218121388(e, skipClientId);
		}

		[ServerRpc(RequireOwnership = false)]
		private void ReceivedDamageServer(DamageEventArgs e, int skipClientId)
		{
			RpcWriter___Server_ReceivedDamageServer___218121388(e, skipClientId);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkDamageableBodyScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkDamageableBodyScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterObserversRpc(0u, RpcReader___Observers_ReceivedDamageClient___218121388);
				RegisterServerRpc(1u, RpcReader___Server_ReceivedDamageServer___218121388);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkDamageableBodyScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkDamageableBodyScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Observers_ReceivedDamageClient___218121388(DamageEventArgs e, int skipClientId)
		{
			if (!base.IsServerInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because server is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EFlight_002EDamage_002EDamageEventArgsFishNet_002ESerializing_002EGenerated(pooledWriter, e);
			pooledWriter.WriteInt32(skipClientId);
			SendObserversRpc(0u, pooledWriter, channel, DataOrderType.Default, bufferLast: false, excludeServer: false, excludeOwner: false, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___ReceivedDamageClient___218121388(DamageEventArgs P_0, int P_1)
		{
			if (base.ClientManager.Connection.ClientId != P_1)
			{
				try
				{
					_ignoreDamageEvent = true;
					_body.OnDamageReceived(P_0.DamageType, P_0.Damage, P_0.PlayerId, P_0.LocalPosition, P_0.LocalNormal);
				}
				finally
				{
					_ignoreDamageEvent = false;
				}
			}
		}

		private void RpcReader___Observers_ReceivedDamageClient___218121388(PooledReader PooledReader0, Channel channel)
		{
			DamageEventArgs e = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EFlight_002EDamage_002EDamageEventArgsFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int num = PooledReader0.ReadInt32();
			if (base.IsClientInitialized)
			{
				RpcLogic___ReceivedDamageClient___218121388(e, num);
			}
		}

		private void RpcWriter___Server_ReceivedDamageServer___218121388(DamageEventArgs e, int skipClientId)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			GeneratedWriters___Internal.GWrite___Assets_002EScripts_002EFlight_002EDamage_002EDamageEventArgsFishNet_002ESerializing_002EGenerated(pooledWriter, e);
			pooledWriter.WriteInt32(skipClientId);
			SendServerRpc(1u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___ReceivedDamageServer___218121388(DamageEventArgs P_0, int P_1)
		{
			ReceivedDamageClient(P_0, P_1);
		}

		private void RpcReader___Server_ReceivedDamageServer___218121388(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			DamageEventArgs e = GeneratedReaders___Internal.GRead___Assets_002EScripts_002EFlight_002EDamage_002EDamageEventArgsFishNet_002ESerializing_002EGenerateds(PooledReader0);
			int num = PooledReader0.ReadInt32();
			if (base.IsServerInitialized)
			{
				RpcLogic___ReceivedDamageServer___218121388(e, num);
			}
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}
	}
}
