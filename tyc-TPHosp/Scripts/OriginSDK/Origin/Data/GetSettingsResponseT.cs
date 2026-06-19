using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetSettingsResponseT
	{
		[XmlAttribute]
		public string Language;

		[XmlAttribute]
		public string Environment;

		[XmlAttribute]
		public bool IsIGOAvailable;

		[XmlAttribute]
		public bool IsIGOEnabled;

		[XmlAttribute]
		public bool IsTelemetryEnabled;

		[XmlAttribute]
		public bool IsManualOffline;
	}
}
