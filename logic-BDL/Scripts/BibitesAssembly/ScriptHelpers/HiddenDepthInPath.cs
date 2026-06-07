namespace ScriptHelpers
{
	public struct HiddenDepthInPath
	{
		public InputOutputPath path;

		public NodeSortHelper node;

		public int depth;

		public float accumulatedAffinity;

		public HiddenDepthInPath(InputOutputPath path, NodeSortHelper node)
		{
			this.path = path;
			this.node = node;
			depth = path.totalDepth;
			accumulatedAffinity = path.accumulatedAffinity;
		}
	}
}
