using System.Text;

namespace Pathfinding
{
	public class PathHandler
	{
		private ushort pathID;

		public readonly int threadID;

		public readonly int totalThreadCount;

		public readonly BinaryHeap heap;

		public PathNode[] nodes;

		public readonly StringBuilder DebugStringBuilder;

		public ushort PathID => 0;

		public PathHandler(int threadID, int totalThreadCount)
		{
		}

		public void InitializeForPath(Path p)
		{
		}

		public void DestroyNode(GraphNode node)
		{
		}

		public void InitializeNode(GraphNode node)
		{
		}

		public PathNode GetPathNode(int nodeIndex)
		{
			return null;
		}

		public PathNode GetPathNode(GraphNode node)
		{
			return null;
		}

		public void ClearPathIDs()
		{
		}
	}
}
