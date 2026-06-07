using System.Runtime.CompilerServices;
using System.Text;
using Pathfinding.Collections;
using Unity.Profiling;

namespace Pathfinding
{
	public class PathHandler
	{
		private ushort pathID;

		public readonly int threadID;

		public readonly int totalThreadCount;

		public readonly NNConstraintWithTraversalProvider constraintWrapper;

		internal readonly GlobalNodeStorage nodeStorage;

		private UnsafeSpan<TemporaryNode> temporaryNodes;

		public UnsafeSpan<PathNode> pathNodes;

		public BinaryHeap heap;

		public readonly StringBuilder DebugStringBuilder;

		public int numTemporaryNodes
		{
			[IgnoredByDeepProfiler]
			get;
			private set; }

		public uint temporaryNodeStartIndex
		{
			[IgnoredByDeepProfiler]
			get;
			private set; }

		public ushort PathID => 0;

		internal PathHandler(GlobalNodeStorage nodeStorage, int threadID, int totalThreadCount)
		{
		}

		public void InitializeForPath(Path p)
		{
		}

		public PathNode GetPathNode(GraphNode node, uint variant = 0u)
		{
			return default(PathNode);
		}

		public bool IsTemporaryNode(uint pathNodeIndex)
		{
			return false;
		}

		public uint AddTemporaryNode(TemporaryNode node)
		{
			return 0u;
		}

		public GraphNode GetNode(uint nodeIndex)
		{
			return null;
		}

		public ref TemporaryNode GetTemporaryNode(uint nodeIndex)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void LogVisitedNode(uint pathNodeIndex, uint h, uint g)
		{
		}

		public void ClearPathIDs()
		{
		}

		public void Dispose()
		{
		}
	}
}
