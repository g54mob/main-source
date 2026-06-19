using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class QueryManifestResponseT
	{
		[XmlElement(ElementName = "Entitlement")]
		public List<EntitlementT> Entitlements;
	}
}
