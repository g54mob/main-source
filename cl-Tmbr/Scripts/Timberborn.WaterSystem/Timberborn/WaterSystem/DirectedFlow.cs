namespace Timberborn.WaterSystem
{
	internal readonly struct DirectedFlow
	{
		public readonly float Flow;

		public readonly int TargetIndex3D;

		public readonly int OriginIndex3D;

		public DirectedFlow(float flow, int targetIndex3D, int originIndex3D)
		{
			Flow = flow;
			TargetIndex3D = targetIndex3D;
			OriginIndex3D = originIndex3D;
		}

		public DirectedFlow MultiplyFlow(float modifer)
		{
			return new DirectedFlow(Flow * modifer, TargetIndex3D, OriginIndex3D);
		}
	}
}
