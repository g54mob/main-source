using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using OneUseScripts;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UIScripts.UIPanels;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public abstract class BrainPanelCommon : BibitePanel
	{
		[Header("Object References")]
		[SerializeField]
		protected TextMeshProUGUI speciesName;

		[SerializeField]
		protected FloatValueTextHandle brainDistance;

		[SerializeField]
		protected FloatValueTextHandle nNodes;

		[SerializeField]
		protected FloatValueTextHandle nConnections;

		[SerializeField]
		protected LayoutElement holder;

		[SerializeField]
		protected RectTransform holderRT;

		[SerializeField]
		protected Transform nodeHolder;

		[SerializeField]
		protected Transform connectionHolder;

		[SerializeField]
		protected GameObject nodePrefab;

		[SerializeField]
		protected GameObject connectionPrefab;

		[SerializeField]
		protected Toggle highLightToggle;

		protected ItemDictPool<int, UINeuron> nodesPool;

		protected ItemPool<UISynaps> connectionPool;

		protected List<int> usedIndexes = new List<int>();

		protected List<NodeGroup> nodeGroups;

		protected float stepI;

		protected float stepO;

		protected float stepG;

		protected float nG;

		protected float width;

		protected float height;

		protected const float TargetVerticalStep = 75f;

		private Dictionary<long, Vector2> anchors;

		public static float hiddenSortDT = 0.1f;

		public override void InitPanel()
		{
			nodesPool = new ItemDictPool<int, UINeuron>(nodePrefab, nodeHolder, 75)
			{
				actionOnCreate = delegate(UINeuron neuron)
				{
					neuron.showValueOnHover = false;
				}
			};
			connectionPool = new ItemPool<UISynaps>(connectionPrefab, connectionHolder, 75);
			highLightToggle.isOn = UserSettings.showBrainDifferences.val;
			highLightToggle.onValueChanged.AddListener(UpdateShowDifferences);
		}

		protected void FillBrainPanel(NEATBrain.Node[] nodes, NEATBrain.Synaps[] connections, Dictionary<long, Vector2> nodeAnchors)
		{
			anchors = nodeAnchors;
			nodeGroups = BrainSorter.MakeGroups(nodes.ToList(), connections.ToList());
			List<NodeGroup> list = nodeGroups.Where((NodeGroup g) => g.inputs.Count + g.hidden.Count <= 0).ToList();
			nG = list.Count;
			int num = list.Sum((NodeGroup g) => g.outputs.Count);
			usedIndexes = BrainSorter.UsedIndicesOfGroups(nodeGroups);
			nNodes.UpdateValue(usedIndexes.Count);
			nConnections.UpdateValue(connections.Length);
			usedIndexes.Select((int i) => nodes[i].Inov);
			usedIndexes.ToList();
			foreach (int index in usedIndexes)
			{
				NEATBrain.Node desc = nodes.FirstOrDefault((NEATBrain.Node n) => n.Index == index);
				UINeuron itemWithKey = nodesPool.GetItemWithKey(index);
				itemWithKey.SetDesc(desc);
				itemWithKey.SetValue(desc.Value);
			}
			for (int num2 = 0; num2 < connections.Length; num2++)
			{
				NEATBrain.Synaps synaps = connections[num2];
				if (usedIndexes.Contains(synaps.NodeOut) && usedIndexes.Contains(synaps.NodeIn))
				{
					UISynaps itemFromPool = connectionPool.GetItemFromPool();
					itemFromPool.SetValue(synaps.Weight, num2, synaps.Inov, synaps.En);
					itemFromPool.SetAnchorIn(nodesPool.activeItems[synaps.NodeIn]);
					itemFromPool.SetAnchorOut(nodesPool.activeItems[synaps.NodeOut]);
				}
			}
			int num3 = usedIndexes.Count((int i) => i < NEATBrain.NInputs);
			int num4 = usedIndexes.Count((int i) => i < NEATBrain.NInputs + NEATBrain.NOutputs) - num3 - num;
			int num5 = nodes.Length - NEATBrain.NInputs - NEATBrain.NOutputs;
			float num6 = nodeGroups.Sum((NodeGroup g) => g.weight + 1f) - 1f;
			height = num6 * 75f;
			height = Mathf.Min(height, (1080f - 350f * UIScaler.totalScale) / UIScaler.UIScale);
			stepG = (0f - height) / num6;
			width = Mathf.Max(400f + 150f * (1f - Mathf.Pow(2f, (float)(-num5) / 5f)), holderRT.rect.width);
			holder.preferredWidth = width;
			holder.minHeight = height;
			float num7 = Mathf.Max(1f, height + nG * stepG);
			stepI = (0f - num7) / (float)Mathf.Max(num3 - 1, 1);
			stepO = (0f - num7) / (float)Mathf.Max(num4 - 1, 1);
			if (anchors != null && anchors.Count > 3 * usedIndexes.Count / 5)
			{
				PlaceNodesAccordingToAnchors(connections);
			}
			else
			{
				BrainSorter.Sort(nodeGroups, 3);
				PlaceNodesAccordingToSort();
			}
			CallShowDifferences();
		}

		private void PlaceNodesAccordingToSort()
		{
			float num = 0f;
			float num2 = 0f;
			foreach (NodeGroup nodeGroup in nodeGroups)
			{
				num += nodeGroup.weight;
				num2 += nodeGroup.weight + 1f;
			}
			float num3 = height / (num2 - 1f);
			if (num < 0.1f)
			{
				num = 1f;
			}
			float num4 = 0f;
			foreach (NodeGroup item in nodeGroups.OrderByDescending((NodeGroup n) => n.weight))
			{
				float num5 = (height - num3 * (float)(nodeGroups.Count - 1)) * item.weight / num;
				item.SetStartEnd(num4, num5);
				foreach (NodeSortHelper node in item.nodes)
				{
					float num6 = ((node.archetype == NEATBrain.NodeArchetype.Input) ? stepI : stepO);
					node.panelPos = new Vector2(node.groupPos.x, (num4 - num5 * node.groupPos.y) / num6);
				}
				num4 -= num5 + num3;
			}
			UpdatePlacement();
		}

		private void PlaceNodesAccordingToAnchors(NEATBrain.Synaps[] connections)
		{
			int num = 0;
			int num2 = 0;
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			List<NodeGroup> list = nodeGroups.Where((NodeGroup g) => g.inputs.Count + g.hidden.Count <= 0).ToList();
			List<NodeSortHelper> inputlessNodes = list.SelectMany((NodeGroup g) => g.outputs).ToList();
			List<long> inputlessInovs = inputlessNodes.Select((NodeSortHelper n) => n.inov).ToList();
			List<int> list2 = usedIndexes.Where((int i) => inputlessNodes.All((NodeSortHelper n) => n.index != i)).ToList();
			List<long> inputInovs = (from k in nodesPool.activeItems
				where k.Value.nodeArchetype == NEATBrain.NodeArchetype.Input
				select k.Value.inov).ToList();
			List<long> outputInovs = (from k in nodesPool.activeItems
				where k.Value.nodeArchetype == NEATBrain.NodeArchetype.Output && !inputlessInovs.Contains(k.Value.inov)
				select k.Value.inov).ToList();
			foreach (long item in inputlessInovs)
			{
				anchors.Remove(item);
			}
			float num3 = anchors.Where((KeyValuePair<long, Vector2> p) => inputInovs.Contains(p.Key)).Max((KeyValuePair<long, Vector2> p) => p.Value.y);
			float num4 = anchors.Where((KeyValuePair<long, Vector2> p) => outputInovs.Contains(p.Key)).Max((KeyValuePair<long, Vector2> p) => p.Value.y);
			float num5 = anchors.Where((KeyValuePair<long, Vector2> p) => !inputInovs.Contains(p.Key) && !outputInovs.Contains(p.Key)).Max((KeyValuePair<long, Vector2> p) => p.Value.y);
			float num6 = 1f + nG * stepG / height;
			float y = Mathf.Min(1f, (float)(inputInovs.Count - 1) / num3);
			float y2 = Mathf.Min(1f, (float)(outputInovs.Count - 1) / num4);
			float num7 = num6 * Mathf.Min(1f, 1f / num5);
			foreach (long inov in from p in anchors
				orderby p.Value.y
				select p.Key)
			{
				UINeuron value = nodesPool.activeItems.FirstOrDefault((KeyValuePair<int, UINeuron> p) => p.Value.inov == inov).Value;
				if (value == null)
				{
					continue;
				}
				int index = value.index;
				if (!usedIndexes.Contains(index))
				{
					if (index < NEATBrain.NInputs)
					{
						zero2.y += 1f;
					}
					else if (index < NEATBrain.NInputs + NEATBrain.NOutputs)
					{
						zero.y += 1f;
					}
					continue;
				}
				if (index < NEATBrain.NInputs)
				{
					value.SetStep(stepI);
					value.transform.localPosition = (anchors[inov] * new Vector2(1f, y) - zero2) * new Vector2(width, stepI);
					num++;
				}
				else if (index < NEATBrain.NInputs + NEATBrain.NOutputs)
				{
					value.SetStep(stepO);
					if (value.node.NIn > 0)
					{
						value.transform.localPosition = (anchors[inov] * new Vector2(1f, y2) - zero) * new Vector2(width, stepO);
						num2++;
					}
				}
				else
				{
					value.transform.localPosition = anchors[inov] * new Vector2(width, (0f - height) * num7);
				}
				list2.Remove(index);
			}
			foreach (int item2 in list2.OrderBy((int i) => i))
			{
				UINeuron itemWithKey = nodesPool.GetItemWithKey(item2);
				if (item2 < NEATBrain.NInputs)
				{
					itemWithKey.SetStep(stepI);
					itemWithKey.transform.localPosition = new Vector3(0f, (float)num++ * stepI);
					continue;
				}
				if (item2 < NEATBrain.NInputs + NEATBrain.NOutputs)
				{
					itemWithKey.SetStep(stepO);
					itemWithKey.transform.localPosition = new Vector3(width, (float)num2++ * stepO);
					continue;
				}
				Vector3 zero3 = Vector3.zero;
				float num8 = 1E-06f;
				for (int num9 = 0; num9 < connections.Length; num9++)
				{
					NEATBrain.Synaps synaps = connections[num9];
					int key;
					if (synaps.NodeIn == item2)
					{
						key = synaps.NodeOut;
					}
					else
					{
						if (synaps.NodeOut != item2)
						{
							continue;
						}
						key = synaps.NodeIn;
					}
					if (nodesPool.HasItemWithKey(key))
					{
						zero3 += nodesPool.GetItemWithKey(key).transform.localPosition * Mathf.Abs(synaps.Weight);
					}
					else
					{
						zero3 += new Vector3((synaps.NodeIn == item2) ? width : 0f, (0f - height) / 2f) * Mathf.Abs(synaps.Weight);
					}
					num8 += Mathf.Abs(synaps.Weight);
				}
				itemWithKey.transform.localPosition = zero3 / num8;
			}
			if (nG > 0f)
			{
				float num10 = (0f - height) * num6;
				foreach (NodeGroup item3 in list)
				{
					num10 += stepG;
					foreach (NodeSortHelper node in item3.nodes)
					{
						nodesPool.GetItemWithKey(node.index).transform.localPosition = new Vector2(node.groupPos.x * width, num10);
					}
				}
			}
			foreach (UISynaps activeItem in connectionPool.activeItems)
			{
				activeItem.UpdatePosition();
			}
		}

		protected void UpdatePlacement()
		{
			foreach (NodeGroup item in nodeGroups.OrderByDescending((NodeGroup n) => n.weight))
			{
				foreach (NodeSortHelper node in item.nodes)
				{
					float num = ((node.archetype == NEATBrain.NodeArchetype.Input) ? stepI : stepO);
					nodesPool.GetItemWithKey(node.index).transform.localPosition = new Vector2(node.panelPos.x * width, node.panelPos.y * num);
				}
			}
			foreach (UISynaps activeItem in connectionPool.activeItems)
			{
				activeItem.UpdatePosition();
			}
		}

		protected void OnRectTransformDimensionsChange()
		{
			if (nodeGroups != null && holderRT.rect.width > width)
			{
				UpdatePlacement();
			}
		}

		private void UpdateShowDifferences(bool val)
		{
			UserSettings.showBrainDifferences.SetValue(val);
			if (!val)
			{
				connectionPool.ForEachActive(delegate(UISynaps s)
				{
					s.ResetDiff();
				});
				nodesPool.ForEachActive(delegate(UINeuron n)
				{
					n.ResetDiff();
				});
			}
			else
			{
				CallShowDifferences();
			}
		}

		protected abstract void CallShowDifferences();

		protected void ShowDifferences(BrainDifferences diffs, bool is1 = false)
		{
			connectionPool.ForEachActive(delegate(UISynaps s)
			{
				s.ResetDiff();
			});
			nodesPool.ForEachActive(delegate(UINeuron s)
			{
				s.ResetDiff();
			});
			float maxDelta = ((diffs.connectionDeltas.Count > 0) ? diffs.connectionDeltas.Max((ConnectionDelta d) => Mathf.Abs(d.dist)) : 0f);
			float speciesGeneticSpan = GlobalLineageManager.usedSpeciesSpan;
			List<long> added = (is1 ? diffs.disjoint1 : diffs.disjoint2);
			if (!is1)
			{
				_ = diffs;
			}
			else
			{
				_ = diffs;
			}
			connectionPool.ForEachActive(delegate(UISynaps s)
			{
				if (added.Contains(s.inov))
				{
					s.SetNew(1f / (float)diffs.nMaxConnections, 1f / (float)diffs.nMaxConnections / speciesGeneticSpan);
				}
				else if (diffs.toggled.Contains(s.inov))
				{
					s.SetToggled(1f / (float)diffs.nCommonConnections, 1f / (float)diffs.nCommonConnections / speciesGeneticSpan);
				}
				else if (diffs.connectionDeltas.Any((ConnectionDelta c) => c.i == s.index && c.inov == s.inov))
				{
					ConnectionDelta connectionDelta = diffs.connectionDeltas.First((ConnectionDelta c) => c.i == s.index && c.inov == s.inov);
					s.SetDiff(is1 ? connectionDelta.delta : (0f - connectionDelta.delta), connectionDelta.dist, connectionDelta.dist / speciesGeneticSpan, Mathf.Sqrt(Mathf.Abs(connectionDelta.delta) / maxDelta));
				}
			});
			if (diffs.activationDelta.Count <= 0)
			{
				return;
			}
			diffs.activationDelta.Max((ActivationDelta d) => Mathf.Abs(d.delta));
			nodesPool.ForEachActive(delegate(UINeuron n)
			{
				if (diffs.activationDelta.Any((ActivationDelta d) => d.inov == n.inov))
				{
					ActivationDelta activationDelta = diffs.activationDelta.First((ActivationDelta d) => d.inov == n.inov);
					n.SetDiff(activationDelta.delta, activationDelta.dist, activationDelta.dist / speciesGeneticSpan, Mathf.Sqrt(Mathf.Abs(activationDelta.delta) / maxDelta));
				}
			});
		}

		public override void ResetState()
		{
			nodeGroups = null;
			connectionPool?.RetireAll();
			nodesPool?.RetireAll();
		}

		protected override void UpdatePanel()
		{
			base.UpdatePanel();
			if (Input.GetKeyDown(KeyCode.F1))
			{
				SortN();
			}
			if (Input.GetKey(KeyCode.F2))
			{
				SortHiddenOnce();
			}
			if (Input.GetKeyDown(KeyCode.F3))
			{
				SortN(6);
			}
			if (Input.GetKeyDown(KeyCode.F4))
			{
				SortN(8);
			}
		}

		public void SortN()
		{
			SortN(1);
		}

		public void SortN(int n)
		{
			if (nodeGroups.Count > 1 && n >= 1)
			{
				BrainSorter.Sort(nodeGroups, n);
				PlaceNodesAccordingToSort();
			}
		}

		public void SortHiddenOnce()
		{
			if (nodeGroups.Count <= 1)
			{
				return;
			}
			foreach (NodeGroup nodeGroup in nodeGroups)
			{
				if (nodeGroup.hidden.Count >= 1)
				{
					nodeGroup.OptimizeHiddenPlacement(1f / TimeKeeper.fps, Input.GetKey(KeyCode.RightControl) ? 0f : 1f);
				}
			}
			PlaceNodesAccordingToSort();
		}

		protected virtual void OnDestroy()
		{
			highLightToggle.onValueChanged.RemoveListener(UpdateShowDifferences);
		}
	}
}
