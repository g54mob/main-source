using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models.SimplePlanes
{
	public class PostNavigationModel
	{
		public class NavigationOption
		{
			public string Id { get; set; }

			public string Name { get; set; }

			public NavigationOption()
			{
			}

			public NavigationOption(string id, string name)
			{
				Id = id;
				Name = name;
			}
		}

		public List<NavigationOption> Links { get; private set; } = new List<NavigationOption>();

		public int MaxTagsAtOnce { get; set; } = 1;

		public List<NavigationOption> Tags { get; private set; } = new List<NavigationOption>();

		public PostNavigationModel()
		{
		}

		public PostNavigationModel(string xmlString)
			: this(XElement.Parse(xmlString))
		{
		}

		public PostNavigationModel(ClientResponse clientResponse)
			: this(clientResponse.XmlResult.Element("PostNavigation"))
		{
		}

		public PostNavigationModel(XElement xml)
			: this()
		{
			MaxTagsAtOnce = int.Parse(xml.Attribute("MaxTagsAtOnce").Value);
			DeserializeOptions(xml, Tags, "Tags");
			DeserializeOptions(xml, Links, "Links");
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("PostNavigation");
			xElement.SetAttributeValue("MaxTagsAtOnce", MaxTagsAtOnce);
			SerializeOptions(xElement, Tags, "Tags");
			SerializeOptions(xElement, Links, "Links");
			return xElement;
		}

		private void DeserializeOptions(XElement xml, List<NavigationOption> options, string containerName)
		{
			options.Clear();
			foreach (XElement item in xml.Element(containerName).Elements())
			{
				NavigationOption navigationOption = new NavigationOption();
				navigationOption.Id = item.Attribute("Id")?.Value;
				navigationOption.Name = item.Attribute("Name")?.Value;
				options.Add(navigationOption);
			}
		}

		private void SerializeOptions(XElement xml, List<NavigationOption> options, string containerName)
		{
			XElement xElement = new XElement(containerName);
			xml.Add(xElement);
			foreach (NavigationOption option in options)
			{
				XElement xElement2 = new XElement("Option");
				xElement2.SetAttributeValue("Id", option.Id);
				xElement2.SetAttributeValue("Name", option.Name);
				xElement.Add(xElement2);
			}
		}
	}
}
