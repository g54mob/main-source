using System;
using System.Collections.Generic;
using System.Linq;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace ScriptHelpers
{
	public static class BrainSorter
	{
		public const int MaxNodePath = 250;

		public static float enabledFactor = 1f;

		public static float disabledFactor = 0.5f;

		public static float initialPlacementTemp = 0.1f;

		public static float connectionPush = 1f;

		public static float repulsionFactor = 1f;

		public static float nonHiddenRepulsionFactor = 0f;

		public static List<NodeGroup> MakeGroups(List<NEATBrain.Node> nodes, List<NEATBrain.Synaps> connections)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			Dictionary<int, NodeSortHelper> dictionary = new Dictionary<int, NodeSortHelper>();
			foreach (NEATBrain.Synaps connection in connections)
			{
				if (!list.Contains(connection.NodeIn))
				{
					list.Add(connection.NodeIn);
				}
				if (!list.Contains(connection.NodeOut))
				{
					list.Add(connection.NodeOut);
				}
			}
			foreach (NEATBrain.Node node in nodes)
			{
				if (node.archetype == NEATBrain.NodeArchetype.Output && (node.Type == NEATBrain.NodeType.Sigmoid || Mathf.Abs(node.baseActivation) != 0f) && !list.Contains(node.Index))
				{
					list2.Add(node.Index);
					list.Add(node.Index);
				}
			}
			foreach (int item2 in list)
			{
				dictionary.Add(item2, new NodeSortHelper(nodes[item2]));
			}
			foreach (NEATBrain.Synaps connection2 in connections)
			{
				ConnectionSortHelper item = new ConnectionSortHelper(connection2, dictionary[connection2.NodeIn], dictionary[connection2.NodeOut]);
				dictionary[connection2.NodeIn].outputConnections.Add(item);
				dictionary[connection2.NodeOut].inputConnections.Add(item);
			}
			List<InputOutputPath> list3 = new List<InputOutputPath>();
			List<InputOutputPath> list4 = new List<InputOutputPath>();
			List<InputOutputPath> list5 = new List<InputOutputPath>();
			foreach (int item3 in list)
			{
				if (item3 >= NEATBrain.NInputs + NEATBrain.NOutputs)
				{
					continue;
				}
				bool flag = item3 < NEATBrain.NInputs;
				list3.Add(new InputOutputPath(dictionary[item3], flag));
				while (list3.Count > 0)
				{
					InputOutputPath inputOutputPath = list3[0];
					int count = (flag ? inputOutputPath.nextNode.outputConnections : inputOutputPath.nextNode.inputConnections).Count;
					if (count <= 0)
					{
						list3.Remove(inputOutputPath);
						continue;
					}
					for (int num = count - 1; num >= 0; num--)
					{
						InputOutputPath inputOutputPath2;
						if (num > 0)
						{
							if (list3.Count > 250)
							{
								continue;
							}
							inputOutputPath2 = new InputOutputPath(inputOutputPath);
							list3.Add(inputOutputPath2);
						}
						else
						{
							inputOutputPath2 = inputOutputPath;
						}
						ConnectionSortHelper nextConnection = (flag ? inputOutputPath2.nextNode.outputConnections : inputOutputPath2.nextNode.inputConnections)[num];
						if (inputOutputPath2.AdvanceAndCheckDone(nextConnection))
						{
							list3.Remove(inputOutputPath2);
							if (inputOutputPath2.blocked)
							{
								list5.Add(inputOutputPath2);
							}
							if (inputOutputPath2.done)
							{
								list4.Add(inputOutputPath2);
							}
						}
					}
				}
			}
			Dictionary<(NodeSortHelper, NodeSortHelper), InputOutputAffinity> dictionary2 = new Dictionary<(NodeSortHelper, NodeSortHelper), InputOutputAffinity>();
			foreach (InputOutputPath item4 in list4)
			{
				if (dictionary2.TryGetValue((item4.sourceNode, item4.nextNode), out var value))
				{
					value.CollapsePathInto(item4);
				}
				else
				{
					dictionary2.Add((item4.sourceNode, item4.nextNode), new InputOutputAffinity(item4));
				}
			}
			List<int> list6 = (from i in list.Where((int i) => i < NEATBrain.NInputs + NEATBrain.NOutputs).Except(list2)
				orderby i
				select i).ToList();
			List<NodeGroup> groups = new List<NodeGroup>();
			while (list6.Count > 0)
			{
				NodeGroup nodeGroup = new NodeGroup();
				int num2 = list6[0];
				List<NodeSortHelper> list7 = new List<NodeSortHelper>();
				List<NodeSortHelper> list8 = new List<NodeSortHelper>();
				if (num2 < NEATBrain.NInputs)
				{
					list7.Add(dictionary[num2]);
					nodeGroup.inputs.Add(dictionary[num2]);
				}
				else
				{
					if (num2 >= NEATBrain.NInputs + NEATBrain.NOutputs)
					{
						break;
					}
					list8.Add(dictionary[num2]);
					nodeGroup.outputs.Add(dictionary[num2]);
				}
				list6.RemoveAt(0);
				while (list7.Count > 0 || list8.Count > 0)
				{
					foreach (NodeSortHelper item5 in list7)
					{
						foreach (InputOutputAffinity affinity in item5.affinities)
						{
							if (!nodeGroup.inputOutputAffinities.Contains(affinity))
							{
								nodeGroup.inputOutputAffinities.Add(affinity);
								if (!nodeGroup.outputs.Contains(affinity.nodeOut))
								{
									nodeGroup.outputs.Add(affinity.nodeOut);
									list8.Add(affinity.nodeOut);
									list6.Remove(affinity.nodeOut.node.Index);
								}
							}
						}
					}
					list7.Clear();
					foreach (NodeSortHelper item6 in list8)
					{
						foreach (InputOutputAffinity affinity2 in item6.affinities)
						{
							if (!nodeGroup.inputOutputAffinities.Contains(affinity2))
							{
								nodeGroup.inputOutputAffinities.Add(affinity2);
								if (!nodeGroup.inputs.Contains(affinity2.nodeIn))
								{
									nodeGroup.inputs.Add(affinity2.nodeIn);
									list7.Add(affinity2.nodeIn);
									list6.Remove(affinity2.nodeIn.node.Index);
								}
							}
						}
					}
					list8.Clear();
				}
				foreach (NodeSortHelper item7 in nodeGroup.hidden)
				{
					list6.Remove(item7.node.Index);
				}
				groups.Add(nodeGroup);
			}
			List<int> nonGroupedHidden = (from i in list
				where i >= NEATBrain.NInputs + NEATBrain.NOutputs
				where groups.All((NodeGroup g) => g.inputOutputAffinities.All((InputOutputAffinity a) => a.hiddenNodes.All((NodeSortHelper n) => n.index != i)))
				select i).ToList();
			List<int> list9 = nonGroupedHidden.ToList();
			foreach (InputOutputPath path in list5)
			{
				List<NodeSortHelper> pathUngrouped = (from h in path.visitedNodes
					where nonGroupedHidden.Contains(h.node.index)
					select h.node).ToList();
				if (pathUngrouped.Count < 1)
				{
					continue;
				}
				NodeGroup nodeGroup2 = groups.FirstOrDefault((NodeGroup g) => (!path.towardOutputs) ? g.outputs.Contains(path.sourceNode) : g.inputs.Contains(path.sourceNode));
				if (nodeGroup2 == null)
				{
					nodeGroup2 = groups.FirstOrDefault((NodeGroup g) => g.inputOutputAffinities.Any((InputOutputAffinity a) => a.hiddenNodes.Any((NodeSortHelper h) => pathUngrouped.Contains(h))));
					if (nodeGroup2 == null)
					{
						nodeGroup2 = new NodeGroup();
						groups.Add(nodeGroup2);
					}
				}
				InputOutputAffinity inputOutputAffinity = new InputOutputAffinity(path);
				nodeGroup2.inputOutputAffinities.Add(inputOutputAffinity);
				if (path.towardOutputs && !nodeGroup2.inputs.Contains(path.sourceNode))
				{
					nodeGroup2.inputs.Add(path.sourceNode);
				}
				else if (!path.towardOutputs && !nodeGroup2.outputs.Contains(path.sourceNode))
				{
					nodeGroup2.outputs.Add(path.sourceNode);
				}
				foreach (int item8 in inputOutputAffinity.hiddenNodes.Select((NodeSortHelper h) => h.index))
				{
					list9.Remove(item8);
				}
				if (list9.Count < 1)
				{
					break;
				}
			}
			if (list2.Count > 5)
			{
				NodeGroup nodeGroup3 = new NodeGroup
				{
					isInputlessOutputsGroup = true
				};
				NodeGroup nodeGroup4 = new NodeGroup
				{
					isInputlessOutputsGroup = true
				};
				groups.Add(nodeGroup3);
				groups.Add(nodeGroup4);
				for (int num3 = 0; num3 < list2.Count; num3++)
				{
					if (num3 % 2 == 0)
					{
						nodeGroup3.outputs.Add(dictionary[list2[num3]]);
					}
					else
					{
						nodeGroup4.outputs.Add(dictionary[list2[num3]]);
					}
				}
			}
			else if (list2.Count > 0)
			{
				NodeGroup nodeGroup5 = new NodeGroup
				{
					isInputlessOutputsGroup = true
				};
				groups.Add(nodeGroup5);
				foreach (int item9 in list2)
				{
					nodeGroup5.outputs.Add(dictionary[item9]);
				}
			}
			foreach (NodeGroup item10 in groups)
			{
				item10.FinalizeInternalStructure();
			}
			return groups;
		}

		public static List<int> UsedIndicesOfGroups(List<NodeGroup> groups)
		{
			List<int> list = new List<int>();
			foreach (NodeGroup group in groups)
			{
				foreach (NodeSortHelper node in group.nodes)
				{
					if (!list.Contains(node.node.Index))
					{
						list.Add(node.node.Index);
					}
				}
			}
			return list;
		}

		public static void Sort(List<NodeGroup> nodeGroups, int iteration = 1, List<int> nodesToIgnore = null)
		{
			if (nodesToIgnore != null)
			{
				_ = nodesToIgnore.Count > 0;
			}
			else
				_ = 0;
			foreach (NodeGroup nodeGroup in nodeGroups)
			{
				float num = 0f;
				int count = nodeGroup.inputs.Count;
				float num2 = 1f / (float)(count - 1);
				foreach (NodeSortHelper input in nodeGroup.inputs)
				{
					input.ComputeLocalMinima(nodeGroup.inputs);
				}
				foreach (NodeSortHelper item in nodeGroup.inputs.OrderBy((NodeSortHelper n) => n.tempPos.y))
				{
					item.groupPos.y = ((count > 1) ? num : 0.5f);
					num += num2;
				}
				num = 0f;
				int count2 = nodeGroup.outputs.Count;
				num2 = 1f / (float)(count2 - 1);
				foreach (NodeSortHelper output in nodeGroup.outputs)
				{
					output.ComputeLocalMinima(nodeGroup.outputs);
				}
				foreach (NodeSortHelper item2 in nodeGroup.outputs.OrderBy((NodeSortHelper n) => n.tempPos.y))
				{
					item2.groupPos.y = ((count2 > 1) ? num : 0.5f);
					num += num2;
				}
			}
			if (iteration > 1)
			{
				Sort(nodeGroups, iteration - 1);
				return;
			}
			foreach (NodeGroup nodeGroup2 in nodeGroups)
			{
				foreach (NodeSortHelper item3 in nodeGroup2.hidden)
				{
					Vector2 zero = Vector2.zero;
					item3.groupPos = Vector2.zero;
					foreach (KeyValuePair<NodeSortHelper, HiddenNodeAffinity> hiddenAffinitiesToInputsOutput in item3.hiddenAffinitiesToInputsOutputs)
					{
						Vector2 vector = new Vector2(hiddenAffinitiesToInputsOutput.Value.closeness, Mathf.Sqrt(1f + hiddenAffinitiesToInputsOutput.Value.affinity));
						item3.groupPos += (hiddenAffinitiesToInputsOutput.Key.groupPos + initialPlacementTemp * new Vector2(0f, UnityEngine.Random.Range(-1f, 1f) / (float)(nodeGroup2.outputs.Count + 4))) * vector;
						zero += vector;
					}
					if (zero.sqrMagnitude > 0f)
					{
						item3.groupPos /= zero;
					}
					else
					{
						item3.groupPos = (Vector2.one + UnityEngine.Random.insideUnitCircle * 0.25f) / 2f;
					}
				}
				int num3 = 20;
				for (int num4 = 0; num4 < num3; num4++)
				{
					nodeGroup2.OptimizeHiddenPlacement(Mathf.Pow(0.6f, (float)num4 / 2f + 0.5f), Mathf.Pow(0.5f, 2 * (num3 - num4)));
				}
			}
		}

		private static void ComputeLocalMinima(this NodeSortHelper node, List<NodeSortHelper> sameNodes)
		{
			if (node.archetype == NEATBrain.NodeArchetype.Output && node.affinities.Count <= 0)
			{
				return;
			}
			float y = node.groupPos.y;
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			foreach (InputOutputAffinity affinity in node.affinities)
			{
				NodeSortHelper nodeSortHelper = ((node.archetype == NEATBrain.NodeArchetype.Input) ? affinity.nodeOut : affinity.nodeIn);
				if (nodeSortHelper != null)
				{
					num3 += affinity.affinity;
					num += 2f * affinity.affinity * (nodeSortHelper.groupPos.y - y);
					num2 += 2f * affinity.affinity;
				}
			}
			int num4 = sameNodes.Count + 1;
			_ = num3 / (float)(sameNodes.Count - 1);
			foreach (NodeSortHelper sameNode in sameNodes)
			{
				if (sameNode != node)
				{
					float f = sameNode.groupPos.y - y;
					num -= (float)num4 * Mathf.Sign(f) * Mathf.Exp((float)(-num4) * Mathf.Abs(f));
					num2 += (float)(num4 * num4) * Mathf.Exp((float)(-num4) * Mathf.Abs(f));
				}
			}
			node.tempPos.y += num / num2;
		}

		public static void OptimizeHiddenPlacement(this NodeGroup group, float dT = 1f, float connectionsPushingScalar = 1f)
		{
			if (group.hidden.Count < 1)
			{
				return;
			}
			foreach (NodeSortHelper item in group.hidden)
			{
				item.tempPos = item.groupPos;
				item.tempVel = (item.tempAcc = Vector2.zero);
			}
			float num = connectionsPushingScalar / (float)group.connections.Count;
			float num2 = 0f;
			foreach (ConnectionSortHelper item2 in group.connections.Where((ConnectionSortHelper c) => c.nodeIn.archetype == NEATBrain.NodeArchetype.Hidden || c.nodeOut.archetype == NEATBrain.NodeArchetype.Hidden))
			{
				num2 += Mathf.Sqrt(Mathf.Min(Mathf.Abs(item2.value), 10f) + 2.5f) * (item2.enabled ? 1f : disabledFactor);
			}
			int num3 = Mathf.Max(group.inputs.Count, group.outputs.Count);
			foreach (ConnectionSortHelper connection in group.connections)
			{
				NodeSortHelper nodeIn = connection.nodeIn;
				NodeSortHelper nodeOut = connection.nodeOut;
				float num4 = enabledFactor * Mathf.Sqrt(Mathf.Abs(connection.value) + 2.5f) * (connection.enabled ? 1f : disabledFactor) / num2;
				Vector2 vector = nodeOut.groupPos - nodeIn.groupPos;
				Vector2 normalized = vector.Rotate(MathF.PI / 2f).normalized;
				if (nodeIn.archetype == NEATBrain.NodeArchetype.Hidden)
				{
					nodeIn.tempVel += (0f - num4) * vector;
					nodeIn.tempAcc += num4 * vector.normalized;
				}
				if (nodeOut.archetype == NEATBrain.NodeArchetype.Hidden)
				{
					nodeOut.tempVel -= (0f - num4) * vector;
					nodeOut.tempAcc -= num4 * vector.normalized;
				}
				foreach (NodeSortHelper item3 in group.hidden)
				{
					if (item3 != nodeIn && item3 != nodeOut)
					{
						Vector2 lhs = item3.groupPos - (nodeIn.groupPos + nodeOut.groupPos) / 2f;
						float num5 = 2f * Mathf.Abs(Vector2.Dot(lhs, vector.normalized) / (vector.magnitude + 0.0001f));
						float f = Vector2.Dot(lhs, normalized) / lhs.magnitude;
						float num6 = Mathf.Abs(f) * Mathf.Max(0.5f, 2f * num5 - 0.5f);
						float num7 = (float)(-num3) * Mathf.Exp((float)(-num3) * num6);
						float num8 = (float)(num3 * num3) * Mathf.Exp((float)(-num3) * num6);
						item3.tempVel += Mathf.Sign(f) * connectionPush * num * num7 * normalized;
						item3.tempAcc += Mathf.Sign(f) * connectionPush * num * num8 * normalized;
					}
				}
			}
			if (group.hidden.Count > 1)
			{
				float num9 = 1f / (float)(group.hidden.Count * group.hidden.Count - 1);
				List<NodeSortHelper> list = group.nodes.ToList();
				foreach (NodeSortHelper node in group.nodes)
				{
					list.Remove(node);
					foreach (NodeSortHelper item4 in list)
					{
						Vector2 vector2 = item4.groupPos - node.groupPos;
						float magnitude = vector2.magnitude;
						float num10 = (float)(-num3) * Mathf.Exp((float)(-num3) * magnitude);
						float num11 = (float)(num3 * num3) * Mathf.Exp((float)(-num3) * magnitude);
						bool flag = node.archetype == NEATBrain.NodeArchetype.Hidden;
						bool flag2 = item4.archetype == NEATBrain.NodeArchetype.Hidden;
						if (flag)
						{
							node.tempVel -= vector2.normalized * (num10 * (flag2 ? num9 : nonHiddenRepulsionFactor));
							node.tempAcc -= vector2.normalized * (num11 * (flag2 ? num9 : nonHiddenRepulsionFactor));
						}
						if (flag2)
						{
							item4.tempVel += vector2.normalized * (num10 * (flag ? num9 : nonHiddenRepulsionFactor));
							item4.tempAcc += vector2.normalized * (num11 * (flag ? num9 : nonHiddenRepulsionFactor));
						}
					}
				}
			}
			Vector2 vector3 = new Vector2(0.15f, 0.05f);
			Vector2 vector4 = new Vector2(0.85f, 0.95f);
			Vector2 vector5 = vector3;
			Vector2 vector6 = vector4;
			foreach (NodeSortHelper item5 in group.hidden)
			{
				item5.tempPos -= dT * item5.tempVel / item5.tempAcc.magnitude;
				vector5 = new Vector2(Mathf.Min(vector5.x, item5.tempPos.x), Mathf.Min(vector5.y, item5.tempPos.y));
				vector6 = new Vector2(Mathf.Max(vector6.x, item5.tempPos.x), Mathf.Max(vector6.y, item5.tempPos.y));
			}
			foreach (NodeSortHelper item6 in group.hidden)
			{
				item6.groupPos = (item6.tempPos - vector5) / (vector6 - vector5) * (vector4 - vector3) + vector3;
			}
		}
	}
}
