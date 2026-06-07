namespace SpaceGraphicsToolkit
{
	public class SgtFloatingWarpSmoothstep : SgtFloatingWarp
	{
		public double WarpTime;

		public int Smoothness;

		public bool Warping;

		public double Progress;

		public SgtPosition StartPosition;

		public SgtPosition TargetPosition;

		public override bool CanAbortWarp => false;

		public override void WarpTo(SgtPosition position)
		{
		}

		public override void AbortWarp()
		{
		}

		protected virtual void Update()
		{
		}

		private static double SmoothStep(double m, int n)
		{
			return 0.0;
		}
	}
}
