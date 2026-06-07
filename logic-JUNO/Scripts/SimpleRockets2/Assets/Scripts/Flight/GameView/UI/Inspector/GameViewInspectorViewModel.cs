using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.Sim;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.UI.Inspector
{
	public class GameViewInspectorViewModel
	{
		private int _stagingUpdateFrameCounter;

		public float Acceleration { get; set; }

		public DockingPortScript ActiveDockingPort { get; private set; }

		public float AirDensity { get; set; }

		public float AirTemperature { get; internal set; }

		public float AngularVelocity { get; set; }

		public float ApoapsisAltitude { get; set; }

		public float ApoapsisTime { get; set; }

		public Vector3 Coordinates { get; set; }

		public float CraftMass { get; set; }

		public float CurrentIsp { get; set; }

		public float DeltaVStage { get; set; }

		public float DeltaVTotal { get; set; }

		public GroupModel DockingGroup { get; internal set; }

		public string DockingStatus { get; internal set; }

		public string DockingStatusLabel { get; set; }

		public float Drag { get; set; }

		public float EngineThrust { get; set; }

		public float FuelActiveStagePercentage { get; set; }

		public float FuelAllStagesPercentage { get; set; }

		public float FuelBatteryPercentage { get; set; }

		public float FuelMonoPercentage { get; set; }

		public float Gravity { get; set; }

		public float LateralSurfaceVelocity { get; set; }

		public float MachNumber { get; set; }

		public float OrbitVelocity { get; set; }

		public GroupModel PerformanceGroup { get; set; }

		public float PeriapsisAltitude { get; set; }

		public float PeriapsisTime { get; set; }

		public IPlanetNode PlanetNode { get; set; }

		public float RemainingBurnTime { get; set; }

		public TextButtonModel SelectDockingPortButton { get; set; }

		public float SpeedOfSound { get; private set; }

		public float SurfaceVelocity { get; set; }

		public float ThrustToWeightRatio { get; set; }

		public float VerticalSurfaceVelocity { get; set; }

		public void Update(CraftNode craftNode)
		{
			CraftScript craftScript = craftNode.CraftScript as CraftScript;
			ICraftFlightData flightData = craftScript.FlightData;
			PlanetNode = craftNode.Parent;
			Vector2 vector = 57.29578f * (Vector2)craftNode.LatLon;
			Coordinates = new Vector3(vector.x, vector.y);
			FuelBatteryPercentage = flightData.RemainingBattery;
			FuelActiveStagePercentage = flightData.RemainingFuelInStage;
			FuelMonoPercentage = flightData.RemainingMonopropellant;
			MachNumber = flightData.MachNumber;
			AirDensity = craftScript.AtmosphereSample.AirDensity;
			if (AirDensity > 0f)
			{
				AirTemperature = flightData.AtmosphereSample.Temperature;
				SpeedOfSound = flightData.AtmosphereSample.SpeedOfSound;
			}
			else
			{
				AirTemperature = float.NaN;
				SpeedOfSound = 0f;
			}
			SurfaceVelocity = (float)flightData.SurfaceVelocityMagnitude;
			OrbitVelocity = (float)flightData.VelocityMagnitude;
			VerticalSurfaceVelocity = (float)flightData.VerticalSurfaceVelocity;
			LateralSurfaceVelocity = (float)flightData.LateralSurfaceVelocity;
			Acceleration = (float)flightData.AccelerationMagnitude;
			Drag = flightData.DragAccelerationMagnitude;
			AngularVelocity = (float)flightData.AngularVelocityMagnitude * 57.29578f;
			Gravity = flightData.GravityMagnitude;
			CraftMass = flightData.CurrentMassUnscaled;
			EngineThrust = flightData.CurrentEngineThrustUnscaled;
			ThrustToWeightRatio = flightData.Performance.ThrustToWeightRatio;
			FuelAllStagesPercentage = flightData.Performance.FuelAllStagesPercentage;
			if (flightData.ActiveEngines.Count > 0)
			{
				RemainingBurnTime = (float)flightData.Performance.RemainingBurnTime;
				CurrentIsp = (float)flightData.Performance.CurrentIsp;
				DeltaVStage = (float)flightData.Performance.DeltaVStage;
			}
			else
			{
				RemainingBurnTime = float.NaN;
				CurrentIsp = float.NaN;
				DeltaVStage = float.NaN;
			}
			int num = 0;
			foreach (PartData part in craftScript.Data.Assembly.Parts)
			{
				DockingPortData modifier = part.GetModifier<DockingPortData>();
				if (modifier != null)
				{
					num++;
					if (CompareDockingPorts(ActiveDockingPort, modifier.Script))
					{
						ActiveDockingPort = modifier.Script;
					}
				}
			}
			SelectDockingPortButton.Visible = ActiveDockingPort != null;
			if (num > 0)
			{
				DockingGroup.Visible = true;
				DockingStatus = "No Activity";
				if (ActiveDockingPort != null)
				{
					DockingStatus = ActiveDockingPort.GetStatus();
					DockingStatusLabel = $"Port {ActiveDockingPort.PartScript.Data.Id}";
				}
			}
			else
			{
				DockingGroup.Visible = false;
			}
			if (flightData.Orbit.Period > 0.0)
			{
				ApoapsisAltitude = (float)flightData.Orbit.ApoapsisAltitude;
				ApoapsisTime = (float)flightData.Orbit.ApoapsisTime;
				PeriapsisAltitude = (float)flightData.Orbit.PeriapsisAltitude;
				PeriapsisTime = (float)flightData.Orbit.PeriapsisTime;
			}
			else
			{
				ApoapsisAltitude = float.NaN;
				ApoapsisTime = float.NaN;
				PeriapsisAltitude = float.NaN;
				PeriapsisTime = float.NaN;
			}
		}

		private static bool CompareDockingPorts(DockingPortScript incumbent, DockingPortScript candidate)
		{
			int importance = GetImportance(incumbent);
			int importance2 = GetImportance(candidate);
			if (importance < importance2)
			{
				return true;
			}
			if (importance == importance2 && incumbent?.DockingTime < candidate?.DockingTime)
			{
				return true;
			}
			return false;
		}

		private static int GetImportance(DockingPortScript dockingPort)
		{
			if (dockingPort != null)
			{
				if (dockingPort.IsDocking)
				{
					return 3;
				}
				if (dockingPort.IsUndocking)
				{
					return 2;
				}
				if (dockingPort.IsDocked)
				{
					return 1;
				}
			}
			return 0;
		}
	}
}
