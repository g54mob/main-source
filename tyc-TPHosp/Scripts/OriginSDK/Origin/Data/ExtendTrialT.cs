using System.Xml.Serialization;

namespace Origin.Data
{
	public class ExtendTrialT
	{
		[XmlAttribute]
		public ulong UserId;

		[XmlAttribute]
		public string RequestTicket;

		[XmlAttribute]
		public int TicketEngine;
	}
}
