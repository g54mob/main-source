using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class PartPropertySpinnerInputFieldTagHandler : ElementTagHandler, IHasXmlFormValue
	{
		private List<string> _eventAttributeNames = new List<string> { "onClick", "onMouseEnter", "onMouseExit", "onValueChanged", "onEndEdit", "onSubmit", "onMouseUp", "onMouseDown" };

		public override bool isCustomElement => true;

		public override string prefabPath => null;

		public override MonoBehaviour primaryComponent => base.currentXmlElement.GetComponent<TMP_InputField>();

		public override RectTransform transformToAddChildrenTo
		{
			get
			{
				RectTransform rectTransform = base.currentInstanceTransform.Find("TMP_PartPropertySpinnerInputField") as RectTransform;
				if (rectTransform == null)
				{
					rectTransform = CreateTMPInputField().GetComponent<RectTransform>();
				}
				return rectTransform;
			}
		}

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "interactable", "xs:boolean" },
			{ "colors", "xmlLayout:colorblock" },
			{ "text", "xs:string" },
			{ "characterLimit", "xs:int" },
			{ "contentType", "Standard,Autocorrected,IntegerNumber,DecimalNumber,Alphanumeric,Name,EmailAddress,Password,Pin,Custom" },
			{ "lineType", "SingleLine,MultiLineSubmit,MultiLineNewline" },
			{ "caretBlinkRate", "xs:float" },
			{ "caretWidth", "xs:float" },
			{ "customCaretColor", "xs:boolean" },
			{ "selectionColor", "xmlLayout:color" },
			{ "onFocusSelectAll", "xs:boolean" },
			{ "resetOnDeactivation", "xs:boolean" },
			{ "restoreOnESCKey", "xs:boolean" },
			{ "readOnly", "xs:boolean" },
			{ "richText", "xs:boolean" },
			{ "allowRichTextEditing", "xs:boolean" },
			{ "onValueChanged", "xmlLayout:function" },
			{ "onEndEdit", "xmlLayout:function" },
			{ "onSelect", "xmlLayout:function" },
			{ "onDeselect", "xmlLayout:function" },
			{ "padding", "xmlLayout:vector4" }
		};

		public override List<string> attributeGroups => new List<string> { "image" };

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override string elementChildType => "TextMeshProInputField";

		public override void Open(AttributeDictionary elementAttributes)
		{
			base.Open(elementAttributes);
			base.currentInstanceTransform.name = "TMP_PartPropertySpinnerInputField";
		}

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			if (base.currentInstanceTransform.GetComponent<Image>() == null)
			{
				CreateBackgroundImage();
			}
			TMP_InputField tMP_InputField = base.currentInstanceTransform.GetComponent<TMP_InputField>();
			if (tMP_InputField == null)
			{
				tMP_InputField = CreateTMPInputField();
			}
			RectTransform component = tMP_InputField.GetComponent<RectTransform>();
			RectTransform rectTransform = component.Find("Text") as RectTransform;
			if (rectTransform == null)
			{
				rectTransform = CreateText(component);
			}
			TextMeshProUGUI component2 = rectTransform.GetComponent<TextMeshProUGUI>();
			tMP_InputField.textViewport = component;
			tMP_InputField.textComponent = component2;
			if (Application.isPlaying)
			{
				tMP_InputField.SendMessage("OnEnable", SendMessageOptions.DontRequireReceiver);
			}
			if (base.currentInstanceTransform.GetComponent<LayoutElement>() == null)
			{
				base.currentInstanceTransform.gameObject.AddComponent<LayoutElement>();
			}
			base.ApplyAttributes(attributesToApply);
			if (component2.GetComponent<XmlElement>() == null)
			{
				component2.gameObject.AddComponent<XmlElement>();
			}
		}

		private Image CreateBackgroundImage()
		{
			Image image = base.currentInstanceTransform.gameObject.AddComponent<Image>();
			image.color = Color.white;
			image.sprite = XmlLayoutUtilities.LoadResource<Sprite>("Sprites/Elements/UISprite_XmlLayout");
			image.type = Image.Type.Sliced;
			return image;
		}

		private TMP_InputField CreateTMPInputField()
		{
			TMP_InputField tMP_InputField = base.currentInstanceTransform.gameObject.AddComponent<TMP_InputField>();
			tMP_InputField.name = "TMP_PartPropertySpinnerInputField";
			RectTransform component = tMP_InputField.GetComponent<RectTransform>();
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			return tMP_InputField;
		}

		private RectTransform CreateTextArea()
		{
			GameObject gameObject = new GameObject("Text Area", typeof(RectTransform));
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.SetParent(base.currentInstanceTransform);
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.offsetMin = Vector2.zero;
			component.offsetMax = Vector2.zero;
			component.localScale = Vector3.one;
			gameObject.layer = ElementTagHandler.uiLayer;
			return component;
		}

		private RectTransform CreateText(RectTransform textArea)
		{
			GameObject gameObject = new GameObject("Text", typeof(RectTransform));
			TextMeshProUGUI textMeshProUGUI = gameObject.AddComponent<TextMeshProUGUI>();
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.SetParent(textArea);
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.offsetMin = Vector2.zero;
			component.offsetMax = Vector2.one;
			component.localScale = Vector3.one;
			textMeshProUGUI.color = new Color(0.2f, 0.2f, 0.2f);
			textMeshProUGUI.fontSize = 14f;
			textMeshProUGUI.alignment = TextAlignmentOptions.TopLeft;
			textMeshProUGUI.raycastTarget = false;
			gameObject.layer = ElementTagHandler.uiLayer;
			return component;
		}

		public string GetValue(XmlElement element)
		{
			return element.GetComponent<TMP_InputField>().text;
		}

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			switch (eventName)
			{
			case "onvaluechanged":
			case "onendedit":
			case "onsubmit":
			{
				TMP_InputField inputField = (TMP_InputField)primaryComponent;
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
	}
}
