using System.Xml.Serialization;

namespace Origin.Data
{
	public class EntitlementT
	{
		[XmlAttribute]
		public string Type;

		[XmlAttribute]
		public string ItemId;

		[XmlAttribute]
		public string EntitlementId;

		[XmlAttribute]
		public string EntitlementTag;

		[XmlAttribute]
		public string Group;

		[XmlAttribute]
		public string ResourceId;

		[XmlAttribute]
		public int UseCount;

		[XmlAttribute]
		public string Expiration;

		[XmlAttribute]
		public string GrantDate;

		[XmlAttribute]
		public string LastModifiedDate;

		[XmlAttribute]
		public int Version;
	}
}
