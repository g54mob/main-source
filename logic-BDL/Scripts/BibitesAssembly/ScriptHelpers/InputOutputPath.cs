using System.Collections.Generic;
using System.Linq;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace ScriptHelpers
{
	public class InputOutputPath
	{
		public readonly NodeSortHelper sourceNode;

		public NodeSortHelper nextNode;

		public readonly List<HiddenDepthInPath> visitedNodes;

		private readonly List<NodeSortHelper> blockedNodes;

		public readonly List<ConnectionSortHelper> connections;

		public float accumulatedAffinity;

		public bool blocked;

		public bool done;

		public int totalDepth;

		public bool towardOutputs;

		private int recursivity;

		public float normalizedAffinity => Mathf.Pow(Mathf.Abs(accumulatedAffinity), 1f / (float)(1 + recursivity));

		public InputOutputPath(NodeSortHelper start, bool directionIsTowardOutputs)
		{
			sourceNode = start;
			nextNode = start;
			accumulatedAffinity = 1f;
			totalDepth = 0;
			visitedNodes = new List<HiddenDepthInPath>();
			blockedNodes = new List<NodeSortHelper>();
			connections = new List<ConnectionSortHelper>();
			recursivity = 0;
			blocked = false;
			done = false;
			towardOutputs = directionIsTowardOutputs;
		}

		public InputOutputPath(InputOutputPath pathToDuplicate)
		{
			sourceNode = pathToDuplicate.sourceNode;
			nextNode = pathToDuplicate.nextNode;
			accumulatedAffinity = pathToDuplicate.accumulatedAffinity;
			totalDepth = pathToDuplicate.totalDepth;
			recursivity = pathToDuplicate.recursivity;
			towardOutputs = pathToDuplicate.towardOutputs;
			visitedNodes = pathToDuplicate.visitedNodes.ToList();
			for (int i = 0; i < visitedNodes.Count; i++)
			{
				HiddenDepthInPath value = visitedNodes[i];
				value.path = this;
				visitedNodes[i] = value;
			}
			blockedNodes = pathToDuplicate.blockedNodes.ToList();
			connections = pathToDuplicate.connections.ToList();
			done = false;
			blocked = false;
		}

		public bool AdvanceAndCheckDone(ConnectionSortHelper nextConnection)
		{
			accumulatedAffinity *= (nextConnection.enabled ? Mathf.Abs(nextConnection.value) : Mathf.Sqrt(Mathf.Abs(nextConnection.value)));
			nextNode = (towardOutputs ? nextConnection.nodeOut : nextConnection.nodeIn);
			if (!connections.Contains(nextConnection))
			{
				connections.Add(nextConnection);
				totalDepth++;
			}
			blocked = blockedNodes.Contains(nextNode);
			done = nextNode.archetype == (NEATBrain.NodeArchetype)(towardOutputs ? 1 : 0);
			if (done)
			{
				foreach (HiddenDepthInPath visitedNode in visitedNodes)
				{
					visitedNode.node.AddHiddenAffinitiesOfPath(visitedNode, totalDepth);
				}
			}
			if (blocked || done)
			{
				return true;
			}
			NodeSortHelper nodeToAdd = nextNode;
			if (visitedNodes.Any((HiddenDepthInPath n) => n.node == nodeToAdd))
			{
				blockedNodes.Add(nextNode);
				recursivity++;
			}
			else
			{
				HiddenDepthInPath item = new HiddenDepthInPath(this, nextNode);
				visitedNodes.Add(item);
			}
			return false;
		}
	}
}
