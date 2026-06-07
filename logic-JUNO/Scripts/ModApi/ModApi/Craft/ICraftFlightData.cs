using System;
using System.Collections.Generic;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Flight.UI;
using ModApi.Planet;
using UnityEngine;

namespace ModApi.Craft
{
	public interface ICraftFlightData
	{
		Vector3d Acceleration { get; }

		Vector3 AccelerationFrame { get; }

		double AccelerationMagnitude { get; }

		List<IReactionEngine> ActiveEngines { get; }

		List<IReactionControlNozzle> ActiveReactionControlNozzles { get; }

		double AltitudeAboveGroundLevel { get; }

		double AltitudeAboveSeaLevel { get; }

		double AltitudeAboveTerrain { get; }

		double AngleOfAttack { get; }

		Vector3d AngularVelocity { get; }

		double AngularVelocityMagnitude { get; }

		AtmosphereSample AtmosphereSample { get; }

		double BankAngle { get; }

		Vector3d CraftForward { get; }

		Vector3d CraftRight { get; }

		Vector3d CraftUp { get; }

		float CurrentEngineThrust { get; }

		float CurrentEngineThrustUnscaled { get; }

		float CurrentMass { get; }

		float CurrentMassUnscaled { get; }

		float CurrentReactionControlNozzleThrust { get; }

		float DragAccelerationMagnitude { get; }

		Vector3d East { get; }

		float FuelMass { get; }

		Vector3d Gravity { get; }

		Vector3 GravityFrame { get; }

		Vector3 GravityFrameNormalized { get; }

		float GravityMagnitude { get; }

		bool Grounded { get; }

		double Heading { get; }

		bool InWater { get; }

		double LateralSurfaceVelocity { get; }

		float MachNumber { get; }

		float MaxActiveEngineThrust { get; }

		float MaxActiveEngineThrustUnscaled { get; }

		INavSphereTarget NavSphereTarget { get; }

		Vector3d North { get; }

		ICraftOrbitData Orbit { get; }

		float ParentPlanetOcclusion { get; }

		ICraftPerformanceData Performance { get; }

		double Pitch { get; }

		Vector3d Position { get; }

		Vector3d PositionNormalized { get; }

		float RemainingBattery { get; }

		float RemainingFuelInStage { get; }

		float RemainingMonopropellant { get; }

		double SideSlip { get; }

		Vector3d SolarRadiationDirection { get; }

		Vector3 SolarRadiationFrameDirection { get; }

		double SolarRadiationIntensity { get; }

		bool SupportsWarpBurn { get; }

		Vector3d SurfaceVelocity { get; }

		Vector3 SurfaceVelocityFrame { get; }

		double SurfaceVelocityMagnitude { get; }

		Vector3d Velocity { get; }

		double VelocityMagnitude { get; }

		double VerticalSurfaceVelocity { get; }

		float WeightedThrottleResponse { get; }

		float WeightedThrottleResponseTime { get; }

		event EventHandler<EventArgs> ActiveEnginesChanged;
	}
}
