using System;
using System.Collections.Generic;
using OneUseScripts;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;
using Utility.InformationWrapers;

namespace UIScripts
{
	public class UINeuron : PoolableDictItem<int, UINeuron>, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IDragHandler
	{
		[NonSerialized]
		public float value;

		public TextMeshProUGUI activationValue;

		public TextMeshProUGUI descText;

		[NonSerialized]
		public string desc = "";

		[NonSerialized]
		public string info = "";

		[NonSerialized]
		public int index;

		public Image plus;

		public Image minus;

		public Image icon;

		public bool showValueOnHover = true;

		[NonSerialized]
		public float alphaFloat;

		[NonSerialized]
		public bool hidden;

		[NonSerialized]
		public List<UISynaps> inSynapses = new List<UISynaps>();

		[NonSerialized]
		public List<UISynaps> outSynapses = new List<UISynaps>();

		[NonSerialized]
		protected Image img;

		[NonSerialized]
		private TooltipTrigger tooltip;

		[NonSerialized]
		protected RectTransform parentRectTransform;

		[NonSerialized]
		public bool isHovered;

		[NonSerialized]
		protected Camera cam;

		public NEATBrain.Node node;

		[NonSerialized]
		public long inov;

		private string tooltipText;

		private float targetStep = 1f;

		private Material mat;

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private static readonly int Selected = Shader.PropertyToID("_Selected");

		private static readonly int HighlightAmount = Shader.PropertyToID("_HighlightAmount");

		public NEATBrain.NodeArchetype nodeArchetype => node.archetype;

		public override void Initialize()
		{
			base.Initialize();
			tooltip = GetComponent<TooltipTrigger>();
			cam = UICamera.cam;
			activationValue.gameObject.SetActive(value: false);
			img = GetComponent<Image>();
			img.material = UnityEngine.Object.Instantiate(img.material);
			mat = img.material;
			parentRectTransform = base.transform.parent.GetComponent<RectTransform>();
			alphaFloat = 1f;
		}

		public override void Retire()
		{
			base.Retire();
			ResetDiff();
		}

		public virtual void Update()
		{
			if (Time.timeScale != 0f)
			{
				mat.SetColor(Color1, GetColorGradiant(value));
				if (isHovered)
				{
					activationValue.text = (Mathf.Round(100f * value) / 100f).ToString() ?? "";
				}
			}
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (showValueOnHover)
			{
				isHovered = true;
				activationValue.gameObject.SetActive(value: true);
				activationValue.text = (Mathf.Round(100f * value) / 100f).ToString() ?? "";
			}
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			if (showValueOnHover)
			{
				isHovered = false;
				activationValue.gameObject.SetActive(value: false);
			}
		}

		public void ShowOverDesc(bool val)
		{
			descText.gameObject.SetActive(val);
		}

		public virtual void SetAlphaLow(bool val)
		{
			Color color = mat.GetColor(Color1);
			Color color2 = plus.color;
			Color color3 = minus.color;
			Color color4 = icon.color;
			hidden = val;
			alphaFloat = (val ? 0.02f : 1f);
			color.a = alphaFloat;
			color2.a = alphaFloat;
			color3.a = alphaFloat;
			color4.a = alphaFloat;
			mat.SetColor(Color1, color);
			plus.color = color2;
			minus.color = color3;
			icon.color = color4;
		}

		public void SetValue(float _value)
		{
			value = _value;
			mat.SetColor(Color1, GetColorGradiant(value));
			if (isHovered)
			{
				activationValue.text = (Mathf.Round(100f * value) / 100f).ToString() ?? "";
			}
		}

		public void SetDiff(float diff, float dist, float contrib, float highlight)
		{
			mat.SetInt(Selected, 1);
			mat.SetFloat(HighlightAmount, highlight);
			tooltip.UpdateText(desc, tooltipText + string.Format("\n\nDelta: {0}{1}\nResulting Genetic Distance: {2:F3}\nContribution to speciation: +{3:F1}%", (diff > 0f) ? "+" : "", diff, dist, 100f * contrib));
		}

		public void ResetDiff()
		{
			mat.SetInt(Selected, 0);
			tooltip.UpdateText(desc, tooltipText);
		}

		public void SetDesc(NEATBrain.Node targetNode)
		{
			node = targetNode;
			index = node.Index;
			inov = node.Inov;
			desc = node.Desc;
			NodeInformation nodeInformation = ((node.archetype != NEATBrain.NodeArchetype.Hidden) ? NodeInformations.InfoOfIndex(node.Index) : NodeInformations.InfoOfFunction(node.Type));
			if (node.archetype != NEATBrain.NodeArchetype.Hidden)
			{
				tooltipText = nodeInformation.desc;
			}
			else
			{
				tooltipText = "Function: " + nodeInformation.name + " " + (nodeInformation.isLinear ? "" : "(nonlinear)") + "\n" + nodeInformation.desc + "\n" + nodeInformation.rangeText;
			}
			if (node.archetype != NEATBrain.NodeArchetype.Input)
			{
				if (node.archetype == NEATBrain.NodeArchetype.Output)
				{
					tooltipText = tooltipText + $"\nFunction: {node.Type}" + "\n" + nodeInformation.rangeText;
				}
				tooltipText += $"\n\nDefault Activation: {node.baseActivation:F4}";
				if (node.archetype != NEATBrain.NodeArchetype.Output)
				{
					tooltipText += $"\nInnovation: {inov}";
				}
			}
			if (tooltip == null)
			{
				tooltip = GetComponent<TooltipTrigger>();
			}
			tooltip.UpdateText(desc, tooltipText);
			plus.gameObject.SetActive(value: false);
			minus.gameObject.SetActive(value: false);
			if (node.Index < NEATBrain.NInputs + NEATBrain.NOutputs)
			{
				icon.sprite = BrainIconHolder.instance.GetIconOfIndex(node.Index);
				descText.text = desc;
			}
			else
			{
				descText.text = node.Type.ToString();
				icon.sprite = BrainIconHolder.instance.GetIconOfFunction(node.Type);
			}
			if (node.Index > NEATBrain.NInputs)
			{
				Image obj = ((node.baseActivation > 0f) ? plus : minus);
				obj.gameObject.SetActive(Mathf.Abs(node.baseActivation) > 0f);
				obj.color = UISynaps.GetColorGradiant(alpha: Mathf.Pow(Mathf.InverseLerp(0f, 1f, Mathf.Abs(node.baseActivation)), 0.5f), _val: node.baseActivation);
			}
		}

		public void SetStep(float val)
		{
			targetStep = val;
		}

		public Color GetColorGradiant(float val)
		{
			float num = (Mathf.Exp(2.5f * val) - 1f) / (1f + Mathf.Exp(2.5f * val));
			if (val >= 0f)
			{
				return new Color(1f - num, 1f, 1f - num, alphaFloat);
			}
			return new Color(1f, num + 1f, num + 1f, alphaFloat);
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				Vector2 vector = cam.WorldToScreenPoint(parentRectTransform.position);
				Vector2 vector2 = (eventData.position - vector) / UserSettings.totalUIScale;
				float x = Mathf.Max(Mathf.Min(vector2.x, parentRectTransform.rect.width), 0f);
				float num = Mathf.Max(Mathf.Min(vector2.y, 0f), 0f - parentRectTransform.rect.height);
				if (Input.GetKey(KeyCode.LeftShift))
				{
					num = Mathf.Round(num / targetStep) * targetStep;
				}
				base.transform.localPosition = new Vector3(x, num, 0f);
			}
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
