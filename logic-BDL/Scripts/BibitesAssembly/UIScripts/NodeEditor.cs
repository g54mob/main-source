using System;
using System.Collections.Generic;
using System.Linq;
using OneUseScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Utility;
using Utility.InformationWrapers;

namespace UIScripts
{
	public class NodeEditor : PoolableDictItem<int, NodeEditor>, IDragHandler, IEventSystemHandler, IPointerClickHandler, IEndDragHandler
	{
		public Image plus;

		public Image minus;

		public Image icon;

		[NonSerialized]
		public UnityEvent<NodeEditor, PointerEventData> itemClicked = new UnityEvent<NodeEditor, PointerEventData>();

		[NonSerialized]
		public UnityEvent<bool> validityChanged = new UnityEvent<bool>();

		[NonSerialized]
		public NEATBrain.Node node;

		[NonSerialized]
		public List<ConnectionEditor> ingoings = new List<ConnectionEditor>();

		[NonSerialized]
		public List<ConnectionEditor> outgoings = new List<ConnectionEditor>();

		public Vector2 groupPos;

		[SerializeField]
		private FloatValueTextHandle outputValue;

		public float activation;

		private Image img;

		private Material mat;

		private TooltipTrigger tooltip;

		[NonSerialized]
		protected Camera cam;

		private float alpha = 1f;

		private bool beingDragged;

		[NonSerialized]
		public RectTransform rt;

		private RectTransform parentRT;

		private static readonly int Selected = Shader.PropertyToID("_Selected");

		private static readonly int Invalid = Shader.PropertyToID("_Invalid");

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		[NonSerialized]
		public bool valid = true;

		public float bias => node.baseActivation;

		public string desc => node.Desc;

		public NEATBrain.NodeType nodeFunction => node.Type;

		public NEATBrain.NodeArchetype archetype => node.archetype;

		public Vector2 pos
		{
			get
			{
				return rt.anchoredPosition;
			}
			set
			{
				rt.anchoredPosition = value;
			}
		}

		public List<ConnectionEditor> connections => ingoings.Union(outgoings).ToList();

		public override void Initialize()
		{
			base.Initialize();
			cam = UICamera.cam;
			img = GetComponent<Image>();
			img.material = UnityEngine.Object.Instantiate(img.material);
			mat = img.material;
			outputValue.InitFromSetup(new FloatValueFormat
			{
				precision = 2,
				alwaysShowSign = true,
				SI = false
			});
			rt = GetComponent<RectTransform>();
			tooltip = GetComponent<TooltipTrigger>();
			parentRT = rt.parent.GetComponent<RectTransform>();
		}

		public override void Retire()
		{
			base.Retire();
			ingoings.Clear();
			outgoings.Clear();
		}

		public override void Destroy()
		{
			base.Destroy();
			UnityEngine.Object.Destroy(mat);
		}

		public void AssignNode(NEATBrain.Node targetNode)
		{
			node = targetNode;
			valid = true;
			NEATBrain.NodeType type = node.Type;
			if ((type == NEATBrain.NodeType.Inhibitory || type == NEATBrain.NodeType.SoftLatch) && Mathf.Approximately(node.baseActivation, 0f))
			{
				node.baseActivation = 0.1f;
			}
			UpdateIcon();
			UpdateIndicator();
			UpdateTooltip();
			ExecuteNode();
			SetHighlight(val: false);
			UpdateShowValues(UserSettings.ShowNodeValues.val);
			RefreshValidity();
		}

		public void AddConnection(ConnectionEditor connection, bool ingoing)
		{
			if (ingoing && !ingoings.Contains(connection))
			{
				ingoings.Add(connection);
			}
			else if (!ingoing && !outgoings.Contains(connection))
			{
				outgoings.Add(connection);
			}
			RefreshValidity();
		}

		public void RemoveConnection(ConnectionEditor connection, bool ingoing)
		{
			if (ingoing)
			{
				ingoings.Remove(connection);
			}
			else
			{
				outgoings.Remove(connection);
			}
			RefreshValidity();
		}

		public void RefreshValidity()
		{
			bool num = valid;
			if (archetype == NEATBrain.NodeArchetype.Input)
			{
				valid = outgoings.Count > 0;
			}
			else if (archetype == NEATBrain.NodeArchetype.Hidden)
			{
				valid = outgoings.Count > 0 && ingoings.Count > 0;
			}
			else if (archetype == NEATBrain.NodeArchetype.Output)
			{
				valid = true;
			}
			img.material.SetFloat(Invalid, valid ? 0f : 1f);
			img.materialForRendering.SetFloat(Invalid, valid ? 0f : 1f);
			if (num != valid)
			{
				validityChanged.Invoke(valid);
			}
		}

		public void ChangeIndex(int i)
		{
			node.Index = i;
			ingoings.ForEach(delegate(ConnectionEditor c)
			{
				c.connection.NodeOut = i;
			});
			outgoings.ForEach(delegate(ConnectionEditor c)
			{
				c.connection.NodeIn = i;
			});
		}

