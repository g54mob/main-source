using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes
{
	public class BasicDrawMode : IDrawMode
	{
		public IGameTime GameTime { get; }

		public ModeType Mode => ModeType.Basic;

		public bool UpdateReferencePerPoint => false;

		public BasicDrawMode()
		{
			GameTime = MapViewManagerScript.Instance.Ioc.Resolve<IGameTime>();
		}

		public double? GetLineEndNu(IPlanetNode referenceNode, MapOrbitInfo orbitInfo)
		{
			return null;
		}

		public IPlanetNode GetReferenceNode(MapOrbitInfo orbitInfo)
		{
			return orbitInfo.OrbitNode.Parent;
		}

		public Vector3d GetReferenceSolarNodePosition(DrawModeReferenceInfo refInfo)
		{
			return refInfo.ReferenceNode.SolarPosition;
		}

		public Vector3d GetReferenceSolarPosition(MapOrbitInfo orbitInfo)
		{
			return orbitInfo.OrbitNode.Parent.SolarPosition;
		}

		public Vector3d GetSolarPosition(MapOrbitInfo orbitInfo, IOrbitPoint point)
		{
			return point.Position + orbitInfo.OrbitNode.Parent.SolarPosition;
		}

		public Vector3d GetSolarPosition(DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, IOrbitPoint point)
		{
			return GetSolarPosition(orbitInfo, point);
		}

		public Vector3d GetSolarPositionAtCurrent(MapOrbitInfo orbitInfo)
		{
			return orbitInfo.OrbitNode.Position + orbitInfo.OrbitNode.Parent.SolarPosition;
		}

		public Vector3d GetSolarPositionFromNu(MapOrbitInfo orbitInfo, double trueAnomaly)
		{
			if (orbitInfo.OrbitNode.Orbit.TrueAnomaly == trueAnomaly)
			{
				return orbitInfo.OrbitNode.SolarPosition;
			}
			if (true)
			{
				double timeAtTrueAnomaly = OrbitMath.GetTimeAtTrueAnomaly(orbitInfo.OrbitNode.Orbit, trueAnomaly);
				return OrbitMath.GetPointAtTime(orbitInfo.OrbitNode.Orbit, timeAtTrueAnomaly).Position + orbitInfo.OrbitNode.Parent.SolarPosition;
			}
			double timeAtTrueAnomaly2 = OrbitMath.GetTimeAtTrueAnomaly(orbitInfo.OrbitNode.Orbit, trueAnomaly);
			return orbitInfo.OrbitNode.GetSolarPositionAtTime(timeAtTrueAnomaly2);
		}

		public void UpdateReferenceNode(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointTime)
		{
			refInfo.ReferenceNode = GetReferenceNode(orbitInfo);
			refInfo.ReferenceNodeTime = pointTime;
			refInfo.ReferenceNodeParentTime = GameTime.Time;
		}

		public void UpdateReferenceNodeFromNu(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointNu)
		{
			refInfo.ReferenceNode = GetReferenceNode(orbitInfo);
			refInfo.ReferenceNodeTime = orbitInfo.OrbitNode.Orbit.Time;
			refInfo.ReferenceNodeParentTime = orbitInfo.OrbitNode.Orbit.Time;
		}

		public void UpdateReferenceNodeFromPoint(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, IOrbitPoint point)
		{
			refInfo.ReferenceNode = GetReferenceNode(orbitInfo);
			refInfo.ReferenceNodeTime = orbitInfo.OrbitNode.Orbit.Time;
			refInfo.ReferenceNodeParentTime = orbitInfo.OrbitNode.Orbit.Time;
		}

		public void UpdateReferenceNoderPerOrbit(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo)
		{
			refInfo.ReferenceNode = GetReferenceNode(orbitInfo);
			refInfo.ReferenceNodeTime = orbitInfo.OrbitNode.Orbit.Time;
			refInfo.ReferenceNodeParentTime = orbitInfo.OrbitNode.Orbit.Time;
		}
	}
}
