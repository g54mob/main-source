using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Environment.Roads;
using Assets.Scripts.Environment.Roads.Data;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using FishNet.Serializing;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public class NetworkFlightObjectVehicleScript : NetworkFlightObjectComponent, INetworkVehicle
	{
		private struct FutureWaypoint
		{
			public bool ReversePath { get; set; }

			public RoadNetworkWaypoints.RoadWaypoint Waypoint { get; set; }
		}

		private int _currentWaypointID;

		private bool _despawning;

		[SerializeField]
		private GameObject _fireParticlesPrefab;

		private Queue<FutureWaypoint> _futureWaypoints = new Queue<FutureWaypoint>();

		[SerializeField]
		private float _laneSwitchPressure;

		private float _ownershipChangedTime;

		private int _preferredLane;

		[SerializeField]
		private GameObject _smokeParticlesPrefab;

		private float _speedVariation = 1f;

		private GameObject _sphere;

		private float _stuckTimer;

		private float _switchLanesTime;

		private Transform _targetTransform;

		private SimpleGroundVehicleScript _vehicle;

		private RoadNetworkWaypoints.RoadWaypoint _waypoint;

		public bool IsReversePath { get; private set; }

		public int OwnerId => base.NetworkFlightObject.OwnerId;

		public int StartingWaypointID { get; private set; }

		public Transform Transform => base.transform;

		private RoadNetworkWaypoints Waypoints => FlightSceneScript.Instance.CarSpawner.Waypoints;

		public void Despawn()
		{
			if (!_despawning)
			{
				_despawning = true;
				base.enabled = false;
				StartingWaypointID = 0;
				_waypoint = null;
				base.NetworkFlightObject.DespawnObject();
			}
		}

		public override void Initialize(PooledReader spawnDataReader, PooledReader stateDataReader)
		{
			base.Initialize(spawnDataReader, stateDataReader);
			StartingWaypointID = spawnDataReader.ReadInt32();
			IsReversePath = spawnDataReader.ReadBoolean();
			byte carType = spawnDataReader.ReadUInt8Unpacked();
			float colorValue = spawnDataReader.ReadSingle();
			base.name = (base.IsOwner ? $"NetworkVehicle_Local_{OwnerId}" : $"NetworkVehicle_Remote_{OwnerId}");
			LoadCar(carType, colorValue);
			float num = Random.value - 0.75f + 0.25f * _vehicle.SpeedFactor;
			_speedVariation = 1f + num * num * num;
			_preferredLane = ((_speedVariation > 1.05f) ? 1 : 0);
			GameWorld.Instance.FloatingOriginChanged += OnFloatingOriginChanged;
		}

		public override void OnCreated(NetworkFlightObject networkFlightObject)
		{
			base.OnCreated(networkFlightObject);
		}

		public override void OnOwnershipChanged(bool isOwner)
		{
			base.OnOwnershipChanged(isOwner);
			_ownershipChangedTime = Time.time;
			if (_vehicle != null)
			{
				_vehicle.IsOwner = isOwner;
			}
			if (isOwner && _currentWaypointID > 0)
			{
				RoadNetworkWaypoints.RoadWaypoint waypointById = Waypoints.GetWaypointById(_currentWaypointID);
				SetWaypoint(waypointById);
			}
		}

		public override void ReadState(PooledReader reader)
		{
			StartingWaypointID = 0;
			_currentWaypointID = reader.ReadInt32();
			IsReversePath = reader.ReadBoolean();
			_preferredLane = reader.ReadUInt8Unpacked();
		}

		public override void WriteState(PooledWriter writer)
		{
			writer.WriteInt32(_currentWaypointID);
			writer.WriteBoolean(IsReversePath);
			writer.WriteUInt8Unpacked((byte)_preferredLane);
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (base.IsOwner)
			{
				NetworkAircraftScript networkAircraftScript = collision.rigidbody?.GetComponentInParent<NetworkAircraftScript>();
				if (networkAircraftScript != null && networkAircraftScript.OwnerId != OwnerId && Time.time - _ownershipChangedTime > 5f)
				{
					_ownershipChangedTime = Time.time;
					base.NetworkFlightObject.GiveOwnershipToClient(networkAircraftScript.Owner);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			GameWorld.Instance.FloatingOriginChanged -= OnFloatingOriginChanged;
			FlightSceneScript.Instance.CarSpawner.UnregisterCar(this);
			if (_targetTransform != null)
			{
				Object.Destroy(_targetTransform.gameObject);
				_targetTransform = null;
			}
		}

		protected virtual void Update()
		{
			if (!base.IsOwner)
			{
				return;
			}
			if (_waypoint == null)
			{
				if (StartingWaypointID > 0)
				{
					RoadNetworkWaypoints.RoadWaypoint waypointById = Waypoints.GetWaypointById(StartingWaypointID);
					waypointById = FlightSceneScript.Instance.CarSpawner.SelectBestWaypoint(this, waypointById, IsReversePath);
					if (waypointById != null)
					{
						Vector3 vector = Waypoints.WaypointToWorldPosition(waypointById.GetLanePosition(IsReversePath, _preferredLane));
						float spawnRaycastHeight = waypointById.Segment.RoadType.spawnRaycastHeight;
						if (spawnRaycastHeight > 0f)
						{
							if (Physics.Raycast(new Ray(vector + Vector3.up * spawnRaycastHeight, Vector3.down), out var hitInfo, spawnRaycastHeight, 4096))
							{
								vector = hitInfo.point;
							}
							else
							{
								Debug.Log($"Could not find a raycast hit for waypoint {waypointById.Id} on road {waypointById.Segment.Name}");
							}
						}
						base.transform.position = vector;
						SetWaypoint(waypointById);
						_vehicle.RigidBody.linearVelocity = base.transform.forward * waypointById.Segment.Speed;
						StartingWaypointID = 0;
					}
					else
					{
						Despawn();
					}
				}
				else
				{
					Despawn();
				}
			}
			else if (Mathf.Abs(_vehicle.ForwardVelocity) <= 2f)
			{
				if (_vehicle.IsDestroyed || !_vehicle.IsBlocked)
				{
					_stuckTimer += Time.deltaTime;
				}
				else if (_vehicle.IsBlocked)
				{
					_stuckTimer += Time.deltaTime * 0.1f;
				}
				if (_stuckTimer > 10f)
				{
					Despawn();
				}
			}
			else
			{
				if (_vehicle.IsBlocked)
				{
					_laneSwitchPressure += Time.deltaTime;
				}
				else if (_laneSwitchPressure > 0f)
				{
					_laneSwitchPressure -= Time.deltaTime * 0.05f;
				}
				if (_laneSwitchPressure > 0.25f && _waypoint.Segment.RoadType.numLanes > 1)
				{
					SwitchLanes();
					_laneSwitchPressure = 0f;
				}
				_stuckTimer = 0f;
			}
		}

		private static RoadNetworkWaypoints.RoadConnection ChooseRandomConnection(RoadNetworkWaypoints.RoadWaypoint waypoint, RoadNetworkData.RoadConnectionDirection direction, int preferredLane)
		{
			float num = 0f;
			List<RoadNetworkWaypoints.RoadConnection> value;
			using (CollectionPool<List<RoadNetworkWaypoints.RoadConnection>, RoadNetworkWaypoints.RoadConnection>.Get(out value))
			{
				foreach (RoadNetworkWaypoints.RoadConnection roadConnection in waypoint.RoadConnections)
				{
					if (roadConnection.Direction == direction && (roadConnection.EntryLane == -1 || roadConnection.EntryLane == preferredLane))
					{
						num += roadConnection.Probability;
						value.Add(roadConnection);
					}
				}
				if (value.Count > 0)
				{
					float num2 = Random.value * num;
					foreach (RoadNetworkWaypoints.RoadConnection item in value)
					{
						if (num2 < item.Probability)
						{
							return item;
						}
						num2 -= item.Probability;
					}
				}
				else
				{
					Debug.LogWarning($"Car couldn't find random connection from road segment {waypoint?.Segment?.Name}, waypoint ID {waypoint?.Id}");
				}
				return value.FirstOrDefault();
			}
		}

		private static FutureWaypoint? GetNextFutureWaypoint(RoadNetworkWaypoints.RoadWaypoint waypoint, bool reversePath, int preferredLane)
		{
			RoadNetworkData.RoadConnectionDirection roadConnectionDirection = (reversePath ? RoadNetworkData.RoadConnectionDirection.Reverse : RoadNetworkData.RoadConnectionDirection.Forward);
			RoadNetworkWaypoints.RoadWaypoint roadWaypoint = ((!reversePath) ? waypoint?.Next : waypoint?.Previous);
			if (roadWaypoint != null)
			{
				RoadNetworkWaypoints.RoadConnection roadConnection = null;
				foreach (RoadNetworkWaypoints.RoadConnection roadConnection3 in waypoint.RoadConnections)
				{
					if (roadConnection3.Direction == roadConnectionDirection && (roadConnection3.EntryLane == -1 || roadConnection3.EntryLane == preferredLane))
					{
						roadConnection = roadConnection3;
						break;
					}
				}
				if (roadConnection != null && Random.value < roadConnection.Probability)
				{
					return new FutureWaypoint
					{
						Waypoint = roadConnection.Waypoint,
						ReversePath = roadConnection.Reversed
					};
				}
			}
			else if (roadWaypoint == null && waypoint != null && waypoint.RoadConnections.Count > 0)
			{
				RoadNetworkWaypoints.RoadConnection roadConnection2 = ChooseRandomConnection(waypoint, roadConnectionDirection, preferredLane);
				if (roadConnection2 != null)
				{
					return new FutureWaypoint
					{
						Waypoint = roadConnection2.Waypoint,
						ReversePath = roadConnection2.Reversed
					};
				}
			}
			if (roadWaypoint != null)
			{
				return new FutureWaypoint
				{
					Waypoint = roadWaypoint,
					ReversePath = reversePath
				};
			}
			return null;
		}

		private void LoadCar(byte carType, float colorValue)
		{
			CarSpawnerScript carSpawner = FlightSceneScript.Instance.CarSpawner;
			Object.Instantiate(carSpawner.GetCarPrefab(carType), base.transform);
			LayerUtility.SetLayerRecursive(base.gameObject, base.gameObject.layer);
			VehicleInfoScript componentInChildren = base.gameObject.GetComponentInChildren<VehicleInfoScript>(includeInactive: true);
			_vehicle = componentInChildren.CreateDrivingCar(GetComponent<Rigidbody>(), _smokeParticlesPrefab, _fireParticlesPrefab, colorValue, carSpawner.CarLightMaterials);
			_vehicle.NavigationTargetDistanceThreshold = 5f;
			_vehicle.InitializeDamgeReceiver().Initialize(0, GetComponent<NetworkFlightObjectDamageScript>());
			_vehicle.NavigationTargetReached += OnNavigationTargetReached;
			_vehicle.IsOwner = base.IsOwner;
			carSpawner.RegisterCar(this);
			_vehicle.ProcessObscrution = delegate(RaycastHit hitinfo)
			{
				bool result = true;
				if (hitinfo.collider.gameObject.layer == 13)
				{
					NetworkFlightObjectVehicleScript componentInParent = hitinfo.collider.GetComponentInParent<NetworkFlightObjectVehicleScript>();
					if (componentInParent != null && _waypoint?.Segment != null)
					{
						bool flag = _waypoint.Segment.RoadType.numLanes == 1 || componentInParent._preferredLane == _preferredLane || Time.time < _switchLanesTime;
						bool flag2 = componentInParent.IsReversePath == IsReversePath;
						result = hitinfo.distance < 20f || (flag && flag2);
					}
				}
				return result;
			};
		}

		private void OnFloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			if (_targetTransform != null)
			{
				_targetTransform.position += e.Delta;
			}
		}

		private void OnNavigationTargetReached(object sender, ConvoyNavigationTargetReachedEventArgs e)
		{
			if (base.IsOwner && _futureWaypoints.Count > 0)
			{
				FutureWaypoint futureWaypoint = _futureWaypoints.Dequeue();
				IsReversePath = futureWaypoint.ReversePath;
				SetWaypoint(futureWaypoint.Waypoint);
			}
		}

		private void SetWaypoint(RoadNetworkWaypoints.RoadWaypoint waypoint)
		{
			if (!base.NetworkFlightObject.IsOwner)
			{
				return;
			}
			_waypoint = waypoint;
			_currentWaypointID = waypoint?.Id ?? 0;
			if (_waypoint != null)
			{
				if (_targetTransform == null)
				{
					_targetTransform = new GameObject("Car Target").transform;
					_targetTransform.parent = base.transform.parent;
				}
				Vector3 forward = _waypoint.Forward;
				if (forward.sqrMagnitude < 0.1f)
				{
					forward = Vector3.forward;
				}
				_targetTransform.SetPositionAndRotation(Waypoints.WaypointToWorldPosition(_waypoint.GetLanePosition(IsReversePath, _preferredLane)), Quaternion.LookRotation(IsReversePath ? (-forward) : forward, Vector3.up));
			}
			else if (_targetTransform != null)
			{
				Object.Destroy(_targetTransform.gameObject);
				_targetTransform = null;
			}
			_vehicle.NavigationTarget = _targetTransform;
			UpdateFutureWaypoints(3);
			UpdateTargetSpeed();
		}

		private void SwitchLanes()
		{
			if (Time.time > _switchLanesTime)
			{
				if (Random.value > 0.5f)
				{
					_preferredLane = ((_preferredLane == 0) ? 1 : 0);
					_futureWaypoints.Clear();
					SetWaypoint(_waypoint);
				}
				_switchLanesTime = Time.time + 5f;
			}
		}

		private void UpdateFutureWaypoints(int num)
		{
			FutureWaypoint? futureWaypoint = ((_futureWaypoints.Count > 0) ? new FutureWaypoint?(_futureWaypoints.Last()) : new FutureWaypoint?(new FutureWaypoint
			{
				Waypoint = _waypoint,
				ReversePath = IsReversePath
			}));
			while (_futureWaypoints.Count < num)
			{
				futureWaypoint = GetNextFutureWaypoint(futureWaypoint.Value.Waypoint, futureWaypoint.Value.ReversePath, _preferredLane);
				if (futureWaypoint.HasValue)
				{
					_futureWaypoints.Enqueue(futureWaypoint.Value);
					continue;
				}
				break;
			}
		}

		private void UpdateTargetSpeed()
		{
			float num = _waypoint?.Segment.Speed ?? 0f;
			foreach (FutureWaypoint futureWaypoint in _futureWaypoints)
			{
				num = Mathf.Min(num, futureWaypoint.Waypoint.Segment.Speed);
			}
			_vehicle.TargetVelocity = (_vehicle.IsOnRoad ? (num * _speedVariation) : 10f);
		}
	}
}