		public void EditLabel(string val)
		{
			if (archetype == NEATBrain.NodeArchetype.Hidden)
			{
				node.Desc = val;
				UpdateTooltip();
			}
		}

		public void EditBias(float val)
		{
			if (NEATBrain.TypeHasBias(nodeFunction))
			{
				if (nodeFunction == NEATBrain.NodeType.Inhibitory)
				{
					val = Mathf.Clamp(val, 0.0001f, 10f);
				}
				else if (nodeFunction == NEATBrain.NodeType.SoftLatch)
				{
					val = Mathf.Clamp(val, 0.0001f, 1000f);
				}
				node.baseActivation = val;
				UpdateIndicator();
				UpdateTooltip();
				ExecuteNode();
			}
		}

		public void EditAct(float val)
		{
			if (nodeFunction == NEATBrain.NodeType.Input)
			{
				node.LastOutput = val;
				node.Value = val;
				UpdateValue();
				UpdateNodeColor();
			}
		}

		public void EditFunction(NEATBrain.NodeType type)
		{
			if (archetype == NEATBrain.NodeArchetype.Hidden)
			{
				node.Type = type;
				node.baseActivation = NEATBrain.DefaultBaseActivationOfType(type);
				activation = ((nodeFunction == NEATBrain.NodeType.Mult) ? 1f : 0f);
				UpdateIndicator();
				UpdateIcon();
				ExecuteNode();
			}
		}

		public void ExecuteNode()
		{
			if (archetype != NEATBrain.NodeArchetype.Input)
			{
				NEATBrain.ExecuteNeuron(ref node, activation, BibiteBrainEditor.brainPeriod);
				UpdateNodeColor();
				UpdateValue();
				activation = ((nodeFunction == NEATBrain.NodeType.Mult) ? 1f : 0f);
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				beingDragged = true;
				tooltip.enabled = false;
				rt.anchoredPosition = BibiteBrainEditor.instance.MousePosToStickyNodePos();
				BibiteBrainEditor.instance.Deselect();
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			beingDragged = false;
			tooltip.enabled = true;
		}

		public virtual void SetAlphaLow(bool val)
		{
			alpha = (val ? 0.02f : 1f);
			icon.color = new Color(1f, 1f, 1f, alpha);
			UpdateNodeColor();
			UpdateIndicator();
		}

		public void UpdateIcon()
		{
			if (archetype == NEATBrain.NodeArchetype.Hidden)
			{
				icon.sprite = BrainIconHolder.instance.GetIconOfFunction(node.Type);
			}
			else
			{
				icon.sprite = BrainIconHolder.instance.GetIconOfIndex(node.Index);
			}
		}

		public void UpdateShowValues(bool val)
		{
			outputValue.gameObject.SetActive(val);
		}

		private void UpdateTooltip()
		{
			string text = ((archetype != NEATBrain.NodeArchetype.Hidden) ? NodeInformations.InfoOfIndex(node.Index).tooltipText : ($"Function: {node.Type}\n" + NodeInformations.InfoOfFunction(node.Type).tooltipText));
			if (archetype != NEATBrain.NodeArchetype.Input)
			{
				text += $"\n\nDefault Activation: {node.baseActivation:F4}";
				if (archetype == NEATBrain.NodeArchetype.Output)
				{
					text += $"\nFunction: {node.Type}";
				}
			}
			tooltip.UpdateText(desc, text);
		}

		private void UpdateValue()
		{
			outputValue.SetValue(node.Value);
		}

		public void UpdateNodeColor()
		{
			float value = node.Value;
			float num = (Mathf.Exp(2.5f * value) - 1f) / (1f + Mathf.Exp(2.5f * value));
			Color value2 = ((value >= 0f) ? new Color(1f - num, 1f, 1f - num, alpha) : new Color(1f, num + 1f, num + 1f, alpha));
			img.material.SetColor(Color1, value2);
			img.materialForRendering.SetColor(Color1, value2);
		}

		public void UpdateIndicator()
		{
			Image obj = ((node.baseActivation > 0f) ? plus : minus);
			obj.gameObject.SetActive(Mathf.Abs(node.baseActivation) > 0f);
			((node.baseActivation <= 0f) ? plus : minus).gameObject.SetActive(value: false);
			obj.color = UISynaps.GetColorGradiant(alpha: Mathf.Pow(Mathf.InverseLerp(0f, 1f, Mathf.Abs(node.baseActivation)), 0.5f), _val: node.baseActivation);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!beingDragged)
			{
				itemClicked.Invoke(this, eventData);
			}
		}

		public void SetHighlight(bool val)
		{
			img.material.SetFloat(Selected, val ? 1f : 0f);
			img.materialForRendering.SetFloat(Selected, val ? 1f : 0f);
		}
	}
}
