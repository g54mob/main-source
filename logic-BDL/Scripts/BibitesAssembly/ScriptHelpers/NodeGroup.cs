using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptHelpers
{
	public class NodeGroup
	{
		public float groupStart;

		public float groupHeight;

		public readonly List<NodeSortHelper> inputs = new List<NodeSortHelper>();

		public readonly List<NodeSortHelper> outputs = new List<NodeSortHelper>();

		public readonly List<NodeSortHelper> hidden = new List<NodeSortHelper>();

		public readonly List<NodeSortHelper> nodes = new List<NodeSortHelper>();

		public readonly List<ConnectionSortHelper> connections = new List<ConnectionSortHelper>();

		public readonly List<InputOutputAffinity> inputOutputAffinities = new List<InputOutputAffinity>();

		public readonly List<InputOutputPath> paths = new List<InputOutputPath>();

		public bool isInputlessOutputsGroup;

		public int maxDepth
		{
			get
			{
				if (paths.Count >= 1)
				{
					return paths.Max((InputOutputPath p) => p.totalDepth);
				}
				return 0;
			}
		}

		public int size => inputs.Count + outputs.Count;

		public float weight => (float)((inputs.Count > 0) ? (Mathf.Max(inputs.Count, outputs.Count) - 1) : 0) + (float)hidden.Count / Mathf.Sqrt(2f + (float)hidden.Count + (float)inputs.Count + (float)outputs.Count);

		public void FinalizeInternalStructure()
		{
			foreach (InputOutputAffinity inputOutputAffinity in inputOutputAffinities)
			{
				foreach (NodeSortHelper hiddenNode in inputOutputAffinity.hiddenNodes)
				{
					if (!hidden.Contains(hiddenNode))
					{
						hidden.Add(hiddenNode);
					}
				}
				foreach (ConnectionSortHelper connection in inputOutputAffinity.connections)
				{
					if (!connections.Contains(connection))
					{
						connections.Add(connection);
					}
				}
			}
			nodes.AddRange(inputs);
			nodes.AddRange(outputs);
			nodes.AddRange(hidden);
			for (int i = 0; i < inputs.Count; i++)
			{
				inputs[i].groupPos = new Vector2(0f, (float)i / ((float)inputs.Count - 1f));
			}
			if (isInputlessOutputsGroup)
			{
				for (int j = 0; j < outputs.Count; j++)
				{
					outputs[j].groupPos = new Vector2((float)(j + 1) / (float)outputs.Count, 1f);
				}
			}
			else
			{
				for (int k = 0; k < outputs.Count; k++)
				{
					outputs[k].groupPos = new Vector2(1f, (float)k / ((float)outputs.Count - 1f));
				}
			}
		}

		public void SetStartEnd(float start, float height)
		{
			groupStart = start;
			groupHeight = height;
		}
	}
}
