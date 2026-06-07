using System.Collections.Generic;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads.Data
{
	[CreateAssetMenu(fileName = "RoadTypeVehicleList", menuName = "Cars/Road Type Vehicle List Data", order = 1)]
	public class RoadTypeVehicleListData : ScriptableObject
	{
		public bool exclusive;

		public List<VehicleListData.VehicleInfo> overrides = new List<VehicleListData.VehicleInfo>();
	}
}
