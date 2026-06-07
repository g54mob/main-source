using System.Xml.Linq;

namespace Web.Client.Models.SimpleRockets
{
	public class UploadSettingsModel
	{
		public const int CurrentVersion = 1;

		public int MaxIndividualFileSize { get; set; }

		public int MaxTotalFileSize { get; set; }

		public int Version { get; set; }

		public UploadSettingsModel()
		{
			Version = 1;
		}

		public UploadSettingsModel(string xmlString)
			: this(XElement.Parse(xmlString))
		{
		}

		public UploadSettingsModel(ClientResponse clientResponse)
			: this(clientResponse.XmlResult.Element("UploadSettings"))
		{
		}

		public UploadSettingsModel(XElement xml)
			: this()
		{
			Version = int.Parse(xml.Attribute("Version").Value);
			MaxIndividualFileSize = (int)xml.Attribute("maxIndividualFileSize");
			MaxTotalFileSize = (int)xml.Attribute("maxTotalFileSize");
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("UploadSettings");
			xElement.SetAttributeValue("Version", Version);
			xElement.SetAttributeValue("maxIndividualFileSize", MaxIndividualFileSize);
			xElement.SetAttributeValue("maxTotalFileSize", MaxTotalFileSize);
			return xElement;
		}
	}
}
