using System;
using FishNet.Connection;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public abstract class NetworkFlightObjectComponent : MonoBehaviour
	{
		public bool IsOwner => NetworkFlightObject.IsOwner;

		public NetworkFlightObject NetworkFlightObject { get; private set; }

		public virtual void Initialize(PooledReader spawnDataReader, PooledReader stateDataReader)
		{
		}

		public virtual void OnCreated(NetworkFlightObject networkFlightObject)
		{
			NetworkFlightObject = networkFlightObject;
		}

		public virtual void OnOwnershipChanged(bool isOwner)
		{
		}

		public virtual void OnServerObservationStateChanged(bool serverIsObserver)
		{
		}

		public virtual void OnStartClient()
		{
		}

		public virtual void ReadState(PooledReader reader)
		{
		}

		public virtual void ReceiveClientRpc(PooledReader data)
		{
		}

		public virtual void ReceiveServerRpc(PooledReader data, NetworkConnection sender)
		{
		}

		public void SendObserversRpc(ArraySegment<byte> data, bool excludeOwner, bool runLocally = false, int? bufferedRpcId = null, Channel channel = Channel.Reliable)
		{
			NetworkFlightObject.SendComponentRpcObservers(this, data, excludeOwner, runLocally, bufferedRpcId, channel);
		}

		public void SendOwnerRpc(ArraySegment<byte> data, Channel channel = Channel.Reliable)
		{
			NetworkFlightObject.SendComponentRpcOwner(this, data, channel);
		}

		public void SendServerRpc(ArraySegment<byte> data, bool runLocally = false, Channel channel = Channel.Reliable)
		{
			NetworkFlightObject.SendComponentRpcServer(this, data, runLocally, channel);
		}

		public void SendTargetRpc(ArraySegment<byte> data, NetworkConnection target, Channel channel = Channel.Reliable)
		{
			NetworkFlightObject.SendComponentRpcTarget(this, data, target, channel);
		}

		public virtual void WriteState(PooledWriter writer)
		{
		}

		public virtual void WriteStateInitializationData(PooledWriter writer)
		{
		}
	}
}
