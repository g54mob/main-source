using System.Collections.Generic;
using System.Xml.Linq;

namespace Web.Client.Models.SimpleRockets
{
	public class ResourceInfoResult
	{
		public class ResourceInfo
		{
			public bool Exists => Size >= 0;

			public string FileName { get; set; }

			public string Hash { get; set; }

			public int NumRequirements { get; set; }

			public int Size { get; set; }

			public byte Type { get; set; }
		}

		private const string XmlTagName = "ResourceInfoResult";

		public List<ResourceInfo> Resources { get; private set; } = new List<ResourceInfo>();

		public ResourceInfoResult()
		{
		}

		public ResourceInfoResult(ClientResponse clientResponse)
		{
			LoadFromClientResponse(clientResponse.XmlResult?.Element("ResourceInfoResult"));
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("ResourceInfoResult");
			foreach (ResourceInfo resource in Resources)
			{
				xElement.Add(new XElement("Resource", (resource.FileName == null) ? null : new XAttribute("fileName", resource.FileName), new XAttribute("hash", resource.Hash), new XAttribute("size", resource.Size), new XAttribute("requirements", resource.NumRequirements), new XAttribute("type", resource.Type)));
			}
			return xElement;
		}

		private void LoadFromClientResponse(XElement element)
		{
			IEnumerable<XElement> enumerable = element?.Elements("Resource");
			if (enumerable == null)
			{
				return;
			}
			foreach (XElement item2 in enumerable)
			{
				ResourceInfo item = new ResourceInfo
				{
					FileName = (string)item2.Attribute("fileName"),
					Hash = (string)item2.Attribute("hash"),
					Size = (((int?)item2.Attribute("size")) ?? (-1)),
					NumRequirements = ((int?)item2.Attribute("requirements")).GetValueOrDefault(),
					Type = (byte)((int?)item2.Attribute("type")).GetValueOrDefault()
				};
				Resources.Add(item);
			}
		}
	}
}
