using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.ControlSurfaces
{
	public abstract class TrailingFlapBase : EdgeSurfaceBase
	{
		public override bool IsLeadingEdge => false;

		public override float DefaultStartPos => -0.25f;

		protected override float2 MinMaxChordSize => new float2(0.05f, 0.8f);
	}
}
