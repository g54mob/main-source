using System.Xml.Serialization;
using Origin.Data;

namespace Origin
{
	public class LSX
	{
		[XmlElement(ElementName = "Request")]
		public Request request;

		[XmlElement(ElementName = "Response")]
		public Response response;

		[XmlElement(ElementName = "Event")]
		public Event evnt;
	}
}
