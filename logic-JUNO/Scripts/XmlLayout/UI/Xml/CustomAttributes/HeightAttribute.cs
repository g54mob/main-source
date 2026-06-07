using UnityEngine;

namespace UI.Xml.CustomAttributes
{
	public class HeightAttribute : SizeAttribute
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
			float width = rectTransform.rect.width;
			if (value.Contains("%"))
			{
				rectTransform.sizeDelta = Vector2.zero;
				float num2 = num / 100f;
				Vector2 vector = ApplyAlignment(new Vector2(0f, num2), alignment);
				rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, vector.y);
				rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, vector.y + num2);
			}
			else
			{
				RectAlignmentStruct alignmentStruct = GetAlignmentStruct(0f, num, position, alignment);
				rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, alignmentStruct.AnchorMin.y);
				rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, alignmentStruct.AnchorMax.y);
				rectTransform.pivot = new Vector2(rectTransform.pivot.x, alignmentStruct.Pivot.y);
				rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, num);
			}
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
		}
	}
}
