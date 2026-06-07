using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Environment.Roads.Data;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land;
using Assets.Scripts.Multiplayer.FlightObjects;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	public class CarSpawnerScript : MonoBehaviour
	{
		[Serializable]
		public class CarLight
		{
			public float DayIntensity;

			public Material Material;

			public float NightIntensity = 2f;

			public Color OriginalColor;
		}

		private CarLight[] _carLightDisabledMaterials;

		[SerializeField]
		private CarLight[] _carLightMaterials;

		private List<INetworkVehicle> _cars = new List<INetworkVehicle>();

		private bool _lightsEnabled;

		[SerializeField]
		private SimpleGroundVehicleUpdaterScript _simpleGroundVehicleUpdater;

		private bool _spawning;

		private float _spawnTimer = 0.01f;

		private float _totalCarTypeRange;

		[SerializeField]
		private VehicleListData _vehicleListData;

		private Dictionary<RoadTypeData.RoadType, VehicleList> _vehicleLists = new Dictionary<RoadTypeData.RoadType, VehicleList>();

		public static int MaxCars { get; set; } = 25;

		public IEnumerable<CarLight> CarLightDisabledMaterials => _carLightDisabledMaterials;

		public IEnumerable<CarLight> CarLightMaterials => _carLightMaterials;

		public SimpleGroundVehicleUpdaterScript SimpleGroundVehicleUpdater => _simpleGroundVehicleUpdater;

		public RoadNetworkWaypoints Waypoints { get; private set; }

		private bool IsServer => FlightSceneScript.Instance.FlightSceneNetwork.IsServerStarted;

		public GameObject GetCarPrefab(int type)
		{
			return _vehicleListData.vehicles[type].prefab;
		}

		public void RegisterCar(INetworkVehicle car)
		{
			_cars.Add(car);
			car.Transform.SetParent(base.transform, worldPositionStays: true);
			if (car.IsOwner)
			{
				_spawning = false;
			}
		}

		public RoadNetworkWaypoints.RoadWaypoint SelectBestWaypoint(INetworkVehicle curiousCar, RoadNetworkWaypoints.RoadWaypoint waypoint, bool reversed)
		{
			for (int i = 0; i < 15; i++)
			{
				if (waypoint == null)
				{
					return null;
				}
				bool flag = false;
				if (waypoint.Segment.RoadType.numLanes == 1 && reversed)
				{
					flag = true;
				}
				Vector3 vector = Waypoints.WaypointToWorldPosition(waypoint.Position);
				if (!flag)
				{
					foreach (INetworkVehicle car in _cars)
					{
						if (curiousCar != car && car.IsReversePath == reversed && (car.Transform.position - vector).magnitude < waypoint.Segment.RoadType.minDistanceBetweenCars && waypoint.Segment.RoadType.minDistanceBetweenCars > 0f)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					foreach (FlightScenePlayer allPlayer in FlightSceneScript.Instance.AllPlayers)
					{
						if ((allPlayer.FramePosition - vector).magnitude < 50f)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					for (int j = 0; j < 3; j++)
					{
						waypoint = (reversed ? waypoint?.Next : waypoint?.Previous);
					}
					continue;
				}
				return waypoint;
			}
			return null;
		}

		public void UnregisterCar(INetworkVehicle car)
		{
			_cars.Remove(car);
		}

		protected virtual void Awake()
		{
			_carLightDisabledMaterials = new CarLight[_carLightMaterials.Length];
			for (int i = 0; i < _carLightMaterials.Length; i++)
			{
				CarLight carLight = _carLightMaterials[i];
				string text = carLight.Material.name;
				carLight.Material = new Material(carLight.Material);
				carLight.Material.name = text + " [Shared Instance]";
				carLight.OriginalColor = carLight.Material.GetColor("_EmissionColor");
				CarLight carLight2 = new CarLight
				{
					DayIntensity = 0f,
					Material = new Material(carLight.Material),
					NightIntensity = 0f,
					OriginalColor = carLight.OriginalColor
				};
				carLight2.Material.name = text + " Disabled [Shared Instance]";
				carLight2.Material.SetColor("_EmissionColor", Color.black);
				_carLightDisabledMaterials[i] = carLight2;
			}
		}

		protected virtual void OnDestroy()
		{
			CarLight[] carLightMaterials = _carLightMaterials;
			foreach (CarLight obj in carLightMaterials)
			{
				UnityEngine.Object.Destroy(obj.Material);
				obj.Material = null;
			}
			carLightMaterials = _carLightDisabledMaterials;
			foreach (CarLight obj2 in carLightMaterials)
			{
				UnityEngine.Object.Destroy(obj2.Material);
				obj2.Material = null;
			}
		}

		protected virtual void Start()
		{
			EnableLights(enable: false, force: true);
		}

		protected virtual void Update()
		{
			if (Waypoints != null && !_spawning)
			{
				_spawnTimer -= Time.deltaTime;
				int num = 0;
				for (int i = 0; i < _cars.Count; i++)
				{
					if (_cars[i].IsOwner)
					{
						num++;
					}
				}
				int num2 = FlightSceneScript.Instance?.AllPlayers.Count ?? 0;
				int num3 = ((num2 > 0) ? (MaxCars / num2) : 0);
				if (num < num3 && _cars.Count < MaxCars && _spawnTimer < 0f)
				{
					Vector3 vector = FlightSceneScript.Instance.LocalPlayer.Velocity;
					if (vector.magnitude < 20f)
					{
						Vector2 vector2 = UnityEngine.Random.insideUnitCircle * 20f;
						vector = new Vector3(vector2.x, 0f, vector2.y);
					}
					Vector3 vector3 = FlightSceneScript.Instance.LocalPlayer.FramePosition + vector * 10f;
					RoadNetworkWaypoints.RoadWaypoint closestSpawnableWaypoint = Waypoints.GetClosestSpawnableWaypoint(vector3);
					if (closestSpawnableWaypoint != null)
					{
						bool reversed = UnityEngine.Random.Range(0, 2) == 0;
						Vector3 vector4 = Waypoints.WaypointToWorldPosition(closestSpawnableWaypoint.Position);
						if ((vector3 - vector4).magnitude < 125f)
						{
							closestSpawnableWaypoint = SelectBestWaypoint(null, closestSpawnableWaypoint, reversed);
							if (closestSpawnableWaypoint != null)
							{
								_spawning = true;
								SpawnCarAtWaypoint(closestSpawnableWaypoint, reversed);
							}
						}
					}
				}
				else if (_cars.Count > MaxCars && IsServer)
				{
					INetworkVehicle networkVehicle = _cars[0];
					networkVehicle.Despawn();
					UnregisterCar(networkVehicle);
				}
			}
			else if (Waypoints == null)
			{
				Waypoints = UnityEngine.Object.FindFirstObjectByType<RoadNetworkWaypoints>();
			}
			EnableLights(FlightSceneScript.Instance.Environment.IsNight);
		}

		private void EnableLights(bool enable, bool force = false)
		{
			if (_lightsEnabled != enable || force)
			{
				_lightsEnabled = enable;
				CarLight[] carLightMaterials = _carLightMaterials;
				foreach (CarLight carLight in carLightMaterials)
				{
					Color value = carLight.OriginalColor * (enable ? carLight.NightIntensity : carLight.DayIntensity);
					carLight.Material.SetColor("_EmissionColor", value);
				}
			}
		}

		private VehicleList GetVehicleListForRoadType(RoadTypeData.RoadType roadType)
		{
			if (!_vehicleLists.TryGetValue(roadType, out var value))
			{
				VehicleListData vehicleListData = UnityEngine.Object.Instantiate(_vehicleListData);
				vehicleListData.vehicles = _vehicleListData.vehicles.Select(delegate(VehicleListData.VehicleInfo v)
				{
					VehicleListData.VehicleInfo vehicleInfo2 = new VehicleListData.VehicleInfo();
					RoadTypeVehicleListData vehicleList = roadType.vehicleList;
					vehicleInfo2.frequency = (((object)vehicleList != null && vehicleList.exclusive) ? 0f : v.frequency);
					vehicleInfo2.prefab = v.prefab;
					return vehicleInfo2;
				}).ToArray();
				if (roadType.vehicleList != null)
				{
					foreach (VehicleListData.VehicleInfo vehiceleOverride in roadType.vehicleList.overrides)
					{
						VehicleListData.VehicleInfo vehicleInfo = vehicleListData.vehicles.FirstOrDefault((VehicleListData.VehicleInfo x) => x.prefab == vehiceleOverride.prefab);
						if (vehicleInfo != null)
						{
							vehicleInfo.frequency = vehiceleOverride.frequency;
						}
						else
						{
							Debug.Log("Could not find vehicle override in default vehicle list: " + vehiceleOverride.prefab.name);
						}
					}
				}
				value = new VehicleList(vehicleListData);
				_vehicleLists[roadType] = value;
			}
			return value;
		}

		private void SpawnCarAtWaypoint(RoadNetworkWaypoints.RoadWaypoint waypoint, bool reversed)
		{
			_spawnTimer = UnityEngine.Random.Range(0.5f, 2.5f);
			Vector3 floatingOriginPosition = Waypoints.WaypointToWorldPosition(waypoint.GetLanePosition(reversed));
			Vector3 obj = (reversed ? (-waypoint.Forward) : waypoint.Forward);
			Vector3 eulerAngles = Quaternion.LookRotation(obj, Vector3.Cross(obj, reversed ? (-waypoint.Right) : waypoint.Right)).eulerAngles;
			PooledWriter pooledWriter = WriterPool.Retrieve();
			pooledWriter.WriteInt32(waypoint.Id);
			pooledWriter.WriteBoolean(reversed);
			int randomVehicleIndex = GetVehicleListForRoadType(waypoint.Segment.RoadType).GetRandomVehicleIndex(UnityEngine.Random.value);
			if (randomVehicleIndex >= 0)
			{
				pooledWriter.WriteUInt8Unpacked((byte)randomVehicleIndex);
				pooledWriter.WriteSingle(UnityEngine.Random.value);
				Vector3 absolutePosition = Utility.ConvertFloatingOriginToAbsolutePosition(floatingOriginPosition);
				absolutePosition -= Vector3.up * 100f;
				FlightSceneScript.Instance.FlightSceneNetwork.SpawnFlightObject("Multiplayer/NetworkVehicle", absolutePosition, eulerAngles, pooledWriter.GetArraySegment());
				pooledWriter.Store();
			}
		}
	}
}
