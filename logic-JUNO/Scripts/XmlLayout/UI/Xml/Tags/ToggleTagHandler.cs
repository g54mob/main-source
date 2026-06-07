using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class ToggleTagHandler : InputBaseTagHandler, IHasXmlFormValue
	{
		private List<string> _eventAttributeNames = new List<string> { "onClick", "onMouseEnter", "onMouseExit", "onValueChanged", "onMouseUp", "onMouseDown" };

		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<Toggle>();
			}
		}

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			Toggle toggle = primaryComponent as Toggle;
			Image image = toggle.graphic as Image;
			Text text = base.currentXmlElement.GetComponentInChildren<Text>();
			if (base.currentXmlElement.childElements.Count > 0)
			{
				AttributeDictionary attributeDictionary = new AttributeDictionary();
				XmlElement xmlElement = base.currentXmlElement.childElements.First();
				if (xmlElement.tagType == "Text")
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
					if (!xmlElement.HasAttribute("alignment"))
					{
						attributeDictionary.Add("alignment", "MiddleLeft");
					}
				}
				else if (xmlElement.tagType == "TextMeshPro")
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
					if (!xmlElement.HasAttribute("alignment"))
					{
						attributeDictionary.Add("alignment", "Left");
					}
				}
				if (!xmlElement.HasAttribute("text"))
				{
					if (attributesToApply.ContainsKey("text"))
					{
						attributeDictionary.Add("text", attributesToApply["text"]);
					}
					else if (!base.currentXmlElement.HasAttribute("text"))
					{
						attributeDictionary.Add("active", "false");
					}
				}
				else
				{
					attributesToApply.SetValue("text", xmlElement.GetAttribute("text"));
				}
				if (!xmlElement.HasAttribute("padding"))
				{
					attributeDictionary.Add("padding", "23 5 2 1");
				}
				if (!xmlElement.HasAttribute("flexibleWidth"))
				{
					attributeDictionary.Add("flexibleWidth", "1");
				}
				if (attributeDictionary.Count > 0)
				{
					xmlElement.ApplyAttributes(attributeDictionary);
				}
			}
			if (attributesToApply.ContainsKey("checkcolor"))
			{
				image.color = attributesToApply["checkcolor"].ToColor(base.currentXmlLayoutInstance);
			}
			Image image2 = toggle.targetGraphic as Image;
			if (attributesToApply.ContainsKey("togglewidth"))
			{
				float num = float.Parse(attributesToApply["togglewidth"]);
				LayoutElement obj = image2.GetComponent<LayoutElement>() ?? image2.gameObject.AddComponent<LayoutElement>();
				obj.preferredWidth = num;
				obj.minWidth = num;
			}
			if (attributesToApply.ContainsKey("toggleheight"))
			{
				float num2 = float.Parse(attributesToApply["toggleheight"]);
				LayoutElement obj2 = image2.GetComponent<LayoutElement>() ?? image2.gameObject.AddComponent<LayoutElement>();
				obj2.preferredHeight = num2;
				obj2.minHeight = num2;
			}
			if (ToggleGroupTagHandler.CurrentToggleGroupInstance != null)
			{
				XmlLayoutToggleGroup xmlLayoutToggleGroupInstance = ToggleGroupTagHandler.CurrentToggleGroupInstance;
				xmlLayoutToggleGroupInstance.AddToggle(toggle);
				xmlLayoutToggleGroupInstance.UpdateToggleElement(toggle);
				toggle.onValueChanged.AddListener(delegate(bool e)
				{
					if (e)
					{
						int valueForElement = xmlLayoutToggleGroupInstance.GetValueForElement(toggle);
						xmlLayoutToggleGroupInstance.SetSelectedValue(valueForElement);
					}
				});
			}
			if (text != null)
			{
				ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("Text");
				xmlTagHandler.SetInstance(text.rectTransform, base.currentXmlLayoutInstance);
				AttributeDictionary attributeDictionary2 = new AttributeDictionary(attributesToApply.Where((KeyValuePair<string, string> a) => TextTagHandler.TextAttributes.Contains(a.Key, StringComparer.OrdinalIgnoreCase)).ToDictionary((KeyValuePair<string, string> a) => a.Key, (KeyValuePair<string, string> b) => b.Value));
				if (attributesToApply.ContainsKey("textshadow"))
				{
					attributeDictionary2.Add("shadow", attributesToApply["textshadow"]);
				}
				if (attributesToApply.ContainsKey("textoutline"))
				{
					attributeDictionary2.Add("outline", attributesToApply["textoutline"]);
				}
				if (attributesToApply.ContainsKey("textcolor"))
				{
					attributeDictionary2.Add("color", attributesToApply["textcolor"]);
				}
				xmlTagHandler.ApplyAttributes(attributeDictionary2);
				text.GetComponent<XmlElement>().enabled = false;
				text.gameObject.SetActive(!string.IsNullOrEmpty(text.text));
			}
			if (!attributesToApply.ContainsKey("text") && !base.currentXmlElement.attributes.ContainsKey("text"))
			{
				RectTransform rectTransform = ((Image)toggle.targetGraphic).rectTransform;
				if (!attributesToApply.ContainsKey("dontModifyBackground"))
				{
					rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
					rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
					rectTransform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
				}
			}
			if (attributesToApply.ContainsKey("togglebackgroundimage"))
			{
				image2.sprite = attributesToApply["togglebackgroundimage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("togglecheckmarkimage"))
			{
				image.sprite = attributesToApply["togglecheckmarkimage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("togglecheckmarkimagepreserveaspect"))
			{
				image.preserveAspect = attributesToApply["togglecheckmarkimagepreserveaspect"].ToBoolean();
			}
			if (attributesToApply.ContainsKey("togglecheckmarksize"))
			{
				float size = float.Parse(attributesToApply["togglecheckmarksize"]);
				image.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
				image.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
				image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
				image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
			}
		}

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			if (eventName == "onvaluechanged")
			{
				Toggle obj = (Toggle)primaryComponent;
				RectTransform transform = base.currentInstanceTransform;
				XmlLayout layout = base.currentXmlLayoutInstance;
				EventData eventData = GetEventValueData(eventValue);
				obj.onValueChanged.AddListener(delegate(bool e)
				{
					string value = eventData.value;
					if (eventData.value.ToLower() == "selectedvalue")
					{
						value = e.ToString();
					}
					layout.XmlLayoutController.ReceiveMessage(eventData.methodName, value, transform);
				});
			}
			else
			{
				base.HandleEventAttribute(eventName, eventValue);
			}
		}

		public string GetValue(XmlElement element)
		{
			return element.GetComponent<Toggle>().isOn.ToString();
		}

		public override void SetValue(string newValue, bool triggerEventHandlers = true)
		{
			Toggle component = base.currentXmlElement.GetComponent<Toggle>();
			bool flag = newValue.ToBoolean();
			if (component.isOn != flag)
			{
				Toggle.ToggleEvent onValueChanged = component.onValueChanged;
				if (!triggerEventHandlers)
				{
					component.onValueChanged = new Toggle.ToggleEvent();
				}
				component.isOn = flag;
				if (!triggerEventHandlers)
				{
					component.onValueChanged = onValueChanged;
				}
			}
		}
	}
}
