using System.Collections.Generic;

namespace Assets.Nimbatus.Scripts.Persistence
{
	public static class RunningModeSpecifics
	{
		private static readonly Dictionary<ERunningMode, HashSet<ERunningModeSpecific>> Specifics;

		private static void AddSpecific(ERunningMode mode, ERunningModeSpecific specific)
		{
			if (Specifics.ContainsKey(mode))
			{
				Specifics[mode].Add(specific);
				return;
			}
			Specifics.Add(mode, new HashSet<ERunningModeSpecific> { specific });
		}

		public static bool Has(ERunningModeSpecific specifc)
		{
			if (Specifics.ContainsKey(RuntimeGlobals.RunningMode))
			{
				return Specifics[RuntimeGlobals.RunningMode].Contains(specifc);
			}
			return false;
		}

		public static bool Can(ERunningModeSpecific specifc)
		{
			return Has(specifc);
		}

		static RunningModeSpecifics()
		{
			Specifics = new Dictionary<ERunningMode, HashSet<ERunningModeSpecific>>();
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.ItemDrops);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.ControlDrone);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.GenerateLocations);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.GenerateTerrain);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.SpawnEnemies);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.RandomWorldEvents);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.CentralGravity);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.MoveCameraToCursor);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.PlanetaryMissions);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.FreeDroneBrainRotation);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.ColoredBackground);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.Crosshair);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.RotateCamera);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.ChemicalReactions);
			AddSpecific(ERunningMode.Normal, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.TestFlight, ERunningModeSpecific.SpawnEnemies);
			AddSpecific(ERunningMode.TestFlight, ERunningModeSpecific.ControlDrone);
			AddSpecific(ERunningMode.TestFlight, ERunningModeSpecific.FreeDroneBrainRotation);
			AddSpecific(ERunningMode.TestFlight, ERunningModeSpecific.MoveCameraToCursor);
			AddSpecific(ERunningMode.TestFlight, ERunningModeSpecific.Crosshair);
			AddSpecific(ERunningMode.TestFlight, ERunningModeSpecific.ChemicalReactions);
			AddSpecific(ERunningMode.TestFlight, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.TestFlight, ERunningModeSpecific.AlwaysAllowInput);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.SpawnEnemies);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.ControlDrone);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.FreeDroneBrainRotation);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.MoveCameraToCursor);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.Crosshair);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.ChemicalReactions);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.RotateCamera);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.CentralGravity);
			AddSpecific(ERunningMode.TestFlightPlanet, ERunningModeSpecific.AlwaysAllowInput);
			AddSpecific(ERunningMode.Tutorial, ERunningModeSpecific.SpawnEnemies);
			AddSpecific(ERunningMode.Tutorial, ERunningModeSpecific.ControlDrone);
			AddSpecific(ERunningMode.Tutorial, ERunningModeSpecific.FreeDroneBrainRotation);
			AddSpecific(ERunningMode.Tutorial, ERunningModeSpecific.MoveCameraToCursor);
			AddSpecific(ERunningMode.Tutorial, ERunningModeSpecific.Crosshair);
			AddSpecific(ERunningMode.Tutorial, ERunningModeSpecific.ChemicalReactions);
			AddSpecific(ERunningMode.Tutorial, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.Arena, ERunningModeSpecific.SpawnEnemies);
			AddSpecific(ERunningMode.Arena, ERunningModeSpecific.ControlDrone);
			AddSpecific(ERunningMode.Arena, ERunningModeSpecific.FreeDroneBrainRotation);
			AddSpecific(ERunningMode.Arena, ERunningModeSpecific.MoveCameraToCursor);
			AddSpecific(ERunningMode.Arena, ERunningModeSpecific.Crosshair);
			AddSpecific(ERunningMode.Arena, ERunningModeSpecific.CentralGravity);
			AddSpecific(ERunningMode.Arena, ERunningModeSpecific.ChemicalReactions);
			AddSpecific(ERunningMode.Arena, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.DroneVersusDrone, ERunningModeSpecific.ControlDrone);
			AddSpecific(ERunningMode.DroneVersusDrone, ERunningModeSpecific.FreeDroneBrainRotation);
			AddSpecific(ERunningMode.DroneVersusDrone, ERunningModeSpecific.Crosshair);
			AddSpecific(ERunningMode.DroneVersusDrone, ERunningModeSpecific.CentralGravity);
			AddSpecific(ERunningMode.DroneVersusDrone, ERunningModeSpecific.ChemicalReactions);
			AddSpecific(ERunningMode.DroneVersusDrone, ERunningModeSpecific.DisableCameraFocusParts);
			AddSpecific(ERunningMode.DroneVersusDrone, ERunningModeSpecific.ContinuousCollisionDetection);
			AddSpecific(ERunningMode.DroneVersusDrone, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.DroneRace, ERunningModeSpecific.ControlDrone);
			AddSpecific(ERunningMode.DroneRace, ERunningModeSpecific.FreeDroneBrainRotation);
			AddSpecific(ERunningMode.DroneRace, ERunningModeSpecific.Crosshair);
			AddSpecific(ERunningMode.DroneRace, ERunningModeSpecific.ChemicalReactions);
			AddSpecific(ERunningMode.DroneRace, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.DroneRace, ERunningModeSpecific.ContinuousCollisionDetection);
			AddSpecific(ERunningMode.DroneRace, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.BossFight, ERunningModeSpecific.SpawnEnemies);
			AddSpecific(ERunningMode.BossFight, ERunningModeSpecific.ControlDrone);
			AddSpecific(ERunningMode.BossFight, ERunningModeSpecific.FreeDroneBrainRotation);
			AddSpecific(ERunningMode.BossFight, ERunningModeSpecific.ColoredBackground);
			AddSpecific(ERunningMode.BossFight, ERunningModeSpecific.MoveCameraToCursor);
			AddSpecific(ERunningMode.BossFight, ERunningModeSpecific.ChemicalReactions);
			AddSpecific(ERunningMode.BossFight, ERunningModeSpecific.Crosshair);
			AddSpecific(ERunningMode.BossFight, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.Space, ERunningModeSpecific.SpawnEnemies);
			AddSpecific(ERunningMode.Space, ERunningModeSpecific.ControlDrone);
			AddSpecific(ERunningMode.Space, ERunningModeSpecific.FreeDroneBrainRotation);
			AddSpecific(ERunningMode.Space, ERunningModeSpecific.ColoredBackground);
			AddSpecific(ERunningMode.Space, ERunningModeSpecific.MoveCameraToCursor);
			AddSpecific(ERunningMode.Space, ERunningModeSpecific.ChemicalReactions);
			AddSpecific(ERunningMode.Space, ERunningModeSpecific.Crosshair);
			AddSpecific(ERunningMode.Space, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.DroneCustomization, ERunningModeSpecific.ZoomCamera);
			AddSpecific(ERunningMode.DroneCustomization, ERunningModeSpecific.AlwaysAllowInput);
		}
	}
}
