using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class ShadowAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "color";

		public override string DefaultValue => "None";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			RectTransform rectTransform = xmlElement.rectTransform;
			if (value.Equals("None", StringComparison.OrdinalIgnoreCase))
			{
				Shadow shadowComponent = GetShadowComponent(rectTransform);
				if (shadowComponent != null)
				{
					shadowComponent.enabled = false;
				}
			}
			else if (elementAttributes.ContainsKey("shadow"))
			{
				Color effectColor = elementAttributes["shadow"].ToColor(xmlElement.xmlLayoutInstance);
				Shadow shadow = GetShadowComponent(rectTransform);
				if (shadow == null)
				{
					shadow = rectTransform.gameObject.AddComponent<Shadow>();
				}
				shadow.enabled = true;
				shadow.effectColor = effectColor;
				if (elementAttributes.ContainsKey("shadowdistance"))
				{
					shadow.effectDistance = elementAttributes["shadowdistance"].ToVector2();
				}
			}
		}

		private Shadow GetShadowComponent(Transform transform)
		{
			Outline outline = transform.GetComponent<Outline>();
			if (outline == null)
			{
				return transform.GetComponent<Shadow>();
			}
			return transform.GetComponents<Shadow>().FirstOrDefault((Shadow t) => t.GetInstanceID() != outline.GetInstanceID());
		}
	}
}
