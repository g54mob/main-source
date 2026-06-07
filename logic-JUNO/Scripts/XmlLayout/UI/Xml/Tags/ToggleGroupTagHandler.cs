using System.Collections.Generic;
using UnityEngine;

namespace UI.Xml.Tags
{
	public class ToggleGroupTagHandler : ElementTagHandler, IHasXmlFormValue
	{
		private List<string> _eventAttributeNames = new List<string> { "onClick", "onMouseEnter", "onMouseExit", "onValueChanged", "onMouseUp", "onMouseDown" };

		private static XmlLayoutToggleGroup previousToggleGroupInstance;

		public static XmlLayoutToggleGroup CurrentToggleGroupInstance;

		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<XmlLayoutToggleGroup>();
			}
		}

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override void Open(AttributeDictionary elementAttributes)
		{
			base.Open(elementAttributes);
			previousToggleGroupInstance = CurrentToggleGroupInstance;
			CurrentToggleGroupInstance = primaryComponent as XmlLayoutToggleGroup;
		}

		public override void Close()
		{
			base.Close();
			CurrentToggleGroupInstance = previousToggleGroupInstance;
		}

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			if (eventName == "onvaluechanged")
			{
				XmlLayoutToggleGroup xmlLayoutToggleGroup = (XmlLayoutToggleGroup)primaryComponent;
				RectTransform transform = base.currentInstanceTransform;
				EventData eventData = GetEventValueData(eventValue);
				xmlLayoutToggleGroup.AddOnValueChangedEventHandler(delegate(int e)
				{
					string value = eventData.value;
					string text = eventData.value.ToLower();
					if (text == "selectedvalue")
					{
						value = e.ToString();
					}
					else if (text == "selectedtext")
					{
						value = xmlLayoutToggleGroup.GetTextValueForIndex(e);
					}
					base.currentXmlLayoutInstance.XmlLayoutController.ReceiveMessage(eventData.methodName, value, transform);
				});
			}
			else
			{
				base.HandleEventAttribute(eventName, eventValue);
			}
		}

		public string GetValue(XmlElement element)
		{
			return element.GetComponent<XmlLayoutToggleGroup>().GetSelectedValue().ToString();
		}
	}
}
