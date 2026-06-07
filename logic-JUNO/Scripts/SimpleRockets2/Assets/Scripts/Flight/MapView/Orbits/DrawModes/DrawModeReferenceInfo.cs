using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes
{
	public struct DrawModeReferenceInfo
	{
		public IPlanetNode ReferenceNode { get; set; }

		public double ReferenceNodeParentTime { get; set; }

		public double ReferenceNodeTime { get; set; }
	}
}
