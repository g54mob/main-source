using UnityEngine;

namespace UI.Xml.CustomAttributes
{
	public class OffsetXYAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override eAttributeGroup AttributeGroup => eAttributeGroup.RectPosition;

		public override string ValueDataType => "vector2";

		public override string DefaultValue => "0 0";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			Vector2 currentOffset = value.ToVector2();
			RectTransform rectTransform = xmlElement.rectTransform;
			if (xmlElement.GetComponent<XmlLayout>() == null)
			{
				Vector2 currentOffset2 = xmlElement.currentOffset;
				xmlElement.currentOffset = currentOffset;
				if (currentOffset2 != Vector2.zero)
				{
					currentOffset -= currentOffset2;
				}
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + currentOffset.x, rectTransform.anchoredPosition.y + currentOffset.y);
			}
			else
			{
				Debug.LogWarning("[XmlLayout][Warning] The 'offsetXY' attribute is currently not supported for <XmlLayout> elements.");
			}
		}
	}
}
