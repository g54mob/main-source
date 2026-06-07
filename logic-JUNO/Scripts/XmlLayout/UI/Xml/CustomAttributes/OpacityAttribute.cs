namespace UI.Xml.CustomAttributes
{
	public class OpacityAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "xs:float";

		public override string DefaultValue => "1";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			float alpha = (xmlElement.DefaultOpacity = float.Parse(value));
			xmlElement.CanvasGroup.alpha = alpha;
		}
	}
}
