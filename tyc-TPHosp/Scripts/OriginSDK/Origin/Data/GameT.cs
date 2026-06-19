using System.Xml.Serialization;

namespace Origin.Data
{
	public class GameT
	{
		[XmlAttribute]
		public string contentID;

		[XmlAttribute]
		public float progressValue;

		[XmlAttribute]
		public ContentStateT state;

		[XmlAttribute]
		public string installedVersion;

		[XmlAttribute]
		public string availableVersion;

		[XmlAttribute]
		public string displayName;
	}
}
