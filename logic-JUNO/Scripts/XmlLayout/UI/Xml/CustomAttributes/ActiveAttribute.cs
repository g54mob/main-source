namespace UI.Xml.CustomAttributes
{
	public class ActiveAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override string ValueDataType => "xs:boolean";

		public override string DefaultValue => "true";

		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary elementAttributes)
		{
			bool active = value.ToBoolean();
			xmlElement.gameObject.SetActive(active);
		}
	}
}
