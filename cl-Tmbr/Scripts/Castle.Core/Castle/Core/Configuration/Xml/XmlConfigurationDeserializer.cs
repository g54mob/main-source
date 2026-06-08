using System.Text;
using System.Xml;

namespace Castle.Core.Configuration.Xml
{
	public class XmlConfigurationDeserializer
	{
		public IConfiguration Deserialize(XmlNode node)
		{
			return GetDeserializedNode(node);
		}

		public static string GetConfigValue(string value)
		{
			if (value == string.Empty)
			{
				return null;
			}
			return value;
		}

		public static IConfiguration GetDeserializedNode(XmlNode node)
		{
			ConfigurationCollection configurationCollection = new ConfigurationCollection();
			StringBuilder stringBuilder = new StringBuilder();
			if (node.HasChildNodes)
			{
				foreach (XmlNode childNode in node.ChildNodes)
				{
					if (IsTextNode(childNode))
					{
						stringBuilder.Append(childNode.Value);
					}
					else if (childNode.NodeType == XmlNodeType.Element)
					{
						configurationCollection.Add(GetDeserializedNode(childNode));
					}
				}
			}
			MutableConfiguration mutableConfiguration = new MutableConfiguration(node.Name, GetConfigValue(stringBuilder.ToString()));
			foreach (XmlAttribute attribute in node.Attributes)
			{
				mutableConfiguration.Attributes.Add(attribute.Name, attribute.Value);
			}
			mutableConfiguration.Children.AddRange(configurationCollection);
			return mutableConfiguration;
		}

		public static bool IsTextNode(XmlNode node)
		{
			if (node.NodeType != XmlNodeType.Text)
			{
				return node.NodeType == XmlNodeType.CDATA;
			}
			return true;
		}
	}
}
