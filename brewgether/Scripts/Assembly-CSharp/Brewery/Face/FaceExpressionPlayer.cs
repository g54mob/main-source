namespace Brewery.Face
{
	public struct FaceExpressionPlayer
	{
		private FaceExpression _expression;

		private FaceExpressionPlayMode _mode;

		private float _elapsed;

		private bool _finished;

		public FaceExpression Expression => null;

		public bool IsFinished => false;

		public void Begin(FaceExpression expression, FaceExpressionPlayMode mode)
		{
		}

		public void Reset()
		{
		}

		public void Tick(FaceFrame frame, FaceDriver driver, float dt, float sourceFade)
		{
		}
	}
}
