using System.Xml.Serialization;

namespace Origin.Data
{
	public class StartGameT
	{
		[XmlAttribute]
		public string GameId;

		[XmlAttribute]
		public string MultiplayerId;

		[XmlAttribute]
		public string CommandLine;
	}
}
