using System.Xml.Serialization;

namespace Origin.Data
{
	public class GameMessageEventT
	{
		[XmlAttribute]
		public string GameId;

		[XmlAttribute]
		public string Message;
	}
}
