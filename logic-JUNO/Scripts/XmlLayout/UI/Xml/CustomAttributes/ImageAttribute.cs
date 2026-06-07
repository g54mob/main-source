using System.Text;

namespace UI.Xml.CustomAttributes
{
	public class ImageAttribute : CustomXmlAttribute
	{
		public override bool UsesConvertMethod => true;

		public override eAttributeGroup AttributeGroup => eAttributeGroup.Image;

		public override AttributeDictionary Convert(string value, AttributeDictionary elementAttributes, XmlElement xmlElement)
		{
			StringBuilder stringBuilder = new StringBuilder(value);
			stringBuilder.Replace(".png", string.Empty);
			stringBuilder.Replace(".jpg", string.Empty);
			stringBuilder.Replace(".jpeg", string.Empty);
			stringBuilder.Replace(".bmp", string.Empty);
			stringBuilder.Replace(".psd", string.Empty);
			AttributeDictionary attributeDictionary = new AttributeDictionary { 
			{
				"sprite",
				stringBuilder.ToString()
			} };
			if (!xmlElement.HasAttribute("color"))
			{
				attributeDictionary.Add("color", "white");
			}
			return attributeDictionary;
		}
	}
}
