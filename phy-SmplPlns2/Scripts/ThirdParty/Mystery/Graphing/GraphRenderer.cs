using UnityEngine;

namespace Mystery.Graphing
{
	[AddComponentMenu("Squiggle/Graph Renderer")]
	public class GraphRenderer : SRPGraphRenderer
	{
		public GraphConsole GraphConsole;

		protected override IGraphConsole LoadGraph()
		{
			return GraphConsole;
		}
	}
}
