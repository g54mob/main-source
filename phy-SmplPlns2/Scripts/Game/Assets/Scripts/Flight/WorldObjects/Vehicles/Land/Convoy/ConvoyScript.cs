using System.Collections.Generic;
using Jundroo.Common.Extensions;
using SWS;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy
{
	public class ConvoyScript : MonoBehaviour
	{
		[SerializeField]
		private ConvoyProviderScript _convoyProvider;

		[SerializeField]
		private Color _dustParticlesColor = new Color(73f / 85f, 62f / 85f, 47f / 85f);

		private bool _initialized;

		[SerializeField]
		private bool _isHostile;

		[SerializeField]
		private PathManager _pathManager;

		[SerializeField]
		private Transform _startingWaypointDebug;

		[SerializeField]
		private Transform[] _startingWaypoints;

		[SerializeField]
		private float _vehicleSpacing = 30f;

		public bool IsHostile
		{
			get
			{
				return _isHostile;
			}
			set
			{
				_isHostile = value;
				for (int i = 0; i < Vehicles.Count; i++)
				{
					Vehicles[i].IsHostile = value;
				}
			}
		}

		public List<SimpleGroundVehicleScript> Vehicles { get; private set; }

		public List<Transform> Waypoints { get; private set; }

		[ContextMenu("Despawn Convoy")]
		public void Despawn()
		{
			for (int i = 0; i < Vehicles.Count; i++)
			{
				SimpleGroundVehicleScript simpleGroundVehicleScript = Vehicles[i];
				if (simpleGroundVehicleScript != null && simpleGroundVehicleScript.gameObject != null)
				{
					Object.Destroy(simpleGroundVehicleScript.gameObject);
				}
			}
			Vehicles.Clear();
		}

		public Transform GetNextWaypoint(Transform currentWaypoint)
		{
			for (int i = 0; i < Waypoints.Count; i++)
			{
				if (Waypoints[i] == currentWaypoint)
				{
					if (i + 1 != Waypoints.Count)
					{
						return Waypoints[i + 1];
					}
					return Waypoints[0];
				}
			}
			return null;
		}

		[ContextMenu("Spawn Convoy")]
		public void Spawn()
		{
			if (!Initialize())
			{
				this.LogError("Unable to initialize the convoy script");
				return;
			}
			Despawn();
			if (_pathManager != null)
			{
				Waypoints.Clear();
				Waypoints.AddRange(_pathManager.waypoints);
			}
			if (_convoyProvider == null)
			{
				return;
			}
			RandomConvoyProviderScript randomConvoyProviderScript = _convoyProvider as RandomConvoyProviderScript;
			if (randomConvoyProviderScript != null)
			{
				randomConvoyProviderScript.AlwaysMaxSize = Game.Instance.Device.IsUnityEditor && _startingWaypointDebug != null;
			}
			GameObject[] convoyPrefabs = _convoyProvider.GetConvoyPrefabs();
			for (int i = 0; i < convoyPrefabs.Length; i++)
			{
				SimpleGroundVehicleScript simpleGroundVehicleScript = SpawnVehiclePrefab(convoyPrefabs[i]);
				if (!(simpleGroundVehicleScript == null))
				{
					AddVehicle(simpleGroundVehicleScript);
				}
			}
		}

		protected virtual void Start()
		{
			Spawn();
		}

		private void AddVehicle(SimpleGroundVehicleScript vehicle)
		{
			Transform transform = vehicle.transform;
			transform.transform.parent = base.transform;
			Transform transform2 = null;
			if (Vehicles.Count == 0)
			{
				transform2 = ((Waypoints.Count > 0) ? Waypoints[0] : base.transform);
				if (Game.Instance.Device.IsUnityEditor && _startingWaypointDebug != null)
				{
					transform2 = _startingWaypointDebug;
				}
				else if (_startingWaypoints.Length != 0)
				{
					Transform transform3 = _startingWaypoints[Random.Range(0, _startingWaypoints.Length)];
					if (transform3 != null)
					{
						transform2 = transform3;
					}
				}
				transform.SetPositionAndRotation(transform2.position, transform2.rotation);
			}
			else
			{
				Transform transform4 = Vehicles[Vehicles.Count - 1].transform;
				transform.SetPositionAndRotation(transform4.position - transform4.forward * _vehicleSpacing, transform4.rotation);
			}
			if (Physics.Raycast(transform.position + Vector3.up * 1000f, Vector3.down, out var hitInfo, 2000f, 1048576))
			{
				Vector3 position = transform.position;
				position.y = hitInfo.point.y + 2f;
				transform.position = position;
			}
			if (Vehicles.Count > 0)
			{
				vehicle.NavigationTarget = Vehicles[Vehicles.Count - 1].transform;
			}
			else if (transform2 != null)
			{
				Transform nextWaypoint = GetNextWaypoint(transform2);
				vehicle.NavigationTarget = nextWaypoint;
			}
			vehicle.NavigationTargetReached += VehicleNavigationTargetReached;
			vehicle.LightDamageReceived += VehicleLightDamageReceived;
			vehicle.AttackedByPlayer += VehicleAttackedByPlayer;
			vehicle.IsHostile = IsHostile;
			vehicle.VehicleNavigationTargetDistance = _vehicleSpacing;
			vehicle.DustParticlesColor = _dustParticlesColor;
			Vehicles.Add(vehicle);
		}

		private bool Initialize()
		{
			if (_initialized)
			{
				return true;
			}
			_initialized = true;
			Vehicles = new List<SimpleGroundVehicleScript>();
			Waypoints = new List<Transform>();
			return _initialized;
		}

		private SimpleGroundVehicleScript SpawnVehiclePrefab(GameObject prefab)
		{
			if (prefab == null)
			{
				return null;
			}
			GameObject gameObject = Object.Instantiate(prefab);
			if (gameObject == null)
			{
				this.LogError("Could not instantiate vehicle prefab '{0}' for convoy.", prefab.name);
				return null;
			}
			if (!gameObject.TryGetComponent<SimpleGroundVehicleScript>(out var component))
			{
				this.LogError("Convoy prefab '{0}' does not have a ground vehicle component.", prefab.name);
				return null;
			}
			return component;
		}

		private void VehicleAttackedByPlayer(object sender, ConvoyVehicleEventArgs e)
		{
			IsHostile = true;
			e.Vehicle.AttackedByPlayer -= VehicleAttackedByPlayer;
		}

		private void VehicleLightDamageReceived(object sender, ConvoyVehicleEventArgs e)
		{
			for (int i = 0; i < Vehicles.Count; i++)
			{
				if (Vehicles[i].NavigationTarget == e.Vehicle.transform)
				{
					Vehicles[i].NavigationTarget = e.Vehicle.NavigationTarget;
				}
			}
		}

		private void VehicleNavigationTargetReached(object sender, ConvoyNavigationTargetReachedEventArgs e)
		{
			bool flag = true;
			Transform transform = e.Target;
			SimpleGroundVehicleScript simpleGroundVehicleScript = null;
			while (transform != null && (simpleGroundVehicleScript = transform.GetComponent<SimpleGroundVehicleScript>()) != null)
			{
				transform = simpleGroundVehicleScript.NavigationTarget;
				flag = false;
			}
			if (transform != null)
			{
				e.Vehicle.NavigationTarget = (flag ? GetNextWaypoint(transform) : transform);
			}
		}
	}
}
