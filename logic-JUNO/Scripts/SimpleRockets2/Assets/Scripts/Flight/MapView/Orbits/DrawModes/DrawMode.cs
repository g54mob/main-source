using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes
{
	public abstract class DrawMode : IDrawMode
	{
		public IGameTime GameTime { get; }

		public abstract ModeType Mode { get; }

		public abstract bool UpdateReferencePerPoint { get; }

		public DrawMode()
		{
			GameTime = MapViewManagerScript.Instance.Ioc.Resolve<IGameTime>();
		}

		public static IPlanetNode GetLuna(IOrbitNode nodeInChain)
		{
			IPlanetNode parent = nodeInChain.Parent;
			while (parent.Parent != null)
			{
				parent = parent.Parent;
			}
			return parent.ChildPlanets[0].ChildPlanets[0];
		}

		public virtual double? GetLineEndNu(IPlanetNode referenceNode, MapOrbitInfo orbitInfo)
		{
			if (!MapUtils.SamePlanet(referenceNode, orbitInfo.OrbitNode.Parent) && orbitInfo.OrbitNode is PlanetNode)
			{
				return orbitInfo.OrbitNode.Orbit.TrueAnomaly + 0.5;
			}
			return null;
		}

		public abstract IPlanetNode GetReferenceNode(MapOrbitInfo orbitInfo);

		public Vector3d GetReferenceSolarNodePosition(DrawModeReferenceInfo refInfo)
		{
			if (refInfo.ReferenceNodeTime == refInfo.ReferenceNodeParentTime)
			{
				return refInfo.ReferenceNode.GetSolarPositionAtTime(refInfo.ReferenceNodeTime);
			}
			if (refInfo.ReferenceNode.Orbit != null)
			{
				Vector3d position = OrbitMath.GetPointAtTime(refInfo.ReferenceNode.Orbit, refInfo.ReferenceNodeTime).Position;
				Vector3d solarPositionAtTime = refInfo.ReferenceNode.Parent.GetSolarPositionAtTime(refInfo.ReferenceNodeParentTime);
				return position + solarPositionAtTime;
			}
			return Vector3d.zero;
		}

		public Vector3d GetReferenceSolarPosition(MapOrbitInfo orbitInfo)
		{
			DrawModeReferenceInfo refInfo = default(DrawModeReferenceInfo);
			UpdateReferenceNode(ref refInfo, orbitInfo, orbitInfo.OrbitNode.Orbit.Time);
			return GetReferenceSolarNodePosition(refInfo);
		}

		public Vector3d GetSolarPosition(DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, IOrbitPoint point)
		{
			return GetSolarPosition(refInfo, orbitInfo, point.Time, point.Position);
		}

		public Vector3d GetSolarPosition(MapOrbitInfo orbitInfo, IOrbitPoint point)
		{
			DrawModeReferenceInfo refInfo = default(DrawModeReferenceInfo);
			UpdateReferenceNode(ref refInfo, orbitInfo, point.Time);
			return GetSolarPosition(refInfo, orbitInfo, point.Time, point.Position);
		}

		public Vector3d GetSolarPositionAtCurrent(MapOrbitInfo orbitInfo)
		{
			DrawModeReferenceInfo refInfo = default(DrawModeReferenceInfo);
			UpdateReferenceNode(ref refInfo, orbitInfo, orbitInfo.OrbitNode.Orbit.Time);
			IOrbit orbit = orbitInfo.OrbitNode.Orbit;
			return GetSolarPosition(refInfo, orbitInfo, orbit.Time, orbit.Position);
		}

		public Vector3d GetSolarPositionFromNu(MapOrbitInfo orbitInfo, double trueAnomaly)
		{
			DrawModeReferenceInfo refInfo = default(DrawModeReferenceInfo);
			UpdateReferenceNodeFromNu(ref refInfo, orbitInfo, trueAnomaly);
			return GetSolarPosition(refInfo, orbitInfo, OrbitMath.GetPointAtTrueAnomaly(orbitInfo.OrbitNode.Orbit, trueAnomaly));
		}

		public abstract void UpdateReferenceNode(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointTime);

		public void UpdateReferenceNodeFromNu(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointNu)
		{
			double timeAtTrueAnomaly = OrbitMath.GetTimeAtTrueAnomaly(orbitInfo.OrbitNode.Orbit, pointNu);
			UpdateReferenceNode(ref refInfo, orbitInfo, timeAtTrueAnomaly);
		}

		public void UpdateReferenceNodeFromPoint(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, IOrbitPoint point)
		{
			UpdateReferenceNode(ref refInfo, orbitInfo, point.Time);
		}

		public void UpdateReferenceNoderPerOrbit(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo)
		{
			UpdateReferenceNode(ref refInfo, orbitInfo, double.NaN);
		}

		private Vector3d GetPositionRelativeToReferenceNode(IOrbitNode pointNode, double pointTime, Vector3d localPosition, IOrbitNode referenceNode)
		{
			Vector3d vector3d;
			Vector3d vector3d2;
			if (!MapUtils.SamePlanet(pointNode.Parent, referenceNode.Parent))
			{
				Vector3d solarPositionAtTime = MapUtils.GetCommonAncestor(pointNode, referenceNode).GetSolarPositionAtTime(pointTime);
				vector3d = pointNode.GetSolarPositionAtTime(pointTime) - solarPositionAtTime;
				vector3d2 = referenceNode.GetSolarPositionAtTime(pointTime) - solarPositionAtTime;
			}
			else
			{
				vector3d = localPosition;
				vector3d2 = OrbitMath.GetPointAtTime(referenceNode.Orbit, pointTime).Position;
			}
			return vector3d - vector3d2;
		}

		private Vector3d GetSolarPosition(DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointTime, Vector3d localPosition)
		{
			Vector3d vector3d;
			Vector3d referenceSolarNodePosition;
			if (!MapUtils.SamePlanet(orbitInfo.OrbitNode.Parent, refInfo.ReferenceNode))
			{
				vector3d = GetPositionRelativeToReferenceNode(orbitInfo.OrbitNode, pointTime, localPosition, refInfo.ReferenceNode);
				referenceSolarNodePosition = GetReferenceSolarNodePosition(refInfo);
			}
			else
			{
				vector3d = localPosition;
				referenceSolarNodePosition = GetReferenceSolarNodePosition(refInfo);
			}
			return vector3d + referenceSolarNodePosition;
		}
	}
}
