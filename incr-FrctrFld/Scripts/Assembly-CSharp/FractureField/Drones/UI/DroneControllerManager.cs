using System.Collections.Generic;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.Drones.UI
{
	public class DroneControllerManager : RComponent
	{
		[Header("Prefabs")]
		[SerializeField]
		private GameObject droneControllerPrefab;

		[Header("Drone Type Prefabs")]
		[SerializeField]
		private GameObject sentryDronePrefab;

		[SerializeField]
		private GameObject collectorDronePrefab;

		[SerializeField]
		private GameObject pierceDronePrefab;

		[SerializeField]
		private GameObject supervisorDronePrefab;

		[SerializeField]
		private GameObject shatterDronePrefab;

		[SerializeField]
		private GameObject boostDronePrefab;

		[Header("Settings")]
		[SerializeField]
		private Transform droneContainer;

		private Dictionary<Drone, DroneController> DroneControllers { get; }

		protected override void Start()
		{
		}

		private void Setup()
		{
		}

		private void OnDroneSpawned()
		{
		}

		private void OnDroneDespawned()
		{
		}

		private void CreateDroneController(Drone drone)
		{
		}

		private void RemoveDroneController(Drone drone)
		{
		}

		private GameObject GetPrefabForDroneType(DroneType type)
		{
			return null;
		}
	}
}
