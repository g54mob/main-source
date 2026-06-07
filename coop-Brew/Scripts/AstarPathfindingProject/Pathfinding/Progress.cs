namespace Pathfinding
{
	public readonly struct Progress
	{
		public readonly float progress;

		internal readonly ScanningStage stage;

		internal readonly int graphIndex;

		internal readonly int graphCount;

		public Progress(float progress, ScanningStage stage, int graphIndex = 0, int graphCount = 0)
		{
			this.progress = 0f;
			this.stage = default(ScanningStage);
			this.graphIndex = 0;
			this.graphCount = 0;
		}

		public Progress MapTo(float min, float max)
		{
			return default(Progress);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
