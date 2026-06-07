using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes
{
	public class SiblingAtPointTime : DrawMode
	{
		public override ModeType Mode => ModeType.SiblingAtPointTime;

		public override bool UpdateReferencePerPoint => true;

		public override IPlanetNode GetReferenceNode(MapOrbitInfo orbitInfo)
		{
			return DrawMode.GetLuna(orbitInfo.OrbitNode);
		}

		public override void UpdateReferenceNode(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointTime)
		{
			refInfo.ReferenceNode = GetReferenceNode(orbitInfo);
			refInfo.ReferenceNodeTime = orbitInfo.OrbitNode.Orbit.Time;
			refInfo.ReferenceNodeParentTime = base.GameTime.Time;
		}
	}
}
