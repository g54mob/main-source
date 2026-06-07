using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public abstract class ScrollViewTagHandler : ElementTagHandler
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
				return base.currentInstanceTransform.GetComponent<ScrollRect>();
			}
		}

		public override RectTransform transformToAddChildrenTo
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return ((ScrollRect)primaryComponent).content;
			}
		}

		protected override List<string> eventAttributeNames => _eventAttributeNames;

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			base.ApplyAttributes(attributesToApply);
			ScrollRect scrollRect = (ScrollRect)primaryComponent;
			if (attributesToApply.ContainsKey("noscrollbars") && attributesToApply["noscrollbars"].ToBoolean())
			{
				if (scrollRect.verticalScrollbar != null)
				{
					Destroy(scrollRect.verticalScrollbar.gameObject);
					scrollRect.verticalScrollbar = null;
				}
				if (scrollRect.horizontalScrollbar != null)
				{
					Destroy(scrollRect.horizontalScrollbar.gameObject);
					scrollRect.horizontalScrollbar = null;
				}
				scrollRect.viewport.offsetMax = default(Vector2);
				scrollRect.viewport.offsetMin = default(Vector2);
			}
			bool flag = scrollRect.verticalScrollbar != null;
			bool flag2 = scrollRect.horizontalScrollbar != null;
			if (attributesToApply.ContainsKey("scrollbarbackgroundcolor"))
			{
				Color color = attributesToApply["scrollbarbackgroundcolor"].ToColor(base.currentXmlLayoutInstance);
				if (flag)
				{
					scrollRect.verticalScrollbar.GetComponent<Image>().color = color;
				}
				if (flag2)
				{
					scrollRect.horizontalScrollbar.GetComponent<Image>().color = color;
				}
			}
			if (attributesToApply.ContainsKey("scrollbarbackgroundimage"))
			{
				Sprite sprite = attributesToApply["scrollbarbackgroundimage"].ToSprite();
				if (flag)
				{
					scrollRect.verticalScrollbar.GetComponent<Image>().sprite = sprite;
				}
				if (flag2)
				{
					scrollRect.horizontalScrollbar.GetComponent<Image>().sprite = sprite;
				}
			}
			if (attributesToApply.ContainsKey("scrollbarcolors"))
			{
				ColorBlock colors = attributesToApply["scrollbarcolors"].ToColorBlock(base.currentXmlLayoutInstance);
				if (flag)
				{
					scrollRect.verticalScrollbar.colors = colors;
				}
				if (flag2)
				{
					scrollRect.horizontalScrollbar.colors = colors;
				}
			}
			if (attributesToApply.ContainsKey("scrollbarimage"))
			{
				Sprite sprite2 = attributesToApply["scrollbarimage"].ToSprite();
				if (flag)
				{
					scrollRect.verticalScrollbar.image.sprite = sprite2;
				}
				if (flag2)
				{
					scrollRect.horizontalScrollbar.image.sprite = sprite2;
				}
			}
			if (attributesToApply.ContainsKey("verticalscrollbarwidth") && flag)
			{
				float num = float.Parse(attributesToApply["verticalscrollbarwidth"]);
				(scrollRect.viewport.transform as RectTransform).offsetMax = new Vector2(0f - num, 0f);
				(scrollRect.verticalScrollbar.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
			}
			if (attributesToApply.ContainsKey("horizontalscrollbarheight") && flag2)
			{
				float num2 = float.Parse(attributesToApply["horizontalscrollbarheight"]);
				(scrollRect.viewport.transform as RectTransform).offsetMin = new Vector2(0f, num2);
				(scrollRect.horizontalScrollbar.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2);
			}
			if (attributesToApply.ContainsKey("maskimage"))
			{
				Image component = scrollRect.viewport.GetComponent<Image>();
				string text = attributesToApply["maskimage"];
				if (!string.IsNullOrEmpty(text))
				{
					component.sprite = text.ToSprite();
				}
				else
				{
					component.sprite = null;
				}
			}
		}

		private void Destroy(Object o)
		{
			if (Application.isPlaying)
			{
				Object.Destroy(o);
			}
			else
			{
				Object.DestroyImmediate(o);
			}
		}

		public override void Close()
		{
			base.Close();
			ScrollRect scrollRect = (ScrollRect)primaryComponent;
			RectTransform content = scrollRect.content;
			XmlLayoutTimer.DelayedCall(0.05f, delegate
			{
				content.GetComponent<SimpleContentSizeFitter>().MatchChildDimensions();
			}, scrollRect);
		}

		protected override void HandleEventAttribute(string eventName, string eventValue)
		{
			if (eventName == "onvaluechanged")
			{
				ScrollRect obj = (ScrollRect)primaryComponent;
				RectTransform transform = base.currentInstanceTransform;
				EventData eventData = GetEventValueData(eventValue);
				obj.onValueChanged.AddListener(delegate(Vector2 e)
				{
					string value = eventData.value;
					switch (eventData.value.ToLower())
					{
					case "selectedvalue":
					case "xy":
						value = $"{e.x},{e.y}";
						break;
					case "x":
						value = e.x.ToString();
						break;
					case "y":
						value = e.y.ToString();
						break;
					}
					base.currentXmlLayoutInstance.XmlLayoutController.ReceiveMessage(eventData.methodName, value, transform);
				});
			}
			else
			{
				base.HandleEventAttribute(eventName, eventValue);
			}
		}
	}
}
