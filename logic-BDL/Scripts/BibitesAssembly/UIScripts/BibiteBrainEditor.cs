using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using OneUseScripts;
using ScriptHelpers;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class BibiteBrainEditor : UIPanel
	{
		public static BibiteBrainEditor instance;

		[SerializeField]
		private BibiteEditorPanel bibiteEditor;

		[SerializeField]
		private GameObject nodePrefab;

		[SerializeField]
		private GameObject connectionPrefab;

		[SerializeField]
		private GameObject nodeGroupPrefab;

		[SerializeField]
		private BrainEditorScroll scroll;

		[SerializeField]
		private RectTransform viewPortRT;

		[SerializeField]
		private RectTransform brainRT;

		[SerializeField]
		private Transform nodeHolder;

		[SerializeField]
		private Transform connectionHolder;

		[SerializeField]
		private Transform groupHolder;

		[SerializeField]
		private ConnectionEditPanel connectionEditPanel;

		[SerializeField]
		private NodeEditPanel nodeEditPanel;

		[SerializeField]
		private AddNodePanel addNodePanel;

		[SerializeField]
		private Button manualPlaceButton;

		[SerializeField]
		private Button autoSortButton;

		[SerializeField]
		private GameObject infoPanel;

		[SerializeField]
		private SettingToggleReference showValuesRef;

		[SerializeField]
		private SettingToggle showValues;

		[SerializeField]
		private GameObject playButton;

		[SerializeField]
		private GameObject stopButton;

		[SerializeField]
		private GameObject positionSavedMessages;

		[SerializeField]
		private GameObject willSaveText;

		[SerializeField]
		private GameObject willNotSaveText;

		private RectTransform rt;

		private ItemDictPool<int, NodeEditor> baseNodes;

		private ItemPool<NodeEditor> hiddenNodes;

		private ItemPool<NodeEditorGroup> placementGroups;

		private ItemPool<ConnectionEditor> connections;

		private List<NodeGroup> nodeGroups;

		private List<int> unusedInputsOutputs = new List<int>();

		private List<int> usedIndices = new List<int>();

		private float currentScale = 1f;

		private float minScale = 0.1f;

		private float maxScale = 5f;

		private float stepI;

		private float stepO;

		private float stepW = 150f;

		private float targetStepV = 75f;

		private float maxDepth = 1f;

		private float stepG;

		private float nG;

		private float width;

		private float height;

		private bool elementSelected;

		private bool connectingMode;

		private bool addNodeMode;

		[NonSerialized]
		public bool anyChange;

		private ConnectionEditor tempConnection;

		private EscapableAction selectAction;

		private EscapableAction createConnectionAction;

		private EscapableAction addNodeAction;

		private Camera cam;

		public List<NEATBrain.Node> nodes;

		public List<NEATBrain.Synaps> synapses;

		public Dictionary<NodeEditor, Vector2> anchors = new Dictionary<NodeEditor, Vector2>();

		private bool saveAnchors;

		private Vector2 addPos;

		public bool valid;

		public static float brainPeriod = 0.1f;

		private float brainProgress;

		private bool play;

		public override void InitPanel()
		{
			if (!hasInit)
			{
				instance = this;
				baseNodes = new ItemDictPool<int, NodeEditor>(nodePrefab, nodeHolder);
				hiddenNodes = new ItemPool<NodeEditor>(nodePrefab, nodeHolder);
				baseNodes.actionOnCreate = BindToNode;
				hiddenNodes.actionOnCreate = BindToNode;
				connections = new ItemPool<ConnectionEditor>(connectionPrefab, connectionHolder);
				connections.actionOnCreate = delegate(ConnectionEditor c)
				{
					c.itemClicked.AddListener(SelectElement);
				};
				scroll.onValueChanged.AddListener(OnPanelMoved);
				rt = GetComponent<RectTransform>();
				cam = (UICamera.cam ? UICamera.cam : Camera.main);
				selectAction = new EscapableAction(Deselect);
				addNodeAction = new EscapableAction(CloseAddNodePanel);
				createConnectionAction = new EscapableAction(StopConnecting);
				showValues = new SettingToggle(UserSettings.ShowNodeValues, showValuesRef);
				UserSettings.ShowNodeValues.Subscribe(UpdateShowValues);
				positionSavedMessages.SetActive(value: false);
				nodeEditPanel.Init();
				nodeEditPanel.Hide();
				connectionEditPanel.Init();
				connectionEditPanel.Hide();
				addNodePanel.Init();
			}
		}

		private void BindToNode(NodeEditor node)
		{
			node.itemClicked.AddListener(SelectElement);
			node.validityChanged.AddListener(CheckAllValid);
		}

		public void FillEditor(List<NEATBrain.Node> newNodes, List<NEATBrain.Synaps> newConnections, Dictionary<long, Vector2> newAnchors)
		{
			if (!hasInit)
			{
				Initialize();
			}
			else
			{
				ResetState();
			}
			nodes = newNodes;
			synapses = new List<NEATBrain.Synaps>();
			anchors.Clear();
			nodeGroups = BrainSorter.MakeGroups(newNodes, newConnections);
			usedIndices = BrainSorter.UsedIndicesOfGroups(nodeGroups);
			foreach (int usedIndex in usedIndices)
			{
				NodeEditor nodeEditor;
				if (usedIndex < NEATBrain.NInputs + NEATBrain.NOutputs)
				{
					addNodePanel.SetIndexAvailability(usedIndex, (usedIndex >= NEATBrain.NInputs) ? NEATBrain.NodeArchetype.Output : NEATBrain.NodeArchetype.Input, available: false);
					nodeEditor = baseNodes.GetItemWithKey(usedIndex);
				}
				else
				{
					nodeEditor = hiddenNodes.GetItemFromPool();
				}
				nodeEditor.AssignNode(newNodes[usedIndex]);
				if (newAnchors.TryGetValue(nodeEditor.node.Inov, out var value))
				{
					anchors.Add(nodeEditor, value);
				}
			}
			SetNodePositionSaveMode(newAnchors != null && newAnchors.Count > usedIndices.Count / 2);
			foreach (NEATBrain.Synaps newConnection in newConnections)
			{
				connections.GetItemFromPool().AssignNodes(GetNode(newConnection.NodeIn), GetNode(newConnection.NodeOut), newConnection);
			}
			CheckAllValid();
			SizePanelAndPlaceBrain();
			UpdateShowValues(UserSettings.ShowNodeValues.val);
		}

		public void SortStepBrain()
		{
			RebuildLists();
			nodeGroups = BrainSorter.MakeGroups(nodes, synapses);
		}

		public void ReSortBrain()
		{
			SetNodePositionSaveMode(manual: false);
			RebuildLists();
			nodeGroups = BrainSorter.MakeGroups(nodes, synapses);
			SizePanelAndPlaceBrain();
			baseNodes.ForEachActive(delegate(NodeEditor n)
			{
				n.EditAct(0f);
				n.node.LastOutput = 0f;
				n.node.LastInput = 0f;
				n.node.Value = 0f;
				n.ExecuteNode();
			});
			hiddenNodes.ForEachActive(delegate(NodeEditor n)
			{
				n.node.LastOutput = 0f;
				n.node.LastInput = 0f;
				n.node.Value = 0f;
				n.ExecuteNode();
			});
		}

		private void RefreshDerivedValues()
		{
			List<NodeGroup> list = nodeGroups.Where((NodeGroup g) => g.inputs.Count + g.hidden.Count <= 0).ToList();
			nG = list.Count;
			int num = list.Sum((NodeGroup g) => g.outputs.Count);
			int num2 = usedIndices.Count((int i) => i < NEATBrain.NInputs);
			int num3 = usedIndices.Count((int i) => i < NEATBrain.NInputs + NEATBrain.NOutputs) - num2 - num;
			_ = usedIndices.Count;
			_ = NEATBrain.NInputs;
			_ = NEATBrain.NOutputs;
			float num4 = nodeGroups.Sum((NodeGroup g) => g.weight + 1f) - 1f;
			height = targetStepV * num4;
			maxDepth = nodeGroups.Max((NodeGroup g) => g.maxDepth);
			if (list.Count > 1)
			{
				maxDepth = Mathf.Max(maxDepth, (float)list.Max((NodeGroup g) => g.outputs.Count) / 2f);
			}
			width = Mathf.Max(height, stepW * (maxDepth + 1f));
			height = Mathf.Max(height, width / 2f);
			stepI = (0f - height) / (float)Mathf.Max(num2 - 1, 1);
			stepO = (0f - height) / (float)Mathf.Max(num3 - 1, 1);
			stepG = (0f - height) / num4;
		}

		private void SizePanelAndPlaceBrain()
		{
			RefreshDerivedValues();
			Vector2 vector = new Vector2((float)Screen.width * 0.7f, (float)Screen.height * 0.8f);
			brainRT.sizeDelta = new Vector2(Mathf.Max(1.5f * vector.x, 2f * width), Mathf.Max(1.5f * vector.y, 2f * height));
			if (saveAnchors)
			{
				PlaceNodesAccordingToAnchors();
			}
			else
			{
				BrainSorter.Sort(nodeGroups, 3);
				PlaceNodesAccordingToSort();
			}
			brainRT.anchoredPosition = Vector2.zero;
		}

		public void SetNodePositionSaveMode(bool manual)
		{
			saveAnchors = manual;
			willSaveText.SetActive(manual);
			willNotSaveText.SetActive(!manual);
			manualPlaceButton.gameObject.SetActive(!manual);
		}

		public void SaveAnchors(bool listsRebuildNeeded = false)
		{
			if (listsRebuildNeeded)
			{
				RebuildLists();
			}
			nodeGroups = BrainSorter.MakeGroups(nodes, synapses);
			usedIndices = BrainSorter.UsedIndicesOfGroups(nodeGroups);
			RefreshDerivedValues();
			anchors.Clear();
			Rect rect = new Rect(Vector2.zero, Vector2.zero);
			List<NodeEditor> list = baseNodes.activeItemsList.Where((NodeEditor n) => n.archetype != NEATBrain.NodeArchetype.Output || n.ingoings.Count > 0).Union(hiddenNodes.activeItems).ToList();
			rect.xMin = 10000f;
			rect.xMax = -10000f;
			rect.yMin = -100000f;
			rect.yMax = 10000f;
			foreach (NodeEditor item in list)
			{
				Vector2 pos = item.pos;
				rect.xMin = Mathf.Min(rect.xMin, pos.x);
				rect.xMax = Mathf.Max(rect.xMax, pos.x);
				rect.yMin = Mathf.Max(rect.yMin, pos.y);
				rect.yMax = Mathf.Min(rect.yMax, pos.y);
			}
			foreach (NodeEditor item2 in list)
			{
				Vector2 vector = item2.pos - new Vector2(rect.xMin, rect.yMin);
				float num = item2.archetype switch
				{
					NEATBrain.NodeArchetype.Input => stepI, 
					NEATBrain.NodeArchetype.Output => stepO, 
					_ => 0f - (height + nG * stepG), 
				};
				Vector2 value = new Vector2(vector.x / rect.width, vector.y / num);
				anchors.Add(item2, value);
			}
		}

		private void CheckAllValid(bool newValidity = true)
		{
			valid = newValidity;
			if (valid)
			{
				foreach (NodeEditor activeItems in baseNodes.activeItemsList)
				{
					if (!activeItems.valid)
					{
						valid = false;
						break;
					}
				}
			}
			if (valid)
			{
				foreach (NodeEditor activeItem in hiddenNodes.activeItems)
				{
					if (!activeItem.valid)
					{
						valid = false;
						break;
					}
				}
			}
			bibiteEditor.UpdateValidity();
			autoSortButton.interactable = valid;
		}

		public void PrepareForTemplateSave()
		{
			RebuildLists();
			if (saveAnchors)
			{
				SaveAnchors();
			}
			else
			{
				anchors.Clear();
			}
		}

		public void RebuildLists()
		{
			PlayBrain(val: false);
			if (nodes.Count > NEATBrain.NInputs + NEATBrain.NOutputs)
			{
				nodes.RemoveRange(NEATBrain.NInputs + NEATBrain.NOutputs, nodes.Count - (NEATBrain.NInputs + NEATBrain.NOutputs));
			}
			for (int i = 0; i < NEATBrain.NInputs + NEATBrain.NOutputs; i++)
			{
				if (baseNodes.TryGetItemWithKey(i, out var item))
				{
					item.node.Inov = i + 1;
					item.node.LastInput = 0f;
					item.node.LastOutput = 0f;
					item.node.Value = 0f;
					nodes[i] = item.node;
					if (item.archetype == NEATBrain.NodeArchetype.Output)
					{
						_ = item.ingoings.Count;
						_ = 1;
					}
				}
			}
			int num = NEATBrain.NInputs + NEATBrain.NOutputs;
			foreach (NodeEditor activeItem in hiddenNodes.activeItems)
			{
				activeItem.ChangeIndex(num);
				activeItem.node.Inov = num + 1;
				activeItem.node.LastInput = 0f;
				activeItem.node.LastOutput = 0f;
				activeItem.node.Value = 0f;
				nodes.Add(activeItem.node);
				num++;
			}
			synapses.Clear();
			int num2 = 1;
			foreach (ConnectionEditor activeItem2 in connections.activeItems)
			{
				activeItem2.connection.Inov = num2++;
				synapses.Add(activeItem2.connection);
			}
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
				foreach (NodeSortHelper node2 in item.nodes)
				{
					float num6 = ((node2.archetype == NEATBrain.NodeArchetype.Input) ? stepI : stepO);
					node2.panelPos = new Vector2(node2.groupPos.x, (num4 - num5 * node2.groupPos.y) / num6);
				}
				num4 -= num5 + num3;
			}
			Vector2 vector = (brainRT.sizeDelta - new Vector2(width, height)) / 2f;
			vector.y = 0f - vector.y;
			foreach (NodeGroup item2 in nodeGroups.OrderByDescending((NodeGroup n) => n.weight))
			{
				foreach (NodeSortHelper node in item2.nodes)
				{
					float num7 = ((node.archetype == NEATBrain.NodeArchetype.Input) ? stepI : stepO);
					NodeEditor nodeEditor = ((node.archetype == NEATBrain.NodeArchetype.Hidden) ? hiddenNodes.activeItems.FirstOrDefault((NodeEditor n) => n.node.Index == node.index) : baseNodes.GetItemWithKey(node.index));
					if (nodeEditor != null)
					{
						nodeEditor.pos = vector + new Vector2(node.panelPos.x * width, node.panelPos.y * num7);
					}
				}
			}
			foreach (ConnectionEditor activeItem in connections.activeItems)
			{
				activeItem.UpdatePosition();
			}
		}

		private void PlaceNodesAccordingToAnchors()
		{
			int num = 0;
			int num2 = 0;
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			List<NodeGroup> list = nodeGroups.Where((NodeGroup g) => g.inputs.Count + g.hidden.Count <= 0).ToList();
			List<long> list2 = (from n in list.SelectMany((NodeGroup g) => g.outputs).ToList()
				select n.inov).ToList();
			List<NodeEditor> list3 = baseNodes.activeItemsList.Union(hiddenNodes.activeItems).ToList();
			List<NodeEditor> source = list3.Except(anchors.Select((KeyValuePair<NodeEditor, Vector2> p) => p.Key)).ToList();
			Dictionary<NodeEditor, Vector2> dictionary = anchors.Where((KeyValuePair<NodeEditor, Vector2> p) => p.Key.archetype == NEATBrain.NodeArchetype.Input).ToDictionary((KeyValuePair<NodeEditor, Vector2> p) => p.Key, (KeyValuePair<NodeEditor, Vector2> p) => p.Value);
			Dictionary<NodeEditor, Vector2> dictionary2 = anchors.Where((KeyValuePair<NodeEditor, Vector2> p) => p.Key.archetype == NEATBrain.NodeArchetype.Output).ToDictionary((KeyValuePair<NodeEditor, Vector2> p) => p.Key, (KeyValuePair<NodeEditor, Vector2> p) => p.Value);
			Vector2 vector = (brainRT.sizeDelta - new Vector2(width, height)) / 2f;
			vector.y = 0f - vector.y;
			foreach (long inov in list2)
			{
				anchors.Remove(list3.First((NodeEditor n) => n.node.Inov == inov));
			}
			float num3 = dictionary.Max((KeyValuePair<NodeEditor, Vector2> p) => p.Value.y);
			float num4 = dictionary2.Max((KeyValuePair<NodeEditor, Vector2> p) => p.Value.y);
			float num5 = anchors.Where((KeyValuePair<NodeEditor, Vector2> p) => p.Key.archetype == NEATBrain.NodeArchetype.Hidden).Max((KeyValuePair<NodeEditor, Vector2> p) => p.Value.y);
			float num6 = 1f + nG * stepG / height;
			float y = Mathf.Min(1f, (float)(dictionary.Count - 1) / num3);
			float y2 = Mathf.Min(1f, (float)(dictionary2.Count - 1) / num4);
			float num7 = num6 * Mathf.Min(1f, 1f / num5);
			foreach (KeyValuePair<NodeEditor, Vector2> anchor in anchors)
			{
				NodeEditor key = anchor.Key;
				if (!(key == null))
				{
					if (key.archetype == NEATBrain.NodeArchetype.Input)
					{
						key.pos = vector + (anchor.Value * new Vector2(1f, y) - zero2) * new Vector2(width, stepI);
						num++;
					}
					else if (key.archetype == NEATBrain.NodeArchetype.Output)
					{
						key.pos = vector + (anchor.Value * new Vector2(1f, y2) - zero) * new Vector2(width, stepO);
						num2++;
					}
					else
					{
						key.pos = vector + anchor.Value * new Vector2(width, (0f - height) * num7);
					}
				}
			}
			foreach (NodeEditor item in source.OrderBy((NodeEditor i) => i.node.Index))
			{
				if (item.archetype == NEATBrain.NodeArchetype.Input)
				{
					item.pos = vector + new Vector2(0f, (float)num++ * stepI);
					continue;
				}
				if (item.archetype == NEATBrain.NodeArchetype.Output)
				{
					item.pos = vector + new Vector2(width, (float)num2++ * stepO);
					continue;
				}
				Vector2 zero3 = Vector2.zero;
				float num8 = 1E-06f;
				foreach (ConnectionEditor connection in item.connections)
				{
					NodeEditor nodeEditor;
					if (connection.nodeIn == item)
					{
						nodeEditor = connection.nodeOut;
					}
					else
					{
						if (!(connection.nodeOut == item))
						{
							continue;
						}
						nodeEditor = connection.nodeIn;
					}
					zero3 += nodeEditor.pos * Mathf.Abs(connection.weight);
					num8 += Mathf.Abs(connection.weight);
				}
				item.pos = vector + zero3 / num8;
			}
			if (nG > 0f)
			{
				float num9 = (0f - height) * num6;
				foreach (NodeGroup item2 in list)
				{
					num9 += stepG;
					float num10 = 1f / (float)(item2.nodes.Count + 1);
					float num11 = 0f;
					foreach (NodeSortHelper nodeHelper in item2.nodes)
					{
						NodeEditor nodeEditor2 = list3.First((NodeEditor n) => n.node.Index == nodeHelper.index);
						num11 += num10;
						nodeEditor2.pos = vector + new Vector2(num11 * width, num9);
					}
				}
			}
			foreach (ConnectionEditor activeItem in connections.activeItems)
			{
				activeItem.UpdatePosition();
			}
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			positionSavedMessages.SetActive(value: true);
			CloseAddNodePanel();
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			positionSavedMessages.SetActive(value: false);
			connectionEditPanel.Hide();
			nodeEditPanel.Hide();
			addNodePanel.Hide();
		}

		public override void ResetState()
		{
			connectionEditPanel.Hide();
			nodeEditPanel.Hide();
			addNodePanel.Hide();
			addNodePanel.ResetAvailabilities();
			PlayBrain(val: false);
			connectingMode = false;
			addNodeMode = false;
			anyChange = false;
			connections.RetireAll();
			hiddenNodes.RetireAll();
			baseNodes.RetireAll();
		}

		protected override void UpdatePanel()
		{
			base.UpdatePanel();
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				OneBrainStep();
			}
			else if (Input.GetKey(KeyCode.Alpha1) || play)
			{
				brainProgress += Time.unscaledDeltaTime;
				if (brainProgress >= brainPeriod)
				{
					brainProgress -= brainPeriod;
					StepBrain();
				}
			}
			if (!MouseIsInPanel() || bibiteEditor.editingText)
			{
				return;
			}
			if (!elementSelected && !addNodeMode && !infoPanel.activeSelf)
			{
				Zoom(Input.GetAxis("Mouse ScrollWheel"));
			}
			if (!Input.GetKeyDown(KeyCode.Space) || elementSelected)
			{
				return;
			}
			if (!addNodeMode)
			{
				if (connectingMode)
				{
					RequestAddNode(tempConnection.missingArchetype switch
					{
						NEATBrain.NodeArchetype.Input => NEATBrain.NodeArchetype.Output, 
						NEATBrain.NodeArchetype.Output => NEATBrain.NodeArchetype.Input, 
						_ => NEATBrain.NodeArchetype.Hidden, 
					});
				}
				else
				{
					RequestAddNode();
				}
			}
			else
			{
				CloseAddNodePanel();
			}
		}

		public Vector2 MousePosInGraph()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(brainRT, Input.mousePosition, cam, out var localPoint);
			return localPoint;
		}

		public Vector2 MouseToNodePos()
		{
			return MousePosInGraph() + new Vector2(0.5f, -0.5f) * brainRT.rect.size;
		}

		public Vector2 MousePosToStickyNodePos()
		{
			Vector2 vector = (brainRT.sizeDelta - new Vector2(width, height)) / 2f;
			vector.y = 0f - vector.y;
			Vector2 vector2 = MouseToNodePos() - vector;
			float x = vector2.x;
			if (x > -10f && x < 10f)
			{
				vector2.x = 0f;
			}
			else if (x > width - 10f && x < width + 10f)
			{
				vector2.x = width;
			}
			return vector2 + vector;
		}

		public Vector2 MousePosInPanel()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, cam, out var localPoint);
			return localPoint;
		}

		public bool MouseIsInPanel()
		{
			Vector2 vector = MousePosInPanel() / rt.rect.size;
			if (!(vector.x > 1f) && !(vector.x < 0f) && !(vector.y > 1f))
			{
				return !(vector.y < 0f);
			}
			return false;
		}

		public Vector2 NodePosToPanel(Vector2 pos)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, cam.WorldToScreenPoint(pos), cam, out var localPoint);
			return localPoint;
		}

		public void SelectElement(ConnectionEditor connection, PointerEventData eventData)
		{
			if (!connectingMode)
			{
				Rect rect = rt.rect;
				Vector2 vector = MousePosInPanel();
				Vector2 vector2 = vector / rect.size;
				Rect rect2 = connectionEditPanel.rt.rect;
				Vector2 anchor = new Vector2(Mathf.Lerp(-75f, rect2.width + 75f, vector2.x) / rect2.width, (vector2.y > 0.5f) ? (1f + 75f / rect2.height) : (-75f / rect2.height));
				nodeEditPanel.Hide();
				connectionEditPanel.SelectConnection(connection, vector, anchor);
				if (elementSelected)
				{
					UINavigationManager.RemoveEscapableFromStack(selectAction);
				}
				UINavigationManager.AddEscapableToStack(selectAction);
				elementSelected = true;
			}
		}

		public void SelectElement(NodeEditor node, PointerEventData eventData)
		{
			if (connectingMode)
			{
				if (node.archetype == NEATBrain.NodeArchetype.Hidden || tempConnection.missingArchetype == node.archetype)
				{
					tempConnection.AssignMissingNode(node);
					SelectElement(tempConnection, eventData);
					tempConnection = null;
					if (addNodeMode)
					{
						CloseAddNodePanel();
					}
					StopConnecting();
					anyChange = true;
				}
				return;
			}
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				if (node.archetype != NEATBrain.NodeArchetype.Output)
				{
					CreateNewConnectionFromToNode(node, null);
				}
				else
				{
					CreateNewConnectionFromToNode(null, node);
				}
				return;
			}
			Rect rect = rt.rect;
			Vector2 vector = ((eventData != null) ? MousePosInPanel() : NodePosToPanel(node.rt.position));
			Vector2 vector2 = vector / rect.size;
			Rect rect2 = nodeEditPanel.rt.rect;
			Vector2 anchor = new Vector2(Mathf.Lerp(-75f, rect2.width + 75f, vector2.x) / rect2.width, (vector2.y > 0.5f) ? (1f + 75f / rect2.height) : (-75f / rect2.height));
			connectionEditPanel.Hide();
			nodeEditPanel.SelectNode(node, vector, anchor);
			if (elementSelected)
			{
				UINavigationManager.RemoveEscapableFromStack(selectAction);
			}
			UINavigationManager.AddEscapableToStack(selectAction);
			elementSelected = true;
		}

		public void Deselect()
		{
			connectionEditPanel.Hide();
			nodeEditPanel.Hide();
			if (elementSelected)
			{
				UINavigationManager.RemoveEscapableFromStack(selectAction);
			}
			elementSelected = false;
		}

		public void OnPanelMoved(Vector2 move)
		{
			Deselect();
			CloseAddNodePanel();
		}

		private void Zoom(float increment)
		{
			if (increment != 0f)
			{
				Vector2 vector = MousePosInGraph();
				float value = increment * currentScale;
				value = Mathf.Clamp(value, minScale - currentScale, maxScale - currentScale);
				currentScale += value;
				brainRT.localScale = new Vector3(currentScale, currentScale, 1f);
				brainRT.anchoredPosition -= vector * value;
			}
		}

		public void CreateNewConnectionFromToNode(NodeEditor from, NodeEditor to)
		{
			NEATBrain.Synaps synaps = new NEATBrain.Synaps
			{
				Weight = 1f,
				En = true
			};
			tempConnection = connections.GetItemFromPool();
			tempConnection.AssignNodes(from, to, synaps);
			Deselect();
			UINavigationManager.AddEscapableToStack(createConnectionAction);
			connectingMode = true;
		}

		public void SplitConnectionInNewNode(ConnectionEditor connection, bool remainIngoing)
		{
			NodeEditor itemFromPool = hiddenNodes.GetItemFromPool();
			itemFromPool.AssignNode(new NEATBrain.Node
			{
				Type = NEATBrain.NodeType.Linear,
				baseActivation = 0f,
				Index = NEATBrain.NInputs + NEATBrain.NOutputs + hiddenNodes.activeCount,
				Desc = "Hidden Node"
			});
			itemFromPool.pos = connection.middlePoint;
			connections.GetItemFromPool().AssignNodes(remainIngoing ? itemFromPool : connection.nodeIn, remainIngoing ? connection.nodeOut : itemFromPool, new NEATBrain.Synaps
			{
				En = true,
				Weight = 1f
			});
			connection.ReassignNode(itemFromPool, !remainIngoing);
			SelectElement(itemFromPool, null);
			anyChange = true;
		}

		public void DeleteConnection(ConnectionEditor connection)
		{
			connection.ReturnToPool();
			Deselect();
			anyChange = true;
		}

		public void DeleteNode(NodeEditor node)
		{
			foreach (ConnectionEditor item in node.ingoings.Union(node.outgoings).ToList())
			{
				item.ReturnToPool();
			}
			if (node.archetype != NEATBrain.NodeArchetype.Hidden)
			{
				addNodePanel.SetIndexAvailability(node.node.Index, node.archetype, available: true);
			}
			anyChange = true;
			if (node.archetype == NEATBrain.NodeArchetype.Output)
			{
				node.EditBias(NEATBrain.DefaultBaseActivationOfType(node.node.Type));
				if (node.node.Type == NEATBrain.NodeType.Sigmoid)
				{
					Deselect();
					return;
				}
			}
			node.ReturnToPool();
			Deselect();
			CheckAllValid();
		}

		public void RequestAddNode(NEATBrain.NodeArchetype unavailableType = NEATBrain.NodeArchetype.Hidden)
		{
			Rect rect = rt.rect;
			Vector2 vector = MousePosInPanel();
			if (!(vector.x > rect.width) && !(vector.y > rect.height))
			{
				addPos = MouseToNodePos();
				Vector2 vector2 = vector / rect.size;
				Rect rect2 = addNodePanel.rt.rect;
				Vector2 pivot = new Vector2((vector2.x > 0.5f) ? (1f + 75f / rect2.width) : (-75f / rect2.width), Mathf.Lerp(-75f, rect2.height + 75f, vector2.y) / rect2.height);
				addNodePanel.RequestAddNode(vector, pivot, unavailableType);
				if (tempConnection != null)
				{
					tempConnection.updatePlacement = false;
				}
				addNodeMode = true;
				UINavigationManager.AddEscapableToStack(addNodeAction);
			}
		}

		public void AddNode(int index, NEATBrain.NodeArchetype archetype)
		{
			NodeEditor nodeEditor = ((archetype == NEATBrain.NodeArchetype.Hidden) ? hiddenNodes.GetItemFromPool() : baseNodes.GetItemWithKey(index));
			if (archetype != NEATBrain.NodeArchetype.Hidden)
			{
				nodeEditor.AssignNode(nodes[index]);
				addNodePanel.SetIndexAvailability(index, archetype, available: false);
			}
			else
			{
				nodeEditor.AssignNode(new NEATBrain.Node
				{
					Type = (NEATBrain.NodeType)index,
					baseActivation = NEATBrain.DefaultBaseActivationOfType((NEATBrain.NodeType)index),
					Index = NEATBrain.NInputs + NEATBrain.NOutputs + hiddenNodes.activeCount,
					Desc = "Hidden Node"
				});
			}
			nodeEditor.pos = addPos;
			CloseAddNodePanel();
			SelectElement(nodeEditor, null);
			anyChange = true;
		}

		public void CloseAddNodePanel()
		{
			UINavigationManager.RemoveEscapableFromStack(addNodeAction);
			addNodePanel.Hide();
			addNodeMode = false;
			if (tempConnection != null)
			{
				tempConnection.updatePlacement = true;
			}
		}

		public void StopConnecting()
		{
			if (connectingMode)
			{
				UINavigationManager.RemoveEscapableFromStack(createConnectionAction);
				if (tempConnection != null)
				{
					DeleteConnection(tempConnection);
				}
				connectingMode = false;
			}
		}

		protected NodeEditor GetNode(int i)
		{
			if (i >= NEATBrain.NInputs + NEATBrain.NOutputs)
			{
				return hiddenNodes.activeItems.FirstOrDefault((NodeEditor n) => n.node.Index == i);
			}
			return baseNodes[i];
		}

		public void UpdateShowValues(bool val)
		{
			hiddenNodes.ForEachActive(delegate(NodeEditor n)
			{
				n.UpdateShowValues(val);
			});
			baseNodes.ForEachActive(delegate(NodeEditor n)
			{
				n.UpdateShowValues(val);
			});
		}

		public void StepBrain()
		{
			connections.ForEachActive(delegate(ConnectionEditor c)
			{
				c.Propagate();
			});
			baseNodes.ForEachActive(delegate(NodeEditor n)
			{
				n.ExecuteNode();
			});
			hiddenNodes.ForEachActive(delegate(NodeEditor n)
			{
				n.ExecuteNode();
			});
		}

		public void OneBrainStep()
		{
			PlayBrain(val: false);
			StepBrain();
		}

		public void PlayBrain(bool val = true)
		{
			brainProgress = 0f;
			play = val;
			playButton.gameObject.SetActive(!val);
			stopButton.gameObject.SetActive(val);
		}

		private void OnDestroy()
		{
			UserSettings.ShowNodeValues.UnSubscribe(UpdateShowValues);
		}
	}
}
