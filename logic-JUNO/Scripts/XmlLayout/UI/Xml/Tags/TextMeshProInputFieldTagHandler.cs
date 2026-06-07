using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class TextMeshProInputFieldTagHandler : ElementTagHandler, IHasXmlFormValue
	{
		private List<string> _eventAttributeNames = new List<string> { "onClick", "onMouseEnter", "onMouseExit", "onValueChanged", "onEndEdit", "onSubmit", "onMouseUp", "onMouseDown" };

		public override bool isCustomElement => true;

		public override string prefabPath => null;

		public override MonoBehaviour primaryComponent => base.currentXmlElement.GetComponent<TMP_InputField>();

		public override RectTransform transformToAddChildrenTo
		{
			get
			{
				RectTransform rectTransform = base.currentInstanceTransform.Find("Text Area") as RectTransform;
				if (rectTransform == null)
				{
					rectTransform = CreateTextArea();
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
			base.currentInstanceTransform.name = "TextMeshPro - Input Field";
		}

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			if (base.currentInstanceTransform.GetComponent<Image>() == null)
			{
				CreateBackgroundImage();
			}
			RectTransform rectTransform = base.currentInstanceTransform.Find("Text Area") as RectTransform;
			if (rectTransform == null)
			{
				rectTransform = CreateTextArea();
			}
			if (attributesToApply.ContainsKey("padding"))
			{
				Vector4 vector = attributesToApply["padding"].ToVector4();
				rectTransform.offsetMin = new Vector2(vector.x, vector.w);
				rectTransform.offsetMax = new Vector2(0f - vector.y, 0f - vector.z);
			}
			RectTransform rectTransform2 = rectTransform.Find("Placeholder") as RectTransform;
			if (rectTransform2 == null)
			{
				rectTransform2 = CreatePlaceholder(rectTransform);
			}
			RectTransform rectTransform3 = rectTransform.Find("Text") as RectTransform;
			if (rectTransform3 == null)
			{
				rectTransform3 = CreateText(rectTransform);
			}
			TMP_InputField tMP_InputField = base.currentInstanceTransform.GetComponent<TMP_InputField>();
			if (tMP_InputField == null)
			{
				tMP_InputField = CreateTMPInputField();
			}
			TextMeshProUGUI component = rectTransform3.GetComponent<TextMeshProUGUI>();
			tMP_InputField.textViewport = rectTransform;
			tMP_InputField.textComponent = component;
			tMP_InputField.placeholder = rectTransform2.GetComponent<TextMeshProUGUI>();
			if (Application.isPlaying)
			{
				tMP_InputField.SendMessage("OnEnable", SendMessageOptions.DontRequireReceiver);
			}
			if (base.currentInstanceTransform.GetComponent<LayoutElement>() == null)
			{
				base.currentInstanceTransform.gameObject.AddComponent<LayoutElement>();
			}
			base.ApplyAttributes(attributesToApply);
			if (component.GetComponent<XmlElement>() == null)
			{
				component.gameObject.AddComponent<XmlElement>();
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
			return base.currentInstanceTransform.gameObject.AddComponent<TMP_InputField>();
		}

		private RectTransform CreateTextArea()
		{
			GameObject gameObject = new GameObject("Text Area", typeof(RectTransform));
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.SetParent(base.currentInstanceTransform);
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.offsetMin = new Vector2(10f, 6f);
			component.offsetMax = new Vector2(-10f, -7f);
			component.localScale = Vector3.one;
			gameObject.AddComponent<RectMask2D>();
			gameObject.layer = ElementTagHandler.uiLayer;
			return component;
		}

		private RectTransform CreatePlaceholder(RectTransform textArea)
		{
			GameObject gameObject = new GameObject("Placeholder", typeof(RectTransform));
			TextMeshProUGUI textMeshProUGUI = gameObject.AddComponent<TextMeshProUGUI>();
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.SetParent(textArea);
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.offsetMin = Vector2.zero;
			component.offsetMax = Vector2.one;
			component.localScale = Vector3.one;
			textMeshProUGUI.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
			textMeshProUGUI.text = "Enter text...";
			textMeshProUGUI.fontStyle = FontStyles.Italic;
			textMeshProUGUI.fontSize = 14f;
			textMeshProUGUI.alignment = TextAlignmentOptions.TopLeft;
			textMeshProUGUI.raycastTarget = false;
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
