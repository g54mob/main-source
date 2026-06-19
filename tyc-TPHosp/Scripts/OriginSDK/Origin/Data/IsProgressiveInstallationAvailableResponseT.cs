using System.Xml.Serialization;

namespace Origin.Data
{
	public class IsProgressiveInstallationAvailableResponseT
	{
		[XmlAttribute]
		public string ItemId;

		[XmlAttribute]
		public bool Available;
	}
}
