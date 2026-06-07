using System;
using System.Collections.Generic;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class SpinnerTagHandler : ElementTagHandler
	{
		private List<string> _eventAttributeNames = new List<string> { "onValueChanged", "onNumericValueChanged" };

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "textColor", "xmlLayout:color" },
			{ "interactable", "xs:boolean" },
			{ "value", "xs:string" },
			{ "values", "xs:string" },
			{ "numericValue", "xs:float" },
			{ "minValue", "xs:float" },
			{ "maxValue", "xs:float" },
			{ "stepSize", "xs:float" },
			{ "numericFormat", "xs:string" },
			{ "buttonColors", "xmlLayout:colorblock" },
			{ "onValueChanged", "xmlLayout:function" },
			{ "onNumericValueChanged", "xmlLayout:function" }
		};

		public override bool isCustomElement => true;

		public override string prefabPath => "Ui/Prefabs/XmlLayout/Spinner";

		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<SpinnerScript>();
			}
		}

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			SpinnerScript spinnerScript = primaryComponent as SpinnerScript;
			if (attributesToApply.ContainsKey("interactable"))
			{
				bool interactable = attributesToApply["interactable"].ToBoolean();
				spinnerScript.PrevButton.interactable = interactable;
				spinnerScript.NextButton.interactable = interactable;
			}
			if (attributesToApply.ContainsKey("value"))
			{
				spinnerScript.Value = attributesToApply["value"];
			}
			if (attributesToApply.ContainsKey("buttoncolors"))
			{
				spinnerScript.NextButton.colors = attributesToApply["buttoncolors"].ToColorBlock(base.currentXmlLayoutInstance);
				spinnerScript.PrevButton.colors = attributesToApply["buttoncolors"].ToColorBlock(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("minvalue"))
			{
				spinnerScript.SpinnerType = SpinnerType.Numeric;
				spinnerScript.MinValue = attributesToApply["minvalue"].ToFloat();
			}
			if (attributesToApply.ContainsKey("maxvalue"))
			{
				spinnerScript.SpinnerType = SpinnerType.Numeric;
				spinnerScript.MaxValue = attributesToApply["maxvalue"].ToFloat();
			}
			if (attributesToApply.ContainsKey("stepsize"))
			{
				spinnerScript.SpinnerType = SpinnerType.Numeric;
				spinnerScript.StepSize = attributesToApply["stepsize"].ToFloat();
			}
			if (attributesToApply.ContainsKey("numericvalue"))
			{
				spinnerScript.SpinnerType = SpinnerType.Numeric;
				spinnerScript.SetNumericValue(attributesToApply["numericvalue"].ToFloat());
			}
			if (attributesToApply.ContainsKey("numericformat"))
			{
				spinnerScript.SpinnerType = SpinnerType.Numeric;
				spinnerScript.NumericFormat = attributesToApply["numericformat"];
			}
			if (attributesToApply.ContainsKey("numericwrap"))
			{
				spinnerScript.SpinnerType = SpinnerType.Numeric;
				spinnerScript.NumericWrap = attributesToApply["numericwrap"].ToBoolean();
			}
			if (attributesToApply.ContainsKey("values"))
			{
				string[] array = attributesToApply["values"].Split(new char[1] { ';' });
				spinnerScript.Values.Clear();
				string[] array2 = array;
				foreach (string value in array2)
				{
					spinnerScript.Values.Add(value);
				}
			}
		}

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			if (eventName == "onvaluechanged")
			{
				SpinnerScript component = primaryComponent.GetComponent<SpinnerScript>();
				RectTransform transform = base.currentInstanceTransform;
				XmlLayout layout = base.currentXmlLayoutInstance;
				string[] eventData = eventValue.Trim(')', ';').Split(',', '(');
				string value = null;
				if (eventData.Length > 1)
				{
					value = eventData[1];
				}
				component.OnValueChanged = (Action<string>)Delegate.Combine(component.OnValueChanged, (Action<string>)delegate(string x)
				{
					string value3 = value;
					if (value.ToLower() == "selectedvalue")
					{
						value3 = x;
					}
					layout.XmlLayoutController.ReceiveMessage(eventData[0], value3, transform);
				});
			}
			else if (eventName == "onnumericvaluechanged")
			{
				SpinnerScript component2 = primaryComponent.GetComponent<SpinnerScript>();
				RectTransform transform2 = base.currentInstanceTransform;
				XmlLayout layout2 = base.currentXmlLayoutInstance;
				string[] eventData2 = eventValue.Trim(')', ';').Split(',', '(');
				string value2 = null;
				if (eventData2.Length > 1)
				{
					value2 = eventData2[1];
				}
				component2.OnNumericValueChanged = (Action<float>)Delegate.Combine(component2.OnNumericValueChanged, (Action<float>)delegate(float x)
				{
					string value3 = value2;
					if (value2.ToLower() == "selectedvalue")
					{
						value3 = x.ToString();
					}
					layout2.XmlLayoutController.ReceiveMessage(eventData2[0], value3, transform2);
				});
			}
			else
			{
				base.HandleEventAttribute(eventName, eventValue);
			}
		}
	}
}
