using System;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class BorderAttribute : CustomXmlAttribute
	{
		public override string DefaultValue => "None";

		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "xmlLayout:color";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			Image image = null;
			Transform transform = xmlElement.transform.Find("_BorderImage_");
			if (transform == null)
			{
				GameObject obj = new GameObject("_BorderImage_")
				{
					layer = 5
				};
				image = obj.AddComponent<Image>();
				transform = obj.transform;
				transform.SetParent(xmlElement.transform, worldPositionStays: false);
				RectTransform component = transform.GetComponent<RectTransform>();
				component.anchoredPosition = Vector2.zero;
				component.anchorMin = Vector2.zero;
				component.anchorMax = Vector2.one;
				component.offsetMin = Vector2.zero;
				component.offsetMax = Vector2.zero;
				image.fillCenter = false;
				image.type = Image.Type.Sliced;
				image.raycastTarget = false;
				obj.AddComponent<LayoutElement>().ignoreLayout = true;
			}
			else
			{
				image = transform.GetComponent<Image>();
			}
			if (string.IsNullOrEmpty(value) || value.Equals("None", StringComparison.OrdinalIgnoreCase))
			{
				image.enabled = false;
				return;
			}
			image.enabled = true;
			Color color = value.ToColor(xmlElement.xmlLayoutInstance);
			image.color = color;
			if (elementAttributes.ContainsKey("borderSprite"))
			{
				image.sprite = elementAttributes["borderSprite"].ToSprite();
			}
			else
			{
				image.sprite = "Ui/Sprites/Border/Square-1px".ToSprite();
			}
			if (elementAttributes.ContainsKey("borderOffset"))
			{
				RectOffset rectOffset = elementAttributes["borderOffset"].ToRectOffset();
				RectTransform component2 = transform.GetComponent<RectTransform>();
				component2.offsetMin = new Vector2(rectOffset.left, rectOffset.bottom);
				component2.offsetMax = new Vector2(rectOffset.right, rectOffset.top);
			}
		}
	}
}
