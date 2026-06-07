using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml.CustomAttributes
{
	public class SetNativeSizeAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "xs:boolean";

		public override string DefaultValue => "false";

		public override eAttributeGroup AttributeGroup => eAttributeGroup.Image;

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			if (!Application.isPlaying)
			{
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					Rect rect = xmlElement.GetComponent<Image>().sprite.rect;
					xmlElement.SetAttribute("width", rect.width.ToString());
					xmlElement.SetAttribute("height", rect.height.ToString());
					xmlElement.ApplyAttributes();
				}, xmlElement);
				return;
			}
			xmlElement.ExecuteNowOrWhenElementIsEnabled(delegate
			{
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					if (!(xmlElement == null))
					{
						Rect rect = xmlElement.GetComponent<Image>().sprite.rect;
						xmlElement.SetAttribute("width", rect.width.ToString());
						xmlElement.SetAttribute("height", rect.height.ToString());
						xmlElement.ApplyAttributes();
					}
				}, null, forceEvenIfObjectIsInactive: true);
			});
		}
	}
}
