using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	public class XmlLayoutTooltip : MonoBehaviour
	{
		public enum TooltipPosition
		{
			Above = 0,
			Below = 1,
			Left = 2,
			Right = 3
		}

		public Text TextComponent;

		public Outline OutlineComponent;

		public Image BackgroundComponent;

		public Image BorderComponent;

		protected RectTransform m_rectTransform;

		protected Canvas m_canvas;

		public TooltipPosition tooltipPosition = TooltipPosition.Right;

		public float offsetDistance = 8f;

		public bool followMouse;

		public float fadeTime = 0.2f;

		public float showDelayTime = 0.1f;

		public float width;

		public TextComponentWrapper TextComponentWrapper;

		private bool started;

		private ContentSizeFitter contentSizeFitter;

		private XmlLayout _xmlLayout;

		private CanvasGroup _canvasGroup;

		private GameObject _targetGameObject;

		protected RectTransform rectTransform
		{
			get
			{
				if (m_rectTransform == null)
				{
					m_rectTransform = base.transform as RectTransform;
				}
				return m_rectTransform;
			}
		}

		protected Canvas canvas
		{
			get
			{
				if (m_canvas == null)
				{
					m_canvas = GetComponentInParent<Canvas>();
				}
				return m_canvas;
			}
		}

		private XmlLayout xmlLayout
		{
			get
			{
				if (_xmlLayout == null)
				{
					_xmlLayout = GetComponentInParent<XmlLayout>();
				}
				return _xmlLayout;
			}
		}

		private CanvasGroup canvasGroup
		{
			get
			{
				if (_canvasGroup == null)
				{
					_canvasGroup = GetComponent<CanvasGroup>();
				}
				return _canvasGroup;
			}
		}

		private void Update()
		{
			base.transform.SetAsLastSibling();
			if (followMouse)
			{
				SetPositionAdjacentToCursor();
			}
			if (_targetGameObject == null || !_targetGameObject.activeInHierarchy)
			{
				_targetGameObject = null;
				FadeOut();
			}
		}

		private void Awake()
		{
			canvasGroup.alpha = 0f;
			showDelayTime = (Application.isMobilePlatform ? 1f : 0.5f);
		}

		private void Start()
		{
			if (!started)
			{
				TextComponentWrapper = new TextComponentWrapper(TextComponent);
				TextComponentWrapper.xmlElement.Initialise(xmlLayout, TextComponentWrapper.xmlElement.rectTransform, XmlLayoutUtilities.GetXmlTagHandler("Text"));
				contentSizeFitter = GetComponent<ContentSizeFitter>();
				started = true;
				Graphic[] componentsInChildren = base.gameObject.GetComponentsInChildren<Graphic>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].raycastTarget = false;
				}
			}
		}

		public void SetText(string text)
		{
			TextComponentWrapper.text = text;
			TextMeshProUGUI componentInChildren = GetComponentInChildren<TextMeshProUGUI>();
			componentInChildren?.ForceMeshUpdate();
			if ((float)(int)componentInChildren.preferredWidth > width)
			{
				contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
				rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
				TextComponentWrapper.text = text;
			}
			else
			{
				contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
				TextComponentWrapper.text = text;
			}
		}

		public void SetTextColor(Color color)
		{
			TextComponentWrapper.color = color;
		}

		public void SetBackgroundColor(Color color)
		{
			BackgroundComponent.color = color;
		}

		public void SetBackgroundImage(Sprite image)
		{
			BackgroundComponent.sprite = image;
		}

		public void SetBorderColor(Color color)
		{
			BorderComponent.color = color;
		}

		public void SetBorderImage(Sprite image)
		{
			BorderComponent.sprite = image;
		}

		public void SetFontSize(int size)
		{
			TextComponentWrapper.xmlElement.SetAndApplyAttribute("fontSize", size.ToString());
		}

		[Obsolete("Please use SetFont(string) instead")]
		public void SetFont(Font font)
		{
			TextComponent.font = font;
		}

		public void SetFont(string font)
		{
			TextComponentWrapper.xmlElement.SetAndApplyAttribute("font", font);
		}

		public void SetTooltipPadding(RectOffset padding)
		{
			BackgroundComponent.GetComponent<HorizontalOrVerticalLayoutGroup>().padding = padding;
		}

		public void SetTextOutlineColor(Color color)
		{
			if (color == default(Color))
			{
				OutlineComponent.enabled = false;
				return;
			}
			OutlineComponent.enabled = true;
			OutlineComponent.effectColor = color;
		}

		public void SetStylesFromXmlElement(XmlElement element)
		{
			LoadAttributes(element.attributes);
		}

		public void SetPositionAdjacentTo(XmlElement element)
		{
			if (!(element == null))
			{
				_targetGameObject = element.gameObject;
				RectTransform rectTransform = xmlLayout.transform as RectTransform;
				this.rectTransform.pivot = GetPivotForPosition(tooltipPosition);
				Vector2 vector = new Vector2(1f - this.rectTransform.pivot.x, 1f - this.rectTransform.pivot.y);
				Vector2 size = element.rectTransform.rect.size;
				Vector3 vector2 = xmlLayout.transform.InverseTransformPoint(element.rectTransform.position);
				vector2 -= new Vector3(rectTransform.rect.width * (0.5f - rectTransform.pivot.x), rectTransform.rect.height * (0.5f - rectTransform.pivot.y), 0f);
				this.rectTransform.anchoredPosition3D = new Vector3(vector2.x + (vector.x - element.rectTransform.pivot.x) * size.x, vector2.y + (vector.y - element.rectTransform.pivot.y) * size.y, 0f);
				switch (tooltipPosition)
				{
				case TooltipPosition.Right:
					this.rectTransform.anchoredPosition3D += new Vector3(offsetDistance, 0f, 0f);
					break;
				case TooltipPosition.Left:
					this.rectTransform.anchoredPosition3D += new Vector3(0f - offsetDistance, 0f, 0f);
					break;
				case TooltipPosition.Above:
					this.rectTransform.anchoredPosition3D += new Vector3(0f, offsetDistance, 0f);
					break;
				case TooltipPosition.Below:
					this.rectTransform.anchoredPosition3D += new Vector3(0f, 0f - offsetDistance, 0f);
					break;
				}
				this.rectTransform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				ClampWithinCanvas();
			}
		}

		public void SetPositionAdjacentToCursor()
		{
			rectTransform.pivot = GetPivotForPosition(tooltipPosition);
			if (canvas.renderMode == RenderMode.WorldSpace)
			{
				Vector2 localPoint = Vector2.zero;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, Camera.main, out localPoint);
				rectTransform.position = canvas.transform.TransformPoint(localPoint);
			}
			else
			{
				rectTransform.position = Input.mousePosition;
			}
			rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y, 0f);
			rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition3D.x, rectTransform.anchoredPosition3D.y, 0f);
			Vector2 vector = default(Vector2);
			switch (tooltipPosition)
			{
			case TooltipPosition.Above:
				vector.y = offsetDistance;
				break;
			case TooltipPosition.Below:
				vector.y = 0f - offsetDistance - rectTransform.rect.height;
				break;
			case TooltipPosition.Left:
				vector.x = 0f - offsetDistance;
				break;
			case TooltipPosition.Right:
				vector.x = offsetDistance;
				break;
			}
			if (canvas.renderMode == RenderMode.WorldSpace)
			{
				Vector2 vector2 = canvas.transform.localScale;
				vector = new Vector2(vector2.x * vector.x, vector2.y * vector.y);
			}
			rectTransform.position += (Vector3)vector;
			ClampWithinCanvas();
		}

		protected void ClampWithinCanvas()
		{
			Rect rect = (canvas.transform as RectTransform).rect;
			Vector2 vector = rect.min - rectTransform.rect.min;
			Vector2 vector2 = rect.max - rectTransform.rect.max;
			Vector3 vector3 = new Vector3
			{
				x = Mathf.Clamp(rectTransform.anchoredPosition.x, vector.x, vector2.x),
				y = Mathf.Clamp(rectTransform.anchoredPosition.y, vector.y, vector2.y)
			};
			rectTransform.anchoredPosition = vector3;
			rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition3D.x, rectTransform.anchoredPosition3D.y, 0f);
		}

		protected Vector2 GetPivotForPosition(TooltipPosition position)
		{
			Vector2 result = new Vector2(0.5f, 0.5f);
			switch (position)
			{
			case TooltipPosition.Above:
				result = new Vector2(0.5f, 0f);
				break;
			case TooltipPosition.Below:
				result = new Vector2(0.5f, 1f);
				break;
			case TooltipPosition.Left:
				result = new Vector2(1f, 0.5f);
				break;
			case TooltipPosition.Right:
				result = new Vector2(0f, 0.5f);
				break;
			}
			return result;
		}

		public void ToggleTextMeshPro(bool on)
		{
			if (on)
			{
				if (TextComponentWrapper == null || !(TextComponentWrapper.xmlElement != null) || !(TextComponentWrapper.xmlElement.tagType == "TextMeshPro"))
				{
					TextMeshProUGUI textMeshProUGUI = base.gameObject.GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
					XmlElement xmlElement = null;
					if (textMeshProUGUI == null)
					{
						ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("TextMeshPro");
						xmlElement = xmlTagHandler.GetInstance(rectTransform, xmlLayout);
						xmlTagHandler.SetInstance(xmlElement);
						xmlTagHandler.ApplyAttributes(new AttributeDictionary());
						textMeshProUGUI = xmlElement.GetComponent<TextMeshProUGUI>();
						textMeshProUGUI.raycastTarget = false;
						textMeshProUGUI.enableWordWrapping = true;
						textMeshProUGUI.rectTransform.localScale = Vector3.one;
					}
					xmlElement = textMeshProUGUI.GetComponent<XmlElement>();
					TextComponentWrapper = new TextComponentWrapper(textMeshProUGUI);
					TextComponent.gameObject.SetActive(value: false);
					textMeshProUGUI.gameObject.SetActive(value: true);
				}
			}
			else if (TextComponentWrapper == null || !(TextComponentWrapper.xmlElement != null) || !(TextComponentWrapper.xmlElement.tagType == "Text"))
			{
				TextComponentWrapper = new TextComponentWrapper(TextComponent);
				TextComponent.gameObject.SetActive(value: true);
				TextMeshProUGUI componentInChildren = base.gameObject.GetComponentInChildren<TextMeshProUGUI>();
				if (componentInChildren != null)
				{
					componentInChildren.gameObject.SetActive(value: false);
				}
			}
		}

		public void LoadAttributes(AttributeDictionary attributes)
		{
			if (!started)
			{
				Start();
			}
			if (attributes.ContainsKey("tooltipUseTextMeshPro"))
			{
				ToggleTextMeshPro(attributes["tooltipUseTextMeshPro"].ToBoolean());
			}
			if (attributes.ContainsKey("tooltipTextColor"))
			{
				SetTextColor(attributes["tooltipTextColor"].ToColor(xmlLayout));
			}
			if (attributes.ContainsKey("tooltipBackgroundColor"))
			{
				SetBackgroundColor(attributes["tooltipBackgroundColor"].ToColor(xmlLayout));
			}
			if (attributes.ContainsKey("tooltipBorderColor"))
			{
				SetBorderColor(attributes["tooltipBorderColor"].ToColor(xmlLayout));
			}
			if (attributes.ContainsKey("tooltipBackgroundImage"))
			{
				SetBackgroundImage(attributes["tooltipBackgroundImage"].ToSprite());
			}
			if (attributes.ContainsKey("tooltipBorderImage"))
			{
				SetBorderImage(attributes["tooltipBorderImage"].ToSprite());
			}
			if (attributes.ContainsKey("tooltipFontSize"))
			{
				SetFontSize(int.Parse(attributes["tooltipfontsize"]));
			}
			if (attributes.ContainsKey("tooltipPadding"))
			{
				SetTooltipPadding(attributes["tooltipPadding"].ToRectOffset());
			}
			if (attributes.ContainsKey("tooltipTextOutlineColor"))
			{
				SetTextOutlineColor(attributes["tooltipTextOutlineColor"].ToColor(xmlLayout));
			}
			if (attributes.ContainsKey("tooltipFont"))
			{
				SetFont(attributes["tooltipFont"]);
			}
			if (attributes.ContainsKey("tooltipPosition"))
			{
				tooltipPosition = (TooltipPosition)Enum.Parse(typeof(TooltipPosition), attributes["tooltipPosition"]);
			}
			if (attributes.ContainsKey("tooltipFollowMouse"))
			{
				followMouse = attributes["tooltipFollowMouse"].ToBoolean();
			}
			if (attributes.ContainsKey("tooltipOffset"))
			{
				offsetDistance = float.Parse(attributes["tooltipOffset"]);
			}
			if (attributes.ContainsKey("tooltipFadeTime"))
			{
				fadeTime = attributes["tooltipFadeTime"].ToFloat();
			}
			if (attributes.ContainsKey("tooltipDelayTime"))
			{
				showDelayTime = attributes["tooltipDelayTime"].ToFloat();
			}
			if (attributes.ContainsKey("tooltipWidth"))
			{
				width = attributes["tooltipWidth"].ToFloat();
			}
			else
			{
				width = 0f;
			}
		}

		public void FadeIn()
		{
			StopAllCoroutines();
			base.gameObject.SetActive(value: true);
			float num = fadeTime * (1f - canvasGroup.alpha);
			if (num > 0f)
			{
				StartCoroutine(FadeInCoroutine(num));
			}
			else
			{
				canvasGroup.alpha = 1f;
			}
		}

		private IEnumerator FadeInCoroutine(float fadeInTime)
		{
			float startTime = Time.unscaledTime;
			float endTime = startTime + fadeInTime;
			float startAlpha = canvasGroup.alpha;
			while (Time.unscaledTime <= endTime)
			{
				float t = (Time.unscaledTime - startTime) / fadeInTime;
				canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, t);
				yield return null;
			}
			canvasGroup.alpha = 1f;
		}

		public void FadeOut()
		{
			float num = fadeTime * canvasGroup.alpha;
			if (num > 0f)
			{
				if (base.gameObject.activeInHierarchy)
				{
					StartCoroutine(FadeOutCoroutine(num));
				}
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private IEnumerator FadeOutCoroutine(float fadeOutTime)
		{
			float startTime = Time.unscaledTime;
			float endTime = startTime + fadeOutTime;
			float startAlpha = canvasGroup.alpha;
			while (Time.unscaledTime <= endTime)
			{
				float t = (Time.unscaledTime - startTime) / fadeOutTime;
				canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, t);
				yield return null;
			}
			canvasGroup.alpha = 0f;
			base.gameObject.SetActive(value: false);
		}
	}
}
