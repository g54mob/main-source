using System.Xml;

namespace UI.Xml
{
	public static class XmlExtensions
	{
		public static AttributeDictionary ToAttributeDictionary(this XmlAttributeCollection attributes)
		{
			AttributeDictionary attributeDictionary = new AttributeDictionary();
			for (int i = 0; i < attributes.Count; i++)
			{
				attributeDictionary.Add(attributes[i].Name.ToLower(), attributes[i].Value);
			}
			return attributeDictionary;
		}

		public static AttributeDictionary GetAttributeDictionary(this XmlReader reader)
		{
			AttributeDictionary attributeDictionary = new AttributeDictionary();
			for (int i = 0; i < reader.AttributeCount; i++)
			{
				reader.MoveToNextAttribute();
				attributeDictionary.Add(reader.Name, reader.Value);
			}
			return attributeDictionary;
		}
	}
}
