using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryEntitlementsResponseT
	{
		[XmlElement(ElementName = "Entitlement")]
		public List<EntitlementT> Entitlements;
	}
}
