using System;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	[CreateAssetMenu(fileName = "VehicleList", menuName = "Cars/Vehicle List Data", order = 1)]
	public class VehicleListData : ScriptableObject
	{
		[Serializable]
		public class VehicleInfo
		{
			public float frequency;

			public GameObject prefab;
		}

		public VehicleInfo[] vehicles;
	}
}
