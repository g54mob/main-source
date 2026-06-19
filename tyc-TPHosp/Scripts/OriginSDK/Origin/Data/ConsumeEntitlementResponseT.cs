using System.Xml.Serialization;

namespace Origin.Data
{
	public class ConsumeEntitlementResponseT
	{
		[XmlElement]
		public EntitlementT Entitlement;
	}
}
