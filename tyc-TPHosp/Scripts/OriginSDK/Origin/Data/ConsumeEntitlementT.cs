using System.Xml.Serialization;

namespace Origin.Data
{
	public class ConsumeEntitlementT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public int Uses;

		[XmlAttribute]
		public bool bOveruse;

		[XmlElement]
		public EntitlementT Entitlement;
	}
}
