using UnityEngine;

namespace Gley.TrafficSystem
{
	[HelpURL("https://gley.gitbook.io/mobile-traffic-system/setup-guide/initializing-asset")]
	public class TrafficComponent : MonoBehaviour
	{
		[Header("Required Settings")]
		[Tooltip("Player is used to instantiate vehicles out of view")]
		public Transform player;

		[Tooltip("Max number of possible vehicles. Cannot be increased during game-play")]
		public int nrOfVehicles;

		[Tooltip("List of different vehicles (Right Click->Create->Traffic System->Vehicle Pool)")]
		public VehiclePool vehiclePool;

		[Header("Optional Settings")]
		[Header("Spawning")]
		[Tooltip("Square located at this distance from the player are actively update. Ex: if set is to 2 -> intersections will update on a 2 square distance from the player")]
		public int activeSquareLevels;

		[Tooltip("Minimum distance from the player where a vehicle can be instantiated. (If -1 the system will automatically determine this value)")]
		public float minDistanceToAdd;

		[Tooltip("Distance from the player where a vehicle can be removed. (If -1 the system will automatically determine this value)")]
		public float distanceToRemove;

		[Header("Intersection")]
		[Tooltip("How long yellow light is on. (If -1 the value from the intersection component will be used)")]
		public float yellowLightTime;

		[Tooltip("How long green light is on. (If -1 the value from the intersection component will be used)")]
		public float greenLightTime;

		[Header("Density")]
		[Tooltip("Nr of vehicles instantiated around the player from the start. Set it to something < nrOfVehicles for low density right at the start. (If -1 all vehicles will be instantiated from the beginning)")]
		public int initialActiveVehicles;

		[Tooltip("Set high priority on roads for higher traffic density(ex highways). See priority setup")]
		public bool useWaypointPriority;

		[Header("Lights")]
		[Tooltip("Set the initial state of the car lights")]
		public bool lightsOn;

		[Header("Waypoints")]
		[Tooltip("Area to disable from the start if cars are not allowed to spawn there")]
		public Area disableWaypointsArea;

		private void Start()
		{
		}

		public static void MyVehicleCrashBehaviour(int vehicleIndex, ObstacleTypes obstacleType, Collider other)
		{
		}
	}
}
