namespace UI.Xml.CustomAttributes
{
	public class AllowDraggingAttribute : CustomXmlAttribute
	{
		public override bool UsesConvertMethod => true;

		public override bool KeepOriginalTag => true;

		public override eAttributeGroup AttributeGroup => eAttributeGroup.Dragging;

		public override AttributeDictionary Convert(string value, AttributeDictionary attributes, XmlElement xmlElement)
		{
			AttributeDictionary attributeDictionary = new AttributeDictionary();
			if (value.ToBoolean() && !attributes.ContainsKey("raycastTarget"))
			{
				attributeDictionary.Add("raycastTarget", "true");
			}
			return attributeDictionary;
		}
	}
}
