namespace Timberborn.WaterSystem
{
	public struct TargetedFlow
	{
		public float Flow;

		public int Index3D;

		public TargetedFlow(float flow, int index3D)
		{
			Flow = flow;
			Index3D = index3D;
		}
	}
}
