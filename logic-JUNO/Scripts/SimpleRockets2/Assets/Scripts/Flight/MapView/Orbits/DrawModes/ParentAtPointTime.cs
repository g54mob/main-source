using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes
{
	public class ParentAtPointTime : DrawMode
	{
		public override ModeType Mode => ModeType.ParentAtPointTime;

		public override bool UpdateReferencePerPoint => true;

		public override IPlanetNode GetReferenceNode(MapOrbitInfo orbitInfo)
		{
			return orbitInfo.OrbitNode.Parent;
		}

		public override void UpdateReferenceNode(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointTime)
		{
			refInfo.ReferenceNode = GetReferenceNode(orbitInfo);
			refInfo.ReferenceNodeTime = pointTime;
			refInfo.ReferenceNodeParentTime = pointTime;
		}
	}
}
