using System.Collections.Generic;
using System.Linq;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace ScriptHelpers
{
	public class NodeSortHelper
	{
		public NEATBrain.Node node;

		public Vector2 groupPos = Vector2.zero;

		public Vector2 panelPos = Vector2.zero;

		public Vector2 tempPos;

		public Vector2 tempVel;

		public Vector2 tempAcc;

		public readonly List<ConnectionSortHelper> inputConnections = new List<ConnectionSortHelper>();

		public readonly List<ConnectionSortHelper> outputConnections = new List<ConnectionSortHelper>();

		public readonly List<InputOutputAffinity> affinities = new List<InputOutputAffinity>();

		public readonly Dictionary<NodeSortHelper, HiddenNodeAffinity> hiddenAffinitiesToInputsOutputs = new Dictionary<NodeSortHelper, HiddenNodeAffinity>();

		public int index => node.Index;

		public long inov => node.Inov;

		public NEATBrain.NodeArchetype archetype => node.archetype;

		public List<ConnectionSortHelper> connections => inputConnections.Union(outputConnections).ToList();

		public NodeSortHelper(NEATBrain.Node refNode)
		{
			node = refNode;
			groupPos = new Vector2((archetype == NEATBrain.NodeArchetype.Output) ? 1f : 0f, 0f);
		}

		public void AddHiddenAffinitiesOfPath(HiddenDepthInPath depth, int totalDepth)
		{
			NodeSortHelper sourceNode = depth.path.sourceNode;
			NodeSortHelper nextNode = depth.path.nextNode;
			float accumulatedAffinity = depth.accumulatedAffinity;
			float num = depth.path.accumulatedAffinity / accumulatedAffinity;
			float num2 = depth.depth;
			if (hiddenAffinitiesToInputsOutputs.TryGetValue(sourceNode, out var value))
			{
				value.AddAffinity(accumulatedAffinity, (float)totalDepth / num2);
			}
			else
			{
				hiddenAffinitiesToInputsOutputs.Add(sourceNode, new HiddenNodeAffinity(accumulatedAffinity, (float)totalDepth / num2));
			}
			if (hiddenAffinitiesToInputsOutputs.TryGetValue(nextNode, out var value2))
			{
				value2.AddAffinity(num, (float)totalDepth / ((float)totalDepth - num2));
			}
			else
			{
				hiddenAffinitiesToInputsOutputs.Add(nextNode, new HiddenNodeAffinity(num, (float)totalDepth / ((float)totalDepth - num2)));
			}
		}
	}
}
