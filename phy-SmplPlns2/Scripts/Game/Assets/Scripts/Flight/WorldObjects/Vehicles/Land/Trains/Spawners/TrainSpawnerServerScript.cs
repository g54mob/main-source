using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Extensions;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Events;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners;
using Assets.Scripts.Multiplayer.ObserverConditions;
using Dreamteck.Splines;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Spawners
{
	public class TrainSpawnerServerScript : NetworkFlightObjectSpawnerServerScript
	{
		[Serializable]
		private class ActiveTrain
		{
			[SerializeField]
			private double _trackVelocity;

			[SerializeField]
			private TrainDefinition _trainDefinition;

			[SerializeField]
			private int _uniqueId;

			[field: SerializeField]
			public bool SpawnPending { get; set; }

			public Vector3 SpawnPosition { get; set; }

			[field: SerializeField]
			public double TrackPosition { get; set; }

			[field: SerializeField]
			public double TrackPositionUpdateTime { get; set; }

			public double TrackVelocity => _trackVelocity;

			public TrainDefinition TrainDefinition => _trainDefinition;

			[field: SerializeField]
			public TrainScript TrainScript { get; set; }

			public int UniqueId => _uniqueId;

			public ActiveTrain(int uniqueId, TrainDefinition def, double trackLength)
			{
				_uniqueId = uniqueId;
				_trainDefinition = def;
				_trackVelocity = (double)def.TargetSpeed / trackLength;
				TrackPosition = def.TrackPosition;
				TrackPositionUpdateTime = Time.realtimeSinceStartupAsDouble;
			}
		}

		[SerializeField]
		private List<int> _objectUniqueIds;

		private float _spawnDistanceSquared;

		[SerializeField]
		private SpawnRange _spawnRange;

		[SerializeField]
		private Vector3 _trackGlobalPosition;

		[SerializeField]
		private Quaternion _trackGlobalRotation;

		private double _trackLength;

		[SerializeField]
		private string _trackPrefabPath;

		[SerializeField]
		private SplineComputer _trackSpline;

		[SerializeField]
		private ActiveTrain[] _trains;

		[SerializeField]
		private List<TrainSpawnData> _trainSpawnData;

		public SplineComputer TrackSpline => _trackSpline;

		public override void UpdateSpawner()
		{
			if (!base.gameObject.activeSelf)
			{
				return;
			}
			for (int i = 0; i < _trains.Length; i++)
			{
				ActiveTrain activeTrain = _trains[i];
				if (activeTrain == null)
				{
					if (IsDisabled(_objectUniqueIds[i]))
					{
						continue;
					}
					activeTrain = CreateTrain(i);
				}
				if (activeTrain.SpawnPending)
				{
					continue;
				}
				if (activeTrain.TrainScript != null)
				{
					activeTrain.TrackPositionUpdateTime = Time.realtimeSinceStartupAsDouble;
					activeTrain.TrackPosition = activeTrain.TrainScript.Locomotive.TrackPosition;
					if (!(activeTrain.TrainScript.Track == null))
					{
						continue;
					}
					foreach (TrainCarScript trainCar in activeTrain.TrainScript.TrainCars)
					{
						Vector3 positionFromTrack = GetPositionFromTrack(trainCar.TrackPosition);
						trainCar.transform.position = positionFromTrack;
					}
				}
				else
				{
					if (IsDisabled(activeTrain.UniqueId))
					{
						continue;
					}
					double trackPositionUpdateTime = activeTrain.TrackPositionUpdateTime;
					activeTrain.TrackPositionUpdateTime = Time.realtimeSinceStartupAsDouble;
					activeTrain.TrackPosition = (activeTrain.TrackPosition + activeTrain.TrackVelocity * (activeTrain.TrackPositionUpdateTime - trackPositionUpdateTime)) % 1.0;
					Vector3 positionFromTrack2 = GetPositionFromTrack(activeTrain.TrackPosition);
					NetworkPlayerScript closestClientInRange = GetClosestClientInRange(positionFromTrack2, _spawnDistanceSquared);
					if (closestClientInRange != null)
					{
						activeTrain.SpawnPending = true;
						string prefabPath = activeTrain.TrainDefinition.Locomotive.GetPrefabPath();
						string path = "Flight/WorldObjects/Vehicles/Land/Trains/Locomotives/" + prefabPath;
						NetworkFlightObject networkFlightObject = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkFlightObject>(path);
						using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = networkFlightObject.GetPooledWriter();
						activeTrain.SpawnPosition = positionFromTrack2;
						activeTrain.TrainDefinition.TrackPosition = activeTrain.TrackPosition;
						activeTrain.TrainDefinition.NetworkSerialize(pooledWriterDisposableWrapper);
						ArraySegment<byte> arraySegment = pooledWriterDisposableWrapper.Writer.GetArraySegment();
						base.Manager.Server.Spawn(networkFlightObject, arraySegment, null, activeTrain.UniqueId, closestClientInRange.Owner);
					}
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
			base.Manager.ObjectSpawning += OnObjectSpawning;
			base.Manager.ObjectDespawned += OnObjectDespawned;
		}

		protected override void ReadSpawnerData(PooledReader data)
		{
			_trackPrefabPath = "Flight/WorldObjects/Vehicles/Land/Trains/Tracks/" + data.ReadStringAllocated();
			_spawnRange = SpawnRange.Read(data);
			_trackGlobalPosition = data.ReadVector3();
			_trackGlobalRotation = data.ReadQuaternion32();
			byte b = data.ReadUInt8Unpacked();
			_objectUniqueIds = new List<int>(b);
			_trainSpawnData = new List<TrainSpawnData>(b);
			_trains = new ActiveTrain[b];
			for (int i = 0; i < b; i++)
			{
				TrainSpawnData trainSpawnData = TrainSpawnData.Read(data);
				_trainSpawnData.Add(trainSpawnData);
				_objectUniqueIds.Add(base.Manager.GetUniqueId(trainSpawnData.Id));
			}
			_trackSpline = Game.Instance.ResourceLoader.InstantiatePrefab<SplineComputer>(_trackPrefabPath);
			if (_trackSpline == null)
			{
				Debug.LogError("Track Spline '" + _trackPrefabPath + "' could not be loaded. The train spawner will be disabled.");
				base.gameObject.SetActive(value: false);
				return;
			}
			_trackSpline.transform.SetParent(base.transform);
			_trackSpline.transform.SetLocalPositionAndRotation(Vector3.zero, _trackGlobalRotation);
			_trackSpline.space = SplineComputer.Space.Local;
			_trackLength = _trackSpline.CalculateLength();
			_spawnDistanceSquared = _spawnRange.SpawnDistance * _spawnRange.SpawnDistance;
		}

		private double CalculateTrackPositionForNewTrain()
		{
			SortedList<double, double> sortedList = new SortedList<double, double>(_trains.Length);
			for (int i = 0; i < _trains.Length; i++)
			{
				double? num = _trains[i]?.TrackPosition;
				if (num.HasValue)
				{
					sortedList.Add(num.Value, num.Value);
				}
			}
			if (sortedList.Count == 0)
			{
				return UnityEngine.Random.Range(0f, 1f);
			}
			IList<double> values = sortedList.Values;
			int num2 = sortedList.Count - 1;
			(double, double) tuple = (0.0, 0.0);
			for (int j = 0; j <= num2; j++)
			{
				double num3 = ((j == num2) ? (values[0] + 1.0) : values[j + 1]) - values[j];
				if (num3 > tuple.Item2)
				{
					tuple = (values[j], num3);
				}
			}
			double num4 = Math.Min(1.0 / (double)_trainSpawnData.Count, tuple.Item2);
			return (tuple.Item1 + num4) % 1.0;
		}

		private ActiveTrain CreateTrain(int trainIndex)
		{
			TrainDefinition trainDefinition = _trainSpawnData[trainIndex].BuildTrain();
			trainDefinition.TrackPosition = CalculateTrackPositionForNewTrain();
			ActiveTrain activeTrain = new ActiveTrain(_objectUniqueIds[trainIndex], trainDefinition, _trackLength);
			_trains[trainIndex] = activeTrain;
			return activeTrain;
		}

		private Vector3 GetPositionFromTrack(double trackPosition)
		{
			Vector3 position = _trackSpline.EvaluatePosition(trackPosition);
			return Utility.ConvertAbsoluteToFloatingOriginPosition(_trackSpline.transform.TransformPoint(position) + _trackGlobalPosition);
		}

		private bool IsDisabled(int trainUniqueId)
		{
			return base.Manager.Server.ObjectSpawnDisabledUniqueIds.Contains(trainUniqueId);
		}

		private void OnObjectDespawned(object sender, NetworkFlightObjectEventArgs e)
		{
			for (int i = 0; i < _trains.Length; i++)
			{
				ActiveTrain activeTrain = _trains[i];
				if (activeTrain?.UniqueId == e.Object.UniqueID)
				{
					if (activeTrain.TrainScript.Locomotive.Derailed)
					{
						_trains[i] = null;
					}
					activeTrain.SpawnPending = false;
					activeTrain.TrainScript = null;
				}
			}
		}

		private void OnObjectSpawning(object sender, NetworkFlightObjectEventArgs e)
		{
			ActiveTrain[] trains = _trains;
			foreach (ActiveTrain activeTrain in trains)
			{
				if (activeTrain?.UniqueId == e.Object.UniqueID)
				{
					activeTrain.SpawnPending = false;
					activeTrain.TrainScript = e.Object.GetComponent<TrainScript>();
					DistanceFromPlayerObserverCondition distanceFromPlayerObserverCondition = e.Object.NetworkObserver.GetObserverCondition<DistanceFromPlayerObserverCondition>() as DistanceFromPlayerObserverCondition;
					if (distanceFromPlayerObserverCondition != null)
					{
						distanceFromPlayerObserverCondition.ObserveDistance = _spawnRange.SpawnDistance;
						distanceFromPlayerObserverCondition.HideDistance = _spawnRange.DespawnDistance;
					}
					Transform obj = e.Object.transform;
					obj.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
					obj.position = activeTrain.SpawnPosition;
				}
			}
		}
	}
}
