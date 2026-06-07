using System;
using System.Collections.Generic;
using Assets.Scripts.Multiplayer.FlightObjects.Events;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners.Events;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners
{
	public class SimpleSpawnerClientScript : NetworkFlightObjectSpawnerClientScript
	{
		[Serializable]
		private class StringKeyValuePair
		{
			public string Key;

			public string Value;
		}

		private int _objectUniqueId;

		[SerializeField]
		private string _prefabPath;

		[SerializeField]
		private List<StringKeyValuePair> _spawnData;

		[SerializeField]
		private string _spawnerId;

		[SerializeField]
		private SpawnRange _spawnRange;

		public int ObjectUniqueId => _objectUniqueId;

		public override string SpawnerId => _spawnerId;

		public override NetworkFlightObjectSpawnerType Type => NetworkFlightObjectSpawnerType.Simple;

		public event EventHandler<NetworkFlightObjectSpawnEventArgs> ObjectLoaded;

		public event EventHandler<NetworkFlightObjectSpawnEventArgs> ObjectUnloaded;

		protected override Dictionary<string, string> GetSpawnerDataKeyValuePairs()
		{
			Dictionary<string, string> dictionary = base.GetSpawnerDataKeyValuePairs();
			List<StringKeyValuePair> spawnData = _spawnData;
			if (spawnData != null && spawnData.Count > 0)
			{
				if (dictionary == null)
				{
					dictionary = new Dictionary<string, string>();
				}
				foreach (StringKeyValuePair spawnDatum in _spawnData)
				{
					dictionary[spawnDatum.Key] = spawnDatum.Value;
				}
			}
			return dictionary;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if ((object)base.Manager != null)
			{
				base.Manager.ObjectSpawning -= OnObjectSpawning;
				base.Manager.ObjectSpawned -= OnObjectSpawned;
				base.Manager.ObjectDespawned -= OnObjectDespawned;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_objectUniqueId = base.Manager.GetUniqueId(SpawnerId);
			base.Manager.ObjectSpawning += OnObjectSpawning;
			base.Manager.ObjectSpawned += OnObjectSpawned;
			base.Manager.ObjectDespawned += OnObjectDespawned;
			NetworkFlightObject flightObjectByID = base.Manager.GetFlightObjectByID(_objectUniqueId);
			if (flightObjectByID != null)
			{
				OnObjectSpawning(this, new NetworkFlightObjectEventArgs(flightObjectByID));
				OnObjectSpawned(this, new NetworkFlightObjectEventArgs(flightObjectByID));
			}
		}

		protected override void WriteSpawnerData(PooledWriter data)
		{
			data.WriteString(_prefabPath);
			_spawnRange.Write(data);
			data.WriteVector3(Utility.ConvertFloatingOriginToAbsolutePosition(base.transform.position));
			data.WriteQuaternion32(base.transform.rotation);
			Dictionary<string, string> spawnerDataKeyValuePairs = GetSpawnerDataKeyValuePairs();
			WriteSpawnerDataKeyValuePairs(data, spawnerDataKeyValuePairs);
		}

		private void OnObjectDespawned(object sender, NetworkFlightObjectEventArgs e)
		{
			if (e.Object.UniqueID == _objectUniqueId)
			{
				this.ObjectUnloaded?.Invoke(this, new NetworkFlightObjectSpawnEventArgs(e.Object.UniqueID, e.Object, this));
			}
		}

		private void OnObjectSpawned(object sender, NetworkFlightObjectEventArgs e)
		{
			if (e.Object.UniqueID == _objectUniqueId)
			{
				this.ObjectLoaded?.Invoke(this, new NetworkFlightObjectSpawnEventArgs(e.Object.UniqueID, e.Object, this));
			}
		}

		private void OnObjectSpawning(object sender, NetworkFlightObjectEventArgs e)
		{
			_ = e.Object.UniqueID;
			_ = _objectUniqueId;
		}
	}
}
