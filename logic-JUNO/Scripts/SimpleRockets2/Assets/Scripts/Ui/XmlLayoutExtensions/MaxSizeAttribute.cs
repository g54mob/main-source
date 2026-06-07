using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.XmlLayoutExtensions
{
	public class MaxSizeAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "xs:string";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			Vector2 maxSize = value.ToVector2();
			if (!(maxSize.x > 0f) && !(maxSize.y > 0f))
			{
				return;
			}
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				RectTransform rectTransform = xmlElement.rectTransform;
				Vector2 size = rectTransform.rect.size;
				bool flag = false;
				if (maxSize.x > 0f && size.x > maxSize.x)
				{
					rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxSize.x);
					flag = true;
				}
				if (maxSize.y > 0f && size.y > maxSize.y)
				{
					rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, maxSize.y);
					flag = true;
				}
				if (flag)
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
				}
			}, xmlElement);
		}
	}
}
