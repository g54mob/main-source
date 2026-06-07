using System;
using Assets.Scripts.Flight.Discoverables;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.FlightObjects;
using FishNet.Connection;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Sea
{
	public class NetworkedShipScript : NetworkFlightObjectComponent
	{
		private enum RpcType : byte
		{
			Sink = 0
		}

		private SinkableShipScript _sinkableShip;

		private bool? _sinkCriticalDamage;

		private Vector3? _sinkPosition;

		public override void Initialize(PooledReader spawnDataReader, PooledReader stateDataReader)
		{
			base.Initialize(spawnDataReader, stateDataReader);
			if (base.NetworkFlightObject.IsServerStarted)
			{
				base.NetworkFlightObject.UnregisterResettableObject();
			}
			if (TryGetComponent<AreaNameScript>(out var component) && base.NetworkFlightObject.SpawnData.TryGetValue("AreaName", out var value))
			{
				component.AreaName = value;
			}
		}

		public override void ReceiveClientRpc(PooledReader data)
		{
			base.ReceiveClientRpc(data);
			ProcessRpc(data, isServerRpc: false);
		}

		public override void ReceiveServerRpc(PooledReader data, NetworkConnection sender)
		{
			base.ReceiveServerRpc(data, sender);
			ProcessRpc(data, isServerRpc: true);
		}

		public void Sink(Vector3 sinkPosition, bool critical)
		{
			_sinkPosition = sinkPosition;
			_sinkCriticalDamage = critical;
			using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = base.NetworkFlightObject.GetPooledWriter();
			PooledWriter writer = pooledWriterDisposableWrapper.Writer;
			writer.WriteEnum(RpcType.Sink);
			writer.WriteVector3(sinkPosition);
			writer.WriteBoolean(critical);
			SendServerRpc(writer.GetArraySegment());
		}

		protected virtual void Awake()
		{
			_sinkableShip = GetComponent<SinkableShipScript>();
		}

		private void ProcessRpc(PooledReader data, bool isServerRpc)
		{
			RpcType rpcType = data.ReadEnum<RpcType>();
			if (rpcType == RpcType.Sink)
			{
				ProcessSinkRpc(data, isServerRpc);
				return;
			}
			throw new NotSupportedException($"Unknown RPC type: '{rpcType}'");
		}

		private void ProcessSinkRpc(PooledReader data, bool isServerRpc)
		{
			if (isServerRpc)
			{
				using (PooledWriterDisposableWrapper pooledWriterDisposableWrapper = base.NetworkFlightObject.GetPooledWriter())
				{
					PooledWriter writer = pooledWriterDisposableWrapper.Writer;
					writer.WriteEnum(RpcType.Sink);
					writer.WriteArraySegment(data.GetRemainingData());
					SendObserversRpc(writer.GetArraySegment(), excludeOwner: true, runLocally: false, 0);
					return;
				}
			}
			_sinkPosition = data.ReadVector3();
			_sinkCriticalDamage = data.ReadBoolean();
			_sinkableShip.Sink(_sinkPosition.Value, _sinkCriticalDamage.Value);
		}
	}
}
