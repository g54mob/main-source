using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryManifestT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string Manifest;
	}
}
