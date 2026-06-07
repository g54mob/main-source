using System;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utility;
using Utility.InformationWrapers;

namespace UIScripts
{
	public class NodeEditPanel : MonoBehaviour
	{
		[SerializeField]
		private SettingSliderReference biasSliderRef;

		[SerializeField]
		private SettingSliderReference activationSliderRef;

		[SerializeField]
		private TextLineReference descFieldRef;

		[SerializeField]
		private SettingDropdownReference functionDropdownRef;

		[SerializeField]
		private GameObject inputDisclaimer;

		[SerializeField]
		private GameObject nonLinearDisclaimer;

		[FormerlySerializedAs("addBeforeButton")]
		[SerializeField]
		private Button addIngoingButton;

		[FormerlySerializedAs("addAfterButton")]
		[SerializeField]
		private Button addOutgoingButton;

		private NodeEditor node;

		[NonSerialized]
		public RectTransform rt;

		private ChoiceSetting<NEATBrain.NodeType> nodeFunction = new ChoiceSetting<NEATBrain.NodeType>
		{
			Name = "Activation Function",
			HelperText = "A node's output is equal the sum of it's inputs and bias, passed trough the activation function.\n\nNon-linear nodes might have different use for biases",
			DefaultValue = NEATBrain.NodeType.Linear,
			val = NEATBrain.NodeType.Linear,
			choices = new SettingChoices<NEATBrain.NodeType>(NodeTypeSelection.nodeTypeChoices)
		};

		private FloatSetting bias = new FloatSetting
		{
			Name = "Bias",
			HelperText = "The node's default activation. \nIt behaves as a constant activation of the node and determines the baseline input aside from any other incoming connection.\n\nSome nodes activation functions, like the Inhibitor function, use the bias differently, but most just add it to their total activation.",
			DefaultValue = 0f,
			val = 0f,
			minValue = -5f,
			maxValue = 5f,
			precision = 2,
			canGoOutOfBounds = true,
			SI = false,
			alwaysShowSign = true
		};

		private FloatSetting act = new FloatSetting
		{
			Name = "Value",
			HelperText = "The input node's value\nThis is just for the simulator, and allows you to test out how the network will react to given senses.",
			DefaultValue = 0f,
			val = 0f,
			minValue = -5f,
			maxValue = 5f,
			precision = 2,
			canGoOutOfBounds = true,
			SI = false,
			alwaysShowSign = true
		};

		private StringSetting desc = new StringSimulationSetting
		{
			Name = "Label",
			HelperText = "Identifies the node\nCan only be modified for hidden nodes",
			DefaultValue = "Hidden",
			val = "Hidden"
		};

		private FloatSettingSlider biasSlider;

		private FloatSettingSlider actSlider;

		private StringFieldHandle descField;

		private ChoiceSettingDropdown<ChoiceSetting<NEATBrain.NodeType>, NEATBrain.NodeType> functionDropdown;

		public void Init()
		{
			descField = new StringFieldHandle(desc, descFieldRef);
			functionDropdown = new ChoiceSettingDropdown<ChoiceSetting<NEATBrain.NodeType>, NEATBrain.NodeType>(nodeFunction, functionDropdownRef);
			biasSlider = new FloatSettingSlider(bias, biasSliderRef);
			actSlider = new FloatSettingSlider(act, activationSliderRef);
			rt = GetComponent<RectTransform>();
			desc.Subscribe(EditLabel);
			nodeFunction.Subscribe(EditFunction);
			nodeFunction.Subscribe(CheckTypeForBiasSlider);
			bias.Subscribe(EditBias);
			act.Subscribe(EditAct);
		}

		public void SelectNode(NodeEditor newNode, Vector2 pos, Vector2 anchor)
		{
			if (node != null)
			{
				node.SetHighlight(val: false);
			}
			node = null;
			nodeFunction.SetValue(newNode.node.Type);
			bias.SetValue(newNode.node.baseActivation);
			desc.SetValue(newNode.node.Desc);
			node = newNode;
			node.SetHighlight(val: true);
			CheckArchetype(node.archetype);
			NodeInformation nodeInformation = NodeInformations.InfoOfIndex(node.node.Index);
			if (node.archetype == NEATBrain.NodeArchetype.Input)
			{
				actSlider.SetMinMax(Mathf.Max(nodeInformation.minOutput, -5f), Mathf.Min(nodeInformation.maxOutput, 5f));
				act.SetValue(node.node.Value);
			}
			rt.pivot = anchor;
			rt.anchoredPosition = pos;
			base.gameObject.SetActive(value: true);
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Delete))
			{
				RemoveNode();
			}
		}

		public void AddConnection(bool from)
		{
			BibiteBrainEditor.instance.CreateNewConnectionFromToNode(from ? node : null, from ? null : node);
		}

		public void RemoveNode()
		{
			BibiteBrainEditor.instance.DeleteNode(node);
		}

		private void EditLabel(string val)
		{
			if (!(node == null))
			{
				node.EditLabel(val);
			}
		}

		private void EditFunction(NEATBrain.NodeType val)
		{
			if (!(node == null))
			{
				node.EditFunction(val);
			}
		}

		private void EditBias(float val)
		{
			if (!(node == null))
			{
				node.EditBias(val);
			}
		}

		private void EditAct(float val)
		{
			if (node != null && node.archetype == NEATBrain.NodeArchetype.Input)
			{
				node.EditAct(val);
			}
		}

		private void CheckTypeForBiasSlider(NEATBrain.NodeType val)
		{
			if (NEATBrain.TypeHasBias(val))
			{
				biasSlider.ShowUIElement();
			}
			else
			{
				biasSlider.HideUIElement();
			}
			if (val == NEATBrain.NodeType.Input)
			{
				actSlider.ShowUIElement();
			}
			else
			{
				actSlider.HideUIElement();
			}
			nonLinearDisclaimer.SetActive(NEATBrain.TypeIsNonLinear(val));
			if (NEATBrain.TypeUsesBiasDifferently(val))
			{
				switch (val)
				{
				case NEATBrain.NodeType.Mult:
					break;
				case NEATBrain.NodeType.Inhibitory:
					bias.canGoOutOfBounds = false;
					bias.SetMinMax(0.0001f, 10f);
					biasSlider.SetMinMax(0.0001f, 10f, forceInBounds: true);
					return;
				case NEATBrain.NodeType.SoftLatch:
					bias.canGoOutOfBounds = false;
					bias.SetMinMax(0.0001f, 1000f);
					biasSlider.SetMinMax(0.0001f, 1000f, forceInBounds: true);
					return;
				default:
					return;
				}
			}
			bias.canGoOutOfBounds = true;
			bias.SetMinMax(-5f, 5f);
			biasSlider.SetMinMax(-5f, 5f);
		}

		private void CheckArchetype(NEATBrain.NodeArchetype archetype)
		{
			descField.SetInteractable(archetype == NEATBrain.NodeArchetype.Hidden);
			functionDropdown.SetInteractable(archetype == NEATBrain.NodeArchetype.Hidden);
			inputDisclaimer.SetActive(archetype != NEATBrain.NodeArchetype.Hidden);
			addIngoingButton.interactable = archetype != NEATBrain.NodeArchetype.Input;
			addOutgoingButton.interactable = archetype != NEATBrain.NodeArchetype.Output;
		}

		public void Hide()
		{
			if (node != null)
			{
				node.SetHighlight(val: false);
			}
			node = null;
			base.gameObject.SetActive(value: false);
		}
	}
}
