namespace Timberborn.WaterSystem
{
	internal readonly struct TargetedDiffusion
	{
		public readonly int TargetIndex3D;

		public readonly int OriginIndex3D;

		public TargetedDiffusion(int targetIndex3D, int originIndex3D)
		{
			TargetIndex3D = targetIndex3D;
			OriginIndex3D = originIndex3D;
		}
	}
}
