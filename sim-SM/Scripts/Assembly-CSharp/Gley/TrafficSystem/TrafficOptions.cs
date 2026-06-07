namespace Gley.TrafficSystem
{
	public class TrafficOptions
	{
		public float minDistanceToAdd;

		public float distanceToRemove;

		public float masterVolume;

		public bool useWaypointPriority;

		public float greenLightTime;

		public float yellowLightTime;

		public int activeSquaresLevel;

		public int initialDensity;

		public bool lightsOn;

		public Area disableWaypointsArea;

		private TrafficLightsBehaviour trafficLightsBehaviour;

		private SpawnWaypointSelector spawnWaypointSelector;

		private ModifyTriggerSize modifyTriggerSize;

		private PlayerInTrigger playerInTrigger;

		private DynamicObstacleInTrigger dynamicObstacleInTrigger;

		private BuildingInTrigger buildingInTrigger;

		private VehicleCrash vehicleCrash;

		public TrafficLightsBehaviour TrafficLightsBehaviour
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SpawnWaypointSelector SpawnWaypointSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ModifyTriggerSize ModifyTriggerSize
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PlayerInTrigger PlayerInTrigger
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DynamicObstacleInTrigger DynamicObstacleInTrigger
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BuildingInTrigger BuildingInTrigger
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public VehicleCrash VehicleCrash
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
