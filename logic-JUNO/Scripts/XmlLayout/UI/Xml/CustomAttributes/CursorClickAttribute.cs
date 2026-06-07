namespace UI.Xml.CustomAttributes
{
	public class CursorClickAttribute : CursorAttribute
	{
		public override void Apply(XmlElement xmlElement, string value, AttributeDictionary attributes)
		{
			xmlElement.cursorClick = value.ToCursorInfo();
		}
	}
}
