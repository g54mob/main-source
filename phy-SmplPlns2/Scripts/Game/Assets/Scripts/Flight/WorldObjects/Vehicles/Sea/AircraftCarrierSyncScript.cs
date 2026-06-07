using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.FlightObjects;
using FishNet.Connection;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Sea
{
	public class AircraftCarrierSyncScript : NetworkFlightObjectComponent
	{
		private enum RpcType
		{
			ArrestingCableState = 0
		}

		[SerializeField]
		private List<ArrestingCable> _arrestingCables;

		public override void Initialize(PooledReader spawnDataReader, PooledReader stateDataReader)
		{
			base.Initialize(spawnDataReader, stateDataReader);
		}

		public override void ReceiveClientRpc(PooledReader data)
		{
			base.ReceiveClientRpc(data);
			if (data.ReadEnum<RpcType>() == RpcType.ArrestingCableState)
			{
				RpcArrestingCableStateRead(data);
			}
		}

		public override void ReceiveServerRpc(PooledReader data, NetworkConnection sender)
		{
			base.ReceiveServerRpc(data, sender);
		}

		public void SynchronizeArrestingCableStatus(ArrestingCable arrestingCable, ArrestingHookScript arrestingHook)
		{
			byte index = (byte)_arrestingCables.IndexOf(arrestingCable);
			using (PooledWriterDisposableWrapper pooledWriter = base.NetworkFlightObject.GetPooledWriter())
			{
				RpcArrestingCableStatusWrite(arrestingHook, index, pooledWriter);
			}
			arrestingCable.SetArrestingHook(arrestingHook, local: true);
		}

		public override void WriteStateInitializationData(PooledWriter writer)
		{
			base.WriteStateInitializationData(writer);
		}

		protected virtual void Start()
		{
			foreach (ArrestingCable arrestingCable in _arrestingCables)
			{
				arrestingCable.InitializeSync(this);
			}
		}

		private void RpcArrestingCableStateRead(PooledReader data)
		{
			byte index = data.ReadUInt8Unpacked();
			ArrestingCable arrestingCable = _arrestingCables[index];
			ArrestingHookScript arrestingHook = null;
			ushort partId = data.ReadUInt16Unpacked();
			if (partId > 0)
			{
				byte playerId = data.ReadUInt8Unpacked();
				FlightScenePlayer flightScenePlayer = FlightSceneScript.Instance.AllPlayers.FirstOrDefault((FlightScenePlayer x) => x.NetworkPlayer.PlayerId == playerId);
				if (flightScenePlayer.Aircraft != null)
				{
					PartData partData = flightScenePlayer.Aircraft.Parts.FirstOrDefault((PartData x) => x.Id == partId);
					if (partData != null)
					{
						arrestingHook = partData.PartScript.GetModifier<ArrestingHookScript>();
					}
				}
			}
			arrestingCable.SetArrestingHook(arrestingHook, local: false);
		}

		private void RpcArrestingCableStatusWrite(ArrestingHookScript arrestingHook, byte index, PooledWriterDisposableWrapper pooledWriter)
		{
			PooledWriter writer = pooledWriter.Writer;
			writer.WriteEnum(RpcType.ArrestingCableState);
			writer.WriteUInt8Unpacked(index);
			if (arrestingHook != null)
			{
				writer.WriteUInt16Unpacked((ushort)arrestingHook.PartScript.Part.Id);
				writer.WriteUInt8Unpacked((byte)arrestingHook.PartScript.Aircraft.NetworkAircraft.PlayerId);
			}
			else
			{
				writer.WriteUInt16Unpacked(0);
			}
			SendObserversRpc(writer.GetArraySegment(), excludeOwner: false);
		}
	}
}
