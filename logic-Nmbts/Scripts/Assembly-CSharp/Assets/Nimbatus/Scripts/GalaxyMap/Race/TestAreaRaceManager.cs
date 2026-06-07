using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	public class TestAreaRaceManager : BaseRaceManager
	{
		public NimbatusDrone PlayerDrone;

		public RaceTrack TestTrack;

		private EAirResistance _ogAirResistance;

		private EGravity _ogGravity;

		public void Start()
		{
			PlayerDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone);
			if (RuntimeGlobals.Camera != null)
			{
				RuntimeGlobals.Camera.FocusTarget = true;
				RuntimeGlobals.Camera.AddPlayer(PlayerDrone.RootDronePart.transform, true, false, true);
			}
			PlayerDrone.TrackerManager.Init(PlayerDrone, TestTrack.MainSpline);
			PlayerDrone.ActivatePhysics();
			_ogAirResistance = WorldController.TerrainSettings.TestSimulationAirResistance;
			_ogGravity = WorldController.TerrainSettings.TestSimulationGravity;
			WorldController.TerrainSettings.TestSimulationAirResistance = TestTrack.AirResistance;
			WorldController.TerrainSettings.TestSimulationGravity = TestTrack.Gravity;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			WorldController.TerrainSettings.TestSimulationAirResistance = _ogAirResistance;
			WorldController.TerrainSettings.TestSimulationGravity = _ogGravity;
		}
	}
}
