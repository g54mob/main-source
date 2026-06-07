using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UI.Tables;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class ButtonTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<Button>();
			}
		}

		protected override AttributeDictionary defaultAttributeValues => new AttributeDictionary { { "interactable", "true" } };

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			XmlLayoutButton xmlLayoutButton = base.currentInstanceTransform.GetComponent<XmlLayoutButton>();
			Text text = base.currentInstanceTransform.GetComponentInChildren<Text>(includeInactive: true);
			bool flag = true;
			ColorBlock block = new ColorBlock
			{
				normalColor = Color.black,
				highlightedColor = Color.black,
				disabledColor = Color.black,
				pressedColor = Color.black,
				colorMultiplier = 1f
			};
			if (attributesToApply.ContainsKey("textcolors"))
			{
				block = attributesToApply["textcolors"].ToColorBlock(base.currentXmlLayoutInstance);
			}
			else if (attributesToApply.ContainsKey("textcolor") || attributesToApply.ContainsKey("deselectedtextcolor"))
			{
				Color color = (attributesToApply.ContainsKey("textcolor") ? attributesToApply["textcolor"] : attributesToApply["deselectedtextcolor"]).ToColor(base.currentXmlLayoutInstance);
				SetColorBlockColor(ref block, color);
			}
			if (base.currentXmlElement.childElements.Count > 0)
			{
				XmlElement xmlElement = base.currentXmlElement.childElements.First();
				if (xmlElement.tagType == "Text")
				{
					if (xmlElement.gameObject != text.gameObject)
					{
						xmlElement.rectTransform.SetParent(text.rectTransform.parent);
						if (Application.isPlaying)
						{
							UnityEngine.Object.Destroy(text.gameObject);
						}
						else
						{
							UnityEngine.Object.DestroyImmediate(text.gameObject);
						}
						text = xmlElement.GetComponent<Text>();
					}
					flag = false;
					if (xmlElement.attributes.ContainsKey("color"))
					{
						SetColorBlockColor(ref block, text.color);
					}
					xmlLayoutButton.TextComponent = new TextComponentWrapper(text);
				}
				else if (xmlElement.tagType == "TextMeshPro")
				{
					if (text != null && xmlElement.gameObject != text.gameObject)
					{
						xmlElement.rectTransform.SetParent(text.rectTransform.parent);
						if (Application.isPlaying)
						{
							UnityEngine.Object.Destroy(text.gameObject);
						}
						else
						{
							UnityEngine.Object.DestroyImmediate(text.gameObject);
						}
					}
					TextMeshProUGUI component = xmlElement.GetComponent<TextMeshProUGUI>();
					flag = false;
					if (xmlElement.attributes.ContainsKey("color"))
					{
						SetColorBlockColor(ref block, component.color);
					}
					xmlLayoutButton.TextComponent = new TextComponentWrapper(component);
				}
				if (!xmlElement.attributes.ContainsKey("text") && attributesToApply.ContainsKey("text"))
				{
					xmlElement.SetAndApplyAttribute("text", attributesToApply["text"]);
				}
				xmlElement.rectTransform.localScale = Vector3.one;
			}
			else
			{
				xmlLayoutButton.TextComponent = new TextComponentWrapper(text);
			}
			if (flag)
			{
				ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("Text");
				xmlTagHandler.SetInstance(text.rectTransform, base.currentXmlLayoutInstance);
				AttributeDictionary attributeDictionary = new AttributeDictionary(attributesToApply.Where((KeyValuePair<string, string> a) => TextTagHandler.TextAttributes.Contains(a.Key, StringComparer.OrdinalIgnoreCase)).ToDictionary((KeyValuePair<string, string> a) => a.Key, (KeyValuePair<string, string> b) => b.Value));
				if (attributesToApply.ContainsKey("textshadow"))
				{
					attributeDictionary.Add("shadow", attributesToApply["textshadow"]);
				}
				if (attributesToApply.ContainsKey("textoutline"))
				{
					attributeDictionary.Add("outline", attributesToApply["textoutline"]);
				}
				if (attributesToApply.ContainsKey("textcolor"))
				{
					attributeDictionary.Add("color", attributesToApply["textcolor"]);
				}
				if (attributesToApply.ContainsKey("textalignment"))
				{
					attributeDictionary.Add("alignment", attributesToApply["textalignment"]);
				}
				xmlTagHandler.ApplyAttributes(attributeDictionary);
			}
			Image component2 = base.currentInstanceTransform.GetComponent<Image>();
			if (attributesToApply.ContainsKey("preserveaspect"))
			{
				component2.preserveAspect = attributesToApply["preserveaspect"].ToBoolean();
			}
			if (attributesToApply.ContainsKey("icon") || base.currentXmlElement.attributes.ContainsKey("icon"))
			{
				TableCell iconCell = xmlLayoutButton.IconCell;
				string value = (attributesToApply.ContainsKey("iconAlignment") ? attributesToApply["iconAlignment"] : (base.currentXmlElement.attributes.ContainsKey("iconAlignment") ? base.currentXmlElement.attributes["iconAlignment"] : "Left"));
				ButtonIconAlignment num = (ButtonIconAlignment)Enum.Parse(typeof(ButtonIconAlignment), value);
				float value2 = (attributesToApply.ContainsKey("iconwidth") ? attributesToApply["iconwidth"].ToFloat() : (base.currentXmlElement.attributes.ContainsKey("iconwidth") ? base.currentXmlElement.attributes["iconwidth"].ToFloat() : 0f));
				xmlLayoutButton.ButtonTableLayout.ColumnWidths = new List<float> { 0f, 0f };
				if (num == ButtonIconAlignment.Left)
				{
					iconCell.transform.SetAsFirstSibling();
					xmlLayoutButton.ButtonTableLayout.ColumnWidths[0] = value2;
				}
				else
				{
					iconCell.transform.SetAsLastSibling();
					xmlLayoutButton.ButtonTableLayout.ColumnWidths[1] = value2;
				}
				xmlLayoutButton.IconComponent.preserveAspect = true;
				if (attributesToApply.ContainsKey("icon"))
				{
					xmlLayoutButton.IconComponent.sprite = attributesToApply["icon"].ToSprite();
				}
				if (attributesToApply.ContainsKey("iconcolor"))
				{
					xmlLayoutButton.IconColor = attributesToApply["iconcolor"].ToColor(base.currentXmlLayoutInstance);
				}
				if (attributesToApply.ContainsKey("iconhovercolor"))
				{
					xmlLayoutButton.IconHoverColor = attributesToApply["iconhovercolor"].ToColor(base.currentXmlLayoutInstance);
				}
				if (attributesToApply.ContainsKey("icondisabledcolor"))
				{
					xmlLayoutButton.IconDisabledColor = attributesToApply["icondisabledcolor"].ToColor(base.currentXmlLayoutInstance);
				}
				if (attributesToApply.ContainsKey("iconimagetype"))
				{
					xmlLayoutButton.IconComponent.type = (Image.Type)Enum.Parse(typeof(Image.Type), attributesToApply["iconimagetype"]);
				}
				iconCell.gameObject.SetActive(value: true);
				if ((!attributesToApply.ContainsKey("text") || string.IsNullOrEmpty(attributesToApply["text"])) && !base.currentXmlElement.attributes.ContainsKey("text"))
				{
					xmlLayoutButton.TextCell.gameObject.SetActive(value: false);
				}
				else
				{
					xmlLayoutButton.TextCell.gameObject.SetActive(value: true);
				}
			}
			if (attributesToApply.ContainsKey("padding"))
			{
				xmlLayoutButton.ButtonTableLayout.padding = attributesToApply["padding"].ToRectOffset();
			}
			xmlLayoutButton.TextColors = block;
			XmlLayoutTimer.DelayedCall(0f, delegate
			{
				if (xmlLayoutButton.mouseIsOver)
				{
					xmlLayoutButton.OnPointerEnter(null);
				}
				else
				{
					xmlLayoutButton.OnPointerExit(null);
				}
			}, xmlLayoutButton);
		}

		private void SetColorBlockColor(ref ColorBlock block, Color color)
		{
			block.normalColor = color;
			block.highlightedColor = color;
			block.disabledColor = color;
			block.pressedColor = color;
			block.colorMultiplier = 1f;
		}
	}
}
