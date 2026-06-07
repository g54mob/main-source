using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class InputFieldTagHandler : InputBaseTagHandler, IHasXmlFormValue
	{
		private List<string> _eventAttributeNames = new List<string> { "onClick", "onMouseEnter", "onMouseExit", "onValueChanged", "onEndEdit", "onSubmit", "onMouseUp", "onMouseDown" };

		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<InputField>();
			}
		}

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			InputField inputField = primaryComponent as InputField;
			List<Text> list = new List<Text> { inputField.textComponent };
			if (inputField.placeholder != null)
			{
				Text component = inputField.placeholder.GetComponent<Text>();
				if (component != null)
				{
					list.Add(component);
				}
				if (attributesToApply.ContainsKey("placeholdertext"))
				{
					component.text = StringExtensions.DecodeEncodedNonAsciiCharacters(attributesToApply["placeholdertext"]);
				}
			}
			foreach (Text item in list)
			{
				ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("Text");
				xmlTagHandler.SetInstance(item.rectTransform, base.currentXmlLayoutInstance);
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
				attributeDictionary.Remove("text");
				if (attributesToApply.ContainsKey("textoffset"))
				{
					RectOffset rectOffset = attributesToApply["textoffset"].ToRectOffset();
					attributeDictionary.Add("offsetMin", $"{rectOffset.left} {rectOffset.bottom}");
					attributeDictionary.Add("offsetMax", $"-{rectOffset.right} -{rectOffset.top}");
				}
				xmlTagHandler.ApplyAttributes(attributeDictionary);
			}
		}

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			switch (eventName)
			{
			case "onvaluechanged":
			case "onendedit":
			case "onsubmit":
			{
				InputField inputField = (InputField)primaryComponent;
				RectTransform transform = base.currentInstanceTransform;
				XmlLayout layout = base.currentXmlLayoutInstance;
				EventData eventData = GetEventValueData(eventValue);
				UnityAction<string> listener = delegate(string e)
				{
					string value = eventData.value;
					if (eventData.value != null && eventData.value.ToLower() == "value")
					{
						value = e.ToString();
					}
					layout.XmlLayoutController.ReceiveMessage(eventData.methodName, value, transform);
				};
				switch (eventName)
				{
				case "onvaluechanged":
					inputField.onValueChanged.AddListener(listener);
					break;
				case "onendedit":
					inputField.onEndEdit.AddListener(listener);
					break;
				case "onsubmit":
					base.currentXmlElement.AddOnSubmitEvent(delegate
					{
						string arg = eventData.value;
						if (eventData.value != null && eventData.value.ToLower() == "value")
						{
							arg = inputField.text;
						}
						listener(arg);
					});
					break;
				}
				break;
			}
			default:
				base.HandleEventAttribute(eventName, eventValue);
				break;
			}
		}

		public string GetValue(XmlElement element)
		{
			return element.GetComponent<InputField>().text;
		}
	}
}
