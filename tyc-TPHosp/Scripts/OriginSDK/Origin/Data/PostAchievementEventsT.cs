using System.Collections.Generic;
using System.Xml.Serialization;

namespace Origin.Data
{
	public class PostAchievementEventsT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public ulong PersonaId;

		[XmlElement(ElementName = "Event")]
		public List<EventT> Events;
	}
}
