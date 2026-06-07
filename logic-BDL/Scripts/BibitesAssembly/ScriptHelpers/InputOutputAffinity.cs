using System.Collections.Generic;
using System.Linq;

namespace ScriptHelpers
{
	public class InputOutputAffinity
	{
		public float affinity;

		public NodeSortHelper nodeIn;

		public NodeSortHelper nodeOut;

		public readonly List<NodeSortHelper> hiddenNodes;

		public readonly List<ConnectionSortHelper> connections;

		public readonly List<InputOutputPath> paths;

		public InputOutputAffinity(InputOutputPath path)
		{
			nodeIn = (path.towardOutputs ? path.sourceNode : (path.blocked ? null : path.nextNode));
			nodeOut = ((!path.towardOutputs) ? path.sourceNode : (path.blocked ? null : path.nextNode));
			affinity = path.normalizedAffinity;
			hiddenNodes = path.visitedNodes.Select((HiddenDepthInPath n) => n.node).ToList();
			connections = path.connections.ToList();
			paths = new List<InputOutputPath> { path };
			nodeIn?.affinities.Add(this);
			nodeOut?.affinities.Add(this);
		}

		public void CollapsePathInto(InputOutputPath otherPath)
		{
			affinity += otherPath.normalizedAffinity;
			paths.Add(otherPath);
			foreach (HiddenDepthInPath visitedNode in otherPath.visitedNodes)
			{
				if (!hiddenNodes.Contains(visitedNode.node))
				{
					hiddenNodes.Add(visitedNode.node);
				}
			}
			foreach (ConnectionSortHelper connection in otherPath.connections)
			{
				if (!connections.Contains(connection))
				{
					connections.Add(connection);
				}
			}
		}
	}
}
