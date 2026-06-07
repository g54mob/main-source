namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	public readonly struct Args
	{
		public readonly Preprocessor Preprocessor;

		public readonly int SloanMaxIters;

		public readonly bool AutoHolesAndBoundary;

		public readonly bool RefineMesh;

		public readonly bool RestoreBoundary;

		public readonly bool ValidateInput;

		public readonly bool Verbose;

		public readonly float RefinementThresholdAngle;

		public readonly float RefinementThresholdArea;

		public Args(Preprocessor preprocessor, int sloanMaxIters, bool autoHolesAndBoundary, bool refineMesh, bool restoreBoundary, bool validateInput, bool verbose, float refinementThresholdAngle, float refinementThresholdArea)
		{
			Preprocessor = default(Preprocessor);
			SloanMaxIters = 0;
			AutoHolesAndBoundary = false;
			RefineMesh = false;
			RestoreBoundary = false;
			ValidateInput = false;
			Verbose = false;
			RefinementThresholdAngle = 0f;
			RefinementThresholdArea = 0f;
		}

		public static Args Default(Preprocessor preprocessor = Preprocessor.None, int sloanMaxIters = 1000000, bool autoHolesAndBoundary = false, bool refineMesh = false, bool restoreBoundary = false, bool validateInput = true, bool verbose = true, float refinementThresholdAngle = 0.08726646f, float refinementThresholdArea = 1f)
		{
			return default(Args);
		}

		public static implicit operator Args(TriangulationSettings settings)
		{
			return default(Args);
		}

		public Args With(Preprocessor? preprocessor = null, int? sloanMaxIters = null, bool? autoHolesAndBoundary = null, bool? refineMesh = null, bool? restoreBoundary = null, bool? validateInput = null, bool? verbose = null, float? refinementThresholdAngle = null, float? refinementThresholdArea = null)
		{
			return default(Args);
		}
	}
}
