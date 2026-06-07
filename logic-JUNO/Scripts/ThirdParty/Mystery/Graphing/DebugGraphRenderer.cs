namespace Mystery.Graphing
{
	public class DebugGraphRenderer : IGraphConsoleRenderer
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
