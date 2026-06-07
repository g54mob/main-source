using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class ToggleButtonTagHandler : ButtonTagHandler, IHasXmlFormValue
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
				return base.currentInstanceTransform.GetComponent<XmlLayoutToggleButton>();
			}
		}

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			Toggle toggleComponent = base.currentInstanceTransform.GetComponent<Toggle>();
			if (attributesToApply.ContainsKey("colors"))
			{
				toggleComponent.colors = attributesToApply["colors"].ToColorBlock(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("ison"))
			{
				toggleComponent.isOn = attributesToApply["ison"].ToBoolean();
			}
			if (attributesToApply.ContainsKey("selectedicon"))
			{
				XmlLayoutToggleButton component = toggleComponent.GetComponent<XmlLayoutToggleButton>();
				component.SelectedIconSprite = attributesToApply["selectedicon"].ToSprite();
				component.DeselectedIconSprite = component.IconComponent.sprite;
			}
			if (ToggleGroupTagHandler.CurrentToggleGroupInstance != null)
			{
				XmlLayoutToggleGroup xmlLayoutToggleGroupInstance = ToggleGroupTagHandler.CurrentToggleGroupInstance;
				xmlLayoutToggleGroupInstance.AddToggle(toggleComponent);
				xmlLayoutToggleGroupInstance.UpdateToggleElement(toggleComponent);
				toggleComponent.onValueChanged.AddListener(delegate(bool e)
				{
					if (e)
					{
						int valueForElement = xmlLayoutToggleGroupInstance.GetValueForElement(toggleComponent);
						xmlLayoutToggleGroupInstance.SetSelectedValue(valueForElement);
					}
				});
			}
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				toggleComponent.GetComponent<XmlLayoutToggleButton>().UpdateDisplay();
			}, toggleComponent);
		}

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			if (eventName == "onvaluechanged")
			{
				Toggle component = primaryComponent.GetComponent<Toggle>();
				RectTransform transform = base.currentInstanceTransform;
				XmlLayout layout = base.currentXmlLayoutInstance;
				EventData eventData = GetEventValueData(eventValue);
				component.onValueChanged.AddListener(delegate(bool e)
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
	}
}
