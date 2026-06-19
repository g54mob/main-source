using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetConfigResponseT
	{
		[XmlElement(ElementName = "Service")]
		public List<ServiceT> Services;
	}
}
