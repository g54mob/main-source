using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Events;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Events;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Spawners
{
	public class TrainSpawnerClientScript : NetworkFlightObjectSpawnerClientScript
	{
		[SerializeField]
		private string _spawnerId;

		[SerializeField]
		private string _trackPrefabPath;

		[SerializeField]
		private SpawnRange _spawnRange;

		private List<TrainScript> _trains;

		[SerializeField]
		private List<TrainSpawnData> _trainSpawnData;

		private List<int> _trainUniqueIds;

		public override string SpawnerId => _spawnerId;

		public List<TrainScript> Trains => _trains;

		public override NetworkFlightObjectSpawnerType Type => NetworkFlightObjectSpawnerType.Train;

		public event EventHandler<TrainEventArgs> TrainLoaded;

		public event EventHandler<TrainEventArgs> TrainUnloaded;

		public static TrainSpawnerClientScript Create(GameObject gameObject, string spawnerId, string trackPrefabPath)
		{
			TrainSpawnerClientScript trainSpawnerClientScript = gameObject.AddComponent<TrainSpawnerClientScript>();
			trainSpawnerClientScript._spawnerId = spawnerId;
			trainSpawnerClientScript._trackPrefabPath = trackPrefabPath;
			return trainSpawnerClientScript;
		}

		public TrainScript GetTrainById(int uniqueId)
		{
			foreach (TrainScript train in _trains)
			{
				if (train.NetworkFlightObject.UniqueID == uniqueId)
				{
					return train;
				}
			}
			return null;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if ((object)base.Manager != null)
			{
				base.Manager.ObjectSpawned -= OnObjectSpawned;
				base.Manager.ObjectDespawned -= OnObjectDespawned;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_trainUniqueIds = new List<int>(_trainSpawnData.Count);
			_trains = new List<TrainScript>(_trainSpawnData.Count);
			foreach (TrainSpawnData trainSpawnDatum in _trainSpawnData)
			{
				_trainUniqueIds.Add(base.Manager.GetUniqueId(trainSpawnDatum.Id));
			}
			base.Manager.ObjectSpawned += OnObjectSpawned;
			base.Manager.ObjectDespawned += OnObjectDespawned;
			foreach (int trainUniqueId in _trainUniqueIds)
			{
				NetworkFlightObject flightObjectByID = base.Manager.GetFlightObjectByID(trainUniqueId);
				if (flightObjectByID != null)
				{
					OnObjectSpawned(this, new NetworkFlightObjectEventArgs(flightObjectByID));
				}
			}
		}

		protected override void WriteSpawnerData(PooledWriter data)
		{
			data.WriteString(_trackPrefabPath);
			_spawnRange.Write(data);
			data.WriteVector3(Utility.ConvertFloatingOriginToAbsolutePosition(base.transform.position));
			data.WriteQuaternion32(base.transform.rotation);
			data.WriteUInt8Unpacked((byte)_trainSpawnData.Count);
			foreach (TrainSpawnData trainSpawnDatum in _trainSpawnData)
			{
				trainSpawnDatum.Write(data);
			}
		}

		private void OnObjectDespawned(object sender, NetworkFlightObjectEventArgs e)
		{
			int uniqueID = e.Object.UniqueID;
			if (_trainUniqueIds.Contains(uniqueID))
			{
				TrainScript trainById = GetTrainById(uniqueID);
				if (trainById == null)
				{
					Debug.LogError($"Train spawner '{_spawnerId}' was notified of the despawning of a train with id '{uniqueID}' but the TrainScript could not be found by id.");
				}
				else if (!_trains.Remove(trainById))
				{
					Debug.LogError($"Train spawner '{_spawnerId}' was notified of the despawning of a train with id '{uniqueID}' but the TrainScript could not be removed.");
				}
				else
				{
					this.TrainUnloaded?.Invoke(this, new TrainEventArgs(trainById));
				}
			}
		}

		private void OnObjectSpawned(object sender, NetworkFlightObjectEventArgs e)
		{
			int uniqueID = e.Object.UniqueID;
			if (_trainUniqueIds.Contains(uniqueID))
			{
				TrainScript networkFlightObjectComponent = e.Object.GetNetworkFlightObjectComponent<TrainScript>();
				if (networkFlightObjectComponent == null)
				{
					Debug.LogError($"Train spawner '{_spawnerId}' was notified of the spawning of a train with id '{uniqueID}' but no TrainScript was found on the flight object.");
				}
				_trains.Add(networkFlightObjectComponent);
				this.TrainLoaded?.Invoke(this, new TrainEventArgs(networkFlightObjectComponent));
			}
		}
	}
}
