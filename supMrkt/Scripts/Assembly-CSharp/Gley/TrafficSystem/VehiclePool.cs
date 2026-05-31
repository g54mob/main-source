using UnityEngine;

namespace Gley.TrafficSystem
{
	[CreateAssetMenu(fileName = "VehiclePool", menuName = "TrafficSystem/Vehicle Pool", order = 1)]
	public class VehiclePool : ScriptableObject
	{
		public CarType[] trafficCars;
	}
}
