using System.Xml.Serialization;

namespace Origin.Data
{
	public class ChallengeT
	{
		[XmlAttribute]
		public string key;

		[XmlAttribute]
		public string version;

		[XmlAttribute]
		public string build;
	}
}
