using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class DropdownTagHandler : ElementTagHandler, IHasXmlFormValue
	{
		private List<string> _eventAttributeNames = new List<string> { "onClick", "onMouseEnter", "onMouseExit", "onValueChanged" };

		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<Dropdown>();
			}
		}

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override bool UseParseChildElements => true;

		protected override bool dontCallHandleDataSourceAttributeAutomatically => true;

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			Dropdown dropdown = primaryComponent as Dropdown;
			Image component = dropdown.template.GetComponent<Image>();
			Toggle componentInChildren = dropdown.template.GetComponentInChildren<Toggle>();
			Text captionText = dropdown.captionText;
			ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("Text");
			xmlTagHandler.SetInstance(captionText.rectTransform, base.currentXmlLayoutInstance);
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
			captionText.GetComponent<XmlElement>().enabled = false;
			XmlLayoutDropdown component2 = dropdown.GetComponent<XmlLayoutDropdown>();
			Image arrow = component2.Arrow;
			if (attributesToApply.ContainsKey("arrowimage"))
			{
				arrow.sprite = attributesToApply["arrowimage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("arrowcolor"))
			{
				arrow.color = attributesToApply["arrowcolor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("dropdownheight"))
			{
				dropdown.template.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, float.Parse(attributesToApply["dropdownheight"]));
			}
			Toggle itemTemplate = component2.ItemTemplate;
			ElementTagHandler xmlTagHandler2 = XmlLayoutUtilities.GetXmlTagHandler("Toggle");
			AttributeDictionary attributeDictionary2 = attributesToApply.Clone();
			if (attributesToApply.ContainsKey("itemheight"))
			{
				float size = float.Parse(attributesToApply["itemheight"]);
				(itemTemplate.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
				component.GetComponentInChildren<ScrollRect>().content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
			}
			if (attributesToApply.ContainsKey("checkcolor"))
			{
				attributeDictionary2.Add("togglecheckmarkcolor", attributesToApply["checkcolor"]);
			}
			if (attributesToApply.ContainsKey("checksize"))
			{
				attributeDictionary2.Add("togglecheckmarksize", attributesToApply["checksize"]);
			}
			if (attributesToApply.ContainsKey("checkimage"))
			{
				attributeDictionary2.Add("togglecheckmarkimage", attributesToApply["checkimage"]);
			}
			if (attributesToApply.ContainsKey("checkimagepreserveaspect"))
			{
				attributeDictionary2.Add("togglecheckmarkimagepreserveaspect", attributesToApply["checkimagepreserveaspect"]);
			}
			attributeDictionary2.Remove("vm-dataSource");
			attributeDictionary2.Remove("vm-options");
			attributeDictionary2.Remove("color");
			attributeDictionary2.Remove("colors");
			attributeDictionary2.Add("dontModifyBackground", string.Empty);
			XmlElement component3 = itemTemplate.transform.GetComponent<XmlElement>();
			if (component3 == null)
			{
				xmlTagHandler2.SetInstance(itemTemplate.transform as RectTransform, base.currentXmlLayoutInstance);
				xmlTagHandler2.ApplyAttributes(attributeDictionary2);
				component3 = itemTemplate.transform.GetComponent<XmlElement>();
			}
			else
			{
				component3.ApplyAttributes(attributeDictionary2);
			}
			if (component3 != null)
			{
				component3.enabled = false;
			}
			if (attributesToApply.ContainsKey("itembackgroundcolors"))
			{
				componentInChildren.colors = attributesToApply["itembackgroundcolors"].ToColorBlock(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("dropdownbackgroundcolor"))
			{
				dropdown.template.GetComponent<Image>().color = attributesToApply["dropdownbackgroundcolor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("dropdownbackgroundimage"))
			{
				dropdown.template.GetComponent<Image>().sprite = attributesToApply["dropdownbackgroundimage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("itemtextcolor"))
			{
				dropdown.itemText.color = attributesToApply["itemtextcolor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("scrollbarcolors"))
			{
				component2.DropdownScrollbar.colors = attributesToApply["scrollbarcolors"].ToColorBlock(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("scrollbarimage"))
			{
				component2.DropdownScrollbar.image.sprite = attributesToApply["scrollbarimage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("scrollbarbackgroundcolor"))
			{
				component2.DropdownScrollbar.GetComponent<Image>().color = attributesToApply["scrollbarbackgroundcolor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("scrollbarbackgroundimage"))
			{
				component2.DropdownScrollbar.GetComponent<Image>().sprite = attributesToApply["scrollbarbackgroundimage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("scrollsensitivity"))
			{
				dropdown.template.GetComponent<ScrollRect>().scrollSensitivity = attributesToApply["scrollsensitivity"].ToFloat();
			}
			foreach (KeyValuePair<string, string> item in attributesToApply)
			{
				SetPropertyValue(component, item.Key, item.Value);
			}
			if (attributesToApply.ContainsKey("vm-options"))
			{
				component2.optionsDataSource = attributesToApply["vm-options"];
			}
			if (attributesToApply.ContainsKey("vm-dataSource"))
			{
				HandleDataSourceAttribute(attributesToApply.GetValue("vm-dataSource"), attributesToApply.GetValue("vm-options"));
			}
		}

		public override void Close()
		{
			base.Close();
			(primaryComponent as Dropdown).RefreshShownValue();
		}

		public override void ParseChildElements(XmlNode xmlNode)
		{
			Dropdown dropdown = (Dropdown)primaryComponent;
			dropdown.value = 0;
			int num = 0;
			int num2 = -1;
			foreach (XmlNode childNode in xmlNode.ChildNodes)
			{
				if (childNode.Name.ToLower() != "option")
				{
					continue;
				}
				string innerText = childNode.InnerText;
				dropdown.options.Add(new Dropdown.OptionData
				{
					text = innerText
				});
				AttributeDictionary attributeDictionary = childNode.Attributes.ToAttributeDictionary();
				if (attributeDictionary.ContainsKey("selected"))
				{
					try
					{
						if (attributeDictionary["selected"].ToBoolean())
						{
							num2 = num;
						}
					}
					catch
					{
					}
				}
				num++;
			}
			if (num2 >= 0)
			{
				dropdown.value = num2;
				dropdown.RefreshShownValue();
			}
		}

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			if (eventName == "onvaluechanged")
			{
				Dropdown dropdown = (Dropdown)primaryComponent;
				RectTransform transform = base.currentInstanceTransform;
				XmlLayout layout = base.currentXmlLayoutInstance;
				EventData eventData = GetEventValueData(eventValue);
				dropdown.onValueChanged.AddListener(delegate(int e)
				{
					string value = eventData.value;
					if (eventData.value != null)
					{
						switch (eventData.value.ToLower())
						{
						case "selectedtext":
						case "selectedvalue":
							value = dropdown.options[e].text;
							break;
						case "selectedindex":
							value = e.ToString();
							break;
						}
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
			Dropdown component = element.GetComponent<Dropdown>();
			return component.options[component.value].text;
		}

		public override void SetValue(string newValue, bool fireEventHandlers = true)
		{
			if (!string.IsNullOrEmpty(newValue))
			{
				Dropdown dropdown = (Dropdown)primaryComponent;
				int result = -1;
				Dropdown.DropdownEvent onValueChanged = dropdown.onValueChanged;
				if (!fireEventHandlers)
				{
					dropdown.onValueChanged = new Dropdown.DropdownEvent();
				}
				if (int.TryParse(newValue, out result))
				{
					dropdown.SetSelectedValue(result);
				}
				else
				{
					dropdown.SetSelectedValue(newValue);
				}
				if (!fireEventHandlers)
				{
					dropdown.onValueChanged = onValueChanged;
				}
			}
		}

		public override void SetListData(IObservableList list)
		{
			List<string> list2 = (List<string>)list;
			if (list2 == null)
			{
				Debug.LogWarning("[XmlLayout][MVVM][Dropdown] Warning: list provided for options needs to be a list of of string values.");
			}
			((Dropdown)primaryComponent).SetOptions(list2);
		}

		protected override void HandleDataSourceAttribute(string dataSource, string additionalDataSource = null)
		{
			XmlLayoutDropdownDataSource xmlLayoutDropdownDataSource = new XmlLayoutDropdownDataSource(dataSource, base.currentXmlElement, additionalDataSource);
			base.currentXmlLayoutInstance.ElementDataSources.RemoveAll((XmlElementDataSource ed) => ed.XmlElement == base.currentXmlElement);
			base.currentXmlLayoutInstance.ElementDataSources.Add(xmlLayoutDropdownDataSource);
			if (xmlLayoutDropdownDataSource.BindingType != ViewModelBindingType.TwoWay)
			{
				return;
			}
			Dropdown dropdown = (Dropdown)primaryComponent;
			XmlLayoutControllerMVVM controller = (XmlLayoutControllerMVVM)base.currentXmlLayoutInstance.XmlLayoutController;
			dropdown.onValueChanged.AddListener(delegate
			{
				Type viewModelMemberDataType = controller.GetViewModelMemberDataType(dataSource);
				if (viewModelMemberDataType == typeof(int))
				{
					controller.SetViewModelValue(dataSource, dropdown.value, fromTwoWayBinding: true);
				}
				else if (viewModelMemberDataType == typeof(string))
				{
					controller.SetViewModelValue(dataSource, dropdown.options[dropdown.value].text, fromTwoWayBinding: true);
				}
			});
		}
	}
}
