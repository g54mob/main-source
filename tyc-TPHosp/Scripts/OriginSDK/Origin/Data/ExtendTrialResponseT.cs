using System.Xml.Serialization;

namespace Origin.Data
{
	public class ExtendTrialResponseT
	{
		[XmlAttribute]
		public int Code;

		[XmlAttribute]
		public int TotalTimeRemaining;

		[XmlAttribute]
		public int TimeGranted;

		[XmlAttribute]
		public string ResponseTicket;

		[XmlAttribute]
		public int RetryCount;

		[XmlAttribute]
		public int RetryAfterFailSec;

		[XmlAttribute]
		public int ExtendBeforeExpireSec;

		[XmlAttribute]
		public int SleepBeforeNukeSec;
	}
}
