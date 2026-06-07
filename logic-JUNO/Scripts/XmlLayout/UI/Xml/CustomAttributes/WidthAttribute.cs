using UnityEngine;

namespace UI.Xml.CustomAttributes
{
	public class WidthAttribute : SizeAttribute
	{
		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			RectTransform rectTransform = xmlElement.rectTransform;
			RectAlignment alignment = RectAlignment.MiddleCenter;
			if (xmlElement.HasAttribute("rectAlignment"))
			{
				alignment = GetRectAlignment(xmlElement.GetAttribute("rectAlignment"));
			}
			else if (elementAttributes.ContainsKey("rectAlignment"))
			{
				alignment = GetRectAlignment(elementAttributes.GetValue("rectAlignment"));
			}
			if (elementAttributes.ContainsKey("position"))
			{
				rectTransform.position = elementAttributes["position"].ToVector2();
			}
			Vector3 position = rectTransform.position;
			float num = float.Parse(value.Replace("%", string.Empty));
			float height = rectTransform.rect.height;
			if (value.Contains("%"))
			{
				rectTransform.sizeDelta = Vector2.zero;
				float num2 = num / 100f;
				Vector2 vector = ApplyAlignment(new Vector2(num2, 0f), alignment);
				rectTransform.anchorMin = new Vector2(vector.x, rectTransform.anchorMin.y);
				rectTransform.anchorMax = new Vector2(vector.x + num2, rectTransform.anchorMax.y);
			}
			else
			{
				RectAlignmentStruct alignmentStruct = GetAlignmentStruct(num, 0f, position, alignment);
				rectTransform.anchorMin = new Vector2(alignmentStruct.AnchorMin.x, rectTransform.anchorMin.y);
				rectTransform.anchorMax = new Vector2(alignmentStruct.AnchorMax.x, rectTransform.anchorMax.y);
				rectTransform.pivot = new Vector2(alignmentStruct.Pivot.x, rectTransform.pivot.y);
				rectTransform.sizeDelta = new Vector2(num, rectTransform.sizeDelta.y);
			}
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		}
	}
}
