using System.Xml.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.State;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Planet;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Career
{
	public interface IFlightContext
	{
		double Acceleration { get; }

		double AltitudeAboveTerrain { get; }

		double AltitudeAGL { get; }

		double AltitudeASL { get; }

		double Apoapsis { get; }

		double ApoapsisTime { get; }

		double AtmosphereDensity { get; }

		double AtmosphereHeight { get; }

		double AtmosphereTemperature { get; }

		PositionBiomeData CraftBiomeData { get; }

		bool CraftIsOrbiting { get; }

		ICraftNode CraftNode { get; }

		double DeltaTime { get; }

		double DeltaVStage { get; }

		double DragAcceleration { get; }

		double Eccentricity { get; }

		FlightState FlightState { get; }

		IFlightTutorialPanel FlightTutorialPanel { get; }

		double FrameDistance { get; }

		double FrameDistanceSurface { get; }

		double FrameFuelUsed { get; }

		double Fuel { get; }

		double FuelBattery { get; }

		double FuelMono { get; }

		double FuelStage { get; }

		double Gravity { get; }

		bool Grounded { get; }

		double Inclination { get; }

		bool InWater { get; }

		bool IsDestroyed { get; }

		bool IsDrood { get; }

		bool IsNewLaunch { get; }

		double Isp { get; }

		double MachNumber { get; }

		double Mass { get; }

		float MaxActiveEngineThrust { get; }

		double Money { get; }

		double MoneyReceived { get; }

		double MoneyRecovered { get; }

		double MoneySpent { get; }

		int NumAstronauts { get; }

		int NumCompletedContracts { get; }

		int NumDockedCrafts { get; }

		int NumDroodsEnteredOrbit { get; }

		int NumExplosions { get; }

		int NumLaunches { get; }

		int NumPlanetContacts { get; }

		int NumPlanetFlyBys { get; }

		int NumPlanetOrbits { get; }

		string Parent { get; }

		double ParentRotationalPeriod { get; }

		double Periapsis { get; }

		double PeriapsisTime { get; }

		double Period { get; }

		IPlanetNode Planet { get; }

		double PlanetRotation { get; }

		Vector3d Position { get; }

		Vector3d SurfacePosition { get; }

		double SurfaceVelocity { get; }

		double SurfaceVelocityLateral { get; }

		double SurfaceVelocityVertical { get; }

		float Thrust { get; }

		double Time { get; }

		double TimeEnginesInactive { get; }

		double TimeGrounded { get; }

		double Velocity { get; }

		event SimpleNotificationDelegate CraftChanged;

		event SimpleNotificationDelegate CraftChangedSoi;

		event CraftEventDelegate CraftContact;

		event SimpleNotificationDelegate CraftDocked;

		event CraftEventDelegate CraftHyperbolicOrbit;

		event CraftEventDelegate CraftOrbit;

		event SimpleNotificationDelegate CraftStructureChanged;

		Vector3d CoordsToPci(double lat, double lon, double agl);

		int CountCraftParts(string partTypeId, string payloadTrackingId, bool activated = false);

		LocationNode CreateLocationNode(ContractLocation contractLocation, string mapViewIcon);

		IPlanetNode GetPlanet(string name);

		bool IsLaunchedCraft(int craftNodeId);

		Vector3d PciToCoords(Vector3d pci);

		Vector3d PciToCoordsASL(Vector3d pci);

		void ShowMessage(string message);

		void ShowRewardMessage(string text, long money, int techPoints, RewardMessageSoundType sound);

		CraftNode SpawnCraft(string craftNodeName, CraftData craftData, LaunchLocation launchLocation, XElement pendingXml);
	}
}
