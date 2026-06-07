namespace UI.Xml.CustomAttributes
{
	public class ScaleAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override eAttributeGroup AttributeGroup => eAttributeGroup.RectTransform;

		public override string DefaultValue => "1 1 1";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary attributes)
		{
			xmlElement.rectTransform.localScale = value.ToVector3();
		}
	}
}
