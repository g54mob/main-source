using System;
using Assets.Scripts.Flight;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkBodyScript : NetworkBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker OnPostTickOwner = new ProfilerMarker("NetworkBodyScript.OnPostTickOwner");
		}

		private Rigidbody _body;

		private FlightSceneNetworkScript _fsn;

		private float _lastPhysicsTime;

		private bool NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkBodyScriptGame_002Edll_Excuted;

		private bool NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkBodyScriptGame_002Edll_Excuted;

		public bool IsRemote => !base.IsOwner;

		public Rigidbody RigidBody => _body;

		public event Action<NetworkConnection> OwnershipChanged;

		[ServerRpc(RequireOwnership = false)]
		public void DespawnOnServer()
		{
			RpcWriter___Server_DespawnOnServer___2166136261();
		}

		[ServerRpc(RequireOwnership = false)]
		public void GiveOwnershipToClient(NetworkConnection newOwner)
		{
			RpcWriter___Server_GiveOwnershipToClient___328543758(newOwner);
		}

		public override void OnOwnershipClient(NetworkConnection prevOwner)
		{
			base.OnOwnershipClient(prevOwner);
			this.OwnershipChanged?.Invoke(prevOwner);
		}

		public override void OnStartClient()
		{
			base.OnStartClient();
			_fsn = FlightSceneScript.Instance.FlightSceneNetwork;
			_body = GetComponent<Rigidbody>();
			base.TimeManager.OnPostTick += OnPostTickOwner;
		}

		public override void OnStopClient()
		{
			base.OnStopClient();
			base.TimeManager.OnPostTick -= OnPostTickOwner;
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002ENetworkBodyScript_Game_002Edll();
			NetworkInitialize___Late();
		}

		protected virtual void OnDestroy()
		{
			if ((object)FloatingOriginScript.Instance != null)
			{
				FloatingOriginScript.Instance.Repositioned -= FloatingOriginChanged;
			}
		}

		private void FloatingOriginChanged(object sender, FloatingOriginUpdatedEventArgs e)
		{
			base.transform.position -= e.Delta;
		}

		private void OnPostTickOwner()
		{
			using (Profile.OnPostTickOwner.Auto())
			{
				if (base.IsOwner && base.gameObject.activeSelf)
				{
					PooledWriter pooledWriter = WriterPool.Retrieve();
					SerializeWrite(pooledWriter);
					RpcNetworkBodyDataReceived(pooledWriter.GetArraySegment());
					pooledWriter.Store();
				}
			}
		}

		[ObserversRpc(BufferLast = true, ExcludeOwner = true)]
		private void RpcDataReceivedClient(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
		{
			RpcWriter___Observers_RpcDataReceivedClient___2713644489(data, channel);
		}

		[ServerRpc]
		private void RpcNetworkBodyDataReceived(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
		{
			RpcWriter___Server_RpcNetworkBodyDataReceived___2713644489(data, channel);
		}

		private void SerializeRead(Reader reader)
		{
			float num = reader.ReadSingle();
			Vector3 vector = reader.ReadVector3() - GameWorld.Instance.FloatingOriginOffset;
			float num2 = _fsn.PhysicsTime - num;
			if (_lastPhysicsTime <= num)
			{
				_lastPhysicsTime = num;
				Vector3 vector2 = reader.ReadVector3();
				Vector3 euler = reader.ReadVector3();
				Vector3 vector3 = reader.ReadVector3();
				Vector3 vector4 = reader.ReadVector3();
				if (_body != null)
				{
					_body.transform.SetPositionAndRotation(vector2 + vector + num2 * vector3, Quaternion.Euler(euler) * Quaternion.Euler(num2 * vector4));
					_body.linearVelocity = vector3;
					_body.angularVelocity = vector4;
				}
			}
		}

		private void SerializeWrite(Writer writer)
		{
			writer.WriteSingle(_fsn.PhysicsTime);
			writer.WriteVector3(GameWorld.Instance.FloatingOriginOffset);
			writer.WriteVector3(base.transform.position);
			writer.WriteVector3(base.transform.rotation.eulerAngles);
			writer.WriteVector3(_body.linearVelocity);
			writer.WriteVector3(_body.angularVelocity);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkBodyScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___EarlyAssets_002EScripts_002EMultiplayer_002ENetworkBodyScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
				RegisterServerRpc(0u, RpcReader___Server_DespawnOnServer___2166136261);
				RegisterServerRpc(1u, RpcReader___Server_GiveOwnershipToClient___328543758);
				RegisterObserversRpc(2u, RpcReader___Observers_RpcDataReceivedClient___2713644489);
				RegisterServerRpc(3u, RpcReader___Server_RpcNetworkBodyDataReceived___2713644489);
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkBodyScriptGame_002Edll_Excuted)
			{
				NetworkInitialize___LateAssets_002EScripts_002EMultiplayer_002ENetworkBodyScriptGame_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		private void RpcWriter___Server_DespawnOnServer___2166136261()
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			SendServerRpc(0u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___DespawnOnServer___2166136261()
		{
			Despawn();
		}

		private void RpcReader___Server_DespawnOnServer___2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			if (base.IsServerInitialized)
			{
				RpcLogic___DespawnOnServer___2166136261();
			}
		}

		private void RpcWriter___Server_GiveOwnershipToClient___328543758(NetworkConnection newOwner)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			Channel channel = Channel.Reliable;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteNetworkConnection(newOwner);
			SendServerRpc(1u, pooledWriter, channel, DataOrderType.Default);
			pooledWriter.Store();
		}

		public void RpcLogic___GiveOwnershipToClient___328543758(NetworkConnection P_0)
		{
			Debug.Log($"Giving ownership from {base.OwnerId} to {P_0.ClientId}");
			GiveOwnership(P_0);
		}

		private void RpcReader___Server_GiveOwnershipToClient___328543758(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			NetworkConnection networkConnection = PooledReader0.ReadNetworkConnection();
			if (base.IsServerInitialized)
			{
				RpcLogic___GiveOwnershipToClient___328543758(networkConnection);
			}
		}

		private void RpcWriter___Observers_RpcDataReceivedClient___2713644489(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
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
			SendObserversRpc(2u, pooledWriter, channel2, DataOrderType.Default, bufferLast: true, excludeServer: false, excludeOwner: true, latestOnly: false, runLocally: false);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcDataReceivedClient___2713644489(ArraySegment<byte> P_0, Channel P_1)
		{
			if (!base.IsOwner)
			{
				PooledReader pooledReader = ReaderPool.Retrieve(P_0, base.NetworkManager);
				SerializeRead(pooledReader);
				pooledReader.Store();
			}
		}

		private void RpcReader___Observers_RpcDataReceivedClient___2713644489(PooledReader PooledReader0, Channel channel)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsClientInitialized)
			{
				RpcLogic___RpcDataReceivedClient___2713644489(arraySegment, channel);
			}
		}

		private void RpcWriter___Server_RpcNetworkBodyDataReceived___2713644489(ArraySegment<byte> data, Channel channel = Channel.Unreliable)
		{
			if (!base.IsClientInitialized)
			{
				NetworkManager networkManager = base.NetworkManager;
				networkManager.LogWarning("Cannot complete action because client is not active. This may also occur if the object is not yet initialized, has deinitialized, or if it does not contain a NetworkObject component.");
				return;
			}
			if (!base.IsOwner)
			{
				NetworkManager networkManager2 = base.NetworkManager;
				networkManager2.LogWarning("Cannot complete action because you are not the owner of this object. .");
				return;
			}
			Channel channel2 = channel;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteArraySegmentAndSize(data);
			SendServerRpc(3u, pooledWriter, channel2, DataOrderType.Default);
			pooledWriter.Store();
		}

		private void RpcLogic___RpcNetworkBodyDataReceived___2713644489(ArraySegment<byte> P_0, Channel P_1)
		{
			RpcDataReceivedClient(P_0, P_1);
		}

		private void RpcReader___Server_RpcNetworkBodyDataReceived___2713644489(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
			ArraySegment<byte> arraySegment = PooledReader0.ReadArraySegmentAndSize();
			if (base.IsServerInitialized && OwnerMatches(conn))
			{
				RpcLogic___RpcNetworkBodyDataReceived___2713644489(arraySegment, channel);
			}
		}

		protected virtual void Awake_UserLogic_Assets_002EScripts_002EMultiplayer_002ENetworkBodyScript_Game_002Edll()
		{
			FloatingOriginScript.Instance.Repositioned += FloatingOriginChanged;
		}
	}
}
