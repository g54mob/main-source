using System;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.FlightObjects.Events;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners.Events;
using Assets.Scripts.Multiplayer.ObserverConditions;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners
{
	public class SimpleSpawnerServerScript : NetworkFlightObjectSpawnerServerScript
	{
		[SerializeField]
		private Vector3 _globalPosition;

		private Quaternion _globalRotation;

		[SerializeField]
		private NetworkFlightObject _loadedObject;

		private float _minimumNextSpawnTime;

		private bool _objectSpawnDisabled;

		[SerializeField]
		private int _objectUniqueId;

		[SerializeField]
		private string _prefabPath;

		[SerializeField]
		private Dictionary<string, string> _spawnData;

		private float _spawnDistanceSquared;

		private bool _spawnPending;

		[SerializeField]
		private SpawnRange _spawnRange;

		public Vector3 GlobalPosition => _globalPosition;

		public Quaternion GlobalRotation => _globalRotation;

		public NetworkFlightObject LoadedObject => _loadedObject;

		public int ObjectUniqueId => _objectUniqueId;

		public string PrefabPath => _prefabPath;

		public SpawnRange SpawnRange => _spawnRange;

		public override void UpdateSpawner()
		{
			if (!_objectSpawnDisabled && !_spawnPending && !(_loadedObject != null) && !(Time.time < _minimumNextSpawnTime))
			{
				Vector3 position = Utility.ConvertAbsoluteToFloatingOriginPosition(_globalPosition);
				NetworkPlayerScript closestClientInRange = GetClosestClientInRange(position, _spawnDistanceSquared);
				if (closestClientInRange != null)
				{
					_spawnPending = true;
					NetworkFlightObject networkFlightObject = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkFlightObject>(_prefabPath);
					Transform obj = networkFlightObject.transform;
					obj.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
					obj.SetPositionAndRotation(Utility.ConvertAbsoluteToFloatingOriginPosition(_globalPosition), _globalRotation);
					base.Manager.Server.Spawn(networkFlightObject, ArraySegment<byte>.Empty, _spawnData, _objectUniqueId, closestClientInRange.Owner);
				}
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if ((object)base.Manager != null)
			{
				base.Manager.ObjectSpawning -= OnObjectSpawning;
				base.Manager.ObjectDespawned -= OnObjectDespawned;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_objectUniqueId = base.SpawnerId;
			base.Manager.ObjectSpawning += OnObjectSpawning;
			base.Manager.ObjectDespawned += OnObjectDespawned;
			NetworkFlightObject flightObjectByID = base.Manager.GetFlightObjectByID(_objectUniqueId);
			if (flightObjectByID != null)
			{
				OnObjectSpawning(this, new NetworkFlightObjectEventArgs(flightObjectByID));
			}
		}

		protected override void OnObjectSpawnEnabledStateChanged(object sender, ObjectSpawnEnabledStateChangedEventArgs e)
		{
			base.OnObjectSpawnEnabledStateChanged(sender, e);
			if (e.ObjectUniqueId == _objectUniqueId)
			{
				_objectSpawnDisabled = !e.Enabled;
			}
		}

		protected override void ReadSpawnerData(PooledReader data)
		{
			_prefabPath = data.ReadStringAllocated();
			_spawnRange = SpawnRange.Read(data);
			_globalPosition = data.ReadVector3();
			_globalRotation = data.ReadQuaternion32();
			_spawnDistanceSquared = _spawnRange.SpawnDistance * _spawnRange.SpawnDistance;
			ReadSpawnerDataKeyValuePairs(data, _spawnData ?? (_spawnData = new Dictionary<string, string>()));
		}

		private void OnObjectDespawned(object sender, NetworkFlightObjectEventArgs e)
		{
			if (e.Object.UniqueID == _objectUniqueId)
			{
				_loadedObject = null;
				_spawnPending = false;
				_minimumNextSpawnTime = Time.time + 5f;
			}
		}

		private void OnObjectSpawning(object sender, NetworkFlightObjectEventArgs e)
		{
			if (e.Object.UniqueID == _objectUniqueId)
			{
				_loadedObject = e.Object;
				_spawnPending = false;
				DistanceFromPlayerObserverCondition distanceFromPlayerObserverCondition = e.Object.NetworkObserver.GetObserverCondition<DistanceFromPlayerObserverCondition>() as DistanceFromPlayerObserverCondition;
				if (distanceFromPlayerObserverCondition != null)
				{
					distanceFromPlayerObserverCondition.ObserveDistance = _spawnRange.SpawnDistance;
					distanceFromPlayerObserverCondition.HideDistance = _spawnRange.DespawnDistance;
				}
			}
		}
	}
}
