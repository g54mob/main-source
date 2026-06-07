using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes
{
	public class ParentAtCurrentTime : DrawMode
	{
		public override ModeType Mode => ModeType.ParentAtCurrentTime;

		public override bool UpdateReferencePerPoint => false;

		public override IPlanetNode GetReferenceNode(MapOrbitInfo orbitInfo)
		{
			return orbitInfo.OrbitNode.Parent;
		}

		public override void UpdateReferenceNode(ref DrawModeReferenceInfo refInfo, MapOrbitInfo orbitInfo, double pointTime)
		{
			double time = base.GameTime.Time;
			refInfo.ReferenceNode = GetReferenceNode(orbitInfo);
			refInfo.ReferenceNodeTime = time;
			refInfo.ReferenceNodeParentTime = time;
		}
	}
}
