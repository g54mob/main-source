using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class TextMeshProDropdownTagHandler : ElementTagHandler, IHasXmlFormValue
	{
		private List<string> _eventAttributeNames = new List<string> { "onClick", "onMouseEnter", "onMouseExit", "onValueChanged", "onMouseUp", "onMouseDown" };

		public static TextMeshProDropdownTagHandler CurrentHandler { get; private set; }

		public override bool isCustomElement => true;

		public override string prefabPath => "XmlLayout Prefabs/TextMeshPro/TextMeshPro - Dropdown";

		public override MonoBehaviour primaryComponent => base.currentXmlElement.GetComponent<TMP_Dropdown>();

		public TMP_Dropdown CurrentDropdown => primaryComponent as TMP_Dropdown;

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "interactable", "xs:boolean" },
			{ "arrowImage", "xs:string" },
			{ "arrowColor", "xmlLayout:color" },
			{ "dropDownHeight", "xs:float" },
			{ "itemHeight", "xs:float" },
			{ "checkColor", "xmlLayout:color" },
			{ "checkSize", "xs:float" },
			{ "checkImage", "xs:string" },
			{ "checkImagePreserveAspect", "xs:boolean" },
			{ "itemBackgroundColors", "xmlLayout:colorblock" },
			{ "dropDownBackgroundColor", "xmlLayout:color" },
			{ "dropDownBackgroundImage", "xs:string" },
			{ "scrollbarColors", "xmlLayout:colorblock" },
			{ "scrollbarImage", "xs:string" },
			{ "scrollbarBackgroundColor", "xmlLayout:color" },
			{ "scrollbarBackgroundImage", "xs:string" },
			{ "scrollbarWidth", "xs:float" },
			{ "colors", "xmlLayout:colorblock" },
			{ "vm-options", "xs:string" },
			{ "onValueChanged", "xmlLayout:function" },
			{ "padding", "xmlLayout:vector4" }
		};

		public override List<string> attributeGroups => new List<string> { "image" };

		public override string elementChildType => "TextMeshProDropdown";

		protected override bool dontCallHandleDataSourceAttributeAutomatically => true;

		public override void Open(AttributeDictionary elementAttributes)
		{
			base.Open(elementAttributes);
			base.currentInstanceTransform.name = "TextMeshPro - Dropdown";
			CurrentHandler = this;
			TMP_Dropdown tMP_Dropdown = base.currentInstanceTransform.GetComponent<TMP_Dropdown>();
			if (tMP_Dropdown == null)
			{
				tMP_Dropdown = base.currentInstanceTransform.gameObject.AddComponent<TMP_Dropdown>();
				tMP_Dropdown.ClearOptions();
			}
			tMP_Dropdown.targetGraphic = tMP_Dropdown.GetComponent<Image>();
			RectTransform rectTransform = base.currentInstanceTransform.Find("Label") as RectTransform;
			TextMeshProUGUI textMeshProUGUI = rectTransform.GetComponent<TextMeshProUGUI>();
			if (textMeshProUGUI == null)
			{
				textMeshProUGUI = rectTransform.gameObject.AddComponent<TextMeshProUGUI>();
				textMeshProUGUI.color = new Color(0.2f, 0.2f, 0.2f);
				textMeshProUGUI.fontSize = 14f;
				textMeshProUGUI.alignment = TextAlignmentOptions.Left;
			}
			RectTransform rectTransform2 = base.currentXmlElement.rectTransform.Find("Template") as RectTransform;
			rectTransform2.gameObject.SetActive(value: true);
			RectTransform rectTransform3 = base.currentInstanceTransform.Find("Template/Viewport/Content/Item/Item Label") as RectTransform;
			TextMeshProUGUI textMeshProUGUI2 = rectTransform3.GetComponentInChildren<TextMeshProUGUI>();
			if (textMeshProUGUI2 == null)
			{
				textMeshProUGUI2 = rectTransform3.gameObject.AddComponent<TextMeshProUGUI>();
				textMeshProUGUI2.alignment = TextAlignmentOptions.Left;
				textMeshProUGUI2.color = new Color(0.2f, 0.2f, 0.2f);
				textMeshProUGUI2.fontSize = 14f;
			}
			tMP_Dropdown.template = rectTransform2;
			tMP_Dropdown.captionText = textMeshProUGUI;
			tMP_Dropdown.itemText = textMeshProUGUI2;
			rectTransform.anchorMin = Vector2.zero;
			rectTransform.anchorMax = Vector2.one;
			rectTransform.offsetMin = new Vector2(10f, 6f);
			rectTransform.offsetMax = new Vector2(-25f, -7f);
			rectTransform3.anchorMin = Vector2.zero;
			rectTransform3.anchorMax = Vector2.one;
			rectTransform3.offsetMin = new Vector2(20f, 1f);
			rectTransform3.offsetMax = new Vector2(-20f, -2f);
			XmlElement obj = rectTransform3.GetComponent<XmlElement>() ?? rectTransform3.gameObject.AddComponent<XmlElement>();
			obj.SetAttribute("alignment", "MidlineLeft");
			obj.SetAttribute("offsetMin", "20,1");
			obj.SetAttribute("offsetMax", "-20,-2");
			rectTransform2.gameObject.SetActive(value: false);
		}

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			RectTransform rectTransform = base.currentXmlElement.rectTransform.Find("Template") as RectTransform;
			if (base.currentInstanceTransform.GetComponent<LayoutElement>() == null)
			{
				base.currentInstanceTransform.gameObject.AddComponent<LayoutElement>();
			}
			base.ApplyAttributes(attributesToApply);
			if (ElementHasAttribute("dropdownheight", attributesToApply))
			{
				rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, float.Parse(attributesToApply["dropdownheight"]));
			}
			RectTransform rectTransform2 = CurrentDropdown.itemText.rectTransform.parent as RectTransform;
			if (ElementHasAttribute("itemHeight", attributesToApply))
			{
				float size = float.Parse(base.currentXmlElement.GetAttribute("itemheight"));
				(rectTransform2.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
				(base.currentXmlElement.rectTransform.Find("Template/Viewport/Content") as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
			}
			Image component = base.currentXmlElement.rectTransform.Find("Arrow").GetComponent<Image>();
			if (attributesToApply.ContainsKey("arrowImage"))
			{
				component.sprite = attributesToApply["arrowImage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("arrowColor"))
			{
				component.color = attributesToApply["arrowColor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("itemBackgroundColors"))
			{
				rectTransform2.GetComponent<Toggle>().colors = attributesToApply["itemBackgroundColors"].ToColorBlock(base.currentXmlLayoutInstance);
			}
			Image component2 = rectTransform.GetComponent<Image>();
			if (attributesToApply.ContainsKey("dropdownBackgroundColor"))
			{
				component2.color = attributesToApply["dropdownBackgroundColor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("dropdownBackgroundImage"))
			{
				component2.sprite = attributesToApply["dropdownBackgroundImage"].ToSprite();
			}
			Scrollbar componentInChildren = rectTransform.GetComponentInChildren<Scrollbar>();
			Image image = componentInChildren.targetGraphic as Image;
			if (attributesToApply.ContainsKey("scrollbarColors"))
			{
				componentInChildren.colors = attributesToApply["scrollbarColors"].ToColorBlock(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("scrollbarImage"))
			{
				image.sprite = attributesToApply["scrollbarImage"].ToSprite();
			}
			Image component3 = componentInChildren.GetComponent<Image>();
			if (attributesToApply.ContainsKey("scrollbarBackgroundColor"))
			{
				component3.color = attributesToApply["scrollbarBackgroundColor"].ToColor(base.currentXmlLayoutInstance);
			}
			if (attributesToApply.ContainsKey("scrollbarBackgroundImage"))
			{
				component3.sprite = attributesToApply["scrollbarBackgroundImage"].ToSprite();
			}
			if (attributesToApply.ContainsKey("scrollbarWidth"))
			{
				componentInChildren.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, attributesToApply["scrollbarWidth"].ToFloat());
			}
			if (attributesToApply.ContainsKey("padding"))
			{
				Vector4 vector = attributesToApply["padding"].ToVector4();
				RectTransform obj = base.currentInstanceTransform.Find("Label") as RectTransform;
				obj.offsetMin = new Vector2(vector.x, vector.w);
				obj.offsetMax = new Vector2(0f - vector.y, 0f - vector.z);
			}
			Image component4 = rectTransform2.Find("Item Checkmark").GetComponent<Image>();
			if (attributesToApply.ContainsKey("checkColor"))
			{
				component4.color = attributesToApply["checkColor"].ToColor(base.currentXmlLayoutInstance);
			}
			else
			{
				component4.color = new Color(0f, 0f, 0f);
			}
			if (attributesToApply.ContainsKey("checkImage"))
			{
				component4.sprite = attributesToApply["checkImage"].ToSprite();
			}
			else
			{
				component4.sprite = XmlLayoutUtilities.LoadResource<Sprite>("Sprites/Elements/Checkmark");
			}
			if (attributesToApply.ContainsKey("checkSize"))
			{
				float size2 = attributesToApply["checkSize"].ToFloat();
				component4.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size2);
				component4.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size2);
			}
			if (attributesToApply.ContainsKey("checkImagePreserveAspect"))
			{
				component4.preserveAspect = attributesToApply["checkMarkImagePreserveAspect"].ToBoolean();
			}
			if (attributesToApply.ContainsKey("vm-options"))
			{
				base.currentXmlElement.GetComponent<XmlLayoutDropdown>().optionsDataSource = attributesToApply["vm-options"];
			}
			if (attributesToApply.ContainsKey("vm-dataSource"))
			{
				HandleDataSourceAttribute(attributesToApply.GetValue("vm-dataSource"), attributesToApply.GetValue("vm-options"));
			}
		}

		public override void Close()
		{
			base.Close();
			CurrentDropdown.captionText.raycastTarget = false;
			CurrentDropdown.itemText.raycastTarget = false;
			CurrentDropdown.RefreshShownValue();
			CurrentHandler = null;
		}

		public string GetValue(XmlElement element)
		{
			TMP_Dropdown component = element.GetComponent<TMP_Dropdown>();
			return component.options[component.value].text;
		}

		public override void SetValue(string newValue, bool fireEventHandlers = true)
		{
			if (string.IsNullOrEmpty(newValue))
			{
				return;
			}
			TMP_Dropdown tMP_Dropdown = (TMP_Dropdown)primaryComponent;
			int result = -1;
			TMP_Dropdown.DropdownEvent onValueChanged = tMP_Dropdown.onValueChanged;
			if (!fireEventHandlers)
			{
				tMP_Dropdown.onValueChanged = new TMP_Dropdown.DropdownEvent();
			}
			if (int.TryParse(newValue, out result))
			{
				tMP_Dropdown.value = result;
				tMP_Dropdown.RefreshShownValue();
			}
			else
			{
				TMP_Dropdown.OptionData optionData = tMP_Dropdown.options.FirstOrDefault((TMP_Dropdown.OptionData o) => o.text.Equals(newValue, StringComparison.OrdinalIgnoreCase));
				if (optionData != null)
				{
					tMP_Dropdown.value = tMP_Dropdown.options.IndexOf(optionData);
					tMP_Dropdown.RefreshShownValue();
				}
			}
			if (!fireEventHandlers)
			{
				tMP_Dropdown.onValueChanged = onValueChanged;
			}
		}

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			if (eventName == "onvaluechanged")
			{
				TMP_Dropdown dropdown = (TMP_Dropdown)primaryComponent;
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

		public override void SetListData(IObservableList list)
		{
			List<string> list2 = (List<string>)list;
			if (list2 == null)
			{
				Debug.LogWarning("[XmlLayout][MVVM][Dropdown] Warning: list provided for options needs to be a list of of string values.");
			}
			TMP_Dropdown obj = (TMP_Dropdown)primaryComponent;
			obj.options = list2.Select((string s) => new TMP_Dropdown.OptionData(s)).ToList();
			obj.RefreshShownValue();
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
			TMP_Dropdown dropdown = (TMP_Dropdown)primaryComponent;
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
