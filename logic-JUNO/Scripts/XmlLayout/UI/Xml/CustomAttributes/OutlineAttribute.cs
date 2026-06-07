using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class OutlineAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "color";

		public override string DefaultValue => "None";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			RectTransform rectTransform = xmlElement.rectTransform;
			if (value.Equals("None", StringComparison.OrdinalIgnoreCase))
			{
				Outline component = rectTransform.GetComponent<Outline>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			else if (elementAttributes.ContainsKey("outline"))
			{
				Color effectColor = elementAttributes["outline"].ToColor(xmlElement.xmlLayoutInstance);
				Outline outline = rectTransform.GetComponent<Outline>();
				if (outline == null)
				{
					outline = rectTransform.gameObject.AddComponent<Outline>();
				}
				outline.enabled = true;
				outline.effectColor = effectColor;
				if (elementAttributes.ContainsKey("outlinesize"))
				{
					outline.effectDistance = elementAttributes["outlinesize"].ToVector2();
				}
			}
		}
	}
}
