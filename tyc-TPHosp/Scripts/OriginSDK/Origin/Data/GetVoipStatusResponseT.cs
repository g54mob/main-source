using System.Xml.Serialization;

namespace Origin.Data
{
	public class GetVoipStatusResponseT
	{
		[XmlAttribute]
		public bool Available;

		[XmlAttribute]
		public bool Active;
	}
}
