using System.Xml.Serialization;

namespace Origin.Data
{
	public class SendGameMessageT
	{
		[XmlAttribute]
		public string GameId;

		[XmlAttribute]
		public string Message;
	}
}
