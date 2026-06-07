using ModApi.Craft;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class FlightLog
	{
		private int _framesSinceLastSample;

		private IPlanetNode _lastCraftParent;

		private Vector3d _lastCraftPosition;

		private double _maxAerodynamicForce;

		public double DistanceTraveled { get; private set; }

		public double FlightTime { get; private set; }

		public bool IsNewLaunch { get; private set; }

		public long LaunchCost { get; private set; }

		public double MaxAltitude { get; private set; }

		public double MaxQ { get; private set; }

		public double MaxVelocity { get; private set; }

		public long Money { get; set; }

		public int TechPoints { get; set; }

		public FlightLog(bool isNewLaunch, long launchCost)
		{
			IsNewLaunch = isNewLaunch;
			LaunchCost = launchCost;
		}

		public void Update(ICraftNode playerCraftNode, double deltaTime)
		{
			FlightTime += deltaTime;
			ICraftScript craftScript = playerCraftNode.CraftScript;
			if (craftScript == null)
			{
				return;
			}
			double num = craftScript.FlightData.SurfaceVelocityMagnitude;
			if (craftScript.FlightData.AltitudeAboveSeaLevel > 20000.0)
			{
				num = craftScript.FlightData.VelocityMagnitude;
			}
			if (MaxVelocity < num)
			{
				MaxVelocity = num;
			}
			if (MaxAltitude < craftScript.FlightData.AltitudeAboveSeaLevel)
			{
				MaxAltitude = craftScript.FlightData.AltitudeAboveSeaLevel;
			}
			if (craftScript.AtmosphereSample.AirDensity > 0f)
			{
				double num2 = CalculateAerodynamicForce(craftScript.AtmosphereSample.AirDensity, craftScript.FlightData.SurfaceVelocityMagnitude);
				if (_maxAerodynamicForce < num2)
				{
					_maxAerodynamicForce = num2;
					MaxQ = craftScript.FlightData.AltitudeAboveSeaLevel;
				}
			}
			if (_framesSinceLastSample < 10)
			{
				_framesSinceLastSample++;
			}
			else if (_lastCraftParent != playerCraftNode.Parent)
			{
				_lastCraftParent = playerCraftNode.Parent;
				_lastCraftPosition = playerCraftNode.Position;
			}
			else if (!playerCraftNode.InContactWithPlanet)
			{
				double magnitude = (_lastCraftPosition - playerCraftNode.Position).magnitude;
				DistanceTraveled += magnitude;
				_lastCraftPosition = playerCraftNode.Position;
				_framesSinceLastSample = 0;
			}
		}

		private static double CalculateAerodynamicForce(double density, double velocityMagnitude)
		{
			return 0.5 * density * velocityMagnitude * velocityMagnitude;
		}
	}
}
