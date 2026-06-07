using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.Sim;
using ModApi.Craft;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Craft.FlightData
{
	public class CraftOrbitData : ICraftOrbitData
	{
		private ICraftScript _craftScript;

		public double ApoapsisAltitude { get; private set; }

		public double ApoapsisTime { get; private set; }

		public Vector3d BurnNodeDeltaV
		{
			get
			{
				ManeuverNodeScript nextBurnNode = NextBurnNode;
				if (nextBurnNode != null)
				{
					return nextBurnNode.DeltaV;
				}
				return Vector3d.zero;
			}
		}

		public IOrbitPoint BurnNodePoint
		{
			get
			{
				ManeuverNodeScript nextBurnNode = NextBurnNode;
				if (nextBurnNode != null)
				{
					return OrbitMath.GetPointAtTrueAnomaly(_craftScript.CraftNode.Orbit, nextBurnNode.TrueAnomalyOnPreviousOrbit);
				}
				return null;
			}
		}

		public double Eccentricity { get; private set; }

		public double Inclination { get; private set; }

		public IPlanetNode Parent { get; private set; }

		public double PeriapsisAltitude { get; private set; }

		public double PeriapsisTime { get; private set; }

		public double Period { get; private set; }

		public double MeanAnomaly { get; private set; }

		public double MeanMotion { get; private set; }

		public double PeriapsisArgument { get; private set; }

		public double RightAscension { get; private set; }

		public double TrueAnomaly { get; private set; }

		public double SemiMajorAxis { get; private set; }

		public double SemiMinorAxis { get; private set; }

		private ManeuverNodeScript NextBurnNode => (Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript).PlayerCraft?.ChainNodeManager?.FirstManeuverNode;

		public CraftOrbitData(ICraftScript craftScript)
		{
			_craftScript = craftScript;
		}

		public void UpdateData()
		{
			ICraftNode craftNode = _craftScript.CraftNode;
			Parent = craftNode.Parent;
			if (!craftNode.InContactWithPlanet)
			{
				ApoapsisAltitude = craftNode.Orbit.ApoapsisDistance - craftNode.Parent.PlanetData.Radius;
				if (ApoapsisAltitude < 0.0)
				{
					ApoapsisAltitude = double.NaN;
					ApoapsisTime = double.NaN;
				}
				else
				{
					ApoapsisTime = craftNode.Orbit.GetTimeToApoapsis();
				}
				PeriapsisAltitude = craftNode.Orbit.PeriapsisDistance - craftNode.Parent.PlanetData.Radius;
				if (PeriapsisAltitude < 0.0)
				{
					PeriapsisAltitude = double.NaN;
					PeriapsisTime = double.NaN;
				}
				else
				{
					PeriapsisTime = craftNode.Orbit.GetTimeToPeriapsis();
				}
				Inclination = craftNode.Orbit.Inclination;
				Period = craftNode.Orbit.Period;
				Eccentricity = craftNode.Orbit.Eccentricity;
				MeanAnomaly = craftNode.Orbit.MeanAnomaly;
				MeanMotion = craftNode.Orbit.MeanMotion;
				PeriapsisArgument = craftNode.Orbit.PeriapsisAngle;
				RightAscension = craftNode.Orbit.RightAscensionOfAscendingNode;
				TrueAnomaly = craftNode.Orbit.TrueAnomaly;
				SemiMajorAxis = craftNode.Orbit.SemiMajorAxis;
				SemiMinorAxis = craftNode.Orbit.SemiMinorAxis;
			}
			else
			{
				ApoapsisAltitude = 0.0;
				ApoapsisTime = 0.0;
				PeriapsisAltitude = 0.0;
				PeriapsisTime = 0.0;
				Inclination = 0.0;
				Eccentricity = 0.0;
				Period = 0.0;
				MeanAnomaly = 0.0;
				MeanMotion = 0.0;
				PeriapsisArgument = 0.0;
				RightAscension = 0.0;
				TrueAnomaly = 0.0;
				SemiMajorAxis = 0.0;
				SemiMinorAxis = 0.0;
			}
		}
	}
}
