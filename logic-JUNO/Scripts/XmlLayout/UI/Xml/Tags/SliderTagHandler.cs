using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class SliderTagHandler : ElementTagHandler, IHasXmlFormValue
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
				return base.currentInstanceTransform.GetComponent<Slider>();
			}
		}

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			if (eventName == "onvaluechanged")
			{
				Slider obj = (Slider)primaryComponent;
				RectTransform transform = base.currentInstanceTransform;
				XmlLayout layout = base.currentXmlLayoutInstance;
				EventData eventData = GetEventValueData(eventValue);
				obj.onValueChanged.AddListener(delegate(float e)
				{
					string methodName = eventData.methodName;
					string value = eventData.value;
					if (eventData.value.ToLower() == "selectedvalue")
					{
						value = e.ToString();
					}
					layout.XmlLayoutController.ReceiveMessage(methodName, value, transform);
				});
			}
			else
			{
				base.HandleEventAttribute(eventName, eventValue);
			}
		}

		public string GetValue(XmlElement element)
		{
			return element.GetComponent<Slider>().value.ToString();
		}

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			XmlLayoutSlider component = primaryComponent.GetComponent<XmlLayoutSlider>();
			if (attributesToApply.ContainsKey("backgroundcolor"))
			{
				component.Background.color = attributesToApply["backgroundcolor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("backgroundimage"))
			{
				component.Background.sprite = attributesToApply["backgroundimage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("fillcolor"))
			{
				component.Fill.color = attributesToApply["fillcolor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("fillimage"))
			{
				component.Fill.sprite = attributesToApply["fillimage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("fillMaskImage"))
			{
				GameObject gameObject = component.Fill.transform.parent.gameObject;
				Mask mask = gameObject.GetComponent<Mask>();
				if (mask == null)
				{
					mask = gameObject.AddComponent<Mask>();
				}
				mask.showMaskGraphic = false;
				Image image = gameObject.GetComponent<Image>();
				if (image == null)
				{
					image = gameObject.AddComponent<Image>();
				}
				image.sprite = attributesToApply["fillMaskImage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("fillPadding"))
			{
				RectTransform obj = component.Fill.rectTransform.parent as RectTransform;
				RectOffset rectOffset = attributesToApply["fillPadding"].ToRectOffset();
				obj.offsetMin = new Vector2(rectOffset.left, rectOffset.bottom);
				obj.offsetMax = new Vector2(-rectOffset.right, -rectOffset.top);
			}
			Image image2 = component.Slider.targetGraphic as Image;
			if (attributesToApply.ContainsKey("handleimage"))
			{
				image2.sprite = attributesToApply["handleimage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("handlepreserveaspect"))
			{
				image2.preserveAspect = attributesToApply["handlepreserveaspect"].ToBoolean();
			}
			if (attributesToApply.ContainsKey("handlecolor"))
			{
				image2.color = attributesToApply["handlecolor"].ToColor(base.currentXmlLayoutInstance);
			}
		}

		public override void SetValue(string newValue, bool fireEventHandlers = true)
		{
			Slider component = base.currentXmlElement.GetComponent<Slider>();
			Slider.SliderEvent onValueChanged = component.onValueChanged;
			if (!fireEventHandlers)
			{
				component.onValueChanged = new Slider.SliderEvent();
			}
			component.value = float.Parse(newValue);
			if (!fireEventHandlers)
			{
				component.onValueChanged = onValueChanged;
			}
		}
	}
}
