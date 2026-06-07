using UnityEngine;

namespace Mystery.Graphing
{
	[AddComponentMenu("Squiggle/Debug Graph Renderer")]
	public class DebugGraphRenderer : SRPGraphRenderer
	{
		public string GraphName = typeof(double).Name;

		protected override IGraphConsole LoadGraph()
		{
			foreach (IGraphConsole item in DebugGraph.GetGraphEnumerator())
			{
				if (item.Name == GraphName)
				{
					return item;
				}
			}
			return null;
		}
	}
}
