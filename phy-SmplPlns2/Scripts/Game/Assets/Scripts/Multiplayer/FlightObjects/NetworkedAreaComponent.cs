using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public class NetworkedAreaComponent : NetworkFlightObjectComponent
	{
		private NetworkedAreaScript _area;

		[SerializeField]
		private string _areaName;

		[SerializeField]
		private int _ownerId;

		[SerializeField]
		private int _uniqueId;

		public override void Initialize(PooledReader spawnDataReader, PooledReader stateDataReader)
		{
			base.Initialize(spawnDataReader, stateDataReader);
			_uniqueId = base.NetworkFlightObject.UniqueID;
		}

		public void OnAreaLoaded(NetworkedAreaScript networkedAreaScript, string areaName)
		{
			_area = networkedAreaScript;
			_areaName = areaName;
		}

		public void OnAreaUnloaded(NetworkedAreaScript networkedAreaScript)
		{
			_area = null;
		}

		public override void OnCreated(NetworkFlightObject networkFlightObject)
		{
			base.OnCreated(networkFlightObject);
		}

		public override void OnOwnershipChanged(bool isOwner)
		{
			base.OnOwnershipChanged(isOwner);
			_area?.OnOwnershipChanged(isOwner);
			_ownerId = base.NetworkFlightObject.OwnerId;
		}

		public override void ReadState(PooledReader reader)
		{
			base.ReadState(reader);
			if (reader.ReadBoolean() && _area != null)
			{
				_area.ReadState(reader);
			}
		}

		public override void WriteState(PooledWriter writer)
		{
			base.WriteState(writer);
			bool flag = _area != null;
			writer.WriteBoolean(flag);
			if (flag)
			{
				_area.WriteState(writer);
			}
		}
	}
}
