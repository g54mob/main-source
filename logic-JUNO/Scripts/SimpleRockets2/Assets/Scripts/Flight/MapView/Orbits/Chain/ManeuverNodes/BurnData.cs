using Assets.Scripts.Flight.Sim;
using ModApi.Craft;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes
{
	public class BurnData
	{
		private ICraftScript _craftScript;

		private ManeuverNodeScript _maneuverNode;

		private IMapOptions _options;

		public BurnAccuracy BurnAccuracy { get; private set; }

		public double BurnDuration { get; private set; }

		public int BurnPasses { get; private set; } = 1;

		public double BurnTimeRemaining { get; private set; }

		public Vector3d DeltaVApplied { get; private set; }

		public double DeltaVMagRemaining { get; private set; }

		public Vector3d DeltaVPerPass => _maneuverNode.DeltaV / BurnPasses;

		public Vector3d DeltaVRemaining { get; private set; }

		public double EstimatedAutoBurnDuration { get; private set; }

		public double PercentNormal { get; private set; }

		public double PercentPrograde { get; private set; }

		public double PercentRadial { get; private set; }

		public double TimeToInitiateBurn { get; private set; }

		public double TimeToInitiateTurn { get; private set; }

		public double TimeToLockNode { get; private set; }

		public double TimeToNode { get; private set; }

		public BurnData(IIocContainer ioc, ManeuverNodeScript maneuverNode, ICraftScript craftScript)
		{
			_options = ioc.Resolve<IMapOptions>();
			_maneuverNode = maneuverNode;
			_craftScript = craftScript;
		}

		public bool ShouldInitiateBurn()
		{
			return TimeToNode <= TimeToInitiateBurn;
		}

		public bool ShouldInitiateTurn()
		{
			return TimeToNode <= TimeToInitiateTurn;
		}

		public bool ShouldLockNode()
		{
			return TimeToNode <= TimeToLockNode;
		}

		public void Update(bool burnInProgress)
		{
			BurnDuration = MathUtils.CalculateBurnDuration(_craftScript.FlightData.MaxActiveEngineThrust, _craftScript.Mass, (float)_maneuverNode.DeltaV.magnitude);
			if (_maneuverNode.DeltaVMag > 0.0)
			{
				PercentPrograde = Mathd.Abs(_maneuverNode.DeltaVPrograde / _maneuverNode.DeltaVMag);
				PercentNormal = Mathd.Abs(_maneuverNode.DeltaVNormal / _maneuverNode.DeltaVMag);
				PercentRadial = Mathd.Abs(_maneuverNode.DeltaVRadial / _maneuverNode.DeltaVMag);
			}
			else
			{
				double num = (PercentRadial = 1.0 / 3.0);
				double percentPrograde = (PercentNormal = num);
				PercentPrograde = percentPrograde;
			}
			EstimatedAutoBurnDuration = BurnDuration + (double)(_craftScript.FlightData.WeightedThrottleResponseTime * 2f);
			TimeToNode = _maneuverNode.GetTimeToNode(fullTime: true, absoluteTime: false);
			double num4 = PercentPrograde + PercentNormal + PercentRadial;
			double num5 = 0.5 * (PercentPrograde / num4);
			double num6 = 0.35 * (PercentNormal / num4);
			double num7 = 0.4345 * (PercentRadial / num4);
			double num8 = num5 + num7 + num6;
			TimeToInitiateBurn = EstimatedAutoBurnDuration * num8;
			TimeToLockNode = TimeToInitiateBurn + 10.0;
			TimeToInitiateTurn = TimeToLockNode * 20.0;
			BurnAccuracy = GetBurnAccuracy(_maneuverNode, _options.ManeuverNodes.ShowBurnAccuracyDebugGizmos);
			if (burnInProgress)
			{
				DeltaVRemaining = _maneuverNode.GetDeltaVToCompleteManeuver();
				DeltaVMagRemaining = DeltaVRemaining.magnitude;
				DeltaVApplied = _maneuverNode.DeltaV - DeltaVRemaining;
				BurnTimeRemaining = MathUtils.CalculateBurnDuration(_craftScript.FlightData.CurrentEngineThrust, _craftScript.Mass, (float)DeltaVMagRemaining);
			}
			else
			{
				DeltaVApplied = Vector3d.zero;
				DeltaVRemaining = _maneuverNode.DeltaV;
				DeltaVMagRemaining = DeltaVRemaining.magnitude;
				BurnTimeRemaining = BurnDuration;
			}
		}

		private static BurnAccuracy GetBurnAccuracy(ManeuverNodeScript maneuverNode, bool showDebug)
		{
			IOrbitNode orbitNode = maneuverNode.OrbitInfo.OrbitNode;
			IOrbit orbit = maneuverNode.ListNode.Previous.Value.OrbitInfo.OrbitNode.Orbit;
			IOrbitPoint pointAtTime = OrbitMath.GetPointAtTime(orbit, orbitNode.Orbit.Time - maneuverNode.BurnData.TimeToInitiateBurn);
			IOrbitPoint pointAtTime2 = OrbitMath.GetPointAtTime(orbit, orbitNode.Orbit.Time);
			if (showDebug)
			{
				MapUtils.DrawDebugRay("UnalteredStartVel", orbitNode.Parent, pointAtTime, pointAtTime.Velocity.normalized, 100.0, Color.blue);
				MapUtils.DrawDebugRay("UnalteredBurnNodeVel", orbitNode.Parent, pointAtTime2, pointAtTime2.Velocity.normalized, 100.0, Color.green);
			}
			double d = Mathd.Clamp01(Vector3d.Dot(pointAtTime.Velocity.normalized, pointAtTime2.Velocity.normalized));
			double num = 1.0;
			if (maneuverNode.DeltaVMag > 0.0)
			{
				double p = Mathd.Pow(1.0 + maneuverNode.BurnData.PercentNormal + maneuverNode.BurnData.PercentRadial, 2.5);
				num = Mathd.Pow(d, p);
			}
			if (num > 0.95)
			{
				return BurnAccuracy.High;
			}
			if (num > 0.9)
			{
				return BurnAccuracy.Med;
			}
			if (num > 0.85)
			{
				return BurnAccuracy.Low;
			}
			return BurnAccuracy.NotRecommended;
		}
	}
}
