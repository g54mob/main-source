using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class EventT
	{
		[XmlAttribute]
		public string EventId;

		[XmlElement(ElementName = "EventParam")]
		public List<EventParamT> Attributes;
	}
}
