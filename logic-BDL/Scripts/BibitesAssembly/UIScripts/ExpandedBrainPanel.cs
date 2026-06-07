using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.SettingHandles;
using UIScripts.UIPanels;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts
{
	public class ExpandedBrainPanel : BibitePanel
	{
		[Header("Object References")]
		public UIPanel BrainSettingsPanel;

		public GameObject BrainHolder;

		public GameObject NeuronHolder;

		public GameObject SynapseHolder;

		public GameObject LinearGraphParameterHolder;

		public GameObject SphericalGraphParameterHolder;

		public GameObject StopButton;

		public GameObject StartButton;

		[Header("Prefabs")]
		public GameObject ExUINeuronPrefab;

		public GameObject UISynapsPrefab;

		private NEATBrain brain;

		private List<ExUINeuron> ExUINeurons = new List<ExUINeuron>();

		private List<ExUINeuron> UIinNeurons = new List<ExUINeuron>();

		private List<ExUINeuron> UIoutNeurons = new List<ExUINeuron>();

		private List<UISynaps> UISynapses = new List<UISynaps>();

		private SettingsGroupHandle LinearGraphParameters = new SettingsGroupHandle
		{
			GroupTitle = "Linear Graph Parameters",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ExpandedBrainParameters.Instance.linearSynapseAttraction),
				new FloatSettingSlider(ExpandedBrainParameters.Instance.linearNeuronRepulsion),
				new FloatSettingSlider(ExpandedBrainParameters.Instance.graphWidthStep),
				new FloatSettingSlider(ExpandedBrainParameters.Instance.graphHeightStep),
				new FloatSettingSlider(ExpandedBrainParameters.Instance.linearFriction),
				new FloatSettingSlider(ExpandedBrainParameters.Instance.switchingThreshold)
			}
		};

		private SettingsGroupHandle SphericalGraphParameters = new SettingsGroupHandle
		{
			GroupTitle = "Spherical Graph Parameters",
			Settings = new List<ISettingHandle>
			{
				new FloatSettingSlider(ExpandedBrainParameters.Instance.synapseAttraction),
				new FloatSettingSlider(ExpandedBrainParameters.Instance.neuronRepulsion),
				new FloatSettingSlider(ExpandedBrainParameters.Instance.attractionToCenter),
				new FloatSettingSlider(ExpandedBrainParameters.Instance.repulsionFromCenter),
				new FloatSettingSlider(ExpandedBrainParameters.Instance.circularFriction)
			}
		};

		private List<int> nextSearchNodes = new List<int>();

		private List<int> toRemove = new List<int>();

		private List<int> nextSearchSynapses = new List<int>();

		private List<int> reachableSynapses = new List<int>();

		private List<int> reachableNodes = new List<int>();

		[NonSerialized]
		public float currentScale = 0.5f;

		private float minScale = 0.1f;

		private float maxScale = 5f;

		private RectTransform rectTransform;

		[NonSerialized]
		public GraphType graphType;

		private float panelHeight;

		private float panelWidth;

		private float leftPadding = 20000f;

		private float rightPadding = 20000f;

		private float brainWindowWidth;

		private float brainWindowHeight;

		private float topPadding = 10000f;

		private float bottomPadding = 10000f;

		private float inputStep;

		private float outputStep;

		private int nMax;

		private int nIn;

		private int nOut;

		public bool runForceGraph;

		public bool branchesTrimmed;

		public static ExpandedBrainPanel Instance;

		public override BibitePanels PanelIndex => BibitePanels.ExpendedBrainPanel;

		public override void InitPanel()
		{
			Instance = this;
			rectTransform = BrainHolder.GetComponent<RectTransform>();
			LinearGraphParameters.AssignHolder(LinearGraphParameterHolder);
			LinearGraphParameters.CreateUIElements();
			SphericalGraphParameters.AssignHolder(SphericalGraphParameterHolder);
			SphericalGraphParameters.CreateUIElements();
			SphericalGraphParameters.Holder.transform.parent.GetComponent<RectTransform>().ForceUpdateRectTransforms();
			SphericalGraphParameterHolder.SetActive(value: false);
			LinearGraphParameterHolder.SetActive(value: true);
			BrainSettingsPanel.ClosePanel();
		}

		private void Zoom(float increment)
		{
			if (increment != 0f)
			{
				Vector3 vector = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
				Vector2 screenPoint = Input.mousePosition - vector;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, null, out var localPoint);
				float num = increment * currentScale;
				currentScale += num;
				if (currentScale >= maxScale)
				{
					currentScale = maxScale;
				}
				else if (currentScale <= minScale)
				{
					currentScale = minScale;
				}
				rectTransform.anchoredPosition -= num * localPoint;
				rectTransform.localScale = new Vector2(currentScale, currentScale);
			}
		}

		public override void ResetState()
		{
			brain = null;
		}

		public override void FillPanel()
		{
			brain = bibite.GetComponent<NEATBrain>();
		}

		protected override void UpdatePanel()
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				Zoom(Input.GetAxis("Mouse ScrollWheel"));
			}
			if (!runForceGraph)
			{
				return;
			}
			if (graphType == GraphType.Linear)
			{
				ApplyLinearForceGraph();
			}
			else
			{
				ApplySphericalForceGraph();
			}
			foreach (ExUINeuron exUINeuron in ExUINeurons)
			{
				if (graphType == GraphType.Circular)
				{
					exUINeuron.Move(ExpandedBrainParameters.Instance.circularFriction.val);
				}
				else if (exUINeuron.type == NodeType.Hidden)
				{
					exUINeuron.Move(ExpandedBrainParameters.Instance.linearFriction.val);
				}
				else
				{
					exUINeuron.Move(ExpandedBrainParameters.Instance.linearFriction.val, moveHiddenPos: true);
				}
			}
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			UserControl.AllowControl = false;
			TimeController.Instance.TogglePauseGame("ExpendedBrainPanel");
			if (brain == null || !brain.isReady)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 1;
			nOut = brain.nActiveOutputs;
			nIn = brain.nActiveInputs;
			nMax = Mathf.Max(nIn, nOut);
			brainWindowHeight = (float)nMax * ExpandedBrainParameters.Instance.graphHeightStep.val;
			panelHeight = topPadding + bottomPadding + brainWindowHeight;
			brainWindowWidth = (float)nMax * ExpandedBrainParameters.Instance.graphWidthStep.val;
			panelWidth = brainWindowWidth + leftPadding + rightPadding;
			currentScale = 5f / (float)nMax;
			if (currentScale >= maxScale)
			{
				currentScale = maxScale;
			}
			else if (currentScale <= minScale)
			{
				currentScale = minScale;
			}
			rectTransform.localScale = new Vector2(currentScale, currentScale);
			int num4 = 0;
			inputStep = brainWindowHeight / (float)Mathf.Max(nIn - 1, 1);
			outputStep = brainWindowHeight / (float)Mathf.Max(nOut - 1, 1);
			float num5 = brainWindowHeight / (float)Mathf.Max(brain.nHidden, 1);
			for (int i = 0; i < NEATBrain.NInputs + NEATBrain.NOutputs + brain.nHidden; i++)
			{
				if (brain.Nodes[i].NIn > 0 || brain.Nodes[i].NOut > 0)
				{
					if (i < NEATBrain.NInputs)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(ExUINeuronPrefab, NeuronHolder.transform, worldPositionStays: false);
						gameObject.transform.localPosition = new Vector2(leftPadding, 0f - topPadding + (float)(-num) * inputStep);
						ExUINeurons.Add(gameObject.GetComponent<ExUINeuron>());
						UIinNeurons.Add(gameObject.GetComponent<ExUINeuron>());
						ExUINeurons[num4].SetType(NodeType.Input);
						ExUINeurons[num4].rank = num;
						num++;
					}
					else if (i < NEATBrain.NInputs + NEATBrain.NOutputs)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(ExUINeuronPrefab, NeuronHolder.transform, worldPositionStays: false);
						gameObject.transform.localPosition = new Vector2(leftPadding + brainWindowWidth, 0f - topPadding + (float)(-num2) * outputStep);
						ExUINeurons.Add(gameObject.GetComponent<ExUINeuron>());
						UIoutNeurons.Add(gameObject.GetComponent<ExUINeuron>());
						ExUINeurons[num4].SetType(NodeType.Output);
						ExUINeurons[num4].rank = num2;
						num2++;
					}
					else
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(ExUINeuronPrefab, NeuronHolder.transform, worldPositionStays: false);
						gameObject.transform.localPosition = new Vector2(leftPadding + brainWindowWidth * UnityEngine.Random.Range(0.2f, 0.8f), 0f - topPadding + (float)(-num3) * num5);
						ExUINeurons.Add(gameObject.GetComponent<ExUINeuron>());
						ExUINeurons[num4].SetType(NodeType.Hidden);
						num3++;
					}
					ExUINeurons[num4].Initialize();
					ExUINeurons[num4].index = i;
					ExUINeurons[num4].SetDesc(brain.Nodes[i]);
					ExUINeurons[num4].SetValue(brain.Nodes[i].LastOutput);
					num4++;
				}
			}
			rectTransform.sizeDelta = new Vector2(panelWidth, panelHeight);
			int j;
			for (j = 0; j < brain.nSynaps; j++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(UISynapsPrefab, base.transform.position, Quaternion.identity, SynapseHolder.transform);
				UISynaps component = gameObject.GetComponent<UISynaps>();
				UISynapses.Add(component);
				component.InitSynaps();
				component.SetValue(brain.Synapses[j].Weight, j, brain.Synapses[j].Inov, brain.Synapses[j].En);
				int index = ExUINeurons.FindIndex((ExUINeuron _n) => _n.GetComponent<ExUINeuron>().index == brain.Synapses[j].NodeIn);
				component.SetAnchorIn(ExUINeurons[index]);
				int index2 = ExUINeurons.FindIndex((ExUINeuron _n) => _n.GetComponent<ExUINeuron>().index == brain.Synapses[j].NodeOut);
				component.SetAnchorOut(ExUINeurons[index2]);
				ExUINeurons[index].GetComponent<ExUINeuron>().outSynapses.Add(component);
				ExUINeurons[index2].GetComponent<ExUINeuron>().inSynapses.Add(component);
				component.UpdatePosition();
				gameObject.GetComponent<RectTransform>().SetAsFirstSibling();
			}
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			UserControl.AllowControl = true;
			TimeController.Instance.TogglePauseGame("ExpendedBrainPanel", isUnpause: true);
			StopButton.SetActive(value: false);
			StartButton.SetActive(value: true);
			LinearGraphParameters.ResetValue();
			SphericalGraphParameters.ResetValue();
			HaltForce();
			if (ExUINeurons != null)
			{
				foreach (ExUINeuron exUINeuron in ExUINeurons)
				{
					UnityEngine.Object.Destroy(exUINeuron.gameObject);
				}
			}
			if (UISynapses != null)
			{
				foreach (UISynaps uISynapse in UISynapses)
				{
					UnityEngine.Object.Destroy(uISynapse.gameObject);
				}
			}
			if (UIinNeurons != null)
			{
				foreach (ExUINeuron uIinNeuron in UIinNeurons)
				{
					UnityEngine.Object.Destroy(uIinNeuron.gameObject);
				}
			}
			if (UIoutNeurons != null)
			{
				foreach (ExUINeuron uIoutNeuron in UIoutNeurons)
				{
					UnityEngine.Object.Destroy(uIoutNeuron.gameObject);
				}
			}
			ExUINeurons?.Clear();
			UISynapses?.Clear();
			UIinNeurons?.Clear();
			UIoutNeurons?.Clear();
			nextSearchNodes.Clear();
			nextSearchSynapses.Clear();
			reachableSynapses.Clear();
			reachableNodes.Clear();
		}

		public void ToggleBrainSettings()
		{
			BrainSettingsPanel.TogglePanel();
		}

		public void DisableSynapse()
		{
			foreach (UISynaps uISynapse in UISynapses)
			{
				uISynapse.ToggleShowDisabled();
			}
		}

		public void HaltForce()
		{
			runForceGraph = false;
		}

		public void StartForce()
		{
			runForceGraph = true;
		}

		public void ApplySphericalForceGraph()
		{
			foreach (ExUINeuron exUINeuron in ExUINeurons)
			{
				Vector2 vector = new Vector3(panelWidth * 0.5f, panelHeight * -0.5f, 0f) - exUINeuron.transform.localPosition;
				float magnitude = vector.magnitude;
				float num = Mathf.Sqrt(magnitude) * ExpandedBrainParameters.Instance.attractionToCenter.val / 46f;
				exUINeuron.Accelerate(num * vector.normalized);
				if (exUINeuron.type != NodeType.Hidden)
				{
					vector = exUINeuron.transform.localPosition - new Vector3(panelWidth * 0.5f, panelHeight * -0.5f, 0f);
					magnitude = vector.magnitude;
					num = Mathf.Min(100f, ExpandedBrainParameters.Instance.repulsionFromCenter.val / Mathf.Pow(magnitude * 0.004f, 2f));
					exUINeuron.Accelerate(num * vector.normalized);
				}
				foreach (ExUINeuron exUINeuron2 in ExUINeurons)
				{
					if (exUINeuron.index != exUINeuron2.index)
					{
						vector = exUINeuron.transform.localPosition - exUINeuron2.transform.localPosition;
						magnitude = vector.magnitude;
						num = Mathf.Min(100f, ExpandedBrainParameters.Instance.neuronRepulsion.val / Mathf.Pow(magnitude * 0.04f, 2f));
						exUINeuron.Accelerate(num * vector.normalized);
					}
				}
			}
			ApplySynapticForce(ExpandedBrainParameters.Instance.synapseAttraction.val);
		}

		public void ApplyLinearForceGraph()
		{
			foreach (ExUINeuron exUINeuron5 in ExUINeurons)
			{
				foreach (ExUINeuron exUINeuron6 in ExUINeurons)
				{
					if (exUINeuron5.index != exUINeuron6.index)
					{
						if (exUINeuron5.type == NodeType.Hidden)
						{
							Vector2 vector = exUINeuron5.transform.localPosition - exUINeuron6.transform.localPosition;
							float magnitude = vector.magnitude;
							float num = Mathf.Min(100f, ExpandedBrainParameters.Instance.linearNeuronRepulsion.val / Mathf.Pow(magnitude * 0.04f, 2f));
							exUINeuron5.Accelerate(num * vector.normalized);
						}
						else
						{
							Vector2 vector2 = exUINeuron5.hiddenPosition - (Vector2)exUINeuron6.transform.localPosition;
							float magnitude2 = vector2.magnitude;
							float num2 = Mathf.Min(100f, ExpandedBrainParameters.Instance.linearNeuronRepulsion.val / Mathf.Pow(magnitude2 * 0.04f, 2f));
							exUINeuron5.Accelerate(num2 * vector2.normalized);
						}
					}
				}
			}
			float val = ExpandedBrainParameters.Instance.switchingThreshold.val;
			brainWindowWidth = (float)nMax * ExpandedBrainParameters.Instance.graphWidthStep.val;
			inputStep = (float)nMax * ExpandedBrainParameters.Instance.graphHeightStep.val / Mathf.Max((float)nIn - 1f, 1f);
			for (int i = 0; i < UIinNeurons.Count; i++)
			{
				ExUINeuron exUINeuron = UIinNeurons[i];
				int currentRank = exUINeuron.rank;
				if (currentRank < nIn - 1)
				{
					ExUINeuron exUINeuron2 = UIinNeurons.First((ExUINeuron node) => node.rank == currentRank + 1);
					if (exUINeuron2.hiddenPosition.y - exUINeuron.hiddenPosition.y > outputStep * val)
					{
						exUINeuron.rank = currentRank + 1;
						exUINeuron2.rank = currentRank;
						Vector3 vector3 = (exUINeuron2.transform.localPosition = new Vector2(leftPadding, 0f - topPadding - (float)currentRank * inputStep));
						exUINeuron2.hiddenPosition = vector3;
						exUINeuron2.velocity = Vector2.zero;
						exUINeuron.velocity = Vector2.zero;
					}
				}
				exUINeuron.transform.localPosition = new Vector2(leftPadding, 0f - topPadding - (float)exUINeuron.rank * inputStep);
				if (exUINeuron.rank != currentRank)
				{
					exUINeuron.hiddenPosition = exUINeuron.transform.localPosition;
					i++;
				}
			}
			outputStep = (float)nMax * ExpandedBrainParameters.Instance.graphHeightStep.val / Mathf.Max((float)nOut - 1f, 1f);
			for (int num3 = 0; num3 < UIoutNeurons.Count; num3++)
			{
				ExUINeuron exUINeuron3 = UIoutNeurons[num3];
				int currentRank2 = exUINeuron3.rank;
				if (currentRank2 < nOut - 1)
				{
					ExUINeuron exUINeuron4 = UIoutNeurons.First((ExUINeuron node) => node.rank == currentRank2 + 1);
					if (exUINeuron4.hiddenPosition.y - exUINeuron3.hiddenPosition.y > outputStep * val)
					{
						exUINeuron3.rank = currentRank2 + 1;
						exUINeuron4.rank = currentRank2;
						Vector3 vector3 = (exUINeuron4.transform.localPosition = new Vector2(leftPadding + brainWindowWidth, 0f - topPadding - (float)currentRank2 * outputStep));
						exUINeuron4.hiddenPosition = vector3;
						exUINeuron4.velocity = Vector2.zero;
						exUINeuron3.velocity = Vector2.zero;
					}
				}
				exUINeuron3.transform.localPosition = new Vector2(leftPadding + brainWindowWidth, 0f - topPadding - (float)exUINeuron3.rank * outputStep);
				if (exUINeuron3.rank != currentRank2)
				{
					exUINeuron3.hiddenPosition = exUINeuron3.transform.localPosition;
					num3++;
				}
			}
			ApplySynapticForce(ExpandedBrainParameters.Instance.linearSynapseAttraction.val);
		}

		private void ApplySynapticForce(float attractionParameter)
		{
			foreach (UISynaps uISynapse in UISynapses)
			{
				if (!uISynapse.disabled)
				{
					ExUINeuron exUINeuron = uISynapse.nodeIn as ExUINeuron;
					ExUINeuron exUINeuron2 = uISynapse.nodeOut as ExUINeuron;
					if (exUINeuron != null && exUINeuron2 != null)
					{
						Vector2 vector = exUINeuron.transform.localPosition - exUINeuron2.transform.localPosition;
						float num = Mathf.Sqrt(vector.magnitude) * (uISynapse.thickness / 6.5f) * attractionParameter;
						exUINeuron.Accelerate((0f - num) * vector.normalized);
						exUINeuron2.Accelerate(num * vector.normalized);
					}
				}
			}
		}

		public void BFS(int sourceNode)
		{
			nextSearchNodes.Add(sourceNode);
			NodeType type = ExUINeurons.First((ExUINeuron neuron) => neuron.index == sourceNode).type;
			while (nextSearchNodes.Count() != 0 || nextSearchSynapses.Count() != 0)
			{
				foreach (int n in nextSearchNodes)
				{
					ExUINeuron exUINeuron = ExUINeurons.First((ExUINeuron ExUINeuron) => ExUINeuron.index == n);
					if (n == sourceNode || exUINeuron.type == NodeType.Hidden)
					{
						reachableNodes.Add(n);
						foreach (UISynaps inSynapse in exUINeuron.inSynapses)
						{
							if (!reachableSynapses.Contains(inSynapse.index) && !nextSearchSynapses.Contains(inSynapse.index))
							{
								nextSearchSynapses.Add(inSynapse.index);
							}
						}
						foreach (UISynaps outSynapse in exUINeuron.outSynapses)
						{
							if (!reachableSynapses.Contains(outSynapse.index) && !nextSearchSynapses.Contains(outSynapse.index))
							{
								nextSearchSynapses.Add(outSynapse.index);
							}
						}
					}
					else if (exUINeuron.type != type)
					{
						reachableNodes.Add(n);
					}
				}
				nextSearchNodes.Clear();
				foreach (int s in nextSearchSynapses)
				{
					UISynaps uISynaps = UISynapses.First((UISynaps UISynaps) => UISynaps.index == s);
					if (!uISynaps.disabled)
					{
						reachableSynapses.Add(s);
						if (!reachableNodes.Contains(uISynaps.nodeIn.index) && !nextSearchNodes.Contains(uISynaps.nodeIn.index))
						{
							nextSearchNodes.Add(uISynaps.nodeIn.index);
						}
						if (!reachableNodes.Contains(uISynaps.nodeOut.index) && !nextSearchNodes.Contains(uISynaps.nodeOut.index))
						{
							nextSearchNodes.Add(uISynaps.nodeOut.index);
						}
					}
				}
				nextSearchSynapses.Clear();
			}
			RemoveBranches(sourceNode);
			drawGraph();
		}

		public void RemoveBranches(int sourceNode)
		{
			int num = 0;
			toRemove.Clear();
			while (num == 0)
			{
				num = 1;
				foreach (int n in reachableNodes)
				{
					ExUINeuron exUINeuron = ExUINeurons.First((ExUINeuron ExUINeuron) => ExUINeuron.index == n);
					if (exUINeuron.type != NodeType.Hidden || n == sourceNode)
					{
						continue;
					}
					int num2 = 0;
					foreach (UISynaps outSynapse in exUINeuron.outSynapses)
					{
						if (reachableSynapses.Contains(outSynapse.index))
						{
							num2 = 1;
						}
					}
					if (num2 == 0)
					{
						toRemove.Add(n);
						num = 0;
					}
					num2 = 0;
					foreach (UISynaps inSynapse in exUINeuron.inSynapses)
					{
						if (reachableSynapses.Contains(inSynapse.index))
						{
							num2 = 1;
						}
					}
					if (num2 == 0)
					{
						toRemove.Add(n);
						num = 0;
					}
				}
				reachableNodes.RemoveAll((int x) => toRemove.Contains(x));
				toRemove.Clear();
				foreach (int s in reachableSynapses)
				{
					UISynaps uISynaps = UISynapses.First((UISynaps UISynaps) => UISynaps.index == s);
					if (!uISynaps.disabled)
					{
						if (!reachableNodes.Contains(uISynaps.nodeOut.index))
						{
							toRemove.Add(s);
							num = 0;
						}
						if (!reachableNodes.Contains(uISynaps.nodeIn.index))
						{
							toRemove.Add(s);
							num = 0;
						}
					}
					else
					{
						toRemove.Add(s);
						num = 0;
					}
				}
				reachableSynapses.RemoveAll((int x) => toRemove.Contains(x));
				toRemove.Clear();
			}
		}

		public void drawGraph()
		{
			foreach (ExUINeuron exUINeuron in ExUINeurons)
			{
				exUINeuron.SetAlphaLow(val: true);
			}
			foreach (UISynaps uISynapse in UISynapses)
			{
				uISynapse.setAlphaLow(val: true);
			}
			foreach (int i in reachableNodes)
			{
				ExUINeurons.First((ExUINeuron ExUINeuron) => ExUINeuron.index == i).SetAlphaLow(val: false);
			}
			foreach (int i2 in reachableSynapses)
			{
				UISynapses.First((UISynaps UISynaps) => UISynaps.index == i2).setAlphaLow(val: false);
			}
			reachableNodes.Clear();
			reachableSynapses.Clear();
		}

		public void toggleTrimBranches()
		{
			if (branchesTrimmed)
			{
				resetBFS();
				branchesTrimmed = false;
				return;
			}
			reachableNodes.Clear();
			reachableSynapses.Clear();
			int sourceNode = 0;
			foreach (ExUINeuron exUINeuron in ExUINeurons)
			{
				reachableNodes.Add(exUINeuron.index);
			}
			foreach (UISynaps uISynapse in UISynapses)
			{
				reachableSynapses.Add(uISynapse.index);
			}
			RemoveBranches(sourceNode);
			drawGraph();
			branchesTrimmed = true;
		}

		public void resetBFS()
		{
			foreach (ExUINeuron exUINeuron in ExUINeurons)
			{
				exUINeuron.SetAlphaLow(val: false);
			}
			foreach (UISynaps uISynapse in UISynapses)
			{
				uISynapse.setAlphaLow(val: false);
			}
		}

		public void reset()
		{
			ClosePanel();
			OpenPanel();
		}

		public void ToggleGraphType()
		{
			if (graphType == GraphType.Linear)
			{
				setGraphCircular();
			}
			else
			{
				setGraphLinear();
			}
		}

		public void setGraphLinear()
		{
			graphType = GraphType.Linear;
			LinearGraphParameterHolder.GetComponent<RectTransform>().ForceUpdateRectTransforms();
		}

		public void setGraphCircular()
		{
			graphType = GraphType.Circular;
			RectTransform component = SphericalGraphParameterHolder.GetComponent<RectTransform>();
			component.ForceUpdateRectTransforms();
			component.parent.GetComponent<RectTransform>().ForceUpdateRectTransforms();
		}
	}
}
