using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes
{
	public class ParentAtReferenceTime : DrawMode
	{
		public override ModeType Mode => ModeType.ParentAtReferenceTime;

		public override bool UpdateReferencePerPoint => false;

		public override IPlanetNode GetReferenceNode(MapOrbitInfo orbitInfo)
		{
			return orbitInfo.OrbitNode.Parent;
		}

		public override void UpdateReferenceNode(ref DrawModeReferenceInfo refnfo, MapOrbitInfo orbitInfo, double pointTime)
		{
			refnfo.ReferenceNode = GetReferenceNode(orbitInfo);
			refnfo.ReferenceNodeTime = orbitInfo.OrbitNode.Orbit.Time;
			refnfo.ReferenceNodeParentTime = base.GameTime.Time;
		}
	}
}
